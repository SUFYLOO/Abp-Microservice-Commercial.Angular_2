import type { CompanyUserCreateDto, CompanyUserDto, CompanyUserExcelDownloadDto, CompanyUserUpdateDto, GetCompanyUsersInput } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class CompanyUserService {
  apiName = 'Default';
  

  create = (input: CompanyUserCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyUserDto>({
      method: 'POST',
      url: '/api/app/company-users',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/company-users/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyUserDto>({
      method: 'GET',
      url: `/api/app/company-users/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/company-users/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetCompanyUsersInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<CompanyUserDto>>({
      method: 'GET',
      url: '/api/app/company-users',
      params: { filterText: input.filterText, companyMainId: input.companyMainId, userMainId: input.userMainId, jobName: input.jobName, officePhone: input.officePhone, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, matchingReceive: input.matchingReceive, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: CompanyUserExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/company-users/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CompanyUserUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyUserDto>({
      method: 'PUT',
      url: `/api/app/company-users/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
