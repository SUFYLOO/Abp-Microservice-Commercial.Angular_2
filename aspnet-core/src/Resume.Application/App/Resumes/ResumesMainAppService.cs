using Microsoft.Extensions.DependencyInjection;
using Resume.App.Companys;
using Resume.App.Shares;
using Resume.App.Users;
using Resume.CompanyJobs;
using Resume.CompanyMains;
using Resume.ResumeMains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.MultiTenancy;
using Volo.Abp.ObjectMapping;

namespace Resume.App.Resumes
{
    public partial class ResumesAppService : ApplicationService, IResumesAppService
    {

        public virtual async Task<List<ResumeMainsDto>> GetResumeMainListAsync(GetResumeMainListInput input)
        {
            //結果
            var Result = new List<ResumeMainsDto>();
            var ex = new UserFriendlyException("錯誤訊息");

            //常用

            //系統層級
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //主體資料
            var qrbResumeMain = await _appService._resumeMainRepository.GetQueryableAsync();
            var qrbsResumeMain = from c in qrbResumeMain
                                 where c.UserMainId == UserMainId
                                 orderby c.Main descending, c.Sort
                                 select c;
            var itemsResumMain = qrbsResumeMain.ToList();
            //var itemsResumMain = await AsyncExecuter.ToListAsync(qrbsResumeMain);

            if (ex.Data.Count == 0)
            {
                //取得履歷所需要的代碼資料-為了加速
                var inputShareCodeGroup = new ShareCodeGroupInput();
                inputShareCodeGroup.ListGroupCode.Add("MarriageCode");
                inputShareCodeGroup.ListGroupCode.Add("MilitaryCode");
                inputShareCodeGroup.ListGroupCode.Add("DisabilityCategoryCode");
                inputShareCodeGroup.ListGroupCode.Add("SpecialIdentityCode");
                var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);

                var inputSetShareCode = new SetShareCodeInput();
                inputSetShareCode.ListShareCode = itemsShareCode;
                var ListColumns = new List<NameCodeStandardDto>()
                {
                        new NameCodeStandardDto { GroupCode = "Marriage", Code = "MarriageCode", Name = "MarriageName" },
                        new NameCodeStandardDto { GroupCode = "Military", Code = "MilitaryCode", Name = "MilitaryName" },
                        new NameCodeStandardDto { GroupCode = "DisabilityCategory", Code = "DisabilityCategoryCode", Name = "DisabilityCategoryName" },
                        new NameCodeStandardDto { GroupCode = "SpecialIdentity", Code = "SpecialIdentityCode", Name = "SpecialIdentityName" }
                };

                inputSetShareCode.ListColumns = ListColumns;
                _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<ResumeMainsDto>(inputSetShareCode);
                ObjectMapper.Map<List<ResumeMain>, List<ResumeMainsDto>>(itemsResumMain, Result);
            }
            if (ex.Data.Count > 0)
                throw ex;
            return Result;
        }

