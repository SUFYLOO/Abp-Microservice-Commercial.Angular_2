using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Resume.ShareCodes
{
    public class ShareCodeManager : DomainService
    {
        private readonly IShareCodeRepository _shareCodeRepository;

        public ShareCodeManager(IShareCodeRepository shareCodeRepository)
        {
            _shareCodeRepository = shareCodeRepository;
        }

        public async Task<ShareCode> CreateAsync(
        string groupCode, string key1, string key2, string key3, string name, string column1, string column2, string column3, bool systemUse, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {
            Check.NotNullOrWhiteSpace(groupCode, nameof(groupCode));
            Check.Length(groupCode, nameof(groupCode), ShareCodeConsts.GroupCodeMaxLength);
            Check.NotNullOrWhiteSpace(key1, nameof(key1));
            Check.Length(key1, nameof(key1), ShareCodeConsts.Key1MaxLength);
            Check.NotNullOrWhiteSpace(key2, nameof(key2));
            Check.Length(key2, nameof(key2), ShareCodeConsts.Key2MaxLength);
            Check.NotNullOrWhiteSpace(key3, nameof(key3));
            Check.Length(key3, nameof(key3), ShareCodeConsts.Key3MaxLength);
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), ShareCodeConsts.NameMaxLength);
            Check.Length(column1, nameof(column1), ShareCodeConsts.Column1MaxLength);
            Check.Length(column2, nameof(column2), ShareCodeConsts.Column2MaxLength);
            Check.Length(column3, nameof(column3), ShareCodeConsts.Column3MaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ShareCodeConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ShareCodeConsts.NoteMaxLength);
            Check.Length(status, nameof(status), ShareCodeConsts.StatusMaxLength);

            var shareCode = new ShareCode(
             GuidGenerator.Create(),
             groupCode, key1, key2, key3, name, column1, column2, column3, systemUse, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _shareCodeRepository.InsertAsync(shareCode);
        }

        public async Task<ShareCode> UpdateAsync(
            Guid id,
            string groupCode, string key1, string key2, string key3, string name, string column1, string column2, string column3, bool systemUse, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null
        )
        {
            Check.NotNullOrWhiteSpace(groupCode, nameof(groupCode));
            Check.Length(groupCode, nameof(groupCode), ShareCodeConsts.GroupCodeMaxLength);
            Check.NotNullOrWhiteSpace(key1, nameof(key1));
            Check.Length(key1, nameof(key1), ShareCodeConsts.Key1MaxLength);
            Check.NotNullOrWhiteSpace(key2, nameof(key2));
            Check.Length(key2, nameof(key2), ShareCodeConsts.Key2MaxLength);
            Check.NotNullOrWhiteSpace(key3, nameof(key3));
            Check.Length(key3, nameof(key3), ShareCodeConsts.Key3MaxLength);
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), ShareCodeConsts.NameMaxLength);
            Check.Length(column1, nameof(column1), ShareCodeConsts.Column1MaxLength);
            Check.Length(column2, nameof(column2), ShareCodeConsts.Column2MaxLength);
            Check.Length(column3, nameof(column3), ShareCodeConsts.Column3MaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ShareCodeConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ShareCodeConsts.NoteMaxLength);
            Check.Length(status, nameof(status), ShareCodeConsts.StatusMaxLength);

            var shareCode = await _shareCodeRepository.GetAsync(id);

            shareCode.GroupCode = groupCode;
            shareCode.Key1 = key1;
            shareCode.Key2 = key2;
            shareCode.Key3 = key3;
            shareCode.Name = name;
            shareCode.Column1 = column1;
            shareCode.Column2 = column2;
            shareCode.Column3 = column3;
            shareCode.SystemUse = systemUse;
            shareCode.ExtendedInformation = extendedInformation;
            shareCode.DateA = dateA;
            shareCode.DateD = dateD;
            shareCode.Sort = sort;
            shareCode.Note = note;
            shareCode.Status = status;

            return await _shareCodeRepository.UpdateAsync(shareCode);
        }

    }
}