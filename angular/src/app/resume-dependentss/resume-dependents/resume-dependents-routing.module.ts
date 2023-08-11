import { AuthGuard, PermissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ResumeDependentsComponent } from './components/resume-dependents.component';

const routes: Routes = [
  {
    path: '',
    component: ResumeDependentsComponent,
    canActivate: [AuthGuard, PermissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ResumeDependentsRoutingModule {}
