import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const SHARE_CODES_SHARE_CODE_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/share-codes',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:ShareCodes',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.ShareCodes',
      },
    ]);
  };
}
