import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetUserVerifysInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  verifyId?: string;
  verifyCode?: string;
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

export interface UserVerifyCreateDto {
  verifyId: string;
  verifyCode: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface UserVerifyDto extends FullAuditedEntityDto<number> {
  verifyId: string;
  verifyCode: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface UserVerifyExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface UserVerifyUpdateDto {
  verifyId: string;
  verifyCode: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}
