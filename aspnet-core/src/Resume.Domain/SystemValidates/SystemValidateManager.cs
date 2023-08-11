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
        string param, DateTime dateOpen, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null)
        {
            Check.NotNullOrWhiteSpace(param, nameof(param));
            Check.Length(param, nameof(param), SystemValidateConsts.ParamMaxLength);
            Check.NotNull(dateOpen, nameof(dateOpen));
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), SystemValidateConsts.StatusMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), SystemValidateConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), SystemValidateConsts.NoteMaxLength);

            var systemValidate = new SystemValidate(
             GuidGenerator.Create(),
             param, dateOpen, dateA, dateD, sort, status, extendedInformation, note
             );

            return await _systemValidateRepository.InsertAsync(systemValidate);
        }

        public async Task<SystemValidate> UpdateAsync(
            Guid id,
            string param, DateTime dateOpen, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null
        )
        {
            Check.NotNullOrWhiteSpace(param, nameof(param));
            Check.Length(param, nameof(param), SystemValidateConsts.ParamMaxLength);
            Check.NotNull(dateOpen, nameof(dateOpen));
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), SystemValidateConsts.StatusMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), SystemValidateConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), SystemValidateConsts.NoteMaxLength);

            var systemValidate = await _systemValidateRepository.GetAsync(id);

            systemValidate.Param = param;
            systemValidate.DateOpen = dateOpen;
            systemValidate.DateA = dateA;
            systemValidate.DateD = dateD;
            systemValidate.Sort = sort;
            systemValidate.Status = status;
            systemValidate.ExtendedInformation = extendedInformation;
            systemValidate.Note = note;

            return await _systemValidateRepository.UpdateAsync(systemValidate);
        }

    }
}