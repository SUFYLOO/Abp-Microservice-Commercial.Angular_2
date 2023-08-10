import type { GetResumeSnapshotsInput, ResumeSnapshotCreateDto, ResumeSnapshotDto, ResumeSnapshotExcelDownloadDto, ResumeSnapshotUpdateDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class ResumeSnapshotService {
  apiName = 'Default';
  

  create = (input: ResumeSnapshotCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ResumeSnapshotDto>({
      method: 'POST',
      url: '/api/app/resume-snapshots',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/resume-snapshots/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ResumeSnapshotDto>({
      method: 'GET',
      url: `/api/app/resume-snapshots/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/resume-snapshots/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetResumeSnapshotsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<ResumeSnapshotDto>>({
      method: 'GET',
      url: '/api/app/resume-snapshots',
      params: { filterText: input.filterText, userMainId: input.userMainId, resumeMainId: input.resumeMainId, companyMainId: input.companyMainId, companyJobId: input.companyJobId, snapshot: input.snapshot, userCompanyBindId: input.userCompanyBindId, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: ResumeSnapshotExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/resume-snapshots/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: ResumeSnapshotUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ResumeSnapshotDto>({
      method: 'PUT',
      url: `/api/app/resume-snapshots/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
