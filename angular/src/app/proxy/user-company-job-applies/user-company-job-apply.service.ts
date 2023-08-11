import type { GetUserCompanyJobAppliesInput, UserCompanyJobApplyCreateDto, UserCompanyJobApplyDto, UserCompanyJobApplyExcelDownloadDto, UserCompanyJobApplyUpdateDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class UserCompanyJobApplyService {
  apiName = 'Default';
  

  create = (input: UserCompanyJobApplyCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, UserCompanyJobApplyDto>({
      method: 'POST',
      url: '/api/app/user-company-job-applies',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/user-company-job-applies/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, UserCompanyJobApplyDto>({
      method: 'GET',
      url: `/api/app/user-company-job-applies/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/user-company-job-applies/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetUserCompanyJobAppliesInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<UserCompanyJobApplyDto>>({
      method: 'GET',
      url: '/api/app/user-company-job-applies',
      params: { filterText: input.filterText, userMainId: input.userMainId, companyJobId: input.companyJobId, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: UserCompanyJobApplyExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/user-company-job-applies/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: UserCompanyJobApplyUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, UserCompanyJobApplyDto>({
      method: 'PUT',
      url: `/api/app/user-company-job-applies/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
