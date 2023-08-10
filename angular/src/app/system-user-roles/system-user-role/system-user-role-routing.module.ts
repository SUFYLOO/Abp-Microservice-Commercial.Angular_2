import { AuthGuard, PermissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SystemUserRoleComponent } from './components/system-user-role.component';

const routes: Routes = [
  {
    path: '',
    component: SystemUserRoleComponent,
    canActivate: [AuthGuard, PermissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SystemUserRoleRoutingModule {}
