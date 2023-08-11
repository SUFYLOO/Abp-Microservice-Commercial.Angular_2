import type { GetResumeDependentssInput, ResumeDependentsCreateDto, ResumeDependentsDto, ResumeDependentsExcelDownloadDto, ResumeDependentsUpdateDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class ResumeDependentsService {
  apiName = 'Default';
  

  create = (input: ResumeDependentsCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ResumeDependentsDto>({
      method: 'POST',
      url: '/api/app/resume-dependentss',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/resume-dependentss/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ResumeDependentsDto>({
      method: 'GET',
      url: `/api/app/resume-dependentss/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/resume-dependentss/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetResumeDependentssInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<ResumeDependentsDto>>({
      method: 'GET',
      url: '/api/app/resume-dependentss',
      params: { filterText: input.filterText, resumeMainId: input.resumeMainId, name: input.name, identityNo: input.identityNo, kinshipCode: input.kinshipCode, birthDateMin: input.birthDateMin, birthDateMax: input.birthDateMax, address: input.address, mobilePhone: input.mobilePhone, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: ResumeDependentsExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/resume-dependentss/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: ResumeDependentsUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ResumeDependentsDto>({
      method: 'PUT',
      url: `/api/app/resume-dependentss/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
