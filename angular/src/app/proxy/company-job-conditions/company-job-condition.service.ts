import type { CompanyJobConditionCreateDto, CompanyJobConditionDto, CompanyJobConditionExcelDownloadDto, CompanyJobConditionUpdateDto, GetCompanyJobConditionsInput } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class CompanyJobConditionService {
  apiName = 'Default';
  

  create = (input: CompanyJobConditionCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyJobConditionDto>({
      method: 'POST',
      url: '/api/app/company-job-conditions',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/company-job-conditions/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyJobConditionDto>({
      method: 'GET',
      url: `/api/app/company-job-conditions/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/company-job-conditions/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetCompanyJobConditionsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<CompanyJobConditionDto>>({
      method: 'GET',
      url: '/api/app/company-job-conditions',
      params: { filterText: input.filterText, companyMainCode: input.companyMainCode, companyJobCode: input.companyJobCode, workExperienceYearCode: input.workExperienceYearCode, educationLevel: input.educationLevel, majorDepartmentCategory: input.majorDepartmentCategory, languageCategory: input.languageCategory, computerExpertise: input.computerExpertise, professionalLicense: input.professionalLicense, drvingLicense: input.drvingLicense, etcCondition: input.etcCondition, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: CompanyJobConditionExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/company-job-conditions/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CompanyJobConditionUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyJobConditionDto>({
      method: 'PUT',
      url: `/api/app/company-job-conditions/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
