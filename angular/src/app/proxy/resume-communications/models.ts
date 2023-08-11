import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetResumeCommunicationsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  resumeMainId?: string;
  communicationCategoryCode?: string;
  communicationValue?: string;
  main?: boolean;
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

export interface ResumeCommunicationCreateDto {
  resumeMainId?: string;
  communicationCategoryCode: string;
  communicationValue: string;
  main: boolean;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}

export interface ResumeCommunicationDto extends FullAuditedEntityDto<string> {
  resumeMainId?: string;
  communicationCategoryCode: string;
  communicationValue: string;
  main: boolean;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}

export interface ResumeCommunicationExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface ResumeCommunicationUpdateDto {
  resumeMainId?: string;
  communicationCategoryCode: string;
  communicationValue: string;
  main: boolean;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}
