using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Resume.UserCompanyJobApplies
{
    public class UserCompanyJobApplyManager : DomainService
    {
        private readonly IUserCompanyJobApplyRepository _userCompanyJobApplyRepository;

        public UserCompanyJobApplyManager(IUserCompanyJobApplyRepository userCompanyJobApplyRepository)
        {
            _userCompanyJobApplyRepository = userCompanyJobApplyRepository;
        }

        public async Task<UserCompanyJobApply> CreateAsync(
        Guid userMainId, Guid companyJobId, string extendedInformation, DateTime dateA, DateTime dateD, int sort, string note, string status)
        {
            Check.Length(extendedInformation, nameof(extendedInformation), UserCompanyJobApplyConsts.ExtendedInformationMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.Length(note, nameof(note), UserCompanyJobApplyConsts.NoteMaxLength);
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), UserCompanyJobApplyConsts.StatusMaxLength);

            var userCompanyJobApply = new UserCompanyJobApply(
             GuidGenerator.Create(),
             userMainId, companyJobId, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _userCompanyJobApplyRepository.InsertAsync(userCompanyJobApply);
        }

        public async Task<UserCompanyJobApply> UpdateAsync(
            Guid id,
            Guid userMainId, Guid companyJobId, string extendedInformation, DateTime dateA, DateTime dateD, int sort, string note, string status, [CanBeNull] string concurrencyStamp = null
        )
        {
            Check.Length(extendedInformation, nameof(extendedInformation), UserCompanyJobApplyConsts.ExtendedInformationMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.Length(note, nameof(note), UserCompanyJobApplyConsts.NoteMaxLength);
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), UserCompanyJobApplyConsts.StatusMaxLength);

            var userCompanyJobApply = await _userCompanyJobApplyRepository.GetAsync(id);

            userCompanyJobApply.UserMainId = userMainId;
            userCompanyJobApply.CompanyJobId = companyJobId;
            userCompanyJobApply.ExtendedInformation = extendedInformation;
            userCompanyJobApply.DateA = dateA;
            userCompanyJobApply.DateD = dateD;
            userCompanyJobApply.Sort = sort;
            userCompanyJobApply.Note = note;
            userCompanyJobApply.Status = status;

            userCompanyJobApply.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _userCompanyJobApplyRepository.UpdateAsync(userCompanyJobApply);
        }

    }
}