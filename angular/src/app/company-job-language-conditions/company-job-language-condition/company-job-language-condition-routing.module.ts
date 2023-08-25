import { AuthGuard, PermissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CompanyJobLanguageConditionComponent } from './components/company-job-language-condition.component';

const routes: Routes = [
  {
    path: '',
    component: CompanyJobLanguageConditionComponent,
    canActivate: [AuthGuard, PermissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CompanyJobLanguageConditionRoutingModule {}
