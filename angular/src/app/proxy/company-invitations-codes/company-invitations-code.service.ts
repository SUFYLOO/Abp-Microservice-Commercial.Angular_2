import type { CompanyInvitationsCodeCreateDto, CompanyInvitationsCodeDto, CompanyInvitationsCodeExcelDownloadDto, CompanyInvitationsCodeUpdateDto, GetCompanyInvitationsCodesInput } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class CompanyInvitationsCodeService {
  apiName = 'Default';
  

  create = (input: CompanyInvitationsCodeCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyInvitationsCodeDto>({
      method: 'POST',
      url: '/api/app/company-invitations-codes',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/company-invitations-codes/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyInvitationsCodeDto>({
      method: 'GET',
      url: `/api/app/company-invitations-codes/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/company-invitations-codes/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetCompanyInvitationsCodesInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<CompanyInvitationsCodeDto>>({
      method: 'GET',
      url: '/api/app/company-invitations-codes',
      params: { filterText: input.filterText, companyMainId: input.companyMainId, companyJobId: input.companyJobId, companyInvitationId: input.companyInvitationId, verifyId: input.verifyId, verifyCode: input.verifyCode, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: CompanyInvitationsCodeExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/company-invitations-codes/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CompanyInvitationsCodeUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyInvitationsCodeDto>({
      method: 'PUT',
      url: `/api/app/company-invitations-codes/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
