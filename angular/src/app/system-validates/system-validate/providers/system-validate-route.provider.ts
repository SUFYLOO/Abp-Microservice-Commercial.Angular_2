import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const SYSTEM_VALIDATES_SYSTEM_VALIDATE_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/system-validates',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:SystemValidates',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.SystemValidates',
      },
    ]);
  };
}
