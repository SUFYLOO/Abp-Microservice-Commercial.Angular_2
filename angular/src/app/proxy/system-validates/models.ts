import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetSystemValidatesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  param?: string;
  dateOpenMin?: string;
  dateOpenMax?: string;
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

export interface SystemValidateCreateDto {
  param: string;
  dateOpen: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface SystemValidateDto extends FullAuditedEntityDto<string> {
  param: string;
  dateOpen: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface SystemValidateExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface SystemValidateUpdateDto {
  param: string;
  dateOpen: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}
