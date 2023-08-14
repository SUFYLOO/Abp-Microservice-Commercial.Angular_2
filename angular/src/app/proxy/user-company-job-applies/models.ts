import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetUserCompanyJobAppliesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  userMainId?: string;
  companyJobId?: string;
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

export interface UserCompanyJobApplyCreateDto {
  userMainId?: string;
  companyJobId?: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface UserCompanyJobApplyDto extends FullAuditedEntityDto<string> {
  userMainId?: string;
  companyJobId?: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface UserCompanyJobApplyExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface UserCompanyJobApplyUpdateDto {
  userMainId?: string;
  companyJobId?: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}
