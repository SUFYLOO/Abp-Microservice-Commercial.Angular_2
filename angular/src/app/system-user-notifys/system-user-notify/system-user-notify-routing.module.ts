import { AuthGuard, PermissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SystemUserNotifyComponent } from './components/system-user-notify.component';

const routes: Routes = [
  {
    path: '',
    component: SystemUserNotifyComponent,
    canActivate: [AuthGuard, PermissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SystemUserNotifyRoutingModule {}
