import type { GetShareMessageTplsInput, ShareMessageTplCreateDto, ShareMessageTplDto, ShareMessageTplExcelDownloadDto, ShareMessageTplUpdateDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class ShareMessageTplService {
  apiName = 'Default';
  

  create = (input: ShareMessageTplCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ShareMessageTplDto>({
      method: 'POST',
      url: '/api/app/share-message-tpls',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/share-message-tpls/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ShareMessageTplDto>({
      method: 'GET',
      url: `/api/app/share-message-tpls/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/share-message-tpls/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetShareMessageTplsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<ShareMessageTplDto>>({
      method: 'GET',
      url: '/api/app/share-message-tpls',
      params: { filterText: input.filterText, key1: input.key1, key2: input.key2, key3: input.key3, name: input.name, statement: input.statement, titleContents: input.titleContents, contentMail: input.contentMail, contentSMS: input.contentSMS, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: ShareMessageTplExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/share-message-tpls/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: ShareMessageTplUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ShareMessageTplDto>({
      method: 'PUT',
      url: `/api/app/share-message-tpls/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
