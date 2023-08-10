import type { GetSystemValidatesInput, SystemValidateCreateDto, SystemValidateDto, SystemValidateExcelDownloadDto, SystemValidateUpdateDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class SystemValidateService {
  apiName = 'Default';
  

  create = (input: SystemValidateCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, SystemValidateDto>({
      method: 'POST',
      url: '/api/app/system-validates',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/system-validates/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, SystemValidateDto>({
      method: 'GET',
      url: `/api/app/system-validates/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/system-validates/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetSystemValidatesInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<SystemValidateDto>>({
      method: 'GET',
      url: '/api/app/system-validates',
      params: { filterText: input.filterText, param: input.param, dateOpenMin: input.dateOpenMin, dateOpenMax: input.dateOpenMax, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: SystemValidateExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/system-validates/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: SystemValidateUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, SystemValidateDto>({
      method: 'PUT',
      url: `/api/app/system-validates/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
