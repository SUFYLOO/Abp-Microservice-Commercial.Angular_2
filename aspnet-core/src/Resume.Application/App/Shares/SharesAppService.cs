using Resume.App.Tools;
using Resume.App.Users;
using Resume.ShareCodes;
using Resume.ShareSendQueues;
using Resume.ShareUploads;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Org.BouncyCastle.Utilities;
using PayPalCheckoutSdk.Orders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Net.Mail;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Volo.Abp.MultiTenancy;

namespace Resume.App.Shares
{
    [RemoteService(IsEnabled = false)]

    public class SharesAppService : ApplicationService, ISharesAppService
    {
        //多鍵的優先順序：代碼鍵優先，再來是公司設定的優先，最後是傑報預設的設定

        private readonly AppService _appService;

        public SharesAppService(AppService appService)
        {
            _appService = appService;
        }

        public virtual async Task<TestDto> GetTest(string Id)
        {
            var Result = new TestDto();

            Result.Id = Id;
            Result.Name = "測試成功";

            return Result;
        }

        public virtual async Task<TestDto> PostTest(TestInput input)
        {
            var Result = new TestDto();
            Result.Id = input.Id;
            Result.Name = "測試成功 Name is:" + input.Name;

            return Result;
        }

        public virtual async Task<ResultDto<List<KeyValueDto>>> GetShareDefaultAsync(ShareDefaultInput input)
        {
            var Result = new ResultDto<List<KeyValueDto>>();
            Result.Data = new List<KeyValueDto>();
            Result.Version = "2023060601";

            var Key1 = input.Key1;
            var Key2 = input.Key2;
            var Key3 = input.Key3;
            var Id = input.Id;
            var GroupCode = input.GroupCode;

            var DateNow = DateTime.Now;

            var qrbShareDefault = await _appService._shareDefaultRepository.GetQueryableAsync();
            qrbShareDefault = qrbShareDefault.Where(c => c.DateA <= DateNow && DateNow <= c.DateD && c.Status == "1");

            var itemsShareDefault = qrbShareDefault.Where(c => c.Id == Id).ToList();
            if (itemsShareDefault.Count == 0)
                itemsShareDefault = qrbShareDefault.Where(c => c.Key1 == Key1 && c.Key2 == Key2 && c.GroupCode == GroupCode).ToList();
            if (itemsShareDefault.Count == 0)
                itemsShareDefault = qrbShareDefault.Where(c => c.Key1.Length == 0 && c.Key2 == Key2 && c.GroupCode == GroupCode).ToList();

            if (itemsShareDefault.Count == 0)
                using (_appService._dataFilter.Disable<IMultiTenant>())
                {
                    itemsShareDefault = qrbShareDefault.Where(c => c.Id == Id && c.TenantId == null).ToList();
                    if (itemsShareDefault.Count == 0)
                        itemsShareDefault = qrbShareDefault.Where(c => c.Key1 == Key1 && c.Key2 == Key2 && c.GroupCode == GroupCode && c.TenantId == null).ToList();
                    if (itemsShareDefault.Count == 0)
                        itemsShareDefault = qrbShareDefault.Where(c => c.Key1.Length == 0 && c.Key2 == Key2 && c.GroupCode == GroupCode && c.TenantId == null).ToList();
                }

            var items = (from c in itemsShareDefault
                         orderby c.Sort
                         select new KeyValueDto
                         {
                             Key = c.FieldKey,
                             Value = c.FieldValue,
                         }).ToList();

            Result.Data = items;
            Result.Save = items.Count > 0;
            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<ShareDefaultSystemDto>> GetShareDefaultSystemAsync(ShareDefaultSystemInput input)
        {
            var Result = new ResultDto<ShareDefaultSystemDto>();
            Result.Data = new ShareDefaultSystemDto();
            Result.Version = "2023060601";

            var GroupCode = "System";

            var inputShareDefault = new ShareDefaultInput();
            inputShareDefault.Key1 = input.Key1;
            inputShareDefault.Key2 = input.Key2;
            inputShareDefault.Key3 = input.Key3;
            inputShareDefault.Id = input.Id;
            inputShareDefault.GroupCode = GroupCode;
            var ResultShareDefault = await GetShareDefaultAsync(inputShareDefault);

            var dc = ResultShareDefault.Data.ToDictionary(p => p.Key, p => p.Value);
            Result.Data.Maintain = dc.ContainsKey("Maintain") ? Convert.ToBoolean(dc["Maintain"]) : true;
            Result.Data.Test = dc.ContainsKey("Test") ? Convert.ToBoolean(dc["Test"]) : true;
            Result.Data.DataMask = dc.ContainsKey("DataMask") ? Convert.ToBoolean(dc["DataMask"]) : true;
            Result.Data.UniversalAccountCode = dc.ContainsKey("UniversalAccountCode") ? dc["UniversalAccountCode"] : Guid.NewGuid().ToString();
            Result.Data.UniversalAccountPassword = dc.ContainsKey("UniversalAccountPassword") ? dc["UniversalAccountPassword"] : Guid.NewGuid().ToString();
            Result.Data.AdminMail = dc.ContainsKey("AdminMail") ? StringSplit.SplitStringToArray(dc["AdminMail"], ",").ToList() : new List<string>() { "ming@jbjob.com.tw" };
            Result.Data.TestMail = dc.ContainsKey("TestMail") ? StringSplit.SplitStringToArray(dc["TestMail"], ",").ToList() : new List<string>() { "ming@jbjob.com.tw" };
            Result.Data.TestAccountCode = dc.ContainsKey("TestAccountCode") ? dc["TestAccountCode"] : "admin";
            Result.Data.UrlValidMinutes = dc.ContainsKey("UrlValidMinutes") ? Convert.ToInt32(dc["UrlValidMinutes"]) : 10;
            Result.Data.DataCache = dc.ContainsKey("DataCache") ? Convert.ToBoolean(dc["DataCache"]) : true;
            Result.Data.InstantSend = dc.ContainsKey("InstantSend") ? Convert.ToBoolean(dc["InstantSend"]) : true;

            Result.Save = true;
            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<ShareDefaultUrlDto>> GetShareDefaultUrlAsync(ShareDefaultUrlInput input)
        {
            var Result = new ResultDto<ShareDefaultUrlDto>();
            Result.Data = new ShareDefaultUrlDto();
            Result.Version = "2023060601";

            var GroupCode = "Url";

            var inputShareDefault = new ShareDefaultInput();
            inputShareDefault.Key1 = input.Key1;
            inputShareDefault.Key2 = input.Key2;
            inputShareDefault.Key3 = input.Key3;
            inputShareDefault.Id = input.Id;
            inputShareDefault.GroupCode = GroupCode;
            var ResultShareDefault = await GetShareDefaultAsync(inputShareDefault);

            var dc = ResultShareDefault.Data.ToDictionary(p => p.Key, p => p.Value);
            Result.Data.LoginBackEnd = dc.ContainsKey("LoginBackEnd") ? dc["LoginBackEnd"] : "https://www.jbjob.com.tw";
            Result.Data.LoginFrontEnd = dc.ContainsKey("LoginFrontEnd") ? dc["LoginFrontEnd"] : "https://www.jbjob.com.tw";
            Result.Data.MainBackEnd = dc.ContainsKey("MainBackEnd") ? dc["MainBackEnd"] : "https://www.jbjob.com.tw";
            Result.Data.MainFrontEnd = dc.ContainsKey("MainFrontEnd") ? dc["MainFrontEnd"] : "https://www.jbjob.com.tw";
            Result.Data.NoPermission = dc.ContainsKey("NoPermission") ? dc["NoPermission"] : "https://www.jbjob.com.tw";
            Result.Data.NotifyAdmission = dc.ContainsKey("NotifyAdmission") ? dc["NotifyAdmission"] : "https://www.jbjob.com.tw";
            Result.Data.NotifyInterview = dc.ContainsKey("NotifyInterview") ? dc["NotifyInterview"] : "https://www.jbjob.com.tw";
            Result.Data.NotifyOnboard = dc.ContainsKey("NotifyOnboard") ? dc["NotifyOnboard"] : "https://www.jbjob.com.tw";
            Result.Data.PasswordForget = dc.ContainsKey("PasswordForget") ? dc["PasswordForget"] : "https://www.jbjob.com.tw";
            Result.Data.PasswordReset = dc.ContainsKey("PasswordReset") ? dc["PasswordReset"] : "https://www.jbjob.com.tw";
            Result.Data.Error = dc.ContainsKey("Error") ? dc["Error"] : "https://www.jbjob.com.tw";

            Result.Save = true;
            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<ShareDefaultMailDto>> GetShareDefaultMailAsync(ShareDefaultMailInput input)
        {
            var Result = new ResultDto<ShareDefaultMailDto>();
            Result.Data = new ShareDefaultMailDto();
            Result.Version = "2023060601";

            var GroupCode = "Mail";

            var inputShareDefault = new ShareDefaultInput();
            inputShareDefault.Key1 = input.Key1;
            inputShareDefault.Key2 = input.Key2;
            inputShareDefault.Key3 = input.Key3;
            inputShareDefault.Id = input.Id;
            inputShareDefault.GroupCode = GroupCode;
            var ResultShareDefault = await GetShareDefaultAsync(inputShareDefault);

            var dc = ResultShareDefault.Data.ToDictionary(p => p.Key, p => p.Value);
            Result.Data.Host = dc.ContainsKey("Host") ? dc["Host"] : "smtp.office365.com";
            Result.Data.Port = dc.ContainsKey("Port") ? Convert.ToInt32(dc["Port"]) : 587;
            Result.Data.UserId = dc.ContainsKey("UserId") ? dc["UserId"] : "service@jbjob.com.tw";
            Result.Data.Password = dc.ContainsKey("Password") ? dc["Password"] : "";
            Result.Data.IsNeedCredentials = dc.ContainsKey("IsNeedCredentials") ? Convert.ToBoolean(dc["IsNeedCredentials"]) : true;
            Result.Data.IsNeedSsl = dc.ContainsKey("IsNeedSsl") ? Convert.ToBoolean(dc["IsNeedSsl"]) : true;
            Result.Data.Sender = dc.ContainsKey("Sender") ? dc["Sender"] : "service@jbjob.com.tw";
            Result.Data.SenderName = dc.ContainsKey("SenderName") ? dc["SenderName"] : "Reply";
            Result.Data.EnableTestMode = dc.ContainsKey("EnableTestMode") ? Convert.ToBoolean(dc["EnableTestMode"]) : true;
            Result.Data.TestMail = dc.ContainsKey("TestMail") ? StringSplit.SplitStringToArray(dc["TestMail"], ",").ToList() : new List<string>() { "ming@jbjob.com.tw" };
            Result.Data.DisableSend = dc.ContainsKey("DisableSend") ? Convert.ToBoolean(dc["DisableSend"]) : true;
            Result.Data.Priority = dc.ContainsKey("Priority") ? Convert.ToInt32(dc["Priority"]) : 0;
            Result.Data.CredentialsType = dc.ContainsKey("CredentialsType") ? dc["CredentialsType"] : "3";
            Result.Data.MaxRetry = dc.ContainsKey("MaxRetry") ? Convert.ToInt32(dc["MaxRetry"]) : 3;
            Result.Data.Delay = dc.ContainsKey("Delay") ? Convert.ToInt32(dc["Delay"]) : 30;
            Result.Data.Subject = dc.ContainsKey("Subject") ? dc["Subject"] : "WorkFlowService";
            Result.Data.BodyHead = dc.ContainsKey("BodyHead") ? dc["BodyHead"] : "";
            Result.Data.BodyContent = dc.ContainsKey("BodyContent") ? dc["BodyContent"] : "";
            Result.Data.BodyFoot = dc.ContainsKey("BodyFoot") ? dc["BodyFoot"] : "";

            Result.Save = true;
            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<ShareDefaultGsmDto>> GetShareDefaultGsmAsync(ShareDefaultGsmInput input)
        {
            var Result = new ResultDto<ShareDefaultGsmDto>();
            Result.Data = new ShareDefaultGsmDto();
            Result.Version = "2023060601";

            var GroupCode = "Gsm";

            var inputShareDefault = new ShareDefaultInput();
            inputShareDefault.Key1 = input.Key1;
            inputShareDefault.Key2 = input.Key2;
            inputShareDefault.Key3 = input.Key3;
            inputShareDefault.Id = input.Id;
            inputShareDefault.GroupCode = GroupCode;
            var ResultShareDefault = await GetShareDefaultAsync(inputShareDefault);

            var dc = ResultShareDefault.Data.ToDictionary(p => p.Key, p => p.Value);
            Result.Data.Host = dc.ContainsKey("Host") ? dc["Host"] : "203.66.172.133";
            Result.Data.Port = dc.ContainsKey("Port") ? Convert.ToInt32(dc["Port"]) : 8001;
            Result.Data.UserId = dc.ContainsKey("UserId") ? dc["UserId"] : "10427";
            Result.Data.Password = dc.ContainsKey("Password") ? dc["Password"] : "";

            Result.Save = true;
            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<ShareDefaultOidcDto>> GetShareDefaultOidcAsync(ShareDefaultOidcInput input)
        {
            var Result = new ResultDto<ShareDefaultOidcDto>();
            Result.Data = new ShareDefaultOidcDto();
            Result.Version = "2023060601";

            var GroupCode = "Oidc";

            var inputShareDefault = new ShareDefaultInput();
            inputShareDefault.Key1 = input.Key1;
            inputShareDefault.Key2 = input.Key2;
            inputShareDefault.Key3 = input.Key3;
            inputShareDefault.Id = input.Id;
            inputShareDefault.GroupCode = GroupCode;
            var ResultShareDefault = await GetShareDefaultAsync(inputShareDefault);

            var dc = ResultShareDefault.Data.ToDictionary(p => p.Key, p => p.Value);
            Result.Data.Uri = dc.ContainsKey("Uri") ? dc["Uri"] : "https://localhost:44397/";
            Result.Data.ClientId = dc.ContainsKey("client_id") ? dc["client_id"] : "Resume_Swagger";
            Result.Data.ClientSecret = dc.ContainsKey("client_secret") ? dc["client_secret"] : "";
            Result.Data.Scope = dc.ContainsKey("scope") ? dc["scope"] : "offline_access Resume";
            Result.Data.GrantType = dc.ContainsKey("grant_type") ? dc["grant_type"] : "password";

            Result.Save = true;
            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<ShareDefaultOAuth2Dto>> GetShareDefaultOAuth2Async(ShareDefaultOAuth2Input input)
        {
            var Result = new ResultDto<ShareDefaultOAuth2Dto>();
            Result.Data = new ShareDefaultOAuth2Dto();
            Result.Version = "2023060601";

            var inputShareDefault = new ShareDefaultInput();
            inputShareDefault.Key1 = input.Key1;
            inputShareDefault.Key2 = input.Key2;
            inputShareDefault.Key3 = input.Key3;
            inputShareDefault.Id = input.Id;
            inputShareDefault.GroupCode = input.GroupCode;
            var ResultShareDefault = await GetShareDefaultAsync(inputShareDefault);

            var dc = ResultShareDefault.Data.ToDictionary(p => p.Key, p => p.Value);
            Result.Data.Scope = dc.ContainsKey("Scope") ? dc["Scope"] : "";
            Result.Data.RedirectUrl = dc.ContainsKey("RedirectUrl") ? dc["RedirectUrl"] : "";
            Result.Data.BindUrl = dc.ContainsKey("BindUrl") ? dc["BindUrl"] : "";
            Result.Data.ClientId = dc.ContainsKey("ClientId") ? dc["ClientId"] : "";
            Result.Data.ClientSecret = dc.ContainsKey("ClientSecret") ? dc["ClientSecret"] : "";
            Result.Data.TokenUrl = dc.ContainsKey("TokenUrl") ? dc["TokenUrl"] : "";
            Result.Data.UserInfoUrl = dc.ContainsKey("UserInfoUrl") ? dc["UserInfoUrl"] : "";
            Result.Data.AuthUrl = dc.ContainsKey("AuthUrl") ? dc["AuthUrl"] : "";

            Result.Save = true;
            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<ShareDefaultOAuth2Dto>> GetShareDefaultOAuth2GoogleAsync(ShareDefaultOAuth2GoogleInput input)
        {
            var Result = new ResultDto<ShareDefaultOAuth2Dto>();
            Result.Data = new ShareDefaultOAuth2Dto();
            Result.Version = "2023060601";

            var GroupCode = "OAuth2Google";

            var inputShareDefault = new ShareDefaultOAuth2Input();
            inputShareDefault.Key1 = input.Key1;
            inputShareDefault.Key2 = input.Key2;
            inputShareDefault.Key3 = input.Key3;
            inputShareDefault.Id = input.Id;
            inputShareDefault.GroupCode = GroupCode;
            Result = await GetShareDefaultOAuth2Async(inputShareDefault);

            Result.Save = true;
            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<ShareDefaultOAuth2Dto>> GetShareDefaultOAuth2FacebookAsync(ShareDefaultOAuth2FacebookInput input)
        {
            var Result = new ResultDto<ShareDefaultOAuth2Dto>();
            Result.Data = new ShareDefaultOAuth2Dto();
            Result.Version = "2023060601";

            var GroupCode = "OAuth2Facebook";

            var inputShareDefault = new ShareDefaultOAuth2Input();
            inputShareDefault.Key1 = input.Key1;
            inputShareDefault.Key2 = input.Key2;
            inputShareDefault.Key3 = input.Key3;
            inputShareDefault.Id = input.Id;
            inputShareDefault.GroupCode = GroupCode;
            Result = await GetShareDefaultOAuth2Async(inputShareDefault);

            Result.Save = true;
            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<ShareDefaultOAuth2Dto>> GetShareDefaultOAuth2LineAsync(ShareDefaultOAuth2LineInput input)
        {
            var Result = new ResultDto<ShareDefaultOAuth2Dto>();
            Result.Data = new ShareDefaultOAuth2Dto();
            Result.Version = "2023060601";

            var GroupCode = "OAuth2Line";

            var inputShareDefault = new ShareDefaultOAuth2Input();
            inputShareDefault.Key1 = input.Key1;
            inputShareDefault.Key2 = input.Key2;
            inputShareDefault.Key3 = input.Key3;
            inputShareDefault.Id = input.Id;
            inputShareDefault.GroupCode = GroupCode;
            Result = await GetShareDefaultOAuth2Async(inputShareDefault);

            Result.Save = true;
            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<List<ShareCode>>> GetShareCodeAsync(ShareCodeInput input)
        {
            var Result = new ResultDto<List<ShareCode>>();
            Result.Data = new List<ShareCode>();
            Result.Version = "2023060601";

            var Key1 = input.Key1;
            var Key2 = input.Key2;
            var Key3 = input.Key3;
            var Id = input.Id;
            var GroupCode = input.GroupCode;
            var ListGroupCode = input.ListGroupCode;
            var Display = input.Display;
            var AllForGroupCode = input.AllForGroupCode;

            var DateNow = DateTime.Now;

            var qrbShareCode = await _appService._shareCodeRepository.GetQueryableAsync();
            qrbShareCode = qrbShareCode.Where(c => c.DateA <= DateNow && DateNow <= c.DateD && (Display || c.Status == "1"));

            var itemsShareCode = qrbShareCode.Where(c => c.Id == Id).ToList();
            if (itemsShareCode.Count == 0 && AllForGroupCode)
                itemsShareCode = qrbShareCode.Where(c => (ListGroupCode.Contains(c.GroupCode) || c.GroupCode == GroupCode)).ToList();
            if (itemsShareCode.Count == 0)
                itemsShareCode = qrbShareCode.Where(c => c.Key1 == Key1 && c.Key2 == Key2 && (ListGroupCode.Contains(c.GroupCode) || c.GroupCode == GroupCode)).ToList();
            if (itemsShareCode.Count == 0)
                itemsShareCode = qrbShareCode.Where(c => c.Key1.Length == 0 && c.Key2 == Key2 && (ListGroupCode.Contains(c.GroupCode) || c.GroupCode == GroupCode)).ToList();

            if (itemsShareCode.Count == 0)
                using (_appService._dataFilter.Disable<IMultiTenant>())
                {
                    itemsShareCode = qrbShareCode.Where(c => c.Id == Id && c.TenantId == null).ToList();
                    if (itemsShareCode.Count == 0 && AllForGroupCode)
                        itemsShareCode = qrbShareCode.Where(c => (ListGroupCode.Contains(c.GroupCode) || c.GroupCode == GroupCode) && c.TenantId == null).ToList();
                    if (itemsShareCode.Count == 0)
                        itemsShareCode = qrbShareCode.Where(c => c.Key1 == Key1 && c.Key2 == Key2 && (ListGroupCode.Contains(c.GroupCode) || c.GroupCode == GroupCode) && c.TenantId == null).ToList();
                    if (itemsShareCode.Count == 0)
                        itemsShareCode = qrbShareCode.Where(c => c.Key1.Length == 0 && c.Key2 == Key2 && (ListGroupCode.Contains(c.GroupCode) || c.GroupCode == GroupCode) && c.TenantId == null).ToList();
                }

            var items = itemsShareCode.OrderBy(p => p.Sort).ToList();

            Result.Data = items;
            Result.Save = items.Count > 0;
            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<List<TextValueDto>>> GetShareCodeTextValueAsync(ShareCodeInput input)
        {
            var Result = new ResultDto<List<TextValueDto>>();
            Result.Data = new List<TextValueDto>();
            Result.Version = "2023060601";

            var inputShareCode = new ShareCodeInput();
            inputShareCode.Key1 = input.Key1;
            inputShareCode.Key2 = input.Key2;
            inputShareCode.Key3 = input.Key3;
            inputShareCode.Id = input.Id;
            inputShareCode.GroupCode = input.GroupCode;
            inputShareCode.ListGroupCode = new List<string>();
            inputShareCode.Display = input.Display;
            inputShareCode.AllForGroupCode = false;
            var ResultShareCode = await GetShareCodeAsync(inputShareCode);

            var items = (from c in ResultShareCode.Data
                         select new TextValueDto
                         {
                             Text = c.Name,
                             Value = c.Key3,
                             Sort = c.Sort.Value,
                         }).ToList();


            Result.Data = items;
            Result.Save = true;
            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<List<NameCodeDto>>> GetShareCodeNameCodeAsync(ShareCodeInput input)
        {
            var Result = new ResultDto<List<NameCodeDto>>();
            Result.Data = new List<NameCodeDto>();
            Result.Version = "2023041001";

            var inputShareCode = new ShareCodeInput();
            inputShareCode.Key1 = input.Key1;
            inputShareCode.Key2 = input.Key2;
            inputShareCode.Key3 = input.Key3;
            inputShareCode.Id = input.Id;
            inputShareCode.GroupCode = input.GroupCode;
            inputShareCode.ListGroupCode = input.ListGroupCode;
            inputShareCode.Display = input.Display;
            inputShareCode.AllForGroupCode = input.AllForGroupCode;
            var ResultShareCode = await GetShareCodeAsync(inputShareCode);

            var items = (from c in ResultShareCode.Data
                         orderby c.Sort
                         select new NameCodeDto
                         {
                             GroupCode = c.GroupCode,
                             ParentCode = c.Key2,
                             Name = c.Name,
                             Code = c.Key3,
                             Column1 = c.Column1,
                             Sort = c.Sort.Value,
                         }).ToList();


            Result.Data = items;
            Result.Save = true;
            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<List<NameCodeStandardDto>> GetShareCodeNameCodeAsync(ShareCodeGroupInput input)
        {
            var Result = new List<NameCodeStandardDto>();

            var inputShareCode = new ShareCodeInput();
            inputShareCode.Key1 = input.Key1;
            inputShareCode.Key2 = input.Key2;
            inputShareCode.Key3 = input.Key3;
            inputShareCode.Id = input.Id;
            inputShareCode.GroupCode = input.GroupCode;
            inputShareCode.ListGroupCode = input.ListGroupCode;
            inputShareCode.Display = input.Display;
            inputShareCode.AllForGroupCode = input.AllForGroupCode;
            var ResultShareCode = await GetShareCodeAsync(inputShareCode);

            var items = from c in ResultShareCode.Data
                        where c.Key2 != c.Key3 //如果前端資料沒有顯示，應該是受這影響，為解決無窮回圈
                        orderby c.Sort
                        select new NameCodeStandardDto
                        {
                            GroupCode = c.GroupCode,
                            ParentCode = c.Key2,
                            Name = c.Name,
                            Code = c.Key3,
                        };

            Result = items.ToList();

            return Result;
        }

        public virtual async Task<ResultDto<List<ShareCodeByGroupCodeDto>>> GetShareCodeByGroupCodeAsync(ShareCodeByGroupCodeInput input)
        {
            var Result = new ResultDto<List<ShareCodeByGroupCodeDto>>();
            Result.Data = new List<ShareCodeByGroupCodeDto>();
            Result.Version = "2023062701";

            var GroupCode = input.GroupCode;

            var DateNow = DateTime.Now;

            var inputShareCodeGroup = new ShareCodeGroupInput();
            inputShareCodeGroup.ListGroupCode.Add(GroupCode);
            var itemsShareCode = await GetShareCodeNameCodeAsync(inputShareCodeGroup);

            //尋找根節點
            var itemsRoot = itemsShareCode.Where(p => p.ParentCode.IsNullOrEmpty()).ToList();
            var items = GetSubItem(itemsShareCode, itemsRoot); ;

            Result.Data = items;
            Result.Save = true;
            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        private static List<ShareCodeByGroupCodeDto> GetSubItem(List<NameCodeStandardDto> itemsAll, List<NameCodeStandardDto> items)
        {
            var Result = new List<ShareCodeByGroupCodeDto>();

            foreach (var item in items)
            {
                var itemShareCodeByGroupCode = new ShareCodeByGroupCodeDto();
                itemShareCodeByGroupCode.Code = item.Code;
                itemShareCodeByGroupCode.Name = item.Name;
                itemShareCodeByGroupCode.disabled = false;  //固定false
                var itemsTemp = itemsAll.Where(p => p.ParentCode == item.Code).ToList();
                itemShareCodeByGroupCode.children = GetSubItem(itemsAll, itemsTemp);
                itemShareCodeByGroupCode.isLeaf = !itemsTemp.Any();    //有到最底 才需要變true
                Result.Add(itemShareCodeByGroupCode);
            }

            return Result;
        }

        public async Task<ResultDto> CheckGroupCode(ResultDto msg, List<GroupCodeConditions> conditions)
        {
            var inputShareCodeGroup = new ShareCodeGroupInput();

            foreach (var con in conditions)
                inputShareCodeGroup.ListGroupCode.Add(con.GroupCode);
            var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);

            foreach (var condition in conditions)
            {
                if (condition.AllowNull && condition.Code.IsNullOrEmpty())
                    continue;
                if (!itemsShareCode.Any(p => p.GroupCode == condition.GroupCode && p.Code == condition.Code))
                    msg.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = condition.ErrorMessage, Pass = false });
            }

            return msg;
        }

        public virtual void SetShareCodeAsync<T>(SetShareCodeInput input)
        {
            var Data = input.Data;
            var Items = (List<T>)Data;
            var ListColumns = input.ListColumns;
            var ListShareCode = input.ListShareCode;

            foreach (var col in ListColumns)
            {
                var GroupCode = col.GroupCode;
                var ColumnCode = col.Code;
                var ColumnName = col.Name;

                foreach (var item in Items)
                {
                    var ValueCode = DataAccess.GetProperty<string>(item, ColumnCode);
                    var ValueName = "";// DataAccess.GetProperty<string>(item, ColumnName);
                    var Value = ListShareCode.FirstOrDefault(p => p.GroupCode == GroupCode && p.Code == ValueCode)?.Name ?? ValueName;

                    DataAccess.SetProperty(item, ColumnName, Value);
                }
            }
        }

        /// <summary>
        /// 檢查ShareCode 是否存在
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public virtual async Task<bool> CheckShareCodeAsync(CheckShareCodeInput input)
        {
            var Result = false;

            var Key1 = input.Key1;
            var Key2 = input.Key2;
            var Key3 = input.Key3;
            var ListKey3 = input.ListKey3;
            var Id = input.Id;
            var GroupCode = input.GroupCode;
            var Display = input.Display;

            var DateNow = DateTime.Now;

            var items = await _appService._shareCodeRepository.GetQueryableAsync();
            if (items.Any(p => p.Id == Id))
                Result = true;
            else
            {
                items = items.Where(p => p.GroupCode == GroupCode);

                if (items.Any(c => c.Key1 == Key1 && (c.Key3 == Key3 || ListKey3.Contains(c.Key3))))
                    Result = true;
                else
                    Result = items.Any(c => c.Key1.Length == 0 && (c.Key3 == Key3 || ListKey3.Contains(c.Key3)));
            }

            return Result;
        }

        public virtual async Task<ResultDto<SendShareSendQueueDto>> SendShareSendQueueAsync(SendShareSendQueueInput input)
        {
            var Result = new ResultDto<SendShareSendQueueDto>();
            Result.Data = new SendShareSendQueueDto();
            Result.Version = "2023032001";

            //取得樣版(主旨及內文) 及 陳述式
            //把陳述式轉換成實體資料表
            //置換主旨及內文

            var Key1 = input.Key1;
            var Key2 = input.Key2;
            var Key3 = input.Key3;
            var Id = input.Id;
            var RowIndex = input.RowIndex;
            var Where = input.Where;
            var InstantSend = input.InstantSend;    //即時發送
            var dcParameter = input.dcParameter;
            var dcParameterSql = input.dcParameterSql;
            var ListToMail = input.ListToMail;
            var ListToGsm = input.ListToGsm;
            var SendTypeCode = input.SendTypeCode;

            var DateNow = DateTime.Now;

            var qrbShareMessageTpl = await _appService._shareMessageTplRepository.GetQueryableAsync();
            var qrShareMessageTpl = from c in qrbShareMessageTpl
                                    where c.Id == Id
                                    select c;
            if (!qrShareMessageTpl.Any())
                qrShareMessageTpl = from c in qrbShareMessageTpl
                                    where c.Key1 == Key1 && c.Key2 == Key2 && c.Key3 == Key3
                                    select c;
            if (!qrShareMessageTpl.Any())
                qrShareMessageTpl = from c in qrbShareMessageTpl
                                    where c.Key2 == Key2 && c.Key3 == Key3
                                    select c;

            qrShareMessageTpl = from c in qrShareMessageTpl
                                where c.DateA <= DateNow && DateNow <= c.DateD
                                select c;

            var itemShareMessageTpl = await AsyncExecuter.FirstOrDefaultAsync(qrShareMessageTpl);

            if (itemShareMessageTpl == null)
            {
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "找不到樣版資訊" });
            }
            else
            {
                var TitleContents = itemShareMessageTpl.TitleContents;
                var ContentMail = itemShareMessageTpl.ContentMail;
                var ContentSMS = itemShareMessageTpl.ContentSMS;
                var Statement = itemShareMessageTpl.Statement;

                List<SqlParameter> ListParameter = null;
                if (dcParameterSql != null && dcParameterSql.Count > 0)
                {
                    ListParameter = new List<SqlParameter>();
                    foreach (var dc in dcParameterSql)
                        ListParameter.Add(new SqlParameter(("@" + dc.Key), dc.Value));
                }

                if (Statement.Length > 0)
                {
                    if (!Where)
                        Statement = Statement.Substring(0, Statement.ToUpper().IndexOf("WHERE 1 = 1"));
                    var builder = new ConfigurationBuilder()
                          .SetBasePath(Directory.GetCurrentDirectory())
                          .AddJsonFile("appsettings.json");
                    var config = builder.Build();
                    string ConnectionString = config["ConnectionStrings:Default"];
                    SqlConnection conn = new SqlConnection(ConnectionString);
                    var dt = SqlTools.GetSqlDataTable(conn, Statement, ListParameter);

                    if (dt.Rows.Count >= (RowIndex + 1))
                    {
                        var row = dt.Rows[RowIndex];

                        foreach (DataColumn dc in dt.Columns)
                        {
                            var ColumnName = dc.ColumnName;
                            var Column = "{{" + ColumnName + "}}";
                            var Value = row[ColumnName].ToString();

                            if (TitleContents.IndexOf(Column) >= 0)
                                TitleContents = TitleContents.Replace(Column, Value);

                            if (ContentMail.IndexOf(Column) >= 0)
                                ContentMail = ContentMail.Replace(Column, Value);

                            if (ContentSMS.IndexOf(Column) >= 0)
                                ContentSMS = ContentSMS.Replace(Column, Value);
                        }
                    }
                }

                //特別定義的變數
                var inputShareCode = new ShareCodeInput();
                inputShareCode.GroupCode = "MailVarDefine";
                var rsShareCode = await GetShareCodeNameCodeAsync(inputShareCode);
                if (rsShareCode != null && rsShareCode.Data.Count > 0)
                {
                    foreach (var rShareCode in rsShareCode.Data)
                    {
                        var ColumnName = rShareCode.Code;
                        var Column = "{{" + ColumnName + "}}";
                        var Value = await GetMailVarDefine(ColumnName, "");

                        //由外部參數傳過來
                        if (dcParameter.ContainsKey(ColumnName))
                            Value = dcParameter[ColumnName];

                        if (TitleContents.IndexOf(Column) >= 0)
                            TitleContents = TitleContents.Replace(Column, Value);

                        if (ContentMail.IndexOf(Column) >= 0)
                            ContentMail = ContentMail.Replace(Column, Value);

                        if (ContentSMS.IndexOf(Column) >= 0)
                            ContentSMS = ContentSMS.Replace(Column, Value);
                    }
                }

                if (SendTypeCode != SendType.None)
                {
                    //傳送到信箱
                    if (SendTypeCode == SendType.All || SendTypeCode == SendType.Mail)
                    {
                        //取得系統設定資訊
                        var inputShareDefaultMail = new ShareDefaultMailInput();
                        var rsShareDefaultMail = await GetShareDefaultMailAsync(inputShareDefaultMail);
                        if (rsShareDefaultMail != null && rsShareDefaultMail.Data != null)
                        {
                            var rMail = rsShareDefaultMail.Data;

                            string Host = rMail.Host;
                            int Port = rMail.Port;
                            string CredentialsType = rMail.CredentialsType;
                            MailAddress Sender = new MailAddress(rMail.Sender, rMail.SenderName);
                            bool IsNeedCredentials = rMail.IsNeedCredentials;
                            bool IsNeedSsl = rMail.IsNeedSsl;
                            int Priority = rMail.Priority;
                            string UserId = rMail.UserId;
                            string Password = rMail.Password;
                            bool EnableTestMode = rMail.EnableTestMode;
                            List<string> TestMail = rMail.TestMail;

                            foreach (var ToAddr in ListToMail)
                            {
                                if (ToAddr.Length == 0)
                                    continue;

                                var rShareSendQueue = new ShareSendQueue();
                                rShareSendQueue.Key1 = Key1;
                                rShareSendQueue.Key2 = Key2;
                                rShareSendQueue.Key3 = Key3;
                                rShareSendQueue.SendTypeCode = "01";
                                rShareSendQueue.FromAddr = rMail.Sender;
                                rShareSendQueue.ToAddr = ToAddr;
                                rShareSendQueue.TitleContents = TitleContents;
                                rShareSendQueue.Contents = ContentMail;
                                rShareSendQueue.Retry = 0;
                                rShareSendQueue.Sucess = false;
                                rShareSendQueue.Suspend = false;
                                rShareSendQueue.DateSend = DateTime.Now;
                                rShareSendQueue.ExtendedInformation = "";
                                rShareSendQueue.DateA = new DateTime(1900, 1, 1);
                                rShareSendQueue.DateD = new DateTime(9999, 12, 31);
                                rShareSendQueue.Sort = 9;
                                rShareSendQueue.Note = "";
                                rShareSendQueue.Status = "1";

                                if (InstantSend)
                                {
                                    var mailAddress = new MailAddress(ToAddr, ToAddr);
                                    Send.Mail.Send(Host, Port, CredentialsType, Sender, IsNeedCredentials, IsNeedSsl, Priority, UserId, Password, mailAddress, TitleContents, ContentMail);
                                    rShareSendQueue.Sucess = true;
                                }

                                await _appService._shareSendQueueRepository.InsertAsync(rShareSendQueue);
                                Result.Save = true;
                            }
                        }
                    }

                    //傳送到手機
                    if (SendTypeCode == SendType.All || SendTypeCode == SendType.Gsm)
                    {
                        //取得系統設定資訊
                        var inputShareDefaultGsm = new ShareDefaultGsmInput();
                        var rsShareDefaultGsm = await GetShareDefaultGsmAsync(inputShareDefaultGsm);
                        if (rsShareDefaultGsm != null && rsShareDefaultGsm.Data != null)
                        {
                            var rGsm = rsShareDefaultGsm.Data;

                            string Host = rGsm.Host;
                            int Port = rGsm.Port;
                            string UserId = rGsm.UserId;
                            string Password = rGsm.Password;

                            var oSMSSend = new SMSSend(Host, Port, UserId, Password);

                            foreach (var ToAddr in ListToGsm)
                            {
                                if (ToAddr.Length == 0)
                                    continue;

                                var rShareSendQueue = new ShareSendQueue();
                                rShareSendQueue.Key1 = Key1;
                                rShareSendQueue.Key2 = Key2;
                                rShareSendQueue.Key3 = Key3;
                                rShareSendQueue.SendTypeCode = "02";
                                rShareSendQueue.FromAddr = "";
                                rShareSendQueue.ToAddr = ToAddr;
                                rShareSendQueue.TitleContents = TitleContents;
                                rShareSendQueue.Contents = ContentMail;
                                rShareSendQueue.Retry = 0;
                                rShareSendQueue.Sucess = false;
                                rShareSendQueue.Suspend = false;
                                rShareSendQueue.DateSend = DateTime.Now;
                                rShareSendQueue.ExtendedInformation = "";
                                rShareSendQueue.DateA = new DateTime(1900, 1, 1);
                                rShareSendQueue.DateD = new DateTime(9999, 12, 31);
                                rShareSendQueue.Sort = 9;
                                rShareSendQueue.Note = "";
                                rShareSendQueue.Status = "1";

                                if (InstantSend)
                                {
                                    //ContentSMS = UrlEncodDecode.UrlEncode(ContentSMS, Encoding.GetEncoding("big5") , false);
                                    oSMSSend.submitMessage(ToAddr, ContentSMS);
                                    rShareSendQueue.Sucess = true;
                                }

                                await _appService._shareSendQueueRepository.InsertAsync(rShareSendQueue);
                                Result.Save = true;
                            }
                        }
                    }
                }
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<SaveShareUploadDto>> SaveShareUploadAsync(SaveShareUploadInput input)
        {
            var Result = new ResultDto<SaveShareUploadDto>();
            Result.Data = new SaveShareUploadDto();
            Result.Version = "2023040601";

            var DateNow = DateTime.Now;

            var UserId = CurrentUser.Id.ToString();
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;

            var Key1 = input.Key1 ?? ""; //為那個資料表
            var Key2 = input.Key2 ?? ""; //資料表分類，可能來自於ShareCode
            var Key3 = input.Key3 ?? ""; //資料表Id代碼
            var Id = input.Id;  //如果要上傳多個檔案 此為空白
            input.inputWithStream.Name = Guid.NewGuid().ToString(); //強制更改name，使其變為可重複上傳
            var Content = input.inputWithStream;

            //var itemsResumeMain = (await _appService._resumeMainRepository.GetListAsync(userMainId: UserMainId));
            //var ListResumeMainId = itemsResumeMain.Select(p => p.Id);

            Guid? DirectoryId = null;
            var AllowUpload = false;
            {
                var itemDirectoryDescriptor = await _appService._directoryDescriptorRepository.FindAsync(Key1);
                if (itemDirectoryDescriptor == null)
                    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "找不到對應的資料夾", Pass = false });
                else
                {
                    DirectoryId = itemDirectoryDescriptor.Id;
                    AllowUpload = true;

                    //if (Key1 == "ResumeMain")
                    //{
                    //    var ResumeMainId = Guid.Parse(Key3);
                    //    var Any = itemsResumeMain.Any(p => p.Id == ResumeMainId);
                    //    if (!Any)
                    //        Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "找不到履歷資料", Pass = false });
                    //}

                    //if (Key1 == "ResumeWorks")
                    //{
                    //    var ResumeWorksId = Guid.Parse(Key3);
                    //    var items = await _appService._resumeWorksRepository.GetQueryableAsync();
                    //    var Any = items.Any(c => ListResumeMainId.Contains(c.ResumeMainId) && c.Id == ResumeWorksId);
                    //    if (!Any)
                    //        Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "找不到附件資料", Pass = false });
                    //}
                }
            }

            if (Result.Messages.Count == 0 && AllowUpload)
            {
                var items = await _appService._shareUploadRepository.GetQueryableAsync();
                var item = items.FirstOrDefault(p => p.Key1 == Key1 && p.Key2 == Key2 && p.Key3 == Key3 && p.Id == Id);

                //強制重新上傳 重新取得id
                var iFileDescriptor = await _appService._fileDescriptorAppService.CreateAsync(DirectoryId, Content);
                var FileDescriptorId = iFileDescriptor.Id;
                var ServerName = FileDescriptorId.ToString();

                if (item == null)
                {
                    item = new ShareUpload();
                    await _appService._shareUploadRepository.InsertAsync(item);
                    item.Status = "1";

                }
                else
                {
                    //檔案存在 必需刪除 一律刪除
                    FileDescriptorId = Guid.Parse(item.ServerName);
                    await _appService._fileDescriptorAppService.DeleteAsync(FileDescriptorId);

                    await _appService._shareUploadRepository.UpdateAsync(item);
                }

                item.Key1 = Key1;
                item.Key2 = Key2;
                item.Key3 = Key3;
                item.UploadName = Content.File.FileName;
                item.ServerName = ServerName;
                //item.Blob = new byte();
                item.Type = Content.File.ContentType;
                item.Size = Convert.ToInt32(Content.File.ContentLength);
                item.SystemUse = false;
                item.ExtendedInformation = input.ExtendedInformation ?? "";
                item.DateA = new DateTime(1900, 1, 1).Date;
                item.DateD = new DateTime(9999, 1, 1).Date;
                item.Sort = 9;
                item.Note = input.Note ?? "";

                var Data = ObjectMapper.Map<ShareUpload, SaveShareUploadDto>(item);

                Result.Data = Data;
                Result.Data.Pass = true;
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<List<ShareUploadsDto>>> GetShareUploadListAsync(ShareUploadListInput input)
        {
            var Result = new ResultDto<List<ShareUploadsDto>>();
            Result.Data = new List<ShareUploadsDto>();
            Result.Version = "2023040701";

            var DateNow = DateTime.Now;

            var CurrentTenantName = CurrentTenant.Name;
            var UserId = CurrentUser.Id.ToString();
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;

            var Key1 = input.Key1 ?? ""; //為那個資料表
            var Key2 = input.Key2 ?? ""; //資料表分類，可能來自於ShareCode
            var Key3 = input.Key3 ?? ""; //資料表Code代碼

            var itemsAllResumeMain = await _appService._resumeMainRepository.GetQueryableAsync();
            var itemsResumeMain = itemsAllResumeMain.Where(p => p.UserMainId == UserMainId).ToList();
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //如果是管理者
            if (SystemUserRoleKeys <= 8 && CurrentTenantName != "User")
            {
                var itemsAllCompanyInvitations = await _appService._companyInvitationsRepository.GetQueryableAsync();
                var ListUserMainCode = itemsAllCompanyInvitations.Select(p => p.UserMainId).ToList();
                itemsResumeMain = itemsAllResumeMain.Where(p => ListUserMainCode.Contains(p.UserMainId)).ToList();
            }

            var ListResumeMainId = itemsResumeMain.Select(p => p.Id);

            using (_appService._dataFilter.Disable<IMultiTenant>())
            {
                var AllowDownload = false;
                {
                    if (Key1 == "ResumeMain")
                    {
                        AllowDownload = true;
                        var ResumeMainId = Guid.Parse(Key3);
                        var Any = itemsResumeMain.Any(p => p.Id == ResumeMainId);
                        if (!Any)
                            Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "找不到履歷資料" });
                    }

                    if (Key1 == "ResumeWorks")
                    {
                        AllowDownload = true;
                        var ResumeWorksId = Guid.Parse(Key3);
                        var items = await _appService._resumeWorksRepository.GetQueryableAsync();
                        var Any = items.Any(c => ListResumeMainId.Contains(c.ResumeMainId) && c.Id == ResumeWorksId);

                        if (!Any)
                            Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "找不到附件資料" });
                    }
                }

                if (Result.Messages.Count == 0 && AllowDownload)
                {
                    var itemsAll = await _appService._shareUploadRepository.GetQueryableAsync();
                    var items = itemsAll.Where(p => p.Key1 == Key1 && p.Key2 == Key2 && p.Key3 == Key3).ToList();

                    var Data = ObjectMapper.Map<List<ShareUpload>, List<ShareUploadsDto>>(items);
                    foreach (var item in Data)
                        item.FileDescriptorId = Guid.Parse(item.ServerName);

                    Result.Data = Data;
                }
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<IRemoteStreamContent> DownloadShareUploadAsync(DownloadShareUploadInput input)
        {
            var Result = await Task.FromResult((IRemoteStreamContent)new RemoteStreamContent(new MemoryStream()));

            var DateNow = DateTime.Now;

            var Pass = true;

            var CurrentTenantName = CurrentTenant.Name;
            var UserId = CurrentUser.Id.ToString();
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            var FileDescriptorId = input.FileDescriptorId;
            var ServerName = FileDescriptorId.ToString();

            var itemsAllShareUpload = await _appService._shareUploadRepository.GetQueryableAsync();
            var itemShareUpload = itemsAllShareUpload.FirstOrDefault(p => p.ServerName == ServerName);

            if (itemShareUpload == null)
            {
                Pass = false;
                //Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "找不到上傳主檔" });
            }
            else
            {
                var Key1 = itemShareUpload.Key1 ?? ""; //為那個資料表
                var Key2 = itemShareUpload.Key2 ?? ""; //資料表分類，可能來自於ShareCode
                var Key3 = itemShareUpload.Key3 ?? ""; //資料表Code代碼
                var Id = itemShareUpload.Id;    //如果要上傳多個檔案 此為空白

                var itemsAllResumeMain = await _appService._resumeMainRepository.GetQueryableAsync();
                var itemsResumeMain = itemsAllResumeMain.Where(p => p.UserMainId == UserMainId).ToList();

                using (_appService._dataFilter.Disable<IMultiTenant>())
                {
                    //如果是管理者
                    if (SystemUserRoleKeys <= 8 && CurrentTenantName != "User")
                    {
                        var itemsAllCompanyInvitations = await _appService._companyInvitationsRepository.GetQueryableAsync();
                        var ListUserMainId = itemsAllCompanyInvitations.Select(p => p.UserMainId).ToList();
                        itemsResumeMain = itemsAllResumeMain.Where(p => ListUserMainId.Contains(p.UserMainId)).ToList();
                    }

                    var ListResumeMainId = itemsResumeMain.Select(p => p.Id);

                    var AllowDownload = false;
                    {
                        if (Key1 == "ResumeMain")
                        {
                            AllowDownload = true;
                            var ResumeMainId = Guid.Parse(Key3);
                            var Any = itemsResumeMain.Any(p => p.Id == ResumeMainId);
                            if (!Any)
                                Pass = false;
                            //Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "找不到履歷資料" });
                        }

                        if (Key1 == "ResumeWorks")
                        {
                            AllowDownload = true;
                            var ResumeWorksId = Guid.Parse(Key3);
                            var items = await _appService._resumeWorksRepository.GetQueryableAsync();
                            var Any = items.Any(c => ListResumeMainId.Contains(c.ResumeMainId) && c.Id == ResumeWorksId);

                            if (!Any)
                                Pass = false;
                            //Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "找不到附件資料" });
                        }
                    }

                    if (Pass && AllowDownload)
                    {
                        var token = await _appService._fileDescriptorAppService.GetDownloadTokenAsync(FileDescriptorId);

                        if (token != null)
                        {
                            var Content = default(IRemoteStreamContent);

                            //有資安的風險 應該要判斷租戶是否有這個使用者的存取權限
                            if (SystemUserRoleKeys <= 8)
                                using (_appService._dataFilter.Disable<IMultiTenant>())
                                    Content = await _appService._fileDescriptorAppService.DownloadAsync(FileDescriptorId, token.Token);
                            else
                                Content = await _appService._fileDescriptorAppService.DownloadAsync(FileDescriptorId, token.Token);

                            string FileName = itemShareUpload.UploadName;
                            Result = new RemoteStreamContent(Content.GetStream(), FileName, Content.ContentType);
                        }
                    }
                }
            }

            return Result;
        }

        //public virtual async Task<ResultDto<DownloadShareUploadDto>> DownloadShareUploadAsync(DownloadShareUploadInput input)
        //{
        //    var Result = new ResultDto<DownloadShareUploadDto>();
        //    Result.Data = new DownloadShareUploadDto();
        //    Result.Version = "2023040701";

        //    var DateNow = DateTime.Now;

        //    var CurrentTenantName = CurrentTenant.Name;
        //    var UserId = CurrentUser.Id.ToString();
        //    var UserMainCode = _appService._serviceProvider.GetService<UsersAppService>().UserMainCode;
        //    var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

        //    var FileDescriptorId = input.FileDescriptorId;
        //    var ServerName = FileDescriptorId.ToString();

        //    var itemsAllShareUpload = await _appService._shareUploadRepository.GetQueryableAsync();
        //    var itemShareUpload = itemsAllShareUpload.FirstOrDefault(p => p.ServerName == ServerName);
        //    if (itemShareUpload == null)
        //    {
        //        Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "找不到上傳主檔" });
        //    }
        //    else
        //    {
        //        var Key1 = itemShareUpload.Key1 ?? ""; //為那個資料表
        //        var Key2 = itemShareUpload.Key2 ?? ""; //資料表分類，可能來自於ShareCode
        //        var Key3 = itemShareUpload.Key3 ?? ""; //資料表Code代碼
        //        var Code = itemShareUpload.Code ?? "";    //如果要上傳多個檔案 此為空白

        //        var itemsAllResumeMain = await _appService._resumeMainRepository.GetQueryableAsync();
        //        var itemsResumeMain = itemsAllResumeMain.Where(p => p.UserMainCode == UserMainCode).ToList();

        //        //如果是管理者
        //        if (SystemUserRoleKeys <= 8 && CurrentTenantName != "User")
        //        {
        //            var itemsAllCompanyInvitations = await _appService._companyInvitationsRepository.GetQueryableAsync();
        //            var ListUserMainCode = itemsAllCompanyInvitations.Select(p => p.UserMainCode).ToList();
        //            itemsResumeMain = itemsAllResumeMain.Where(p => ListUserMainCode.Contains(p.UserMainCode)).ToList();
        //        }

        //        var ListResumeMainCode = itemsResumeMain.Select(p => p.Code);

        //        using (_appService._dataFilter.Disable<IMultiTenant>())
        //        {
        //            var AllowDownload = false;
        //            {
        //                if (Key1 == "ResumeMain")
        //                {
        //                    AllowDownload = true;
        //                    var ResumeMainCode = Key3;
        //                    var Any = itemsResumeMain.Any(p => p.Code == ResumeMainCode);
        //                    if (!Any)
        //                        Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "找不到履歷資料" });
        //                }

        //                if (Key1 == "ResumeWorks")
        //                {
        //                    AllowDownload = true;
        //                    var ResumeWorksCode = Key3;
        //                    var items = await _appService._resumeWorksRepository.GetQueryableAsync();
        //                    var Any = items.Any(c => ListResumeMainCode.Contains(c.ResumeMainCode) && c.Code == ResumeWorksCode);

        //                    if (!Any)
        //                        Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "找不到附件資料" });
        //                }
        //            }

        //            if (Result.Messages.Count == 0 && AllowDownload)
        //            {
        //                var token = await _appService._fileDescriptorAppService.GetDownloadTokenAsync(FileDescriptorId);

        //                if (token != null)
        //                {
        //                    Result.Data.FileName = itemShareUpload.UploadName;
        //                    Result.Data.RemoteStreamContent = await _appService._fileDescriptorAppService.DownloadAsync(FileDescriptorId, token.Token);
        //                }
        //            }
        //        }
        //    }

        //    Result.Check = Result.Messages.Count == 0;

        //    return Result;
        //}

        /// <summary>
        /// 取得系統共用參數
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public async Task<string> GetMailVarDefine(string Code, string Parm = "")
        {
            var Vdb = "";

            switch (Code)
            {
                case "NowDate":
                    Vdb = DateTime.Now.ToShortDateString();
                    break;
                case "NowDateTime":
                    Vdb = DateTime.Now.ToString();
                    break;
                case "LgoinUrl":
                    {
                        var input = new ShareDefaultUrlInput();
                        input.Key1 = CurrentTenant.Id == null ? "" : CurrentTenant.Id.ToString();
                        var item = await GetShareDefaultUrlAsync(input);
                        if (item != null && item.Messages.Count == 0 && item.Data != null)
                            Vdb = item.Data.LoginFrontEnd;
                    }
                    break;
                case "ResetPasswordUrl":
                    {
                        var input = new ShareDefaultUrlInput();
                        input.Key1 = CurrentTenant.Id == null ? "" : CurrentTenant.Id.ToString();
                        var item = await GetShareDefaultUrlAsync(input);
                        if (item != null && item.Messages.Count == 0 && item.Data != null)
                            Vdb = item.Data.PasswordReset;
                    }
                    break;
                case "NotifyAdmission":
                    {
                        var input = new ShareDefaultUrlInput();
                        input.Key1 = CurrentTenant.Id == null ? "" : CurrentTenant.Id.ToString();
                        var item = await GetShareDefaultUrlAsync(input);
                        if (item != null && item.Messages.Count == 0 && item.Data != null)
                            Vdb = item.Data.NotifyAdmission;
                    }
                    break;
                case "MainUrl":
                case "MainValidUrl":
                    {
                        //var oShareDefault = new ShareDefaultDao(dcShare);
                        //var r = oShareDefault.DefaultSystem;
                        //var req = HttpContext.Current.Request;
                        //var Path = req.Url.Scheme + "://" + req.Url.Host + ":" + req.Url.Port + req.Url.Segments[0] + req.Url.Segments[1];
                        //Vdb = Path + r.MainPage;

                        //Parm = "?Parm=" + Parm;
                        ////不給驗証
                        //if (Code == "ManinUrl")
                        //    Parm = "";

                        //Vdb = Path + r.MainPage + Parm;
                    }
                    break;
            }

            return Vdb;
        }
    }
}