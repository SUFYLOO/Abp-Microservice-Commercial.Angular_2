using Resume.App.Users;
using Resume.ResumeSnapshots;
using Resume.UserInfos;
using Resume.UserMains;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.MultiTenancy;
using Resume.CompanyJobs;
using Resume.CompanyJobPays;
using Resume.App.Shares;

namespace Resume.App.Companys
{
    public partial class CompanysAppService : ApplicationService, ICompanysAppService
    {
        public virtual async Task<SaveCompanyJobPayDto> SaveCompanyJobPayAsync(SaveCompanyJobPayInput input)
        {
            var Result = new SaveCompanyJobPayDto();

            var CompanyJobPayId = input.Id;
            //await SaveCompanyJobPayCheckAsync(input);

            var qrbCompanyJobPay = await _appService._companyJobPayRepository.GetQueryableAsync();
            var itemCompanyJobPay = qrbCompanyJobPay.FirstOrDefault(p => p.Id == CompanyJobPayId);


            if (itemCompanyJobPay == null)
            {
                var itemCompanyJobPayDto = ObjectMapper.Map<SaveCompanyJobPayInput, CompanyJobPayDto>(input);

                itemCompanyJobPayDto.CompanyMainId = _appService._guidGenerator.Create();
                itemCompanyJobPayDto.CompanyJobId = _appService._guidGenerator.Create();

                itemCompanyJobPay = ObjectMapper.Map<CompanyJobPayDto, CompanyJobPay>(itemCompanyJobPayDto);
                await _appService._companyJobPayRepository.InsertAsync(itemCompanyJobPay);
                Result = ObjectMapper.Map<CompanyJobPay, SaveCompanyJobPayDto>(itemCompanyJobPay);
            }
            else
            {
                var item = ObjectMapper.Map<SaveCompanyJobPayInput, CompanyJobPay>(input);
                await _appService._companyJobPayRepository.UpdateAsync(item);

                Result = ObjectMapper.Map<CompanyJobPay, SaveCompanyJobPayDto>(item);
            }
            return Result;
        }

        public virtual async Task<ResultDto> SaveCompanyJobPayCheckAsync(SaveCompanyJobPayInput input)
        {
            var Result = new ResultDto();

            var CompanyMainId = input.CompanyMainId;
            var JobPayTypeCode = input.JobPayTypeCode ?? "";
            var DateReal = input.DateReal;

            if (JobPayTypeCode.IsNullOrEmpty())
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "付費代碼不能空白", Pass = false });
            if (DateReal.Equals(null))
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "上架日期不能空白", Pass = false });

            var itemsCompanymain = await _appService._companyMainRepository.GetQueryableAsync();
            var item = itemsCompanymain.FirstOrDefault(p => p.Id == CompanyMainId);

            var inputShareCodeGroup = new ShareCodeGroupInput();
            inputShareCodeGroup.ListGroupCode.Add("JobPayTypeCode");
            var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);

            if (!itemsShareCode.Any(p => p.GroupCode == "JobPayTypeCode" && p.Code == JobPayTypeCode))
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "付費類別代碼錯誤" });

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