using Resume.App.Companys;
using Resume.App.Resumes;
using Resume.App.Shares;
using Resume.App.Tools;
using Resume.CompanyInvitationss;
using Resume.CompanyJobs;
using Resume.CompanyMains;
using Resume.CompanyUsers;
using Resume.Permissions;
using Resume.ResumeCommunications;
using Resume.ResumeMains;
using Resume.ResumeSnapshots;
using Resume.UserAccountBinds;
using Resume.UserCompanyBinds;
using Resume.UserInfos;
using Resume.UserMains;
using Resume.UserVerifys;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Asn1.Cms;
using PayPalCheckoutSdk.Orders;
using Polly;
using Scriban.Syntax;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Net.Http;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Commercial.SuiteTemplates;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Guids;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.ObjectExtending;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Security.Claims;
using Volo.Abp.Users;
using Volo.Abp.Validation;
using Volo.Chat.Messages;
using Volo.FileManagement.Directories;
using Volo.Saas.Tenants;
using static Resume.Permissions.ResumePermissions;
using static Volo.Abp.Identity.IdentityPermissions;
using static Volo.Abp.Identity.Settings.IdentitySettingNames;
using static Volo.Saas.Host.SaasHostPermissions;
using OrganizationUnit = Volo.Abp.Identity.OrganizationUnit;

namespace Resume.App.Users
{
    [RemoteService(IsEnabled = false)]

    public class UsersAppService : ApplicationService, IUsersAppService
    {
        private readonly AppService _appService;

        public UsersAppService(AppService appService)
        {
            _appService = appService;
        }

        public virtual async Task<ResultDto<List<ResultMessageDto>>> RegisterCheckAsync(RegisterCheckInput input)
        {
            var Result = new ResultDto<List<ResultMessageDto>>();
            Result.Data = new List<ResultMessageDto>();
            Result.Version = "2023041701";

            var TenantId = Guid.Parse("d63dd51b-2e19-a965-ed20-3a09cda74359");
            var TenantName = input.TenantName.IsNullOrEmpty() ? "User" : input.TenantName;

            var Name = input.Name ?? "";
            var Email = input.Email ?? "";
            var MobilePhone = input.MobilePhone ?? "";
            var IdentityNo = input.IdentityNo ?? "";
            var Password = input.Password ?? "";

            try
            {
                if (Name.Length == 0)
                    Result.Data.Add(new ResultMessageDto() { MessageCode = @"400", MessageContents = @"�m�W���o���ť�" });

                if (Email.Length == 0 && MobilePhone.Length == 0 && IdentityNo.Length == 0)
                    Result.Data.Add(new ResultMessageDto() { MessageCode = @"400", MessageContents = @"��ƶ�g������(�H�c�Τ���Ψ����ҥ�����g�@��)" });

                if (Password.Length == 0)
                    Result.Data.Add(new ResultMessageDto() { MessageCode = @"400", MessageContents = @"�K�X���o���ť�" });

                //�P�_�O�_������
                using (_appService._dataFilter.Disable<IMultiTenant>())
                {
                    var itemTenant = await _appService._tenantRepository.FindByNameAsync(TenantName);
                    if (itemTenant != null)
                        TenantId = itemTenant.Id;

                    //�ۦP���ᤣ�i�H����
                    var itemsAllUserMain = await _appService._userMainRepository.GetQueryableAsync();
                    itemsAllUserMain = from c in itemsAllUserMain
                                       where c.TenantId == TenantId
                                       && ((c.LoginEmail.Length > 0 && c.LoginEmail.ToUpper() == Email.ToUpper())
                                       || (c.LoginMobilePhone.Length > 0 && c.LoginMobilePhone.ToUpper() == MobilePhone.ToUpper())
                                       || (c.LoginIdentityNo.Length > 0 && c.LoginIdentityNo.ToUpper() == IdentityNo.ToUpper()))
                                       select c;

                    var itemsUser = await _appService._identityUserRepository.GetListAsync();
                    var itemUser = from c in itemsUser
                                   where c.TenantId == TenantId
                                   && ((!c.PhoneNumber.IsNullOrEmpty() && c.PhoneNumber.ToUpper() == MobilePhone.ToUpper())
                                   || (!c.NormalizedEmail.IsNullOrEmpty() && c.NormalizedEmail.ToUpper() == Email.ToUpper())
                                   || (!c.Surname.IsNullOrEmpty() && c.Surname.ToUpper() == IdentityNo.ToUpper()))
                                   select c;

                    if (itemsAllUserMain.Any() || itemUser.Any())
                        Result.Data.Add(new ResultMessageDto() { MessageCode = @"400", MessageContents = @"�ӽи�ƭ���" });
                }
            }
            catch (Exception ex)
            {
                Result.StackTrace = ex.StackTrace;
                Result.Status = false;

                Result.Messages.Add(new ResultMessageDto() { MessageCode = @"400", MessageContents = @"�t�εo�Ϳ��~ �еy��A��" });

                _appService._logger.LogException(ex);
            }

            Result.Check = Result.Data.Count == 0;
            Result.Save = true;

            return Result;
        }

        public virtual async Task<ResultDto<RegisterDto>> RegisterAsync(RegisterInput input)
        {
            var Result = new ResultDto<RegisterDto>();
            Result.Data = new RegisterDto();
            Result.Version = "2023041701";

            //���U�����}��k �÷|���D��eTenantName
            var TenantName = "User";// input.TenantName; �@��ϥΪ̵��U �@�ߥ�User�ˬd
            var Name = input.Name ?? "";
            var Email = input.AdminEmailAddress ?? "";
            var MobilePhone = input.MobilePhone ?? "";
            var IdentityNo = input.IdentityNo ?? "";
            IdentityNo = IdentityNo.ToUpper();//��������j�g
            var Password = input.AdminPassword ?? "";

            //���g��
            var OrgId = Guid.Parse("910ebc10-6f99-1a6d-0410-3a0a1a237bfe");
            var RoleId = Guid.Parse("45fd7f1d-3e7e-7bd6-d787-3a0a1a24ee50");
            var TenantId = Guid.Parse("d63dd51b-2e19-a965-ed20-3a09cda74359");

            try
            {
                var inputRegisterCheck = new RegisterCheckInput();
                inputRegisterCheck.TenantName = TenantName;
                inputRegisterCheck.Name = Name;
                inputRegisterCheck.Email = Email;
                inputRegisterCheck.MobilePhone = MobilePhone;
                inputRegisterCheck.IdentityNo = IdentityNo;
                inputRegisterCheck.Password = Password;
                var RegisterCheck = await RegisterCheckAsync(inputRegisterCheck);
                Result.Messages = RegisterCheck.Data;

                //�ˬd�O�_�����g�L���
                var rCheckUserVerifyInput = new CheckUserVerifyInput();
                rCheckUserVerifyInput.VerifyId = input.CheckUserVerify.VerifyId;
                rCheckUserVerifyInput.VerifyCode = input.CheckUserVerify.VerifyCode;
                var CheckUserVerify = await CheckUserVerifyAsync(rCheckUserVerifyInput);
                Result.Messages.AddRange(CheckUserVerify.Messages);

                if (Result.Messages.Count == 0)
                {
                    //�ѩ�Abp�H�c���i�H�ťաA�Ӧb�i���t�ΫH�c�N��ߤ@�ȡA�]���p�G�ϥΪ̥Τ�����U�ɡA�ڨM�w�ĥ�UserName���H�c�ȥ�

                    var UserName = _appService._guidGenerator.Create().ToString();
                    var EmailAbp = Email.Length > 0 ? Email : (UserName + "@jbjob.com.tw");
                    var user = new IdentityUser(GuidGenerator.Create(), UserName, EmailAbp, TenantId);
                    user.AddOrganizationUnit(OrgId);  //�[�J��´
                    user.AddRole(RoleId); //�[�J����
                    user.Name = Name;
                    user.SetPhoneNumber(MobilePhone, MobilePhone.Length > 0);    //�]�w�q��
                    user.Surname = IdentityNo;  //�Ȧs������

                    //�N�K�X�[�K
                    var itemUser = await _appService._identityUserManager.CreateAsync(user, Password, false);
                    itemUser.CheckErrors();

                    //�[�J�Ҧ��w�]����
                    //var SetRole = await _appService._identityUserManager.AddDefaultRolesAsync(user);
                    //SetRole.CheckErrors();

                    //UserMain�D��
                    var UserId = user.Id;
                    var UserMainId = _appService._guidGenerator.Create();

                    //�ذ򥻸�T
                    var inputInsertUserMain = new InsertUserMainInput();
                    inputInsertUserMain.TenantId = TenantId;
                    inputInsertUserMain.UserId = UserId;
                    inputInsertUserMain.UserMainId = UserMainId;
                    inputInsertUserMain.Name = input.Name;
                    inputInsertUserMain.UserName = UserName;
                    inputInsertUserMain.MobilePhone = MobilePhone;
                    inputInsertUserMain.Email = Email;
                    inputInsertUserMain.IdentityNo = IdentityNo;
                    inputInsertUserMain.Password = Password;    //����k�̭��A�[�K
                    await InsertUserMainAsync(inputInsertUserMain);

                    //�g�J�ĤT���T
                    var UserData = input.UserData;
                    if (UserData != null && UserData.Message.IsNullOrEmpty() && !UserData.id.IsNullOrEmpty())
                    {
                        var item = new UserAccountBind();
                        item.ThirdPartyTypeCode = input.ThirdPartyTypeCode ?? "";
                        item.ThirdPartyAccountId = UserData.id ?? "";
                        item.ExtendedInformation = JsonSerializer.Serialize(UserData, new JsonSerializerOptions
                        {
                            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping, // ����r���s�X
                            WriteIndented = true  // ����P�Y��
                        });
                        item.DateA = new DateTime(1900, 1, 1).Date;
                        item.DateD = new DateTime(9999, 1, 1).Date;
                        item.Sort = 9;
                        item.Note = "";
                        item.UserMainId = UserMainId;
                        item.Status = "1";
                        await _appService._userAccountBindRepository.InsertAsync(item);
                    }

                    //�o�e�l��
                    var inputSendShareSendQueue = new SendShareSendQueueInput();
                    inputSendShareSendQueue.Key3 = "02";    //�l��˪�
                    inputSendShareSendQueue.InstantSend = true;
                    inputSendShareSendQueue.ListToMail.Add(Email);
                    inputSendShareSendQueue.ListToGsm.Add(MobilePhone);
                    inputSendShareSendQueue.SendTypeCode = Email.Length > 0 && MobilePhone.Length > 0 ? SendType.All : MobilePhone.Length > 0 ? SendType.Gsm : SendType.Mail;
                    inputSendShareSendQueue.dcParameter.Add("UserName", Name);
                    await _appService._serviceProvider.GetService<SharesAppService>().SendShareSendQueueAsync(inputSendShareSendQueue);

                    //�I�s�n�J ���|���\ �]��uw�����Y �����n���W�������s�J��Ʈw �~�ন�\
                    //var inputLogin = new LoginInput();
                    //inputLogin.LoginId = UserName;
                    //inputLogin.Password = Password;
                    //var Data = await LoginAsync(inputLogin);
                    //Result.Data.Login = Data.Data;

                    Result.Save = true;
                }
            }
            catch (Exception ex)
            {
                Result.StackTrace = ex.StackTrace;
                Result.Status = false;

                Result.Messages.Add(new ResultMessageDto() { MessageCode = @"400", MessageContents = @"�t�εo�Ϳ��~ �еy��A��" });

                _appService._logger.LogException(ex);
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        /// <summary>
        /// ��l�ϥΪ̰򥻸��
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public virtual async Task<bool> InsertUserMainAsync(InsertUserMainInput input)
        {
            var TenantId = input.TenantId;
            var UserId = input.UserId;
            var UserMainId = input.UserMainId;
            var Name = input.Name;
            var UserName = input.UserName;
            var MobilePhone = input.MobilePhone;
            var Email = input.Email;
            var IdentityNo = input.IdentityNo;
            var Password = input.Password;
            var SystemUserRoleKeys = input.SystemUserRoleKeys;

            var rUserMain = new UserMain();
            rUserMain.TenantId = TenantId;
            rUserMain.UserId = UserId;
            rUserMain.Name = Name;
            rUserMain.AnonymousName = Name;
            rUserMain.LoginAccountCode = UserName.ToUpper();
            rUserMain.LoginMobilePhoneUpdate = MobilePhone;
            rUserMain.LoginMobilePhone = MobilePhone;
            rUserMain.LoginEmail = Email;
            rUserMain.LoginEmailUpdate = Email;
            rUserMain.LoginIdentityNo = IdentityNo.ToUpper();
            rUserMain.Password = Security.Encrypt(Password);  //�ݭn�[�K
            rUserMain.SystemUserRoleKeys = SystemUserRoleKeys;
            rUserMain.AllowSearch = false;
            rUserMain.ExtendedInformation = "";
            rUserMain.DateA = new DateTime(1900, 1, 1);
            rUserMain.DateD = new DateTime(9999, 12, 31);
            rUserMain.Sort = 9;
            rUserMain.Note = "";
            rUserMain.Status = "1";
            var iUserMain = await _appService._userMainRepository.InsertAsync(rUserMain);

            var rUserInfo = new UserInfo();
            rUserInfo.TenantId = TenantId;
            rUserInfo.UserMainId = UserMainId;
            rUserInfo.NameC = Name;
            rUserInfo.NameE = "";
            rUserInfo.IdentityNo = IdentityNo.ToUpper();
            rUserInfo.BirthDate = new DateTime(1900, 1, 1).Date;
            rUserInfo.SexCode = "";
            rUserInfo.BloodCode = "";
            rUserInfo.PlaceOfBirthCode = "";
            rUserInfo.PassportNo = "";
            rUserInfo.NationalityCode = "";
            rUserInfo.ResidenceNo = "";
            rUserInfo.ExtendedInformation = "";
            rUserInfo.DateA = new DateTime(1900, 1, 1);
            rUserInfo.DateD = new DateTime(9999, 12, 31);
            rUserInfo.Sort = 9;
            rUserInfo.Note = "";
            rUserInfo.Status = "1";
            var iUserInfo = await _appService._userInfoRepository.InsertAsync(rUserInfo);

            //�s�W�ڪ��Ĥ@���i��
            var rResumeMain = new ResumeMain();
            rResumeMain.TenantId = TenantId;
            rResumeMain.UserMainId = UserMainId;
            rResumeMain.ResumeName = "�ڪ��Ĥ@���i��";
            //rResumeMain.NameC = Name;
            //rResumeMain.NameE = "";
            //rResumeMain.IdentityNo = IdentityNo.ToUpper();
            //rResumeMain.BirthDate = new DateTime(1900, 1, 1).Date;
            //rResumeMain.SexCode = "";
            //rResumeMain.BloodCode = "";
            rResumeMain.MarriageCode = "";
            //rResumeMain.PlaceOfBirthCode = "";
            rResumeMain.MilitaryCode = "";
            //rResumeMain.PassportNo = "";
            rResumeMain.DisabilityCategoryCode = "";
            //rResumeMain.NationalityCode = "";
            rResumeMain.SpecialIdentityCode = "";
            rResumeMain.Main = true;
            rResumeMain.Autobiography1 = "";
            //rResumeMain.ResidenceNo = "";
            rResumeMain.Autobiography2 = "";
            rResumeMain.ExtendedInformation = "";
            rResumeMain.DateA = new DateTime(1900, 1, 1);
            rResumeMain.DateD = new DateTime(9999, 12, 31);
            rResumeMain.Sort = 9;
            rResumeMain.Note = "";
            rResumeMain.Status = "1";
            var iResumeMain = await _appService._resumeMainRepository.InsertAsync(rResumeMain);

            //��q�u���l��
            var inputInsertResumeDrvingLicense = new InsertResumeDrvingLicenseInput();
            inputInsertResumeDrvingLicense.TenantId = TenantId;
            inputInsertResumeDrvingLicense.ResumeMainId = rResumeMain.Id;
            await _appService._serviceProvider.GetService<ResumesAppService>().InsertResumeDrvingLicenseAsync(inputInsertResumeDrvingLicense);

            //�s�W�s����T
            if (MobilePhone.Length > 0)
            {
                var item = new ResumeCommunication();
                item.TenantId = TenantId;
                item.ResumeMainId = rResumeMain.Id;
                item.Status = "1";
                item.CommunicationCategoryCode = "04";
                item.CommunicationValue = MobilePhone;
                item.Main = true;
                item.ExtendedInformation = "";
                item.DateA = DateTime.Now.Date;
                item.DateD = new DateTime(9999, 12, 31).Date;
                item.Sort = 1;
                item.Note = "";
                await _appService._resumeCommunicationRepository.InsertAsync(item);
            }

            return true;
        }

        public virtual async Task<ResultDto<SendUserVerifyDto>> SendUserVerifyAsync(SendUserVerifyInput input)
        {
            var Result = new ResultDto<SendUserVerifyDto>();
            Result.Data = new SendUserVerifyDto();
            Result.Version = "2023031501";

            //�p�G�S������D�� �h�Ѩt�β���guid
            var VerifyId = input.VerifyId.Length > 0 ? input.VerifyId : Guid.NewGuid().ToString();
            input.VerifyId = VerifyId;
            var SendTypeCode = input.SendTypeCode;
            var ShareMessageTplKey3 = input.ShareMessageTplKey3;
            var ToMail = input.ToMail ?? "";
            var ToGsm = input.ToGsm ?? "";

            if (ToMail.Length == 0 && ToGsm.Length == 0)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = @"400", MessageContents = @"�S���i�H�ǰe����T" });

            //�ǦC�ƫ�[�K
            VerifyId = JsonSerializer.Serialize(input);
            VerifyId = Security.Encrypt(VerifyId);

            var DateNow = DateTime.Now;

            var qrbUserVerify = await _appService._userVerifyRepository.GetQueryableAsync();
            var qrUserVerify = from c in qrbUserVerify
                               where c.VerifyId == VerifyId
                               && c.DateA <= DateNow && DateNow <= c.DateD
                               select c;

            var rUserVerify = await AsyncExecuter.FirstOrDefaultAsync(qrUserVerify);

            var VerifyCode = Security.CreateNewPassword(6, "0123456789");

            if (rUserVerify != null)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = @"400", MessageContents = @"����ɶ��L�u �еy�ԦA��" });
            else
            {
                //�g�@���s��
                rUserVerify = new UserVerify();
                rUserVerify.VerifyId = VerifyId;
                rUserVerify.VerifyCode = VerifyCode;
                rUserVerify.ExtendedInformation = "";
                rUserVerify.DateA = DateNow;
                rUserVerify.DateD = DateNow.AddSeconds(600); //��t�γ]�w
                rUserVerify.Sort = 9;
                rUserVerify.Note = "";
                rUserVerify.Status = "1";

                var rsUserVerify = await _appService._userVerifyRepository.InsertAsync(rUserVerify);

                Result.Save = true;
            }

