using Resume.App.Users;
using Resume.CompanyMains;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.MultiTenancy;
using Resume.CompanyJobContents;
using Volo.Abp.ObjectMapping;
using Volo.Abp;
using PayPalCheckoutSdk.Orders;

namespace Resume.App.Companys
{
    public partial class CompanysAppService : ApplicationService, ICompanysAppService
    {
        public virtual async Task<List<CompanyMainsDto>> GetCompanyMainListAsync(CompanyMainListInput input)
        {
            //結果
            var Result = new List<CompanyMainsDto>();
            var ex = new UserFriendlyException("錯誤訊息");

            //常用

            //系統層級
            var TenantId = CurrentTenant.Id;
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //強制把input帶入系統值
            //input.CompanyMainId = CompanyMainId;

            //外部傳入
            //var CompanyMainId = input.Id;
            //var RefreshItem = input.RefreshItem;

            //預設值
            //input.Sort = input.Sort != null ? input.Sort : ShareDefine.Sort;
            //input.DateA = input.DateA != null ? input.DateA : ShareDefine.DateA;
            //input.DateD = input.DateD != null ? input.DateD : ShareDefine.DateD;

            //檢查
            //由登入者的CurrentUser.Id尋找CompanyUser.UserMainId      
            //得到公司的主檔代碼(可能有多筆，來自於不同的，也可能來自於不同的租戶)
            if (SystemUserRoleKeys >= 16)
                ex.Data.Add(GuidGenerator.Create().ToString(), "您沒有權限");

            //主體資料
            var qrbCompanyMain = await _appService._companyMainRepository.GetQueryableAsync();
            var qrbsCompanyMain = from c in qrbCompanyMain
                                      //where c.DateA <= ShareDefine.DateTimeNow && ShareDefine.DateTimeNow <= c.DateD
                                      //&& c.Status == "1"                      
                                  select c;

            if (ex.Data.Count == 0)
                using (_appService._dataFilter.Disable<IMultiTenant>())
                {
                    var qrbCompanyUser = await _appService._companyUserRepository.GetQueryableAsync();
                    var qrbsCompanyUser = qrbCompanyUser.Where(p => p.UserMainId == UserMainId);
                    var ListCompanyMainId = qrbsCompanyUser.Select(p => p.CompanyMainId);

                    //如果是一般公司
                    if (SystemUserRoleKeys > 2)
                        qrbsCompanyMain = qrbsCompanyMain.Where(p => ListCompanyMainId.Contains(p.Id) || p.TenantId == TenantId);

                    var itemsCompanyMain = qrbsCompanyMain.ToList();

                    //排序結果 ，如果需要排序就
                    //itemsCompanyMain = (from c in itemsCompanyMain
                    //                    orderby c.Sort
                    //                    select c).ToList();

                    ObjectMapper.Map<List<CompanyMain>, List<CompanyMainsDto>>(itemsCompanyMain, Result);
                }

            if (ex.Data.Count > 0)
                throw ex;
            return Result;
        }

