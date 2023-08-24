import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const RESUME_EXPERIENCES_JOBS_RESUME_EXPERIENCES_JOB_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/resume-experiences-jobs',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:ResumeExperiencesJobs',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.ResumeExperiencesJobs',
      },
    ]);
  };
}
