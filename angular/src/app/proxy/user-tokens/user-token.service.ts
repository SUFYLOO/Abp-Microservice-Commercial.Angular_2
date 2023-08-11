import type { GetUserTokensInput, UserTokenCreateDto, UserTokenDto, UserTokenExcelDownloadDto, UserTokenUpdateDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class UserTokenService {
  apiName = 'Default';
  

  create = (input: UserTokenCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, UserTokenDto>({
      method: 'POST',
      url: '/api/app/user-tokens',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/user-tokens/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, UserTokenDto>({
      method: 'GET',
      url: `/api/app/user-tokens/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/user-tokens/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetUserTokensInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<UserTokenDto>>({
      method: 'GET',
      url: '/api/app/user-tokens',
      params: { filterText: input.filterText, userMainId: input.userMainId, tokenOld: input.tokenOld, tokenNew: input.tokenNew, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: UserTokenExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/user-tokens/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: UserTokenUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, UserTokenDto>({
      method: 'PUT',
      url: `/api/app/user-tokens/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
