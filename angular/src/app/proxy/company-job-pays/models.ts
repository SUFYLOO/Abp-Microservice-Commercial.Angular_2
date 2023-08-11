import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CompanyJobPayCreateDto {
  companyMainId?: string;
  companyJobId?: string;
  jobPayTypeCode: string;
  dateReal?: string;
  isCancel?: boolean;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status: string;
}

export interface CompanyJobPayDto extends FullAuditedEntityDto<string> {
  companyMainId?: string;
  companyJobId?: string;
  jobPayTypeCode: string;
  dateReal?: string;
  isCancel?: boolean;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status: string;
  concurrencyStamp?: string;
}

export interface CompanyJobPayExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface CompanyJobPayUpdateDto {
  companyMainId?: string;
  companyJobId?: string;
  jobPayTypeCode: string;
  dateReal?: string;
  isCancel?: boolean;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status: string;
  concurrencyStamp?: string;
}

export interface GetCompanyJobPaysInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  companyMainId?: string;
  companyJobId?: string;
  jobPayTypeCode?: string;
  dateRealMin?: string;
  dateRealMax?: string;
  isCancel?: boolean;
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
