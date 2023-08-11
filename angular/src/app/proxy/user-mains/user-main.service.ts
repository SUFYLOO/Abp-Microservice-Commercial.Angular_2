import type { GetUserMainsInput, UserMainCreateDto, UserMainDto, UserMainExcelDownloadDto, UserMainUpdateDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class UserMainService {
  apiName = 'Default';
  

  create = (input: UserMainCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, UserMainDto>({
      method: 'POST',
      url: '/api/app/user-mains',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/user-mains/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, UserMainDto>({
      method: 'GET',
      url: `/api/app/user-mains/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/user-mains/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetUserMainsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<UserMainDto>>({
      method: 'GET',
      url: '/api/app/user-mains',
      params: { filterText: input.filterText, userId: input.userId, name: input.name, anonymousName: input.anonymousName, loginAccountCode: input.loginAccountCode, loginMobilePhoneUpdate: input.loginMobilePhoneUpdate, loginMobilePhone: input.loginMobilePhone, loginEmailUpdate: input.loginEmailUpdate, loginEmail: input.loginEmail, loginIdentityNo: input.loginIdentityNo, password: input.password, systemUserRoleKeysMin: input.systemUserRoleKeysMin, systemUserRoleKeysMax: input.systemUserRoleKeysMax, allowSearch: input.allowSearch, dateAMin: input.dateAMin, dateAMax: input.dateAMax, extendedInformation: input.extendedInformation, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, matching: input.matching, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: UserMainExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/user-mains/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: UserMainUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, UserMainDto>({
      method: 'PUT',
      url: `/api/app/user-mains/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
