using Resume.ResumeDependentss;
using Resume.UserInfos;
using Resume.UserMains;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Account;
using Volo.Abp.Application.Dtos;

namespace Resume.App.Users
{
    public class SendUserVerifyDto
    {
        public string VerifyId { get; set; } = "";
        public DateTime DateA { get; set; } = DateTime.Now;
        public DateTime DateD { get; set; } = DateTime.Now.AddSeconds(60);
    }

    public class CheckUserVerifyDto 
    {
        public bool Pass { get; set; } = false;
    }


    // 基本資料
    public class UserMainsDto : UserMainDto
    {

    }

    public class InsertUserMainsDto 
    {
        public UserMainsDto UserMains { get; set; } = new UserMainsDto();
        public UserInfosDto UserInfos { get; set; } = new UserInfosDto();
    }

    // 基本資料
    public class UserInfosDto : UserInfoDto
    {
        public string SexName { get; set; } = "";
        public string BloodName { get; set; } = "";
        public string MarriageName { get; set; } = "";
        public string PlaceOfBirthName { get; set; } = "";
        public string MilitaryName { get; set; } = "";
        public string DisabilityCategoryName { get; set; } = "";
        public string NationalityName { get; set; } = "";
        public string SpecialIdentityName { get; set; } = "";


    }

    public class Id4TokenDto
    {
        public string access_token { get; set; }

        public int expires_in { get; set; }

        public string token_type { get; set; }

        public string refresh_token { get; set; }

        public string scope { get; set; }
    }

    public class AccessTokenDto
    {
        public string AccessToken { get; set; } = "";
        public string Message { get; set; } = "";
    }

    public class ThirdPartyUserDataDto
    {
        public string id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string given_name { get; set; }
        public string family_name { get; set; }
        public string picture { get; set; }
        public string locale { get; set; }
        public string Message { get; set; } = "";

        //line
        public string userId { get; set; }
        public string displayName { get; set; }
        public string statusMessage { get; set; }
        public string pictureUrl { get; set; }
        public ThirdPartyUserDataDto()
        {
            id = "";
            email = "";
            name = "";
            given_name = "";
            family_name = "";
            picture = "";
            locale = "";
        }
    }

 

    public class SaveUserMainSingleValueDto
    {
        public bool Pass { get; set; } = false;      

    }

    public class SaveUserCompanyBindDto
    {
        public bool Pass { get; set; } = false;
        public Guid UserMainId { get; set; } 
        public Guid UserCompanyBindId { get; set; } 

    }

    public class UserCompanyBindListDto
    {
        public List<NameIdStandardDto> ListCompanyMain { get; set; } = new List<NameIdStandardDto>();
        public List<NameIdStandardDto> ListCompanyJob { get; set; } = new List<NameIdStandardDto>();

    }

    public class DeleteUserCompanyBindDto
    {
        public bool Pass { get; set; } = false;

    }

    public class DeleteUserAccountBindDto
    {
        public bool Pass { get; set; } = false;

    }
}