using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Resume.CompanyJobDrvingLicenses
{
    public class CompanyJobDrvingLicenseManager : DomainService
    {
        private readonly ICompanyJobDrvingLicenseRepository _companyJobDrvingLicenseRepository;

        public CompanyJobDrvingLicenseManager(ICompanyJobDrvingLicenseRepository companyJobDrvingLicenseRepository)
        {
            _companyJobDrvingLicenseRepository = companyJobDrvingLicenseRepository;
        }

        public async Task<CompanyJobDrvingLicense> CreateAsync(
        Guid companyMainId, Guid companyJobId, string drvingLicenseCode, bool haveDrvingLicense, bool haveCar, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {
            Check.NotNullOrWhiteSpace(drvingLicenseCode, nameof(drvingLicenseCode));
            Check.Length(drvingLicenseCode, nameof(drvingLicenseCode), CompanyJobDrvingLicenseConsts.DrvingLicenseCodeMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyJobDrvingLicenseConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), CompanyJobDrvingLicenseConsts.NoteMaxLength);
            Check.Length(status, nameof(status), CompanyJobDrvingLicenseConsts.StatusMaxLength);

            var companyJobDrvingLicense = new CompanyJobDrvingLicense(
             GuidGenerator.Create(),
             companyMainId, companyJobId, drvingLicenseCode, haveDrvingLicense, haveCar, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _companyJobDrvingLicenseRepository.InsertAsync(companyJobDrvingLicense);
        }

        public async Task<CompanyJobDrvingLicense> UpdateAsync(
            Guid id,
            Guid companyMainId, Guid companyJobId, string drvingLicenseCode, bool haveDrvingLicense, bool haveCar, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null, [CanBeNull] string concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(drvingLicenseCode, nameof(drvingLicenseCode));
            Check.Length(drvingLicenseCode, nameof(drvingLicenseCode), CompanyJobDrvingLicenseConsts.DrvingLicenseCodeMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyJobDrvingLicenseConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), CompanyJobDrvingLicenseConsts.NoteMaxLength);
            Check.Length(status, nameof(status), CompanyJobDrvingLicenseConsts.StatusMaxLength);

            var companyJobDrvingLicense = await _companyJobDrvingLicenseRepository.GetAsync(id);

            companyJobDrvingLicense.CompanyMainId = companyMainId;
            companyJobDrvingLicense.CompanyJobId = companyJobId;
            companyJobDrvingLicense.DrvingLicenseCode = drvingLicenseCode;
            companyJobDrvingLicense.HaveDrvingLicense = haveDrvingLicense;
            companyJobDrvingLicense.HaveCar = haveCar;
            companyJobDrvingLicense.ExtendedInformation = extendedInformation;
            companyJobDrvingLicense.DateA = dateA;
            companyJobDrvingLicense.DateD = dateD;
            companyJobDrvingLicense.Sort = sort;
            companyJobDrvingLicense.Note = note;
            companyJobDrvingLicense.Status = status;

            companyJobDrvingLicense.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _companyJobDrvingLicenseRepository.UpdateAsync(companyJobDrvingLicense);
        }

    }
}