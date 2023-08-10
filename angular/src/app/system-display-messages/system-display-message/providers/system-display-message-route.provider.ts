import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const SYSTEM_DISPLAY_MESSAGES_SYSTEM_DISPLAY_MESSAGE_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/system-display-messages',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:SystemDisplayMessages',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.SystemDisplayMessages',
      },
    ]);
  };
}
