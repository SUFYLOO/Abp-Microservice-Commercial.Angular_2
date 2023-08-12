import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetSystemUserRolesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  name?: string;
  keysMin?: number;
  keysMax?: number;
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

export interface SystemUserRoleCreateDto {
  name: string;
  keys: number;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface SystemUserRoleDto extends FullAuditedEntityDto<string> {
  name: string;
  keys: number;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface SystemUserRoleExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface SystemUserRoleUpdateDto {
  name: string;
  keys: number;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}
