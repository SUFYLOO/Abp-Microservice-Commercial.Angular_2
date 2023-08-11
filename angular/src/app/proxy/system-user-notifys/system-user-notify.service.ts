import type { GetSystemUserNotifysInput, SystemUserNotifyCreateDto, SystemUserNotifyDto, SystemUserNotifyExcelDownloadDto, SystemUserNotifyUpdateDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class SystemUserNotifyService {
  apiName = 'Default';
  

  create = (input: SystemUserNotifyCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, SystemUserNotifyDto>({
      method: 'POST',
      url: '/api/app/system-user-notifys',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/system-user-notifys/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, SystemUserNotifyDto>({
      method: 'GET',
      url: `/api/app/system-user-notifys/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/system-user-notifys/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetSystemUserNotifysInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<SystemUserNotifyDto>>({
      method: 'GET',
      url: '/api/app/system-user-notifys',
      params: { filterText: input.filterText, userMainId: input.userMainId, keyId: input.keyId, keyName: input.keyName, notifyTypeCode: input.notifyTypeCode, appName: input.appName, appCode: input.appCode, titleContents: input.titleContents, contents: input.contents, isRead: input.isRead, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: SystemUserNotifyExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/system-user-notifys/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: SystemUserNotifyUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, SystemUserNotifyDto>({
      method: 'PUT',
      url: `/api/app/system-user-notifys/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
