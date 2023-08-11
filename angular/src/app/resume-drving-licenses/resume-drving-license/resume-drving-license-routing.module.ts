import { AuthGuard, PermissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ResumeDrvingLicenseComponent } from './components/resume-drving-license.component';

const routes: Routes = [
  {
    path: '',
    component: ResumeDrvingLicenseComponent,
    canActivate: [AuthGuard, PermissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ResumeDrvingLicenseRoutingModule {}
