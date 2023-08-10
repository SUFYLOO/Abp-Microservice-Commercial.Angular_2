import { AuthGuard, PermissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserCompanyJobPairComponent } from './components/user-company-job-pair.component';

const routes: Routes = [
  {
    path: '',
    component: UserCompanyJobPairComponent,
    canActivate: [AuthGuard, PermissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class UserCompanyJobPairRoutingModule {}
