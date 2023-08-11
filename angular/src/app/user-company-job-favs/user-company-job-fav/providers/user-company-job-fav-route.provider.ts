import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const USER_COMPANY_JOB_FAVS_USER_COMPANY_JOB_FAV_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/user-company-job-favs',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:UserCompanyJobFavs',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.UserCompanyJobFavs',
      },
    ]);
  };
}
