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
using Resume.CompanyContracts;
using System;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Uow;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.LanguageManagement.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TextTemplateManagement.EntityFrameworkCore;
using Volo.Saas.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.Gdpr;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Chat.EntityFrameworkCore;
using Volo.FileManagement.EntityFrameworkCore;
using Volo.Payment.EntityFrameworkCore;
using Volo.Abp.Auditing;

namespace Resume.EntityFrameworkCore;

[DependsOn(
    typeof(ResumeDomainModule),
    typeof(AbpIdentityProEntityFrameworkCoreModule),
    typeof(AbpOpenIddictProEntityFrameworkCoreModule),
    typeof(AbpPermissionManagementEntityFrameworkCoreModule),
    typeof(AbpSettingManagementEntityFrameworkCoreModule),
    typeof(AbpEntityFrameworkCoreSqlServerModule),
    typeof(AbpBackgroundJobsEntityFrameworkCoreModule),
    typeof(AbpAuditLoggingEntityFrameworkCoreModule),
    typeof(AbpFeatureManagementEntityFrameworkCoreModule),
    typeof(LanguageManagementEntityFrameworkCoreModule),
    typeof(SaasEntityFrameworkCoreModule),
    typeof(TextTemplateManagementEntityFrameworkCoreModule),
    typeof(AbpGdprEntityFrameworkCoreModule),
    typeof(BlobStoringDatabaseEntityFrameworkCoreModule)
    )]
