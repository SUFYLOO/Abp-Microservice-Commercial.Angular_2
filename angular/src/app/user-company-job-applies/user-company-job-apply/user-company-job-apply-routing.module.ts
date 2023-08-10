import { AuthGuard, PermissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserCompanyJobApplyComponent } from './components/user-company-job-apply.component';

const routes: Routes = [
  {
    path: '',
    component: UserCompanyJobApplyComponent,
    canActivate: [AuthGuard, PermissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class UserCompanyJobApplyRoutingModule {}
