import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const COMPANY_JOB_ORGANIZATION_UNITS_COMPANY_JOB_ORGANIZATION_UNIT_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/company-job-organization-units',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:CompanyJobOrganizationUnits',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.CompanyJobOrganizationUnits',
      },
    ]);
  };
}
