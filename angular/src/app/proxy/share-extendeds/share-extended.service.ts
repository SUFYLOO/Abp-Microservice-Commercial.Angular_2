import type { GetShareExtendedsInput, ShareExtendedCreateDto, ShareExtendedDto, ShareExtendedExcelDownloadDto, ShareExtendedUpdateDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class ShareExtendedService {
  apiName = 'Default';
  

  create = (input: ShareExtendedCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ShareExtendedDto>({
      method: 'POST',
      url: '/api/app/share-extendeds',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/share-extendeds/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ShareExtendedDto>({
      method: 'GET',
      url: `/api/app/share-extendeds/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/share-extendeds/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetShareExtendedsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<ShareExtendedDto>>({
      method: 'GET',
      url: '/api/app/share-extendeds',
      params: { filterText: input.filterText, key1: input.key1, key2: input.key2, key3: input.key3, key4: input.key4, key5: input.key5, keyId: input.keyId, fieldValue: input.fieldValue, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: ShareExtendedExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/share-extendeds/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: ShareExtendedUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ShareExtendedDto>({
      method: 'PUT',
      url: `/api/app/share-extendeds/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
