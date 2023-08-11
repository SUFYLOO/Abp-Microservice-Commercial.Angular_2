using Resume.ShareUploads;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Content;

namespace Resume.App.Shares
{
    /// <summary>
    /// �t�Φ@�ΰѼ�
    /// </summary>
    public class ShareDefaultSystemDto
    {
        /// <summary>
        /// ���@
        /// </summary>
        public bool Maintain { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public bool Test { get; set; }
        /// <summary>
        /// ��ƾB�n
        /// </summary>
        public bool DataMask { get; set; }
        /// <summary>
        /// �U�αb��
        /// </summary>
        public string UniversalAccountCode { get; set; }
        /// <summary>
        /// �U�αK�X
        /// </summary>
        public string UniversalAccountPassword { get; set; }
        /// <summary>
        /// �t�κ޲z�̫H�c
        /// </summary>
        public List<string> AdminMail { get; set; }
        /// <summary>
        /// ���իH�c
        /// </summary>
        public List<string> TestMail { get; set; }
        /// <summary>
        /// ���ձb��
        /// </summary>
        public string TestAccountCode { get; set; }
        /// <summary>
        /// ���}���������
        /// </summary>
        public int UrlValidMinutes { get; set; }
        /// <summary>
        /// ��ƼȦs
        /// </summary>
        public bool DataCache { get; set; }
        /// <summary>
        /// �Y�ɶǰe
        /// </summary>
        public bool InstantSend { get; set; }
    }

    public class ShareDefaultUrlDto
    {
        /// <summary>
        /// ��ݵn�J
        /// </summary>
        public string LoginFrontEnd { get; set; }
        /// <summary>
        /// �e�ݵn�J
        /// </summary>
        public string LoginBackEnd { get; set; }
        /// <summary>
        /// ��ݥD��
        /// </summary>
        public string MainBackEnd { get; set; }
        /// <summary>
        /// �e�ݥD��
        /// </summary>
        public string MainFrontEnd { get; set; }
        /// <summary>
        /// �L�v���ɦV
        /// </summary>
        public string NoPermission { get; set; }
        /// <summary>
        /// �����q��
        /// </summary>
        public string NotifyAdmission { get; set; }
        /// <summary>
        /// ���ճq��
        /// </summary>
        public string NotifyInterview { get; set; }
        /// <summary>
        /// �J¾�q��
        /// </summary>
        public string NotifyOnboard { get; set; }
        /// <summary>
        /// �ѰO�K�X
        /// </summary>
        public string PasswordForget { get; set; }
        /// <summary>
        /// ���m�K�X
        /// </summary>
        public string PasswordReset { get; set; }
        /// <summary>
        /// ���~
        /// </summary>
        public string Error { get; set; }
    }

    /// <summary>
    /// �l��
    /// </summary>
    public class ShareDefaultMailDto
    {
        /// <summary>
        /// �l��D������m
        /// </summary>
        public string Host { get; set; }
        /// <summary>
        /// Port
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// �b��
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// �K�X
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public bool IsNeedCredentials { get; set; }
        /// <summary>
        /// ����Ssl
        /// </summary>
        public bool IsNeedSsl { get; set; }
        /// <summary>
        /// �H���
        /// </summary>
        public string Sender { get; set; }
        /// <summary>
        /// �H��̦W��
        /// </summary>
        public string SenderName { get; set; }
        /// <summary>
        /// �ҥδ��ռҦ�
        /// </summary>
        public bool EnableTestMode { get; set; }
        /// <summary>
        /// ���իH�c
        /// </summary>
        public List<string> TestMail { get; set; }
        /// <summary>
        /// ����o�H
        /// </summary>
        public bool DisableSend { get; set; }
        /// <summary>
        /// �u���v
        /// </summary>
        public int Priority { get; set; }
        /// <summary>
        /// �ǿ�Ҧ�
        /// </summary>
        public string CredentialsType { get; set; }
        /// <summary>
        /// �̤j���զ���
        /// </summary>
        public int MaxRetry { get; set; }
        /// <summary>
        /// ���թ���(min)
        /// </summary>
        public int Delay { get; set; }
        /// <summary>
        /// �D��
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// ���e���Y
        /// </summary>
        public string BodyHead { get; set; }
        /// <summary>
        /// ���e
        /// </summary>
        public string BodyContent { get; set; }
        /// <summary>
        /// ���e����
        /// </summary>
        public string BodyFoot { get; set; }
    }

    /// <summary>
    /// GSM
    /// </summary>
    public class ShareDefaultGsmDto
    {
        /// <summary>
        /// �l��D������m
        /// </summary>
        public string Host { get; set; }
        /// <summary>
        /// Port
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// �b��
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// �K�X
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public bool IsNeedCredentials { get; set; }
        /// <summary>
        /// ����Ssl
        /// </summary>
        public bool IsNeedSsl { get; set; }
        /// <summary>
        /// �H���
        /// </summary>
        public string Sender { get; set; }
        /// <summary>
        /// �H��̦W��
        /// </summary>
        public string SenderName { get; set; }
        /// <summary>
        /// �ҥδ��ռҦ�
        /// </summary>
        public bool EnableTestMode { get; set; }
        /// <summary>
        /// ���իH�c
        /// </summary>
        public List<string> TestGsm { get; set; }
        /// <summary>
        /// ����o�H
        /// </summary>
        public bool DisableSend { get; set; }
        /// <summary>
        /// �u���v
        /// </summary>
        public int Priority { get; set; }
        /// <summary>
        /// �ǿ�Ҧ�
        /// </summary>
        public string CredentialsType { get; set; }
        /// <summary>
        /// �̤j���զ���
        /// </summary>
        public int MaxRetry { get; set; }
        /// <summary>
        /// ���թ���(min)
        /// </summary>
        public int Delay { get; set; }
        /// <summary>
        /// �D��
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// ���e���Y
        /// </summary>
        public string BodyHead { get; set; }
        /// <summary>
        /// ���e
        /// </summary>
        public string BodyContent { get; set; }
        /// <summary>
        /// ���e����
        /// </summary>
        public string BodyFoot { get; set; }
    }

    /// <summary>
    /// OAuth2�Ѽ�
    /// </summary>
    public class ShareDefaultOAuth2Dto
    {
        /// <summary>
        /// �v���d��
        /// </summary>
        public string Scope { get; set; }
        /// <summary>
        /// �������{�Һ���
        /// </summary>
        public string RedirectUrl { get; set; }
        /// <summary>
        /// �������j�w����
        /// </summary>
        public string BindUrl { get; set; }
        /// <summary>
        /// OAuth2�b��
        /// </summary>
        public string ClientId { get; set; }
        /// <summary>
        /// OAuth2�K�X
        /// </summary>
        public string ClientSecret { get; set; }
        /// <summary>
        /// ���oToken����
        /// </summary>
        public string TokenUrl { get; set; }
        /// <summary>
        /// ���oUserInfo����
        /// </summary>
        public string UserInfoUrl { get; set; }
        /// <summary>
        /// ���o�{�ҵn�J����
        /// </summary>
        public string AuthUrl { get; set; }
    }

    /// <summary>
    /// Oidc�Ѽ�
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
    /// OAuth2Google�Ѽ�
    /// </summary>
    public class ShareDefaultOAuth2GoogleDto : ShareDefaultOAuth2Dto
    {

    }

    /// <summary>
    /// OAuth2Facebook�Ѽ�
    /// </summary>
    public class ShareDefaultOAuth2FacebookDto : ShareDefaultOAuth2Dto
    {

    }

    /// <summary>
    /// OAuth2Line�Ѽ�
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