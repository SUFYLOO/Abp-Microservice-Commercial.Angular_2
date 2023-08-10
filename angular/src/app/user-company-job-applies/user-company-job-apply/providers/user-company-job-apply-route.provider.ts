import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const USER_COMPANY_JOB_APPLIES_USER_COMPANY_JOB_APPLY_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/user-company-job-applies',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:UserCompanyJobApplies',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.UserCompanyJobApplies',
      },
    ]);
  };
}
