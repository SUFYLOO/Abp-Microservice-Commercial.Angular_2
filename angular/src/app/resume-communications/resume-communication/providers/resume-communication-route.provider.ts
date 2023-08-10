import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const RESUME_COMMUNICATIONS_RESUME_COMMUNICATION_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/resume-communications',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:ResumeCommunications',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.ResumeCommunications',
      },
    ]);
  };
}
