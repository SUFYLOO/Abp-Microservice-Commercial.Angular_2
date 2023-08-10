import type { CompanyContractCreateDto, CompanyContractDto, CompanyContractExcelDownloadDto, CompanyContractUpdateDto, GetCompanyContractsInput } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class CompanyContractService {
  apiName = 'Default';
  

  create = (input: CompanyContractCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyContractDto>({
      method: 'POST',
      url: '/api/app/company-contracts',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/company-contracts/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyContractDto>({
      method: 'GET',
      url: `/api/app/company-contracts/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/company-contracts/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetCompanyContractsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<CompanyContractDto>>({
      method: 'GET',
      url: '/api/app/company-contracts',
      params: { filterText: input.filterText, companyMainId: input.companyMainId, planCode: input.planCode, pointsTotalMin: input.pointsTotalMin, pointsTotalMax: input.pointsTotalMax, pointsPayMin: input.pointsPayMin, pointsPayMax: input.pointsPayMax, pointsGiftMin: input.pointsGiftMin, pointsGiftMax: input.pointsGiftMax, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: CompanyContractExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/company-contracts/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CompanyContractUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyContractDto>({
      method: 'PUT',
      url: `/api/app/company-contracts/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
