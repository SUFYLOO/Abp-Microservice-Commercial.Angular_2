import { AuthGuard, PermissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CompanyJobOrganizationUnitComponent } from './components/company-job-organization-unit.component';

const routes: Routes = [
  {
    path: '',
    component: CompanyJobOrganizationUnitComponent,
    canActivate: [AuthGuard, PermissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CompanyJobOrganizationUnitRoutingModule {}
