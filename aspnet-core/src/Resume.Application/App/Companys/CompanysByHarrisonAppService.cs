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

namespace Resume.App.Companys
{
    public partial class CompanysAppService : ApplicationService, ICompanysAppService
    {
        public virtual async Task <List<CompanyJobWorkHourssDto>> SaveJobWorkHoursAsync(SaveCompanyJobWorkHoursInput input)
        {
            //結果
            var Result = new List<CompanyJobWorkHourssDto>();

            //常用 

            //系統層級
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>()?.UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>()?.SystemUserRoleKeys;
            
 
            //強制把input帶入系統值
            input.Status = "1";
            input.ExtendedInformation = "";
            input.CompanyMainId = CompanyMainId;

            //外部傳入
            var WorkHoursId = input.Id;
            var CompanyJobId = input.CompanyJobId;
            var RefreshItem = input.RefreshItem;

            //預設值
            input.Sort = input.Sort != null ? input.Sort : ShareDefine.Sort;
            input.DateA = input.DateA != null ? input.DateA : ShareDefine.DateA;
            input.DateD = input.DateD != null ? input.DateD : ShareDefine.DateD;
            input.Status = input.Status.IsNullOrEmpty() ? "1" : input.Status;
            input.ExtendedInformation = input.ExtendedInformation.IsNullOrEmpty() ? "" : input.ExtendedInformation;

            //檢查
            //await SaveCompanyJobContentCheckAsync(input);

            //主體資料
            var qrbCompanyJobWorkHours = await _appService._companyJobWorkHoursRepository.GetQueryableAsync();
            var itemCompanyJobWorkHours = qrbCompanyJobWorkHours.FirstOrDefault(p => p.Id == WorkHoursId);

            //Result.SaveIntent = itemCompanyJobContent == null ? SaveIntentType.Insert : SaveIntentType.Update;

            if (itemCompanyJobWorkHours == null)
            {
                itemCompanyJobWorkHours = ObjectMapper.Map<SaveCompanyJobWorkHoursInput, CompanyJobWorkHours>(input);
                itemCompanyJobWorkHours = await _appService._companyJobWorkHoursRepository.InsertAsync(itemCompanyJobWorkHours);
            }
            else
            {
                //不要變更的值

                ObjectMapper.Map(input, itemCompanyJobWorkHours);
                itemCompanyJobWorkHours = await _appService._companyJobWorkHoursRepository.UpdateAsync(itemCompanyJobWorkHours);
                //如果要更新為最新資料 就需要認可交易
                if (RefreshItem)
                    await _appService._unitOfWorkManager.Current.SaveChangesAsync();
            }
            ObjectMapper.Map(itemCompanyJobWorkHours, Result);
            return Result;
        }
    }
}



