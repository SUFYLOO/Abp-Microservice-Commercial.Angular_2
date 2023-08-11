import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const COMPANY_JOB_CONDITIONS_COMPANY_JOB_CONDITION_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/company-job-conditions',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:CompanyJobConditions',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.CompanyJobConditions',
      },
    ]);
  };
}
