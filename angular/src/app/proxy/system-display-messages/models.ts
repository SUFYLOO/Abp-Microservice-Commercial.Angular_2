import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetSystemDisplayMessagesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  displayTypeCode?: string;
  titleContents?: string;
  contents?: string;
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

export interface SystemDisplayMessageCreateDto {
  displayTypeCode: string;
  titleContents: string;
  contents: string;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}

export interface SystemDisplayMessageDto extends FullAuditedEntityDto<string> {
  displayTypeCode: string;
  titleContents: string;
  contents: string;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}

export interface SystemDisplayMessageExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface SystemDisplayMessageUpdateDto {
  displayTypeCode: string;
  titleContents: string;
  contents: string;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}
