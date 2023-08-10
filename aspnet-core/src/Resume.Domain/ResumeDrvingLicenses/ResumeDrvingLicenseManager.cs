using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Resume.ResumeDrvingLicenses
{
    public class ResumeDrvingLicenseManager : DomainService
    {
        private readonly IResumeDrvingLicenseRepository _resumeDrvingLicenseRepository;

        public ResumeDrvingLicenseManager(IResumeDrvingLicenseRepository resumeDrvingLicenseRepository)
        {
            _resumeDrvingLicenseRepository = resumeDrvingLicenseRepository;
        }

        public async Task<ResumeDrvingLicense> CreateAsync(
        Guid resumeMainId, string drvingLicenseCode, bool haveDrvingLicense, bool haveCar, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null)
        {
            Check.NotNullOrWhiteSpace(drvingLicenseCode, nameof(drvingLicenseCode));
            Check.Length(drvingLicenseCode, nameof(drvingLicenseCode), ResumeDrvingLicenseConsts.DrvingLicenseCodeMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), ResumeDrvingLicenseConsts.StatusMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeDrvingLicenseConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ResumeDrvingLicenseConsts.NoteMaxLength);

            var resumeDrvingLicense = new ResumeDrvingLicense(
             GuidGenerator.Create(),
             resumeMainId, drvingLicenseCode, haveDrvingLicense, haveCar, dateA, dateD, sort, status, extendedInformation, note
             );

            return await _resumeDrvingLicenseRepository.InsertAsync(resumeDrvingLicense);
        }

        public async Task<ResumeDrvingLicense> UpdateAsync(
            Guid id,
            Guid resumeMainId, string drvingLicenseCode, bool haveDrvingLicense, bool haveCar, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null
        )
        {
            Check.NotNullOrWhiteSpace(drvingLicenseCode, nameof(drvingLicenseCode));
            Check.Length(drvingLicenseCode, nameof(drvingLicenseCode), ResumeDrvingLicenseConsts.DrvingLicenseCodeMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), ResumeDrvingLicenseConsts.StatusMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeDrvingLicenseConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ResumeDrvingLicenseConsts.NoteMaxLength);

            var resumeDrvingLicense = await _resumeDrvingLicenseRepository.GetAsync(id);

            resumeDrvingLicense.ResumeMainId = resumeMainId;
            resumeDrvingLicense.DrvingLicenseCode = drvingLicenseCode;
            resumeDrvingLicense.HaveDrvingLicense = haveDrvingLicense;
            resumeDrvingLicense.HaveCar = haveCar;
            resumeDrvingLicense.DateA = dateA;
            resumeDrvingLicense.DateD = dateD;
            resumeDrvingLicense.Sort = sort;
            resumeDrvingLicense.Status = status;
            resumeDrvingLicense.ExtendedInformation = extendedInformation;
            resumeDrvingLicense.Note = note;

            return await _resumeDrvingLicenseRepository.UpdateAsync(resumeDrvingLicense);
        }

    }
}