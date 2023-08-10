import type { GetUserInfosInput, UserInfoCreateDto, UserInfoDto, UserInfoExcelDownloadDto, UserInfoUpdateDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class UserInfoService {
  apiName = 'Default';
  

  create = (input: UserInfoCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, UserInfoDto>({
      method: 'POST',
      url: '/api/app/user-infos',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/user-infos/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, UserInfoDto>({
      method: 'GET',
      url: `/api/app/user-infos/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/user-infos/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetUserInfosInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<UserInfoDto>>({
      method: 'GET',
      url: '/api/app/user-infos',
      params: { filterText: input.filterText, userMainId: input.userMainId, nameC: input.nameC, nameE: input.nameE, identityNo: input.identityNo, birthDateMin: input.birthDateMin, birthDateMax: input.birthDateMax, sexCode: input.sexCode, bloodCode: input.bloodCode, placeOfBirthCode: input.placeOfBirthCode, passportNo: input.passportNo, nationalityCode: input.nationalityCode, residenceNo: input.residenceNo, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: UserInfoExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/user-infos/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: UserInfoUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, UserInfoDto>({
      method: 'PUT',
      url: `/api/app/user-infos/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
