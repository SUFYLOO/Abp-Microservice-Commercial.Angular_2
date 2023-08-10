import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const SYSTEM_COLUMNS_SYSTEM_COLUMN_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/system-columns',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:SystemColumns',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.SystemColumns',
      },
    ]);
  };
}
