import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const RESUME_DEPENDENTSS_RESUME_DEPENDENTS_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/resume-dependentss',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:ResumeDependentss',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.ResumeDependentss',
      },
    ]);
  };
}
