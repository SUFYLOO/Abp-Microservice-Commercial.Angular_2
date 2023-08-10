import { AuthGuard, PermissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShareDictionaryComponent } from './components/share-dictionary.component';

const routes: Routes = [
  {
    path: '',
    component: ShareDictionaryComponent,
    canActivate: [AuthGuard, PermissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ShareDictionaryRoutingModule {}
