import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetResumeDrvingLicensesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  resumeMainId?: string;
  drvingLicenseCode?: string;
  haveDrvingLicense?: boolean;
  haveCar?: boolean;
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

export interface ResumeDrvingLicenseCreateDto {
  resumeMainId?: string;
  drvingLicenseCode: string;
  haveDrvingLicense: boolean;
  haveCar: boolean;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface ResumeDrvingLicenseDto extends FullAuditedEntityDto<string> {
  resumeMainId?: string;
  drvingLicenseCode: string;
  haveDrvingLicense: boolean;
  haveCar: boolean;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface ResumeDrvingLicenseExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface ResumeDrvingLicenseUpdateDto {
  resumeMainId?: string;
  drvingLicenseCode: string;
  haveDrvingLicense: boolean;
  haveCar: boolean;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}
