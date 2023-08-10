using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Resume.CompanyJobs
{
    public class CompanyJobManager : DomainService
    {
        private readonly ICompanyJobRepository _companyJobRepository;

        public CompanyJobManager(ICompanyJobRepository companyJobRepository)
        {
            _companyJobRepository = companyJobRepository;
        }

        public async Task<CompanyJob> CreateAsync(
        Guid companyMainId, string name, string jobTypeCode, bool jobOpen, string mailTplId, string sMSTplId, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), CompanyJobConsts.NameMaxLength);
            Check.NotNullOrWhiteSpace(jobTypeCode, nameof(jobTypeCode));
            Check.Length(jobTypeCode, nameof(jobTypeCode), CompanyJobConsts.JobTypeCodeMaxLength);
            Check.NotNullOrWhiteSpace(mailTplId, nameof(mailTplId));
            Check.Length(mailTplId, nameof(mailTplId), CompanyJobConsts.MailTplIdMaxLength);
            Check.NotNullOrWhiteSpace(sMSTplId, nameof(sMSTplId));
            Check.Length(sMSTplId, nameof(sMSTplId), CompanyJobConsts.SMSTplIdMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), CompanyJobConsts.StatusMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyJobConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), CompanyJobConsts.NoteMaxLength);

            var companyJob = new CompanyJob(
             GuidGenerator.Create(),
             companyMainId, name, jobTypeCode, jobOpen, mailTplId, sMSTplId, dateA, dateD, sort, status, extendedInformation, note
             );

            return await _companyJobRepository.InsertAsync(companyJob);
        }

        public async Task<CompanyJob> UpdateAsync(
            Guid id,
            Guid companyMainId, string name, string jobTypeCode, bool jobOpen, string mailTplId, string sMSTplId, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), CompanyJobConsts.NameMaxLength);
            Check.NotNullOrWhiteSpace(jobTypeCode, nameof(jobTypeCode));
            Check.Length(jobTypeCode, nameof(jobTypeCode), CompanyJobConsts.JobTypeCodeMaxLength);
            Check.NotNullOrWhiteSpace(mailTplId, nameof(mailTplId));
            Check.Length(mailTplId, nameof(mailTplId), CompanyJobConsts.MailTplIdMaxLength);
            Check.NotNullOrWhiteSpace(sMSTplId, nameof(sMSTplId));
            Check.Length(sMSTplId, nameof(sMSTplId), CompanyJobConsts.SMSTplIdMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), CompanyJobConsts.StatusMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyJobConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), CompanyJobConsts.NoteMaxLength);

            var companyJob = await _companyJobRepository.GetAsync(id);

            companyJob.CompanyMainId = companyMainId;
            companyJob.Name = name;
            companyJob.JobTypeCode = jobTypeCode;
            companyJob.JobOpen = jobOpen;
            companyJob.MailTplId = mailTplId;
            companyJob.SMSTplId = sMSTplId;
            companyJob.DateA = dateA;
            companyJob.DateD = dateD;
            companyJob.Sort = sort;
            companyJob.Status = status;
            companyJob.ExtendedInformation = extendedInformation;
            companyJob.Note = note;

            return await _companyJobRepository.UpdateAsync(companyJob);
        }

    }
}