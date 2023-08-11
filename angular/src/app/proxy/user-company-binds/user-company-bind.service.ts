import type { GetUserCompanyBindsInput, UserCompanyBindCreateDto, UserCompanyBindDto, UserCompanyBindExcelDownloadDto, UserCompanyBindUpdateDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class UserCompanyBindService {
  apiName = 'Default';
  

  create = (input: UserCompanyBindCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, UserCompanyBindDto>({
      method: 'POST',
      url: '/api/app/user-company-binds',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/user-company-binds/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, UserCompanyBindDto>({
      method: 'GET',
      url: `/api/app/user-company-binds/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/user-company-binds/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetUserCompanyBindsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<UserCompanyBindDto>>({
      method: 'GET',
      url: '/api/app/user-company-binds',
      params: { filterText: input.filterText, userMainId: input.userMainId, companyMainId: input.companyMainId, companyJobId: input.companyJobId, companyInvitationsId: input.companyInvitationsId, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: UserCompanyBindExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/user-company-binds/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: UserCompanyBindUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, UserCompanyBindDto>({
      method: 'PUT',
      url: `/api/app/user-company-binds/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
