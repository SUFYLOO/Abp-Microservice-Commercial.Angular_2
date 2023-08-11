import type { GetShareDefaultsInput, ShareDefaultCreateDto, ShareDefaultDto, ShareDefaultExcelDownloadDto, ShareDefaultUpdateDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class ShareDefaultService {
  apiName = 'Default';
  

  create = (input: ShareDefaultCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ShareDefaultDto>({
      method: 'POST',
      url: '/api/app/share-defaults',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/share-defaults/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ShareDefaultDto>({
      method: 'GET',
      url: `/api/app/share-defaults/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/share-defaults/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetShareDefaultsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<ShareDefaultDto>>({
      method: 'GET',
      url: '/api/app/share-defaults',
      params: { filterText: input.filterText, groupCode: input.groupCode, key1: input.key1, key2: input.key2, key3: input.key3, name: input.name, fieldKey: input.fieldKey, fieldValue: input.fieldValue, columnTypeCode: input.columnTypeCode, formTypeCode: input.formTypeCode, systemUse: input.systemUse, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: ShareDefaultExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/share-defaults/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: ShareDefaultUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ShareDefaultDto>({
      method: 'PUT',
      url: `/api/app/share-defaults/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
