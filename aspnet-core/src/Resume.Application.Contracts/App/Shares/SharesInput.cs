using Volo.Abp.Application.Dtos;
using System;
using System.Collections.Generic;
using Resume.App.Users;
using Resume.ShareUploads;
using Volo.FileManagement.Files;

namespace Resume.App.Shares
{
    public class ShareInput
    {
        public string Key1 { get; set; } = "";
        public string Key2 { get; set; } = "";
        public string Key3 { get; set; } = "";
        public Guid Id { get; set; } 
        public bool Display { get; set; } = true;
        public bool AllForGroupCode { get; set; } = false;
    }

    public class ShareDefaultInput : ShareInput
    {
        public string GroupCode { get; set; } 
    }

    public class ShareDefaultSystemInput : ShareInput
    {
    }

    public class ShareDefaultUrlInput : ShareInput
    {
    }

    public class ShareDefaultMailInput : ShareInput
    {
    }

    public class ShareDefaultGsmInput : ShareInput
    {
    }

    public class ShareDefaultOAuth2Input : ShareInput
    {
        public string GroupCode { get; set; }
    }

    public class ShareDefaultOAuth2GoogleInput : ShareInput
    {
    }

    public class ShareDefaultOidcInput : ShareInput
    {
    }

    public class ShareDefaultOAuth2FacebookInput : ShareInput
    {
    }

    public class ShareDefaultOAuth2LineInput : ShareInput
    {
    }

    public class ShareCodeInput : ShareInput
    {
        public string GroupCode { get; set; }
        public List<string> ListGroupCode { get; set; } = new List<string>();
    }

    public class ShareCodeGroupInput : ShareInput
    {
        public string GroupCode { get; set; }
        public List<string> ListGroupCode { get; set; } = new List<string>();
    }

    public class ShareCodeByGroupCodeInput : ShareInput
    {
        public string GroupCode { get; set; }
    }

    //public class CheckShareCodeInput : ShareInput
    //{
    //    public string GroupCode { get; set; }
    //    public List<string> ListKey3 { get; set; } = new List<string>();
    //}

    public class CheckShareCode
    {
        public bool AllowNull { get; set; } = true;
        public string GroupCode { get; set; } = "";
        public string? Code { get; set; } 
        public string MessageCode { get; set; } = "400";
        public string MessageContents { get; set; } = "";
        public bool Pass { get; set; } = false;
    }

    public class CheckShareCodeInput
    {
        public ResultDto Result { get; set; } = new ResultDto();
        public object? Data { get; set; }
        public List<CheckShareCode>? ListCheckShareCode { get; set; } 
        public bool? DynamicSearch { get; set; }
    }

    public class SendShareSendQueueInput : ShareInput
    {
        public int RowIndex { get; set; } = 0;
        public bool Where { get; set; } = false;
        public bool InstantSend { get; set; } = false;
        public Dictionary<string, Guid> dcParameterSql { get; set; } = new Dictionary<string, Guid>();
        public Dictionary<string, string> dcParameter { get; set; } = new Dictionary<string, string>();
        public List<string> ListToMail { get; set; } = new List<string>();
        public List<string> ListToGsm { get; set; } = new List<string>();
        public SendType SendTypeCode { get; set; } = SendType.Mail;
    }

    public class SetShareCodeInput : ShareInput
    {
        public List<NameCodeStandardDto> ListShareCode { get; set; }
        public List<NameCodeStandardDto> ListColumns { get; set; }
        public object Data { get; set; }
    }

    public class SetShareCodeName
    {
        public string GroupCode { get; set; } = "";
        public string Code { get; set; } = "";
        public string Name { get; set; } = "";
    }

    public class SetShareCodeNameInput 
    {
        public object Result { get; set; }
        public List<SetShareCodeName>? ListSetShareCodeName { get; set; }
        public bool? DynamicSearch { get; set; }
    }

    public class ShareUploadInput : ShareInput
    {
        /// <summary>
        /// 是否要取得檔案
        /// </summary>
        public bool GetFileContent { get; set; }
    }

    public class SaveShareUploadInput : ShareUploadDto
    {
        /// <summary>
        /// 二進位存放資料庫
        /// </summary>
        public CreateFileInputWithStream inputWithStream { get; set; }
        public string Name { get; set; }

    }

    public class ShareUploadListInput : ShareUploadDto
    {


    }

    public class DownloadShareUploadInput
    {
        public Guid FileDescriptorId { get; set; }

    }
}