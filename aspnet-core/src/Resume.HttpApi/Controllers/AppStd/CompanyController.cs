using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Content;
using Resume.Shared;
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
using Resume.CompanyJobApplicationMethods;
using Resume.CompanyJobConditions;


namespace Resume.App.Controllers.AppStd.Companys
{
    [RemoteService]
    [Area("app")]
    [ControllerName("Company")]
    [Route("api-std/app/companys")]
    [Authorize(ResumePermissions.CompanyMains.Default)]

    public class CompanyController : AbpController
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
        
        public virtual async Task<IActionResult> DeleteCompanyInvitationsAsync(DeleteCompanyInvitationsInput input)
        {
            var Result = await _CompanysAppService.DeleteCompanyInvitationsAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("DeleteCompanyJob")]
        [ProducesResponseType(typeof(CompanyJobsDto), StatusCodes.Status200OK)]
        
        public virtual  Task<CompanyJobsDto> DeleteCompanyJobAsync(CompanyJobInput input)
        {
            //var Result = await _CompanysAppService.DeleteCompanyJobAsync(input);
            //var ResultCheck = Result.Check;
            //var ResultMessage = Result.Messages;

            return  _CompanysAppService.DeleteCompanyJobAsync(input);
        }

        [HttpPost]
        [Route("DeleteCompanyMain")]
        [ProducesResponseType(typeof(CompanyMainsDto), StatusCodes.Status200OK)]
        
        public virtual async Task<CompanyMainsDto> DeleteCompanyMainAsync(DeleteCompanyMainInput input)
        {
            //var Result = await _CompanysAppService.DeleteCompanyMainAsync(input);
            //var ResultCheck = Result.Check;
            //var ResultMessage = Result.Messages;

            return await _CompanysAppService.DeleteCompanyMainAsync(input);
        }

        [HttpPost]
        [Route("DeleteCompanyUser")]
        public virtual async Task<DeleteCompanyUserDto> DeleteCompanyUserAsync(DeleteCompanyUserInput input)
        {
            return await _CompanysAppService.DeleteCompanyUserAsync(input);
        }

