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
import { CompanyJobApplicationMethodComponent } from './components/company-job-application-method.component';
import { CompanyJobApplicationMethodRoutingModule } from './company-job-application-method-routing.module';

@NgModule({
  declarations: [CompanyJobApplicationMethodComponent],
  imports: [
    CompanyJobApplicationMethodRoutingModule,
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
export class CompanyJobApplicationMethodModule {}
