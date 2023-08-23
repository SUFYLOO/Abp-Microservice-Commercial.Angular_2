using Microsoft.Extensions.DependencyInjection;
using PayPalCheckoutSdk.Orders;
using Resume.App.Shares;
using Resume.App.Users;
using Resume.CompanyJobApplicationMethods;
using Resume.CompanyJobConditions;
using Resume.CompanyJobContents;
using Resume.CompanyJobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.MultiTenancy;

namespace Resume.App.Companys
{
    public partial class CompanysAppService : ApplicationService, ICompanysAppService
    {
        /// <summary>
        /// 儲存工作應徵方式
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public virtual async Task<CompanyJobApplicationMethodsDto> SaveCompanyJobApplicationMethodAsync(SaveCompanyJobApplicationMethodInput input)
        {
            var Result = new CompanyJobApplicationMethodsDto();
            //系統層級
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //強制帶入Id
            input.CompanyMainId = CompanyMainId;

            //外部傳入
            var CompanyJobApplicationMethodId = input.Id;
            var RefreshItem = input.RefreshItem;
            input.Status = "1";
            input.ExtendedInformation = "";

            //不要變更的值
            input.Sort = input.Sort != null ? input.Sort : ShareDefine.Sort;
            input.DateA = input.DateA != null ? input.DateA : ShareDefine.DateA;
            input.DateD = input.DateD != null ? input.DateD : ShareDefine.DateD;

            //檢查
            await SaveCompanyJobApplicationMethodCheckAsync(input);

            //主體資料
            var qrbCompanyJobApplicationMethod = await _appService._companyJobApplicationMethodRepository.GetQueryableAsync();
            var itemCompanyJobApplicationMethod = qrbCompanyJobApplicationMethod.FirstOrDefault(p => p.Id == CompanyJobApplicationMethodId);

            //如果CompanyJobApplicationMethodsRepository沒有這個Id就新增資料，已存在就update
            if (itemCompanyJobApplicationMethod == null)
            {
                itemCompanyJobApplicationMethod = ObjectMapper.Map<SaveCompanyJobApplicationMethodInput, CompanyJobApplicationMethod>(input);
                itemCompanyJobApplicationMethod = await _appService._companyJobApplicationMethodRepository.InsertAsync(itemCompanyJobApplicationMethod);
            }
            else
            {
                //不要變更的值
                input.Sort = itemCompanyJobApplicationMethod.Sort;
                input.DateA = itemCompanyJobApplicationMethod.DateA;
                input.DateD = itemCompanyJobApplicationMethod.DateD;

                ObjectMapper.Map(input, itemCompanyJobApplicationMethod);
                await _appService._companyJobApplicationMethodRepository.UpdateAsync(itemCompanyJobApplicationMethod);
            }
            if (RefreshItem)
                await _appService._unitOfWorkManager.Current.SaveChangesAsync();

            ObjectMapper.Map(itemCompanyJobApplicationMethod, Result);
            return Result;
        }

        public virtual async Task<ResultDto> SaveCompanyJobApplicationMethodCheckAsync(SaveCompanyJobApplicationMethodInput input)
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
            var Personally = input.Personally ?? "";

            //必要代碼檢核
            var conditions = new List<GroupCodeConditions>()
            {
                new GroupCodeConditions(){GroupCode = "WorkPlace",Code =Personally, ErrorMessage = "地點類別代碼錯誤" ,AllowNull = true},
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

        public virtual async Task<CompanyJobApplicationMethodsDto> GetCompanyJobApplicationMethodAsync(CompanyJobApplicationMethodInput input)
        {
            var Result = new CompanyJobApplicationMethodsDto();

            var ex = new UserFriendlyException("錯誤訊息");

            //常用

            //系統層級
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //強制把input帶入系統值

            //外部傳入
            var CompanyJobApplicationMethodId = input.Id;

            //預設值


            //檢查
            if (CompanyJobApplicationMethodId.ToString() == " ")
            {
                ex.Data.Add(GuidGenerator.Create().ToString(), "ID不能為空白");
                throw ex;
            }
            //主體資料
            if (ex.Data.Count == 0)
            {
                var qrbCompanyJobApplicationMethod = await _appService._companyJobApplicationMethodRepository.GetQueryableAsync();
                qrbCompanyJobApplicationMethod = (from c in qrbCompanyJobApplicationMethod
                                          where c.Status == "1"
                                          orderby c.Sort
                                          select c);
                var itemCompanyJobApplicationMethod = qrbCompanyJobApplicationMethod.FirstOrDefault(p => p.Id == CompanyJobApplicationMethodId);

                if (itemCompanyJobApplicationMethod != null)
                {
                    var inputShareCodeGroup = new ShareCodeGroupInput();
                    inputShareCodeGroup.ListGroupCode.Add("WorkPlace");

                    inputShareCodeGroup.AllForGroupCode = true;
                    var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);

                    ObjectMapper.Map(itemCompanyJobApplicationMethod, Result);

                    var inputSetShareCode = new SetShareCodeInput();
                    inputSetShareCode.ListShareCode = itemsShareCode;
                    inputSetShareCode.Data = new List<CompanyJobApplicationMethodsDto>() { Result };

                    var ListColumns = new List<NameCodeStandardDto>
                    {
                        new NameCodeStandardDto { GroupCode = "WorkPlace", Code = "Personally", Name = "PersonallyName" },
                    };

                    inputSetShareCode.ListColumns = ListColumns;
                    _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<CompanyJobApplicationMethodsDto>(inputSetShareCode);
                }
            }
            if (ex.Data.Count > 0)
                throw ex;

            return Result;
        }

