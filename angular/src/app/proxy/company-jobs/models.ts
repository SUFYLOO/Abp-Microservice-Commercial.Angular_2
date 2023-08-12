import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CompanyJobCreateDto {
  companyMainId?: string;
  name: string;
  jobTypeCode: string;
  jobOpen: boolean;
  mailTplId: string;
  smsTplId: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface CompanyJobDto extends FullAuditedEntityDto<string> {
  companyMainId?: string;
  name: string;
  jobTypeCode: string;
  jobOpen: boolean;
  mailTplId: string;
  smsTplId: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface CompanyJobExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface CompanyJobUpdateDto {
  companyMainId?: string;
  name: string;
  jobTypeCode: string;
  jobOpen: boolean;
  mailTplId: string;
  smsTplId: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface GetCompanyJobsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  companyMainId?: string;
  name?: string;
  jobTypeCode?: string;
  jobOpen?: boolean;
  mailTplId?: string;
  smsTplId?: string;
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
