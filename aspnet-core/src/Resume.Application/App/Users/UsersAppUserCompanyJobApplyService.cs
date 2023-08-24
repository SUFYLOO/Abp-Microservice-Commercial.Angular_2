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
            //結果
            var Result = new List<UserCompanyJobApplysDto>();
            var ex = new UserFriendlyException("錯誤訊息");

            //常用

            //系統層級
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //主體資料
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
            //結果
            var Result = new UserCompanyJobApplysDto();
            var ex = new UserFriendlyException("錯誤訊息");

            //系統層級

            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //外部傳入
            var UserCompanyJobApplyId = input.Id;

            //預設值

            //檢查
            if (UserCompanyJobApplyId.ToString() == " ")
            {
                ex.Data.Add(GuidGenerator.Create().ToString(), "ID不能為空白");
                throw ex;
            }

            //主體取資料
            if (ex.Data.Count == 0)
            {

                //如果是一般公司
                var qrbUserCompanyJobApply = await _appService._userCompanyJobApplyRepository.GetQueryableAsync();
                var itemUserCompanyJobApply = qrbUserCompanyJobApply.FirstOrDefault(p => p.Id == UserCompanyJobApplyId);

                if (itemUserCompanyJobApply == null)
                    ex.Data.Add(GuidGenerator.Create().ToString(), "沒有這筆資料");

                ObjectMapper.Map(itemUserCompanyJobApply, Result);
            }
            if (ex.Data.Count > 0)
                throw ex;

            return Result;
        }

     

        public async Task<UserCompanyJobApplysDto> SaveUserCompanyJobApplyAsync(SaveUserCompanyJobApplyInput input)
        {
            var Result = new UserCompanyJobApplysDto();

            //系統層級
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //強制帶入Id
            input.UserMainId = UserMainId;

            //外部傳入
            var RefreshItem = input.RefreshItem;
            var UserCompanyJobApplyId = input.Id;

            //不要變更的值
            input.Sort = input.Sort != null ? input.Sort : ShareDefine.Sort;
            input.DateA = input.DateA != null ? input.DateA : ShareDefine.DateA;
            input.DateD = input.DateD != null ? input.DateD : ShareDefine.DateD;
            input.Status = input.Status.IsNullOrEmpty() ? "1" : input.Status;
            input.ExtendedInformation = input.ExtendedInformation.IsNullOrEmpty() ? "" : input.ExtendedInformation;

            //檢查
            await SaveUserCompanyJobApplyCheckAsync(input);

            //主體資料
            var qrbUserCompanyJobApply = await _appService._userCompanyJobApplyRepository.GetQueryableAsync();
            var itemqrbUserCompanyJobApply = qrbUserCompanyJobApply.FirstOrDefault(p => p.Id == UserCompanyJobApplyId);

            //如果CompanyJobApplicationMethodsRepository沒有這個Id就新增資料，已存在就update
            if (itemqrbUserCompanyJobApply == null)
            {
                input.DateA = DateTime.Now;
                itemqrbUserCompanyJobApply = ObjectMapper.Map<SaveUserCompanyJobApplyInput, UserCompanyJobApply>(input);
                itemqrbUserCompanyJobApply = await _appService._userCompanyJobApplyRepository.InsertAsync(itemqrbUserCompanyJobApply);
            }
            else
            {
                //不要變更的值
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
            //結果
            var Result = new ResultDto();
            var ex = new UserFriendlyException("錯誤訊息");

            //常用

            //系統層級
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //外部傳入

            var CompanyJobId = input.CompanyJobId;


            //必要代碼檢核

            var qrbCompanyJob = await _appService._companyJobRepository.GetQueryableAsync();
            var itemCompanyJob = qrbCompanyJob.FirstOrDefault(p => p.Id == CompanyJobId);

            if (itemCompanyJob == null)
                ex.Data.Add(GuidGenerator.Create().ToString(), "沒有這筆資料");

            foreach (var msg in Result.Messages)
                ex.Data.Add(GuidGenerator.Create().ToString(), msg.MessageContents);

            if (ex.Data.Count > 0)
                throw ex;

            return Result;
        }

        public virtual async Task<UserCompanyJobApplysDto> DeleteUserCompanyJobApplyAsync(UserCompanyJobApplyInput input)
        {
            var Result = new UserCompanyJobApplysDto();
            var ex = new UserFriendlyException("錯誤訊息");

            //常用

            //系統層級

            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //強制把input帶入系統值

            //外部傳入
            var Id = input.Id;

            //預設值

            //檢查


            //主體資料
            var qrbUserCompanyJobApply = await _appService._userCompanyJobApplyRepository.GetQueryableAsync();
            var itemUserCompanyJobApply = qrbUserCompanyJobApply.FirstOrDefault(p => p.Id == Id);
            if (ex.Data.Count == 0)
            {
                if (itemUserCompanyJobApply == null)
                    ex.Data.Add(GuidGenerator.Create().ToString(), "沒有此筆資料");
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