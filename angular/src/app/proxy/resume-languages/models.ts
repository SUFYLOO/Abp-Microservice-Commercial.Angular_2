import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetResumeLanguagesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  resumeMainId?: string;
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

export interface ResumeLanguageCreateDto {
  resumeMainId?: string;
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

export interface ResumeLanguageDto extends FullAuditedEntityDto<string> {
  resumeMainId?: string;
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

export interface ResumeLanguageExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface ResumeLanguageUpdateDto {
  resumeMainId?: string;
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
