import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const SHARE_UPLOADS_SHARE_UPLOAD_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/share-uploads',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:ShareUploads',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.ShareUploads',
      },
    ]);
  };
}
