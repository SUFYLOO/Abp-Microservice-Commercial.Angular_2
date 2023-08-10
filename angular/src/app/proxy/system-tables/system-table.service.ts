import type { GetSystemTablesInput, SystemTableCreateDto, SystemTableDto, SystemTableExcelDownloadDto, SystemTableUpdateDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class SystemTableService {
  apiName = 'Default';
  

  create = (input: SystemTableCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, SystemTableDto>({
      method: 'POST',
      url: '/api/app/system-tables',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/system-tables/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, SystemTableDto>({
      method: 'GET',
      url: `/api/app/system-tables/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/system-tables/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetSystemTablesInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<SystemTableDto>>({
      method: 'GET',
      url: '/api/app/system-tables',
      params: { filterText: input.filterText, name: input.name, allowInsert: input.allowInsert, allowUpdate: input.allowUpdate, allowDelete: input.allowDelete, allowSelect: input.allowSelect, allowExport: input.allowExport, allowImport: input.allowImport, allowPage: input.allowPage, allowSort: input.allowSort, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: SystemTableExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/system-tables/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: SystemTableUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, SystemTableDto>({
      method: 'PUT',
      url: `/api/app/system-tables/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
