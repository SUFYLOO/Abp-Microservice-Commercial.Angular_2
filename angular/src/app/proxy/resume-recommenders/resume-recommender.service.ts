import type { GetResumeRecommendersInput, ResumeRecommenderCreateDto, ResumeRecommenderDto, ResumeRecommenderExcelDownloadDto, ResumeRecommenderUpdateDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class ResumeRecommenderService {
  apiName = 'Default';
  

  create = (input: ResumeRecommenderCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ResumeRecommenderDto>({
      method: 'POST',
      url: '/api/app/resume-recommenders',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/resume-recommenders/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ResumeRecommenderDto>({
      method: 'GET',
      url: `/api/app/resume-recommenders/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/resume-recommenders/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetResumeRecommendersInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<ResumeRecommenderDto>>({
      method: 'GET',
      url: '/api/app/resume-recommenders',
      params: { filterText: input.filterText, resumeMainId: input.resumeMainId, name: input.name, companyName: input.companyName, jobName: input.jobName, mobilePhone: input.mobilePhone, officePhone: input.officePhone, email: input.email, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: ResumeRecommenderExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/resume-recommenders/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: ResumeRecommenderUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ResumeRecommenderDto>({
      method: 'PUT',
      url: `/api/app/resume-recommenders/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
