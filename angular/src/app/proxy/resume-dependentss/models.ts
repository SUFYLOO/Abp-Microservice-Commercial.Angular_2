import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetResumeDependentssInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  resumeMainId?: string;
  name?: string;
  identityNo?: string;
  kinshipCode?: string;
  birthDateMin?: string;
  birthDateMax?: string;
  address?: string;
  mobilePhone?: string;
  extendedInformation?: string;
  dateAMin?: string;
  dateAMax?: string;
  dateDMin?: string;
  dateDMax?: string;
  sortMin?: number;
  sortMax?: number;
  note?: string;
  status?: string;
}

export interface ResumeDependentsCreateDto {
  resumeMainId?: string;
  name: string;
  identityNo?: string;
  kinshipCode: string;
  birthDate: string;
  address?: string;
  mobilePhone?: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface ResumeDependentsDto extends FullAuditedEntityDto<string> {
  resumeMainId?: string;
  name: string;
  identityNo?: string;
  kinshipCode: string;
  birthDate: string;
  address?: string;
  mobilePhone?: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface ResumeDependentsExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface ResumeDependentsUpdateDto {
  resumeMainId?: string;
  name: string;
  identityNo?: string;
  kinshipCode: string;
  birthDate: string;
  address?: string;
  mobilePhone?: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}
