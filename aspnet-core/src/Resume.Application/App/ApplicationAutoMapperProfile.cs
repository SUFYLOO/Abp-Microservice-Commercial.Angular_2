using AutoMapper;
using AutoMapper.Internal.Mappers;
using Resume.App.Companys;
using Resume.App.Resumes;
using Resume.App.Shares;
using Resume.App.Users;
using Resume.CompanyInvitationss;
using Resume.CompanyJobApplicationMethods;
using Resume.CompanyJobConditions;
using Resume.CompanyJobContents;
using Resume.CompanyJobPays;
using Resume.CompanyJobs;
using Resume.CompanyMains;
using Resume.CompanyUsers;
using Resume.ResumeCommunications;
using Resume.ResumeDependentss;
using Resume.ResumeDrvingLicenses;
using Resume.ResumeEducationss;
using Resume.ResumeExperiencess;
using Resume.ResumeLanguages;
using Resume.ResumeMains;
using Resume.ResumeRecommenders;
using Resume.ResumeSkills;
using Resume.ResumeSnapshots;
using Resume.ResumeWorkss;
using Resume.ShareUploads;
using Resume.UserAccountBinds;
using Resume.UserInfos;
using Resume.UserMains;
using PayPalCheckoutSdk.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AutoMapper;
using Volo.Abp.ObjectMapping;
using static Resume.Permissions.ResumePermissions;
using Volo.Abp.Guids;

