import type { GetResumeEducationssInput, ResumeEducationsCreateDto, ResumeEducationsDto, ResumeEducationsExcelDownloadDto, ResumeEducationsUpdateDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class ResumeEducationsService {
  apiName = 'Default';
  

  create = (input: ResumeEducationsCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ResumeEducationsDto>({
      method: 'POST',
      url: '/api/app/resume-educationss',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/resume-educationss/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ResumeEducationsDto>({
      method: 'GET',
      url: `/api/app/resume-educationss/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/resume-educationss/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetResumeEducationssInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<ResumeEducationsDto>>({
      method: 'GET',
      url: '/api/app/resume-educationss',
      params: { filterText: input.filterText, resumeMainId: input.resumeMainId, educationLevelCode: input.educationLevelCode, schoolCode: input.schoolCode, schoolName: input.schoolName, night: input.night, working: input.working, majorDepartmentName: input.majorDepartmentName, majorDepartmentCategoryCode: input.majorDepartmentCategoryCode, minorDepartmentName: input.minorDepartmentName, minorDepartmentCategoryCode: input.minorDepartmentCategoryCode, graduationCode: input.graduationCode, domestic: input.domestic, countryCode: input.countryCode, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: ResumeEducationsExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/resume-educationss/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: ResumeEducationsUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ResumeEducationsDto>({
      method: 'PUT',
      url: `/api/app/resume-educationss/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
