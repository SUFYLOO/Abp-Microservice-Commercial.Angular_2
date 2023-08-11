import { AuthGuard, PermissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShareMessageTplComponent } from './components/share-message-tpl.component';

const routes: Routes = [
  {
    path: '',
    component: ShareMessageTplComponent,
    canActivate: [AuthGuard, PermissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ShareMessageTplRoutingModule {}
