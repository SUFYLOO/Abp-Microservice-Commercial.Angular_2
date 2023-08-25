using Resume.CompanyJobLanguageConditions;
using Resume.CompanyJobWorkHourss;
using Resume.CompanyJobDrvingLicenses;
using Resume.CompanyJobEducationLevels;
using Resume.CompanyJobDisabilityCategories;
using Resume.CompanyJobWorkIdentities;
using Resume.CompanyUserMainFavs;
using Resume.ResumeExperiencesJobs;
using Resume.ShareExtendeds;
using Resume.CompanyJobOrganizationUnits;
using Resume.UserVerifys;
using Resume.UserTokens;
using Resume.UserMains;
using Resume.UserInfos;
using Resume.UserCompanyJobPairs;
using Resume.UserCompanyJobFavs;
using Resume.UserCompanyJobApplies;
using Resume.UserCompanyBinds;
using Resume.UserAccountBinds;
using Resume.TradeProducts;
using Resume.TradeOrders;
using Resume.TradeOderDetails;
using Resume.SystemValidates;
using Resume.SystemUserRoles;
using Resume.SystemUserNotifys;
using Resume.SystemTables;
using Resume.SystemPages;
using Resume.SystemDisplayMessages;
using Resume.SystemColumns;
using Resume.ShareUploads;
using Resume.ShareTags;
using Resume.ShareSendQueues;
using Resume.ShareMessageTpls;
using Resume.ShareLanguages;
using Resume.ShareDictionarys;
using Resume.ShareDefaults;
using Resume.ShareCodes;
using Resume.ResumeWorkss;
using Resume.ResumeSnapshots;
using Resume.ResumeSkills;
using Resume.ResumeRecommenders;
using Resume.ResumeMains;
using Resume.ResumeLanguages;
using Resume.ResumeExperiencess;
using Resume.ResumeEducationss;
using Resume.ResumeDrvingLicenses;
using Resume.ResumeDependentss;
using Resume.ResumeCommunications;
using Resume.CompanyUsers;
using Resume.CompanyPointss;
using Resume.CompanyMains;
using Resume.CompanyJobPays;
using Resume.CompanyJobPairs;
using Resume.CompanyJobContents;
using Resume.CompanyJobConditions;
using Resume.CompanyJobApplicationMethods;
using Resume.CompanyJobs;
using Resume.CompanyInvitationsCodes;
using Resume.CompanyInvitationss;
using System;
using Resume.Shared;
using Volo.Abp.AutoMapper;
using Resume.CompanyContracts;
using AutoMapper;

namespace Resume;

public class ResumeApplicationAutoMapperProfile : Profile
{
    public ResumeApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<CompanyContract, CompanyContractDto>();
        CreateMap<CompanyContract, CompanyContractExcelDto>();

        CreateMap<CompanyInvitations, CompanyInvitationsDto>();
        CreateMap<CompanyInvitations, CompanyInvitationsExcelDto>();

        CreateMap<CompanyInvitationsCode, CompanyInvitationsCodeDto>();
        CreateMap<CompanyInvitationsCode, CompanyInvitationsCodeExcelDto>();

        CreateMap<CompanyJob, CompanyJobDto>();
        CreateMap<CompanyJob, CompanyJobExcelDto>();

        CreateMap<CompanyJobApplicationMethod, CompanyJobApplicationMethodDto>();
        CreateMap<CompanyJobApplicationMethod, CompanyJobApplicationMethodExcelDto>();

        CreateMap<CompanyJobCondition, CompanyJobConditionDto>();
        CreateMap<CompanyJobCondition, CompanyJobConditionExcelDto>();

        CreateMap<CompanyJobContent, CompanyJobContentDto>();
        CreateMap<CompanyJobContent, CompanyJobContentExcelDto>();

        CreateMap<CompanyJobPair, CompanyJobPairDto>();
        CreateMap<CompanyJobPair, CompanyJobPairExcelDto>();

