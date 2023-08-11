using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Resume.ShareDictionarys
{
    public class ShareDictionaryManager : DomainService
    {
        private readonly IShareDictionaryRepository _shareDictionaryRepository;

        public ShareDictionaryManager(IShareDictionaryRepository shareDictionaryRepository)
        {
            _shareDictionaryRepository = shareDictionaryRepository;
        }

        public async Task<ShareDictionary> CreateAsync(
        Guid shareLanguageId, Guid shareTagId, string key1, string key2, string key3, string name, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null)
        {
            Check.Length(key1, nameof(key1), ShareDictionaryConsts.Key1MaxLength);
            Check.Length(key2, nameof(key2), ShareDictionaryConsts.Key2MaxLength);
            Check.Length(key3, nameof(key3), ShareDictionaryConsts.Key3MaxLength);
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), ShareDictionaryConsts.NameMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), ShareDictionaryConsts.StatusMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ShareDictionaryConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ShareDictionaryConsts.NoteMaxLength);

            var shareDictionary = new ShareDictionary(
             GuidGenerator.Create(),
             shareLanguageId, shareTagId, key1, key2, key3, name, dateA, dateD, sort, status, extendedInformation, note
             );

            return await _shareDictionaryRepository.InsertAsync(shareDictionary);
        }

        public async Task<ShareDictionary> UpdateAsync(
            Guid id,
            Guid shareLanguageId, Guid shareTagId, string key1, string key2, string key3, string name, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null
        )
        {
            Check.Length(key1, nameof(key1), ShareDictionaryConsts.Key1MaxLength);
            Check.Length(key2, nameof(key2), ShareDictionaryConsts.Key2MaxLength);
            Check.Length(key3, nameof(key3), ShareDictionaryConsts.Key3MaxLength);
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), ShareDictionaryConsts.NameMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), ShareDictionaryConsts.StatusMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ShareDictionaryConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ShareDictionaryConsts.NoteMaxLength);

            var shareDictionary = await _shareDictionaryRepository.GetAsync(id);

            shareDictionary.ShareLanguageId = shareLanguageId;
            shareDictionary.ShareTagId = shareTagId;
            shareDictionary.Key1 = key1;
            shareDictionary.Key2 = key2;
            shareDictionary.Key3 = key3;
            shareDictionary.Name = name;
            shareDictionary.DateA = dateA;
            shareDictionary.DateD = dateD;
            shareDictionary.Sort = sort;
            shareDictionary.Status = status;
            shareDictionary.ExtendedInformation = extendedInformation;
            shareDictionary.Note = note;

            return await _shareDictionaryRepository.UpdateAsync(shareDictionary);
        }

    }
}