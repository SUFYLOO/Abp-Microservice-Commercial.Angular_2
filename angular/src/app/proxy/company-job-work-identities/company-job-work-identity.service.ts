import type { CompanyJobWorkIdentityCreateDto, CompanyJobWorkIdentityDto, CompanyJobWorkIdentityExcelDownloadDto, CompanyJobWorkIdentityUpdateDto, GetCompanyJobWorkIdentitiesInput } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class CompanyJobWorkIdentityService {
  apiName = 'Default';
  

  create = (input: CompanyJobWorkIdentityCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyJobWorkIdentityDto>({
      method: 'POST',
      url: '/api/app/company-job-work-identities',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/company-job-work-identities/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyJobWorkIdentityDto>({
      method: 'GET',
      url: `/api/app/company-job-work-identities/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/company-job-work-identities/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetCompanyJobWorkIdentitiesInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<CompanyJobWorkIdentityDto>>({
      method: 'GET',
      url: '/api/app/company-job-work-identities',
      params: { filterText: input.filterText, companyMainId: input.companyMainId, companyJobId: input.companyJobId, workIdentityCode: input.workIdentityCode, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: CompanyJobWorkIdentityExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/company-job-work-identities/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CompanyJobWorkIdentityUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyJobWorkIdentityDto>({
      method: 'PUT',
      url: `/api/app/company-job-work-identities/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