        public virtual async Task<CompanyMainsDto> GetCompanyMainAsync(CompanyMainInput input)
        {
            var Result = new CompanyMainsDto();
            var ex = new UserFriendlyException("錯誤訊息");

            //常用

            //系統層級
            var TenantId = CurrentTenant.Id;
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //強制把input帶入系統值
            //input.CompanyMainId = CompanyMainId;

            //外部傳入
            var Id = input.Id;
            //var RefreshItem = input.RefreshItem;

            //預設值
            //input.Sort = input.Sort != null ? input.Sort : ShareDefine.Sort;
            //input.DateA = input.DateA != null ? input.DateA : ShareDefine.DateA;
            //input.DateD = input.DateD != null ? input.DateD : ShareDefine.DateD;
            

            //檢查
            if (SystemUserRoleKeys > 5)
                ex.Data.Add(GuidGenerator.Create().ToString(), "您沒有權限");

            //主體資料
            var qrbCompanyMain = await _appService._companyMainRepository.GetQueryableAsync();
            var qrbsCompanyMain = from c in qrbCompanyMain
                                      //where c.DateA <= ShareDefine.DateTimeNow && ShareDefine.DateTimeNow <= c.DateD
                                      //&& c.Status == "1"                      
                                  select c;

            if (ex.Data.Count == 0)
            {
                using (_appService._dataFilter.Disable<IMultiTenant>())
                {
                    var qrbCompanyUser = await _appService._companyUserRepository.GetQueryableAsync();
                    var qrbsCompanyUser = qrbCompanyUser.Where(p => p.UserMainId == UserMainId);
                    var ListCompanyMainId = qrbsCompanyUser.Select(p => p.CompanyMainId);

                    //如果是一般公司
                    if (SystemUserRoleKeys > 2)
                        qrbsCompanyMain = qrbsCompanyMain.Where(p => ListCompanyMainId.Contains(p.Id) || p.TenantId == TenantId);

                    var itemCompanyMain = qrbsCompanyMain.FirstOrDefault(p => p.Id == Id);
                    if (itemCompanyMain == null)
                        ex.Data.Add(GuidGenerator.Create().ToString(), "沒有這筆資料");

                    ObjectMapper.Map(itemCompanyMain, Result);
                }
            }
            if (ex.Data.Count > 0)
                throw ex;
            return Result;
        }

        public virtual async Task<ResultDto<CompanyMainDto>> SaveCompanyMainAsync(CompanyMainDto input)
        {
            var Result = new ResultDto<CompanyMainDto>();
            Result.Data = new CompanyMainDto();
            Result.Version = "2023033001";

            var DateNow = DateTime.Now;

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            if (SystemUserRoleKeys >= 8)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "您沒有權限" });

            var Id = input.Id;

