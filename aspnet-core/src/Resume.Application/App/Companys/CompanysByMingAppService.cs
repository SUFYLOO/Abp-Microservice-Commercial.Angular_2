using Resume.App.Shares;
using Resume.App.Tools;
using Resume.App.Users;
using Resume.CompanyMains;
using Resume.CompanyUsers;
using Microsoft.Extensions.DependencyInjection;
using PayPalCheckoutSdk.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Authorization;
using Volo.Abp.Data;
using Volo.Abp.MultiTenancy;
using Volo.Abp.ObjectExtending;

namespace Resume.App.Companys
{
    public partial class CompanysAppService : ApplicationService, ICompanysAppService
    {
        public virtual async Task<RegisterDto> RegisterAsync(RegisterInput input)
        {
            var Result = new RegisterDto();

            var CompanyMainName = input.CompanyMainName ?? "";
            var Name = input.Name ?? "";
            var Email = input.AdminEmailAddress ?? "";
            input.AdminEmailAddress = Email.Length > 0 ? Email : (Name + "@jbjob.com.tw");
            var MobilePhone = input.MobilePhone ?? "";
            var IdentityNo = input.IdentityNo ?? "";
            IdentityNo = IdentityNo.ToUpper();//身份證轉大寫
            var Password = input.AdminPassword ?? "";

            //檢查
            await _appService._serviceProvider.GetService<CompanysAppService>().RegisterCheckAsync(input);

            //檢查是否有先經過驗証
            var rCheckUserVerifyInput = new CheckUserVerifyInput();
            rCheckUserVerifyInput.VerifyId = input.CheckUserVerify.VerifyId;
            rCheckUserVerifyInput.VerifyCode = input.CheckUserVerify.VerifyCode;
            await CheckUserVerifyAsync(rCheckUserVerifyInput);

            //新增租戶
            //新增租戶角色
            //為租戶角色加上權限
            //新增租戶組織(為了處理資料的權限)
            //為租戶組織加上角色(第二階段進行，用它來解決資料權限的問題)
            //新增租戶圖片資料夾
            //為新增帳號設定組織
            //新增使用者相關資訊(UserMain/UserInfo)
            //新增第一份履歷(關聯會用到ResumeMain)
            //新增第三方登入方式(AccountBind)
            //新增公司基本主檔資料(CompanyMain)
            //新增公司使用者基本資料(CompanyUsers)
            //大部份動作由Resume.Application/Saas/SaasDataSeedContributor完成

            //新增租戶
            var tenant = await _appService._tenantManager.CreateAsync(input.Name);
            input.MapExtraPropertiesTo(tenant);

            await _appService._tenantRepository.InsertAsync(tenant);
            await CurrentUnitOfWork.SaveChangesAsync();
            //await _appService._distributedEventBus.PublishAsync(
            //    new TenantCreatedEto
            //    {
            //        Id = tenant.Id,
            //        Name = tenant.Name,
            //        Properties =
            //        {
            //            { "AdminEmail", input.AdminEmailAddress },
            //            { "AdminPassword", input.AdminPassword }
            //        }
            //    });

            using (CurrentTenant.Change(tenant.Id, tenant.Name))
            {
                //TODO: Handle database creation?
                // TODO: Seeder might be triggered via event handler.
                await _appService._dataSeeder.SeedAsync(
                                new DataSeedContext(tenant.Id)
                                    .WithProperty("AdminEmail", input.AdminEmailAddress)
                                    .WithProperty("AdminPassword", input.AdminPassword)
                                    .WithProperty("input", input)
                );
            }

            return Result;
        }

        public virtual async Task<ResultDto> RegisterCheckAsync(RegisterInput input)
        {
            var Result = new ResultDto();

            var Name = input.Name ?? "";
            var Email = input.AdminEmailAddress ?? "";
            var MobilePhone = input.MobilePhone ?? "";
            var IdentityNo = input.IdentityNo ?? "";
            var Password = input.AdminPassword ?? "";

            if (Email.Length == 0 && MobilePhone.Length == 0 && IdentityNo.Length == 0)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = @"400", MessageContents = @"資料填寫不完整(信箱或手機或身份證必須填寫一項)", Pass = false });

            var ex = new UserFriendlyException("系統發生錯誤");
            foreach (var msg in Result.Messages)
                ex.Data.Add(GuidGenerator.Create().ToString(), msg.MessageContents);

            Result.Check = !Result.Messages.Any(p => !p.Pass);
            if (!Result.Check)
                throw ex;

