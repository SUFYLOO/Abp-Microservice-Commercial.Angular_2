import { AuthGuard, PermissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CompanyJobApplicationMethodComponent } from './components/company-job-application-method.component';

const routes: Routes = [
  {
    path: '',
    component: CompanyJobApplicationMethodComponent,
    canActivate: [AuthGuard, PermissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CompanyJobApplicationMethodRoutingModule {}
