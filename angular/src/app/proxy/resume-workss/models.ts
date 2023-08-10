import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetResumeWorkssInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  resumeMainId?: string;
  name?: string;
  link?: string;
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

export interface ResumeWorksCreateDto {
  resumeMainId?: string;
  name: string;
  link?: string;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}

export interface ResumeWorksDto extends FullAuditedEntityDto<string> {
  resumeMainId?: string;
  name: string;
  link?: string;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}

export interface ResumeWorksExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface ResumeWorksUpdateDto {
  resumeMainId?: string;
  name: string;
  link?: string;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}
