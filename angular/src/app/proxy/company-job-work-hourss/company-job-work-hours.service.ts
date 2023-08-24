import type { CompanyJobWorkHoursCreateDto, CompanyJobWorkHoursDto, CompanyJobWorkHoursExcelDownloadDto, CompanyJobWorkHoursUpdateDto, GetCompanyJobWorkHourssInput } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class CompanyJobWorkHoursService {
  apiName = 'Default';
  

  create = (input: CompanyJobWorkHoursCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyJobWorkHoursDto>({
      method: 'POST',
      url: '/api/app/company-job-work-hourss',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/company-job-work-hourss/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyJobWorkHoursDto>({
      method: 'GET',
      url: `/api/app/company-job-work-hourss/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/company-job-work-hourss/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetCompanyJobWorkHourssInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<CompanyJobWorkHoursDto>>({
      method: 'GET',
      url: '/api/app/company-job-work-hourss',
      params: { filterText: input.filterText, companyMainId: input.companyMainId, companyJobId: input.companyJobId, workHoursCode: input.workHoursCode, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: CompanyJobWorkHoursExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/company-job-work-hourss/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CompanyJobWorkHoursUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyJobWorkHoursDto>({
      method: 'PUT',
      url: `/api/app/company-job-work-hourss/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
