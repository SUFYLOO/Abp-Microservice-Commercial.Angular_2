import type { CompanyInvitationsCreateDto, CompanyInvitationsDto, CompanyInvitationsExcelDownloadDto, CompanyInvitationsUpdateDto, GetCompanyInvitationssInput } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class CompanyInvitationsService {
  apiName = 'Default';
  

  create = (input: CompanyInvitationsCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyInvitationsDto>({
      method: 'POST',
      url: '/api/app/company-invitationss',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/company-invitationss/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyInvitationsDto>({
      method: 'GET',
      url: `/api/app/company-invitationss/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/company-invitationss/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetCompanyInvitationssInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<CompanyInvitationsDto>>({
      method: 'GET',
      url: '/api/app/company-invitationss',
      params: { filterText: input.filterText, companyMainId: input.companyMainId, companyJobId: input.companyJobId, openAllJob: input.openAllJob, userMainId: input.userMainId, userMainName: input.userMainName, userMainLoginMobilePhone: input.userMainLoginMobilePhone, userMainLoginEmail: input.userMainLoginEmail, userMainLoginIdentityNo: input.userMainLoginIdentityNo, sendTypeCode: input.sendTypeCode, sendStatusCode: input.sendStatusCode, resumeFlowStageCode: input.resumeFlowStageCode, isRead: input.isRead, userCompanyBindId: input.userCompanyBindId, resumeSnapshotId: input.resumeSnapshotId, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: CompanyInvitationsExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/company-invitationss/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CompanyInvitationsUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyInvitationsDto>({
      method: 'PUT',
      url: `/api/app/company-invitationss/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
