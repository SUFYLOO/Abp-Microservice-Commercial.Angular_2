import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetSystemTablesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  name?: string;
  allowInsert?: boolean;
  allowUpdate?: boolean;
  allowDelete?: boolean;
  allowSelect?: boolean;
  allowExport?: boolean;
  allowImport?: boolean;
  allowPage?: boolean;
  allowSort?: boolean;
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

export interface SystemTableCreateDto {
  name: string;
  allowInsert: boolean;
  allowUpdate: boolean;
  allowDelete: boolean;
  allowSelect: boolean;
  allowExport: boolean;
  allowImport: boolean;
  allowPage: boolean;
  allowSort: boolean;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}

export interface SystemTableDto extends FullAuditedEntityDto<string> {
  name: string;
  allowInsert: boolean;
  allowUpdate: boolean;
  allowDelete: boolean;
  allowSelect: boolean;
  allowExport: boolean;
  allowImport: boolean;
  allowPage: boolean;
  allowSort: boolean;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}

export interface SystemTableExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface SystemTableUpdateDto {
  name: string;
  allowInsert: boolean;
  allowUpdate: boolean;
  allowDelete: boolean;
  allowSelect: boolean;
  allowExport: boolean;
  allowImport: boolean;
  allowPage: boolean;
  allowSort: boolean;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}
