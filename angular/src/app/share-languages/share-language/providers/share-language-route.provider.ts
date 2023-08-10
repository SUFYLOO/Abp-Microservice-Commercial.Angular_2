import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const SHARE_LANGUAGES_SHARE_LANGUAGE_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/share-languages',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:ShareLanguages',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.ShareLanguages',
      },
    ]);
  };
}
