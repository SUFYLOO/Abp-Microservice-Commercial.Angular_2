using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.UserTokens;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.UserTokens
{
    [RemoteService]
    [Area("app")]
    [ControllerName("UserToken")]
    [Route("api/app/user-tokens")]

    public class UserTokenController : AbpController, IUserTokensAppService
    {
        private readonly IUserTokensAppService _userTokensAppService;

        public UserTokenController(IUserTokensAppService userTokensAppService)
        {
            _userTokensAppService = userTokensAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<UserTokenDto>> GetListAsync(GetUserTokensInput input)
        {
            return _userTokensAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<UserTokenDto> GetAsync(Guid id)
        {
            return _userTokensAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<UserTokenDto> CreateAsync(UserTokenCreateDto input)
        {
            return _userTokensAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<UserTokenDto> UpdateAsync(Guid id, UserTokenUpdateDto input)
        {
            return _userTokensAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _userTokensAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(UserTokenExcelDownloadDto input)
        {
            return _userTokensAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _userTokensAppService.GetDownloadTokenAsync();
        }
    }
}