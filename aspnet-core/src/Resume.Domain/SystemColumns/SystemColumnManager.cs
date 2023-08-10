using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Resume.SystemColumns
{
    public class SystemColumnManager : DomainService
    {
        private readonly ISystemColumnRepository _systemColumnRepository;

        public SystemColumnManager(ISystemColumnRepository systemColumnRepository)
        {
            _systemColumnRepository = systemColumnRepository;
        }

        public async Task<SystemColumn> CreateAsync(
        Guid systemTableId, string name, bool isKey, bool isSensitive, bool needMask, string defaultValue, bool checkCode, string related, bool allowUpdate, bool allowNull, bool allowEmpty, bool allowExport, bool allowSort, string columnTypeCode, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), SystemColumnConsts.NameMaxLength);
            Check.Length(defaultValue, nameof(defaultValue), SystemColumnConsts.DefaultValueMaxLength);
            Check.Length(related, nameof(related), SystemColumnConsts.RelatedMaxLength);
            Check.NotNullOrWhiteSpace(columnTypeCode, nameof(columnTypeCode));
            Check.Length(columnTypeCode, nameof(columnTypeCode), SystemColumnConsts.ColumnTypeCodeMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), SystemColumnConsts.StatusMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), SystemColumnConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), SystemColumnConsts.NoteMaxLength);

            var systemColumn = new SystemColumn(
             GuidGenerator.Create(),
             systemTableId, name, isKey, isSensitive, needMask, defaultValue, checkCode, related, allowUpdate, allowNull, allowEmpty, allowExport, allowSort, columnTypeCode, dateA, dateD, sort, status, extendedInformation, note
             );

            return await _systemColumnRepository.InsertAsync(systemColumn);
        }

        public async Task<SystemColumn> UpdateAsync(
            Guid id,
            Guid systemTableId, string name, bool isKey, bool isSensitive, bool needMask, string defaultValue, bool checkCode, string related, bool allowUpdate, bool allowNull, bool allowEmpty, bool allowExport, bool allowSort, string columnTypeCode, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), SystemColumnConsts.NameMaxLength);
            Check.Length(defaultValue, nameof(defaultValue), SystemColumnConsts.DefaultValueMaxLength);
            Check.Length(related, nameof(related), SystemColumnConsts.RelatedMaxLength);
            Check.NotNullOrWhiteSpace(columnTypeCode, nameof(columnTypeCode));
            Check.Length(columnTypeCode, nameof(columnTypeCode), SystemColumnConsts.ColumnTypeCodeMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), SystemColumnConsts.StatusMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), SystemColumnConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), SystemColumnConsts.NoteMaxLength);

            var systemColumn = await _systemColumnRepository.GetAsync(id);

            systemColumn.SystemTableId = systemTableId;
            systemColumn.Name = name;
            systemColumn.IsKey = isKey;
            systemColumn.IsSensitive = isSensitive;
            systemColumn.NeedMask = needMask;
            systemColumn.DefaultValue = defaultValue;
            systemColumn.CheckCode = checkCode;
            systemColumn.Related = related;
            systemColumn.AllowUpdate = allowUpdate;
            systemColumn.AllowNull = allowNull;
            systemColumn.AllowEmpty = allowEmpty;
            systemColumn.AllowExport = allowExport;
            systemColumn.AllowSort = allowSort;
            systemColumn.ColumnTypeCode = columnTypeCode;
            systemColumn.DateA = dateA;
            systemColumn.DateD = dateD;
            systemColumn.Sort = sort;
            systemColumn.Status = status;
            systemColumn.ExtendedInformation = extendedInformation;
            systemColumn.Note = note;

            return await _systemColumnRepository.UpdateAsync(systemColumn);
        }

    }
}