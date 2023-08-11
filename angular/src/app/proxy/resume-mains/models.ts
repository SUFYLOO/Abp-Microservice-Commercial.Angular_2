import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetResumeMainsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  userMainId?: string;
  resumeName?: string;
  marriageCode?: string;
  militaryCode?: string;
  disabilityCategoryCode?: string;
  specialIdentityCode?: string;
  main?: boolean;
  autobiography1?: string;
  autobiography2?: string;
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

export interface ResumeMainCreateDto {
  userMainId?: string;
  resumeName: string;
  marriageCode?: string;
  militaryCode?: string;
  disabilityCategoryCode?: string;
  specialIdentityCode?: string;
  main: boolean;
  autobiography1?: string;
  autobiography2?: string;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}

export interface ResumeMainDto extends FullAuditedEntityDto<string> {
  userMainId?: string;
  resumeName: string;
  marriageCode?: string;
  militaryCode?: string;
  disabilityCategoryCode?: string;
  specialIdentityCode?: string;
  main: boolean;
  autobiography1?: string;
  autobiography2?: string;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}

export interface ResumeMainExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface ResumeMainUpdateDto {
  userMainId?: string;
  resumeName: string;
  marriageCode?: string;
  militaryCode?: string;
  disabilityCategoryCode?: string;
  specialIdentityCode?: string;
  main: boolean;
  autobiography1?: string;
  autobiography2?: string;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}
