import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const COMPANY_JOB_WORK_HOURSS_COMPANY_JOB_WORK_HOURS_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/company-job-work-hourss',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:CompanyJobWorkHourss',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.CompanyJobWorkHourss',
      },
    ]);
  };
}
