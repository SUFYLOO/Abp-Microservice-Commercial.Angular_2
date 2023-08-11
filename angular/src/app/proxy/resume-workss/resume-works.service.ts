import type { GetResumeWorkssInput, ResumeWorksCreateDto, ResumeWorksDto, ResumeWorksExcelDownloadDto, ResumeWorksUpdateDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class ResumeWorksService {
  apiName = 'Default';
  

  create = (input: ResumeWorksCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ResumeWorksDto>({
      method: 'POST',
      url: '/api/app/resume-workss',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/resume-workss/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ResumeWorksDto>({
      method: 'GET',
      url: `/api/app/resume-workss/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/resume-workss/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetResumeWorkssInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<ResumeWorksDto>>({
      method: 'GET',
      url: '/api/app/resume-workss',
      params: { filterText: input.filterText, resumeMainId: input.resumeMainId, name: input.name, link: input.link, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: ResumeWorksExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/resume-workss/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: ResumeWorksUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ResumeWorksDto>({
      method: 'PUT',
      url: `/api/app/resume-workss/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
