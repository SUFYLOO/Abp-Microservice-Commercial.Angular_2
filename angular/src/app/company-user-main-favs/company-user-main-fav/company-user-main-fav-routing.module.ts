import { AuthGuard, PermissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CompanyUserMainFavComponent } from './components/company-user-main-fav.component';

const routes: Routes = [
  {
    path: '',
    component: CompanyUserMainFavComponent,
    canActivate: [AuthGuard, PermissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CompanyUserMainFavRoutingModule {}
