import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const USER_VERIFYS_USER_VERIFY_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/user-verifys',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:UserVerifys',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.UserVerifys',
      },
    ]);
  };
}
