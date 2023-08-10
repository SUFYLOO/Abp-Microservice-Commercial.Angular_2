using System;

namespace Resume.CompanyContracts;

[Serializable]
public class CompanyContractExcelDownloadTokenCacheItem
{
    public string Token { get; set; }
}