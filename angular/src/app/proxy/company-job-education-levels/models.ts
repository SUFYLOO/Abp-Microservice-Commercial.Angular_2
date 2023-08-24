import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CompanyJobEducationLevelCreateDto {
  companyMainId?: string;
  companyJobId?: string;
  educationLevelCode: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface CompanyJobEducationLevelDto extends FullAuditedEntityDto<string> {
  companyMainId?: string;
  companyJobId?: string;
  educationLevelCode: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
  concurrencyStamp?: string;
}

export interface CompanyJobEducationLevelExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface CompanyJobEducationLevelUpdateDto {
  companyMainId?: string;
  companyJobId?: string;
  educationLevelCode: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
  concurrencyStamp?: string;
}

export interface GetCompanyJobEducationLevelsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  companyMainId?: string;
  companyJobId?: string;
  educationLevelCode?: string;
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
