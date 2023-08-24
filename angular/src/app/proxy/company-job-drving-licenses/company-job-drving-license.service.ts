import type { CompanyJobDrvingLicenseCreateDto, CompanyJobDrvingLicenseDto, CompanyJobDrvingLicenseExcelDownloadDto, CompanyJobDrvingLicenseUpdateDto, GetCompanyJobDrvingLicensesInput } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class CompanyJobDrvingLicenseService {
  apiName = 'Default';
  

  create = (input: CompanyJobDrvingLicenseCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyJobDrvingLicenseDto>({
      method: 'POST',
      url: '/api/app/company-job-drving-licenses',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/company-job-drving-licenses/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyJobDrvingLicenseDto>({
      method: 'GET',
      url: `/api/app/company-job-drving-licenses/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/company-job-drving-licenses/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetCompanyJobDrvingLicensesInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<CompanyJobDrvingLicenseDto>>({
      method: 'GET',
      url: '/api/app/company-job-drving-licenses',
      params: { filterText: input.filterText, companyMainId: input.companyMainId, companyJobId: input.companyJobId, drvingLicenseCode: input.drvingLicenseCode, haveDrvingLicense: input.haveDrvingLicense, haveCar: input.haveCar, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: CompanyJobDrvingLicenseExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/company-job-drving-licenses/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CompanyJobDrvingLicenseUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyJobDrvingLicenseDto>({
      method: 'PUT',
      url: `/api/app/company-job-drving-licenses/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
