import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetResumeExperiencesJobsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  resumeMainId?: string;
  resumeExperiencesId?: string;
  jobType?: string;
  yearMin?: number;
  yearMax?: number;
  monthMin?: number;
  monthMax?: number;
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

export interface ResumeExperiencesJobCreateDto {
  resumeMainId?: string;
  resumeExperiencesId?: string;
  jobType: string;
  year?: number;
  month?: number;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface ResumeExperiencesJobDto extends FullAuditedEntityDto<string> {
  resumeMainId?: string;
  resumeExperiencesId?: string;
  jobType: string;
  year?: number;
  month?: number;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
  concurrencyStamp?: string;
}

export interface ResumeExperiencesJobExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface ResumeExperiencesJobUpdateDto {
  resumeMainId?: string;
  resumeExperiencesId?: string;
  jobType: string;
  year?: number;
  month?: number;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
  concurrencyStamp?: string;
}
