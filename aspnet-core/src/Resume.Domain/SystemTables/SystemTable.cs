using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.SystemTables
{
    public class SystemTable : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        [NotNull]
        public virtual string Name { get; set; }

        public virtual bool AllowInsert { get; set; }

        public virtual bool AllowUpdate { get; set; }

        public virtual bool AllowDelete { get; set; }

        public virtual bool AllowSelect { get; set; }

        public virtual bool AllowExport { get; set; }

        public virtual bool AllowImport { get; set; }

        public virtual bool AllowPage { get; set; }

        public virtual bool AllowSort { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime? DateA { get; set; }

        public virtual DateTime? DateD { get; set; }

        public virtual int? Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [CanBeNull]
        public virtual string? Status { get; set; }

        public SystemTable()
        {

        }

        public SystemTable(Guid id, string name, bool allowInsert, bool allowUpdate, bool allowDelete, bool allowSelect, bool allowExport, bool allowImport, bool allowPage, bool allowSort, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {

            Id = id;
            Check.NotNull(name, nameof(name));
            Check.Length(name, nameof(name), SystemTableConsts.NameMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), SystemTableConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), SystemTableConsts.NoteMaxLength, 0);
            Check.Length(status, nameof(status), SystemTableConsts.StatusMaxLength, 0);
            Name = name;
            AllowInsert = allowInsert;
            AllowUpdate = allowUpdate;
            AllowDelete = allowDelete;
            AllowSelect = allowSelect;
            AllowExport = allowExport;
            AllowImport = allowImport;
            AllowPage = allowPage;
            AllowSort = allowSort;
            ExtendedInformation = extendedInformation;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Note = note;
            Status = status;
        }

    }
}