using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.SystemPages
{
    public class SystemPage : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        [NotNull]
        public virtual string TypeCode { get; set; }

        [CanBeNull]
        public virtual string? FilePath { get; set; }

        [CanBeNull]
        public virtual string? FileName { get; set; }

        [CanBeNull]
        public virtual string? FileTitle { get; set; }

        [NotNull]
        public virtual string SystemUserRoleKeys { get; set; }

        [NotNull]
        public virtual string ParentCode { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime? DateA { get; set; }

        public virtual DateTime? DateD { get; set; }

        public virtual int? Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [CanBeNull]
        public virtual string? Status { get; set; }

        public SystemPage()
        {

        }

        public SystemPage(Guid id, string typeCode, string systemUserRoleKeys, string parentCode, string filePath = null, string fileName = null, string fileTitle = null, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {

            Id = id;
            Check.NotNull(typeCode, nameof(typeCode));
            Check.Length(typeCode, nameof(typeCode), SystemPageConsts.TypeCodeMaxLength, 0);
            Check.NotNull(systemUserRoleKeys, nameof(systemUserRoleKeys));
            Check.Length(systemUserRoleKeys, nameof(systemUserRoleKeys), SystemPageConsts.SystemUserRoleKeysMaxLength, 0);
            Check.NotNull(parentCode, nameof(parentCode));
            Check.Length(parentCode, nameof(parentCode), SystemPageConsts.ParentCodeMaxLength, 0);
            Check.Length(filePath, nameof(filePath), SystemPageConsts.FilePathMaxLength, 0);
            Check.Length(fileName, nameof(fileName), SystemPageConsts.FileNameMaxLength, 0);
            Check.Length(fileTitle, nameof(fileTitle), SystemPageConsts.FileTitleMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), SystemPageConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), SystemPageConsts.NoteMaxLength, 0);
            Check.Length(status, nameof(status), SystemPageConsts.StatusMaxLength, 0);
            TypeCode = typeCode;
            SystemUserRoleKeys = systemUserRoleKeys;
            ParentCode = parentCode;
            FilePath = filePath;
            FileName = fileName;
            FileTitle = fileTitle;
            ExtendedInformation = extendedInformation;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Note = note;
            Status = status;
        }

    }
}