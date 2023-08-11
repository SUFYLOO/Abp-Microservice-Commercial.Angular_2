using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.CompanyUsers;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.CompanyUsers
{
    [RemoteService]
    [Area("app")]
    [ControllerName("CompanyUser")]
    [Route("api/app/company-users")]

    public class CompanyUserController : AbpController, ICompanyUsersAppService
    {
        private readonly ICompanyUsersAppService _companyUsersAppService;

        public CompanyUserController(ICompanyUsersAppService companyUsersAppService)
        {
            _companyUsersAppService = companyUsersAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<CompanyUserDto>> GetListAsync(GetCompanyUsersInput input)
        {
            return _companyUsersAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<CompanyUserDto> GetAsync(Guid id)
        {
            return _companyUsersAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<CompanyUserDto> CreateAsync(CompanyUserCreateDto input)
        {
            return _companyUsersAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<CompanyUserDto> UpdateAsync(Guid id, CompanyUserUpdateDto input)
        {
            return _companyUsersAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _companyUsersAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyUserExcelDownloadDto input)
        {
            return _companyUsersAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _companyUsersAppService.GetDownloadTokenAsync();
        }
    }
}