import type { GetResumeSkillsInput, ResumeSkillCreateDto, ResumeSkillDto, ResumeSkillExcelDownloadDto, ResumeSkillUpdateDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class ResumeSkillService {
  apiName = 'Default';
  

  create = (input: ResumeSkillCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ResumeSkillDto>({
      method: 'POST',
      url: '/api/app/resume-skills',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/resume-skills/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ResumeSkillDto>({
      method: 'GET',
      url: `/api/app/resume-skills/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/resume-skills/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetResumeSkillsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<ResumeSkillDto>>({
      method: 'GET',
      url: '/api/app/resume-skills',
      params: { filterText: input.filterText, resumeMainId: input.resumeMainId, computerExpertise: input.computerExpertise, computerExpertiseEtc: input.computerExpertiseEtc, chineseTypingSpeedMin: input.chineseTypingSpeedMin, chineseTypingSpeedMax: input.chineseTypingSpeedMax, chineseTypingCode: input.chineseTypingCode, englishTypingSpeedMin: input.englishTypingSpeedMin, englishTypingSpeedMax: input.englishTypingSpeedMax, professionalLicense: input.professionalLicense, professionalLicenseEtc: input.professionalLicenseEtc, workSkills: input.workSkills, workSkillsEtc: input.workSkillsEtc, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: ResumeSkillExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/resume-skills/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: ResumeSkillUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ResumeSkillDto>({
      method: 'PUT',
      url: `/api/app/resume-skills/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
