import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const SYSTEM_USER_ROLES_SYSTEM_USER_ROLE_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/system-user-roles',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:SystemUserRoles',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.SystemUserRoles',
      },
    ]);
  };
}
