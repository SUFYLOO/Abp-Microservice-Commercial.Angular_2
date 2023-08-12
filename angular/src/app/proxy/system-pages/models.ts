import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetSystemPagesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  typeCode?: string;
  filePath?: string;
  fileName?: string;
  fileTitle?: string;
  systemUserRoleKeys?: string;
  parentCode?: string;
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

export interface SystemPageCreateDto {
  typeCode: string;
  filePath?: string;
  fileName?: string;
  fileTitle?: string;
  systemUserRoleKeys: string;
  parentCode: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface SystemPageDto extends FullAuditedEntityDto<string> {
  typeCode: string;
  filePath?: string;
  fileName?: string;
  fileTitle?: string;
  systemUserRoleKeys: string;
  parentCode: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface SystemPageExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface SystemPageUpdateDto {
  typeCode: string;
  filePath?: string;
  fileName?: string;
  fileTitle?: string;
  systemUserRoleKeys: string;
  parentCode: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}
