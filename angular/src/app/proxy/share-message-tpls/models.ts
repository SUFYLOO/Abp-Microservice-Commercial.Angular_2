import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetShareMessageTplsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  key1?: string;
  key2?: string;
  key3?: string;
  name?: string;
  statement?: string;
  titleContents?: string;
  contentMail?: string;
  contentSMS?: string;
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

export interface ShareMessageTplCreateDto {
  key1?: string;
  key2?: string;
  key3: string;
  name: string;
  statement?: string;
  titleContents: string;
  contentMail?: string;
  contentSMS?: string;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}

export interface ShareMessageTplDto extends FullAuditedEntityDto<string> {
  key1?: string;
  key2?: string;
  key3: string;
  name: string;
  statement?: string;
  titleContents: string;
  contentMail?: string;
  contentSMS?: string;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}

export interface ShareMessageTplExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface ShareMessageTplUpdateDto {
  key1?: string;
  key2?: string;
  key3: string;
  name: string;
  statement?: string;
  titleContents: string;
  contentMail?: string;
  contentSMS?: string;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}
