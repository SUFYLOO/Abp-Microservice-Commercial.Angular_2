using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.UserAccountBinds;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.UserAccountBinds
{
    [RemoteService]
    [Area("app")]
    [ControllerName("UserAccountBind")]
    [Route("api/app/user-account-binds")]

    public class UserAccountBindController : AbpController, IUserAccountBindsAppService
    {
        private readonly IUserAccountBindsAppService _userAccountBindsAppService;

        public UserAccountBindController(IUserAccountBindsAppService userAccountBindsAppService)
        {
            _userAccountBindsAppService = userAccountBindsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<UserAccountBindDto>> GetListAsync(GetUserAccountBindsInput input)
        {
            return _userAccountBindsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<UserAccountBindDto> GetAsync(Guid id)
        {
            return _userAccountBindsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<UserAccountBindDto> CreateAsync(UserAccountBindCreateDto input)
        {
            return _userAccountBindsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<UserAccountBindDto> UpdateAsync(Guid id, UserAccountBindUpdateDto input)
        {
            return _userAccountBindsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _userAccountBindsAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(UserAccountBindExcelDownloadDto input)
        {
            return _userAccountBindsAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _userAccountBindsAppService.GetDownloadTokenAsync();
        }
    }
}