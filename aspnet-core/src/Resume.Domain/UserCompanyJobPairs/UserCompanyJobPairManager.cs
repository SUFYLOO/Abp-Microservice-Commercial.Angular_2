using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Resume.UserCompanyJobPairs
{
    public class UserCompanyJobPairManager : DomainService
    {
        private readonly IUserCompanyJobPairRepository _userCompanyJobPairRepository;

        public UserCompanyJobPairManager(IUserCompanyJobPairRepository userCompanyJobPairRepository)
        {
            _userCompanyJobPairRepository = userCompanyJobPairRepository;
        }

        public async Task<UserCompanyJobPair> CreateAsync(
        Guid userMainId, string name, string pairCondition, string extendedInformation, DateTime dateA, DateTime dateD, int sort, string note, string status)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), UserCompanyJobPairConsts.NameMaxLength);
            Check.Length(pairCondition, nameof(pairCondition), UserCompanyJobPairConsts.PairConditionMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), UserCompanyJobPairConsts.ExtendedInformationMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.Length(note, nameof(note), UserCompanyJobPairConsts.NoteMaxLength);
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), UserCompanyJobPairConsts.StatusMaxLength);

            var userCompanyJobPair = new UserCompanyJobPair(
             GuidGenerator.Create(),
             userMainId, name, pairCondition, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _userCompanyJobPairRepository.InsertAsync(userCompanyJobPair);
        }

        public async Task<UserCompanyJobPair> UpdateAsync(
            Guid id,
            Guid userMainId, string name, string pairCondition, string extendedInformation, DateTime dateA, DateTime dateD, int sort, string note, string status, [CanBeNull] string concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), UserCompanyJobPairConsts.NameMaxLength);
            Check.Length(pairCondition, nameof(pairCondition), UserCompanyJobPairConsts.PairConditionMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), UserCompanyJobPairConsts.ExtendedInformationMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.Length(note, nameof(note), UserCompanyJobPairConsts.NoteMaxLength);
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), UserCompanyJobPairConsts.StatusMaxLength);

            var userCompanyJobPair = await _userCompanyJobPairRepository.GetAsync(id);

            userCompanyJobPair.UserMainId = userMainId;
            userCompanyJobPair.Name = name;
            userCompanyJobPair.PairCondition = pairCondition;
            userCompanyJobPair.ExtendedInformation = extendedInformation;
            userCompanyJobPair.DateA = dateA;
            userCompanyJobPair.DateD = dateD;
            userCompanyJobPair.Sort = sort;
            userCompanyJobPair.Note = note;
            userCompanyJobPair.Status = status;

            userCompanyJobPair.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _userCompanyJobPairRepository.UpdateAsync(userCompanyJobPair);
        }

    }
}