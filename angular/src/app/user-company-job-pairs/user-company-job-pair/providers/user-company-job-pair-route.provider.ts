import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const USER_COMPANY_JOB_PAIRS_USER_COMPANY_JOB_PAIR_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/user-company-job-pairs',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:UserCompanyJobPairs',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.UserCompanyJobPairs',
      },
    ]);
  };
}
