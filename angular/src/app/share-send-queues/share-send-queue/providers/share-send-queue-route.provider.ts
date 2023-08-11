import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const SHARE_SEND_QUEUES_SHARE_SEND_QUEUE_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/share-send-queues',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:ShareSendQueues',
        layout: eLayoutType.application,
        requiredPolicy: 'Resume.ShareSendQueues',
      },
    ]);
  };
}
