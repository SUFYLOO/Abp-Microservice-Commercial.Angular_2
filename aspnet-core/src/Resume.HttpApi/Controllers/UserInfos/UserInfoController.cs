using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.UserInfos;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.UserInfos
{
    [RemoteService]
    [Area("app")]
    [ControllerName("UserInfo")]
    [Route("api/app/user-infos")]

    public class UserInfoController : AbpController, IUserInfosAppService
    {
        private readonly IUserInfosAppService _userInfosAppService;

        public UserInfoController(IUserInfosAppService userInfosAppService)
        {
            _userInfosAppService = userInfosAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<UserInfoDto>> GetListAsync(GetUserInfosInput input)
        {
            return _userInfosAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<UserInfoDto> GetAsync(Guid id)
        {
            return _userInfosAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<UserInfoDto> CreateAsync(UserInfoCreateDto input)
        {
            return _userInfosAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<UserInfoDto> UpdateAsync(Guid id, UserInfoUpdateDto input)
        {
            return _userInfosAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _userInfosAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(UserInfoExcelDownloadDto input)
        {
            return _userInfosAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _userInfosAppService.GetDownloadTokenAsync();
        }
    }
}