import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CompanyJobWorkIdentityCreateDto {
  companyMainId?: string;
  companyJobId?: string;
  workIdentityCode: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface CompanyJobWorkIdentityDto extends FullAuditedEntityDto<string> {
  companyMainId?: string;
  companyJobId?: string;
  workIdentityCode: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
  concurrencyStamp?: string;
}

export interface CompanyJobWorkIdentityExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface CompanyJobWorkIdentityUpdateDto {
  companyMainId?: string;
  companyJobId?: string;
  workIdentityCode: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
  concurrencyStamp?: string;
}

export interface GetCompanyJobWorkIdentitiesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  companyMainId?: string;
  companyJobId?: string;
  workIdentityCode?: string;
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
