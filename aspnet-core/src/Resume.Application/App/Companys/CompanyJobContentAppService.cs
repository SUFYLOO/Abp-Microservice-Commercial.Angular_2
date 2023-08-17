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
        /// <summary>
        /// 新增公司職缺內容方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public virtual async Task<CompanyJobContentsDto> SaveCompanyJobContentAsync(SaveCompanyJobContentInput input)
        {
            //結果
            var Result = new CompanyJobContentsDto();

            //常用 

            //呼叫CompanyJob
            var CompanyJobContentId = input.Id;
            var CompanyJobId = input.CompanyJobId;
            input.Id = CompanyJobId;

            var itemCompanyJob = ObjectMapper.Map<SaveCompanyJobContentInput, SaveCompanyJobInput>(input);
            var itemCompanyJobs = await SaveCompanyJobAsync(itemCompanyJob);
            
            var qrbCompanyJob = await _appService._companyJobRepository.GetQueryableAsync();
            var itemsCompanyJob = qrbCompanyJob.FirstOrDefault(p => p.Id == itemCompanyJobs.Id);

            //系統層級
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>()?.UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>()?.SystemUserRoleKeys;

             //強制把input帶入系統值
            input.CompanyMainId = CompanyMainId;
            input.CompanyJobId = itemsCompanyJob.Id;
            input.Id = CompanyJobContentId;

            //外部傳入
            //var CompanyJobContentId = Id;
            var RefreshItem = input.RefreshItem;
  

            //預設值
            input.Sort = input.Sort != null ? input.Sort : ShareDefine.Sort;
            input.DateA = input.DateA != null ? input.DateA : ShareDefine.DateA;
            input.DateD = input.DateD != null ? input.DateD : ShareDefine.DateD;

            //檢查
            await SaveCompanyJobContentCheckAsync(input);
            
            //主體資料
            var qrbCompanyJobContent = await _appService._companyJobContentRepository.GetQueryableAsync();
            var itemCompanyJobContent = qrbCompanyJobContent.FirstOrDefault(p => p.Id == CompanyJobContentId);

            //Result.SaveIntent = itemCompanyJobContent == null ? SaveIntentType.Insert : SaveIntentType.Update;

            if (itemCompanyJobContent == null)
            {
                itemCompanyJobContent = ObjectMapper.Map<SaveCompanyJobContentInput, CompanyJobContent>(input);
                itemCompanyJobContent = await _appService._companyJobContentRepository.InsertAsync(itemCompanyJobContent);
            }
            else
            {
                //不要變更的值
                input.Sort = itemCompanyJobContent.Sort;
                input.DateA = itemCompanyJobContent.DateA;
                input.DateD = itemCompanyJobContent.DateD;

                ObjectMapper.Map(input, itemCompanyJobContent);
                itemCompanyJobContent = await _appService._companyJobContentRepository.UpdateAsync(itemCompanyJobContent);
                //如果要更新為最新資料 就需要認可交易
                if (RefreshItem)
                    await _appService._unitOfWorkManager.Current.SaveChangesAsync();
            }
            ObjectMapper.Map(itemCompanyJobContent, Result);
            return Result;
        }

        /// <summary>
        /// 檢查公司職缺方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public virtual async Task<ResultDto> SaveCompanyJobContentCheckAsync(SaveCompanyJobContentInput input)
        {
            //結果
            var Result = new ResultDto();

            //常用

            //系統層級
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>()?.CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>()?.UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>()?.SystemUserRoleKeys;

            //外部傳入
            var CompanyJobId = input.CompanyJobId;
            var JobTypeCode = input.JobTypeCode ?? ""; 
            var Name = input.Name ?? "";
            var JobType = input.JobType ?? ""; 
            var SalaryPayTypeCode = input.SalaryPayTypeCode ?? ""; 
            var WorkPlace = input.WorkPlace ?? ""; 
            var WorkHours = input.WorkHours ?? ""; 

            //預設值
            //if (CompanyJobId != input.CompanyJobId)
            //    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = L[nameof(CompanyMainId)] + L[ResumeDomainErrorCodes.NotExists], Pass = false });


            //必要代碼檢核
         

            if (JobTypeCode.IsNullOrEmpty())
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "職務類型不能空白", Pass = false });

            if (Name.IsNullOrEmpty())
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "職缺名稱不能空白", Pass = false });

            if (JobType.IsNullOrEmpty())
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "職務類別不能空白", Pass = false });

            if (SalaryPayTypeCode.IsNullOrEmpty())
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "薪資發放不能空白", Pass = false });

            if (WorkPlace.IsNullOrEmpty())
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "工作地點不能空白", Pass = false });

            if (WorkHours.IsNullOrEmpty())
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "工作時段選項不能空白", Pass = false });

            var inputShareCodeGroup = new ShareCodeGroupInput();
            inputShareCodeGroup.ListGroupCode.Add("JobType");
            inputShareCodeGroup.ListGroupCode.Add("SalaryPayType");
            inputShareCodeGroup.ListGroupCode.Add("WorkPlace");
            inputShareCodeGroup.ListGroupCode.Add("WorkHours");
            var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);

            if (itemsShareCode.Any(p => p.GroupCode == "JobType" && p.Code == JobTypeCode))
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "職務類型代碼錯誤", Pass = false });

            if (itemsShareCode.Any(p => p.GroupCode == "JobType" && p.Code == JobType))
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "職務類別代碼錯誤", Pass = false });

            if (itemsShareCode.Any(p => p.GroupCode == "SalaryPayType" && p.Code == SalaryPayTypeCode))
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "薪水分類代碼錯誤", Pass = false });

            if (itemsShareCode.Any(p => p.GroupCode == "WorkPlace" && p.Code == WorkPlace))
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "工作地點錯誤", Pass = false });

            if (itemsShareCode.Any(p => p.GroupCode == "WorkHours" && p.Code == WorkHours))
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "工作時段錯誤", Pass = false });

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

        public virtual async Task<CompanyJobContentsDto> GetCompanyJobContentAsync(CompanyJobContentInput input)
        {
            var Result = new CompanyJobContentsDto();

            var ex = new UserFriendlyException("錯誤訊息");

            //常用

            //系統層級
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //強制把input帶入系統值

            //外部傳入
            var CompanyJobContentId = input.Id;

            //預設值


            //檢查
            if (CompanyJobContentId.ToString() == " ")
            {
                ex.Data.Add(GuidGenerator.Create().ToString(), "ID不能為空白");
                throw ex;
            }
            //主體資料
            var qrbCompanyJobContent = await _appService._companyJobContentRepository.GetQueryableAsync();

            if (ex.Data.Count == 0)
            {

                //如果是一般公司
                var itemCompanyJobContent = qrbCompanyJobContent.FirstOrDefault(p => p.Id == CompanyJobContentId);
                if (itemCompanyJobContent == null)
                    ex.Data.Add(GuidGenerator.Create().ToString(), "沒有這筆資料");

                ObjectMapper.Map(itemCompanyJobContent, Result);
            }
            if (ex.Data.Count > 0)
                throw ex;

            return Result;
        }

    }
}



