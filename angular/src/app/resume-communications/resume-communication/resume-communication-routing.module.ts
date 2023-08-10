import { AuthGuard, PermissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ResumeCommunicationComponent } from './components/resume-communication.component';

const routes: Routes = [
  {
    path: '',
    component: ResumeCommunicationComponent,
    canActivate: [AuthGuard, PermissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ResumeCommunicationRoutingModule {}