        public virtual async Task<List<CompanyJobApplicationMethodsDto>> GetCompanyJobApplicationMethodListAsync(CompanyJobApplicationMethodInput input)
        {   //結果
            var Result = new List<CompanyJobApplicationMethodsDto>();
            var ex = new UserFriendlyException("錯誤訊息");

            //常用

            //系統層級
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //輸入值

            //預設值

            //檢查

            //主體資料
            var qrbCompanyJobApplicationMethod = await _appService._companyJobApplicationMethodRepository.GetQueryableAsync();
            qrbCompanyJobApplicationMethod = from c in qrbCompanyJobApplicationMethod
                                       //where c.JobOpen == JobOpen
                                       //&& c.Name.IndexOf(KeyWords) >= 0
                                   select c;

            if (ex.Data.Count == 0)
            {
                var itemsCompanyJobApplicationMethod = await AsyncExecuter.ToListAsync(qrbCompanyJobApplicationMethod);
                ObjectMapper.Map<List<CompanyJobApplicationMethod>, List<CompanyJobApplicationMethodsDto>>(itemsCompanyJobApplicationMethod, Result);
            }

            if (ex.Data.Count > 0)
                throw ex;
            return Result;
        }

        public virtual async Task<CompanyJobApplicationMethodsDto> DeleteCompanyJobApplicationMethodAsync(CompanyJobApplicationMethodInput input)
        {

            var Result = new CompanyJobApplicationMethodsDto();
            var ex = new UserFriendlyException("錯誤訊息");

            //常用

            //系統層級
            var TenantId = CurrentTenant.Id;
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //強制把input帶入系統值


            //外部傳入
            var Id = input.Id;


            //預設值


            //檢查
            if (SystemUserRoleKeys > 5)
                ex.Data.Add(GuidGenerator.Create().ToString(), "您沒有權限");

            //主體資料
            var qrbCompanyJobApplicationMethod = await _appService._companyJobApplicationMethodRepository.GetQueryableAsync();
            var qrbsCompanyJobApplicationMethod = from c in qrbCompanyJobApplicationMethod
                                            //where c.DateA <= ShareDefine.DateTimeNow && ShareDefine.DateTimeNow <= c.DateD
                                            //&& c.Status == "1"                      
                                        select c;

            if (ex.Data.Count == 0)
            {
                var qrbCompanyUser = await _appService._companyUserRepository.GetQueryableAsync();
                var qrbsCompanyUser = qrbCompanyUser.Where(p => p.UserMainId == UserMainId);
                var ListCompanyMainId = qrbsCompanyUser.Select(p => p.CompanyMainId);

                var itemCompanyJobApplicationMethod = qrbsCompanyJobApplicationMethod.FirstOrDefault(p => p.Id == Id);
                if (itemCompanyJobApplicationMethod == null)
                    ex.Data.Add(GuidGenerator.Create().ToString(), "沒有這筆資料");
                else
                {
                    await _appService._companyJobApplicationMethodRepository.DeleteAsync(itemCompanyJobApplicationMethod);
                    ObjectMapper.Map(itemCompanyJobApplicationMethod, Result);
                }
            }

            if (ex.Data.Count > 0)
                throw ex;
            return Result;
        }
    }
}



