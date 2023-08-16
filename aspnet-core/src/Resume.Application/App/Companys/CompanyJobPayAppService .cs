using Microsoft.Extensions.DependencyInjection;
using Resume.App.Shares;
using Resume.App.Users;
using Resume.CompanyJobPays;
using Resume.CompanyJobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace Resume.App.Companys
{
    public partial class CompanysAppService : ApplicationService, ICompanysAppService
    {
        public virtual async Task<CompanyJobPaysDto> SaveCompanyJobPayAsync(SaveCompanyJobPayInput input)
        {
            var Result = new CompanyJobPaysDto();

            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //強制帶入Id
            input.CompanyMainId = CompanyMainId;

            //外部傳入
            var CompanyJobPayId = input.Id;
            var RefreshItem = input.RefreshItem;

            //不要變更的值
            input.Sort = input.Sort != null ? input.Sort : ShareDefine.Sort;
            input.DateA = input.DateA != null ? input.DateA : ShareDefine.DateA;
            input.DateD = input.DateD != null ? input.DateD : ShareDefine.DateD;

            //檢查
            await SaveCompanyJobPayCheckAsync(input);


            //主體資料
            var qrbCompanyJobPay = await _appService._companyJobPayRepository.GetQueryableAsync();
            var itemCompanyJobPay = qrbCompanyJobPay.FirstOrDefault(p => p.Id == CompanyJobPayId);

            //如果CompanyJobPaysRepository沒有這個Id就新增資料，已存在就update
            if (itemCompanyJobPay == null)
            {
                itemCompanyJobPay = ObjectMapper.Map<SaveCompanyJobPayInput, CompanyJobPay>(input);
                itemCompanyJobPay = await _appService._companyJobPayRepository.InsertAsync(itemCompanyJobPay);
            }
            else
            {
                //不要變更的值
                input.Sort = itemCompanyJobPay.Sort;
                input.DateA = itemCompanyJobPay.DateA;
                input.DateD = itemCompanyJobPay.DateD;

                ObjectMapper.Map(input, itemCompanyJobPay);
                await _appService._companyJobPayRepository.UpdateAsync(itemCompanyJobPay);
            }
            if (RefreshItem)
                await _appService._unitOfWorkManager.Current.SaveChangesAsync();

            ObjectMapper.Map(itemCompanyJobPay, Result);
            return Result;
        }

        public virtual async Task<ResultDto> SaveCompanyJobPayCheckAsync(SaveCompanyJobPayInput input)
        {
            var Result = new ResultDto();

            var JobPayTypeCode = input.JobPayTypeCode ?? "";
            var DateReal = input.DateReal;

            if (JobPayTypeCode.IsNullOrEmpty())
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "付費代碼不能空白", Pass = false });
            if (DateReal.Equals(null))
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "上架日期不能空白", Pass = false });

            var inputShareCodeGroup = new ShareCodeGroupInput();
            inputShareCodeGroup.ListGroupCode.Add("JobPayTypeCode");
            var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);

            if (!itemsShareCode.Any(p => p.GroupCode == "JobPayTypeCode" && p.Code == JobPayTypeCode))
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "付費類別代碼錯誤" });

            var itemsCompanyjob = await _appService._companyJobRepository.GetQueryableAsync();
         //   var item = itemsCompanyjob.FirstOrDefault(p => p.Id == CompanyJobId);

            //if (item == null)
            //    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "資料不存在", Pass = false });

            var ex = new UserFriendlyException("系統發生錯誤");
            foreach (var msg in Result.Messages)
                ex.Data.Add(GuidGenerator.Create().ToString(), msg.MessageContents);


            Result.Check = !Result.Messages.Any(p => !p.Pass);
            if (!Result.Check)
                throw ex;

            return Result;

        }
        public virtual async Task<CompanyJobsDto> GetCompanyJobsAsync(CompanyJobInput input)
        {
            var Result = new CompanyJobsDto();

            var CompanyJobId = input.Id;

            if (CompanyJobId.Equals(null))
            {
                var ex = new UserFriendlyException("Id不能空白");
                throw ex;
            }

            //var inputCompanyJobs = new GetCompanyJobsInput();
            //inputCompanyJobs.IsDelelte

            var itemCompanyJob = await _appService._companyJobsAppService.GetAsync(CompanyJobId);

            Result = ObjectMapper.Map<CompanyJobDto, CompanyJobsDto>(itemCompanyJob);
            return Result;
        }
    }

}