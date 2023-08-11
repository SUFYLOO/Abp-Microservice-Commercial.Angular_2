using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Resume.ShareMessageTpls
{
    public class ShareMessageTplManager : DomainService
    {
        private readonly IShareMessageTplRepository _shareMessageTplRepository;

        public ShareMessageTplManager(IShareMessageTplRepository shareMessageTplRepository)
        {
            _shareMessageTplRepository = shareMessageTplRepository;
        }

        public async Task<ShareMessageTpl> CreateAsync(
        string key1, string key2, string key3, string name, string statement, string titleContents, string contentMail, string contentSMS, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null)
        {
            Check.Length(key1, nameof(key1), ShareMessageTplConsts.Key1MaxLength);
            Check.Length(key2, nameof(key2), ShareMessageTplConsts.Key2MaxLength);
            Check.NotNullOrWhiteSpace(key3, nameof(key3));
            Check.Length(key3, nameof(key3), ShareMessageTplConsts.Key3MaxLength);
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), ShareMessageTplConsts.NameMaxLength);
            Check.Length(statement, nameof(statement), ShareMessageTplConsts.StatementMaxLength);
            Check.NotNullOrWhiteSpace(titleContents, nameof(titleContents));
            Check.Length(titleContents, nameof(titleContents), ShareMessageTplConsts.TitleContentsMaxLength);
            Check.Length(contentSMS, nameof(contentSMS), ShareMessageTplConsts.ContentSMSMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), ShareMessageTplConsts.StatusMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ShareMessageTplConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ShareMessageTplConsts.NoteMaxLength);

            var shareMessageTpl = new ShareMessageTpl(
             GuidGenerator.Create(),
             key1, key2, key3, name, statement, titleContents, contentMail, contentSMS, dateA, dateD, sort, status, extendedInformation, note
             );

            return await _shareMessageTplRepository.InsertAsync(shareMessageTpl);
        }

        public async Task<ShareMessageTpl> UpdateAsync(
            Guid id,
            string key1, string key2, string key3, string name, string statement, string titleContents, string contentMail, string contentSMS, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null
        )
        {
            Check.Length(key1, nameof(key1), ShareMessageTplConsts.Key1MaxLength);
            Check.Length(key2, nameof(key2), ShareMessageTplConsts.Key2MaxLength);
            Check.NotNullOrWhiteSpace(key3, nameof(key3));
            Check.Length(key3, nameof(key3), ShareMessageTplConsts.Key3MaxLength);
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), ShareMessageTplConsts.NameMaxLength);
            Check.Length(statement, nameof(statement), ShareMessageTplConsts.StatementMaxLength);
            Check.NotNullOrWhiteSpace(titleContents, nameof(titleContents));
            Check.Length(titleContents, nameof(titleContents), ShareMessageTplConsts.TitleContentsMaxLength);
            Check.Length(contentSMS, nameof(contentSMS), ShareMessageTplConsts.ContentSMSMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), ShareMessageTplConsts.StatusMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ShareMessageTplConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ShareMessageTplConsts.NoteMaxLength);

            var shareMessageTpl = await _shareMessageTplRepository.GetAsync(id);

            shareMessageTpl.Key1 = key1;
            shareMessageTpl.Key2 = key2;
            shareMessageTpl.Key3 = key3;
            shareMessageTpl.Name = name;
            shareMessageTpl.Statement = statement;
            shareMessageTpl.TitleContents = titleContents;
            shareMessageTpl.ContentMail = contentMail;
            shareMessageTpl.ContentSMS = contentSMS;
            shareMessageTpl.DateA = dateA;
            shareMessageTpl.DateD = dateD;
            shareMessageTpl.Sort = sort;
            shareMessageTpl.Status = status;
            shareMessageTpl.ExtendedInformation = extendedInformation;
            shareMessageTpl.Note = note;

            return await _shareMessageTplRepository.UpdateAsync(shareMessageTpl);
        }

    }
}