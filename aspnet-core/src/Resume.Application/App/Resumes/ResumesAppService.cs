using Resume.App.Companys;
using Resume.App.Shares;
using Resume.App.Users;
using Resume.CompanyInvitationss;
using Resume.ResumeCommunications;
using Resume.ResumeDependentss;
using Resume.ResumeDrvingLicenses;
using Resume.ResumeEducationss;
using Resume.ResumeExperiencess;
using Resume.ResumeLanguages;
using Resume.ResumeMains;
using Resume.ResumeRecommenders;
using Resume.ResumeSkills;
using Resume.ResumeSnapshots;
using Resume.ResumeWorkss;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.MultiTenancy;

namespace Resume.App.Resumes
{
    [RemoteService(IsEnabled = false)]

    public partial class ResumesAppService : ApplicationService, IResumesAppService
    {
        private readonly AppService _appService;

        public ResumesAppService(AppService appService)
        {
            _appService = appService;
        }

        public virtual async Task<ResultDto<ResumeDto>> GetResumeAsync(ResumeInput input)
        {
            var Result = new ResultDto<ResumeDto>();
            Result.Data = new ResumeDto();
            Result.Version = "2023040701";

            var DateNow = DateTime.Now;

            var UserId = CurrentUser.Id.ToString();

            var ResumeMainId = input.ResumeMainId;
            var ResumeDisplay = input.ResumeDisplay;

            var inputUserMains = new UserMainsInput();
            var itemUserMain = await _appService._serviceProvider.GetService<UsersAppService>().GetUserMainsAsync(inputUserMains);

            if (itemUserMain == null && itemUserMain.Data != null)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "無法取得使用者基本資料" });
            else
            {
                Result.Data.UserMains = itemUserMain.Data;

                var UserMainId = itemUserMain.Data.Id;
                var qrbResumeMain = await _appService._resumeMainRepository.GetQueryableAsync();
                var qrResumeMain = from c in qrbResumeMain
                                   where c.UserMainId == UserMainId
                                   && (ResumeMainId == null || c.Id == ResumeMainId)
                                   //&& c.DateA <= DateNow && DateNow <= c.DateD
                                   && c.Status == "1"
                                   orderby c.Main descending, c.Sort
                                   select c;

                var itemsResumeMain = await AsyncExecuter.ToListAsync(qrResumeMain);
                if (itemsResumeMain.Count > 0)
                {
                    //取得履歷所需要的代碼資料-為了加速
                    var inputShareCodeGroup = new ShareCodeGroupInput();
                    inputShareCodeGroup.ListGroupCode.Add("Sex");
                    inputShareCodeGroup.ListGroupCode.Add("Blood");
                    inputShareCodeGroup.ListGroupCode.Add("Marriage");
                    inputShareCodeGroup.ListGroupCode.Add("PlaceOfBirth");
                    inputShareCodeGroup.ListGroupCode.Add("Military");
                    inputShareCodeGroup.ListGroupCode.Add("DisabilityCategory");
                    inputShareCodeGroup.ListGroupCode.Add("Nationality");
                    inputShareCodeGroup.ListGroupCode.Add("SpecialIdentity");

                    inputShareCodeGroup.ListGroupCode.Add("CommunicationCategory");
                    inputShareCodeGroup.ListGroupCode.Add("DrvingLicense");
                    inputShareCodeGroup.ListGroupCode.Add("LanguageCategory");
                    inputShareCodeGroup.ListGroupCode.Add("LanguageLevel");
                    inputShareCodeGroup.ListGroupCode.Add("ChineseTyping");
                    inputShareCodeGroup.ListGroupCode.Add("Kinship");
                    inputShareCodeGroup.ListGroupCode.Add("EducationLevel");
                    //inputShareCodeGroup.ListGroupCode.Add("DepartmentCategory");
                    inputShareCodeGroup.ListGroupCode.Add("Graduation");
                    inputShareCodeGroup.ListGroupCode.Add("Country");
                    inputShareCodeGroup.ListGroupCode.Add("WorkNature");
                    //inputShareCodeGroup.ListGroupCode.Add("IndustryCategory");
                    //inputShareCodeGroup.ListGroupCode.Add("WorkPlace");
                    inputShareCodeGroup.ListGroupCode.Add("SalaryPayType");
                    inputShareCodeGroup.ListGroupCode.Add("CurrencyType");
                    inputShareCodeGroup.ListGroupCode.Add("CompanyScale");
                    inputShareCodeGroup.ListGroupCode.Add("CompanyManagementNumber");
                    var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);

                    {
                        var Data = ObjectMapper.Map<List<ResumeMain>, List<ResumeMainsDto>>(itemsResumeMain);

                        var inputSetShareCode = new SetShareCodeInput();
                        inputSetShareCode.ListShareCode = itemsShareCode;
                        inputSetShareCode.Data = Data;
                        var ListColumns = new List<NameCodeStandardDto>();
                        ListColumns.Add(new NameCodeStandardDto { GroupCode = "Sex", Code = "SexCode", Name = "SexName" });
                        ListColumns.Add(new NameCodeStandardDto { GroupCode = "Blood", Code = "BloodCode", Name = "BloodName" });
                        ListColumns.Add(new NameCodeStandardDto { GroupCode = "Marriage", Code = "MarriageCode", Name = "MarriageName" });
                        ListColumns.Add(new NameCodeStandardDto { GroupCode = "PlaceOfBirth", Code = "PlaceOfBirthCode", Name = "PlaceOfBirthName" });
                        ListColumns.Add(new NameCodeStandardDto { GroupCode = "Military", Code = "MilitaryCode", Name = "MilitaryName" });
                        ListColumns.Add(new NameCodeStandardDto { GroupCode = "DisabilityCategory", Code = "DisabilityCategoryCode", Name = "DisabilityCategoryName" });
                        ListColumns.Add(new NameCodeStandardDto { GroupCode = "Nationality", Code = "NationalityCode", Name = "NationalityName" });
                        ListColumns.Add(new NameCodeStandardDto { GroupCode = "SpecialIdentity", Code = "SpecialIdentityCode", Name = "SpecialIdentityName" });
                        inputSetShareCode.ListColumns = ListColumns;
                        _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<ResumeMainsDto>(inputSetShareCode);

                        var inputShareUploadList = new ShareUploadListInput();
                        inputShareUploadList.Key1 = "ResumeMain";
                        inputShareUploadList.Key2 = "";
                        inputShareUploadList.Key3 = itemsResumeMain.FirstOrDefault().UserMainId.ToString();
                        var itemsShareUploadList = await _appService._serviceProvider.GetService<SharesAppService>().GetShareUploadListAsync(inputShareUploadList);

                        //有可能會變成 新的履歷主檔
                        var item = Data.First();
                        //item.ListShareUpload = itemsShareUploadList.Data;
                        Result.Data.ResumeMains = item;
                        ResumeMainId = item.Id;
                    }

                    {
                        var items = await _appService._resumeCommunicationRepository.GetListAsync(resumeMainId: ResumeMainId);
                        var Data = ObjectMapper.Map<List<ResumeCommunication>, List<ResumeCommunicationsDto>>(items);
                        Data = (from c in Data
                                where c.Status == "1"
                                orderby c.Main descending, c.Sort
                                select c).ToList();
                        Result.Data.ListResumeCommunications = Data;
                        var inputSetShareCode = new SetShareCodeInput();
                        inputSetShareCode.ListShareCode = itemsShareCode;
                        inputSetShareCode.Data = Data;
                        var ListColumns = new List<NameCodeStandardDto>();
                        ListColumns.Add(new NameCodeStandardDto { GroupCode = "CommunicationCategory", Code = "CommunicationCategoryCode", Name = "CommunicationCategoryName" });
                        inputSetShareCode.ListColumns = ListColumns;
                        _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<ResumeCommunicationsDto>(inputSetShareCode);

                        //進行分類
                        if (ResumeDisplay != ResumeDisplayMethod.None)
                        {
                            var rsShareCode = itemsShareCode.Where(p => p.GroupCode == "CommunicationCategory").ToList();
                            var itemsDataClassification = new List<ResumeCommunicationsClassificationDto>();
                            ResumeCommunicationsClassificationDto itemDataClassification;
                            foreach (var rShareCode in rsShareCode)
                            {
                                var Code = rShareCode.Code;

                                itemDataClassification = new ResumeCommunicationsClassificationDto();
                                itemDataClassification.Code = Code;
                                itemDataClassification.Name = rShareCode.Name;
                                itemDataClassification.ListResumeCommunications = Data.Where(p => p.CommunicationCategoryCode == Code).ToList();
                                itemsDataClassification.Add(itemDataClassification);
                            }

                            Result.Data.ListResumeCommunicationsClassification = itemsDataClassification;

                            if (ResumeDisplay == ResumeDisplayMethod.Classification)
                                Result.Data.ListResumeCommunications = null;
                        }
                    }

                    {
                        var items = await _appService._resumeDrvingLicenseRepository.GetListAsync(resumeMainId: ResumeMainId);
                        var Data = ObjectMapper.Map<List<ResumeDrvingLicense>, List<ResumeDrvingLicensesDto>>(items);
                        Data = (from c in Data
                                where c.Status == "1"
                                orderby c.Sort
                                select c).ToList();
                        Result.Data.ListResumeDrvingLicenses = Data;
                        var inputSetShareCode = new SetShareCodeInput();
                        inputSetShareCode.ListShareCode = itemsShareCode;
                        inputSetShareCode.Data = Data;
                        var ListColumns = new List<NameCodeStandardDto>();
                        ListColumns.Add(new NameCodeStandardDto { GroupCode = "DrvingLicense", Code = "DrvingLicenseCode", Name = "DrvingLicenseName" });
                        inputSetShareCode.ListColumns = ListColumns;
                        _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<ResumeDrvingLicensesDto>(inputSetShareCode);

                        //進行分類
                        if (ResumeDisplay != ResumeDisplayMethod.None)
                        {
                            var rsShareCode = itemsShareCode.Where(p => p.GroupCode == "DrvingLicense").ToList();
                            var rsgShareCode = rsShareCode.Where(p => p.ParentCode.Length == 0).ToList();   //上層的分類
                            var itemsDataClassification = new List<ResumeDrvingLicensesClassificationDto>();
                            ResumeDrvingLicensesClassificationDto itemDataClassification;
                            foreach (var rShareCode in rsgShareCode)
                            {
                                var Code = rShareCode.Code;
                                var ListShareCode = rsShareCode.Where(p => p.ParentCode == Code).Select(p => p.Code);

                                itemDataClassification = new ResumeDrvingLicensesClassificationDto();
                                itemDataClassification.Code = Code;
                                itemDataClassification.Name = rShareCode.Name;
                                itemDataClassification.ListResumeDrvingLicenses = Data.Where(p => ListShareCode.Contains(p.DrvingLicenseCode)).ToList();
                                itemsDataClassification.Add(itemDataClassification);
                            }

                            Result.Data.ListResumeDrvingLicensesClassification = itemsDataClassification;

                            if (ResumeDisplay == ResumeDisplayMethod.Classification)
                                Result.Data.ListResumeDrvingLicenses = null;
                        }
                    }

                    {
                        var items = await _appService._resumeRecommenderRepository.GetListAsync(resumeMainId: ResumeMainId);
                        var Data = ObjectMapper.Map<List<ResumeRecommender>, List<ResumeRecommendersDto>>(items);
                        Data = (from c in Data
                                where c.Status == "1"
                                orderby c.Sort
                                select c).ToList();
                        Result.Data.ListResumeRecommenders = Data;
                    }

                    {
                        var items = await _appService._resumeLanguageRepository.GetListAsync(resumeMainId: ResumeMainId);
                        var Data = ObjectMapper.Map<List<ResumeLanguage>, List<ResumeLanguagesDto>>(items);
                        Data = (from c in Data
                                where c.DateA <= DateNow && DateNow <= c.DateD
                                && c.Status == "1"
                                orderby c.Sort
                                select c).ToList();
                        Result.Data.ListResumeLanguages = Data;
                        var inputSetShareCode = new SetShareCodeInput();
                        inputSetShareCode.ListShareCode = itemsShareCode;
                        inputSetShareCode.Data = Data;
                        var ListColumns = new List<NameCodeStandardDto>();
                        ListColumns.Add(new NameCodeStandardDto { GroupCode = "LanguageCategory", Code = "LanguageCategoryCode", Name = "LanguageCategoryName" });
                        ListColumns.Add(new NameCodeStandardDto { GroupCode = "LanguageLevel", Code = "LevelSayCode", Name = "LevelSayName" });
                        ListColumns.Add(new NameCodeStandardDto { GroupCode = "LanguageLevel", Code = "LevelListenCode", Name = "LevelListenName" });
                        ListColumns.Add(new NameCodeStandardDto { GroupCode = "LanguageLevel", Code = "LevelReadCode", Name = "LevelReadName" });
                        ListColumns.Add(new NameCodeStandardDto { GroupCode = "LanguageLevel", Code = "LevelWriteCode", Name = "LevelWriteName" });
                        inputSetShareCode.ListColumns = ListColumns;
                        _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<ResumeLanguagesDto>(inputSetShareCode);

                        //進行分類
                        //語言的分法-分成國際語言及方言(比較特殊)
                        if (ResumeDisplay != ResumeDisplayMethod.None)
                        {
                            var rsShareCode = itemsShareCode.Where(p => p.GroupCode == "LanguageCategory").ToList();
                            var rsgShareCode = rsShareCode.Where(p => p.ParentCode.Length == 0).ToList();   //上層的分類
                            var itemsDataClassification = new List<ResumeLanguagesClassificationDto>();
                            ResumeLanguagesClassificationDto itemDataClassification;
                            foreach (var rShareCode in rsgShareCode)
                            {
                                var Code = rShareCode.Code;
                                var ListShareCode = rsShareCode.Where(p => p.ParentCode == Code).Select(p => p.Code);

                                itemDataClassification = new ResumeLanguagesClassificationDto();
                                itemDataClassification.Code = Code;
                                itemDataClassification.Name = rShareCode.Name;
                                itemDataClassification.ListResumeLanguages = Data.Where(p => ListShareCode.Contains(p.LanguageCategoryCode)).ToList();
                                itemsDataClassification.Add(itemDataClassification);
                            }

                            Result.Data.ListResumeLanguagesClassification = itemsDataClassification;

                            if (ResumeDisplay == ResumeDisplayMethod.Classification)
                                Result.Data.ListResumeLanguages = null;
                        }
                    }

                    {
                        var items = await _appService._resumeSkillRepository.GetListAsync(resumeMainId: ResumeMainId);
                        var Data = ObjectMapper.Map<List<ResumeSkill>, List<ResumeSkillsDto>>(items);
                        Data = (from c in Data
                                where c.Status == "1"
                                orderby c.Sort
                                select c).ToList();
                        Result.Data.ListResumeSkills = Data;
                        var inputSetShareCode = new SetShareCodeInput();
                        inputSetShareCode.ListShareCode = itemsShareCode;
                        inputSetShareCode.Data = Data;
                        var ListColumns = new List<NameCodeStandardDto>();
                        ListColumns.Add(new NameCodeStandardDto { GroupCode = "ChineseTyping", Code = "ChineseTypingCode", Name = "ChineseTypingName" });
                        inputSetShareCode.ListColumns = ListColumns;
                        _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<ResumeSkillsDto>(inputSetShareCode);
                    }

                    {
                        var items = await _appService._resumeDependentsRepository.GetListAsync(resumeMainId: ResumeMainId);
                        var Data = ObjectMapper.Map<List<ResumeDependents>, List<ResumeDependentssDto>>(items);
                        Data = (from c in Data
                                where c.Status == "1"
                                orderby c.Sort
                                select c).ToList();
                        Result.Data.ListResumeDependentss = Data;
                        var inputSetShareCode = new SetShareCodeInput();
                        inputSetShareCode.ListShareCode = itemsShareCode;
                        inputSetShareCode.Data = Data;
                        var ListColumns = new List<NameCodeStandardDto>();
                        ListColumns.Add(new NameCodeStandardDto { GroupCode = "Kinship", Code = "KinshipCode", Name = "KinshipName" });
                        inputSetShareCode.ListColumns = ListColumns;
                        _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<ResumeDependentssDto>(inputSetShareCode);
                    }

                    {
                        var items = await _appService._resumeEducationsRepository.GetListAsync(resumeMainId: ResumeMainId);
                        var Data = ObjectMapper.Map<List<ResumeEducations>, List<ResumeEducationssDto>>(items);
                        Data = (from c in Data
                                where c.Status == "1"
                                orderby c.Sort
                                select c).ToList();
                        Result.Data.ListResumeEducationss = Data;
                        var inputSetShareCode = new SetShareCodeInput();
                        inputSetShareCode.ListShareCode = itemsShareCode;
                        inputSetShareCode.Data = Data;
                        var ListColumns = new List<NameCodeStandardDto>();
                        ListColumns.Add(new NameCodeStandardDto { GroupCode = "EducationLevel", Code = "EducationLevelCode", Name = "EducationLevelName" });
                        //ListColumns.Add(new NameCodeStandardDto { GroupCode = "DepartmentCategory", Code = "MajorDepartmentCategoryCode", Name = "MajorDepartmentCategoryName" });
                        //ListColumns.Add(new NameCodeStandardDto { GroupCode = "DepartmentCategory", Code = "MinorDepartmentCategoryCode", Name = "MinorDepartmentCategoryName" });
                        ListColumns.Add(new NameCodeStandardDto { GroupCode = "Graduation", Code = "GraduationCode", Name = "GraduationName" });
                        ListColumns.Add(new NameCodeStandardDto { GroupCode = "Country", Code = "CountryCode", Name = "CountryName" });
                        inputSetShareCode.ListColumns = ListColumns;
                        _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<ResumeEducationssDto>(inputSetShareCode);
                    }

                    {
                        var items = await _appService._resumeExperiencesRepository.GetListAsync(resumeMainId: ResumeMainId);
                        var Data = ObjectMapper.Map<List<ResumeExperiences>, List<ResumeExperiencessDto>>(items);
                        Data = (from c in Data
                                where c.Status == "1"
                                orderby c.Sort
                                select c).ToList();
                        Result.Data.ListResumeExperiencess = Data;
                        var inputSetShareCode = new SetShareCodeInput();
                        inputSetShareCode.ListShareCode = itemsShareCode;
                        inputSetShareCode.Data = Data;
                        var ListColumns = new List<NameCodeStandardDto>();
                        ListColumns.Add(new NameCodeStandardDto { GroupCode = "WorkNature", Code = "WorkNatureCode", Name = "WorkNatureName" });
                        //ListColumns.Add(new NameCodeStandardDto { GroupCode = "IndustryCategory", Code = "IndustryCategoryCode", Name = "IndustryCategoryName" });
                        //ListColumns.Add(new NameCodeStandardDto { GroupCode = "WorkPlace", Code = "WorkPlaceCode", Name = "WorkPlaceName" });
                        ListColumns.Add(new NameCodeStandardDto { GroupCode = "SalaryPayType", Code = "SalaryPayTypeCode", Name = "SalaryPayTypeName" });
                        ListColumns.Add(new NameCodeStandardDto { GroupCode = "CurrencyType", Code = "CurrencyTypeCode", Name = "CurrencyTypeName" });
                        ListColumns.Add(new NameCodeStandardDto { GroupCode = "CompanyScale", Code = "CompanyScaleCode", Name = "CompanyScaleName" });
                        ListColumns.Add(new NameCodeStandardDto { GroupCode = "CompanyManagementNumber", Code = "CompanyManagementNumberCode", Name = "CompanyManagementNumberName" });
                        inputSetShareCode.ListColumns = ListColumns;
                        _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<ResumeExperiencessDto>(inputSetShareCode);

                        //try
                        //{
                        //    foreach (var item in Data)
                        //        item.ListJobType = JsonSerializer.Deserialize<List<ResumeExperiencesJobType>>(item.JobType);
                        //}
                        //catch { }
                    }

                    {
                        var items = await _appService._resumeWorksRepository.GetListAsync(resumeMainId: ResumeMainId);
                        var Data = ObjectMapper.Map<List<ResumeWorks>, List<ResumeWorkssDto>>(items);
                        Data = (from c in Data
                                where c.Status == "1"
                                orderby c.Sort
                                select c).ToList();

                        var inputShareUploadList = new ShareUploadListInput();
                        inputShareUploadList.Key1 = "ResumeWorks";
                        inputShareUploadList.Key2 = "";
                        foreach (var item in Data)
                        {
                            inputShareUploadList.Key3 = item.Id.ToString();
                            var itemsShareUploadList = await _appService._serviceProvider.GetService<SharesAppService>().GetShareUploadListAsync(inputShareUploadList);
                            item.ListShareUpload = itemsShareUploadList.Data;
                        }

                        Result.Data.ListResumeWorkss = Data;
                    }
                }

