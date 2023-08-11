import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const COMPANY_MAINS_COMPANY_MAIN_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/company-mains',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:CompanyMains',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.CompanyMains',
      },
    ]);
  };
}
