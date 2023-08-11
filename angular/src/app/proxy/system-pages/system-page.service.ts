import type { GetSystemPagesInput, SystemPageCreateDto, SystemPageDto, SystemPageExcelDownloadDto, SystemPageUpdateDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class SystemPageService {
  apiName = 'Default';
  

  create = (input: SystemPageCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, SystemPageDto>({
      method: 'POST',
      url: '/api/app/system-pages',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/system-pages/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, SystemPageDto>({
      method: 'GET',
      url: `/api/app/system-pages/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/system-pages/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetSystemPagesInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<SystemPageDto>>({
      method: 'GET',
      url: '/api/app/system-pages',
      params: { filterText: input.filterText, typeCode: input.typeCode, filePath: input.filePath, fileName: input.fileName, fileTitle: input.fileTitle, systemUserRoleKeys: input.systemUserRoleKeys, parentCode: input.parentCode, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: SystemPageExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/system-pages/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: SystemPageUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, SystemPageDto>({
      method: 'PUT',
      url: `/api/app/system-pages/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
