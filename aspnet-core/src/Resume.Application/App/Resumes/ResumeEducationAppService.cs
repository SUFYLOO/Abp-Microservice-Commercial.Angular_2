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
        public virtual async Task<List<ResumeEducationssDto>> GetResumeEducationsListAsync(ResumeEducationsInput input)
        {
            //結果
            var Result = new List<ResumeEducationssDto>();
            var ex = new UserFriendlyException("錯誤訊息");
            //常用

            var ResumeMainId = input.Id;

            //系統層級
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //主體資料
            var qrbResumeEducations = await _appService._resumeEducationsRepository.GetQueryableAsync();
            var qrbsResumeEducations = from c in qrbResumeEducations
                                            //where c.UserMainId == ResumeMainId
                                            //(c.Id == ResumeMainId)
                                        where c.DateA <= DateTime.Now
                                         && c.Status == "1"
                                        select c;
            var itemsResumMain = await AsyncExecuter.ToListAsync(qrbsResumeEducations);
            //var itemsResumMain = await AsyncExecuter.ToListAsync(qrbsResumeEducations);

            if (ex.Data.Count == 0)
            {
                //取得履歷所需要的代碼資料-為了加速
                var inputShareCodeGroup = new ShareCodeGroupInput();
                inputShareCodeGroup.ListGroupCode.Add("EducationLevel");
                inputShareCodeGroup.ListGroupCode.Add("School");
                inputShareCodeGroup.ListGroupCode.Add("DepartmentCategory");
                inputShareCodeGroup.ListGroupCode.Add("Graduation");
                inputShareCodeGroup.ListGroupCode.Add("Country");

                inputShareCodeGroup.AllForGroupCode = true;
                var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);
                {

                    ObjectMapper.Map(itemsResumMain, Result);

                    var inputSetShareCode = new SetShareCodeInput();
                    inputSetShareCode.ListShareCode = itemsShareCode;
                    inputSetShareCode.Data = Result;
                    var ListColumns = new List<NameCodeStandardDto>
                {
                        new NameCodeStandardDto { GroupCode = "EducationLevel", Code = "EducationLevelCode", Name = "EducationLevelName" },
                        new NameCodeStandardDto { GroupCode = "School", Code = "SchoolCode", Name = "SchoolName" },
                        new NameCodeStandardDto { GroupCode = "DepartmentCategory", Code = "MajorDepartmentCategoryCode", Name = "DepartmentCategoryName" },
                        new NameCodeStandardDto { GroupCode = "DepartmentCategory", Code = "MinorDepartmentCategoryCode", Name = "DepartmentCategoryName2" },
                        new NameCodeStandardDto { GroupCode = "Graduation", Code = "GraduationCode", Name = "GraduationName" },
                        new NameCodeStandardDto { GroupCode = "Country", Code = "CountryCode", Name = "CountryName" }
                };

                    inputSetShareCode.ListColumns = ListColumns;
                    _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<ResumeEducationssDto>(inputSetShareCode);
                }
            }

            if (ex.Data.Count > 0)
                throw ex;
            return Result;
        }

        public async Task<ResumeEducationssDto> GetResumeEducationssAsync(ResumeEducationsInput input)
        {
            var Result = new ResumeEducationssDto();
            var ex = new UserFriendlyException("錯誤訊息");

            //系統層級

            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //外部傳入
            var ResumeEducationsId = input.Id;

            //主體取資料
            if (ex.Data.Count == 0)
            {
                var qrbResumeEducations = await _appService._resumeEducationsRepository.GetQueryableAsync();
                var itemResumeEducations = qrbResumeEducations.FirstOrDefault(p => p.Id == ResumeEducationsId);

                if (itemResumeEducations != null)
                {
                    var inputShareCodeGroup = new ShareCodeGroupInput();
                    inputShareCodeGroup.ListGroupCode.Add("EducationLevel");
                    inputShareCodeGroup.ListGroupCode.Add("School");
                    inputShareCodeGroup.ListGroupCode.Add("DepartmentCategory");
                    inputShareCodeGroup.ListGroupCode.Add("Graduation");
                    inputShareCodeGroup.ListGroupCode.Add("Country");
                    inputShareCodeGroup.AllForGroupCode = true;

                    var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);
                    {
                        ObjectMapper.Map(itemResumeEducations, Result);

                        var inputSetShareCode = new SetShareCodeInput();
                        inputSetShareCode.ListShareCode = itemsShareCode;
                        inputSetShareCode.Data = new List<ResumeEducationssDto>();
                        var ListColumns = new List<NameCodeStandardDto>()
                        {
                        new NameCodeStandardDto { GroupCode = "EducationLevel", Code = "EducationLevelCode", Name = "EducationLevelName" },
                        new NameCodeStandardDto { GroupCode = "School", Code = "SchoolCode", Name = "SchoolName" },
                        new NameCodeStandardDto { GroupCode = "DepartmentCategory", Code = "MajorDepartmentCategoryCode", Name = "DepartmentCategoryName" },
                        new NameCodeStandardDto { GroupCode = "DepartmentCategory", Code = "MinorDepartmentCategoryCode", Name = "DepartmentCategoryName2" },
                        new NameCodeStandardDto { GroupCode = "Graduation", Code = "GraduationCode", Name = "GraduationName" },
                        new NameCodeStandardDto { GroupCode = "Country", Code = "CountryCode", Name = "CountryName" }
                        };

                        inputSetShareCode.ListColumns = ListColumns;
                        _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<ResumeEducationssDto>(inputSetShareCode);

                        //var inputShareUploadList = new ShareUploadListInput();
                        //inputShareUploadList.Key1 = "ResumeEducations";
                        //inputShareUploadList.Key2 = "";
                        //inputShareUploadList.Key3 = itemResumeEducations.ResumeMainId.ToString();
                        //var itemsShareUploadList = await _appService._serviceProvider.GetService<SharesAppService>().GetShareUploadListAsync(inputShareUploadList);
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
            await SaveResumeEducationsCheckAsync(input);

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
            var DateA = input.DateA;
            var DateD = input.DateD;
            var EducationLevelCode = input.EducationLevelCode;
            var SchoolCode = input.SchoolCode;
            var MajorDepartmentCategory = input.MajorDepartmentCategory;
            var MinorDepartmentCategory = input.MinorDepartmentCategory;
            var GraduationCode = input.GraduationCode;
            var Country = input.CountryCode;

            //必要代碼檢核
            var conditions = new List<GroupCodeConditions>()
            {
                new GroupCodeConditions(){GroupCode = "EducationLevel",Code =EducationLevelCode, ErrorMessage = "教育類別代碼錯誤" ,AllowNull = false},
                new GroupCodeConditions(){GroupCode = "School",Code = SchoolCode , ErrorMessage = "學校類別代碼錯誤" ,AllowNull = false},
                new GroupCodeConditions(){GroupCode = "DepartmentCategory",Code = MajorDepartmentCategory , ErrorMessage = "主修代碼錯誤", AllowNull = true},
                new GroupCodeConditions(){GroupCode = "DepartmentCategory",Code = MinorDepartmentCategory , ErrorMessage = "雙主修代碼錯誤", AllowNull = true},
                new GroupCodeConditions(){GroupCode = "Graduation",Code = GraduationCode , ErrorMessage = "畢業代碼錯誤", AllowNull = false},
                new GroupCodeConditions(){GroupCode = "Country",Code = Country , ErrorMessage = "國家代碼錯誤", AllowNull = false},

            };

            Result = await _appService._serviceProvider.GetService<SharesAppService>().CheckGroupCode(Result, conditions);

            if (DateA > DateD)
                ex.Data.Add(GuidGenerator.Create().ToString(), "日期輸入錯誤");

            var qrbResumeMain = await _appService._resumeMainRepository.GetQueryableAsync();
            var itemResumeMain = qrbResumeMain.FirstOrDefault(p => p.Id == ResumeMainId);

            if (itemResumeMain == null)
                ex.Data.Add(GuidGenerator.Create().ToString(), "沒有這筆資料");

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