        CreateMap<CompanyJobPay, CompanyJobPayDto>();
        CreateMap<CompanyJobPay, CompanyJobPayExcelDto>();

        CreateMap<CompanyMain, CompanyMainDto>();
        CreateMap<CompanyMain, CompanyMainExcelDto>();

        CreateMap<CompanyPoints, CompanyPointsDto>();
        CreateMap<CompanyPoints, CompanyPointsExcelDto>();

        CreateMap<CompanyUser, CompanyUserDto>();
        CreateMap<CompanyUser, CompanyUserExcelDto>();

        CreateMap<ResumeCommunication, ResumeCommunicationDto>();
        CreateMap<ResumeCommunication, ResumeCommunicationExcelDto>();

        CreateMap<ResumeDependents, ResumeDependentsDto>();
        CreateMap<ResumeDependents, ResumeDependentsExcelDto>();

        CreateMap<ResumeDrvingLicense, ResumeDrvingLicenseDto>();
        CreateMap<ResumeDrvingLicense, ResumeDrvingLicenseExcelDto>();

        CreateMap<ResumeEducations, ResumeEducationsDto>();
        CreateMap<ResumeEducations, ResumeEducationsExcelDto>();

        CreateMap<ResumeExperiences, ResumeExperiencesDto>();
        CreateMap<ResumeExperiences, ResumeExperiencesExcelDto>();

        CreateMap<ResumeLanguage, ResumeLanguageDto>();
        CreateMap<ResumeLanguage, ResumeLanguageExcelDto>();

        CreateMap<ResumeMain, ResumeMainDto>();
        CreateMap<ResumeMain, ResumeMainExcelDto>();

        CreateMap<ResumeRecommender, ResumeRecommenderDto>();
        CreateMap<ResumeRecommender, ResumeRecommenderExcelDto>();

        CreateMap<ResumeSkill, ResumeSkillDto>();
        CreateMap<ResumeSkill, ResumeSkillExcelDto>();

        CreateMap<ResumeSnapshot, ResumeSnapshotDto>();
        CreateMap<ResumeSnapshot, ResumeSnapshotExcelDto>();

        CreateMap<ResumeWorks, ResumeWorksDto>();
        CreateMap<ResumeWorks, ResumeWorksExcelDto>();

        CreateMap<ShareCode, ShareCodeDto>();
        CreateMap<ShareCode, ShareCodeExcelDto>();

        CreateMap<ShareDefault, ShareDefaultDto>();
        CreateMap<ShareDefault, ShareDefaultExcelDto>();

        CreateMap<ShareDictionary, ShareDictionaryDto>();
        CreateMap<ShareDictionary, ShareDictionaryExcelDto>();

        CreateMap<ShareLanguage, ShareLanguageDto>();
        CreateMap<ShareLanguage, ShareLanguageExcelDto>();

        CreateMap<ShareMessageTpl, ShareMessageTplDto>();
        CreateMap<ShareMessageTpl, ShareMessageTplExcelDto>();

        CreateMap<ShareSendQueue, ShareSendQueueDto>();
        CreateMap<ShareSendQueue, ShareSendQueueExcelDto>();

        CreateMap<ShareTag, ShareTagDto>();
        CreateMap<ShareTag, ShareTagExcelDto>();

        CreateMap<ShareUpload, ShareUploadDto>();
        CreateMap<ShareUpload, ShareUploadExcelDto>();

        CreateMap<SystemColumn, SystemColumnDto>();
        CreateMap<SystemColumn, SystemColumnExcelDto>();

        CreateMap<SystemDisplayMessage, SystemDisplayMessageDto>();
        CreateMap<SystemDisplayMessage, SystemDisplayMessageExcelDto>();

        CreateMap<SystemPage, SystemPageDto>();
        CreateMap<SystemPage, SystemPageExcelDto>();

        CreateMap<SystemTable, SystemTableDto>();
        CreateMap<SystemTable, SystemTableExcelDto>();

        CreateMap<SystemUserNotify, SystemUserNotifyDto>();
        CreateMap<SystemUserNotify, SystemUserNotifyExcelDto>();

