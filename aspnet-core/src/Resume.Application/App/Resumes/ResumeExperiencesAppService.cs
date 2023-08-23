using Microsoft.Extensions.DependencyInjection;
using Resume.App.Companys;
using Resume.App.Shares;
using Resume.App.Users;
using Resume.CompanyJobs;
using Resume.CompanyMains;
using Resume.ResumeEducationss;
using Resume.ResumeExperiencess;
using Resume.ResumeMains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.MultiTenancy;
using Volo.Abp.ObjectMapping;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Resume.App.Resumes
{
    public partial class ResumesAppService : ApplicationService, IResumesAppService
    {
        public virtual async Task<ResumeExperiencessDto> SaveResumeExperiencesAsync(SaveResumeExperiencesInput input)
        {
            var Result = new ResumeExperiencessDto();

            //常用

            //系統層級
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //強制帶入Id

            //外部傳入
            input.Status = "1";
            input.ExtendedInformation = "";
            var RefreshItem = input.RefreshItem;
            var ResumeExperiencesId = input.Id;

            //不要變更的值
            input.Sort = input.Sort != null ? input.Sort : ShareDefine.Sort;
            input.DateA = input.DateA != null ? input.DateA : ShareDefine.DateA;
            input.DateD = input.DateD != null ? input.DateD : ShareDefine.DateD;

            //檢查
            //await SaveResumeExperiencesAsync(input);

            //主體資料
            var ResumeExperiences = await _appService._resumeExperiencesRepository.GetQueryableAsync();
            var itemResumeExperiences = ResumeExperiences.FirstOrDefault(p => p.Id == ResumeExperiencesId);

            //如果沒有ID就新增資料
            if (itemResumeExperiences == null)
            {
                itemResumeExperiences = ObjectMapper.Map<SaveResumeExperiencesInput, ResumeExperiences>(input);
                itemResumeExperiences = await _appService._resumeExperiencesRepository.InsertAsync(itemResumeExperiences);
            }
            else
            {
                //不要變更的值
                input.Sort = itemResumeExperiences.Sort;
                input.DateD = itemResumeExperiences.DateD;
                input.DateA = itemResumeExperiences.DateA;

                ObjectMapper.Map(input, itemResumeExperiences);
                await _appService._resumeExperiencesRepository.UpdateAsync(itemResumeExperiences);
            }

            ObjectMapper.Map(itemResumeExperiences, input);

            return Result;
        }

        public virtual async Task<ResultDto> SaveResumeExperiencesCheckAsync(SaveResumeExperiencesInput input)
        {
            //結果
            var Result = new ResultDto();
            var ex = new UserFriendlyException("錯誤訊息");

            //常用

            //系統層級
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>()?.CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>()?.UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>()?.SystemUserRoleKeys;

            //外部傳入
            var ResumeMainId = input.ResumeMainId;
            var WorkNatureCode = input.WorkNatureCode;
            var IndustryCategoryCode = input.IndustryCategoryCode;
            var JobName = input.JobName;
            var JobType = input.JobType;
            var WorkPlaceCode = input.WorkPlaceCode;
            var SalaryPayTypeCode = input.SalaryPayTypeCode;
            var CurrencyTypeCode = input.CurrencyTypeCode;
            var CompanyScaleCode = input.CompanyScaleCode;
            var CompanyManagementNumberCode = input.CompanyManagementNumberCode;

            //必要代碼檢核
            var conditions = new List<GroupCodeConditions>()
            {
                new GroupCodeConditions(){GroupCode = "WorkNature",Code =WorkNatureCode, ErrorMessage = "工作性質代碼錯誤" ,AllowNull = false},
                new GroupCodeConditions(){GroupCode = "IndustryCategory",Code = IndustryCategoryCode , ErrorMessage = "產業類別代碼錯誤" ,AllowNull = false},
                new GroupCodeConditions(){GroupCode = "JobType",Code = JobType  , ErrorMessage = "職務類別代碼錯誤", AllowNull = true},
                new GroupCodeConditions(){GroupCode = "WorkPlace",Code = WorkPlaceCode , ErrorMessage = "工作地點代碼錯誤", AllowNull = true},
                new GroupCodeConditions(){GroupCode = "SalaryPayType",Code = SalaryPayTypeCode , ErrorMessage = "薪資發放分類代碼錯誤", AllowNull = false},
                new GroupCodeConditions(){GroupCode = "CurrencyType",Code = CurrencyTypeCode , ErrorMessage = "幣別代碼錯誤", AllowNull = false},
                new GroupCodeConditions(){GroupCode = "CompanyScale",Code = CompanyScaleCode , ErrorMessage = "公司規模代碼錯誤", AllowNull = false},
                new GroupCodeConditions(){GroupCode = "CompanyManagementNumber",Code = CompanyManagementNumberCode , ErrorMessage = "管理人數代碼錯誤", AllowNull = false}
            };

            Result = await _appService._serviceProvider.GetService<SharesAppService>().CheckGroupCode(Result, conditions);

            var qrbCompanyJob = await _appService._companyJobRepository.GetQueryableAsync();
            var itemCompanyJob = qrbCompanyJob.FirstOrDefault(p => p.Id == ResumeMainId);

            if (itemCompanyJob == null)
                ex.Data.Add(GuidGenerator.Create().ToString(), "沒有這筆資料");

            foreach (var msg in Result.Messages)
                ex.Data.Add(GuidGenerator.Create().ToString(), msg.MessageContents);

            Result.Check = !Result.Messages.Any(p => !p.Pass);
            if (!Result.Check)
                throw ex;

            return Result;
        }

        public virtual async Task<List<ResumeExperiencessDto>> GetResumeExperiencesListAsync(ResumeExperiencesInput input)
        {
            //結果
            var Result = new List<ResumeExperiencessDto>();
            var ex = new UserFriendlyException("錯誤訊息");
            //常用

            //系統層級
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //主體資料
            var qrbResumeExperiences = await _appService._resumeExperiencesRepository.GetQueryableAsync();
            var qrbsResumeExperiences = from c in qrbResumeExperiences
                                        //where c.UserMainId == ResumeMainId
                                         //&& (c.Id == ResumeMainId)
                                        //&& c.DateA <= DateNow && DateNow <= c.DateD
                                        //&& c.Status == "1"
                                        select c;
            var itemsResumMain = await AsyncExecuter.ToListAsync(qrbsResumeExperiences);
            //var itemsResumMain = await AsyncExecuter.ToListAsync(qrbsResumeExperiences);

            if (ex.Data.Count == 0)
            {
                //取得履歷所需要的代碼資料-為了加速
                var inputShareCodeGroup = new ShareCodeGroupInput();
                inputShareCodeGroup.ListGroupCode.Add("WorkNature");
                inputShareCodeGroup.ListGroupCode.Add("IndustryCategory");
                inputShareCodeGroup.ListGroupCode.Add("WorkPlace");
                inputShareCodeGroup.ListGroupCode.Add("JobType");
                inputShareCodeGroup.ListGroupCode.Add("SalaryPayType");
                inputShareCodeGroup.ListGroupCode.Add("CurrencyType");
                inputShareCodeGroup.ListGroupCode.Add("CompanyScale");
                inputShareCodeGroup.ListGroupCode.Add("CompanyManagementNumber");
                inputShareCodeGroup.AllForGroupCode = true;
                var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);
                {

                    ObjectMapper.Map(itemsResumMain, Result);

                    var inputSetShareCode = new SetShareCodeInput();
                    inputSetShareCode.ListShareCode = itemsShareCode;
                    inputSetShareCode.Data = Result;
                    var ListColumns = new List<NameCodeStandardDto>
                {
                        new NameCodeStandardDto { GroupCode = "WorkNature", Code = "WorkNatureCode", Name = "WorkNatureName" },
                        new NameCodeStandardDto { GroupCode = "IndustryCategory", Code = "IndustryCategoryCode", Name = "IndustryCategoryName" },
                        new NameCodeStandardDto { GroupCode = "WorkPlace", Code = "WorkPlaceCode", Name = "WorkPlaceName" },
                        new NameCodeStandardDto { GroupCode = "SalaryPayType", Code = "SalaryPayTypeCode", Name = "SalaryPayTypeName" },
                        new NameCodeStandardDto { GroupCode = "JobType", Code = "SJobTypeCode", Name = "JobTypeName" },
                        new NameCodeStandardDto { GroupCode = "CurrencyType", Code = "CurrencyTypeCode", Name = "CurrencyTypeName" },
                        new NameCodeStandardDto { GroupCode = "CompanyScale", Code = "CompanyScaleCode", Name = "CompanyScaleName" },
                        new NameCodeStandardDto { GroupCode = "CompanyManagementNumber", Code = "CompanyManagementNumberCode", Name = "CompanyManagementNumberName" }
                };

                    inputSetShareCode.ListColumns = ListColumns;
                    _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<ResumeExperiencessDto>(inputSetShareCode);
                }
            }

            if (ex.Data.Count > 0)
                throw ex;
            return Result;
        }

        public async Task<ResumeExperiencessDto> GetResumeExperiencessAsync(ResumeExperiencesInput input)
        {
            var Result = new ResumeExperiencessDto();
            var ex = new UserFriendlyException("錯誤訊息");

            //系統層級

            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //外部傳入
            var ResumeExperiencesId = input.Id;

            //主體取資料
            if (ex.Data.Count == 0)
            {
                var qrbResumeExperiences = await _appService._resumeExperiencesRepository.GetQueryableAsync();
                var itemResumeExperiences = qrbResumeExperiences.FirstOrDefault(p => p.Id == ResumeExperiencesId);

                if (itemResumeExperiences != null)
                {
                    var inputShareCodeGroup = new ShareCodeGroupInput();
                    inputShareCodeGroup.ListGroupCode.Add("Marriage");
                    inputShareCodeGroup.ListGroupCode.Add("Military");
                    inputShareCodeGroup.ListGroupCode.Add("DisabilityCategory");
                    inputShareCodeGroup.ListGroupCode.Add("SpecialIdentity");
                    inputShareCodeGroup.AllForGroupCode = true;
                    var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);

                    {
                        ObjectMapper.Map(itemResumeExperiences, Result);

                        var inputSetShareCode = new SetShareCodeInput();
                        inputSetShareCode.ListShareCode = itemsShareCode;
                        inputSetShareCode.Data = new List<ResumeExperiencessDto>();
                        var ListColumns = new List<NameCodeStandardDto>()
                        {
                        new NameCodeStandardDto { GroupCode = "Marriage", Code = "MarriageCode", Name = "MarriageName" },
                        new NameCodeStandardDto { GroupCode = "Military", Code = "MilitaryCode", Name = "MilitaryName" },
                        new NameCodeStandardDto { GroupCode = "DisabilityCategory", Code = "DisabilityCategoryCode", Name = "DisabilityCategoryName" },
                        new NameCodeStandardDto { GroupCode = "SpecialIdentity", Code = "SpecialIdentityCode", Name = "SpecialIdentityName" },
                        };

                        inputSetShareCode.ListColumns = ListColumns;
                        _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<ResumeExperiencessDto>(inputSetShareCode);

                        var inputShareUploadList = new ShareUploadListInput();
                        inputShareUploadList.Key1 = "ResumeExperiences";
                        inputShareUploadList.Key2 = "";
                        inputShareUploadList.Key3 = itemResumeExperiences.ResumeMainId.ToString();
                        var itemsShareUploadList = await _appService._serviceProvider.GetService<SharesAppService>().GetShareUploadListAsync(inputShareUploadList);
                    };
                }
                else
                {
                    ex.Data.Add(GuidGenerator.Create().ToString(), "沒有此筆資料");
                }
            }
            //回傳錯誤
            if (ex.Data.Count > 0)

                throw ex;
            return Result;
        }

        public virtual async Task<ResumeExperiencessDto> DeleteResumeExperiencesAsync(ResumeExperiencesInput input)
        {
            var Result = new ResumeExperiencessDto();
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
            var qrbResumeExperiences = await _appService._resumeExperiencesRepository.GetQueryableAsync();
            var itemResumeExperiences = qrbResumeExperiences.FirstOrDefault(p => p.Id == Id);
            if (ex.Data.Count == 0)
            {
                if (itemResumeExperiences == null)
                    ex.Data.Add(GuidGenerator.Create().ToString(), "沒有此筆資料");
                else
                {
                    await _appService._resumeExperiencesRepository.DeleteAsync(itemResumeExperiences);
                    ObjectMapper.Map(itemResumeExperiences, Result);
                }
            }

            if (ex.Data.Count > 0)
                throw ex;
            return Result;
        }

    }
}
