using System;

namespace Resume.ShareSendQueues;

[Serializable]
public class ShareSendQueueExcelDownloadTokenCacheItem
{
    public string Token { get; set; }
}