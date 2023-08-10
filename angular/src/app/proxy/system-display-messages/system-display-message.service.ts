import type { GetSystemDisplayMessagesInput, SystemDisplayMessageCreateDto, SystemDisplayMessageDto, SystemDisplayMessageExcelDownloadDto, SystemDisplayMessageUpdateDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class SystemDisplayMessageService {
  apiName = 'Default';
  

  create = (input: SystemDisplayMessageCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, SystemDisplayMessageDto>({
      method: 'POST',
      url: '/api/app/system-display-messages',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/system-display-messages/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, SystemDisplayMessageDto>({
      method: 'GET',
      url: `/api/app/system-display-messages/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/system-display-messages/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetSystemDisplayMessagesInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<SystemDisplayMessageDto>>({
      method: 'GET',
      url: '/api/app/system-display-messages',
      params: { filterText: input.filterText, displayTypeCode: input.displayTypeCode, titleContents: input.titleContents, contents: input.contents, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: SystemDisplayMessageExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/system-display-messages/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: SystemDisplayMessageUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, SystemDisplayMessageDto>({
      method: 'PUT',
      url: `/api/app/system-display-messages/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
