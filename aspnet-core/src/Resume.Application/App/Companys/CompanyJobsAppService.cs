using Resume.App.Users;
using Resume.CompanyJobs;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp;
using Volo.Abp.MultiTenancy;
using Resume.CompanyJobContents;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Repositories;

namespace Resume.App.Companys
{
    public partial class CompanysAppService : ApplicationService, ICompanysAppService
    {
        public virtual async Task<List<CompanyJobsDto>> GetCompanyJobListAsync(CompanyJobListInput input)
        {
            var Result = new List<CompanyJobsDto>();
            var ex = new UserFriendlyException("錯誤訊息");

            //系統層級
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            if (SystemUserRoleKeys >= 16)
                ex.Data.Add(GuidGenerator.Create().ToString(), "您沒有權限");

            //輸入值
            var JobOpen = input.JobOpen;
            var KeyWords = input.KeyWords;
            var SortName = input.SortName;

            //主體資料
            var qrbCompanyJob = await _appService._companyJobRepository.GetQueryableAsync();
            qrbCompanyJob = from c in qrbCompanyJob
                            where c.JobOpen == JobOpen
                            && c.Name.IndexOf(KeyWords) >= 0
                            select c;

            if (ex.Data.Count == 0)
            {
                var Data = qrbCompanyJob.OrderByDescending(p => p.LastModificationTime);
                if (SortName.Equals("Name"))
                    Data = qrbCompanyJob.OrderBy(p => p.Name);

                if (SortName.Equals("LastModificationTime"))
                    Data = qrbCompanyJob.OrderByDescending(p => p.LastModificationTime);

                var itemsCompanyJob = await AsyncExecuter.ToListAsync(Data);

                ObjectMapper.Map(itemsCompanyJob,Result);
            }

            if (ex.Data.Count > 0)
                throw ex;
            return Result;
        }

        public virtual async Task<CompanyJobsDto> GetCompanyJobAsync(CompanyJobInput input)
        {
            var Result = new CompanyJobsDto();
            var ex = new UserFriendlyException("錯誤訊息");

            //系統層級
            
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;



            //權限
            if (SystemUserRoleKeys >= 16)
                ex.Data.Add(GuidGenerator.Create().ToString(), "您沒有權限");

            //外部傳入
            var CompanyJobId = input.Id;

            //主體取資料
            if (ex.Data.Count == 0)
            {
                var qrbCompanyJob = await _appService._companyJobRepository.GetQueryableAsync();
                var itemCompanyJob = qrbCompanyJob.FirstOrDefault(p => p.Id == CompanyJobId);

                if (itemCompanyJob == null)
                    ex.Data.Add(GuidGenerator.Create().ToString(), "沒有這筆資料");

                ObjectMapper.Map<CompanyJob, CompanyJobsDto>(itemCompanyJob, Result);
            }
            //回傳錯誤
            if (ex.Data.Count > 0)

                throw ex;
            return Result;
        }

        public virtual async Task<CompanyJobDto> SaveCompanyJobAsync(SaveCompanyJobInput input)
        {
            //開殼
            var Result = new CompanyJobDto();
            var ex = new UserFriendlyException("錯誤訊息");

            //系統層級
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //要帶入companymainid
            input.CompanyMainId = CompanyMainId;
            input.LastModificationTime = DateTime.Now;

            //外部傳入
            var CompanyJobId = input.Id;
            var RefreshItem = input.RefreshItem;
            
            //檢查
            //由登入者的CurrentUser.Id尋找CompanyUser.UserMainId      
            //得到公司的主檔代碼(可能有多筆，來自於不同的，也可能來自於不同的租戶
            if (SystemUserRoleKeys >= 16)
                ex.Data.Add(GuidGenerator.Create().ToString(), "您沒有權限");

            //判斷公司是否與CurrentTenantId一致
            var qrbCompanyMain = await _appService._companyMainRepository.GetQueryableAsync();
            var itemCompanyMain = qrbCompanyMain.FirstOrDefault(p => p.Id == CompanyMainId);

            if (itemCompanyMain == null)
                ex.Data.Add(GuidGenerator.Create().ToString(), "您沒有權限");

            var qrbCompanyJob = await _appService._companyJobRepository.GetQueryableAsync();
            var itemCompanyJob = qrbCompanyJob.FirstOrDefault(p => p.Id == CompanyJobId);

            if (ex.Data.Count == 0 && itemCompanyJob ==null)
            {
                input.MailTplId = "01";
                input.SMSTplId = "01";
                itemCompanyJob = ObjectMapper.Map<SaveCompanyJobInput, CompanyJob>(input);
                itemCompanyJob = await _appService._companyJobRepository.InsertAsync(itemCompanyJob);
                await _appService._unitOfWorkManager.Current.SaveChangesAsync();
            }
            else
            {
                //不要變更的值
                input.Sort = itemCompanyJob.Sort;
                input.DateA = itemCompanyJob.DateA;
                input.DateD = itemCompanyJob.DateD;
                input.MailTplId = itemCompanyJob.MailTplId;
                input.SMSTplId = itemCompanyJob.SMSTplId;

                ObjectMapper.Map(input, itemCompanyJob);
                itemCompanyJob = await _appService._companyJobRepository.UpdateAsync(itemCompanyJob);

                //如果要更新為最新資料 就需要認可交易
                if (RefreshItem)
                    await _appService._unitOfWorkManager.Current.SaveChangesAsync();
            }
            ObjectMapper.Map(itemCompanyJob, Result);
            return Result;
        }

        

