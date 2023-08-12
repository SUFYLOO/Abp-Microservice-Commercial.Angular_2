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
        Guid resumeMainId, string drvingLicenseCode, bool haveDrvingLicense, bool haveCar, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {
            Check.NotNullOrWhiteSpace(drvingLicenseCode, nameof(drvingLicenseCode));
            Check.Length(drvingLicenseCode, nameof(drvingLicenseCode), ResumeDrvingLicenseConsts.DrvingLicenseCodeMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeDrvingLicenseConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ResumeDrvingLicenseConsts.NoteMaxLength);
            Check.Length(status, nameof(status), ResumeDrvingLicenseConsts.StatusMaxLength);

            var resumeDrvingLicense = new ResumeDrvingLicense(
             GuidGenerator.Create(),
             resumeMainId, drvingLicenseCode, haveDrvingLicense, haveCar, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _resumeDrvingLicenseRepository.InsertAsync(resumeDrvingLicense);
        }

        public async Task<ResumeDrvingLicense> UpdateAsync(
            Guid id,
            Guid resumeMainId, string drvingLicenseCode, bool haveDrvingLicense, bool haveCar, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null
        )
        {
            Check.NotNullOrWhiteSpace(drvingLicenseCode, nameof(drvingLicenseCode));
            Check.Length(drvingLicenseCode, nameof(drvingLicenseCode), ResumeDrvingLicenseConsts.DrvingLicenseCodeMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeDrvingLicenseConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ResumeDrvingLicenseConsts.NoteMaxLength);
            Check.Length(status, nameof(status), ResumeDrvingLicenseConsts.StatusMaxLength);

            var resumeDrvingLicense = await _resumeDrvingLicenseRepository.GetAsync(id);

            resumeDrvingLicense.ResumeMainId = resumeMainId;
            resumeDrvingLicense.DrvingLicenseCode = drvingLicenseCode;
            resumeDrvingLicense.HaveDrvingLicense = haveDrvingLicense;
            resumeDrvingLicense.HaveCar = haveCar;
            resumeDrvingLicense.ExtendedInformation = extendedInformation;
            resumeDrvingLicense.DateA = dateA;
            resumeDrvingLicense.DateD = dateD;
            resumeDrvingLicense.Sort = sort;
            resumeDrvingLicense.Note = note;
            resumeDrvingLicense.Status = status;

            return await _resumeDrvingLicenseRepository.UpdateAsync(resumeDrvingLicense);
        }

    }
}