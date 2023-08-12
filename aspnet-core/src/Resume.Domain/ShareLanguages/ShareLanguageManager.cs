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
        string name, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), ShareLanguageConsts.NameMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ShareLanguageConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ShareLanguageConsts.NoteMaxLength);
            Check.Length(status, nameof(status), ShareLanguageConsts.StatusMaxLength);

            var shareLanguage = new ShareLanguage(
             GuidGenerator.Create(),
             name, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _shareLanguageRepository.InsertAsync(shareLanguage);
        }

        public async Task<ShareLanguage> UpdateAsync(
            Guid id,
            string name, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), ShareLanguageConsts.NameMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ShareLanguageConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ShareLanguageConsts.NoteMaxLength);
            Check.Length(status, nameof(status), ShareLanguageConsts.StatusMaxLength);

            var shareLanguage = await _shareLanguageRepository.GetAsync(id);

            shareLanguage.Name = name;
            shareLanguage.ExtendedInformation = extendedInformation;
            shareLanguage.DateA = dateA;
            shareLanguage.DateD = dateD;
            shareLanguage.Sort = sort;
            shareLanguage.Note = note;
            shareLanguage.Status = status;

            return await _shareLanguageRepository.UpdateAsync(shareLanguage);
        }

    }
}