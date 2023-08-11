import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const SHARE_DICTIONARYS_SHARE_DICTIONARY_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/share-dictionarys',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:ShareDictionarys',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.ShareDictionarys',
      },
    ]);
  };
}
