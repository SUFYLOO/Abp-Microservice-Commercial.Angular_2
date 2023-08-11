using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Resume.SystemUserRoles
{
    public class SystemUserRoleManager : DomainService
    {
        private readonly ISystemUserRoleRepository _systemUserRoleRepository;

        public SystemUserRoleManager(ISystemUserRoleRepository systemUserRoleRepository)
        {
            _systemUserRoleRepository = systemUserRoleRepository;
        }

        public async Task<SystemUserRole> CreateAsync(
        string name, int keys, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), SystemUserRoleConsts.NameMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), SystemUserRoleConsts.StatusMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), SystemUserRoleConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), SystemUserRoleConsts.NoteMaxLength);

            var systemUserRole = new SystemUserRole(
             GuidGenerator.Create(),
             name, keys, dateA, dateD, sort, status, extendedInformation, note
             );

            return await _systemUserRoleRepository.InsertAsync(systemUserRole);
        }

        public async Task<SystemUserRole> UpdateAsync(
            Guid id,
            string name, int keys, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), SystemUserRoleConsts.NameMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), SystemUserRoleConsts.StatusMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), SystemUserRoleConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), SystemUserRoleConsts.NoteMaxLength);

            var systemUserRole = await _systemUserRoleRepository.GetAsync(id);

            systemUserRole.Name = name;
            systemUserRole.Keys = keys;
            systemUserRole.DateA = dateA;
            systemUserRole.DateD = dateD;
            systemUserRole.Sort = sort;
            systemUserRole.Status = status;
            systemUserRole.ExtendedInformation = extendedInformation;
            systemUserRole.Note = note;

            return await _systemUserRoleRepository.UpdateAsync(systemUserRole);
        }

    }
}