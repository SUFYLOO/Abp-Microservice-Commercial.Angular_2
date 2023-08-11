using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Resume.SystemTables
{
    public class SystemTableManager : DomainService
    {
        private readonly ISystemTableRepository _systemTableRepository;

        public SystemTableManager(ISystemTableRepository systemTableRepository)
        {
            _systemTableRepository = systemTableRepository;
        }

        public async Task<SystemTable> CreateAsync(
        string name, bool allowInsert, bool allowUpdate, bool allowDelete, bool allowSelect, bool allowExport, bool allowImport, bool allowPage, bool allowSort, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), SystemTableConsts.NameMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), SystemTableConsts.StatusMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), SystemTableConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), SystemTableConsts.NoteMaxLength);

            var systemTable = new SystemTable(
             GuidGenerator.Create(),
             name, allowInsert, allowUpdate, allowDelete, allowSelect, allowExport, allowImport, allowPage, allowSort, dateA, dateD, sort, status, extendedInformation, note
             );

            return await _systemTableRepository.InsertAsync(systemTable);
        }

        public async Task<SystemTable> UpdateAsync(
            Guid id,
            string name, bool allowInsert, bool allowUpdate, bool allowDelete, bool allowSelect, bool allowExport, bool allowImport, bool allowPage, bool allowSort, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), SystemTableConsts.NameMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), SystemTableConsts.StatusMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), SystemTableConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), SystemTableConsts.NoteMaxLength);

            var systemTable = await _systemTableRepository.GetAsync(id);

            systemTable.Name = name;
            systemTable.AllowInsert = allowInsert;
            systemTable.AllowUpdate = allowUpdate;
            systemTable.AllowDelete = allowDelete;
            systemTable.AllowSelect = allowSelect;
            systemTable.AllowExport = allowExport;
            systemTable.AllowImport = allowImport;
            systemTable.AllowPage = allowPage;
            systemTable.AllowSort = allowSort;
            systemTable.DateA = dateA;
            systemTable.DateD = dateD;
            systemTable.Sort = sort;
            systemTable.Status = status;
            systemTable.ExtendedInformation = extendedInformation;
            systemTable.Note = note;

            return await _systemTableRepository.UpdateAsync(systemTable);
        }

    }
}