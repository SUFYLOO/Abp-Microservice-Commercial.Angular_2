import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const RESUME_EDUCATIONSS_RESUME_EDUCATIONS_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/resume-educationss',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:ResumeEducationss',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.ResumeEducationss',
      },
    ]);
  };
}
