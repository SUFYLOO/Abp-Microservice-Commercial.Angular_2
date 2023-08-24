using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.CompanyUserMainFavs
{
    public interface ICompanyUserMainFavsAppService : IApplicationService
    {
        Task<PagedResultDto<CompanyUserMainFavDto>> GetListAsync(GetCompanyUserMainFavsInput input);

        Task<CompanyUserMainFavDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<CompanyUserMainFavDto> CreateAsync(CompanyUserMainFavCreateDto input);

        Task<CompanyUserMainFavDto> UpdateAsync(Guid id, CompanyUserMainFavUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyUserMainFavExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}