import type { CompanyJobCreateDto, CompanyJobDto, CompanyJobExcelDownloadDto, CompanyJobUpdateDto, GetCompanyJobsInput } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class CompanyJobService {
  apiName = 'Default';
  

  create = (input: CompanyJobCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyJobDto>({
      method: 'POST',
      url: '/api/app/company-jobs',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/company-jobs/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyJobDto>({
      method: 'GET',
      url: `/api/app/company-jobs/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/company-jobs/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetCompanyJobsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<CompanyJobDto>>({
      method: 'GET',
      url: '/api/app/company-jobs',
      params: { filterText: input.filterText, companyMainId: input.companyMainId, name: input.name, jobTypeCode: input.jobTypeCode, jobOpen: input.jobOpen, mailTplId: input.mailTplId, smsTplId: input.smsTplId, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: CompanyJobExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/company-jobs/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CompanyJobUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyJobDto>({
      method: 'PUT',
      url: `/api/app/company-jobs/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
