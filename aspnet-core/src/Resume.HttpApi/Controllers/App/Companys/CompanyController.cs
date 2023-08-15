using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Content;
using Resume.Shared;
using Resume.App.Users;
using Resume.App;
using Resume.App.Resumes;
using Resume.App.Shares;
using System.Collections.Generic;
using Resume.App.Systems;
using Resume.App.Companys;
using Resume.Permissions;
using Microsoft.AspNetCore.Authorization;
using Resume.CompanyInvitationss;
using Resume.CompanyJobs;
using Resume.CompanyMains;
using Resume.CompanyUsers;
using static Volo.Abp.Identity.Settings.IdentitySettingNames;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Resume.CompanyJobContents;
using Resume.CompanyJobConditions;
using Resume.CompanyJobApplicationMethods;

namespace Resume.App.Controllers.App.Companys
{
    [RemoteService]
    [Area("app")]
    [ControllerName("Company")]
    [Route("api/app/companys")]
    [Authorize(ResumePermissions.CompanyMains.Default)]

    public class CompanyController : AbpController, ICompanysAppService
    {
        private readonly ICompanysAppService _CompanysAppService;

        public CompanyController(ICompanysAppService CompanysAppService)
        {
            _CompanysAppService = CompanysAppService;
        }

        //[HttpPost]
        //[Route("GetOrganizationUnits")]
        //public virtual Task<ResultDto<List<OrganizationUnit>>> GetOrganizationUnitsAsync(OrganizationUnitsInput input)
        //{
        //    return _CompanysAppService.GetOrganizationUnitsAsync(input);
        //}

        //[HttpPost]
        //[Route("GetRoles")]
        //public virtual async Task<ResultDto<List<IdentityRole>>> GetRolesAsync(RolesInput input)
        //{
        //    return _CompanysAppService.GetRolesAsync(input);
        //}

