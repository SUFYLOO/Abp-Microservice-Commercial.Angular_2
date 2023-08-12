import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CompanyMainCreateDto {
  name: string;
  compilation?: string;
  officePhone?: string;
  faxPhone?: string;
  address?: string;
  principal?: string;
  allowSearch?: boolean;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  note?: string;
  sort?: number;
  status?: string;
  industryCategory: string;
  companyUrl?: string;
  capitalAmount?: number;
  hideCapitalAmount?: boolean;
  companyScaleCode: string;
  hidePrincipal?: boolean;
  companyUserId?: string;
  companyProfile?: string;
  businessPhilosophy?: string;
  operatingItems?: string;
  welfareSystem?: string;
  matching?: boolean;
  contractPass?: boolean;
}

export interface CompanyMainDto extends FullAuditedEntityDto<string> {
  name: string;
  compilation?: string;
  officePhone?: string;
  faxPhone?: string;
  address?: string;
  principal?: string;
  allowSearch?: boolean;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  note?: string;
  sort?: number;
  status?: string;
  industryCategory: string;
  companyUrl?: string;
  capitalAmount?: number;
  hideCapitalAmount?: boolean;
  companyScaleCode: string;
  hidePrincipal?: boolean;
  companyUserId?: string;
  companyProfile?: string;
  businessPhilosophy?: string;
  operatingItems?: string;
  welfareSystem?: string;
  matching?: boolean;
  contractPass?: boolean;
}

export interface CompanyMainExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface CompanyMainUpdateDto {
  name: string;
  compilation?: string;
  officePhone?: string;
  faxPhone?: string;
  address?: string;
  principal?: string;
  allowSearch?: boolean;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  note?: string;
  sort?: number;
  status?: string;
  industryCategory: string;
  companyUrl?: string;
  capitalAmount?: number;
  hideCapitalAmount?: boolean;
  companyScaleCode: string;
  hidePrincipal?: boolean;
  companyUserId?: string;
  companyProfile?: string;
  businessPhilosophy?: string;
  operatingItems?: string;
  welfareSystem?: string;
  matching?: boolean;
  contractPass?: boolean;
}

export interface GetCompanyMainsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  name?: string;
  compilation?: string;
  officePhone?: string;
  faxPhone?: string;
  address?: string;
  principal?: string;
  allowSearch?: boolean;
  extendedInformation?: string;
  dateAMin?: string;
  dateAMax?: string;
  dateDMin?: string;
  dateDMax?: string;
  note?: string;
  sortMin?: number;
  sortMax?: number;
  status?: string;
  industryCategory?: string;
  companyUrl?: string;
  capitalAmountMin?: number;
  capitalAmountMax?: number;
  hideCapitalAmount?: boolean;
  companyScaleCode?: string;
  hidePrincipal?: boolean;
  companyUserId?: string;
  companyProfile?: string;
  businessPhilosophy?: string;
  operatingItems?: string;
  welfareSystem?: string;
  matching?: boolean;
  contractPass?: boolean;
}
