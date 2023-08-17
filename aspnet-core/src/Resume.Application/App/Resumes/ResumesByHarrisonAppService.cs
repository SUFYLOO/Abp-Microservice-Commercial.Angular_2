using Microsoft.Extensions.DependencyInjection;
using Resume.App.Companys;
using Resume.App.Shares;
using Resume.App.Users;
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

namespace Resume.App.Resumes
{
    public partial class ResumesAppService : ApplicationService, IResumesAppService
    {
        public async Task<ResumeEducationssDto> SaveResumeEducationsAsync (SaveResumeEducationsInput input)
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

            //不要變更的值
            input.Sort = input.Sort != null ? input.Sort : ShareDefine.Sort;
            input.DateA = input.DateA != null ? input.DateA : ShareDefine.DateA;
            input.DateD = input.DateD != null ? input .DateD : ShareDefine.DateD;

            //檢查
            // await SaveResumeEducationsAsync(input);

            //主體資料
            var ResumeEducation = await _appService._resumeEducationsRepository.GetQueryableAsync();
            var itemResumeEducation = ResumeEducation.FirstOrDefault(p => p.Id == ResumeEducationsId);

            //如果沒有ID就新增資料
            if (itemResumeEducation != null)
            {
                itemResumeEducation = ObjectMapper.Map<SaveResumeEducationsInput, ResumeEducations>(input);
                itemResumeEducation = await _appService._resumeEducationsRepository.InsertAsync(itemResumeEducation);
            }
            else
            {
                //不要變更的值
                input.Sort = itemResumeEducation.Sort;
                input.DateD = itemResumeEducation.DateD;
                input.DateA = itemResumeEducation.DateA;

                ObjectMapper.Map(input, itemResumeEducation);
                await _appService._resumeEducationsRepository.UpdateAsync(itemResumeEducation);
            }

            ObjectMapper.Map(itemResumeEducation, input);

            return Result;
        }

        public virtual async Task<ResultDto> SaveResumeEducationsCheckAsync(SaveResumeEducationsInput input)
        {

            var Result = new ResultDto();

            var ResumeMainId = input.ResumeMainId;

            var inputShareCodeGroup = new ShareCodeGroupInput();
            inputShareCodeGroup.ListGroupCode.Add("EducationLevelCode");
            inputShareCodeGroup.ListGroupCode.Add("MajorDepartmentCategoryCode");
            inputShareCodeGroup.ListGroupCode.Add("MinorDepartmentCategoryCode");
            inputShareCodeGroup.ListGroupCode.Add("GraduationCode");
            inputShareCodeGroup.ListGroupCode.Add("CountryCode");

            var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);

            //if (!itemsShareCode.Any(p => p.GroupCode == "JobPayTypeCode" && p.Code == MarriageCode))
            //    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "付費類別代碼錯誤" });

            //if (!itemsShareCode.Any(p => p.GroupCode == "DisabilityCategoryCode" && p.Code == DisabilityCategoryCode))
            //    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "付費類別代碼錯誤" });

            //if (!itemsShareCode.Any(p => p.GroupCode == "SpecialIdentityCode" && p.Code == SpecialIdentityCode))
            //    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "付費類別代碼錯誤" });

            var qrbResumeMain = await _appService._resumeMainRepository.GetQueryableAsync();
            var itemResumeMain = qrbResumeMain.FirstOrDefault(p => p.Id == ResumeMainId);
            if (itemResumeMain == null)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "資料不存在" });
            var ex = new UserFriendlyException("系統發生錯誤");
            foreach (var msg in Result.Messages)
                ex.Data.Add(GuidGenerator.Create().ToString(), msg.MessageContents);

            Result.Check = !Result.Messages.Any(p => !p.Pass);

            return Result;
        }

    }
}
