import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetResumeExperiencessInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  resumeMainId?: string;
  name?: string;
  workNatureCode?: string;
  hideCompanyName?: boolean;
  industryCategoryCode?: string;
  jobName?: string;
  jobType?: string;
  working?: boolean;
  workPlaceCode?: string;
  hideWorkSalary?: boolean;
  salaryPayTypeCode?: string;
  currencyTypeCode?: string;
  salary1Min?: number;
  salary1Max?: number;
  salary2Min?: number;
  salary2Max?: number;
  companyScaleCode?: string;
  companyManagementNumberCode?: string;
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

export interface ResumeExperiencesCreateDto {
  resumeMainId?: string;
  name: string;
  workNatureCode: string;
  hideCompanyName: boolean;
  industryCategoryCode: string;
  jobName: string;
  jobType?: string;
  working: boolean;
  workPlaceCode?: string;
  hideWorkSalary?: boolean;
  salaryPayTypeCode: string;
  currencyTypeCode: string;
  salary1?: number;
  salary2?: number;
  companyScaleCode: string;
  companyManagementNumberCode: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface ResumeExperiencesDto extends FullAuditedEntityDto<string> {
  resumeMainId?: string;
  name: string;
  workNatureCode: string;
  hideCompanyName: boolean;
  industryCategoryCode: string;
  jobName: string;
  jobType?: string;
  working: boolean;
  workPlaceCode?: string;
  hideWorkSalary?: boolean;
  salaryPayTypeCode: string;
  currencyTypeCode: string;
  salary1?: number;
  salary2?: number;
  companyScaleCode: string;
  companyManagementNumberCode: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface ResumeExperiencesExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface ResumeExperiencesUpdateDto {
  resumeMainId?: string;
  name: string;
  workNatureCode: string;
  hideCompanyName: boolean;
  industryCategoryCode: string;
  jobName: string;
  jobType?: string;
  working: boolean;
  workPlaceCode?: string;
  hideWorkSalary?: boolean;
  salaryPayTypeCode: string;
  currencyTypeCode: string;
  salary1?: number;
  salary2?: number;
  companyScaleCode: string;
  companyManagementNumberCode: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}
