using Resume.UserCompanyBinds;
using System;

namespace Resume.App.Users
{
    public class RegisterCheckInput
    {
        public string TenantName { get; set; } = "User";
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string IdentityNo { get; set; }
        public string Password { get; set; }

        public RegisterCheckInput()
        {

        }
    }

    public class RefreshTokenInput
    {
        public string RefreshToken { get; set; } = "";
    }

    public class InsertUserMainInput
    {
        public Guid? TenantId { get; set; }
        public Guid UserId { get; set; }
        public Guid UserMainId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string IdentityNo { get; set; }
        public string Password { get; set; }
        public int SystemUserRoleKeys { get; set; } = 16;

    }

    public class SendUserVerifyInput
    {
        public string VerifyId { get; set; } = Guid.NewGuid().ToString();
        public string SendTypeCode { get; set; }
        public string ShareMessageTplKey3 { get; set; }
        public string ToMail { get; set; }
        public string ToGsm { get; set; }

        public SendUserVerifyInput()
        {

        }
    }

    public class ForgetPasswordInput
    {
        public string Email { get; set; }
        public string MobilePhone { get; set; }
    }

    public class LoginBindInput
    {
        public string State { get; set; } = "";
        public string Code { get; set; } = "";
        public string ThirdPartyTypeCode { get; set; } = "";
    }

    public class UserAccountBindListInput
    {

    }

    public class SaveUserAccountBindInput
    {
        public string State { get; set; } = "";
        public string Code { get; set; }
        public string ThirdPartyTypeCode { get; set; } = "";
    }

    public class UserMainsInput
    {
        public Guid? UserMainId { get; set; } 
    }

    public class UserInfosInput
    {
        public Guid? UserMainId { get; set; }
    }

    public class SaveUserMainSingleValueInput
    {
        public string TenantName { get; set; } = "User"; 
        public string UserId { get; set; } = "";
        public string Value { get; set; }
        public CheckUserVerifyInput CheckUserVerify { get; set; }

    }

    public class SaveUserMainPasswordInput: SaveUserMainSingleValueInput
    {
        public string CurrentPassword { get; set; }
    }

    public class SaveUserMainColumnNameInput
    {
        public string UserId { get; set; } = "";
        public string ColumnName { get; set; } = "";
        public string Value { get; set; } = "";
        public string CurrentPassword { get; set; } = "";
        public CheckUserVerifyInput CheckUserVerify { get; set; }
    }

    public class SaveUserCompanyBindInput:UserCompanyBindDto
    {
    }

    public class UserCompanyBindListInput
    {
      
    }

    public class DeleteUserCompanyBindInput
    {
        public Guid Id { get; set; }
    }

    public class DeleteUserAccountBindInput
    {
        public Guid Id { get; set; }
    }
}