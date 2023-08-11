import type { GetUserVerifysInput, UserVerifyCreateDto, UserVerifyDto, UserVerifyExcelDownloadDto, UserVerifyUpdateDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class UserVerifyService {
  apiName = 'Default';
  

  create = (input: UserVerifyCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, UserVerifyDto>({
      method: 'POST',
      url: '/api/app/user-verifys',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/user-verifys/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, UserVerifyDto>({
      method: 'GET',
      url: `/api/app/user-verifys/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/user-verifys/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetUserVerifysInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<UserVerifyDto>>({
      method: 'GET',
      url: '/api/app/user-verifys',
      params: { filterText: input.filterText, verifyId: input.verifyId, verifyCode: input.verifyCode, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: UserVerifyExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/user-verifys/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: number, input: UserVerifyUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, UserVerifyDto>({
      method: 'PUT',
      url: `/api/app/user-verifys/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
