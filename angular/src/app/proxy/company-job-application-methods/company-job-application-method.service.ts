import type { CompanyJobApplicationMethodCreateDto, CompanyJobApplicationMethodDto, CompanyJobApplicationMethodExcelDownloadDto, CompanyJobApplicationMethodUpdateDto, GetCompanyJobApplicationMethodsInput } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class CompanyJobApplicationMethodService {
  apiName = 'Default';
  

  create = (input: CompanyJobApplicationMethodCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyJobApplicationMethodDto>({
      method: 'POST',
      url: '/api/app/company-job-application-methods',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/company-job-application-methods/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyJobApplicationMethodDto>({
      method: 'GET',
      url: `/api/app/company-job-application-methods/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/company-job-application-methods/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetCompanyJobApplicationMethodsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<CompanyJobApplicationMethodDto>>({
      method: 'GET',
      url: '/api/app/company-job-application-methods',
      params: { filterText: input.filterText, companyMainId: input.companyMainId, companyJobId: input.companyJobId, orgDept: input.orgDept, orgContactPerson: input.orgContactPerson, orgContactMail: input.orgContactMail, toRespondDayMin: input.toRespondDayMin, toRespondDayMax: input.toRespondDayMax, toRespond: input.toRespond, systemSendResume: input.systemSendResume, displayMail: input.displayMail, telephone: input.telephone, personally: input.personally, personallyAddress: input.personallyAddress, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: CompanyJobApplicationMethodExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/company-job-application-methods/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CompanyJobApplicationMethodUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyJobApplicationMethodDto>({
      method: 'PUT',
      url: `/api/app/company-job-application-methods/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
