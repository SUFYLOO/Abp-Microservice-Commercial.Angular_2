import type { GetResumeLanguagesInput, ResumeLanguageCreateDto, ResumeLanguageDto, ResumeLanguageExcelDownloadDto, ResumeLanguageUpdateDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class ResumeLanguageService {
  apiName = 'Default';
  

  create = (input: ResumeLanguageCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ResumeLanguageDto>({
      method: 'POST',
      url: '/api/app/resume-languages',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/resume-languages/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ResumeLanguageDto>({
      method: 'GET',
      url: `/api/app/resume-languages/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/resume-languages/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetResumeLanguagesInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<ResumeLanguageDto>>({
      method: 'GET',
      url: '/api/app/resume-languages',
      params: { filterText: input.filterText, resumeMainId: input.resumeMainId, languageCategoryCode: input.languageCategoryCode, levelSayCode: input.levelSayCode, levelListenCode: input.levelListenCode, levelReadCode: input.levelReadCode, levelWriteCode: input.levelWriteCode, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: ResumeLanguageExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/resume-languages/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: ResumeLanguageUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ResumeLanguageDto>({
      method: 'PUT',
      url: `/api/app/resume-languages/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
