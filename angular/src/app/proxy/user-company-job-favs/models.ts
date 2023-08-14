import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetUserCompanyJobFavsInput extends PagedAndSortedResultRequestDto {
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

export interface UserCompanyJobFavCreateDto {
  userMainId?: string;
  companyJobId?: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface UserCompanyJobFavDto extends FullAuditedEntityDto<string> {
  userMainId?: string;
  companyJobId?: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface UserCompanyJobFavExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface UserCompanyJobFavUpdateDto {
  userMainId?: string;
  companyJobId?: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}
