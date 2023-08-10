import { AuthGuard, PermissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CompanyInvitationsComponent } from './components/company-invitations.component';

const routes: Routes = [
  {
    path: '',
    component: CompanyInvitationsComponent,
    canActivate: [AuthGuard, PermissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CompanyInvitationsRoutingModule {}
