import { AuthGuard, PermissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ResumeEducationsComponent } from './components/resume-educations.component';

const routes: Routes = [
  {
    path: '',
    component: ResumeEducationsComponent,
    canActivate: [AuthGuard, PermissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ResumeEducationsRoutingModule {}
