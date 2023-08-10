import { AuthGuard, PermissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TradeOderDetailComponent } from './components/trade-oder-detail.component';

const routes: Routes = [
  {
    path: '',
    component: TradeOderDetailComponent,
    canActivate: [AuthGuard, PermissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TradeOderDetailRoutingModule {}
