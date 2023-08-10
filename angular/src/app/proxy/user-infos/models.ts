import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetUserInfosInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  userMainId?: string;
  nameC?: string;
  nameE?: string;
  identityNo?: string;
  birthDateMin?: string;
  birthDateMax?: string;
  sexCode?: string;
  bloodCode?: string;
  placeOfBirthCode?: string;
  passportNo?: string;
  nationalityCode?: string;
  residenceNo?: string;
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

export interface UserInfoCreateDto {
  userMainId?: string;
  nameC: string;
  nameE?: string;
  identityNo?: string;
  birthDate?: string;
  sexCode?: string;
  bloodCode?: string;
  placeOfBirthCode?: string;
  passportNo?: string;
  nationalityCode?: string;
  residenceNo?: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status: string;
}

export interface UserInfoDto extends FullAuditedEntityDto<string> {
  userMainId?: string;
  nameC: string;
  nameE?: string;
  identityNo?: string;
  birthDate?: string;
  sexCode?: string;
  bloodCode?: string;
  placeOfBirthCode?: string;
  passportNo?: string;
  nationalityCode?: string;
  residenceNo?: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status: string;
  concurrencyStamp?: string;
}

export interface UserInfoExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface UserInfoUpdateDto {
  userMainId?: string;
  nameC: string;
  nameE?: string;
  identityNo?: string;
  birthDate?: string;
  sexCode?: string;
  bloodCode?: string;
  placeOfBirthCode?: string;
  passportNo?: string;
  nationalityCode?: string;
  residenceNo?: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status: string;
  concurrencyStamp?: string;
}
