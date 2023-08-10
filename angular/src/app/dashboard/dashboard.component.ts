import { Component } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  template: `
    <app-host-dashboard *abpPermission="'Resume.Dashboard.Host'"></app-host-dashboard>
    <app-tenant-dashboard *abpPermission="'Resume.Dashboard.Tenant'"></app-tenant-dashboard>
  `,
})
export class DashboardComponent {}
