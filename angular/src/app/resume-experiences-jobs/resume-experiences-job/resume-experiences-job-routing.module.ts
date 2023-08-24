import { AuthGuard, PermissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ResumeExperiencesJobComponent } from './components/resume-experiences-job.component';

const routes: Routes = [
  {
    path: '',
    component: ResumeExperiencesJobComponent,
    canActivate: [AuthGuard, PermissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ResumeExperiencesJobRoutingModule {}
