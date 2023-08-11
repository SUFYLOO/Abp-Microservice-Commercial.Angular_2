<# convert any simple XML document into an ordered hashtable. #>
function ConvertFrom-XML
{
	[CmdletBinding()]
	param
	(
		[Parameter(Mandatory = $true, ValueFromPipeline)]
		[System.Xml.XmlNode]$node,
		#we are working through the nodes

		[string]$Prefix = '',
		#do we indicate an attribute with a prefix?

		$ShowDocElement = $false #Do we show the document element? 
	)
	
	process
	{
		#if option set, we skip the Document element
		if ($node.DocumentElement -and !($ShowDocElement))
		{ $node = $node.DocumentElement }
		$oHash = [ordered] @{ } # start with an ordered hashtable.
		#The order of elements is always significant regardless of what they are
		write-verbose "calling with $($node.LocalName)"
		if ($node.Attributes -ne $null) #if there are elements
		# record all the attributes first in the ordered hash
		{
			$node.Attributes | foreach {
				$oHash.$($Prefix + $_.FirstChild.parentNode.LocalName) = $_.FirstChild.value
			}
		}
		# check to see if there is a pseudo-array. (more than one
		# child-node with the same name that must be handled as an array)
		$node.ChildNodes | #we just group the names and create an empty
		#array for each
		Group-Object -Property LocalName | where { $_.count -gt 1 } | select Name |
		foreach{
			write-verbose "pseudo-Array $($_.Name)"
			$oHash.($_.Name) = @() <# create an empty array for each one#>
		};
		foreach ($child in $node.ChildNodes)
		{
			#now we look at each node in turn.
			write-verbose "processing the '$($child.LocalName)'"
			$childName = $child.LocalName
			if ($child -is [system.xml.xmltext])
			# if it is simple XML text 
			{
				write-verbose "simple xml $childname";
				$oHash.$childname += $child.InnerText
			}
			# if it has a #text child we may need to cope with attributes
			elseif ($child.FirstChild.Name -eq '#text' -and $child.ChildNodes.Count -eq 1)
			{
				write-verbose "text";
				if ($child.Attributes -ne $null) #hah, an attribute
				{
					<#we need to record the text with the #text label and preserve all
					the attributes #>
					$aHash = [ordered]@{ };
					$child.Attributes | foreach {
						$aHash.$($_.FirstChild.parentNode.LocalName) = $_.FirstChild.value
					}
					#now we add the text with an explicit name
					$aHash.'#text' += $child.'#text'
					$oHash.$childname += $aHash
				}
				else
				{
					#phew, just a simple text attribute. 
					$oHash.$childname += $child.FirstChild.InnerText
				}
			}
			elseif ($child.'#cdata-section' -ne $null)
			# if it is a data section, a block of text that isnt parsed by the parser,
			# but is otherwise recognized as markup
			{
				write-verbose "cdata section";
				$oHash.$childname = $child.'#cdata-section'
			}
			elseif ($child.ChildNodes.Count -gt 1 -and
				($child | gm -MemberType Property).Count -eq 1)
			{
				$oHash.$childname = @()
				foreach ($grandchild in $child.ChildNodes)
				{
					$oHash.$childname += (ConvertFrom-XML $grandchild)
				}
			}
			else
			{
				# create an array as a value  to the hashtable element
				$oHash.$childname += (ConvertFrom-XML $child)
			}
		}
		$oHash
	}
}

# 先從 Azure App Service 取得發行設定檔 (Publish Profile)
$PublishProfile = 'JBResumeHttpApiHost.PublishSettings'

# 利用 ConvertFrom-XML.ps1 將 XML 轉為 DictionaryEntry 物件
$WebDeployProfiles = ([xml[]] (Get-Content -Raw $PublishProfile) | ConvertFrom-XML).publishProfile

# 篩選出 publishMethod 為 MSDeploy 的資訊
For ($i=0; $i -lt $WebDeployProfiles.Count; $i++) {
  If ($WebDeployProfiles[$i].publishMethod -eq 'MSDeploy') {
    $publishUrl   = $WebDeployProfiles[$i].publishUrl
    $msdeploySite = $WebDeployProfiles[$i].msdeploySite
    $userName     = $WebDeployProfiles[$i].userName
    $userPWD      = $WebDeployProfiles[$i].userPWD
  }
}

# 這裡要設定你實際想要部署到遠端站台的來源路徑
#$sourcePath = '$(System.DefaultWorkingDirectory)/yoursite-CI/drop'
$sourcePath = 'D:\Source\JBResume\aspnet-core\src\JBResume.HttpApi.Host\bin\Debug\net7.0'

# 我這裡假設你的 app_offline.template.htm 是 CI 的時候自動產生的
# 你當然也可以透過 Download secure file 上傳一個 app_offline.htm 檔案
$appOffline = $sourcePath + '\app_offline.template.htm'

# 部署 app_offline.htm 站台離線檔，避免 DLL 檔案被鎖定導致無法更版
. "C:\Program Files (x86)\IIS\Microsoft Web Deploy V3\msdeploy.exe" -verb:sync -source:contentPath=$appOffline -dest:contentPath=`"$msdeploySite/app_offline.htm`",computerName=`"https://$publishUrl/msdeploy.axd?site=$msdeploySite`",userName=`"$userName`",password=`"$userPWD`",authtype=`"Basic`",includeAcls=`"False`"

# 實際進行部署動作，最多重試 10 次！
. "C:\Program Files (x86)\IIS\Microsoft Web Deploy V3\msdeploy.exe" -verb:sync -source:contentPath=$sourcePath -dest:contentPath=`"$msdeploySite`",computerName=`"https://$publishUrl/msdeploy.axd?site=$msdeploySite`",userName=`"$userName`",password=`"$userPWD`",authtype=`"Basic`",includeAcls=`"False`" -retryAttempts:10 -retryInterval:3000 -enableRule:DoNotDeleteRule

# 移除 app_offline.htm 站台離線檔，讓網站恢復連線
. "C:\Program Files (x86)\IIS\Microsoft Web Deploy V3\msdeploy.exe" -verb:delete -dest:contentPath=$msdeploySite/app_offline.htm,computerName=`"https://$publishUrl/msdeploy.axd?site=$msdeploySite`",userName=`"$userName`",password=`"$userPWD`",authtype=`"Basic`",includeAcls=`"False`"