        [HttpPost]
        [Route("GetUserResumeSnapshotsList")]
        [ProducesResponseType(typeof(UserResumeSnapshotsListDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> GetUserResumeSnapshotsListAsync(UserResumeSnapshotsListInput input)
        {
            var Result = await _CompanysAppService.GetUserResumeSnapshotsListAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("GetCompanyInvitations")]
        [ProducesResponseType(typeof(CompanyInvitationssDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> GetCompanyInvitationsAsync(CompanyInvitationsInput input)
        {
            var Result = await _CompanysAppService.GetCompanyInvitationsAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("GetCompanyInvitationsList")]
        [ProducesResponseType(typeof(CompanyInvitationssDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> GetCompanyInvitationsListAsync(CompanyInvitationsListInput input)
        {
            var Result = await _CompanysAppService.GetCompanyInvitationsListAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("GetCompanyJob")]
        [ProducesResponseType(typeof(CompanyJobsDto), StatusCodes.Status200OK)]
        
        public virtual Task<CompanyJobsDto> GetCompanyJobAsync(CompanyJobInput input)
        {
            //var Result = await _CompanysAppService.GetCompanyJobAsync(input);
            //var ResultCheck = Result.Check;
            //var ResultMessage = Result.Messages;

            return _CompanysAppService.GetCompanyJobAsync(input); ;
        }

        [HttpPost]
        [Route("GetCompanyJobList")]
        [ProducesResponseType(typeof(CompanyJobsDto), StatusCodes.Status200OK)]
        
        public virtual async Task<List<CompanyJobsDto>> GetCompanyJobListAsync(CompanyJobListInput input)
        {
            //var Result = await _CompanysAppService.GetCompanyJobListAsync(input);
            //var ResultCheck = Result.Check;
            //var ResultMessage = Result.Messages;
            return await _CompanysAppService.GetCompanyJobListAsync(input);
        }

        [HttpPost]
        [Route("GetCompanyMain")]
        [ProducesResponseType(typeof(CompanyMainsDto), StatusCodes.Status200OK)]
        
        public virtual  Task<CompanyMainsDto> GetCompanyMainAsync(CompanyMainInput input)
        {
            return  _CompanysAppService.GetCompanyMainAsync(input);
        }

        [HttpPost]
        [Route("GetCompanyMainList")]
        public virtual  Task<List<CompanyMainsDto>> GetCompanyMainListAsync(CompanyMainListInput input)
        {
            return  _CompanysAppService.GetCompanyMainListAsync(input);
        }

        [HttpPost]
        [Route("GetCompanyUser")]
        public virtual async Task<CompanyUsersDto> GetCompanyUserAsync(CompanyUserInput input)
        {
            return await _CompanysAppService.GetCompanyUserAsync(input);
        }

        [HttpPost]
        [Route("GetCompanyUserList")]
        [ProducesResponseType(typeof(CompanyUsersDto), StatusCodes.Status200OK)]
        
        public virtual async Task<List<CompanyUsersDto>> GetCompanyUserListAsync(CompanyUserListInput input)
        {
            return await _CompanysAppService.GetCompanyUserListAsync(input); 
        }

        [HttpPost]
        [Route("SaveCompanyInvitations")]
        [ProducesResponseType(typeof(CompanyInvitationssDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> SaveCompanyInvitationsAsync(CompanyInvitationsDto input)
        {
            var Result = await _CompanysAppService.SaveCompanyInvitationsAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("SaveCompanyJob")]
        [ProducesResponseType(typeof(CompanyJobDto), StatusCodes.Status200OK)]
        
        public virtual  Task<CompanyJobDto> SaveCompanyJobAsync(SaveCompanyJobInput input)
        {
            //var Result = await _CompanysAppService.SaveCompanyJobAsync(input);
            //var ResultCheck = Result.Check;
            //var ResultMessage = Result.Messages;

            return _CompanysAppService.SaveCompanyJobAsync(input);
        }

        [HttpPost]
        [Route("SaveCompanyMain")]
        [ProducesResponseType(typeof(CompanyMainDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> SaveCompanyMainAsync(CompanyMainDto input)
        {
            var Result = await _CompanysAppService.SaveCompanyMainAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("InsertCompanyUser")]
        public virtual async Task<CompanyUsersDto> InsertCompanyUserAsync(SaveCompanyUserInput input)
        {
            return await _CompanysAppService.InsertCompanyUserAsync(input);
        }

        [HttpPost]
        [Route("UpdateCompanyUser")]
        public virtual async Task<CompanyUsersDto> UpdateCompanyUserAsync(SaveCompanyUserInput input)
        {
            return await _CompanysAppService.UpdateCompanyUserAsync(input);
        }

        [HttpPost]
        [Route("GenerateLinkCompanyInvitations")]
        [ProducesResponseType(typeof(GenerateLinkCompanyInvitationsDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> GenerateLinkCompanyInvitationsAsync(GenerateLinkCompanyInvitationsInput input)
        {
            var Result = await _CompanysAppService.GenerateLinkCompanyInvitationsAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("SendCompanyInvitations")]
        [ProducesResponseType(typeof(CompanyInvitationssDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> SendCompanyInvitationsAsync(SendCompanyInvitationsInput input)
        {
            var Result = await _CompanysAppService.SendCompanyInvitationsAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("UpdateCompanyMain")]
        [ProducesResponseType(typeof(UpdateCompanyMainDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result1Dto), StatusCodes.Status400BadRequest)]
        public virtual async Task<IActionResult> UpdateCompanyMainAsync(UpdateCompanyMainInput input)
        {
            var ResultMessage = await _CompanysAppService.UpdateCompanyMainCheckAsync(input);
            if (!ResultMessage.Check)
                return BadRequest(ResultMessage);
            return Ok(_CompanysAppService.UpdateCompanyMainAsync(input));
            
        }

        [HttpPost]
        [Route("UpdateCompanyMainCheck")]
        [ProducesResponseType(typeof(ResultDto), StatusCodes.Status200OK)]

        public virtual  Task<ResultDto> UpdateCompanyMainCheckAsync(UpdateCompanyMainInput input)
        {
            return  _CompanysAppService.UpdateCompanyMainCheckAsync(input);
        }

        [HttpPost]
        [Route("UpdateCompanyMainCompanyProfile")]
        [ProducesResponseType(typeof(UpdateCompanyMainCompanyProfileDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> UpdateCompanyMainCompanyProfileAsync(UpdateCompanyMainCompanyProfileInput input)
        {
            var ResultMessage = await _CompanysAppService.UpdateCompanyMainCompanyProfileCheckAsync(input);
            if (!ResultMessage.Check)
                return BadRequest(ResultMessage);
            return Ok(_CompanysAppService.UpdateCompanyMainCompanyProfileAsync(input));
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
        [ProducesResponseType(typeof(UpdateCompanyMainBusinessPhilosophyDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> UpdateCompanyMainBusinessPhilosophyAsync(UpdateCompanyMainBusinessPhilosophyInput input)
        {
            var ResultMessage = await _CompanysAppService.UpdateCompanyMainBusinessPhilosophyCheckAsync(input);
            if (!ResultMessage.Check)
                return BadRequest(ResultMessage);
            return Ok(_CompanysAppService.UpdateCompanyMainBusinessPhilosophyAsync(input));
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
        [ProducesResponseType(typeof(UpdateCompanyMainOperatingItemsDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> UpdateCompanyMainOperatingItemsAsync(UpdateCompanyMainOperatingItemsInput input)
        {

            var ResultMessage = await _CompanysAppService.UpdateCompanyMainOperatingItemsCheckAsync(input);
            if (!ResultMessage.Check)
                return BadRequest(ResultMessage);
            return Ok(_CompanysAppService.UpdateCompanyMainOperatingItemsAsync(input));
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
        [ProducesResponseType(typeof(UpdateCompanyMainWelfareSystemDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> UpdateCompanyMainWelfareSystemAsync(UpdateCompanyMainWelfareSystemInput input)
        {

            var ResultMessage = await _CompanysAppService.UpdateCompanyMainWelfareSystemCheckAsync(input);
            if (!ResultMessage.Check)
                return BadRequest(ResultMessage);
            return Ok(_CompanysAppService.UpdateCompanyMainWelfareSystemAsync(input));
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
        [IgnoreAntiforgeryToken] // �������� XSRF-TOKEN
        [Route("Register")]
        public virtual Task<RegisterDto> RegisterAsync(RegisterTenantInput input)
        {
            return _CompanysAppService.RegisterAsync(input);
        }

        [HttpPost]
        [AllowAnonymous]
        [IgnoreAntiforgeryToken] // �������� XSRF-TOKEN
        [Route("RegisterCheck")]
        public virtual Task<ResultDto> RegisterCheckAsync(RegisterTenantInput input)
        {
            return _CompanysAppService.RegisterCheckAsync(input);
        }

        [HttpPost]
        [AllowAnonymous]
        [IgnoreAntiforgeryToken] // �������� XSRF-TOKEN
        [Route("CheckUserVerify")]
        public virtual Task<ResultDto> CheckUserVerifyAsync(CheckUserVerifyInput input)
        {
            return _CompanysAppService.CheckUserVerifyAsync(input);
        }

        [HttpPost]
        [AllowAnonymous]
        [IgnoreAntiforgeryToken] // �������� XSRF-TOKEN
        [Route("GetLoginInfo")]
        public virtual Task<List<LoginInfoDto>> GetLoginInfoAsync(LoginInput input)
        {
            return _CompanysAppService.GetLoginInfoAsync(input);
        }

        [HttpPost]
        [AllowAnonymous]
        [IgnoreAntiforgeryToken] // �������� XSRF-TOKEN
        [Route("Login")]
        public virtual Task<LoginDto> LoginAsync(LoginInput input)
        {
            return _CompanysAppService.LoginAsync(input);
        }

        [HttpPost]
        [Route("SaveCompanyJobContent")]
        [ProducesResponseType(typeof(CompanyJobContentsDto), StatusCodes.Status200OK)]

        public virtual   Task<CompanyJobContentsDto> SaveCompanyJobContentAsync(SaveCompanyJobContentInput input)
        {
      
            return  _CompanysAppService.SaveCompanyJobContentAsync(input);
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
        [ProducesResponseType(typeof(CompanyJobConditionsDto), StatusCodes.Status200OK)]

        public virtual Task<CompanyJobConditionsDto> SaveCompanyJobConditionAsync(SaveCompanyJobConditionInput input)
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
        [ProducesResponseType(typeof(CompanyJobApplicationMethodsDto), StatusCodes.Status200OK)]

        public virtual Task<CompanyJobApplicationMethodsDto> SaveCompanyJobApplicationMethodAsync(SaveCompanyJobApplicationMethodInput input)
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
        [Route("GetCompanyJobContentList")]
        [ProducesResponseType(typeof(CompanyJobContentsDto), StatusCodes.Status200OK)]
        public virtual Task<List<CompanyJobContentsDto>> GetCompanyJobContentListAsync(CompanyJobContentInput input)
        {
            return _CompanysAppService.GetCompanyJobContentListAsync(input);
        }

        [HttpPost]
        [Route("GetCompanyJobContent")]
        [ProducesResponseType(typeof(CompanyJobContentsDto), StatusCodes.Status200OK)]

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
        [ProducesResponseType(typeof(CompanyJobsDto), StatusCodes.Status200OK)]

        public virtual Task<CompanyJobsDto> UpdateCompanyJobLaunchAsync(UpdateCompanyJobDateInput input)
        {
            return _CompanysAppService.UpdateCompanyJobDateAsync(input);
        }

        [HttpPost]
        [Route("UpdateCompanyJobDateCheck")]
        [ProducesResponseType(typeof(CompanyJobsDto), StatusCodes.Status200OK)]

        public virtual Task<ResultDto> UpdateCompanyJobDateCheckAsync(UpdateCompanyJobDateInput input)
        {
            return _CompanysAppService.UpdateCompanyJobDateCheckAsync(input);
        }

        [HttpPost]
        [Route("UpdateCompanyJobOpen")]
        [ProducesResponseType(typeof(CompanyJobsDto), StatusCodes.Status200OK)]

        public virtual Task<CompanyJobsDto> UpdateCompanyJobOpenAsync(UpdateCompanyJobOpenInput input)
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

        [HttpPost]
        [Route("SaveCompanyJobPay")]
        [ProducesResponseType(typeof(CompanyJobPaysDto), StatusCodes.Status200OK)]

        public virtual Task<CompanyJobPaysDto> SaveCompanyJobPay(SaveCompanyJobPayInput input)
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
        [Route("GetCompanyJobPay")]
        [ProducesResponseType(typeof(CompanyJobsDto), StatusCodes.Status200OK)]

        public virtual Task<CompanyJobPaysDto> GetCompanyJobPayAsync(CompanyJobPayInput input)
        {
            return _CompanysAppService.GetCompanyJobPayAsync(input);
        }
    }
}