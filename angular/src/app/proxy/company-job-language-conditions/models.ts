import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CompanyJobLanguageConditionCreateDto {
  companyMainId?: string;
  companyJobId?: string;
  languageCategoryCode: string;
  levelSayCode: string;
  levelListenCode: string;
  levelReadCode: string;
  levelWriteCode: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface CompanyJobLanguageConditionDto extends FullAuditedEntityDto<string> {
  companyMainId?: string;
  companyJobId?: string;
  languageCategoryCode: string;
  levelSayCode: string;
  levelListenCode: string;
  levelReadCode: string;
  levelWriteCode: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface CompanyJobLanguageConditionExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface CompanyJobLanguageConditionUpdateDto {
  companyMainId?: string;
  companyJobId?: string;
  languageCategoryCode: string;
  levelSayCode: string;
  levelListenCode: string;
  levelReadCode: string;
  levelWriteCode: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface GetCompanyJobLanguageConditionsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  companyMainId?: string;
  companyJobId?: string;
  languageCategoryCode?: string;
  levelSayCode?: string;
  levelListenCode?: string;
  levelReadCode?: string;
  levelWriteCode?: string;
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
