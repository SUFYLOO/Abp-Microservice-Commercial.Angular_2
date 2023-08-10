import type { GetResumeMainsInput, ResumeMainCreateDto, ResumeMainDto, ResumeMainExcelDownloadDto, ResumeMainUpdateDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class ResumeMainService {
  apiName = 'Default';
  

  create = (input: ResumeMainCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ResumeMainDto>({
      method: 'POST',
      url: '/api/app/resume-mains',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/resume-mains/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ResumeMainDto>({
      method: 'GET',
      url: `/api/app/resume-mains/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/resume-mains/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetResumeMainsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<ResumeMainDto>>({
      method: 'GET',
      url: '/api/app/resume-mains',
      params: { filterText: input.filterText, userMainId: input.userMainId, resumeName: input.resumeName, marriageCode: input.marriageCode, militaryCode: input.militaryCode, disabilityCategoryCode: input.disabilityCategoryCode, specialIdentityCode: input.specialIdentityCode, main: input.main, autobiography1: input.autobiography1, autobiography2: input.autobiography2, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: ResumeMainExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/resume-mains/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: ResumeMainUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ResumeMainDto>({
      method: 'PUT',
      url: `/api/app/resume-mains/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
