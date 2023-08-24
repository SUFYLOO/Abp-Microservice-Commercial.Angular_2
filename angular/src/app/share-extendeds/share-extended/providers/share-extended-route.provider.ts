import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const SHARE_EXTENDEDS_SHARE_EXTENDED_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/share-extendeds',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:ShareExtendeds',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.ShareExtendeds',
      },
    ]);
  };
}
