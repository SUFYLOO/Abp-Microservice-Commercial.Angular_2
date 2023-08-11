import type { CompanyPointsCreateDto, CompanyPointsDto, CompanyPointsExcelDownloadDto, CompanyPointsUpdateDto, GetCompanyPointssInput } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class CompanyPointsService {
  apiName = 'Default';
  

  create = (input: CompanyPointsCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyPointsDto>({
      method: 'POST',
      url: '/api/app/company-pointss',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/company-pointss/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyPointsDto>({
      method: 'GET',
      url: `/api/app/company-pointss/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/company-pointss/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetCompanyPointssInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<CompanyPointsDto>>({
      method: 'GET',
      url: '/api/app/company-pointss',
      params: { filterText: input.filterText, companyMainId: input.companyMainId, companyPointsTypeCode: input.companyPointsTypeCode, pointsMin: input.pointsMin, pointsMax: input.pointsMax, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: CompanyPointsExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/company-pointss/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CompanyPointsUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CompanyPointsDto>({
      method: 'PUT',
      url: `/api/app/company-pointss/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
