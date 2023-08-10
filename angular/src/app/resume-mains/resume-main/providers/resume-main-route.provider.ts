import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const RESUME_MAINS_RESUME_MAIN_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/resume-mains',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:ResumeMains',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.ResumeMains',
      },
    ]);
  };
}
