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
using Volo.Abp.EntityFrameworkCore.Modeling;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.LanguageManagement.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TextTemplateManagement.EntityFrameworkCore;
using Volo.Saas.EntityFrameworkCore;
using Volo.Saas.Editions;
using Volo.Saas.Tenants;
using Volo.Abp.Gdpr;
using Volo.Abp.OpenIddict.EntityFrameworkCore;

namespace Resume.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityProDbContext))]
[ReplaceDbContext(typeof(ISaasDbContext))]
[ConnectionStringName("Default")]
public class ResumeDbContext :
    AbpDbContext<ResumeDbContext>,
    IIdentityProDbContext,
    ISaasDbContext
{
    public DbSet<UserVerify> UserVerifys { get; set; }
    public DbSet<UserToken> UserTokens { get; set; }
    public DbSet<UserMain> UserMains { get; set; }
    public DbSet<UserInfo> UserInfos { get; set; }
    public DbSet<UserCompanyJobPair> UserCompanyJobPairs { get; set; }
    public DbSet<UserCompanyJobFav> UserCompanyJobFavs { get; set; }
    public DbSet<UserCompanyJobApply> UserCompanyJobApplies { get; set; }
    public DbSet<UserCompanyBind> UserCompanyBinds { get; set; }
    public DbSet<UserAccountBind> UserAccountBinds { get; set; }
    public DbSet<TradeProduct> TradeProducts { get; set; }
    public DbSet<TradeOrder> TradeOrders { get; set; }
    public DbSet<TradeOderDetail> TradeOderDetails { get; set; }
    public DbSet<SystemValidate> SystemValidates { get; set; }
    public DbSet<SystemUserRole> SystemUserRoles { get; set; }
    public DbSet<SystemUserNotify> SystemUserNotifys { get; set; }
    public DbSet<SystemTable> SystemTables { get; set; }
    public DbSet<SystemPage> SystemPages { get; set; }
    public DbSet<SystemDisplayMessage> SystemDisplayMessages { get; set; }
    public DbSet<SystemColumn> SystemColumns { get; set; }
    public DbSet<ShareUpload> ShareUploads { get; set; }
    public DbSet<ShareTag> ShareTags { get; set; }
    public DbSet<ShareSendQueue> ShareSendQueues { get; set; }
    public DbSet<ShareMessageTpl> ShareMessageTpls { get; set; }
    public DbSet<ShareLanguage> ShareLanguages { get; set; }
    public DbSet<ShareDictionary> ShareDictionarys { get; set; }
    public DbSet<ShareDefault> ShareDefaults { get; set; }
    public DbSet<ShareCode> ShareCodes { get; set; }
    public DbSet<ResumeWorks> ResumeWorkss { get; set; }
    public DbSet<ResumeSnapshot> ResumeSnapshots { get; set; }
    public DbSet<ResumeSkill> ResumeSkills { get; set; }
    public DbSet<ResumeRecommender> ResumeRecommenders { get; set; }
    public DbSet<ResumeMain> ResumeMains { get; set; }
    public DbSet<ResumeLanguage> ResumeLanguages { get; set; }
    public DbSet<ResumeExperiences> ResumeExperiencess { get; set; }
    public DbSet<ResumeEducations> ResumeEducationss { get; set; }
    public DbSet<ResumeDrvingLicense> ResumeDrvingLicenses { get; set; }
    public DbSet<ResumeDependents> ResumeDependentss { get; set; }
    public DbSet<ResumeCommunication> ResumeCommunications { get; set; }
    public DbSet<CompanyUser> CompanyUsers { get; set; }
    public DbSet<CompanyPoints> CompanyPointss { get; set; }
    public DbSet<CompanyMain> CompanyMains { get; set; }
    public DbSet<CompanyJobPay> CompanyJobPays { get; set; }
    public DbSet<CompanyJobPair> CompanyJobPairs { get; set; }
    public DbSet<CompanyJobContent> CompanyJobContents { get; set; }
    public DbSet<CompanyJobCondition> CompanyJobConditions { get; set; }
    public DbSet<CompanyJobApplicationMethod> CompanyJobApplicationMethods { get; set; }
    public DbSet<CompanyJob> CompanyJobs { get; set; }
    public DbSet<CompanyInvitationsCode> CompanyInvitationsCodes { get; set; }
    public DbSet<CompanyInvitations> CompanyInvitationss { get; set; }
    public DbSet<CompanyContract> CompanyContracts { get; set; }
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityProDbContext and ISaasDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityProDbContext and ISaasDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    // Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; }

    // SaaS
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<Edition> Editions { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public ResumeDbContext(DbContextOptions<ResumeDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentityPro();
        builder.ConfigureOpenIddictPro();
        builder.ConfigureFeatureManagement();
        builder.ConfigureLanguageManagement();
        builder.ConfigureSaas();
        builder.ConfigureTextTemplateManagement();
        builder.ConfigureBlobStoring();
        builder.ConfigureGdpr();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(ResumeConsts.DbTablePrefix + "YourEntities", ResumeConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
        builder.Entity<CompanyContract>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "CompanyContracts", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(CompanyContract.TenantId));
        b.Property(x => x.CompanyMainId).HasColumnName(nameof(CompanyContract.CompanyMainId));
        b.Property(x => x.PlanCode).HasColumnName(nameof(CompanyContract.PlanCode)).IsRequired().HasMaxLength(CompanyContractConsts.PlanCodeMaxLength);
        b.Property(x => x.PointsTotal).HasColumnName(nameof(CompanyContract.PointsTotal));
        b.Property(x => x.PointsPay).HasColumnName(nameof(CompanyContract.PointsPay));
        b.Property(x => x.PointsGift).HasColumnName(nameof(CompanyContract.PointsGift));
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(CompanyContract.ExtendedInformation)).HasMaxLength(CompanyContractConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(CompanyContract.DateA));
        b.Property(x => x.DateD).HasColumnName(nameof(CompanyContract.DateD));
        b.Property(x => x.Sort).HasColumnName(nameof(CompanyContract.Sort));
        b.Property(x => x.Note).HasColumnName(nameof(CompanyContract.Note)).HasMaxLength(CompanyContractConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(CompanyContract.Status)).IsRequired().HasMaxLength(CompanyContractConsts.StatusMaxLength);
    });
        builder.Entity<CompanyInvitations>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "CompanyInvitationss", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(CompanyInvitations.TenantId));
        b.Property(x => x.CompanyMainId).HasColumnName(nameof(CompanyInvitations.CompanyMainId));
        b.Property(x => x.CompanyJobId).HasColumnName(nameof(CompanyInvitations.CompanyJobId));
        b.Property(x => x.OpenAllJob).HasColumnName(nameof(CompanyInvitations.OpenAllJob)).IsRequired();
        b.Property(x => x.UserMainId).HasColumnName(nameof(CompanyInvitations.UserMainId));
        b.Property(x => x.UserMainName).HasColumnName(nameof(CompanyInvitations.UserMainName)).HasMaxLength(CompanyInvitationsConsts.UserMainNameMaxLength);
        b.Property(x => x.UserMainLoginMobilePhone).HasColumnName(nameof(CompanyInvitations.UserMainLoginMobilePhone)).HasMaxLength(CompanyInvitationsConsts.UserMainLoginMobilePhoneMaxLength);
        b.Property(x => x.UserMainLoginEmail).HasColumnName(nameof(CompanyInvitations.UserMainLoginEmail)).HasMaxLength(CompanyInvitationsConsts.UserMainLoginEmailMaxLength);
        b.Property(x => x.UserMainLoginIdentityNo).HasColumnName(nameof(CompanyInvitations.UserMainLoginIdentityNo)).HasMaxLength(CompanyInvitationsConsts.UserMainLoginIdentityNoMaxLength);
        b.Property(x => x.SendTypeCode).HasColumnName(nameof(CompanyInvitations.SendTypeCode)).IsRequired().HasMaxLength(CompanyInvitationsConsts.SendTypeCodeMaxLength);
        b.Property(x => x.SendStatusCode).HasColumnName(nameof(CompanyInvitations.SendStatusCode)).IsRequired().HasMaxLength(CompanyInvitationsConsts.SendStatusCodeMaxLength);
        b.Property(x => x.ResumeFlowStageCode).HasColumnName(nameof(CompanyInvitations.ResumeFlowStageCode)).IsRequired().HasMaxLength(CompanyInvitationsConsts.ResumeFlowStageCodeMaxLength);
        b.Property(x => x.IsRead).HasColumnName(nameof(CompanyInvitations.IsRead)).IsRequired();
        b.Property(x => x.UserCompanyBindId).HasColumnName(nameof(CompanyInvitations.UserCompanyBindId));
        b.Property(x => x.ResumeSnapshotId).HasColumnName(nameof(CompanyInvitations.ResumeSnapshotId));
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(CompanyInvitations.ExtendedInformation)).HasMaxLength(CompanyInvitationsConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(CompanyInvitations.DateA)).IsRequired();
        b.Property(x => x.DateD).HasColumnName(nameof(CompanyInvitations.DateD)).IsRequired();
        b.Property(x => x.Sort).HasColumnName(nameof(CompanyInvitations.Sort)).IsRequired();
        b.Property(x => x.Note).HasColumnName(nameof(CompanyInvitations.Note)).HasMaxLength(CompanyInvitationsConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(CompanyInvitations.Status)).IsRequired().HasMaxLength(CompanyInvitationsConsts.StatusMaxLength);
    });
        builder.Entity<CompanyInvitationsCode>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "CompanyInvitationsCodes", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(CompanyInvitationsCode.TenantId));
        b.Property(x => x.CompanyMainId).HasColumnName(nameof(CompanyInvitationsCode.CompanyMainId));
        b.Property(x => x.CompanyJobId).HasColumnName(nameof(CompanyInvitationsCode.CompanyJobId));
        b.Property(x => x.CompanyInvitationId).HasColumnName(nameof(CompanyInvitationsCode.CompanyInvitationId)).IsRequired().HasMaxLength(CompanyInvitationsCodeConsts.CompanyInvitationIdMaxLength);
        b.Property(x => x.VerifyId).HasColumnName(nameof(CompanyInvitationsCode.VerifyId)).IsRequired().HasMaxLength(CompanyInvitationsCodeConsts.VerifyIdMaxLength);
        b.Property(x => x.VerifyCode).HasColumnName(nameof(CompanyInvitationsCode.VerifyCode)).IsRequired().HasMaxLength(CompanyInvitationsCodeConsts.VerifyCodeMaxLength);
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(CompanyInvitationsCode.ExtendedInformation)).HasMaxLength(CompanyInvitationsCodeConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(CompanyInvitationsCode.DateA));
        b.Property(x => x.DateD).HasColumnName(nameof(CompanyInvitationsCode.DateD));
        b.Property(x => x.Sort).HasColumnName(nameof(CompanyInvitationsCode.Sort));
        b.Property(x => x.Note).HasColumnName(nameof(CompanyInvitationsCode.Note)).HasMaxLength(CompanyInvitationsCodeConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(CompanyInvitationsCode.Status)).IsRequired().HasMaxLength(CompanyInvitationsCodeConsts.StatusMaxLength);
    });
        builder.Entity<CompanyJob>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "CompanyJobs", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(CompanyJob.TenantId));
        b.Property(x => x.CompanyMainId).HasColumnName(nameof(CompanyJob.CompanyMainId));
        b.Property(x => x.Name).HasColumnName(nameof(CompanyJob.Name)).IsRequired().HasMaxLength(CompanyJobConsts.NameMaxLength);
        b.Property(x => x.JobTypeCode).HasColumnName(nameof(CompanyJob.JobTypeCode)).IsRequired().HasMaxLength(CompanyJobConsts.JobTypeCodeMaxLength);
        b.Property(x => x.JobOpen).HasColumnName(nameof(CompanyJob.JobOpen)).IsRequired();
        b.Property(x => x.MailTplId).HasColumnName(nameof(CompanyJob.MailTplId)).IsRequired().HasMaxLength(CompanyJobConsts.MailTplIdMaxLength);
        b.Property(x => x.SMSTplId).HasColumnName(nameof(CompanyJob.SMSTplId)).IsRequired().HasMaxLength(CompanyJobConsts.SMSTplIdMaxLength);
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(CompanyJob.ExtendedInformation)).HasMaxLength(CompanyJobConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(CompanyJob.DateA)).IsRequired();
        b.Property(x => x.DateD).HasColumnName(nameof(CompanyJob.DateD)).IsRequired();
        b.Property(x => x.Sort).HasColumnName(nameof(CompanyJob.Sort)).IsRequired();
        b.Property(x => x.Note).HasColumnName(nameof(CompanyJob.Note)).HasMaxLength(CompanyJobConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(CompanyJob.Status)).IsRequired().HasMaxLength(CompanyJobConsts.StatusMaxLength);
    });
        builder.Entity<CompanyJobApplicationMethod>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "CompanyJobApplicationMethods", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(CompanyJobApplicationMethod.TenantId));
        b.Property(x => x.CompanyMainId).HasColumnName(nameof(CompanyJobApplicationMethod.CompanyMainId));
        b.Property(x => x.CompanyJobId).HasColumnName(nameof(CompanyJobApplicationMethod.CompanyJobId));
        b.Property(x => x.OrgDept).HasColumnName(nameof(CompanyJobApplicationMethod.OrgDept)).HasMaxLength(CompanyJobApplicationMethodConsts.OrgDeptMaxLength);
        b.Property(x => x.OrgContactPerson).HasColumnName(nameof(CompanyJobApplicationMethod.OrgContactPerson)).HasMaxLength(CompanyJobApplicationMethodConsts.OrgContactPersonMaxLength);
        b.Property(x => x.OrgContactMail).HasColumnName(nameof(CompanyJobApplicationMethod.OrgContactMail)).HasMaxLength(CompanyJobApplicationMethodConsts.OrgContactMailMaxLength);
        b.Property(x => x.ToRespondDay).HasColumnName(nameof(CompanyJobApplicationMethod.ToRespondDay));
        b.Property(x => x.ToRespond).HasColumnName(nameof(CompanyJobApplicationMethod.ToRespond));
        b.Property(x => x.SystemSendResume).HasColumnName(nameof(CompanyJobApplicationMethod.SystemSendResume));
        b.Property(x => x.DisplayMail).HasColumnName(nameof(CompanyJobApplicationMethod.DisplayMail));
        b.Property(x => x.Telephone).HasColumnName(nameof(CompanyJobApplicationMethod.Telephone)).HasMaxLength(CompanyJobApplicationMethodConsts.TelephoneMaxLength);
        b.Property(x => x.Personally).HasColumnName(nameof(CompanyJobApplicationMethod.Personally)).HasMaxLength(CompanyJobApplicationMethodConsts.PersonallyMaxLength);
        b.Property(x => x.PersonallyAddress).HasColumnName(nameof(CompanyJobApplicationMethod.PersonallyAddress)).HasMaxLength(CompanyJobApplicationMethodConsts.PersonallyAddressMaxLength);
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(CompanyJobApplicationMethod.ExtendedInformation)).HasMaxLength(CompanyJobApplicationMethodConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(CompanyJobApplicationMethod.DateA));
        b.Property(x => x.DateD).HasColumnName(nameof(CompanyJobApplicationMethod.DateD));
        b.Property(x => x.Sort).HasColumnName(nameof(CompanyJobApplicationMethod.Sort));
        b.Property(x => x.Note).HasColumnName(nameof(CompanyJobApplicationMethod.Note)).HasMaxLength(CompanyJobApplicationMethodConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(CompanyJobApplicationMethod.Status)).IsRequired().HasMaxLength(CompanyJobApplicationMethodConsts.StatusMaxLength);
    });
        builder.Entity<CompanyJobCondition>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "CompanyJobConditions", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(CompanyJobCondition.TenantId));
        b.Property(x => x.CompanyMainCode).HasColumnName(nameof(CompanyJobCondition.CompanyMainCode)).IsRequired().HasMaxLength(CompanyJobConditionConsts.CompanyMainCodeMaxLength);
        b.Property(x => x.CompanyJobCode).HasColumnName(nameof(CompanyJobCondition.CompanyJobCode)).IsRequired().HasMaxLength(CompanyJobConditionConsts.CompanyJobCodeMaxLength);
        b.Property(x => x.WorkExperienceYearCode).HasColumnName(nameof(CompanyJobCondition.WorkExperienceYearCode)).IsRequired().HasMaxLength(CompanyJobConditionConsts.WorkExperienceYearCodeMaxLength);
        b.Property(x => x.EducationLevel).HasColumnName(nameof(CompanyJobCondition.EducationLevel)).HasMaxLength(CompanyJobConditionConsts.EducationLevelMaxLength);
        b.Property(x => x.MajorDepartmentCategory).HasColumnName(nameof(CompanyJobCondition.MajorDepartmentCategory)).HasMaxLength(CompanyJobConditionConsts.MajorDepartmentCategoryMaxLength);
        b.Property(x => x.LanguageCategory).HasColumnName(nameof(CompanyJobCondition.LanguageCategory)).HasMaxLength(CompanyJobConditionConsts.LanguageCategoryMaxLength);
        b.Property(x => x.ComputerExpertise).HasColumnName(nameof(CompanyJobCondition.ComputerExpertise)).HasMaxLength(CompanyJobConditionConsts.ComputerExpertiseMaxLength);
        b.Property(x => x.ProfessionalLicense).HasColumnName(nameof(CompanyJobCondition.ProfessionalLicense)).HasMaxLength(CompanyJobConditionConsts.ProfessionalLicenseMaxLength);
        b.Property(x => x.DrvingLicense).HasColumnName(nameof(CompanyJobCondition.DrvingLicense)).HasMaxLength(CompanyJobConditionConsts.DrvingLicenseMaxLength);
        b.Property(x => x.EtcCondition).HasColumnName(nameof(CompanyJobCondition.EtcCondition)).HasMaxLength(CompanyJobConditionConsts.EtcConditionMaxLength);
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(CompanyJobCondition.ExtendedInformation)).HasMaxLength(CompanyJobConditionConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(CompanyJobCondition.DateA));
        b.Property(x => x.DateD).HasColumnName(nameof(CompanyJobCondition.DateD));
        b.Property(x => x.Sort).HasColumnName(nameof(CompanyJobCondition.Sort));
        b.Property(x => x.Note).HasColumnName(nameof(CompanyJobCondition.Note)).HasMaxLength(CompanyJobConditionConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(CompanyJobCondition.Status)).IsRequired().HasMaxLength(CompanyJobConditionConsts.StatusMaxLength);
    });
        builder.Entity<CompanyJobContent>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "CompanyJobContents", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(CompanyJobContent.TenantId));
        b.Property(x => x.CompanyMainId).HasColumnName(nameof(CompanyJobContent.CompanyMainId));
        b.Property(x => x.CompanyJobId).HasColumnName(nameof(CompanyJobContent.CompanyJobId));
        b.Property(x => x.Name).HasColumnName(nameof(CompanyJobContent.Name)).IsRequired().HasMaxLength(CompanyJobContentConsts.NameMaxLength);
        b.Property(x => x.JobTypeCode).HasColumnName(nameof(CompanyJobContent.JobTypeCode)).IsRequired().HasMaxLength(CompanyJobContentConsts.JobTypeCodeMaxLength);
        b.Property(x => x.PeopleRequiredNumber).HasColumnName(nameof(CompanyJobContent.PeopleRequiredNumber));
        b.Property(x => x.PeopleRequiredNumberUnlimited).HasColumnName(nameof(CompanyJobContent.PeopleRequiredNumberUnlimited));
        b.Property(x => x.JobType).HasColumnName(nameof(CompanyJobContent.JobType)).HasMaxLength(CompanyJobContentConsts.JobTypeMaxLength);
        b.Property(x => x.JobTypeContent).HasColumnName(nameof(CompanyJobContent.JobTypeContent));
        b.Property(x => x.SalaryPayTypeCode).HasColumnName(nameof(CompanyJobContent.SalaryPayTypeCode)).IsRequired().HasMaxLength(CompanyJobContentConsts.SalaryPayTypeCodeMaxLength);
        b.Property(x => x.SalaryMin).HasColumnName(nameof(CompanyJobContent.SalaryMin));
        b.Property(x => x.SalaryMax).HasColumnName(nameof(CompanyJobContent.SalaryMax));
        b.Property(x => x.SalaryUp).HasColumnName(nameof(CompanyJobContent.SalaryUp));
        b.Property(x => x.WorkPlace).HasColumnName(nameof(CompanyJobContent.WorkPlace)).HasMaxLength(CompanyJobContentConsts.WorkPlaceMaxLength);
        b.Property(x => x.WorkHours).HasColumnName(nameof(CompanyJobContent.WorkHours)).HasMaxLength(CompanyJobContentConsts.WorkHoursMaxLength);
        b.Property(x => x.WorkHour).HasColumnName(nameof(CompanyJobContent.WorkHour)).HasMaxLength(CompanyJobContentConsts.WorkHourMaxLength);
        b.Property(x => x.WorkShift).HasColumnName(nameof(CompanyJobContent.WorkShift));
        b.Property(x => x.WorkRemoteAllow).HasColumnName(nameof(CompanyJobContent.WorkRemoteAllow));
        b.Property(x => x.WorkRemoteTypeCode).HasColumnName(nameof(CompanyJobContent.WorkRemoteTypeCode)).IsRequired().HasMaxLength(CompanyJobContentConsts.WorkRemoteTypeCodeMaxLength);
        b.Property(x => x.WorkRemote).HasColumnName(nameof(CompanyJobContent.WorkRemote)).HasMaxLength(CompanyJobContentConsts.WorkRemoteMaxLength);
        b.Property(x => x.WorkDifferentPlaces).HasColumnName(nameof(CompanyJobContent.WorkDifferentPlaces)).HasMaxLength(CompanyJobContentConsts.WorkDifferentPlacesMaxLength);
        b.Property(x => x.HolidaySystemCode).HasColumnName(nameof(CompanyJobContent.HolidaySystemCode)).IsRequired().HasMaxLength(CompanyJobContentConsts.HolidaySystemCodeMaxLength);
        b.Property(x => x.WorkDayCode).HasColumnName(nameof(CompanyJobContent.WorkDayCode)).IsRequired().HasMaxLength(CompanyJobContentConsts.WorkDayCodeMaxLength);
        b.Property(x => x.WorkIdentityCode).HasColumnName(nameof(CompanyJobContent.WorkIdentityCode)).HasMaxLength(CompanyJobContentConsts.WorkIdentityCodeMaxLength);
        b.Property(x => x.DisabilityCategory).HasColumnName(nameof(CompanyJobContent.DisabilityCategory)).HasMaxLength(CompanyJobContentConsts.DisabilityCategoryMaxLength);
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(CompanyJobContent.ExtendedInformation)).HasMaxLength(CompanyJobContentConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(CompanyJobContent.DateA));
        b.Property(x => x.DateD).HasColumnName(nameof(CompanyJobContent.DateD));
        b.Property(x => x.Sort).HasColumnName(nameof(CompanyJobContent.Sort));
        b.Property(x => x.Note).HasColumnName(nameof(CompanyJobContent.Note)).HasMaxLength(CompanyJobContentConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(CompanyJobContent.Status)).IsRequired().HasMaxLength(CompanyJobContentConsts.StatusMaxLength);
    });
        builder.Entity<CompanyJobPair>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "CompanyJobPairs", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(CompanyJobPair.TenantId));
        b.Property(x => x.CompanyMainId).HasColumnName(nameof(CompanyJobPair.CompanyMainId));
        b.Property(x => x.Name).HasColumnName(nameof(CompanyJobPair.Name)).IsRequired().HasMaxLength(CompanyJobPairConsts.NameMaxLength);
        b.Property(x => x.PairCondition).HasColumnName(nameof(CompanyJobPair.PairCondition)).HasMaxLength(CompanyJobPairConsts.PairConditionMaxLength);
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(CompanyJobPair.ExtendedInformation)).HasMaxLength(CompanyJobPairConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(CompanyJobPair.DateA));
        b.Property(x => x.DateD).HasColumnName(nameof(CompanyJobPair.DateD));
        b.Property(x => x.Sort).HasColumnName(nameof(CompanyJobPair.Sort));
        b.Property(x => x.Note).HasColumnName(nameof(CompanyJobPair.Note)).HasMaxLength(CompanyJobPairConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(CompanyJobPair.Status)).IsRequired().HasMaxLength(CompanyJobPairConsts.StatusMaxLength);
    });
        builder.Entity<CompanyJobPay>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "CompanyJobPays", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(CompanyJobPay.TenantId));
        b.Property(x => x.CompanyMainId).HasColumnName(nameof(CompanyJobPay.CompanyMainId));
        b.Property(x => x.CompanyJobId).HasColumnName(nameof(CompanyJobPay.CompanyJobId));
        b.Property(x => x.JobPayTypeCode).HasColumnName(nameof(CompanyJobPay.JobPayTypeCode)).IsRequired().HasMaxLength(CompanyJobPayConsts.JobPayTypeCodeMaxLength);
        b.Property(x => x.DateReal).HasColumnName(nameof(CompanyJobPay.DateReal));
        b.Property(x => x.IsCancel).HasColumnName(nameof(CompanyJobPay.IsCancel));
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(CompanyJobPay.ExtendedInformation)).HasMaxLength(CompanyJobPayConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(CompanyJobPay.DateA));
        b.Property(x => x.DateD).HasColumnName(nameof(CompanyJobPay.DateD));
        b.Property(x => x.Sort).HasColumnName(nameof(CompanyJobPay.Sort));
        b.Property(x => x.Note).HasColumnName(nameof(CompanyJobPay.Note)).HasMaxLength(CompanyJobPayConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(CompanyJobPay.Status)).IsRequired().HasMaxLength(CompanyJobPayConsts.StatusMaxLength);
    });
        builder.Entity<CompanyMain>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "CompanyMains", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(CompanyMain.TenantId));
        b.Property(x => x.Name).HasColumnName(nameof(CompanyMain.Name)).IsRequired().HasMaxLength(CompanyMainConsts.NameMaxLength);
        b.Property(x => x.Compilation).HasColumnName(nameof(CompanyMain.Compilation)).HasMaxLength(CompanyMainConsts.CompilationMaxLength);
        b.Property(x => x.OfficePhone).HasColumnName(nameof(CompanyMain.OfficePhone)).HasMaxLength(CompanyMainConsts.OfficePhoneMaxLength);
        b.Property(x => x.FaxPhone).HasColumnName(nameof(CompanyMain.FaxPhone)).HasMaxLength(CompanyMainConsts.FaxPhoneMaxLength);
        b.Property(x => x.Address).HasColumnName(nameof(CompanyMain.Address)).HasMaxLength(CompanyMainConsts.AddressMaxLength);
        b.Property(x => x.Principal).HasColumnName(nameof(CompanyMain.Principal)).HasMaxLength(CompanyMainConsts.PrincipalMaxLength);
        b.Property(x => x.AllowSearch).HasColumnName(nameof(CompanyMain.AllowSearch));
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(CompanyMain.ExtendedInformation)).HasMaxLength(CompanyMainConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(CompanyMain.DateA)).IsRequired();
        b.Property(x => x.DateD).HasColumnName(nameof(CompanyMain.DateD)).IsRequired();
        b.Property(x => x.Note).HasColumnName(nameof(CompanyMain.Note)).HasMaxLength(CompanyMainConsts.NoteMaxLength);
        b.Property(x => x.Sort).HasColumnName(nameof(CompanyMain.Sort)).IsRequired();
        b.Property(x => x.Status).HasColumnName(nameof(CompanyMain.Status)).IsRequired().HasMaxLength(CompanyMainConsts.StatusMaxLength);
        b.Property(x => x.IndustryCategory).HasColumnName(nameof(CompanyMain.IndustryCategory)).IsRequired().HasMaxLength(CompanyMainConsts.IndustryCategoryMaxLength);
        b.Property(x => x.CompanyUrl).HasColumnName(nameof(CompanyMain.CompanyUrl)).HasMaxLength(CompanyMainConsts.CompanyUrlMaxLength);
        b.Property(x => x.CapitalAmount).HasColumnName(nameof(CompanyMain.CapitalAmount));
        b.Property(x => x.HideCapitalAmount).HasColumnName(nameof(CompanyMain.HideCapitalAmount));
        b.Property(x => x.CompanyScaleCode).HasColumnName(nameof(CompanyMain.CompanyScaleCode)).IsRequired().HasMaxLength(CompanyMainConsts.CompanyScaleCodeMaxLength);
        b.Property(x => x.HidePrincipal).HasColumnName(nameof(CompanyMain.HidePrincipal));
        b.Property(x => x.CompanyUserId).HasColumnName(nameof(CompanyMain.CompanyUserId));
        b.Property(x => x.CompanyProfile).HasColumnName(nameof(CompanyMain.CompanyProfile)).HasMaxLength(CompanyMainConsts.CompanyProfileMaxLength);
        b.Property(x => x.BusinessPhilosophy).HasColumnName(nameof(CompanyMain.BusinessPhilosophy)).HasMaxLength(CompanyMainConsts.BusinessPhilosophyMaxLength);
        b.Property(x => x.OperatingItems).HasColumnName(nameof(CompanyMain.OperatingItems)).HasMaxLength(CompanyMainConsts.OperatingItemsMaxLength);
        b.Property(x => x.WelfareSystem).HasColumnName(nameof(CompanyMain.WelfareSystem)).HasMaxLength(CompanyMainConsts.WelfareSystemMaxLength);
        b.Property(x => x.Matching).HasColumnName(nameof(CompanyMain.Matching));
        b.Property(x => x.ContractPass).HasColumnName(nameof(CompanyMain.ContractPass));
    });
        builder.Entity<CompanyPoints>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "CompanyPointss", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(CompanyPoints.TenantId));
        b.Property(x => x.CompanyMainId).HasColumnName(nameof(CompanyPoints.CompanyMainId));
        b.Property(x => x.CompanyPointsTypeCode).HasColumnName(nameof(CompanyPoints.CompanyPointsTypeCode)).HasMaxLength(CompanyPointsConsts.CompanyPointsTypeCodeMaxLength);
        b.Property(x => x.Points).HasColumnName(nameof(CompanyPoints.Points));
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(CompanyPoints.ExtendedInformation)).HasMaxLength(CompanyPointsConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(CompanyPoints.DateA));
        b.Property(x => x.DateD).HasColumnName(nameof(CompanyPoints.DateD));
        b.Property(x => x.Sort).HasColumnName(nameof(CompanyPoints.Sort));
        b.Property(x => x.Note).HasColumnName(nameof(CompanyPoints.Note)).HasMaxLength(CompanyPointsConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(CompanyPoints.Status)).IsRequired().HasMaxLength(CompanyPointsConsts.StatusMaxLength);
    });
        builder.Entity<CompanyUser>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "CompanyUsers", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(CompanyUser.TenantId));
        b.Property(x => x.CompanyMainId).HasColumnName(nameof(CompanyUser.CompanyMainId));
        b.Property(x => x.UserMainId).HasColumnName(nameof(CompanyUser.UserMainId));
        b.Property(x => x.JobName).HasColumnName(nameof(CompanyUser.JobName)).HasMaxLength(CompanyUserConsts.JobNameMaxLength);
        b.Property(x => x.OfficePhone).HasColumnName(nameof(CompanyUser.OfficePhone)).HasMaxLength(CompanyUserConsts.OfficePhoneMaxLength);
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(CompanyUser.ExtendedInformation)).HasMaxLength(CompanyUserConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(CompanyUser.DateA)).IsRequired();
        b.Property(x => x.DateD).HasColumnName(nameof(CompanyUser.DateD)).IsRequired();
        b.Property(x => x.Sort).HasColumnName(nameof(CompanyUser.Sort)).IsRequired();
        b.Property(x => x.Note).HasColumnName(nameof(CompanyUser.Note)).HasMaxLength(CompanyUserConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(CompanyUser.Status)).IsRequired().HasMaxLength(CompanyUserConsts.StatusMaxLength);
        b.Property(x => x.MatchingReceive).HasColumnName(nameof(CompanyUser.MatchingReceive));
    });
        builder.Entity<ResumeCommunication>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "ResumeCommunications", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(ResumeCommunication.TenantId));
        b.Property(x => x.ResumeMainId).HasColumnName(nameof(ResumeCommunication.ResumeMainId));
        b.Property(x => x.CommunicationCategoryCode).HasColumnName(nameof(ResumeCommunication.CommunicationCategoryCode)).IsRequired().HasMaxLength(ResumeCommunicationConsts.CommunicationCategoryCodeMaxLength);
        b.Property(x => x.CommunicationValue).HasColumnName(nameof(ResumeCommunication.CommunicationValue)).IsRequired().HasMaxLength(ResumeCommunicationConsts.CommunicationValueMaxLength);
        b.Property(x => x.Main).HasColumnName(nameof(ResumeCommunication.Main)).IsRequired();
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(ResumeCommunication.ExtendedInformation)).HasMaxLength(ResumeCommunicationConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(ResumeCommunication.DateA)).IsRequired();
        b.Property(x => x.DateD).HasColumnName(nameof(ResumeCommunication.DateD)).IsRequired();
        b.Property(x => x.Sort).HasColumnName(nameof(ResumeCommunication.Sort)).IsRequired();
        b.Property(x => x.Note).HasColumnName(nameof(ResumeCommunication.Note)).HasMaxLength(ResumeCommunicationConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(ResumeCommunication.Status)).IsRequired().HasMaxLength(ResumeCommunicationConsts.StatusMaxLength);
    });
        builder.Entity<ResumeDependents>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "ResumeDependentss", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(ResumeDependents.TenantId));
        b.Property(x => x.ResumeMainId).HasColumnName(nameof(ResumeDependents.ResumeMainId));
        b.Property(x => x.Name).HasColumnName(nameof(ResumeDependents.Name)).IsRequired().HasMaxLength(ResumeDependentsConsts.NameMaxLength);
        b.Property(x => x.IdentityNo).HasColumnName(nameof(ResumeDependents.IdentityNo)).HasMaxLength(ResumeDependentsConsts.IdentityNoMaxLength);
        b.Property(x => x.KinshipCode).HasColumnName(nameof(ResumeDependents.KinshipCode)).IsRequired().HasMaxLength(ResumeDependentsConsts.KinshipCodeMaxLength);
        b.Property(x => x.BirthDate).HasColumnName(nameof(ResumeDependents.BirthDate)).IsRequired();
        b.Property(x => x.Address).HasColumnName(nameof(ResumeDependents.Address)).HasMaxLength(ResumeDependentsConsts.AddressMaxLength);
        b.Property(x => x.MobilePhone).HasColumnName(nameof(ResumeDependents.MobilePhone)).HasMaxLength(ResumeDependentsConsts.MobilePhoneMaxLength);
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(ResumeDependents.ExtendedInformation)).HasMaxLength(ResumeDependentsConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(ResumeDependents.DateA)).IsRequired();
        b.Property(x => x.DateD).HasColumnName(nameof(ResumeDependents.DateD)).IsRequired();
        b.Property(x => x.Sort).HasColumnName(nameof(ResumeDependents.Sort)).IsRequired();
        b.Property(x => x.Note).HasColumnName(nameof(ResumeDependents.Note)).HasMaxLength(ResumeDependentsConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(ResumeDependents.Status)).IsRequired().HasMaxLength(ResumeDependentsConsts.StatusMaxLength);
    });
        builder.Entity<ResumeDrvingLicense>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "ResumeDrvingLicenses", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(ResumeDrvingLicense.TenantId));
        b.Property(x => x.ResumeMainId).HasColumnName(nameof(ResumeDrvingLicense.ResumeMainId));
        b.Property(x => x.DrvingLicenseCode).HasColumnName(nameof(ResumeDrvingLicense.DrvingLicenseCode)).IsRequired().HasMaxLength(ResumeDrvingLicenseConsts.DrvingLicenseCodeMaxLength);
        b.Property(x => x.HaveDrvingLicense).HasColumnName(nameof(ResumeDrvingLicense.HaveDrvingLicense)).IsRequired();
        b.Property(x => x.HaveCar).HasColumnName(nameof(ResumeDrvingLicense.HaveCar)).IsRequired();
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(ResumeDrvingLicense.ExtendedInformation)).HasMaxLength(ResumeDrvingLicenseConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(ResumeDrvingLicense.DateA)).IsRequired();
        b.Property(x => x.DateD).HasColumnName(nameof(ResumeDrvingLicense.DateD)).IsRequired();
        b.Property(x => x.Sort).HasColumnName(nameof(ResumeDrvingLicense.Sort)).IsRequired();
        b.Property(x => x.Note).HasColumnName(nameof(ResumeDrvingLicense.Note)).HasMaxLength(ResumeDrvingLicenseConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(ResumeDrvingLicense.Status)).IsRequired().HasMaxLength(ResumeDrvingLicenseConsts.StatusMaxLength);
    });
        builder.Entity<ResumeEducations>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "ResumeEducationss", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(ResumeEducations.TenantId));
        b.Property(x => x.ResumeMainId).HasColumnName(nameof(ResumeEducations.ResumeMainId));
        b.Property(x => x.EducationLevelCode).HasColumnName(nameof(ResumeEducations.EducationLevelCode)).IsRequired().HasMaxLength(ResumeEducationsConsts.EducationLevelCodeMaxLength);
        b.Property(x => x.SchoolCode).HasColumnName(nameof(ResumeEducations.SchoolCode)).IsRequired().HasMaxLength(ResumeEducationsConsts.SchoolCodeMaxLength);
        b.Property(x => x.SchoolName).HasColumnName(nameof(ResumeEducations.SchoolName)).IsRequired().HasMaxLength(ResumeEducationsConsts.SchoolNameMaxLength);
        b.Property(x => x.Night).HasColumnName(nameof(ResumeEducations.Night)).IsRequired();
        b.Property(x => x.Working).HasColumnName(nameof(ResumeEducations.Working)).IsRequired();
        b.Property(x => x.MajorDepartmentName).HasColumnName(nameof(ResumeEducations.MajorDepartmentName)).IsRequired().HasMaxLength(ResumeEducationsConsts.MajorDepartmentNameMaxLength);
        b.Property(x => x.MajorDepartmentCategoryCode).HasColumnName(nameof(ResumeEducations.MajorDepartmentCategoryCode)).IsRequired().HasMaxLength(ResumeEducationsConsts.MajorDepartmentCategoryCodeMaxLength);
        b.Property(x => x.MinorDepartmentName).HasColumnName(nameof(ResumeEducations.MinorDepartmentName)).IsRequired().HasMaxLength(ResumeEducationsConsts.MinorDepartmentNameMaxLength);
        b.Property(x => x.MinorDepartmentCategoryCode).HasColumnName(nameof(ResumeEducations.MinorDepartmentCategoryCode)).IsRequired().HasMaxLength(ResumeEducationsConsts.MinorDepartmentCategoryCodeMaxLength);
        b.Property(x => x.GraduationCode).HasColumnName(nameof(ResumeEducations.GraduationCode)).IsRequired().HasMaxLength(ResumeEducationsConsts.GraduationCodeMaxLength);
        b.Property(x => x.Domestic).HasColumnName(nameof(ResumeEducations.Domestic)).IsRequired();
        b.Property(x => x.CountryCode).HasColumnName(nameof(ResumeEducations.CountryCode)).IsRequired().HasMaxLength(ResumeEducationsConsts.CountryCodeMaxLength);
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(ResumeEducations.ExtendedInformation)).HasMaxLength(ResumeEducationsConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(ResumeEducations.DateA)).IsRequired();
        b.Property(x => x.DateD).HasColumnName(nameof(ResumeEducations.DateD)).IsRequired();
        b.Property(x => x.Sort).HasColumnName(nameof(ResumeEducations.Sort)).IsRequired();
        b.Property(x => x.Note).HasColumnName(nameof(ResumeEducations.Note)).HasMaxLength(ResumeEducationsConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(ResumeEducations.Status)).IsRequired().HasMaxLength(ResumeEducationsConsts.StatusMaxLength);
    });
        builder.Entity<ResumeExperiences>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "ResumeExperiencess", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(ResumeExperiences.TenantId));
        b.Property(x => x.ResumeMainId).HasColumnName(nameof(ResumeExperiences.ResumeMainId));
        b.Property(x => x.Name).HasColumnName(nameof(ResumeExperiences.Name)).IsRequired().HasMaxLength(ResumeExperiencesConsts.NameMaxLength);
        b.Property(x => x.WorkNatureCode).HasColumnName(nameof(ResumeExperiences.WorkNatureCode)).IsRequired().HasMaxLength(ResumeExperiencesConsts.WorkNatureCodeMaxLength);
        b.Property(x => x.HideCompanyName).HasColumnName(nameof(ResumeExperiences.HideCompanyName)).IsRequired();
        b.Property(x => x.IndustryCategoryCode).HasColumnName(nameof(ResumeExperiences.IndustryCategoryCode)).IsRequired().HasMaxLength(ResumeExperiencesConsts.IndustryCategoryCodeMaxLength);
        b.Property(x => x.JobName).HasColumnName(nameof(ResumeExperiences.JobName)).IsRequired().HasMaxLength(ResumeExperiencesConsts.JobNameMaxLength);
        b.Property(x => x.JobType).HasColumnName(nameof(ResumeExperiences.JobType)).HasMaxLength(ResumeExperiencesConsts.JobTypeMaxLength);
        b.Property(x => x.Working).HasColumnName(nameof(ResumeExperiences.Working)).IsRequired();
        b.Property(x => x.WorkPlaceCode).HasColumnName(nameof(ResumeExperiences.WorkPlaceCode)).HasMaxLength(ResumeExperiencesConsts.WorkPlaceCodeMaxLength);
        b.Property(x => x.HideWorkSalary).HasColumnName(nameof(ResumeExperiences.HideWorkSalary));
        b.Property(x => x.SalaryPayTypeCode).HasColumnName(nameof(ResumeExperiences.SalaryPayTypeCode)).IsRequired().HasMaxLength(ResumeExperiencesConsts.SalaryPayTypeCodeMaxLength);
        b.Property(x => x.CurrencyTypeCode).HasColumnName(nameof(ResumeExperiences.CurrencyTypeCode)).IsRequired().HasMaxLength(ResumeExperiencesConsts.CurrencyTypeCodeMaxLength);
        b.Property(x => x.Salary1).HasColumnName(nameof(ResumeExperiences.Salary1));
        b.Property(x => x.Salary2).HasColumnName(nameof(ResumeExperiences.Salary2));
        b.Property(x => x.CompanyScaleCode).HasColumnName(nameof(ResumeExperiences.CompanyScaleCode)).IsRequired().HasMaxLength(ResumeExperiencesConsts.CompanyScaleCodeMaxLength);
        b.Property(x => x.CompanyManagementNumberCode).HasColumnName(nameof(ResumeExperiences.CompanyManagementNumberCode)).IsRequired().HasMaxLength(ResumeExperiencesConsts.CompanyManagementNumberCodeMaxLength);
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(ResumeExperiences.ExtendedInformation)).HasMaxLength(ResumeExperiencesConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(ResumeExperiences.DateA)).IsRequired();
        b.Property(x => x.DateD).HasColumnName(nameof(ResumeExperiences.DateD)).IsRequired();
        b.Property(x => x.Sort).HasColumnName(nameof(ResumeExperiences.Sort)).IsRequired();
        b.Property(x => x.Note).HasColumnName(nameof(ResumeExperiences.Note)).HasMaxLength(ResumeExperiencesConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(ResumeExperiences.Status)).IsRequired().HasMaxLength(ResumeExperiencesConsts.StatusMaxLength);
    });
        builder.Entity<ResumeLanguage>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "ResumeLanguages", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(ResumeLanguage.TenantId));
        b.Property(x => x.ResumeMainId).HasColumnName(nameof(ResumeLanguage.ResumeMainId));
        b.Property(x => x.LanguageCategoryCode).HasColumnName(nameof(ResumeLanguage.LanguageCategoryCode)).IsRequired().HasMaxLength(ResumeLanguageConsts.LanguageCategoryCodeMaxLength);
        b.Property(x => x.LevelSayCode).HasColumnName(nameof(ResumeLanguage.LevelSayCode)).IsRequired().HasMaxLength(ResumeLanguageConsts.LevelSayCodeMaxLength);
        b.Property(x => x.LevelListenCode).HasColumnName(nameof(ResumeLanguage.LevelListenCode)).IsRequired().HasMaxLength(ResumeLanguageConsts.LevelListenCodeMaxLength);
        b.Property(x => x.LevelReadCode).HasColumnName(nameof(ResumeLanguage.LevelReadCode)).IsRequired().HasMaxLength(ResumeLanguageConsts.LevelReadCodeMaxLength);
        b.Property(x => x.LevelWriteCode).HasColumnName(nameof(ResumeLanguage.LevelWriteCode)).IsRequired().HasMaxLength(ResumeLanguageConsts.LevelWriteCodeMaxLength);
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(ResumeLanguage.ExtendedInformation)).HasMaxLength(ResumeLanguageConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(ResumeLanguage.DateA)).IsRequired();
        b.Property(x => x.DateD).HasColumnName(nameof(ResumeLanguage.DateD)).IsRequired();
        b.Property(x => x.Sort).HasColumnName(nameof(ResumeLanguage.Sort)).IsRequired();
        b.Property(x => x.Note).HasColumnName(nameof(ResumeLanguage.Note)).HasMaxLength(ResumeLanguageConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(ResumeLanguage.Status)).IsRequired().HasMaxLength(ResumeLanguageConsts.StatusMaxLength);
    });
        builder.Entity<ResumeMain>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "ResumeMains", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(ResumeMain.TenantId));
        b.Property(x => x.UserMainId).HasColumnName(nameof(ResumeMain.UserMainId));
        b.Property(x => x.ResumeName).HasColumnName(nameof(ResumeMain.ResumeName)).IsRequired().HasMaxLength(ResumeMainConsts.ResumeNameMaxLength);
        b.Property(x => x.MarriageCode).HasColumnName(nameof(ResumeMain.MarriageCode)).HasMaxLength(ResumeMainConsts.MarriageCodeMaxLength);
        b.Property(x => x.MilitaryCode).HasColumnName(nameof(ResumeMain.MilitaryCode)).HasMaxLength(ResumeMainConsts.MilitaryCodeMaxLength);
        b.Property(x => x.DisabilityCategoryCode).HasColumnName(nameof(ResumeMain.DisabilityCategoryCode)).HasMaxLength(ResumeMainConsts.DisabilityCategoryCodeMaxLength);
        b.Property(x => x.SpecialIdentityCode).HasColumnName(nameof(ResumeMain.SpecialIdentityCode)).HasMaxLength(ResumeMainConsts.SpecialIdentityCodeMaxLength);
        b.Property(x => x.Main).HasColumnName(nameof(ResumeMain.Main)).IsRequired();
        b.Property(x => x.Autobiography1).HasColumnName(nameof(ResumeMain.Autobiography1));
        b.Property(x => x.Autobiography2).HasColumnName(nameof(ResumeMain.Autobiography2));
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(ResumeMain.ExtendedInformation)).HasMaxLength(ResumeMainConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(ResumeMain.DateA)).IsRequired();
        b.Property(x => x.DateD).HasColumnName(nameof(ResumeMain.DateD)).IsRequired();
        b.Property(x => x.Sort).HasColumnName(nameof(ResumeMain.Sort)).IsRequired();
        b.Property(x => x.Note).HasColumnName(nameof(ResumeMain.Note)).HasMaxLength(ResumeMainConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(ResumeMain.Status)).IsRequired().HasMaxLength(ResumeMainConsts.StatusMaxLength);
    });
        builder.Entity<ResumeRecommender>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "ResumeRecommenders", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(ResumeRecommender.TenantId));
        b.Property(x => x.ResumeMainId).HasColumnName(nameof(ResumeRecommender.ResumeMainId));
        b.Property(x => x.Name).HasColumnName(nameof(ResumeRecommender.Name)).IsRequired().HasMaxLength(ResumeRecommenderConsts.NameMaxLength);
        b.Property(x => x.CompanyName).HasColumnName(nameof(ResumeRecommender.CompanyName)).HasMaxLength(ResumeRecommenderConsts.CompanyNameMaxLength);
        b.Property(x => x.JobName).HasColumnName(nameof(ResumeRecommender.JobName)).HasMaxLength(ResumeRecommenderConsts.JobNameMaxLength);
        b.Property(x => x.MobilePhone).HasColumnName(nameof(ResumeRecommender.MobilePhone)).HasMaxLength(ResumeRecommenderConsts.MobilePhoneMaxLength);
        b.Property(x => x.OfficePhone).HasColumnName(nameof(ResumeRecommender.OfficePhone)).HasMaxLength(ResumeRecommenderConsts.OfficePhoneMaxLength);
        b.Property(x => x.Email).HasColumnName(nameof(ResumeRecommender.Email)).HasMaxLength(ResumeRecommenderConsts.EmailMaxLength);
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(ResumeRecommender.ExtendedInformation)).HasMaxLength(ResumeRecommenderConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(ResumeRecommender.DateA)).IsRequired();
        b.Property(x => x.DateD).HasColumnName(nameof(ResumeRecommender.DateD)).IsRequired();
        b.Property(x => x.Sort).HasColumnName(nameof(ResumeRecommender.Sort)).IsRequired();
        b.Property(x => x.Note).HasColumnName(nameof(ResumeRecommender.Note)).HasMaxLength(ResumeRecommenderConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(ResumeRecommender.Status)).IsRequired().HasMaxLength(ResumeRecommenderConsts.StatusMaxLength);
    });
        builder.Entity<ResumeSkill>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "ResumeSkills", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(ResumeSkill.TenantId));
        b.Property(x => x.ResumeMainId).HasColumnName(nameof(ResumeSkill.ResumeMainId));
        b.Property(x => x.ComputerSkills).HasColumnName(nameof(ResumeSkill.ComputerSkills)).HasMaxLength(ResumeSkillConsts.ComputerSkillsMaxLength);
        b.Property(x => x.ComputerSkillsEtc).HasColumnName(nameof(ResumeSkill.ComputerSkillsEtc)).HasMaxLength(ResumeSkillConsts.ComputerSkillsEtcMaxLength);
        b.Property(x => x.ChineseTypingSpeed).HasColumnName(nameof(ResumeSkill.ChineseTypingSpeed)).IsRequired();
        b.Property(x => x.ChineseTypingCode).HasColumnName(nameof(ResumeSkill.ChineseTypingCode)).IsRequired().HasMaxLength(ResumeSkillConsts.ChineseTypingCodeMaxLength);
        b.Property(x => x.EnglishTypingSpeed).HasColumnName(nameof(ResumeSkill.EnglishTypingSpeed)).IsRequired();
        b.Property(x => x.ProfessionalLicense).HasColumnName(nameof(ResumeSkill.ProfessionalLicense)).HasMaxLength(ResumeSkillConsts.ProfessionalLicenseMaxLength);
        b.Property(x => x.ProfessionalLicenseEtc).HasColumnName(nameof(ResumeSkill.ProfessionalLicenseEtc)).HasMaxLength(ResumeSkillConsts.ProfessionalLicenseEtcMaxLength);
        b.Property(x => x.WorkSkills).HasColumnName(nameof(ResumeSkill.WorkSkills)).HasMaxLength(ResumeSkillConsts.WorkSkillsMaxLength);
        b.Property(x => x.WorkSkillsEtc).HasColumnName(nameof(ResumeSkill.WorkSkillsEtc)).HasMaxLength(ResumeSkillConsts.WorkSkillsEtcMaxLength);
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(ResumeSkill.ExtendedInformation)).HasMaxLength(ResumeSkillConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(ResumeSkill.DateA)).IsRequired();
        b.Property(x => x.DateD).HasColumnName(nameof(ResumeSkill.DateD)).IsRequired();
        b.Property(x => x.Sort).HasColumnName(nameof(ResumeSkill.Sort)).IsRequired();
        b.Property(x => x.Note).HasColumnName(nameof(ResumeSkill.Note)).HasMaxLength(ResumeSkillConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(ResumeSkill.Status)).IsRequired().HasMaxLength(ResumeSkillConsts.StatusMaxLength);
    });
        builder.Entity<ResumeSnapshot>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "ResumeSnapshots", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(ResumeSnapshot.TenantId));
        b.Property(x => x.UserMainId).HasColumnName(nameof(ResumeSnapshot.UserMainId));
        b.Property(x => x.ResumeMainId).HasColumnName(nameof(ResumeSnapshot.ResumeMainId));
        b.Property(x => x.CompanyMainId).HasColumnName(nameof(ResumeSnapshot.CompanyMainId));
        b.Property(x => x.CompanyJobId).HasColumnName(nameof(ResumeSnapshot.CompanyJobId));
        b.Property(x => x.Snapshot).HasColumnName(nameof(ResumeSnapshot.Snapshot)).IsRequired();
        b.Property(x => x.UserCompanyBindId).HasColumnName(nameof(ResumeSnapshot.UserCompanyBindId));
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(ResumeSnapshot.ExtendedInformation)).HasMaxLength(ResumeSnapshotConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(ResumeSnapshot.DateA)).IsRequired();
        b.Property(x => x.DateD).HasColumnName(nameof(ResumeSnapshot.DateD)).IsRequired();
        b.Property(x => x.Sort).HasColumnName(nameof(ResumeSnapshot.Sort)).IsRequired();
        b.Property(x => x.Note).HasColumnName(nameof(ResumeSnapshot.Note)).HasMaxLength(ResumeSnapshotConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(ResumeSnapshot.Status)).IsRequired().HasMaxLength(ResumeSnapshotConsts.StatusMaxLength);
    });
        builder.Entity<ResumeWorks>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "ResumeWorkss", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(ResumeWorks.TenantId));
        b.Property(x => x.ResumeMainId).HasColumnName(nameof(ResumeWorks.ResumeMainId));
        b.Property(x => x.Name).HasColumnName(nameof(ResumeWorks.Name)).IsRequired().HasMaxLength(ResumeWorksConsts.NameMaxLength);
        b.Property(x => x.Link).HasColumnName(nameof(ResumeWorks.Link)).HasMaxLength(ResumeWorksConsts.LinkMaxLength);
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(ResumeWorks.ExtendedInformation)).HasMaxLength(ResumeWorksConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(ResumeWorks.DateA)).IsRequired();
        b.Property(x => x.DateD).HasColumnName(nameof(ResumeWorks.DateD)).IsRequired();
        b.Property(x => x.Sort).HasColumnName(nameof(ResumeWorks.Sort)).IsRequired();
        b.Property(x => x.Note).HasColumnName(nameof(ResumeWorks.Note)).HasMaxLength(ResumeWorksConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(ResumeWorks.Status)).IsRequired().HasMaxLength(ResumeWorksConsts.StatusMaxLength);
    });
        builder.Entity<ShareCode>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "ShareCodes", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(ShareCode.TenantId));
        b.Property(x => x.GroupCode).HasColumnName(nameof(ShareCode.GroupCode)).IsRequired().HasMaxLength(ShareCodeConsts.GroupCodeMaxLength);
        b.Property(x => x.Key1).HasColumnName(nameof(ShareCode.Key1)).IsRequired().HasMaxLength(ShareCodeConsts.Key1MaxLength);
        b.Property(x => x.Key2).HasColumnName(nameof(ShareCode.Key2)).IsRequired().HasMaxLength(ShareCodeConsts.Key2MaxLength);
        b.Property(x => x.Key3).HasColumnName(nameof(ShareCode.Key3)).IsRequired().HasMaxLength(ShareCodeConsts.Key3MaxLength);
        b.Property(x => x.Name).HasColumnName(nameof(ShareCode.Name)).IsRequired().HasMaxLength(ShareCodeConsts.NameMaxLength);
        b.Property(x => x.Column1).HasColumnName(nameof(ShareCode.Column1)).HasMaxLength(ShareCodeConsts.Column1MaxLength);
        b.Property(x => x.Column2).HasColumnName(nameof(ShareCode.Column2)).HasMaxLength(ShareCodeConsts.Column2MaxLength);
        b.Property(x => x.Column3).HasColumnName(nameof(ShareCode.Column3)).HasMaxLength(ShareCodeConsts.Column3MaxLength);
        b.Property(x => x.SystemUse).HasColumnName(nameof(ShareCode.SystemUse)).IsRequired();
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(ShareCode.ExtendedInformation)).HasMaxLength(ShareCodeConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(ShareCode.DateA)).IsRequired();
        b.Property(x => x.DateD).HasColumnName(nameof(ShareCode.DateD)).IsRequired();
        b.Property(x => x.Sort).HasColumnName(nameof(ShareCode.Sort)).IsRequired();
        b.Property(x => x.Note).HasColumnName(nameof(ShareCode.Note)).HasMaxLength(ShareCodeConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(ShareCode.Status)).IsRequired().HasMaxLength(ShareCodeConsts.StatusMaxLength);
    });
        builder.Entity<ShareDefault>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "ShareDefaults", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(ShareDefault.TenantId));
        b.Property(x => x.GroupCode).HasColumnName(nameof(ShareDefault.GroupCode)).IsRequired().HasMaxLength(ShareDefaultConsts.GroupCodeMaxLength);
        b.Property(x => x.Key1).HasColumnName(nameof(ShareDefault.Key1)).HasMaxLength(ShareDefaultConsts.Key1MaxLength);
        b.Property(x => x.Key2).HasColumnName(nameof(ShareDefault.Key2)).HasMaxLength(ShareDefaultConsts.Key2MaxLength);
        b.Property(x => x.Key3).HasColumnName(nameof(ShareDefault.Key3)).HasMaxLength(ShareDefaultConsts.Key3MaxLength);
        b.Property(x => x.Name).HasColumnName(nameof(ShareDefault.Name)).IsRequired().HasMaxLength(ShareDefaultConsts.NameMaxLength);
        b.Property(x => x.FieldKey).HasColumnName(nameof(ShareDefault.FieldKey)).IsRequired().HasMaxLength(ShareDefaultConsts.FieldKeyMaxLength);
        b.Property(x => x.FieldValue).HasColumnName(nameof(ShareDefault.FieldValue)).HasMaxLength(ShareDefaultConsts.FieldValueMaxLength);
        b.Property(x => x.ColumnTypeCode).HasColumnName(nameof(ShareDefault.ColumnTypeCode)).IsRequired().HasMaxLength(ShareDefaultConsts.ColumnTypeCodeMaxLength);
        b.Property(x => x.FormTypeCode).HasColumnName(nameof(ShareDefault.FormTypeCode)).IsRequired().HasMaxLength(ShareDefaultConsts.FormTypeCodeMaxLength);
        b.Property(x => x.SystemUse).HasColumnName(nameof(ShareDefault.SystemUse)).IsRequired();
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(ShareDefault.ExtendedInformation)).HasMaxLength(ShareDefaultConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(ShareDefault.DateA)).IsRequired();
        b.Property(x => x.DateD).HasColumnName(nameof(ShareDefault.DateD)).IsRequired();
        b.Property(x => x.Sort).HasColumnName(nameof(ShareDefault.Sort)).IsRequired();
        b.Property(x => x.Note).HasColumnName(nameof(ShareDefault.Note)).HasMaxLength(ShareDefaultConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(ShareDefault.Status)).IsRequired().HasMaxLength(ShareDefaultConsts.StatusMaxLength);
    });
        builder.Entity<ShareDictionary>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "ShareDictionarys", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(ShareDictionary.TenantId));
        b.Property(x => x.ShareLanguageId).HasColumnName(nameof(ShareDictionary.ShareLanguageId));
        b.Property(x => x.ShareTagId).HasColumnName(nameof(ShareDictionary.ShareTagId));
        b.Property(x => x.Key1).HasColumnName(nameof(ShareDictionary.Key1)).HasMaxLength(ShareDictionaryConsts.Key1MaxLength);
        b.Property(x => x.Key2).HasColumnName(nameof(ShareDictionary.Key2)).HasMaxLength(ShareDictionaryConsts.Key2MaxLength);
        b.Property(x => x.Key3).HasColumnName(nameof(ShareDictionary.Key3)).HasMaxLength(ShareDictionaryConsts.Key3MaxLength);
        b.Property(x => x.Name).HasColumnName(nameof(ShareDictionary.Name)).IsRequired().HasMaxLength(ShareDictionaryConsts.NameMaxLength);
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(ShareDictionary.ExtendedInformation)).HasMaxLength(ShareDictionaryConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(ShareDictionary.DateA)).IsRequired();
        b.Property(x => x.DateD).HasColumnName(nameof(ShareDictionary.DateD)).IsRequired();
        b.Property(x => x.Sort).HasColumnName(nameof(ShareDictionary.Sort)).IsRequired();
        b.Property(x => x.Note).HasColumnName(nameof(ShareDictionary.Note)).HasMaxLength(ShareDictionaryConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(ShareDictionary.Status)).IsRequired().HasMaxLength(ShareDictionaryConsts.StatusMaxLength);
    });
        builder.Entity<ShareLanguage>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "ShareLanguages", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(ShareLanguage.TenantId));
        b.Property(x => x.Name).HasColumnName(nameof(ShareLanguage.Name)).IsRequired().HasMaxLength(ShareLanguageConsts.NameMaxLength);
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(ShareLanguage.ExtendedInformation)).HasMaxLength(ShareLanguageConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(ShareLanguage.DateA)).IsRequired();
        b.Property(x => x.DateD).HasColumnName(nameof(ShareLanguage.DateD)).IsRequired();
        b.Property(x => x.Sort).HasColumnName(nameof(ShareLanguage.Sort)).IsRequired();
        b.Property(x => x.Note).HasColumnName(nameof(ShareLanguage.Note)).HasMaxLength(ShareLanguageConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(ShareLanguage.Status)).IsRequired().HasMaxLength(ShareLanguageConsts.StatusMaxLength);
    });
        builder.Entity<ShareMessageTpl>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "ShareMessageTpls", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(ShareMessageTpl.TenantId));
        b.Property(x => x.Key1).HasColumnName(nameof(ShareMessageTpl.Key1)).HasMaxLength(ShareMessageTplConsts.Key1MaxLength);
        b.Property(x => x.Key2).HasColumnName(nameof(ShareMessageTpl.Key2)).HasMaxLength(ShareMessageTplConsts.Key2MaxLength);
        b.Property(x => x.Key3).HasColumnName(nameof(ShareMessageTpl.Key3)).IsRequired().HasMaxLength(ShareMessageTplConsts.Key3MaxLength);
        b.Property(x => x.Name).HasColumnName(nameof(ShareMessageTpl.Name)).IsRequired().HasMaxLength(ShareMessageTplConsts.NameMaxLength);
        b.Property(x => x.Statement).HasColumnName(nameof(ShareMessageTpl.Statement)).HasMaxLength(ShareMessageTplConsts.StatementMaxLength);
        b.Property(x => x.TitleContents).HasColumnName(nameof(ShareMessageTpl.TitleContents)).IsRequired().HasMaxLength(ShareMessageTplConsts.TitleContentsMaxLength);
        b.Property(x => x.ContentMail).HasColumnName(nameof(ShareMessageTpl.ContentMail));
        b.Property(x => x.ContentSMS).HasColumnName(nameof(ShareMessageTpl.ContentSMS)).HasMaxLength(ShareMessageTplConsts.ContentSMSMaxLength);
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(ShareMessageTpl.ExtendedInformation)).HasMaxLength(ShareMessageTplConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(ShareMessageTpl.DateA)).IsRequired();
        b.Property(x => x.DateD).HasColumnName(nameof(ShareMessageTpl.DateD)).IsRequired();
        b.Property(x => x.Sort).HasColumnName(nameof(ShareMessageTpl.Sort)).IsRequired();
        b.Property(x => x.Note).HasColumnName(nameof(ShareMessageTpl.Note)).HasMaxLength(ShareMessageTplConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(ShareMessageTpl.Status)).IsRequired().HasMaxLength(ShareMessageTplConsts.StatusMaxLength);
    });
        builder.Entity<ShareSendQueue>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "ShareSendQueues", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(ShareSendQueue.TenantId));
        b.Property(x => x.Key1).HasColumnName(nameof(ShareSendQueue.Key1)).IsRequired().HasMaxLength(ShareSendQueueConsts.Key1MaxLength);
        b.Property(x => x.Key2).HasColumnName(nameof(ShareSendQueue.Key2)).IsRequired().HasMaxLength(ShareSendQueueConsts.Key2MaxLength);
        b.Property(x => x.Key3).HasColumnName(nameof(ShareSendQueue.Key3)).IsRequired().HasMaxLength(ShareSendQueueConsts.Key3MaxLength);
        b.Property(x => x.SendTypeCode).HasColumnName(nameof(ShareSendQueue.SendTypeCode)).IsRequired().HasMaxLength(ShareSendQueueConsts.SendTypeCodeMaxLength);
        b.Property(x => x.FromAddr).HasColumnName(nameof(ShareSendQueue.FromAddr)).HasMaxLength(ShareSendQueueConsts.FromAddrMaxLength);
        b.Property(x => x.ToAddr).HasColumnName(nameof(ShareSendQueue.ToAddr)).IsRequired().HasMaxLength(ShareSendQueueConsts.ToAddrMaxLength);
        b.Property(x => x.TitleContents).HasColumnName(nameof(ShareSendQueue.TitleContents)).HasMaxLength(ShareSendQueueConsts.TitleContentsMaxLength);
        b.Property(x => x.Contents).HasColumnName(nameof(ShareSendQueue.Contents)).IsRequired();
        b.Property(x => x.Retry).HasColumnName(nameof(ShareSendQueue.Retry)).IsRequired();
        b.Property(x => x.Sucess).HasColumnName(nameof(ShareSendQueue.Sucess)).IsRequired();
        b.Property(x => x.Suspend).HasColumnName(nameof(ShareSendQueue.Suspend)).IsRequired();
        b.Property(x => x.DateSend).HasColumnName(nameof(ShareSendQueue.DateSend)).IsRequired();
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(ShareSendQueue.ExtendedInformation)).HasMaxLength(ShareSendQueueConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(ShareSendQueue.DateA)).IsRequired();
        b.Property(x => x.DateD).HasColumnName(nameof(ShareSendQueue.DateD)).IsRequired();
        b.Property(x => x.Sort).HasColumnName(nameof(ShareSendQueue.Sort)).IsRequired();
        b.Property(x => x.Note).HasColumnName(nameof(ShareSendQueue.Note)).HasMaxLength(ShareSendQueueConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(ShareSendQueue.Status)).IsRequired().HasMaxLength(ShareSendQueueConsts.StatusMaxLength);
    });
        builder.Entity<ShareTag>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "ShareTags", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(ShareTag.TenantId));
        b.Property(x => x.ColorCode).HasColumnName(nameof(ShareTag.ColorCode)).IsRequired().HasMaxLength(ShareTagConsts.ColorCodeMaxLength);
        b.Property(x => x.Key1).HasColumnName(nameof(ShareTag.Key1)).IsRequired().HasMaxLength(ShareTagConsts.Key1MaxLength);
        b.Property(x => x.Key2).HasColumnName(nameof(ShareTag.Key2)).IsRequired().HasMaxLength(ShareTagConsts.Key2MaxLength);
        b.Property(x => x.Key3).HasColumnName(nameof(ShareTag.Key3)).IsRequired().HasMaxLength(ShareTagConsts.Key3MaxLength);
        b.Property(x => x.Name).HasColumnName(nameof(ShareTag.Name)).IsRequired().HasMaxLength(ShareTagConsts.NameMaxLength);
        b.Property(x => x.TagCategoryCode).HasColumnName(nameof(ShareTag.TagCategoryCode)).IsRequired().HasMaxLength(ShareTagConsts.TagCategoryCodeMaxLength);
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(ShareTag.ExtendedInformation)).HasMaxLength(ShareTagConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(ShareTag.DateA)).IsRequired();
        b.Property(x => x.DateD).HasColumnName(nameof(ShareTag.DateD)).IsRequired();
        b.Property(x => x.Sort).HasColumnName(nameof(ShareTag.Sort)).IsRequired();
        b.Property(x => x.Note).HasColumnName(nameof(ShareTag.Note)).HasMaxLength(ShareTagConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(ShareTag.Status)).IsRequired().HasMaxLength(ShareTagConsts.StatusMaxLength);
    });
        builder.Entity<ShareUpload>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "ShareUploads", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(ShareUpload.TenantId));
        b.Property(x => x.Key1).HasColumnName(nameof(ShareUpload.Key1)).HasMaxLength(ShareUploadConsts.Key1MaxLength);
        b.Property(x => x.Key2).HasColumnName(nameof(ShareUpload.Key2)).HasMaxLength(ShareUploadConsts.Key2MaxLength);
        b.Property(x => x.Key3).HasColumnName(nameof(ShareUpload.Key3)).HasMaxLength(ShareUploadConsts.Key3MaxLength);
        b.Property(x => x.UploadName).HasColumnName(nameof(ShareUpload.UploadName)).IsRequired().HasMaxLength(ShareUploadConsts.UploadNameMaxLength);
        b.Property(x => x.ServerName).HasColumnName(nameof(ShareUpload.ServerName)).IsRequired().HasMaxLength(ShareUploadConsts.ServerNameMaxLength);
        b.Property(x => x.Type).HasColumnName(nameof(ShareUpload.Type)).IsRequired().HasMaxLength(ShareUploadConsts.TypeMaxLength);
        b.Property(x => x.Size).HasColumnName(nameof(ShareUpload.Size)).IsRequired();
        b.Property(x => x.SystemUse).HasColumnName(nameof(ShareUpload.SystemUse)).IsRequired();
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(ShareUpload.ExtendedInformation)).HasMaxLength(ShareUploadConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(ShareUpload.DateA)).IsRequired();
        b.Property(x => x.DateD).HasColumnName(nameof(ShareUpload.DateD)).IsRequired();
        b.Property(x => x.Sort).HasColumnName(nameof(ShareUpload.Sort)).IsRequired();
        b.Property(x => x.Note).HasColumnName(nameof(ShareUpload.Note)).HasMaxLength(ShareUploadConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(ShareUpload.Status)).IsRequired().HasMaxLength(ShareUploadConsts.StatusMaxLength);
    });
        builder.Entity<SystemColumn>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "SystemColumns", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(SystemColumn.TenantId));
        b.Property(x => x.SystemTableId).HasColumnName(nameof(SystemColumn.SystemTableId));
        b.Property(x => x.Name).HasColumnName(nameof(SystemColumn.Name)).IsRequired().HasMaxLength(SystemColumnConsts.NameMaxLength);
        b.Property(x => x.IsKey).HasColumnName(nameof(SystemColumn.IsKey)).IsRequired();
        b.Property(x => x.IsSensitive).HasColumnName(nameof(SystemColumn.IsSensitive)).IsRequired();
        b.Property(x => x.NeedMask).HasColumnName(nameof(SystemColumn.NeedMask)).IsRequired();
        b.Property(x => x.DefaultValue).HasColumnName(nameof(SystemColumn.DefaultValue)).HasMaxLength(SystemColumnConsts.DefaultValueMaxLength);
        b.Property(x => x.CheckCode).HasColumnName(nameof(SystemColumn.CheckCode)).IsRequired();
        b.Property(x => x.Related).HasColumnName(nameof(SystemColumn.Related)).HasMaxLength(SystemColumnConsts.RelatedMaxLength);
        b.Property(x => x.AllowUpdate).HasColumnName(nameof(SystemColumn.AllowUpdate)).IsRequired();
        b.Property(x => x.AllowNull).HasColumnName(nameof(SystemColumn.AllowNull)).IsRequired();
        b.Property(x => x.AllowEmpty).HasColumnName(nameof(SystemColumn.AllowEmpty)).IsRequired();
        b.Property(x => x.AllowExport).HasColumnName(nameof(SystemColumn.AllowExport)).IsRequired();
        b.Property(x => x.AllowSort).HasColumnName(nameof(SystemColumn.AllowSort)).IsRequired();
        b.Property(x => x.ColumnTypeCode).HasColumnName(nameof(SystemColumn.ColumnTypeCode)).IsRequired().HasMaxLength(SystemColumnConsts.ColumnTypeCodeMaxLength);
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(SystemColumn.ExtendedInformation)).HasMaxLength(SystemColumnConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(SystemColumn.DateA)).IsRequired();
        b.Property(x => x.DateD).HasColumnName(nameof(SystemColumn.DateD)).IsRequired();
        b.Property(x => x.Sort).HasColumnName(nameof(SystemColumn.Sort)).IsRequired();
        b.Property(x => x.Note).HasColumnName(nameof(SystemColumn.Note)).HasMaxLength(SystemColumnConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(SystemColumn.Status)).IsRequired().HasMaxLength(SystemColumnConsts.StatusMaxLength);
    });
        builder.Entity<SystemDisplayMessage>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "SystemDisplayMessages", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(SystemDisplayMessage.TenantId));
        b.Property(x => x.DisplayTypeCode).HasColumnName(nameof(SystemDisplayMessage.DisplayTypeCode)).IsRequired().HasMaxLength(SystemDisplayMessageConsts.DisplayTypeCodeMaxLength);
        b.Property(x => x.TitleContents).HasColumnName(nameof(SystemDisplayMessage.TitleContents)).IsRequired().HasMaxLength(SystemDisplayMessageConsts.TitleContentsMaxLength);
        b.Property(x => x.Contents).HasColumnName(nameof(SystemDisplayMessage.Contents)).IsRequired().HasMaxLength(SystemDisplayMessageConsts.ContentsMaxLength);
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(SystemDisplayMessage.ExtendedInformation)).HasMaxLength(SystemDisplayMessageConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(SystemDisplayMessage.DateA)).IsRequired();
        b.Property(x => x.DateD).HasColumnName(nameof(SystemDisplayMessage.DateD)).IsRequired();
        b.Property(x => x.Sort).HasColumnName(nameof(SystemDisplayMessage.Sort)).IsRequired();
        b.Property(x => x.Note).HasColumnName(nameof(SystemDisplayMessage.Note)).HasMaxLength(SystemDisplayMessageConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(SystemDisplayMessage.Status)).IsRequired().HasMaxLength(SystemDisplayMessageConsts.StatusMaxLength);
    });
        builder.Entity<SystemPage>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "SystemPages", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(SystemPage.TenantId));
        b.Property(x => x.TypeCode).HasColumnName(nameof(SystemPage.TypeCode)).IsRequired().HasMaxLength(SystemPageConsts.TypeCodeMaxLength);
        b.Property(x => x.FilePath).HasColumnName(nameof(SystemPage.FilePath)).HasMaxLength(SystemPageConsts.FilePathMaxLength);
        b.Property(x => x.FileName).HasColumnName(nameof(SystemPage.FileName)).HasMaxLength(SystemPageConsts.FileNameMaxLength);
        b.Property(x => x.FileTitle).HasColumnName(nameof(SystemPage.FileTitle)).HasMaxLength(SystemPageConsts.FileTitleMaxLength);
        b.Property(x => x.SystemUserRoleKeys).HasColumnName(nameof(SystemPage.SystemUserRoleKeys)).IsRequired().HasMaxLength(SystemPageConsts.SystemUserRoleKeysMaxLength);
        b.Property(x => x.ParentCode).HasColumnName(nameof(SystemPage.ParentCode)).IsRequired().HasMaxLength(SystemPageConsts.ParentCodeMaxLength);
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(SystemPage.ExtendedInformation)).HasMaxLength(SystemPageConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(SystemPage.DateA)).IsRequired();
        b.Property(x => x.DateD).HasColumnName(nameof(SystemPage.DateD)).IsRequired();
        b.Property(x => x.Sort).HasColumnName(nameof(SystemPage.Sort)).IsRequired();
        b.Property(x => x.Note).HasColumnName(nameof(SystemPage.Note)).HasMaxLength(SystemPageConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(SystemPage.Status)).IsRequired().HasMaxLength(SystemPageConsts.StatusMaxLength);
    });
        builder.Entity<SystemTable>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "SystemTables", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(SystemTable.TenantId));
        b.Property(x => x.Name).HasColumnName(nameof(SystemTable.Name)).IsRequired().HasMaxLength(SystemTableConsts.NameMaxLength);
        b.Property(x => x.AllowInsert).HasColumnName(nameof(SystemTable.AllowInsert)).IsRequired();
        b.Property(x => x.AllowUpdate).HasColumnName(nameof(SystemTable.AllowUpdate)).IsRequired();
        b.Property(x => x.AllowDelete).HasColumnName(nameof(SystemTable.AllowDelete)).IsRequired();
        b.Property(x => x.AllowSelect).HasColumnName(nameof(SystemTable.AllowSelect)).IsRequired();
        b.Property(x => x.AllowExport).HasColumnName(nameof(SystemTable.AllowExport)).IsRequired();
        b.Property(x => x.AllowImport).HasColumnName(nameof(SystemTable.AllowImport)).IsRequired();
        b.Property(x => x.AllowPage).HasColumnName(nameof(SystemTable.AllowPage)).IsRequired();
        b.Property(x => x.AllowSort).HasColumnName(nameof(SystemTable.AllowSort)).IsRequired();
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(SystemTable.ExtendedInformation)).HasMaxLength(SystemTableConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(SystemTable.DateA)).IsRequired();
        b.Property(x => x.DateD).HasColumnName(nameof(SystemTable.DateD)).IsRequired();
        b.Property(x => x.Sort).HasColumnName(nameof(SystemTable.Sort)).IsRequired();
        b.Property(x => x.Note).HasColumnName(nameof(SystemTable.Note)).HasMaxLength(SystemTableConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(SystemTable.Status)).IsRequired().HasMaxLength(SystemTableConsts.StatusMaxLength);
    });
        builder.Entity<SystemUserNotify>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "SystemUserNotifys", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(SystemUserNotify.TenantId));
        b.Property(x => x.UserMainId).HasColumnName(nameof(SystemUserNotify.UserMainId)).IsRequired();
        b.Property(x => x.KeyId).HasColumnName(nameof(SystemUserNotify.KeyId)).HasMaxLength(SystemUserNotifyConsts.KeyIdMaxLength);
        b.Property(x => x.KeyName).HasColumnName(nameof(SystemUserNotify.KeyName)).HasMaxLength(SystemUserNotifyConsts.KeyNameMaxLength);
        b.Property(x => x.NotifyTypeCode).HasColumnName(nameof(SystemUserNotify.NotifyTypeCode)).IsRequired().HasMaxLength(SystemUserNotifyConsts.NotifyTypeCodeMaxLength);
        b.Property(x => x.AppName).HasColumnName(nameof(SystemUserNotify.AppName)).IsRequired().HasMaxLength(SystemUserNotifyConsts.AppNameMaxLength);
        b.Property(x => x.AppCode).HasColumnName(nameof(SystemUserNotify.AppCode)).IsRequired().HasMaxLength(SystemUserNotifyConsts.AppCodeMaxLength);
        b.Property(x => x.TitleContents).HasColumnName(nameof(SystemUserNotify.TitleContents)).IsRequired().HasMaxLength(SystemUserNotifyConsts.TitleContentsMaxLength);
        b.Property(x => x.Contents).HasColumnName(nameof(SystemUserNotify.Contents)).IsRequired().HasMaxLength(SystemUserNotifyConsts.ContentsMaxLength);
        b.Property(x => x.IsRead).HasColumnName(nameof(SystemUserNotify.IsRead)).IsRequired();
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(SystemUserNotify.ExtendedInformation)).HasMaxLength(SystemUserNotifyConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(SystemUserNotify.DateA)).IsRequired();
        b.Property(x => x.DateD).HasColumnName(nameof(SystemUserNotify.DateD)).IsRequired();
        b.Property(x => x.Sort).HasColumnName(nameof(SystemUserNotify.Sort)).IsRequired();
        b.Property(x => x.Note).HasColumnName(nameof(SystemUserNotify.Note)).HasMaxLength(SystemUserNotifyConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(SystemUserNotify.Status)).IsRequired().HasMaxLength(SystemUserNotifyConsts.StatusMaxLength);
    });
        builder.Entity<SystemUserRole>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "SystemUserRoles", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(SystemUserRole.TenantId));
        b.Property(x => x.Name).HasColumnName(nameof(SystemUserRole.Name)).IsRequired().HasMaxLength(SystemUserRoleConsts.NameMaxLength);
        b.Property(x => x.Keys).HasColumnName(nameof(SystemUserRole.Keys)).IsRequired();
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(SystemUserRole.ExtendedInformation)).HasMaxLength(SystemUserRoleConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(SystemUserRole.DateA)).IsRequired();
        b.Property(x => x.DateD).HasColumnName(nameof(SystemUserRole.DateD)).IsRequired();
        b.Property(x => x.Sort).HasColumnName(nameof(SystemUserRole.Sort)).IsRequired();
        b.Property(x => x.Note).HasColumnName(nameof(SystemUserRole.Note)).HasMaxLength(SystemUserRoleConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(SystemUserRole.Status)).IsRequired().HasMaxLength(SystemUserRoleConsts.StatusMaxLength);
    });
        builder.Entity<SystemValidate>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "SystemValidates", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(SystemValidate.TenantId));
        b.Property(x => x.Param).HasColumnName(nameof(SystemValidate.Param)).IsRequired().HasMaxLength(SystemValidateConsts.ParamMaxLength);
        b.Property(x => x.DateOpen).HasColumnName(nameof(SystemValidate.DateOpen)).IsRequired();
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(SystemValidate.ExtendedInformation)).HasMaxLength(SystemValidateConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(SystemValidate.DateA)).IsRequired();
        b.Property(x => x.DateD).HasColumnName(nameof(SystemValidate.DateD)).IsRequired();
        b.Property(x => x.Sort).HasColumnName(nameof(SystemValidate.Sort)).IsRequired();
        b.Property(x => x.Note).HasColumnName(nameof(SystemValidate.Note)).HasMaxLength(SystemValidateConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(SystemValidate.Status)).IsRequired().HasMaxLength(SystemValidateConsts.StatusMaxLength);
    });
        builder.Entity<TradeOderDetail>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "TradeOderDetails", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(TradeOderDetail.TenantId));
        b.Property(x => x.TradeOrderId).HasColumnName(nameof(TradeOderDetail.TradeOrderId));
        b.Property(x => x.TradeProductId).HasColumnName(nameof(TradeOderDetail.TradeProductId));
        b.Property(x => x.UnitPrice).HasColumnName(nameof(TradeOderDetail.UnitPrice));
        b.Property(x => x.Quantity).HasColumnName(nameof(TradeOderDetail.Quantity));
        b.Property(x => x.OrderDetailStateCode).HasColumnName(nameof(TradeOderDetail.OrderDetailStateCode)).IsRequired().HasMaxLength(TradeOderDetailConsts.OrderDetailStateCodeMaxLength);
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(TradeOderDetail.ExtendedInformation)).HasMaxLength(TradeOderDetailConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(TradeOderDetail.DateA));
        b.Property(x => x.DateD).HasColumnName(nameof(TradeOderDetail.DateD));
        b.Property(x => x.Sort).HasColumnName(nameof(TradeOderDetail.Sort));
        b.Property(x => x.Note).HasColumnName(nameof(TradeOderDetail.Note)).HasMaxLength(TradeOderDetailConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(TradeOderDetail.Status)).IsRequired().HasMaxLength(TradeOderDetailConsts.StatusMaxLength);
    });
        builder.Entity<TradeOrder>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "TradeOrders", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(TradeOrder.TenantId));
        b.Property(x => x.KeyId).HasColumnName(nameof(TradeOrder.KeyId));
        b.Property(x => x.OrderNumber).HasColumnName(nameof(TradeOrder.OrderNumber)).IsRequired().HasMaxLength(TradeOrderConsts.OrderNumberMaxLength);
        b.Property(x => x.DateOrder).HasColumnName(nameof(TradeOrder.DateOrder));
        b.Property(x => x.DateNeed).HasColumnName(nameof(TradeOrder.DateNeed));
        b.Property(x => x.DateDelivery).HasColumnName(nameof(TradeOrder.DateDelivery));
        b.Property(x => x.DeliveryMethodCode).HasColumnName(nameof(TradeOrder.DeliveryMethodCode)).HasMaxLength(TradeOrderConsts.DeliveryMethodCodeMaxLength);
        b.Property(x => x.DeliveryZipCode).HasColumnName(nameof(TradeOrder.DeliveryZipCode)).HasMaxLength(TradeOrderConsts.DeliveryZipCodeMaxLength);
        b.Property(x => x.DeliveryCityCode).HasColumnName(nameof(TradeOrder.DeliveryCityCode)).HasMaxLength(TradeOrderConsts.DeliveryCityCodeMaxLength);
        b.Property(x => x.DeliveryAreaCode).HasColumnName(nameof(TradeOrder.DeliveryAreaCode)).HasMaxLength(TradeOrderConsts.DeliveryAreaCodeMaxLength);
        b.Property(x => x.DeliveryAddress).HasColumnName(nameof(TradeOrder.DeliveryAddress)).HasMaxLength(TradeOrderConsts.DeliveryAddressMaxLength);
        b.Property(x => x.DeliveryFee).HasColumnName(nameof(TradeOrder.DeliveryFee));
        b.Property(x => x.UserName).HasColumnName(nameof(TradeOrder.UserName)).HasMaxLength(TradeOrderConsts.UserNameMaxLength);
        b.Property(x => x.OrderStateCode).HasColumnName(nameof(TradeOrder.OrderStateCode)).IsRequired().HasMaxLength(TradeOrderConsts.OrderStateCodeMaxLength);
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(TradeOrder.ExtendedInformation)).HasMaxLength(TradeOrderConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(TradeOrder.DateA));
        b.Property(x => x.DateD).HasColumnName(nameof(TradeOrder.DateD));
        b.Property(x => x.Sort).HasColumnName(nameof(TradeOrder.Sort));
        b.Property(x => x.Note).HasColumnName(nameof(TradeOrder.Note)).HasMaxLength(TradeOrderConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(TradeOrder.Status)).IsRequired().HasMaxLength(TradeOrderConsts.StatusMaxLength);
    });
        builder.Entity<TradeProduct>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "TradeProducts", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(TradeProduct.TenantId));
        b.Property(x => x.Name).HasColumnName(nameof(TradeProduct.Name)).IsRequired().HasMaxLength(TradeProductConsts.NameMaxLength);
        b.Property(x => x.Contents).HasColumnName(nameof(TradeProduct.Contents)).HasMaxLength(TradeProductConsts.ContentsMaxLength);
        b.Property(x => x.ProductCategoryCode).HasColumnName(nameof(TradeProduct.ProductCategoryCode)).IsRequired().HasMaxLength(TradeProductConsts.ProductCategoryCodeMaxLength);
        b.Property(x => x.UnitPrice).HasColumnName(nameof(TradeProduct.UnitPrice));
        b.Property(x => x.UnitPricePromotions).HasColumnName(nameof(TradeProduct.UnitPricePromotions));
        b.Property(x => x.UnitCode).HasColumnName(nameof(TradeProduct.UnitCode)).IsRequired().HasMaxLength(TradeProductConsts.UnitCodeMaxLength);
        b.Property(x => x.QuantityStock).HasColumnName(nameof(TradeProduct.QuantityStock));
        b.Property(x => x.QuantityOrdered).HasColumnName(nameof(TradeProduct.QuantityOrdered));
        b.Property(x => x.QuantitySafetyStock).HasColumnName(nameof(TradeProduct.QuantitySafetyStock));
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(TradeProduct.ExtendedInformation)).HasMaxLength(TradeProductConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(TradeProduct.DateA));
        b.Property(x => x.DateD).HasColumnName(nameof(TradeProduct.DateD));
        b.Property(x => x.Sort).HasColumnName(nameof(TradeProduct.Sort));
        b.Property(x => x.OrderStateCode).HasColumnName(nameof(TradeProduct.OrderStateCode)).HasMaxLength(TradeProductConsts.OrderStateCodeMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(TradeProduct.Status)).IsRequired().HasMaxLength(TradeProductConsts.StatusMaxLength);
    });
        builder.Entity<UserAccountBind>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "UserAccountBinds", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(UserAccountBind.TenantId));
        b.Property(x => x.UserMainId).HasColumnName(nameof(UserAccountBind.UserMainId));
        b.Property(x => x.ThirdPartyTypeCode).HasColumnName(nameof(UserAccountBind.ThirdPartyTypeCode)).IsRequired().HasMaxLength(UserAccountBindConsts.ThirdPartyTypeCodeMaxLength);
        b.Property(x => x.ThirdPartyAccountId).HasColumnName(nameof(UserAccountBind.ThirdPartyAccountId)).IsRequired().HasMaxLength(UserAccountBindConsts.ThirdPartyAccountIdMaxLength);
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(UserAccountBind.ExtendedInformation)).HasMaxLength(UserAccountBindConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(UserAccountBind.DateA)).IsRequired();
        b.Property(x => x.DateD).HasColumnName(nameof(UserAccountBind.DateD)).IsRequired();
        b.Property(x => x.Sort).HasColumnName(nameof(UserAccountBind.Sort)).IsRequired();
        b.Property(x => x.Note).HasColumnName(nameof(UserAccountBind.Note)).HasMaxLength(UserAccountBindConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(UserAccountBind.Status)).IsRequired().HasMaxLength(UserAccountBindConsts.StatusMaxLength);
    });
        builder.Entity<UserCompanyBind>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "UserCompanyBinds", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(UserCompanyBind.TenantId));
        b.Property(x => x.UserMainId).HasColumnName(nameof(UserCompanyBind.UserMainId));
        b.Property(x => x.CompanyMainId).HasColumnName(nameof(UserCompanyBind.CompanyMainId));
        b.Property(x => x.CompanyJobId).HasColumnName(nameof(UserCompanyBind.CompanyJobId));
        b.Property(x => x.CompanyInvitationsId).HasColumnName(nameof(UserCompanyBind.CompanyInvitationsId));
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(UserCompanyBind.ExtendedInformation)).HasMaxLength(UserCompanyBindConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(UserCompanyBind.DateA)).IsRequired();
        b.Property(x => x.DateD).HasColumnName(nameof(UserCompanyBind.DateD)).IsRequired();
        b.Property(x => x.Sort).HasColumnName(nameof(UserCompanyBind.Sort)).IsRequired();
        b.Property(x => x.Note).HasColumnName(nameof(UserCompanyBind.Note)).HasMaxLength(UserCompanyBindConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(UserCompanyBind.Status)).IsRequired().HasMaxLength(UserCompanyBindConsts.StatusMaxLength);
    });
        builder.Entity<UserCompanyJobApply>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "UserCompanyJobApplies", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(UserCompanyJobApply.TenantId));
        b.Property(x => x.UserMainId).HasColumnName(nameof(UserCompanyJobApply.UserMainId));
        b.Property(x => x.CompanyJobId).HasColumnName(nameof(UserCompanyJobApply.CompanyJobId));
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(UserCompanyJobApply.ExtendedInformation)).HasMaxLength(UserCompanyJobApplyConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(UserCompanyJobApply.DateA));
        b.Property(x => x.DateD).HasColumnName(nameof(UserCompanyJobApply.DateD));
        b.Property(x => x.Sort).HasColumnName(nameof(UserCompanyJobApply.Sort));
        b.Property(x => x.Note).HasColumnName(nameof(UserCompanyJobApply.Note)).HasMaxLength(UserCompanyJobApplyConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(UserCompanyJobApply.Status)).IsRequired().HasMaxLength(UserCompanyJobApplyConsts.StatusMaxLength);
    });
        builder.Entity<UserCompanyJobFav>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "UserCompanyJobFavs", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(UserCompanyJobFav.TenantId));
        b.Property(x => x.UserMainId).HasColumnName(nameof(UserCompanyJobFav.UserMainId));
        b.Property(x => x.CompanyJobId).HasColumnName(nameof(UserCompanyJobFav.CompanyJobId));
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(UserCompanyJobFav.ExtendedInformation)).HasMaxLength(UserCompanyJobFavConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(UserCompanyJobFav.DateA));
        b.Property(x => x.DateD).HasColumnName(nameof(UserCompanyJobFav.DateD));
        b.Property(x => x.Sort).HasColumnName(nameof(UserCompanyJobFav.Sort));
        b.Property(x => x.Note).HasColumnName(nameof(UserCompanyJobFav.Note)).HasMaxLength(UserCompanyJobFavConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(UserCompanyJobFav.Status)).IsRequired().HasMaxLength(UserCompanyJobFavConsts.StatusMaxLength);
    });
        builder.Entity<UserCompanyJobPair>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "UserCompanyJobPairs", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(UserCompanyJobPair.TenantId));
        b.Property(x => x.UserMainId).HasColumnName(nameof(UserCompanyJobPair.UserMainId));
        b.Property(x => x.Name).HasColumnName(nameof(UserCompanyJobPair.Name)).IsRequired().HasMaxLength(UserCompanyJobPairConsts.NameMaxLength);
        b.Property(x => x.PairCondition).HasColumnName(nameof(UserCompanyJobPair.PairCondition)).HasMaxLength(UserCompanyJobPairConsts.PairConditionMaxLength);
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(UserCompanyJobPair.ExtendedInformation)).HasMaxLength(UserCompanyJobPairConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(UserCompanyJobPair.DateA));
        b.Property(x => x.DateD).HasColumnName(nameof(UserCompanyJobPair.DateD));
        b.Property(x => x.Sort).HasColumnName(nameof(UserCompanyJobPair.Sort));
        b.Property(x => x.Note).HasColumnName(nameof(UserCompanyJobPair.Note)).HasMaxLength(UserCompanyJobPairConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(UserCompanyJobPair.Status)).IsRequired().HasMaxLength(UserCompanyJobPairConsts.StatusMaxLength);
    });
        builder.Entity<UserInfo>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "UserInfos", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(UserInfo.TenantId));
        b.Property(x => x.UserMainId).HasColumnName(nameof(UserInfo.UserMainId));
        b.Property(x => x.NameC).HasColumnName(nameof(UserInfo.NameC)).IsRequired().HasMaxLength(UserInfoConsts.NameCMaxLength);
        b.Property(x => x.NameE).HasColumnName(nameof(UserInfo.NameE)).HasMaxLength(UserInfoConsts.NameEMaxLength);
        b.Property(x => x.IdentityNo).HasColumnName(nameof(UserInfo.IdentityNo)).HasMaxLength(UserInfoConsts.IdentityNoMaxLength);
        b.Property(x => x.BirthDate).HasColumnName(nameof(UserInfo.BirthDate));
        b.Property(x => x.SexCode).HasColumnName(nameof(UserInfo.SexCode)).HasMaxLength(UserInfoConsts.SexCodeMaxLength);
        b.Property(x => x.BloodCode).HasColumnName(nameof(UserInfo.BloodCode)).HasMaxLength(UserInfoConsts.BloodCodeMaxLength);
        b.Property(x => x.PlaceOfBirthCode).HasColumnName(nameof(UserInfo.PlaceOfBirthCode)).HasMaxLength(UserInfoConsts.PlaceOfBirthCodeMaxLength);
        b.Property(x => x.PassportNo).HasColumnName(nameof(UserInfo.PassportNo)).HasMaxLength(UserInfoConsts.PassportNoMaxLength);
        b.Property(x => x.NationalityCode).HasColumnName(nameof(UserInfo.NationalityCode)).HasMaxLength(UserInfoConsts.NationalityCodeMaxLength);
        b.Property(x => x.ResidenceNo).HasColumnName(nameof(UserInfo.ResidenceNo)).HasMaxLength(UserInfoConsts.ResidenceNoMaxLength);
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(UserInfo.ExtendedInformation)).HasMaxLength(UserInfoConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(UserInfo.DateA));
        b.Property(x => x.DateD).HasColumnName(nameof(UserInfo.DateD));
        b.Property(x => x.Sort).HasColumnName(nameof(UserInfo.Sort));
        b.Property(x => x.Note).HasColumnName(nameof(UserInfo.Note)).HasMaxLength(UserInfoConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(UserInfo.Status)).IsRequired().HasMaxLength(UserInfoConsts.StatusMaxLength);
    });
        builder.Entity<UserMain>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "UserMains", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(UserMain.TenantId));
        b.Property(x => x.UserId).HasColumnName(nameof(UserMain.UserId));
        b.Property(x => x.Name).HasColumnName(nameof(UserMain.Name)).IsRequired().HasMaxLength(UserMainConsts.NameMaxLength);
        b.Property(x => x.AnonymousName).HasColumnName(nameof(UserMain.AnonymousName)).HasMaxLength(UserMainConsts.AnonymousNameMaxLength);
        b.Property(x => x.LoginAccountCode).HasColumnName(nameof(UserMain.LoginAccountCode)).IsRequired().HasMaxLength(UserMainConsts.LoginAccountCodeMaxLength);
        b.Property(x => x.LoginMobilePhoneUpdate).HasColumnName(nameof(UserMain.LoginMobilePhoneUpdate)).HasMaxLength(UserMainConsts.LoginMobilePhoneUpdateMaxLength);
        b.Property(x => x.LoginMobilePhone).HasColumnName(nameof(UserMain.LoginMobilePhone)).HasMaxLength(UserMainConsts.LoginMobilePhoneMaxLength);
        b.Property(x => x.LoginEmailUpdate).HasColumnName(nameof(UserMain.LoginEmailUpdate)).HasMaxLength(UserMainConsts.LoginEmailUpdateMaxLength);
        b.Property(x => x.LoginEmail).HasColumnName(nameof(UserMain.LoginEmail)).HasMaxLength(UserMainConsts.LoginEmailMaxLength);
        b.Property(x => x.LoginIdentityNo).HasColumnName(nameof(UserMain.LoginIdentityNo)).HasMaxLength(UserMainConsts.LoginIdentityNoMaxLength);
        b.Property(x => x.Password).HasColumnName(nameof(UserMain.Password)).IsRequired().HasMaxLength(UserMainConsts.PasswordMaxLength);
        b.Property(x => x.SystemUserRoleKeys).HasColumnName(nameof(UserMain.SystemUserRoleKeys)).IsRequired();
        b.Property(x => x.AllowSearch).HasColumnName(nameof(UserMain.AllowSearch)).IsRequired();
        b.Property(x => x.DateA).HasColumnName(nameof(UserMain.DateA)).IsRequired();
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(UserMain.ExtendedInformation)).HasMaxLength(UserMainConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateD).HasColumnName(nameof(UserMain.DateD)).IsRequired();
        b.Property(x => x.Sort).HasColumnName(nameof(UserMain.Sort)).IsRequired();
        b.Property(x => x.Note).HasColumnName(nameof(UserMain.Note)).HasMaxLength(UserMainConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(UserMain.Status)).IsRequired().HasMaxLength(UserMainConsts.StatusMaxLength);
        b.Property(x => x.Matching).HasColumnName(nameof(UserMain.Matching));
    });
        builder.Entity<UserToken>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "UserTokens", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(UserToken.TenantId));
        b.Property(x => x.UserMainId).HasColumnName(nameof(UserToken.UserMainId));
        b.Property(x => x.TokenOld).HasColumnName(nameof(UserToken.TokenOld)).IsRequired();
        b.Property(x => x.TokenNew).HasColumnName(nameof(UserToken.TokenNew)).IsRequired();
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(UserToken.ExtendedInformation)).HasMaxLength(UserTokenConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(UserToken.DateA));
        b.Property(x => x.DateD).HasColumnName(nameof(UserToken.DateD));
        b.Property(x => x.Sort).HasColumnName(nameof(UserToken.Sort));
        b.Property(x => x.Note).HasColumnName(nameof(UserToken.Note)).HasMaxLength(UserTokenConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(UserToken.Status)).IsRequired().HasMaxLength(UserTokenConsts.StatusMaxLength);
    });
        builder.Entity<UserVerify>(b =>
    {
        b.ToTable(ResumeConsts.DbTablePrefix + "UserVerifys", ResumeConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(UserVerify.TenantId));
        b.Property(x => x.VerifyId).HasColumnName(nameof(UserVerify.VerifyId)).IsRequired().HasMaxLength(UserVerifyConsts.VerifyIdMaxLength);
        b.Property(x => x.VerifyCode).HasColumnName(nameof(UserVerify.VerifyCode)).IsRequired().HasMaxLength(UserVerifyConsts.VerifyCodeMaxLength);
        b.Property(x => x.ExtendedInformation).HasColumnName(nameof(UserVerify.ExtendedInformation)).HasMaxLength(UserVerifyConsts.ExtendedInformationMaxLength);
        b.Property(x => x.DateA).HasColumnName(nameof(UserVerify.DateA)).IsRequired();
        b.Property(x => x.DateD).HasColumnName(nameof(UserVerify.DateD)).IsRequired();
        b.Property(x => x.Sort).HasColumnName(nameof(UserVerify.Sort)).IsRequired();
        b.Property(x => x.Note).HasColumnName(nameof(UserVerify.Note)).HasMaxLength(UserVerifyConsts.NoteMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(UserVerify.Status)).IsRequired().HasMaxLength(UserVerifyConsts.StatusMaxLength);
    });
    }
}