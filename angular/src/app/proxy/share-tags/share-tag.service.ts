import type { GetShareTagsInput, ShareTagCreateDto, ShareTagDto, ShareTagExcelDownloadDto, ShareTagUpdateDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class ShareTagService {
  apiName = 'Default';
  

  create = (input: ShareTagCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ShareTagDto>({
      method: 'POST',
      url: '/api/app/share-tags',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/share-tags/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ShareTagDto>({
      method: 'GET',
      url: `/api/app/share-tags/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/share-tags/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetShareTagsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<ShareTagDto>>({
      method: 'GET',
      url: '/api/app/share-tags',
      params: { filterText: input.filterText, colorCode: input.colorCode, key1: input.key1, key2: input.key2, key3: input.key3, name: input.name, tagCategoryCode: input.tagCategoryCode, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: ShareTagExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/share-tags/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: ShareTagUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ShareTagDto>({
      method: 'PUT',
      url: `/api/app/share-tags/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
