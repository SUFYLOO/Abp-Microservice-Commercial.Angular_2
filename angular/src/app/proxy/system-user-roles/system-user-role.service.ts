import type { GetSystemUserRolesInput, SystemUserRoleCreateDto, SystemUserRoleDto, SystemUserRoleExcelDownloadDto, SystemUserRoleUpdateDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class SystemUserRoleService {
  apiName = 'Default';
  

  create = (input: SystemUserRoleCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, SystemUserRoleDto>({
      method: 'POST',
      url: '/api/app/system-user-roles',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/system-user-roles/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, SystemUserRoleDto>({
      method: 'GET',
      url: `/api/app/system-user-roles/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/system-user-roles/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetSystemUserRolesInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<SystemUserRoleDto>>({
      method: 'GET',
      url: '/api/app/system-user-roles',
      params: { filterText: input.filterText, name: input.name, keysMin: input.keysMin, keysMax: input.keysMax, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: SystemUserRoleExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/system-user-roles/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: SystemUserRoleUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, SystemUserRoleDto>({
      method: 'PUT',
      url: `/api/app/system-user-roles/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
