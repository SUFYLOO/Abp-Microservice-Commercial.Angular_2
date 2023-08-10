using AutoMapper;
using Resume.App.Shares;
using Resume.App.Users;
using Resume.CompanyInvitationss;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.MultiTenancy;

namespace Resume.App.Companys
{
    public partial class CompanysAppService : ApplicationService, ICompanysAppService
    {
        public virtual async Task<ResultDto<CompanyInvitationssDto>> SaveCompanyInvitationsAsync(CompanyInvitationsDto input)
        {
            var Result = new ResultDto<CompanyInvitationssDto>();
            Result.Data = new CompanyInvitationssDto();
            Result.Version = "2023040801";

            var DateNow = DateTime.Now;

            var CurrentTenantId = CurrentTenant.Id;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            var Id = input.Id;
            var CompanyMainId = input.CompanyMainId;
            var CompanyJobId = input.CompanyJobId;

            if (SystemUserRoleKeys >= 16)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "您沒有權限" });

            //判斷公司是否與CurrentTenantId一致
            var itemsAllCompanyMain = await _appService._companyMainRepository.GetQueryableAsync();

            //使用CurrentTenantId 尋找CompnayMainId
            var itmeCompanyMain = itemsAllCompanyMain.FirstOrDefault(p => p.TenantId == CurrentTenantId);
            if (itmeCompanyMain == null)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "您沒有權限" });

            if (Result.Messages.Count == 0)
            {
                //把公司代碼 更改成實際代碼 避免傳入大小寫的問題
                CompanyMainId = itmeCompanyMain.Id;

                //預設走Tenant原則 只會取得自己的Tenant名單
                var itemsAll = await _appService._companyInvitationsRepository.GetQueryableAsync();
                var item = itemsAll.FirstOrDefault(p => p.Id == Id);
                if (item == null)
                {
                    item = new CompanyInvitations();
                    await _appService._companyInvitationsRepository.InsertAsync(item);
                    item.CompanyMainId = CompanyMainId;
                    item.Status = "1";
                }
                else
                    await _appService._companyInvitationsRepository.UpdateAsync(item);

                item.OpenAllJob = input.OpenAllJob;
                item.UserMainId = item.UserMainId != null ? item.UserMainId : input.UserMainId;  //使用者綁定的方式，只能從使用者點擊
                item.UserCompanyBindId = item.UserMainId != null  ? item.UserCompanyBindId : input.UserCompanyBindId ?? null;  //使用者綁定的方式，只能從使用者點擊
                item.ResumeSnapshotId = item.UserMainId != null  ? item.ResumeSnapshotId : input.ResumeSnapshotId ?? null;  //使用者綁定的方式，只能從使用者點擊
                item.CompanyJobId = item.UserMainId != null  ? item.CompanyJobId : input.CompanyJobId ?? null;   //一旦使用者綁定，則無法修改
                item.UserMainName = input.UserMainName ?? "";
                item.UserMainLoginMobilePhone = input.UserMainLoginMobilePhone ?? "";
                item.UserMainLoginEmail = input.UserMainLoginEmail ?? "";
                item.UserMainLoginIdentityNo = input.UserMainLoginIdentityNo ?? "";
                item.SendTypeCode = input.SendTypeCode ?? "";
                item.SendStatusCode = input.SendStatusCode ?? "";
                item.ResumeFlowStageCode = input.ResumeFlowStageCode ?? "";
                item.IsRead = input.IsRead;
                item.ExtendedInformation = input.ExtendedInformation;
                item.DateA = input.DateA;
                item.DateD = input.DateD;
                item.Sort = input.Sort;
                item.Note = input.Note;

                var Data = ObjectMapper.Map<CompanyInvitations, CompanyInvitationssDto>(item);

                var itemsAllCompanyJob = await _appService._companyJobRepository.GetQueryableAsync();

                var itemCompanyMain = itemsAllCompanyMain.FirstOrDefault(p => p.Id == CompanyMainId);
                var itemCompanyJob = itemsAllCompanyJob.FirstOrDefault(p => p.Id == CompanyJobId);

                if (itemCompanyMain != null)
                    Data.CompanyMainName = itemCompanyMain.Name;

                if (itemCompanyJob != null)
                    Data.CompanyJobName = itemCompanyJob.Name;

                var inputShareCodeGroup = new ShareCodeGroupInput();
                inputShareCodeGroup.ListGroupCode.Add("SendType");
                inputShareCodeGroup.ListGroupCode.Add("SendStatus");
                inputShareCodeGroup.ListGroupCode.Add("ResumeFlowStage");
                var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);

                var inputSetShareCode = new SetShareCodeInput();
                inputSetShareCode.ListShareCode = itemsShareCode;
                inputSetShareCode.Data = new List<CompanyInvitationssDto>() { Data };
                var ListColumns = new List<NameCodeStandardDto>();
                ListColumns.Add(new NameCodeStandardDto { GroupCode = "SendType", Code = "SendTypeCode", Name = "SendTypeName" });
                ListColumns.Add(new NameCodeStandardDto { GroupCode = "SendStatus", Code = "SendStatusCode", Name = "SendStatusName" });
                ListColumns.Add(new NameCodeStandardDto { GroupCode = "ResumeFlowStage", Code = "ResumeFlowStageCode", Name = "ResumeFlowStageName" });
                inputSetShareCode.ListColumns = ListColumns;
                _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<CompanyInvitationssDto>(inputSetShareCode);

                Result.Data = Data;
                Result.Save = true;
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }
        public virtual async Task<ResultDto<DeleteCompanyInvitationsAsyncDto>> DeleteCompanyInvitationsAsync(DeleteCompanyInvitationsInput input)
        {
            var Result = new ResultDto<DeleteCompanyInvitationsAsyncDto>();
            Result.Data = new DeleteCompanyInvitationsAsyncDto();
            Result.Version = "2023050301";

            var DateNow = DateTime.Now;

            var CurrentTenantId = CurrentTenant.Id;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            var Id = input.Id;

            if (SystemUserRoleKeys >= 16)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "您沒有權限" });

            if (Result.Messages.Count == 0)
            {
                //預設走Tenant原則 只會取得自己的Tenant名單
                var itemsAll = await _appService._companyInvitationsRepository.GetQueryableAsync();
                var item = itemsAll.FirstOrDefault(p => p.Id == Id);
                if (item != null)
                {
                    var UserCompanyBindId = item.UserCompanyBindId;
                    var ResumeSnapshotId = item.ResumeSnapshotId;

                    item.Status = "2";
                    await _appService._companyInvitationsRepository.DeleteAsync(item);

                    //刪除綁定資料 及履歷快照
                    using (_appService._dataFilter.Disable<IMultiTenant>())
                    {
                        var itemsAllUserCompanyBind = await _appService._userCompanyBindRepository.GetQueryableAsync();
                        var itemUserCompanyBind = itemsAllUserCompanyBind.FirstOrDefault(p => p.Id == UserCompanyBindId);
                        if (itemUserCompanyBind != null)
                        {
                            itemUserCompanyBind.Status = "2";
                            await _appService._userCompanyBindRepository.DeleteAsync(itemUserCompanyBind);
                        }

                        var itemsResumeSnapshot = await _appService._resumeSnapshotRepository.GetQueryableAsync();
                        var itemResumeSnapshot = itemsResumeSnapshot.FirstOrDefault(p => p.Id == ResumeSnapshotId);
                        if (itemResumeSnapshot != null)
                        {
                            itemResumeSnapshot.Status = "2";
                            await _appService._resumeSnapshotRepository.DeleteAsync(itemResumeSnapshot);
                        }
                    }

                    Result.Data.Pass = true;
                    Result.Save = true;
                }
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }
        public virtual async Task<ResultDto<GenerateLinkCompanyInvitationsDto>> GenerateLinkCompanyInvitationsAsync(GenerateLinkCompanyInvitationsInput input)
        {
            var Result = new ResultDto<GenerateLinkCompanyInvitationsDto>();
            Result.Data = new GenerateLinkCompanyInvitationsDto();
            Result.Version = "2023040201";

            var DateNow = DateTime.Now;

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            var Id = input.Id;

            if (SystemUserRoleKeys >= 16)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "您沒有權限" });

            if (Result.Messages.Count == 0)
            {
                //預設走Tenant原則 只會取得自己的Tenant名單
                var itemsAll = await _appService._companyInvitationsRepository.GetQueryableAsync();
                var item = itemsAll.FirstOrDefault(p => p.Id == Id);

                if (item != null)
                {
                    var inputShareDefault = new ShareDefaultUrlInput();
                    inputShareDefault.Key1 = CurrentTenant.Id == null ? "" : CurrentTenant.Id.ToString();
                    var itemShareDefault = await _appService._serviceProvider.GetService<SharesAppService>().GetShareDefaultUrlAsync(inputShareDefault);
                    if (itemShareDefault != null && itemShareDefault.Messages.Count == 0 && itemShareDefault.Data != null)
                    {
                        //未來需要實做加密
                        Result.Data.Url = itemShareDefault.Data.NotifyAdmission + item.Id;
                        Result.Save = true;
                    }
                }
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }
        public virtual async Task<ResultDto<CompanyInvitationssDto>> SendCompanyInvitationsAsync(SendCompanyInvitationsInput input)
        {
            var Result = new ResultDto<CompanyInvitationssDto>();
            Result.Data = new CompanyInvitationssDto();
            Result.Version = "2023040701";

            var DateNow = DateTime.Now;

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            var Id = input.Id;

            if (SystemUserRoleKeys >= 16)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "您沒有權限" });

            if (Result.Messages.Count == 0)
            {
                //預設走Tenant原則 只會取得自己的Tenant名單
                var itemsAll = await _appService._companyInvitationsRepository.GetQueryableAsync();
                var item = itemsAll.FirstOrDefault(p => p.Id == Id);

                if (item != null)
                {
                    //更新發送狀態
                    item.SendStatusCode = "已發送";
                    await _appService._companyInvitationsRepository.UpdateAsync(item);

                    var inputCompanyInvitations = new CompanyInvitationsInput();
                    inputCompanyInvitations.Id = Id;
                    Result = await GetCompanyInvitationsAsync(inputCompanyInvitations);

                    var inputShareDefault = new ShareDefaultUrlInput();
                    inputShareDefault.Key1 = CurrentTenant.Id == null ? "" : CurrentTenant.Id.ToString();
                    var itemShareDefault = await _appService._serviceProvider.GetService<SharesAppService>().GetShareDefaultUrlAsync(inputShareDefault);
                    if (itemShareDefault != null && itemShareDefault.Messages.Count == 0 && itemShareDefault.Data != null)
                    {
                        //未來需要實做加密
                        var Url = itemShareDefault.Data.NotifyAdmission + item.Id;

                        var inputSendShareSendQueue = new SendShareSendQueueInput();
                        var ToMail = item.UserMainLoginEmail;
                        var ToGsm = item.UserMainLoginMobilePhone;
                        inputSendShareSendQueue.Key3 = "11";    //郵件樣版
                        inputSendShareSendQueue.InstantSend = true;
                        inputSendShareSendQueue.ListToMail.Add(ToMail);
                        inputSendShareSendQueue.ListToGsm.Add(ToGsm);
                        inputSendShareSendQueue.SendTypeCode = SendType.Mail;
                        inputSendShareSendQueue.Where = true;
                        inputSendShareSendQueue.dcParameterSql.Add("Id", Id);
                        inputSendShareSendQueue.dcParameter.Add("NotifyAdmission", Url);
                        await _appService._serviceProvider.GetService<SharesAppService>().SendShareSendQueueAsync(inputSendShareSendQueue);

                        //Result.Data.Pass = true;
                        Result.Save = true;
                    }
                }
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public virtual async Task<ResultDto<List<CompanyInvitationssDto>>> GetCompanyInvitationsListAsync(CompanyInvitationsListInput input)
        {
            var Result = new ResultDto<List<CompanyInvitationssDto>>();
            Result.Data = new List<CompanyInvitationssDto>();
            Result.Version = "2023042001";

            var DateNow = DateTime.Now;

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            if (SystemUserRoleKeys >= 16)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "您沒有權限" });

            if (Result.Messages.Count == 0)
            {
                //預設走Tenant原則 只會取得自己的Tenant名單
                var itemsAll = await _appService._companyInvitationsRepository.GetQueryableAsync();
                var items = itemsAll.ToList();

                var Data = ObjectMapper.Map<List<CompanyInvitations>, List<CompanyInvitationssDto>>(items);
                Data = (from c in Data
                            //where c.DateA <= DateNow && DateNow <= c.DateD
                        where c.Status == "1"
                        orderby c.Sort
                        select c).ToList();

                var ListCompanyMainId = items.Select(p => p.CompanyMainId).ToList();
                var ListCompanyJobId = items.Select(p => p.CompanyJobId).ToList();

                var itemsAllCompanyMain = await _appService._companyMainRepository.GetQueryableAsync();
                var itemsAllCompanyJob = await _appService._companyJobRepository.GetQueryableAsync();

                var itemsCompanyMain = itemsAllCompanyMain.Where(p => ListCompanyMainId.Contains(p.Id)).ToList();
                var itemsCompanyJob = itemsAllCompanyJob.Where(p => ListCompanyMainId.Contains(p.CompanyMainId))
                       .Where(p => ListCompanyJobId.Contains(p.Id)).ToList();

                //取得網址
                var inputShareDefault = new ShareDefaultUrlInput();
                inputShareDefault.Key1 = CurrentTenant.Id == null ? "" : CurrentTenant.Id.ToString();
                var itemShareDefault = await _appService._serviceProvider.GetService<SharesAppService>().GetShareDefaultUrlAsync(inputShareDefault);

                foreach (var item in Data)
                {
                    var CompanyMainId = item.CompanyMainId;
                    var CompanyJobId = item.CompanyJobId;

                    var itemCompanyMain = itemsCompanyMain.FirstOrDefault(p => p.Id == CompanyMainId);
                    if (itemCompanyMain != null)
                        item.CompanyMainName = itemCompanyMain.Name;

                    var itemCompanyJob = itemsCompanyJob.FirstOrDefault(p => p.Id == CompanyJobId);
                    if (itemCompanyJob != null)
                        item.CompanyJobName = itemCompanyJob.Name;

                    //未來需要實做加密
                    if (itemShareDefault != null && itemShareDefault.Messages.Count == 0 && itemShareDefault.Data != null)
                        item.Url = itemShareDefault.Data.NotifyAdmission + item.Id;

                    //發信歷程
                    item.ListShareSendQueue = new List<ShareSendQueues.ShareSendQueueDto>();
                }

                var inputShareCodeGroup = new ShareCodeGroupInput();
                inputShareCodeGroup.ListGroupCode.Add("SendType");
                inputShareCodeGroup.ListGroupCode.Add("SendStatus");
                inputShareCodeGroup.ListGroupCode.Add("ResumeFlowStage");
                var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);

                var inputSetShareCode = new SetShareCodeInput();
                inputSetShareCode.ListShareCode = itemsShareCode;
                inputSetShareCode.Data = Data;
                var ListColumns = new List<NameCodeStandardDto>();
                ListColumns.Add(new NameCodeStandardDto { GroupCode = "SendType", Code = "SendTypeCode", Name = "SendTypeName" });
                ListColumns.Add(new NameCodeStandardDto { GroupCode = "SendStatus", Code = "SendStatusCode", Name = "SendStatusName" });
                ListColumns.Add(new NameCodeStandardDto { GroupCode = "ResumeFlowStage", Code = "ResumeFlowStageCode", Name = "ResumeFlowStageName" });
                inputSetShareCode.ListColumns = ListColumns;
                _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<CompanyInvitationssDto>(inputSetShareCode);

                Result.Data = Data;
                Result.Save = true;
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }
        public virtual async Task<ResultDto<CompanyInvitationssDto>> GetCompanyInvitationsAsync(CompanyInvitationsInput input)
        {
            var Result = new ResultDto<CompanyInvitationssDto>();
            Result.Data = new CompanyInvitationssDto();
            Result.Version = "2023040201";

            var DateNow = DateTime.Now;

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            var Id = input.Id;

            //為了提供給使用者使用 因此任何人皆可讀取-未來再想資安如何解決 暫時先這樣做
            //未來可能把使用者資訊夾到邀請涵的get參數裡
            //if (SystemUserRoleKeys >= 16)
            //    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "您沒有權限" });

            ////判斷公司是否與CurrentTenantId一致
            //var itemsAllCompanyMain = await _appService._companyMainRepository.GetQueryableAsync();

            ////使用CurrentTenantId 尋找CompnayMainId
            //var itmeCompanyMain = itemsAllCompanyMain.FirstOrDefault(p => p.TenantId == CurrentTenantId);
            //if (itmeCompanyMain == null)
            //    Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "您沒有權限" });

            if (Result.Messages.Count == 0)
            {
                using (_appService._dataFilter.Disable<IMultiTenant>())
                {
                    var itemsAll = await _appService._companyInvitationsRepository.GetQueryableAsync();
                    var item = itemsAll.FirstOrDefault(p => p.Id == Id);
                    if (item != null)
                    {
                        var CompanyJobId = item.CompanyJobId;

                        var Data = ObjectMapper.Map<CompanyInvitations, CompanyInvitationssDto>(item);

                        var itemsAllCompanyMain = await _appService._companyMainRepository.GetQueryableAsync();
                        var itemsAllCompanyJob = await _appService._companyJobRepository.GetQueryableAsync();

                        var itemCompanyMain = itemsAllCompanyMain.FirstOrDefault(p => p.Id == CompanyMainId);
                        var itemCompanyJob = itemsAllCompanyJob.FirstOrDefault(p => p.Id == CompanyJobId);

                        if (itemCompanyMain != null)
                            Data.CompanyMainName = itemCompanyMain.Name;

                        if (itemCompanyJob != null)
                            Data.CompanyJobName = itemCompanyJob.Name;

                        var inputShareCodeGroup = new ShareCodeGroupInput();
                        inputShareCodeGroup.ListGroupCode.Add("SendType");
                        inputShareCodeGroup.ListGroupCode.Add("SendStatus");
                        inputShareCodeGroup.ListGroupCode.Add("ResumeFlowStage");
                        var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);

                        var inputSetShareCode = new SetShareCodeInput();
                        inputSetShareCode.ListShareCode = itemsShareCode;
                        inputSetShareCode.Data = new List<CompanyInvitationssDto>() { Data };
                        var ListColumns = new List<NameCodeStandardDto>();
                        ListColumns.Add(new NameCodeStandardDto { GroupCode = "SendType", Code = "SendTypeCode", Name = "SendTypeName" });
                        ListColumns.Add(new NameCodeStandardDto { GroupCode = "SendStatus", Code = "SendStatusCode", Name = "SendStatusName" });
                        ListColumns.Add(new NameCodeStandardDto { GroupCode = "ResumeFlowStage", Code = "ResumeFlowStageCode", Name = "ResumeFlowStageName" });
                        inputSetShareCode.ListColumns = ListColumns;
                        _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<CompanyInvitationssDto>(inputSetShareCode);

                        Result.Data = Data;
                        Result.Save = true;
                    }
                }
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }
    }
}
