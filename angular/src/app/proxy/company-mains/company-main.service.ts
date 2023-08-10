import type { CompanyMainCreateDto, CompanyMainDto, CompanyMainExcelDownloadDto, CompanyMainUpdateDto, GetCompanyMainsInput } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class CompanyMainService {
  apiName = 'Default';
  

  create = (input: CompanyMainCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyMainDto>({
      method: 'POST',
      url: '/api/app/company-mains',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/company-mains/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyMainDto>({
      method: 'GET',
      url: `/api/app/company-mains/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/company-mains/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetCompanyMainsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<CompanyMainDto>>({
      method: 'GET',
      url: '/api/app/company-mains',
      params: { filterText: input.filterText, name: input.name, compilation: input.compilation, officePhone: input.officePhone, faxPhone: input.faxPhone, address: input.address, principal: input.principal, allowSearch: input.allowSearch, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, note: input.note, sortMin: input.sortMin, sortMax: input.sortMax, status: input.status, industryCategory: input.industryCategory, companyUrl: input.companyUrl, capitalAmountMin: input.capitalAmountMin, capitalAmountMax: input.capitalAmountMax, hideCapitalAmount: input.hideCapitalAmount, companyScaleCode: input.companyScaleCode, hidePrincipal: input.hidePrincipal, companyUserId: input.companyUserId, companyProfile: input.companyProfile, businessPhilosophy: input.businessPhilosophy, operatingItems: input.operatingItems, welfareSystem: input.welfareSystem, matching: input.matching, contractPass: input.contractPass, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: CompanyMainExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/company-mains/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CompanyMainUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyMainDto>({
      method: 'PUT',
      url: `/api/app/company-mains/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
