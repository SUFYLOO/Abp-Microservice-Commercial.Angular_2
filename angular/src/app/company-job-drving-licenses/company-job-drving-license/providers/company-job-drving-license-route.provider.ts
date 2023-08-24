import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const COMPANY_JOB_DRVING_LICENSES_COMPANY_JOB_DRVING_LICENSE_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/company-job-drving-licenses',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:CompanyJobDrvingLicenses',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.CompanyJobDrvingLicenses',
      },
    ]);
  };
}