                Result.Save = true;
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<List<ResumeSnapshotsDto>>> GetResumeSnapshotsListAsync(ResumeSnapshotsListInput input)
        {
            var Result = new ResultDto<List<ResumeSnapshotsDto>>();
            Result.Data = new List<ResumeSnapshotsDto>();
            Result.Version = "2023041301";

            var CurrentTenantId = CurrentTenant.Id;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;

            //兩用 個人找快照 及公司找快照
            //從員工的角度一個主履歷主檔ResumeMainId，可以得知投遞過多少公司職缺的快照
            //從公司的角度可以得知對應的職缺，有多少人投遞(公司的頁面需要另開)
            var ResumeMainId = input.ResumeMainId;
            var CompanyJobId = input.CompanyJobId;   //沒有丟入職缺代碼 可以看全公司綁定的職缺

            var itemsAll = await _appService._resumeSnapshotRepository.GetQueryableAsync();
            var items = itemsAll.Where(p => p.ResumeMainId == ResumeMainId).ToList();

            var itemsAllCompanyMain = await _appService._companyMainRepository.GetQueryableAsync();
            var itemsAllCompanyJob = await _appService._companyJobRepository.GetQueryableAsync();

            if (items.Count == 0)
            {
                //人事管理者 可以觀看履歷
                if (SystemUserRoleKeys <= 8)
                    using (_appService._dataFilter.Disable<IMultiTenant>())
                        items = itemsAll.Where(p => p.CompanyMainId == CompanyMainId && (CompanyJobId == null || p.CompanyJobId == CompanyJobId)
                        && p.ResumeMainId == ResumeMainId).ToList();
            }

            if (items.Count > 0)
            {
                var ListCompanyMainId = items.Select(p => p.CompanyMainId).ToList();
                var ListCompanyJobId = items.Select(p => p.CompanyJobId).ToList();

                using (_appService._dataFilter.Disable<IMultiTenant>())
                {
                    var itemsCompanyMain = itemsAllCompanyMain.Where(p => ListCompanyMainId.Contains(p.Id)).ToList();
                    var itemsCompanyJob = itemsAllCompanyJob.Where(p => ListCompanyMainId.Contains(p.CompanyMainId) && ListCompanyJobId.Contains(p.Id)).ToList();

                    var Data = ObjectMapper.Map<List<ResumeSnapshot>, List<ResumeSnapshotsDto>>(items);
                    foreach (var item in Data)
                    {
                        CompanyMainId = item.CompanyMainId;
                        CompanyJobId = item.CompanyJobId;

                        var itemCompanyMain = itemsCompanyMain.FirstOrDefault(p => p.Id == CompanyMainId);
                        if (itemCompanyMain != null)
                            item.CompanyMainName = itemCompanyMain.Name;

                        var itemCompanyJob = itemsCompanyJob.FirstOrDefault(p => p.Id == CompanyJobId);
                        if (itemCompanyJob != null)
                            item.CompanyJobName = itemCompanyJob.Name;

                        item.Resume = JsonSerializer.Deserialize<ResumeDto>(item.Snapshot);
                        item.Snapshot = "";
                    }

                    Result.Data = Data;
                    Result.Save = true;
                }
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<ResumeSnapshotsDto>> GetResumeSnapshotsAsync(ResumeSnapshotsInput input)
        {
            var Result = new ResultDto<ResumeSnapshotsDto>();
            Result.Data = new ResumeSnapshotsDto();
            Result.Version = "2023042001";

            var CurrentTenantId = CurrentTenant.Id;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            var Id = input.Id;

            var itemsAll = await _appService._resumeSnapshotRepository.GetQueryableAsync();
            var item = itemsAll.FirstOrDefault(p => p.Id == Id);

            var itemsAllCompanyMain = await _appService._companyMainRepository.GetQueryableAsync();
            var itemsAllCompanyJob = await _appService._companyJobRepository.GetQueryableAsync();

            if (item == null)
            {
                //人事管理者 可以觀看履歷
                if (SystemUserRoleKeys <= 8)
                {
                    //由使用者的 CurrentTenantId 去尋找所屬公司 不用判斷也不會錯
                    var itemCompanyMain = itemsAllCompanyMain.FirstOrDefault(p => p.TenantId == CurrentTenantId);
                    if (itemCompanyMain != null)
                    {
                        var CompanyMainId = itemCompanyMain.Id;
                        using (_appService._dataFilter.Disable<IMultiTenant>())
                            item = itemsAll.FirstOrDefault(p => p.Id == Id && p.CompanyMainId == CompanyMainId);    //該快照必須要綁定該公司
                    }
                }
            }

            if (item != null)
            {
                var CompanyMainId = item.CompanyMainId;
                var CompanyJobId = item.CompanyJobId;

                var Data = ObjectMapper.Map<ResumeSnapshot, ResumeSnapshotsDto>(item);

                using (_appService._dataFilter.Disable<IMultiTenant>())
                {
                    var itemCompanyMain = itemsAllCompanyMain.FirstOrDefault(p => p.Id == CompanyMainId);
                    if (itemCompanyMain != null)
                        Data.CompanyMainName = itemCompanyMain.Name;

                    var itemCompanyJob = itemsAllCompanyJob.FirstOrDefault(p => p.CompanyMainId == CompanyMainId && p.Id == CompanyJobId);
                    if (itemCompanyJob != null)
                        Data.CompanyJobName = itemCompanyJob.Name;
                }

                Data.Resume = JsonSerializer.Deserialize<ResumeDto>(item.Snapshot);
                Data.Snapshot = "";

                Result.Data = Data;
                Result.Save = true;
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<List<ResumeSnapshotsDto>>> GetResumeSnapshotsListAsync(ResumeSnapshotsListKeyWordsInput input)
        {
            var Result = new ResultDto<List<ResumeSnapshotsDto>>();
            Result.Data = new List<ResumeSnapshotsDto>();
            Result.Version = "2023062901";

            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;

            var KeyWords = input.KeyWords ?? "";

            if (SystemUserRoleKeys >= 16)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "您沒有權限" });

            if (Result.Messages.Count == 0)
            {
                var itemsAll = await _appService._resumeSnapshotRepository.GetQueryableAsync();
                var Data = new List<ResumeSnapshotsDto>();
                using (_appService._dataFilter.Disable<IMultiTenant>())
                {
                    var items = itemsAll.Where(p => p.CompanyMainId == CompanyMainId && p.Snapshot.IndexOf(KeyWords) >= 0).ToList();
                    Data = ObjectMapper.Map<List<ResumeSnapshot>, List<ResumeSnapshotsDto>>(items);
                }

                try
                {
                    foreach (var item in Data)
                    {
                        item.Resume = JsonSerializer.Deserialize<ResumeDto>(item.Snapshot);
                        item.Snapshot = "";
                    }

                    Result.Save = true;
                }
                catch (Exception ex)
                {
                    var Msg = "錯誤：JSON格式不正確，轉換失敗---" + KeyWords;
                    _appService._logger.LogInformation(Msg + "ex:" + ex.ToString());
                    Result.Messages.Add(new ResultMessageDto() { MessageCode = @"400", MessageContents = Msg, Pass = false });
                }

                Result.Data = Data;
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<UpdateResumeMainNameDto>> UpdateResumeMainNameAsync(UpdateResumeMainNameInput input)
        {
            var Result = new ResultDto<UpdateResumeMainNameDto>();
            Result.Data = new UpdateResumeMainNameDto();
            Result.Version = "2023041301";

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;

            var Id = input.Id;
            var ResumeName = input.ResumeName ?? "我的履歷";

            //必要代碼檢核
            if (ResumeName.IsNullOrEmpty())
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "欄位不可以空白" });

            //資料會判斷UserMainId 因此不用先判斷此份履歷的權限

            if (Result.Messages.Count == 0)
            {
                var itemsAll = await _appService._resumeMainRepository.GetQueryableAsync();
                var item = itemsAll.FirstOrDefault(p => p.UserMainId == UserMainId && p.Id == Id);
                if (item != null)
                {
                    item.ResumeName = ResumeName;
                    await _appService._resumeMainRepository.UpdateAsync(item);

                    Result.Data.Pass = true;
                    Result.Save = true;
                }
                else
                    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "修改沒有成功" });
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<UpdateResumeMainNameDto>> UpdateResumeMainAutobiographyAsync(UpdateResumeMainAutobiographyInput input)
        {
            var Result = new ResultDto<UpdateResumeMainNameDto>();
            Result.Data = new UpdateResumeMainNameDto();
            Result.Version = "2023041301";

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;

            var Id = input.Id;
            var ResumeMainAutobiography1 = input.ResumeMainAutobiography1 ?? "";
            var ResumeMainAutobiography2 = input.ResumeMainAutobiography2 ?? "";

            //必要代碼檢核

            //資料會判斷UserMainId 因此不用先判斷此份履歷的權限

            if (Result.Messages.Count == 0)
            {
                var itemsAll = await _appService._resumeMainRepository.GetQueryableAsync();
                var item = itemsAll.FirstOrDefault(p => p.UserMainId == UserMainId && p.Id == Id);
                if (item != null)
                {
                    item.Autobiography1 = ResumeMainAutobiography1;
                    item.Autobiography2 = ResumeMainAutobiography2;
                    await _appService._resumeMainRepository.UpdateAsync(item);

                    Result.Data.Pass = true;
                    Result.Save = true;
                }
                else
                    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "修改沒有成功" });
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<SaveResumeSnapshotsDto>> SaveResumeSnapshotsAsync(SaveResumeSnapshotInput input)
        {
            var Result = new ResultDto<SaveResumeSnapshotsDto>();
            Result.Data = new SaveResumeSnapshotsDto();
            Result.Version = "2023042001";

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;

            var Id = input.Id;
            var ResumeMainId = input.ResumeMainId;
            var CompanyMainId = input.CompanyMainId;
            var CompanyJobId = input.CompanyJobId;

            //必要代碼檢核

            //與綁定的公司驗証是否有該公司的職缺可以發送履歷
            var itemsAllUserCompanyBind = await _appService._userCompanyBindRepository.GetQueryableAsync();
            var itemUserCompanyBind = itemsAllUserCompanyBind.FirstOrDefault(p => p.UserMainId == UserMainId && p.CompanyMainId == CompanyMainId && p.CompanyJobId == CompanyJobId && p.Status == "1");
            if (itemUserCompanyBind == null)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "您與該公司並未連結" });

            if (Result.Messages.Count == 0)
            {
                //把綁定的資訊，寫回後台
                var CompanyInvitationsId = itemUserCompanyBind.CompanyInvitationsId;
                var UserCompanyBindId = itemUserCompanyBind.Id;
                var itemsAllCompanyInvitations = await _appService._companyInvitationsRepository.GetQueryableAsync();
                var itemCompanyInvitations = new CompanyInvitations();
                using (_appService._dataFilter.Disable<IMultiTenant>())
                    itemCompanyInvitations = itemsAllCompanyInvitations.FirstOrDefault(p => p.Id == CompanyInvitationsId);
                if (itemCompanyInvitations == null)
                    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "該公司沒有邀請資料" });

                if (Result.Messages.Count == 0)
                {
                    var inputResume = new ResumeInput();
                    inputResume.ResumeMainId = ResumeMainId;
                    inputResume.ResumeDisplay = ResumeDisplayMethod.None;
                    var itemResume = await GetResumeAsync(inputResume);
                    if (itemResume != null && itemResume.Check)
                    {
                        //用使用者綁定的代碼去找尋快照 或是 用完整的資訊尋找快照
                        var items = await _appService._resumeSnapshotRepository.GetQueryableAsync();
                        var item = items.FirstOrDefault(p => p.UserCompanyBindId == UserCompanyBindId || (p.UserMainId == UserMainId && p.ResumeMainId == ResumeMainId && p.CompanyMainId == CompanyMainId && p.CompanyJobId == CompanyJobId));
                        if (item == null)
                        {
                            item = new ResumeSnapshot();
                            await _appService._resumeSnapshotRepository.InsertAsync(item);
                            item.Status = "1";
                        }
                        else
                            await _appService._resumeSnapshotRepository.UpdateAsync(item);

                        item.ResumeMainId = ResumeMainId;
                        item.CompanyMainId = CompanyMainId;
                        item.CompanyJobId = CompanyJobId;
                        item.UserMainId = UserMainId;
                        item.Snapshot = JsonSerializer.Serialize(itemResume.Data, new JsonSerializerOptions
                        {
                            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping, // 中文字不編碼
                            WriteIndented = true  // 換行與縮排
                        });

                        item.ExtendedInformation = input.ExtendedInformation ?? "";
                        item.UserCompanyBindId = UserCompanyBindId;
                        item.DateA = input.DateA;
                        item.DateD = input.DateD;
                        item.Sort = input.Sort;
                        item.Note = input.Note ?? "";

                        itemCompanyInvitations.UserMainId = UserMainId;//這行應該不用儲存 但再次儲存可以加強 也是不錯
                        itemCompanyInvitations.UserCompanyBindId = UserCompanyBindId;  //這行應該不用儲存 但再次儲存可以加強 也是不錯
                        itemCompanyInvitations.ResumeSnapshotId = item.Id;
                        await _appService._companyInvitationsRepository.UpdateAsync(itemCompanyInvitations);

                        Result.Data.Pass = true;
                        Result.Save = true;
                    }
                }
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<ResumeMainsDto>> SaveResumeAsync(ResumeMainsDto input)
        {
            var Result = new ResultDto<ResumeMainsDto>();
            Result.Data = new ResumeMainsDto();
            Result.Version = "2023041301";

            var CurrentTenantId = CurrentTenant.Id;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;

            var SaveIntent = SaveIntentType.Update;
            var Id = input.Id;
            var ResumeName = input.ResumeName ?? "我的履歷";
            //var SexCode = input.SexCode;
            //var BloodCode = input.BloodCode;
            var MarriageCode = input.MarriageCode;
            //var PlaceOfBirthCode = input.PlaceOfBirthCode;
            var MilitaryCode = input.MilitaryCode;
            var DisabilityCategoryCode = input.DisabilityCategoryCode;
            //var NationalityCode = input.NationalityCode;
            var SpecialIdentityCode = input.SpecialIdentityCode;

            //必要代碼檢核
            var inputShareCodeGroup = new ShareCodeGroupInput();
            inputShareCodeGroup.ListGroupCode.Add("Sex");
            inputShareCodeGroup.ListGroupCode.Add("Blood");
            inputShareCodeGroup.ListGroupCode.Add("Marriage");
            inputShareCodeGroup.ListGroupCode.Add("PlaceOfBirth");
            inputShareCodeGroup.ListGroupCode.Add("Military");
            inputShareCodeGroup.ListGroupCode.Add("DisabilityCategory");
            inputShareCodeGroup.ListGroupCode.Add("Nationality");
            inputShareCodeGroup.ListGroupCode.Add("SpecialIdentity");
            var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);

