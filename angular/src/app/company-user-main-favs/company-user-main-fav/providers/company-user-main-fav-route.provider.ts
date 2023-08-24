import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const COMPANY_USER_MAIN_FAVS_COMPANY_USER_MAIN_FAV_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/company-user-main-favs',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:CompanyUserMainFavs',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.CompanyUserMainFavs',
      },
    ]);
  };
}
