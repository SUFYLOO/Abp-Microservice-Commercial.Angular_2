import type { GetUserAccountBindsInput, UserAccountBindCreateDto, UserAccountBindDto, UserAccountBindExcelDownloadDto, UserAccountBindUpdateDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class UserAccountBindService {
  apiName = 'Default';
  

  create = (input: UserAccountBindCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, UserAccountBindDto>({
      method: 'POST',
      url: '/api/app/user-account-binds',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/user-account-binds/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, UserAccountBindDto>({
      method: 'GET',
      url: `/api/app/user-account-binds/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/user-account-binds/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetUserAccountBindsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<UserAccountBindDto>>({
      method: 'GET',
      url: '/api/app/user-account-binds',
      params: { filterText: input.filterText, userMainId: input.userMainId, thirdPartyTypeCode: input.thirdPartyTypeCode, thirdPartyAccountId: input.thirdPartyAccountId, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: UserAccountBindExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/user-account-binds/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: UserAccountBindUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, UserAccountBindDto>({
      method: 'PUT',
      url: `/api/app/user-account-binds/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
