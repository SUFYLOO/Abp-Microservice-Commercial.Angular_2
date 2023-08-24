import type { CompanyUserMainFavCreateDto, CompanyUserMainFavDto, CompanyUserMainFavExcelDownloadDto, CompanyUserMainFavUpdateDto, GetCompanyUserMainFavsInput } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class CompanyUserMainFavService {
  apiName = 'Default';
  

  create = (input: CompanyUserMainFavCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyUserMainFavDto>({
      method: 'POST',
      url: '/api/app/company-user-main-favs',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/company-user-main-favs/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyUserMainFavDto>({
      method: 'GET',
      url: `/api/app/company-user-main-favs/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/company-user-main-favs/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetCompanyUserMainFavsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<CompanyUserMainFavDto>>({
      method: 'GET',
      url: '/api/app/company-user-main-favs',
      params: { filterText: input.filterText, companyMainId: input.companyMainId, companyJobId: input.companyJobId, userMainId: input.userMainId, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: CompanyUserMainFavExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/company-user-main-favs/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CompanyUserMainFavUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyUserMainFavDto>({
      method: 'PUT',
      url: `/api/app/company-user-main-favs/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
