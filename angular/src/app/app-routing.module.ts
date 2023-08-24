import { AuthGuard, PermissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    loadChildren: () => import('./home/home.module').then(m => m.HomeModule),
  },
  {
    path: 'dashboard',
    loadChildren: () => import('./dashboard/dashboard.module').then(m => m.DashboardModule),
    canActivate: [AuthGuard, PermissionGuard],
  },
  {
    path: 'account',
    loadChildren: () =>
      import('@volo/abp.ng.account/public').then(m => m.AccountPublicModule.forLazy()),
  },
  {
    path: 'gdpr',
    loadChildren: () => import('@volo/abp.ng.gdpr').then(m => m.GdprModule.forLazy()),
  },
  {
    path: 'identity',
    loadChildren: () => import('@volo/abp.ng.identity').then(m => m.IdentityModule.forLazy()),
  },
  {
    path: 'language-management',
    loadChildren: () =>
      import('@volo/abp.ng.language-management').then(m => m.LanguageManagementModule.forLazy()),
  },
  {
    path: 'saas',
    loadChildren: () => import('@volo/abp.ng.saas').then(m => m.SaasModule.forLazy()),
  },
  {
    path: 'audit-logs',
    loadChildren: () =>
      import('@volo/abp.ng.audit-logging').then(m => m.AuditLoggingModule.forLazy()),
  },
  {
    path: 'openiddict',
    loadChildren: () =>
      import('@volo/abp.ng.openiddictpro').then(m => m.OpeniddictproModule.forLazy()),
  },
  {
    path: 'text-template-management',
    loadChildren: () =>
      import('@volo/abp.ng.text-template-management').then(m =>
        m.TextTemplateManagementModule.forLazy()
      ),
  },
  {
    path: 'setting-management',
    loadChildren: () =>
      import('@abp/ng.setting-management').then(m => m.SettingManagementModule.forLazy()),
  },
  {
    path: 'gdpr-cookie-consent',
    loadChildren: () =>
      import('./gdpr-cookie-consent/gdpr-cookie-consent.module').then(
        m => m.GdprCookieConsentModule
      ),
  },
  {
    path: 'company-contracts',
    loadChildren: () =>
      import('./company-contracts/company-contract/company-contract.module').then(
        m => m.CompanyContractModule
      ),
  },
  {
    path: 'company-invitationss',
    loadChildren: () =>
      import('./company-invitationss/company-invitations/company-invitations.module').then(
        m => m.CompanyInvitationsModule
      ),
  },
  {
    path: 'company-invitations-codes',
    loadChildren: () =>
      import(
        './company-invitations-codes/company-invitations-code/company-invitations-code.module'
      ).then(m => m.CompanyInvitationsCodeModule),
  },
  {
    path: 'company-jobs',
    loadChildren: () =>
      import('./company-jobs/company-job/company-job.module').then(m => m.CompanyJobModule),
  },
  {
    path: 'company-job-application-methods',
    loadChildren: () =>
      import(
        './company-job-application-methods/company-job-application-method/company-job-application-method.module'
      ).then(m => m.CompanyJobApplicationMethodModule),
  },
  {
    path: 'company-job-conditions',
    loadChildren: () =>
      import('./company-job-conditions/company-job-condition/company-job-condition.module').then(
        m => m.CompanyJobConditionModule
      ),
  },
  {
    path: 'company-job-contents',
    loadChildren: () =>
      import('./company-job-contents/company-job-content/company-job-content.module').then(
        m => m.CompanyJobContentModule
      ),
  },
  {
    path: 'company-job-pairs',
    loadChildren: () =>
      import('./company-job-pairs/company-job-pair/company-job-pair.module').then(
        m => m.CompanyJobPairModule
      ),
  },
  {
    path: 'company-job-pays',
    loadChildren: () =>
      import('./company-job-pays/company-job-pay/company-job-pay.module').then(
        m => m.CompanyJobPayModule
      ),
  },
  {
    path: 'company-mains',
    loadChildren: () =>
      import('./company-mains/company-main/company-main.module').then(m => m.CompanyMainModule),
  },
  {
    path: 'company-pointss',
    loadChildren: () =>
      import('./company-pointss/company-points/company-points.module').then(
        m => m.CompanyPointsModule
      ),
  },
  {
    path: 'company-users',
    loadChildren: () =>
      import('./company-users/company-user/company-user.module').then(m => m.CompanyUserModule),
  },
  {
    path: 'resume-communications',
    loadChildren: () =>
      import('./resume-communications/resume-communication/resume-communication.module').then(
        m => m.ResumeCommunicationModule
      ),
  },
  {
    path: 'resume-dependentss',
    loadChildren: () =>
      import('./resume-dependentss/resume-dependents/resume-dependents.module').then(
        m => m.ResumeDependentsModule
      ),
  },
  {
    path: 'resume-drving-licenses',
    loadChildren: () =>
      import('./resume-drving-licenses/resume-drving-license/resume-drving-license.module').then(
        m => m.ResumeDrvingLicenseModule
      ),
  },
  {
    path: 'resume-educationss',
    loadChildren: () =>
      import('./resume-educationss/resume-educations/resume-educations.module').then(
        m => m.ResumeEducationsModule
      ),
  },
  {
    path: 'resume-experiencess',
    loadChildren: () =>
      import('./resume-experiencess/resume-experiences/resume-experiences.module').then(
        m => m.ResumeExperiencesModule
      ),
  },
  {
    path: 'resume-languages',
    loadChildren: () =>
      import('./resume-languages/resume-language/resume-language.module').then(
        m => m.ResumeLanguageModule
      ),
  },
  {
    path: 'resume-mains',
    loadChildren: () =>
      import('./resume-mains/resume-main/resume-main.module').then(m => m.ResumeMainModule),
  },
  {
    path: 'resume-recommenders',
    loadChildren: () =>
      import('./resume-recommenders/resume-recommender/resume-recommender.module').then(
        m => m.ResumeRecommenderModule
      ),
  },
  {
    path: 'resume-skills',
    loadChildren: () =>
      import('./resume-skills/resume-skill/resume-skill.module').then(m => m.ResumeSkillModule),
  },
  {
    path: 'resume-snapshots',
    loadChildren: () =>
      import('./resume-snapshots/resume-snapshot/resume-snapshot.module').then(
        m => m.ResumeSnapshotModule
      ),
  },
  {
    path: 'resume-workss',
    loadChildren: () =>
      import('./resume-workss/resume-works/resume-works.module').then(m => m.ResumeWorksModule),
  },
  {
    path: 'share-codes',
    loadChildren: () =>
      import('./share-codes/share-code/share-code.module').then(m => m.ShareCodeModule),
  },
  {
    path: 'share-defaults',
    loadChildren: () =>
      import('./share-defaults/share-default/share-default.module').then(m => m.ShareDefaultModule),
  },
  {
    path: 'share-dictionarys',
    loadChildren: () =>
      import('./share-dictionarys/share-dictionary/share-dictionary.module').then(
        m => m.ShareDictionaryModule
      ),
  },
  {
    path: 'share-languages',
    loadChildren: () =>
      import('./share-languages/share-language/share-language.module').then(
        m => m.ShareLanguageModule
      ),
  },
  {
    path: 'share-message-tpls',
    loadChildren: () =>
      import('./share-message-tpls/share-message-tpl/share-message-tpl.module').then(
        m => m.ShareMessageTplModule
      ),
  },
  {
    path: 'share-send-queues',
    loadChildren: () =>
      import('./share-send-queues/share-send-queue/share-send-queue.module').then(
        m => m.ShareSendQueueModule
      ),
  },
  {
    path: 'share-tags',
    loadChildren: () =>
      import('./share-tags/share-tag/share-tag.module').then(m => m.ShareTagModule),
  },
  {
    path: 'share-uploads',
    loadChildren: () =>
      import('./share-uploads/share-upload/share-upload.module').then(m => m.ShareUploadModule),
  },
  {
    path: 'system-columns',
    loadChildren: () =>
      import('./system-columns/system-column/system-column.module').then(m => m.SystemColumnModule),
  },
  {
    path: 'system-display-messages',
    loadChildren: () =>
      import('./system-display-messages/system-display-message/system-display-message.module').then(
        m => m.SystemDisplayMessageModule
      ),
  },
  {
    path: 'system-pages',
    loadChildren: () =>
      import('./system-pages/system-page/system-page.module').then(m => m.SystemPageModule),
  },
  {
    path: 'system-tables',
    loadChildren: () =>
      import('./system-tables/system-table/system-table.module').then(m => m.SystemTableModule),
  },
  {
    path: 'system-user-notifys',
    loadChildren: () =>
      import('./system-user-notifys/system-user-notify/system-user-notify.module').then(
        m => m.SystemUserNotifyModule
      ),
  },
  {
    path: 'system-user-roles',
    loadChildren: () =>
      import('./system-user-roles/system-user-role/system-user-role.module').then(
        m => m.SystemUserRoleModule
      ),
  },
  {
    path: 'system-validates',
    loadChildren: () =>
      import('./system-validates/system-validate/system-validate.module').then(
        m => m.SystemValidateModule
      ),
  },
  {
    path: 'trade-oder-details',
    loadChildren: () =>
      import('./trade-oder-details/trade-oder-detail/trade-oder-detail.module').then(
        m => m.TradeOderDetailModule
      ),
  },
  {
    path: 'trade-orders',
    loadChildren: () =>
      import('./trade-orders/trade-order/trade-order.module').then(m => m.TradeOrderModule),
  },
  {
    path: 'trade-products',
    loadChildren: () =>
      import('./trade-products/trade-product/trade-product.module').then(m => m.TradeProductModule),
  },
  {
    path: 'user-account-binds',
    loadChildren: () =>
      import('./user-account-binds/user-account-bind/user-account-bind.module').then(
        m => m.UserAccountBindModule
      ),
  },
  {
    path: 'user-company-binds',
    loadChildren: () =>
      import('./user-company-binds/user-company-bind/user-company-bind.module').then(
        m => m.UserCompanyBindModule
      ),
  },
  {
    path: 'user-company-job-applies',
    loadChildren: () =>
      import(
        './user-company-job-applies/user-company-job-apply/user-company-job-apply.module'
      ).then(m => m.UserCompanyJobApplyModule),
  },
  {
    path: 'user-company-job-favs',
    loadChildren: () =>
      import('./user-company-job-favs/user-company-job-fav/user-company-job-fav.module').then(
        m => m.UserCompanyJobFavModule
      ),
  },
  {
    path: 'user-company-job-pairs',
    loadChildren: () =>
      import('./user-company-job-pairs/user-company-job-pair/user-company-job-pair.module').then(
        m => m.UserCompanyJobPairModule
      ),
  },
  {
    path: 'user-infos',
    loadChildren: () =>
      import('./user-infos/user-info/user-info.module').then(m => m.UserInfoModule),
  },
  {
    path: 'user-mains',
    loadChildren: () =>
      import('./user-mains/user-main/user-main.module').then(m => m.UserMainModule),
  },
  {
    path: 'user-tokens',
    loadChildren: () =>
      import('./user-tokens/user-token/user-token.module').then(m => m.UserTokenModule),
  },
  {
    path: 'user-verifys',
    loadChildren: () =>
      import('./user-verifys/user-verify/user-verify.module').then(m => m.UserVerifyModule),
  },
  {
    path: 'company-job-organization-units',
    loadChildren: () =>
      import(
        './company-job-organization-units/company-job-organization-unit/company-job-organization-unit.module'
      ).then(m => m.CompanyJobOrganizationUnitModule),
  },
  {
    path: 'share-extendeds',
    loadChildren: () =>
      import('./share-extendeds/share-extended/share-extended.module').then(
        m => m.ShareExtendedModule
      ),
  },
  {
    path: 'resume-experiences-jobs',
    loadChildren: () =>
      import('./resume-experiences-jobs/resume-experiences-job/resume-experiences-job.module').then(
        m => m.ResumeExperiencesJobModule
      ),
  },
  {
    path: 'company-user-main-favs',
    loadChildren: () =>
      import('./company-user-main-favs/company-user-main-fav/company-user-main-fav.module').then(
        m => m.CompanyUserMainFavModule
      ),
  },
  {
    path: 'company-job-work-identities',
    loadChildren: () =>
      import(
        './company-job-work-identities/company-job-work-identity/company-job-work-identity.module'
      ).then(m => m.CompanyJobWorkIdentityModule),
  },
  {
    path: 'company-job-disability-categories',
    loadChildren: () =>
      import(
        './company-job-disability-categories/company-job-disability-category/company-job-disability-category.module'
      ).then(m => m.CompanyJobDisabilityCategoryModule),
  },
  {
    path: 'company-job-education-levels',
    loadChildren: () =>
      import(
        './company-job-education-levels/company-job-education-level/company-job-education-level.module'
      ).then(m => m.CompanyJobEducationLevelModule),
  },
  {
    path: 'company-job-drving-licenses',
    loadChildren: () =>
      import(
        './company-job-drving-licenses/company-job-drving-license/company-job-drving-license.module'
      ).then(m => m.CompanyJobDrvingLicenseModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {})],
  exports: [RouterModule],
})
export class AppRoutingModule {}
