using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Resume.CompanyJobApplicationMethods
{
    public class CompanyJobApplicationMethodManager : DomainService
    {
        private readonly ICompanyJobApplicationMethodRepository _companyJobApplicationMethodRepository;

        public CompanyJobApplicationMethodManager(ICompanyJobApplicationMethodRepository companyJobApplicationMethodRepository)
        {
            _companyJobApplicationMethodRepository = companyJobApplicationMethodRepository;
        }

        public async Task<CompanyJobApplicationMethod> CreateAsync(
        Guid companyMainId, Guid companyJobId, string orgContactPerson, string orgContactMail, int toRespondDay, bool toRespond, bool systemSendResume, bool displayMail, string telephone, string personally, string personallyAddress, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {
            Check.Length(orgContactPerson, nameof(orgContactPerson), CompanyJobApplicationMethodConsts.OrgContactPersonMaxLength);
            Check.Length(orgContactMail, nameof(orgContactMail), CompanyJobApplicationMethodConsts.OrgContactMailMaxLength);
            Check.Length(telephone, nameof(telephone), CompanyJobApplicationMethodConsts.TelephoneMaxLength);
            Check.Length(personally, nameof(personally), CompanyJobApplicationMethodConsts.PersonallyMaxLength);
            Check.Length(personallyAddress, nameof(personallyAddress), CompanyJobApplicationMethodConsts.PersonallyAddressMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyJobApplicationMethodConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), CompanyJobApplicationMethodConsts.NoteMaxLength);
            Check.Length(status, nameof(status), CompanyJobApplicationMethodConsts.StatusMaxLength);

            var companyJobApplicationMethod = new CompanyJobApplicationMethod(
             GuidGenerator.Create(),
             companyMainId, companyJobId, orgContactPerson, orgContactMail, toRespondDay, toRespond, systemSendResume, displayMail, telephone, personally, personallyAddress, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _companyJobApplicationMethodRepository.InsertAsync(companyJobApplicationMethod);
        }

        public async Task<CompanyJobApplicationMethod> UpdateAsync(
            Guid id,
            Guid companyMainId, Guid companyJobId, string orgContactPerson, string orgContactMail, int toRespondDay, bool toRespond, bool systemSendResume, bool displayMail, string telephone, string personally, string personallyAddress, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null
        )
        {
            Check.Length(orgContactPerson, nameof(orgContactPerson), CompanyJobApplicationMethodConsts.OrgContactPersonMaxLength);
            Check.Length(orgContactMail, nameof(orgContactMail), CompanyJobApplicationMethodConsts.OrgContactMailMaxLength);
            Check.Length(telephone, nameof(telephone), CompanyJobApplicationMethodConsts.TelephoneMaxLength);
            Check.Length(personally, nameof(personally), CompanyJobApplicationMethodConsts.PersonallyMaxLength);
            Check.Length(personallyAddress, nameof(personallyAddress), CompanyJobApplicationMethodConsts.PersonallyAddressMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyJobApplicationMethodConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), CompanyJobApplicationMethodConsts.NoteMaxLength);
            Check.Length(status, nameof(status), CompanyJobApplicationMethodConsts.StatusMaxLength);

            var companyJobApplicationMethod = await _companyJobApplicationMethodRepository.GetAsync(id);

            companyJobApplicationMethod.CompanyMainId = companyMainId;
            companyJobApplicationMethod.CompanyJobId = companyJobId;
            companyJobApplicationMethod.OrgContactPerson = orgContactPerson;
            companyJobApplicationMethod.OrgContactMail = orgContactMail;
            companyJobApplicationMethod.ToRespondDay = toRespondDay;
            companyJobApplicationMethod.ToRespond = toRespond;
            companyJobApplicationMethod.SystemSendResume = systemSendResume;
            companyJobApplicationMethod.DisplayMail = displayMail;
            companyJobApplicationMethod.Telephone = telephone;
            companyJobApplicationMethod.Personally = personally;
            companyJobApplicationMethod.PersonallyAddress = personallyAddress;
            companyJobApplicationMethod.ExtendedInformation = extendedInformation;
            companyJobApplicationMethod.DateA = dateA;
            companyJobApplicationMethod.DateD = dateD;
            companyJobApplicationMethod.Sort = sort;
            companyJobApplicationMethod.Note = note;
            companyJobApplicationMethod.Status = status;

            return await _companyJobApplicationMethodRepository.UpdateAsync(companyJobApplicationMethod);
        }

    }
}