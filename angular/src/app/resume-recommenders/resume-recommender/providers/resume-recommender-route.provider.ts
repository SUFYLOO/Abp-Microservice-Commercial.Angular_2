import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const RESUME_RECOMMENDERS_RESUME_RECOMMENDER_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/resume-recommenders',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:ResumeRecommenders',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.ResumeRecommenders',
      },
    ]);
  };
}
