import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const SHARE_DEFAULTS_SHARE_DEFAULT_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/share-defaults',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:ShareDefaults',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.ShareDefaults',
      },
    ]);
  };
}
