using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.CompanyUserMainFavs;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.CompanyUserMainFavs
{
    [RemoteService]
    [Area("app")]
    [ControllerName("CompanyUserMainFav")]
    [Route("api/app/company-user-main-favs")]

    public class CompanyUserMainFavController : AbpController, ICompanyUserMainFavsAppService
    {
        private readonly ICompanyUserMainFavsAppService _companyUserMainFavsAppService;

        public CompanyUserMainFavController(ICompanyUserMainFavsAppService companyUserMainFavsAppService)
        {
            _companyUserMainFavsAppService = companyUserMainFavsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<CompanyUserMainFavDto>> GetListAsync(GetCompanyUserMainFavsInput input)
        {
            return _companyUserMainFavsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<CompanyUserMainFavDto> GetAsync(Guid id)
        {
            return _companyUserMainFavsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<CompanyUserMainFavDto> CreateAsync(CompanyUserMainFavCreateDto input)
        {
            return _companyUserMainFavsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<CompanyUserMainFavDto> UpdateAsync(Guid id, CompanyUserMainFavUpdateDto input)
        {
            return _companyUserMainFavsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _companyUserMainFavsAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyUserMainFavExcelDownloadDto input)
        {
            return _companyUserMainFavsAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _companyUserMainFavsAppService.GetDownloadTokenAsync();
        }
    }
}