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
using static Volo.Abp.Identity.IdentityPermissions;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

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

                            item.ListRoleId = itemUser.Roles.Select(p => p.RoleId).ToList();
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


                        Result.ListRoleId = itemUser.Roles.Select(p => p.RoleId).ToList();
                        Result.ListOrgId = itemsOrg.Select(p => p.Id).ToList();
                    }
                }
            }

            if (ex.Data.Count > 0)
                throw ex;
            return Result;
        }

        public virtual async Task<ResultDto> SaveCompanyUserCheckAsync(SaveCompanyUserInput input)
        {
            //結果
            var Result = new ResultDto();
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
            var Name = input.Name ?? "";
            var AnonymousName = input.AnonymousName ?? "";
            //var LoginAccountCode = input.LoginAccountCode;
            var MobilePhone = input.MobilePhone ?? "";
            var Email = input.Email ?? "";
            var IdentityNo = input.IdentityNo ?? "";
            var Password = input.Password ?? "";
            //var SystemUserRoleKeys = input.SystemUserRoleKeys;
            //var AllowSearch = input.AllowSearch;
            var BirthDate = input.BirthDate;

            //預設值

            //檢查
            if (Email.IsNullOrEmpty() && MobilePhone.IsNullOrEmpty())
                Result.Messages.Add(new ResultMessageDto() { MessageCode = @"400", MessageContents = @"資料填寫不完整(信箱或手機必須填寫一項)", Pass = false });

            //主體資料
            var qrbCompanyUser = await _appService._companyUserRepository.GetQueryableAsync();
            var itemCompanyUser = qrbCompanyUser.FirstOrDefault(p => p.Id == CompanyUserId);

            //使用者主檔
            var qrbUserMain = await _appService._userMainRepository.GetQueryableAsync();

            //取得要被修改的人的UserId，如果UserId是null就默認此次做為新增，判斷略為不同
            Guid? UserId = null;
            if (itemCompanyUser != null)
            {
                var itemCompanyUserUserMainId = itemCompanyUser.UserMainId;

                var itemUserMain = qrbUserMain.FirstOrDefault(p => p.Id == itemCompanyUserUserMainId);
                if (itemUserMain != null)
                    UserId = itemUserMain.UserId;
            }

            {
                qrbUserMain = from c in qrbUserMain
                              where c.UserId != UserId
                              && (
                               //(c.LoginAccountCode.Length > 0 && c.LoginAccountCode.ToUpper() == LoginAccountCode.ToUpper()) ||
                               (c.LoginMobilePhone != null && c.LoginMobilePhone.Length > 0 && c.LoginMobilePhone.ToUpper() == MobilePhone)
                              || (c.LoginEmail != null && c.LoginEmail.Length > 0 && c.LoginEmail.ToUpper() == Email.ToUpper())
                              || (c.LoginIdentityNo != null && c.LoginIdentityNo.Length > 0 && c.LoginIdentityNo.ToUpper() == IdentityNo.ToUpper()))
                              select c;

                if (qrbUserMain.Any())
                    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "資料重複(使用者主檔)", Pass = false });

                //效能不好，未來再想怎麼改善 可能調用 EfCoreIdentityUserRepository
                var itemsUser = await _appService._identityUserRepository.GetListAsync();
                var itemUser = from c in itemsUser
                               where c.Id != UserId
                               && (
                                //(!c.NormalizedUserName.IsNullOrEmpty() && c.NormalizedUserName.ToUpper() == LoginAccountCode.ToUpper()) ||  //帳號是大寫
                                (!c.PhoneNumber.IsNullOrEmpty() && c.PhoneNumber.ToUpper() == MobilePhone.ToUpper())
                               || (!c.NormalizedEmail.IsNullOrEmpty() && c.NormalizedEmail.ToUpper() == Email.ToUpper())
                               || (!c.Surname.IsNullOrEmpty() && c.Surname.ToUpper() == IdentityNo.ToUpper()))
                               select c;

                if (itemUser.Any())
                    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "資料重複(Abp使用者主檔)", Pass = false });
            }

            foreach (var msg in Result.Messages)
                ex.Data.Add(GuidGenerator.Create().ToString(), msg.MessageContents);

            Result.Check = !Result.Messages.Any(p => !p.Pass);
            if (!Result.Check)
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

            //外部傳入
            var CompanyUserId = input.Id;

            //預設值

            //檢查
            await SaveCompanyUserCheckAsync(input);
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
                var inputRegister = ObjectMapper.Map<SaveCompanyUserInput, RegisterBaseInput>(input);
                inputRegister.NeedCheckUserVerify = false;
                inputRegister.SystemUserRoleKeys = 4;
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

        public virtual async Task<CompanyUsersDto> UpdateCompanyUserAsync(SaveCompanyUserInput input)
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
            input.CompanyMainId = CompanyMainId;

            //外部傳入
            var CompanyUserId = input.Id;
            var Name = input.Name ?? "";
            var AnonymousName = input.AnonymousName ?? "";
            //var LoginAccountCode = input.LoginAccountCode;
            var MobilePhone = input.MobilePhone ?? "";
            var Email = input.Email ?? "";
            var IdentityNo = input.IdentityNo ?? "";
            var Password = input.Password ?? "";
            //var SystemUserRoleKeys = input.SystemUserRoleKeys;
            //var AllowSearch = input.AllowSearch;
            var BirthDate = input.BirthDate;
            var ListRoleId = input.ListRoleId;
            var ListOrgId = input.ListOrgId;

            //預設值

            //檢查
            await SaveCompanyUserCheckAsync(input);
            if (SystemUserRoleKeys >= 9)
            {
                var Msg = "沒有權限";
                ex.Code = "401";
                ex.Details = Msg;
                ex.Data.Add(GuidGenerator.Create().ToString(), Msg);
            }

            //主體資料
            var qrbCompanyUser = await _appService._companyUserRepository.GetQueryableAsync();
            var itemCompanyUser = qrbCompanyUser.FirstOrDefault(p => p.Id == CompanyUserId);

            //使用者主檔
            var qrbUserMain = await _appService._userMainRepository.GetQueryableAsync();

            //使用者資訊檔
            var qrbUserInfo = await _appService._userInfoRepository.GetQueryableAsync();

            //如果權限是8以上，則只能修改自己的(如果帳號是從abp後台建立，則必須至少登入過一次，才可以修改)
            if (SystemUserRoleKeys >= 8 && (UserMainId != itemCompanyUser?.UserMainId))
            {
                var Msg = "沒有權限";
                ex.Code = "401";
                ex.Details = Msg;
                ex.Data.Add(GuidGenerator.Create().ToString(), Msg);
            }

            if (itemCompanyUser == null)
            {
                var Msg = "沒有資料";
                ex.Code = "400";
                ex.Details = Msg;
                ex.Data.Add(GuidGenerator.Create().ToString(), Msg);
            }
            else
            {
                var itemCompanyUserUserMainId = itemCompanyUser.UserMainId;

                var itemUserMain = qrbUserMain.FirstOrDefault(p => p.Id == itemCompanyUserUserMainId);
                if (itemUserMain == null)
                {
                    var Msg = "沒有資料";
                    ex.Code = "400";
                    ex.Details = Msg;
                    ex.Data.Add(GuidGenerator.Create().ToString(), Msg);
                }
                else
                {
                    var UserId = itemUserMain.UserId;

                    //Abp使用者主檔   
                    var itemUser = await _appService._identityUserRepository.GetAsync(UserId);
                    if (itemUser == null)
                    {
                        var Msg = "沒有資料";
                        ex.Code = "400";
                        ex.Details = Msg;
                        ex.Data.Add(GuidGenerator.Create().ToString(), Msg);
                    }
                    else if (ex.Data.Count == 0)
                    {
                        itemUser.Name = Name;
                        //await _appService._identityUserManager.SetUserNameAsync(itemUser, LoginAccountCode);
                        await _appService._identityUserManager.SetPhoneNumberAsync(itemUser, MobilePhone);
                        await _appService._identityUserManager.SetEmailAsync(itemUser, Email);
                        itemUser.Surname = IdentityNo;
                        if (Password.Length > 0)
                        {
                            //管理者 或是 自己 可以修改
                            if (SystemUserRoleKeys <= 4 || (UserMainId == itemCompanyUserUserMainId))
                            {
                                var Token = await _appService._identityUserManager.GeneratePasswordResetTokenAsync(itemUser);
                                await _appService._identityUserManager.ResetPasswordAsync(itemUser, Token, Password);
                            }
                        }
                        //只有管理者可以修改角色跟組織
                        if (SystemUserRoleKeys <= 4)
                        {
                            if (ListOrgId != null)
                            {
                                itemUser.OrganizationUnits.Clear();
                                foreach (var OrgId in ListOrgId)
                                    itemUser.AddOrganizationUnit(OrgId);
                            }

                            if (ListRoleId != null)
                            {
                                itemUser.Roles.Clear();
                                foreach (var RoleId in ListRoleId)
                                    itemUser.AddRole(RoleId);
                            }
                        }
                        await _appService._identityUserManager.UpdateAsync(itemUser);

                        //使用者主檔
                        itemUserMain.Name = Name;
                        itemUserMain.AnonymousName = AnonymousName;
                        //itemUserMain.LoginAccountCode = LoginAccountCode;
                        itemUserMain.LoginMobilePhone = MobilePhone;
                        itemUserMain.LoginEmail = Email;
                        itemUserMain.LoginIdentityNo = IdentityNo.ToUpper();
                        if (Password.Length > 0)
                            //管理者 或是 自己 可以修改
                            if (SystemUserRoleKeys <= 4 || (UserMainId == itemCompanyUserUserMainId))
                                itemUserMain.Password = Security.Encrypt(Password);
                        //itemUserMain.SystemUserRoleKeys = SystemUserRoleKeys;
                        //itemUserMain.AllowSearch = false;
                        await _appService._userMainRepository.UpdateAsync(itemUserMain);

                        //使用者主檔資訊     
                        var itemUserInfo = qrbUserInfo.FirstOrDefault(p => p.UserMainId == itemCompanyUserUserMainId);
                        if (itemUserInfo != null)
                        {
                            itemUserInfo.NameC = Name;
                            itemUserInfo.IdentityNo = IdentityNo.ToUpper();
                            itemUserInfo.BirthDate = BirthDate;
                            await _appService._userInfoRepository.UpdateAsync(itemUserInfo);
                        }

                        //更新公司使用者資訊
                        input.UserMainId = itemCompanyUserUserMainId;
                        ObjectMapper.Map(input, itemCompanyUser);
                        itemCompanyUser = await _appService._companyUserRepository.UpdateAsync(itemCompanyUser);
                        ObjectMapper.Map(itemCompanyUser, Result);

                        if (itemUser != null)
                        {
                            var itemsRole = await _appService._identityUserManager.GetRolesAsync(itemUser);
                            var itemsOrg = await _appService._identityUserManager.GetOrganizationUnitsAsync(itemUser);

                            Result.ListRoleId = itemUser.Roles.Select(p => p.RoleId).ToList();
                            Result.ListOrgId = itemsOrg.Select(p => p.Id).ToList();
                        }
                    }
                }
            }

            if (ex.Data.Count > 0)
                throw ex;
            return Result;
        }

        public virtual async Task<DeleteCompanyUserDto> DeleteCompanyUserAsync(DeleteCompanyUserInput input)
        {
            //結果
            var Result = new DeleteCompanyUserDto();
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
            if (SystemUserRoleKeys >= 5)
            {
                var Msg = "沒有權限";
                ex.Code = "401";
                ex.Details = Msg;
                ex.Data.Add(GuidGenerator.Create().ToString(), Msg);
            }

            //主體資料
            //主體資料
            var qrbCompanyUser = await _appService._companyUserRepository.GetQueryableAsync();
            var itemCompanyUser = qrbCompanyUser.FirstOrDefault(p => p.Id == CompanyUserId);

            //使用者主檔
            var qrbUserMain = await _appService._userMainRepository.GetQueryableAsync();

            if (itemCompanyUser == null)
            {
                var Msg = "沒有資料";
                ex.Code = "400";
                ex.Details = Msg;
                ex.Data.Add(GuidGenerator.Create().ToString(), Msg);
            }
            else
            {
                var itemCompanyUserUserMainId = itemCompanyUser.UserMainId;

                var itemUserMain = qrbUserMain.FirstOrDefault(p => p.Id == itemCompanyUserUserMainId);
                if (itemUserMain == null)
                {
                    var Msg = "沒有資料";
                    ex.Code = "400";
                    ex.Details = Msg;
                    ex.Data.Add(GuidGenerator.Create().ToString(), Msg);
                }
                else
                {
                    var UserId = itemUserMain.UserId;

                    //Abp使用者主檔   
                    var itemUser = await _appService._identityUserRepository.GetAsync(UserId);
                    if (itemUser == null)
                    {
                        var Msg = "沒有資料";
                        ex.Code = "400";
                        ex.Details = Msg;
                        ex.Data.Add(GuidGenerator.Create().ToString(), Msg);
                    }
                    else if (ex.Data.Count == 0)
                    {
                        await _appService._identityUserRepository.DeleteAsync(itemUser);
                        await _appService._userMainRepository.DeleteAsync(itemUserMain);
                        await _appService._companyUserRepository.DeleteAsync(itemCompanyUser);

                        Result.Pass = true;
                    }
                }
            }

            if (ex.Data.Count > 0)
                throw ex;
            return Result;
        }
    }
}