using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Resume.CompanyJobWorkIdentities
{
    public class CompanyJobWorkIdentityManager : DomainService
    {
        private readonly ICompanyJobWorkIdentityRepository _companyJobWorkIdentityRepository;

        public CompanyJobWorkIdentityManager(ICompanyJobWorkIdentityRepository companyJobWorkIdentityRepository)
        {
            _companyJobWorkIdentityRepository = companyJobWorkIdentityRepository;
        }

        public async Task<CompanyJobWorkIdentity> CreateAsync(
        Guid companyMainId, Guid companyJobId, Guid workIdentityCode, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyJobWorkIdentityConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), CompanyJobWorkIdentityConsts.NoteMaxLength);
            Check.Length(status, nameof(status), CompanyJobWorkIdentityConsts.StatusMaxLength);

            var companyJobWorkIdentity = new CompanyJobWorkIdentity(
             GuidGenerator.Create(),
             companyMainId, companyJobId, workIdentityCode, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _companyJobWorkIdentityRepository.InsertAsync(companyJobWorkIdentity);
        }

        public async Task<CompanyJobWorkIdentity> UpdateAsync(
            Guid id,
            Guid companyMainId, Guid companyJobId, Guid workIdentityCode, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null, [CanBeNull] string concurrencyStamp = null
        )
        {
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyJobWorkIdentityConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), CompanyJobWorkIdentityConsts.NoteMaxLength);
            Check.Length(status, nameof(status), CompanyJobWorkIdentityConsts.StatusMaxLength);

            var companyJobWorkIdentity = await _companyJobWorkIdentityRepository.GetAsync(id);

            companyJobWorkIdentity.CompanyMainId = companyMainId;
            companyJobWorkIdentity.CompanyJobId = companyJobId;
            companyJobWorkIdentity.WorkIdentityCode = workIdentityCode;
            companyJobWorkIdentity.ExtendedInformation = extendedInformation;
            companyJobWorkIdentity.DateA = dateA;
            companyJobWorkIdentity.DateD = dateD;
            companyJobWorkIdentity.Sort = sort;
            companyJobWorkIdentity.Note = note;
            companyJobWorkIdentity.Status = status;

            companyJobWorkIdentity.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _companyJobWorkIdentityRepository.UpdateAsync(companyJobWorkIdentity);
        }

    }
}