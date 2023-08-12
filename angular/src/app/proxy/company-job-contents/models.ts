import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CompanyJobContentCreateDto {
  companyMainId?: string;
  companyJobId?: string;
  name: string;
  jobTypeCode: string;
  peopleRequiredNumber?: number;
  peopleRequiredNumberUnlimited?: boolean;
  jobType?: string;
  jobTypeContent?: string;
  salaryPayTypeCode: string;
  salaryMin?: number;
  salaryMax?: number;
  salaryUp?: boolean;
  workPlace?: string;
  workHours?: string;
  workHour?: string;
  workShift?: boolean;
  workRemoteAllow?: boolean;
  workRemoteTypeCode: string;
  workRemote?: string;
  workDifferentPlaces?: string;
  holidaySystemCode: string;
  workDayCode: string;
  workIdentityCode?: string;
  disabilityCategory?: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface CompanyJobContentDto extends FullAuditedEntityDto<string> {
  companyMainId?: string;
  companyJobId?: string;
  name: string;
  jobTypeCode: string;
  peopleRequiredNumber?: number;
  peopleRequiredNumberUnlimited?: boolean;
  jobType?: string;
  jobTypeContent?: string;
  salaryPayTypeCode: string;
  salaryMin?: number;
  salaryMax?: number;
  salaryUp?: boolean;
  workPlace?: string;
  workHours?: string;
  workHour?: string;
  workShift?: boolean;
  workRemoteAllow?: boolean;
  workRemoteTypeCode: string;
  workRemote?: string;
  workDifferentPlaces?: string;
  holidaySystemCode: string;
  workDayCode: string;
  workIdentityCode?: string;
  disabilityCategory?: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
  concurrencyStamp?: string;
}

export interface CompanyJobContentExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface CompanyJobContentUpdateDto {
  companyMainId?: string;
  companyJobId?: string;
  name: string;
  jobTypeCode: string;
  peopleRequiredNumber?: number;
  peopleRequiredNumberUnlimited?: boolean;
  jobType?: string;
  jobTypeContent?: string;
  salaryPayTypeCode: string;
  salaryMin?: number;
  salaryMax?: number;
  salaryUp?: boolean;
  workPlace?: string;
  workHours?: string;
  workHour?: string;
  workShift?: boolean;
  workRemoteAllow?: boolean;
  workRemoteTypeCode: string;
  workRemote?: string;
  workDifferentPlaces?: string;
  holidaySystemCode: string;
  workDayCode: string;
  workIdentityCode?: string;
  disabilityCategory?: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
  concurrencyStamp?: string;
}

export interface GetCompanyJobContentsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  companyMainId?: string;
  companyJobId?: string;
  name?: string;
  jobTypeCode?: string;
  peopleRequiredNumberMin?: number;
  peopleRequiredNumberMax?: number;
  peopleRequiredNumberUnlimited?: boolean;
  jobType?: string;
  jobTypeContent?: string;
  salaryPayTypeCode?: string;
  salaryMinMin?: number;
  salaryMinMax?: number;
  salaryMaxMin?: number;
  salaryMaxMax?: number;
  salaryUp?: boolean;
  workPlace?: string;
  workHours?: string;
  workHour?: string;
  workShift?: boolean;
  workRemoteAllow?: boolean;
  workRemoteTypeCode?: string;
  workRemote?: string;
  workDifferentPlaces?: string;
  holidaySystemCode?: string;
  workDayCode?: string;
  workIdentityCode?: string;
  disabilityCategory?: string;
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
