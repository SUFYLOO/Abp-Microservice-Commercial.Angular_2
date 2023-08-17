using Microsoft.Extensions.DependencyInjection;
using PayPalCheckoutSdk.Orders;
using Resume.App.Shares;
using Resume.App.Users;
using Resume.CompanyJobApplicationMethods;
using Resume.CompanyJobConditions;
using Resume.CompanyJobContents;
using Resume.CompanyJobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace Resume.App.Companys
{
    public partial class CompanysAppService : ApplicationService, ICompanysAppService
    {
        public virtual async Task<CompanyJobConditionsDto> SaveCompanyJobConditionAsync(SaveCompanyJobConditionInput input)
        {
            var Result = new CompanyJobConditionsDto();
            //系統層級
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //強制帶入Id
            input.CompanyMainId = CompanyMainId;

            //外部傳入
            var CompanyJobConditionId = input.Id;
            var RefreshItem = input.RefreshItem;

            //不要變更的值
            input.Sort = input.Sort != null ? input.Sort : ShareDefine.Sort;
            input.DateA = input.DateA != null ? input.DateA : ShareDefine.DateA;
            input.DateD = input.DateD != null ? input.DateD : ShareDefine.DateD;

            //檢查
            await SaveCompanyJobConditionCheckAsync(input);


            //主體資料
            var qrbcompanyJobCondition = await _appService._companyJobConditionRepository.GetQueryableAsync();
            var itemCompanyJobCondition = qrbcompanyJobCondition.FirstOrDefault(p => p.Id == CompanyJobConditionId);

            //如果CompanyJobConditionsRepository沒有這個Id就新增資料，已存在就update
            if (itemCompanyJobCondition == null)
            {
                itemCompanyJobCondition = ObjectMapper.Map<SaveCompanyJobConditionInput, CompanyJobCondition>(input);
                itemCompanyJobCondition = await _appService._companyJobConditionRepository.InsertAsync(itemCompanyJobCondition);
            }
            else
            {
                //不要變更的值
                input.Sort = itemCompanyJobCondition.Sort;
                input.DateA = itemCompanyJobCondition.DateA;
                input.DateD = itemCompanyJobCondition.DateD;

                ObjectMapper.Map(input,itemCompanyJobCondition);
                await _appService._companyJobConditionRepository.UpdateAsync(itemCompanyJobCondition);
            }
            if (RefreshItem)
                await _appService._unitOfWorkManager.Current.SaveChangesAsync();

            ObjectMapper.Map(itemCompanyJobCondition, Result);
            return Result;
        }

        public virtual async Task<ResultDto> SaveCompanyJobConditionCheckAsync(SaveCompanyJobConditionInput input)
        {
            var Result = new ResultDto();

            var CompanyJobId = input.CompanyJobId;
            var EducationLevel = input.EducationLevel ?? "";


            if (EducationLevel.IsNullOrEmpty())
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "教育程度不能空白", Pass = false });

            var inputShareCodeGroup = new ShareCodeGroupInput();
            inputShareCodeGroup.ListGroupCode.Add("EducationLevel");
            var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);

            if (!itemsShareCode.Any(p => p.GroupCode == "EducationLevel" && p.Code == EducationLevel))
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "教育程度代碼錯誤" });

            var itemsCompanyjob = await _appService._companyJobRepository.GetQueryableAsync();
            var item = itemsCompanyjob.FirstOrDefault(p => p.Id == CompanyJobId);

            if (item == null)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "資料不存在", Pass = false });

            var ex = new UserFriendlyException("系統發生錯誤");
            foreach (var msg in Result.Messages)
                ex.Data.Add(GuidGenerator.Create().ToString(), msg.MessageContents);

            Result.Check = !Result.Messages.Any(p => !p.Pass);
            if (!Result.Check)
                throw ex;

            return Result;
        }

        public virtual async Task<CompanyJobConditionsDto> GetCompanyJobConditionAsync(CompanyJobConditionInput input)
        {
            var Result = new CompanyJobConditionsDto();

            var ex = new UserFriendlyException("錯誤訊息");

            //常用

            //系統層級
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //強制把input帶入系統值

            //外部傳入
            var CompanyJobConditionId = input.Id;

            //預設值


            //檢查
            if (CompanyJobConditionId.ToString() == " ")
            {
                ex.Data.Add(GuidGenerator.Create().ToString(), "ID不能為空白");
                throw ex;
            }
            //主體資料
            var qrbCompanyJobCondition = await _appService._companyJobConditionRepository.GetQueryableAsync();

            if (ex.Data.Count == 0)
            {

                //如果是一般公司
                var itemCompanyJobCondition = qrbCompanyJobCondition.FirstOrDefault(p => p.Id == CompanyJobConditionId);
                if (itemCompanyJobCondition == null)
                    ex.Data.Add(GuidGenerator.Create().ToString(), "沒有這筆資料");

                ObjectMapper.Map(itemCompanyJobCondition, Result);
            }
            if (ex.Data.Count > 0)
                throw ex;

            return Result;
        }
    }
}



