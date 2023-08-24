import { AuthGuard, PermissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CompanyJobDisabilityCategoryComponent } from './components/company-job-disability-category.component';

const routes: Routes = [
  {
    path: '',
    component: CompanyJobDisabilityCategoryComponent,
    canActivate: [AuthGuard, PermissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CompanyJobDisabilityCategoryRoutingModule {}
