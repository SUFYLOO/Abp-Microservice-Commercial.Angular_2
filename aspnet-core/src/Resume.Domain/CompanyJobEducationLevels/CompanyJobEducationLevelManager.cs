using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Resume.CompanyJobEducationLevels
{
    public class CompanyJobEducationLevelManager : DomainService
    {
        private readonly ICompanyJobEducationLevelRepository _companyJobEducationLevelRepository;

        public CompanyJobEducationLevelManager(ICompanyJobEducationLevelRepository companyJobEducationLevelRepository)
        {
            _companyJobEducationLevelRepository = companyJobEducationLevelRepository;
        }

        public async Task<CompanyJobEducationLevel> CreateAsync(
        Guid companyMainId, Guid companyJobId, string educationLevelCode, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {
            Check.Length(educationLevelCode, nameof(educationLevelCode), CompanyJobEducationLevelConsts.EducationLevelCodeMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyJobEducationLevelConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), CompanyJobEducationLevelConsts.NoteMaxLength);
            Check.Length(status, nameof(status), CompanyJobEducationLevelConsts.StatusMaxLength);

            var companyJobEducationLevel = new CompanyJobEducationLevel(
             GuidGenerator.Create(),
             companyMainId, companyJobId, educationLevelCode, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _companyJobEducationLevelRepository.InsertAsync(companyJobEducationLevel);
        }

        public async Task<CompanyJobEducationLevel> UpdateAsync(
            Guid id,
            Guid companyMainId, Guid companyJobId, string educationLevelCode, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null, [CanBeNull] string concurrencyStamp = null
        )
        {
            Check.Length(educationLevelCode, nameof(educationLevelCode), CompanyJobEducationLevelConsts.EducationLevelCodeMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyJobEducationLevelConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), CompanyJobEducationLevelConsts.NoteMaxLength);
            Check.Length(status, nameof(status), CompanyJobEducationLevelConsts.StatusMaxLength);

            var companyJobEducationLevel = await _companyJobEducationLevelRepository.GetAsync(id);

            companyJobEducationLevel.CompanyMainId = companyMainId;
            companyJobEducationLevel.CompanyJobId = companyJobId;
            companyJobEducationLevel.EducationLevelCode = educationLevelCode;
            companyJobEducationLevel.ExtendedInformation = extendedInformation;
            companyJobEducationLevel.DateA = dateA;
            companyJobEducationLevel.DateD = dateD;
            companyJobEducationLevel.Sort = sort;
            companyJobEducationLevel.Note = note;
            companyJobEducationLevel.Status = status;

            companyJobEducationLevel.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _companyJobEducationLevelRepository.UpdateAsync(companyJobEducationLevel);
        }

    }
}