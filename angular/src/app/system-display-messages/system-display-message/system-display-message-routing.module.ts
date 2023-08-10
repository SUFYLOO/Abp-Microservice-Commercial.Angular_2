import { AuthGuard, PermissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SystemDisplayMessageComponent } from './components/system-display-message.component';

const routes: Routes = [
  {
    path: '',
    component: SystemDisplayMessageComponent,
    canActivate: [AuthGuard, PermissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SystemDisplayMessageRoutingModule {}
