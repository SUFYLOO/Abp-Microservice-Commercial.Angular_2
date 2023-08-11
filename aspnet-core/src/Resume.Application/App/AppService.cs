using Resume.App.Users;
using Resume.CompanyContracts;
using Resume.CompanyInvitationsCodes;
using Resume.CompanyInvitationss;
using Resume.CompanyJobApplicationMethods;
using Resume.CompanyJobConditions;
using Resume.CompanyJobContents;
using Resume.CompanyJobPairs;
using Resume.CompanyJobPays;
using Resume.CompanyJobs;
using Resume.CompanyMains;
using Resume.CompanyPointss;
using Resume.CompanyUsers;
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
using Resume.ShareCodes;
using Resume.ShareDefaults;
using Resume.ShareDictionarys;
using Resume.ShareLanguages;
using Resume.ShareMessageTpls;
using Resume.ShareSendQueues;
using Resume.ShareTags;
using Resume.ShareUploads;
using Resume.SystemColumns;
using Resume.SystemDisplayMessages;
using Resume.SystemPages;
using Resume.SystemTables;
using Resume.SystemUserNotifys;
using Resume.SystemUserRoles;
using Resume.SystemValidates;
using Resume.TradeOderDetails;
using Resume.TradeOrders;
using Resume.TradeProducts;
using Resume.UserAccountBinds;
using Resume.UserCompanyBinds;
using Resume.UserCompanyJobApplies;
using Resume.UserCompanyJobFavs;
using Resume.UserCompanyJobPairs;
using Resume.UserInfos;
using Resume.UserMains;
using Resume.UserTokens;
using Resume.UserVerifys;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using Volo.Abp.Application.Services;
using Volo.Abp.Data;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Guids;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement;
using Volo.Abp.Uow;
using Volo.FileManagement.Directories;
using Volo.FileManagement.Files;
using Volo.Saas.Editions;
using Volo.Saas.Tenants;

namespace Resume.App
{
    public class AppService : ApplicationService
    {
        public readonly ICurrentTenant _currentTenant;
        public readonly IDataFilter _dataFilter;
        public readonly IGuidGenerator _guidGenerator;
        public readonly IEditionDataSeeder _editionDataSeeder;
        public readonly UnitOfWorkManager _unitOfWorkManager;

        public readonly UserManager<IdentityUser> _userManager;
        //public readonly AbpIdentityOptions _abpIdentityOptions;

        public readonly ITenantRepository _tenantRepository;
        public readonly ITenantManager _tenantManager;
        public readonly IDistributedEventBus _distributedEventBus;
        public readonly IDataSeeder _dataSeeder;
        public readonly IOrganizationUnitRepository _organizationUnitRepository;
        public readonly OrganizationUnitManager _organizationUnitManager;
        public readonly IPermissionManager _permissionManager;
        public readonly IPermissionGrantRepository _permissionGrantRepository;
        public readonly IIdentityRoleRepository _identityRoleRepository;
        public readonly IdentityRoleManager _identityRoleManager;
        public readonly IIdentityUserRepository _identityUserRepository;
        public readonly IdentityUserManager _identityUserManager;
        public readonly IHttpClientFactory _httpClientFactory;

        public readonly IUserMainRepository _userMainRepository;
        public readonly IUserInfoRepository _userInfoRepository;
        public readonly IUserCompanyBindRepository _userCompanyBindRepository;
        public readonly IUserAccountBindRepository _userAccountBindRepository;
        public readonly IUserVerifyRepository _userVerifyRepository;
        public readonly IUserTokenRepository _userTokenRepository;

        public readonly IResumeMainRepository _resumeMainRepository;
        public readonly IResumeSnapshotRepository _resumeSnapshotRepository;
        public readonly IResumeCommunicationRepository _resumeCommunicationRepository;
        public readonly IResumeDrvingLicenseRepository _resumeDrvingLicenseRepository;
        public readonly IResumeRecommenderRepository _resumeRecommenderRepository;
        public readonly IResumeLanguageRepository _resumeLanguageRepository;
        public readonly IResumeSkillRepository _resumeSkillRepository;
        public readonly IResumeDependentsRepository _resumeDependentsRepository;
        public readonly IResumeEducationsRepository _resumeEducationsRepository;
        public readonly IResumeExperiencesRepository _resumeExperiencesRepository;
        public readonly IResumeWorksRepository _resumeWorksRepository;