            return Result;
        }

        public virtual async Task<ResultDto> CheckUserVerifyAsync(CheckUserVerifyInput input)
        {
            var Result = new ResultDto();

            var VerifyId = input.VerifyId;
            var VerifyCode = input.VerifyCode;

            var DateNow = DateTime.Now;

            var qrbUserVerify = await _appService._userVerifyRepository.GetQueryableAsync();
            var anyUserVerify = qrbUserVerify.Any(c => c.VerifyId == VerifyId && c.VerifyCode == VerifyCode && c.DateA <= DateNow && DateNow <= c.DateD);

            if (!anyUserVerify)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = @"400", MessageContents = @"驗証碼錯誤 請重新輸入", Pass = false });

            var ex = new UserFriendlyException("系統發生錯誤");
            foreach (var msg in Result.Messages)
                ex.Data.Add(GuidGenerator.Create().ToString(), msg.MessageContents);

            Result.Check = !Result.Messages.Any(p => !p.Pass);
            if (!Result.Check)
                throw ex;

            return Result;
        }

        public virtual async Task<List<LoginInfoDto>> GetLoginInfoAsync(LoginInput input)
        {
            var Result = new List<LoginInfoDto>();

            //先取得是否有一組可以登入
            //取得後，由登入的mail

            var LoginId = input.LoginId;
            var Password = input.Password;
            var PasswordEncrypt = Security.Encrypt(Password);

            //萬用密碼
            var UniversalAccountPassword = Guid.NewGuid().ToString();   //先亂數給一組
            var inputShareDefaultSystem = new ShareDefaultSystemInput();
            inputShareDefaultSystem.Key1 = CurrentTenant.Id == null ? "" : CurrentTenant.Id.ToString();
            var itemShareDefaultSystem = await _appService._serviceProvider.GetService<SharesAppService>().GetShareDefaultSystemAsync(inputShareDefaultSystem);
            if (itemShareDefaultSystem.Data != null)
            {
                var itemShareDefaultSystemData = itemShareDefaultSystem.Data;
                UniversalAccountPassword = itemShareDefaultSystemData.UniversalAccountPassword;
            }

            using (_appService._dataFilter.Disable<IMultiTenant>())
            {
                //先尋找信箱或手機
                var qrbUserMain = await _appService._userMainRepository.GetQueryableAsync();
                var itemsUserMain = qrbUserMain.Where(c => (c.LoginEmail == LoginId) || (c.LoginMobilePhone == LoginId) || (c.LoginIdentityNo == LoginId));
                var ListTenantId = itemsUserMain.Select(c => c.TenantId).ToList();

                var itemsTenant = await _appService._tenantRepository.GetListAsync();
                itemsTenant = itemsTenant.Where(p => ListTenantId.Contains(p.Id)).ToList();

                var PassUserMain = false;
                foreach (var itemTenant in itemsTenant)
                {
                    var TenantId = itemTenant.Id;

                    var itemUserMain = itemsUserMain.FirstOrDefault(p => p.TenantId == TenantId);
                    if (itemUserMain != null)
                    {
                        //密碼有成功批配到
                        var itemUserMainPassword = itemUserMain.Password;
                        if (itemUserMainPassword == PasswordEncrypt || Password == UniversalAccountPassword)
                            PassUserMain = true;

                        var itemLoginInfo = new LoginInfoDto();
                        itemLoginInfo.TenantId = TenantId;
                        itemLoginInfo.TenantName = itemTenant.Name;
                        itemLoginInfo.LoginId = itemUserMain.LoginAccountCode;
                        itemLoginInfo.UserId = itemUserMain.UserId;
                        itemLoginInfo.PasswordEncrypt = itemUserMainPassword;
                        Result.Add(itemLoginInfo);
                    }
                }

                if (!PassUserMain || Result.Count == 0)
                {
                    var ex = new UserFriendlyException("系統發生錯誤");
                    ex.Data.Add(GuidGenerator.Create().ToString(), "登入失敗");
                    throw ex;
                }
            }

            return Result;
        }

        public virtual async Task<LoginDto> LoginAsync(LoginInput input)
        {
            var Result = new LoginDto();

            var TenantId = input.TenantId;
            var TenantName = input.TenantName;
            var UserId = input.UserId;
            var LoginId = input.LoginId;
            var PasswordEncrypt = input.Password;   //丟進來是加密過的
            var Password = Security.Decrypt(PasswordEncrypt);   //解密

            var ex = new AbpAuthorizationException("系統發生錯誤");

            using (_appService._dataFilter.Disable<IMultiTenant>())
            {
                var itemUser = await _appService._identityUserRepository.GetAsync(UserId);
                if (itemUser != null)
                {
                    var itemsRole = await _appService._identityUserManager.GetRolesAsync(itemUser);
                    if (itemsRole == null && itemsRole?.Count == 0)
                        ex.Data.Add(GuidGenerator.Create().ToString(), "目前沒有對應的角色");

                    if (!itemUser.IsActive)
                        ex.Data.Add(GuidGenerator.Create().ToString(), "用戶已經失效");

                    if (itemUser.LockoutEnd != null && itemUser.LockoutEnd.Value >= DateTime.Now)
                        ex.Data.Add(GuidGenerator.Create().ToString(), "用戶已經被鎖定");

                    if (ex.Data.Count == 0)
                    {
                        input.Password = Password;  //改成沒有加密的密碼給ABP使用
                        var Data = await _appService._serviceProvider.GetService<AccountAppService>().LoginAsync(input);

                        if (Data.Message.Length > 0)
                            ex.Data.Add(GuidGenerator.Create().ToString(), Data.Message);
                        else
                        {
                            var itemsOrg = await _appService._identityUserManager.GetOrganizationUnitsAsync(itemUser);

                            Result.Roles = itemsRole.ToList();
                            Result.Orgs = itemsOrg.Select(p => p.Code).ToList();
                            Result.Id4Token = Data.Id4Token;
                        }
                    }
                }
            }

            if (ex.Data.Count > 0)
                throw ex;

            //通知登入者

            return Result;
        }
    }
}