            var inputUserMains = new UserMainsInput();
            var itemUserMain = await _appService._serviceProvider.GetService<UsersAppService>().GetUserMainsAsync(inputUserMains);
            if (itemUserMain == null && itemUserMain.Data != null)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "無法取得使用者基本資料" });

            var itemsAll = await _appService._resumeMainRepository.GetQueryableAsync();
            var item = itemsAll.FirstOrDefault(p => p.UserMainId == UserMainId && p.Id == Id);
            SaveIntent = (item == null) ? SaveIntentType.Insert : SaveIntentType.Update;
            if (SaveIntent == SaveIntentType.Update)
            {
                //if (!itemsShareCode.Any(p => p.GroupCode == "Sex" && p.Code == SexCode))
                //    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "性別代碼錯誤" });

                //if (!itemsShareCode.Any(p => p.GroupCode == "Blood" && p.Code == BloodCode))
                //    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "血型代碼錯誤" });

                if (!itemsShareCode.Any(p => p.GroupCode == "Marriage" && p.Code == MarriageCode))
                    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "婚姻代碼錯誤" });

                //if (!itemsShareCode.Any(p => p.GroupCode == "PlaceOfBirth" && p.Code == PlaceOfBirthCode))
                //    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "出生地代碼錯誤" });

                if (!itemsShareCode.Any(p => p.GroupCode == "Military" && p.Code == MilitaryCode))
                    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "兵役代碼錯誤" });

                if (!itemsShareCode.Any(p => p.GroupCode == "DisabilityCategory" && p.Code == DisabilityCategoryCode))
                    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "殘障類別代碼錯誤" });

                //if (!itemsShareCode.Any(p => p.GroupCode == "Nationality" && p.Code == NationalityCode))
                //    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "國藉代碼錯誤" });

                if (!itemsShareCode.Any(p => p.GroupCode == "SpecialIdentity" && p.Code == SpecialIdentityCode))
                    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "特殊身份代碼錯誤" });
            }

            if (Result.Messages.Count == 0)
            {
                if (item == null)
                {
                    var UserMains = itemUserMain.Data;

                    item = new ResumeMain();
                    await _appService._resumeMainRepository.InsertAsync(item);
                    item.UserMainId = UserMainId;
                    item.Main = false;
                    item.ResumeName = ResumeName;
                    item.Autobiography1 = "";
                    item.Autobiography2 = "";
                    item.Status = "1";
                    //item.IdentityNo = UserMains.LoginIdentityNo;
                    //item.NameC = UserMains.Name;

                    //交通工具初始化
                    var inputInsertResumeDrvingLicense = new InsertResumeDrvingLicenseInput();
                    inputInsertResumeDrvingLicense.TenantId = CurrentTenantId;
                    inputInsertResumeDrvingLicense.ResumeMainId = Id;
                    await _appService._serviceProvider.GetService<ResumesAppService>().InsertResumeDrvingLicenseAsync(inputInsertResumeDrvingLicense);
                }
                else
                    await _appService._resumeMainRepository.UpdateAsync(item);

                //item.NameE = input.NameE ?? "";
                //item.SexCode = input.SexCode ?? "";
                //item.BloodCode = input.BloodCode ?? "";
                item.MarriageCode = input.MarriageCode ?? "";
                //item.PlaceOfBirthCode = input.PlaceOfBirthCode ?? "";
                item.MilitaryCode = input.MilitaryCode ?? "";
                //item.PassportNo = input.PassportNo ?? "";
                item.DisabilityCategoryCode = input.DisabilityCategoryCode ?? "";
                //item.NationalityCode = input.NationalityCode ?? "";
                item.SpecialIdentityCode = input.SpecialIdentityCode ?? "";
                //item.ResidenceNo = input.ResidenceNo ?? "";
                item.ExtendedInformation = input.ExtendedInformation ?? "";
                item.DateA = input.DateA;
                item.DateD = input.DateD;
                item.Sort = input.Sort;
                item.Note = input.Note ?? "";

                Result.Data = ObjectMapper.Map<ResumeMain, ResumeMainsDto>(item);

                if (SaveIntent == SaveIntentType.Update)
                {
                    //為代碼類加上名稱
                    var inputSetShareCode = new SetShareCodeInput();
                    inputSetShareCode.ListShareCode = itemsShareCode;
                    inputSetShareCode.Data = new List<ResumeMainsDto>() { Result.Data };
                    var ListColumns = new List<NameCodeStandardDto>();
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "Sex", Code = "SexCode", Name = "SexName" });
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "Blood", Code = "BloodCode", Name = "BloodName" });
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "Marriage", Code = "MarriageCode", Name = "MarriageName" });
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "PlaceOfBirth", Code = "PlaceOfBirthCode", Name = "PlaceOfBirthName" });
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "Military", Code = "MilitaryCode", Name = "MilitaryName" });
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "DisabilityCategory", Code = "DisabilityCategoryCode", Name = "DisabilityCategoryName" });
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "Nationality", Code = "NationalityCode", Name = "NationalityName" });
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "SpecialIdentity", Code = "SpecialIdentityCode", Name = "SpecialIdentityName" });
                    inputSetShareCode.ListColumns = ListColumns;
                    _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<ResumeMainsDto>(inputSetShareCode);
                }

                Result.Save = true;
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<ResumeMainsDto>> SaveResumeSwitchAsync(SaveResumeSwitchInput input)
        {
            var Result = new ResultDto<ResumeMainsDto>();
            Result.Data = new ResumeMainsDto();
            Result.Version = "2023062701";

            var CurrentTenantId = CurrentTenant.Id;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;

            var ResumeMainId = input.ResumeMainId;
            var Switch = input.Switch;

            if (Result.Messages.Count == 0)
            {
                var itemsAll = await _appService._resumeMainRepository.GetQueryableAsync();
                var item = itemsAll.FirstOrDefault(p => p.UserMainId == UserMainId && p.Id == ResumeMainId);
                if (item == null)
                    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "沒有履歷資料" });
                else
                {
                    await _appService._resumeMainRepository.UpdateAsync(item);

                    item.DateD = Switch ? new DateTime(2099, 12, 31).Date : DateTime.Now.Date.AddDays(-1);
                    Result.Data = ObjectMapper.Map<ResumeMain, ResumeMainsDto>(item);

                    Result.Save = true;
                }
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<ResumeMainMainDto>> SaveResumeMainMainAsync(SaveResumeMainMainInput input)
        {
            var Result = new ResultDto<ResumeMainMainDto>();
            Result.Data = new ResumeMainMainDto();
            Result.Version = "2023062801";

            var CurrentTenantId = CurrentTenant.Id;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;

            var ResumeMainId = input.ResumeMainId;
            var Main = input.Main;

            if (Result.Messages.Count == 0)
            {
                var itemsAll = await _appService._resumeMainRepository.GetQueryableAsync();
                var items = itemsAll.Where(p => p.UserMainId == UserMainId).ToList();
                if (!items.Any())
                    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "沒有履歷資料" });
                else
                {
                    Result.Data.dcResumeMain = new Dictionary<Guid, bool>();
                    foreach (var item in items)
                    {
                        item.Main = false;

                        var Id = item.Id;
                        if (ResumeMainId == Id)
                            item.Main = Main;

                        Result.Data.dcResumeMain.Add(Id, item.Main);
                    }

                    await _appService._resumeMainRepository.UpdateManyAsync(items);

                    Result.Save = true;
                }
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<ResumeMainSortDto>> SaveResumeMainSortAsync(SaveResumeMainSortInput input)
        {
            var Result = new ResultDto<ResumeMainSortDto>();
            Result.Data = new ResumeMainSortDto();
            Result.Version = "2023062801";

            var CurrentTenantId = CurrentTenant.Id;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;

            var ListResumeMain = input.ListResumeMain;

            if (Result.Messages.Count == 0)
            {
                var itemsAll = await _appService._resumeMainRepository.GetQueryableAsync();
                var items = itemsAll.Where(p => p.UserMainId == UserMainId).ToList();
                if (!items.Any())
                    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "沒有履歷資料" });
                else
                {
                    Result.Data.dcResumeMain = new Dictionary<Guid, int>();
                    foreach (var itemResumeMain in ListResumeMain)
                    {
                        var Id = itemResumeMain.Id;
                        var Sort = itemResumeMain.Sort;
                        var item = items.FirstOrDefault(p => p.Id == Id);
                        if (item != null)
                        {
                            item.Sort = Sort;
                            Result.Data.dcResumeMain.Add(Id, Sort);
                        }
                    }

                    await _appService._resumeMainRepository.UpdateManyAsync(items);

                    Result.Save = true;
                }
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<ResumeMainsDto>> CopyResumeAsync(CopyResumeInput input)
        {
            var Result = new ResultDto<ResumeMainsDto>();
            Result.Data = new ResumeMainsDto();
            Result.Version = "2023062701";

            var CurrentTenantId = CurrentTenant.Id;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;

            var ResumeMainId = input.ResumeMainId;
            var ResumeMainName = input.ResumeMainName ?? "我的新履歷" + DateTime.Now.ToString("yyyyMMddHHmmssffff");

            if (Result.Messages.Count == 0)
            {
                var qrbResumeMain = await _appService._resumeMainRepository.GetQueryableAsync();
                var itemResumeMain = qrbResumeMain.FirstOrDefault(p => p.UserMainId == UserMainId && p.Id == ResumeMainId);
                if (itemResumeMain == null)
                    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "沒有履歷資料" });
                else
                {
                    //主檔
                    var itemResumeMainDto = ObjectMapper.Map<ResumeMain, ResumeMainDto>(itemResumeMain);
                    itemResumeMainDto.Id = _appService._guidGenerator.Create();
                    var Id = _appService._guidGenerator.Create();
                    itemResumeMainDto.Id = Id;
                    itemResumeMainDto.ResumeName = ResumeMainName;
                    itemResumeMainDto.Main = false;
                    itemResumeMainDto.LastModificationTime = DateTime.Now;
                    var itemResumeMainCopy = ObjectMapper.Map<ResumeMainDto, ResumeMain>(itemResumeMainDto);
                    await _appService._resumeMainRepository.InsertAsync(itemResumeMainCopy);

                    //通訊資料
                    var qrbResumeCommunication = await _appService._resumeCommunicationRepository.GetQueryableAsync();
                    var itemsResumeCommunication = qrbResumeCommunication.Where(p => p.ResumeMainId == ResumeMainId).ToList();
                    var itemsResumeCommunicationDto = ObjectMapper.Map<List<ResumeCommunication>, List<ResumeCommunicationDto>>(itemsResumeCommunication);
                    foreach (var itemResumeCommunicationDto in itemsResumeCommunicationDto)
                    {
                        itemResumeCommunicationDto.Id = _appService._guidGenerator.Create();
                        itemResumeCommunicationDto.ResumeMainId = Id;
                        itemResumeCommunicationDto.LastModificationTime = DateTime.Now;
                    }
                    var itemsResumeCommunicationCopy = ObjectMapper.Map<List<ResumeCommunicationDto>, List<ResumeCommunication>>(itemsResumeCommunicationDto);
                    await _appService._resumeCommunicationRepository.InsertManyAsync(itemsResumeCommunicationCopy);

                    //駕照及交通工具
                    var qrbResumeDrvingLicense = await _appService._resumeDrvingLicenseRepository.GetQueryableAsync();
                    var itemsResumeDrvingLicense = qrbResumeDrvingLicense.Where(p => p.ResumeMainId == ResumeMainId).ToList();
                    var itemsResumeDrvingLicenseDto = ObjectMapper.Map<List<ResumeDrvingLicense>, List<ResumeDrvingLicenseDto>>(itemsResumeDrvingLicense);
                    foreach (var itemResumeDrvingLicenseDto in itemsResumeDrvingLicenseDto)
                    {
                        itemResumeDrvingLicenseDto.Id = _appService._guidGenerator.Create();
                        itemResumeDrvingLicenseDto.ResumeMainId = Id;
                        itemResumeDrvingLicenseDto.LastModificationTime = DateTime.Now;
                    }
                    var itemsResumeDrvingLicenseCopy = ObjectMapper.Map<List<ResumeDrvingLicenseDto>, List<ResumeDrvingLicense>>(itemsResumeDrvingLicenseDto);
                    await _appService._resumeDrvingLicenseRepository.InsertManyAsync(itemsResumeDrvingLicenseCopy);

                    //推薦人
                    var qrbResumeRecommender = await _appService._resumeRecommenderRepository.GetQueryableAsync();
                    var itemsResumeRecommender = qrbResumeRecommender.Where(p => p.ResumeMainId == ResumeMainId).ToList();
                    var itemsResumeRecommenderDto = ObjectMapper.Map<List<ResumeRecommender>, List<ResumeRecommenderDto>>(itemsResumeRecommender);
                    foreach (var itemResumeRecommenderDto in itemsResumeRecommenderDto)
                    {
                        itemResumeRecommenderDto.Id = _appService._guidGenerator.Create();
                        itemResumeRecommenderDto.ResumeMainId = Id;
                        itemResumeRecommenderDto.LastModificationTime = DateTime.Now;
                    }
                    var itemsResumeRecommenderCopy = ObjectMapper.Map<List<ResumeRecommenderDto>, List<ResumeRecommender>>(itemsResumeRecommenderDto);
                    await _appService._resumeRecommenderRepository.InsertManyAsync(itemsResumeRecommenderCopy);

                    //語言能力
                    var qrbResumeLanguage = await _appService._resumeLanguageRepository.GetQueryableAsync();
                    var itemsResumeLanguage = qrbResumeLanguage.Where(p => p.ResumeMainId == ResumeMainId).ToList();
                    var itemsResumeLanguageDto = ObjectMapper.Map<List<ResumeLanguage>, List<ResumeLanguageDto>>(itemsResumeLanguage);
                    foreach (var itemResumeLanguageDto in itemsResumeLanguageDto)
                    {
                        itemResumeLanguageDto.Id = _appService._guidGenerator.Create();
                        itemResumeLanguageDto.ResumeMainId = Id;
                        itemResumeLanguageDto.LastModificationTime = DateTime.Now;
                    }
                    var itemsResumeLanguageCopy = ObjectMapper.Map<List<ResumeLanguageDto>, List<ResumeLanguage>>(itemsResumeLanguageDto);
                    await _appService._resumeLanguageRepository.InsertManyAsync(itemsResumeLanguageCopy);

                    //技能專長
                    var qrbResumeSkill = await _appService._resumeSkillRepository.GetQueryableAsync();
                    var itemsResumeSkill = qrbResumeSkill.Where(p => p.ResumeMainId == ResumeMainId).ToList();
                    var itemsResumeSkillDto = ObjectMapper.Map<List<ResumeSkill>, List<ResumeSkillDto>>(itemsResumeSkill);
                    foreach (var itemResumeSkillDto in itemsResumeSkillDto)
                    {
                        itemResumeSkillDto.Id = _appService._guidGenerator.Create();
                        itemResumeSkillDto.ResumeMainId = Id;
                        itemResumeSkillDto.LastModificationTime = DateTime.Now;
                    }
                    var itemsResumeSkillCopy = ObjectMapper.Map<List<ResumeSkillDto>, List<ResumeSkill>>(itemsResumeSkillDto);
                    await _appService._resumeSkillRepository.InsertManyAsync(itemsResumeSkillCopy);

                    //眷屬資料
                    var qrbResumeDependents = await _appService._resumeDependentsRepository.GetQueryableAsync();
                    var itemsResumeDependents = qrbResumeDependents.Where(p => p.ResumeMainId == ResumeMainId).ToList();
                    var itemsResumeDependentsDto = ObjectMapper.Map<List<ResumeDependents>, List<ResumeDependentsDto>>(itemsResumeDependents);
                    foreach (var itemResumeDependentsDto in itemsResumeDependentsDto)
                    {
                        itemResumeDependentsDto.Id = _appService._guidGenerator.Create();
                        itemResumeDependentsDto.ResumeMainId = Id;
                        itemResumeDependentsDto.LastModificationTime = DateTime.Now;
                    }
                    var itemsResumeDependentsCopy = ObjectMapper.Map<List<ResumeDependentsDto>, List<ResumeDependents>>(itemsResumeDependentsDto);
                    await _appService._resumeDependentsRepository.InsertManyAsync(itemsResumeDependentsCopy);

                    //學歷
                    var qrbResumeEducations = await _appService._resumeEducationsRepository.GetQueryableAsync();
                    var itemsResumeEducations = qrbResumeEducations.Where(p => p.ResumeMainId == ResumeMainId).ToList();
                    var itemsResumeEducationsDto = ObjectMapper.Map<List<ResumeEducations>, List<ResumeEducationsDto>>(itemsResumeEducations);
                    foreach (var itemResumeEducationsDto in itemsResumeEducationsDto)
                    {
                        itemResumeEducationsDto.Id = _appService._guidGenerator.Create();
                        itemResumeEducationsDto.ResumeMainId = Id;
                        itemResumeEducationsDto.LastModificationTime = DateTime.Now;
                    }
                    var itemsResumeEducationsCopy = ObjectMapper.Map<List<ResumeEducationsDto>, List<ResumeEducations>>(itemsResumeEducationsDto);
                    await _appService._resumeEducationsRepository.InsertManyAsync(itemsResumeEducationsCopy);

                    //經歷
                    var qrbResumeExperiences = await _appService._resumeExperiencesRepository.GetQueryableAsync();
                    var itemsResumeExperiences = qrbResumeExperiences.Where(p => p.ResumeMainId == ResumeMainId).ToList();
                    var itemsResumeExperiencesDto = ObjectMapper.Map<List<ResumeExperiences>, List<ResumeExperiencesDto>>(itemsResumeExperiences);
                    foreach (var itemResumeExperiencesDto in itemsResumeExperiencesDto)
                    {
                        itemResumeExperiencesDto.Id = _appService._guidGenerator.Create();
                        itemResumeExperiencesDto.ResumeMainId = Id;
                        itemResumeExperiencesDto.LastModificationTime = DateTime.Now;
                    }
                    var itemsResumeExperiencesCopy = ObjectMapper.Map<List<ResumeExperiencesDto>, List<ResumeExperiences>>(itemsResumeExperiencesDto);
                    await _appService._resumeExperiencesRepository.InsertManyAsync(itemsResumeExperiencesCopy);

                    //作品無法複制

                    Result.Data = ObjectMapper.Map<ResumeMain, ResumeMainsDto>(itemResumeMainCopy);
                    Result.Save = true;
                }
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<ResumeCommunicationsDto>> SaveResumeAsync(ResumeCommunicationsDto input)
        {
            var Result = new ResultDto<ResumeCommunicationsDto>();
            Result.Data = new ResumeCommunicationsDto();
            Result.Version = "2023041301";

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;

            var ResumeMainId = input.ResumeMainId;
            var Id = input.Id;  //空白時當做新增
            var CommunicationCategoryCode = input.CommunicationCategoryCode;

            //必要代碼檢核
            //if (ResumeMainId.IsNullOrEmpty())
            //    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "履歷主檔代碼不可以空白" });

            var anyResumeMain = await _appService._resumeMainRepository.AnyAsync(p => p.UserMainId == UserMainId && p.Id == ResumeMainId);
            if (!anyResumeMain)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "無法取得履歷主檔資料" });

            var inputShareCodeGroup = new ShareCodeGroupInput();
            inputShareCodeGroup.ListGroupCode.Add("CommunicationCategory");
            var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);

            if (!itemsShareCode.Any(p => p.GroupCode == "CommunicationCategory" && p.Code == CommunicationCategoryCode))
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "通訊資訊代碼錯誤" });

            if (Result.Messages.Count == 0)
            {
                var itemsAll = await _appService._resumeCommunicationRepository.GetQueryableAsync();
                var item = itemsAll.FirstOrDefault(p => p.ResumeMainId == ResumeMainId && p.Id == Id);
                if (item == null)
                {
                    item = new ResumeCommunication();
                    await _appService._resumeCommunicationRepository.InsertAsync(item);
                    item.ResumeMainId = ResumeMainId;
                    item.Status = "1";
                }
                else
                    await _appService._resumeCommunicationRepository.UpdateAsync(item);

                item.CommunicationCategoryCode = input.CommunicationCategoryCode;
                item.CommunicationValue = input.CommunicationValue ?? "";
                item.Main = input.Main;
                item.ExtendedInformation = input.ExtendedInformation ?? "";
                item.DateA = input.DateA;
                item.DateD = input.DateD;
                item.Sort = input.Sort;
                item.Note = input.Note ?? "";

                Result.Data = ObjectMapper.Map<ResumeCommunication, ResumeCommunicationsDto>(item);

                //為代碼類加上名稱 
                var inputSetShareCode = new SetShareCodeInput();
                inputSetShareCode.ListShareCode = itemsShareCode;
                inputSetShareCode.Data = new List<ResumeCommunicationsDto>() { Result.Data };
                var ListColumns = new List<NameCodeStandardDto>();
                ListColumns.Add(new NameCodeStandardDto { GroupCode = "CommunicationCategory", Code = "CommunicationCategoryCode", Name = "CommunicationCategoryName" });
                inputSetShareCode.ListColumns = ListColumns;
                _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<ResumeCommunicationsDto>(inputSetShareCode);

                Result.Save = true;
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<ResumeDrvingLicensesDto>> SaveResumeAsync(ResumeDrvingLicensesDto input)
        {
            var Result = new ResultDto<ResumeDrvingLicensesDto>();
            Result.Data = new ResumeDrvingLicensesDto();
            Result.Version = "2023041301";

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;

            var ResumeMainId = input.ResumeMainId;
            var Id = input.Id; //空白時當做新增
            var DrvingLicenseCode = input.DrvingLicenseCode;

            //必要代碼檢核
            //if (ResumeMainId.IsNullOrEmpty())
            //    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "履歷主檔代碼不可以空白" });

            var anyResumeMain = await _appService._resumeMainRepository.AnyAsync(p => p.UserMainId == UserMainId && p.Id == ResumeMainId);
            if (!anyResumeMain)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "無法取得履歷主檔資料" });

            var inputShareCodeGroup = new ShareCodeGroupInput();
            inputShareCodeGroup.ListGroupCode.Add("DrvingLicense");
            var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);

            if (!itemsShareCode.Any(p => p.GroupCode == "DrvingLicense" && p.Code == DrvingLicenseCode))
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "車種類別代碼錯誤" });

            var itemsAll = await _appService._resumeDrvingLicenseRepository.GetQueryableAsync();
            var item = itemsAll.FirstOrDefault(p => p.ResumeMainId == ResumeMainId && p.DrvingLicenseCode == DrvingLicenseCode && p.Id != Id);
            if (item != null)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "車種類別代碼重複新增" });

            if (Result.Messages.Count == 0)
            {
                item = itemsAll.FirstOrDefault(p => p.ResumeMainId == ResumeMainId && p.Id == Id);
                if (item == null)
                {
                    item = new ResumeDrvingLicense();
                    await _appService._resumeDrvingLicenseRepository.InsertAsync(item);
                    item.ResumeMainId = ResumeMainId;
                    item.Status = "1";
                }
                else
                    await _appService._resumeDrvingLicenseRepository.UpdateAsync(item);

                item.DrvingLicenseCode = input.DrvingLicenseCode;
                item.HaveDrvingLicense = input.HaveDrvingLicense;
                item.HaveCar = input.HaveCar;
                item.ExtendedInformation = input.ExtendedInformation ?? "";
                item.DateA = input.DateA;
                item.DateD = input.DateD;
                item.Sort = input.Sort;
                item.Note = input.Note ?? "";

                Result.Data = ObjectMapper.Map<ResumeDrvingLicense, ResumeDrvingLicensesDto>(item);

                //為代碼類加上名稱
                var inputSetShareCode = new SetShareCodeInput();
                inputSetShareCode.ListShareCode = itemsShareCode;
                inputSetShareCode.Data = new List<ResumeDrvingLicensesDto>() { Result.Data };
                var ListColumns = new List<NameCodeStandardDto>();
                ListColumns.Add(new NameCodeStandardDto { GroupCode = "DrvingLicense", Code = "DrvingLicenseCode", Name = "DrvingLicenseName" });
                inputSetShareCode.ListColumns = ListColumns;
                _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<ResumeDrvingLicensesDto>(inputSetShareCode);

                Result.Save = true;
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        /// <summary>
        /// 駕照及交通工具---簡易4欄位
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public virtual async Task<ResultDto<List<ResumeDrvingLicensesDto>>> SaveResumeAsync(SaveResumeDrvingLicensesListInput input)
        {
            var Result = new ResultDto<List<ResumeDrvingLicensesDto>>();
            Result.Data = new List<ResumeDrvingLicensesDto>();
            Result.Version = "2023041301";

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;

            var ResumeMainId = input.ResumeMainId;
            var ListResumeDrvingLicenses = input.ListResumeDrvingLicenses;

            //if (ResumeMainId.IsNullOrEmpty())
            //    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "履歷主檔代碼不可以空白" });

            //必要代碼檢核
            var itemsAllResumeMain = await _appService._resumeMainRepository.GetQueryableAsync();
            var ListResumeMainId = itemsAllResumeMain.Where(p => p.UserMainId == UserMainId).Select(p => p.Id).ToList();

            var inputShareCodeGroup = new ShareCodeGroupInput();
            inputShareCodeGroup.ListGroupCode.Add("DrvingLicense");
            var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);

            var itemsAll = await _appService._resumeDrvingLicenseRepository.GetQueryableAsync();
            var items = itemsAll.Where(p => p.ResumeMainId == ResumeMainId).ToList();

            if (!ListResumeMainId.Contains(ResumeMainId))
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "無法取得履歷主檔資料" });

            //先進行檢查
            foreach (var itemResumeDrvingLicenses in ListResumeDrvingLicenses)
            {
                var Id = itemResumeDrvingLicenses.Id;
                var DrvingLicenseCode = itemResumeDrvingLicenses.DrvingLicenseCode;
                var HaveDrvingLicense = itemResumeDrvingLicenses.HaveDrvingLicense;
                var HaveCar = itemResumeDrvingLicenses.HaveCar;

                if (!itemsShareCode.Any(p => p.GroupCode == "DrvingLicense" && p.Code == DrvingLicenseCode))
                    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "車種類別代碼錯誤" });

                var any = items.Any(p => p.ResumeMainId == ResumeMainId && p.DrvingLicenseCode == DrvingLicenseCode && p.Id != Id);
                if (any)
                    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "車種類別代碼重複新增" });
            }

            if (Result.Messages.Count == 0)
            {
                foreach (var itemResumeDrvingLicenses in ListResumeDrvingLicenses)
                {
                    var Id = itemResumeDrvingLicenses.Id;
                    var DrvingLicenseCode = itemResumeDrvingLicenses.DrvingLicenseCode;
                    var HaveDrvingLicense = itemResumeDrvingLicenses.HaveDrvingLicense;
                    var HaveCar = itemResumeDrvingLicenses.HaveCar;
                    var ExtendedInformation = "";
                    var DateA = new DateTime(1900, 1, 1).Date;
                    var DateD = new DateTime(9999, 1, 1).Date;
                    var Sort = 9;
                    var Note = "";

                    var item = items.FirstOrDefault(p => p.ResumeMainId == ResumeMainId && p.Id == Id);
                    if (item == null)
                    {
                        item = new ResumeDrvingLicense();
                        await _appService._resumeDrvingLicenseRepository.InsertAsync(item);
                        item.ResumeMainId = ResumeMainId;
                        item.Status = "1";
                    }
                    else
                        await _appService._resumeDrvingLicenseRepository.UpdateAsync(item);

                    item.DrvingLicenseCode = DrvingLicenseCode;
                    item.HaveDrvingLicense = HaveDrvingLicense;
                    item.HaveCar = HaveCar;
                    item.ExtendedInformation = ExtendedInformation;
                    item.DateA = DateA;
                    item.DateD = DateD;
                    item.Sort = Sort;
                    item.Note = Note ?? "";

                    var Data = ObjectMapper.Map<ResumeDrvingLicense, ResumeDrvingLicensesDto>(item);
                    Result.Data.Add(Data);

                    Result.Save = true;
                }

                //為代碼類加上名稱
                var inputSetShareCode = new SetShareCodeInput();
                inputSetShareCode.ListShareCode = itemsShareCode;
                inputSetShareCode.Data = Result.Data;
                var ListColumns = new List<NameCodeStandardDto>();
                ListColumns.Add(new NameCodeStandardDto { GroupCode = "DrvingLicense", Code = "DrvingLicenseCode", Name = "DrvingLicenseName" });
                inputSetShareCode.ListColumns = ListColumns;
                _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<ResumeDrvingLicensesDto>(inputSetShareCode);
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        /// <summary>
        /// 駕照及交通工具---用群組新增
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public virtual async Task<ResultDto<List<ResumeDrvingLicensesDto>>> SaveResumeAsync(List<ResumeDrvingLicensesClassificationDto> input)
        {
            var Result = new ResultDto<List<ResumeDrvingLicensesDto>>();
            Result.Data = new List<ResumeDrvingLicensesDto>();
            Result.Version = "2023040901";

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;

            var itemsClassification = input;

            //必要代碼檢核
            var itemsAllResumeMain = await _appService._resumeMainRepository.GetQueryableAsync();
            var ListResumeMainId = itemsAllResumeMain.Where(p => p.UserMainId == UserMainId).Select(p => p.Id).ToList();

            var inputShareCodeGroup = new ShareCodeGroupInput();
            inputShareCodeGroup.ListGroupCode.Add("DrvingLicense");
            var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);

            var itemsAll = await _appService._resumeDrvingLicenseRepository.GetQueryableAsync();
            var items = itemsAll.ToList();

            //先進行檢查
            foreach (var itemClassification in itemsClassification)
            {
                foreach (var itemResumeDrvingLicenses in itemClassification.ListResumeDrvingLicenses)
                {
                    var Id = itemResumeDrvingLicenses.Id;
                    var ResumeMainId = itemResumeDrvingLicenses.ResumeMainId;
                    var DrvingLicenseCode = itemResumeDrvingLicenses.DrvingLicenseCode;
                    var HaveDrvingLicense = itemResumeDrvingLicenses.HaveDrvingLicense;
                    var HaveCar = itemResumeDrvingLicenses.HaveCar;

                    if (!ListResumeMainId.Contains(ResumeMainId))
                        Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "無法取得履歷主檔資料" });

                    if (!itemsShareCode.Any(p => p.GroupCode == "DrvingLicense" && p.Code == DrvingLicenseCode))
                        Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "車種類別代碼錯誤" });

                    var any = items.Any(p => p.ResumeMainId == ResumeMainId && p.DrvingLicenseCode == DrvingLicenseCode && p.Id != Id);
                    if (any)
                        Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "車種類別代碼重複新增" });
                }
            }

            if (Result.Messages.Count == 0)
            {
                foreach (var itemClassification in itemsClassification)
                {
                    foreach (var itemResumeDrvingLicenses in itemClassification.ListResumeDrvingLicenses)
                    {
                        var Id = itemResumeDrvingLicenses.Id;
                        var ResumeMainId = itemResumeDrvingLicenses.ResumeMainId;
                        var DrvingLicenseCode = itemResumeDrvingLicenses.DrvingLicenseCode;
                        var HaveDrvingLicense = itemResumeDrvingLicenses.HaveDrvingLicense;
                        var HaveCar = itemResumeDrvingLicenses.HaveCar;
                        var ExtendedInformation = itemResumeDrvingLicenses.ExtendedInformation;
                        var DateA = itemResumeDrvingLicenses.DateA;
                        var DateD = itemResumeDrvingLicenses.DateD;
                        var Sort = itemResumeDrvingLicenses.Sort;
                        var Note = itemResumeDrvingLicenses.Note;

                        var item = items.FirstOrDefault(p => p.ResumeMainId == ResumeMainId && p.Id == Id);
                        if (item == null)
                        {
                            item = new ResumeDrvingLicense();
                            await _appService._resumeDrvingLicenseRepository.InsertAsync(item);
                            item.ResumeMainId = ResumeMainId;
                            item.Status = "1";
                        }
                        else
                            await _appService._resumeDrvingLicenseRepository.UpdateAsync(item);

                        item.DrvingLicenseCode = DrvingLicenseCode;
                        item.HaveDrvingLicense = HaveDrvingLicense;
                        item.HaveCar = HaveCar;
                        item.ExtendedInformation = "";
                        item.DateA = DateA;
                        item.DateD = DateD;
                        item.Sort = Sort;
                        item.Note = Note ?? "";

                        var Data = ObjectMapper.Map<ResumeDrvingLicense, ResumeDrvingLicensesDto>(item);
                        Result.Data.Add(Data);

                        Result.Save = true;
                    }
                }

                //為代碼類加上名稱
                var inputSetShareCode = new SetShareCodeInput();
                inputSetShareCode.ListShareCode = itemsShareCode;
                inputSetShareCode.Data = Result.Data;
                var ListColumns = new List<NameCodeStandardDto>();
                ListColumns.Add(new NameCodeStandardDto { GroupCode = "DrvingLicense", Code = "DrvingLicenseCode", Name = "DrvingLicenseName" });
                inputSetShareCode.ListColumns = ListColumns;
                _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<ResumeDrvingLicensesDto>(inputSetShareCode);
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        /// <summary>
        /// 駕照及交通工具---初始化
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public virtual async Task<ResultDto<InsertResumeDrvingLicenseInitDto>> InsertResumeDrvingLicenseInitAsync(InsertResumeDrvingLicenseInitInput input)
        {
            var Result = new ResultDto<InsertResumeDrvingLicenseInitDto>();
            Result.Data = new InsertResumeDrvingLicenseInitDto();
            Result.Version = "2023040301";

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;

            //取得交通工具的代碼檔
            //為每一個代碼檔新增預設值
            //每次叫用這個方法時，都會重新將預設值設定為false

            var ResumeMainId = input.ResumeMainId;

            //if (ResumeMainId.IsNullOrEmpty())
            //    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "履歷主檔代碼不可以空白" });

            var anyResumeMain = await _appService._resumeMainRepository.AnyAsync(p => p.UserMainId == UserMainId && p.Id == ResumeMainId);
            if (!anyResumeMain)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "無法取得履歷主檔資料" });

            if (Result.Messages.Count == 0)
            {
                var inputShareCodeGroup = new ShareCodeGroupInput();
                inputShareCodeGroup.ListGroupCode.Add("DrvingLicense");
                var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);
                itemsShareCode = itemsShareCode.Where(p => p.ParentCode.Length > 0).ToList();

                var itemsAll = await _appService._resumeDrvingLicenseRepository.GetQueryableAsync();
                var items = itemsAll.Where(p => p.ResumeMainId == ResumeMainId).ToList();
                var itemsTemp = new List<ResumeDrvingLicense>();
                foreach (var itemShareCode in itemsShareCode)
                {
                    var DrvingLicenseCode = itemShareCode.Code;
                    var item = items.FirstOrDefault(p => p.DrvingLicenseCode == DrvingLicenseCode);
                    if (item == null)
                    {
                        item = new ResumeDrvingLicense();
                        await _appService._resumeDrvingLicenseRepository.InsertAsync(item);
                        item.ResumeMainId = ResumeMainId;
                        item.Status = "1";
                    }
                    else
                        await _appService._resumeDrvingLicenseRepository.UpdateAsync(item);

                    item.DrvingLicenseCode = DrvingLicenseCode;
                    item.HaveDrvingLicense = false;
                    item.HaveCar = false;
                    item.ExtendedInformation = "";
                    item.DateA = new DateTime(1900, 1, 1).Date;
                    item.DateD = new DateTime(9999, 12, 31).Date;
                    item.Sort = 9;
                    item.Note = "";

                    itemsTemp.Add(item);
                }

                Result.Data.ListResumeDrvingLicenses = ObjectMapper.Map<List<ResumeDrvingLicense>, List<ResumeDrvingLicensesDto>>(itemsTemp);

                //為代碼類加上名稱
                var inputSetShareCode = new SetShareCodeInput();
                inputSetShareCode.ListShareCode = itemsShareCode;
                inputSetShareCode.Data = Result.Data.ListResumeDrvingLicenses;
                var ListColumns = new List<NameCodeStandardDto>();
                ListColumns.Add(new NameCodeStandardDto { GroupCode = "DrvingLicense", Code = "DrvingLicenseCode", Name = "DrvingLicenseName" });
                inputSetShareCode.ListColumns = ListColumns;
                _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<ResumeDrvingLicensesDto>(inputSetShareCode);

                Result.Save = true;
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        /// <summary>
        /// 駕照及交通工具---註冊使用
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public virtual async Task<ResultDto<InsertResumeDrvingLicenseInitDto>> InsertResumeDrvingLicenseAsync(InsertResumeDrvingLicenseInput input)
        {
            var Result = new ResultDto<InsertResumeDrvingLicenseInitDto>();
            Result.Data = new InsertResumeDrvingLicenseInitDto();
            Result.Version = "2023041301";

            //取得交通工具的代碼檔
            //為每一個代碼檔新增預設值
            //每次叫用這個方法時，都會重新將預設值設定為false

            var ResumeMainId = input.ResumeMainId;
            var TenantId = input.TenantId;

            //if (ResumeMainId.IsNullOrEmpty())
            //    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "履歷主檔代碼不可以空白" });

            if (Result.Messages.Count == 0)
            {
                var inputShareCodeGroup = new ShareCodeGroupInput();
                inputShareCodeGroup.GroupCode = "DrvingLicense";
                var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);
                itemsShareCode = itemsShareCode.Where(p => p.ParentCode.Length > 0).ToList();

                var itemsAll = await _appService._resumeDrvingLicenseRepository.GetQueryableAsync();
                var items = itemsAll.Where(p => p.ResumeMainId == ResumeMainId).ToList();
                var itemsTemp = new List<ResumeDrvingLicense>();
                foreach (var itemShareCode in itemsShareCode)
                {
                    var DrvingLicenseCode = itemShareCode.Code;
                    var item = items.FirstOrDefault(p => p.DrvingLicenseCode == DrvingLicenseCode);
                    if (item == null)
                    {
                        item = new ResumeDrvingLicense();
                        await _appService._resumeDrvingLicenseRepository.InsertAsync(item);
                        item.TenantId = TenantId;
                        item.ResumeMainId = ResumeMainId;
                        item.Status = "1";
                    }
                    else
                        await _appService._resumeDrvingLicenseRepository.UpdateAsync(item);

                    item.DrvingLicenseCode = DrvingLicenseCode;
                    item.HaveDrvingLicense = false;
                    item.HaveCar = false;
                    item.ExtendedInformation = "";
                    item.DateA = new DateTime(1900, 1, 1).Date;
                    item.DateD = new DateTime(9999, 12, 31).Date;
                    item.Sort = 9;
                    item.Note = "";

                    itemsTemp.Add(item);
                }

                Result.Data.ListResumeDrvingLicenses = ObjectMapper.Map<List<ResumeDrvingLicense>, List<ResumeDrvingLicensesDto>>(itemsTemp);

                Result.Save = true;
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<ResumeRecommendersDto>> SaveResumeAsync(ResumeRecommendersDto input)
        {
            var Result = new ResultDto<ResumeRecommendersDto>();
            Result.Data = new ResumeRecommendersDto();
            Result.Version = "2023041301";

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;

            var ResumeMainId = input.ResumeMainId;
            var Id = input.Id;  //空白時當做新增
            var Name = input.Name ?? "";

            //必要代碼檢核
            if (Name.IsNullOrEmpty())
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "姓名不可以空白" });

            //if (ResumeMainId.IsNullOrEmpty())
            //    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "履歷主檔代碼不可以空白" });

            var anyResumeMain = await _appService._resumeMainRepository.AnyAsync(p => p.UserMainId == UserMainId && p.Id == ResumeMainId);
            if (!anyResumeMain)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "無法取得履歷主檔資料" });

            if (Result.Messages.Count == 0)
            {
                var itemsAll = await _appService._resumeRecommenderRepository.GetQueryableAsync();
                var item = itemsAll.FirstOrDefault(p => p.ResumeMainId == ResumeMainId && p.Id == Id);
                if (item == null)
                {
                    item = new ResumeRecommender();
                    await _appService._resumeRecommenderRepository.InsertAsync(item);
                    item.ResumeMainId = ResumeMainId;
                    item.Status = "1";
                }
                else
                    await _appService._resumeRecommenderRepository.UpdateAsync(item);

                item.Name = input.Name ?? "";
                item.CompanyName = input.CompanyName ?? "";
                item.JobName = input.JobName ?? "";
                item.MobilePhone = input.MobilePhone ?? "";
                item.OfficePhone = input.OfficePhone ?? "";
                item.Email = input.Email ?? "";
                item.ExtendedInformation = input.ExtendedInformation ?? "";
                item.DateA = input.DateA;
                item.DateD = input.DateD;
                item.Sort = input.Sort;
                item.Note = input.Note ?? "";

                Result.Data = ObjectMapper.Map<ResumeRecommender, ResumeRecommendersDto>(item);

                Result.Save = true;
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<ResumeLanguagesDto>> SaveResumeAsync(ResumeLanguagesDto input)
        {
            var Result = new ResultDto<ResumeLanguagesDto>();
            Result.Data = new ResumeLanguagesDto();
            Result.Version = "2023041301";

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;

            var ResumeMainId = input.ResumeMainId;
            var Id = input.Id;  //空白時當做新增
            var LanguageCategoryCode = input.LanguageCategoryCode ?? "";
            var LevelSayCode = input.LevelSayCode ?? "";
            var LevelListenCode = input.LevelListenCode ?? "";
            var LevelReadCode = input.LevelReadCode ?? "";
            var LevelWriteCode = input.LevelWriteCode ?? "";

            //必要代碼檢核
            //if (ResumeMainId.IsNullOrEmpty())
            //    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "履歷主檔代碼不可以空白" });

            var anyResumeMain = await _appService._resumeMainRepository.AnyAsync(p => p.UserMainId == UserMainId && p.Id == ResumeMainId);
            if (!anyResumeMain)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "無法取得履歷主檔資料" });

            var inputShareCodeGroup = new ShareCodeGroupInput();
            inputShareCodeGroup.ListGroupCode.Add("LanguageCategory");
            inputShareCodeGroup.ListGroupCode.Add("LanguageLevel");
            var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);

            if (!itemsShareCode.Any(p => p.GroupCode == "LanguageCategory" && p.Code == LanguageCategoryCode))
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "語言類別代碼錯誤" });

            if (!itemsShareCode.Any(p => p.GroupCode == "LanguageLevel" && p.Code == LevelSayCode))
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "說-語言等級代碼錯誤" });

            if (!itemsShareCode.Any(p => p.GroupCode == "LanguageLevel" && p.Code == LevelListenCode))
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "聽-語言等級代碼錯誤" });

            if (!itemsShareCode.Any(p => p.GroupCode == "LanguageLevel" && p.Code == LevelReadCode))
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "讀-語言等級代碼錯誤" });

            if (!itemsShareCode.Any(p => p.GroupCode == "LanguageLevel" && p.Code == LevelWriteCode))
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "寫-語言等級代碼錯誤" });

            var itemsAll = await _appService._resumeLanguageRepository.GetQueryableAsync();
            var itemAny = itemsAll.Any(p => p.ResumeMainId == ResumeMainId && p.LanguageCategoryCode == LanguageCategoryCode && p.Id != Id);
            if (itemAny)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "語言類別代碼重複新增" });

            if (Result.Messages.Count == 0)
            {
                var item = itemsAll.FirstOrDefault(p => p.ResumeMainId == ResumeMainId && p.Id == Id);

                if (item == null)
                {
                    item = new ResumeLanguage();
                    await _appService._resumeLanguageRepository.InsertAsync(item);
                    item.ResumeMainId = ResumeMainId;
                    item.Status = "1";
                }
                else
                    await _appService._resumeLanguageRepository.UpdateAsync(item);

                item.LanguageCategoryCode = LanguageCategoryCode;
                item.LevelSayCode = input.LevelSayCode ?? "";
                item.LevelListenCode = input.LevelListenCode ?? "";
                item.LevelReadCode = input.LevelReadCode ?? "";
                item.LevelWriteCode = input.LevelWriteCode ?? "";
                item.ExtendedInformation = input.ExtendedInformation ?? "";
                item.DateA = input.DateA;
                item.DateD = input.DateD;
                item.Sort = input.Sort;
                item.Note = input.Note ?? "";

                Result.Data = ObjectMapper.Map<ResumeLanguage, ResumeLanguagesDto>(item);

                //為代碼類加上名稱
                var inputSetShareCode = new SetShareCodeInput();
                inputSetShareCode.ListShareCode = itemsShareCode;
                inputSetShareCode.Data = new List<ResumeLanguagesDto>() { Result.Data };
                var ListColumns = new List<NameCodeStandardDto>();
                ListColumns.Add(new NameCodeStandardDto { GroupCode = "LanguageCategory", Code = "LanguageCategoryCode", Name = "LanguageCategoryName" });
                ListColumns.Add(new NameCodeStandardDto { GroupCode = "LanguageLevel", Code = "LevelSayCode", Name = "LevelSayName" });
                ListColumns.Add(new NameCodeStandardDto { GroupCode = "LanguageLevel", Code = "LevelListenCode", Name = "LevelListenName" });
                ListColumns.Add(new NameCodeStandardDto { GroupCode = "LanguageLevel", Code = "LevelReadCode", Name = "LevelReadName" });
                ListColumns.Add(new NameCodeStandardDto { GroupCode = "LanguageLevel", Code = "LevelWriteCode", Name = "LevelWriteName" });
                inputSetShareCode.ListColumns = ListColumns;
                _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<ResumeLanguagesDto>(inputSetShareCode);

                Result.Save = true;
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<ResumeSkillsDto>> SaveResumeAsync(ResumeSkillsDto input)
        {
            var Result = new ResultDto<ResumeSkillsDto>();
            Result.Data = new ResumeSkillsDto();
            Result.Version = "2023041301";

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;

            var ResumeMainId = input.ResumeMainId;
            var Id = input.Id;  //空白時當做新增
            var ChineseTypingCode = input.ChineseTypingCode ?? "";

            //必要代碼檢核
            //if (ResumeMainId.Length == 0)
            //    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "履歷主檔代碼不可以空白" });

            var anyResumeMain = await _appService._resumeMainRepository.AnyAsync(p => p.UserMainId == UserMainId && p.Id == ResumeMainId);
            if (!anyResumeMain)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "無法取得履歷主檔資料" });

            var inputShareCodeGroup = new ShareCodeGroupInput();
            inputShareCodeGroup.ListGroupCode.Add("ChineseTyping");
            var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);

            if (!itemsShareCode.Any(p => p.GroupCode == "ChineseTyping" && p.Code == ChineseTypingCode))
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "輸入法代碼錯誤" });

            if (Result.Messages.Count == 0)
            {
                var itemsAll = await _appService._resumeSkillRepository.GetQueryableAsync();
                var item = itemsAll.FirstOrDefault(p => p.ResumeMainId == ResumeMainId && p.Id == Id);
                if (item == null)
                {
                    item = new ResumeSkill();
                    await _appService._resumeSkillRepository.InsertAsync(item);
                    item.ResumeMainId = ResumeMainId;
                    item.Status = "1";
                }
                else
                    await _appService._resumeSkillRepository.UpdateAsync(item);

                item.ComputerSkills = input.ComputerSkills;
                item.ComputerSkillsEtc = input.ComputerSkillsEtc;
                item.ChineseTypingSpeed = input.ChineseTypingSpeed;
                item.ChineseTypingCode = input.ChineseTypingCode;
                item.EnglishTypingSpeed = input.EnglishTypingSpeed;
                item.ProfessionalLicense = input.ProfessionalLicense;
                item.ProfessionalLicenseEtc = input.ProfessionalLicenseEtc;
                item.WorkSkills = input.WorkSkills;
                item.WorkSkillsEtc = input.WorkSkillsEtc;
                item.ExtendedInformation = input.ExtendedInformation;
                item.DateA = input.DateA;
                item.DateD = input.DateD;
                item.Sort = input.Sort;
                item.Note = input.Note;

                Result.Data = ObjectMapper.Map<ResumeSkill, ResumeSkillsDto>(item);

                //為代碼類加上名稱
                var inputSetShareCode = new SetShareCodeInput();
                inputSetShareCode.ListShareCode = itemsShareCode;
                inputSetShareCode.Data = new List<ResumeSkillsDto>() { Result.Data };
                var ListColumns = new List<NameCodeStandardDto>();
                ListColumns.Add(new NameCodeStandardDto { GroupCode = "ChineseTyping", Code = "ChineseTypingCode", Name = "ChineseTypingName" });
                inputSetShareCode.ListColumns = ListColumns;
                _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<ResumeSkillsDto>(inputSetShareCode);

                Result.Save = true;
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<ResumeDependentssDto>> SaveResumeAsync(ResumeDependentssDto input)
        {
            var Result = new ResultDto<ResumeDependentssDto>();
            Result.Data = new ResumeDependentssDto();
            Result.Version = "2023041301";

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;

            var ResumeMainId = input.ResumeMainId;
            var Id = input.Id; //空白時當做新增
            var KinshipCode = input.KinshipCode ?? "";

            //必要代碼檢核
            //if (ResumeMainId.IsNullOrEmpty())
            //    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "履歷主檔代碼不可以空白" });

            var anyResumeMain = await _appService._resumeMainRepository.AnyAsync(p => p.UserMainId == UserMainId && p.Id == ResumeMainId);
            if (!anyResumeMain)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "無法取得履歷主檔資料" });

            var inputShareCodeGroup = new ShareCodeGroupInput();
            inputShareCodeGroup.ListGroupCode.Add("Kinship");
            var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);

            if (!itemsShareCode.Any(p => p.GroupCode == "Kinship" && p.Code == KinshipCode))
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "眷屬關係代碼錯誤" });

            if (Result.Messages.Count == 0)
            {
                var itemsAll = await _appService._resumeDependentsRepository.GetQueryableAsync();
                var item = itemsAll.FirstOrDefault(p => p.ResumeMainId == ResumeMainId && p.Id == Id);
                if (item == null)
                {
                    item = new ResumeDependents();
                    await _appService._resumeDependentsRepository.InsertAsync(item);
                    item.ResumeMainId = ResumeMainId;
                    item.Status = "1";
                }
                else
                    await _appService._resumeDependentsRepository.UpdateAsync(item);

                item.Name = input.Name;
                item.IdentityNo = input.IdentityNo;
                item.KinshipCode = input.KinshipCode;
                item.BirthDate = input.BirthDate;
                item.Address = input.Address;
                item.MobilePhone = input.MobilePhone;
                item.ExtendedInformation = input.ExtendedInformation;
                item.DateA = input.DateA;
                item.DateD = input.DateD;
                item.Sort = input.Sort;
                item.Note = input.Note;

                Result.Data = ObjectMapper.Map<ResumeDependents, ResumeDependentssDto>(item);

                //為代碼類加上名稱
                var inputSetShareCode = new SetShareCodeInput();
                inputSetShareCode.ListShareCode = itemsShareCode;
                inputSetShareCode.Data = new List<ResumeDependentssDto>() { Result.Data };
                var ListColumns = new List<NameCodeStandardDto>();
                ListColumns.Add(new NameCodeStandardDto { GroupCode = "Kinship", Code = "KinshipCode", Name = "KinshipName" });
                inputSetShareCode.ListColumns = ListColumns;
                _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<ResumeDependentssDto>(inputSetShareCode);

                Result.Save = true;
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<ResumeEducationssDto>> SaveResumeAsync(ResumeEducationssDto input)
        {
            var Result = new ResultDto<ResumeEducationssDto>();
            Result.Data = new ResumeEducationssDto();
            Result.Version = "2023041301";

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;

            var ResumeMainId = input.ResumeMainId;
            var Id = input.Id;  //空白時當做新增
            var SchoolCode = input.SchoolCode ?? "";
            var EducationLevelCode = input.EducationLevelCode ?? "";
            var MajorDepartmentCategoryCode = input.MajorDepartmentCategoryCode ?? "";
            var MinorDepartmentCategoryCode = input.MinorDepartmentCategoryCode ?? "";
            var GraduationCode = input.GraduationCode ?? "";
            var CountryCode = input.CountryCode ?? "";

            //必要代碼檢核
            if (SchoolCode.IsNullOrEmpty())
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "學校名稱不可空白" });

            //if (ResumeMainId.IsNullOrEmpty())
            //    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "履歷主檔代碼不可以空白" });

            var anyResumeMain = await _appService._resumeMainRepository.AnyAsync(p => p.UserMainId == UserMainId && p.Id == ResumeMainId);
            if (!anyResumeMain)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "無法取得履歷主檔資料" });

            var inputShareCodeGroup = new ShareCodeGroupInput();
            inputShareCodeGroup.ListGroupCode.Add("EducationLevel");
            inputShareCodeGroup.ListGroupCode.Add("DepartmentCategory");
            inputShareCodeGroup.ListGroupCode.Add("Graduation");
            inputShareCodeGroup.ListGroupCode.Add("Country");
            var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);

            if (!itemsShareCode.Any(p => p.GroupCode == "EducationLevel" && p.Code == EducationLevelCode))
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "教育程度代碼錯誤" });

            //if (!itemsShareCode.Any(p => p.GroupCode == "DepartmentCategory" && p.Code == MajorDepartmentCategoryCode))
            //    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "科系類別代碼錯誤(主修)" });

            //if (!MinorDepartmentCategoryCode.IsNullOrEmpty())
            //    if (!itemsShareCode.Any(p => p.GroupCode == "DepartmentCategory" && p.Code == MinorDepartmentCategoryCode))
            //        Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "科系類別代碼錯誤(第二主修)" });

            if (!itemsShareCode.Any(p => p.GroupCode == "Graduation" && p.Code == GraduationCode))
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "畢業類別代碼錯誤" });

            if (!itemsShareCode.Any(p => p.GroupCode == "Country" && p.Code == CountryCode))
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "國家代碼錯誤" });

            if (Result.Messages.Count == 0)
            {
                var itemsAll = await _appService._resumeEducationsRepository.GetQueryableAsync();
                var item = itemsAll.FirstOrDefault(p => p.ResumeMainId == ResumeMainId && p.Id == Id);
                if (item == null)
                {
                    item = new ResumeEducations();
                    await _appService._resumeEducationsRepository.InsertAsync(item);
                    item.ResumeMainId = ResumeMainId;
                    item.Status = "1";
                }
                else
                    await _appService._resumeEducationsRepository.UpdateAsync(item);

                item.EducationLevelCode = input.EducationLevelCode;
                item.SchoolCode = input.SchoolCode;
                item.SchoolName = input.SchoolCode; //先反正規化
                item.Night = input.Night;
                item.Working = input.Working;
                item.MajorDepartmentName = input.MajorDepartmentName;
                item.MajorDepartmentCategoryCode = input.MajorDepartmentCategoryCode;
                item.MinorDepartmentName = input.MinorDepartmentName;
                item.MinorDepartmentCategoryCode = input.MinorDepartmentCategoryCode;
                item.GraduationCode = input.GraduationCode;
                item.Domestic = input.Domestic;
                item.CountryCode = input.CountryCode;
                item.ExtendedInformation = input.ExtendedInformation;
                item.DateA = input.DateA;
                item.DateD = input.DateD;
                item.Sort = input.Sort;
                item.Note = input.Note;

                Result.Data = ObjectMapper.Map<ResumeEducations, ResumeEducationssDto>(item);

                //為代碼類加上名稱
                var inputSetShareCode = new SetShareCodeInput();
                inputSetShareCode.ListShareCode = itemsShareCode;
                inputSetShareCode.Data = new List<ResumeEducationssDto>() { Result.Data };
                var ListColumns = new List<NameCodeStandardDto>();
                ListColumns.Add(new NameCodeStandardDto { GroupCode = "EducationLevel", Code = "EducationLevelCode", Name = "EducationLevelName" });
                //ListColumns.Add(new NameCodeStandardDto { GroupCode = "DepartmentCategory", Code = "MajorDepartmentCategoryCode", Name = "MajorDepartmentCategoryName" });
                //ListColumns.Add(new NameCodeStandardDto { GroupCode = "DepartmentCategory", Code = "MinorDepartmentCategoryCode", Name = "MinorDepartmentCategoryName" });
                ListColumns.Add(new NameCodeStandardDto { GroupCode = "Graduation", Code = "GraduationCode", Name = "GraduationName" });
                ListColumns.Add(new NameCodeStandardDto { GroupCode = "Country", Code = "CountryCode", Name = "CountryName" });
                inputSetShareCode.ListColumns = ListColumns;
                _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<ResumeEducationssDto>(inputSetShareCode);

                Result.Save = true;
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<ResumeExperiencessDto>> SaveResumeAsync(ResumeExperiencessDto input)
        {
            var Result = new ResultDto<ResumeExperiencessDto>();
            Result.Data = new ResumeExperiencessDto();
            Result.Version = "2023041301";

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;

            var ResumeMainId = input.ResumeMainId;
            var Id = input.Id; //空白時當做新增
            var WorkNatureCode = input.WorkNatureCode ?? "";
            var IndustryCategoryCode = input.IndustryCategoryCode ?? "";
            var WorkPlaceCode = input.WorkPlaceCode ?? "";
            var SalaryPayTypeCode = input.SalaryPayTypeCode ?? "";
            var CurrencyTypeCode = input.CurrencyTypeCode ?? "TWD";
            var CompanyScaleCode = input.CompanyScaleCode ?? "";
            var CompanyManagementNumberCode = input.CompanyManagementNumberCode ?? "";

            //必要代碼檢核
            //if (ResumeMainId.IsNullOrEmpty())
            //    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "履歷主檔代碼不可以空白" });

            var anyResumeMain = await _appService._resumeMainRepository.AnyAsync(p => p.UserMainId == UserMainId && p.Id == ResumeMainId);
            if (!anyResumeMain)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "無法取得履歷主檔資料" });

            var inputShareCodeGroup = new ShareCodeGroupInput();
            inputShareCodeGroup.ListGroupCode.Add("WorkNature");
            //inputShareCodeGroup.ListGroupCode.Add("IndustryCategory");
            //inputShareCodeGroup.ListGroupCode.Add("WorkPlace");
            inputShareCodeGroup.ListGroupCode.Add("SalaryPayType");
            inputShareCodeGroup.ListGroupCode.Add("CurrencyType");
            inputShareCodeGroup.ListGroupCode.Add("CompanyScale");
            inputShareCodeGroup.ListGroupCode.Add("CompanyManagementNumber");
            var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);

            if (!itemsShareCode.Any(p => p.GroupCode == "WorkNature" && p.Code == WorkNatureCode))
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "工作性質代碼錯誤" });

            //if (!itemsShareCode.Any(p => p.GroupCode == "IndustryCategory" && p.Code == IndustryCategoryCode))
            //    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "產業類別代碼錯誤" });

            //if (!itemsShareCode.Any(p => p.GroupCode == "WorkPlace" && p.Code == WorkPlaceCode))
            //    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "工作地點代碼錯誤" });

            if (!itemsShareCode.Any(p => p.GroupCode == "SalaryPayType" && p.Code == SalaryPayTypeCode))
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "薪資發放分類代碼錯誤" });

            if (!itemsShareCode.Any(p => p.GroupCode == "CurrencyType" && p.Code == CurrencyTypeCode))
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "幣別代碼錯誤" });

            if (!itemsShareCode.Any(p => p.GroupCode == "CompanyScale" && p.Code == CompanyScaleCode))
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "公司規模代碼錯誤" });

            if (!itemsShareCode.Any(p => p.GroupCode == "CompanyManagementNumber" && p.Code == CompanyManagementNumberCode))
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "管理人數代碼錯誤" });

            if (Result.Messages.Count == 0)
            {
                var itemsAll = await _appService._resumeExperiencesRepository.GetQueryableAsync();
                var item = itemsAll.FirstOrDefault(p => p.ResumeMainId == ResumeMainId && p.Id == Id);
                if (item == null)
                {
                    item = new ResumeExperiences();
                    await _appService._resumeExperiencesRepository.InsertAsync(item);
                    item.ResumeMainId = ResumeMainId;
                    item.Status = "1";
                }
                else
                    await _appService._resumeExperiencesRepository.UpdateAsync(item);

                item.Name = input.Name;
                item.WorkNatureCode = input.WorkNatureCode;
                item.HideCompanyName = input.HideCompanyName;
                item.IndustryCategoryCode = input.IndustryCategoryCode; //json
                item.JobName = input.JobName;
                item.JobType = input.JobType;   //json
                //item.JobType =   JsonSerializer.Serialize(input.ListJobType, new JsonSerializerOptions
                //{
                //    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping, // 中文字不編碼
                //    WriteIndented = true  // 換行與縮排
                //});
                item.Working = input.Working;
                item.WorkPlaceCode = input.WorkPlaceCode;
                item.HideWorkSalary = input.HideWorkSalary;
                item.SalaryPayTypeCode = input.SalaryPayTypeCode;
                item.CurrencyTypeCode = input.CurrencyTypeCode ?? "TWD";
                item.Salary1 = input.Salary1;
                item.Salary2 = input.Salary2;
                item.CompanyScaleCode = input.CompanyScaleCode;
                item.CompanyManagementNumberCode = input.CompanyManagementNumberCode;
                item.ExtendedInformation = input.ExtendedInformation;
                item.DateA = input.DateA;
                item.DateD = input.DateD;
                item.Sort = input.Sort;
                item.Note = input.Note;

                Result.Data = ObjectMapper.Map<ResumeExperiences, ResumeExperiencessDto>(item);

                //try
                //{
                //    Result.Data.ListJobType = JsonSerializer.Deserialize<List<ResumeExperiencesJobType>>(item.JobType);
                //    Result.Data.JobType = "";
                //}
                //catch { }

                //為代碼類加上名稱
                var inputSetShareCode = new SetShareCodeInput();
                inputSetShareCode.ListShareCode = itemsShareCode;
                inputSetShareCode.Data = new List<ResumeExperiencessDto>() { Result.Data };
                var ListColumns = new List<NameCodeStandardDto>();
                ListColumns.Add(new NameCodeStandardDto { GroupCode = "WorkNature", Code = "WorkNatureCode", Name = "WorkNatureName" });
                //ListColumns.Add(new NameCodeStandardDto { GroupCode = "IndustryCategory", Code = "IndustryCategoryCode", Name = "IndustryCategoryName" });
                //ListColumns.Add(new NameCodeStandardDto { GroupCode = "WorkPlace", Code = "WorkPlaceCode", Name = "WorkPlaceName" });
                ListColumns.Add(new NameCodeStandardDto { GroupCode = "SalaryPayType", Code = "SalaryPayTypeCode", Name = "SalaryPayTypeName" });
                ListColumns.Add(new NameCodeStandardDto { GroupCode = "CompanyScale", Code = "CompanyScaleCode", Name = "CompanyScaleName" });
                ListColumns.Add(new NameCodeStandardDto { GroupCode = "CompanyManagementNumber", Code = "CompanyManagementNumberCode", Name = "CompanyManagementNumberName" });
                inputSetShareCode.ListColumns = ListColumns;
                _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<ResumeExperiencessDto>(inputSetShareCode);

                Result.Save = true;
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<ResumeWorkssDto>> SaveResumeAsync(ResumeWorkssDto input)
        {
            var Result = new ResultDto<ResumeWorkssDto>();
            Result.Data = new ResumeWorkssDto();
            Result.Version = "2023041301";

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;

            var ResumeMainId = input.ResumeMainId;
            var Id = input.Id;  //空白時當做新增

            //必要代碼檢核
            //if (ResumeMainId.IsNullOrEmpty())
            //    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "履歷主檔代碼不可以空白" });

            var anyResumeMain = await _appService._resumeMainRepository.AnyAsync(p => p.UserMainId == UserMainId && p.Id == ResumeMainId);
            if (!anyResumeMain)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "無法取得履歷主檔資料" });

            if (Result.Messages.Count == 0)
            {
                var itemsAll = await _appService._resumeWorksRepository.GetQueryableAsync();
                var item = itemsAll.FirstOrDefault(p => p.ResumeMainId == ResumeMainId && p.Id == Id);
                if (item == null)
                {
                    item = new ResumeWorks();
                    await _appService._resumeWorksRepository.InsertAsync(item);
                    item.ResumeMainId = ResumeMainId;
                    item.Status = "1";
                }
                else
                    await _appService._resumeWorksRepository.UpdateAsync(item);

                item.Name = input.Name;
                item.Link = input.Link;
                item.ExtendedInformation = input.ExtendedInformation;
                item.DateA = input.DateA;
                item.DateD = input.DateD;
                item.Sort = input.Sort;
                item.Note = input.Note;

                Result.Data = ObjectMapper.Map<ResumeWorks, ResumeWorkssDto>(item);

                Result.Save = true;
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<DeleteDto>> DeleteResumeAsync(DeleteResumeInput input)
        {
            var Result = new ResultDto<DeleteDto>();
            Result.Data = new DeleteDto();
            Result.Version = "2023032701";

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;

            var TableName = input.TableName ?? "";
            var ResumeMainId = input.ResumeMainId;
            var Id = input.Id;

            //必要代碼檢核
            //if (Id.IsNullOrEmpty())
            //    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "代碼不可以空白" });

            var itemResumeMain = await _appService._resumeMainRepository.FirstOrDefaultAsync(p => p.UserMainId == UserMainId && p.Id == ResumeMainId);
            if (itemResumeMain == null)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "無法取得履歷主檔資料" });

            if (Result.Messages.Count == 0)
            {
                switch (TableName)
                {
                    case "ResumeMain":
                        itemResumeMain.Status = "2";
                        await _appService._resumeMainRepository.UpdateAsync(itemResumeMain);
                        //應該要連同其它資料表一起刪除 20230627
                        Result.Data.Pass = true;
                        break;
                    case "ResumeCommunication":
                        {
                            var item = (await _appService._resumeCommunicationRepository.GetAsync(Id));
                            if (item != null)
                            {
                                item.Status = "2";
                                await _appService._resumeCommunicationRepository.DeleteAsync(item);
                                Result.Data.Pass = true;
                            }
                        }
                        break;
                    case "ResumeDrvingLicense":
                        {
                            var item = (await _appService._resumeDrvingLicenseRepository.GetAsync(Id));
                            if (item != null)
                            {
                                item.Status = "2";
                                await _appService._resumeDrvingLicenseRepository.DeleteAsync(item);
                                Result.Data.Pass = true;
                            }
                        }
                        break;
                    case "ResumeRecommender":
                        {
                            var item = (await _appService._resumeRecommenderRepository.GetAsync(Id));
                            if (item != null)
                            {
                                item.Status = "2";
                                await _appService._resumeRecommenderRepository.DeleteAsync(item);
                                Result.Data.Pass = true;
                            }
                        }
                        break;
                    case "ResumeLanguage":
                        {
                            var item = (await _appService._resumeLanguageRepository.GetAsync(Id));
                            if (item != null)
                            {
                                item.Status = "2";
                                await _appService._resumeLanguageRepository.DeleteAsync(item);
                                Result.Data.Pass = true;
                            }
                        }
                        break;
                    case "ResumeSkill":
                        {
                            var item = (await _appService._resumeSkillRepository.GetAsync(Id));
                            if (item != null)
                            {
                                item.Status = "2";
                                await _appService._resumeSkillRepository.DeleteAsync(item);
                                Result.Data.Pass = true;
                            }
                        }
                        break;
                    case "ResumeDependents":
                        {
                            var item = (await _appService._resumeDependentsRepository.GetAsync(Id));
                            if (item != null)
                            {
                                item.Status = "2";
                                await _appService._resumeDependentsRepository.DeleteAsync(item);
                                Result.Data.Pass = true;
                            }
                        }
                        break;
                    case "ResumeEducations":
                        {
                            var item = (await _appService._resumeEducationsRepository.GetAsync(Id));
                            if (item != null)
                            {
                                item.Status = "2";
                                await _appService._resumeEducationsRepository.DeleteAsync(item);
                                Result.Data.Pass = true;
                            }
                        }
                        break;
                    case "ResumeExperiences":
                        {
                            var item = (await _appService._resumeExperiencesRepository.GetAsync(Id));
                            if (item != null)
                            {
                                item.Status = "2";
                                await _appService._resumeExperiencesRepository.DeleteAsync(item);
                                Result.Data.Pass = true;
                            }
                        }
                        break;
                    case "ResumeWorks":
                        {
                            var item = (await _appService._resumeWorksRepository.GetAsync(Id));
                            if (item != null)
                            {
                                item.Status = "2";
                                await _appService._resumeWorksRepository.DeleteAsync(item);
                                Result.Data.Pass = true;
                            }
                        }
                        break;
                    case "ResumeSnapshot":
                        {
                            var item = (await _appService._resumeSnapshotRepository.GetAsync(Id));
                            if (item != null)
                            {
                                item.Status = "2";
                                await _appService._resumeSnapshotRepository.DeleteAsync(item);
                                Result.Data.Pass = true;
                            }
                        }
                        break;
                }

                Result.Save = true;
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<List<ResumeMainsDto>>> GetResumeMainsListAsync(ResumeInput input)
        {
            var Result = new ResultDto<List<ResumeMainsDto>>();
            Result.Data = new List<ResumeMainsDto>();
            Result.Version = "2023052201";

            var DateNow = DateTime.Now;

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;

            var ResumeMainId = input.ResumeMainId;

            var itemsAll = await _appService._resumeMainRepository.GetQueryableAsync();
            itemsAll = from c in itemsAll
                       where c.UserMainId == UserMainId
                       && c.Status == "1"
                       orderby c.Main descending, c.Sort
                       select c;

            var items = await AsyncExecuter.ToListAsync(itemsAll);
            if (items.Count > 0)
            {
                //取得履歷所需要的代碼資料-為了加速
                var inputShareCodeGroup = new ShareCodeGroupInput();
                inputShareCodeGroup.ListGroupCode.Add("Sex");
                inputShareCodeGroup.ListGroupCode.Add("Blood");
                inputShareCodeGroup.ListGroupCode.Add("Marriage");
                inputShareCodeGroup.ListGroupCode.Add("PlaceOfBirth");
                inputShareCodeGroup.ListGroupCode.Add("Military");
                inputShareCodeGroup.ListGroupCode.Add("DisabilityCategory");
                inputShareCodeGroup.ListGroupCode.Add("Nationality");
                inputShareCodeGroup.ListGroupCode.Add("SpecialIdentity");
                var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);

                {
                    var Data = ObjectMapper.Map<List<ResumeMain>, List<ResumeMainsDto>>(items);

                    var inputSetShareCode = new SetShareCodeInput();
                    inputSetShareCode.ListShareCode = itemsShareCode;
                    inputSetShareCode.Data = Data;
                    var ListColumns = new List<NameCodeStandardDto>();
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "Sex", Code = "SexCode", Name = "SexName" });
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "Blood", Code = "BloodCode", Name = "BloodName" });
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "Marriage", Code = "MarriageCode", Name = "MarriageName" });
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "PlaceOfBirth", Code = "PlaceOfBirthCode", Name = "PlaceOfBirthName" });
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "Military", Code = "MilitaryCode", Name = "MilitaryName" });
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "DisabilityCategory", Code = "DisabilityCategoryCode", Name = "DisabilityCategoryName" });
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "Nationality", Code = "NationalityCode", Name = "NationalityName" });
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "SpecialIdentity", Code = "SpecialIdentityCode", Name = "SpecialIdentityName" });
                    inputSetShareCode.ListColumns = ListColumns;
                    _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<ResumeMainsDto>(inputSetShareCode);

                    Result.Data = Data;
                    Result.Save = true;
                }
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<ResumeMainsDto>> GetResumeMainsAsync(ResumeInput input)
        {
            var Result = new ResultDto<ResumeMainsDto>();
            Result.Data = new ResumeMainsDto();
            Result.Version = "2023041801";

            var DateNow = DateTime.Now;

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;

            var ResumeMainId = input.ResumeMainId;

            var itemsAll = await _appService._resumeMainRepository.GetQueryableAsync();
            itemsAll = from c in itemsAll
                       where c.UserMainId == UserMainId
                       && (c.Id == ResumeMainId)
                       //&& c.DateA <= DateNow && DateNow <= c.DateD
                       && c.Status == "1"
                       select c;

            var item = await AsyncExecuter.FirstOrDefaultAsync(itemsAll);
            if (item != null)
            {
                //取得履歷所需要的代碼資料-為了加速
                var inputShareCodeGroup = new ShareCodeGroupInput();
                inputShareCodeGroup.ListGroupCode.Add("Sex");
                inputShareCodeGroup.ListGroupCode.Add("Blood");
                inputShareCodeGroup.ListGroupCode.Add("Marriage");
                inputShareCodeGroup.ListGroupCode.Add("PlaceOfBirth");
                inputShareCodeGroup.ListGroupCode.Add("Military");
                inputShareCodeGroup.ListGroupCode.Add("DisabilityCategory");
                inputShareCodeGroup.ListGroupCode.Add("Nationality");
                inputShareCodeGroup.ListGroupCode.Add("SpecialIdentity");
                var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);

                {
                    var Data = ObjectMapper.Map<ResumeMain, ResumeMainsDto>(item);

                    var inputSetShareCode = new SetShareCodeInput();
                    inputSetShareCode.ListShareCode = itemsShareCode;
                    inputSetShareCode.Data = new List<ResumeMainsDto>() { Data };
                    var ListColumns = new List<NameCodeStandardDto>();
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "Sex", Code = "SexCode", Name = "SexName" });
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "Blood", Code = "BloodCode", Name = "BloodName" });
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "Marriage", Code = "MarriageCode", Name = "MarriageName" });
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "PlaceOfBirth", Code = "PlaceOfBirthCode", Name = "PlaceOfBirthName" });
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "Military", Code = "MilitaryCode", Name = "MilitaryName" });
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "DisabilityCategory", Code = "DisabilityCategoryCode", Name = "DisabilityCategoryName" });
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "Nationality", Code = "NationalityCode", Name = "NationalityName" });
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "SpecialIdentity", Code = "SpecialIdentityCode", Name = "SpecialIdentityName" });
                    inputSetShareCode.ListColumns = ListColumns;
                    _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<ResumeMainsDto>(inputSetShareCode);

                    //放入附檔
                    var inputShareUploadList = new ShareUploadListInput();
                    inputShareUploadList.Key1 = "ResumeMain";
                    inputShareUploadList.Key2 = "";
                    inputShareUploadList.Key3 = Data.UserMainId.ToString() ;
                    var itemsShareUploadList = await _appService._serviceProvider.GetService<SharesAppService>().GetShareUploadListAsync(inputShareUploadList);
                    //Data.ListShareUpload = itemsShareUploadList.Data;

                    Result.Data = Data;
                    Result.Save = true;
                }
            }
            else
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "履歷主檔不正確" });


            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<List<ResumeCommunicationsDto>>> GetResumeCommunicationsListAsync(ResumeInput input)
        {
            var Result = new ResultDto<List<ResumeCommunicationsDto>>();
            Result.Data = new List<ResumeCommunicationsDto>();
            Result.Version = "2023041801";

            var DateNow = DateTime.Now;

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;

            var ResumeMainId = input.ResumeMainId;

            var itemsAllResumeMain = await _appService._resumeMainRepository.GetQueryableAsync();
            itemsAllResumeMain = from c in itemsAllResumeMain
                                 where c.UserMainId == UserMainId
                                 && (c.Id == ResumeMainId)
                                 //&& c.DateA <= DateNow && DateNow <= c.DateD
                                 && c.Status == "1"
                                 select c;

            var anyResumeMain = await AsyncExecuter.AnyAsync(itemsAllResumeMain);
            if (anyResumeMain)
            {
                //取得履歷所需要的代碼資料-為了加速
                var inputShareCodeGroup = new ShareCodeGroupInput();
                inputShareCodeGroup.ListGroupCode.Add("CommunicationCategory");
                var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);

                {
                    var itemsAll = await _appService._resumeCommunicationRepository.GetQueryableAsync();
                    var items = itemsAll.Where(p => p.ResumeMainId == ResumeMainId).ToList();
                    var Data = ObjectMapper.Map<List<ResumeCommunication>, List<ResumeCommunicationsDto>>(items);
                    Data = (from c in Data
                            where c.Status == "1"
                            orderby c.Main descending, c.Sort
                            select c).ToList();

                    var inputSetShareCode = new SetShareCodeInput();
                    inputSetShareCode.ListShareCode = itemsShareCode;
                    inputSetShareCode.Data = Data;
                    var ListColumns = new List<NameCodeStandardDto>();
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "CommunicationCategory", Code = "CommunicationCategoryCode", Name = "CommunicationCategoryName" });
                    inputSetShareCode.ListColumns = ListColumns;
                    _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<ResumeCommunicationsDto>(inputSetShareCode);

                    Result.Data = Data;
                    Result.Save = true;
                }
            }
            else
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "履歷主檔不正確" });

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<List<ResumeCommunicationsClassificationDto>>> GetResumeCommunicationsClassificationListAsync(ResumeInput input)
        {
            var Result = new ResultDto<List<ResumeCommunicationsClassificationDto>>();
            Result.Data = new List<ResumeCommunicationsClassificationDto>();
            Result.Version = "2023041801";

            var DateNow = DateTime.Now;

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;

            var ResumeMainId = input.ResumeMainId;

            var itemsAllResumeMain = await _appService._resumeMainRepository.GetQueryableAsync();
            itemsAllResumeMain = from c in itemsAllResumeMain
                                 where c.UserMainId == UserMainId
                                 && (c.Id == ResumeMainId)
                                 //&& c.DateA <= DateNow && DateNow <= c.DateD
                                 && c.Status == "1"
                                 select c;

            var anyResumeMain = await AsyncExecuter.AnyAsync(itemsAllResumeMain);
            if (anyResumeMain)
            {
                //取得履歷所需要的代碼資料-為了加速
                var inputShareCodeGroup = new ShareCodeGroupInput();
                inputShareCodeGroup.ListGroupCode.Add("CommunicationCategory");
                var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);

                {
                    var itemsAll = await _appService._resumeCommunicationRepository.GetQueryableAsync();
                    var items = itemsAll.Where(p => p.ResumeMainId == ResumeMainId).ToList();
                    var Data = ObjectMapper.Map<List<ResumeCommunication>, List<ResumeCommunicationsDto>>(items);
                    Data = (from c in Data
                            where c.Status == "1"
                            orderby c.Main descending, c.Sort
                            select c).ToList();

                    var inputSetShareCode = new SetShareCodeInput();
                    inputSetShareCode.ListShareCode = itemsShareCode;
                    inputSetShareCode.Data = Data;
                    var ListColumns = new List<NameCodeStandardDto>();
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "CommunicationCategory", Code = "CommunicationCategoryCode", Name = "CommunicationCategoryName" });
                    inputSetShareCode.ListColumns = ListColumns;
                    _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<ResumeCommunicationsDto>(inputSetShareCode);

                    //進行分類   
                    var rsShareCode = itemsShareCode.Where(p => p.GroupCode == "CommunicationCategory").ToList();
                    var itemsDataClassification = new List<ResumeCommunicationsClassificationDto>();
                    ResumeCommunicationsClassificationDto itemDataClassification;
                    foreach (var rShareCode in rsShareCode)
                    {
                        var Code = rShareCode.Code;

                        itemDataClassification = new ResumeCommunicationsClassificationDto();
                        itemDataClassification.Code = Code;
                        itemDataClassification.Name = rShareCode.Name;
                        itemDataClassification.ListResumeCommunications = Data.Where(p => p.CommunicationCategoryCode == Code).ToList();
                        itemsDataClassification.Add(itemDataClassification);
                    }

                    Result.Data = itemsDataClassification;
                    Result.Save = true;
                }
            }
            else
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "履歷主檔不正確" });

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<List<ResumeDrvingLicensesDto>>> GetResumeDrvingLicensesListAsync(ResumeInput input)
        {
            var Result = new ResultDto<List<ResumeDrvingLicensesDto>>();
            Result.Data = new List<ResumeDrvingLicensesDto>();
            Result.Version = "2023041801";

            var DateNow = DateTime.Now;

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;

            var ResumeMainId = input.ResumeMainId;

            var itemsAllResumeMain = await _appService._resumeMainRepository.GetQueryableAsync();
            itemsAllResumeMain = from c in itemsAllResumeMain
                                 where c.UserMainId == UserMainId
                                 && (c.Id == ResumeMainId)
                                 //&& c.DateA <= DateNow && DateNow <= c.DateD
                                 && c.Status == "1"
                                 select c;

            var anyResumeMain = await AsyncExecuter.AnyAsync(itemsAllResumeMain);
            if (anyResumeMain)
            {
                //取得履歷所需要的代碼資料-為了加速
                var inputShareCodeGroup = new ShareCodeGroupInput();
                inputShareCodeGroup.ListGroupCode.Add("DrvingLicense");
                var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);

                {
                    var itemsAll = await _appService._resumeDrvingLicenseRepository.GetQueryableAsync();
                    var items = itemsAll.Where(p => p.ResumeMainId == ResumeMainId).ToList();
                    var Data = ObjectMapper.Map<List<ResumeDrvingLicense>, List<ResumeDrvingLicensesDto>>(items);
                    Data = (from c in Data
                            where c.Status == "1"
                            orderby c.Sort
                            select c).ToList();

                    var inputSetShareCode = new SetShareCodeInput();
                    inputSetShareCode.ListShareCode = itemsShareCode;
                    inputSetShareCode.Data = Data;
                    var ListColumns = new List<NameCodeStandardDto>();
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "DrvingLicense", Code = "DrvingLicenseCode", Name = "DrvingLicenseName" });
                    inputSetShareCode.ListColumns = ListColumns;
                    _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<ResumeDrvingLicensesDto>(inputSetShareCode);

                    Result.Data = Data;
                    Result.Save = true;
                }
            }
            else
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "履歷主檔不正確" });

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<List<ResumeDrvingLicensesClassificationDto>>> GetResumeDrvingLicensesClassificationListAsync(ResumeInput input)
        {
            var Result = new ResultDto<List<ResumeDrvingLicensesClassificationDto>>();
            Result.Data = new List<ResumeDrvingLicensesClassificationDto>();
            Result.Version = "2023041801";

            var DateNow = DateTime.Now;

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;

            var ResumeMainId = input.ResumeMainId;

            var itemsAllResumeMain = await _appService._resumeMainRepository.GetQueryableAsync();
            itemsAllResumeMain = from c in itemsAllResumeMain
                                 where c.UserMainId == UserMainId
                                 && (c.Id == ResumeMainId)
                                 //&& c.DateA <= DateNow && DateNow <= c.DateD
                                 && c.Status == "1"
                                 select c;

            var anyResumeMain = await AsyncExecuter.AnyAsync(itemsAllResumeMain);
            if (anyResumeMain)
            {
                //取得履歷所需要的代碼資料-為了加速
                var inputShareCodeGroup = new ShareCodeGroupInput();
                inputShareCodeGroup.ListGroupCode.Add("DrvingLicense");
                var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);

                {
                    var itemsAll = await _appService._resumeDrvingLicenseRepository.GetQueryableAsync();
                    var items = itemsAll.Where(p => p.ResumeMainId == ResumeMainId).ToList();
                    var Data = ObjectMapper.Map<List<ResumeDrvingLicense>, List<ResumeDrvingLicensesDto>>(items);
                    Data = (from c in Data
                            where c.Status == "1"
                            orderby c.Sort
                            select c).ToList();
                    var inputSetShareCode = new SetShareCodeInput();
                    inputSetShareCode.ListShareCode = itemsShareCode;
                    inputSetShareCode.Data = Data;
                    var ListColumns = new List<NameCodeStandardDto>();
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "DrvingLicense", Code = "DrvingLicenseCode", Name = "DrvingLicenseName" });
                    inputSetShareCode.ListColumns = ListColumns;
                    _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<ResumeDrvingLicensesDto>(inputSetShareCode);

                    //進行分類
                    var rsShareCode = itemsShareCode.Where(p => p.GroupCode == "DrvingLicense").ToList();
                    var rsgShareCode = rsShareCode.Where(p => p.ParentCode.Length == 0).ToList();   //上層的分類
                    var itemsDataClassification = new List<ResumeDrvingLicensesClassificationDto>();
                    ResumeDrvingLicensesClassificationDto itemDataClassification;
                    foreach (var rShareCode in rsgShareCode)
                    {
                        var Code = rShareCode.Code;
                        var ListShareCode = rsShareCode.Where(p => p.ParentCode == Code).Select(p => p.Code);

                        itemDataClassification = new ResumeDrvingLicensesClassificationDto();
                        itemDataClassification.Code = Code;
                        itemDataClassification.Name = rShareCode.Name;
                        itemDataClassification.ListResumeDrvingLicenses = Data.Where(p => ListShareCode.Contains(p.DrvingLicenseCode)).ToList();
                        itemsDataClassification.Add(itemDataClassification);
                    }

                    Result.Data = itemsDataClassification;
                    Result.Save = true;
                }
            }
            else
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "履歷主檔不正確" });

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<List<ResumeRecommendersDto>>> GetResumeRecommendersListAsync(ResumeInput input)
        {
            var Result = new ResultDto<List<ResumeRecommendersDto>>();
            Result.Data = new List<ResumeRecommendersDto>();
            Result.Version = "2023041801";

            var DateNow = DateTime.Now;

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;

            var ResumeMainId = input.ResumeMainId;

            var itemsAllResumeMain = await _appService._resumeMainRepository.GetQueryableAsync();
            itemsAllResumeMain = from c in itemsAllResumeMain
                                 where c.UserMainId == UserMainId
                                 && (c.Id == ResumeMainId)
                                 //&& c.DateA <= DateNow && DateNow <= c.DateD
                                 && c.Status == "1"
                                 select c;

            var anyResumeMain = await AsyncExecuter.AnyAsync(itemsAllResumeMain);
            if (anyResumeMain)
            {
                {
                    var itemsAll = await _appService._resumeRecommenderRepository.GetQueryableAsync();
                    var items = itemsAll.Where(p => p.ResumeMainId == ResumeMainId).ToList();

                    var Data = ObjectMapper.Map<List<ResumeRecommender>, List<ResumeRecommendersDto>>(items);
                    Data = (from c in Data
                            where c.Status == "1"
                            orderby c.Sort
                            select c).ToList();

                    Result.Data = Data;
                    Result.Save = true;
                }
            }
            else
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "履歷主檔不正確" });

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<List<ResumeLanguagesDto>>> GetResumeLanguagesListAsync(ResumeInput input)
        {
            var Result = new ResultDto<List<ResumeLanguagesDto>>();
            Result.Data = new List<ResumeLanguagesDto>();
            Result.Version = "2023041801";

            var DateNow = DateTime.Now;

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;

            var ResumeMainId = input.ResumeMainId;

            var itemsAllResumeMain = await _appService._resumeMainRepository.GetQueryableAsync();
            itemsAllResumeMain = from c in itemsAllResumeMain
                                 where c.UserMainId == UserMainId
                                 && (c.Id == ResumeMainId)
                                 //&& c.DateA <= DateNow && DateNow <= c.DateD
                                 && c.Status == "1"
                                 select c;

            var anyResumeMain = await AsyncExecuter.AnyAsync(itemsAllResumeMain);
            if (anyResumeMain)
            {
                //取得履歷所需要的代碼資料-為了加速
                var inputShareCodeGroup = new ShareCodeGroupInput();
                inputShareCodeGroup.ListGroupCode.Add("LanguageCategory");
                inputShareCodeGroup.ListGroupCode.Add("LanguageLevel");
                var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);

                {
                    var itemsAll = await _appService._resumeLanguageRepository.GetQueryableAsync();
                    var items = itemsAll.Where(p => p.ResumeMainId == ResumeMainId).ToList();
                    var Data = ObjectMapper.Map<List<ResumeLanguage>, List<ResumeLanguagesDto>>(items);
                    Data = (from c in Data
                            where c.DateA <= DateNow && DateNow <= c.DateD
                            && c.Status == "1"
                            orderby c.Sort
                            select c).ToList();

                    var inputSetShareCode = new SetShareCodeInput();
                    inputSetShareCode.ListShareCode = itemsShareCode;
                    inputSetShareCode.Data = Data;
                    var ListColumns = new List<NameCodeStandardDto>();
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "LanguageCategory", Code = "LanguageCategoryCode", Name = "LanguageCategoryName" });
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "LanguageLevel", Code = "LevelSayCode", Name = "LevelSayName" });
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "LanguageLevel", Code = "LevelListenCode", Name = "LevelListenName" });
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "LanguageLevel", Code = "LevelReadCode", Name = "LevelReadName" });
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "LanguageLevel", Code = "LevelWriteCode", Name = "LevelWriteName" });
                    inputSetShareCode.ListColumns = ListColumns;
                    _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<ResumeLanguagesDto>(inputSetShareCode);

                    Result.Data = Data;
                    Result.Save = true;
                }
            }
            else
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "履歷主檔不正確" });

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<List<ResumeLanguagesClassificationDto>>> GetResumeLanguagesClassificationListAsync(ResumeInput input)
        {
            var Result = new ResultDto<List<ResumeLanguagesClassificationDto>>();
            Result.Data = new List<ResumeLanguagesClassificationDto>();
            Result.Version = "2023041801";

            var DateNow = DateTime.Now;

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;

            var ResumeMainId = input.ResumeMainId;

            var itemsAllResumeMain = await _appService._resumeMainRepository.GetQueryableAsync();
            itemsAllResumeMain = from c in itemsAllResumeMain
                                 where c.UserMainId == UserMainId
                                 && (c.Id == ResumeMainId)
                                 //&& c.DateA <= DateNow && DateNow <= c.DateD
                                 && c.Status == "1"
                                 select c;

            var anyResumeMain = await AsyncExecuter.AnyAsync(itemsAllResumeMain);
            if (anyResumeMain)
            {
                //取得履歷所需要的代碼資料-為了加速
                var inputShareCodeGroup = new ShareCodeGroupInput();
                inputShareCodeGroup.ListGroupCode.Add("LanguageCategory");
                inputShareCodeGroup.ListGroupCode.Add("LanguageLevel");
                var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);

                {
                    var itemsAll = await _appService._resumeLanguageRepository.GetQueryableAsync();
                    var items = itemsAll.Where(p => p.ResumeMainId == ResumeMainId).ToList();
                    var Data = ObjectMapper.Map<List<ResumeLanguage>, List<ResumeLanguagesDto>>(items);
                    Data = (from c in Data
                            where c.DateA <= DateNow && DateNow <= c.DateD
                            && c.Status == "1"
                            orderby c.Sort
                            select c).ToList();

                    var inputSetShareCode = new SetShareCodeInput();
                    inputSetShareCode.ListShareCode = itemsShareCode;
                    inputSetShareCode.Data = Data;
                    var ListColumns = new List<NameCodeStandardDto>();
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "LanguageCategory", Code = "LanguageCategoryCode", Name = "LanguageCategoryName" });
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "LanguageLevel", Code = "LevelSayCode", Name = "LevelSayName" });
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "LanguageLevel", Code = "LevelListenCode", Name = "LevelListenName" });
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "LanguageLevel", Code = "LevelReadCode", Name = "LevelReadName" });
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "LanguageLevel", Code = "LevelWriteCode", Name = "LevelWriteName" });
                    inputSetShareCode.ListColumns = ListColumns;
                    _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<ResumeLanguagesDto>(inputSetShareCode);

                    //進行分類
                    //語言的分法-分成國際語言及方言(比較特殊)
                    var rsShareCode = itemsShareCode.Where(p => p.GroupCode == "LanguageCategory").ToList();
                    var rsgShareCode = rsShareCode.Where(p => p.ParentCode.Length == 0).ToList();   //上層的分類
                    var itemsDataClassification = new List<ResumeLanguagesClassificationDto>();
                    ResumeLanguagesClassificationDto itemDataClassification;
                    foreach (var rShareCode in rsgShareCode)
                    {
                        var Code = rShareCode.Code;
                        var ListShareCode = rsShareCode.Where(p => p.ParentCode == Code).Select(p => p.Code);

                        itemDataClassification = new ResumeLanguagesClassificationDto();
                        itemDataClassification.Code = Code;
                        itemDataClassification.Name = rShareCode.Name;
                        itemDataClassification.ListResumeLanguages = Data.Where(p => ListShareCode.Contains(p.LanguageCategoryCode)).ToList();
                        itemsDataClassification.Add(itemDataClassification);
                    }

                    Result.Data = itemsDataClassification;
                    Result.Save = true;
                }
            }
            else
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "履歷主檔不正確" });

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<List<ResumeSkillsDto>>> GetResumeSkillsListAsync(ResumeInput input)
        {
            var Result = new ResultDto<List<ResumeSkillsDto>>();
            Result.Data = new List<ResumeSkillsDto>();
            Result.Version = "2023041801";

            var DateNow = DateTime.Now;

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;

            var ResumeMainId = input.ResumeMainId;

            var itemsAllResumeMain = await _appService._resumeMainRepository.GetQueryableAsync();
            itemsAllResumeMain = from c in itemsAllResumeMain
                                 where c.UserMainId == UserMainId
                                 && (c.Id == ResumeMainId)
                                 //&& c.DateA <= DateNow && DateNow <= c.DateD
                                 && c.Status == "1"
                                 select c;

            var anyResumeMain = await AsyncExecuter.AnyAsync(itemsAllResumeMain);
            if (anyResumeMain)
            {
                //取得履歷所需要的代碼資料-為了加速
                var inputShareCodeGroup = new ShareCodeGroupInput();
                inputShareCodeGroup.ListGroupCode.Add("ChineseTyping");
                var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);

                {
                    var itemsAll = await _appService._resumeSkillRepository.GetQueryableAsync();
                    var items = itemsAll.Where(p => p.ResumeMainId == ResumeMainId).ToList();
                    var Data = ObjectMapper.Map<List<ResumeSkill>, List<ResumeSkillsDto>>(items);
                    Data = (from c in Data
                            where c.Status == "1"
                            orderby c.Sort
                            select c).ToList();

                    var inputSetShareCode = new SetShareCodeInput();
                    inputSetShareCode.ListShareCode = itemsShareCode;
                    inputSetShareCode.Data = Data;
                    var ListColumns = new List<NameCodeStandardDto>();
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "ChineseTyping", Code = "ChineseTypingCode", Name = "ChineseTypingName" });
                    inputSetShareCode.ListColumns = ListColumns;
                    _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<ResumeSkillsDto>(inputSetShareCode);

                    Result.Data = Data;
                    Result.Save = true;
                }
            }
            else
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "履歷主檔不正確" });

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<List<ResumeDependentssDto>>> GetResumeDependentssListAsync(ResumeInput input)
        {
            var Result = new ResultDto<List<ResumeDependentssDto>>();
            Result.Data = new List<ResumeDependentssDto>();
            Result.Version = "2023041801";

            var DateNow = DateTime.Now;

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;

            var ResumeMainId = input.ResumeMainId;

            var itemsAllResumeMain = await _appService._resumeMainRepository.GetQueryableAsync();
            itemsAllResumeMain = from c in itemsAllResumeMain
                                 where c.UserMainId == UserMainId
                                 && (c.Id == ResumeMainId)
                                 //&& c.DateA <= DateNow && DateNow <= c.DateD
                                 && c.Status == "1"
                                 select c;

            var anyResumeMain = await AsyncExecuter.AnyAsync(itemsAllResumeMain);
            if (anyResumeMain)
            {
                //取得履歷所需要的代碼資料-為了加速
                var inputShareCodeGroup = new ShareCodeGroupInput();
                inputShareCodeGroup.ListGroupCode.Add("Kinship");
                var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);

                {
                    var itemsAll = await _appService._resumeDependentsRepository.GetQueryableAsync();
                    var items = itemsAll.Where(p => p.ResumeMainId == ResumeMainId).ToList();
                    var Data = ObjectMapper.Map<List<ResumeDependents>, List<ResumeDependentssDto>>(items);
                    Data = (from c in Data
                            where c.Status == "1"
                            orderby c.Sort
                            select c).ToList();

                    var inputSetShareCode = new SetShareCodeInput();
                    inputSetShareCode.ListShareCode = itemsShareCode;
                    inputSetShareCode.Data = Data;
                    var ListColumns = new List<NameCodeStandardDto>();
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "Kinship", Code = "KinshipCode", Name = "KinshipName" });
                    inputSetShareCode.ListColumns = ListColumns;
                    _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<ResumeDependentssDto>(inputSetShareCode);

                    Result.Data = Data;
                    Result.Save = true;
                }
            }
            else
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "履歷主檔不正確" });

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<List<ResumeEducationssDto>>> GetResumeEducationssListAsync(ResumeInput input)
        {
            var Result = new ResultDto<List<ResumeEducationssDto>>();
            Result.Data = new List<ResumeEducationssDto>();
            Result.Version = "2023041801";

            var DateNow = DateTime.Now;

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;

            var ResumeMainId = input.ResumeMainId;

            var itemsAllResumeMain = await _appService._resumeMainRepository.GetQueryableAsync();
            itemsAllResumeMain = from c in itemsAllResumeMain
                                 where c.UserMainId == UserMainId
                                 && (c.Id == ResumeMainId)
                                 //&& c.DateA <= DateNow && DateNow <= c.DateD
                                 && c.Status == "1"
                                 select c;

            var anyResumeMain = await AsyncExecuter.AnyAsync(itemsAllResumeMain);
            if (anyResumeMain)
            {
                //取得履歷所需要的代碼資料-為了加速
                var inputShareCodeGroup = new ShareCodeGroupInput();
                inputShareCodeGroup.ListGroupCode.Add("EducationLevel");
                inputShareCodeGroup.ListGroupCode.Add("DepartmentCategory");
                inputShareCodeGroup.ListGroupCode.Add("Graduation");
                inputShareCodeGroup.ListGroupCode.Add("Country");
                var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);

                {
                    var itemsAll = await _appService._resumeEducationsRepository.GetQueryableAsync();
                    var items = itemsAll.Where(p => p.ResumeMainId == ResumeMainId).ToList();
                    var Data = ObjectMapper.Map<List<ResumeEducations>, List<ResumeEducationssDto>>(items);
                    Data = (from c in Data
                            where c.Status == "1"
                            orderby c.Sort
                            select c).ToList();

                    var inputSetShareCode = new SetShareCodeInput();
                    inputSetShareCode.ListShareCode = itemsShareCode;
                    inputSetShareCode.Data = Data;
                    var ListColumns = new List<NameCodeStandardDto>();
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "EducationLevel", Code = "EducationLevelCode", Name = "EducationLevelName" });
                    //ListColumns.Add(new NameCodeStandardDto { GroupCode = "DepartmentCategory", Code = "MajorDepartmentCategoryCode", Name = "MajorDepartmentCategoryName" });
                    //ListColumns.Add(new NameCodeStandardDto { GroupCode = "DepartmentCategory", Code = "MinorDepartmentCategoryCode", Name = "MinorDepartmentCategoryName" });
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "Graduation", Code = "GraduationCode", Name = "GraduationName" });
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "Country", Code = "CountryCode", Name = "CountryName" });
                    inputSetShareCode.ListColumns = ListColumns;
                    _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<ResumeEducationssDto>(inputSetShareCode);

                    Result.Data = Data;
                    Result.Save = true;
                }
            }
            else
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "履歷主檔不正確" });

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<List<ResumeExperiencessDto>>> GetResumeExperiencessListAsync(ResumeInput input)
        {
            var Result = new ResultDto<List<ResumeExperiencessDto>>();
            Result.Data = new List<ResumeExperiencessDto>();
            Result.Version = "2023041801";

            var DateNow = DateTime.Now;

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;

            var ResumeMainId = input.ResumeMainId;

            var itemsAllResumeMain = await _appService._resumeMainRepository.GetQueryableAsync();
            itemsAllResumeMain = from c in itemsAllResumeMain
                                 where c.UserMainId == UserMainId
                                 && (c.Id == ResumeMainId)
                                 //&& c.DateA <= DateNow && DateNow <= c.DateD
                                 && c.Status == "1"
                                 select c;

            var anyResumeMain = await AsyncExecuter.AnyAsync(itemsAllResumeMain);
            if (anyResumeMain)
            {
                //取得履歷所需要的代碼資料-為了加速
                var inputShareCodeGroup = new ShareCodeGroupInput();
                inputShareCodeGroup.ListGroupCode.Add("WorkNature");
                //inputShareCodeGroup.ListGroupCode.Add("IndustryCategory");
                //inputShareCodeGroup.ListGroupCode.Add("WorkPlace");
                inputShareCodeGroup.ListGroupCode.Add("SalaryPayType");
                inputShareCodeGroup.ListGroupCode.Add("CurrencyType");
                inputShareCodeGroup.ListGroupCode.Add("CompanyScale");
                inputShareCodeGroup.ListGroupCode.Add("CompanyManagementNumber");
                var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);

                {
                    var itemsAll = await _appService._resumeExperiencesRepository.GetQueryableAsync();
                    var items = itemsAll.Where(p => p.ResumeMainId == ResumeMainId).ToList();
                    var Data = ObjectMapper.Map<List<ResumeExperiences>, List<ResumeExperiencessDto>>(items);
                    Data = (from c in Data
                            where c.Status == "1"
                            orderby c.Sort
                            select c).ToList();

                    var inputSetShareCode = new SetShareCodeInput();
                    inputSetShareCode.ListShareCode = itemsShareCode;
                    inputSetShareCode.Data = Data;
                    var ListColumns = new List<NameCodeStandardDto>();
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "WorkNature", Code = "WorkNatureCode", Name = "WorkNatureName" });
                    //ListColumns.Add(new NameCodeStandardDto { GroupCode = "IndustryCategory", Code = "IndustryCategoryCode", Name = "IndustryCategoryName" });
                    //ListColumns.Add(new NameCodeStandardDto { GroupCode = "WorkPlace", Code = "WorkPlaceCode", Name = "WorkPlaceName" });
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "SalaryPayType", Code = "SalaryPayTypeCode", Name = "SalaryPayTypeName" });
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "CurrencyType", Code = "CurrencyTypeCode", Name = "CurrencyTypeName" });
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "CompanyScale", Code = "CompanyScaleCode", Name = "CompanyScaleName" });
                    ListColumns.Add(new NameCodeStandardDto { GroupCode = "CompanyManagementNumber", Code = "CompanyManagementNumberCode", Name = "CompanyManagementNumberName" });
                    inputSetShareCode.ListColumns = ListColumns;
                    _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<ResumeExperiencessDto>(inputSetShareCode);

                    //try
                    //{
                    //    foreach (var item in Data)
                    //        item.ListJobType = JsonSerializer.Deserialize<List<ResumeExperiencesJobType>>(item.JobType);
                    //}
                    //catch { }

                    Result.Data = Data;
                    Result.Save = true;
                }
            }
            else
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "履歷主檔不正確" });

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<List<ResumeWorkssDto>>> GetResumeWorkssListAsync(ResumeInput input)
        {
            var Result = new ResultDto<List<ResumeWorkssDto>>();
            Result.Data = new List<ResumeWorkssDto>();
            Result.Version = "2023041801";

            var DateNow = DateTime.Now;

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;

            var ResumeMainId = input.ResumeMainId;

            var itemsAllResumeMain = await _appService._resumeMainRepository.GetQueryableAsync();
            itemsAllResumeMain = from c in itemsAllResumeMain
                                 where c.UserMainId == UserMainId
                                 && (c.Id == ResumeMainId)
                                 //&& c.DateA <= DateNow && DateNow <= c.DateD
                                 && c.Status == "1"
                                 select c;

            var anyResumeMain = await AsyncExecuter.AnyAsync(itemsAllResumeMain);
            if (anyResumeMain)
            {
                {
                    var itemsAll = await _appService._resumeWorksRepository.GetQueryableAsync();
                    var items = itemsAll.Where(p => p.ResumeMainId == ResumeMainId).ToList();

                    var Data = ObjectMapper.Map<List<ResumeWorks>, List<ResumeWorkssDto>>(items);
                    Data = (from c in Data
                            where c.Status == "1"
                            orderby c.Sort
                            select c).ToList();

                    var inputShareUploadList = new ShareUploadListInput();
                    inputShareUploadList.Key1 = "ResumeWorks";
                    inputShareUploadList.Key2 = "";
                    foreach (var item in Data)
                    {
                        inputShareUploadList.Key3 = item.Id.ToString();
                        var itemsShareUploadList = await _appService._serviceProvider.GetService<SharesAppService>().GetShareUploadListAsync(inputShareUploadList);
                        item.ListShareUpload = itemsShareUploadList.Data;
                    }

                    Result.Data = Data;
                    Result.Save = true;
                }
            }
            else
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "履歷主檔不正確" });

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }
    }
}