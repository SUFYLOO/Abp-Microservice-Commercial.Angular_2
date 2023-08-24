import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const COMPANY_JOB_EDUCATION_LEVELS_COMPANY_JOB_EDUCATION_LEVEL_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/company-job-education-levels',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:CompanyJobEducationLevels',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.CompanyJobEducationLevels',
      },
    ]);
  };
}
