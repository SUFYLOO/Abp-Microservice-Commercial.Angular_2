import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetShareUploadsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  key1?: string;
  key2?: string;
  key3?: string;
  uploadName?: string;
  serverName?: string;
  type?: string;
  sizeMin?: number;
  sizeMax?: number;
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

export interface ShareUploadCreateDto {
  key1?: string;
  key2?: string;
  key3?: string;
  uploadName: string;
  serverName: string;
  type: string;
  size: number;
  systemUse: boolean;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}

export interface ShareUploadDto extends FullAuditedEntityDto<string> {
  key1?: string;
  key2?: string;
  key3?: string;
  uploadName: string;
  serverName: string;
  type: string;
  size: number;
  systemUse: boolean;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}

export interface ShareUploadExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface ShareUploadUpdateDto {
  key1?: string;
  key2?: string;
  key3?: string;
  uploadName: string;
  serverName: string;
  type: string;
  size: number;
  systemUse: boolean;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}
