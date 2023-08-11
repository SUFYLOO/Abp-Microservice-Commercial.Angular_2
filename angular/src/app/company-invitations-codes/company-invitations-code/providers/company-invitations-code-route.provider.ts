import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const COMPANY_INVITATIONS_CODES_COMPANY_INVITATIONS_CODE_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/company-invitations-codes',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:CompanyInvitationsCodes',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.CompanyInvitationsCodes',
      },
    ]);
  };
}
