import { AuthGuard, PermissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ResumeExperiencesComponent } from './components/resume-experiences.component';

const routes: Routes = [
  {
    path: '',
    component: ResumeExperiencesComponent,
    canActivate: [AuthGuard, PermissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ResumeExperiencesRoutingModule {}
