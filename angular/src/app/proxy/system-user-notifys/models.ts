import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetSystemUserNotifysInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  userMainId?: string;
  keyId?: string;
  keyName?: string;
  notifyTypeCode?: string;
  appName?: string;
  appCode?: string;
  titleContents?: string;
  contents?: string;
  isRead?: boolean;
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

export interface SystemUserNotifyCreateDto {
  userMainId: string;
  keyId?: string;
  keyName?: string;
  notifyTypeCode: string;
  appName: string;
  appCode: string;
  titleContents: string;
  contents: string;
  isRead: boolean;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}

export interface SystemUserNotifyDto extends FullAuditedEntityDto<string> {
  userMainId: string;
  keyId?: string;
  keyName?: string;
  notifyTypeCode: string;
  appName: string;
  appCode: string;
  titleContents: string;
  contents: string;
  isRead: boolean;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}

export interface SystemUserNotifyExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface SystemUserNotifyUpdateDto {
  userMainId: string;
  keyId?: string;
  keyName?: string;
  notifyTypeCode: string;
  appName: string;
  appCode: string;
  titleContents: string;
  contents: string;
  isRead: boolean;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}
