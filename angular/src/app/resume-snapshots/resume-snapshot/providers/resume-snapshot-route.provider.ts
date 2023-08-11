import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const RESUME_SNAPSHOTS_RESUME_SNAPSHOT_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/resume-snapshots',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:ResumeSnapshots',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.ResumeSnapshots',
      },
    ]);
  };
}
