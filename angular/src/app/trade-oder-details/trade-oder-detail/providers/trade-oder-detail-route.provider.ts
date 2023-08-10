import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const TRADE_ODER_DETAILS_TRADE_ODER_DETAIL_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/trade-oder-details',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:TradeOderDetails',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.TradeOderDetails',
      },
    ]);
  };
}