            using (_appService._dataFilter.Disable<IMultiTenant>())
            {
                var itemsCompanyUser = await _appService._companyUserRepository.GetQueryableAsync();
                itemsCompanyUser = itemsCompanyUser.Where(p => p.UserMainId == UserMainId);

                var ListCompanyMainId = itemsCompanyUser.Select(p => p.CompanyMainId);

                if (SystemUserRoleKeys >= 4)
                    if (!ListCompanyMainId.Contains(Id))
                        Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "您沒有權限" });

                if (Result.Messages.Count == 0)
                {
                    var itemsAll = await _appService._companyMainRepository.GetQueryableAsync();
                    var item = itemsAll.FirstOrDefault(p => p.Id == Id);
                    if (item == null)
                    {
                        //僅只有管理權限的人 才可以新增公司
                        if (SystemUserRoleKeys >= 1)
                            Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "您沒有權限" });
                        else
                        {
                            item = new CompanyMain();
                            await _appService._companyMainRepository.InsertAsync(item);
                            item.Status = "1";
                        }
                    }
                    else
                        await _appService._companyMainRepository.UpdateAsync(item);

                    if (Result.Messages.Count == 0)
                    {
                        item.Name = input.Name;
                        item.Compilation = input.Compilation;
                        item.OfficePhone = input.OfficePhone;
                        item.FaxPhone = input.FaxPhone;
                        item.Address = input.Address;
                        item.Principal = input.Principal;
                        item.AllowSearch = input.AllowSearch;
                        item.ExtendedInformation = input.ExtendedInformation;
                        item.DateA = input.DateA;
                        item.DateD = input.DateD;
                        item.Sort = input.Sort;
                        item.Note = input.Note;

                        var Data = ObjectMapper.Map<CompanyMain, CompanyMainsDto>(item);

                        Result.Data = Data;
                        Result.Save = true;
                    }
                }
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<CompanyMainsDto> DeleteCompanyMainAsync(DeleteCompanyMainInput input)
        {
            //結果
            var Result = new CompanyMainsDto();
            var ex = new UserFriendlyException("錯誤訊息");

            //常用

            //系統層級
            var TenantId = CurrentTenant.Id;
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //強制把input帶入系統值
            //input.CompanyMainId = CompanyMainId;

            //外部傳入
            var Id = input.Id;
            //var RefreshItem = input.RefreshItem;

            //預設值
            //input.Sort = input.Sort != null ? input.Sort : ShareDefine.Sort;
            //input.DateA = input.DateA != null ? input.DateA : ShareDefine.DateA;
            //input.DateD = input.DateD != null ? input.DateD : ShareDefine.DateD;

            //檢查
            if (SystemUserRoleKeys > 5)
                ex.Data.Add(GuidGenerator.Create().ToString(), "您沒有權限");

            if (CompanyMainId == Id)
                ex.Data.Add(GuidGenerator.Create().ToString(), "您無法刪除自己");

            //主體資料
            var qrbCompanyMain = await _appService._companyMainRepository.GetQueryableAsync();
            var qrbsCompanyMain = from c in qrbCompanyMain
                                      //where c.DateA <= ShareDefine.DateTimeNow && ShareDefine.DateTimeNow <= c.DateD
                                      //&& c.Status == "1"                      
                                  select c;

            if (ex.Data.Count == 0)
                using (_appService._dataFilter.Disable<IMultiTenant>())
                {
                    var qrbCompanyUser = await _appService._companyUserRepository.GetQueryableAsync();
                    var qrbsCompanyUser = qrbCompanyUser.Where(p => p.UserMainId == UserMainId);
                    var ListCompanyMainId = qrbsCompanyUser.Select(p => p.CompanyMainId);

                    var itemCompanyMain = qrbCompanyMain.FirstOrDefault(p => p.Id == Id);
                    if (itemCompanyMain == null)
                        ex.Data.Add(GuidGenerator.Create().ToString(), "您沒有權限");
                    else
                    {
                        await _appService._companyMainRepository.DeleteAsync(itemCompanyMain);
                        ObjectMapper.Map(itemCompanyMain, Result);
                    }
                }

            if (ex.Data.Count > 0)
                throw ex;
            return Result;
        }



        public virtual async Task<CompanyMainsDto> UpdateCompanyMainAsync(UpdateCompanyMainInput input)
        {
            // 結果
            var Result = new CompanyMainsDto();

            //系統層
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            // input id
            //input.Id = CompanyMainId;

            // 外部傳入
            CompanyMainId = input.Id;
            var RefreshItem = input.RefreshItem;

            //固定資料
            input.Sort = input.Sort != null ? input.Sort : ShareDefine.Sort;
            input.DateA = input.DateA != null ? input.DateA : ShareDefine.DateA;
            input.DateD = input.DateD != null ? input.DateD : ShareDefine.DateD;

            //檢查
            await UpdateCompanyMainCheckAsync(input);

            //主體資料
            var qrbCompanyMain = await _appService._companyMainRepository.GetQueryableAsync();
            var itemCompanyJobMain = qrbCompanyMain.FirstOrDefault(p => p.Id == CompanyMainId);

            //不要變更的值
            input.Name = itemCompanyJobMain.Name;
            input.Compilation = itemCompanyJobMain.Compilation;
            input.Sort = itemCompanyJobMain.Sort;
            input.DateA = itemCompanyJobMain.DateA;
            input.DateD = itemCompanyJobMain.DateD;

            //映射
            itemCompanyJobMain = ObjectMapper.Map<UpdateCompanyMainInput, CompanyMain>(input);
            itemCompanyJobMain = await _appService._companyMainRepository.UpdateAsync(itemCompanyJobMain);

            //如果要更新為最新資料 就需要認可交易
            if (RefreshItem)
                await _appService._unitOfWorkManager.Current.SaveChangesAsync();

            ObjectMapper.Map(itemCompanyJobMain, Result);
            return Result;
        }

        public virtual async Task<ResultDto> UpdateCompanyMainCheckAsync(UpdateCompanyMainInput input)
        {
            var Result = new ResultDto();

            var IndustryCategory = input.IndustryCategory;
            var CapitalAmount = input.CapitalAmount;
            var CompanyUserId = input.CompanyUserId;
            var OfficePhone = input.OfficePhone;
            var Address = input.Address;
            var Principal = input.Principal;

            if (IndustryCategory.IsNullOrEmpty())
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "產業類別不能空白", Pass = false });
            if (CompanyUserId == null)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "人事聯絡人不能空白", Pass = false });
            if (OfficePhone.IsNullOrEmpty())
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "電話不能空白", Pass = false });
            if (Address.IsNullOrEmpty())
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "地址不能空白", Pass = false });
            if (Principal.IsNullOrEmpty())
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "負責人不能空白", Pass = false });

            var itemsCompanyMain = await _appService._companyMainRepository.GetQueryableAsync();
            var item = itemsCompanyMain.FirstOrDefault(p => p.Id == CompanyMainId);
            if (item == null)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "資料不存在", Pass = false });

            Result.Check = !Result.Messages.Any(p => !p.Pass);

            return Result;
        }

        public virtual async Task<UpdateCompanyMainCompanyProfileDto> UpdateCompanyMainCompanyProfileAsync(UpdateCompanyMainCompanyProfileInput input)
        {
            var Result = new UpdateCompanyMainCompanyProfileDto();

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            var CompanyMainId = input.CompanyMainId;
            var CompanyProfile = input.CompanyProfile ?? "";

            var qrbCompanyMain = await _appService._companyMainRepository.GetQueryableAsync();
            var itemCompanyMain = qrbCompanyMain.FirstOrDefault(p => p.Id == CompanyMainId);

            var ResultMessage = await UpdateCompanyMainCompanyProfileCheckAsync(input);

            if (ResultMessage.Check)
            {
                itemCompanyMain.CompanyProfile = CompanyProfile;
                await _appService._companyMainRepository.UpdateAsync(itemCompanyMain);
                Result = ObjectMapper.Map<CompanyMain, UpdateCompanyMainCompanyProfileDto>(itemCompanyMain);
            }
            return Result;
        }

        public virtual async Task<ResultDto> UpdateCompanyMainCompanyProfileCheckAsync(UpdateCompanyMainCompanyProfileInput input)
        {
            var Result = new ResultDto();

            var CompanyMainId = input.CompanyMainId;
            var CompanyProfile = input.CompanyProfile ?? "";

            //if (CompanyMainId == null)
            //    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "代碼不能空白", Pass = false });

            if (CompanyProfile.IsNullOrEmpty())
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "簡介不能空白", Pass = false });

            var qrbCompanyMain = await _appService._companyMainRepository.GetQueryableAsync();
            var itemCompanyMain = qrbCompanyMain.FirstOrDefault(p => p.Id == CompanyMainId);
            if (itemCompanyMain == null)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "資料不存在", Pass = false });

            Result.Check = !Result.Messages.Any(p => !p.Pass);

            return Result;
        }

        public virtual async Task<UpdateCompanyMainBusinessPhilosophyDto> UpdateCompanyMainBusinessPhilosophyAsync(UpdateCompanyMainBusinessPhilosophyInput input)
        {
            var Result = new UpdateCompanyMainBusinessPhilosophyDto();
            var Datenow = DateTime.Now;

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKes = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            var Id = input.CompanyMainId;

            var qrbCompanyMain = await _appService._companyMainRepository.GetQueryableAsync();
            var itemCompanyMain = qrbCompanyMain.FirstOrDefault(p => p.Id == Id);

            var ResultMessage = await UpdateCompanyMainBusinessPhilosophyCheckAsync(input);

            if (ResultMessage.Check)
            {
                itemCompanyMain.BusinessPhilosophy = input.BusinessPhilosophy;
                await _appService._companyMainRepository.UpdateAsync(itemCompanyMain);

                Result = ObjectMapper.Map<CompanyMain, UpdateCompanyMainBusinessPhilosophyDto>(itemCompanyMain);
            }

            return Result;
        }

        public virtual async Task<ResultDto> UpdateCompanyMainBusinessPhilosophyCheckAsync(UpdateCompanyMainBusinessPhilosophyInput input)
        {
            var Result = new ResultDto();
            var CompanyMainId = input.CompanyMainId;
            var BusinessPhilosophy = input.BusinessPhilosophy ?? "";

            //if (CompanyMainId==null)
            //    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "代碼不能空白", Pass = false });
            if (BusinessPhilosophy.IsNullOrEmpty())
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "經營理念不能空白", Pass = false });

            var itemsCompanyMain = await _appService._companyMainRepository.GetQueryableAsync();
            var item = itemsCompanyMain.FirstOrDefault(p => p.Id == CompanyMainId);

            if (item == null)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "資料不存在", Pass = false });

            Result.Check = !Result.Messages.Any(p => !p.Pass);

            return Result;
        }

        public virtual async Task<UpdateCompanyMainOperatingItemsDto> UpdateCompanyMainOperatingItemsAsync(UpdateCompanyMainOperatingItemsInput input)
        {
            var Result = new UpdateCompanyMainOperatingItemsDto();
            var DateNow = DateTime.Now;

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKes = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            var CompanyMainId = input.CompanyMainId;

            var qrbCompanyMain = await _appService._companyMainRepository.GetQueryableAsync();
            var item = qrbCompanyMain.FirstOrDefault(p => p.Id == CompanyMainId);

            var ResultMessage = await UpdateCompanyMainOperatingItemsCheckAsync(input);

            if (ResultMessage.Check)
            {
                item.OperatingItems = input.OperatingItems;
                await _appService._companyMainRepository.UpdateAsync(item);

                Result = ObjectMapper.Map<CompanyMain, UpdateCompanyMainOperatingItemsDto>(item);
            }
            return Result;
        }

        public virtual async Task<ResultDto> UpdateCompanyMainOperatingItemsCheckAsync(UpdateCompanyMainOperatingItemsInput input)
        {
            var Result = new ResultDto();
            var CompanyMainId = input.CompanyMainId;
            var OperatingItems = input.OperatingItems ?? "";

            //if (CompanyMainId.IsNullOrEmpty())
            //    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "代碼不能空白", Pass = false });
            if (OperatingItems.IsNullOrEmpty())
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "主要項目不能空白", Pass = false });

            var itemsCompanyMain = await _appService._companyMainRepository.GetQueryableAsync();
            var item = itemsCompanyMain.FirstOrDefault(p => p.Id == CompanyMainId);

            if (item == null)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "資料不存在", Pass = false });

            Result.Check = !Result.Messages.Any(p => !p.Pass);

            return Result;
        }

        public virtual async Task<UpdateCompanyMainWelfareSystemDto> UpdateCompanyMainWelfareSystemAsync(UpdateCompanyMainWelfareSystemInput input)
        {
            var Result = new UpdateCompanyMainWelfareSystemDto();
            var DateNow = DateTime.Now;

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKes = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            var CompanyMainId = input.CompanyMainId;

            var qrbCompanyMain = await _appService._companyMainRepository.GetQueryableAsync();
            var item = qrbCompanyMain.FirstOrDefault(p => p.Id == CompanyMainId);

            var ResultMessage = await UpdateCompanyMainWelfareSystemCheckAsync(input);

            if (ResultMessage.Check)
            {
                item.WelfareSystem = input.WelfareSystem;
                await _appService._companyMainRepository.UpdateAsync(item);

                Result = ObjectMapper.Map<CompanyMain, UpdateCompanyMainWelfareSystemDto>(item);
            }
            return Result;

        }

        /// <summary>
        /// 檢查公司福利制度方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public virtual async Task<ResultDto> UpdateCompanyMainWelfareSystemCheckAsync(UpdateCompanyMainWelfareSystemInput input)
        {
            var Result = new ResultDto();

            var CompanyMainId = input.CompanyMainId;
            var WelfareSystem = input.WelfareSystem ?? "";

            //if (CompanyMainId.IsNullOrEmpty())
            //    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "代碼不能空白", Pass = false });
            if (WelfareSystem.IsNullOrEmpty())
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "福利不能空白", Pass = false });

            var itemsCompanyMain = await _appService._companyMainRepository.GetQueryableAsync();
            var item = itemsCompanyMain.FirstOrDefault(p => p.Id == CompanyMainId);

            if (item == null)
                //throw new UserFriendlyException(message:"").Data.Add();
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "資料不存在", Pass = false });

            Result.Check = !Result.Messages.Any(p => !p.Pass);
            return Result;
        }
    }
}
