import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CompanyJobApplicationMethodCreateDto {
  companyMainId?: string;
  companyJobId?: string;
  orgDept?: string;
  orgContactPerson?: string;
  orgContactMail?: string;
  toRespondDay?: number;
  toRespond?: boolean;
  systemSendResume?: boolean;
  displayMail?: boolean;
  telephone?: string;
  personally?: string;
  personallyAddress?: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status: string;
}

export interface CompanyJobApplicationMethodDto extends FullAuditedEntityDto<string> {
  companyMainId?: string;
  companyJobId?: string;
  orgDept?: string;
  orgContactPerson?: string;
  orgContactMail?: string;
  toRespondDay?: number;
  toRespond?: boolean;
  systemSendResume?: boolean;
  displayMail?: boolean;
  telephone?: string;
  personally?: string;
  personallyAddress?: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status: string;
  concurrencyStamp?: string;
}

export interface CompanyJobApplicationMethodExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface CompanyJobApplicationMethodUpdateDto {
  companyMainId?: string;
  companyJobId?: string;
  orgDept?: string;
  orgContactPerson?: string;
  orgContactMail?: string;
  toRespondDay?: number;
  toRespond?: boolean;
  systemSendResume?: boolean;
  displayMail?: boolean;
  telephone?: string;
  personally?: string;
  personallyAddress?: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status: string;
  concurrencyStamp?: string;
}

export interface GetCompanyJobApplicationMethodsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  companyMainId?: string;
  companyJobId?: string;
  orgDept?: string;
  orgContactPerson?: string;
  orgContactMail?: string;
  toRespondDayMin?: number;
  toRespondDayMax?: number;
  toRespond?: boolean;
  systemSendResume?: boolean;
  displayMail?: boolean;
  telephone?: string;
  personally?: string;
  personallyAddress?: string;
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
