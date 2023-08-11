using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.UserMains
{
    public class UserMain : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid UserId { get; set; }

        [NotNull]
        public virtual string Name { get; set; }

        [CanBeNull]
        public virtual string? AnonymousName { get; set; }

        [NotNull]
        public virtual string LoginAccountCode { get; set; }

        [CanBeNull]
        public virtual string? LoginMobilePhoneUpdate { get; set; }

        [CanBeNull]
        public virtual string? LoginMobilePhone { get; set; }

        [CanBeNull]
        public virtual string? LoginEmailUpdate { get; set; }

        [CanBeNull]
        public virtual string? LoginEmail { get; set; }

        [CanBeNull]
        public virtual string? LoginIdentityNo { get; set; }

        [NotNull]
        public virtual string Password { get; set; }

        public virtual int SystemUserRoleKeys { get; set; }

        public virtual bool AllowSearch { get; set; }

        public virtual DateTime DateA { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime DateD { get; set; }

        public virtual int Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [NotNull]
        public virtual string Status { get; set; }

        public virtual bool Matching { get; set; }

        public UserMain()
        {

        }

        public UserMain(Guid id, Guid userId, string name, string loginAccountCode, string loginMobilePhoneUpdate, string loginMobilePhone, string loginEmailUpdate, string loginEmail, string loginIdentityNo, string password, int systemUserRoleKeys, bool allowSearch, DateTime dateA, DateTime dateD, int sort, string status, bool matching, string anonymousName = null, string extendedInformation = null, string note = null)
        {

            Id = id;
            Check.NotNull(name, nameof(name));
            Check.Length(name, nameof(name), UserMainConsts.NameMaxLength, 0);
            Check.NotNull(loginAccountCode, nameof(loginAccountCode));
            Check.Length(loginAccountCode, nameof(loginAccountCode), UserMainConsts.LoginAccountCodeMaxLength, 0);
            Check.Length(loginMobilePhoneUpdate, nameof(loginMobilePhoneUpdate), UserMainConsts.LoginMobilePhoneUpdateMaxLength, 0);
            Check.Length(loginMobilePhone, nameof(loginMobilePhone), UserMainConsts.LoginMobilePhoneMaxLength, 0);
            Check.Length(loginEmailUpdate, nameof(loginEmailUpdate), UserMainConsts.LoginEmailUpdateMaxLength, 0);
            Check.Length(loginEmail, nameof(loginEmail), UserMainConsts.LoginEmailMaxLength, 0);
            Check.Length(loginIdentityNo, nameof(loginIdentityNo), UserMainConsts.LoginIdentityNoMaxLength, 0);
            Check.NotNull(password, nameof(password));
            Check.Length(password, nameof(password), UserMainConsts.PasswordMaxLength, 0);
            Check.NotNull(status, nameof(status));
            Check.Length(status, nameof(status), UserMainConsts.StatusMaxLength, 0);
            Check.Length(anonymousName, nameof(anonymousName), UserMainConsts.AnonymousNameMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), UserMainConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), UserMainConsts.NoteMaxLength, 0);
            UserId = userId;
            Name = name;
            LoginAccountCode = loginAccountCode;
            LoginMobilePhoneUpdate = loginMobilePhoneUpdate;
            LoginMobilePhone = loginMobilePhone;
            LoginEmailUpdate = loginEmailUpdate;
            LoginEmail = loginEmail;
            LoginIdentityNo = loginIdentityNo;
            Password = password;
            SystemUserRoleKeys = systemUserRoleKeys;
            AllowSearch = allowSearch;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Status = status;
            Matching = matching;
            AnonymousName = anonymousName;
            ExtendedInformation = extendedInformation;
            Note = note;
        }

    }
}