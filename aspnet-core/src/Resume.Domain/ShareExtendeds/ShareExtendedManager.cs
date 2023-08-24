using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Resume.ShareExtendeds
{
    public class ShareExtendedManager : DomainService
    {
        private readonly IShareExtendedRepository _shareExtendedRepository;

        public ShareExtendedManager(IShareExtendedRepository shareExtendedRepository)
        {
            _shareExtendedRepository = shareExtendedRepository;
        }

        public async Task<ShareExtended> CreateAsync(
        string key1, string key2, string key3, string key4, string key5, string fieldValue, Guid? keyId = null, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {
            Check.Length(key1, nameof(key1), ShareExtendedConsts.Key1MaxLength);
            Check.Length(key2, nameof(key2), ShareExtendedConsts.Key2MaxLength);
            Check.Length(key3, nameof(key3), ShareExtendedConsts.Key3MaxLength);
            Check.Length(key4, nameof(key4), ShareExtendedConsts.Key4MaxLength);
            Check.Length(key5, nameof(key5), ShareExtendedConsts.Key5MaxLength);
            Check.Length(fieldValue, nameof(fieldValue), ShareExtendedConsts.FieldValueMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ShareExtendedConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ShareExtendedConsts.NoteMaxLength);
            Check.Length(status, nameof(status), ShareExtendedConsts.StatusMaxLength);

            var shareExtended = new ShareExtended(
             GuidGenerator.Create(),
             key1, key2, key3, key4, key5, fieldValue, keyId, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _shareExtendedRepository.InsertAsync(shareExtended);
        }

        public async Task<ShareExtended> UpdateAsync(
            Guid id,
            string key1, string key2, string key3, string key4, string key5, string fieldValue, Guid? keyId = null, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null
        )
        {
            Check.Length(key1, nameof(key1), ShareExtendedConsts.Key1MaxLength);
            Check.Length(key2, nameof(key2), ShareExtendedConsts.Key2MaxLength);
            Check.Length(key3, nameof(key3), ShareExtendedConsts.Key3MaxLength);
            Check.Length(key4, nameof(key4), ShareExtendedConsts.Key4MaxLength);
            Check.Length(key5, nameof(key5), ShareExtendedConsts.Key5MaxLength);
            Check.Length(fieldValue, nameof(fieldValue), ShareExtendedConsts.FieldValueMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ShareExtendedConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ShareExtendedConsts.NoteMaxLength);
            Check.Length(status, nameof(status), ShareExtendedConsts.StatusMaxLength);

            var shareExtended = await _shareExtendedRepository.GetAsync(id);

            shareExtended.Key1 = key1;
            shareExtended.Key2 = key2;
            shareExtended.Key3 = key3;
            shareExtended.Key4 = key4;
            shareExtended.Key5 = key5;
            shareExtended.FieldValue = fieldValue;
            shareExtended.KeyId = keyId;
            shareExtended.ExtendedInformation = extendedInformation;
            shareExtended.DateA = dateA;
            shareExtended.DateD = dateD;
            shareExtended.Sort = sort;
            shareExtended.Note = note;
            shareExtended.Status = status;

            return await _shareExtendedRepository.UpdateAsync(shareExtended);
        }

    }
}