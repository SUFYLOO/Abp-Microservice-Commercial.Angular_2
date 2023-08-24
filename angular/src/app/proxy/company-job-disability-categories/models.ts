import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CompanyJobDisabilityCategoryCreateDto {
  companyMainId?: string;
  companyJobId?: string;
  disabilityCategoryCode?: string;
  disabilityLevelCode?: string;
  disabilityCertifiedDocumentsNeed?: boolean;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface CompanyJobDisabilityCategoryDto extends FullAuditedEntityDto<string> {
  companyMainId?: string;
  companyJobId?: string;
  disabilityCategoryCode?: string;
  disabilityLevelCode?: string;
  disabilityCertifiedDocumentsNeed?: boolean;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
  concurrencyStamp?: string;
}

export interface CompanyJobDisabilityCategoryExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface CompanyJobDisabilityCategoryUpdateDto {
  companyMainId?: string;
  companyJobId?: string;
  disabilityCategoryCode?: string;
  disabilityLevelCode?: string;
  disabilityCertifiedDocumentsNeed?: boolean;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
  concurrencyStamp?: string;
}

export interface GetCompanyJobDisabilityCategoriesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  companyMainId?: string;
  companyJobId?: string;
  disabilityCategoryCode?: string;
  disabilityLevelCode?: string;
  disabilityCertifiedDocumentsNeed?: boolean;
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
