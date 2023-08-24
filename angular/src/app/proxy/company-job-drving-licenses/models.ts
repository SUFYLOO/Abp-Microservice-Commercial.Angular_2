import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CompanyJobDrvingLicenseCreateDto {
  companyMainId?: string;
  companyJobId?: string;
  drvingLicenseCode: string;
  haveDrvingLicense?: boolean;
  haveCar?: boolean;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface CompanyJobDrvingLicenseDto extends FullAuditedEntityDto<string> {
  companyMainId?: string;
  companyJobId?: string;
  drvingLicenseCode: string;
  haveDrvingLicense?: boolean;
  haveCar?: boolean;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
  concurrencyStamp?: string;
}

export interface CompanyJobDrvingLicenseExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface CompanyJobDrvingLicenseUpdateDto {
  companyMainId?: string;
  companyJobId?: string;
  drvingLicenseCode: string;
  haveDrvingLicense?: boolean;
  haveCar?: boolean;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
  concurrencyStamp?: string;
}

export interface GetCompanyJobDrvingLicensesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  companyMainId?: string;
  companyJobId?: string;
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
