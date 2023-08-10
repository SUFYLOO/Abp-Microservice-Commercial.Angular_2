import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const USER_MAINS_USER_MAIN_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/user-mains',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:UserMains',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.UserMains',
      },
    ]);
  };
}