namespace Resume.App
{
    public class ApplicationAutoMapperProfile : ResumeApplicationAutoMapperProfile
    {
        public ApplicationAutoMapperProfile()
        {
            //所有對應檔，都是成雙成對的

            CreateMap<UserMain, UserMainsDto>();
            CreateMap<UserMainsDto, UserMain>();
            CreateMap<UserInfo, UserInfosDto>();
            CreateMap<UserInfosDto, UserInfo>();
            CreateMap<UserAccountBind, UserAccountBindDto>();
            CreateMap<UserAccountBindDto, UserAccountBind>();

            CreateMap<ResumeMain, UserInfo>();

            //CreateMap<ResumeMain, ResumeMain>()
            //    .Ignore(p => p.Id)
            //.ForMember(x => x.Id, map => map.Ignore());

            CreateMap<ResumeMain, ResumeMainsDto>();
            CreateMap<ResumeMainsDto, ResumeMain>();
            CreateMap<ResumeMainDto, ResumeMain>();
            CreateMap<ResumeSnapshot, ResumeSnapshotsDto>();
            CreateMap<ResumeSnapshotsDto, ResumeSnapshot>();
            CreateMap<ResumeCommunication, ResumeCommunicationsDto>();
            CreateMap<ResumeCommunicationsDto, ResumeCommunication>();
            CreateMap<ResumeCommunicationDto, ResumeCommunication>();
            CreateMap<ResumeDrvingLicense, ResumeDrvingLicensesDto>();
            CreateMap<ResumeDrvingLicensesDto, ResumeDrvingLicense>();
            CreateMap<ResumeDrvingLicenseDto, ResumeDrvingLicense>();
            CreateMap<ResumeRecommender, ResumeRecommendersDto>();
            CreateMap<ResumeRecommendersDto, ResumeRecommender>();
            CreateMap<ResumeRecommenderDto, ResumeRecommender>();
            CreateMap<ResumeLanguage, ResumeLanguagesDto>();
            CreateMap<ResumeLanguagesDto, ResumeLanguage>();
            CreateMap<ResumeLanguageDto, ResumeLanguage>();
            CreateMap<ResumeSkill, ResumeSkillsDto>();
            CreateMap<ResumeSkillsDto, ResumeSkill>();
            CreateMap<ResumeSkillDto, ResumeSkill>();
            CreateMap<ResumeDependents, ResumeDependentssDto>();
            CreateMap<ResumeDependentssDto, ResumeDependents>();
            CreateMap<ResumeDependentsDto, ResumeDependents>();
            CreateMap<ResumeEducations, ResumeEducationssDto>();
            CreateMap<ResumeEducationssDto, ResumeEducations>();
            CreateMap<ResumeEducationsDto, ResumeEducations>();
            CreateMap<ResumeExperiences, ResumeExperiencessDto>();
            CreateMap<ResumeExperiencessDto, ResumeExperiences>();
            CreateMap<ResumeExperiencesDto, ResumeExperiences>();
            CreateMap<ResumeWorks, ResumeWorkssDto>();
            CreateMap<ResumeWorkssDto, ResumeWorks>();
            CreateMap<ResumeWorksDto, ResumeWorks>();

            CreateMap<CompanyMain, CompanyMainsDto>();
            CreateMap<CompanyMainsDto, CompanyMain>();
            CreateMap<CompanyUser, CompanyUsersDto>();
            CreateMap<CompanyUsersDto, CompanyUser>();
            CreateMap<CompanyJob, CompanyJobsDto>();
            CreateMap<CompanyJobsDto, CompanyJob>();
            CreateMap<CompanyInvitations, CompanyInvitationssDto>();
            CreateMap<CompanyInvitationssDto, CompanyInvitations>();

            CreateMap<ShareUpload, ShareUploadsDto>();
            CreateMap<ShareUploadsDto, ShareUpload>();

            CreateMap<ShareUpload, SaveShareUploadDto>();

            CreateMap<CompanyMain, UpdateCompanyMainDto>();
            CreateMap<CompanyMain, UpdateCompanyMainCompanyProfileDto>();
            CreateMap<CompanyMain, UpdateCompanyMainBusinessPhilosophyDto>();
            CreateMap<CompanyMain, UpdateCompanyMainOperatingItemsDto>();
            CreateMap<CompanyMain, UpdateCompanyMainWelfareSystemDto>();

            CreateMap<SaveCompanyJobContentInput, CompanyJobContentDto>();
            CreateMap<SaveCompanyJobContentInput, CompanyJobContent>();
            CreateMap<CompanyJobContentDto, CompanyJobContent>();
            CreateMap<CompanyJobContent, SaveCompanyJobContentDto>();
            
            CreateMap<SaveCompanyJobConditionInput, CompanyJobCondition>();
            CreateMap<CompanyJobConditionDto, CompanyJobCondition>();
            CreateMap<CompanyJobCondition, SaveCompanyJobConditionDto>();

            CreateMap<SaveCompanyJobApplicationMethodInput, CompanyJobApplicationMethodDto>();
            CreateMap<CompanyJobApplicationMethodDto, CompanyJobApplicationMethod>();
            CreateMap<CompanyJobApplicationMethod, SaveCompanyJobApplicationMethodDto>();

            CreateMap<CompanyJobContentDto, CompanyJobContentsDto>();
            CreateMap<CompanyJobConditionDto, CompanyJobConditionsDto>();
            CreateMap<CompanyJobApplicationMethodDto, CompanyJobApplicationMethodsDto>();

            CreateMap<SaveCompanyJobPayInput, CompanyJobPayDto>();
            CreateMap<CompanyJobPayDto, CompanyJobPay>();
            CreateMap<CompanyJobPay, SaveCompanyJobPayDto>();

            CreateMap<CompanyJobDto, CompanysJobDto>();
            CreateMap<CompanyJob, UpdateCompanyJobOpenDto>();
            CreateMap<CompanyJob, CompanysJobDto>();

            //四個一組
            CreateMap<CompanyJobContent, CompanyJobContentDto>();
            CreateMap<SaveCompanyJobContentInput, CompanyJobContentCreateDto>();
            CreateMap<SaveCompanyJobContentInput, CompanyJobContentUpdateDto>();
            CreateMap<CompanyJobContentDto, SaveCompanyJobContentDto>();

            CreateMap<SaveResumeMainInput, ResumeMainDto>();
            CreateMap<ResumeMainDto, ResumeMain>();
            CreateMap<ResumeMain, SaveResumeMainDto>();

            CreateMap<SaveResumeMainInput, ResumeMainDto>();
            CreateMap<ResumeMainDto, ResumeMain>();
            CreateMap<ResumeMain, SaveResumeMainDto>();


        }
    }
}