using Microsoft.Extensions.DependencyInjection;
using PayPalCheckoutSdk.Orders;
using Resume.App.Companys;
using Resume.App.Shares;
using Resume.App.Users;
using Resume.CompanyJobs;
using Resume.CompanyMains;
using Resume.ResumeExperiencess;
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

        public virtual async Task<List<ResumeMainsDto>> GetResumeMainListAsync(ResumeMainInput input)
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
            var itemsResumeMain = qrbsResumeMain.ToList();
            //var itemsResumMain = await AsyncExecuter.ToListAsync(qrbsResumeMain);

            if (ex.Data.Count == 0)
            {
                //取得履歷所需要的代碼資料-為了加速
                var inputShareCodeGroup = new ShareCodeGroupInput();
                inputShareCodeGroup.ListGroupCode.Add("Marriage");
                inputShareCodeGroup.ListGroupCode.Add("Military");
                inputShareCodeGroup.ListGroupCode.Add("DisabilityCategory");
                inputShareCodeGroup.ListGroupCode.Add("SpecialIdentity");
                inputShareCodeGroup.AllForGroupCode = true;
                var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);

                {

                    ObjectMapper.Map(itemsResumeMain, Result);

                    var inputSetShareCode = new SetShareCodeInput();
                    inputSetShareCode.ListShareCode = itemsShareCode;
                    inputSetShareCode.Data = Result;
                    var ListColumns = new List<NameCodeStandardDto>
                {
                        new NameCodeStandardDto { GroupCode = "Marriage", Code = "MarriageCode", Name = "MarriageName" },
                        new NameCodeStandardDto { GroupCode = "Military", Code = "MilitaryCode", Name = "MilitaryName" },
                        new NameCodeStandardDto { GroupCode = "DisabilityCategory", Code = "DisabilityCategoryCode", Name = "DisabilityCategoryName" },
                        new NameCodeStandardDto { GroupCode = "SpecialIdentity", Code = "SpecialIdentityCode", Name = "SpecialIdentityName" }
                };

                    inputSetShareCode.ListColumns = ListColumns;
                    _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<ResumeMainsDto>(inputSetShareCode);
                }
            }

            if (ex.Data.Count > 0)
                throw ex;
            return Result;
        }

        public async Task<ResumeMainsDto> GetResumeMainsAsync(GetResumeMainInput input)
        {
            //結果
            var Result = new ResumeMainsDto();
            var ex = new UserFriendlyException("錯誤訊息");

            //系統層級

            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //外部傳入
            var ResumeMainId = input.Id;

            //預設值

            //檢查
            if (ResumeMainId.ToString() == " ")
            {
                ex.Data.Add(GuidGenerator.Create().ToString(), "ID不能為空白");
                throw ex;
            }

            //主體取資料
            if (ex.Data.Count == 0)
            {
                var qrbResumeMain = await _appService._resumeMainRepository.GetQueryableAsync();
                qrbResumeMain = (from c in qrbResumeMain
                                 where c.Status == "1"
                                 orderby c.Sort
                                 select c);
                var itemResumeMain = qrbResumeMain.FirstOrDefault(p => p.Id == ResumeMainId);

                if (itemResumeMain != null)
                {
                    var inputShareCodeGroup = new ShareCodeGroupInput();
                    inputShareCodeGroup.ListGroupCode.Add("Marriage");
                    inputShareCodeGroup.ListGroupCode.Add("Military");
                    inputShareCodeGroup.ListGroupCode.Add("DisabilityCategory");
                    inputShareCodeGroup.ListGroupCode.Add("SpecialIdentity");
                    inputShareCodeGroup.AllForGroupCode = true;
                    var itemsShareCode = await _appService._serviceProvider.GetService<SharesAppService>().GetShareCodeNameCodeAsync(inputShareCodeGroup);

                    ObjectMapper.Map(itemResumeMain, Result);

                    var inputSetShareCode = new SetShareCodeInput();
                    inputSetShareCode.ListShareCode = itemsShareCode;
                    inputSetShareCode.Data = new List<ResumeMainsDto>() { Result }; ;
                    var ListColumns = new List<NameCodeStandardDto>
                    {
                        new NameCodeStandardDto { GroupCode = "Marriage", Code = "MarriageCode", Name = "MarriageName" },
                        new NameCodeStandardDto { GroupCode = "Military", Code = "MilitaryCode", Name = "MilitaryName" },
                        new NameCodeStandardDto { GroupCode = "DisabilityCategory", Code = "DisabilityCategoryCode", Name = "DisabilityCategoryName" },
                        new NameCodeStandardDto { GroupCode = "SpecialIdentity", Code = "SpecialIdentityCode", Name = "SpecialIdentityName" }
                    };

                    inputSetShareCode.ListColumns = ListColumns;
                    _appService._serviceProvider.GetService<SharesAppService>().SetShareCodeAsync<ResumeMainsDto>(inputSetShareCode);
                }
            }
                else
                {
                    ex.Data.Add(GuidGenerator.Create().ToString(), "沒有此筆資料");
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
            input.Status = "1";
            input.ExtendedInformation = "";

            //外部傳入
            var RefreshItem = input.RefreshItem;
            var ResumeMainId = input.Id;
            //不要變更的值
            input.Sort = input.Sort != null ? input.Sort : ShareDefine.Sort;
            input.DateA = input.DateA != null ? input.DateA : ShareDefine.DateA;
            input.DateD = input.DateD != null ? input.DateD : ShareDefine.DateD;
            input.Status = input.Status.IsNullOrEmpty() ? "1" : input.Status;
            input.ExtendedInformation = input.ExtendedInformation.IsNullOrEmpty() ? "" : input.ExtendedInformation;

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
            //結果
            var Result = new ResultDto();
            var ex = new UserFriendlyException("錯誤訊息");

            //常用

            //系統層級
            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>()?.CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>()?.UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>()?.SystemUserRoleKeys;

            //外部傳入

            var MarriageCode = input.MarriageCode ?? "";
            var MilitaryCode = input.MilitaryCode;
            var DisabilityCategoryCode = input.DisabilityCategoryCode;
            var SpecialIdentityCode = input.SpecialIdentityCode;


            //必要代碼檢核
            var conditions = new List<GroupCodeConditions>()
             {
                 new GroupCodeConditions(){GroupCode = "Marriage",Code =MarriageCode, ErrorMessage = "婚姻類別代碼錯誤" ,AllowNull = true},
                 new GroupCodeConditions(){GroupCode = "Military",Code = MilitaryCode , ErrorMessage = "兵役類別代碼錯誤" ,AllowNull = false},
                 new GroupCodeConditions(){GroupCode = "DisabilityCategory",Code = DisabilityCategoryCode , ErrorMessage = "殘障類別代碼錯誤" , AllowNull = true},
                 new GroupCodeConditions(){GroupCode = "SpecialIdentity",Code = SpecialIdentityCode , ErrorMessage = "特殊身分代碼錯誤" ,AllowNull = true },
               
             };

            Result = await _appService._serviceProvider.GetService<SharesAppService>().CheckGroupCode(Result, conditions);

            foreach (var msg in Result.Messages)
                ex.Data.Add(GuidGenerator.Create().ToString(), msg.MessageContents);

            Result.Check = !Result.Messages.Any(p => !p.Pass);
            if (!Result.Check)
                throw ex;

            return Result;
        }

        public virtual async Task<ResumeMainsDto> UpdateResumeMainsAutobiography1Async(UpdateResumeMainsAutobiographyInput input)
        {
            var Result = new ResumeMainsDto();

            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            // 外部傳入
            var ResumeMainsId = input.Id;
            var WelfareSystem = input.Autobiography1;
            //var RefreshItem = input.RefreshItem;

            //檢查
            await UpdateResumeMainsAutobiography1CheckAsync(input);

            //主體資料
            var qrbResumeMains = await _appService._resumeMainRepository.GetQueryableAsync();
            var itemResumeMains = qrbResumeMains.FirstOrDefault(p => p.Id == ResumeMainsId);

            //映射
            ObjectMapper.Map(input, itemResumeMains);
            itemResumeMains = await _appService._resumeMainRepository.UpdateAsync(itemResumeMains);

            ObjectMapper.Map(itemResumeMains, Result);
            return Result;
        }

        public virtual async Task<ResultDto> UpdateResumeMainsAutobiography1CheckAsync(UpdateResumeMainsAutobiographyInput input)
        {
            var Result = new ResultDto();
            var ex = new UserFriendlyException("系統發生錯誤");

            var ResumeMainId = input.Id;
            var Autobiography = input.Autobiography1;


            if (Autobiography.Equals(null))
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "自傳不能空白", Pass = false });

            var qrbCompanyJob = await _appService._resumeMainRepository.GetQueryableAsync();
            var itemCompanyJob = qrbCompanyJob.FirstOrDefault(p => p.Id == ResumeMainId);

            if (itemCompanyJob == null)
                Result.Messages.Add(new ResultMessageDto() { MessageCode = "400", MessageContents = "沒有此筆資料", Pass = false });


            foreach (var msg in Result.Messages)
                ex.Data.Add(GuidGenerator.Create().ToString(), msg.MessageContents);


            Result.Check = !Result.Messages.Any(p => !p.Pass);
            if (!Result.Check)
                throw ex;

            return Result;
        }

        public virtual async Task<ResumeMainsDto> DeleteResumeMainAsync(ResumeMainInput input)
        {
            var Result = new ResumeMainsDto();
            var ex = new UserFriendlyException("錯誤訊息");

            //常用

            //系統層級

            var CompanyMainId = _appService._serviceProvider.GetService<CompanysAppService>().CompanyMainId;
            var UserMainId = _appService._serviceProvider.GetService<UsersAppService>().UserMainId;
            var SystemUserRoleKeys = _appService._serviceProvider.GetService<UsersAppService>().SystemUserRoleKeys;

            //強制把input帶入系統值

            //外部傳入
            var Id = input.Id;

            //預設值

            //檢查


            //主體資料
            var qrbResumeMain = await _appService._resumeMainRepository.GetQueryableAsync();
            var itemResumeMain = qrbResumeMain.FirstOrDefault(p => p.Id == Id);
            if (ex.Data.Count == 0)
            {
                if (itemResumeMain == null)
                    ex.Data.Add(GuidGenerator.Create().ToString(), "沒有此筆資料");
                else
                {
                    await _appService._resumeMainRepository.DeleteAsync(itemResumeMain);
                    ObjectMapper.Map(itemResumeMain, Result);
                }
            }

            if (ex.Data.Count > 0)
                throw ex;
            return Result;
        }
    }
}
