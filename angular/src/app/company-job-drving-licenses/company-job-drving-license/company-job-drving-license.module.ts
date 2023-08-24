import { CoreModule } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { NgModule } from '@angular/core';
import {
  NgbCollapseModule,
  NgbDatepickerModule,
  NgbDropdownModule,
} from '@ng-bootstrap/ng-bootstrap';
import { NgxValidateCoreModule } from '@ngx-validate/core';
import { CommercialUiModule } from '@volo/abp.commercial.ng.ui';
import { PageModule } from '@abp/ng.components/page';
import { CompanyJobDrvingLicenseComponent } from './components/company-job-drving-license.component';
import { CompanyJobDrvingLicenseRoutingModule } from './company-job-drving-license-routing.module';

@NgModule({
  declarations: [CompanyJobDrvingLicenseComponent],
  imports: [
    CompanyJobDrvingLicenseRoutingModule,
    CoreModule,
    ThemeSharedModule,
    CommercialUiModule,
    NgxValidateCoreModule,
    NgbCollapseModule,
    NgbDatepickerModule,
    NgbDropdownModule,

    PageModule,
  ],
})
export class CompanyJobDrvingLicenseModule {}
