using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

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
        Guid companyMainId, Guid companyJobId, string jobPayTypeCode, bool isCancel, DateTime? dateReal = null, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {
            Check.NotNullOrWhiteSpace(jobPayTypeCode, nameof(jobPayTypeCode));
            Check.Length(jobPayTypeCode, nameof(jobPayTypeCode), CompanyJobPayConsts.JobPayTypeCodeMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyJobPayConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), CompanyJobPayConsts.NoteMaxLength);
            Check.Length(status, nameof(status), CompanyJobPayConsts.StatusMaxLength);

            var companyJobPay = new CompanyJobPay(
             GuidGenerator.Create(),
             companyMainId, companyJobId, jobPayTypeCode, isCancel, dateReal, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _companyJobPayRepository.InsertAsync(companyJobPay);
        }

        public async Task<CompanyJobPay> UpdateAsync(
            Guid id,
            Guid companyMainId, Guid companyJobId, string jobPayTypeCode, bool isCancel, DateTime? dateReal = null, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null
        )
        {
            Check.NotNullOrWhiteSpace(jobPayTypeCode, nameof(jobPayTypeCode));
            Check.Length(jobPayTypeCode, nameof(jobPayTypeCode), CompanyJobPayConsts.JobPayTypeCodeMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyJobPayConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), CompanyJobPayConsts.NoteMaxLength);
            Check.Length(status, nameof(status), CompanyJobPayConsts.StatusMaxLength);

            var companyJobPay = await _companyJobPayRepository.GetAsync(id);

            companyJobPay.CompanyMainId = companyMainId;
            companyJobPay.CompanyJobId = companyJobId;
            companyJobPay.JobPayTypeCode = jobPayTypeCode;
            companyJobPay.IsCancel = isCancel;
            companyJobPay.DateReal = dateReal;
            companyJobPay.ExtendedInformation = extendedInformation;
            companyJobPay.DateA = dateA;
            companyJobPay.DateD = dateD;
            companyJobPay.Sort = sort;
            companyJobPay.Note = note;
            companyJobPay.Status = status;

            return await _companyJobPayRepository.UpdateAsync(companyJobPay);
        }

    }
}