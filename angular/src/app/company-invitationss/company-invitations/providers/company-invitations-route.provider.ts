import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const COMPANY_INVITATIONSS_COMPANY_INVITATIONS_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/company-invitationss',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:CompanyInvitationss',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.CompanyInvitationss',
      },
    ]);
  };
}
