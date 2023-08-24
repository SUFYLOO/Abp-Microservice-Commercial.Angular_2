import type { CompanyJobContentCreateDto, CompanyJobContentDto, CompanyJobContentExcelDownloadDto, CompanyJobContentUpdateDto, GetCompanyJobContentsInput } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class CompanyJobContentService {
  apiName = 'Default';
  

  create = (input: CompanyJobContentCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyJobContentDto>({
      method: 'POST',
      url: '/api/app/company-job-contents',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/company-job-contents/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyJobContentDto>({
      method: 'GET',
      url: `/api/app/company-job-contents/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/company-job-contents/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetCompanyJobContentsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<CompanyJobContentDto>>({
      method: 'GET',
      url: '/api/app/company-job-contents',
      params: { filterText: input.filterText, companyMainId: input.companyMainId, companyJobId: input.companyJobId, name: input.name, jobTypeCode: input.jobTypeCode, peopleRequiredNumberMin: input.peopleRequiredNumberMin, peopleRequiredNumberMax: input.peopleRequiredNumberMax, peopleRequiredNumberUnlimited: input.peopleRequiredNumberUnlimited, jobType: input.jobType, jobTypeContent: input.jobTypeContent, salaryPayTypeCode: input.salaryPayTypeCode, salaryMinMin: input.salaryMinMin, salaryMinMax: input.salaryMinMax, salaryMaxMin: input.salaryMaxMin, salaryMaxMax: input.salaryMaxMax, salaryUp: input.salaryUp, workPlace: input.workPlace, workHours: input.workHours, workHoursCustom: input.workHoursCustom, workShift: input.workShift, workRemoteAllow: input.workRemoteAllow, workRemoteTypeCode: input.workRemoteTypeCode, workRemoteDescript: input.workRemoteDescript, businessTrip: input.businessTrip, holidaySystemCode: input.holidaySystemCode, dispatched: input.dispatched, workDayCode: input.workDayCode, workIdentity: input.workIdentity, disabilityCategory: input.disabilityCategory, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: CompanyJobContentExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/company-job-contents/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CompanyJobContentUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyJobContentDto>({
      method: 'PUT',
      url: `/api/app/company-job-contents/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
