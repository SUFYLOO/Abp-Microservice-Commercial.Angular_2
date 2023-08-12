import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetResumeRecommendersInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  resumeMainId?: string;
  name?: string;
  companyName?: string;
  jobName?: string;
  mobilePhone?: string;
  officePhone?: string;
  email?: string;
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

export interface ResumeRecommenderCreateDto {
  resumeMainId?: string;
  name: string;
  companyName?: string;
  jobName?: string;
  mobilePhone?: string;
  officePhone?: string;
  email?: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface ResumeRecommenderDto extends FullAuditedEntityDto<string> {
  resumeMainId?: string;
  name: string;
  companyName?: string;
  jobName?: string;
  mobilePhone?: string;
  officePhone?: string;
  email?: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface ResumeRecommenderExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface ResumeRecommenderUpdateDto {
  resumeMainId?: string;
  name: string;
  companyName?: string;
  jobName?: string;
  mobilePhone?: string;
  officePhone?: string;
  email?: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}
