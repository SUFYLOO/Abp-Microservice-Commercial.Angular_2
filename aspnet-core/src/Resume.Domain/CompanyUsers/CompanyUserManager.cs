using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Resume.CompanyUsers
{
    public class CompanyUserManager : DomainService
    {
        private readonly ICompanyUserRepository _companyUserRepository;

        public CompanyUserManager(ICompanyUserRepository companyUserRepository)
        {
            _companyUserRepository = companyUserRepository;
        }

        public async Task<CompanyUser> CreateAsync(
        Guid companyMainId, Guid userMainId, DateTime dateA, DateTime dateD, int sort, string status, bool matchingReceive, string jobName = null, string officePhone = null, string extendedInformation = null, string note = null)
        {
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), CompanyUserConsts.StatusMaxLength);
            Check.Length(jobName, nameof(jobName), CompanyUserConsts.JobNameMaxLength);
            Check.Length(officePhone, nameof(officePhone), CompanyUserConsts.OfficePhoneMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyUserConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), CompanyUserConsts.NoteMaxLength);

            var companyUser = new CompanyUser(
             GuidGenerator.Create(),
             companyMainId, userMainId, dateA, dateD, sort, status, matchingReceive, jobName, officePhone, extendedInformation, note
             );

            return await _companyUserRepository.InsertAsync(companyUser);
        }

        public async Task<CompanyUser> UpdateAsync(
            Guid id,
            Guid companyMainId, Guid userMainId, DateTime dateA, DateTime dateD, int sort, string status, bool matchingReceive, string jobName = null, string officePhone = null, string extendedInformation = null, string note = null
        )
        {
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), CompanyUserConsts.StatusMaxLength);
            Check.Length(jobName, nameof(jobName), CompanyUserConsts.JobNameMaxLength);
            Check.Length(officePhone, nameof(officePhone), CompanyUserConsts.OfficePhoneMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyUserConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), CompanyUserConsts.NoteMaxLength);

            var companyUser = await _companyUserRepository.GetAsync(id);

            companyUser.CompanyMainId = companyMainId;
            companyUser.UserMainId = userMainId;
            companyUser.DateA = dateA;
            companyUser.DateD = dateD;
            companyUser.Sort = sort;
            companyUser.Status = status;
            companyUser.MatchingReceive = matchingReceive;
            companyUser.JobName = jobName;
            companyUser.OfficePhone = officePhone;
            companyUser.ExtendedInformation = extendedInformation;
            companyUser.Note = note;

            return await _companyUserRepository.UpdateAsync(companyUser);
        }

    }
}