import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const RESUME_LANGUAGES_RESUME_LANGUAGE_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/resume-languages',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:ResumeLanguages',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.ResumeLanguages',
      },
    ]);
  };
}
