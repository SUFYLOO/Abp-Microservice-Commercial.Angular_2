using Resume.App.Companys;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Resume.UserCompanyJobApplies;
using PayPalCheckoutSdk.Orders;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Resume.App.Users
{
    public partial class UsersAppService : ApplicationService, IUsersAppService
    {
        public async Task<int> CountUserMainIdAsync()
        {
            var qrbUserCompanyJobApply = await _appService._userCompanyJobApplyRepository.GetQueryableAsync();
 
            var UserMainIds = qrbUserCompanyJobApply.Select(p => p.UserMainId).Distinct().Count();

            return UserMainIds;
        }

        public virtual async Task<List<UserCompanyJobApplysDto>> GetUserCompanyJobApplyListAsync(UserCompanyJobApplyInput input)
        {
            //���G
            var Result = new List<UserCompanyJobApplysDto>();
            var ex = new UserFriendlyException("���~�T��");

            //�`��

            //�t�μh��
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //�D����
            if (ex.Data.Count == 0)
            {
                var qrbUserCompanyJobApply = await _appService._userCompanyJobApplyRepository.GetQueryableAsync();
                qrbUserCompanyJobApply = from c in qrbUserCompanyJobApply
                                        where c.UserMainId == UserMainId
                                        //  orderby c.Main descending, c.Sort
                                        select c;       
                var itemsUserCompanyJobApply = qrbUserCompanyJobApply.ToList();
                // var itemsResumMain = await AsyncExecuter.ToListAsync(qrbsUserCompanyJobApply);
                ObjectMapper.Map<List<UserCompanyJobApply>, List<UserCompanyJobApplysDto>>(itemsUserCompanyJobApply, Result);
            }
            if (ex.Data.Count > 0)
                throw ex;
            return Result;
        }

        public async Task<UserCompanyJobApplysDto> GetUserCompanyJobApplyAsync(UserCompanyJobApplyInput input)
        {
            //���G
            var Result = new UserCompanyJobApplysDto();
            var ex = new UserFriendlyException("���~�T��");

            //�t�μh��

            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //�~���ǤJ
            var UserCompanyJobApplyId = input.Id;

            //�w�]��

            //�ˬd
            if (UserCompanyJobApplyId.ToString() == " ")
            {
                ex.Data.Add(GuidGenerator.Create().ToString(), "ID���ର�ť�");
                throw ex;
            }

            //�D������
            if (ex.Data.Count == 0)
            {

                //�p�G�O�@�뤽�q
                var qrbUserCompanyJobApply = await _appService._userCompanyJobApplyRepository.GetQueryableAsync();
                var itemUserCompanyJobApply = qrbUserCompanyJobApply.FirstOrDefault(p => p.Id == UserCompanyJobApplyId);

                if (itemUserCompanyJobApply == null)
                    ex.Data.Add(GuidGenerator.Create().ToString(), "�S���o�����");

                ObjectMapper.Map(itemUserCompanyJobApply, Result);
            }
            if (ex.Data.Count > 0)
                throw ex;

            return Result;
        }

     

        public async Task<UserCompanyJobApplysDto> SaveUserCompanyJobApplyAsync(SaveUserCompanyJobApplyInput input)
        {
            var Result = new UserCompanyJobApplysDto();

            //�t�μh��
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //�j��a�JId
            input.UserMainId = UserMainId;

            //�~���ǤJ
            var RefreshItem = input.RefreshItem;
            var UserCompanyJobApplyId = input.Id;

            //���n�ܧ󪺭�
            input.Sort = input.Sort != null ? input.Sort : ShareDefine.Sort;
            input.DateA = input.DateA != null ? input.DateA : ShareDefine.DateA;
            input.DateD = input.DateD != null ? input.DateD : ShareDefine.DateD;
            input.Status = input.Status.IsNullOrEmpty() ? "1" : input.Status;
            input.ExtendedInformation = input.ExtendedInformation.IsNullOrEmpty() ? "" : input.ExtendedInformation;

            //�ˬd
            await SaveUserCompanyJobApplyCheckAsync(input);

            //�D����
            var qrbUserCompanyJobApply = await _appService._userCompanyJobApplyRepository.GetQueryableAsync();
            var itemqrbUserCompanyJobApply = qrbUserCompanyJobApply.FirstOrDefault(p => p.Id == UserCompanyJobApplyId);

            //�p�GCompanyJobApplicationMethodsRepository�S���o��Id�N�s�W��ơA�w�s�b�Nupdate
            if (itemqrbUserCompanyJobApply == null)
            {
                input.DateA = DateTime.Now;
                itemqrbUserCompanyJobApply = ObjectMapper.Map<SaveUserCompanyJobApplyInput, UserCompanyJobApply>(input);
                itemqrbUserCompanyJobApply = await _appService._userCompanyJobApplyRepository.InsertAsync(itemqrbUserCompanyJobApply);
            }
            else
            {
                //���n�ܧ󪺭�
                ObjectMapper.Map(input, itemqrbUserCompanyJobApply);
                await _appService._userCompanyJobApplyRepository.UpdateAsync(itemqrbUserCompanyJobApply);
            }
            if (RefreshItem)
                await _appService._unitOfWorkManager.Current.SaveChangesAsync();

            ObjectMapper.Map(itemqrbUserCompanyJobApply, Result);

            return Result;
        }

        public virtual async Task<ResultDto> SaveUserCompanyJobApplyCheckAsync(SaveUserCompanyJobApplyInput input)
        {
            //���G
            var Result = new ResultDto();
            var ex = new UserFriendlyException("���~�T��");

            //�`��

            //�t�μh��
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

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

        public virtual async Task<UserCompanyJobApplysDto> DeleteUserCompanyJobApplyAsync(UserCompanyJobApplyInput input)
        {
            var Result = new UserCompanyJobApplysDto();
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
            var qrbUserCompanyJobApply = await _appService._userCompanyJobApplyRepository.GetQueryableAsync();
            var itemUserCompanyJobApply = qrbUserCompanyJobApply.FirstOrDefault(p => p.Id == Id);
            if (ex.Data.Count == 0)
            {
                if (itemUserCompanyJobApply == null)
                    ex.Data.Add(GuidGenerator.Create().ToString(), "�S���������");
                else
                {
                    await _appService._userCompanyJobApplyRepository.DeleteAsync(itemUserCompanyJobApply);
                    ObjectMapper.Map(itemUserCompanyJobApply, Result);
                }
            }

            if (ex.Data.Count > 0)
                throw ex;

            return Result;
        }
    }
}