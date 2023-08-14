import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CompanyContractCreateDto {
  companyMainId?: string;
  planCode: string;
  pointsTotal?: number;
  pointsPay?: number;
  pointsGift?: number;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface CompanyContractDto extends FullAuditedEntityDto<string> {
  companyMainId?: string;
  planCode: string;
  pointsTotal?: number;
  pointsPay?: number;
  pointsGift?: number;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface CompanyContractExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface CompanyContractUpdateDto {
  companyMainId?: string;
  planCode: string;
  pointsTotal?: number;
  pointsPay?: number;
  pointsGift?: number;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface GetCompanyContractsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  companyMainId?: string;
  planCode?: string;
  pointsTotalMin?: number;
  pointsTotalMax?: number;
  pointsPayMin?: number;
  pointsPayMax?: number;
  pointsGiftMin?: number;
  pointsGiftMax?: number;
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
