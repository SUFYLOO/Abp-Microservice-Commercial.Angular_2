using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.UserVerifys;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.UserVerifys
{
    [RemoteService]
    [Area("app")]
    [ControllerName("UserVerify")]
    [Route("api/app/user-verifys")]

    public class UserVerifyController : AbpController, IUserVerifysAppService
    {
        private readonly IUserVerifysAppService _userVerifysAppService;

        public UserVerifyController(IUserVerifysAppService userVerifysAppService)
        {
            _userVerifysAppService = userVerifysAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<UserVerifyDto>> GetListAsync(GetUserVerifysInput input)
        {
            return _userVerifysAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<UserVerifyDto> GetAsync(long id)
        {
            return _userVerifysAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<UserVerifyDto> CreateAsync(UserVerifyCreateDto input)
        {
            return _userVerifysAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<UserVerifyDto> UpdateAsync(long id, UserVerifyUpdateDto input)
        {
            return _userVerifysAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(long id)
        {
            return _userVerifysAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(UserVerifyExcelDownloadDto input)
        {
            return _userVerifysAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _userVerifysAppService.GetDownloadTokenAsync();
        }
    }
}