import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetUserTokensInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  userMainId?: string;
  tokenOld?: string;
  tokenNew?: string;
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

export interface UserTokenCreateDto {
  userMainId?: string;
  tokenOld: string;
  tokenNew: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface UserTokenDto extends FullAuditedEntityDto<string> {
  userMainId?: string;
  tokenOld: string;
  tokenNew: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
  concurrencyStamp?: string;
}

export interface UserTokenExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface UserTokenUpdateDto {
  userMainId?: string;
  tokenOld: string;
  tokenNew: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
  concurrencyStamp?: string;
}
