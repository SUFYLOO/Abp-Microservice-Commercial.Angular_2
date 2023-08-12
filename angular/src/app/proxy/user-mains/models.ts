import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetUserMainsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  userId?: string;
  name?: string;
  anonymousName?: string;
  loginAccountCode?: string;
  loginMobilePhoneUpdate?: string;
  loginMobilePhone?: string;
  loginEmailUpdate?: string;
  loginEmail?: string;
  loginIdentityNo?: string;
  password?: string;
  systemUserRoleKeysMin?: number;
  systemUserRoleKeysMax?: number;
  allowSearch?: boolean;
  dateAMin?: string;
  dateAMax?: string;
  extendedInformation?: string;
  dateDMin?: string;
  dateDMax?: string;
  sortMin?: number;
  sortMax?: number;
  note?: string;
  status?: string;
  matching?: boolean;
}

export interface UserMainCreateDto {
  userId?: string;
  name: string;
  anonymousName?: string;
  loginAccountCode: string;
  loginMobilePhoneUpdate?: string;
  loginMobilePhone?: string;
  loginEmailUpdate?: string;
  loginEmail?: string;
  loginIdentityNo?: string;
  password: string;
  systemUserRoleKeys: number;
  allowSearch: boolean;
  dateA: string;
  extendedInformation?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
  matching?: boolean;
}

export interface UserMainDto extends FullAuditedEntityDto<string> {
  userId?: string;
  name: string;
  anonymousName?: string;
  loginAccountCode: string;
  loginMobilePhoneUpdate?: string;
  loginMobilePhone?: string;
  loginEmailUpdate?: string;
  loginEmail?: string;
  loginIdentityNo?: string;
  password: string;
  systemUserRoleKeys: number;
  allowSearch: boolean;
  dateA: string;
  extendedInformation?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
  matching?: boolean;
}

export interface UserMainExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface UserMainUpdateDto {
  userId?: string;
  name: string;
  anonymousName?: string;
  loginAccountCode: string;
  loginMobilePhoneUpdate?: string;
  loginMobilePhone?: string;
  loginEmailUpdate?: string;
  loginEmail?: string;
  loginIdentityNo?: string;
  password: string;
  systemUserRoleKeys: number;
  allowSearch: boolean;
  dateA: string;
  extendedInformation?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
  matching?: boolean;
}
