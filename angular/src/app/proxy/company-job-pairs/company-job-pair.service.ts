import type { CompanyJobPairCreateDto, CompanyJobPairDto, CompanyJobPairExcelDownloadDto, CompanyJobPairUpdateDto, GetCompanyJobPairsInput } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class CompanyJobPairService {
  apiName = 'Default';
  

  create = (input: CompanyJobPairCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyJobPairDto>({
      method: 'POST',
      url: '/api/app/company-job-pairs',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/company-job-pairs/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyJobPairDto>({
      method: 'GET',
      url: `/api/app/company-job-pairs/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/company-job-pairs/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetCompanyJobPairsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<CompanyJobPairDto>>({
      method: 'GET',
      url: '/api/app/company-job-pairs',
      params: { filterText: input.filterText, companyMainId: input.companyMainId, name: input.name, pairCondition: input.pairCondition, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: CompanyJobPairExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/company-job-pairs/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CompanyJobPairUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyJobPairDto>({
      method: 'PUT',
      url: `/api/app/company-job-pairs/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
