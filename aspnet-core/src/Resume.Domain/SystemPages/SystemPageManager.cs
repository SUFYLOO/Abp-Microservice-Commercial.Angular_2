using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Resume.SystemPages
{
    public class SystemPageManager : DomainService
    {
        private readonly ISystemPageRepository _systemPageRepository;

        public SystemPageManager(ISystemPageRepository systemPageRepository)
        {
            _systemPageRepository = systemPageRepository;
        }

        public async Task<SystemPage> CreateAsync(
        string typeCode, string systemUserRoleKeys, string parentCode, DateTime dateA, DateTime dateD, int sort, string status, string filePath = null, string fileName = null, string fileTitle = null, string extendedInformation = null, string note = null)
        {
            Check.NotNullOrWhiteSpace(typeCode, nameof(typeCode));
            Check.Length(typeCode, nameof(typeCode), SystemPageConsts.TypeCodeMaxLength);
            Check.NotNullOrWhiteSpace(systemUserRoleKeys, nameof(systemUserRoleKeys));
            Check.Length(systemUserRoleKeys, nameof(systemUserRoleKeys), SystemPageConsts.SystemUserRoleKeysMaxLength);
            Check.NotNullOrWhiteSpace(parentCode, nameof(parentCode));
            Check.Length(parentCode, nameof(parentCode), SystemPageConsts.ParentCodeMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), SystemPageConsts.StatusMaxLength);
            Check.Length(filePath, nameof(filePath), SystemPageConsts.FilePathMaxLength);
            Check.Length(fileName, nameof(fileName), SystemPageConsts.FileNameMaxLength);
            Check.Length(fileTitle, nameof(fileTitle), SystemPageConsts.FileTitleMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), SystemPageConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), SystemPageConsts.NoteMaxLength);

            var systemPage = new SystemPage(
             GuidGenerator.Create(),
             typeCode, systemUserRoleKeys, parentCode, dateA, dateD, sort, status, filePath, fileName, fileTitle, extendedInformation, note
             );

            return await _systemPageRepository.InsertAsync(systemPage);
        }

        public async Task<SystemPage> UpdateAsync(
            Guid id,
            string typeCode, string systemUserRoleKeys, string parentCode, DateTime dateA, DateTime dateD, int sort, string status, string filePath = null, string fileName = null, string fileTitle = null, string extendedInformation = null, string note = null
        )
        {
            Check.NotNullOrWhiteSpace(typeCode, nameof(typeCode));
            Check.Length(typeCode, nameof(typeCode), SystemPageConsts.TypeCodeMaxLength);
            Check.NotNullOrWhiteSpace(systemUserRoleKeys, nameof(systemUserRoleKeys));
            Check.Length(systemUserRoleKeys, nameof(systemUserRoleKeys), SystemPageConsts.SystemUserRoleKeysMaxLength);
            Check.NotNullOrWhiteSpace(parentCode, nameof(parentCode));
            Check.Length(parentCode, nameof(parentCode), SystemPageConsts.ParentCodeMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), SystemPageConsts.StatusMaxLength);
            Check.Length(filePath, nameof(filePath), SystemPageConsts.FilePathMaxLength);
            Check.Length(fileName, nameof(fileName), SystemPageConsts.FileNameMaxLength);
            Check.Length(fileTitle, nameof(fileTitle), SystemPageConsts.FileTitleMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), SystemPageConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), SystemPageConsts.NoteMaxLength);

            var systemPage = await _systemPageRepository.GetAsync(id);

            systemPage.TypeCode = typeCode;
            systemPage.SystemUserRoleKeys = systemUserRoleKeys;
            systemPage.ParentCode = parentCode;
            systemPage.DateA = dateA;
            systemPage.DateD = dateD;
            systemPage.Sort = sort;
            systemPage.Status = status;
            systemPage.FilePath = filePath;
            systemPage.FileName = fileName;
            systemPage.FileTitle = fileTitle;
            systemPage.ExtendedInformation = extendedInformation;
            systemPage.Note = note;

            return await _systemPageRepository.UpdateAsync(systemPage);
        }

    }
}