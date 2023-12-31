using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.UserCompanyJobFavs
{
    public class UserCompanyJobFav : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid UserMainId { get; set; }

        public virtual Guid CompanyJobId { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime? DateA { get; set; }

        public virtual DateTime? DateD { get; set; }

        public virtual int? Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [CanBeNull]
        public virtual string? Status { get; set; }

        public UserCompanyJobFav()
        {

        }

        public UserCompanyJobFav(Guid id, Guid userMainId, Guid companyJobId, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {

            Id = id;
            Check.Length(extendedInformation, nameof(extendedInformation), UserCompanyJobFavConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), UserCompanyJobFavConsts.NoteMaxLength, 0);
            Check.Length(status, nameof(status), UserCompanyJobFavConsts.StatusMaxLength, 0);
            UserMainId = userMainId;
            CompanyJobId = companyJobId;
            ExtendedInformation = extendedInformation;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Note = note;
            Status = status;
        }

    }
}