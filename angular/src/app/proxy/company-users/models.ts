import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CompanyUserCreateDto {
  companyMainId?: string;
  userMainId?: string;
  jobName?: string;
  officePhone?: string;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
  matchingReceive?: boolean;
}

export interface CompanyUserDto extends FullAuditedEntityDto<string> {
  companyMainId?: string;
  userMainId?: string;
  jobName?: string;
  officePhone?: string;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
  matchingReceive?: boolean;
}

export interface CompanyUserExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface CompanyUserUpdateDto {
  companyMainId?: string;
  userMainId?: string;
  jobName?: string;
  officePhone?: string;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
  matchingReceive?: boolean;
}

export interface GetCompanyUsersInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  companyMainId?: string;
  userMainId?: string;
  jobName?: string;
  officePhone?: string;
  extendedInformation?: string;
  dateAMin?: string;
  dateAMax?: string;
  dateDMin?: string;
  dateDMax?: string;
  sortMin?: number;
  sortMax?: number;
  note?: string;
  status?: string;
  matchingReceive?: boolean;
}
