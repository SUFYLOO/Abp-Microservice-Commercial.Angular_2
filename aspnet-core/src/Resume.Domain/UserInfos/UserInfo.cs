using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.UserInfos
{
    public class UserInfo : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid UserMainId { get; set; }

        [NotNull]
        public virtual string NameC { get; set; }

        [CanBeNull]
        public virtual string? NameE { get; set; }

        [CanBeNull]
        public virtual string? IdentityNo { get; set; }

        public virtual DateTime? BirthDate { get; set; }

        [CanBeNull]
        public virtual string? SexCode { get; set; }

        [CanBeNull]
        public virtual string? BloodCode { get; set; }

        [CanBeNull]
        public virtual string? PlaceOfBirthCode { get; set; }

        [CanBeNull]
        public virtual string? PassportNo { get; set; }

        [CanBeNull]
        public virtual string? NationalityCode { get; set; }

        [CanBeNull]
        public virtual string? ResidenceNo { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime DateA { get; set; }

        public virtual DateTime DateD { get; set; }

        public virtual int Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [NotNull]
        public virtual string Status { get; set; }

        public UserInfo()
        {

        }

        public UserInfo(Guid id, Guid userMainId, string nameC, string nameE, string identityNo, string sexCode, string bloodCode, string placeOfBirthCode, string passportNo, string nationalityCode, string residenceNo, string extendedInformation, DateTime dateA, DateTime dateD, int sort, string note, string status, DateTime? birthDate = null)
        {

            Id = id;
            Check.NotNull(nameC, nameof(nameC));
            Check.Length(nameC, nameof(nameC), UserInfoConsts.NameCMaxLength, 0);
            Check.Length(nameE, nameof(nameE), UserInfoConsts.NameEMaxLength, 0);
            Check.Length(identityNo, nameof(identityNo), UserInfoConsts.IdentityNoMaxLength, 0);
            Check.Length(sexCode, nameof(sexCode), UserInfoConsts.SexCodeMaxLength, 0);
            Check.Length(bloodCode, nameof(bloodCode), UserInfoConsts.BloodCodeMaxLength, 0);
            Check.Length(placeOfBirthCode, nameof(placeOfBirthCode), UserInfoConsts.PlaceOfBirthCodeMaxLength, 0);
            Check.Length(passportNo, nameof(passportNo), UserInfoConsts.PassportNoMaxLength, 0);
            Check.Length(nationalityCode, nameof(nationalityCode), UserInfoConsts.NationalityCodeMaxLength, 0);
            Check.Length(residenceNo, nameof(residenceNo), UserInfoConsts.ResidenceNoMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), UserInfoConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), UserInfoConsts.NoteMaxLength, 0);
            Check.NotNull(status, nameof(status));
            Check.Length(status, nameof(status), UserInfoConsts.StatusMaxLength, 0);
            UserMainId = userMainId;
            NameC = nameC;
            NameE = nameE;
            IdentityNo = identityNo;
            SexCode = sexCode;
            BloodCode = bloodCode;
            PlaceOfBirthCode = placeOfBirthCode;
            PassportNo = passportNo;
            NationalityCode = nationalityCode;
            ResidenceNo = residenceNo;
            ExtendedInformation = extendedInformation;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Note = note;
            Status = status;
            BirthDate = birthDate;
        }

    }
}