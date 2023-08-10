import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CompanyInvitationsCreateDto {
  companyMainId?: string;
  companyJobId?: string;
  openAllJob: boolean;
  userMainId?: string;
  userMainName?: string;
  userMainLoginMobilePhone?: string;
  userMainLoginEmail?: string;
  userMainLoginIdentityNo?: string;
  sendTypeCode: string;
  sendStatusCode: string;
  resumeFlowStageCode: string;
  isRead: boolean;
  userCompanyBindId?: string;
  resumeSnapshotId?: string;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}

export interface CompanyInvitationsDto extends FullAuditedEntityDto<string> {
  companyMainId?: string;
  companyJobId?: string;
  openAllJob: boolean;
  userMainId?: string;
  userMainName?: string;
  userMainLoginMobilePhone?: string;
  userMainLoginEmail?: string;
  userMainLoginIdentityNo?: string;
  sendTypeCode: string;
  sendStatusCode: string;
  resumeFlowStageCode: string;
  isRead: boolean;
  userCompanyBindId?: string;
  resumeSnapshotId?: string;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}

export interface CompanyInvitationsExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface CompanyInvitationsUpdateDto {
  companyMainId?: string;
  companyJobId?: string;
  openAllJob: boolean;
  userMainId?: string;
  userMainName?: string;
  userMainLoginMobilePhone?: string;
  userMainLoginEmail?: string;
  userMainLoginIdentityNo?: string;
  sendTypeCode: string;
  sendStatusCode: string;
  resumeFlowStageCode: string;
  isRead: boolean;
  userCompanyBindId?: string;
  resumeSnapshotId?: string;
  extendedInformation?: string;
  dateA: string;
  dateD: string;
  sort: number;
  note?: string;
  status: string;
}

export interface GetCompanyInvitationssInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  companyMainId?: string;
  companyJobId?: string;
  openAllJob?: boolean;
  userMainId?: string;
  userMainName?: string;
  userMainLoginMobilePhone?: string;
  userMainLoginEmail?: string;
  userMainLoginIdentityNo?: string;
  sendTypeCode?: string;
  sendStatusCode?: string;
  resumeFlowStageCode?: string;
  isRead?: boolean;
  userCompanyBindId?: string;
  resumeSnapshotId?: string;
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