        [HttpPost]
        [Route("DeleteCompanyInvitations")]
        [ProducesResponseType(typeof(DeleteCompanyInvitationsAsyncDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResultDto<DeleteCompanyInvitationsAsyncDto>> DeleteCompanyInvitationsAsync(DeleteCompanyInvitationsInput input)
        {
          return  _CompanysAppService.DeleteCompanyInvitationsAsync(input);
        }

        [HttpPost]
        [Route("DeleteCompanyJob")]
        [ProducesResponseType(typeof(CompanyJobsDto), StatusCodes.Status200OK)]
        
        public virtual Task<CompanyJobsDto> DeleteCompanyJobAsync(DeleteCompanyJobInput input)
        {
            return _CompanysAppService.DeleteCompanyJobAsync(input);
        }

        [HttpPost]
        [Route("DeleteCompanyMain")]
        [ProducesResponseType(typeof(CompanyMainsDto), StatusCodes.Status200OK)]
        
        public virtual Task<CompanyMainsDto> DeleteCompanyMainAsync(DeleteCompanyMainInput input)
        {
            return _CompanysAppService.DeleteCompanyMainAsync(input);
        }

        [HttpPost]
        [Route("DeleteCompanyUser")]
        [ProducesResponseType(typeof(DeleteCompanyUserDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResultDto<DeleteCompanyUserDto>> DeleteCompanyUserAsync(DeleteCompanyUserInput input)
        {
            return _CompanysAppService.DeleteCompanyUserAsync(input);
        }

        [HttpPost]
        [Route("GetUserResumeSnapshotsList")]
        [ProducesResponseType(typeof(UserResumeSnapshotsListDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResultDto<List<UserResumeSnapshotsListDto>>> GetUserResumeSnapshotsListAsync(UserResumeSnapshotsListInput input)
        {
            return _CompanysAppService.GetUserResumeSnapshotsListAsync(input);
        }

        [HttpPost]
        [Route("GetCompanyInvitations")]
        [ProducesResponseType(typeof(CompanyInvitationssDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResultDto<CompanyInvitationssDto>> GetCompanyInvitationsAsync( CompanyInvitationsInput input)
        {
            return _CompanysAppService.GetCompanyInvitationsAsync(input);
        }

        [HttpPost]
        [Route("GetCompanyInvitationsList")]
        [ProducesResponseType(typeof(CompanyInvitationssDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResultDto<List<CompanyInvitationssDto>>> GetCompanyInvitationsListAsync( CompanyInvitationsListInput input)
        {
            return _CompanysAppService.GetCompanyInvitationsListAsync(input);
        }

        [HttpPost]
        [Route("GetCompanyJob")]
        [ProducesResponseType(typeof(CompanyJobsDto), StatusCodes.Status200OK)]
        
        public virtual Task<CompanyJobsDto> GetCompanyJobAsync( CompanyJobInput input)
        {
            return _CompanysAppService.GetCompanyJobAsync(input);
        }

        [HttpPost]
        [Route("GetCompanyJobList")]
        [ProducesResponseType(typeof(CompanyJobsDto), StatusCodes.Status200OK)]

        public virtual Task<List<CompanyJobsDto>> GetCompanyJobListAsync(CompanyJobListInput input)
        {
            return _CompanysAppService.GetCompanyJobListAsync(input);
        }

        [HttpPost]
        [Route("GetCompanyMain")]
        [ProducesResponseType(typeof(CompanyMainsDto), StatusCodes.Status200OK)]
        
        public virtual Task<CompanyMainsDto> GetCompanyMainAsync( CompanyMainInput input)
        {
            return _CompanysAppService.GetCompanyMainAsync(input);
        }

        [HttpPost]
        [Route("GetCompanyMainList")]
        [ProducesResponseType(typeof(CompanyMainsDto), StatusCodes.Status200OK)]
        
        public virtual Task<List<CompanyMainsDto>> GetCompanyMainListAsync( CompanyMainListInput input)
        {
            return _CompanysAppService.GetCompanyMainListAsync(input);
        }

        [HttpPost]
        [Route("GetCompanyUser")]        
        public virtual Task<CompanyUsersDto> GetCompanyUserAsync(CompanyUserInput input)
        {
            return _CompanysAppService.GetCompanyUserAsync(input);
        }

        [HttpPost]
        [Route("GetCompanyUserList")]       
        public virtual Task<List<CompanyUsersDto>> GetCompanyUserListAsync(CompanyUserListInput input)
        {
            return _CompanysAppService.GetCompanyUserListAsync(input);
        }

        [HttpPost]
        [Route("SaveCompanyInvitations")]
        [ProducesResponseType(typeof(CompanyInvitationssDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResultDto<CompanyInvitationssDto>> SaveCompanyInvitationsAsync(CompanyInvitationsDto input)
        {
            return _CompanysAppService.SaveCompanyInvitationsAsync(input);
        }

        [HttpPost]
        [Route("SaveCompanyJob")]
        [ProducesResponseType(typeof(CompanyJobDto), StatusCodes.Status200OK)]
        
        public virtual Task<CompanyJobDto> SaveCompanyJobAsync(SaveCompanyJobInput input)
        {
            return _CompanysAppService.SaveCompanyJobAsync(input);
        }

        [HttpPost]
        [Route("SaveCompanyMain")]
        [ProducesResponseType(typeof(CompanyMainDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResultDto<CompanyMainDto>> SaveCompanyMainAsync(CompanyMainDto input)
        {
            return _CompanysAppService.SaveCompanyMainAsync(input);
        }

        [HttpPost]
        [Route("InsertCompanyUser")]
        public virtual Task<CompanyUsersDto> InsertCompanyUserAsync(SaveCompanyUserInput input)
        {
            return _CompanysAppService.InsertCompanyUserAsync(input);
        }

        [HttpPost]
        [Route("UpdateCompanyUser")]
        [ProducesResponseType(typeof(CompanyUsersDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResultDto<CompanyUsersDto>> UpdateCompanyUserAsync(UpdateCompanyUserInput input)
        {
            return _CompanysAppService.UpdateCompanyUserAsync(input);
        }

        [HttpPost]
        [Route("SaveCompanyUser")]
        [ProducesResponseType(typeof(CompanyUsersDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResultDto<CompanyUsersDto>> SaveCompanyUserAsync(SaveCompanyUserInput input)
        {
            return _CompanysAppService.SaveCompanyUserAsync(input);
        }

        [HttpPost]
        [Route("GenerateLinkCompanyInvitations")]
        [ProducesResponseType(typeof(GenerateLinkCompanyInvitationsDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResultDto<GenerateLinkCompanyInvitationsDto>> GenerateLinkCompanyInvitationsAsync(GenerateLinkCompanyInvitationsInput input)
        {
            return _CompanysAppService.GenerateLinkCompanyInvitationsAsync(input);
        }

        [HttpPost]
        [Route("SendCompanyInvitations")]
        [ProducesResponseType(typeof(CompanyInvitationssDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResultDto<CompanyInvitationssDto>> SendCompanyInvitationsAsync(SendCompanyInvitationsInput input)
        {
            return _CompanysAppService.SendCompanyInvitationsAsync(input);
        }

        [HttpPost]
        [Route("UpdateCompanyMain")]
        [ProducesResponseType(typeof(UpdateCompanyMainDto), StatusCodes.Status200OK)]

        public virtual Task<CompanyMainsDto> UpdateCompanyMainAsync(UpdateCompanyMainInput input)
        {
            return _CompanysAppService.UpdateCompanyMainAsync(input);
        }

        [HttpPost]
        [Route("UpdateCompanyMainCheck")]
        [ProducesResponseType(typeof(ResultDto), StatusCodes.Status200OK)]

        public virtual Task<ResultDto> UpdateCompanyMainCheckAsync(UpdateCompanyMainInput input)
        {
            return _CompanysAppService.UpdateCompanyMainCheckAsync(input);
        }

        [HttpPost]
        [Route("UpdateCompanyMainCompanyProfile")]
        [ProducesResponseType(typeof(CompanyMainsDto), StatusCodes.Status200OK)]
        
        public virtual Task<CompanyMainsDto> UpdateCompanyMainCompanyProfileAsync(UpdateCompanyMainCompanyProfileInput input)
        {
            return _CompanysAppService.UpdateCompanyMainCompanyProfileAsync(input);
        }

        [HttpPost]
        [Route("UpdateCompanyMainCompanyProfileCheck")]
        [ProducesResponseType(typeof(ResultDto), StatusCodes.Status200OK)]

        public virtual Task<ResultDto> UpdateCompanyMainCompanyProfileCheckAsync(UpdateCompanyMainCompanyProfileInput input)
        {
            return _CompanysAppService.UpdateCompanyMainCompanyProfileCheckAsync(input);
        }

        [HttpPost]
        [Route("UpdateCompanyMainBusinessPhilosophy")]
        [ProducesResponseType(typeof(CompanyMainsDto), StatusCodes.Status200OK)]
        
        public virtual Task<CompanyMainsDto> UpdateCompanyMainBusinessPhilosophyAsync(UpdateCompanyMainBusinessPhilosophyInput input)
        {
            return _CompanysAppService.UpdateCompanyMainBusinessPhilosophyAsync(input);
        }

        [HttpPost]
        [Route("UpdateCompanyMainBusinessPhilosophyCheck")]
        [ProducesResponseType(typeof(ResultDto), StatusCodes.Status200OK)]

        public virtual Task<ResultDto> UpdateCompanyMainBusinessPhilosophyCheckAsync(UpdateCompanyMainBusinessPhilosophyInput input)
        {
            return _CompanysAppService.UpdateCompanyMainBusinessPhilosophyCheckAsync(input);
        }


        [HttpPost]
        [Route("UpdateCompanyMainOperatingItems")]
        [ProducesResponseType(typeof(CompanyMainsDto), StatusCodes.Status200OK)]
        
        public virtual Task<CompanyMainsDto> UpdateCompanyMainOperatingItemsAsync(UpdateCompanyMainOperatingItemsInput input)
        {
            return _CompanysAppService.UpdateCompanyMainOperatingItemsAsync(input);
        }

        [HttpPost]
        [Route("UpdateCompanyMainOperatingItemsCheck")]
        [ProducesResponseType(typeof(UpdateCompanyMainOperatingItemsDto), StatusCodes.Status200OK)]

        public virtual Task<ResultDto> UpdateCompanyMainOperatingItemsCheckAsync(UpdateCompanyMainOperatingItemsInput input)
        {
            return _CompanysAppService.UpdateCompanyMainOperatingItemsCheckAsync(input);
        }

        [HttpPost]
        [Route("UpdateCompanyMainWelfareSystem")]
        [ProducesResponseType(typeof(CompanyMainsDto), StatusCodes.Status200OK)]        
        public virtual Task<CompanyMainsDto> UpdateCompanyMainWelfareSystemAsync(UpdateCompanyMainWelfareSystemInput input)
        {
            return _CompanysAppService.UpdateCompanyMainWelfareSystemAsync(input);
        }

        [HttpPost]
        [Route("UpdateCompanyMainWelfareSystemCheck")]
        [ProducesResponseType(typeof(UpdateCompanyMainWelfareSystemDto), StatusCodes.Status200OK)]

        public virtual Task<ResultDto> UpdateCompanyMainWelfareSystemCheckAsync(UpdateCompanyMainWelfareSystemInput input)
        {
            return _CompanysAppService.UpdateCompanyMainWelfareSystemCheckAsync(input);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Register")]
        public virtual Task<RegisterDto> RegisterAsync(RegisterTenantInput input)
        {
            return _CompanysAppService.RegisterAsync(input);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("RegisterCheck")]
        public virtual Task<ResultDto> RegisterCheckAsync(RegisterTenantInput input)
        {
            return _CompanysAppService.RegisterCheckAsync(input);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("CheckUserVerify")]
        public virtual Task<ResultDto> CheckUserVerifyAsync(CheckUserVerifyInput input)
        {
            return _CompanysAppService.CheckUserVerifyAsync(input);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("GetLoginInfo")]
        public virtual Task<List<LoginInfoDto>> GetLoginInfoAsync(LoginInput input)
        {
            return _CompanysAppService.GetLoginInfoAsync(input);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]
        public virtual Task<LoginDto> LoginAsync(LoginInput input)
        {
            return _CompanysAppService.LoginAsync(input);
        }

        [HttpPost]
        [Route("SaveCompanyJobContent")]
        [ProducesResponseType(typeof(SaveCompanyJobContentDto), StatusCodes.Status200OK)]

        public virtual Task<SaveCompanyJobContentDto> SaveCompanyJobContentAsync(SaveCompanyJobContentInput input)
        {
            return _CompanysAppService.SaveCompanyJobContentAsync(input);
        }

        [HttpPost]
        [Route("SaveCompanyJobContentCheck")]
        [ProducesResponseType(typeof(ResultDto), StatusCodes.Status200OK)]

        public virtual Task<ResultDto> SaveCompanyJobContentCheckAsync(SaveCompanyJobContentInput input)
        {
            return _CompanysAppService.SaveCompanyJobContentCheckAsync(input);
        }


        [HttpPost]
        [Route("SaveCompanyJobCondition")]
        [ProducesResponseType(typeof(SaveCompanyJobConditionDto), StatusCodes.Status200OK)]

        public virtual Task<SaveCompanyJobConditionDto> SaveCompanyJobConditionAsync(SaveCompanyJobConditionInput input)
        {
            return _CompanysAppService.SaveCompanyJobConditionAsync(input);
        }

        [HttpPost]
        [Route("SaveCompanyJobConditionCheck")]
        [ProducesResponseType(typeof(ResultDto), StatusCodes.Status200OK)]

        public virtual Task<ResultDto> SaveCompanyJobConditionCheckAsync(SaveCompanyJobConditionInput input)
        {
            return _CompanysAppService.SaveCompanyJobConditionCheckAsync(input);
        }

        [HttpPost]
        [Route("SaveCompanyJobApplicationMethod")]
        [ProducesResponseType(typeof(SaveCompanyJobApplicationMethodDto), StatusCodes.Status200OK)]

        public virtual Task<SaveCompanyJobApplicationMethodDto> SaveCompanyJobApplicationMethodAsync(SaveCompanyJobApplicationMethodInput input)
        {
            return _CompanysAppService.SaveCompanyJobApplicationMethodAsync(input);
        }


        [HttpPost]
        [Route("SaveCompanyJobApplicationMethodCheck")]
        [ProducesResponseType(typeof(ResultDto), StatusCodes.Status200OK)]

        public virtual Task<ResultDto> SaveCompanyJobApplicationMethodCheckAsync(SaveCompanyJobApplicationMethodInput input)
        {
            return _CompanysAppService.SaveCompanyJobApplicationMethodCheckAsync(input);
        }

        [HttpPost]
        [Route("GetCompanyJobContent")]
        [ProducesResponseType(typeof(CompanyJobContentDto), StatusCodes.Status200OK)]

        public virtual Task<CompanyJobContentsDto> GetCompanyJobContentAsync(CompanyJobContentInput input)
        {
            return _CompanysAppService.GetCompanyJobContentAsync(input);
        }

        [HttpPost]
        [Route("GetCompanyJobCondition")]
        [ProducesResponseType(typeof(CompanyJobConditionsDto), StatusCodes.Status200OK)]

        public virtual Task<CompanyJobConditionsDto> GetCompanyJobConditionAsync(CompanyJobConditionInput input)
        {
            return _CompanysAppService.GetCompanyJobConditionAsync(input);
        }

        [HttpPost]
        [Route("GetCompanyJobApplicationMethod")]
        [ProducesResponseType(typeof(CompanyJobApplicationMethodDto), StatusCodes.Status200OK)]

        public virtual Task<CompanyJobApplicationMethodsDto> GetCompanyJobApplicationMethodAsync(CompanyJobApplicationMethodInput input)
        {
            return _CompanysAppService.GetCompanyJobApplicationMethodAsync(input);
        }

        [HttpPost]
        [Route("UpdateCompanyJobDate")]
        [ProducesResponseType(typeof(UpdateCompanyJobDateDto), StatusCodes.Status200OK)]

        public virtual Task<UpdateCompanyJobDateDto> UpdateCompanyJobDateAsync(UpdateCompanyJobDateInput input)
        {
            return _CompanysAppService.UpdateCompanyJobDateAsync(input);
        }

        [HttpPost]
        [Route("SaveCompanyJobPay")]
        [ProducesResponseType(typeof(SaveCompanyJobPayDto), StatusCodes.Status200OK)]

        public virtual Task<SaveCompanyJobPayDto> SaveCompanyJobPayAsync(SaveCompanyJobPayInput input)
        {
            return _CompanysAppService.SaveCompanyJobPayAsync(input);
        }

        [HttpPost]
        [Route("SaveCompanyJobPayCheck")]
        [ProducesResponseType(typeof(ResultDto), StatusCodes.Status200OK)]

        public virtual Task<ResultDto> SaveCompanyJobPayCheckAsync(SaveCompanyJobPayInput input)
        {
            return _CompanysAppService.SaveCompanyJobPayCheckAsync(input);
        }

        [HttpPost]
        [Route("GetCompanyJobs")]
        [ProducesResponseType(typeof(CompanysJobDto), StatusCodes.Status200OK)]

        public virtual Task<CompanysJobDto> GetCompanyJobsAsync(CompanyJobInput input)
        {
            return _CompanysAppService.GetCompanyJobsAsync(input);
        }

        [HttpPost]
        [Route("GetCompanyJobsList")]
        [ProducesResponseType(typeof(CompanyJobsDto), StatusCodes.Status200OK)]

        [HttpPost]
        [Route("UpdateCompanyJobOpen")]
        [ProducesResponseType(typeof(UpdateCompanyJobOpenDto), StatusCodes.Status200OK)]

        public virtual Task<UpdateCompanyJobOpenDto> UpdateCompanyJobOpenAsync(UpdateCompanyJobOpenInput input)
        {
            return _CompanysAppService.UpdateCompanyJobOpenAsync(input);
        }

        [HttpPost]
        [Route("UpdateCompanyJobOpenCheck")]
        [ProducesResponseType(typeof(ResultDto), StatusCodes.Status200OK)]

        public virtual Task<ResultDto> UpdateCompanyJobOpenCheckAsync(UpdateCompanyJobOpenInput input)
        {
            return _CompanysAppService.UpdateCompanyJobOpenCheckAsync(input);
        }

    }
}