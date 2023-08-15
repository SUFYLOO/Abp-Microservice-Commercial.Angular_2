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
using Volo.Abp;
using Org.BouncyCastle.Asn1.Ocsp;
using PayPalCheckoutSdk.Orders;
using Volo.Abp.ObjectMapping;

namespace Resume.App.Companys
{
    public partial class CompanysAppService : ApplicationService, ICompanysAppService
    {       
        public virtual async Task<List<CompanyUsersDto>> GetCompanyUserListAsync(CompanyUserListInput input)
        {
            //結果
            var Result = new List<CompanyUsersDto>();
            var ex = new UserFriendlyException("錯誤訊息");

            //常用

            //系統層級
            var TenantId = CurrentTenant.Id;
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //強制把input帶入系統值

            //外部傳入

            //預設值

            //檢查
            if (SystemUserRoleKeys >= 9)
            {
                var Msg = "您沒有權限";
                ex.Code = "401";
                ex.Details = Msg;
                ex.Data.Add(GuidGenerator.Create().ToString(), Msg);
            }

            //主體資料
            var qrbCompanyUser = await _appService._companyUserRepository.GetQueryableAsync();
            var qrbsCompanyUser = from c in qrbCompanyUser
                                  select c;

            if (ex.Data.Count == 0)
            {
                var itemsCompanyUser = qrbsCompanyUser.ToList();

                //排序結果 ，如果需要排序就
                //itemsCompanyUser = (from c in itemsCompanyUser
                //                    orderby c.Sort
                //                    select c).ToList();

                ObjectMapper.Map(itemsCompanyUser, Result);

                //取得角色
                var qrbUserMain = await _appService._userMainRepository.GetQueryableAsync();
                foreach (var item in Result)
                {
                    //使用者主檔的UserMainId
                    UserMainId = item.UserMainId;
                    var itemUserMain = qrbUserMain.FirstOrDefault(p => p.Id == UserMainId);
                    if (itemUserMain != null)
                    {
                        //Abp原生的UserId
                        var UserId = itemUserMain.UserId;
                        var itemUser = await _appService._identityUserRepository.GetAsync(id: UserId);
                        if (itemUser != null)
                        {
                            var itemsRole = await _appService._identityUserManager.GetRolesAsync(itemUser);
                            var itemsOrg = await _appService._identityUserManager.GetOrganizationUnitsAsync(itemUser);

                            item.ListOrgId = itemsRole.Cast<Guid>().ToList();
                            item.ListOrgId = itemsOrg.Select(p => p.Id).ToList();
                        }
                    }
                }
            }

            if (ex.Data.Count > 0)
                throw ex;
            return Result;
        }

        public virtual async Task<CompanyUsersDto> GetCompanyUserAsync(CompanyUserInput input)
        {
            //結果
            var Result = new CompanyUsersDto();
            var ex = new UserFriendlyException("錯誤訊息", "400");

            //常用

            //系統層級
            var TenantId = CurrentTenant.Id;
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //強制把input帶入系統值

            //外部傳入
            var CompanyUserId = input.Id;

            //預設值

            //檢查
            if (SystemUserRoleKeys >= 9)
            {
                var Msg = "您沒有權限";
                ex.Code = "401";
                ex.Details = Msg;
                ex.Data.Add(GuidGenerator.Create().ToString(), Msg);
            }

            //主體資料
            var qrbCompanyUser = await _appService._companyUserRepository.GetQueryableAsync();
            var qrbsCompanyUser = from c in qrbCompanyUser
                                  select c;

            if (ex.Data.Count == 0)
            {
                var itemCompanyUser = qrbsCompanyUser.FirstOrDefault(p => p.Id == CompanyUserId);
                if (itemCompanyUser == null)
                {
                    var Msg = "沒有資料";
                    ex.Code = "204";
                    ex.Details = Msg;
                    ex.Data.Add(GuidGenerator.Create().ToString(), Msg);
                }

                ObjectMapper.Map(itemCompanyUser, Result);

                //取得角色
                var qrbUserMain = await _appService._userMainRepository.GetQueryableAsync();

                //使用者主檔的UserMainId
                var itemUserMain = qrbUserMain.FirstOrDefault(p => p.Id == UserMainId);
                if (itemUserMain != null)
                {
                    //Abp原生的UserId
                    var UserId = itemUserMain.UserId;
                    var itemUser = await _appService._identityUserRepository.GetAsync(id: UserId);
                    if (itemUser != null)
                    {
                        var itemsRole = await _appService._identityUserManager.GetRolesAsync(itemUser);
                        var itemsOrg = await _appService._identityUserManager.GetOrganizationUnitsAsync(itemUser);

                        Result.ListOrgId = itemsRole.Cast<Guid>().ToList();
                        Result.ListOrgId = itemsOrg.Select(p => p.Id).ToList();
                    }
                }
            }

            if (ex.Data.Count > 0)
                throw ex;
            return Result;
        }

        public virtual async Task<CompanyUsersDto> InsertCompanyUserAsync(SaveCompanyUserInput input)
        {
            //結果
            var Result = new CompanyUsersDto();
            var ex = new UserFriendlyException("錯誤訊息", "400");

            //常用

            //系統層級
            var TenantId = CurrentTenant.Id;
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //強制把input帶入系統值
            input.Register.NeedCheckUserVerify = false;

            //外部傳入
            var CompanyUserId = input.Id;
            var inputRegister = input.Register;

            //預設值

            //檢查
            if (SystemUserRoleKeys >= 5)
            {
                var Msg = "您沒有權限";
                ex.Code = "401";
                ex.Details = Msg;
                ex.Data.Add(GuidGenerator.Create().ToString(), Msg);
            }

            //主體資料

            if (ex.Data.Count == 0)
            {
                var ResultRegister = await _appService._serviceProvider.GetService<UsersAppService>().RegisterAsync(inputRegister);

                var itemCompanyUser = ObjectMapper.Map<SaveCompanyUserInput, CompanyUser>(input);
                itemCompanyUser.CompanyMainId = CompanyMainId; //公司不可以更改 且由系統代入
                itemCompanyUser.UserMainId = ResultRegister.UserMainId;
                itemCompanyUser = await _appService._companyUserRepository.InsertAsync(itemCompanyUser);

                ObjectMapper.Map(itemCompanyUser, Result);
            }

            if (ex.Data.Count > 0)
                throw ex;
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

                            Data.ListOrgId = itemsRole.Cast<Guid>().ToList();
                            Data.ListOrgId = itemsOrg.Select(p => p.Id).ToList();
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

            var SaveIntent = SaveIntentType.Insert;
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