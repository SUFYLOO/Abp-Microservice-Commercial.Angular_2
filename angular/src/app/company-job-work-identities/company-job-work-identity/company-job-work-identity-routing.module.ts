import { AuthGuard, PermissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CompanyJobWorkIdentityComponent } from './components/company-job-work-identity.component';

const routes: Routes = [
  {
    path: '',
    component: CompanyJobWorkIdentityComponent,
    canActivate: [AuthGuard, PermissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CompanyJobWorkIdentityRoutingModule {}
