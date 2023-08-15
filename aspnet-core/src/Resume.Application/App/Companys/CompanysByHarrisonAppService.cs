using Resume.App.Shares;
using Resume.CompanyJobApplicationMethods;
using Resume.CompanyJobConditions;
using Resume.CompanyJobContents;
using Resume.CompanyJobPays;
using Resume.CompanyJobs;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Validation;
using Resume.App.Users;
using Volo.Saas.Tenants;
using static Volo.Abp.Identity.Settings.IdentitySettingNames;
using Volo.Abp.Users;
using PayPalCheckoutSdk.Orders;
using Volo.Abp.MultiTenancy;

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

            //系統層級
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //強制把input帶入系統值
            input.CompanyMainId = CompanyMainId;

            //外部傳入
            var CompanyJobContentId = input.Id;
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

                ////如果要更新為最新資料 就需要認可交易
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
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //外部傳入
            var CompanyJobContentId = input.Id;
            var JobTypeCode = input.JobTypeCode ?? ""; //
            var Name = input.Name ?? "";
            var JobType = input.JobType ?? ""; //
            var SalaryPayTypeCode = input.SalaryPayTypeCode ?? ""; //
            var WorkPlace = input.WorkPlace ?? ""; //
            var WorkHours = input.WorkHours ?? ""; //

            //預設值
            if (CompanyMainId != input.CompanyMainId)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = L[nameof(CompanyMainId)] + L[ResumeDomainErrorCodes.NotExists], Pass = false });


            //必要代碼檢核
            //if (CompainMainId.IsNullOrEmpty())
            //    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "公司代碼不能空白", Pass = false });

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

            var itemsCompanymain = await _appService._companyMainRepository.GetQueryableAsync();
            var item = itemsCompanymain.FirstOrDefault(p => p.Id == CompanyMainId);

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

            //var CompanyMainId = input.CompanyMainId ?? "";
            var EducationLevel = input.EducationLevel ?? "";


            if (EducationLevel.IsNullOrEmpty())
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "教育程度不能空白", Pass = false });

            var inputShareCodeGroup = new ShareCodeGroupInput();
            inputShareCodeGroup.ListGroupCode.Add("EducationLevel");
            var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);

            if (!itemsShareCode.Any(p => p.GroupCode == "EducationLevel" && p.Code == EducationLevel))
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "教育程度代碼錯誤" });

            var itemsCompanymain = await _appService._companyMainRepository.GetQueryableAsync();
            var item = itemsCompanymain.FirstOrDefault(p => p.Id == CompanyMainId);

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

        /// <summary>
        /// 儲存工作應徵方式
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public virtual async Task<CompanyJobApplicationMethodsDto> SaveCompanyJobApplicationMethodAsync(SaveCompanyJobApplicationMethodInput input)
        {
            var Result = new CompanyJobApplicationMethodsDto();
            //系統層級
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //強制帶入Id
            input.CompanyMainId = CompanyMainId;

            //外部傳入
            var CompanyJobApplicationMethodId = input.Id;
            var RefreshItem = input.RefreshItem;

            //不要變更的值
            input.Sort = input.Sort != null ? input.Sort : ShareDefine.Sort;
            input.DateA = input.DateA != null ? input.DateA : ShareDefine.DateA;
            input.DateD = input.DateD != null ? input.DateD : ShareDefine.DateD;

            //檢查
            await SaveCompanyJobApplicationMethodCheckAsync(input);


            //主體資料
            var qrbCompanyJobApplicationMethod = await _appService._companyJobApplicationMethodRepository.GetQueryableAsync();
            var itemCompanyJobApplicationMethod = qrbCompanyJobApplicationMethod.FirstOrDefault(p => p.Id == CompanyJobApplicationMethodId);

            //如果CompanyJobApplicationMethodsRepository沒有這個Id就新增資料，已存在就update
            if (itemCompanyJobApplicationMethod == null)
            {
                itemCompanyJobApplicationMethod = ObjectMapper.Map<SaveCompanyJobApplicationMethodInput, CompanyJobApplicationMethod>(input);
                itemCompanyJobApplicationMethod = await _appService._companyJobApplicationMethodRepository.InsertAsync(itemCompanyJobApplicationMethod);
            }
            else
            {
                //不要變更的值
                input.Sort = itemCompanyJobApplicationMethod.Sort;
                input.DateA = itemCompanyJobApplicationMethod.DateA;
                input.DateD = itemCompanyJobApplicationMethod.DateD;

                ObjectMapper.Map(input, itemCompanyJobApplicationMethod);
                await _appService._companyJobApplicationMethodRepository.UpdateAsync(itemCompanyJobApplicationMethod);
            }
            if (RefreshItem)
                await _appService._unitOfWorkManager.Current.SaveChangesAsync();

            ObjectMapper.Map(itemCompanyJobApplicationMethod, Result);
            return Result;
        }

        public virtual async Task<ResultDto> SaveCompanyJobApplicationMethodCheckAsync(SaveCompanyJobApplicationMethodInput input)
        {
            var Result = new ResultDto();

            var CompanyMainId = input.CompanyMainId;
            var OrgDept = input.OrgDept ?? "";
            var OrgContactPerson = input.OrgContactPerson ?? "";
            var OrgContactMail = input.OrgContactMail ?? "";
            var ToRespond = input.ToRespond;

            if (OrgDept.IsNullOrEmpty())
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "部門不能空白", Pass = false });
            if (OrgContactPerson.IsNullOrEmpty())
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "職務聯絡人不能空白", Pass = false });
            if (OrgContactMail.IsNullOrEmpty())
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "職務E-mail不能空白", Pass = false });

            var itemsCompanymain = await _appService._companyMainRepository.GetQueryableAsync();
            var item = itemsCompanymain.FirstOrDefault(p => p.Id == CompanyMainId);

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

        public virtual async Task<CompanyJobApplicationMethodsDto> GetCompanyJobApplicationMethodAsync(CompanyJobApplicationMethodInput input)
        {
            var Result = new CompanyJobApplicationMethodsDto();

            var ex = new UserFriendlyException("錯誤訊息");

            //常用

            //系統層級
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //強制把input帶入系統值

            //外部傳入
            var CompanyJobApplicationMethodId = input.Id;

            //預設值


            //檢查
            if (CompanyJobApplicationMethodId.ToString() == " ")
            {
                ex.Data.Add(GuidGenerator.Create().ToString(), "ID不能為空白");
                throw ex;
            }
            //主體資料
            var qrbCompanyJobApplicationMethod = await _appService._companyJobApplicationMethodRepository.GetQueryableAsync();

            if (ex.Data.Count == 0)
            {

                //如果是一般公司
                var itemCompanyJobApplicationMethod = qrbCompanyJobApplicationMethod.FirstOrDefault(p => p.Id == CompanyJobApplicationMethodId);
                if (itemCompanyJobApplicationMethod == null)
                    ex.Data.Add(GuidGenerator.Create().ToString(), "沒有這筆資料");

                ObjectMapper.Map(itemCompanyJobApplicationMethod, Result);
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

            var itemsCompanyMain = await _appService._companyMainRepository.GetQueryableAsync();
            var item = itemsCompanyMain.FirstOrDefault(p => p.Id == CompanyMainId);

            if (item == null)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "資料不存在", Pass = false });

            Result.Check = !Result.Messages.Any(p => !p.Pass);

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
            var DateA = input.JobOpen;
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

            var CompanyMainId = input.CompanyMainId;
            var JobOpen = input.JobOpen;

            if (JobOpen.Equals(null))
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "職缺開關不能空白", Pass = false });

            var itemsCompanyMain = await _appService._companyMainRepository.GetQueryableAsync();
            var item = itemsCompanyMain.FirstOrDefault(p => p.Id == CompanyMainId);

            if (item == null)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "資料不存在", Pass = false });

            Result.Check = !Result.Messages.Any(p => !p.Pass);

            return Result;
        }
    }
}



