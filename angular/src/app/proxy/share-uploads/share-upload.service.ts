import type { GetShareUploadsInput, ShareUploadCreateDto, ShareUploadDto, ShareUploadExcelDownloadDto, ShareUploadUpdateDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class ShareUploadService {
  apiName = 'Default';
  

  create = (input: ShareUploadCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ShareUploadDto>({
      method: 'POST',
      url: '/api/app/share-uploads',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/share-uploads/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ShareUploadDto>({
      method: 'GET',
      url: `/api/app/share-uploads/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/share-uploads/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetShareUploadsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<ShareUploadDto>>({
      method: 'GET',
      url: '/api/app/share-uploads',
      params: { filterText: input.filterText, key1: input.key1, key2: input.key2, key3: input.key3, uploadName: input.uploadName, serverName: input.serverName, type: input.type, sizeMin: input.sizeMin, sizeMax: input.sizeMax, systemUse: input.systemUse, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: ShareUploadExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/share-uploads/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: ShareUploadUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ShareUploadDto>({
      method: 'PUT',
      url: `/api/app/share-uploads/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
