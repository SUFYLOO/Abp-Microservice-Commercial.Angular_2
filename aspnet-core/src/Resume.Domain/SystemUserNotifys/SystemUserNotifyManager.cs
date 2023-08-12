using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Resume.SystemUserNotifys
{
    public class SystemUserNotifyManager : DomainService
    {
        private readonly ISystemUserNotifyRepository _systemUserNotifyRepository;

        public SystemUserNotifyManager(ISystemUserNotifyRepository systemUserNotifyRepository)
        {
            _systemUserNotifyRepository = systemUserNotifyRepository;
        }

        public async Task<SystemUserNotify> CreateAsync(
        Guid userMainId, string keyId, string keyName, string notifyTypeCode, string appName, string appCode, string titleContents, string contents, bool isRead, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {
            Check.Length(keyId, nameof(keyId), SystemUserNotifyConsts.KeyIdMaxLength);
            Check.Length(keyName, nameof(keyName), SystemUserNotifyConsts.KeyNameMaxLength);
            Check.NotNullOrWhiteSpace(notifyTypeCode, nameof(notifyTypeCode));
            Check.Length(notifyTypeCode, nameof(notifyTypeCode), SystemUserNotifyConsts.NotifyTypeCodeMaxLength);
            Check.NotNullOrWhiteSpace(appName, nameof(appName));
            Check.Length(appName, nameof(appName), SystemUserNotifyConsts.AppNameMaxLength);
            Check.NotNullOrWhiteSpace(appCode, nameof(appCode));
            Check.Length(appCode, nameof(appCode), SystemUserNotifyConsts.AppCodeMaxLength);
            Check.NotNullOrWhiteSpace(titleContents, nameof(titleContents));
            Check.Length(titleContents, nameof(titleContents), SystemUserNotifyConsts.TitleContentsMaxLength);
            Check.NotNullOrWhiteSpace(contents, nameof(contents));
            Check.Length(contents, nameof(contents), SystemUserNotifyConsts.ContentsMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), SystemUserNotifyConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), SystemUserNotifyConsts.NoteMaxLength);
            Check.Length(status, nameof(status), SystemUserNotifyConsts.StatusMaxLength);

            var systemUserNotify = new SystemUserNotify(
             GuidGenerator.Create(),
             userMainId, keyId, keyName, notifyTypeCode, appName, appCode, titleContents, contents, isRead, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _systemUserNotifyRepository.InsertAsync(systemUserNotify);
        }

        public async Task<SystemUserNotify> UpdateAsync(
            Guid id,
            Guid userMainId, string keyId, string keyName, string notifyTypeCode, string appName, string appCode, string titleContents, string contents, bool isRead, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null
        )
        {
            Check.Length(keyId, nameof(keyId), SystemUserNotifyConsts.KeyIdMaxLength);
            Check.Length(keyName, nameof(keyName), SystemUserNotifyConsts.KeyNameMaxLength);
            Check.NotNullOrWhiteSpace(notifyTypeCode, nameof(notifyTypeCode));
            Check.Length(notifyTypeCode, nameof(notifyTypeCode), SystemUserNotifyConsts.NotifyTypeCodeMaxLength);
            Check.NotNullOrWhiteSpace(appName, nameof(appName));
            Check.Length(appName, nameof(appName), SystemUserNotifyConsts.AppNameMaxLength);
            Check.NotNullOrWhiteSpace(appCode, nameof(appCode));
            Check.Length(appCode, nameof(appCode), SystemUserNotifyConsts.AppCodeMaxLength);
            Check.NotNullOrWhiteSpace(titleContents, nameof(titleContents));
            Check.Length(titleContents, nameof(titleContents), SystemUserNotifyConsts.TitleContentsMaxLength);
            Check.NotNullOrWhiteSpace(contents, nameof(contents));
            Check.Length(contents, nameof(contents), SystemUserNotifyConsts.ContentsMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), SystemUserNotifyConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), SystemUserNotifyConsts.NoteMaxLength);
            Check.Length(status, nameof(status), SystemUserNotifyConsts.StatusMaxLength);

            var systemUserNotify = await _systemUserNotifyRepository.GetAsync(id);

            systemUserNotify.UserMainId = userMainId;
            systemUserNotify.KeyId = keyId;
            systemUserNotify.KeyName = keyName;
            systemUserNotify.NotifyTypeCode = notifyTypeCode;
            systemUserNotify.AppName = appName;
            systemUserNotify.AppCode = appCode;
            systemUserNotify.TitleContents = titleContents;
            systemUserNotify.Contents = contents;
            systemUserNotify.IsRead = isRead;
            systemUserNotify.ExtendedInformation = extendedInformation;
            systemUserNotify.DateA = dateA;
            systemUserNotify.DateD = dateD;
            systemUserNotify.Sort = sort;
            systemUserNotify.Note = note;
            systemUserNotify.Status = status;

            return await _systemUserNotifyRepository.UpdateAsync(systemUserNotify);
        }

    }
}