import { AuthGuard, PermissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserCompanyJobFavComponent } from './components/user-company-job-fav.component';

const routes: Routes = [
  {
    path: '',
    component: UserCompanyJobFavComponent,
    canActivate: [AuthGuard, PermissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class UserCompanyJobFavRoutingModule {}
