import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetSystemColumnsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  systemTableId?: string;
  name?: string;
  isKey?: boolean;
  isSensitive?: boolean;
  needMask?: boolean;
  defaultValue?: string;
  checkCode?: boolean;
  related?: string;
  allowUpdate?: boolean;
  allowNull?: boolean;
  allowEmpty?: boolean;
  allowExport?: boolean;
  allowSort?: boolean;
  columnTypeCode?: string;
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

export interface SystemColumnCreateDto {
  systemTableId?: string;
  name: string;
  isKey: boolean;
  isSensitive: boolean;
  needMask: boolean;
  defaultValue?: string;
  checkCode: boolean;
  related?: string;
  allowUpdate: boolean;
  allowNull: boolean;
  allowEmpty: boolean;
  allowExport: boolean;
  allowSort: boolean;
  columnTypeCode: string;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}

export interface SystemColumnDto extends FullAuditedEntityDto<string> {
  systemTableId?: string;
  name: string;
  isKey: boolean;
  isSensitive: boolean;
  needMask: boolean;
  defaultValue?: string;
  checkCode: boolean;
  related?: string;
  allowUpdate: boolean;
  allowNull: boolean;
  allowEmpty: boolean;
  allowExport: boolean;
  allowSort: boolean;
  columnTypeCode: string;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}

export interface SystemColumnExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface SystemColumnUpdateDto {
  systemTableId?: string;
  name: string;
  isKey: boolean;
  isSensitive: boolean;
  needMask: boolean;
  defaultValue?: string;
  checkCode: boolean;
  related?: string;
  allowUpdate: boolean;
  allowNull: boolean;
  allowEmpty: boolean;
  allowExport: boolean;
  allowSort: boolean;
  columnTypeCode: string;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}
