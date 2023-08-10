import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CompanyInvitationsCodeCreateDto {
  companyMainId?: string;
  companyJobId?: string;
  companyInvitationId: string;
  verifyId: string;
  verifyCode: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status: string;
}

export interface CompanyInvitationsCodeDto extends FullAuditedEntityDto<string> {
  companyMainId?: string;
  companyJobId?: string;
  companyInvitationId: string;
  verifyId: string;
  verifyCode: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status: string;
  concurrencyStamp?: string;
}

export interface CompanyInvitationsCodeExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface CompanyInvitationsCodeUpdateDto {
  companyMainId?: string;
  companyJobId?: string;
  companyInvitationId: string;
  verifyId: string;
  verifyCode: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status: string;
  concurrencyStamp?: string;
}

export interface GetCompanyInvitationsCodesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  companyMainId?: string;
  companyJobId?: string;
  companyInvitationId?: string;
  verifyId?: string;
  verifyCode?: string;
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
