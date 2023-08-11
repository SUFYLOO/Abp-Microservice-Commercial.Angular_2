import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetUserAccountBindsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  userMainId?: string;
  thirdPartyTypeCode?: string;
  thirdPartyAccountId?: string;
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

export interface UserAccountBindCreateDto {
  userMainId?: string;
  thirdPartyTypeCode: string;
  thirdPartyAccountId: string;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}

export interface UserAccountBindDto extends FullAuditedEntityDto<string> {
  userMainId?: string;
  thirdPartyTypeCode: string;
  thirdPartyAccountId: string;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}

export interface UserAccountBindExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface UserAccountBindUpdateDto {
  userMainId?: string;
  thirdPartyTypeCode: string;
  thirdPartyAccountId: string;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}
