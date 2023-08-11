import { AuthGuard, PermissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserCompanyBindComponent } from './components/user-company-bind.component';

const routes: Routes = [
  {
    path: '',
    component: UserCompanyBindComponent,
    canActivate: [AuthGuard, PermissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class UserCompanyBindRoutingModule {}
