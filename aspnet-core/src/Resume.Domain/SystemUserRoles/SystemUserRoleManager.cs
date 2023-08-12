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
        string name, int keys, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), SystemUserRoleConsts.NameMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), SystemUserRoleConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), SystemUserRoleConsts.NoteMaxLength);
            Check.Length(status, nameof(status), SystemUserRoleConsts.StatusMaxLength);

            var systemUserRole = new SystemUserRole(
             GuidGenerator.Create(),
             name, keys, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _systemUserRoleRepository.InsertAsync(systemUserRole);
        }

        public async Task<SystemUserRole> UpdateAsync(
            Guid id,
            string name, int keys, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), SystemUserRoleConsts.NameMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), SystemUserRoleConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), SystemUserRoleConsts.NoteMaxLength);
            Check.Length(status, nameof(status), SystemUserRoleConsts.StatusMaxLength);

            var systemUserRole = await _systemUserRoleRepository.GetAsync(id);

            systemUserRole.Name = name;
            systemUserRole.Keys = keys;
            systemUserRole.ExtendedInformation = extendedInformation;
            systemUserRole.DateA = dateA;
            systemUserRole.DateD = dateD;
            systemUserRole.Sort = sort;
            systemUserRole.Note = note;
            systemUserRole.Status = status;

            return await _systemUserRoleRepository.UpdateAsync(systemUserRole);
        }

    }
}