        public readonly ICompanyMainRepository _companyMainRepository;
        public readonly ICompanyJobRepository _companyJobRepository;
        public readonly ICompanyUserRepository _companyUserRepository;
        public readonly ICompanyInvitationsRepository _companyInvitationsRepository;
        public readonly ICompanyInvitationsCodeRepository _companyInvitationsCodeRepository;
        public readonly ICompanyContractRepository _companyContractRepository;
        public readonly ICompanyPointsRepository _companyPointsRepository;
        public readonly ICompanyJobPayRepository _companyJobPayRepository;
        public readonly ICompanyJobContentRepository _companyJobContentRepository;
        public readonly ICompanyJobConditionRepository _companyJobConditionRepository;
        public readonly ICompanyJobApplicationMethodRepository _companyJobApplicationMethodRepository;
        public readonly ICompanyJobPairRepository _companyJobPairRepository;

        public readonly ITradeProductRepository _tradeProductRepository;
        public readonly ITradeOderDetailRepository _tradeOderDetailRepository;
        public readonly ITradeOrderRepository _tradeOrder;

        public readonly IDirectoryDescriptorAppService _directoryDescriptorAppService;
        public readonly IDirectoryDescriptorRepository  _directoryDescriptorRepository;
        public readonly IFileDescriptorAppService _fileDescriptorAppService;
        public readonly IShareDefaultRepository _shareDefaultRepository;
        public readonly IShareCodeRepository _shareCodeRepository;
        public readonly IShareMessageTplRepository _shareMessageTplRepository;
        public readonly IShareSendQueueRepository _shareSendQueueRepository;
        public readonly IShareUploadRepository _shareUploadRepository;

        //abp原生service
        public readonly CompanyContractsAppService _companyContractsAppService;
        public readonly CompanyInvitationsCodesAppService _companyInvitationsCodesAppService;
        public readonly CompanyJobContentsAppService _companyJobContentsAppService;
        public readonly CompanyJobConditionsAppService _companyJobConditionAppService;
        public readonly CompanyJobApplicationMethodsAppService _companyJobApplicationMethodsAppService;
        public readonly CompanyJobPairsAppService _companyJobPairsAppService;
        public readonly CompanyJobPaysAppService _companyJobPaysAppService;
        public readonly CompanyJobsAppService _companyJobsAppService;
        public readonly CompanyMainsAppService _companyMainsAppService;
        public readonly CompanyPointssAppService _companyPointssAppService;
        public readonly CompanyUsersAppService _companyUsersAppService;

        public readonly ResumeCommunicationsAppService _resumeCommunicationsAppService;
        public readonly ResumeDependentssAppService _resumeDependentssAppService;
        public readonly ResumeDrvingLicensesAppService _resumeDrvingLicensesAppService;
        public readonly ResumeEducationssAppService _resumeEducationssAppService;
        public readonly ResumeExperiencessAppService _resumeExperiencessAppService;
        public readonly ResumeLanguagesAppService _resumeLanguagesAppService;
        public readonly ResumeMainsAppService _resumeMainsAppService;
        public readonly ResumeRecommendersAppService _resumeRecommendersAppService;
        public readonly ResumeSkillsAppService _resumeSkillsAppService;
        public readonly ResumeSnapshotsAppService _resumeSnapshotsAppService;
        public readonly ResumeWorkssAppService _resumeWorkssAppService;

        public readonly ShareCodesAppService _shareCodesAppService;
        public readonly ShareDefaultsAppService _shareDefaultsAppService;
        public readonly ShareDictionarysAppService _shareDictionarysAppService;
        public readonly ShareLanguagesAppService _shareLanguagesAppService;
        public readonly ShareMessageTplsAppService _shareMessageTplsAppService;
        public readonly ShareSendQueuesAppService _shareSendQueuesAppService;
        public readonly ShareTagsAppService _shareTagsAppService;
        public readonly ShareUploadsAppService _shareUploadsAppService;
        public readonly SystemColumnsAppService _systemColumnsAppService;
        public readonly SystemDisplayMessagesAppService _systemDisplayMessagesAppService;
        public readonly SystemPagesAppService _systemPagesAppService;
        public readonly SystemTablesAppService _systemTablesAppService;
        public readonly SystemUserNotifysAppService _systemUserNotifysAppService;
        public readonly SystemUserRolesAppService _systemUserRolesAppService;
        public readonly SystemValidatesAppService _systemValidatesAppService;

        public readonly TradeOderDetailsAppService _tradeOderDetailsAppService;
        public readonly TradeOrdersAppService _tradeOrdersAppService;
        public readonly TradeProductsAppService _tradeProductsAppService;

