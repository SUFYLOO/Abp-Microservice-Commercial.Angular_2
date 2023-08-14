import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CompanyJobPairCreateDto {
  companyMainId?: string;
  name: string;
  pairCondition?: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface CompanyJobPairDto extends FullAuditedEntityDto<string> {
  companyMainId?: string;
  name: string;
  pairCondition?: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface CompanyJobPairExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface CompanyJobPairUpdateDto {
  companyMainId?: string;
  name: string;
  pairCondition?: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface GetCompanyJobPairsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  companyMainId?: string;
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
