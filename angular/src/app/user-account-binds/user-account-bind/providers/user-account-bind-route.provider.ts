import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const USER_ACCOUNT_BINDS_USER_ACCOUNT_BIND_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/user-account-binds',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:UserAccountBinds',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.UserAccountBinds',
      },
    ]);
  };
}
