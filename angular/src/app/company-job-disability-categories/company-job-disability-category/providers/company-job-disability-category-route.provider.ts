import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const COMPANY_JOB_DISABILITY_CATEGORIES_COMPANY_JOB_DISABILITY_CATEGORY_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/company-job-disability-categories',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:CompanyJobDisabilityCategories',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.CompanyJobDisabilityCategories',
      },
    ]);
  };
}
