import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const SYSTEM_PAGES_SYSTEM_PAGE_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/system-pages',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:SystemPages',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.SystemPages',
      },
    ]);
  };
}
