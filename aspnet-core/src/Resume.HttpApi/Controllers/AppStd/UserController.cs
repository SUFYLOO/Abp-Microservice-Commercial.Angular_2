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
using Resume.Permissions;
using Microsoft.AspNetCore.Authorization;
using Resume.App.Companys;
using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.AntiForgery;
using Resume.UserInfos;
using Resume.UserAccountBinds;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Volo.Abp.Security.Claims;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Http;

namespace Resume.App.Controllers.AppStd.Users
{
    [RemoteService]
    [Area("app")]
    [ControllerName("User")]
    [Route("api-std/app/users")]
    [Authorize(ResumePermissions.UserMains.Default)]
    public class UserController : AbpController
    {
        private readonly IUsersAppService _usersAppService;

        public UserController(IUsersAppService usersAppService)
        {
            _usersAppService = usersAppService;
        }

        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        public virtual async Task<RegisterDto> RegisterAsync(RegisterInput input)
        {
            return await _usersAppService.RegisterAsync(input);
        }

        [HttpPost]
        [Route("SendUserVerify")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(CheckUserVerifyDto), StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> SendUserVerifyAsync(SendUserVerifyInput input)
        {
            var Result = await _usersAppService.SendUserVerifyAsync(input);
            var ResultCheck = Result.Check;
            var RseultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(RseultMessage);
        }

        [HttpPost]
        [Route("CheckUserVerify")]
        [AllowAnonymous]
        public virtual async Task<ResultDto> CheckUserVerifyAsync(CheckUserVerifyInput input)
        {
            return await _usersAppService.CheckUserVerifyAsync(input);
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(LoginDto), StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> LoginAsync(LoginInput input)
        {
            var Result = await _usersAppService.LoginAsync(input);
            var ResultCheck = Result.Check;
            var RseultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(RseultMessage);
        }

        [HttpPost]
        [Route("RefreshToken")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(LoginDto), StatusCodes.Status200OK)]

        public virtual async Task<IActionResult> RefreshTokenAsync(RefreshTokenInput input)
        {
            var Result = await _usersAppService.RefreshTokenAsync(input);
            var ResultCheck= Result.Check;
            var RseultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(RseultMessage);
        }

        

        [HttpPost]
        [Route("LoginCookie")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ClaimsPrincipal), StatusCodes.Status200OK)]
        public virtual Task<ClaimsPrincipal> LoginCookieAsync(LoginInput input)
        {
            return _usersAppService.LoginCookieAsync(input);
        }

        /// <summary>
        /// ±ßÂI³B²z
        /// </summary>
        //[HttpPost]
        //[Route("LoginCookie")]
        //[AllowAnonymous]
        //public virtual async Task<IActionResult> LoginCookie1Async(LoginInput input)
        //{
        //    var principal = await _usersAppService.LoginCookieAsync(input);
        //    await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, principal);

        //    return Redirect("/");
        //}

