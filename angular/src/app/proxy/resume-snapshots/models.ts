import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetResumeSnapshotsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  userMainId?: string;
  resumeMainId?: string;
  companyMainId?: string;
  companyJobId?: string;
  snapshot?: string;
  userCompanyBindId?: string;
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

export interface ResumeSnapshotCreateDto {
  userMainId?: string;
  resumeMainId?: string;
  companyMainId?: string;
  companyJobId?: string;
  snapshot: string;
  userCompanyBindId?: string;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}

export interface ResumeSnapshotDto extends FullAuditedEntityDto<string> {
  userMainId?: string;
  resumeMainId?: string;
  companyMainId?: string;
  companyJobId?: string;
  snapshot: string;
  userCompanyBindId?: string;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}

export interface ResumeSnapshotExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface ResumeSnapshotUpdateDto {
  userMainId?: string;
  resumeMainId?: string;
  companyMainId?: string;
  companyJobId?: string;
  snapshot: string;
  userCompanyBindId?: string;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}