        CreateMap<SystemUserRole, SystemUserRoleDto>();
        CreateMap<SystemUserRole, SystemUserRoleExcelDto>();

        CreateMap<SystemValidate, SystemValidateDto>();
        CreateMap<SystemValidate, SystemValidateExcelDto>();

        CreateMap<TradeOderDetail, TradeOderDetailDto>();
        CreateMap<TradeOderDetail, TradeOderDetailExcelDto>();

        CreateMap<TradeOrder, TradeOrderDto>();
        CreateMap<TradeOrder, TradeOrderExcelDto>();

        CreateMap<TradeProduct, TradeProductDto>();
        CreateMap<TradeProduct, TradeProductExcelDto>();

        CreateMap<UserAccountBind, UserAccountBindDto>();
        CreateMap<UserAccountBind, UserAccountBindExcelDto>();

        CreateMap<UserCompanyBind, UserCompanyBindDto>();
        CreateMap<UserCompanyBind, UserCompanyBindExcelDto>();

        CreateMap<UserCompanyJobApply, UserCompanyJobApplyDto>();
        CreateMap<UserCompanyJobApply, UserCompanyJobApplyExcelDto>();

        CreateMap<UserCompanyJobFav, UserCompanyJobFavDto>();
        CreateMap<UserCompanyJobFav, UserCompanyJobFavExcelDto>();

        CreateMap<UserCompanyJobPair, UserCompanyJobPairDto>();
        CreateMap<UserCompanyJobPair, UserCompanyJobPairExcelDto>();

        CreateMap<UserInfo, UserInfoDto>();
        CreateMap<UserInfo, UserInfoExcelDto>();

        CreateMap<UserMain, UserMainDto>();
        CreateMap<UserMain, UserMainExcelDto>();

        CreateMap<UserToken, UserTokenDto>();
        CreateMap<UserToken, UserTokenExcelDto>();

        CreateMap<UserVerify, UserVerifyDto>();
        CreateMap<UserVerify, UserVerifyExcelDto>();

        CreateMap<CompanyJobOrganizationUnit, CompanyJobOrganizationUnitDto>();
        CreateMap<CompanyJobOrganizationUnit, CompanyJobOrganizationUnitExcelDto>();

        CreateMap<ShareExtended, ShareExtendedDto>();
        CreateMap<ShareExtended, ShareExtendedExcelDto>();

        CreateMap<ResumeExperiencesJob, ResumeExperiencesJobDto>();
        CreateMap<ResumeExperiencesJob, ResumeExperiencesJobExcelDto>();

        CreateMap<CompanyUserMainFav, CompanyUserMainFavDto>();
        CreateMap<CompanyUserMainFav, CompanyUserMainFavExcelDto>();

        CreateMap<CompanyJobWorkIdentity, CompanyJobWorkIdentityDto>();
        CreateMap<CompanyJobWorkIdentity, CompanyJobWorkIdentityExcelDto>();

        CreateMap<CompanyJobDisabilityCategory, CompanyJobDisabilityCategoryDto>();
        CreateMap<CompanyJobDisabilityCategory, CompanyJobDisabilityCategoryExcelDto>();

        CreateMap<CompanyJobEducationLevel, CompanyJobEducationLevelDto>();
        CreateMap<CompanyJobEducationLevel, CompanyJobEducationLevelExcelDto>();

        CreateMap<CompanyJobDrvingLicense, CompanyJobDrvingLicenseDto>();
        CreateMap<CompanyJobDrvingLicense, CompanyJobDrvingLicenseExcelDto>();

        CreateMap<CompanyJobWorkHours, CompanyJobWorkHoursDto>();
        CreateMap<CompanyJobWorkHours, CompanyJobWorkHoursExcelDto>();

        CreateMap<CompanyJobLanguageCondition, CompanyJobLanguageConditionDto>();
        CreateMap<CompanyJobLanguageCondition, CompanyJobLanguageConditionExcelDto>();
    }
}