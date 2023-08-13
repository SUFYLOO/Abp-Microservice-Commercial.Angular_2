using Resume.App.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Saas.Host.Dtos;

namespace Resume.App
{
    public class StdInput
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string ConcurrencyStamp { get; set; }
        [Required]
        public bool RefreshItem { get; set; } = false;

    }



    public  class DeleteInput: StdInput
    {
        public string TableName { get; set; }
    }

    public enum ResumeDisplayMethod
    {
        None,
        Classification,
        All,
    }

    public enum SaveIntentType
    {
        Insert ,
        Update,
        Delete,
        None,
    }

    public class CheckUserVerifyInput
    {
        [Required]
        public string VerifyId { get; set; } = "";
        [Required]
        public string VerifyCode { get; set; } = "";

        public CheckUserVerifyInput()
        {

        }
    }

    //public class RegisterInput
    //{
    //    public string TenantName { get; set; } = "User";
    //    public string Name { get; set; }
    //    public string AccountCode { get; set; }
    //    public string Email { get; set; }
    //    public string MobilePhone { get; set; }
    //    public string IdentityNo { get; set; }
    //    public string Password { get; set; }
    //    public CheckUserVerifyInput CheckUserVerify { get; set; }
    //    public string ThirdPartyTypeCode { get; set; } = "";
    //    public ThirdPartyUserDataDto UserData { get; set; }

    //    public RegisterInput()
    //    {

    //    }
    //}

    public class RegisterInput : SaasTenantCreateDto
    {
        /// <summary>
        /// 允許沒有MAIL 由系統自創
        /// </summary>
        new public string AdminEmailAddress { get; set; }
        [Required]
        public string CompanyMainName { get; set; }
        public string AccountCode { get; set; } = "";
        //public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string IdentityNo { get; set; }
        //public string Password { get; set; }
        public CheckUserVerifyInput CheckUserVerify { get; set; }
        public string ThirdPartyTypeCode { get; set; } = "";
        public ThirdPartyUserDataDto UserData { get; set; }
    }

    public class LoginInput : IValidatableObject
    {
        public Guid TenantId { get; set; }
        public string TenantName { get; set; } = "User";
        [Required]
        public string LoginId { get; set; } = "";
        public Guid UserId { get; set; }
        [Required]
        public string Password { get; set; } = "";

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (LoginId.IsNullOrWhiteSpace())
            {
                yield return new ValidationResult("帳號不得空白", new[] { "LoginId" });
            }

            if (Password.IsNullOrWhiteSpace())
            {
                yield return new ValidationResult("密碼不得空白", new[] { "Password" });
            }
        }
    }
}
