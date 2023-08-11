import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const SHARE_TAGS_SHARE_TAG_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/share-tags',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:ShareTags',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.ShareTags',
      },
    ]);
  };
}
