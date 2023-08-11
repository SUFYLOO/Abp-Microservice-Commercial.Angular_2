import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetShareCodesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  groupCode?: string;
  key1?: string;
  key2?: string;
  key3?: string;
  name?: string;
  column1?: string;
  column2?: string;
  column3?: string;
  systemUse?: boolean;
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

export interface ShareCodeCreateDto {
  groupCode: string;
  key1: string;
  key2: string;
  key3: string;
  name: string;
  column1?: string;
  column2?: string;
  column3?: string;
  systemUse: boolean;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}

export interface ShareCodeDto extends FullAuditedEntityDto<string> {
  groupCode: string;
  key1: string;
  key2: string;
  key3: string;
  name: string;
  column1?: string;
  column2?: string;
  column3?: string;
  systemUse: boolean;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}

export interface ShareCodeExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface ShareCodeUpdateDto {
  groupCode: string;
  key1: string;
  key2: string;
  key3: string;
  name: string;
  column1?: string;
  column2?: string;
  column3?: string;
  systemUse: boolean;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}
