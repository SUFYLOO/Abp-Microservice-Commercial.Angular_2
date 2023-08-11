import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const COMPANY_JOB_CONTENTS_COMPANY_JOB_CONTENT_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/company-job-contents',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:CompanyJobContents',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.CompanyJobContents',
      },
    ]);
  };
}
