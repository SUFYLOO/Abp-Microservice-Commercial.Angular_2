import type { GetShareLanguagesInput, ShareLanguageCreateDto, ShareLanguageDto, ShareLanguageExcelDownloadDto, ShareLanguageUpdateDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class ShareLanguageService {
  apiName = 'Default';
  

  create = (input: ShareLanguageCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ShareLanguageDto>({
      method: 'POST',
      url: '/api/app/share-languages',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/share-languages/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ShareLanguageDto>({
      method: 'GET',
      url: `/api/app/share-languages/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/share-languages/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetShareLanguagesInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<ShareLanguageDto>>({
      method: 'GET',
      url: '/api/app/share-languages',
      params: { filterText: input.filterText, name: input.name, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: ShareLanguageExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/share-languages/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: ShareLanguageUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ShareLanguageDto>({
      method: 'PUT',
      url: `/api/app/share-languages/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
