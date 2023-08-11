using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.UserCompanyJobApplies;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.UserCompanyJobApplies
{
    [RemoteService]
    [Area("app")]
    [ControllerName("UserCompanyJobApply")]
    [Route("api/app/user-company-job-applies")]

    public class UserCompanyJobApplyController : AbpController, IUserCompanyJobAppliesAppService
    {
        private readonly IUserCompanyJobAppliesAppService _userCompanyJobAppliesAppService;

        public UserCompanyJobApplyController(IUserCompanyJobAppliesAppService userCompanyJobAppliesAppService)
        {
            _userCompanyJobAppliesAppService = userCompanyJobAppliesAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<UserCompanyJobApplyDto>> GetListAsync(GetUserCompanyJobAppliesInput input)
        {
            return _userCompanyJobAppliesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<UserCompanyJobApplyDto> GetAsync(Guid id)
        {
            return _userCompanyJobAppliesAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<UserCompanyJobApplyDto> CreateAsync(UserCompanyJobApplyCreateDto input)
        {
            return _userCompanyJobAppliesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<UserCompanyJobApplyDto> UpdateAsync(Guid id, UserCompanyJobApplyUpdateDto input)
        {
            return _userCompanyJobAppliesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _userCompanyJobAppliesAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(UserCompanyJobApplyExcelDownloadDto input)
        {
            return _userCompanyJobAppliesAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _userCompanyJobAppliesAppService.GetDownloadTokenAsync();
        }
    }
}