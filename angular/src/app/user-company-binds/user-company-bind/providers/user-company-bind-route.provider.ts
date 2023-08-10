import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const USER_COMPANY_BINDS_USER_COMPANY_BIND_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/user-company-binds',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:UserCompanyBinds',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.UserCompanyBinds',
      },
    ]);
  };
}
