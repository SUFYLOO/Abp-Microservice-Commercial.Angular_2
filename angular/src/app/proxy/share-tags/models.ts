import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetShareTagsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  colorCode?: string;
  key1?: string;
  key2?: string;
  key3?: string;
  name?: string;
  tagCategoryCode?: string;
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

export interface ShareTagCreateDto {
  colorCode: string;
  key1: string;
  key2: string;
  key3: string;
  name: string;
  tagCategoryCode: string;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}

export interface ShareTagDto extends FullAuditedEntityDto<string> {
  colorCode: string;
  key1: string;
  key2: string;
  key3: string;
  name: string;
  tagCategoryCode: string;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}

export interface ShareTagExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface ShareTagUpdateDto {
  colorCode: string;
  key1: string;
  key2: string;
  key3: string;
  name: string;
  tagCategoryCode: string;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}
