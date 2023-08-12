import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetShareDefaultsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  groupCode?: string;
  key1?: string;
  key2?: string;
  key3?: string;
  name?: string;
  fieldKey?: string;
  fieldValue?: string;
  columnTypeCode?: string;
  formTypeCode?: string;
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

export interface ShareDefaultCreateDto {
  groupCode: string;
  key1?: string;
  key2?: string;
  key3?: string;
  name: string;
  fieldKey: string;
  fieldValue?: string;
  columnTypeCode: string;
  formTypeCode: string;
  systemUse: boolean;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface ShareDefaultDto extends FullAuditedEntityDto<string> {
  groupCode: string;
  key1?: string;
  key2?: string;
  key3?: string;
  name: string;
  fieldKey: string;
  fieldValue?: string;
  columnTypeCode: string;
  formTypeCode: string;
  systemUse: boolean;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface ShareDefaultExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface ShareDefaultUpdateDto {
  groupCode: string;
  key1?: string;
  key2?: string;
  key3?: string;
  name: string;
  fieldKey: string;
  fieldValue?: string;
  columnTypeCode: string;
  formTypeCode: string;
  systemUse: boolean;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}
