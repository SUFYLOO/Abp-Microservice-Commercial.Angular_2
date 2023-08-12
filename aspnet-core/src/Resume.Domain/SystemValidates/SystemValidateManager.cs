using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Resume.SystemValidates
{
    public class SystemValidateManager : DomainService
    {
        private readonly ISystemValidateRepository _systemValidateRepository;

        public SystemValidateManager(ISystemValidateRepository systemValidateRepository)
        {
            _systemValidateRepository = systemValidateRepository;
        }

        public async Task<SystemValidate> CreateAsync(
        string param, DateTime dateOpen, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {
            Check.NotNullOrWhiteSpace(param, nameof(param));
            Check.Length(param, nameof(param), SystemValidateConsts.ParamMaxLength);
            Check.NotNull(dateOpen, nameof(dateOpen));
            Check.Length(extendedInformation, nameof(extendedInformation), SystemValidateConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), SystemValidateConsts.NoteMaxLength);
            Check.Length(status, nameof(status), SystemValidateConsts.StatusMaxLength);

            var systemValidate = new SystemValidate(
             GuidGenerator.Create(),
             param, dateOpen, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _systemValidateRepository.InsertAsync(systemValidate);
        }

        public async Task<SystemValidate> UpdateAsync(
            Guid id,
            string param, DateTime dateOpen, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null
        )
        {
            Check.NotNullOrWhiteSpace(param, nameof(param));
            Check.Length(param, nameof(param), SystemValidateConsts.ParamMaxLength);
            Check.NotNull(dateOpen, nameof(dateOpen));
            Check.Length(extendedInformation, nameof(extendedInformation), SystemValidateConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), SystemValidateConsts.NoteMaxLength);
            Check.Length(status, nameof(status), SystemValidateConsts.StatusMaxLength);

            var systemValidate = await _systemValidateRepository.GetAsync(id);

            systemValidate.Param = param;
            systemValidate.DateOpen = dateOpen;
            systemValidate.ExtendedInformation = extendedInformation;
            systemValidate.DateA = dateA;
            systemValidate.DateD = dateD;
            systemValidate.Sort = sort;
            systemValidate.Note = note;
            systemValidate.Status = status;

            return await _systemValidateRepository.UpdateAsync(systemValidate);
        }

    }
}