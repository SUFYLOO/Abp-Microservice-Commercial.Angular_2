using Resume.App.Shares;
using Resume.App;
using Resume.App.Users;
using Resume.Permissions;
using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement;
using Volo.Abp.Uow;
using Volo.FileManagement.Directories;
using Volo.Saas.Editions;
using Microsoft.Extensions.DependencyInjection;
using Resume.UserAccountBinds;
using System.Text.Json;
using Resume.CompanyMains;
using PayPalCheckoutSdk.Orders;
using Resume.App.Companys;
using Resume.CompanyUsers;

namespace Resume.Saas
{
    public class SaasDataSeedContributor : IDataSeedContributor, ITransientDependency, IUnitOfWorkEnabled
    {
        private readonly AppService _appService;

        public SaasDataSeedContributor(AppService appService)
        {
            _appService = appService;
        }

        [UnitOfWork]
        public virtual async Task SeedAsync(DataSeedContext context)
        {
            if (context.TenantId.HasValue)
            {
                var input = context.Properties.ContainsKey("input") ? (RegisterTenantInput)context.Properties["input"] : new RegisterTenantInput();
                var AdminEmail = context.Properties.ContainsKey("AdminEmail") ? Convert.ToString(context.Properties["AdminEmail"]) : "";
                var AdminPassword = context.Properties.ContainsKey("AdminPassword") ? Convert.ToString(context.Properties["AdminPassword"]) : "";

                //新增租戶角色(admin 這個角色 abp會創出來 ，並將admin的帳號加入到這個角色)
                var itemIdentityRole = await _appService._identityRoleManager.FindByNameAsync("Manage");
                if (itemIdentityRole == null)
                {

                    var itemRole = new IdentityRole(_appService._guidGenerator.Create(), "Manage", context.TenantId.Value);
                    itemRole.IsDefault = true;
                    itemRole.IsPublic = true;
                    await _appService._identityRoleManager.CreateAsync(itemRole);

                    //為租戶角色加上權限
                    var PermissionsData = ResumePermissionsData.GetAll(ResumePermissions.GroupName);
                    foreach (var itemPermissionsData in PermissionsData)
                        await _appService._permissionManager.SetForRoleAsync("Manage", itemPermissionsData.key, true);
                }

                itemIdentityRole = await _appService._identityRoleManager.FindByNameAsync("User");
                if (itemIdentityRole == null)
                {
                    var itemRole = new IdentityRole(_appService._guidGenerator.Create(), "User", context.TenantId.Value);
                    itemRole.IsDefault = true;
                    itemRole.IsPublic = true;
                    await _appService._identityRoleManager.CreateAsync(itemRole);
                }

                //新增租戶上傳檔案資料夾
                var inputCreateDirectory = new CreateDirectoryInput();
                inputCreateDirectory.ParentId = null;
                inputCreateDirectory.Name = "ResumeMain";
                await _appService._directoryDescriptorAppService.CreateAsync(inputCreateDirectory);

                inputCreateDirectory = new CreateDirectoryInput();
                inputCreateDirectory.ParentId = null;
                inputCreateDirectory.Name = "ResumeWorks";
                await _appService._directoryDescriptorAppService.CreateAsync(inputCreateDirectory);

                inputCreateDirectory = new CreateDirectoryInput();
                inputCreateDirectory.ParentId = null;
                inputCreateDirectory.Name = "CompanyMainLogo";
                await _appService._directoryDescriptorAppService.CreateAsync(inputCreateDirectory);

                inputCreateDirectory = new CreateDirectoryInput();
                inputCreateDirectory.ParentId = null;
                inputCreateDirectory.Name = "CompanyMain";
                await _appService._directoryDescriptorAppService.CreateAsync(inputCreateDirectory);

                //新增部門
                Guid? itemOrgParentId = null;
                var itemOrg = new OrganizationUnit(_appService._guidGenerator.Create(), "Org", null, context.TenantId.Value);
                await _appService._organizationUnitManager.CreateAsync(itemOrg);
                await _appService._unitOfWorkManager.Current.SaveChangesAsync();
                itemOrgParentId = itemOrg.Id;

                Guid? itemOrgAllGuid = null;
                //All的部門 代表可以存取全部資料
                //預設組織               
                itemOrg = new OrganizationUnit(_appService._guidGenerator.Create(), "All", itemOrgParentId, context.TenantId.Value);
                await _appService._organizationUnitManager.CreateAsync(itemOrg);
                await _appService._unitOfWorkManager.Current.SaveChangesAsync();
                itemOrgAllGuid = itemOrg.Id;

                //NotClassified的部門 代表沒有任何資料權限
                itemOrg = new OrganizationUnit(_appService._guidGenerator.Create(), "NotClassified", itemOrgParentId, context.TenantId.Value);
                await _appService._organizationUnitManager.CreateAsync(itemOrg);

                //取得 admin這個帳戶 並為它加上組織及其它資訊               
                var itemUser = await _appService._identityUserRepository.FindByTenantIdAndUserNameAsync("admin", context.TenantId.Value);
                if (itemOrgAllGuid != null)
                    itemUser.AddOrganizationUnit(itemOrgAllGuid.Value);  //加入組織
                input.MobilePhone = input.MobilePhone ?? "";
                itemUser.SetPhoneNumber(input.MobilePhone, input.MobilePhone.Length > 0);    //設定電話
                itemUser.Surname = input.IdentityNo ?? "";  //暫存身份證
                await _appService._identityUserRepository.UpdateAsync(itemUser);

                //UserMain主檔
                var UserId = itemUser.Id;
                var UserMainId = _appService._guidGenerator.Create();

                var Name = "管理者";
                //建基本資訊
                var inputInsertUserMain = new InsertUserMainInput();
                inputInsertUserMain.TenantId = context.TenantId.Value;
                inputInsertUserMain.UserId = UserId;
                inputInsertUserMain.Name = Name;
                inputInsertUserMain.UserName = itemUser.UserName; //登入帳號
                inputInsertUserMain.MobilePhone = input.MobilePhone ?? "";
                inputInsertUserMain.Email = AdminEmail??"";
                inputInsertUserMain.IdentityNo = input.IdentityNo ?? "";
                inputInsertUserMain.Password = AdminPassword??"";//改到方法裡面再加密
                await _appService._serviceProvider.GetService<UsersAppService>().InsertUserMainAsync(inputInsertUserMain);

                var UserData = input.UserData;
                //寫入第三方資訊
                if (UserData != null && UserData.Message.IsNullOrEmpty() && !UserData.id.IsNullOrEmpty())
                {
                    var item = new UserAccountBind();                
                    item.ThirdPartyTypeCode = input.ThirdPartyTypeCode ?? "";
                    item.ThirdPartyAccountId = UserData.id ?? "";
                    item.ExtendedInformation = JsonSerializer.Serialize(UserData, new JsonSerializerOptions
                    {
                        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping, // 中文字不編碼
                        WriteIndented = true  // 換行與縮排
                    });
                    item.DateA = new DateTime(1900, 1, 1).Date;
                    item.DateD = new DateTime(9999, 1, 1).Date;
                    item.Sort = 9;
                    item.Note = "";
                    item.UserMainId = UserMainId;
                    item.Status = "1";
                    await _appService._serviceProvider.GetService<IUserAccountBindRepository>().InsertAsync(item);
                }

                //新增公司基本主檔資料(CompanyMain)
                var itemCompanyMain = new CompanyMain();
                itemCompanyMain.Name = input.CompanyMainName ?? "";
                itemCompanyMain.Compilation = input.Name ?? "";
                itemCompanyMain.OfficePhone = "";
                itemCompanyMain.FaxPhone = "";
                itemCompanyMain.Address = "";
                itemCompanyMain.Principal = "";
                itemCompanyMain.AllowSearch = true;
                itemCompanyMain.IndustryCategory = "";
                itemCompanyMain.CompanyUrl = "";
                itemCompanyMain.HideCapitalAmount = true;
                itemCompanyMain.CapitalAmount = 0;
                itemCompanyMain.CompanyScaleCode = "";
                itemCompanyMain.HidePrincipal = true;
                itemCompanyMain.CompanyUserId = UserMainId;
                itemCompanyMain.CompanyProfile = "";
                itemCompanyMain.BusinessPhilosophy = "";
                itemCompanyMain.OperatingItems = "";
                itemCompanyMain.WelfareSystem = "";
                itemCompanyMain.Matching = false;
                itemCompanyMain.ContractPass = false;
                itemCompanyMain.Status = "1";
                itemCompanyMain.ExtendedInformation = "";
                itemCompanyMain.DateA = new DateTime(1900, 1, 1).Date;
                itemCompanyMain.DateD = new DateTime(9999, 12, 31).Date;
                itemCompanyMain.Sort = 9;
                itemCompanyMain.Note = "";
                await _appService._companyMainRepository.InsertAsync(itemCompanyMain);

                //新增公司使用者基本資料(CompanyUsers)
                var itemCompanyUser = new CompanyUser();
                itemCompanyUser.CompanyMainId = itemCompanyMain.Id;
                itemCompanyUser.UserMainId = UserMainId;
                itemCompanyUser.JobName = Name;
                itemCompanyUser.OfficePhone = input.MobilePhone ?? "";
                itemCompanyUser.Status = "1";
                itemCompanyUser.ExtendedInformation = "";
                itemCompanyMain.DateA = new DateTime(1900, 1, 1).Date;
                itemCompanyMain.DateD = new DateTime(9999, 12, 31).Date;
                itemCompanyMain.Sort = 9;
                itemCompanyMain.Note = "";
                await _appService._companyUserRepository.InsertAsync(itemCompanyUser);

                //發送郵件
                //var inputSendShareSendQueue = new SendShareSendQueueInput();
                //inputSendShareSendQueue.Key3 = "02";    //郵件樣版
                //inputSendShareSendQueue.InstantSend = true;
                //inputSendShareSendQueue.ListToMail.Add(AdminEmail);
                //inputSendShareSendQueue.ListToGsm.Add(input.MobilePhone);
                //inputSendShareSendQueue.SendTypeCode = AdminEmail.Length > 0 && input.MobilePhone.Length > 0 ? SendType.All : input.MobilePhone.Length > 0 ? SendType.Gsm : SendType.Mail;
                //inputSendShareSendQueue.dcParameter.Add("UserName", Name);
                //await _appService._serviceProvider.GetService<SharesAppService>().SendShareSendQueueAsync(inputSendShareSendQueue);

                //呼叫登入 不會成功 因為uw的關係 必須要讓上面的先存入資料庫 才能成功
                //var inputLogin = new LoginInput();
                //inputLogin.LoginId = UserName;
                //inputLogin.Password = Password;
                //var Data = await LoginAsync(inputLogin);
                //Result.Data.Login = Data.Data;
            }
            using (_appService._currentTenant.Change(context?.TenantId))
            {
                await _appService._editionDataSeeder.CreateStandardEditionsAsync();
            }
        }
    }
}