        public readonly UserAccountBindsAppService _userAccountBindsAppService;
        public readonly UserCompanyBindsAppService _userCompanyBindsAppService;
        public readonly UserCompanyJobAppliesAppService _userCompanyJobAppliesAppService;
        public readonly UserCompanyJobFavsAppService _userCompanyJobFavsAppService;
        public readonly UserCompanyJobPairsAppService _userCompanyJobPairsAppService;
        public readonly UserInfosAppService _userInfosAppService;
        public readonly UserMainsAppService _userMainsAppService;
        public readonly UserTokensAppService _userTokensAppService;
        public readonly UserVerifysAppService _userVerifysAppService;

        public readonly ILogger<AppService> _logger;

        public readonly IServiceProvider _serviceProvider;

        public AppService(
          ICurrentTenant currentTenant,
          IDataFilter dataFilter,
          IGuidGenerator guidGenerator,
          IEditionDataSeeder editionDataSeeder,
          UnitOfWorkManager unitOfWorkManager,

          UserManager<IdentityUser> userManager,
          //AbpIdentityOptions abpIdentityOptions,

          ITenantRepository tenantRepository,
          ITenantManager tenantManager,
          IDistributedEventBus distributedEventBus,
          IDataSeeder dataSeeder,
          IOrganizationUnitRepository organizationUnitRepository,
          OrganizationUnitManager organizationUnit,
          IPermissionManager permissionManager,
          IPermissionGrantRepository permissionGrantRepository,
          IIdentityRoleRepository identityRoleRepository,
          IdentityRoleManager identityRoleManager,
          IIdentityUserRepository identityUserRepository,
          IdentityUserManager identityUserManager,
          IHttpClientFactory httpClientFactory,

          IUserMainRepository userMainRepository,
          IUserInfoRepository userInfoRepository,
          IUserCompanyBindRepository userCompanyBindRepository,
          IUserAccountBindRepository userAccountBindRepository,
          IUserVerifyRepository userVerifyRepository,
          IUserTokenRepository userTokenRepository,

          IResumeMainRepository resumeMainRepository,
          IResumeSnapshotRepository resumeSnapshotRepository,
          IResumeCommunicationRepository resumeCommunicationRepository,
          IResumeDrvingLicenseRepository resumeDrvingLicenseRepository,
          IResumeRecommenderRepository resumeRecommenderRepository,
          IResumeLanguageRepository resumeLanguageRepository,
          IResumeSkillRepository resumeSkillRepository,
          IResumeDependentsRepository resumeDependentsRepository,
          IResumeEducationsRepository resumeEducationsRepository,
          IResumeExperiencesRepository resumeExperiencesRepository,
          IResumeWorksRepository resumeWorksRepository,

          ICompanyMainRepository companyMainRepository,
          ICompanyJobRepository companyJobRepository,
          ICompanyUserRepository companyUserRepository,
          ICompanyInvitationsRepository companyInvitationsRepository,
          ICompanyInvitationsCodeRepository companyInvitationsCodeRepository,
          ICompanyContractRepository companyContractRepository,
          ICompanyPointsRepository companyPointsRepository,
          ICompanyJobPayRepository companyJobPayRepository,
          ICompanyJobContentRepository companyJobContentRepository,
          ICompanyJobConditionRepository companyJobConditionRepository,
          ICompanyJobApplicationMethodRepository companyJobApplicationMethodRepository,
          ICompanyJobPairRepository companyJobPairRepository,

          ITradeProductRepository tradeProductRepository,
          ITradeOderDetailRepository tradeOderDetailRepository,
          ITradeOrderRepository tradeOrderRepository,

          IDirectoryDescriptorAppService directoryDescriptorAppService,
          IDirectoryDescriptorRepository directoryDescriptorRepository,
          IFileDescriptorAppService fileDescriptorAppService,
          IShareDefaultRepository shareDefaultRepository,
          IShareCodeRepository shareCodeRepository,
          IShareMessageTplRepository shareMessageTplRepository,
          IShareSendQueueRepository shareSendQueueRepository,
          IShareUploadRepository shareUploadRepository,

         //abp原生service
         CompanyContractsAppService companyContractsAppService,
         CompanyInvitationsCodesAppService companyInvitationsCodesAppService,
         CompanyJobContentsAppService companyJobContentsAppService,
         CompanyJobConditionsAppService companyJobConditionAppService,
         CompanyJobApplicationMethodsAppService companyJobApplicationMethodsAppService,
         CompanyJobPairsAppService companyJobPairsAppService,
         CompanyJobPaysAppService companyJobPaysAppService,
         CompanyJobsAppService companyJobsAppService,
         CompanyMainsAppService companyMainsAppService,
         CompanyPointssAppService companyPointssAppService,
         CompanyUsersAppService companyUsersAppService,

         ResumeCommunicationsAppService resumeCommunicationsAppService,
         ResumeDependentssAppService resumeDependentssAppService,
         ResumeDrvingLicensesAppService resumeDrvingLicensesAppService,
         ResumeEducationssAppService resumeEducationssAppService,
         ResumeExperiencessAppService resumeExperiencessAppService,
         ResumeLanguagesAppService resumeLanguagesAppService,
         ResumeMainsAppService resumeMainsAppService,
         ResumeRecommendersAppService resumeRecommendersAppService,
         ResumeSkillsAppService resumeSkillsAppService,
         ResumeSnapshotsAppService resumeSnapshotsAppService,
         ResumeWorkssAppService resumeWorkssAppService,

         ShareCodesAppService shareCodesAppService,
         ShareDefaultsAppService shareDefaultsAppService,
         ShareDictionarysAppService shareDictionarysAppService,
         ShareLanguagesAppService shareLanguagesAppService,
         ShareMessageTplsAppService shareMessageTplsAppService,
         ShareSendQueuesAppService shareSendQueuesAppService,
         ShareTagsAppService shareTagsAppService,
         ShareUploadsAppService shareUploadsAppService,
         SystemColumnsAppService systemColumnsAppService,
         SystemDisplayMessagesAppService systemDisplayMessagesAppService,
         SystemPagesAppService systemPagesAppService,
         SystemTablesAppService systemTablesAppService,
         SystemUserNotifysAppService systemUserNotifysAppService,
         SystemUserRolesAppService systemUserRolesAppService,
         SystemValidatesAppService systemValidatesAppService,

         TradeOderDetailsAppService tradeOderDetailsAppService,
         TradeOrdersAppService tradeOrdersAppService,
         TradeProductsAppService tradeProductsAppService,

         UserAccountBindsAppService userAccountBindsAppService,
         UserCompanyBindsAppService userCompanyBindsAppService,
         UserCompanyJobAppliesAppService userCompanyJobAppliesAppService,
         UserCompanyJobFavsAppService userCompanyJobFavsAppService,
         UserCompanyJobPairsAppService userCompanyJobPairsAppService,
         UserInfosAppService userInfosAppService,
         UserMainsAppService userMainsAppService,
         UserTokensAppService userTokensAppService,
         UserVerifysAppService userVerifysAppService,

          ILogger<AppService> logger,

          IServiceProvider serviceProvider
          )
        {
            _currentTenant = currentTenant;
            _dataFilter = dataFilter;
            _guidGenerator = guidGenerator;
            _editionDataSeeder = editionDataSeeder;
            _unitOfWorkManager = unitOfWorkManager;

            _userManager = userManager;
            //_abpIdentityOptions = abpIdentityOptions;

            _tenantRepository = tenantRepository;
            _tenantManager = tenantManager;
            _distributedEventBus = distributedEventBus;
            _dataSeeder = dataSeeder;
            _organizationUnitRepository = organizationUnitRepository;
            _organizationUnitManager = organizationUnit;
            _permissionManager = permissionManager;
            _permissionGrantRepository = permissionGrantRepository;
            _identityRoleRepository = identityRoleRepository;
            _identityRoleManager = identityRoleManager;
            _identityUserRepository = identityUserRepository;
            _identityUserManager = identityUserManager;
            _httpClientFactory = httpClientFactory;

            _userMainRepository = userMainRepository;
            _userInfoRepository = userInfoRepository;
            _userCompanyBindRepository = userCompanyBindRepository;
            _userAccountBindRepository = userAccountBindRepository;
            _userVerifyRepository = userVerifyRepository;
            _userTokenRepository = userTokenRepository;

            _resumeMainRepository = resumeMainRepository;
            _resumeSnapshotRepository = resumeSnapshotRepository;
            _resumeCommunicationRepository = resumeCommunicationRepository;
            _resumeDrvingLicenseRepository = resumeDrvingLicenseRepository;
            _resumeRecommenderRepository = resumeRecommenderRepository;
            _resumeLanguageRepository = resumeLanguageRepository;
            _resumeSkillRepository = resumeSkillRepository;
            _resumeDependentsRepository = resumeDependentsRepository;
            _resumeEducationsRepository = resumeEducationsRepository;
            _resumeExperiencesRepository = resumeExperiencesRepository;
            _resumeWorksRepository = resumeWorksRepository;

            _companyMainRepository = companyMainRepository;
            _companyJobRepository = companyJobRepository;
            _companyUserRepository = companyUserRepository;
            _companyInvitationsRepository = companyInvitationsRepository;
            _companyInvitationsCodeRepository = companyInvitationsCodeRepository;
            _companyContractRepository = companyContractRepository;
            _companyPointsRepository = companyPointsRepository;
            _companyJobPayRepository = companyJobPayRepository;
            _companyJobContentRepository = companyJobContentRepository;
            _companyJobConditionRepository = companyJobConditionRepository;
            _companyJobApplicationMethodRepository = companyJobApplicationMethodRepository;
            _companyJobPairRepository = companyJobPairRepository;

            _tradeProductRepository = tradeProductRepository;
            _tradeOderDetailRepository = tradeOderDetailRepository;
            _tradeOrder = tradeOrderRepository;

            _directoryDescriptorAppService = directoryDescriptorAppService;
            _directoryDescriptorRepository = directoryDescriptorRepository;
            _fileDescriptorAppService = fileDescriptorAppService;
            _shareDefaultRepository = shareDefaultRepository;
            _shareCodeRepository = shareCodeRepository;
            _shareMessageTplRepository = shareMessageTplRepository;
            _shareSendQueueRepository = shareSendQueueRepository;
            _shareUploadRepository = shareUploadRepository;

            //abp原生service
            _companyContractsAppService = companyContractsAppService;
            _companyInvitationsCodesAppService = companyInvitationsCodesAppService;
            _companyJobContentsAppService = companyJobContentsAppService;
            _companyJobConditionAppService = companyJobConditionAppService;
            _companyJobApplicationMethodsAppService = companyJobApplicationMethodsAppService;
            _companyJobPairsAppService = companyJobPairsAppService;
            _companyJobPaysAppService = companyJobPaysAppService;
            _companyJobsAppService = companyJobsAppService;
            _companyMainsAppService = companyMainsAppService;
            _companyPointssAppService = companyPointssAppService;
            _companyUsersAppService = companyUsersAppService;

            _resumeCommunicationsAppService = resumeCommunicationsAppService;
            _resumeDependentssAppService = resumeDependentssAppService;
            _resumeDrvingLicensesAppService = resumeDrvingLicensesAppService;
            _resumeEducationssAppService = resumeEducationssAppService;
            _resumeExperiencessAppService = resumeExperiencessAppService;
            _resumeLanguagesAppService = resumeLanguagesAppService;
            _resumeMainsAppService = resumeMainsAppService;
            _resumeRecommendersAppService = resumeRecommendersAppService;
            _resumeSkillsAppService = resumeSkillsAppService;
            _resumeSnapshotsAppService = resumeSnapshotsAppService;
            _resumeWorkssAppService = resumeWorkssAppService;

            _shareCodesAppService = shareCodesAppService;
            _shareDefaultsAppService = shareDefaultsAppService;
            _shareDictionarysAppService = shareDictionarysAppService;
            _shareLanguagesAppService = shareLanguagesAppService;
            _shareMessageTplsAppService = shareMessageTplsAppService;
            _shareSendQueuesAppService = shareSendQueuesAppService;
            _shareTagsAppService = shareTagsAppService;
            _shareUploadsAppService = shareUploadsAppService;
            _systemColumnsAppService = systemColumnsAppService;
            _systemDisplayMessagesAppService = systemDisplayMessagesAppService;
            _systemPagesAppService = systemPagesAppService;
            _systemTablesAppService = systemTablesAppService;
            _systemUserNotifysAppService = systemUserNotifysAppService;
            _systemUserRolesAppService = systemUserRolesAppService;
            _systemValidatesAppService = systemValidatesAppService;

            _tradeOderDetailsAppService = tradeOderDetailsAppService;
            _tradeOrdersAppService = tradeOrdersAppService;
            _tradeProductsAppService = tradeProductsAppService;

            _userAccountBindsAppService = userAccountBindsAppService;
            _userCompanyBindsAppService = userCompanyBindsAppService;
            _userCompanyJobAppliesAppService = userCompanyJobAppliesAppService;
            _userCompanyJobFavsAppService = userCompanyJobFavsAppService;
            _userCompanyJobPairsAppService = userCompanyJobPairsAppService;
            _userInfosAppService = userInfosAppService;
            _userMainsAppService = userMainsAppService;
            _userTokensAppService = userTokensAppService;
            _userVerifysAppService = userVerifysAppService;

            _logger = logger;

            _serviceProvider = serviceProvider;
        }
    }
}