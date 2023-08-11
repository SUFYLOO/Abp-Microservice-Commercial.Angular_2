import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const TRADE_ORDERS_TRADE_ORDER_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/trade-orders',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:TradeOrders',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.TradeOrders',
      },
    ]);
  };
}
