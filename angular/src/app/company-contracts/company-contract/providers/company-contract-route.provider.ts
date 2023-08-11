import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const COMPANY_CONTRACTS_COMPANY_CONTRACT_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/company-contracts',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:CompanyContracts',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.CompanyContracts',
      },
    ]);
  };
}
