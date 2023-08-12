using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.ShareUploads
{
    public class ShareUpload : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        [CanBeNull]
        public virtual string? Key1 { get; set; }

        [CanBeNull]
        public virtual string? Key2 { get; set; }

        [CanBeNull]
        public virtual string? Key3 { get; set; }

        [NotNull]
        public virtual string UploadName { get; set; }

        [NotNull]
        public virtual string ServerName { get; set; }

        [NotNull]
        public virtual string Type { get; set; }

        public virtual int Size { get; set; }

        public virtual bool SystemUse { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime? DateA { get; set; }

        public virtual DateTime? DateD { get; set; }

        public virtual int? Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [CanBeNull]
        public virtual string? Status { get; set; }

        public ShareUpload()
        {

        }

        public ShareUpload(Guid id, string key1, string key2, string key3, string uploadName, string serverName, string type, int size, bool systemUse, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {

            Id = id;
            Check.Length(key1, nameof(key1), ShareUploadConsts.Key1MaxLength, 0);
            Check.Length(key2, nameof(key2), ShareUploadConsts.Key2MaxLength, 0);
            Check.Length(key3, nameof(key3), ShareUploadConsts.Key3MaxLength, 0);
            Check.NotNull(uploadName, nameof(uploadName));
            Check.Length(uploadName, nameof(uploadName), ShareUploadConsts.UploadNameMaxLength, 0);
            Check.NotNull(serverName, nameof(serverName));
            Check.Length(serverName, nameof(serverName), ShareUploadConsts.ServerNameMaxLength, 0);
            Check.NotNull(type, nameof(type));
            Check.Length(type, nameof(type), ShareUploadConsts.TypeMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), ShareUploadConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), ShareUploadConsts.NoteMaxLength, 0);
            Check.Length(status, nameof(status), ShareUploadConsts.StatusMaxLength, 0);
            Key1 = key1;
            Key2 = key2;
            Key3 = key3;
            UploadName = uploadName;
            ServerName = serverName;
            Type = type;
            Size = size;
            SystemUse = systemUse;
            ExtendedInformation = extendedInformation;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Note = note;
            Status = status;
        }

    }
}