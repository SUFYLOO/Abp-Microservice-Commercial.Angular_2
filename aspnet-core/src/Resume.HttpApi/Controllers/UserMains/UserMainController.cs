using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.UserMains;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.UserMains
{
    [RemoteService]
    [Area("app")]
    [ControllerName("UserMain")]
    [Route("api/app/user-mains")]

    public class UserMainController : AbpController, IUserMainsAppService
    {
        private readonly IUserMainsAppService _userMainsAppService;

        public UserMainController(IUserMainsAppService userMainsAppService)
        {
            _userMainsAppService = userMainsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<UserMainDto>> GetListAsync(GetUserMainsInput input)
        {
            return _userMainsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<UserMainDto> GetAsync(Guid id)
        {
            return _userMainsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<UserMainDto> CreateAsync(UserMainCreateDto input)
        {
            return _userMainsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<UserMainDto> UpdateAsync(Guid id, UserMainUpdateDto input)
        {
            return _userMainsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _userMainsAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(UserMainExcelDownloadDto input)
        {
            return _userMainsAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _userMainsAppService.GetDownloadTokenAsync();
        }
    }
}