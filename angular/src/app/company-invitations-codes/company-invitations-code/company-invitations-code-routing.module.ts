import { AuthGuard, PermissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CompanyInvitationsCodeComponent } from './components/company-invitations-code.component';

const routes: Routes = [
  {
    path: '',
    component: CompanyInvitationsCodeComponent,
    canActivate: [AuthGuard, PermissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CompanyInvitationsCodeRoutingModule {}
