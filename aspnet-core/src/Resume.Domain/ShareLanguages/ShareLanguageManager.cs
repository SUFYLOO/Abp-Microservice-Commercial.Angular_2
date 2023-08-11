using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Resume.ShareLanguages
{
    public class ShareLanguageManager : DomainService
    {
        private readonly IShareLanguageRepository _shareLanguageRepository;

        public ShareLanguageManager(IShareLanguageRepository shareLanguageRepository)
        {
            _shareLanguageRepository = shareLanguageRepository;
        }

        public async Task<ShareLanguage> CreateAsync(
        string name, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), ShareLanguageConsts.NameMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), ShareLanguageConsts.StatusMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ShareLanguageConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ShareLanguageConsts.NoteMaxLength);

            var shareLanguage = new ShareLanguage(
             GuidGenerator.Create(),
             name, dateA, dateD, sort, status, extendedInformation, note
             );

            return await _shareLanguageRepository.InsertAsync(shareLanguage);
        }

        public async Task<ShareLanguage> UpdateAsync(
            Guid id,
            string name, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), ShareLanguageConsts.NameMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), ShareLanguageConsts.StatusMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ShareLanguageConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ShareLanguageConsts.NoteMaxLength);

            var shareLanguage = await _shareLanguageRepository.GetAsync(id);

            shareLanguage.Name = name;
            shareLanguage.DateA = dateA;
            shareLanguage.DateD = dateD;
            shareLanguage.Sort = sort;
            shareLanguage.Status = status;
            shareLanguage.ExtendedInformation = extendedInformation;
            shareLanguage.Note = note;

            return await _shareLanguageRepository.UpdateAsync(shareLanguage);
        }

    }
}