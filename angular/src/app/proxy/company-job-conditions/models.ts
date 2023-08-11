import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CompanyJobConditionCreateDto {
  companyMainCode: string;
  companyJobCode: string;
  workExperienceYearCode: string;
  educationLevel?: string;
  majorDepartmentCategory?: string;
  languageCategory?: string;
  computerExpertise?: string;
  professionalLicense?: string;
  drvingLicense?: string;
  etcCondition?: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status: string;
}

export interface CompanyJobConditionDto extends FullAuditedEntityDto<string> {
  companyMainCode: string;
  companyJobCode: string;
  workExperienceYearCode: string;
  educationLevel?: string;
  majorDepartmentCategory?: string;
  languageCategory?: string;
  computerExpertise?: string;
  professionalLicense?: string;
  drvingLicense?: string;
  etcCondition?: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status: string;
  concurrencyStamp?: string;
}

export interface CompanyJobConditionExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface CompanyJobConditionUpdateDto {
  companyMainCode: string;
  companyJobCode: string;
  workExperienceYearCode: string;
  educationLevel?: string;
  majorDepartmentCategory?: string;
  languageCategory?: string;
  computerExpertise?: string;
  professionalLicense?: string;
  drvingLicense?: string;
  etcCondition?: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status: string;
  concurrencyStamp?: string;
}

export interface GetCompanyJobConditionsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  companyMainCode?: string;
  companyJobCode?: string;
  workExperienceYearCode?: string;
  educationLevel?: string;
  majorDepartmentCategory?: string;
  languageCategory?: string;
  computerExpertise?: string;
  professionalLicense?: string;
  drvingLicense?: string;
  etcCondition?: string;
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