        [HttpPost]
        [Route("LoginBind")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(LoginDto), StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> LoginBindAsync(LoginBindInput input)
        {
            var Result = await _usersAppService.LoginBindAsync(input);
            var ResultCheck = Result.Check;
            var RseultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(RseultMessage);
        }

        [HttpPost]
        [Route("GetUserAccountBindList")]
        [ProducesResponseType(typeof(UserAccountBindDto), StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> GetUserAccountBindListAsync(UserAccountBindListInput input)
        {
            var Result = await _usersAppService.GetUserAccountBindListAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) :¡@BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("SaveUserAccountBind")]
        [ProducesResponseType(typeof(UserAccountBindDto), StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> SaveUserAccountBindAsync(SaveUserAccountBindInput input)
        {
            var Result = await _usersAppService.SaveUserAccountBindAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("DeleteUserAccountBind")]
        [ProducesResponseType(typeof(DeleteUserAccountBindDto), StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> DeleteUserAccountBindAsync(DeleteUserAccountBindInput input)
        {
            var Result = await _usersAppService.DeleteUserAccountBindAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("GetUserMains")]
        [ProducesResponseType(typeof(UserMainsDto), StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> GetUserMainsAsync(UserMainsInput input)
        {
            var Result = await _usersAppService.GetUserMainsAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage); 
        }

        [HttpPost]
        [Route("GetUserInfos")]
        [ProducesResponseType(typeof(UserInfosDto), StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> GetUserInfosAsync(UserInfosInput input)
        {
           var Result = await _usersAppService.GetUserInfosAsync(input);
           var ResultCheck = Result.Check;
           var ResultMessage = Result.Messages;

           return ResultCheck ? Ok (Result.Data) : BadRequest(ResultMessage);

        }

        [HttpPost]
        [Route("SaveUserInfo")]
        [ProducesResponseType(typeof(UserInfosDto), StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> SaveUserInfoAsync(UserInfoDto input)
        {
            var Result = await _usersAppService.SaveUserInfoAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("SaveUserMainPasswordReset")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(SaveUserMainSingleValueDto), StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> SaveUserMainPasswordResetAsync(SaveUserMainSingleValueInput input)
        {
            var Result = await _usersAppService.SaveUserMainPasswordResetAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("SaveUserMainColumnName")]
        [ProducesResponseType(typeof(SaveUserMainSingleValueDto), StatusCodes.Status200OK)]
        //[AbpValidateAntiForgeryToken]
        public virtual async Task<IActionResult> SaveUserMainColumnNameAsync(SaveUserMainColumnNameInput input)
        {
            var Result = await _usersAppService.SaveUserMainColumnNameAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("SaveUserMainName")]
        [ProducesResponseType(typeof(SaveUserMainSingleValueDto), StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> SaveUserMainNameAsync(SaveUserMainSingleValueInput input)
        {
            var Result = await _usersAppService.SaveUserMainNameAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);

        }

        [HttpPost]
        [Route("SaveUserMainAnonymousName")]
        [ProducesResponseType(typeof(SaveUserMainSingleValueDto), StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> SaveUserMainAnonymousNameAsync(SaveUserMainSingleValueInput input)
        {
            var Result = await _usersAppService.SaveUserMainAnonymousNameAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("SaveUserMainLoginAccountCode")]
        [ProducesResponseType(typeof(SaveUserMainSingleValueDto), StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> SaveUserMainLoginAccountCodeAsync(SaveUserMainSingleValueInput input)
        {
            var Result = await _usersAppService.SaveUserMainLoginAccountCodeAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("SaveUserMainLoginMobilePhone")]
        [ProducesResponseType(typeof(SaveUserMainSingleValueDto), StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> SaveUserMainLoginMobilePhoneAsync(SaveUserMainSingleValueInput input)
        {
            var Result = await _usersAppService.SaveUserMainLoginMobilePhoneAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage); 
        }

        [HttpPost]
        [Route("SaveUserMainLoginEmail")]
        [ProducesResponseType(typeof(SaveUserMainSingleValueDto), StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> SaveUserMainLoginEmailAsync(SaveUserMainSingleValueInput input)
        {
            var Result = await _usersAppService.SaveUserMainLoginEmailAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("SaveUserMainLoginIdentityNo")]
        [ProducesResponseType(typeof(SaveUserMainSingleValueDto), StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> SaveUserMainLoginIdentityNoAsync(SaveUserMainSingleValueInput input)
        {
            var Result = await _usersAppService.SaveUserMainLoginIdentityNoAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

            [HttpPost]
        [Route("SaveUserMainPassword")]
        [ProducesResponseType(typeof(SaveUserMainSingleValueDto), StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> SaveUserMainPasswordAsync(SaveUserMainPasswordInput input)
        {
            var Result = await _usersAppService.SaveUserMainPasswordAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("SaveUserMainSystemUserRoleKeys")]
        [ProducesResponseType(typeof(SaveUserMainSingleValueDto), StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> SaveUserMainSystemUserRoleKeysAsync(SaveUserMainSingleValueInput input)
        {
            var Result = await _usersAppService.SaveUserMainSystemUserRoleKeysAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("SaveUserMainAllowSearch")]
        [ProducesResponseType(typeof(SaveUserMainSingleValueDto), StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> SaveUserMainAllowSearchAsync(SaveUserMainSingleValueInput input)
        {
            var Result = await _usersAppService.SaveUserMainAllowSearchAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(ResultMessage) : BadRequest(ResultMessage);

        }

        [HttpPost]
        [Route("SaveUserMainBirthDate")]
        [ProducesResponseType(typeof(SaveUserMainSingleValueDto), StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> SaveUserMainBirthDateAsync(SaveUserMainSingleValueInput input)
        {
            var Result = await _usersAppService.SaveUserMainBirthDateAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(ResultMessage) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("GetUserCompanyInvitationsList")]
        [ProducesResponseType(typeof(SaveUserMainSingleValueDto), StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> GetUserCompanyInvitationsListAsync(CompanyInvitationsListInput input)
        {
            var Result = await _usersAppService.GetUserCompanyInvitationsListAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(ResultCheck) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("SaveUserCompanyBind")]
        [ProducesResponseType(typeof(SaveUserMainSingleValueDto), StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> SaveUserCompanyBindAsync(SaveUserCompanyBindInput input)
        {
            var Result = await _usersAppService.SaveUserCompanyBindAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(ResultCheck): BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("DeleteUserCompanyBind")]
        [ProducesResponseType(typeof(DeleteUserCompanyBindDto), StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> DeleteUserCompanyBindAsync(DeleteUserCompanyBindInput input)
        {
            var Result = await _usersAppService.DeleteUserCompanyBindAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(ResultCheck) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("GetUserCompanyBindList")]
        [ProducesResponseType(typeof(UserCompanyBindListDto), StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> GetUserCompanyBindListAsync(UserCompanyBindListInput input)
        {
            var Result = await _usersAppService.GetUserCompanyBindListAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(ResultCheck) : BadRequest(ResultMessage);
        }
    }
}