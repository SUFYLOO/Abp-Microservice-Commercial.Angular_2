import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const COMPANY_USERS_COMPANY_USER_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/company-users',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:CompanyUsers',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.CompanyUsers',
      },
    ]);
  };
}
