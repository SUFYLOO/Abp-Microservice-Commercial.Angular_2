using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Resume.ShareUploads
{
    public class ShareUploadManager : DomainService
    {
        private readonly IShareUploadRepository _shareUploadRepository;

        public ShareUploadManager(IShareUploadRepository shareUploadRepository)
        {
            _shareUploadRepository = shareUploadRepository;
        }

        public async Task<ShareUpload> CreateAsync(
        string key1, string key2, string key3, string uploadName, string serverName, string type, int size, bool systemUse, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {
            Check.Length(key1, nameof(key1), ShareUploadConsts.Key1MaxLength);
            Check.Length(key2, nameof(key2), ShareUploadConsts.Key2MaxLength);
            Check.Length(key3, nameof(key3), ShareUploadConsts.Key3MaxLength);
            Check.NotNullOrWhiteSpace(uploadName, nameof(uploadName));
            Check.Length(uploadName, nameof(uploadName), ShareUploadConsts.UploadNameMaxLength);
            Check.NotNullOrWhiteSpace(serverName, nameof(serverName));
            Check.Length(serverName, nameof(serverName), ShareUploadConsts.ServerNameMaxLength);
            Check.NotNullOrWhiteSpace(type, nameof(type));
            Check.Length(type, nameof(type), ShareUploadConsts.TypeMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ShareUploadConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ShareUploadConsts.NoteMaxLength);
            Check.Length(status, nameof(status), ShareUploadConsts.StatusMaxLength);

            var shareUpload = new ShareUpload(
             GuidGenerator.Create(),
             key1, key2, key3, uploadName, serverName, type, size, systemUse, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _shareUploadRepository.InsertAsync(shareUpload);
        }

        public async Task<ShareUpload> UpdateAsync(
            Guid id,
            string key1, string key2, string key3, string uploadName, string serverName, string type, int size, bool systemUse, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null
        )
        {
            Check.Length(key1, nameof(key1), ShareUploadConsts.Key1MaxLength);
            Check.Length(key2, nameof(key2), ShareUploadConsts.Key2MaxLength);
            Check.Length(key3, nameof(key3), ShareUploadConsts.Key3MaxLength);
            Check.NotNullOrWhiteSpace(uploadName, nameof(uploadName));
            Check.Length(uploadName, nameof(uploadName), ShareUploadConsts.UploadNameMaxLength);
            Check.NotNullOrWhiteSpace(serverName, nameof(serverName));
            Check.Length(serverName, nameof(serverName), ShareUploadConsts.ServerNameMaxLength);
            Check.NotNullOrWhiteSpace(type, nameof(type));
            Check.Length(type, nameof(type), ShareUploadConsts.TypeMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ShareUploadConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ShareUploadConsts.NoteMaxLength);
            Check.Length(status, nameof(status), ShareUploadConsts.StatusMaxLength);

            var shareUpload = await _shareUploadRepository.GetAsync(id);

            shareUpload.Key1 = key1;
            shareUpload.Key2 = key2;
            shareUpload.Key3 = key3;
            shareUpload.UploadName = uploadName;
            shareUpload.ServerName = serverName;
            shareUpload.Type = type;
            shareUpload.Size = size;
            shareUpload.SystemUse = systemUse;
            shareUpload.ExtendedInformation = extendedInformation;
            shareUpload.DateA = dateA;
            shareUpload.DateD = dateD;
            shareUpload.Sort = sort;
            shareUpload.Note = note;
            shareUpload.Status = status;

            return await _shareUploadRepository.UpdateAsync(shareUpload);
        }

    }
}