using Microsoft.Extensions.DependencyInjection;
using Resume.App.Shares;
using Resume.App.Users;
using Resume.CompanyJobPays;
using Resume.CompanyJobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace Resume.App.Companys
{
    public partial class CompanysAppService : ApplicationService, ICompanysAppService
    {
        public virtual async Task<CompanyJobPaysDto> SaveCompanyJobPayAsync(SaveCompanyJobPayInput input)
        {
            var Result = new CompanyJobPaysDto();

            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //強制帶入Id
            input.CompanyMainId = CompanyMainId;

            //外部傳入
            var CompanyJobPayId = input.Id;
            var RefreshItem = input.RefreshItem;
            input.Status = "1";
            input.ExtendedInformation = "";

            //不要變更的值
            input.Sort = input.Sort != null ? input.Sort : ShareDefine.Sort;
            input.DateA = input.DateA != null ? input.DateA : ShareDefine.DateA;
            input.DateD = input.DateD != null ? input.DateD : ShareDefine.DateD;

            //檢查
            await SaveCompanyJobPayCheckAsync(input);


            //主體資料
            var qrbCompanyJobPay = await _appService._companyJobPayRepository.GetQueryableAsync();
            var itemCompanyJobPay = qrbCompanyJobPay.FirstOrDefault(p => p.Id == CompanyJobPayId);

            //如果CompanyJobPaysRepository沒有這個Id就新增資料，已存在就update
            if (itemCompanyJobPay == null)
            {
                itemCompanyJobPay = ObjectMapper.Map<SaveCompanyJobPayInput, CompanyJobPay>(input);
                itemCompanyJobPay = await _appService._companyJobPayRepository.InsertAsync(itemCompanyJobPay);
            }
            else
            {
                //不要變更的值
                input.Sort = itemCompanyJobPay.Sort;
                input.DateA = itemCompanyJobPay.DateA;
                input.DateD = itemCompanyJobPay.DateD;

                ObjectMapper.Map(input, itemCompanyJobPay);
                await _appService._companyJobPayRepository.UpdateAsync(itemCompanyJobPay);
            }
            if (RefreshItem)
                await _appService._unitOfWorkManager.Current.SaveChangesAsync();

            ObjectMapper.Map(itemCompanyJobPay, Result);
            return Result;
        }

        public virtual async Task<ResultDto> SaveCompanyJobPayCheckAsync(SaveCompanyJobPayInput input)
        {
            //結果
            var Result = new ResultDto();
            var ex = new UserFriendlyException("錯誤訊息");

            //常用

            //系統層級
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>()?.CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>()?.UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>()?.SystemUserRoleKeys;

            //外部傳入
            var CompanyJobId = input.CompanyJobId;
            var JobPayTypeCode = input.JobPayTypeCode ?? "";


            //必要代碼檢核
            var conditions = new List<GroupCodeConditions>()
            {
                new GroupCodeConditions(){GroupCode = "JobPayType",Code =JobPayTypeCode, ErrorMessage = "付費類別代碼錯誤" ,AllowNull = true},

            };

            Result = await _appService._serviceProvider.GetService<SharesAppService>().CheckGroupCode(Result, conditions);

            var qrbCompanyJob = await _appService._companyJobRepository.GetQueryableAsync();
            var itemCompanyJob = qrbCompanyJob.FirstOrDefault(p => p.Id == CompanyJobId);

            if (itemCompanyJob == null)
                ex.Data.Add(GuidGenerator.Create().ToString(), "沒有這筆資料");

            foreach (var msg in Result.Messages)
                ex.Data.Add(GuidGenerator.Create().ToString(), msg.MessageContents);

            Result.Check = !Result.Messages.Any(p => !p.Pass);
            if (!Result.Check)
                throw ex;

            return Result;
        }
        public virtual async Task<CompanyJobPaysDto> GetCompanyJobPayAsync(CompanyJobPayInput input)
        {
            //結果
            var Result = new CompanyJobPaysDto();
            var ex = new UserFriendlyException("錯誤訊息");
            //常用

            //系統層級
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //強制把input帶入系統值

            //外部傳入
            var CompanyJobPayId = input.Id;

            //預設值


            //檢查
            if (CompanyJobPayId.ToString() == " ")
            {
                ex.Data.Add(GuidGenerator.Create().ToString(), "ID不能為空白");
                throw ex;
            }
            //主體資料
            var qrbCompanyJobPay = await _appService._companyJobPayRepository.GetQueryableAsync();

            if (ex.Data.Count == 0)
            {

                //如果是一般公司
                var itemCompanyJobPay = qrbCompanyJobPay.FirstOrDefault(p => p.Id == CompanyJobPayId);
                if (itemCompanyJobPay == null)
                    ex.Data.Add(GuidGenerator.Create().ToString(), "沒有這筆資料");

                ObjectMapper.Map(itemCompanyJobPay, Result);
            }
            if (ex.Data.Count > 0)
                throw ex;

            return Result;
        }
    }

}