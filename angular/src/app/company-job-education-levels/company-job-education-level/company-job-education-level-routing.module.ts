import { AuthGuard, PermissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CompanyJobEducationLevelComponent } from './components/company-job-education-level.component';

const routes: Routes = [
  {
    path: '',
    component: CompanyJobEducationLevelComponent,
    canActivate: [AuthGuard, PermissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CompanyJobEducationLevelRoutingModule {}
