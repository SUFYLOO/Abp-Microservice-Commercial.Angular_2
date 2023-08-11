import type { GetShareCodesInput, ShareCodeCreateDto, ShareCodeDto, ShareCodeExcelDownloadDto, ShareCodeUpdateDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class ShareCodeService {
  apiName = 'Default';
  

  create = (input: ShareCodeCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ShareCodeDto>({
      method: 'POST',
      url: '/api/app/share-codes',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/share-codes/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ShareCodeDto>({
      method: 'GET',
      url: `/api/app/share-codes/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/share-codes/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetShareCodesInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<ShareCodeDto>>({
      method: 'GET',
      url: '/api/app/share-codes',
      params: { filterText: input.filterText, groupCode: input.groupCode, key1: input.key1, key2: input.key2, key3: input.key3, name: input.name, column1: input.column1, column2: input.column2, column3: input.column3, systemUse: input.systemUse, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: ShareCodeExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/share-codes/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: ShareCodeUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ShareCodeDto>({
      method: 'PUT',
      url: `/api/app/share-codes/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
