import type { GetShareDictionarysInput, ShareDictionaryCreateDto, ShareDictionaryDto, ShareDictionaryExcelDownloadDto, ShareDictionaryUpdateDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class ShareDictionaryService {
  apiName = 'Default';
  

  create = (input: ShareDictionaryCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ShareDictionaryDto>({
      method: 'POST',
      url: '/api/app/share-dictionarys',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/share-dictionarys/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ShareDictionaryDto>({
      method: 'GET',
      url: `/api/app/share-dictionarys/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/share-dictionarys/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetShareDictionarysInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<ShareDictionaryDto>>({
      method: 'GET',
      url: '/api/app/share-dictionarys',
      params: { filterText: input.filterText, shareLanguageId: input.shareLanguageId, shareTagId: input.shareTagId, key1: input.key1, key2: input.key2, key3: input.key3, name: input.name, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: ShareDictionaryExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/share-dictionarys/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: ShareDictionaryUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ShareDictionaryDto>({
      method: 'PUT',
      url: `/api/app/share-dictionarys/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
