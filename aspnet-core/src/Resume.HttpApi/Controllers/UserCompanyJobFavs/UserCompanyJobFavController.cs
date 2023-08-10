using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.UserCompanyJobFavs;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.UserCompanyJobFavs
{
    [RemoteService]
    [Area("app")]
    [ControllerName("UserCompanyJobFav")]
    [Route("api/app/user-company-job-favs")]

    public class UserCompanyJobFavController : AbpController, IUserCompanyJobFavsAppService
    {
        private readonly IUserCompanyJobFavsAppService _userCompanyJobFavsAppService;

        public UserCompanyJobFavController(IUserCompanyJobFavsAppService userCompanyJobFavsAppService)
        {
            _userCompanyJobFavsAppService = userCompanyJobFavsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<UserCompanyJobFavDto>> GetListAsync(GetUserCompanyJobFavsInput input)
        {
            return _userCompanyJobFavsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<UserCompanyJobFavDto> GetAsync(Guid id)
        {
            return _userCompanyJobFavsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<UserCompanyJobFavDto> CreateAsync(UserCompanyJobFavCreateDto input)
        {
            return _userCompanyJobFavsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<UserCompanyJobFavDto> UpdateAsync(Guid id, UserCompanyJobFavUpdateDto input)
        {
            return _userCompanyJobFavsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _userCompanyJobFavsAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(UserCompanyJobFavExcelDownloadDto input)
        {
            return _userCompanyJobFavsAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _userCompanyJobFavsAppService.GetDownloadTokenAsync();
        }
    }
}