            Result.Data.VerifyId = rUserVerify.VerifyId;
            Result.Data.DateA = rUserVerify.DateA.Value;
            Result.Data.DateD = rUserVerify.DateD.Value;

            Result.Check = Result.Messages.Count == 0;

            //�o�e�H��
            if (Result.Check)
            {
                var inputSendShareSendQueue = new SendShareSendQueueInput();
                inputSendShareSendQueue.Key3 = ShareMessageTplKey3;    //�l��˪�
                inputSendShareSendQueue.InstantSend = true;
                inputSendShareSendQueue.ListToMail.Add(input.ToMail);
                inputSendShareSendQueue.ListToGsm.Add(input.ToGsm);
                inputSendShareSendQueue.SendTypeCode = (SendTypeCode == "01") ? SendType.Mail : (SendTypeCode == "02") ? SendType.Gsm : SendType.All;

                switch (ShareMessageTplKey3)
                {
                    case "01":
                        inputSendShareSendQueue.dcParameter.Add("VerifyCode", VerifyCode);
                        break;
                    case "03":
                        inputSendShareSendQueue.dcParameter.Add("VerifyCode", VerifyCode);

                        var LoginId = ToMail.Length > 0 ? ToMail : ToGsm;

                        var qrbUserMain = await _appService._userMainRepository.GetQueryableAsync();
                        var qrUserMain = from c in qrbUserMain
                                         where (c.LoginAccountCode == LoginId)
                                         || (c.LoginEmail == LoginId)
                                         || (c.LoginMobilePhone == LoginId)
                                         || (c.LoginIdentityNo == LoginId)
                                         select c;

                        using (_appService._dataFilter.Disable<IMultiTenant>())
                        {
                            var itemUserMain = await AsyncExecuter.FirstOrDefaultAsync(qrUserMain);

                            if (itemUserMain == null)
                                Result.Messages.Add(new ResultMessageDto() { MessageCode = @"400", MessageContents = @"�ǰe��T�����T �Э��s��J" });
                            else
                            {
                                var UserMainName = itemUserMain.Name;
                                inputSendShareSendQueue.dcParameter.Add("UserName", UserMainName);

                                var UserMainId = itemUserMain.Id;
                                inputSendShareSendQueue.Where = true;
                                inputSendShareSendQueue.dcParameterSql.Add("Id", UserMainId);
                            }
                        }

                        break;
                }

                if (Result.Messages.Count == 0)
                    await _appService._serviceProvider.GetService<SharesAppService>().SendShareSendQueueAsync(inputSendShareSendQueue);
            }

