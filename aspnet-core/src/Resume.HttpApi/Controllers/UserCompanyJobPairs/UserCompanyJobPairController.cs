using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.UserCompanyJobPairs;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.UserCompanyJobPairs
{
    [RemoteService]
    [Area("app")]
    [ControllerName("UserCompanyJobPair")]
    [Route("api/app/user-company-job-pairs")]

    public class UserCompanyJobPairController : AbpController, IUserCompanyJobPairsAppService
    {
        private readonly IUserCompanyJobPairsAppService _userCompanyJobPairsAppService;

        public UserCompanyJobPairController(IUserCompanyJobPairsAppService userCompanyJobPairsAppService)
        {
            _userCompanyJobPairsAppService = userCompanyJobPairsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<UserCompanyJobPairDto>> GetListAsync(GetUserCompanyJobPairsInput input)
        {
            return _userCompanyJobPairsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<UserCompanyJobPairDto> GetAsync(Guid id)
        {
            return _userCompanyJobPairsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<UserCompanyJobPairDto> CreateAsync(UserCompanyJobPairCreateDto input)
        {
            return _userCompanyJobPairsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<UserCompanyJobPairDto> UpdateAsync(Guid id, UserCompanyJobPairUpdateDto input)
        {
            return _userCompanyJobPairsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _userCompanyJobPairsAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(UserCompanyJobPairExcelDownloadDto input)
        {
            return _userCompanyJobPairsAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _userCompanyJobPairsAppService.GetDownloadTokenAsync();
        }
    }
}