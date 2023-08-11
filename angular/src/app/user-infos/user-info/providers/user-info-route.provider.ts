import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const USER_INFOS_USER_INFO_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/user-infos',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:UserInfos',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.UserInfos',
      },
    ]);
  };
}
