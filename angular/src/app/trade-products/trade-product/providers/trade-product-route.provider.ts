import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const TRADE_PRODUCTS_TRADE_PRODUCT_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/trade-products',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:TradeProducts',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.TradeProducts',
      },
    ]);
  };
}
