using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.UserCompanyBinds;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.UserCompanyBinds
{
    [RemoteService]
    [Area("app")]
    [ControllerName("UserCompanyBind")]
    [Route("api/app/user-company-binds")]

    public class UserCompanyBindController : AbpController, IUserCompanyBindsAppService
    {
        private readonly IUserCompanyBindsAppService _userCompanyBindsAppService;

        public UserCompanyBindController(IUserCompanyBindsAppService userCompanyBindsAppService)
        {
            _userCompanyBindsAppService = userCompanyBindsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<UserCompanyBindDto>> GetListAsync(GetUserCompanyBindsInput input)
        {
            return _userCompanyBindsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<UserCompanyBindDto> GetAsync(Guid id)
        {
            return _userCompanyBindsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<UserCompanyBindDto> CreateAsync(UserCompanyBindCreateDto input)
        {
            return _userCompanyBindsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<UserCompanyBindDto> UpdateAsync(Guid id, UserCompanyBindUpdateDto input)
        {
            return _userCompanyBindsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _userCompanyBindsAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(UserCompanyBindExcelDownloadDto input)
        {
            return _userCompanyBindsAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _userCompanyBindsAppService.GetDownloadTokenAsync();
        }
    }
}