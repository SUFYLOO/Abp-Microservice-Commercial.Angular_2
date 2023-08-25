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
using Resume.UserCompanyJobFavs;
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
using Resume.CompanyJobContents;
using Resume.CompanyJobConditions;

namespace Resume.App.Users
{
    public partial class UsersAppService : ApplicationService, IUsersAppService
    {
        public virtual async Task<List<UserCompanyJobFavsDto>> GetUserCompanyJobFavsListAsync(UserCompanyJobFavsInput input)
        {
            //���G
            var Result = new List<UserCompanyJobFavsDto>();
            var ex = new UserFriendlyException("���~�T��");

            //�`��

            //�t�μh��
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //�D����
            if (ex.Data.Count == 0)
            {
                var qrbUserCompanyJobFavs = await _appService._userCompanyJobFavRepository.GetQueryableAsync();
                qrbUserCompanyJobFavs = from c in qrbUserCompanyJobFavs
                                        where c.UserMainId == UserMainId
                                        //  orderby c.Main descending, c.Sort
                                        select c;
                var itemsUserCompanyJobFavs = qrbUserCompanyJobFavs.ToList();
                // var itemsResumMain = await AsyncExecuter.ToListAsync(qrbsUserCompanyJobFavs);
                ObjectMapper.Map<List<UserCompanyJobFav>, List<UserCompanyJobFavsDto>>(itemsUserCompanyJobFavs, Result);
            }
            if (ex.Data.Count > 0)
                throw ex;
            return Result;
        }

        public async Task<UserCompanyJobFavsDto> GetUserCompanyJobFavsAsync(UserCompanyJobFavsInput input)
        {
            //���G
            var Result = new UserCompanyJobFavsDto();
            var ex = new UserFriendlyException("���~�T��");

            //�t�μh��

            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //�~���ǤJ
            var UserCompanyJobFavsId = input.Id;

            //�w�]��

            //�ˬd
            if (UserCompanyJobFavsId.ToString() == " ")
            {
                ex.Data.Add(GuidGenerator.Create().ToString(), "ID���ର�ť�");
                throw ex;
            }

            //�D������
            if (ex.Data.Count == 0)
            {
                //�p�G�O�@�뤽�q
                var qrbUserCompanyJobFav = await _appService._userCompanyJobFavRepository.GetQueryableAsync();
                var itemUserCompanyJobFav = qrbUserCompanyJobFav.FirstOrDefault(p => p.Id == UserCompanyJobFavsId);

                if (itemUserCompanyJobFav == null)
                    ex.Data.Add(GuidGenerator.Create().ToString(), "�S���o�����");

                ObjectMapper.Map(itemUserCompanyJobFav, Result);
            }
            if (ex.Data.Count > 0)
                throw ex;

            return Result;
        }

     

        public async Task<UserCompanyJobFavsDto> SaveUserCompanyJobFavsAsync(SaveUserCompanyJobFavsInput input)
        {
            var Result = new UserCompanyJobFavsDto();

            //�t�μh��
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //�j��a�JId
            input.UserMainId = UserMainId;

            //�~���ǤJ
            var RefreshItem = input.RefreshItem;
            var UserCompanyJobFavsId = input.Id;

            //���n�ܧ󪺭�
            input.Sort = input.Sort != null ? input.Sort : ShareDefine.Sort;
            input.DateA = input.DateA != null ? input.DateA : ShareDefine.DateA;
            input.DateD = input.DateD != null ? input.DateD : ShareDefine.DateD;
            input.Status = input.Status.IsNullOrEmpty() ? "1" : input.Status;
            input.ExtendedInformation = input.ExtendedInformation.IsNullOrEmpty() ? "" : input.ExtendedInformation;

            //�ˬd
            await SaveUserCompanyJobFavsCheckAsync(input);

            //�D����
            var qrbUserCompanyJobFavs = await _appService._userCompanyJobFavRepository.GetQueryableAsync();
            var itemqrbUserCompanyJobFavs = qrbUserCompanyJobFavs.FirstOrDefault(p => p.Id == UserCompanyJobFavsId);

            //�p�GCompanyJobApplicationMethodsRepository�S���o��Id�N�s�W��ơA�w�s�b�Nupdate
            if (itemqrbUserCompanyJobFavs == null)
            {
                itemqrbUserCompanyJobFavs = ObjectMapper.Map<SaveUserCompanyJobFavsInput, UserCompanyJobFav>(input);
                itemqrbUserCompanyJobFavs = await _appService._userCompanyJobFavRepository.InsertAsync(itemqrbUserCompanyJobFavs);
            }
            else
            {
                //���n�ܧ󪺭�
                input.Sort = itemqrbUserCompanyJobFavs.Sort;
                input.DateA = itemqrbUserCompanyJobFavs.DateA;
                input.DateD = itemqrbUserCompanyJobFavs.DateD;

                ObjectMapper.Map(input, itemqrbUserCompanyJobFavs);
                await _appService._userCompanyJobFavRepository.UpdateAsync(itemqrbUserCompanyJobFavs);
            }
            if (RefreshItem)
                await _appService._unitOfWorkManager.Current.SaveChangesAsync();

            ObjectMapper.Map(itemqrbUserCompanyJobFavs, Result);

            return Result;
        }

        public virtual async Task<ResultDto> SaveUserCompanyJobFavsCheckAsync(SaveUserCompanyJobFavsInput input)
        {
            //���G
            var Result = new ResultDto();
            var ex = new UserFriendlyException("���~�T��");

            //�`��

            //�t�μh��
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>()?.CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>()?.UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>()?.SystemUserRoleKeys;

            //�~���ǤJ

            var CompanyJobId = input.CompanyJobId;


            //���n�N�X�ˮ�


            var qrbCompanyJob = await _appService._companyJobRepository.GetQueryableAsync();
            var itemCompanyJob = qrbCompanyJob.FirstOrDefault(p => p.Id == CompanyJobId);

            if (itemCompanyJob == null)
                ex.Data.Add(GuidGenerator.Create().ToString(), "�S���o�����");

            foreach (var msg in Result.Messages)
                ex.Data.Add(GuidGenerator.Create().ToString(), msg.MessageContents);

            if (ex.Data.Count > 0)
                throw ex;

            return Result;
        }

        public virtual async Task<UserCompanyJobFavsDto> DeleteUserCompanyJobFavsAsync(UserCompanyJobFavsInput input)
        {
            var Result = new UserCompanyJobFavsDto();
            var ex = new UserFriendlyException("���~�T��");

            //�`��

            //�t�μh��

            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //�j���input�a�J�t�έ�

            //�~���ǤJ
            var Id = input.Id;

            //�w�]��

            //�ˬd


            //�D����
            var qrbUserCompanyJobFavs = await _appService._userCompanyJobFavRepository.GetQueryableAsync();
            var itemUserCompanyJobFavs = qrbUserCompanyJobFavs.FirstOrDefault(p => p.Id == Id);
            if (ex.Data.Count == 0)
            {
                if (itemUserCompanyJobFavs == null)
                    ex.Data.Add(GuidGenerator.Create().ToString(), "�S���������");
                else
                {
                    await _appService._userCompanyJobFavRepository.DeleteAsync(itemUserCompanyJobFavs);
                    ObjectMapper.Map(itemUserCompanyJobFavs, Result);
                }
            }

            if (ex.Data.Count > 0)
                throw ex;

            return Result;
        }
    }
}