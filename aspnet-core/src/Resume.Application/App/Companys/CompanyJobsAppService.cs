using Resume.App.Users;
using Resume.CompanyJobs;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Resume.App.Companys
{
    public partial class CompanysAppService : ApplicationService, ICompanysAppService
    {
        public virtual async Task<ResultDto<List<CompanyJobsDto>>> GetCompanyJobListAsync(CompanyJobListInput input)
        {
            var Result = new ResultDto<List<CompanyJobsDto>>();
            Result.Data = new List<CompanyJobsDto>();
            Result.Version = "2023040101";

            var DateNow = DateTime.Now;

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            if (SystemUserRoleKeys >= 16)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "您沒有權限" });

            if (Result.Messages.Count == 0)
            {
                //預設走Tenant原則 只會取得自己的Tenant名單
                var itemsAll = await _appService._companyJobRepository.GetQueryableAsync();
                var items = itemsAll.ToList();

                var Data = ObjectMapper.Map<List<CompanyJob>, List<CompanyJobsDto>>(items);
                Data = (from c in Data
                        where c.DateA <= DateNow && DateNow <= c.DateD
                        && c.Status == "1"
                        orderby c.Sort
                        select c).ToList();

                Result.Data = Data;
                Result.Save = true;
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }
        public virtual async Task<ResultDto<CompanyJobsDto>> GetCompanyJobAsync(CompanyJobInput input)
        {
            var Result = new ResultDto<CompanyJobsDto>();
            Result.Data = new CompanyJobsDto();
            Result.Version = "2023040101";

            var DateNow = DateTime.Now;

            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            var Id = input.Id;

            if (SystemUserRoleKeys >= 16)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "您沒有權限" });

            if (Result.Messages.Count == 0)
            {
                //預設走Tenant原則 只會取得自己的Tenant名單
                var itemsAll = await _appService._companyJobRepository.GetQueryableAsync();
                var item = itemsAll.FirstOrDefault(p => p.Id == Id);

                var Data = ObjectMapper.Map<CompanyJob, CompanyJobsDto>(item);

                Result.Data = Data;
                Result.Save = true;
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }
        public virtual async Task<ResultDto<CompanyJobDto>> SaveCompanyJobAsync(CompanyJobDto input)
        {
            var Result = new ResultDto<CompanyJobDto>();
            Result.Data = new CompanyJobDto();
            Result.Version = "2023040101";

            var DateNow = DateTime.Now;

            var CurrentTenantId = CurrentTenant.Id;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            var Id = input.Id;
            var CompanyMainId = input.CompanyMainId;

            if (SystemUserRoleKeys >= 16)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "您沒有權限" });

            //判斷公司是否與CurrentTenantId一致
            var itemsCompanyMain = await _appService._companyMainRepository.GetQueryableAsync();
            var itemCompanyMain = itemsCompanyMain.FirstOrDefault(p => p.Id == CompanyMainId);

            if (itemCompanyMain == null)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "您沒有權限" });

            if (Result.Messages.Count == 0)
            {
                //大小寫會造成錯誤
                CompanyMainId = itemCompanyMain.Id;

                //預設走Tenant原則 只會取得自己的Tenant名單
                var itemsAll = await _appService._companyJobRepository.GetQueryableAsync();
                var item = itemsAll.FirstOrDefault(p => p.Id == Id);
                if (item == null)
                {
                    item = new CompanyJob();
                    await _appService._companyJobRepository.InsertAsync(item);
                    item.CompanyMainId = CompanyMainId;
                    item.Status = "1";
                }
                else
                    await _appService._companyJobRepository.UpdateAsync(item);

                item.Name = input.Name ?? "";
                item.JobTypeCode = input.JobTypeCode ?? "";
                item.JobOpen = input.JobOpen;
                item.MailTplId = input.MailTplId ?? "";
                item.SMSTplId = input.SMSTplId ?? "";
                item.ExtendedInformation = input.ExtendedInformation;
                item.DateA = input.DateA;
                item.DateD = input.DateD;
                item.Sort = input.Sort;
                item.Note = input.Note;

                var Data = ObjectMapper.Map<CompanyJob, CompanyJobDto>(item);

                Result.Data = Data;
                Result.Save = true;
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }
        public virtual async Task<ResultDto<DeleteCompanyJobDto>> DeleteCompanyJobAsync(DeleteCompanyJobInput input)
        {
            var Result = new ResultDto<DeleteCompanyJobDto>();
            Result.Data = new DeleteCompanyJobDto();
            Result.Version = "2023040101";

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
                var itemsAll = await _appService._companyJobRepository.GetQueryableAsync();
                var item = itemsAll.FirstOrDefault(p => p.Id == Id);
                if (item != null)
                {
                    var CompanyJobId = item.Id;

                    item.Status = "2";
                    await _appService._companyJobRepository.DeleteAsync(item);

                    //刪除邀請涵及其所有資料
                    var itemsAllCompanyInvitations = await _appService._companyInvitationsRepository.GetQueryableAsync();
                    var itemsCompanyInvitations = itemsAllCompanyInvitations.Where(p => p.CompanyJobId == CompanyJobId).ToList();
                    foreach (var itemCompanyInvitations in itemsCompanyInvitations)
                    {
                        var inputDeleteCompanyInvitations = new DeleteCompanyInvitationsInput();
                        inputDeleteCompanyInvitations.Id = itemCompanyInvitations.Id;
                        await DeleteCompanyInvitationsAsync(inputDeleteCompanyInvitations);
                    }

                    Result.Data.Pass = true;
                    Result.Save = true;
                }
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }
    }
}
