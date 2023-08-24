import { CoreModule } from '@abp/ng.core';
import { GdprConfigModule } from '@volo/abp.ng.gdpr/config';
import { SettingManagementConfigModule } from '@abp/ng.setting-management/config';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CommercialUiConfigModule } from '@volo/abp.commercial.ng.ui/config';
import { AccountAdminConfigModule } from '@volo/abp.ng.account/admin/config';
import { AccountPublicConfigModule } from '@volo/abp.ng.account/public/config';
import { AuditLoggingConfigModule } from '@volo/abp.ng.audit-logging/config';
import { IdentityConfigModule } from '@volo/abp.ng.identity/config';
import { LanguageManagementConfigModule } from '@volo/abp.ng.language-management/config';
import { registerLocale } from '@volo/abp.ng.language-management/locale';
import { SaasConfigModule } from '@volo/abp.ng.saas/config';
import { TextTemplateManagementConfigModule } from '@volo/abp.ng.text-template-management/config';
import { HttpErrorComponent, ThemeLeptonXModule } from '@volosoft/abp.ng.theme.lepton-x';
import { SideMenuLayoutModule } from '@volosoft/abp.ng.theme.lepton-x/layouts';
import { environment } from '../environments/environment';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { APP_ROUTE_PROVIDER } from './route.provider';
import { OpeniddictproConfigModule } from '@volo/abp.ng.openiddictpro/config';
import { FeatureManagementModule } from '@abp/ng.feature-management';
import { AbpOAuthModule } from '@abp/ng.oauth';
import { AccountLayoutModule } from '@volosoft/abp.ng.theme.lepton-x/account';
import { COMPANY_CONTRACTS_COMPANY_CONTRACT_ROUTE_PROVIDER } from './company-contracts/company-contract/providers/company-contract-route.provider';
import { COMPANY_INVITATIONSS_COMPANY_INVITATIONS_ROUTE_PROVIDER } from './company-invitationss/company-invitations/providers/company-invitations-route.provider';
import { COMPANY_INVITATIONS_CODES_COMPANY_INVITATIONS_CODE_ROUTE_PROVIDER } from './company-invitations-codes/company-invitations-code/providers/company-invitations-code-route.provider';
import { COMPANY_JOBS_COMPANY_JOB_ROUTE_PROVIDER } from './company-jobs/company-job/providers/company-job-route.provider';
import { COMPANY_JOB_APPLICATION_METHODS_COMPANY_JOB_APPLICATION_METHOD_ROUTE_PROVIDER } from './company-job-application-methods/company-job-application-method/providers/company-job-application-method-route.provider';
import { COMPANY_JOB_CONDITIONS_COMPANY_JOB_CONDITION_ROUTE_PROVIDER } from './company-job-conditions/company-job-condition/providers/company-job-condition-route.provider';
import { COMPANY_JOB_CONTENTS_COMPANY_JOB_CONTENT_ROUTE_PROVIDER } from './company-job-contents/company-job-content/providers/company-job-content-route.provider';
import { COMPANY_JOB_PAIRS_COMPANY_JOB_PAIR_ROUTE_PROVIDER } from './company-job-pairs/company-job-pair/providers/company-job-pair-route.provider';
import { COMPANY_JOB_PAYS_COMPANY_JOB_PAY_ROUTE_PROVIDER } from './company-job-pays/company-job-pay/providers/company-job-pay-route.provider';
import { COMPANY_MAINS_COMPANY_MAIN_ROUTE_PROVIDER } from './company-mains/company-main/providers/company-main-route.provider';
import { COMPANY_POINTSS_COMPANY_POINTS_ROUTE_PROVIDER } from './company-pointss/company-points/providers/company-points-route.provider';
import { COMPANY_USERS_COMPANY_USER_ROUTE_PROVIDER } from './company-users/company-user/providers/company-user-route.provider';
import { RESUME_COMMUNICATIONS_RESUME_COMMUNICATION_ROUTE_PROVIDER } from './resume-communications/resume-communication/providers/resume-communication-route.provider';
import { RESUME_DEPENDENTSS_RESUME_DEPENDENTS_ROUTE_PROVIDER } from './resume-dependentss/resume-dependents/providers/resume-dependents-route.provider';
import { RESUME_DRVING_LICENSES_RESUME_DRVING_LICENSE_ROUTE_PROVIDER } from './resume-drving-licenses/resume-drving-license/providers/resume-drving-license-route.provider';
import { RESUME_EDUCATIONSS_RESUME_EDUCATIONS_ROUTE_PROVIDER } from './resume-educationss/resume-educations/providers/resume-educations-route.provider';
import { RESUME_EXPERIENCESS_RESUME_EXPERIENCES_ROUTE_PROVIDER } from './resume-experiencess/resume-experiences/providers/resume-experiences-route.provider';
import { RESUME_LANGUAGES_RESUME_LANGUAGE_ROUTE_PROVIDER } from './resume-languages/resume-language/providers/resume-language-route.provider';
import { RESUME_MAINS_RESUME_MAIN_ROUTE_PROVIDER } from './resume-mains/resume-main/providers/resume-main-route.provider';
import { RESUME_RECOMMENDERS_RESUME_RECOMMENDER_ROUTE_PROVIDER } from './resume-recommenders/resume-recommender/providers/resume-recommender-route.provider';
import { RESUME_SKILLS_RESUME_SKILL_ROUTE_PROVIDER } from './resume-skills/resume-skill/providers/resume-skill-route.provider';
import { RESUME_SNAPSHOTS_RESUME_SNAPSHOT_ROUTE_PROVIDER } from './resume-snapshots/resume-snapshot/providers/resume-snapshot-route.provider';
import { RESUME_WORKSS_RESUME_WORKS_ROUTE_PROVIDER } from './resume-workss/resume-works/providers/resume-works-route.provider';
import { SHARE_CODES_SHARE_CODE_ROUTE_PROVIDER } from './share-codes/share-code/providers/share-code-route.provider';
import { SHARE_DEFAULTS_SHARE_DEFAULT_ROUTE_PROVIDER } from './share-defaults/share-default/providers/share-default-route.provider';
import { SHARE_DICTIONARYS_SHARE_DICTIONARY_ROUTE_PROVIDER } from './share-dictionarys/share-dictionary/providers/share-dictionary-route.provider';
import { SHARE_LANGUAGES_SHARE_LANGUAGE_ROUTE_PROVIDER } from './share-languages/share-language/providers/share-language-route.provider';
import { SHARE_MESSAGE_TPLS_SHARE_MESSAGE_TPL_ROUTE_PROVIDER } from './share-message-tpls/share-message-tpl/providers/share-message-tpl-route.provider';
import { SHARE_SEND_QUEUES_SHARE_SEND_QUEUE_ROUTE_PROVIDER } from './share-send-queues/share-send-queue/providers/share-send-queue-route.provider';
import { SHARE_TAGS_SHARE_TAG_ROUTE_PROVIDER } from './share-tags/share-tag/providers/share-tag-route.provider';
import { SHARE_UPLOADS_SHARE_UPLOAD_ROUTE_PROVIDER } from './share-uploads/share-upload/providers/share-upload-route.provider';
import { SYSTEM_COLUMNS_SYSTEM_COLUMN_ROUTE_PROVIDER } from './system-columns/system-column/providers/system-column-route.provider';
import { SYSTEM_DISPLAY_MESSAGES_SYSTEM_DISPLAY_MESSAGE_ROUTE_PROVIDER } from './system-display-messages/system-display-message/providers/system-display-message-route.provider';
import { SYSTEM_PAGES_SYSTEM_PAGE_ROUTE_PROVIDER } from './system-pages/system-page/providers/system-page-route.provider';
import { SYSTEM_TABLES_SYSTEM_TABLE_ROUTE_PROVIDER } from './system-tables/system-table/providers/system-table-route.provider';
import { SYSTEM_USER_NOTIFYS_SYSTEM_USER_NOTIFY_ROUTE_PROVIDER } from './system-user-notifys/system-user-notify/providers/system-user-notify-route.provider';
import { SYSTEM_USER_ROLES_SYSTEM_USER_ROLE_ROUTE_PROVIDER } from './system-user-roles/system-user-role/providers/system-user-role-route.provider';
import { SYSTEM_VALIDATES_SYSTEM_VALIDATE_ROUTE_PROVIDER } from './system-validates/system-validate/providers/system-validate-route.provider';
import { TRADE_ODER_DETAILS_TRADE_ODER_DETAIL_ROUTE_PROVIDER } from './trade-oder-details/trade-oder-detail/providers/trade-oder-detail-route.provider';
import { TRADE_ORDERS_TRADE_ORDER_ROUTE_PROVIDER } from './trade-orders/trade-order/providers/trade-order-route.provider';
import { TRADE_PRODUCTS_TRADE_PRODUCT_ROUTE_PROVIDER } from './trade-products/trade-product/providers/trade-product-route.provider';
import { USER_ACCOUNT_BINDS_USER_ACCOUNT_BIND_ROUTE_PROVIDER } from './user-account-binds/user-account-bind/providers/user-account-bind-route.provider';
import { USER_COMPANY_BINDS_USER_COMPANY_BIND_ROUTE_PROVIDER } from './user-company-binds/user-company-bind/providers/user-company-bind-route.provider';
import { USER_COMPANY_JOB_APPLIES_USER_COMPANY_JOB_APPLY_ROUTE_PROVIDER } from './user-company-job-applies/user-company-job-apply/providers/user-company-job-apply-route.provider';
import { USER_COMPANY_JOB_FAVS_USER_COMPANY_JOB_FAV_ROUTE_PROVIDER } from './user-company-job-favs/user-company-job-fav/providers/user-company-job-fav-route.provider';
import { USER_COMPANY_JOB_PAIRS_USER_COMPANY_JOB_PAIR_ROUTE_PROVIDER } from './user-company-job-pairs/user-company-job-pair/providers/user-company-job-pair-route.provider';
import { USER_INFOS_USER_INFO_ROUTE_PROVIDER } from './user-infos/user-info/providers/user-info-route.provider';
import { USER_MAINS_USER_MAIN_ROUTE_PROVIDER } from './user-mains/user-main/providers/user-main-route.provider';
import { USER_TOKENS_USER_TOKEN_ROUTE_PROVIDER } from './user-tokens/user-token/providers/user-token-route.provider';
import { USER_VERIFYS_USER_VERIFY_ROUTE_PROVIDER } from './user-verifys/user-verify/providers/user-verify-route.provider';
import { COMPANY_JOB_ORGANIZATION_UNITS_COMPANY_JOB_ORGANIZATION_UNIT_ROUTE_PROVIDER } from './company-job-organization-units/company-job-organization-unit/providers/company-job-organization-unit-route.provider';
import { SHARE_EXTENDEDS_SHARE_EXTENDED_ROUTE_PROVIDER } from './share-extendeds/share-extended/providers/share-extended-route.provider';
import { RESUME_EXPERIENCES_JOBS_RESUME_EXPERIENCES_JOB_ROUTE_PROVIDER } from './resume-experiences-jobs/resume-experiences-job/providers/resume-experiences-job-route.provider';
import { COMPANY_USER_MAIN_FAVS_COMPANY_USER_MAIN_FAV_ROUTE_PROVIDER } from './company-user-main-favs/company-user-main-fav/providers/company-user-main-fav-route.provider';
import { COMPANY_JOB_WORK_IDENTITIES_COMPANY_JOB_WORK_IDENTITY_ROUTE_PROVIDER } from './company-job-work-identities/company-job-work-identity/providers/company-job-work-identity-route.provider';
import { COMPANY_JOB_DISABILITY_CATEGORIES_COMPANY_JOB_DISABILITY_CATEGORY_ROUTE_PROVIDER } from './company-job-disability-categories/company-job-disability-category/providers/company-job-disability-category-route.provider';
import { COMPANY_JOB_EDUCATION_LEVELS_COMPANY_JOB_EDUCATION_LEVEL_ROUTE_PROVIDER } from './company-job-education-levels/company-job-education-level/providers/company-job-education-level-route.provider';
import { COMPANY_JOB_DRVING_LICENSES_COMPANY_JOB_DRVING_LICENSE_ROUTE_PROVIDER } from './company-job-drving-licenses/company-job-drving-license/providers/company-job-drving-license-route.provider';
@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    CoreModule.forRoot({
      environment,
      registerLocaleFn: registerLocale(),
    }),
    AbpOAuthModule.forRoot(),
    ThemeSharedModule.forRoot({
      httpErrorConfig: {
        errorScreen: {
          component: HttpErrorComponent,
          forWhichErrors: [401, 403, 404, 500],
          hideCloseIcon: true,
        },
      },
    }),
    AccountAdminConfigModule.forRoot(),
    AccountPublicConfigModule.forRoot(),
    AccountLayoutModule.forRoot(),
    IdentityConfigModule.forRoot(),
    LanguageManagementConfigModule.forRoot(),
    SaasConfigModule.forRoot(),
    AuditLoggingConfigModule.forRoot(),
    OpeniddictproConfigModule.forRoot(),
    TextTemplateManagementConfigModule.forRoot(),
    SettingManagementConfigModule.forRoot(),
    ThemeLeptonXModule.forRoot(),
    SideMenuLayoutModule.forRoot(),
    CommercialUiConfigModule.forRoot(),
    FeatureManagementModule.forRoot(),
    GdprConfigModule.forRoot({
      cookieConsent: {
        privacyPolicyUrl: 'gdpr-cookie-consent/privacy',
        cookiePolicyUrl: 'gdpr-cookie-consent/cookie',
      },
    }),
  ],
  providers: [
    APP_ROUTE_PROVIDER,
    COMPANY_CONTRACTS_COMPANY_CONTRACT_ROUTE_PROVIDER,
    COMPANY_INVITATIONSS_COMPANY_INVITATIONS_ROUTE_PROVIDER,
    COMPANY_INVITATIONS_CODES_COMPANY_INVITATIONS_CODE_ROUTE_PROVIDER,
    COMPANY_JOBS_COMPANY_JOB_ROUTE_PROVIDER,
    COMPANY_JOB_APPLICATION_METHODS_COMPANY_JOB_APPLICATION_METHOD_ROUTE_PROVIDER,
    COMPANY_JOB_CONDITIONS_COMPANY_JOB_CONDITION_ROUTE_PROVIDER,
    COMPANY_JOB_CONTENTS_COMPANY_JOB_CONTENT_ROUTE_PROVIDER,
    COMPANY_JOB_PAIRS_COMPANY_JOB_PAIR_ROUTE_PROVIDER,
    COMPANY_JOB_PAYS_COMPANY_JOB_PAY_ROUTE_PROVIDER,
    COMPANY_MAINS_COMPANY_MAIN_ROUTE_PROVIDER,
    COMPANY_POINTSS_COMPANY_POINTS_ROUTE_PROVIDER,
    COMPANY_USERS_COMPANY_USER_ROUTE_PROVIDER,
    RESUME_COMMUNICATIONS_RESUME_COMMUNICATION_ROUTE_PROVIDER,
    RESUME_DEPENDENTSS_RESUME_DEPENDENTS_ROUTE_PROVIDER,
    RESUME_DRVING_LICENSES_RESUME_DRVING_LICENSE_ROUTE_PROVIDER,
    RESUME_EDUCATIONSS_RESUME_EDUCATIONS_ROUTE_PROVIDER,
    RESUME_EXPERIENCESS_RESUME_EXPERIENCES_ROUTE_PROVIDER,
    RESUME_LANGUAGES_RESUME_LANGUAGE_ROUTE_PROVIDER,
    RESUME_MAINS_RESUME_MAIN_ROUTE_PROVIDER,
    RESUME_RECOMMENDERS_RESUME_RECOMMENDER_ROUTE_PROVIDER,
    RESUME_SKILLS_RESUME_SKILL_ROUTE_PROVIDER,
    RESUME_SNAPSHOTS_RESUME_SNAPSHOT_ROUTE_PROVIDER,
    RESUME_WORKSS_RESUME_WORKS_ROUTE_PROVIDER,
    SHARE_CODES_SHARE_CODE_ROUTE_PROVIDER,
    SHARE_DEFAULTS_SHARE_DEFAULT_ROUTE_PROVIDER,
    SHARE_DICTIONARYS_SHARE_DICTIONARY_ROUTE_PROVIDER,
    SHARE_LANGUAGES_SHARE_LANGUAGE_ROUTE_PROVIDER,
    SHARE_MESSAGE_TPLS_SHARE_MESSAGE_TPL_ROUTE_PROVIDER,
    SHARE_SEND_QUEUES_SHARE_SEND_QUEUE_ROUTE_PROVIDER,
    SHARE_TAGS_SHARE_TAG_ROUTE_PROVIDER,
    SHARE_UPLOADS_SHARE_UPLOAD_ROUTE_PROVIDER,
    SYSTEM_COLUMNS_SYSTEM_COLUMN_ROUTE_PROVIDER,
    SYSTEM_DISPLAY_MESSAGES_SYSTEM_DISPLAY_MESSAGE_ROUTE_PROVIDER,
    SYSTEM_PAGES_SYSTEM_PAGE_ROUTE_PROVIDER,
    SYSTEM_TABLES_SYSTEM_TABLE_ROUTE_PROVIDER,
    SYSTEM_USER_NOTIFYS_SYSTEM_USER_NOTIFY_ROUTE_PROVIDER,
    SYSTEM_USER_ROLES_SYSTEM_USER_ROLE_ROUTE_PROVIDER,
    SYSTEM_VALIDATES_SYSTEM_VALIDATE_ROUTE_PROVIDER,
    TRADE_ODER_DETAILS_TRADE_ODER_DETAIL_ROUTE_PROVIDER,
    TRADE_ORDERS_TRADE_ORDER_ROUTE_PROVIDER,
    TRADE_PRODUCTS_TRADE_PRODUCT_ROUTE_PROVIDER,
    USER_ACCOUNT_BINDS_USER_ACCOUNT_BIND_ROUTE_PROVIDER,
    USER_COMPANY_BINDS_USER_COMPANY_BIND_ROUTE_PROVIDER,
    USER_COMPANY_JOB_APPLIES_USER_COMPANY_JOB_APPLY_ROUTE_PROVIDER,
    USER_COMPANY_JOB_FAVS_USER_COMPANY_JOB_FAV_ROUTE_PROVIDER,
    USER_COMPANY_JOB_PAIRS_USER_COMPANY_JOB_PAIR_ROUTE_PROVIDER,
    USER_INFOS_USER_INFO_ROUTE_PROVIDER,
    USER_MAINS_USER_MAIN_ROUTE_PROVIDER,
    USER_TOKENS_USER_TOKEN_ROUTE_PROVIDER,
    USER_VERIFYS_USER_VERIFY_ROUTE_PROVIDER,
    COMPANY_JOB_ORGANIZATION_UNITS_COMPANY_JOB_ORGANIZATION_UNIT_ROUTE_PROVIDER,
    SHARE_EXTENDEDS_SHARE_EXTENDED_ROUTE_PROVIDER,
    RESUME_EXPERIENCES_JOBS_RESUME_EXPERIENCES_JOB_ROUTE_PROVIDER,
    COMPANY_USER_MAIN_FAVS_COMPANY_USER_MAIN_FAV_ROUTE_PROVIDER,
    COMPANY_JOB_WORK_IDENTITIES_COMPANY_JOB_WORK_IDENTITY_ROUTE_PROVIDER,
    COMPANY_JOB_DISABILITY_CATEGORIES_COMPANY_JOB_DISABILITY_CATEGORY_ROUTE_PROVIDER,
    COMPANY_JOB_EDUCATION_LEVELS_COMPANY_JOB_EDUCATION_LEVEL_ROUTE_PROVIDER,
    COMPANY_JOB_DRVING_LICENSES_COMPANY_JOB_DRVING_LICENSE_ROUTE_PROVIDER,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
