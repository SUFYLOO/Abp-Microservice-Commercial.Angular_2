using Resume.App.Users;
using Resume.ResumeSnapshots;
using Resume.UserInfos;
using Resume.UserMains;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.MultiTenancy;

namespace Resume.App.Companys
{
    [RemoteService(IsEnabled = false)]

    public partial class CompanysAppService : ApplicationService, ICompanysAppService
    {
        private readonly AppService _appService;

        public CompanysAppService(AppService appService)
        {
            _appService = appService;
        }

        public virtual async Task<ResultDto<List<UserResumeSnapshotsListDto>>> GetUserResumeSnapshotsListAsync(UserResumeSnapshotsListInput input)
        {
            var Result = new ResultDto<List<UserResumeSnapshotsListDto>>();
            Result.Data = new List<UserResumeSnapshotsListDto>();
            Result.Version = "2023052201";

            var DateNow = DateTime.Now;

            var CurrentTenantId = CurrentTenant.Id;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            if (SystemUserRoleKeys >= 16)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "您沒有權限" });

            //取得求職者資訊-經由履歷快照取得，相同的UserMainId應併同一列
            if (Result.Messages.Count == 0)
            {
                //預設走Tenant原則 只會取得自己的Tenant名單
                var itemsAllCompanyInvitations = await _appService._companyInvitationsRepository.GetQueryableAsync();
                itemsAllCompanyInvitations = itemsAllCompanyInvitations.Where(p => p.TenantId == CurrentTenantId && p.UserCompanyBindId != null);
                var itemsCompanyInvitations = itemsAllCompanyInvitations.ToList();  //有綁定的資料

                //取得UserMain
                var itemsAllUserMain = await _appService._userMainRepository.GetQueryableAsync();
                var itemsUserMain = new List<UserMain>();
                using (_appService._dataFilter.Disable<IMultiTenant>())
                    itemsUserMain = itemsAllUserMain.Where(u => itemsAllCompanyInvitations.Any(c => c.UserMainId == u.Id)).ToList();

                //取得取得UserInfo
                var itemsAllUserInfo = await _appService._userInfoRepository.GetQueryableAsync();
                var itemsUserInfo = new List<UserInfo>();
                using (_appService._dataFilter.Disable<IMultiTenant>())
                    itemsUserInfo = itemsAllUserInfo.Where(u => itemsAllCompanyInvitations.Any(c => c.UserMainId == u.UserMainId)).ToList();

                //取得ResumeSnapshot
                var itemsAllResumeSnapshot = await _appService._resumeSnapshotRepository.GetQueryableAsync();
                var itemsResumeSnapshot = new List<ResumeSnapshot>();
                using (_appService._dataFilter.Disable<IMultiTenant>())
                    itemsResumeSnapshot = itemsAllResumeSnapshot.Where(u => itemsAllCompanyInvitations.Any(c => c.UserMainId == u.Id)).ToList();

                foreach (var itemUserMain in itemsUserMain)
                {
                    UserMainId = itemUserMain.Id;

                    //有綁定則填入求職者基本資料
                    var itemUserResumeSnapshotsList = new UserResumeSnapshotsListDto();
                    itemUserResumeSnapshotsList.UserMainId = UserMainId;
                    itemUserResumeSnapshotsList.UserMainName = itemUserMain.Name;

                    var itemUserInfo = itemsUserInfo.FirstOrDefault(p => p.UserMainId == UserMainId);
                    if (itemUserInfo != null)
                    {
                        itemUserResumeSnapshotsList.UserInfoNameC = itemUserInfo.NameC;
                        itemUserResumeSnapshotsList.UserInfoSex = itemUserInfo.SexCode;
                    }

                    //有綁定且有送出快照則可獲得完整資料
                    var ListResumeSnapshotId = itemsCompanyInvitations.Where(p => p.UserMainId == UserMainId && p.ResumeSnapshotId != null).Select(p => p.ResumeSnapshotId).ToList();
                    var itemsResumeSnapshot1 = itemsResumeSnapshot.Where(p => ListResumeSnapshotId.Contains(p.Id)).ToList();
                    if (itemsResumeSnapshot1.Count > 0)
                    {
                        itemUserResumeSnapshotsList.ListResumeSnapshot = new List<ResumeSnapshotDto>();
                        foreach (var itemResumeSnapshot in itemsResumeSnapshot1)
                        {
                            var item = new ResumeSnapshotDto();
                            item.Id = itemResumeSnapshot.Id;
                            item.UpdateDate = itemResumeSnapshot.LastModificationTime ?? itemResumeSnapshot.CreationTime;
                            itemUserResumeSnapshotsList.ListResumeSnapshot.Add(item);
                        }

                        //取消完整的快照 以節省時間
                        //itemUserResumeSnapshotsList.Resume = new List<ResumeDto>();
                        //foreach (var itemResumeSnapshot in itemsResumeSnapshot1)
                        //{
                        //    var itemResume = new ResumeDto();
                        //    itemResume = JsonSerializer.Deserialize<ResumeDto>(itemResumeSnapshot.Snapshot);
                        //    itemUserResumeSnapshotsList.Resume.Add(itemResume);
                        //}
                    }

                    Result.Data.Add(itemUserResumeSnapshotsList);
                }

                Result.Save = true;
            }

            Result.Check = Result.Messages.Count == 0;

            return Result;
        }

        public Guid CompanyMainId
        {
            get
            {
                //using (_appService._dataFilter.Disable<IMultiTenant>())
                {
                    //理論上 不可能同一個Tenant 有兩個公司
                    var item = _appService._companyMainRepository.FirstOrDefaultAsync();
                    if (item != null && item.Result != null)
                        return item.Result.Id;
                }

                return _appService._guidGenerator.Create();
            }
        }
    }
}