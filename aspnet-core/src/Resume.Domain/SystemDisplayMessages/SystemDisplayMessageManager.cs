using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Resume.SystemDisplayMessages
{
    public class SystemDisplayMessageManager : DomainService
    {
        private readonly ISystemDisplayMessageRepository _systemDisplayMessageRepository;

        public SystemDisplayMessageManager(ISystemDisplayMessageRepository systemDisplayMessageRepository)
        {
            _systemDisplayMessageRepository = systemDisplayMessageRepository;
        }

        public async Task<SystemDisplayMessage> CreateAsync(
        string displayTypeCode, string titleContents, string contents, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null)
        {
            Check.NotNullOrWhiteSpace(displayTypeCode, nameof(displayTypeCode));
            Check.Length(displayTypeCode, nameof(displayTypeCode), SystemDisplayMessageConsts.DisplayTypeCodeMaxLength);
            Check.NotNullOrWhiteSpace(titleContents, nameof(titleContents));
            Check.Length(titleContents, nameof(titleContents), SystemDisplayMessageConsts.TitleContentsMaxLength);
            Check.NotNullOrWhiteSpace(contents, nameof(contents));
            Check.Length(contents, nameof(contents), SystemDisplayMessageConsts.ContentsMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), SystemDisplayMessageConsts.StatusMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), SystemDisplayMessageConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), SystemDisplayMessageConsts.NoteMaxLength);

            var systemDisplayMessage = new SystemDisplayMessage(
             GuidGenerator.Create(),
             displayTypeCode, titleContents, contents, dateA, dateD, sort, status, extendedInformation, note
             );

            return await _systemDisplayMessageRepository.InsertAsync(systemDisplayMessage);
        }

        public async Task<SystemDisplayMessage> UpdateAsync(
            Guid id,
            string displayTypeCode, string titleContents, string contents, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null
        )
        {
            Check.NotNullOrWhiteSpace(displayTypeCode, nameof(displayTypeCode));
            Check.Length(displayTypeCode, nameof(displayTypeCode), SystemDisplayMessageConsts.DisplayTypeCodeMaxLength);
            Check.NotNullOrWhiteSpace(titleContents, nameof(titleContents));
            Check.Length(titleContents, nameof(titleContents), SystemDisplayMessageConsts.TitleContentsMaxLength);
            Check.NotNullOrWhiteSpace(contents, nameof(contents));
            Check.Length(contents, nameof(contents), SystemDisplayMessageConsts.ContentsMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), SystemDisplayMessageConsts.StatusMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), SystemDisplayMessageConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), SystemDisplayMessageConsts.NoteMaxLength);

            var systemDisplayMessage = await _systemDisplayMessageRepository.GetAsync(id);

            systemDisplayMessage.DisplayTypeCode = displayTypeCode;
            systemDisplayMessage.TitleContents = titleContents;
            systemDisplayMessage.Contents = contents;
            systemDisplayMessage.DateA = dateA;
            systemDisplayMessage.DateD = dateD;
            systemDisplayMessage.Sort = sort;
            systemDisplayMessage.Status = status;
            systemDisplayMessage.ExtendedInformation = extendedInformation;
            systemDisplayMessage.Note = note;

            return await _systemDisplayMessageRepository.UpdateAsync(systemDisplayMessage);
        }

    }
}