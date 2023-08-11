import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const RESUME_SKILLS_RESUME_SKILL_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/resume-skills',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:ResumeSkills',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.ResumeSkills',
      },
    ]);
  };
}
