import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetShareLanguagesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  name?: string;
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

export interface ShareLanguageCreateDto {
  name: string;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}

export interface ShareLanguageDto extends FullAuditedEntityDto<string> {
  name: string;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}

export interface ShareLanguageExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface ShareLanguageUpdateDto {
  name: string;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}
