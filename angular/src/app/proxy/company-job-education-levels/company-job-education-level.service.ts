import type { CompanyJobEducationLevelCreateDto, CompanyJobEducationLevelDto, CompanyJobEducationLevelExcelDownloadDto, CompanyJobEducationLevelUpdateDto, GetCompanyJobEducationLevelsInput } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class CompanyJobEducationLevelService {
  apiName = 'Default';
  

  create = (input: CompanyJobEducationLevelCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyJobEducationLevelDto>({
      method: 'POST',
      url: '/api/app/company-job-education-levels',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/company-job-education-levels/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyJobEducationLevelDto>({
      method: 'GET',
      url: `/api/app/company-job-education-levels/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/company-job-education-levels/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetCompanyJobEducationLevelsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<CompanyJobEducationLevelDto>>({
      method: 'GET',
      url: '/api/app/company-job-education-levels',
      params: { filterText: input.filterText, companyMainId: input.companyMainId, companyJobId: input.companyJobId, educationLevelCode: input.educationLevelCode, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: CompanyJobEducationLevelExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/company-job-education-levels/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CompanyJobEducationLevelUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyJobEducationLevelDto>({
      method: 'PUT',
      url: `/api/app/company-job-education-levels/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
