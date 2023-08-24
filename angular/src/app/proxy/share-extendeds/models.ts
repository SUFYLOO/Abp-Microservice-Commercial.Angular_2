import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetShareExtendedsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  key1?: string;
  key2?: string;
  key3?: string;
  key4?: string;
  key5?: string;
  keyId?: string;
  fieldValue?: string;
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

export interface ShareExtendedCreateDto {
  key1?: string;
  key2?: string;
  key3?: string;
  key4?: string;
  key5?: string;
  keyId?: string;
  fieldValue?: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface ShareExtendedDto extends FullAuditedEntityDto<string> {
  key1?: string;
  key2?: string;
  key3?: string;
  key4?: string;
  key5?: string;
  keyId?: string;
  fieldValue?: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface ShareExtendedExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface ShareExtendedUpdateDto {
  key1?: string;
  key2?: string;
  key3?: string;
  key4?: string;
  key5?: string;
  keyId?: string;
  fieldValue?: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}
