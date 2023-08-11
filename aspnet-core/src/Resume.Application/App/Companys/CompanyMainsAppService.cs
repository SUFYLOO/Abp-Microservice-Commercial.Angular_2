﻿using Resume.App.Users;
using Resume.CompanyMains;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.MultiTenancy;

namespace Resume.App.Companys
{
    public partial class CompanysAppService : ApplicationService, ICompanysAppService
    {
        public virtual async Task<ResultDto<List<CompanyMainsDto>>> GetCompanyMainListAsync(CompanyMainListInput input)
        {
            var Result = new ResultDto<List<CompanyMainsDto>>();
            Result.Data = new List<CompanyMainsDto>();
            Result.Version = "2023033001";

            var DateNow = DateTime.Now;

            var CurrentTenantId = CurrentTenant.Id;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //由登入者的CurrentUser.Id尋找CompanyUser.UserMainId      
            //得到公司的主檔代碼(可能有多筆，來自於不同的，也可能來自於不同的租戶)
            if (SystemUserRoleKeys >= 16)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "您沒有權限" });

            using (_appService._dataFilter.Disable<IMultiTenant>())
            {
                var itemsCompanyUser = await _appService._companyUserRepository.GetQueryableAsync();
                itemsCompanyUser = itemsCompanyUser.Where(p => p.UserMainId == UserMainId);

                var ListCompanyMainId = itemsCompanyUser.Select(p => p.CompanyMainId);

                var itemsAll = await _appService._companyMainRepository.GetQueryableAsync();
                var items = itemsAll.Where(p => ListCompanyMainId.Contains(p.Id) || p.TenantId == CurrentTenantId).ToList();
                if (SystemUserRoleKeys <= 2)    //系統廠可以看
                    items = itemsAll.ToList();

                if (Result.Messages.Count == 0)
                {
                    var Data = ObjectMapper.Map<List<CompanyMain>, List<CompanyMainsDto>>(items);
                    Data = (from c in Data
                                //where c.DateA <= DateNow && DateNow <= c.DateD
                            where c.Status == "1"
                            orderby c.Sort
                            select c).ToList();

                    Result.Data = Data;
                    Result.Save = true;
                }
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<CompanyMainsDto>> GetCompanyMainAsync(CompanyMainInput input)
        {
            var Result = new ResultDto<CompanyMainsDto>();
            Result.Data = new CompanyMainsDto();
            Result.Version = "2023051101";

            var DateNow = DateTime.Now;

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //由Id取得公司資料
            if (SystemUserRoleKeys >= 16)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "您沒有權限" });

            var Id = input.Id;

            using (_appService._dataFilter.Disable<IMultiTenant>())
            {
                //理論上 一個使用者只會對應到一間公司 但未來會開放一個使用者 可以跨公司管理不同的租戶資料 目前如果要實現 只能改資料庫的欄位值 到CompanyUser新增一筆資料
                var itemsCompanyUser = await _appService._companyUserRepository.GetQueryableAsync();
                itemsCompanyUser = itemsCompanyUser.Where(p => p.UserMainId == UserMainId);

                var ListCompanyMainId = itemsCompanyUser.Select(p => p.CompanyMainId).ToList();

                if (SystemUserRoleKeys >= 4)
                    if (!ListCompanyMainId.Contains(Id))
                        Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "您沒有權限" });

                if (Result.Messages.Count == 0)
                {
                    var itemsAll = await _appService._companyMainRepository.GetQueryableAsync();
                    var item = itemsAll.FirstOrDefault(p => p.Id == Id);

                    var Data = ObjectMapper.Map<CompanyMain, CompanyMainsDto>(item);

                    Result.Data = Data;
                    Result.Save = true;
                }
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<DeleteCompanyMainDto>> DeleteCompanyMainAsync(DeleteCompanyMainInput input)
        {
            var Result = new ResultDto<DeleteCompanyMainDto>();
            Result.Data = new DeleteCompanyMainDto();
            Result.Version = "2023033001";

            var DateNow = DateTime.Now;

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            if (SystemUserRoleKeys >= 16)
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

                var itemsAll = await _appService._companyMainRepository.GetQueryableAsync();
                var item = itemsAll.FirstOrDefault(p => p.Id == Id);
                if (item != null)
                {
                    //僅只有管理權限的人 才可以刪除
                    if (SystemUserRoleKeys >= 2)
                        Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "您沒有權限" });

                    if (Result.Messages.Count == 0)
                    {
                        item.Status = "2";
                        await _appService._companyMainRepository.DeleteAsync(item);

                        Result.Data.Pass = true;
                        Result.Save = true;
                    }
                }
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<UpdateCompanyMainDto> UpdateCompanyMainAsync(UpdateCompanyMainInput input)
        {
            var Result = new UpdateCompanyMainDto();

            var DateNow = DateTime.Now;

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            var Id = CompanyMainId;

            var itemsCompanyMain = await _appService._companyMainRepository.GetQueryableAsync();
            var item = itemsCompanyMain.FirstOrDefault(p => p.Id == Id);
            //check
            var ResultMessage = await UpdateCompanyMainCheckAsync(input);

            if (ResultMessage.Check)
            {
                item.IndustryCategory = input.IndustryCategory;
                item.CapitalAmount = input.CapitalAmount;
                item.HideCapitalAmount = input.HideCapitalAmount;
                item.CompanyScaleCode = input.CompanyScaleCode;
                item.CompanyUrl = input.CompanyUrl;
                item.CompanyUserId = input.CompanyUserId;
                item.OfficePhone = input.OfficePhone;
                item.FaxPhone = input.FaxPhone;
                item.Address = input.Address;
                item.Principal = input.Principal;
                item.HidePrincipal = input.HidePrincipal;
                await _appService._companyMainRepository.UpdateAsync(item);
                Result = ObjectMapper.Map<CompanyMain, UpdateCompanyMainDto>(item);
            }
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
            var DateNow = DateTime.Now;

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