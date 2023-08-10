import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const COMPANY_JOBS_COMPANY_JOB_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/company-jobs',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:CompanyJobs',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.CompanyJobs',
      },
    ]);
  };
}