        public async Task<ResumeMainsDto> GetResumeMainsAsync(GetResumeMainInput input)
        {
            var Result = new ResumeMainsDto();
            var ex = new UserFriendlyException("錯誤訊息");

            //系統層級

            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //外部傳入
            var ResumeMainId = input.Id;

            //主體取資料
            if (ex.Data.Count == 0)
            {
                var qrbResumeMain = await _appService._resumeMainRepository.GetQueryableAsync();
                var itemResumeMain = qrbResumeMain.FirstOrDefault(p => p.Id == ResumeMainId);

                if (itemResumeMain != null)
                {
                    var inputShareCodeGroup = new ShareCodeGroupInput();
                    inputShareCodeGroup.ListGroupCode.Add("MarriageCode");
                    inputShareCodeGroup.ListGroupCode.Add("MilitaryCode");
                    inputShareCodeGroup.ListGroupCode.Add("DisabilityCategoryCode");
                    inputShareCodeGroup.ListGroupCode.Add("SpecialIdentityCode");
                    var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);

                    {
                        ObjectMapper.Map<ResumeMain, ResumeMainsDto>(itemResumeMain, Result);

                        var inputSetShareCode = new SetShareCodeInput();
                        inputSetShareCode.ListShareCode = itemsShareCode;
                        var ListColumns = new List<NameCodeStandardDto>();

                        new NameCodeStandardDto { GroupCode = "Marriage", Code = "MarriageCode", Name = "MarriageName" };
                        new NameCodeStandardDto { GroupCode = "Military", Code = "MilitaryCode", Name = "MilitaryName" };
                        new NameCodeStandardDto { GroupCode = "DisabilityCategory", Code = "DisabilityCategoryCode", Name = "DisabilityCategoryName" };
                        new NameCodeStandardDto { GroupCode = "SpecialIdentity", Code = "SpecialIdentityCode", Name = "SpecialIdentityName" };

                         inputSetShareCode.ListColumns = ListColumns;
                        _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<ResumeMainsDto>(inputSetShareCode);

                        var inputShareUploadList = new ShareUploadListInput();
                        inputShareUploadList.Key1 = "ResumeMain";
                        inputShareUploadList.Key2 = "";
                        inputShareUploadList.Key3 = itemResumeMain.UserMainId.ToString();
                        var itemsShareUploadList = await _appService._serviceProvider.GetService<SharesAppService>().GetShareUploadListAsync(inputShareUploadList);
                    };
                }
                else
                {
                    ex.Data.Add(GuidGenerator.Create().ToString(), "履歷主檔不正確");
                }
            }
            //回傳錯誤
            if (ex.Data.Count > 0)

                throw ex;
            return Result;
        }



        public async Task<ResumeMainsDto> SaveResumeMainsAsync(SaveResumeMainInput input)
        {
            var Result = new ResumeMainsDto();

            //系統層級
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //強制帶入Id
            input.UserMainId = UserMainId;

            //外部傳入
            var RefreshItem = input.RefreshItem;
            var ResumeMainId = input.Id;
            //不要變更的值
            input.Sort = input.Sort != null ? input.Sort : ShareDefine.Sort;
            input.DateA = input.DateA != null ? input.DateA : ShareDefine.DateA;
            input.DateD = input.DateD != null ? input.DateD : ShareDefine.DateD;

            //檢查
            await SaveResumeMainsCheckAsync(input);

            //主體資料
            var qrbResumeMain = await _appService._resumeMainRepository.GetQueryableAsync();
            var itemqrbResumeMain = qrbResumeMain.FirstOrDefault(p => p.Id == ResumeMainId);

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

        public virtual async Task<ResultDto> SaveResumeMainsCheckAsync(SaveResumeMainInput input)
        {

            var Result = new ResultDto();

            var MarriageCode = input.MarriageCode;
            var DisabilityCategoryCode = input.DisabilityCategoryCode;
            var SpecialIdentityCode = input.SpecialIdentityCode;

            var inputShareCodeGroup = new ShareCodeGroupInput();
            inputShareCodeGroup.ListGroupCode.Add("MarriageCode");
            inputShareCodeGroup.ListGroupCode.Add("DisabilityCategoryCode");
            inputShareCodeGroup.ListGroupCode.Add("SpecialIdentityCode");
            var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);

            if (!itemsShareCode.Any(p => p.GroupCode == "JobPayTypeCode" && p.Code == MarriageCode))
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "付費類別代碼錯誤" });

            if (!itemsShareCode.Any(p => p.GroupCode == "DisabilityCategoryCode" && p.Code == DisabilityCategoryCode))
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "付費類別代碼錯誤" });

            if (!itemsShareCode.Any(p => p.GroupCode == "SpecialIdentityCode" && p.Code == SpecialIdentityCode))
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "付費類別代碼錯誤" });

            var itemsCompanyjob = await _appService._companyJobRepository.GetQueryableAsync();

            var ex = new UserFriendlyException("系統發生錯誤");
            foreach (var msg in Result.Messages)
                ex.Data.Add(GuidGenerator.Create().ToString(), msg.MessageContents);

            Result.Check = !Result.Messages.Any(p => !p.Pass);

            return Result;
        }


    }
}
