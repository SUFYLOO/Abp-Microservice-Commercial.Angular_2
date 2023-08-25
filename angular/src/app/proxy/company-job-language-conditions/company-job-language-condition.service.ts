import type { CompanyJobLanguageConditionCreateDto, CompanyJobLanguageConditionDto, CompanyJobLanguageConditionExcelDownloadDto, CompanyJobLanguageConditionUpdateDto, GetCompanyJobLanguageConditionsInput } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class CompanyJobLanguageConditionService {
  apiName = 'Default';
  

  create = (input: CompanyJobLanguageConditionCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyJobLanguageConditionDto>({
      method: 'POST',
      url: '/api/app/company-job-language-conditions',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/company-job-language-conditions/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyJobLanguageConditionDto>({
      method: 'GET',
      url: `/api/app/company-job-language-conditions/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/company-job-language-conditions/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetCompanyJobLanguageConditionsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<CompanyJobLanguageConditionDto>>({
      method: 'GET',
      url: '/api/app/company-job-language-conditions',
      params: { filterText: input.filterText, companyMainId: input.companyMainId, companyJobId: input.companyJobId, languageCategoryCode: input.languageCategoryCode, levelSayCode: input.levelSayCode, levelListenCode: input.levelListenCode, levelReadCode: input.levelReadCode, levelWriteCode: input.levelWriteCode, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: CompanyJobLanguageConditionExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/company-job-language-conditions/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CompanyJobLanguageConditionUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyJobLanguageConditionDto>({
      method: 'PUT',
      url: `/api/app/company-job-language-conditions/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