[DependsOn(typeof(ChatEntityFrameworkCoreModule))]
    [DependsOn(typeof(FileManagementEntityFrameworkCoreModule))]
    [DependsOn(typeof(AbpPaymentEntityFrameworkCoreModule))]
    public class ResumeEntityFrameworkCoreModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        ResumeEfCoreEntityExtensionMappings.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<ResumeDbContext>(options =>
        {
            /* Remove "includeAllEntities: true" to create
             * default repositories only for aggregate roots */
            options.AddDefaultRepositories(includeAllEntities: true);
            options.AddRepository<CompanyContract, CompanyContracts.EfCoreCompanyContractRepository>();

            options.AddRepository<CompanyInvitations, CompanyInvitationss.EfCoreCompanyInvitationsRepository>();

            options.AddRepository<CompanyInvitationsCode, CompanyInvitationsCodes.EfCoreCompanyInvitationsCodeRepository>();

            options.AddRepository<CompanyJob, CompanyJobs.EfCoreCompanyJobRepository>();

            options.AddRepository<CompanyJobApplicationMethod, CompanyJobApplicationMethods.EfCoreCompanyJobApplicationMethodRepository>();

            options.AddRepository<CompanyJobCondition, CompanyJobConditions.EfCoreCompanyJobConditionRepository>();

            options.AddRepository<CompanyJobContent, CompanyJobContents.EfCoreCompanyJobContentRepository>();

            options.AddRepository<CompanyJobPair, CompanyJobPairs.EfCoreCompanyJobPairRepository>();

            options.AddRepository<CompanyJobPay, CompanyJobPays.EfCoreCompanyJobPayRepository>();

            options.AddRepository<CompanyMain, CompanyMains.EfCoreCompanyMainRepository>();

            options.AddRepository<CompanyPoints, CompanyPointss.EfCoreCompanyPointsRepository>();

            options.AddRepository<CompanyUser, CompanyUsers.EfCoreCompanyUserRepository>();

            options.AddRepository<ResumeCommunication, ResumeCommunications.EfCoreResumeCommunicationRepository>();

            options.AddRepository<ResumeDependents, ResumeDependentss.EfCoreResumeDependentsRepository>();

            options.AddRepository<ResumeDrvingLicense, ResumeDrvingLicenses.EfCoreResumeDrvingLicenseRepository>();

            options.AddRepository<ResumeEducations, ResumeEducationss.EfCoreResumeEducationsRepository>();

            options.AddRepository<ResumeExperiences, ResumeExperiencess.EfCoreResumeExperiencesRepository>();

            options.AddRepository<ResumeLanguage, ResumeLanguages.EfCoreResumeLanguageRepository>();

            options.AddRepository<ResumeMain, ResumeMains.EfCoreResumeMainRepository>();

            options.AddRepository<ResumeRecommender, ResumeRecommenders.EfCoreResumeRecommenderRepository>();

            options.AddRepository<ResumeSkill, ResumeSkills.EfCoreResumeSkillRepository>();

            options.AddRepository<ResumeSnapshot, ResumeSnapshots.EfCoreResumeSnapshotRepository>();

            options.AddRepository<ResumeWorks, ResumeWorkss.EfCoreResumeWorksRepository>();

            options.AddRepository<ShareCode, ShareCodes.EfCoreShareCodeRepository>();

            options.AddRepository<ShareDefault, ShareDefaults.EfCoreShareDefaultRepository>();

            options.AddRepository<ShareDictionary, ShareDictionarys.EfCoreShareDictionaryRepository>();

            options.AddRepository<ShareLanguage, ShareLanguages.EfCoreShareLanguageRepository>();

            options.AddRepository<ShareMessageTpl, ShareMessageTpls.EfCoreShareMessageTplRepository>();

            options.AddRepository<ShareSendQueue, ShareSendQueues.EfCoreShareSendQueueRepository>();

            options.AddRepository<ShareTag, ShareTags.EfCoreShareTagRepository>();

            options.AddRepository<ShareUpload, ShareUploads.EfCoreShareUploadRepository>();

            options.AddRepository<SystemColumn, SystemColumns.EfCoreSystemColumnRepository>();

            options.AddRepository<SystemDisplayMessage, SystemDisplayMessages.EfCoreSystemDisplayMessageRepository>();

            options.AddRepository<SystemPage, SystemPages.EfCoreSystemPageRepository>();

            options.AddRepository<SystemTable, SystemTables.EfCoreSystemTableRepository>();

            options.AddRepository<SystemUserNotify, SystemUserNotifys.EfCoreSystemUserNotifyRepository>();

            options.AddRepository<SystemUserRole, SystemUserRoles.EfCoreSystemUserRoleRepository>();

            options.AddRepository<SystemValidate, SystemValidates.EfCoreSystemValidateRepository>();

            options.AddRepository<TradeOderDetail, TradeOderDetails.EfCoreTradeOderDetailRepository>();

            options.AddRepository<TradeOrder, TradeOrders.EfCoreTradeOrderRepository>();

            options.AddRepository<TradeProduct, TradeProducts.EfCoreTradeProductRepository>();

            options.AddRepository<UserAccountBind, UserAccountBinds.EfCoreUserAccountBindRepository>();

            options.AddRepository<UserCompanyBind, UserCompanyBinds.EfCoreUserCompanyBindRepository>();

            options.AddRepository<UserCompanyJobApply, UserCompanyJobApplies.EfCoreUserCompanyJobApplyRepository>();

            options.AddRepository<UserCompanyJobFav, UserCompanyJobFavs.EfCoreUserCompanyJobFavRepository>();

            options.AddRepository<UserCompanyJobPair, UserCompanyJobPairs.EfCoreUserCompanyJobPairRepository>();

            options.AddRepository<UserInfo, UserInfos.EfCoreUserInfoRepository>();

            options.AddRepository<UserMain, UserMains.EfCoreUserMainRepository>();

            options.AddRepository<UserToken, UserTokens.EfCoreUserTokenRepository>();

            options.AddRepository<UserVerify, UserVerifys.EfCoreUserVerifyRepository>();

        });

        Configure<AbpDbContextOptions>(options =>
        {
            /* The main point to change your DBMS.
             * See also ResumeDbContextFactory for EF Core tooling. */
            options.UseSqlServer();
        });

        //AbpEntityChanges
        Configure<AbpAuditingOptions>(options =>
        {
            /* The main point to change your DBMS.
             * See also HRMDbContextFactory for EF Core tooling. */
            options.EntityHistorySelectors.AddAllEntities();
        });
    }
}