import type { GetResumeExperiencessInput, ResumeExperiencesCreateDto, ResumeExperiencesDto, ResumeExperiencesExcelDownloadDto, ResumeExperiencesUpdateDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class ResumeExperiencesService {
  apiName = 'Default';
  

  create = (input: ResumeExperiencesCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ResumeExperiencesDto>({
      method: 'POST',
      url: '/api/app/resume-experiencess',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/resume-experiencess/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ResumeExperiencesDto>({
      method: 'GET',
      url: `/api/app/resume-experiencess/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/resume-experiencess/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetResumeExperiencessInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<ResumeExperiencesDto>>({
      method: 'GET',
      url: '/api/app/resume-experiencess',
      params: { filterText: input.filterText, resumeMainId: input.resumeMainId, name: input.name, workNatureCode: input.workNatureCode, hideCompanyName: input.hideCompanyName, industryCategoryCode: input.industryCategoryCode, jobName: input.jobName, jobType: input.jobType, working: input.working, workPlaceCode: input.workPlaceCode, hideWorkSalary: input.hideWorkSalary, salaryPayTypeCode: input.salaryPayTypeCode, currencyTypeCode: input.currencyTypeCode, salary1Min: input.salary1Min, salary1Max: input.salary1Max, salary2Min: input.salary2Min, salary2Max: input.salary2Max, companyScaleCode: input.companyScaleCode, companyManagementNumberCode: input.companyManagementNumberCode, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: ResumeExperiencesExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/resume-experiencess/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: ResumeExperiencesUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ResumeExperiencesDto>({
      method: 'PUT',
      url: `/api/app/resume-experiencess/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
