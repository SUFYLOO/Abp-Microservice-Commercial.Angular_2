import { AuthGuard, PermissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShareSendQueueComponent } from './components/share-send-queue.component';

const routes: Routes = [
  {
    path: '',
    component: ShareSendQueueComponent,
    canActivate: [AuthGuard, PermissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ShareSendQueueRoutingModule {}
