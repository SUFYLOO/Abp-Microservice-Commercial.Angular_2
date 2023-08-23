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
            input.Status = "1";
            input.ExtendedInformation = "";

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
            //結果
            var Result = new ResultDto();
            var ex = new UserFriendlyException("錯誤訊息");

            //常用

            //系統層級
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>()?.CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>()?.UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>()?.SystemUserRoleKeys;

            //外部傳入
            var CompanyJobId = input.CompanyJobId;
            var EducationLevelCode = input.EducationLevel ?? "";
            var WorkExperienceYearCode = input.WorkExperienceYearCode;
            var MajorDepartmentCategory = input.MajorDepartmentCategory;
            var LanguageCategory = input.LanguageCategory;
            var ComputerExpertise = input.ComputerExpertise;
            var ProfessionalLicense = input.ProfessionalLicense;
            var DrvingLicense = input.DrvingLicense;

            //必要代碼檢核
            var conditions = new List<GroupCodeConditions>()
            {
                new GroupCodeConditions(){GroupCode = "EducationLevel",Code =EducationLevelCode, ErrorMessage = "教育類別代碼錯誤" ,AllowNull = true},
                new GroupCodeConditions(){GroupCode = "WorkExperienceYear",Code = WorkExperienceYearCode , ErrorMessage = "工作經驗代碼錯誤" ,AllowNull = false},
              //new GroupCodeConditions(){GroupCode = "MajorDepartmentCategory",Code = MajorDepartmentCategory , ErrorMessage = "科系需求代碼錯誤" , AllowNull = true},
                new GroupCodeConditions(){GroupCode = "LanguageCategory",Code = LanguageCategory , ErrorMessage = "語文條件代碼錯誤" ,AllowNull = true },
                new GroupCodeConditions(){GroupCode = "ComputerExpertise",Code = ComputerExpertise  , ErrorMessage = "電腦專長代碼錯誤", AllowNull = true},
                new GroupCodeConditions(){GroupCode = "ProfessionalLicense",Code = ProfessionalLicense , ErrorMessage = "專業證照代碼錯誤", AllowNull = true},
                new GroupCodeConditions(){GroupCode = "DrvingLicense",Code = DrvingLicense , ErrorMessage = "駕照類別代碼錯誤", AllowNull = true}
            };

            Result = await _appService._serviceProvider.GetService<SharesAppService>().CheckGroupCode(Result, conditions);

            //var qrbCompanyJob = await _appService._companyJobRepository.GetQueryableAsync();
            //var itemCompanyJob = qrbCompanyJob.FirstOrDefault(p => p.Id == CompanyJobId);

            //if (itemCompanyJob == null)
            //    ex.Data.Add(GuidGenerator.Create().ToString(), "沒有這筆資料");

            foreach (var msg in Result.Messages)
                ex.Data.Add(GuidGenerator.Create().ToString(), msg.MessageContents);

            Result.Check = !Result.Messages.Any(p => !p.Pass);
            if (!Result.Check)
                throw ex;

            return Result;
        }

        public virtual async Task<List<CompanyJobConditionsDto>> GetCompanyJobConditionsListAsync(SaveCompanyJobConditionInput input)
        {   //結果
            var Result = new List<CompanyJobConditionsDto>();
            var ex = new UserFriendlyException("錯誤訊息");

            //常用

            //系統層級
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //輸入值

            //檢查

            //主體資料
            var qrbCompanyJobCondition = await _appService._companyJobConditionRepository.GetQueryableAsync();
            qrbCompanyJobCondition = from c in qrbCompanyJobCondition
                                         //where c.JobOpen == JobOpen
                                         //&& c.Name.IndexOf(KeyWords) >= 0
                                     select c;

            if (ex.Data.Count == 0)
            {
                var itemsCompanyJobCondition = await AsyncExecuter.ToListAsync(qrbCompanyJobCondition);
                ObjectMapper.Map<List<CompanyJobCondition>, List<CompanyJobConditionsDto>>(itemsCompanyJobCondition, Result);
            }

            if (ex.Data.Count > 0)
                throw ex;
            return Result;
        }

        public virtual async Task<CompanyJobConditionsDto> DeleteCompanyJobConditionAsync(CompanyJobConditionInput input)
        {

            var Result = new CompanyJobConditionsDto();
            var ex = new UserFriendlyException("錯誤訊息");

            //常用

            //系統層級
            var TenantId = CurrentTenant.Id;
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //強制把input帶入系統值


            //外部傳入
            var Id = input.Id;


            //預設值


            //檢查
            if (SystemUserRoleKeys > 5)
                ex.Data.Add(GuidGenerator.Create().ToString(), "您沒有權限");

            //主體資料
            var qrbCompanyJobCondition = await _appService._companyJobConditionRepository.GetQueryableAsync();
            var qrbsCompanyJobCondition = from c in qrbCompanyJobCondition
                                                      //where c.DateA <= ShareDefine.DateTimeNow && ShareDefine.DateTimeNow <= c.DateD
                                                      //&& c.Status == "1"                      
                                                  select c;

            if (ex.Data.Count == 0)
            {
                var qrbCompanyUser = await _appService._companyUserRepository.GetQueryableAsync();
                var qrbsCompanyUser = qrbCompanyUser.Where(p => p.UserMainId == UserMainId);
                var ListCompanyMainId = qrbsCompanyUser.Select(p => p.CompanyMainId);

                var itemCompanyJobCondition = qrbsCompanyJobCondition.FirstOrDefault(p => p.Id == Id);
                if (itemCompanyJobCondition == null)
                    ex.Data.Add(GuidGenerator.Create().ToString(), "沒有這筆資料");
                else
                {
                    await _appService._companyJobConditionRepository.DeleteAsync(itemCompanyJobCondition);
                    ObjectMapper.Map(itemCompanyJobCondition, Result);
                }
            }

            if (ex.Data.Count > 0)
                throw ex;
            return Result;
        }
    }
}



