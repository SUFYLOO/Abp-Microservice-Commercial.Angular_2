using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;
using Volo.Abp.Account;
using Resume.App.Resumes;
using Resume.CompanyMains;
using Resume.CompanyUsers;
using System.Collections.Generic;
using Resume.CompanyJobs;
using Resume.CompanyInvitationss;
using static Volo.Abp.Identity.Settings.IdentitySettingNames;
using Resume.CompanyJobContents;
using Resume.CompanyJobConditions;
using Resume.CompanyJobApplicationMethods;
using Resume.CompanyJobPays;
using Resume.App.Users;

namespace Resume.App.Companys
{
    public interface ICompanysAppService : IApplicationService
    {
        //公司基本資料管理：管理人員管理
        //公司職缺管理
        //求職者邀約(履歷)管理：複制連結、發送訊息、履歷檢視、郵件或簡訊記錄
        Task<List<CompanyMainsDto>> GetCompanyMainListAsync(CompanyMainListInput input);
        Task<CompanyMainsDto> GetCompanyMainAsync(CompanyMainInput input);
        Task<ResultDto<CompanyMainDto>> SaveCompanyMainAsync(CompanyMainDto input);
        Task<ResultDto<DeleteCompanyMainDto>> DeleteCompanyMainAsync(DeleteCompanyMainInput input);
        Task<ResultDto<List<CompanyUsersDto>>> GetCompanyUserListAsync(CompanyUserListInput input);
        Task<ResultDto<CompanyUsersDto>> GetCompanyUserAsync(CompanyUserInput input);
        Task<ResultDto<CompanyUsersDto>> InsertCompanyUserAsync(SaveCompanyUserInput input);
        Task<ResultDto<CompanyUsersDto>> UpdateCompanyUserAsync(UpdateCompanyUserInput input);
        Task<ResultDto<CompanyUsersDto>> SaveCompanyUserAsync(SaveCompanyUserInput input);
        Task<ResultDto<DeleteCompanyUserDto>> DeleteCompanyUserAsync(DeleteCompanyUserInput input);
        Task<ResultDto<List<CompanyJobsDto>>> GetCompanyJobListAsync(CompanyJobListInput input);
        Task<ResultDto<CompanyJobsDto>> GetCompanyJobAsync(CompanyJobInput input);
        Task<ResultDto<CompanyJobDto>> SaveCompanyJobAsync(CompanyJobDto input);
        Task<ResultDto<DeleteCompanyJobDto>> DeleteCompanyJobAsync(DeleteCompanyJobInput input);
        Task<ResultDto<List<UserResumeSnapshotsListDto>>> GetUserResumeSnapshotsListAsync(UserResumeSnapshotsListInput input);
        Task<ResultDto<List<CompanyInvitationssDto>>> GetCompanyInvitationsListAsync(CompanyInvitationsListInput input);
        Task<ResultDto<CompanyInvitationssDto>> GetCompanyInvitationsAsync(CompanyInvitationsInput input);
        Task<ResultDto<CompanyInvitationssDto>> SaveCompanyInvitationsAsync(CompanyInvitationsDto input);
        Task<ResultDto<DeleteCompanyInvitationsAsyncDto>> DeleteCompanyInvitationsAsync(DeleteCompanyInvitationsInput input);
        Task<ResultDto<GenerateLinkCompanyInvitationsDto>> GenerateLinkCompanyInvitationsAsync(GenerateLinkCompanyInvitationsInput input);
        Task<ResultDto<CompanyInvitationssDto>> SendCompanyInvitationsAsync(SendCompanyInvitationsInput input);
        Task<UpdateCompanyMainDto> UpdateCompanyMainAsync(UpdateCompanyMainInput input);
        Task<ResultDto> UpdateCompanyMainCheckAsync(UpdateCompanyMainInput input);
        Task<UpdateCompanyMainCompanyProfileDto> UpdateCompanyMainCompanyProfileAsync(UpdateCompanyMainCompanyProfileInput input);
        Task<ResultDto> UpdateCompanyMainCompanyProfileCheckAsync(UpdateCompanyMainCompanyProfileInput input);
        Task<UpdateCompanyMainBusinessPhilosophyDto> UpdateCompanyMainBusinessPhilosophyAsync(UpdateCompanyMainBusinessPhilosophyInput input);
        Task<ResultDto> UpdateCompanyMainBusinessPhilosophyCheckAsync(UpdateCompanyMainBusinessPhilosophyInput input);
        Task<UpdateCompanyMainOperatingItemsDto> UpdateCompanyMainOperatingItemsAsync(UpdateCompanyMainOperatingItemsInput input);
        Task<ResultDto> UpdateCompanyMainOperatingItemsCheckAsync(UpdateCompanyMainOperatingItemsInput input);
        Task<UpdateCompanyMainWelfareSystemDto> UpdateCompanyMainWelfareSystemAsync(UpdateCompanyMainWelfareSystemInput input);
        Task<ResultDto> UpdateCompanyMainWelfareSystemCheckAsync(UpdateCompanyMainWelfareSystemInput input);
        Task<RegisterDto> RegisterAsync(RegisterInput input);
        Task<ResultDto> RegisterCheckAsync(RegisterInput input);
        Task<ResultDto> CheckUserVerifyAsync(CheckUserVerifyInput input);
        Task<List<LoginInfoDto>> GetLoginInfoAsync(LoginInput input);
        Task<LoginDto> LoginAsync(LoginInput input);
        Task<SaveCompanyJobContentDto> SaveCompanyJobContentAsync (SaveCompanyJobContentInput input);
        Task<ResultDto> SaveCompanyJobContentCheckAsync(SaveCompanyJobContentInput input);
        Task<SaveCompanyJobConditionDto> SaveCompanyJobConditionAsync(SaveCompanyJobConditionInput input);
        Task<ResultDto> SaveCompanyJobConditionCheckAsync(SaveCompanyJobConditionInput input);
        Task<SaveCompanyJobApplicationMethodDto> SaveCompanyJobApplicationMethodAsync(SaveCompanyJobApplicationMethodInput input);
        Task<ResultDto> SaveCompanyJobApplicationMethodCheckAsync(SaveCompanyJobApplicationMethodInput input);
        Task<CompanyJobContentsDto> GetCompanyJobContentAsync(CompanyJobContentInput input);
        Task<CompanyJobConditionsDto> GetCompanyJobConditionAsync(CompanyJobConditionInput input);
        Task<CompanyJobApplicationMethodsDto> GetCompanyJobApplicationMethodAsync(CompanyJobApplicationMethodInput input);
        Task<UpdateCompanyJobDateDto> UpdateCompanyJobDateAsync(UpdateCompanyJobDateInput input);
        Task<SaveCompanyJobPayDto> SaveCompanyJobPayAsync(SaveCompanyJobPayInput input);
        Task<ResultDto> SaveCompanyJobPayCheckAsync(SaveCompanyJobPayInput input);
        Task<CompanysJobDto> GetCompanyJobsAsync(CompanyJobsInput input);
        Task<List<CompanysJobDto>> GetCompanyJobsListAsync(CompanyJobsInput input);
        Task<UpdateCompanyJobOpenDto> UpdateCompanyJobOpenAsync(UpdateCompanyJobOpenInput input);
        Task<ResultDto> UpdateCompanyJobOpenCheckAsync(UpdateCompanyJobOpenInput input);
    }

    public interface ICompanysStdAppService : IApplicationService
    {
        

    }
}