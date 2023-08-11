import type { GetResumeCommunicationsInput, ResumeCommunicationCreateDto, ResumeCommunicationDto, ResumeCommunicationExcelDownloadDto, ResumeCommunicationUpdateDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class ResumeCommunicationService {
  apiName = 'Default';
  

  create = (input: ResumeCommunicationCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ResumeCommunicationDto>({
      method: 'POST',
      url: '/api/app/resume-communications',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/resume-communications/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ResumeCommunicationDto>({
      method: 'GET',
      url: `/api/app/resume-communications/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/resume-communications/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetResumeCommunicationsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<ResumeCommunicationDto>>({
      method: 'GET',
      url: '/api/app/resume-communications',
      params: { filterText: input.filterText, resumeMainId: input.resumeMainId, communicationCategoryCode: input.communicationCategoryCode, communicationValue: input.communicationValue, main: input.main, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: ResumeCommunicationExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/resume-communications/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: ResumeCommunicationUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ResumeCommunicationDto>({
      method: 'PUT',
      url: `/api/app/resume-communications/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
