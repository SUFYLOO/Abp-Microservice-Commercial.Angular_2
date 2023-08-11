import type { GetUserCompanyJobFavsInput, UserCompanyJobFavCreateDto, UserCompanyJobFavDto, UserCompanyJobFavExcelDownloadDto, UserCompanyJobFavUpdateDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class UserCompanyJobFavService {
  apiName = 'Default';
  

  create = (input: UserCompanyJobFavCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, UserCompanyJobFavDto>({
      method: 'POST',
      url: '/api/app/user-company-job-favs',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/user-company-job-favs/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, UserCompanyJobFavDto>({
      method: 'GET',
      url: `/api/app/user-company-job-favs/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/user-company-job-favs/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetUserCompanyJobFavsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<UserCompanyJobFavDto>>({
      method: 'GET',
      url: '/api/app/user-company-job-favs',
      params: { filterText: input.filterText, userMainId: input.userMainId, companyJobId: input.companyJobId, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: UserCompanyJobFavExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/user-company-job-favs/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: UserCompanyJobFavUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, UserCompanyJobFavDto>({
      method: 'PUT',
      url: `/api/app/user-company-job-favs/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
