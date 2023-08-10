using Resume.ShareUploads;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Content;

namespace Resume.App.Shares
{
    /// <summary>
    /// 系統共用參數
    /// </summary>
    public class ShareDefaultSystemDto
    {
        /// <summary>
        /// 維護
        /// </summary>
        public bool Maintain { get; set; }
        /// <summary>
        /// 測試
        /// </summary>
        public bool Test { get; set; }
        /// <summary>
        /// 資料遮罩
        /// </summary>
        public bool DataMask { get; set; }
        /// <summary>
        /// 萬用帳號
        /// </summary>
        public string UniversalAccountCode { get; set; }
        /// <summary>
        /// 萬用密碼
        /// </summary>
        public string UniversalAccountPassword { get; set; }
        /// <summary>
        /// 系統管理者信箱
        /// </summary>
        public List<string> AdminMail { get; set; }
        /// <summary>
        /// 測試信箱
        /// </summary>
        public List<string> TestMail { get; set; }
        /// <summary>
        /// 測試帳號
        /// </summary>
        public string TestAccountCode { get; set; }
        /// <summary>
        /// 網址驗証分鐘數
        /// </summary>
        public int UrlValidMinutes { get; set; }
        /// <summary>
        /// 資料暫存
        /// </summary>
        public bool DataCache { get; set; }
        /// <summary>
        /// 即時傳送
        /// </summary>
        public bool InstantSend { get; set; }
    }

    public class ShareDefaultUrlDto
    {
        /// <summary>
        /// 後端登入
        /// </summary>
        public string LoginFrontEnd { get; set; }
        /// <summary>
        /// 前端登入
        /// </summary>
        public string LoginBackEnd { get; set; }
        /// <summary>
        /// 後端主頁
        /// </summary>
        public string MainBackEnd { get; set; }
        /// <summary>
        /// 前端主頁
        /// </summary>
        public string MainFrontEnd { get; set; }
        /// <summary>
        /// 無權限導向
        /// </summary>
        public string NoPermission { get; set; }
        /// <summary>
        /// 錄取通知
        /// </summary>
        public string NotifyAdmission { get; set; }
        /// <summary>
        /// 面試通知
        /// </summary>
        public string NotifyInterview { get; set; }
        /// <summary>
        /// 入職通知
        /// </summary>
        public string NotifyOnboard { get; set; }
        /// <summary>
        /// 忘記密碼
        /// </summary>
        public string PasswordForget { get; set; }
        /// <summary>
        /// 重置密碼
        /// </summary>
        public string PasswordReset { get; set; }
        /// <summary>
        /// 錯誤
        /// </summary>
        public string Error { get; set; }
    }

    /// <summary>
    /// 郵件
    /// </summary>
    public class ShareDefaultMailDto
    {
        /// <summary>
        /// 郵件主機的位置
        /// </summary>
        public string Host { get; set; }
        /// <summary>
        /// Port
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// 帳號
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 密碼
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 驗證
        /// </summary>
        public bool IsNeedCredentials { get; set; }
        /// <summary>
        /// 驗證Ssl
        /// </summary>
        public bool IsNeedSsl { get; set; }
        /// <summary>
        /// 寄件者
        /// </summary>
        public string Sender { get; set; }
        /// <summary>
        /// 寄件者名稱
        /// </summary>
        public string SenderName { get; set; }
        /// <summary>
        /// 啟用測試模式
        /// </summary>
        public bool EnableTestMode { get; set; }
        /// <summary>
        /// 測試信箱
        /// </summary>
        public List<string> TestMail { get; set; }
        /// <summary>
        /// 停止發信
        /// </summary>
        public bool DisableSend { get; set; }
        /// <summary>
        /// 優先權
        /// </summary>
        public int Priority { get; set; }
        /// <summary>
        /// 傳輸模式
        /// </summary>
        public string CredentialsType { get; set; }
        /// <summary>
        /// 最大重試次數
        /// </summary>
        public int MaxRetry { get; set; }
        /// <summary>
        /// 重試延遲(min)
        /// </summary>
        public int Delay { get; set; }
        /// <summary>
        /// 主旨
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// 內容標頭
        /// </summary>
        public string BodyHead { get; set; }
        /// <summary>
        /// 內容
        /// </summary>
        public string BodyContent { get; set; }
        /// <summary>
        /// 內容結尾
        /// </summary>
        public string BodyFoot { get; set; }
    }

