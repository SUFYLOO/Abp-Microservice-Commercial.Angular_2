import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const RESUME_DRVING_LICENSES_RESUME_DRVING_LICENSE_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/resume-drving-licenses',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:ResumeDrvingLicenses',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.ResumeDrvingLicenses',
      },
    ]);
  };
}
