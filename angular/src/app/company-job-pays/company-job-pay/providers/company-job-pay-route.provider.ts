import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const COMPANY_JOB_PAYS_COMPANY_JOB_PAY_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/company-job-pays',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:CompanyJobPays',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.CompanyJobPays',
      },
    ]);
  };
}
