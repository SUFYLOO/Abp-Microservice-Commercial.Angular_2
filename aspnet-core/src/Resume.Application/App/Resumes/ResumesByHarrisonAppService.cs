using Microsoft.Extensions.DependencyInjection;
using Resume.App.Companys;
using Resume.App.Users;
using Resume.ResumeMains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.ObjectMapping;

namespace Resume.App.Resumes
{
    public partial class ResumesAppService : ApplicationService, IResumesAppService
    {
        public async Task<ResumeMainsDto> SaveResumeMainsAsync(SaveResumeMainInput input)
        {
            var Result = new ResumeMainsDto();

            //系統層級
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>()?.CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>()?.SystemUserRoleKeys;

            //強制帶入Id
            input.UserMainId = UserMainId;

            //外部傳入
            var RefreshItem = input.RefreshItem;

            //不要變更的值
            input.Sort = input.Sort != null ? input.Sort : ShareDefine.Sort;
            input.DateA = input.DateA != null ? input.DateA : ShareDefine.DateA;
            input.DateD = input.DateD != null ? input.DateD : ShareDefine.DateD;

            //檢查
            //await SaveCompanyJobApplicationMethodCheckAsync(input);


            //主體資料
            var qrbResumeMain = await _appService._resumeMainRepository.GetQueryableAsync();
            var itemqrbResumeMain = qrbResumeMain.FirstOrDefault(p => p.Id == input.Id);

            //如果CompanyJobApplicationMethodsRepository沒有這個Id就新增資料，已存在就update
            if (itemqrbResumeMain == null)
            {
                itemqrbResumeMain = ObjectMapper.Map<SaveResumeMainInput, ResumeMain>(input);
                itemqrbResumeMain = await _appService._resumeMainRepository.InsertAsync(itemqrbResumeMain);
            }
            else
            {
                //不要變更的值
                input.Sort = itemqrbResumeMain.Sort;
                input.DateA = itemqrbResumeMain.DateA;
                input.DateD = itemqrbResumeMain.DateD;

                ObjectMapper.Map(input, itemqrbResumeMain);
                await _appService._resumeMainRepository.UpdateAsync(itemqrbResumeMain);
            }
            if (RefreshItem)
                await _appService._unitOfWorkManager.Current.SaveChangesAsync();

            ObjectMapper.Map(itemqrbResumeMain, Result);

            return Result;
        }
    }
}
