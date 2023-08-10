import type { GetSystemColumnsInput, SystemColumnCreateDto, SystemColumnDto, SystemColumnExcelDownloadDto, SystemColumnUpdateDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class SystemColumnService {
  apiName = 'Default';
  

  create = (input: SystemColumnCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, SystemColumnDto>({
      method: 'POST',
      url: '/api/app/system-columns',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/system-columns/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, SystemColumnDto>({
      method: 'GET',
      url: `/api/app/system-columns/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/system-columns/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetSystemColumnsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<SystemColumnDto>>({
      method: 'GET',
      url: '/api/app/system-columns',
      params: { filterText: input.filterText, systemTableId: input.systemTableId, name: input.name, isKey: input.isKey, isSensitive: input.isSensitive, needMask: input.needMask, defaultValue: input.defaultValue, checkCode: input.checkCode, related: input.related, allowUpdate: input.allowUpdate, allowNull: input.allowNull, allowEmpty: input.allowEmpty, allowExport: input.allowExport, allowSort: input.allowSort, columnTypeCode: input.columnTypeCode, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: SystemColumnExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/system-columns/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: SystemColumnUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, SystemColumnDto>({
      method: 'PUT',
      url: `/api/app/system-columns/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
