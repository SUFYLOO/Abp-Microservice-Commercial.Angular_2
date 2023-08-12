using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Resume.ResumeDependentss
{
    public class ResumeDependentsManager : DomainService
    {
        private readonly IResumeDependentsRepository _resumeDependentsRepository;

        public ResumeDependentsManager(IResumeDependentsRepository resumeDependentsRepository)
        {
            _resumeDependentsRepository = resumeDependentsRepository;
        }

        public async Task<ResumeDependents> CreateAsync(
        Guid resumeMainId, string name, string identityNo, string kinshipCode, DateTime birthDate, string address = null, string mobilePhone = null, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), ResumeDependentsConsts.NameMaxLength);
            Check.Length(identityNo, nameof(identityNo), ResumeDependentsConsts.IdentityNoMaxLength);
            Check.NotNullOrWhiteSpace(kinshipCode, nameof(kinshipCode));
            Check.Length(kinshipCode, nameof(kinshipCode), ResumeDependentsConsts.KinshipCodeMaxLength);
            Check.NotNull(birthDate, nameof(birthDate));
            Check.Length(address, nameof(address), ResumeDependentsConsts.AddressMaxLength);
            Check.Length(mobilePhone, nameof(mobilePhone), ResumeDependentsConsts.MobilePhoneMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeDependentsConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ResumeDependentsConsts.NoteMaxLength);
            Check.Length(status, nameof(status), ResumeDependentsConsts.StatusMaxLength);

            var resumeDependents = new ResumeDependents(
             GuidGenerator.Create(),
             resumeMainId, name, identityNo, kinshipCode, birthDate, address, mobilePhone, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _resumeDependentsRepository.InsertAsync(resumeDependents);
        }

        public async Task<ResumeDependents> UpdateAsync(
            Guid id,
            Guid resumeMainId, string name, string identityNo, string kinshipCode, DateTime birthDate, string address = null, string mobilePhone = null, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), ResumeDependentsConsts.NameMaxLength);
            Check.Length(identityNo, nameof(identityNo), ResumeDependentsConsts.IdentityNoMaxLength);
            Check.NotNullOrWhiteSpace(kinshipCode, nameof(kinshipCode));
            Check.Length(kinshipCode, nameof(kinshipCode), ResumeDependentsConsts.KinshipCodeMaxLength);
            Check.NotNull(birthDate, nameof(birthDate));
            Check.Length(address, nameof(address), ResumeDependentsConsts.AddressMaxLength);
            Check.Length(mobilePhone, nameof(mobilePhone), ResumeDependentsConsts.MobilePhoneMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeDependentsConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ResumeDependentsConsts.NoteMaxLength);
            Check.Length(status, nameof(status), ResumeDependentsConsts.StatusMaxLength);

            var resumeDependents = await _resumeDependentsRepository.GetAsync(id);

            resumeDependents.ResumeMainId = resumeMainId;
            resumeDependents.Name = name;
            resumeDependents.IdentityNo = identityNo;
            resumeDependents.KinshipCode = kinshipCode;
            resumeDependents.BirthDate = birthDate;
            resumeDependents.Address = address;
            resumeDependents.MobilePhone = mobilePhone;
            resumeDependents.ExtendedInformation = extendedInformation;
            resumeDependents.DateA = dateA;
            resumeDependents.DateD = dateD;
            resumeDependents.Sort = sort;
            resumeDependents.Note = note;
            resumeDependents.Status = status;

            return await _resumeDependentsRepository.UpdateAsync(resumeDependents);
        }

    }
}