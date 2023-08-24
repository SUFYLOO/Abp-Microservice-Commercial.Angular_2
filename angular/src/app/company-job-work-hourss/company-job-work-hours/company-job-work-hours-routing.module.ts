import { AuthGuard, PermissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CompanyJobWorkHoursComponent } from './components/company-job-work-hours.component';

const routes: Routes = [
  {
    path: '',
    component: CompanyJobWorkHoursComponent,
    canActivate: [AuthGuard, PermissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CompanyJobWorkHoursRoutingModule {}
