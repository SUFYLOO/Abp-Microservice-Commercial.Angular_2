import type { GetResumeExperiencesJobsInput, ResumeExperiencesJobCreateDto, ResumeExperiencesJobDto, ResumeExperiencesJobExcelDownloadDto, ResumeExperiencesJobUpdateDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class ResumeExperiencesJobService {
  apiName = 'Default';
  

  create = (input: ResumeExperiencesJobCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ResumeExperiencesJobDto>({
      method: 'POST',
      url: '/api/app/resume-experiences-jobs',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/resume-experiences-jobs/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ResumeExperiencesJobDto>({
      method: 'GET',
      url: `/api/app/resume-experiences-jobs/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/resume-experiences-jobs/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetResumeExperiencesJobsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<ResumeExperiencesJobDto>>({
      method: 'GET',
      url: '/api/app/resume-experiences-jobs',
      params: { filterText: input.filterText, resumeMainId: input.resumeMainId, resumeExperiencesId: input.resumeExperiencesId, jobType: input.jobType, yearMin: input.yearMin, yearMax: input.yearMax, monthMin: input.monthMin, monthMax: input.monthMax, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: ResumeExperiencesJobExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/resume-experiences-jobs/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: ResumeExperiencesJobUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ResumeExperiencesJobDto>({
      method: 'PUT',
      url: `/api/app/resume-experiences-jobs/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
