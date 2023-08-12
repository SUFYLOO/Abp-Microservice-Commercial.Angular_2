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
        Guid companyMainId, Guid userMainId, string jobName = null, string officePhone = null, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null, bool? matchingReceive = null)
        {
            Check.Length(jobName, nameof(jobName), CompanyUserConsts.JobNameMaxLength);
            Check.Length(officePhone, nameof(officePhone), CompanyUserConsts.OfficePhoneMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyUserConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), CompanyUserConsts.NoteMaxLength);
            Check.Length(status, nameof(status), CompanyUserConsts.StatusMaxLength);

            var companyUser = new CompanyUser(
             GuidGenerator.Create(),
             companyMainId, userMainId, jobName, officePhone, extendedInformation, dateA, dateD, sort, note, status, matchingReceive
             );

            return await _companyUserRepository.InsertAsync(companyUser);
        }

        public async Task<CompanyUser> UpdateAsync(
            Guid id,
            Guid companyMainId, Guid userMainId, string jobName = null, string officePhone = null, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null, bool? matchingReceive = null
        )
        {
            Check.Length(jobName, nameof(jobName), CompanyUserConsts.JobNameMaxLength);
            Check.Length(officePhone, nameof(officePhone), CompanyUserConsts.OfficePhoneMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyUserConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), CompanyUserConsts.NoteMaxLength);
            Check.Length(status, nameof(status), CompanyUserConsts.StatusMaxLength);

            var companyUser = await _companyUserRepository.GetAsync(id);

            companyUser.CompanyMainId = companyMainId;
            companyUser.UserMainId = userMainId;
            companyUser.JobName = jobName;
            companyUser.OfficePhone = officePhone;
            companyUser.ExtendedInformation = extendedInformation;
            companyUser.DateA = dateA;
            companyUser.DateD = dateD;
            companyUser.Sort = sort;
            companyUser.Note = note;
            companyUser.Status = status;
            companyUser.MatchingReceive = matchingReceive;

            return await _companyUserRepository.UpdateAsync(companyUser);
        }

    }
}