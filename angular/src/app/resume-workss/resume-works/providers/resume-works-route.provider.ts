import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const RESUME_WORKSS_RESUME_WORKS_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/resume-workss',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:ResumeWorkss',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.ResumeWorkss',
      },
    ]);
  };
}
