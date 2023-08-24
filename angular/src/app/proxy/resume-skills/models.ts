import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetResumeSkillsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  resumeMainId?: string;
  computerExpertise?: string;
  computerExpertiseEtc?: string;
  chineseTypingSpeedMin?: number;
  chineseTypingSpeedMax?: number;
  chineseTypingCode?: string;
  englishTypingSpeedMin?: number;
  englishTypingSpeedMax?: number;
  professionalLicense?: string;
  professionalLicenseEtc?: string;
  workSkills?: string;
  workSkillsEtc?: string;
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

export interface ResumeSkillCreateDto {
  resumeMainId?: string;
  computerExpertise?: string;
  computerExpertiseEtc?: string;
  chineseTypingSpeed: number;
  chineseTypingCode: string;
  englishTypingSpeed: number;
  professionalLicense?: string;
  professionalLicenseEtc?: string;
  workSkills?: string;
  workSkillsEtc?: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface ResumeSkillDto extends FullAuditedEntityDto<string> {
  resumeMainId?: string;
  computerExpertise?: string;
  computerExpertiseEtc?: string;
  chineseTypingSpeed: number;
  chineseTypingCode: string;
  englishTypingSpeed: number;
  professionalLicense?: string;
  professionalLicenseEtc?: string;
  workSkills?: string;
  workSkillsEtc?: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface ResumeSkillExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface ResumeSkillUpdateDto {
  resumeMainId?: string;
  computerExpertise?: string;
  computerExpertiseEtc?: string;
  chineseTypingSpeed: number;
  chineseTypingCode: string;
  englishTypingSpeed: number;
  professionalLicense?: string;
  professionalLicenseEtc?: string;
  workSkills?: string;
  workSkillsEtc?: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}