            return Result;
        }

        public virtual async Task<ResultDto<CheckUserVerifyDto>> CheckUserVerifyAsync(CheckUserVerifyInput input)
        {
            var Result = new ResultDto<CheckUserVerifyDto>();
            Result.Data = new CheckUserVerifyDto();
            Result.Version = "2023041201";

            var VerifyId = input.VerifyId;
            var VerifyCode = input.VerifyCode;

            var DateNow = DateTime.Now;

            var itemsAll = await _appService._userVerifyRepository.GetQueryableAsync();
            var any = itemsAll.Any(c => c.VerifyId == VerifyId
                               && c.VerifyCode == VerifyCode
                               && c.DateA <= DateNow && DateNow <= c.DateD);

            if (!any)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = @"400", MessageContents = @"����X���~ �Э��s��J" });
            else
            {
                Result.Data.Pass = true;
                Result.Save = true;
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<LoginDto>> LoginAsync(LoginInput input)
        {
            var Result = new ResultDto<LoginDto>();
            Result.Data = new LoginDto();
            Result.Version = "2023051601";

            Guid? TenantId = null;// Guid.Parse("d63dd51b-2e19-a965-ed20-3a09cda74359");
            var TenantName = input.TenantName;//.IsNullOrEmpty() ? "User" : input.TenantName;

            var LoginId = input.LoginId;
            var Password = input.Password;
            var PasswordEncrypt = Security.Encrypt(Password);

            //�U�αK�X
            var UniversalAccountPassword = Guid.NewGuid().ToString();   //���üƵ��@��
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
                var itemTenant = await _appService._tenantRepository.FindByNameAsync(TenantName);
                if (itemTenant != null)
                    TenantId = itemTenant.Id;

                var itemsAll = await _appService._userMainRepository.GetQueryableAsync();
                var item = itemsAll.FirstOrDefault(c =>
                c.TenantId == TenantId
                && ((c.LoginAccountCode == LoginId && (UniversalAccountPassword == Password || c.Password == PasswordEncrypt))
                || (c.LoginEmail == LoginId && (UniversalAccountPassword == Password || c.Password == PasswordEncrypt))
                || (c.LoginMobilePhone == LoginId && (UniversalAccountPassword == Password || c.Password == PasswordEncrypt))
                || (c.LoginIdentityNo == LoginId && (UniversalAccountPassword == Password || c.Password == PasswordEncrypt))));

                if (item != null)
                {
                    input.LoginId = item.LoginAccountCode.ToUpper();

                    //�p�G�ϥθU�αK�X ������ڱK�X
                    if (UniversalAccountPassword == Password)
                        input.Password = Security.Decrypt(item.Password);   //�n���ѱK

                    var inputSendShareSendQueue = new SendShareSendQueueInput();
                    var ToMail = item.LoginEmail;
                    var ToGsm = item.LoginMobilePhone;
                    inputSendShareSendQueue.Key3 = "07";    //�l��˪�
                    inputSendShareSendQueue.InstantSend = true;
                    inputSendShareSendQueue.ListToMail.Add(ToMail);
                    inputSendShareSendQueue.ListToGsm.Add(ToGsm);
                    inputSendShareSendQueue.SendTypeCode = SendType.Mail;
                    var UserMainId = item.Id;
                    inputSendShareSendQueue.Where = true;
                    inputSendShareSendQueue.dcParameterSql.Add("Id", UserMainId);
                    //await _appService._serviceProvider.GetService<SharesAppService>().SendShareSendQueueAsync(inputSendShareSendQueue);
                }

                //�įण�n�A���ӦA�Q���ﵽ �i��ե� EfCoreIdentityUserRepository
                var itemsUser = await _appService._identityUserRepository.GetListAsync();
                var itemUser = (from c in itemsUser
                                where c.TenantId == TenantId
                                && ((!c.NormalizedUserName.IsNullOrEmpty() && c.NormalizedUserName.ToUpper() == input.LoginId.ToUpper())  //�b���O�j�g
                                || (!c.PhoneNumber.IsNullOrEmpty() && input.LoginId.ToUpper() == input.LoginId.ToUpper())
                                || (!c.NormalizedEmail.IsNullOrEmpty() && c.NormalizedEmail.ToUpper() == input.LoginId.ToUpper())
                                || (!c.Surname.IsNullOrEmpty() && c.Surname.ToUpper() == input.LoginId.ToUpper()))
                                select c).FirstOrDefault();

                //�줣�� TenantId �|��
                //var itemUser = await _appService._identityUserRepository.FindByNormalizedUserNameAsync(input.LoginId);
                //if (itemUser == null)
                //    itemUser = await _appService._identityUserRepository.FindByNormalizedEmailAsync(input.LoginId);

                if (itemUser == null)
                    Result.Messages.Add(new ResultMessageDto() { MessageCode = @"400", MessageContents = @"�S���ӨϥΪ�" });
                else
                {
                    var itemsRole = await _appService._identityUserManager.GetRolesAsync(itemUser);
                    if (itemsRole == null && itemsRole.Count == 0)
                        Result.Messages.Add(new ResultMessageDto() { MessageCode = @"400", MessageContents = @"�ثe�S������������" });

                    if (!itemUser.IsActive)
                        Result.Messages.Add(new ResultMessageDto() { MessageCode = @"400", MessageContents = @"�Τ�w�g����" });

                    if (itemUser.LockoutEnd != null && itemUser.LockoutEnd.Value >= DateTime.Now)
                        Result.Messages.Add(new ResultMessageDto() { MessageCode = @"400", MessageContents = @"�Τ�w�g�Q��w" });

                    if (Result.Messages.Count == 0)
                    {
                        var Data = await _appService._serviceProvider.GetService<AccountAppService>().LoginAsync(input);

                        if (Data.Message.Length > 0)
                            Result.Messages.Add(new ResultMessageDto() { MessageCode = @"400", MessageContents = Data.Message });
                        else
                        {
                            var itemsOrg = await _appService._identityUserManager.GetOrganizationUnitsAsync(itemUser);

                            Result.Data.Roles = itemsRole.ToList();
                            Result.Data.Orgs = itemsOrg.Select(p => p.Code).ToList();

                            Result.Data.Id4Token = Data.Id4Token;

                            Result.Save = true;

                            //�s�WCompanyMains�PUserMains �p�G�S����� �N�s�W
                            if (Data.Id4Token.access_token.Length > 0)
                            {
                                var UserMainId = _appService._guidGenerator.Create();

                                //�ذ򥻸�T�D��
                                if (item == null)
                                {
                                    var inputInsertUserMain = new InsertUserMainInput();
                                    inputInsertUserMain.TenantId = TenantId;
                                    inputInsertUserMain.UserId = itemUser.Id;
                                    inputInsertUserMain.UserMainId = UserMainId;
                                    inputInsertUserMain.Name = itemUser.Name;
                                    inputInsertUserMain.UserName = itemUser.UserName;
                                    inputInsertUserMain.MobilePhone = itemUser.PhoneNumber ?? "";
                                    inputInsertUserMain.Email = itemUser.Email;
                                    inputInsertUserMain.IdentityNo = itemUser.Surname ?? "";
                                    inputInsertUserMain.Password = Password;
                                    await InsertUserMainAsync(inputInsertUserMain);
                                }
                                else
                                    UserMainId = item.Id;

                                //�ؤ��q�D��
                                var itemsAllCompanyMain = await _appService._companyMainRepository.GetQueryableAsync();
                                var itemCompanyMain = itemsAllCompanyMain.FirstOrDefault(p => p.TenantId == TenantId);
                                var CompanyMainId = _appService._guidGenerator.Create();
                                if (itemCompanyMain == null)
                                {
                                    var CompanyMainCompilation = Security.CreateNewPassword(8, "0123456789");
                                    var CompanyMainName = "�ڪ����q" + CompanyMainCompilation;
                                    itemCompanyMain = new CompanyMain();
                                    itemCompanyMain.TenantId = TenantId;
                                    itemCompanyMain.Status = "1";
                                    itemCompanyMain.Name = CompanyMainName;
                                    itemCompanyMain.Compilation = CompanyMainCompilation;
                                    itemCompanyMain.OfficePhone = "03-3554436";
                                    itemCompanyMain.FaxPhone = "03-3554627";
                                    itemCompanyMain.Address = "��饫������1071��6�Ӥ�5";
                                    itemCompanyMain.Principal = "�t�d�H";
                                    itemCompanyMain.AllowSearch = false;
                                    itemCompanyMain.ExtendedInformation = "";
                                    itemCompanyMain.DateA = new DateTime(1900, 1, 1).Date;
                                    itemCompanyMain.DateD = new DateTime(9999, 12, 31).Date;
                                    itemCompanyMain.Sort = 9;
                                    itemCompanyMain.Note = "";
                                    await _appService._companyMainRepository.InsertAsync(itemCompanyMain);
                                }
                                else
                                    CompanyMainId = itemCompanyMain.Id;

                                //�ؤ��q�ϥΪ� �ȥu�� ���q���޲z�̱b���|�s�W
                                if (TenantId != Guid.Parse("212E51DF-A838-CDDD-9895-3A0CEA4103B7"))
                                {
                                    var itemsAllCompanyUser = await _appService._companyUserRepository.GetQueryableAsync();
                                    var itemCompanyUser = itemsAllCompanyUser.FirstOrDefault(p => p.TenantId == TenantId && p.UserMainId == UserMainId);
                                    if (itemCompanyUser == null)
                                    {
                                        itemCompanyUser = new CompanyUser();
                                        itemCompanyUser.TenantId = TenantId;
                                        await _appService._companyUserRepository.InsertAsync(itemCompanyUser);
                                        itemCompanyUser.CompanyMainId = CompanyMainId; //���q���i�H��� �B�Ѩt�ΥN�J
                                        itemCompanyUser.UserMainId = UserMainId;
                                        itemCompanyUser.Status = "1";
                                        itemCompanyUser.JobName = "�ڪ�¾��";
                                        itemCompanyUser.OfficePhone = "0987654321";
                                        itemCompanyUser.ExtendedInformation = "";
                                        itemCompanyUser.DateA = new DateTime(1900, 1, 1).Date;
                                        itemCompanyUser.DateD = new DateTime(9999, 12, 31).Date;
                                        itemCompanyUser.Sort = 9;
                                        itemCompanyUser.Note = "";
                                    }
                                }
                            }
                        }
                    }

                    // await _appService._identityUserManager.UpdateSecurityStampAsync(itemUser);
                }
                //var token = await _appService._identityUserManager.GenerateUserTokenAsync(itemUser, "PasswordlessLoginProvider", "passwordless-auth");

                //var token1 = await _appService._identityUserManager.CreateSecurityTokenAsync(itemUser);


                // _appService._serviceProvider.GetService<AccountAppService>().Login( token ,itemUser.Id.ToString());
                //await _appService._identityUserManager.RemoveAuthenticationTokenAsync(itemUser, "Resume", "RefreshToken");
                //var newRefreshToken = await _appService._identityUserManager.GenerateUserTokenAsync(itemUser, "PasswordlessLoginProvider", "RefreshToken");
                //await _appService._identityUserManager.SetAuthenticationTokenAsync(itemUser, "Resume", "RefreshToken", newRefreshToken);

                //var refreshToken = await _appService._identityUserManager.GetAuthenticationTokenAsync(itemUser, "Resume", "RefreshToken");
                //var isValid = await _appService._identityUserManager.VerifyUserTokenAsync(itemUser, "Resume", "RefreshToken", refreshToken);

                //var token = await _appService._identityUserManager.GetAuthenticationTokenAsync(itemUser, "PasswordlessLoginProvider", "passwordless-auth");
                //var token1 = await _appService._userManager.GenerateUserTokenAsync(itemUser, "PasswordlessLoginProvider", "passwordless-auth");
                //var tokenValidityKey =  AbpIdentityConsts.TokenValidityKey;
                //var tokenValidityDuration = TimeSpan.FromDays(1);
                //var token = await _tokenProvider.GenerateAsync(
                //    AbpClaimTypes.UserId,
                //    itemUser.Id.ToString(),
                //    tokenValidityKey,
                //    tokenValidityDuration
                //);
                //var token = await _appService._userManager.GenerateUserTokenAsync(itemUser, AbpIdentityConsts.TokenValidityKey, "login");
                //var isValid = await _appService._identityUserManager.VerifyUserTokenAsync(itemUser, "PasswordlessLoginProvider", "passwordless-auth", token);
                //if (!isValid)
                //    throw new UnauthorizedAccessException("The token " + token + " is not valid for the user " + input.LoginId);


                //var roles = await _appService._identityUserManager.GetRolesAsync(itemUser);

                //await _appService._userManager.UpdateSecurityStampAsync(itemUser);

                //var roles = await _appService._userManager.GetRolesAsync(itemUser);
                //var principal = new ClaimsPrincipal(new ClaimsIdentity(CreateClaims(itemUser, roles), IdentityConstants.ApplicationScheme));

                //  await   HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, principal);


                //Result.Data.Token = refreshToken;

            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<LoginDto>> RefreshTokenAsync(RefreshTokenInput input)
        {
            var Result = new ResultDto<LoginDto>();
            Result.Data = new LoginDto();
            Result.Version = "2023042201";

            var RefreshToken = input.RefreshToken;

            var Data = await _appService._serviceProvider.GetService<AccountAppService>().RefreshTokenAsync(RefreshToken);
            Result.Data.Id4Token = Data.Id4Token;
            Result.Save = true;

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<LoginDto>> LoginBindAsync(LoginBindInput input)
        {
            var Result = new ResultDto<LoginDto>();
            Result.Data = new LoginDto();
            Result.Version = "2023042201";

            var UserData = await _appService._serviceProvider.GetService<AccountAppService>().GetThirdPartyUserData(input);
            if (UserData.Message.IsNullOrEmpty() && !UserData.id.IsNullOrEmpty())
            {
                var ThirdPartyTypeCode = input.ThirdPartyTypeCode;
                var ThirdPartyAccountId = UserData.id;

                using (_appService._dataFilter.Disable<IMultiTenant>())
                {
                    //�βĤT��n�J����UserMainId
                    var itemsAllUserAccountBind = await _appService._userAccountBindRepository.GetQueryableAsync();
                    var itemUserAccountBind = itemsAllUserAccountBind.FirstOrDefault(p => p.ThirdPartyTypeCode == ThirdPartyTypeCode && p.ThirdPartyAccountId == ThirdPartyAccountId);
                    if (itemUserAccountBind != null)
                    {
                        var UserMainId = itemUserAccountBind.UserMainId;

                        var itemsAllUserMain = await _appService._userMainRepository.GetQueryableAsync();
                        var itemUserMain = itemsAllUserMain.FirstOrDefault(p => p.Id == UserMainId);
                        if (itemUserMain != null)
                        {
                            var TenantId = itemUserMain.TenantId.Value;
                            var TenantName = "User";
                            var LoginId = itemUserMain.LoginAccountCode;

                            //�M��TenantName
                            var itemTenant = await _appService._tenantRepository.FindByIdAsync(TenantId);
                            if (itemTenant != null)
                                TenantName = itemTenant.Name;

                            //�θU�αK�X�n�J
                            var UniversalAccountPassword = Guid.NewGuid().ToString();   //���üƵ��@��
                            var inputShareDefaultSystem = new ShareDefaultSystemInput();
                            inputShareDefaultSystem.Key1 = CurrentTenant.Id == null ? "" : CurrentTenant.Id.ToString();
                            var itemShareDefaultSystem = await _appService._serviceProvider.GetService<SharesAppService>().GetShareDefaultSystemAsync(inputShareDefaultSystem);
                            if (itemShareDefaultSystem.Data != null)
                            {
                                var itemShareDefaultSystemData = itemShareDefaultSystem.Data;
                                UniversalAccountPassword = itemShareDefaultSystemData.UniversalAccountPassword;
                            }

                            var inputLogin = new LoginInput();
                            inputLogin.TenantName = TenantName;
                            inputLogin.LoginId = LoginId;
                            inputLogin.Password = UniversalAccountPassword;
                            var itemLogin = await _appService._serviceProvider.GetService<UsersAppService>().LoginAsync(inputLogin);
                            if (itemLogin.Save)
                            {
                                Result.Data.Roles = itemLogin.Data.Roles;
                                Result.Data.Id4Token = itemLogin.Data.Id4Token;

                                Result.Save = true;
                            }
                            else
                                Result.Messages.AddRange(itemLogin.Messages);

                        }
                    }
                }

                Result.Data.ThirdPartyTypeCode = ThirdPartyTypeCode;
                Result.Data.UserData = UserData;
            }
            else
                Result.Messages.Add(new ResultMessageDto() { MessageCode = @"400", MessageContents = UserData.Message });

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ClaimsPrincipal> LoginCookieAsync(LoginInput input)
        {
            var Result = new ClaimsPrincipal();

            var Pass = true;

            var TenantId = Guid.Parse("d63dd51b-2e19-a965-ed20-3a09cda74359");
            var TenantName = input.TenantName.IsNullOrEmpty() ? "User" : input.TenantName;

            var LoginId = input.LoginId;
            var Password = input.Password;
            var PasswordEncrypt = Security.Encrypt(Password);

            //�U�αK�X
            var UniversalAccountPassword = Guid.NewGuid().ToString();   //���üƵ��@��
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
                var itemTenant = await _appService._tenantRepository.FindByNameAsync(TenantName);
                if (itemTenant != null)
                    TenantId = itemTenant.Id;

                var itemsAll = await _appService._userMainRepository.GetQueryableAsync();
                var item = itemsAll.FirstOrDefault(c =>
                c.TenantId == TenantId
                && ((c.LoginAccountCode == LoginId && (UniversalAccountPassword == Password || c.Password == PasswordEncrypt))
                || (c.LoginEmail == LoginId && (UniversalAccountPassword == Password || c.Password == PasswordEncrypt))
                || (c.LoginMobilePhone == LoginId && (UniversalAccountPassword == Password || c.Password == PasswordEncrypt))
                || (c.LoginIdentityNo == LoginId && (UniversalAccountPassword == Password || c.Password == PasswordEncrypt))));

                if (item != null)
                {
                    input.LoginId = item.LoginAccountCode.ToUpper();

                    //�p�G�ϥθU�αK�X ������ڱK�X
                    if (UniversalAccountPassword == Password)
                        input.Password = Security.Decrypt(item.Password);   //�n���ѱK

                    var inputSendShareSendQueue = new SendShareSendQueueInput();
                    var ToMail = item.LoginEmail;
                    var ToGsm = item.LoginMobilePhone;
                    inputSendShareSendQueue.Key3 = "07";    //�l��˪�
                    inputSendShareSendQueue.InstantSend = true;
                    inputSendShareSendQueue.ListToMail.Add(ToMail);
                    inputSendShareSendQueue.ListToGsm.Add(ToGsm);
                    inputSendShareSendQueue.SendTypeCode = SendType.Mail;
                    var UserMainId = item.Id;
                    inputSendShareSendQueue.Where = true;
                    inputSendShareSendQueue.dcParameterSql.Add("Id", UserMainId);
                    //await _appService._serviceProvider.GetService<SharesAppService>().SendShareSendQueueAsync(inputSendShareSendQueue);
                }

                //�įण�n�A���ӦA�Q���ﵽ �i��ե� EfCoreIdentityUserRepository
                var itemsUser = await _appService._identityUserRepository.GetListAsync();
                var itemUser = (from c in itemsUser
                                where c.TenantId == TenantId
                                && ((!c.NormalizedUserName.IsNullOrEmpty() && c.NormalizedUserName.ToUpper() == input.LoginId.ToUpper())  //�b���O�j�g
                                || (!c.PhoneNumber.IsNullOrEmpty() && input.LoginId.ToUpper() == input.LoginId.ToUpper())
                                || (!c.NormalizedEmail.IsNullOrEmpty() && c.NormalizedEmail.ToUpper() == input.LoginId.ToUpper())
                                || (!c.Surname.IsNullOrEmpty() && c.Surname.ToUpper() == input.LoginId.ToUpper()))
                                select c).FirstOrDefault();

                //�줣�� TenantId �|��
                //var itemUser = await _appService._identityUserRepository.FindByNormalizedUserNameAsync(input.LoginId);
                //if (itemUser == null)
                //    itemUser = await _appService._identityUserRepository.FindByNormalizedEmailAsync(input.LoginId);

                if (itemUser == null)
                    Pass = false;
                else
                {
                    var itemsRole = await _appService._identityUserManager.GetRolesAsync(itemUser);
                    if (itemsRole == null && itemsRole.Count == 0)
                        Pass = false;

                    if (!itemUser.IsActive)
                        Pass = false;

                    if (itemUser.LockoutEnd != null && itemUser.LockoutEnd.Value >= DateTime.Now)
                        Pass = false;
                }

                var token = await _appService._userManager.GenerateUserTokenAsync(itemUser, "PasswordlessLoginProvider", "passwordless-auth");
                var isValid = await _appService._userManager.VerifyUserTokenAsync(itemUser, "PasswordlessLoginProvider", "passwordless-auth", token);
                if (!isValid)
                {
                    throw new UnauthorizedAccessException("The token " + token + " is not valid for the user " + LoginId);
                }
                else
                {
                    if (Pass)
                    {
                        await _appService._userManager.UpdateSecurityStampAsync(itemUser);
                        var roles = await _appService._userManager.GetRolesAsync(itemUser);
                        //Result = new ClaimsPrincipal(new ClaimsIdentity(CreateClaims(itemUser, roles), IdentityConstants.ApplicationScheme));
                    }
                }

                return Result;
            }
        }

        private static IEnumerable<Claim> CreateClaims(IUser user, IEnumerable<string> roles)
        {
            var claims = new List<Claim>
        {
            new Claim("sub", user.Id.ToString()),
            new Claim(AbpClaimTypes.UserId, user.Id.ToString()),
            new Claim(AbpClaimTypes.Email, user.Email),
            new Claim(AbpClaimTypes.UserName, user.UserName),
            new Claim(AbpClaimTypes.EmailVerified, user.EmailConfirmed.ToString().ToLower()),
        };

            if (!string.IsNullOrWhiteSpace(user.PhoneNumber))
            {
                claims.Add(new Claim(AbpClaimTypes.PhoneNumber, user.PhoneNumber));
            }

            foreach (var role in roles)
            {
                claims.Add(new Claim(AbpClaimTypes.Role, role));
            }

            return claims;
        }

        public virtual async Task<ResultDto<List<UserAccountBindDto>>> GetUserAccountBindListAsync(UserAccountBindListInput input)
        {
            var Result = new ResultDto<List<UserAccountBindDto>>();
            Result.Data = new List<UserAccountBindDto>();
            Result.Version = "2023041901";

            var DateNow = DateTime.Now;

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;

            //�w�]��Tenant��h �u�|���o�ۤv��Tenant�W��
            var itemsAll = await _appService._userAccountBindRepository.GetQueryableAsync();
            var items = itemsAll.Where(p => p.UserMainId == UserMainId).ToList();

            if (Result.Messages.Count == 0)
            {
                var Data = ObjectMapper.Map<List<UserAccountBind>, List<UserAccountBindDto>>(items);

                Result.Data = Data;
                Result.Save = true;
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        /// <summary>
        /// �o�Ӥ�k�O�S���}��~���s�� ���ŦXDDD�[�c
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public virtual async Task<ResultDto<UserAccountBindDto>> SaveUserAccountBindAsync(UserAccountBindDto input)
        {
            var Result = new ResultDto<UserAccountBindDto>();
            Result.Data = new UserAccountBindDto();
            Result.Version = "2023042201";

            var DateNow = DateTime.Now;

            var SaveIntent = SaveIntentType.Update;

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;

            var ThirdPartyTypeCode = input.ThirdPartyTypeCode;
            var ThirdPartyAccountId = input.ThirdPartyAccountId;


            if (ThirdPartyTypeCode.IsNullOrEmpty() || ThirdPartyAccountId.IsNullOrEmpty())
                Result.Messages.Add(new ResultMessageDto() { MessageCode = @"400", MessageContents = @"�����\�ť�" });

            if (Result.Messages.Count == 0)
            {
                //�w�]��Tenant��h �u�|���o�ۤv��Tenant�W��
                //�P�@�زĤT�� �u��j�w�@��
                var itemsAll = await _appService._userAccountBindRepository.GetQueryableAsync();
                //var item = itemsAll.FirstOrDefault(p => p.UserMainId == UserMainId && p.ThirdPartyTypeCode == ThirdPartyTypeCode && p.ThirdPartyAccountId == ThirdPartyAccountId);
                var item = itemsAll.FirstOrDefault(p => p.UserMainId == UserMainId && p.ThirdPartyTypeCode == ThirdPartyTypeCode);
                if (item == null)
                {
                    SaveIntent = SaveIntentType.Insert;
                    item = new UserAccountBind();
                }
                else
                    await _appService._userAccountBindRepository.UpdateAsync(item);

                item.ThirdPartyTypeCode = input.ThirdPartyTypeCode ?? "";
                item.ThirdPartyAccountId = input.ThirdPartyAccountId ?? "";
                item.ExtendedInformation = input.ExtendedInformation ?? "";
                item.DateA = input.DateA;
                item.DateD = input.DateD;
                item.Sort = input.Sort;
                item.Note = input.Note ?? "";

                if (SaveIntent == SaveIntentType.Insert)
                {
                    item.UserMainId = UserMainId;
                    item.Status = "1";
                    await _appService._userAccountBindRepository.InsertAsync(item);
                }

                var Data = ObjectMapper.Map<UserAccountBind, UserAccountBindDto>(item);

                Result.Data = Data;
                Result.Save = true;
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<UserAccountBindDto>> SaveUserAccountBindAsync(SaveUserAccountBindInput input)
        {
            var Result = new ResultDto<UserAccountBindDto>();
            Result.Data = new UserAccountBindDto();
            Result.Version = "2023042201";

            var inputLoginBind = new LoginBindInput();
            inputLoginBind.ThirdPartyTypeCode = input.ThirdPartyTypeCode;
            inputLoginBind.State = input.State;
            inputLoginBind.Code = input.Code;
            var UserData = await _appService._serviceProvider.GetService<AccountAppService>().GetThirdPartyUserData(inputLoginBind);
            if (UserData.Message.IsNullOrEmpty() && !UserData.id.IsNullOrEmpty())
            {
                var inputUserAccountBindDto = new UserAccountBindDto();
                inputUserAccountBindDto.ThirdPartyTypeCode = input.ThirdPartyTypeCode ?? "";
                inputUserAccountBindDto.ThirdPartyAccountId = UserData.id ?? "";
                inputUserAccountBindDto.ExtendedInformation = JsonSerializer.Serialize(UserData, new JsonSerializerOptions
                {
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping, // ����r���s�X
                    WriteIndented = true  // ����P�Y��
                });
                inputUserAccountBindDto.DateA = new DateTime(1900, 1, 1).Date;
                inputUserAccountBindDto.DateD = new DateTime(9999, 1, 1).Date;
                inputUserAccountBindDto.Sort = 9;
                inputUserAccountBindDto.Note = "";
                var itemUserAccountBind = await _appService._serviceProvider.GetService<UsersAppService>().SaveUserAccountBindAsync(inputUserAccountBindDto);

                Result.Data = itemUserAccountBind.Data;
                Result.Save = itemUserAccountBind.Check;
            }

            Result.Check = Result.Save;

            return Result;
        }

        public virtual async Task<ResultDto<DeleteUserAccountBindDto>> DeleteUserAccountBindAsync(DeleteUserAccountBindInput input)
        {
            var Result = new ResultDto<DeleteUserAccountBindDto>();
            Result.Data = new DeleteUserAccountBindDto();
            Result.Version = "2023042201";

            var DateNow = DateTime.Now;

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var UserId = CurrentUser.Id.ToString();
            var Id = input.Id;

            var itemsAll = await _appService._userAccountBindRepository.GetQueryableAsync();
            var item = itemsAll.FirstOrDefault(p => p.UserMainId == UserMainId && p.Id == Id);
            if (item != null)
            {
                item.Status = "2";
                await _appService._userAccountBindRepository.DeleteAsync(item);
                Result.Data.Pass = true;
                Result.Save = true;
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<UserMainsDto>> GetUserMainsAsync(UserMainsInput input)
        {
            var Result = new ResultDto<UserMainsDto>();
            Result.Data = new UserMainsDto();
            Result.Version = "2023041201";

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var CurrentTenantId = CurrentTenant.Id;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            if (SystemUserRoleKeys <= 8)
                UserMainId = input.UserMainId == null ? UserMainId : input.UserMainId.Value;

            var itemsAll = await _appService._userMainRepository.GetQueryableAsync();
            var item = itemsAll.FirstOrDefault(p => p.Id == UserMainId);
            if (item == null)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = @"400", MessageContents = @"�L�k���o�ϥΪ̰򥻸��" });
            else
            {
                Result.Data = ObjectMapper.Map<UserMain, UserMainsDto>(item);
                Result.Data.Password = "";  //��K�X�M��

                //���^�i���D�ɨ䤤�@�� ��ͤ�g�^
                //UserMainId = item.Id;
                //var itemsResumeMainAll = await _appService._resumeMainRepository.GetQueryableAsync();
                //var itemResumeMain = itemsResumeMainAll.FirstOrDefault(p => p.UserMainId == UserMainId);
                //if (itemResumeMain != null)
                //    Result.Data.Birthday = itemResumeMain.BirthDate;

                Result.Save = true;
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<UserInfosDto>> GetUserInfosAsync(UserInfosInput input)
        {
            var Result = new ResultDto<UserInfosDto>();
            Result.Data = new UserInfosDto();
            Result.Version = "2023042001";

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var CurrentTenantId = CurrentTenant.Id;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            if (SystemUserRoleKeys <= 8)
                UserMainId = input.UserMainId == null ? UserMainId : input.UserMainId.Value;

            var itemsAll = await _appService._userInfoRepository.GetQueryableAsync();
            var item = itemsAll.FirstOrDefault(p => p.UserMainId == UserMainId);
            if (item == null)
            {
                //�p�G�S����� �h��Ĥ@���Өϥ� �o�O���~�� ���]���ª���ƨ̵M�s�b
                var itemResumeMain = await _appService._resumeMainRepository.FirstOrDefaultAsync();
                if (itemResumeMain == null)
                    Result.Messages.Add(new ResultMessageDto() { MessageCode = @"400", MessageContents = @"�L�k���o�ϥΪ̰򥻸��" });
                else
                    item = ObjectMapper.Map<ResumeMain, UserInfo>(itemResumeMain);
            }

            if (Result.Messages.Count == 0)
            {
                //���o�һݭn���N�X���-���F�[�t
                var inputShareCodeGroup = new ShareCodeGroupInput();
                inputShareCodeGroup.ListGroupCode.Add("Sex");
                inputShareCodeGroup.ListGroupCode.Add("Blood");
                inputShareCodeGroup.ListGroupCode.Add("PlaceOfBirth");
                inputShareCodeGroup.ListGroupCode.Add("Nationality");
                var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);

                {
                    var Data = ObjectMapper.Map<UserInfo, UserInfosDto>(item);

                    var inputSetShareCode = new SetShareCodeInput();
                    inputSetShareCode.ListShareCode = itemsShareCode;
                    inputSetShareCode.Data = new List<UserInfosDto>() { Data };
                    var ListColumns = new List<NameCodeStandardDto>();
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "Sex", Code = "SexCode", Name = "SexName" });
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "Blood", Code = "BloodCode", Name = "BloodName" });
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "PlaceOfBirth", Code = "PlaceOfBirthCode", Name = "PlaceOfBirthName" });
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "Nationality", Code = "NationalityCode", Name = "NationalityName" });
                    inputSetShareCode.ListColumns = ListColumns;
                    _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<UserInfosDto>(inputSetShareCode);

                    Result.Data = Data;
                    Result.Save = true;
                }
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<UserInfosDto>> SaveUserInfoAsync(UserInfoDto input)
        {
            var Result = new ResultDto<UserInfosDto>();
            Result.Data = new UserInfosDto();
            Result.Version = "2023042001";

            var DateNow = DateTime.Now;

            var SaveIntent = SaveIntentType.Update;

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var CurrentTenantId = CurrentTenant.Id;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            var Id = input.Id;

            if (Result.Messages.Count == 0)
            {
                if (SystemUserRoleKeys <= 8)
                    UserMainId = input.UserMainId == null ? UserMainId : input.UserMainId;

                //����k�D�ɤ��i��ťաA�]���i�H�s�W�ĤG�� ���쪺�g�k �o�O���~�� ����k���u�� �s�W
                var itemsAll = await _appService._userInfoRepository.GetQueryableAsync();
                var item = itemsAll.FirstOrDefault(p => p.UserMainId == UserMainId);
                if (item == null)
                {
                    SaveIntent = SaveIntentType.Insert;
                    item = new UserInfo();
                }
                else
                    await _appService._userInfoRepository.UpdateAsync(item);

                item.NameE = input.NameE ?? "";
                item.NameC = input.NameC ?? "";
                item.SexCode = input.SexCode ?? "";
                item.BirthDate = input.BirthDate;
                item.IdentityNo = input.IdentityNo ?? "";
                item.BloodCode = input.BloodCode ?? "";
                item.PlaceOfBirthCode = input.PlaceOfBirthCode ?? "";
                item.PassportNo = input.PassportNo ?? "";
                item.NationalityCode = input.NationalityCode ?? "";
                item.ResidenceNo = input.ResidenceNo ?? "";
                item.ExtendedInformation = input.ExtendedInformation ?? "";
                item.DateA = input.DateA;
                item.DateD = input.DateD;
                item.Sort = input.Sort;
                item.Note = input.Note ?? "";

                if (SaveIntent == SaveIntentType.Insert)
                {
                    item.UserMainId = UserMainId;
                    item.Status = "1";
                    await _appService._userInfoRepository.InsertAsync(item);
                }

                var Data = ObjectMapper.Map<UserInfo, UserInfosDto>(item);

                //���o�һݭn���N�X���-���F�[�t
                var inputShareCodeGroup = new ShareCodeGroupInput();
                inputShareCodeGroup.ListGroupCode.Add("Sex");
                inputShareCodeGroup.ListGroupCode.Add("Blood");
                inputShareCodeGroup.ListGroupCode.Add("PlaceOfBirth");
                inputShareCodeGroup.ListGroupCode.Add("Nationality");
                var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);

                //���N�X���[�W�W��
                var inputSetShareCode = new SetShareCodeInput();
                inputSetShareCode.ListShareCode = itemsShareCode;
                inputSetShareCode.Data = new List<UserInfosDto>() { Data };
                var ListColumns = new List<NameCodeStandardDto>();
                ListColumns.Add(new NameCodeStandardDto { GroupCode = "Sex", Code = "SexCode", Name = "SexName" });
                ListColumns.Add(new NameCodeStandardDto { GroupCode = "Blood", Code = "BloodCode", Name = "BloodName" });
                ListColumns.Add(new NameCodeStandardDto { GroupCode = "PlaceOfBirth", Code = "PlaceOfBirthCode", Name = "PlaceOfBirthName" });
                ListColumns.Add(new NameCodeStandardDto { GroupCode = "Nationality", Code = "NationalityCode", Name = "NationalityName" });
                inputSetShareCode.ListColumns = ListColumns;
                _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<UserInfosDto>(inputSetShareCode);

                //���C�@���i���令�ۦP���� �C�@��
                //var itemsAllResumeMain = await _appService._resumeMainRepository.GetQueryableAsync();
                //var itemsResumeMain = itemsAllResumeMain.Where(p => p.UserMainId == UserMainId).ToList();
                //foreach (var itemResumeMain in itemsResumeMain)
                //{
                //    itemResumeMain.NameE = input.NameE ?? "";
                //    itemResumeMain.SexCode = input.SexCode ?? "";
                //    itemResumeMain.BloodCode = input.BloodCode ?? "";
                //    itemResumeMain.PlaceOfBirthCode = input.PlaceOfBirthCode ?? "";
                //    itemResumeMain.PassportNo = input.PassportNo ?? "";
                //    itemResumeMain.NationalityCode = input.NationalityCode ?? "";
                //    itemResumeMain.ResidenceNo = input.ResidenceNo ?? "";
                //}

                //await _appService._resumeMainRepository.UpdateManyAsync(itemsResumeMain);

                Result.Data = Data;
                Result.Save = true;
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<SaveUserMainSingleValueDto>> SaveUserMainPasswordResetAsync(SaveUserMainSingleValueInput input)
        {
            var Result = new ResultDto<SaveUserMainSingleValueDto>();
            Result.Data = new SaveUserMainSingleValueDto();
            Result.Version = "2023050901";

            var TenantId = Guid.Parse("d63dd51b-2e19-a965-ed20-3a09cda74359");
            var TenantName = input.TenantName.IsNullOrEmpty() ? "User" : input.TenantName;

            var UserId = input.UserId;
            var VerifyId = input.CheckUserVerify.VerifyId;
            var VerifyCode = input.CheckUserVerify.VerifyCode;
            var Value = input.Value;

            var inputCheckUserVerify = new CheckUserVerifyInput();
            inputCheckUserVerify.VerifyId = input.CheckUserVerify.VerifyId;
            inputCheckUserVerify.VerifyCode = input.CheckUserVerify.VerifyCode;
            var CheckUserVerify = await CheckUserVerifyAsync(inputCheckUserVerify);
            Result.Messages.AddRange(CheckUserVerify.Messages);

            try
            {
                var inputSendUserVerify = JsonSerializer.Deserialize<SendUserVerifyInput>(Security.Decrypt(VerifyId));

                var ToMail = inputSendUserVerify.ToMail;
                var ToGsm = inputSendUserVerify.ToGsm;
                if (ToMail != UserId && ToGsm != UserId)
                    Result.Messages.Add(new ResultMessageDto() { MessageCode = @"400", MessageContents = @"����X��T���~", Pass = false });
            }
            catch (Exception ex)
            {
                Result.Messages.Add(new ResultMessageDto() { MessageCode = @"400", MessageContents = @"����X�L�k���T�ഫ", Pass = false });
            }

            if (Result.Messages.Count == 0)
            {
                using (_appService._dataFilter.Disable<IMultiTenant>())
                {
                    var itemTenant = await _appService._tenantRepository.FindByNameAsync(TenantName);
                    if (itemTenant != null)
                        TenantId = itemTenant.Id;

                    //�ϥΪ̥D��
                    var itemsAllUserMain = await _appService._userMainRepository.GetQueryableAsync();
                    itemsAllUserMain = from c in itemsAllUserMain
                                       where c.TenantId == TenantId
                                       && (c.LoginEmail == UserId
                                       || c.LoginMobilePhone == UserId)
                                       select c;

                    var itemUserMain = await AsyncExecuter.FirstOrDefaultAsync(itemsAllUserMain);
                    if (itemUserMain == null)
                        Result.Messages.Add(new ResultMessageDto() { MessageCode = @"400", MessageContents = @"�ק�S�����\�A�]���䤣��ϥΪ̥D��" });
                    else
                    {
                        var Id = itemUserMain.UserId;
                        var itemUser = await _appService._identityUserManager.FindByIdAsync(Id.ToString());
                        if (itemUser == null)
                            Result.Messages.Add(new ResultMessageDto() { MessageCode = @"400", MessageContents = @"�ק�S�����\�A�]���䤣��ϥΪ̥D��(Apb)" });
                        else
                        {
                            var Token = await _appService._identityUserManager.GeneratePasswordResetTokenAsync(itemUser);
                            var uIdentityResult = await _appService._identityUserManager.ResetPasswordAsync(itemUser, Token, Value);
                            if (!uIdentityResult.Succeeded)
                                Result.Messages.Add(new ResultMessageDto() { MessageCode = @"400", MessageContents = @"�ק�S�����\" });

                            if (Result.Messages.Count == 0)
                            {
                                Value = Security.Encrypt(Value);
                                itemUserMain.Password = Value;
                                var uUserMain = await _appService._userMainRepository.UpdateAsync(itemUserMain);

                                Result.Data.Pass = true;
                                Result.Save = true;
                            }
                        }
                    }
                }
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<SaveUserMainSingleValueDto>> SaveUserMainColumnNameAsync(SaveUserMainColumnNameInput input)
        {
            var Result = new ResultDto<SaveUserMainSingleValueDto>();
            Result.Data = new SaveUserMainSingleValueDto();
            Result.Version = "2023041701";

            var CurrentTenantId = CurrentTenant.Id;
            var UserId = CurrentUser.Id;

            var dcAllowColumns = new Dictionary<string, List<string>>();
            dcAllowColumns.Add("Name", new List<string>() { "AppUserMains", "AbpUsers", "AppUserInfos", "AppResumeMains" });
            dcAllowColumns.Add("AnonymousName", new List<string>() { "AppUserMains" });
            dcAllowColumns.Add("LoginAccountCode", new List<string>() { "AppUserMains", "AbpUsers" });
            dcAllowColumns.Add("LoginMobilePhone", new List<string>() { "AppUserMains", "AbpUsers" });
            dcAllowColumns.Add("LoginEmail", new List<string>() { "AppUserMains", "AbpUsers" });
            dcAllowColumns.Add("LoginIdentityNo", new List<string>() { "AppUserMains", "AbpUsers", "AppUserInfos", "AppResumeMains" });
            dcAllowColumns.Add("Password", new List<string>() { "AppUserMains", "AbpUsers" });
            dcAllowColumns.Add("SystemUserRoleKeys", new List<string>() { "AppUserMains" });
            dcAllowColumns.Add("AllowSearch", new List<string>() { "AppUserMains" });
            dcAllowColumns.Add("BirthDate", new List<string>() { "AppUserInfos", "AppResumeMains" });

            var ColumnName = input.ColumnName ?? "";
            var Value = input.Value ?? "";
            if (ColumnName == "LoginIdentityNo")
                Value = Value.ToUpper();
            var CurrentPassword = input.CurrentPassword ?? "";
            if (ColumnName.Length == 0 || Value.Length == 0)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = @"400", MessageContents = @"�����\�ť�" });

            if (!dcAllowColumns.ContainsKey(ColumnName))
                Result.Messages.Add(new ResultMessageDto() { MessageCode = @"400", MessageContents = @"�����\�ק�" });

            //�ˬd�O�_�����g�L���
            if (ColumnName == "LoginMobilePhone" || ColumnName == "LoginEmail")
            {
                var VerifyId = input.CheckUserVerify.VerifyId;
                var VerifyCode = input.CheckUserVerify.VerifyCode;

                var inputCheckUserVerify = new CheckUserVerifyInput();
                inputCheckUserVerify.VerifyId = input.CheckUserVerify.VerifyId;
                inputCheckUserVerify.VerifyCode = input.CheckUserVerify.VerifyCode;
                var CheckUserVerify = await CheckUserVerifyAsync(inputCheckUserVerify);
                Result.Messages.AddRange(CheckUserVerify.Messages);
            }

            if (dcAllowColumns.ContainsKey(ColumnName))
            {
                //�ϥΪ̥D��
                var itemsAllUserMain = await _appService._userMainRepository.GetQueryableAsync();
                var itemsUserMain = itemsAllUserMain;

                //�P�_�O�_������
                if (ColumnName == "LoginAccountCode" || ColumnName == "LoginMobilePhone" || ColumnName == "LoginEmail" || ColumnName == "LoginIdentityNo")
                    using (_appService._dataFilter.Disable<IMultiTenant>())
                    {
                        itemsUserMain = from c in itemsAllUserMain
                                        where c.TenantId == CurrentTenantId
                                        && c.UserId != UserId
                                        && ((ColumnName == "LoginAccountCode" && c.LoginAccountCode.Length > 0 && c.LoginAccountCode.ToUpper() == Value.ToUpper())
                                        || (ColumnName == "LoginMobilePhone" && c.LoginMobilePhone.Length > 0 && c.LoginMobilePhone.ToUpper() == Value)
                                        || (ColumnName == "LoginEmail" && c.LoginEmail.Length > 0 && c.LoginEmail.ToUpper() == Value.ToUpper())
                                        || (ColumnName == "LoginIdentityNo" && c.LoginIdentityNo.Length > 0 && c.LoginIdentityNo.ToUpper() == Value.ToUpper()))
                                        select c;

                        if (itemsUserMain.Any())
                            Result.Messages.Add(new ResultMessageDto() { MessageCode = @"400", MessageContents = @"��ƭ���(�ϥΪ̥D��)" });

                        //�įण�n�A���ӦA�Q���ﵽ �i��ե� EfCoreIdentityUserRepository
                        var itemsUser = await _appService._identityUserRepository.GetListAsync();
                        var itemUser = from c in itemsUser
                                       where c.TenantId == CurrentTenantId
                                       && c.Id != UserId
                                       && ((ColumnName == "LoginAccountCode" && !c.NormalizedUserName.IsNullOrEmpty() && c.NormalizedUserName.ToUpper() == Value.ToUpper())  //�b���O�j�g
                                       || (ColumnName == "LoginMobilePhone" && !c.PhoneNumber.IsNullOrEmpty() && c.PhoneNumber.ToUpper() == Value.ToUpper())
                                       || (ColumnName == "LoginEmail" && !c.NormalizedEmail.IsNullOrEmpty() && c.NormalizedEmail.ToUpper() == Value.ToUpper())
                                       || (ColumnName == "LoginIdentityNo" && !c.Surname.IsNullOrEmpty() && c.Surname.ToUpper() == Value.ToUpper()))
                                       select c;

                        if (itemUser.Any())
                            Result.Messages.Add(new ResultMessageDto() { MessageCode = @"400", MessageContents = @"��ƭ���(Abp�ϥΪ̥D��)" });
                    }

                itemsUserMain = from c in itemsAllUserMain
                                where c.UserId == UserId
                                select c;

                var UserMainId = _appService._guidGenerator.Create();
                var itemUserMain = await AsyncExecuter.FirstOrDefaultAsync(itemsUserMain);
                if (itemUserMain != null)
                    UserMainId = itemUserMain.Id;

                //Abp�ϥΪ̥D��              
                if (dcAllowColumns.Any(p => p.Key == ColumnName && p.Value.Contains("AbpUsers")))
                {
                    var itemUser = await _appService._identityUserRepository.GetAsync(id: UserId.Value);
                    if (itemUser == null)
                        Result.Messages.Add(new ResultMessageDto() { MessageCode = @"400", MessageContents = @"�ק�S�����\�A�]���䤣����" });
                    else
                    {
                        if (Result.Messages.Count == 0)
                        {
                            IdentityResult uIdentityResult;
                            switch (ColumnName)
                            {
                                case "Name":
                                    itemUser.Name = Value;
                                    await _appService._identityUserRepository.UpdateAsync(itemUser);
                                    break;
                                case "LoginAccountCode":
                                    uIdentityResult = await _appService._identityUserManager.SetUserNameAsync(itemUser, Value);
                                    await _appService._identityUserManager.UpdateNormalizedUserNameAsync(itemUser);
                                    break;
                                case "LoginMobilePhone":
                                    uIdentityResult = await _appService._identityUserManager.SetPhoneNumberAsync(itemUser, Value);
                                    break;
                                case "LoginEmail":
                                    uIdentityResult = await _appService._identityUserManager.SetEmailAsync(itemUser, Value);
                                    await _appService._identityUserManager.UpdateNormalizedEmailAsync(itemUser);
                                    break;
                                case "LoginIdentityNo":
                                    itemUser.Surname = Value;
                                    await _appService._identityUserRepository.UpdateAsync(itemUser);
                                    break;
                                case "Password":
                                    uIdentityResult = await _appService._identityUserManager.ChangePasswordAsync(itemUser, CurrentPassword, Value);
                                    if (!uIdentityResult.Succeeded)
                                        Result.Messages.Add(new ResultMessageDto() { MessageCode = @"400", MessageContents = @"�ק�S�����\�A�]���K�X�P�e�����P" });
                                    break;
                            }
                        }
                    }
                }

                //�ϥΪ̥D��
                if (dcAllowColumns.Any(p => p.Key == ColumnName && p.Value.Contains("AppUserMains")))
                {
                    if (Result.Messages.Count == 0)
                    {
                        var ToMail = itemUserMain.LoginEmail;
                        var ToGsm = itemUserMain.LoginMobilePhone;
                        var inputSendShareSendQueue = new SendShareSendQueueInput();
                        inputSendShareSendQueue.InstantSend = true;
                        if (ToMail.Length > 0)
                            inputSendShareSendQueue.ListToMail.Add(ToMail);
                        if (ToGsm.Length > 0)
                            inputSendShareSendQueue.ListToGsm.Add(ToGsm);
                        inputSendShareSendQueue.SendTypeCode = SendType.Mail;
                        inputSendShareSendQueue.Where = true;
                        inputSendShareSendQueue.dcParameterSql.Add("Id", UserMainId);

                        //�S�O�B�zValue����
                        switch (ColumnName)
                        {
                            case "Password":    //�K�X�ݭn�[�K�A�s�J
                                Value = Security.Encrypt(Value);

                                inputSendShareSendQueue.Key3 = "04";    //�l��˪�           
                                await _appService._serviceProvider.GetService<SharesAppService>().SendShareSendQueueAsync(inputSendShareSendQueue);
                                break;
                            case "LoginEmail":
                                inputSendShareSendQueue.Key3 = "04";    //�l��˪�
                                inputSendShareSendQueue.ListToMail.Add(Value);
                                //await _appService._serviceProvider.GetService<SharesAppService>().SendShareSendQueueAsync(inputSendShareSendQueue);
                                break;
                            case "LoginIdentityNo":
                                inputSendShareSendQueue.Key3 = "04";    //�l��˪�           
                                //await _appService._serviceProvider.GetService<SharesAppService>().SendShareSendQueueAsync(inputSendShareSendQueue);
                                break;
                            case "LoginMobilePhone":
                                inputSendShareSendQueue.Key3 = "04";    //�l��˪�
                                inputSendShareSendQueue.ListToGsm.Add(Value);
                                break;
                        }

                        if (!DataAccess.SetProperty(itemUserMain, ColumnName, Value))
                            Result.Messages.Add(new ResultMessageDto() { MessageCode = @"400", MessageContents = @"�ק�S�����\�A�䤣��������" });
                        else
                            await _appService._userMainRepository.UpdateAsync(itemUserMain);
                    }
                }

                //�ϥΪ̥D�ɸ�T               
                if (dcAllowColumns.Any(p => p.Key == ColumnName && p.Value.Contains("AppUserInfos")))
                {
                    if (Result.Messages.Count == 0)
                    {
                        var itemsAll = await _appService._userInfoRepository.GetQueryableAsync();
                        var item = itemsAll.FirstOrDefault(p => p.UserMainId == UserMainId);
                        if (item != null)
                        {
                            switch (ColumnName)
                            {
                                case "Name":
                                    item.NameC = Value;
                                    break;
                                case "LoginIdentityNo":
                                    item.IdentityNo = Value.ToUpper();
                                    break;
                                case "BirthDate":
                                    item.BirthDate = Convert.ToDateTime(Value);
                                    break;
                            }

                            await _appService._userInfoRepository.UpdateAsync(item);
                        }
                    }
                }

                //�i���D��               
                //if (dcAllowColumns.Any(p => p.Key == ColumnName && p.Value.Contains("AppResumeMains")))
                //{
                //    var itemsAllResumeMain = await _appService._resumeMainRepository.GetQueryableAsync();
                //    var itemsResumeMain = itemsAllResumeMain.Where(p => p.UserMainId == UserMainId).ToList();

                //    if (Result.Messages.Count == 0)
                //    {
                //        foreach (var itemResumeMain in itemsResumeMain)
                //            switch (ColumnName)
                //            {
                //                case "Name":
                //                    itemResumeMain.NameC = Value;
                //                    break;
                //                case "LoginIdentityNo":
                //                    itemResumeMain.IdentityNo = Value.ToUpper();
                //                    break;
                //                case "BirthDate":
                //                    itemResumeMain.BirthDate = Convert.ToDateTime(Value);
                //                    break;
                //            }

                //        await _appService._resumeMainRepository.UpdateManyAsync(itemsResumeMain);
                //    }
                //}
            }

            if (Result.Messages.Count == 0)
            {
                Result.Data.Pass = true;
                Result.Save = true;
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<SaveUserMainSingleValueDto>> SaveUserMainNameAsync(SaveUserMainSingleValueInput input)
        {
            var Result = new ResultDto<SaveUserMainSingleValueDto>();
            Result.Data = new SaveUserMainSingleValueDto();
            Result.Version = "2023032401";

            var inputSaveUserMainColumnName = new SaveUserMainColumnNameInput();
            inputSaveUserMainColumnName.UserId = input.UserId;
            inputSaveUserMainColumnName.ColumnName = "Name";
            inputSaveUserMainColumnName.Value = input.Value;
            inputSaveUserMainColumnName.CurrentPassword = "";
            inputSaveUserMainColumnName.CheckUserVerify = input.CheckUserVerify;
            Result = await SaveUserMainColumnNameAsync(inputSaveUserMainColumnName);

            return Result;
        }

        public virtual async Task<ResultDto<SaveUserMainSingleValueDto>> SaveUserMainAnonymousNameAsync(SaveUserMainSingleValueInput input)
        {
            var Result = new ResultDto<SaveUserMainSingleValueDto>();
            Result.Data = new SaveUserMainSingleValueDto();
            Result.Version = "2023032401";

            var inputSaveUserMainColumnName = new SaveUserMainColumnNameInput();
            inputSaveUserMainColumnName.UserId = input.UserId;
            inputSaveUserMainColumnName.ColumnName = "AnonymousName";
            inputSaveUserMainColumnName.Value = input.Value;
            inputSaveUserMainColumnName.CurrentPassword = "";
            inputSaveUserMainColumnName.CheckUserVerify = input.CheckUserVerify;
            Result = await SaveUserMainColumnNameAsync(inputSaveUserMainColumnName);

            return Result;
        }

        public virtual async Task<ResultDto<SaveUserMainSingleValueDto>> SaveUserMainLoginAccountCodeAsync(SaveUserMainSingleValueInput input)
        {
            var Result = new ResultDto<SaveUserMainSingleValueDto>();
            Result.Data = new SaveUserMainSingleValueDto();
            Result.Version = "2023032401";

            var inputSaveUserMainColumnName = new SaveUserMainColumnNameInput();
            inputSaveUserMainColumnName.UserId = input.UserId;
            inputSaveUserMainColumnName.ColumnName = "LoginAccountCode";
            inputSaveUserMainColumnName.Value = input.Value;
            inputSaveUserMainColumnName.CurrentPassword = "";
            inputSaveUserMainColumnName.CheckUserVerify = input.CheckUserVerify;
            Result = await SaveUserMainColumnNameAsync(inputSaveUserMainColumnName);

            return Result;
        }

        public virtual async Task<ResultDto<SaveUserMainSingleValueDto>> SaveUserMainLoginMobilePhoneAsync(SaveUserMainSingleValueInput input)
        {
            var Result = new ResultDto<SaveUserMainSingleValueDto>();
            Result.Data = new SaveUserMainSingleValueDto();
            Result.Version = "2023032401";

            var inputSaveUserMainColumnName = new SaveUserMainColumnNameInput();
            inputSaveUserMainColumnName.UserId = input.UserId;
            inputSaveUserMainColumnName.ColumnName = "LoginMobilePhone";
            inputSaveUserMainColumnName.Value = input.Value;
            inputSaveUserMainColumnName.CurrentPassword = "";
            inputSaveUserMainColumnName.CheckUserVerify = input.CheckUserVerify;
            Result = await SaveUserMainColumnNameAsync(inputSaveUserMainColumnName);

            return Result;
        }

        public virtual async Task<ResultDto<SaveUserMainSingleValueDto>> SaveUserMainLoginEmailAsync(SaveUserMainSingleValueInput input)
        {
            var Result = new ResultDto<SaveUserMainSingleValueDto>();
            Result.Data = new SaveUserMainSingleValueDto();
            Result.Version = "2023032401";

            var inputSaveUserMainColumnName = new SaveUserMainColumnNameInput();
            inputSaveUserMainColumnName.UserId = input.UserId;
            inputSaveUserMainColumnName.ColumnName = "LoginEmail";
            inputSaveUserMainColumnName.Value = input.Value;
            inputSaveUserMainColumnName.CurrentPassword = "";
            inputSaveUserMainColumnName.CheckUserVerify = input.CheckUserVerify;
            Result = await SaveUserMainColumnNameAsync(inputSaveUserMainColumnName);

            return Result;
        }

        public virtual async Task<ResultDto<SaveUserMainSingleValueDto>> SaveUserMainLoginIdentityNoAsync(SaveUserMainSingleValueInput input)
        {
            var Result = new ResultDto<SaveUserMainSingleValueDto>();
            Result.Data = new SaveUserMainSingleValueDto();
            Result.Version = "2023032401";

            var inputSaveUserMainColumnName = new SaveUserMainColumnNameInput();
            inputSaveUserMainColumnName.UserId = input.UserId;
            inputSaveUserMainColumnName.ColumnName = "LoginIdentityNo";
            inputSaveUserMainColumnName.Value = input.Value;
            inputSaveUserMainColumnName.CurrentPassword = "";
            inputSaveUserMainColumnName.CheckUserVerify = input.CheckUserVerify;
            Result = await SaveUserMainColumnNameAsync(inputSaveUserMainColumnName);

            return Result;
        }

        public virtual async Task<ResultDto<SaveUserMainSingleValueDto>> SaveUserMainPasswordAsync(SaveUserMainPasswordInput input)
        {
            var Result = new ResultDto<SaveUserMainSingleValueDto>();
            Result.Data = new SaveUserMainSingleValueDto();
            Result.Version = "2023032401";

            var inputSaveUserMainColumnName = new SaveUserMainColumnNameInput();
            inputSaveUserMainColumnName.UserId = input.UserId;
            inputSaveUserMainColumnName.ColumnName = "Password";
            inputSaveUserMainColumnName.Value = input.Value;
            inputSaveUserMainColumnName.CurrentPassword = input.CurrentPassword;
            inputSaveUserMainColumnName.CheckUserVerify = input.CheckUserVerify;
            Result = await SaveUserMainColumnNameAsync(inputSaveUserMainColumnName);

            return Result;
        }

        public virtual async Task<ResultDto<SaveUserMainSingleValueDto>> SaveUserMainSystemUserRoleKeysAsync(SaveUserMainSingleValueInput input)
        {
            var Result = new ResultDto<SaveUserMainSingleValueDto>();
            Result.Data = new SaveUserMainSingleValueDto();
            Result.Version = "2023032401";

            var inputSaveUserMainColumnName = new SaveUserMainColumnNameInput();
            inputSaveUserMainColumnName.UserId = input.UserId;
            inputSaveUserMainColumnName.ColumnName = "SystemUserRoleKeys";
            inputSaveUserMainColumnName.Value = input.Value;
            inputSaveUserMainColumnName.CurrentPassword = "";
            inputSaveUserMainColumnName.CheckUserVerify = input.CheckUserVerify;
            Result = await SaveUserMainColumnNameAsync(inputSaveUserMainColumnName);

            return Result;
        }

        public virtual async Task<ResultDto<SaveUserMainSingleValueDto>> SaveUserMainAllowSearchAsync(SaveUserMainSingleValueInput input)
        {
            var Result = new ResultDto<SaveUserMainSingleValueDto>();
            Result.Data = new SaveUserMainSingleValueDto();
            Result.Version = "2023032401";

            var inputSaveUserMainColumnName = new SaveUserMainColumnNameInput();
            inputSaveUserMainColumnName.UserId = input.UserId;
            inputSaveUserMainColumnName.ColumnName = "AllowSearch";
            inputSaveUserMainColumnName.Value = input.Value;
            inputSaveUserMainColumnName.CurrentPassword = "";
            inputSaveUserMainColumnName.CheckUserVerify = input.CheckUserVerify;
            Result = await SaveUserMainColumnNameAsync(inputSaveUserMainColumnName);

            return Result;
        }

        public virtual async Task<ResultDto<SaveUserMainSingleValueDto>> SaveUserMainBirthDateAsync(SaveUserMainSingleValueInput input)
        {
            var Result = new ResultDto<SaveUserMainSingleValueDto>();
            Result.Data = new SaveUserMainSingleValueDto();
            Result.Version = "2023032401";

            var inputSaveUserMainColumnName = new SaveUserMainColumnNameInput();
            inputSaveUserMainColumnName.UserId = input.UserId;
            inputSaveUserMainColumnName.ColumnName = "BirthDate";
            inputSaveUserMainColumnName.Value = input.Value;
            inputSaveUserMainColumnName.CurrentPassword = "";
            inputSaveUserMainColumnName.CheckUserVerify = input.CheckUserVerify;
            Result = await SaveUserMainColumnNameAsync(inputSaveUserMainColumnName);

            return Result;
        }

        public virtual async Task<ResultDto<SaveUserCompanyBindDto>> SaveUserCompanyBindAsync(SaveUserCompanyBindInput input)
        {
            var Result = new ResultDto<SaveUserCompanyBindDto>();
            Result.Data = new SaveUserCompanyBindDto();
            Result.Version = "2023042001";

            var DateNow = DateTime.Now;

            var UserId = CurrentUser.Id.ToString();

            var CompanyInvitationsId = input.Id;

            //���o���q�ܽв[�N�X CompanyInvitationsId
            //����������T
            //�g�^UserCompanyBind
            var itemsCompanyInvitations = await _appService._companyInvitationsRepository.GetQueryableAsync();
            var itemCompanyInvitations = new CompanyInvitations();
            using (_appService._dataFilter.Disable<IMultiTenant>())
                itemCompanyInvitations = itemsCompanyInvitations.FirstOrDefault(p => p.Id == CompanyInvitationsId && p.Status == "1");  //����Ȥ��d

            if (itemCompanyInvitations == null)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = @"400", MessageContents = @"�䤣�������T" });
            else
            {
                var CompanyMainId = itemCompanyInvitations.CompanyMainId;
                var CompanyJobId = itemCompanyInvitations.CompanyJobId;
                var UserMainId = itemCompanyInvitations.UserMainId;

                //if (CompanyMainId.IsNullOrEmpty())
                //    Result.Messages.Add(new ResultMessageDto() { MessageCode = @"400", MessageContents = @"�䤣�������T" });

                if (UserMainId != null)
                    Result.Messages.Add(new ResultMessageDto() { MessageCode = @"400", MessageContents = @"�w�g�Q�j�w�L" });

                if (Result.Messages.Count == 0)
                {
                    //���s���o�u����UserMainId�]�\���e���Q�O�H�j�w�F
                    UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;

                    //�z�פW�A���i�঳���ơA�]���Ѱ��j�w�A�O�����R����ơA�����קK���Ʀs�J�A�]���A�@���M��O�_���ۦP�����q¾�ʸ��
                    //�A�W�[�j�w���ܽв[�N�X�ӧP�_
                    var items = await _appService._userCompanyBindRepository.GetQueryableAsync();
                    var item = items.FirstOrDefault(p => p.UserMainId == UserMainId && ((p.CompanyMainId == CompanyMainId && p.CompanyJobId == CompanyJobId) || (p.CompanyInvitationsId == CompanyInvitationsId)));
                    if (item == null)
                    {
                        item = new UserCompanyBind();
                        await _appService._userCompanyBindRepository.InsertAsync(item);
                        item.Status = "1";
                    }
                    else
                        await _appService._userCompanyBindRepository.UpdateAsync(item);

                    item.UserMainId = UserMainId.Value;
                    item.CompanyMainId = CompanyMainId;
                    item.CompanyJobId = CompanyJobId;
                    item.CompanyInvitationsId = CompanyInvitationsId;
                    item.ExtendedInformation = input.ExtendedInformation;
                    item.DateA = input.DateA;
                    item.DateD = input.DateD;
                    item.Sort = input.Sort;
                    item.Note = input.Note;

                    //�NUserMainId�g�^�ܽв[��-�����ܽв[�L�k�A���ϥ�
                    itemCompanyInvitations.UserMainId = UserMainId;
                    itemCompanyInvitations.UserCompanyBindId = item.Id;
                    await _appService._companyInvitationsRepository.UpdateAsync(itemCompanyInvitations);

                    Result.Data.UserMainId = UserMainId.Value;
                    Result.Data.UserCompanyBindId = item.Id;   //���F�e�ݸj�w�Ϯץ��`

                    Result.Data.Pass = true;
                    Result.Save = true;
                }
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<UserCompanyBindListDto>> GetUserCompanyBindListAsync(UserCompanyBindListInput input)
        {
            var Result = new ResultDto<UserCompanyBindListDto>();
            Result.Data = new UserCompanyBindListDto();
            Result.Version = "2023050401";

            var DateNow = DateTime.Now;

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var UserId = CurrentUser.Id.ToString();

            var itemsAll = await _appService._userCompanyBindRepository.GetQueryableAsync();
            var items = itemsAll.Where(p => p.UserMainId == UserMainId).ToList();
            var ListCompanyBindId = items.Select(p => p.Id).ToList();

            //���o����W��
            var ListCompanyMainId = items.Select(p => p.CompanyMainId).ToList();
            var itemsAllCompanyMain = await _appService._companyMainRepository.GetQueryableAsync();
            var itemsAllCompanyJob = await _appService._companyJobRepository.GetQueryableAsync();

            //���o�ܽв[�N�X �p�G�ܽв[�N�X�A�w�g���s�b�A�N���n��ܥX�ӸӤ��q��¾��
            var itemsAllCompanyInvitations = await _appService._companyInvitationsRepository.GetQueryableAsync();

            var itemsCompanyMain = new List<CompanyMain>();
            var itemsCompanyJob = new List<CompanyJob>();
            var itemsCompanyInvitations = new List<CompanyInvitations>();
            using (_appService._dataFilter.Disable<IMultiTenant>())
            {
                itemsCompanyMain = itemsAllCompanyMain.Where(p => ListCompanyMainId.Contains(p.Id)).ToList();
                itemsCompanyJob = itemsAllCompanyJob.Where(p => ListCompanyMainId.Contains(p.CompanyMainId)).ToList();
                itemsCompanyInvitations = itemsAllCompanyInvitations.Where(p => ListCompanyBindId.Contains(p.UserCompanyBindId.Value)).ToList();
            }

            //�N�j�w����ơA�ഫ�����}�C��� ���ѵ��U�Կ��
            var ListCompanyMain = new List<NameIdStandardDto>();
            var ListCompanyJob = new List<NameIdStandardDto>();
            foreach (var item in items)
            {
                var CompanyInvitationsId = item.CompanyInvitationsId;
                if (itemsCompanyInvitations.Any(p => p.Id == CompanyInvitationsId))
                {
                    var CompanyMainId = item.CompanyMainId;
                    var CompanyJobId = item.CompanyJobId;

                    var anyCompanyMain = ListCompanyMain.Any(p => p.Id == CompanyMainId);
                    if (!anyCompanyMain)
                    {
                        var itemCompanyMain = itemsCompanyMain.FirstOrDefault(p => p.Id == CompanyMainId);
                        if (itemCompanyMain != null)
                        {
                            var itemNameId = new NameIdStandardDto();
                            itemNameId.Id = CompanyMainId;
                            itemNameId.Name = itemCompanyMain.Name;
                            ListCompanyMain.Add(itemNameId);
                        }
                    }

                    var anyCompanyJob = ListCompanyJob.Any(p => p.GroupId == CompanyMainId && p.Id == CompanyJobId);
                    if (!anyCompanyJob)
                    {
                        var itemCompanyJob = itemsCompanyJob.FirstOrDefault(p => p.CompanyMainId == CompanyMainId && p.Id == CompanyJobId);
                        if (itemCompanyJob != null)
                        {
                            var itemNameId = new NameIdStandardDto();
                            itemNameId.Id = CompanyJobId.Value;
                            itemNameId.Name = itemCompanyJob.Name;
                            itemNameId.GroupId = CompanyMainId;
                            ListCompanyJob.Add(itemNameId);
                        }
                    }
                }
            }

            ListCompanyMain = ListCompanyMain.OrderBy(p => p.Id).ToList();
            ListCompanyJob = ListCompanyJob.OrderBy(p => p.GroupId).ThenBy(p => p.Id).ToList();

            Result.Data.ListCompanyMain = ListCompanyMain;
            Result.Data.ListCompanyJob = ListCompanyJob;

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<DeleteUserCompanyBindDto>> DeleteUserCompanyBindAsync(DeleteUserCompanyBindInput input)
        {
            var Result = new ResultDto<DeleteUserCompanyBindDto>();
            Result.Data = new DeleteUserCompanyBindDto();
            Result.Version = "2023042001";

            var DateNow = DateTime.Now;

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var UserId = CurrentUser.Id.ToString();
            var Id = input.Id;

            var itemsAll = await _appService._userCompanyBindRepository.GetQueryableAsync();
            var item = itemsAll.FirstOrDefault(p => p.UserMainId == UserMainId && p.Id == Id);
            if (item != null)
            {
                //�M���ܽв[��T(�p�G���ӴN���s�b �h�N���βM�ŤF�A���p�G�Q�O�H�j�w�F �]�� �h����M��)
                var CompanyInvitationsId = item.CompanyInvitationsId;
                var itemsAllCompanyInvitations = await _appService._companyInvitationsRepository.GetQueryableAsync();
                var itemCompanyInvitations = new CompanyInvitations();
                using (_appService._dataFilter.Disable<IMultiTenant>())
                    itemCompanyInvitations = itemsAllCompanyInvitations.FirstOrDefault(p => p.Id == CompanyInvitationsId && (p.UserMainId == null || p.UserMainId == UserMainId));
                if (itemCompanyInvitations != null)
                {
                    itemCompanyInvitations.UserMainId = null;
                    itemCompanyInvitations.UserCompanyBindId = null;
                    itemCompanyInvitations.ResumeSnapshotId = null;

                    await _appService._companyInvitationsRepository.UpdateAsync(itemCompanyInvitations);
                }

                //�R���ַӸ��
                var itemsResumeSnapshot = await _appService._resumeSnapshotRepository.GetQueryableAsync();
                var itemResumeSnapshot = itemsResumeSnapshot.FirstOrDefault(p => p.UserCompanyBindId == Id);
                if (itemResumeSnapshot != null)
                {
                    itemResumeSnapshot.Status = "2";
                    await _appService._resumeSnapshotRepository.DeleteAsync(itemResumeSnapshot);
                }

                item.Status = "2";
                await _appService._userCompanyBindRepository.DeleteAsync(item);
                Result.Data.Pass = true;
                Result.Save = true;
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<List<CompanyInvitationssDto>>> GetUserCompanyInvitationsListAsync(CompanyInvitationsListInput input)
        {
            var Result = new ResultDto<List<CompanyInvitationssDto>>();
            Result.Data = new List<CompanyInvitationssDto>();
            Result.Version = "2023042001";

            var DateNow = DateTime.Now;

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;

            var itemsUserMain = await _appService._userMainRepository.GetQueryableAsync();
            var itemUserMain = itemsUserMain.FirstOrDefault(p => p.Id == UserMainId);
            if (itemUserMain != null)
            {
                var LoginAccountCode = itemUserMain.LoginAccountCode;
                var LoginEmail = itemUserMain.LoginEmail;
                var LoginIdentityNo = itemUserMain.LoginIdentityNo;
                var LoginMobilePhone = itemUserMain.LoginMobilePhone;

                var itemsAllUserCompany = await _appService._userCompanyBindRepository.GetQueryableAsync();
                var ListCompanyInvitationsId = itemsAllUserCompany.Where(p => p.UserMainId == UserMainId && p.CompanyInvitationsId != null).Select(p => p.CompanyInvitationsId).ToList();

                using (_appService._dataFilter.Disable<IMultiTenant>())
                {
                    //�ϥΫH�c�ιq�ܼҽk�j�M
                    var itemsAll = await _appService._companyInvitationsRepository.GetQueryableAsync();
                    var items = (from c in itemsAll
                                 where (c.UserMainId != null && c.UserMainId == UserMainId)    //�p�G�Ѱ��j�w�A�̵M�i�H�o�촿�g�j�w�����
                                 || (ListCompanyInvitationsId.Contains(c.Id))   //�p�G���g�j�w�L�A�̵M�i�H���o�A���o�ӸѸj�A�i��|�Ѩ�O�H��
                                 || (c.UserMainLoginEmail.Length > 0 && c.UserMainLoginEmail == LoginEmail)
                                 //|| (c.UserMainLoginIdentityNo.Length > 0 &&  c.UserMainLoginIdentityNo == LoginIdentityNo) //����w���D ���D�����ҥѤH�u�P�w
                                 || (c.UserMainLoginMobilePhone.Length > 0 && c.UserMainLoginMobilePhone == LoginMobilePhone)
                                 select c).ToList();

                    var ListCompanyMainId = items.Select(p => p.CompanyMainId).ToList();
                    var ListCompanyJobId = items.Select(p => p.CompanyJobId).ToList();

                    var itemsAllCompanyMain = await _appService._companyMainRepository.GetQueryableAsync();
                    var itemsAllCompanyJob = await _appService._companyJobRepository.GetQueryableAsync();

                    var itemsCompanyMain = itemsAllCompanyMain.Where(p => ListCompanyMainId.Contains(p.Id)).ToList();
                    var itemsCompanyJob = itemsAllCompanyJob.Where(p => ListCompanyMainId.Contains(p.CompanyMainId) && ListCompanyJobId.Contains(p.Id)).ToList();

                    var Data = ObjectMapper.Map<List<CompanyInvitations>, List<CompanyInvitationssDto>>(items);
                    Data = (from c in Data
                            where c.Status == "1"
                            orderby c.Sort
                            select c).ToList();

                    foreach (var item in Data)
                    {
                        var CompanyMainId = item.CompanyMainId;
                        var CompanyJobId = item.CompanyJobId;

                        var itemCompanyMain = itemsCompanyMain.FirstOrDefault(p => p.Id == CompanyMainId);
                        if (itemCompanyMain != null)
                            item.CompanyMainName = itemCompanyMain.Name;

                        var itemCompanyJob = itemsCompanyJob.FirstOrDefault(p => p.Id == CompanyJobId);
                        if (itemCompanyJob != null)
                            item.CompanyJobName = itemCompanyJob.Name;
                    }

                    Result.Data = Data;
                    Result.Save = true;
                }
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public Guid UserMainId
        {
            get
            {
                var AbpUserId = CurrentUser.Id;

                {
                    using (_appService._dataFilter.Disable<IMultiTenant>())
                    {
                        var itemUserMain = _appService._userMainRepository.FirstOrDefaultAsync(p => p.UserId == AbpUserId);
                        if (itemUserMain != null && itemUserMain.Result != null)
                            return itemUserMain.Result.Id;
                    }
                }

                return _appService._guidGenerator.Create();
            }
        }

        public string UserRoleId
        {
            get
            {
                var Code = "";

                var Id = CurrentUser.Roles.LastOrDefault();

                if (Id.Length > 0)
                {
                    Code = Id;
                }

                return Code;
            }
        }

        public int SystemUserRoleKeys
        {
            get
            {
                var Key = 0;

                var CurrentTenantId = CurrentTenant.Id;
                var CurrentUserRoles = CurrentUser.Roles;

                if (CurrentTenantId == null && CurrentUserRoles.Contains("admin"))
                    Key = 1;    //�t�μt�ӳ̰��޲z��
                else if (CurrentTenantId == null && CurrentUserRoles.Contains("Manage"))
                    Key = 2;    //�t�μt�Ӻ޲z��
                else if (CurrentTenantId != null && CurrentUserRoles.Contains("admin"))
                    Key = 4;    //�Ȥ�޲z��
                else if (CurrentTenantId != null && CurrentUserRoles.Contains("Manage"))
                    Key = 8;    //�Ȥ�޲z�H��
                else if (CurrentTenantId != null && CurrentUserRoles.Contains("User"))
                    Key = 16;   //�@��ϥΪ�

                return Key;
            }
        }
    }
}