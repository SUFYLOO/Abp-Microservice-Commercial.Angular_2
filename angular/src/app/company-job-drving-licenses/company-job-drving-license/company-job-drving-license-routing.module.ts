import { AuthGuard, PermissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CompanyJobDrvingLicenseComponent } from './components/company-job-drving-license.component';

const routes: Routes = [
  {
    path: '',
    component: CompanyJobDrvingLicenseComponent,
    canActivate: [AuthGuard, PermissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CompanyJobDrvingLicenseRoutingModule {}
