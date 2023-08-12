using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Resume.ShareDefaults
{
    public class ShareDefaultManager : DomainService
    {
        private readonly IShareDefaultRepository _shareDefaultRepository;

        public ShareDefaultManager(IShareDefaultRepository shareDefaultRepository)
        {
            _shareDefaultRepository = shareDefaultRepository;
        }

        public async Task<ShareDefault> CreateAsync(
        string groupCode, string key1, string key2, string key3, string name, string fieldKey, string fieldValue, string columnTypeCode, string formTypeCode, bool systemUse, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {
            Check.NotNullOrWhiteSpace(groupCode, nameof(groupCode));
            Check.Length(groupCode, nameof(groupCode), ShareDefaultConsts.GroupCodeMaxLength);
            Check.Length(key1, nameof(key1), ShareDefaultConsts.Key1MaxLength);
            Check.Length(key2, nameof(key2), ShareDefaultConsts.Key2MaxLength);
            Check.Length(key3, nameof(key3), ShareDefaultConsts.Key3MaxLength);
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), ShareDefaultConsts.NameMaxLength);
            Check.NotNullOrWhiteSpace(fieldKey, nameof(fieldKey));
            Check.Length(fieldKey, nameof(fieldKey), ShareDefaultConsts.FieldKeyMaxLength);
            Check.Length(fieldValue, nameof(fieldValue), ShareDefaultConsts.FieldValueMaxLength);
            Check.NotNullOrWhiteSpace(columnTypeCode, nameof(columnTypeCode));
            Check.Length(columnTypeCode, nameof(columnTypeCode), ShareDefaultConsts.ColumnTypeCodeMaxLength);
            Check.NotNullOrWhiteSpace(formTypeCode, nameof(formTypeCode));
            Check.Length(formTypeCode, nameof(formTypeCode), ShareDefaultConsts.FormTypeCodeMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ShareDefaultConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ShareDefaultConsts.NoteMaxLength);
            Check.Length(status, nameof(status), ShareDefaultConsts.StatusMaxLength);

            var shareDefault = new ShareDefault(
             GuidGenerator.Create(),
             groupCode, key1, key2, key3, name, fieldKey, fieldValue, columnTypeCode, formTypeCode, systemUse, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _shareDefaultRepository.InsertAsync(shareDefault);
        }

        public async Task<ShareDefault> UpdateAsync(
            Guid id,
            string groupCode, string key1, string key2, string key3, string name, string fieldKey, string fieldValue, string columnTypeCode, string formTypeCode, bool systemUse, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null
        )
        {
            Check.NotNullOrWhiteSpace(groupCode, nameof(groupCode));
            Check.Length(groupCode, nameof(groupCode), ShareDefaultConsts.GroupCodeMaxLength);
            Check.Length(key1, nameof(key1), ShareDefaultConsts.Key1MaxLength);
            Check.Length(key2, nameof(key2), ShareDefaultConsts.Key2MaxLength);
            Check.Length(key3, nameof(key3), ShareDefaultConsts.Key3MaxLength);
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), ShareDefaultConsts.NameMaxLength);
            Check.NotNullOrWhiteSpace(fieldKey, nameof(fieldKey));
            Check.Length(fieldKey, nameof(fieldKey), ShareDefaultConsts.FieldKeyMaxLength);
            Check.Length(fieldValue, nameof(fieldValue), ShareDefaultConsts.FieldValueMaxLength);
            Check.NotNullOrWhiteSpace(columnTypeCode, nameof(columnTypeCode));
            Check.Length(columnTypeCode, nameof(columnTypeCode), ShareDefaultConsts.ColumnTypeCodeMaxLength);
            Check.NotNullOrWhiteSpace(formTypeCode, nameof(formTypeCode));
            Check.Length(formTypeCode, nameof(formTypeCode), ShareDefaultConsts.FormTypeCodeMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ShareDefaultConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ShareDefaultConsts.NoteMaxLength);
            Check.Length(status, nameof(status), ShareDefaultConsts.StatusMaxLength);

            var shareDefault = await _shareDefaultRepository.GetAsync(id);

            shareDefault.GroupCode = groupCode;
            shareDefault.Key1 = key1;
            shareDefault.Key2 = key2;
            shareDefault.Key3 = key3;
            shareDefault.Name = name;
            shareDefault.FieldKey = fieldKey;
            shareDefault.FieldValue = fieldValue;
            shareDefault.ColumnTypeCode = columnTypeCode;
            shareDefault.FormTypeCode = formTypeCode;
            shareDefault.SystemUse = systemUse;
            shareDefault.ExtendedInformation = extendedInformation;
            shareDefault.DateA = dateA;
            shareDefault.DateD = dateD;
            shareDefault.Sort = sort;
            shareDefault.Note = note;
            shareDefault.Status = status;

            return await _shareDefaultRepository.UpdateAsync(shareDefault);
        }

    }
}