using Microsoft.Extensions.DependencyInjection;
using Resume.App.Companys;
using Resume.App.Shares;
using Resume.App.Users;
using Resume.CompanyJobContents;
using Resume.CompanyJobs;
using Resume.CompanyMains;
using Resume.ResumeEducationss;
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
        public async Task<ResumeEducationssDto> SaveResumeEducationsAsync(SaveResumeEducationsInput input)
        {
            var Result = new ResumeEducationssDto();

            //常用

            //系統層級
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //強制帶入Id

            //外部傳入
            var RefreshItem = input.RefreshItem;
            var ResumeEducationsId = input.Id;

            //預設值
            input.Sort = input.Sort != null ? input.Sort : ShareDefine.Sort;
            input.DateA = input.DateA != null ? input.DateA : ShareDefine.DateA;
            input.DateD = input.DateD != null ? input.DateD : ShareDefine.DateD;
            input.Status = input.Status.IsNullOrEmpty() ?  "1" : input.Status;
            input.ExtendedInformation = input.ExtendedInformation.IsNullOrEmpty() ? "" : input.ExtendedInformation;

            //檢查
            //await SaveResumeEducationsAsync(input);

            //主體資料
            var ResumeEducation = await _appService._resumeEducationsRepository.GetQueryableAsync();
            var itemResumeEducation = ResumeEducation.FirstOrDefault(p => p.Id == ResumeEducationsId);

            //如果沒有ID就新增資料
            if (itemResumeEducation == null)
            {
                itemResumeEducation = ObjectMapper.Map<SaveResumeEducationsInput, ResumeEducations>(input);
                itemResumeEducation = await _appService._resumeEducationsRepository.InsertAsync(itemResumeEducation);
            }
            else
            {
                //不要變更的值
                //input.Sort = itemResumeEducation.Sort;
                //input.DateD = itemResumeEducation.DateD;
                //input.DateA = itemResumeEducation.DateA;

                ObjectMapper.Map(input, itemResumeEducation);
                await _appService._resumeEducationsRepository.UpdateAsync(itemResumeEducation);
            }

            ObjectMapper.Map(itemResumeEducation, Result);

            return Result;
        }

        public virtual async Task<ResultDto> SaveResumeEducationsCheckAsync(SaveResumeEducationsInput input)
        {

            var Result = new ResultDto();

            var ResumeMainId = input.ResumeMainId;
            var SchoolName = input.SchoolName;
            var MajorDepartmentName = input.MajorDepartmentName;
            var EducationLevelCode = input.EducationLevelCode;
            var MajorDepartmentCategoryCode = input.MajorDepartmentCategoryCode;
            var MinorDepartmentCategoryCode = input.MinorDepartmentCategoryCode;
            var GraduationCode = input.GraduationCode;
            var CountryCode = input.CountryCode;

            if(SchoolName.IsNullOrEmpty())
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "學校名稱不能空白" });

            if (MajorDepartmentCategoryCode.IsNullOrEmpty())
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "科系名稱不能空白" });

            if (EducationLevelCode.IsNullOrEmpty())
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "教育程度不能空白" });

            if (GraduationCode.IsNullOrEmpty())
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "就學狀態不能空白" });

            var inputShareCodeGroup = new ShareCodeGroupInput();
            inputShareCodeGroup.ListGroupCode.Add("EducationLevel");
            inputShareCodeGroup.ListGroupCode.Add("MajorDepartmentCategory");
            inputShareCodeGroup.ListGroupCode.Add("MinorDepartmentCategory");
            inputShareCodeGroup.ListGroupCode.Add("Graduation");
            inputShareCodeGroup.ListGroupCode.Add("Country");

            var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);

            if (!itemsShareCode.Any(p => p.GroupCode == "EducationLevel" && p.Code == EducationLevelCode))
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "教育程度代碼錯誤" });

            if (!itemsShareCode.Any(p => p.GroupCode == "MajorDepartmentCategory" && p.Code == MajorDepartmentCategoryCode))
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "科系類別代碼錯誤" });

            if (!itemsShareCode.Any(p => p.GroupCode == "MinorDepartmentCategory" && p.Code == MinorDepartmentCategoryCode))
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "雙主修類別代碼錯誤" });

            if (!itemsShareCode.Any(p => p.GroupCode == "Graduation" && p.Code == GraduationCode))
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "畢業類別代碼錯誤" });

            if (!itemsShareCode.Any(p => p.GroupCode == "Country" && p.Code == CountryCode))
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "國家代碼錯誤" });

            var qrbResumeMain = await _appService._resumeMainRepository.GetQueryableAsync();
            var itemResumeMain = qrbResumeMain.FirstOrDefault(p => p.Id == ResumeMainId);

            if (itemResumeMain == null)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "資料不存在" });

            var ex = new UserFriendlyException("系統發生錯誤");
            foreach (var msg in Result.Messages)
                ex.Data.Add(GuidGenerator.Create().ToString(), msg.MessageContents);

            Result.Check = !Result.Messages.Any(p => !p.Pass);

            if (!Result.Check)
                throw ex;

            return Result;
        }




        public virtual async Task<ResumeEducationssDto> DeleteResumeEducationsAsync(ResumeEducationsInput input)
        {
            var Result = new ResumeEducationssDto();
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
            var qrbResumeEducations = await _appService._resumeEducationsRepository.GetQueryableAsync();
            var itemResumeEducations = qrbResumeEducations.FirstOrDefault(p => p.Id == Id);
            if (ex.Data.Count == 0)
            {
                if (itemResumeEducations == null)
                    ex.Data.Add(GuidGenerator.Create().ToString(), "沒有此筆資料");
                else
                {
                    await _appService._resumeEducationsRepository.DeleteAsync(itemResumeEducations);
                    ObjectMapper.Map(itemResumeEducations, Result);
                }
            }

            if (ex.Data.Count > 0)
                throw ex;
            return Result;
        }
    }
}
