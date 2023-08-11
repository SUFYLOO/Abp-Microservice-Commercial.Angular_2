import type { GetResumeDrvingLicensesInput, ResumeDrvingLicenseCreateDto, ResumeDrvingLicenseDto, ResumeDrvingLicenseExcelDownloadDto, ResumeDrvingLicenseUpdateDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class ResumeDrvingLicenseService {
  apiName = 'Default';
  

  create = (input: ResumeDrvingLicenseCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ResumeDrvingLicenseDto>({
      method: 'POST',
      url: '/api/app/resume-drving-licenses',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/resume-drving-licenses/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ResumeDrvingLicenseDto>({
      method: 'GET',
      url: `/api/app/resume-drving-licenses/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/resume-drving-licenses/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetResumeDrvingLicensesInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<ResumeDrvingLicenseDto>>({
      method: 'GET',
      url: '/api/app/resume-drving-licenses',
      params: { filterText: input.filterText, resumeMainId: input.resumeMainId, drvingLicenseCode: input.drvingLicenseCode, haveDrvingLicense: input.haveDrvingLicense, haveCar: input.haveCar, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: ResumeDrvingLicenseExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/resume-drving-licenses/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: ResumeDrvingLicenseUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ResumeDrvingLicenseDto>({
      method: 'PUT',
      url: `/api/app/resume-drving-licenses/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
