using Resume.App.Companys;
using Resume.App.Users;
using Resume.Permissions;
using Resume.UserAccountBinds;
using Resume.UserInfos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Resume.App.Controllers.App.Users
{
    [RemoteService]
    [Area("app")]
    [ControllerName("User")]
    [Route("api/app/users")]
    [Authorize(ResumePermissions.UserMains.Default)]
    public class UserController : AbpController, IUsersAppService
    {
        private readonly IUsersAppService _usersAppService;

        public UserController(IUsersAppService usersAppService)
        {
            _usersAppService = usersAppService;
        }

        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        [IgnoreAntiforgeryToken] // ©ø≤§≈Á√“ XSRF-TOKEN
        public virtual Task<RegisterDto> RegisterAsync(RegisterInput input)
        {
            return _usersAppService.RegisterAsync(input);
        }

        [HttpPost]
        [Route("SendUserVerify")]
        [AllowAnonymous]
        [IgnoreAntiforgeryToken] // ©ø≤§≈Á√“ XSRF-TOKEN
        [ProducesResponseType(typeof(SendUserVerifyDto), StatusCodes.Status200OK)]
        public virtual Task<ResultDto<SendUserVerifyDto>> SendUserVerifyAsync(SendUserVerifyInput input)
        {
            return _usersAppService.SendUserVerifyAsync(input);
        }

        [HttpPost]
        [Route("CheckUserVerify")]
        [AllowAnonymous]
        [IgnoreAntiforgeryToken] // ©ø≤§≈Á√“ XSRF-TOKEN
        public virtual Task<ResultDto> CheckUserVerifyAsync(CheckUserVerifyInput input)
        {
            return _usersAppService.CheckUserVerifyAsync(input);
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        [IgnoreAntiforgeryToken] // ©ø≤§≈Á√“ XSRF-TOKEN
        [ProducesResponseType(typeof(LoginDto), StatusCodes.Status200OK)]
        public virtual Task<ResultDto<LoginDto>> LoginAsync(LoginInput input)
        {
            return _usersAppService.LoginAsync(input);
        }

        [HttpPost]
        [Route("RefreshToken")]
        [AllowAnonymous]
        [IgnoreAntiforgeryToken] // ©ø≤§≈Á√“ XSRF-TOKEN
        [ProducesResponseType(typeof(LoginDto), StatusCodes.Status200OK)]
        public virtual Task<ResultDto<LoginDto>> RefreshTokenAsync(RefreshTokenInput input)
        {
            return _usersAppService.RefreshTokenAsync(input);
        }

        [HttpPost]
        [Route("LoginCookie")]
        [AllowAnonymous]
        [IgnoreAntiforgeryToken] // ©ø≤§≈Á√“ XSRF-TOKEN
        [ProducesResponseType(typeof(ClaimsPrincipal), StatusCodes.Status200OK)]
        public virtual  Task<ClaimsPrincipal> LoginCookieAsync(LoginInput input)
        {
            return _usersAppService.LoginCookieAsync(input);
        }

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
        [IgnoreAntiforgeryToken] // ©ø≤§≈Á√“ XSRF-TOKEN
        [ProducesResponseType(typeof(LoginDto), StatusCodes.Status200OK)]
        public virtual Task<ResultDto<LoginDto>> LoginBindAsync(LoginBindInput input)
        {
            return _usersAppService.LoginBindAsync(input);
        }

        [HttpPost]
        [Route("GetUserAccountBindList")]
        [ProducesResponseType(typeof(UserAccountBindDto), StatusCodes.Status200OK)]
        public virtual Task<ResultDto<List<UserAccountBindDto>>> GetUserAccountBindListAsync(UserAccountBindListInput input)
        {
            return _usersAppService.GetUserAccountBindListAsync(input);
        }

        [HttpPost]
        [Route("SaveUserAccountBind")]
        [ProducesResponseType(typeof(UserAccountBindDto), StatusCodes.Status200OK)]
        public virtual Task<ResultDto<UserAccountBindDto>> SaveUserAccountBindAsync(SaveUserAccountBindInput input)
        {
            return _usersAppService.SaveUserAccountBindAsync(input);
        }

        [HttpPost]
        [Route("DeleteUserAccountBind")]
        [ProducesResponseType(typeof(DeleteUserAccountBindDto), StatusCodes.Status200OK)]
        public virtual Task<ResultDto<DeleteUserAccountBindDto>> DeleteUserAccountBindAsync(DeleteUserAccountBindInput input)
        {
            return _usersAppService.DeleteUserAccountBindAsync(input);
        }

        [HttpPost]
        [Route("GetUserMains")]
        [ProducesResponseType(typeof(UserMainsDto), StatusCodes.Status200OK)]
        public virtual Task<ResultDto<UserMainsDto>> GetUserMainsAsync( UserMainsInput input)
        {
            return _usersAppService.GetUserMainsAsync(input);
        }

        [HttpPost]
        [Route("GetUserInfos")]
        [ProducesResponseType(typeof(UserInfosDto), StatusCodes.Status200OK)]
        public virtual Task<ResultDto<UserInfosDto>> GetUserInfosAsync(UserInfosInput input)
        {
            return _usersAppService.GetUserInfosAsync(input);
        }

        [HttpPost]
        [Route("SaveUserInfo")]
        [ProducesResponseType(typeof(UserInfosDto), StatusCodes.Status200OK)]
        public virtual Task<ResultDto<UserInfosDto>> SaveUserInfoAsync(UserInfoDto input)
        {
            return _usersAppService.SaveUserInfoAsync(input);
        }

        [HttpPost]
        [Route("SaveUserMainPasswordReset")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(SaveUserMainSingleValueDto), StatusCodes.Status200OK)]
        public virtual Task<ResultDto<SaveUserMainSingleValueDto>> SaveUserMainPasswordResetAsync(SaveUserMainSingleValueInput input)
        {
            return _usersAppService.SaveUserMainPasswordResetAsync(input);
        }

        [HttpPost]
        [Route("SaveUserMainColumnName")]
        //[AbpValidateAntiForgeryToken]
        [ProducesResponseType(typeof(SaveUserMainSingleValueDto), StatusCodes.Status200OK)]
        public virtual Task<ResultDto<SaveUserMainSingleValueDto>> SaveUserMainColumnNameAsync(SaveUserMainColumnNameInput input)
        {
            return _usersAppService.SaveUserMainColumnNameAsync(input);
        }

        [HttpPost]
        [Route("SaveUserMainName")]
        [ProducesResponseType(typeof(SaveUserMainSingleValueDto), StatusCodes.Status200OK)]
        public virtual Task<ResultDto<SaveUserMainSingleValueDto>> SaveUserMainNameAsync(SaveUserMainSingleValueInput input)
        {
            return _usersAppService.SaveUserMainNameAsync(input);
        }

        [HttpPost]
        [Route("SaveUserMainAnonymousName")]
        [ProducesResponseType(typeof(SaveUserMainSingleValueDto), StatusCodes.Status200OK)]
        public virtual Task<ResultDto<SaveUserMainSingleValueDto>> SaveUserMainAnonymousNameAsync(SaveUserMainSingleValueInput input)
        {
            return _usersAppService.SaveUserMainAnonymousNameAsync(input);
        }

        [HttpPost]
        [Route("SaveUserMainLoginAccountCode")]
        [ProducesResponseType(typeof(SaveUserMainSingleValueDto), StatusCodes.Status200OK)]
        public virtual Task<ResultDto<SaveUserMainSingleValueDto>> SaveUserMainLoginAccountCodeAsync(SaveUserMainSingleValueInput input)
        {
            return _usersAppService.SaveUserMainLoginAccountCodeAsync(input);
        }

        [HttpPost]
        [Route("SaveUserMainLoginMobilePhone")]
        [ProducesResponseType(typeof(SaveUserMainSingleValueDto), StatusCodes.Status200OK)]
        public virtual Task<ResultDto<SaveUserMainSingleValueDto>> SaveUserMainLoginMobilePhoneAsync(SaveUserMainSingleValueInput input)
        {
            return _usersAppService.SaveUserMainLoginMobilePhoneAsync(input);
        }

        [HttpPost]
        [Route("SaveUserMainLoginEmail")]
        [ProducesResponseType(typeof(SaveUserMainSingleValueDto), StatusCodes.Status200OK)]
        public virtual Task<ResultDto<SaveUserMainSingleValueDto>> SaveUserMainLoginEmailAsync(SaveUserMainSingleValueInput input)
        {
            return _usersAppService.SaveUserMainLoginEmailAsync(input);
        }

        [HttpPost]
        [Route("SaveUserMainLoginIdentityNo")]
        [ProducesResponseType(typeof(SaveUserMainSingleValueDto), StatusCodes.Status200OK)]
        public virtual Task<ResultDto<SaveUserMainSingleValueDto>> SaveUserMainLoginIdentityNoAsync(SaveUserMainSingleValueInput input)
        {
            return _usersAppService.SaveUserMainLoginIdentityNoAsync(input);
        }

        [HttpPost]
        [Route("SaveUserMainPassword")]
        [ProducesResponseType(typeof(SaveUserMainSingleValueDto), StatusCodes.Status200OK)]
        public virtual Task<ResultDto<SaveUserMainSingleValueDto>> SaveUserMainPasswordAsync(SaveUserMainPasswordInput input)
        {
            return _usersAppService.SaveUserMainPasswordAsync(input);
        }

        [HttpPost]
        [Route("SaveUserMainSystemUserRoleKeys")]
        [ProducesResponseType(typeof(SaveUserMainSingleValueDto), StatusCodes.Status200OK)]
        public virtual Task<ResultDto<SaveUserMainSingleValueDto>> SaveUserMainSystemUserRoleKeysAsync(SaveUserMainSingleValueInput input)
        {
            return _usersAppService.SaveUserMainSystemUserRoleKeysAsync(input);
        }

        [HttpPost]
        [Route("SaveUserMainAllowSearch")]
        [ProducesResponseType(typeof(SaveUserMainSingleValueDto), StatusCodes.Status200OK)]
        public virtual Task<ResultDto<SaveUserMainSingleValueDto>> SaveUserMainAllowSearchAsync(SaveUserMainSingleValueInput input)
        {
            return _usersAppService.SaveUserMainAllowSearchAsync(input);
        }

        [HttpPost]
        [Route("SaveUserMainBirthDate")]
        [ProducesResponseType(typeof(SaveUserMainSingleValueDto), StatusCodes.Status200OK)]
        public virtual Task<ResultDto<SaveUserMainSingleValueDto>> SaveUserMainBirthDateAsync(SaveUserMainSingleValueInput input)
        {
            return _usersAppService.SaveUserMainBirthDateAsync(input);
        }

        [HttpPost]
        [Route("GetUserCompanyInvitationsList")]
        [ProducesResponseType(typeof(SaveUserMainSingleValueDto), StatusCodes.Status200OK)]
        public virtual Task<ResultDto<List<CompanyInvitationssDto>>> GetUserCompanyInvitationsListAsync(CompanyInvitationsListInput input)
        {
            return _usersAppService.GetUserCompanyInvitationsListAsync(input);
        }

        [HttpPost]
        [Route("SaveUserCompanyBind")]
        [ProducesResponseType(typeof(SaveUserMainSingleValueDto), StatusCodes.Status200OK)]
        public virtual Task<ResultDto<SaveUserCompanyBindDto>> SaveUserCompanyBindAsync(SaveUserCompanyBindInput input)
        {
            return _usersAppService.SaveUserCompanyBindAsync(input);
        }

        [HttpPost]
        [Route("DeleteUserCompanyBind")]
        [ProducesResponseType(typeof(DeleteUserCompanyBindDto), StatusCodes.Status200OK)]
        public virtual Task<ResultDto<DeleteUserCompanyBindDto>> DeleteUserCompanyBindAsync(DeleteUserCompanyBindInput input)
        {
            return _usersAppService.DeleteUserCompanyBindAsync(input);
        }

        [HttpPost]
        [Route("GetUserCompanyBindList")]
        [ProducesResponseType(typeof(UserCompanyBindListDto), StatusCodes.Status200OK)]
        public virtual Task<ResultDto<UserCompanyBindListDto>> GetUserCompanyBindListAsync(UserCompanyBindListInput input)
        {
            return _usersAppService.GetUserCompanyBindListAsync(input);
        }
    }
}