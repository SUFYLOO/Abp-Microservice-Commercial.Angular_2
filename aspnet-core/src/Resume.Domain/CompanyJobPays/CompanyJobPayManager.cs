using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Resume.CompanyJobPays
{
    public class CompanyJobPayManager : DomainService
    {
        private readonly ICompanyJobPayRepository _companyJobPayRepository;

        public CompanyJobPayManager(ICompanyJobPayRepository companyJobPayRepository)
        {
            _companyJobPayRepository = companyJobPayRepository;
        }

        public async Task<CompanyJobPay> CreateAsync(
        Guid companyMainId, Guid companyJobId, string jobPayTypeCode, bool isCancel, string extendedInformation, DateTime dateA, DateTime dateD, int sort, string note, string status, DateTime? dateReal = null)
        {
            Check.NotNullOrWhiteSpace(jobPayTypeCode, nameof(jobPayTypeCode));
            Check.Length(jobPayTypeCode, nameof(jobPayTypeCode), CompanyJobPayConsts.JobPayTypeCodeMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyJobPayConsts.ExtendedInformationMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.Length(note, nameof(note), CompanyJobPayConsts.NoteMaxLength);
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), CompanyJobPayConsts.StatusMaxLength);

            var companyJobPay = new CompanyJobPay(
             GuidGenerator.Create(),
             companyMainId, companyJobId, jobPayTypeCode, isCancel, extendedInformation, dateA, dateD, sort, note, status, dateReal
             );

            return await _companyJobPayRepository.InsertAsync(companyJobPay);
        }

        public async Task<CompanyJobPay> UpdateAsync(
            Guid id,
            Guid companyMainId, Guid companyJobId, string jobPayTypeCode, bool isCancel, string extendedInformation, DateTime dateA, DateTime dateD, int sort, string note, string status, DateTime? dateReal = null, [CanBeNull] string concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(jobPayTypeCode, nameof(jobPayTypeCode));
            Check.Length(jobPayTypeCode, nameof(jobPayTypeCode), CompanyJobPayConsts.JobPayTypeCodeMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyJobPayConsts.ExtendedInformationMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.Length(note, nameof(note), CompanyJobPayConsts.NoteMaxLength);
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), CompanyJobPayConsts.StatusMaxLength);

            var companyJobPay = await _companyJobPayRepository.GetAsync(id);

            companyJobPay.CompanyMainId = companyMainId;
            companyJobPay.CompanyJobId = companyJobId;
            companyJobPay.JobPayTypeCode = jobPayTypeCode;
            companyJobPay.IsCancel = isCancel;
            companyJobPay.ExtendedInformation = extendedInformation;
            companyJobPay.DateA = dateA;
            companyJobPay.DateD = dateD;
            companyJobPay.Sort = sort;
            companyJobPay.Note = note;
            companyJobPay.Status = status;
            companyJobPay.DateReal = dateReal;

            companyJobPay.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _companyJobPayRepository.UpdateAsync(companyJobPay);
        }

    }
}