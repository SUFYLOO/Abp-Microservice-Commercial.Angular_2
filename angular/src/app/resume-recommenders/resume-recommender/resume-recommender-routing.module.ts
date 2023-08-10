import { AuthGuard, PermissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ResumeRecommenderComponent } from './components/resume-recommender.component';

const routes: Routes = [
  {
    path: '',
    component: ResumeRecommenderComponent,
    canActivate: [AuthGuard, PermissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ResumeRecommenderRoutingModule {}
