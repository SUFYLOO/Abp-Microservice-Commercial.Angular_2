using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Resume.ResumeCommunications
{
    public class ResumeCommunicationManager : DomainService
    {
        private readonly IResumeCommunicationRepository _resumeCommunicationRepository;

        public ResumeCommunicationManager(IResumeCommunicationRepository resumeCommunicationRepository)
        {
            _resumeCommunicationRepository = resumeCommunicationRepository;
        }

        public async Task<ResumeCommunication> CreateAsync(
        Guid resumeMainId, string communicationCategoryCode, string communicationValue, bool main, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {
            Check.NotNullOrWhiteSpace(communicationCategoryCode, nameof(communicationCategoryCode));
            Check.Length(communicationCategoryCode, nameof(communicationCategoryCode), ResumeCommunicationConsts.CommunicationCategoryCodeMaxLength);
            Check.NotNullOrWhiteSpace(communicationValue, nameof(communicationValue));
            Check.Length(communicationValue, nameof(communicationValue), ResumeCommunicationConsts.CommunicationValueMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeCommunicationConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ResumeCommunicationConsts.NoteMaxLength);
            Check.Length(status, nameof(status), ResumeCommunicationConsts.StatusMaxLength);

            var resumeCommunication = new ResumeCommunication(
             GuidGenerator.Create(),
             resumeMainId, communicationCategoryCode, communicationValue, main, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _resumeCommunicationRepository.InsertAsync(resumeCommunication);
        }

        public async Task<ResumeCommunication> UpdateAsync(
            Guid id,
            Guid resumeMainId, string communicationCategoryCode, string communicationValue, bool main, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null
        )
        {
            Check.NotNullOrWhiteSpace(communicationCategoryCode, nameof(communicationCategoryCode));
            Check.Length(communicationCategoryCode, nameof(communicationCategoryCode), ResumeCommunicationConsts.CommunicationCategoryCodeMaxLength);
            Check.NotNullOrWhiteSpace(communicationValue, nameof(communicationValue));
            Check.Length(communicationValue, nameof(communicationValue), ResumeCommunicationConsts.CommunicationValueMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeCommunicationConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ResumeCommunicationConsts.NoteMaxLength);
            Check.Length(status, nameof(status), ResumeCommunicationConsts.StatusMaxLength);

            var resumeCommunication = await _resumeCommunicationRepository.GetAsync(id);

            resumeCommunication.ResumeMainId = resumeMainId;
            resumeCommunication.CommunicationCategoryCode = communicationCategoryCode;
            resumeCommunication.CommunicationValue = communicationValue;
            resumeCommunication.Main = main;
            resumeCommunication.ExtendedInformation = extendedInformation;
            resumeCommunication.DateA = dateA;
            resumeCommunication.DateD = dateD;
            resumeCommunication.Sort = sort;
            resumeCommunication.Note = note;
            resumeCommunication.Status = status;

            return await _resumeCommunicationRepository.UpdateAsync(resumeCommunication);
        }

    }
}