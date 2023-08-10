import type { GetShareSendQueuesInput, ShareSendQueueCreateDto, ShareSendQueueDto, ShareSendQueueExcelDownloadDto, ShareSendQueueUpdateDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class ShareSendQueueService {
  apiName = 'Default';
  

  create = (input: ShareSendQueueCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ShareSendQueueDto>({
      method: 'POST',
      url: '/api/app/share-send-queues',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/share-send-queues/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ShareSendQueueDto>({
      method: 'GET',
      url: `/api/app/share-send-queues/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/share-send-queues/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetShareSendQueuesInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<ShareSendQueueDto>>({
      method: 'GET',
      url: '/api/app/share-send-queues',
      params: { filterText: input.filterText, key1: input.key1, key2: input.key2, key3: input.key3, sendTypeCode: input.sendTypeCode, fromAddr: input.fromAddr, toAddr: input.toAddr, titleContents: input.titleContents, contents: input.contents, retryMin: input.retryMin, retryMax: input.retryMax, sucess: input.sucess, suspend: input.suspend, dateSendMin: input.dateSendMin, dateSendMax: input.dateSendMax, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: ShareSendQueueExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/share-send-queues/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: ShareSendQueueUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ShareSendQueueDto>({
      method: 'PUT',
      url: `/api/app/share-send-queues/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
