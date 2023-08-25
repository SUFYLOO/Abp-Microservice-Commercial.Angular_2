using Microsoft.Extensions.DependencyInjection;
using PayPalCheckoutSdk.Orders;
using Resume.App.Shares;
using Resume.App.Users;
using Resume.CompanyJobApplicationMethods;
using Resume.CompanyJobConditions;
using Resume.CompanyJobContents;
using Resume.CompanyJobs;
using Resume.CompanyJobWorkHourss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text.Json;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.ObjectMapping;

namespace Resume.App.Companys
{
    public partial class CompanysAppService : ApplicationService, ICompanysAppService
    {
        public virtual async Task<List<CompanyJobWorkHourssDto>> SaveJobWorkHoursListAsync(SaveCompanyJobWorkHoursListInput input)
        {
            //結果
            var Result = new List<CompanyJobWorkHourssDto>();

            //常用 

            //系統層級
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>()?.UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>()?.SystemUserRoleKeys;

            //強制把input帶入系統值

            //外部傳入
            var CompanyJobId = input.CompanyJobId;
            var ListSaveCompanyJobWorkHoursInput = input.ListSaveCompanyJobWorkHoursInput;

            //預設值

            //檢查
            //await SaveCompanyJobContentCheckAsync(input);

            //主體資料
            var qrbCompanyJobWorkHours = await _appService._companyJobWorkHoursRepository.GetQueryableAsync();
            var itemsCompanyJobWorkHours = qrbCompanyJobWorkHours.Where(p => p.CompanyJobId == CompanyJobId);
            var ListCompanyJobWorkId = itemsCompanyJobWorkHours.Select(p => p.Id);
            //Result.SaveIntent = itemCompanyJobContent == null ? SaveIntentType.Insert : SaveIntentType.Update;

            //更新前先刪除之前紀錄
            await _appService._companyJobWorkHoursRepository.DeleteManyAsync(ListCompanyJobWorkId);

            //var ListCompanyJobWorkHours = new List<CompanyJobWorkHours>();
            //foreach (var itemSaveCompanyJobWorkHoursInput in ListSaveCompanyJobWorkHoursInput)
            //{
            //    var itemCompanyJobWorkHours = ObjectMapper.Map<SaveCompanyJobWorkHoursInput, CompanyJobWorkHours>(itemSaveCompanyJobWorkHoursInput);
            //    ListCompanyJobWorkHours.Add(itemCompanyJobWorkHours);
            //}

           var ListCompanyJobWorkHours = ObjectMapper.Map<List<SaveCompanyJobWorkHoursInput>, List<CompanyJobWorkHours>>(ListSaveCompanyJobWorkHoursInput);
            await _appService._companyJobWorkHoursRepository.InsertManyAsync(ListCompanyJobWorkHours);

            //不要變更的值

            //如果要更新為最新資料 就需要認可交易
            //if (RefreshItem)
            //    await _appService._unitOfWorkManager.Current.SaveChangesAsync();

            ObjectMapper.Map(ListCompanyJobWorkHours, Result);
            return Result;
        }
    }
}