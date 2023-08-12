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
        string name, bool allowInsert, bool allowUpdate, bool allowDelete, bool allowSelect, bool allowExport, bool allowImport, bool allowPage, bool allowSort, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), SystemTableConsts.NameMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), SystemTableConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), SystemTableConsts.NoteMaxLength);
            Check.Length(status, nameof(status), SystemTableConsts.StatusMaxLength);

            var systemTable = new SystemTable(
             GuidGenerator.Create(),
             name, allowInsert, allowUpdate, allowDelete, allowSelect, allowExport, allowImport, allowPage, allowSort, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _systemTableRepository.InsertAsync(systemTable);
        }

        public async Task<SystemTable> UpdateAsync(
            Guid id,
            string name, bool allowInsert, bool allowUpdate, bool allowDelete, bool allowSelect, bool allowExport, bool allowImport, bool allowPage, bool allowSort, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), SystemTableConsts.NameMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), SystemTableConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), SystemTableConsts.NoteMaxLength);
            Check.Length(status, nameof(status), SystemTableConsts.StatusMaxLength);

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
            systemTable.ExtendedInformation = extendedInformation;
            systemTable.DateA = dateA;
            systemTable.DateD = dateD;
            systemTable.Sort = sort;
            systemTable.Note = note;
            systemTable.Status = status;

            return await _systemTableRepository.UpdateAsync(systemTable);
        }

    }
}