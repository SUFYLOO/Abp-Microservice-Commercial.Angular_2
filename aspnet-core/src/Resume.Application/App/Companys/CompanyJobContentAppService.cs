using Microsoft.Extensions.DependencyInjection;
using Org.BouncyCastle.Asn1.Mozilla;
using PayPalCheckoutSdk.Orders;
using Resume.App.Shares;
using Resume.App.Users;
using Resume.CompanyJobApplicationMethods;
using Resume.CompanyJobConditions;
using Resume.CompanyJobContents;
using Resume.CompanyJobDisabilityCategories;
using Resume.CompanyJobs;
using Resume.CompanyJobWorkHourss;
using Resume.CompanyMains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.MultiTenancy;
using Volo.Abp.ObjectMapping;

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
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>()?.UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>()?.SystemUserRoleKeys;

            //強制把input帶入系統值
            input.Status = "1";
            input.ExtendedInformation = "";
            input.CompanyMainId = CompanyMainId;

            //var jsonSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            //input.DisabilityCategory = JsonSerializer.Serialize(input.ListDisabilityCategory, new JsonSerializerOptions
            //{
            //    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping, // 中文字不編碼
            //    WriteIndented = true  // 換行與縮排
            //});

            //外部傳入
            var CompanyJobContentId = input.Id;
            var CompanyJobId = input.CompanyJobId;
            var RefreshItem = input.RefreshItem;
            var WorkHoursCodes = input.WorkHours;
            var ListWorkHoursCode = input.ListWorkHoursCode;

            //預設值
            input.Sort = input.Sort != null ? input.Sort : ShareDefine.Sort;
            input.DateA = input.DateA != null ? input.DateA : ShareDefine.DateA;
            input.DateD = input.DateD != null ? input.DateD : ShareDefine.DateD;
            input.Status = input.Status.IsNullOrEmpty() ? "1" : input.Status;
            input.ExtendedInformation = input.ExtendedInformation.IsNullOrEmpty() ? "" : input.ExtendedInformation;


            //呼叫CompanyJob
            var itemCompanyJob = ObjectMapper.Map<SaveCompanyJobContentInput, SaveCompanyJobInput>(input);
            itemCompanyJob.Id = CompanyJobId;
            var itemCompanyJobDto = await SaveCompanyJobAsync(itemCompanyJob);
            CompanyJobId = itemCompanyJobDto.Id;

            //呼叫CompanyJobworkhours
            var ListSaveCompanyJobWorkHoursInput = new List<SaveCompanyJobWorkHoursInput>();
            foreach (var WorkHoursCode in ListWorkHoursCode)
            {
              var itemSaveCompanyJobWorkHoursInput =   ObjectMapper.Map<SaveCompanyJobContentInput, SaveCompanyJobWorkHoursInput>(input);
                itemSaveCompanyJobWorkHoursInput.CompanyJobId = CompanyJobId;
                itemSaveCompanyJobWorkHoursInput.WorkHoursCode = WorkHoursCode;
                ListSaveCompanyJobWorkHoursInput.Add(itemSaveCompanyJobWorkHoursInput);
            }

            var inputSaveCompanyJobWorkHoursList = new SaveCompanyJobWorkHoursListInput();
            var ListCompanyJobWorkHours = CompanyJobId;
            await SaveJobWorkHoursListAsync(inputSaveCompanyJobWorkHoursList);

            //檢查
            //await SaveCompanyJobContentCheckAsync(input);

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
            var ex = new UserFriendlyException("系統發生錯誤");

            //常用

            //系統層級
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>()?.CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>()?.UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>()?.SystemUserRoleKeys;

            //外部傳入
            var JobTypeCode = input.JobTypeCode ?? "";
            var SalaryPayTypeCode = input.SalaryPayTypeCode ?? "";
            var WorkHoursCode = input.WorkHours ?? "";
            var WorkRemoteTypeCode = input.WorkRemoteTypeCode;
            var HolidaySystemCode = input.HolidaySystemCode;
            var WorkDayCode = input.WorkDayCode;
            var WorkIdentity = input.WorkIdentity;
            var ListDisabilityCategory = input.ListDisabilityCategory;
            var ListCompanyJobWorkIdentityCode = input.ListCompanyJobWorkIdentityCode;
            var ListWorkHoursCode = input.ListWorkHoursCode;


            //預設值

            //必要代碼檢核

            //var conditions = new List<GroupCodeConditions>()
            //{
            //    new GroupCodeConditions(){GroupCode = "JobType",Code =JobTypeCode, ErrorMessage = "職務類別代碼錯誤" ,AllowNull = true},
            //    new GroupCodeConditions(){GroupCode = "SalaryPayType",Code = SalaryPayTypeCode , ErrorMessage = "薪資發放分類代碼錯誤" ,AllowNull = false},
            //    new GroupCodeConditions(){GroupCode = "WorkRemoteType",Code = WorkRemoteTypeCode , ErrorMessage = "遠端工作代碼錯誤" , AllowNull = true},
            //    new GroupCodeConditions(){GroupCode = "HolidaySystem",Code = HolidaySystemCode , ErrorMessage = "休假制度代碼錯誤" ,AllowNull = false },
            //    new GroupCodeConditions(){GroupCode = "WorkDay",Code = WorkDayCode  , ErrorMessage = "可上班日代碼錯誤", AllowNull = false},
            //    new GroupCodeConditions(){GroupCode = "WorkIdentity",Code = WorkIdentity , ErrorMessage = "身分類別代碼錯誤", AllowNull = true},
            //};

            //foreach (var itemListDisabilityCategory in ListDisabilityCategory)
            //{
            //    new GroupCodeConditions() { GroupCode = "DisabilityCategory", Code = itemListDisabilityCategory.DisabilityCategoryCode, ErrorMessage = "殘障類別代碼錯誤", AllowNull = true };
            //    new GroupCodeConditions() { GroupCode = "DisabilityLevel", Code = itemListDisabilityCategory.DisabilityLevelCode, ErrorMessage = "殘障等級代碼錯誤", AllowNull = true };
            //}

            //Result =  await _appService._serviceProvider.GetService<SharesAppService>().CheckGroupCode(Result, conditions);

            var inputCheckShareCode = new CheckShareCodeInput();
            inputCheckShareCode.Result = Result;
            inputCheckShareCode.Data =new List<SaveCompanyJobContentInput>() { input };
            _appService._serviceProvider.GetService<SharesAppService>().CheckShareCodeAsync<SaveCompanyJobContentInput>(inputCheckShareCode);

            inputCheckShareCode = new CheckShareCodeInput();
            inputCheckShareCode.Result = Result;
            inputCheckShareCode.Data = ListWorkHoursCode;
            _appService._serviceProvider.GetService<SharesAppService>().CheckShareCodeAsync<SaveCompanyJobWorkHoursInput>(inputCheckShareCode);

            inputCheckShareCode = new CheckShareCodeInput();
            inputCheckShareCode.Result = Result;
            inputCheckShareCode.Data = ListCompanyJobWorkIdentityCode;
            _appService._serviceProvider.GetService<SharesAppService>().CheckShareCodeAsync<SaveCompanyJobWorkIdentityInput>(inputCheckShareCode);

            inputCheckShareCode = new CheckShareCodeInput();
            inputCheckShareCode.Result = Result;
            inputCheckShareCode.Data = ListDisabilityCategory;
            _appService._serviceProvider.GetService<SharesAppService>().CheckShareCodeAsync<SaveDisabilityCategoryInput>(inputCheckShareCode);

            foreach (var msg in Result.Messages)
                ex.Data.Add(GuidGenerator.Create().ToString(), msg.MessageContents);

            Result.Check = !Result.Messages.Any(p => !p.Pass);
            if (!Result.Check)
                throw ex;

            return Result;
        }

        public virtual async Task<CompanyJobContentsDto> GetCompanyJobContentAsync(CompanyJobContentInput input)
        {
            //結果
            var Result = new CompanyJobContentsDto();
            var ex = new UserFriendlyException("錯誤訊息");

            //系統層級

            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //外部傳入
            var CompanyJobContentId = input.Id;

            //預設值

            //檢查
            if (CompanyJobContentId.ToString() == " ")
            {
                ex.Data.Add(GuidGenerator.Create().ToString(), "ID不能為空白");
                throw ex;
            }

            //主體取資料
            if (ex.Data.Count == 0)
            {
                var qrbCompanyJobContent = await _appService._companyJobContentRepository.GetQueryableAsync();
                var itemCompanyJobContent = qrbCompanyJobContent.FirstOrDefault(p => p.Id == CompanyJobContentId);

                if (itemCompanyJobContent != null)
                {
                    var inputShareCodeGroup = new ShareCodeGroupInput();
                    inputShareCodeGroup.ListGroupCode.Add("JobType");
                    inputShareCodeGroup.ListGroupCode.Add("SalaryPayType");
                    inputShareCodeGroup.ListGroupCode.Add("WorkRemoteType");
                    inputShareCodeGroup.ListGroupCode.Add("HolidaySystem");
                    inputShareCodeGroup.ListGroupCode.Add("WorkDay");
                    inputShareCodeGroup.ListGroupCode.Add("WorkIdentityCode");
                    inputShareCodeGroup.ListGroupCode.Add("DisabilityLevel");
                    inputShareCodeGroup.ListGroupCode.Add("DisabilityCategory");

                    inputShareCodeGroup.AllForGroupCode = true;
                    var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);

                    ObjectMapper.Map(itemCompanyJobContent, Result);

                    var inputSetShareCode = new SetShareCodeInput();
                    inputSetShareCode.ListShareCode = itemsShareCode;
                    inputSetShareCode.Data = new List<CompanyJobContentsDto>() { Result };
                    var ListDisabilityCategory = new List<CompanyJobDisabilityCategoryDto>();

                    var ListColumns = new List<NameCodeStandardDto>
                    {
                        new NameCodeStandardDto { GroupCode = "JobType", Code = "JobTypeCode", Name = "JobTypeName" },
                        new NameCodeStandardDto { GroupCode = "SalaryPayType", Code = "SalaryPayTypeCode", Name = "SalaryPayTypeName" },
                        new NameCodeStandardDto { GroupCode = "WorkRemoteType", Code = "WorkRemoteTypeCode", Name = "WorkRemoteTypeName" },
                        new NameCodeStandardDto { GroupCode = "HolidaySystem", Code = "HolidaySystemCode", Name = "HolidaySystemName" },
                        new NameCodeStandardDto { GroupCode = "WorkDay", Code = "WorkDayCode", Name = "WorkDayName" },
                        new NameCodeStandardDto { GroupCode = "WorkIdentityCode", Code = "WorkIdentityCode", Name = "WorkIdentityCodeName" },
                        new NameCodeStandardDto { GroupCode = "DisabilityCategory", Code = "DisabilityCategoryCode", Name = "DisabilityCategoryName"},
                        new NameCodeStandardDto { GroupCode = "DisabilityLevel", Code = "DisabilityLevelCode", Name = "DisabilityLevelName" }
                    };

                    inputSetShareCode.ListColumns = ListColumns;
                    _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<CompanyJobContentsDto>(inputSetShareCode);
                }
            }
            else
            {
                ex.Data.Add(GuidGenerator.Create().ToString(), "沒有此筆資料");
            }

            //回傳錯誤
            if (ex.Data.Count > 0)
                throw ex;

            return Result;
        }

         public virtual async Task<List<CompanyJobContentsDto>> GetCompanyJobContentListAsync(CompanyJobContentInput input)
        {   //結果
            var Result = new List<CompanyJobContentsDto>();
            var ex = new UserFriendlyException("錯誤訊息");

            //常用

            //系統層級
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //輸入值

            //預設值

            //檢查

            //主體資料
            var qrbCompanyJobContent = await _appService._companyJobContentRepository.GetQueryableAsync();
            qrbCompanyJobContent = from c in qrbCompanyJobContent
                                       //where c.JobOpen == JobOpen
                                       //&& c.Name.IndexOf(KeyWords) >= 0
                                   select c;

            if (ex.Data.Count == 0)
            {
                var itemsCompanyJobContent = await AsyncExecuter.ToListAsync(qrbCompanyJobContent);
                ObjectMapper.Map(itemsCompanyJobContent, Result);
            }

            if (ex.Data.Count > 0)
                throw ex;
            return Result;
        }

        public virtual async Task<CompanyJobContentsDto> DeleteCompanyJobContentAsync(CompanyJobContentInput input)
        {

            var Result = new CompanyJobContentsDto();
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
            var qrbCompanyJobContent = await _appService._companyJobContentRepository.GetQueryableAsync();
            var qrbsCompanyJobContent = from c in qrbCompanyJobContent
                                            //where c.DateA <= ShareDefine.DateTimeNow && ShareDefine.DateTimeNow <= c.DateD
                                            //&& c.Status == "1"                      
                                        select c;

            if (ex.Data.Count == 0)
            {
                var qrbCompanyUser = await _appService._companyUserRepository.GetQueryableAsync();
                var qrbsCompanyUser = qrbCompanyUser.Where(p => p.UserMainId == UserMainId);
                var ListCompanyMainId = qrbsCompanyUser.Select(p => p.CompanyMainId);

                var itemCompanyJobContent = qrbsCompanyJobContent.FirstOrDefault(p => p.Id == Id);
                if (itemCompanyJobContent == null)
                    ex.Data.Add(GuidGenerator.Create().ToString(), "沒有這筆資料");
                else
                {
                    await _appService._companyJobContentRepository.DeleteAsync(itemCompanyJobContent);
                    ObjectMapper.Map(itemCompanyJobContent, Result);
                }
            }

            if (ex.Data.Count > 0)
                throw ex;
            return Result;
        }

    }
}



