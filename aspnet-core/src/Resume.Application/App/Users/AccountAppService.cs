using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Resume.App.Shares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Security.Claims;
using Volo.Abp.Users;

namespace Resume.App.Users
{
    public class AccountAppService : ApplicationService
    {

        private readonly AppService _appService;

        public AccountAppService(AppService appService)
        {
            _appService = appService;
        }

        [AllowAnonymous]
        public async Task<LoginDto> LoginAsync(LoginInput input)
        {
            var Result = new LoginDto();

            try
            {
                var oidc = (await _appService._serviceProvider.GetService<SharesAppService>().GetShareDefaultOidcAsync(new ShareDefaultOidcInput())).Data;

                var client = _appService._httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(oidc.Uri);
                var dic = new Dictionary<string, object>
                {
                    {"client_id",oidc.ClientId},
                    {"client_secret",oidc.ClientSecret},
                    {"grant_type",oidc.GrantType},
                    {"username",input.LoginId},
                    {"password",input.Password},
                    {"scope",oidc.Scope},
                    {"state",Guid.NewGuid().ToString()},
                };
                var dicStr = dic.Select(m => m.Key + "=" + m.Value).DefaultIfEmpty().Aggregate((m, n) => m + "&" + n);
                HttpContent httpContent = new StringContent(dicStr);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                httpContent.Headers.Add("__tenant", input.TenantName);
                var oauthRep = await client.PostAsync("connect/token", httpContent);
                var oauthStr = await oauthRep.Content.ReadAsStringAsync();
                var oauthResult = default(Id4TokenDto);
                if (oauthRep.IsSuccessStatusCode)
                {
                    if (!string.IsNullOrEmpty(oauthStr))
                        oauthResult = JsonConvert.DeserializeObject<Id4TokenDto>(oauthStr);
                }
                else
                {
                    if (string.IsNullOrEmpty(oauthStr))
                        throw new BusinessException(oauthRep.ReasonPhrase);

                    Result.Message = "登入失敗";
                }

                Result.Id4Token = oauthResult;

                return Result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        #region 私有方法
        //private async Task<LoginDto> BuildResult(IdentityUser user, string token)
        //{
        //    var roles = await _identityUserManager.GetRolesAsync(user);
        //    if (roles == null || roles.Count == 0) throw new UserFriendlyException("當前用戶沒有角色");
        //    //var loginOutput = ObjectMapper.Map<IdentityUser, LoginDto>(user);
        //    var loginOutput = new LoginDto();
        //    loginOutput.Token = token;
        //    loginOutput.Roles = roles.ToList();
        //    return loginOutput;
        //}
        #endregion

        [AllowAnonymous]
        public async Task<LoginDto> RefreshTokenAsync(string input)
        {
            var Result = new LoginDto();

            try
            {
                var oidc = (await _appService._serviceProvider.GetService<SharesAppService>().GetShareDefaultOidcAsync(new ShareDefaultOidcInput())).Data;

                var client = _appService._httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(oidc.Uri);
                var dic = new Dictionary<string, object>
                {
                    {"client_id",oidc.ClientId},
                    {"client_secret",oidc.ClientSecret},
                    {"grant_type","refresh_token"},
                    {"refresh_token",input},
                };
                var dicStr = dic.Select(m => m.Key + "=" + m.Value).DefaultIfEmpty().Aggregate((m, n) => m + "&" + n);
                HttpContent httpContent = new StringContent(dicStr);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                var oauthRep = await client.PostAsync("connect/token", httpContent);
                var oauthStr = await oauthRep.Content.ReadAsStringAsync();
                var oauthResult = default(Id4TokenDto);
                if (oauthRep.IsSuccessStatusCode)
                {
                    if (!string.IsNullOrEmpty(oauthStr))
                        oauthResult = JsonConvert.DeserializeObject<Id4TokenDto>(oauthStr);
                }
                else
                {
                    if (string.IsNullOrEmpty(oauthStr))
                        throw new BusinessException(oauthRep.ReasonPhrase);

                    Result.Message = "登入失敗";
                }

                Result.Id4Token = oauthResult;

                return Result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [AllowAnonymous]
        public virtual async Task<AccessTokenDto> GetAccessToken(LoginBindInput input)
        {
            var Result = new AccessTokenDto();

            var Code = input.Code;
            var State = input.State;
            var ThirdPartyTypeCode = input.ThirdPartyTypeCode;

            var inputShareDefault = new ShareDefaultInput();
            inputShareDefault.GroupCode = ThirdPartyTypeCode;
            inputShareDefault.Key1 = CurrentTenant.Id == null ? "" : CurrentTenant.Id.ToString();
            var itemShareDefault = await _appService._serviceProvider.GetService<SharesAppService>().GetShareDefaultAsync(inputShareDefault);

            if (itemShareDefault.Data.Count > 0)
            {
                var dc = itemShareDefault.Data.ToDictionary(p => p.Key, p => p.Value);

                var TokenUrl = dc["TokenUrl"];
                var ClientId = dc["ClientId"];
                var ClientSecret = dc["ClientSecret"];
                var RedirectUrl = dc["RedirectUrl"];
                var GrantType = "authorization_code";

                var client = _appService._httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(TokenUrl);
                var dic = new Dictionary<string, object> {
                    { "code", Code },
                    { "client_id", ClientId },
                    { "client_secret", ClientSecret },
                    { "redirect_uri", RedirectUrl },
                    { "grant_type", GrantType },
                    { "prompt", "consent" },
                };
                var dicStr = dic.Select(m => m.Key + "=" + m.Value).DefaultIfEmpty().Aggregate((m, n) => m + "&" + n);
                HttpContent httpContent = new StringContent(dicStr);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                var oauthRep = await client.PostAsync("", httpContent);
                var oauthStr = await oauthRep.Content.ReadAsStringAsync();

                var oauthResult = default(Id4TokenDto);
                if (oauthRep.IsSuccessStatusCode)
                {
                    if (!string.IsNullOrEmpty(oauthStr))
                        oauthResult = JsonConvert.DeserializeObject<Id4TokenDto>(oauthStr);
                }
                else
                {
                    if (string.IsNullOrEmpty(oauthStr))
                        throw new BusinessException(oauthRep.ReasonPhrase);

                    Result.Message = "登入失敗";
                }

                Result.AccessToken = oauthResult?.access_token;
            }

            return Result;
        }

        public virtual async Task<ThirdPartyUserDataDto> GetThirdPartyUserData(LoginBindInput input)
        {
            var Result = new ThirdPartyUserDataDto();

            var Code = input.Code;
            var State = input.State;
            var ThirdPartyTypeCode = input.ThirdPartyTypeCode;

            var inputShareDefault = new ShareDefaultInput();
            inputShareDefault.GroupCode = ThirdPartyTypeCode;
            inputShareDefault.Key1 = CurrentTenant.Id == null ? "" : CurrentTenant.Id.ToString();
            var itemShareDefault = await _appService._serviceProvider.GetService<SharesAppService>().GetShareDefaultAsync(inputShareDefault);

            if (itemShareDefault.Data.Count > 0)
            {
                var dc = itemShareDefault.Data.ToDictionary(p => p.Key, p => p.Value);
                var UserInfoUrl = dc["UserInfoUrl"];

                try
                {
                    var item = await GetAccessToken(input);
                    var AccessToken = item.AccessToken;

                     var client = _appService._httpClientFactory.CreateClient();
                    client.BaseAddress = new Uri(UserInfoUrl);
                    //line需要用這種權限的加入方法
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
                    var oauthRep = await client.GetAsync("?access_token=" + AccessToken);
             
                    var oauthStr = await oauthRep.Content.ReadAsStringAsync();

                    if (oauthRep.IsSuccessStatusCode)
                    {
                        if (!string.IsNullOrEmpty(oauthStr))
                        {
                            Result = JsonConvert.DeserializeObject<ThirdPartyUserDataDto>(oauthStr);

                            //因為各平台的id名稱都不相同 未來再想怎麼整合
                            Result.id = Result.id.IsNullOrEmpty() ? Result.userId : Result.id;
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(oauthStr))
                            throw new BusinessException(oauthRep.ReasonPhrase);
                    }
                }
                catch (Exception ex)
                {
                  var Error = ex.ToString();
                }
            }

            return Result;
        }
            

        public virtual async void Login(string token, string userId)
        {
            var user = await _appService._identityUserManager.FindByIdAsync(userId);

            var isValid = await _appService._identityUserManager.VerifyUserTokenAsync(user, "PasswordlessLoginProvider", "passwordless-auth", token);
            if (!isValid)
            {
                throw new UnauthorizedAccessException("The token " + token + " is not valid for the user " + userId);
            }

            await _appService._identityUserManager.UpdateSecurityStampAsync(user);

            var roles = await _appService._identityUserManager.GetRolesAsync(user);

            //var principal = new ClaimsPrincipal(
            //    new ClaimsIdentity(CreateClaims(user, roles), IdentityConstants.ApplicationScheme)
            //);

            //var _httpContext = new HttpContext();
            //await _httpContext.SignInAsync(IdentityConstants.ApplicationScheme, principal);

        }

        private static IEnumerable<Claim> CreateClaims(IUser user, IEnumerable<string> roles)
        {
            var claims = new List<Claim>
        {
            new Claim("sub", user.Id.ToString()),
            new Claim(AbpClaimTypes.UserId, user.Id.ToString()),
            new Claim(AbpClaimTypes.Email, user.Email),
            new Claim(AbpClaimTypes.UserName, user.UserName),
            new Claim(AbpClaimTypes.EmailVerified, user.EmailConfirmed.ToString().ToLower()),
        };

            if (!string.IsNullOrWhiteSpace(user.PhoneNumber))
            {
                claims.Add(new Claim(AbpClaimTypes.PhoneNumber, user.PhoneNumber));
            }

            foreach (var role in roles)
            {
                claims.Add(new Claim(AbpClaimTypes.Role, role));
            }

            return claims;
        }
    }

   


}