import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const USER_TOKENS_USER_TOKEN_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/user-tokens',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:UserTokens',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.UserTokens',
      },
    ]);
  };
}
