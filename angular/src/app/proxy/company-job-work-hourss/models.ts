import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CompanyJobWorkHoursCreateDto {
  companyMainId?: string;
  companyJobId?: string;
  workHoursCode: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface CompanyJobWorkHoursDto extends FullAuditedEntityDto<string> {
  companyMainId?: string;
  companyJobId?: string;
  workHoursCode: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
  concurrencyStamp?: string;
}

export interface CompanyJobWorkHoursExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface CompanyJobWorkHoursUpdateDto {
  companyMainId?: string;
  companyJobId?: string;
  workHoursCode: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
  concurrencyStamp?: string;
}

export interface GetCompanyJobWorkHourssInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  companyMainId?: string;
  companyJobId?: string;
  workHoursCode?: string;
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
