import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetUserCompanyBindsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  userMainId?: string;
  companyMainId?: string;
  companyJobId?: string;
  companyInvitationsId?: string;
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

export interface UserCompanyBindCreateDto {
  userMainId?: string;
  companyMainId?: string;
  companyJobId?: string;
  companyInvitationsId?: string;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}

export interface UserCompanyBindDto extends FullAuditedEntityDto<string> {
  userMainId?: string;
  companyMainId?: string;
  companyJobId?: string;
  companyInvitationsId?: string;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}

export interface UserCompanyBindExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface UserCompanyBindUpdateDto {
  userMainId?: string;
  companyMainId?: string;
  companyJobId?: string;
  companyInvitationsId?: string;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}
