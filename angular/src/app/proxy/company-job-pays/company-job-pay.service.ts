import type { CompanyJobPayCreateDto, CompanyJobPayDto, CompanyJobPayExcelDownloadDto, CompanyJobPayUpdateDto, GetCompanyJobPaysInput } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class CompanyJobPayService {
  apiName = 'Default';
  

  create = (input: CompanyJobPayCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyJobPayDto>({
      method: 'POST',
      url: '/api/app/company-job-pays',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/company-job-pays/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyJobPayDto>({
      method: 'GET',
      url: `/api/app/company-job-pays/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/company-job-pays/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetCompanyJobPaysInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<CompanyJobPayDto>>({
      method: 'GET',
      url: '/api/app/company-job-pays',
      params: { filterText: input.filterText, companyMainId: input.companyMainId, companyJobId: input.companyJobId, jobPayTypeCode: input.jobPayTypeCode, dateRealMin: input.dateRealMin, dateRealMax: input.dateRealMax, isCancel: input.isCancel, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: CompanyJobPayExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/company-job-pays/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CompanyJobPayUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyJobPayDto>({
      method: 'PUT',
      url: `/api/app/company-job-pays/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
