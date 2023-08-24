import type { CompanyJobDisabilityCategoryCreateDto, CompanyJobDisabilityCategoryDto, CompanyJobDisabilityCategoryExcelDownloadDto, CompanyJobDisabilityCategoryUpdateDto, GetCompanyJobDisabilityCategoriesInput } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class CompanyJobDisabilityCategoryService {
  apiName = 'Default';
  

  create = (input: CompanyJobDisabilityCategoryCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyJobDisabilityCategoryDto>({
      method: 'POST',
      url: '/api/app/company-job-disability-categories',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/company-job-disability-categories/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyJobDisabilityCategoryDto>({
      method: 'GET',
      url: `/api/app/company-job-disability-categories/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/company-job-disability-categories/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetCompanyJobDisabilityCategoriesInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<CompanyJobDisabilityCategoryDto>>({
      method: 'GET',
      url: '/api/app/company-job-disability-categories',
      params: { filterText: input.filterText, companyMainId: input.companyMainId, companyJobId: input.companyJobId, disabilityCategoryCode: input.disabilityCategoryCode, disabilityLevelCode: input.disabilityLevelCode, disabilityCertifiedDocumentsNeed: input.disabilityCertifiedDocumentsNeed, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: CompanyJobDisabilityCategoryExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/company-job-disability-categories/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CompanyJobDisabilityCategoryUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyJobDisabilityCategoryDto>({
      method: 'PUT',
      url: `/api/app/company-job-disability-categories/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
