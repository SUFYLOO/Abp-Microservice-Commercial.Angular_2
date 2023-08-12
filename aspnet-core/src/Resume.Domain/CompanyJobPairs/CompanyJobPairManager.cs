using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Resume.CompanyJobPairs
{
    public class CompanyJobPairManager : DomainService
    {
        private readonly ICompanyJobPairRepository _companyJobPairRepository;

        public CompanyJobPairManager(ICompanyJobPairRepository companyJobPairRepository)
        {
            _companyJobPairRepository = companyJobPairRepository;
        }

        public async Task<CompanyJobPair> CreateAsync(
        Guid companyMainId, string name, string pairCondition, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), CompanyJobPairConsts.NameMaxLength);
            Check.Length(pairCondition, nameof(pairCondition), CompanyJobPairConsts.PairConditionMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyJobPairConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), CompanyJobPairConsts.NoteMaxLength);
            Check.Length(status, nameof(status), CompanyJobPairConsts.StatusMaxLength);

            var companyJobPair = new CompanyJobPair(
             GuidGenerator.Create(),
             companyMainId, name, pairCondition, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _companyJobPairRepository.InsertAsync(companyJobPair);
        }

        public async Task<CompanyJobPair> UpdateAsync(
            Guid id,
            Guid companyMainId, string name, string pairCondition, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null, [CanBeNull] string concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), CompanyJobPairConsts.NameMaxLength);
            Check.Length(pairCondition, nameof(pairCondition), CompanyJobPairConsts.PairConditionMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyJobPairConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), CompanyJobPairConsts.NoteMaxLength);
            Check.Length(status, nameof(status), CompanyJobPairConsts.StatusMaxLength);

            var companyJobPair = await _companyJobPairRepository.GetAsync(id);

            companyJobPair.CompanyMainId = companyMainId;
            companyJobPair.Name = name;
            companyJobPair.PairCondition = pairCondition;
            companyJobPair.ExtendedInformation = extendedInformation;
            companyJobPair.DateA = dateA;
            companyJobPair.DateD = dateD;
            companyJobPair.Sort = sort;
            companyJobPair.Note = note;
            companyJobPair.Status = status;

            companyJobPair.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _companyJobPairRepository.UpdateAsync(companyJobPair);
        }

    }
}