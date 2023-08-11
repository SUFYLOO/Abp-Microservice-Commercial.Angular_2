import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const SYSTEM_TABLES_SYSTEM_TABLE_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/system-tables',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:SystemTables',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.SystemTables',
      },
    ]);
  };
}
