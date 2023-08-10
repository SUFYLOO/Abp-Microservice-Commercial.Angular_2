import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetShareSendQueuesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  key1?: string;
  key2?: string;
  key3?: string;
  sendTypeCode?: string;
  fromAddr?: string;
  toAddr?: string;
  titleContents?: string;
  contents?: string;
  retryMin?: number;
  retryMax?: number;
  sucess?: boolean;
  suspend?: boolean;
  dateSendMin?: string;
  dateSendMax?: string;
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

export interface ShareSendQueueCreateDto {
  key1: string;
  key2: string;
  key3: string;
  sendTypeCode: string;
  fromAddr?: string;
  toAddr: string;
  titleContents?: string;
  contents: string;
  retry: number;
  sucess: boolean;
  suspend: boolean;
  dateSend: string;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}

export interface ShareSendQueueDto extends FullAuditedEntityDto<string> {
  key1: string;
  key2: string;
  key3: string;
  sendTypeCode: string;
  fromAddr?: string;
  toAddr: string;
  titleContents?: string;
  contents: string;
  retry: number;
  sucess: boolean;
  suspend: boolean;
  dateSend: string;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}

export interface ShareSendQueueExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface ShareSendQueueUpdateDto {
  key1: string;
  key2: string;
  key3: string;
  sendTypeCode: string;
  fromAddr?: string;
  toAddr: string;
  titleContents?: string;
  contents: string;
  retry: number;
  sucess: boolean;
  suspend: boolean;
  dateSend: string;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}
