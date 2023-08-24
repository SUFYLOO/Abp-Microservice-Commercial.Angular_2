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
import { CompanyJobDisabilityCategoryComponent } from './components/company-job-disability-category.component';
import { CompanyJobDisabilityCategoryRoutingModule } from './company-job-disability-category-routing.module';

@NgModule({
  declarations: [CompanyJobDisabilityCategoryComponent],
  imports: [
    CompanyJobDisabilityCategoryRoutingModule,
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
export class CompanyJobDisabilityCategoryModule {}
