import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const SYSTEM_USER_NOTIFYS_SYSTEM_USER_NOTIFY_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/system-user-notifys',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:SystemUserNotifys',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.SystemUserNotifys',
      },
    ]);
  };
}
