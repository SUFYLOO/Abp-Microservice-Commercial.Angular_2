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
        string groupCode, string key1, string key2, string key3, string name, string fieldKey, string fieldValue, string columnTypeCode, string formTypeCode, bool systemUse, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null)
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
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), ShareDefaultConsts.StatusMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ShareDefaultConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ShareDefaultConsts.NoteMaxLength);

            var shareDefault = new ShareDefault(
             GuidGenerator.Create(),
             groupCode, key1, key2, key3, name, fieldKey, fieldValue, columnTypeCode, formTypeCode, systemUse, dateA, dateD, sort, status, extendedInformation, note
             );

            return await _shareDefaultRepository.InsertAsync(shareDefault);
        }

        public async Task<ShareDefault> UpdateAsync(
            Guid id,
            string groupCode, string key1, string key2, string key3, string name, string fieldKey, string fieldValue, string columnTypeCode, string formTypeCode, bool systemUse, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null
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
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), ShareDefaultConsts.StatusMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ShareDefaultConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ShareDefaultConsts.NoteMaxLength);

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
            shareDefault.DateA = dateA;
            shareDefault.DateD = dateD;
            shareDefault.Sort = sort;
            shareDefault.Status = status;
            shareDefault.ExtendedInformation = extendedInformation;
            shareDefault.Note = note;

            return await _shareDefaultRepository.UpdateAsync(shareDefault);
        }

    }
}