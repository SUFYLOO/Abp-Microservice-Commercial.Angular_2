using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Resume.ShareSendQueues
{
    public class ShareSendQueueManager : DomainService
    {
        private readonly IShareSendQueueRepository _shareSendQueueRepository;

        public ShareSendQueueManager(IShareSendQueueRepository shareSendQueueRepository)
        {
            _shareSendQueueRepository = shareSendQueueRepository;
        }

        public async Task<ShareSendQueue> CreateAsync(
        string key1, string key2, string key3, string sendTypeCode, string fromAddr, string toAddr, string titleContents, string contents, int retry, bool sucess, bool suspend, DateTime dateSend, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {
            Check.NotNullOrWhiteSpace(key1, nameof(key1));
            Check.Length(key1, nameof(key1), ShareSendQueueConsts.Key1MaxLength);
            Check.NotNullOrWhiteSpace(key2, nameof(key2));
            Check.Length(key2, nameof(key2), ShareSendQueueConsts.Key2MaxLength);
            Check.NotNullOrWhiteSpace(key3, nameof(key3));
            Check.Length(key3, nameof(key3), ShareSendQueueConsts.Key3MaxLength);
            Check.NotNullOrWhiteSpace(sendTypeCode, nameof(sendTypeCode));
            Check.Length(sendTypeCode, nameof(sendTypeCode), ShareSendQueueConsts.SendTypeCodeMaxLength);
            Check.Length(fromAddr, nameof(fromAddr), ShareSendQueueConsts.FromAddrMaxLength);
            Check.NotNullOrWhiteSpace(toAddr, nameof(toAddr));
            Check.Length(toAddr, nameof(toAddr), ShareSendQueueConsts.ToAddrMaxLength);
            Check.Length(titleContents, nameof(titleContents), ShareSendQueueConsts.TitleContentsMaxLength);
            Check.NotNullOrWhiteSpace(contents, nameof(contents));
            Check.NotNull(dateSend, nameof(dateSend));
            Check.Length(extendedInformation, nameof(extendedInformation), ShareSendQueueConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ShareSendQueueConsts.NoteMaxLength);
            Check.Length(status, nameof(status), ShareSendQueueConsts.StatusMaxLength);

            var shareSendQueue = new ShareSendQueue(
             GuidGenerator.Create(),
             key1, key2, key3, sendTypeCode, fromAddr, toAddr, titleContents, contents, retry, sucess, suspend, dateSend, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _shareSendQueueRepository.InsertAsync(shareSendQueue);
        }

        public async Task<ShareSendQueue> UpdateAsync(
            Guid id,
            string key1, string key2, string key3, string sendTypeCode, string fromAddr, string toAddr, string titleContents, string contents, int retry, bool sucess, bool suspend, DateTime dateSend, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null
        )
        {
            Check.NotNullOrWhiteSpace(key1, nameof(key1));
            Check.Length(key1, nameof(key1), ShareSendQueueConsts.Key1MaxLength);
            Check.NotNullOrWhiteSpace(key2, nameof(key2));
            Check.Length(key2, nameof(key2), ShareSendQueueConsts.Key2MaxLength);
            Check.NotNullOrWhiteSpace(key3, nameof(key3));
            Check.Length(key3, nameof(key3), ShareSendQueueConsts.Key3MaxLength);
            Check.NotNullOrWhiteSpace(sendTypeCode, nameof(sendTypeCode));
            Check.Length(sendTypeCode, nameof(sendTypeCode), ShareSendQueueConsts.SendTypeCodeMaxLength);
            Check.Length(fromAddr, nameof(fromAddr), ShareSendQueueConsts.FromAddrMaxLength);
            Check.NotNullOrWhiteSpace(toAddr, nameof(toAddr));
            Check.Length(toAddr, nameof(toAddr), ShareSendQueueConsts.ToAddrMaxLength);
            Check.Length(titleContents, nameof(titleContents), ShareSendQueueConsts.TitleContentsMaxLength);
            Check.NotNullOrWhiteSpace(contents, nameof(contents));
            Check.NotNull(dateSend, nameof(dateSend));
            Check.Length(extendedInformation, nameof(extendedInformation), ShareSendQueueConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ShareSendQueueConsts.NoteMaxLength);
            Check.Length(status, nameof(status), ShareSendQueueConsts.StatusMaxLength);

            var shareSendQueue = await _shareSendQueueRepository.GetAsync(id);

            shareSendQueue.Key1 = key1;
            shareSendQueue.Key2 = key2;
            shareSendQueue.Key3 = key3;
            shareSendQueue.SendTypeCode = sendTypeCode;
            shareSendQueue.FromAddr = fromAddr;
            shareSendQueue.ToAddr = toAddr;
            shareSendQueue.TitleContents = titleContents;
            shareSendQueue.Contents = contents;
            shareSendQueue.Retry = retry;
            shareSendQueue.Sucess = sucess;
            shareSendQueue.Suspend = suspend;
            shareSendQueue.DateSend = dateSend;
            shareSendQueue.ExtendedInformation = extendedInformation;
            shareSendQueue.DateA = dateA;
            shareSendQueue.DateD = dateD;
            shareSendQueue.Sort = sort;
            shareSendQueue.Note = note;
            shareSendQueue.Status = status;

            return await _shareSendQueueRepository.UpdateAsync(shareSendQueue);
        }

    }
}