        public virtual async Task<CompanyJobsDto> DeleteCompanyJobAsync(DeleteCompanyJobInput input)
        {

            var Result = new CompanyJobsDto();
            var ex = new UserFriendlyException("錯誤訊息");

            //常用

            //系統層級
            var TenantId = CurrentTenant.Id;
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //強制把input帶入系統值
            //input.CompanyJobId = CompanyJobId;

            //外部傳入
            var Id = input.Id;
            //var RefreshItem = input.RefreshItem;

            //預設值
            //input.Sort = input.Sort != null ? input.Sort : ShareDefine.Sort;
            //input.DateA = input.DateA != null ? input.DateA : ShareDefine.DateA;
            //input.DateD = input.DateD != null ? input.DateD : ShareDefine.DateD;

            //檢查
            if (SystemUserRoleKeys > 5)
                ex.Data.Add(GuidGenerator.Create().ToString(), "您沒有權限");

            //主體資料
            var qrbCompanyjob = await _appService._companyJobRepository.GetQueryableAsync();
            var qrbsCompanyjob = from c in qrbCompanyjob
                                     //where c.DateA <= ShareDefine.DateTimeNow && ShareDefine.DateTimeNow <= c.DateD
                                     //&& c.Status == "1"                      
                                 select c;

            if (ex.Data.Count == 0)
                using (_appService._dataFilter.Disable<IMultiTenant>())
                {
                    var qrbCompanyUser = await _appService._companyUserRepository.GetQueryableAsync();
                    var qrbsCompanyUser = qrbCompanyUser.Where(p => p.UserMainId == UserMainId);
                    var ListCompanyMainId = qrbsCompanyUser.Select(p => p.CompanyMainId);

                    var itemCompanyJob = qrbsCompanyjob.FirstOrDefault(p => p.Id == Id);
                    if (itemCompanyJob == null)
                        ex.Data.Add(GuidGenerator.Create().ToString(), "您沒有權限");
                    else
                    {
                        await _appService._companyJobRepository.DeleteAsync(itemCompanyJob);
                        ObjectMapper.Map(itemCompanyJob, Result);
                    }
                }

            if (ex.Data.Count > 0)
                throw ex;
            return Result;
        }

        public virtual async Task<CompanyJobsDto> UpdateCompanyJobDateAsync(UpdateCompanyJobDateInput input)
        {
            var Result = new CompanyJobsDto();

            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            // 外部傳入
            var CompanyJobId = input.Id;
            var DateA = input.DateA;
            var DateD = input.DateD;
            //var RefreshItem = input.RefreshItem;

            //檢查
            await UpdateCompanyJobDateCheckAsync(input);

            //主體資料
            var qrbCompanyJob = await _appService._companyJobRepository.GetQueryableAsync();
            var itemCompanyJob = qrbCompanyJob.FirstOrDefault(p => p.Id == CompanyJobId);

            //映射
            ObjectMapper.Map(input, itemCompanyJob);
            itemCompanyJob = await _appService._companyJobRepository.UpdateAsync(itemCompanyJob);

            ObjectMapper.Map(itemCompanyJob, Result);
            return Result;
        }

        public virtual async Task<ResultDto> UpdateCompanyJobDateCheckAsync(UpdateCompanyJobDateInput input)
        {
            var Result = new ResultDto();

            var CompanyMainId = input.Id;
            var DateA = input.DateA;
            var DateD = input.DateD;

            if (DateA.Equals(null))
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "職缺上架日不能空白", Pass = false });

            if (DateD.Equals(null))
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "職缺下架日不能空白", Pass = false });

            if (DateA > DateD)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "日期輸入錯誤", Pass = false });

            var ex = new UserFriendlyException("系統發生錯誤");
            foreach (var msg in Result.Messages)
                ex.Data.Add(GuidGenerator.Create().ToString(), msg.MessageContents);


            Result.Check = !Result.Messages.Any(p => !p.Pass);
            if (!Result.Check)
                throw ex;

            return Result;
        }

        public virtual async Task<CompanyJobsDto> UpdateCompanyJobOpenAsync(UpdateCompanyJobOpenInput input)
        {
            var Result = new CompanyJobsDto();

            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            // 外部傳入
            var CompanyJobId = input.Id;
            var JobOpen = input.JobOpen;
            //var RefreshItem = input.RefreshItem;

            //檢查
            await UpdateCompanyJobOpenCheckAsync(input);

            //主體資料
            var qrbCompanyJob = await _appService._companyJobRepository.GetQueryableAsync();
            var itemCompanyJob = qrbCompanyJob.FirstOrDefault(p => p.Id == CompanyJobId);

            //映射
            ObjectMapper.Map(input, itemCompanyJob);
            itemCompanyJob = await _appService._companyJobRepository.UpdateAsync(itemCompanyJob);

            ObjectMapper.Map(itemCompanyJob, Result);

            return Result;
        }

        public virtual async Task<ResultDto> UpdateCompanyJobOpenCheckAsync(UpdateCompanyJobOpenInput input)
        {
            var Result = new ResultDto();

            var CompanyMainId = input.Id;
            var JobOpen = input.JobOpen;

            if (JobOpen.Equals(null))
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "職缺開關不能空白", Pass = false });

            var ex = new UserFriendlyException("系統發生錯誤");
            foreach (var msg in Result.Messages)
                ex.Data.Add(GuidGenerator.Create().ToString(), msg.MessageContents);


            Result.Check = !Result.Messages.Any(p => !p.Pass);
            if (!Result.Check)
                throw ex;

            Result.Check = !Result.Messages.Any(p => !p.Pass);

            return Result;
        }

    }
}
