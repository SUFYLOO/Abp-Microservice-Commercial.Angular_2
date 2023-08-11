import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const SHARE_MESSAGE_TPLS_SHARE_MESSAGE_TPL_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/share-message-tpls',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:ShareMessageTpls',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.ShareMessageTpls',
      },
    ]);
  };
}
