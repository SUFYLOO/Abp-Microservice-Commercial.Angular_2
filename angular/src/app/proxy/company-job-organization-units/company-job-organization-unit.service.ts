import type { CompanyJobOrganizationUnitCreateDto, CompanyJobOrganizationUnitDto, CompanyJobOrganizationUnitExcelDownloadDto, CompanyJobOrganizationUnitUpdateDto, GetCompanyJobOrganizationUnitsInput } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class CompanyJobOrganizationUnitService {
  apiName = 'Default';
  

  create = (input: CompanyJobOrganizationUnitCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyJobOrganizationUnitDto>({
      method: 'POST',
      url: '/api/app/company-job-organization-units',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/company-job-organization-units/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyJobOrganizationUnitDto>({
      method: 'GET',
      url: `/api/app/company-job-organization-units/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/company-job-organization-units/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetCompanyJobOrganizationUnitsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<CompanyJobOrganizationUnitDto>>({
      method: 'GET',
      url: '/api/app/company-job-organization-units',
      params: { filterText: input.filterText, companyMainId: input.companyMainId, companyJobId: input.companyJobId, organizationUnitId: input.organizationUnitId, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: CompanyJobOrganizationUnitExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/company-job-organization-units/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CompanyJobOrganizationUnitUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyJobOrganizationUnitDto>({
      method: 'PUT',
      url: `/api/app/company-job-organization-units/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
