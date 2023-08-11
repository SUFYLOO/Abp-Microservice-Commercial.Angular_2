import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetUserCompanyJobPairsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  userMainId?: string;
  name?: string;
  pairCondition?: string;
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

export interface UserCompanyJobPairCreateDto {
  userMainId?: string;
  name: string;
  pairCondition?: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status: string;
}

export interface UserCompanyJobPairDto extends FullAuditedEntityDto<string> {
  userMainId?: string;
  name: string;
  pairCondition?: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status: string;
  concurrencyStamp?: string;
}

export interface UserCompanyJobPairExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface UserCompanyJobPairUpdateDto {
  userMainId?: string;
  name: string;
  pairCondition?: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status: string;
  concurrencyStamp?: string;
}
