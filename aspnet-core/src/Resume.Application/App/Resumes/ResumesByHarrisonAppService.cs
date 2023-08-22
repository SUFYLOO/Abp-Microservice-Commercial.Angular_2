using Microsoft.Extensions.DependencyInjection;
using Resume.App.Companys;
using Resume.App.Shares;
using Resume.App.Users;
using Resume.CompanyJobs;
using Resume.CompanyMains;
using Resume.ResumeEducationss;
using Resume.ResumeExperiencess;
using Resume.ResumeMains;
using Resume.ResumeSkills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public delegate void Test();
    public partial class ResumesAppService : ApplicationService, IResumesAppService
    {
        public virtual async Task<ResumeSkillsDto> SaveResumeSkillAsync(SaveResumeSkillInput input)
        {
            var Result = new ResumeSkillsDto();
            //常用

            //系統層級
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //強制帶入Id

            //外部傳入
            var RefreshItem = input.RefreshItem;
            var ResumeSkillId = input.Id;

            //預設值
            input.Sort = input.Sort != null ? input.Sort : ShareDefine.Sort;
            input.DateA = input.DateA != null ? input.DateA : ShareDefine.DateA;
            input.DateD = input.DateD != null ? input.DateD : ShareDefine.DateD;
            input.Status = input.Status.IsNullOrEmpty() ? "1" : input.Status;
            input.ExtendedInformation = input.ExtendedInformation.IsNullOrEmpty() ? "" : input.ExtendedInformation;
            input.ChineseTypingSpeed = input.ChineseTypingSpeed != null ? input.ChineseTypingSpeed : 0;
            input.ChineseTypingCode = input.ChineseTypingCode != null ? input.ChineseTypingCode : "07";
            input.EnglishTypingSpeed = input.EnglishTypingSpeed != null ? input.EnglishTypingSpeed : 0;

            //檢查
            //await SaveResumeSkillAsync(input);

            //主體資料
            var qrbResumeSkill = await _appService._resumeSkillRepository.GetQueryableAsync();
            var itemResumeSkill = qrbResumeSkill.FirstOrDefault(p => p.Id == ResumeSkillId);

            //如果沒有ID就新增資料
            if (itemResumeSkill == null)
            {
                itemResumeSkill = ObjectMapper.Map<SaveResumeSkillInput, ResumeSkill>(input);
                itemResumeSkill = await _appService._resumeSkillRepository.InsertAsync(itemResumeSkill);
            }
            else
            {
                //不要變更的值
                //input.Sort = itemResumeSkill.Sort;
                //input.DateD = itemResumeSkill.DateD;
                //input.DateA = itemResumeSkill.DateA;

                ObjectMapper.Map(input, itemResumeSkill);
                await _appService._resumeSkillRepository.UpdateAsync(itemResumeSkill);
            }

            ObjectMapper.Map(itemResumeSkill, Result);

            return Result;
        }

        public virtual async Task<ResultDto> SaveResumeSkillCheckAsync(SaveResumeSkillInput input)
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
            var ComputerSkills = input.ComputerSkills ?? "";
            var ProfessionalLicense = input.ProfessionalLicense;
            var WorkSkills = input.WorkSkills;

            //必要代碼檢核
            var conditions = new List<GroupCodeConditions>()
            {
                new GroupCodeConditions(){GroupCode = "ComputerExpertise",Code =ComputerSkills, ErrorMessage = "電腦技能代碼錯誤" ,AllowNull = true},
                new GroupCodeConditions(){GroupCode = "WorkSkills",Code = WorkSkills , ErrorMessage = "工作技能代碼錯誤" ,AllowNull = false},               
                new GroupCodeConditions(){GroupCode = "ProfessionalLicense",Code = ProfessionalLicense  , ErrorMessage = "專業證照代碼錯誤", AllowNull = true},
            };

            Result = await _appService._serviceProvider.GetService<SharesAppService>().CheckGroupCode(Result, conditions);

            foreach (var msg in Result.Messages)
                ex.Data.Add(GuidGenerator.Create().ToString(), msg.MessageContents);

            Result.Check = !Result.Messages.Any(p => !p.Pass);
            if (!Result.Check)
                throw ex;

            return Result;


        }
    }
}
