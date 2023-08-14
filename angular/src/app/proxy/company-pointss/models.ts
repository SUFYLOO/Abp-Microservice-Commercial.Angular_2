import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CompanyPointsCreateDto {
  companyMainId?: string;
  companyPointsTypeCode?: string;
  points?: number;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface CompanyPointsDto extends FullAuditedEntityDto<string> {
  companyMainId?: string;
  companyPointsTypeCode?: string;
  points?: number;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface CompanyPointsExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface CompanyPointsUpdateDto {
  companyMainId?: string;
  companyPointsTypeCode?: string;
  points?: number;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface GetCompanyPointssInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  companyMainId?: string;
  companyPointsTypeCode?: string;
  pointsMin?: number;
  pointsMax?: number;
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
