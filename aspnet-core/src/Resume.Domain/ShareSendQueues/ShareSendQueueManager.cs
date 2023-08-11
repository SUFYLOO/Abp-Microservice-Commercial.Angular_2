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
        string key1, string key2, string key3, string sendTypeCode, string fromAddr, string toAddr, string titleContents, string contents, int retry, bool sucess, bool suspend, DateTime dateSend, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null)
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
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), ShareSendQueueConsts.StatusMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ShareSendQueueConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ShareSendQueueConsts.NoteMaxLength);

            var shareSendQueue = new ShareSendQueue(
             GuidGenerator.Create(),
             key1, key2, key3, sendTypeCode, fromAddr, toAddr, titleContents, contents, retry, sucess, suspend, dateSend, dateA, dateD, sort, status, extendedInformation, note
             );

            return await _shareSendQueueRepository.InsertAsync(shareSendQueue);
        }

        public async Task<ShareSendQueue> UpdateAsync(
            Guid id,
            string key1, string key2, string key3, string sendTypeCode, string fromAddr, string toAddr, string titleContents, string contents, int retry, bool sucess, bool suspend, DateTime dateSend, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null
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
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), ShareSendQueueConsts.StatusMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ShareSendQueueConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ShareSendQueueConsts.NoteMaxLength);

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
            shareSendQueue.DateA = dateA;
            shareSendQueue.DateD = dateD;
            shareSendQueue.Sort = sort;
            shareSendQueue.Status = status;
            shareSendQueue.ExtendedInformation = extendedInformation;
            shareSendQueue.Note = note;

            return await _shareSendQueueRepository.UpdateAsync(shareSendQueue);
        }

    }
}