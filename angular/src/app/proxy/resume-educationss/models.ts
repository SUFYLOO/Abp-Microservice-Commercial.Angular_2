import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetResumeEducationssInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  resumeMainId?: string;
  educationLevelCode?: string;
  schoolCode?: string;
  schoolName?: string;
  night?: boolean;
  working?: boolean;
  majorDepartmentName?: string;
  majorDepartmentCategory?: string;
  minorDepartmentName?: string;
  minorDepartmentCategory?: string;
  graduationCode?: string;
  domestic?: boolean;
  countryCode?: string;
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

export interface ResumeEducationsCreateDto {
  resumeMainId?: string;
  educationLevelCode: string;
  schoolCode: string;
  schoolName: string;
  night: boolean;
  working: boolean;
  majorDepartmentName: string;
  majorDepartmentCategory: string;
  minorDepartmentName: string;
  minorDepartmentCategory: string;
  graduationCode: string;
  domestic: boolean;
  countryCode: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface ResumeEducationsDto extends FullAuditedEntityDto<string> {
  resumeMainId?: string;
  educationLevelCode: string;
  schoolCode: string;
  schoolName: string;
  night: boolean;
  working: boolean;
  majorDepartmentName: string;
  majorDepartmentCategory: string;
  minorDepartmentName: string;
  minorDepartmentCategory: string;
  graduationCode: string;
  domestic: boolean;
  countryCode: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface ResumeEducationsExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface ResumeEducationsUpdateDto {
  resumeMainId?: string;
  educationLevelCode: string;
  schoolCode: string;
  schoolName: string;
  night: boolean;
  working: boolean;
  majorDepartmentName: string;
  majorDepartmentCategory: string;
  minorDepartmentName: string;
  minorDepartmentCategory: string;
  graduationCode: string;
  domestic: boolean;
  countryCode: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}
