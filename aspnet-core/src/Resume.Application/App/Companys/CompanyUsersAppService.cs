using Resume.App.Tools;
using Resume.App.Users;
using Resume.CompanyMains;
using Resume.CompanyUsers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;

namespace Resume.App.Companys
{
    public partial class CompanysAppService : ApplicationService, ICompanysAppService
    {
        public virtual async Task<ResultDto<CompanyMainDto>> SaveCompanyMainAsync(CompanyMainDto input)
        {
            var Result = new ResultDto<CompanyMainDto>();
            Result.Data = new CompanyMainDto();
            Result.Version = "2023033001";

            var DateNow = DateTime.Now;

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            if (SystemUserRoleKeys >= 8)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "您沒有權限" });

            var Id = input.Id;

            using (_appService._dataFilter.Disable<IMultiTenant>())
            {
                var itemsCompanyUser = await _appService._companyUserRepository.GetQueryableAsync();
                itemsCompanyUser = itemsCompanyUser.Where(p => p.UserMainId == UserMainId);

                var ListCompanyMainId = itemsCompanyUser.Select(p => p.CompanyMainId);

                if (SystemUserRoleKeys >= 4)
                    if (!ListCompanyMainId.Contains(Id))
                        Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "您沒有權限" });

                if (Result.Messages.Count == 0)
                {
                    var itemsAll = await _appService._companyMainRepository.GetQueryableAsync();
                    var item = itemsAll.FirstOrDefault(p => p.Id == Id);
                    if (item == null)
                    {
                        //僅只有管理權限的人 才可以新增公司
                        if (SystemUserRoleKeys >= 1)
                            Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "您沒有權限" });
                        else
                        {
                            item = new CompanyMain();
                            await _appService._companyMainRepository.InsertAsync(item);
                            item.Status = "1";
                        }
                    }
                    else
                        await _appService._companyMainRepository.UpdateAsync(item);

                    if (Result.Messages.Count == 0)
                    {
                        item.Name = input.Name;
                        item.Compilation = input.Compilation;
                        item.OfficePhone = input.OfficePhone;
                        item.FaxPhone = input.FaxPhone;
                        item.Address = input.Address;
                        item.Principal = input.Principal;
                        item.AllowSearch = input.AllowSearch;
                        item.ExtendedInformation = input.ExtendedInformation;
                        item.DateA = input.DateA;
                        item.DateD = input.DateD;
                        item.Sort = input.Sort;
                        item.Note = input.Note;

                        var Data = ObjectMapper.Map<CompanyMain, CompanyMainsDto>(item);

                        Result.Data = Data;
                        Result.Save = true;
                    }
                }
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<List<CompanyUsersDto>>> GetCompanyUserListAsync(CompanyUserListInput input)
        {
            var Result = new ResultDto<List<CompanyUsersDto>>();
            Result.Data = new List<CompanyUsersDto>();
            Result.Version = "2023040101";

            var DateNow = DateTime.Now;

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            if (SystemUserRoleKeys >= 16)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "您沒有權限" });

            if (Result.Messages.Count == 0)
            {
                //預設走Tenant原則 只會取得自己的Tenant名單
                var itemsAll = await _appService._companyUserRepository.GetQueryableAsync();
                var items = itemsAll.ToList();

                var Data = ObjectMapper.Map<List<CompanyUser>, List<CompanyUsersDto>>(items);
                Data = (from c in Data
                        where c.DateA <= DateNow && DateNow <= c.DateD
                        && c.Status == "1"
                        orderby c.Sort
                        select c).ToList();

                foreach (var item in Data)
                {
                    //使用者主檔
                    UserMainId = item.UserMainId;
                    var itemsAllUserMain = await _appService._userMainRepository.GetQueryableAsync();

                    //取得要被修改的UserId
                    var UserId = Guid.NewGuid();
                    var itemUserMain = itemsAllUserMain.FirstOrDefault(p => p.Id == UserMainId);
                    if (itemUserMain != null)
                    {
                        UserId = itemUserMain.UserId;
                        var itemUser = await _appService._identityUserRepository.GetAsync(id: UserId);
                        if (itemUser != null)
                        {
                            var itemsRole = await _appService._identityUserManager.GetRolesAsync(itemUser);
                            var itemsOrg = await _appService._identityUserManager.GetOrganizationUnitsAsync(itemUser);

                            item.Roles = itemsRole.ToList();
                            item.Orgs = itemsOrg.Select(p => p.Code).ToList();
                        }
                    }
                }

                Result.Data = Data;
                Result.Save = true;
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }
        public virtual async Task<ResultDto<CompanyUsersDto>> GetCompanyUserAsync(CompanyUserInput input)
        {
            var Result = new ResultDto<CompanyUsersDto>();
            Result.Data = new CompanyUsersDto();
            Result.Version = "2023040101";

            var DateNow = DateTime.Now;

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            var Id = input.Id;

            if (SystemUserRoleKeys >= 16)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "您沒有權限" });

            //預設走Tenant原則 只會取得自己的Tenant名單
            var itemsAll = await _appService._companyUserRepository.GetQueryableAsync();
            var item = itemsAll.FirstOrDefault(p => p.Id == Id);

            if (item == null)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "資料不存在" });

            if (Result.Messages.Count == 0)
            {
                var Data = ObjectMapper.Map<CompanyUser, CompanyUsersDto>(item);

                //使用者主檔
                UserMainId = item.UserMainId;
                var itemsAllUserMain = await _appService._userMainRepository.GetQueryableAsync();

                //取得要被修改的UserId
                var UserId = Guid.NewGuid();
                var itemUserMain = itemsAllUserMain.FirstOrDefault(p => p.Id == UserMainId);
                if (itemUserMain != null)
                {
                    UserId = itemUserMain.UserId;
                    var itemUser = await _appService._identityUserRepository.GetAsync(id: UserId);
                    if (itemUser != null)
                    {
                        var itemsRole = await _appService._identityUserManager.GetRolesAsync(itemUser);
                        var itemsOrg = await _appService._identityUserManager.GetOrganizationUnitsAsync(itemUser);

                        Data.Roles = itemsRole.ToList();
                        Data.Orgs = itemsOrg.Select(p => p.Code).ToList();
                    }
                }

                Result.Data = Data;
                Result.Save = true;
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<CompanyUsersDto>> InsertCompanyUserAsync(SaveCompanyUserInput input)
        {
            var Result = new ResultDto<CompanyUsersDto>();
            Result.Data = new CompanyUsersDto();
            Result.Version = "2023041701";

            var DateNow = DateTime.Now;

            var CurrentTenantId = CurrentTenant.Id;
            var CurrentTenantName = CurrentTenant.Name;

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;

            var SaveIntent = input.SaveIntent;
            var Id = input.Id;
            var RoleId = input.RolesId;
            var OrgId = input.OrganizationUnitsId;

            var itemRole = await _appService._identityRoleRepository.FindByNormalizedNameAsync("MANAGE");
            if (RoleId == null && itemRole != null)
                RoleId = new List<Guid?>() { itemRole.Id };

            var itemsAllOrg = await _appService._organizationUnitRepository.GetListAsync();
            var itemOrg = itemsAllOrg.FirstOrDefault(p => p.ParentId == null && p.DisplayName == "Org");
            if (OrgId == null && itemOrg != null)
                OrgId = new List<Guid?>() { itemOrg.Id };

            var inputRegister = input.Register;
            var Name = inputRegister.Name ?? "";
            var AccountCode = inputRegister.AccountCode;
            var Email = inputRegister.AdminEmailAddress ?? "";
            var MobilePhone = inputRegister.MobilePhone ?? "";
            var IdentityNo = inputRegister.IdentityNo ?? ""; //身份證轉大寫
            IdentityNo = IdentityNo.Trim().ToUpper();
            var Password = inputRegister.AdminPassword ?? "";

            //預設走Tenant原則 只會取得自己的Tenant名單
            var itemsAllCompanyUser = await _appService._companyUserRepository.GetQueryableAsync();
            var item = itemsAllCompanyUser.FirstOrDefault(p => p.Id == Id);

            SaveIntent = (item == null) ? SaveIntentType.Insert : SaveIntentType.Update;

            if (SystemUserRoleKeys >= 5)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "您沒有權限" });

            //如果是新增 則要檢查重複註冊的問題
            if (SaveIntent == SaveIntentType.Insert)
            {
                var inputRegisterCheck = new RegisterCheckInput();
                inputRegisterCheck.TenantName = CurrentTenantName;
                inputRegisterCheck.Name = Name;
                inputRegisterCheck.Email = Email;
                inputRegisterCheck.MobilePhone = MobilePhone;
                inputRegisterCheck.IdentityNo = IdentityNo;
                inputRegisterCheck.Password = Password;
                var RegisterCheck = await _appService._serviceProvider.GetService<UsersAppService>().RegisterCheckAsync(inputRegisterCheck);
                Result.Messages.AddRange(RegisterCheck.Data);
            }

            if (Result.Messages.Count == 0)
            {
                if (item == null)
                {
                    //註冊流程
                    var UserName = Guid.NewGuid().ToString();
                    var EmailAbp = Email.Length > 0 ? Email : (UserName + "@jbjob.com.tw");
                    var user = new IdentityUser(GuidGenerator.Create(), UserName, EmailAbp, CurrentTenantId);
                    //if (OrgId != null)
                    //    user.AddOrganizationUnit(OrgId.Value);  //加入組織
                    //if (RoleId != null)
                    //    user.AddRole(RoleId.Value); //加入角色
                    foreach (var s in OrgId)
                        if (s != null)
                            user.AddOrganizationUnit(s.Value);
                    foreach (var s in RoleId)
                        if (s != null)
                            user.AddRole(s.Value);

                    user.Name = Name;
                    user.SetPhoneNumber(MobilePhone, MobilePhone.Length > 0);    //設定電話
                    user.Surname = IdentityNo;  //暫存身份證

                    //將密碼加密
                    var itemUser = await _appService._identityUserManager.CreateAsync(user, Password, false);
                    itemUser.CheckErrors();

                    //加入所有預設角色
                    var SetRole = await _appService._identityUserManager.AddDefaultRolesAsync(user);
                    //SetRole.CheckErrors();

                    //UserMain主檔
                    var UserId = user.Id;
                    UserMainId = _appService._guidGenerator.Create();

                    var inputInsertUserMain = new InsertUserMainInput();
                    inputInsertUserMain.TenantId = CurrentTenantId;
                    inputInsertUserMain.UserId = UserId;
                    inputInsertUserMain.UserMainId = UserMainId;
                    inputInsertUserMain.Name = Name;
                    inputInsertUserMain.UserName = UserName;
                    inputInsertUserMain.MobilePhone = MobilePhone;
                    inputInsertUserMain.Email = Email;
                    inputInsertUserMain.IdentityNo = IdentityNo;
                    inputInsertUserMain.Password = Password;
                    inputInsertUserMain.SystemUserRoleKeys = 8;
                    await _appService._serviceProvider.GetService<UsersAppService>().InsertUserMainAsync(inputInsertUserMain);

                    item = new CompanyUser();
                    await _appService._companyUserRepository.InsertAsync(item);
                    item.CompanyMainId = CompanyMainId; //公司不可以更改 且由系統代入
                    item.UserMainId = UserMainId;
                    item.Status = "1";
                    item.JobName = input.JobName;
                    item.OfficePhone = input.OfficePhone;
                    item.ExtendedInformation = input.ExtendedInformation;
                    item.DateA = input.DateA;
                    item.DateD = input.DateD;
                    item.Sort = input.Sort;
                    item.Note = input.Note;

                    var Data = ObjectMapper.Map<CompanyUser, CompanyUsersDto>(item);

                    var roles = new List<string>();
                    foreach (var r in RoleId)
                        roles.Add(r.Value.ToString());

                    var orgs = new List<string>();
                    foreach (var r in OrgId)
                        orgs.Add(r.Value.ToString());

                    Data.Roles = roles;
                    Data.Orgs = orgs;

                    Result.Data = Data;
                    Result.Save = true;
                }
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<CompanyUsersDto>> UpdateCompanyUserAsync(UpdateCompanyUserInput input)
        {
            var Result = new ResultDto<CompanyUsersDto>();
            Result.Data = new CompanyUsersDto();
            Result.Version = "2023041701";

            var DateNow = DateTime.Now;

            var CurrentTenantId = CurrentTenant.Id;
            var CurrentTenantName = CurrentTenant.Name;
            var UserId = CurrentUser.Id;

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;

            var Id = input.Id;
            var RoleId = input.RolesId;
            var OrgId = input.OrganizationUnitsId;

            var Name = input.Name ?? "";
            var AnonymousName = input.AnonymousName ?? "";
            //var LoginAccountCode = input.LoginAccountCode;
            var LoginMobilePhone = input.LoginMobilePhone ?? "";
            var LoginEmail = input.LoginEmail ?? "";
            var LoginIdentityNo = input.LoginIdentityNo ?? "";
            var Password = input.Password ?? "";
            //var SystemUserRoleKeys = input.SystemUserRoleKeys;
            //var AllowSearch = input.AllowSearch;
            var BirthDate = input.BirthDate;

            if (Name.IsNullOrEmpty() || LoginEmail.IsNullOrEmpty())
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "不允許空白" });

            //預設走Tenant原則 只會取得自己的Tenant名單
            var itemsAllCompanyUser = await _appService._companyUserRepository.GetQueryableAsync();
            var item = itemsAllCompanyUser.FirstOrDefault(p => p.Id == Id);

            var SaveIntent = (item == null) ? SaveIntentType.Insert : SaveIntentType.Update;

            if (SystemUserRoleKeys >= 9 || SaveIntent == SaveIntentType.Insert)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "您沒有權限" });

            if (item != null)
            {
                //如果權限是8以上，則只能修改自己的(如果帳號是從abp後台建立，則必須至少登入過一次，才可以修改)
                if (SystemUserRoleKeys >= 8 && (UserMainId != item.UserMainId))
                    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "您沒有權限" });

                if (Result.Messages.Count == 0)
                {
                    //換成要被修改的UserMainId
                    UserMainId = item.UserMainId;

                    //使用者主檔
                    var itemsAllUserMain = await _appService._userMainRepository.GetQueryableAsync();

                    //取得要被修改的UserId
                    var itemUserMain = itemsAllUserMain.FirstOrDefault(p => p.Id == UserMainId);
                    if (itemUserMain != null)
                        UserId = itemUserMain.UserId;

                    var itemsUserMain = itemsAllUserMain;

                    {
                        itemsUserMain = from c in itemsAllUserMain
                                        where c.TenantId == CurrentTenantId
                                        && c.UserId != UserId
                                        && (
                                        //(c.LoginAccountCode.Length > 0 && c.LoginAccountCode.ToUpper() == LoginAccountCode.ToUpper()) ||
                                         (c.LoginMobilePhone.Length > 0 && c.LoginMobilePhone.ToUpper() == LoginMobilePhone)
                                        || (c.LoginEmail.Length > 0 && c.LoginEmail.ToUpper() == LoginEmail.ToUpper())
                                        || (c.LoginIdentityNo.Length > 0 && c.LoginIdentityNo.ToUpper() == LoginIdentityNo.ToUpper()))
                                        select c;

                        if (itemsUserMain.Any())
                            Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "資料重複(使用者主檔)" });

                        //效能不好，未來再想怎麼改善 可能調用 EfCoreIdentityUserRepository
                        var itemsUser = await _appService._identityUserRepository.GetListAsync();
                        var itemUser = from c in itemsUser
                                       where c.TenantId == CurrentTenantId
                                       && c.Id != UserId
                                       && (
                                       //(!c.NormalizedUserName.IsNullOrEmpty() && c.NormalizedUserName.ToUpper() == LoginAccountCode.ToUpper()) ||  //帳號是大寫
                                        (!c.PhoneNumber.IsNullOrEmpty() && c.PhoneNumber.ToUpper() == LoginMobilePhone.ToUpper())
                                       || (!c.NormalizedEmail.IsNullOrEmpty() && c.NormalizedEmail.ToUpper() == LoginEmail.ToUpper())
                                       || (!c.Surname.IsNullOrEmpty() && c.Surname.ToUpper() == LoginIdentityNo.ToUpper()))
                                       select c;

                        if (itemUser.Any())
                            Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "資料重複(Abp使用者主檔)" });
                    }

                    if (Result.Messages.Count == 0)
                    {
                        //Abp使用者主檔   
                        var itemUser = await _appService._identityUserRepository.GetAsync(id: UserId.Value);
                        {

                            if (itemUser != null)
                            {
                                itemUser.Name = Name;
                                //await _appService._identityUserManager.SetUserNameAsync(itemUser, LoginAccountCode);
                                await _appService._identityUserManager.SetPhoneNumberAsync(itemUser, LoginMobilePhone);
                                await _appService._identityUserManager.SetEmailAsync(itemUser, LoginEmail);
                                itemUser.Surname = LoginIdentityNo;
                                if (Password.Length > 0)
                                {
                                    //管理者 或是 自己 可以修改
                                    if (SystemUserRoleKeys <= 4 || (UserMainId == item.UserMainId))
                                    {
                                        var Token = await _appService._identityUserManager.GeneratePasswordResetTokenAsync(itemUser);
                                        await _appService._identityUserManager.ResetPasswordAsync(itemUser, Token, Password);
                                    }
                                }

                                //只有管理者可以修改角色跟組織
                                if (SystemUserRoleKeys <= 4)
                                {
                                    //var itemsIdentityRole = await _appService._identityRoleRepository.GetListAsync();
                                    //var itemsOrganizationUnit = await _appService._organizationUnitRepository.GetListAsync();

                                    ////刪除目前原本的再新增
                                    //foreach (var itemIdentityRole in itemsIdentityRole)
                                    //{
                                    //    var itemIdentityRoleId = itemIdentityRole.Id;
                                    //    if (itemUser.IsInRole(itemIdentityRoleId))
                                    //        itemUser.RemoveRole(itemIdentityRoleId);
                                    //}

                                    //foreach (var itemOrganizationUnit in itemsOrganizationUnit)
                                    //{
                                    //    var itemOrganizationUnitId = itemOrganizationUnit.Id;
                                    //    if (itemUser.IsInOrganizationUnit(itemOrganizationUnitId))
                                    //        itemUser.RemoveOrganizationUnit(itemOrganizationUnitId);
                                    //}

                                    //var itemsRole = await _appService._identityUserManager.GetRolesAsync(itemUser);
                                    //var itemsOrg = await _appService._identityUserManager.GetOrganizationUnitsAsync(itemUser);

                                    if (OrgId != null)
                                    {
                                        itemUser.OrganizationUnits.Clear();
                                        foreach (var s in OrgId)
                                            if (s != null)
                                                itemUser.AddOrganizationUnit(s.Value);
                                        //itemUser.AddOrganizationUnit(OrgId.Value);  //加入組織
                                    }
                                    if (RoleId != null)
                                    {
                                        itemUser.Roles.Clear();
                                        foreach (var s in RoleId)
                                            if (s != null)
                                                itemUser.AddRole(s.Value);
                                        //itemUser.AddRole(RoleId.Value); //加入角色
                                    }
                                }

                                await _appService._identityUserManager.UpdateAsync(itemUser);
                            }
                        }

                        //使用者主檔
                        {
                            if (itemUserMain != null)
                            {
                                itemUserMain.Name = Name;
                                itemUserMain.AnonymousName = AnonymousName;
                                //itemUserMain.LoginAccountCode = LoginAccountCode;
                                itemUserMain.LoginMobilePhone = LoginMobilePhone;
                                itemUserMain.LoginEmail = LoginEmail;
                                itemUserMain.LoginIdentityNo = LoginIdentityNo.ToUpper();
                                if (Password.Length > 0)
                                    //管理者 或是 自己 可以修改
                                    if (SystemUserRoleKeys <= 4 || (UserMainId == item.UserMainId))
                                        itemUserMain.Password = Security.Encrypt(Password);
                                //itemUserMain.SystemUserRoleKeys = SystemUserRoleKeys;
                                //itemUserMain.AllowSearch = false;
                                await _appService._userMainRepository.UpdateAsync(itemUserMain);
                            }
                        }

                        //使用者主檔資訊     
                        {
                            var itemsAllUserInfo = await _appService._userInfoRepository.GetQueryableAsync();
                            var itemUserInfo = itemsAllUserInfo.FirstOrDefault(p => p.UserMainId == UserMainId);
                            if (itemUserInfo != null)
                            {
                                itemUserInfo.NameC = Name;
                                itemUserInfo.IdentityNo = LoginIdentityNo.ToUpper();
                                itemUserInfo.BirthDate = BirthDate;
                                await _appService._userInfoRepository.UpdateAsync(itemUserInfo);
                            }
                        }

                        ////履歷主檔     
                        //{
                        //    var itemsAllResumeMain = await _appService._resumeMainRepository.GetQueryableAsync();
                        //    var itemsResumeMain = itemsAllResumeMain.Where(p => p.UserMainId == UserMainId).ToList();
                        //    foreach (var itemResumeMain in itemsResumeMain)
                        //    {
                        //        itemResumeMain.NameC = Name;
                        //        itemResumeMain.IdentityNo = LoginIdentityNo.ToUpper();
                        //        itemResumeMain.BirthDate = BirthDate;
                        //    }
                        //    await _appService._resumeMainRepository.UpdateManyAsync(itemsResumeMain);
                        //}

                        await _appService._companyUserRepository.UpdateAsync(item);

                        //不允許改公司代碼
                        //item.CompanyMainId = CompanyMainId;                        
                        item.JobName = input.JobName;
                        item.OfficePhone = input.OfficePhone;
                        item.ExtendedInformation = input.ExtendedInformation;
                        item.DateA = input.DateA;
                        item.DateD = input.DateD;
                        item.Sort = input.Sort;
                        item.Note = input.Note;

                        var Data = ObjectMapper.Map<CompanyUser, CompanyUsersDto>(item);

                        if (itemUser != null)
                        {
                            var itemsRole = await _appService._identityUserManager.GetRolesAsync(itemUser);
                            var itemsOrg = await _appService._identityUserManager.GetOrganizationUnitsAsync(itemUser);

                            Data.Roles = itemsRole.ToList();
                            Data.Orgs = itemsOrg.Select(p => p.Code).ToList();
                        }

                        Result.Data = Data;
                        Result.Save = true;
                    }
                }
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<CompanyUsersDto>> SaveCompanyUserAsync(SaveCompanyUserInput input)
        {
            var Result = new ResultDto<CompanyUsersDto>();
            Result.Data = new CompanyUsersDto();
            Result.Version = "2023051101";

            Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "此功能不開放" });

            var DateNow = DateTime.Now;

            var CurrentTenantId = CurrentTenant.Id;
            var CurrentTenantName = CurrentTenant.Name;

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;

            var SaveIntent = input.SaveIntent;
            var Id = input.Id;

            //預設走Tenant原則 只會取得自己的Tenant名單
            var itemsAllCompanyUser = await _appService._companyUserRepository.GetQueryableAsync();
            var item = itemsAllCompanyUser.FirstOrDefault(p => p.Id == Id);

            SaveIntent = (item == null) ? SaveIntentType.Insert : SaveIntentType.Update;

            if (SystemUserRoleKeys >= 9 || SaveIntent == SaveIntentType.Insert)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "您沒有權限" });

            if (Result.Messages.Count == 0)
            {
                if (item != null)
                {
                    await _appService._companyUserRepository.UpdateAsync(item);

                    //不允許改公司代碼
                    //item.CompanyMainId = CompanyMainId;
                    item.JobName = input.JobName;
                    item.OfficePhone = input.OfficePhone;
                    item.ExtendedInformation = input.ExtendedInformation;
                    item.DateA = input.DateA;
                    item.DateD = input.DateD;
                    item.Sort = input.Sort;
                    item.Note = input.Note;

                    var Data = ObjectMapper.Map<CompanyUser, CompanyUsersDto>(item);

                    Result.Data = Data;
                    Result.Save = true;
                }
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }
        public virtual async Task<ResultDto<DeleteCompanyUserDto>> DeleteCompanyUserAsync(DeleteCompanyUserInput input)
        {
            var Result = new ResultDto<DeleteCompanyUserDto>();
            Result.Data = new DeleteCompanyUserDto();
            Result.Version = "2023051101";

            var DateNow = DateTime.Now;

            var CurrentTenantId = CurrentTenant.Id;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            var Id = input.Id;

            if (SystemUserRoleKeys >= 5)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "您沒有權限" });

            if (Result.Messages.Count == 0)
            {
                //預設走Tenant原則 只會取得自己的Tenant名單
                var itemsAll = await _appService._companyUserRepository.GetQueryableAsync();
                var item = itemsAll.FirstOrDefault(p => p.Id == Id);
                if (item != null)
                {
                    UserMainId = item.UserMainId;

                    var itemsUserMain = await _appService._userMainRepository.GetQueryableAsync();
                    var itemUserMain = itemsUserMain.FirstOrDefault(p => p.Id == UserMainId);
                    if (itemUserMain != null)
                    {
                        var UserId = itemUserMain.UserId;
                        var itemUser = await _appService._identityUserRepository.GetAsync(id: UserId);
                        if (itemUser != null)
                            await _appService._identityUserRepository.DeleteAsync(itemUser);

                        itemUserMain.Status = "2";
                        await _appService._userMainRepository.DeleteAsync(itemUserMain);
                    }

                    item.Status = "2";
                    await _appService._companyUserRepository.DeleteAsync(item);

                    Result.Data.Pass = true;
                    Result.Save = true;
                }
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

    }
}