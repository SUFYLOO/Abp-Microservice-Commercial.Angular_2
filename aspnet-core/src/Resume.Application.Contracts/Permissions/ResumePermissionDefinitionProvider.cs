using Resume.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Resume.Permissions;

public class ResumePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ResumePermissions.GroupName);

        myGroup.AddPermission(ResumePermissions.Dashboard.Host, L("Permission:Dashboard"), MultiTenancySides.Host);
        myGroup.AddPermission(ResumePermissions.Dashboard.Tenant, L("Permission:Dashboard"), MultiTenancySides.Tenant);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(ResumePermissions.MyPermission1, L("Permission:MyPermission1"));

        var companyContractPermission = myGroup.AddPermission(ResumePermissions.CompanyContracts.Default, L("Permission:CompanyContracts"));
        companyContractPermission.AddChild(ResumePermissions.CompanyContracts.Create, L("Permission:Create"));
        companyContractPermission.AddChild(ResumePermissions.CompanyContracts.Edit, L("Permission:Edit"));
        companyContractPermission.AddChild(ResumePermissions.CompanyContracts.Delete, L("Permission:Delete"));

        var companyInvitationsPermission = myGroup.AddPermission(ResumePermissions.CompanyInvitationss.Default, L("Permission:CompanyInvitationss"));
        companyInvitationsPermission.AddChild(ResumePermissions.CompanyInvitationss.Create, L("Permission:Create"));
        companyInvitationsPermission.AddChild(ResumePermissions.CompanyInvitationss.Edit, L("Permission:Edit"));
        companyInvitationsPermission.AddChild(ResumePermissions.CompanyInvitationss.Delete, L("Permission:Delete"));

        var companyInvitationsCodePermission = myGroup.AddPermission(ResumePermissions.CompanyInvitationsCodes.Default, L("Permission:CompanyInvitationsCodes"));
        companyInvitationsCodePermission.AddChild(ResumePermissions.CompanyInvitationsCodes.Create, L("Permission:Create"));
        companyInvitationsCodePermission.AddChild(ResumePermissions.CompanyInvitationsCodes.Edit, L("Permission:Edit"));
        companyInvitationsCodePermission.AddChild(ResumePermissions.CompanyInvitationsCodes.Delete, L("Permission:Delete"));

        var companyJobPermission = myGroup.AddPermission(ResumePermissions.CompanyJobs.Default, L("Permission:CompanyJobs"));
        companyJobPermission.AddChild(ResumePermissions.CompanyJobs.Create, L("Permission:Create"));
        companyJobPermission.AddChild(ResumePermissions.CompanyJobs.Edit, L("Permission:Edit"));
        companyJobPermission.AddChild(ResumePermissions.CompanyJobs.Delete, L("Permission:Delete"));

        var companyJobApplicationMethodPermission = myGroup.AddPermission(ResumePermissions.CompanyJobApplicationMethods.Default, L("Permission:CompanyJobApplicationMethods"));
        companyJobApplicationMethodPermission.AddChild(ResumePermissions.CompanyJobApplicationMethods.Create, L("Permission:Create"));
        companyJobApplicationMethodPermission.AddChild(ResumePermissions.CompanyJobApplicationMethods.Edit, L("Permission:Edit"));
        companyJobApplicationMethodPermission.AddChild(ResumePermissions.CompanyJobApplicationMethods.Delete, L("Permission:Delete"));

        var companyJobConditionPermission = myGroup.AddPermission(ResumePermissions.CompanyJobConditions.Default, L("Permission:CompanyJobConditions"));
        companyJobConditionPermission.AddChild(ResumePermissions.CompanyJobConditions.Create, L("Permission:Create"));
        companyJobConditionPermission.AddChild(ResumePermissions.CompanyJobConditions.Edit, L("Permission:Edit"));
        companyJobConditionPermission.AddChild(ResumePermissions.CompanyJobConditions.Delete, L("Permission:Delete"));

        var companyJobContentPermission = myGroup.AddPermission(ResumePermissions.CompanyJobContents.Default, L("Permission:CompanyJobContents"));
        companyJobContentPermission.AddChild(ResumePermissions.CompanyJobContents.Create, L("Permission:Create"));
        companyJobContentPermission.AddChild(ResumePermissions.CompanyJobContents.Edit, L("Permission:Edit"));
        companyJobContentPermission.AddChild(ResumePermissions.CompanyJobContents.Delete, L("Permission:Delete"));

        var companyJobPairPermission = myGroup.AddPermission(ResumePermissions.CompanyJobPairs.Default, L("Permission:CompanyJobPairs"));
        companyJobPairPermission.AddChild(ResumePermissions.CompanyJobPairs.Create, L("Permission:Create"));
        companyJobPairPermission.AddChild(ResumePermissions.CompanyJobPairs.Edit, L("Permission:Edit"));
        companyJobPairPermission.AddChild(ResumePermissions.CompanyJobPairs.Delete, L("Permission:Delete"));

        var companyJobPayPermission = myGroup.AddPermission(ResumePermissions.CompanyJobPays.Default, L("Permission:CompanyJobPays"));
        companyJobPayPermission.AddChild(ResumePermissions.CompanyJobPays.Create, L("Permission:Create"));
        companyJobPayPermission.AddChild(ResumePermissions.CompanyJobPays.Edit, L("Permission:Edit"));
        companyJobPayPermission.AddChild(ResumePermissions.CompanyJobPays.Delete, L("Permission:Delete"));

        var companyMainPermission = myGroup.AddPermission(ResumePermissions.CompanyMains.Default, L("Permission:CompanyMains"));
        companyMainPermission.AddChild(ResumePermissions.CompanyMains.Create, L("Permission:Create"));
        companyMainPermission.AddChild(ResumePermissions.CompanyMains.Edit, L("Permission:Edit"));
        companyMainPermission.AddChild(ResumePermissions.CompanyMains.Delete, L("Permission:Delete"));

        var companyPointsPermission = myGroup.AddPermission(ResumePermissions.CompanyPointss.Default, L("Permission:CompanyPointss"));
        companyPointsPermission.AddChild(ResumePermissions.CompanyPointss.Create, L("Permission:Create"));
        companyPointsPermission.AddChild(ResumePermissions.CompanyPointss.Edit, L("Permission:Edit"));
        companyPointsPermission.AddChild(ResumePermissions.CompanyPointss.Delete, L("Permission:Delete"));

        var companyUserPermission = myGroup.AddPermission(ResumePermissions.CompanyUsers.Default, L("Permission:CompanyUsers"));
        companyUserPermission.AddChild(ResumePermissions.CompanyUsers.Create, L("Permission:Create"));
        companyUserPermission.AddChild(ResumePermissions.CompanyUsers.Edit, L("Permission:Edit"));
        companyUserPermission.AddChild(ResumePermissions.CompanyUsers.Delete, L("Permission:Delete"));

        var resumeCommunicationPermission = myGroup.AddPermission(ResumePermissions.ResumeCommunications.Default, L("Permission:ResumeCommunications"));
        resumeCommunicationPermission.AddChild(ResumePermissions.ResumeCommunications.Create, L("Permission:Create"));
        resumeCommunicationPermission.AddChild(ResumePermissions.ResumeCommunications.Edit, L("Permission:Edit"));
        resumeCommunicationPermission.AddChild(ResumePermissions.ResumeCommunications.Delete, L("Permission:Delete"));

        var resumeDependentsPermission = myGroup.AddPermission(ResumePermissions.ResumeDependentss.Default, L("Permission:ResumeDependentss"));
        resumeDependentsPermission.AddChild(ResumePermissions.ResumeDependentss.Create, L("Permission:Create"));
        resumeDependentsPermission.AddChild(ResumePermissions.ResumeDependentss.Edit, L("Permission:Edit"));
        resumeDependentsPermission.AddChild(ResumePermissions.ResumeDependentss.Delete, L("Permission:Delete"));

        var resumeDrvingLicensePermission = myGroup.AddPermission(ResumePermissions.ResumeDrvingLicenses.Default, L("Permission:ResumeDrvingLicenses"));
        resumeDrvingLicensePermission.AddChild(ResumePermissions.ResumeDrvingLicenses.Create, L("Permission:Create"));
        resumeDrvingLicensePermission.AddChild(ResumePermissions.ResumeDrvingLicenses.Edit, L("Permission:Edit"));
        resumeDrvingLicensePermission.AddChild(ResumePermissions.ResumeDrvingLicenses.Delete, L("Permission:Delete"));

        var resumeEducationsPermission = myGroup.AddPermission(ResumePermissions.ResumeEducationss.Default, L("Permission:ResumeEducationss"));
        resumeEducationsPermission.AddChild(ResumePermissions.ResumeEducationss.Create, L("Permission:Create"));
        resumeEducationsPermission.AddChild(ResumePermissions.ResumeEducationss.Edit, L("Permission:Edit"));
        resumeEducationsPermission.AddChild(ResumePermissions.ResumeEducationss.Delete, L("Permission:Delete"));

        var resumeExperiencesPermission = myGroup.AddPermission(ResumePermissions.ResumeExperiencess.Default, L("Permission:ResumeExperiencess"));
        resumeExperiencesPermission.AddChild(ResumePermissions.ResumeExperiencess.Create, L("Permission:Create"));
        resumeExperiencesPermission.AddChild(ResumePermissions.ResumeExperiencess.Edit, L("Permission:Edit"));
        resumeExperiencesPermission.AddChild(ResumePermissions.ResumeExperiencess.Delete, L("Permission:Delete"));

        var resumeLanguagePermission = myGroup.AddPermission(ResumePermissions.ResumeLanguages.Default, L("Permission:ResumeLanguages"));
        resumeLanguagePermission.AddChild(ResumePermissions.ResumeLanguages.Create, L("Permission:Create"));
        resumeLanguagePermission.AddChild(ResumePermissions.ResumeLanguages.Edit, L("Permission:Edit"));
        resumeLanguagePermission.AddChild(ResumePermissions.ResumeLanguages.Delete, L("Permission:Delete"));

        var resumeMainPermission = myGroup.AddPermission(ResumePermissions.ResumeMains.Default, L("Permission:ResumeMains"));
        resumeMainPermission.AddChild(ResumePermissions.ResumeMains.Create, L("Permission:Create"));
        resumeMainPermission.AddChild(ResumePermissions.ResumeMains.Edit, L("Permission:Edit"));
        resumeMainPermission.AddChild(ResumePermissions.ResumeMains.Delete, L("Permission:Delete"));

        var resumeRecommenderPermission = myGroup.AddPermission(ResumePermissions.ResumeRecommenders.Default, L("Permission:ResumeRecommenders"));
        resumeRecommenderPermission.AddChild(ResumePermissions.ResumeRecommenders.Create, L("Permission:Create"));
        resumeRecommenderPermission.AddChild(ResumePermissions.ResumeRecommenders.Edit, L("Permission:Edit"));
        resumeRecommenderPermission.AddChild(ResumePermissions.ResumeRecommenders.Delete, L("Permission:Delete"));

        var resumeSkillPermission = myGroup.AddPermission(ResumePermissions.ResumeSkills.Default, L("Permission:ResumeSkills"));
        resumeSkillPermission.AddChild(ResumePermissions.ResumeSkills.Create, L("Permission:Create"));
        resumeSkillPermission.AddChild(ResumePermissions.ResumeSkills.Edit, L("Permission:Edit"));
        resumeSkillPermission.AddChild(ResumePermissions.ResumeSkills.Delete, L("Permission:Delete"));

        var resumeSnapshotPermission = myGroup.AddPermission(ResumePermissions.ResumeSnapshots.Default, L("Permission:ResumeSnapshots"));
        resumeSnapshotPermission.AddChild(ResumePermissions.ResumeSnapshots.Create, L("Permission:Create"));
        resumeSnapshotPermission.AddChild(ResumePermissions.ResumeSnapshots.Edit, L("Permission:Edit"));
        resumeSnapshotPermission.AddChild(ResumePermissions.ResumeSnapshots.Delete, L("Permission:Delete"));

        var resumeWorksPermission = myGroup.AddPermission(ResumePermissions.ResumeWorkss.Default, L("Permission:ResumeWorkss"));
        resumeWorksPermission.AddChild(ResumePermissions.ResumeWorkss.Create, L("Permission:Create"));
        resumeWorksPermission.AddChild(ResumePermissions.ResumeWorkss.Edit, L("Permission:Edit"));
        resumeWorksPermission.AddChild(ResumePermissions.ResumeWorkss.Delete, L("Permission:Delete"));

        var shareCodePermission = myGroup.AddPermission(ResumePermissions.ShareCodes.Default, L("Permission:ShareCodes"));
        shareCodePermission.AddChild(ResumePermissions.ShareCodes.Create, L("Permission:Create"));
        shareCodePermission.AddChild(ResumePermissions.ShareCodes.Edit, L("Permission:Edit"));
        shareCodePermission.AddChild(ResumePermissions.ShareCodes.Delete, L("Permission:Delete"));

        var shareDefaultPermission = myGroup.AddPermission(ResumePermissions.ShareDefaults.Default, L("Permission:ShareDefaults"));
        shareDefaultPermission.AddChild(ResumePermissions.ShareDefaults.Create, L("Permission:Create"));
        shareDefaultPermission.AddChild(ResumePermissions.ShareDefaults.Edit, L("Permission:Edit"));
        shareDefaultPermission.AddChild(ResumePermissions.ShareDefaults.Delete, L("Permission:Delete"));

        var shareDictionaryPermission = myGroup.AddPermission(ResumePermissions.ShareDictionarys.Default, L("Permission:ShareDictionarys"));
        shareDictionaryPermission.AddChild(ResumePermissions.ShareDictionarys.Create, L("Permission:Create"));
        shareDictionaryPermission.AddChild(ResumePermissions.ShareDictionarys.Edit, L("Permission:Edit"));
        shareDictionaryPermission.AddChild(ResumePermissions.ShareDictionarys.Delete, L("Permission:Delete"));

        var shareLanguagePermission = myGroup.AddPermission(ResumePermissions.ShareLanguages.Default, L("Permission:ShareLanguages"));
        shareLanguagePermission.AddChild(ResumePermissions.ShareLanguages.Create, L("Permission:Create"));
        shareLanguagePermission.AddChild(ResumePermissions.ShareLanguages.Edit, L("Permission:Edit"));
        shareLanguagePermission.AddChild(ResumePermissions.ShareLanguages.Delete, L("Permission:Delete"));

        var shareMessageTplPermission = myGroup.AddPermission(ResumePermissions.ShareMessageTpls.Default, L("Permission:ShareMessageTpls"));
        shareMessageTplPermission.AddChild(ResumePermissions.ShareMessageTpls.Create, L("Permission:Create"));
        shareMessageTplPermission.AddChild(ResumePermissions.ShareMessageTpls.Edit, L("Permission:Edit"));
        shareMessageTplPermission.AddChild(ResumePermissions.ShareMessageTpls.Delete, L("Permission:Delete"));

        var shareSendQueuePermission = myGroup.AddPermission(ResumePermissions.ShareSendQueues.Default, L("Permission:ShareSendQueues"));
        shareSendQueuePermission.AddChild(ResumePermissions.ShareSendQueues.Create, L("Permission:Create"));
        shareSendQueuePermission.AddChild(ResumePermissions.ShareSendQueues.Edit, L("Permission:Edit"));
        shareSendQueuePermission.AddChild(ResumePermissions.ShareSendQueues.Delete, L("Permission:Delete"));

        var shareTagPermission = myGroup.AddPermission(ResumePermissions.ShareTags.Default, L("Permission:ShareTags"));
        shareTagPermission.AddChild(ResumePermissions.ShareTags.Create, L("Permission:Create"));
        shareTagPermission.AddChild(ResumePermissions.ShareTags.Edit, L("Permission:Edit"));
        shareTagPermission.AddChild(ResumePermissions.ShareTags.Delete, L("Permission:Delete"));

        var shareUploadPermission = myGroup.AddPermission(ResumePermissions.ShareUploads.Default, L("Permission:ShareUploads"));
        shareUploadPermission.AddChild(ResumePermissions.ShareUploads.Create, L("Permission:Create"));
        shareUploadPermission.AddChild(ResumePermissions.ShareUploads.Edit, L("Permission:Edit"));
        shareUploadPermission.AddChild(ResumePermissions.ShareUploads.Delete, L("Permission:Delete"));

        var systemColumnPermission = myGroup.AddPermission(ResumePermissions.SystemColumns.Default, L("Permission:SystemColumns"));
        systemColumnPermission.AddChild(ResumePermissions.SystemColumns.Create, L("Permission:Create"));
        systemColumnPermission.AddChild(ResumePermissions.SystemColumns.Edit, L("Permission:Edit"));
        systemColumnPermission.AddChild(ResumePermissions.SystemColumns.Delete, L("Permission:Delete"));

        var systemDisplayMessagePermission = myGroup.AddPermission(ResumePermissions.SystemDisplayMessages.Default, L("Permission:SystemDisplayMessages"));
        systemDisplayMessagePermission.AddChild(ResumePermissions.SystemDisplayMessages.Create, L("Permission:Create"));
        systemDisplayMessagePermission.AddChild(ResumePermissions.SystemDisplayMessages.Edit, L("Permission:Edit"));
        systemDisplayMessagePermission.AddChild(ResumePermissions.SystemDisplayMessages.Delete, L("Permission:Delete"));

        var systemPagePermission = myGroup.AddPermission(ResumePermissions.SystemPages.Default, L("Permission:SystemPages"));
        systemPagePermission.AddChild(ResumePermissions.SystemPages.Create, L("Permission:Create"));
        systemPagePermission.AddChild(ResumePermissions.SystemPages.Edit, L("Permission:Edit"));
        systemPagePermission.AddChild(ResumePermissions.SystemPages.Delete, L("Permission:Delete"));

        var systemTablePermission = myGroup.AddPermission(ResumePermissions.SystemTables.Default, L("Permission:SystemTables"));
        systemTablePermission.AddChild(ResumePermissions.SystemTables.Create, L("Permission:Create"));
        systemTablePermission.AddChild(ResumePermissions.SystemTables.Edit, L("Permission:Edit"));
        systemTablePermission.AddChild(ResumePermissions.SystemTables.Delete, L("Permission:Delete"));

        var systemUserNotifyPermission = myGroup.AddPermission(ResumePermissions.SystemUserNotifys.Default, L("Permission:SystemUserNotifys"));
        systemUserNotifyPermission.AddChild(ResumePermissions.SystemUserNotifys.Create, L("Permission:Create"));
        systemUserNotifyPermission.AddChild(ResumePermissions.SystemUserNotifys.Edit, L("Permission:Edit"));
        systemUserNotifyPermission.AddChild(ResumePermissions.SystemUserNotifys.Delete, L("Permission:Delete"));

        var systemUserRolePermission = myGroup.AddPermission(ResumePermissions.SystemUserRoles.Default, L("Permission:SystemUserRoles"));
        systemUserRolePermission.AddChild(ResumePermissions.SystemUserRoles.Create, L("Permission:Create"));
        systemUserRolePermission.AddChild(ResumePermissions.SystemUserRoles.Edit, L("Permission:Edit"));
        systemUserRolePermission.AddChild(ResumePermissions.SystemUserRoles.Delete, L("Permission:Delete"));

        var systemValidatePermission = myGroup.AddPermission(ResumePermissions.SystemValidates.Default, L("Permission:SystemValidates"));
        systemValidatePermission.AddChild(ResumePermissions.SystemValidates.Create, L("Permission:Create"));
        systemValidatePermission.AddChild(ResumePermissions.SystemValidates.Edit, L("Permission:Edit"));
        systemValidatePermission.AddChild(ResumePermissions.SystemValidates.Delete, L("Permission:Delete"));

        var tradeOderDetailPermission = myGroup.AddPermission(ResumePermissions.TradeOderDetails.Default, L("Permission:TradeOderDetails"));
        tradeOderDetailPermission.AddChild(ResumePermissions.TradeOderDetails.Create, L("Permission:Create"));
        tradeOderDetailPermission.AddChild(ResumePermissions.TradeOderDetails.Edit, L("Permission:Edit"));
        tradeOderDetailPermission.AddChild(ResumePermissions.TradeOderDetails.Delete, L("Permission:Delete"));

        var tradeOrderPermission = myGroup.AddPermission(ResumePermissions.TradeOrders.Default, L("Permission:TradeOrders"));
        tradeOrderPermission.AddChild(ResumePermissions.TradeOrders.Create, L("Permission:Create"));
        tradeOrderPermission.AddChild(ResumePermissions.TradeOrders.Edit, L("Permission:Edit"));
        tradeOrderPermission.AddChild(ResumePermissions.TradeOrders.Delete, L("Permission:Delete"));

        var tradeProductPermission = myGroup.AddPermission(ResumePermissions.TradeProducts.Default, L("Permission:TradeProducts"));
        tradeProductPermission.AddChild(ResumePermissions.TradeProducts.Create, L("Permission:Create"));
        tradeProductPermission.AddChild(ResumePermissions.TradeProducts.Edit, L("Permission:Edit"));
        tradeProductPermission.AddChild(ResumePermissions.TradeProducts.Delete, L("Permission:Delete"));

        var userAccountBindPermission = myGroup.AddPermission(ResumePermissions.UserAccountBinds.Default, L("Permission:UserAccountBinds"));
        userAccountBindPermission.AddChild(ResumePermissions.UserAccountBinds.Create, L("Permission:Create"));
        userAccountBindPermission.AddChild(ResumePermissions.UserAccountBinds.Edit, L("Permission:Edit"));
        userAccountBindPermission.AddChild(ResumePermissions.UserAccountBinds.Delete, L("Permission:Delete"));

        var userCompanyBindPermission = myGroup.AddPermission(ResumePermissions.UserCompanyBinds.Default, L("Permission:UserCompanyBinds"));
        userCompanyBindPermission.AddChild(ResumePermissions.UserCompanyBinds.Create, L("Permission:Create"));
        userCompanyBindPermission.AddChild(ResumePermissions.UserCompanyBinds.Edit, L("Permission:Edit"));
        userCompanyBindPermission.AddChild(ResumePermissions.UserCompanyBinds.Delete, L("Permission:Delete"));

        var userCompanyJobApplyPermission = myGroup.AddPermission(ResumePermissions.UserCompanyJobApplies.Default, L("Permission:UserCompanyJobApplies"));
        userCompanyJobApplyPermission.AddChild(ResumePermissions.UserCompanyJobApplies.Create, L("Permission:Create"));
        userCompanyJobApplyPermission.AddChild(ResumePermissions.UserCompanyJobApplies.Edit, L("Permission:Edit"));
        userCompanyJobApplyPermission.AddChild(ResumePermissions.UserCompanyJobApplies.Delete, L("Permission:Delete"));

        var userCompanyJobFavPermission = myGroup.AddPermission(ResumePermissions.UserCompanyJobFavs.Default, L("Permission:UserCompanyJobFavs"));
        userCompanyJobFavPermission.AddChild(ResumePermissions.UserCompanyJobFavs.Create, L("Permission:Create"));
        userCompanyJobFavPermission.AddChild(ResumePermissions.UserCompanyJobFavs.Edit, L("Permission:Edit"));
        userCompanyJobFavPermission.AddChild(ResumePermissions.UserCompanyJobFavs.Delete, L("Permission:Delete"));

        var userCompanyJobPairPermission = myGroup.AddPermission(ResumePermissions.UserCompanyJobPairs.Default, L("Permission:UserCompanyJobPairs"));
        userCompanyJobPairPermission.AddChild(ResumePermissions.UserCompanyJobPairs.Create, L("Permission:Create"));
        userCompanyJobPairPermission.AddChild(ResumePermissions.UserCompanyJobPairs.Edit, L("Permission:Edit"));
        userCompanyJobPairPermission.AddChild(ResumePermissions.UserCompanyJobPairs.Delete, L("Permission:Delete"));

        var userInfoPermission = myGroup.AddPermission(ResumePermissions.UserInfos.Default, L("Permission:UserInfos"));
        userInfoPermission.AddChild(ResumePermissions.UserInfos.Create, L("Permission:Create"));
        userInfoPermission.AddChild(ResumePermissions.UserInfos.Edit, L("Permission:Edit"));
        userInfoPermission.AddChild(ResumePermissions.UserInfos.Delete, L("Permission:Delete"));

        var userMainPermission = myGroup.AddPermission(ResumePermissions.UserMains.Default, L("Permission:UserMains"));
        userMainPermission.AddChild(ResumePermissions.UserMains.Create, L("Permission:Create"));
        userMainPermission.AddChild(ResumePermissions.UserMains.Edit, L("Permission:Edit"));
        userMainPermission.AddChild(ResumePermissions.UserMains.Delete, L("Permission:Delete"));

        var userTokenPermission = myGroup.AddPermission(ResumePermissions.UserTokens.Default, L("Permission:UserTokens"));
        userTokenPermission.AddChild(ResumePermissions.UserTokens.Create, L("Permission:Create"));
        userTokenPermission.AddChild(ResumePermissions.UserTokens.Edit, L("Permission:Edit"));
        userTokenPermission.AddChild(ResumePermissions.UserTokens.Delete, L("Permission:Delete"));

        var userVerifyPermission = myGroup.AddPermission(ResumePermissions.UserVerifys.Default, L("Permission:UserVerifys"));
        userVerifyPermission.AddChild(ResumePermissions.UserVerifys.Create, L("Permission:Create"));
        userVerifyPermission.AddChild(ResumePermissions.UserVerifys.Edit, L("Permission:Edit"));
        userVerifyPermission.AddChild(ResumePermissions.UserVerifys.Delete, L("Permission:Delete"));

        var companyJobOrganizationUnitPermission = myGroup.AddPermission(ResumePermissions.CompanyJobOrganizationUnits.Default, L("Permission:CompanyJobOrganizationUnits"));
        companyJobOrganizationUnitPermission.AddChild(ResumePermissions.CompanyJobOrganizationUnits.Create, L("Permission:Create"));
        companyJobOrganizationUnitPermission.AddChild(ResumePermissions.CompanyJobOrganizationUnits.Edit, L("Permission:Edit"));
        companyJobOrganizationUnitPermission.AddChild(ResumePermissions.CompanyJobOrganizationUnits.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ResumeResource>(name);
    }
}