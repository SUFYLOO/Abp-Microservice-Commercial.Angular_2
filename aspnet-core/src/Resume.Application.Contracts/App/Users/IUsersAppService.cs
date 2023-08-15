using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;
using Volo.Abp.Account;
using Resume.App.Resumes;
using Resume.App.Companys;
using System.Collections.Generic;
using Resume.UserInfos;
using Resume.UserAccountBinds;
using System.Security.Claims;

namespace Resume.App.Users
{
    public interface IUsersAppService : IApplicationService
    {
        Task<RegisterDto> RegisterAsync(RegisterInput input);

        Task<ResultDto<SendUserVerifyDto>> SendUserVerifyAsync(SendUserVerifyInput input);

        Task<ResultDto> CheckUserVerifyAsync(CheckUserVerifyInput input);

        Task<ResultDto<LoginDto>> LoginAsync(LoginInput input);
        Task<ResultDto<LoginDto>> RefreshTokenAsync(RefreshTokenInput input);
        Task<ResultDto<LoginDto>> LoginBindAsync(LoginBindInput input);

        Task<ClaimsPrincipal> LoginCookieAsync(LoginInput input);
        Task<ResultDto<List<UserAccountBindDto>>> GetUserAccountBindListAsync(UserAccountBindListInput input);
        Task<ResultDto<UserAccountBindDto>> SaveUserAccountBindAsync(SaveUserAccountBindInput input);
        Task<ResultDto<DeleteUserAccountBindDto>> DeleteUserAccountBindAsync(DeleteUserAccountBindInput input);

        Task<ResultDto<UserMainsDto>> GetUserMainsAsync(UserMainsInput input);
        Task<ResultDto<UserInfosDto>> GetUserInfosAsync(UserInfosInput input);
        Task<ResultDto<UserInfosDto>> SaveUserInfoAsync(UserInfoDto input);
        Task<ResultDto<SaveUserMainSingleValueDto>> SaveUserMainPasswordResetAsync(SaveUserMainSingleValueInput input);
        Task<ResultDto<SaveUserMainSingleValueDto>> SaveUserMainColumnNameAsync(SaveUserMainColumnNameInput input);

        Task<ResultDto<SaveUserMainSingleValueDto>> SaveUserMainNameAsync(SaveUserMainSingleValueInput input);
        Task<ResultDto<SaveUserMainSingleValueDto>> SaveUserMainAnonymousNameAsync(SaveUserMainSingleValueInput input);
        Task<ResultDto<SaveUserMainSingleValueDto>> SaveUserMainLoginAccountCodeAsync(SaveUserMainSingleValueInput input);
        Task<ResultDto<SaveUserMainSingleValueDto>> SaveUserMainLoginMobilePhoneAsync(SaveUserMainSingleValueInput input);
        Task<ResultDto<SaveUserMainSingleValueDto>> SaveUserMainLoginEmailAsync(SaveUserMainSingleValueInput input);
        Task<ResultDto<SaveUserMainSingleValueDto>> SaveUserMainLoginIdentityNoAsync(SaveUserMainSingleValueInput input);
        Task<ResultDto<SaveUserMainSingleValueDto>> SaveUserMainPasswordAsync(SaveUserMainPasswordInput input);
        Task<ResultDto<SaveUserMainSingleValueDto>> SaveUserMainSystemUserRoleKeysAsync(SaveUserMainSingleValueInput input);
        Task<ResultDto<SaveUserMainSingleValueDto>> SaveUserMainAllowSearchAsync(SaveUserMainSingleValueInput input);
        Task<ResultDto<SaveUserMainSingleValueDto>> SaveUserMainBirthDateAsync(SaveUserMainSingleValueInput input);

        Task<ResultDto<List<CompanyInvitationssDto>>> GetUserCompanyInvitationsListAsync(CompanyInvitationsListInput input);
        Task<ResultDto<SaveUserCompanyBindDto>> SaveUserCompanyBindAsync(SaveUserCompanyBindInput input);
        Task<ResultDto<DeleteUserCompanyBindDto>> DeleteUserCompanyBindAsync(DeleteUserCompanyBindInput input);
        Task<ResultDto<UserCompanyBindListDto>> GetUserCompanyBindListAsync(UserCompanyBindListInput input);

        
    }
}