    /// <summary>
    /// GSM
    /// </summary>
    public class ShareDefaultGsmDto
    {
        /// <summary>
        /// 郵件主機的位置
        /// </summary>
        public string Host { get; set; }
        /// <summary>
        /// Port
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// 帳號
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 密碼
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 驗證
        /// </summary>
        public bool IsNeedCredentials { get; set; }
        /// <summary>
        /// 驗證Ssl
        /// </summary>
        public bool IsNeedSsl { get; set; }
        /// <summary>
        /// 寄件者
        /// </summary>
        public string Sender { get; set; }
        /// <summary>
        /// 寄件者名稱
        /// </summary>
        public string SenderName { get; set; }
        /// <summary>
        /// 啟用測試模式
        /// </summary>
        public bool EnableTestMode { get; set; }
        /// <summary>
        /// 測試信箱
        /// </summary>
        public List<string> TestGsm { get; set; }
        /// <summary>
        /// 停止發信
        /// </summary>
        public bool DisableSend { get; set; }
        /// <summary>
        /// 優先權
        /// </summary>
        public int Priority { get; set; }
        /// <summary>
        /// 傳輸模式
        /// </summary>
        public string CredentialsType { get; set; }
        /// <summary>
        /// 最大重試次數
        /// </summary>
        public int MaxRetry { get; set; }
        /// <summary>
        /// 重試延遲(min)
        /// </summary>
        public int Delay { get; set; }
        /// <summary>
        /// 主旨
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// 內容標頭
        /// </summary>
        public string BodyHead { get; set; }
        /// <summary>
        /// 內容
        /// </summary>
        public string BodyContent { get; set; }
        /// <summary>
        /// 內容結尾
        /// </summary>
        public string BodyFoot { get; set; }
    }

    /// <summary>
    /// OAuth2參數
    /// </summary>
    public class ShareDefaultOAuth2Dto
    {
        /// <summary>
        /// 權限範圍
        /// </summary>
        public string Scope { get; set; }
        /// <summary>
        /// 本網站認證網頁
        /// </summary>
        public string RedirectUrl { get; set; }
        /// <summary>
        /// 本網站綁定網頁
        /// </summary>
        public string BindUrl { get; set; }
        /// <summary>
        /// OAuth2帳號
        /// </summary>
        public string ClientId { get; set; }
        /// <summary>
        /// OAuth2密碼
        /// </summary>
        public string ClientSecret { get; set; }
        /// <summary>
        /// 取得Token網頁
        /// </summary>
        public string TokenUrl { get; set; }
        /// <summary>
        /// 取得UserInfo網頁
        /// </summary>
        public string UserInfoUrl { get; set; }
        /// <summary>
        /// 取得認證登入網頁
        /// </summary>
        public string AuthUrl { get; set; }
    }

    /// <summary>
    /// Oidc參數
    /// </summary>
    public class ShareDefaultOidcDto
    {
        public string Uri { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Scope { get; set; }
        public string GrantType { get; set; }
    }

    /// <summary>
    /// OAuth2Google參數
    /// </summary>
    public class ShareDefaultOAuth2GoogleDto : ShareDefaultOAuth2Dto
    {

    }

    /// <summary>
    /// OAuth2Facebook參數
    /// </summary>
    public class ShareDefaultOAuth2FacebookDto : ShareDefaultOAuth2Dto
    {

    }

    /// <summary>
    /// OAuth2Line參數
    /// </summary>
    public class ShareDefaultOAuth2LineDto : ShareDefaultOAuth2Dto
    {

    }

    public class SendShareSendQueueDto
    {
        public bool Pass { get; set; } = false;
    }

    public class ShareCodeByGroupCodeDto
    {
        public string Code { get; set; } = "";
        public string Name { get; set; } = "";
        public bool disabled { get; set; } = false;
        public bool isLeaf { get; set; } = false;
        public List<ShareCodeByGroupCodeDto> children { get; set; } = new List<ShareCodeByGroupCodeDto>();
    }

    public class SetShareCodeDto
    {
        public bool Pass { get; set; } = false;
    }

    public class SaveShareUploadDto : ShareUploadDto
    {
        public bool Pass { get; set; } = false;
    }

    public class ShareUploadsDto : ShareUploadDto
    {
        public Guid FileDescriptorId { get; set; }
    }

    public class DownloadShareUploadDto
    {
        public IRemoteStreamContent RemoteStreamContent { get; set; }
        public string FileName { get; set; }
    }
}