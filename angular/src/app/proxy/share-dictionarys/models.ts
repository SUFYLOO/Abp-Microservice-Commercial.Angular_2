import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetShareDictionarysInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  shareLanguageId?: string;
  shareTagId?: string;
  key1?: string;
  key2?: string;
  key3?: string;
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

export interface ShareDictionaryCreateDto {
  shareLanguageId?: string;
  shareTagId?: string;
  key1?: string;
  key2?: string;
  key3?: string;
  name: string;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}

export interface ShareDictionaryDto extends FullAuditedEntityDto<string> {
  shareLanguageId?: string;
  shareTagId?: string;
  key1?: string;
  key2?: string;
  key3?: string;
  name: string;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}

export interface ShareDictionaryExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface ShareDictionaryUpdateDto {
  shareLanguageId?: string;
  shareTagId?: string;
  key1?: string;
  key2?: string;
  key3?: string;
  name: string;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}
