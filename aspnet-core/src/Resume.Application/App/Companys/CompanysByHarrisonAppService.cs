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

namespace Resume.App.Companys
{
    public partial class CompanysAppService : ApplicationService, ICompanysAppService
    {
        /// <summary>
        /// 新增公司職缺內容方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public virtual async Task<SaveCompanyJobContentDto> SaveCompanyJobContentAsync(SaveCompanyJobContentInput input)
        {
            var Result = new SaveCompanyJobContentDto();

            var CompanyJobContentId = input.Id;


            await SaveCompanyJobContentCheckAsync(input);

            var qrbCompanyJobContent = await _appService._companyJobContentRepository.GetQueryableAsync();
            var itemCompanyJobContent = qrbCompanyJobContent.FirstOrDefault(p => p.Id == CompanyJobContentId);

            //var itemsCompanyJobContents = await _appService._companyJobContentsAppService.GetAsync(CompanyJobContentId)
            //如果CompanyJobContentRepository沒有這個Id就新增資料，已存在就update
            if (itemCompanyJobContent == null)
            {
                var itemCompanyJobContentDto = ObjectMapper.Map<SaveCompanyJobContentInput, CompanyJobContentDto>(input);

                itemCompanyJobContentDto.Id = _appService._guidGenerator.Create();

                itemCompanyJobContent = ObjectMapper.Map<CompanyJobContentDto, CompanyJobContent>(itemCompanyJobContentDto);
                await _appService._companyJobContentRepository.InsertAsync(itemCompanyJobContent);

                Result = ObjectMapper.Map<CompanyJobContent, SaveCompanyJobContentDto>(itemCompanyJobContent);
            }
            else
            {
                itemCompanyJobContent = ObjectMapper.Map<SaveCompanyJobContentInput, CompanyJobContent>(input);
                await _appService._companyJobContentRepository.UpdateAsync(itemCompanyJobContent);

                Result = ObjectMapper.Map<CompanyJobContent, SaveCompanyJobContentDto>(itemCompanyJobContent);
            }
            return Result;
        }
        /// <summary>
        /// 檢查公司職缺方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public virtual async Task<ResultDto> SaveCompanyJobContentCheckAsync(SaveCompanyJobContentInput input)
        {
            var Result = new ResultDto();

            var JobTypeCode = input.JobTypeCode ?? ""; //
            var Name = input.Name ?? "";
            var JobType = input.JobType ?? ""; //
            var SalaryPayTypeCode = input.SalaryPayTypeCode ?? ""; //
            var WorkPlace = input.WorkPlace ?? ""; //
            var WorkHours = input.WorkHours ?? ""; //

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

        public virtual async Task<SaveCompanyJobConditionDto> SaveCompanyJobConditionAsync(SaveCompanyJobConditionInput input)
        {
            var Result = new SaveCompanyJobConditionDto();

            var CompanyJobConditionId = input.Id;

            await SaveCompanyJobConditionCheckAsync(input);

            var qrbcompanyJobCondition = await _appService._companyJobConditionRepository.GetQueryableAsync();
            var itemCompanyJobCondition = qrbcompanyJobCondition.FirstOrDefault(p => p.Id == CompanyJobConditionId);

            //如果CompanyJobConditionsRepository沒有這個Id就新增資料，已存在就update
            if (itemCompanyJobCondition == null)
            {
                var CompanyJobConditionDto = ObjectMapper.Map<SaveCompanyJobConditionInput, CompanyJobConditionDto>(input);

                CompanyJobConditionDto.Id = GuidGenerator.Create();

                itemCompanyJobCondition = ObjectMapper.Map<CompanyJobConditionDto, CompanyJobCondition>(input);
                await _appService._companyJobConditionRepository.InsertAsync(itemCompanyJobCondition);

                Result = ObjectMapper.Map<CompanyJobCondition, SaveCompanyJobConditionDto>(itemCompanyJobCondition);
            }
            else
            {
                var item = ObjectMapper.Map<SaveCompanyJobConditionInput, CompanyJobCondition>(input);
                await _appService._companyJobConditionRepository.UpdateAsync(item);

                Result = ObjectMapper.Map<CompanyJobCondition, SaveCompanyJobConditionDto>(item);
            }

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
        public virtual async Task<SaveCompanyJobApplicationMethodDto> SaveCompanyJobApplicationMethodAsync(SaveCompanyJobApplicationMethodInput input)
        {
            var Result = new SaveCompanyJobApplicationMethodDto();

            var CompanyJobApplicationMethodId = input.Id;

            await SaveCompanyJobApplicationMethodCheckAsync(input);

            var qbrCompanyJobApplicationMethod = await _appService._companyJobApplicationMethodRepository.GetQueryableAsync();
            var itemCompanyJobApplicationMethod = qbrCompanyJobApplicationMethod.FirstOrDefault(p => p.Id == CompanyJobApplicationMethodId);

            if (itemCompanyJobApplicationMethod == null)
            {
                var itemCompanyJobApplicationMethodDto = ObjectMapper.Map<SaveCompanyJobApplicationMethodInput, CompanyJobApplicationMethodDto>(input);

                itemCompanyJobApplicationMethodDto.Id = GuidGenerator.Create();

                itemCompanyJobApplicationMethod = ObjectMapper.Map<CompanyJobApplicationMethodDto, CompanyJobApplicationMethod>(itemCompanyJobApplicationMethodDto);
                await _appService._companyJobApplicationMethodRepository.InsertAsync(itemCompanyJobApplicationMethod);

                Result = ObjectMapper.Map<CompanyJobApplicationMethod, SaveCompanyJobApplicationMethodDto>(itemCompanyJobApplicationMethod);
            }
            else
            {
                var item = ObjectMapper.Map<SaveCompanyJobApplicationMethodInput, CompanyJobApplicationMethod>(input);
                await _appService._companyJobApplicationMethodRepository.UpdateAsync(item);

                Result = ObjectMapper.Map<CompanyJobApplicationMethod, SaveCompanyJobApplicationMethodDto>(item);
            }
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

            var CompanyJobContentId = input.Id;

            if (CompanyJobContentId == null)
            {
                var ex = new AbpValidationException("代碼不能空白");
                throw ex;
            }

            var inputGetCompanyJobContents = new GetCompanyJobContentsInput();
            //inputGetCompanyJobContents.Id = CompanyJobContentId;
            var itemsCompanyJobContents = await _appService._companyJobContentsAppService.GetListAsync(inputGetCompanyJobContents);

            //var CompanyJobContentId = input.Id ?? input.CompanyJobContentId ?? _appService._guidGenerator.Create();
            //var itemCompanyJobContents = await _appService._companyJobContentsAppService.GetAsync(CompanyJobContentId);

            var itemCompanyJobContents = itemsCompanyJobContents.Items.FirstOrDefault();
            if (itemCompanyJobContents == null)
            {
                var ex = new EntityNotFoundException("沒有資料");
                throw ex;
            }

            Result = ObjectMapper.Map<CompanyJobContentDto, CompanyJobContentsDto>(itemCompanyJobContents);

            return Result;
        }

        public virtual async Task<CompanyJobConditionsDto> GetCompanyJobConditionAsync(CompanyJobConditionInput input)
        {
            var Result = new CompanyJobConditionsDto();

            var CompanyJobConditionId = input.Id;

            if (CompanyJobConditionId == null)
            {
                var ex = new AbpValidationException("代碼不能空白");
                throw ex;
            }

            var inputGetCompanyJobConditions = new GetCompanyJobConditionsInput();
            //inputGetCompanyJobConditions.Id = CompanyJobConditionId;
            var itemsCompanyJobConditions = await _appService._companyJobConditionAppService.GetListAsync(inputGetCompanyJobConditions);

            var itemCompanyJobConditions = itemsCompanyJobConditions.Items.FirstOrDefault();
            if (itemCompanyJobConditions == null)
            {
                var ex = new EntityNotFoundException("沒有資料");
                throw ex;
            }

            Result = ObjectMapper.Map<CompanyJobConditionDto, CompanyJobConditionsDto>(itemCompanyJobConditions);

            return Result;
        }

        public virtual async Task<CompanyJobApplicationMethodsDto> GetCompanyJobApplicationMethodAsync(CompanyJobApplicationMethodInput input)
        {
            var Result = new CompanyJobApplicationMethodsDto();

            var CompanyJobApplicationMethodId = input.Id;
            if (CompanyJobApplicationMethodId == null)
            {
                var ex = new AbpValidationException("代碼不能空白");
                throw ex;
            }

            var inputCompanyJobApplicationMethod = new GetCompanyJobApplicationMethodsInput();
            //inputCompanyJobApplicationMethod.Id = CompanyJobApplicationMethodId;
            var itemsCompanyJobApplicationMethod = await _appService._companyJobApplicationMethodsAppService.GetListAsync(inputCompanyJobApplicationMethod);

            var itemCompanyJobApplicationMethod = itemsCompanyJobApplicationMethod.Items.FirstOrDefault();
            if (itemCompanyJobApplicationMethod == null)
            {
                var ex = new EntityNotFoundException("沒有資料");
                throw ex;
            }
            Result = ObjectMapper.Map<CompanyJobApplicationMethodDto, CompanyJobApplicationMethodsDto>(itemCompanyJobApplicationMethod);

            return Result;
        }

        public virtual async Task<UpdateCompanyJobDateDto> UpdateCompanyJobDateAsync(UpdateCompanyJobDateInput input)
        {
            var Result = new UpdateCompanyJobDateDto();

            var CompanyJobId = input.Id;

            if (CompanyJobId.Equals(null))
            {
                var ex = new UserFriendlyException("Id不能空白");
                throw ex;
            }

            var qrbitemCompanyJob = await _appService._companyJobRepository.GetQueryableAsync();
            var itemCompanyJob = qrbitemCompanyJob.FirstOrDefault(p => p.Id == CompanyJobId);

            if (itemCompanyJob == null)
            {
                var item = ObjectMapper.Map<UpdateCompanyJobDateInput, CompanyJob>(input);
                item.DateA = input.DateA;
                item.DateD = input.DateD;
                await _appService._companyJobRepository.UpdateAsync(item);

                Result = ObjectMapper.Map<CompanyJob, UpdateCompanyJobDateDto>(item);
            }
            return Result;
        }

        public virtual async Task<SaveCompanyJobPayDto> SaveCompanyJobPayAsync(SaveCompanyJobPayInput input)
        {
            var Result = new SaveCompanyJobPayDto();

            var CompanyJobPayId = input.Id;
            await SaveCompanyJobPayCheckAsync(input);

            var qrbCompanyJobPay = await _appService._companyJobPayRepository.GetQueryableAsync();
            var itemCompanyJobPay = qrbCompanyJobPay.FirstOrDefault(p => p.Id == CompanyJobPayId);

          
                if (itemCompanyJobPay == null)
                {
                  var itemCompanyJobPayDto = ObjectMapper.Map<SaveCompanyJobPayInput, CompanyJobPayDto>(input);
                      itemCompanyJobPayDto.Id = GuidGenerator.Create();

                      itemCompanyJobPay = ObjectMapper.Map<CompanyJobPayDto, CompanyJobPay>(itemCompanyJobPayDto);
 
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

        public virtual async Task<List<CompanysJobDto>> GetCompanyJobsListAsync(CompanyJobsInput input)
        {
            var Result = new List<CompanysJobDto>();

            var JobOpen = input.JobOpen;
            var KeyWords = input.KeyWords;
            var SortName = input.SortName;

            var qrbCompanyJob = await _appService._companyJobRepository.GetQueryableAsync();
            qrbCompanyJob = from c in qrbCompanyJob
                            where c.JobOpen == JobOpen
                            && c.Name.IndexOf(KeyWords) >= 0
                            select c;

            var Data = qrbCompanyJob.OrderByDescending(p => p.LastModificationTime);
            if (SortName.Equals("Name"))
                Data = qrbCompanyJob.OrderBy(p => p.Name);

            if (SortName.Equals("LastModificationTime"))
                Data = qrbCompanyJob.OrderByDescending(p => p.LastModificationTime);

            var itemsCompanyJob = await AsyncExecuter.ToListAsync(Data);

            Result = ObjectMapper.Map<List<CompanyJob>, List<CompanysJobDto>>(itemsCompanyJob);
            return Result;
        }

        public virtual async Task<CompanysJobDto> GetCompanyJobsAsync(CompanyJobsInput input)
        {
            var Result = new CompanysJobDto();

            var CompanyJobId = input.Id;

            if (CompanyJobId.Equals(null))
            {
                var ex = new UserFriendlyException("Id不能空白");
                throw ex;
            }

            //var inputCompanyJobs = new GetCompanyJobsInput();
            //inputCompanyJobs.IsDelelte

            var itemCompanyJob = await _appService._companyJobsAppService.GetAsync(CompanyJobId);

            Result = ObjectMapper.Map<CompanyJobDto, CompanysJobDto>(itemCompanyJob);
            return Result;
        }

        public virtual async Task<UpdateCompanyJobOpenDto> UpdateCompanyJobOpenAsync(UpdateCompanyJobOpenInput input)
        {
            var Result = new UpdateCompanyJobOpenDto();

            var CompanyMainId = input.CompanyMainId;

            await UpdateCompanyJobOpenCheckAsync(input);

            var itemsCompanyJob = await _appService._companyJobRepository.GetQueryableAsync();
            var item = itemsCompanyJob.FirstOrDefault(p => p.Id == CompanyMainId);


            item.JobOpen = input.JobOpen;
            await _appService._companyJobRepository.UpdateAsync(item);

            Result = ObjectMapper.Map<CompanyJob, UpdateCompanyJobOpenDto>(item);

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



