import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const COMPANY_POINTSS_COMPANY_POINTS_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/company-pointss',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:CompanyPointss',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.CompanyPointss',
      },
    ]);
  };
}
