using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.ResumeRecommenders;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.ResumeRecommenders
{
    [RemoteService]
    [Area("app")]
    [ControllerName("ResumeRecommender")]
    [Route("api/app/resume-recommenders")]

    public class ResumeRecommenderController : AbpController, IResumeRecommendersAppService
    {
        private readonly IResumeRecommendersAppService _resumeRecommendersAppService;

        public ResumeRecommenderController(IResumeRecommendersAppService resumeRecommendersAppService)
        {
            _resumeRecommendersAppService = resumeRecommendersAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ResumeRecommenderDto>> GetListAsync(GetResumeRecommendersInput input)
        {
            return _resumeRecommendersAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ResumeRecommenderDto> GetAsync(Guid id)
        {
            return _resumeRecommendersAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<ResumeRecommenderDto> CreateAsync(ResumeRecommenderCreateDto input)
        {
            return _resumeRecommendersAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ResumeRecommenderDto> UpdateAsync(Guid id, ResumeRecommenderUpdateDto input)
        {
            return _resumeRecommendersAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _resumeRecommendersAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(ResumeRecommenderExcelDownloadDto input)
        {
            return _resumeRecommendersAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _resumeRecommendersAppService.GetDownloadTokenAsync();
        }
    }
}