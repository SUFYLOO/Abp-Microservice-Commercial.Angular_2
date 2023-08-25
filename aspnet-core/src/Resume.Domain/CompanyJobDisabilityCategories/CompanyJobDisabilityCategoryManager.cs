using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Resume.CompanyJobDisabilityCategories
{
    public class CompanyJobDisabilityCategoryManager : DomainService
    {
        private readonly ICompanyJobDisabilityCategoryRepository _companyJobDisabilityCategoryRepository;

        public CompanyJobDisabilityCategoryManager(ICompanyJobDisabilityCategoryRepository companyJobDisabilityCategoryRepository)
        {
            _companyJobDisabilityCategoryRepository = companyJobDisabilityCategoryRepository;
        }

        public async Task<CompanyJobDisabilityCategory> CreateAsync(
        Guid companyMainId, Guid companyJobId, string disabilityCategoryCode, string disabilityLevelCode, bool disabilityCertifiedDocumentsNeed, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {
            Check.NotNullOrWhiteSpace(disabilityCategoryCode, nameof(disabilityCategoryCode));
            Check.Length(disabilityCategoryCode, nameof(disabilityCategoryCode), CompanyJobDisabilityCategoryConsts.DisabilityCategoryCodeMaxLength);
            Check.NotNullOrWhiteSpace(disabilityLevelCode, nameof(disabilityLevelCode));
            Check.Length(disabilityLevelCode, nameof(disabilityLevelCode), CompanyJobDisabilityCategoryConsts.DisabilityLevelCodeMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyJobDisabilityCategoryConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), CompanyJobDisabilityCategoryConsts.NoteMaxLength);
            Check.Length(status, nameof(status), CompanyJobDisabilityCategoryConsts.StatusMaxLength);

            var companyJobDisabilityCategory = new CompanyJobDisabilityCategory(
             GuidGenerator.Create(),
             companyMainId, companyJobId, disabilityCategoryCode, disabilityLevelCode, disabilityCertifiedDocumentsNeed, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _companyJobDisabilityCategoryRepository.InsertAsync(companyJobDisabilityCategory);
        }

        public async Task<CompanyJobDisabilityCategory> UpdateAsync(
            Guid id,
            Guid companyMainId, Guid companyJobId, string disabilityCategoryCode, string disabilityLevelCode, bool disabilityCertifiedDocumentsNeed, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null
        )
        {
            Check.NotNullOrWhiteSpace(disabilityCategoryCode, nameof(disabilityCategoryCode));
            Check.Length(disabilityCategoryCode, nameof(disabilityCategoryCode), CompanyJobDisabilityCategoryConsts.DisabilityCategoryCodeMaxLength);
            Check.NotNullOrWhiteSpace(disabilityLevelCode, nameof(disabilityLevelCode));
            Check.Length(disabilityLevelCode, nameof(disabilityLevelCode), CompanyJobDisabilityCategoryConsts.DisabilityLevelCodeMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyJobDisabilityCategoryConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), CompanyJobDisabilityCategoryConsts.NoteMaxLength);
            Check.Length(status, nameof(status), CompanyJobDisabilityCategoryConsts.StatusMaxLength);

            var companyJobDisabilityCategory = await _companyJobDisabilityCategoryRepository.GetAsync(id);

            companyJobDisabilityCategory.CompanyMainId = companyMainId;
            companyJobDisabilityCategory.CompanyJobId = companyJobId;
            companyJobDisabilityCategory.DisabilityCategoryCode = disabilityCategoryCode;
            companyJobDisabilityCategory.DisabilityLevelCode = disabilityLevelCode;
            companyJobDisabilityCategory.DisabilityCertifiedDocumentsNeed = disabilityCertifiedDocumentsNeed;
            companyJobDisabilityCategory.ExtendedInformation = extendedInformation;
            companyJobDisabilityCategory.DateA = dateA;
            companyJobDisabilityCategory.DateD = dateD;
            companyJobDisabilityCategory.Sort = sort;
            companyJobDisabilityCategory.Note = note;
            companyJobDisabilityCategory.Status = status;

            return await _companyJobDisabilityCategoryRepository.UpdateAsync(companyJobDisabilityCategory);
        }

    }
}