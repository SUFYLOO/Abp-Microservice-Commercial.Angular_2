using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Resume.ShareTags
{
    public class ShareTagManager : DomainService
    {
        private readonly IShareTagRepository _shareTagRepository;

        public ShareTagManager(IShareTagRepository shareTagRepository)
        {
            _shareTagRepository = shareTagRepository;
        }

        public async Task<ShareTag> CreateAsync(
        string colorCode, string key1, string key2, string key3, string name, string tagCategoryCode, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {
            Check.NotNullOrWhiteSpace(colorCode, nameof(colorCode));
            Check.Length(colorCode, nameof(colorCode), ShareTagConsts.ColorCodeMaxLength);
            Check.NotNullOrWhiteSpace(key1, nameof(key1));
            Check.Length(key1, nameof(key1), ShareTagConsts.Key1MaxLength);
            Check.NotNullOrWhiteSpace(key2, nameof(key2));
            Check.Length(key2, nameof(key2), ShareTagConsts.Key2MaxLength);
            Check.NotNullOrWhiteSpace(key3, nameof(key3));
            Check.Length(key3, nameof(key3), ShareTagConsts.Key3MaxLength);
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), ShareTagConsts.NameMaxLength);
            Check.NotNullOrWhiteSpace(tagCategoryCode, nameof(tagCategoryCode));
            Check.Length(tagCategoryCode, nameof(tagCategoryCode), ShareTagConsts.TagCategoryCodeMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ShareTagConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ShareTagConsts.NoteMaxLength);
            Check.Length(status, nameof(status), ShareTagConsts.StatusMaxLength);

            var shareTag = new ShareTag(
             GuidGenerator.Create(),
             colorCode, key1, key2, key3, name, tagCategoryCode, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _shareTagRepository.InsertAsync(shareTag);
        }

        public async Task<ShareTag> UpdateAsync(
            Guid id,
            string colorCode, string key1, string key2, string key3, string name, string tagCategoryCode, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null
        )
        {
            Check.NotNullOrWhiteSpace(colorCode, nameof(colorCode));
            Check.Length(colorCode, nameof(colorCode), ShareTagConsts.ColorCodeMaxLength);
            Check.NotNullOrWhiteSpace(key1, nameof(key1));
            Check.Length(key1, nameof(key1), ShareTagConsts.Key1MaxLength);
            Check.NotNullOrWhiteSpace(key2, nameof(key2));
            Check.Length(key2, nameof(key2), ShareTagConsts.Key2MaxLength);
            Check.NotNullOrWhiteSpace(key3, nameof(key3));
            Check.Length(key3, nameof(key3), ShareTagConsts.Key3MaxLength);
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), ShareTagConsts.NameMaxLength);
            Check.NotNullOrWhiteSpace(tagCategoryCode, nameof(tagCategoryCode));
            Check.Length(tagCategoryCode, nameof(tagCategoryCode), ShareTagConsts.TagCategoryCodeMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ShareTagConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ShareTagConsts.NoteMaxLength);
            Check.Length(status, nameof(status), ShareTagConsts.StatusMaxLength);

            var shareTag = await _shareTagRepository.GetAsync(id);

            shareTag.ColorCode = colorCode;
            shareTag.Key1 = key1;
            shareTag.Key2 = key2;
            shareTag.Key3 = key3;
            shareTag.Name = name;
            shareTag.TagCategoryCode = tagCategoryCode;
            shareTag.ExtendedInformation = extendedInformation;
            shareTag.DateA = dateA;
            shareTag.DateD = dateD;
            shareTag.Sort = sort;
            shareTag.Note = note;
            shareTag.Status = status;

            return await _shareTagRepository.UpdateAsync(shareTag);
        }

    }
}