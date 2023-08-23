using Resume.App.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.App
{
    public class TestDto
    {
        public string Id { get; set; }
        public string? Name { get; set; }
    }

    public class ResultDto<T>
    {
        /// <summary>
        /// 此次呼叫 API 是否成功
        /// </summary>
        public bool Status { get; set; } = true;
        /// <summary>
        /// 此次呼叫 API 驗証是否通過
        /// </summary>
        public bool Check { get; set; } = false;
        /// <summary>
        /// 此次呼叫 API 修改儲存是否完成
        /// </summary>
        public bool Save { get; set; } = false;
        /// <summary>
        /// 呼叫 API 提示訊息
        /// </summary>
        public List<ResultMessageDto> Messages { get; set; } = new List<ResultMessageDto>();
        /// <summary>
        /// 例外訊息
        /// </summary>
        public string StackTrace { get; set; } = "";
        /// <summary>
        /// 版本
        /// </summary>
        public string Version { get; set; } = "";
        /// <summary>
        /// <summary>
        /// 呼叫此API所得到的其他內容
        /// </summary>
        public Object Payload { get; set; } = null;
        /// <summary>
        /// 呼叫此API所得到的主要內容
        /// </summary>
        public T Data { get; set; }
    }

    public class ResultDto
    {
        /// <summary>
        /// 此次呼叫 API 是否成功
        /// </summary>
        public bool Status { get; set; } = true;
        /// <summary>
        /// 此次呼叫 API 驗証是否通過
        /// </summary>
        public bool Check { get; set; } = false;
        /// <summary>
        /// 此次呼叫 API 修改儲存是否完成
        /// </summary>
        public bool Save { get; set; } = false;
        /// <summary>
        /// 呼叫 API 提示訊息
        /// </summary>
        public List<ResultMessageDto> Messages { get; set; } = new List<ResultMessageDto>();
   
    }

    public class Result1Dto
    {
        /// <summary>
        /// 此次呼叫 API 是否成功
        /// </summary>
        public bool Status { get; set; } = true;
        /// <summary>
        /// 此次呼叫 API 驗証是否通過
        /// </summary>
        public bool Check { get; set; } = false;
        /// <summary>
        /// 此次呼叫 API 修改儲存是否完成
        /// </summary>
        public bool Save { get; set; } = false;
        /// <summary>
        /// 呼叫 API 提示訊息
        /// </summary>
        public List<ResultMessageDto> Messages { get; set; } = new List<ResultMessageDto>();

    }

    public class ResultMessageDto
    {
        /// <summary>
        /// 呼叫 API 提示訊息代碼
        /// </summary>
        public string MessageCode { get; set; } = "400";
        /// <summary>
        /// 呼叫 API 提示訊息內容
        /// </summary>
        public string MessageContents { get; set; } = "";
        /// <summary>
        /// 系統內容Exception
        /// </summary>
       // public Exception SystemContents { set; get; }
        /// <summary>
        /// 是否可通過
        /// </summary>
        public bool Pass { set; get; } = true;
    }

    /// <summary>
    /// TextValueRow
    /// </summary>
    public class TextValueDto
    {
        /// <summary>
        /// Text
        /// </summary>
        public string Text { set; get; }
        /// <summary>
        /// Value
        /// </summary>
        public string Value { set; get; }
        /// <summary>
        /// 類別判斷用
        /// </summary>
        public string Category { set; get; }
        /// <summary>
        /// Description
        /// </summary>
        public string Note { set; get; }
        /// <summary>
        /// 欄位1
        /// </summary>
        public string Column1 { set; get; }
        /// <summary>
        /// 欄位2
        /// </summary>
        public string Column2 { set; get; }
        /// <summary>
        /// 欄位3
        /// </summary>
        public string Column3 { set; get; }
        /// <summary>
        /// 順序
        /// </summary>
        public int Sort { set; get; }
    }

    public class NameCodeStandardDto
    {
        /// <summary>
        /// Name
        /// </summary>
        public string GroupCode { set; get; } = "";
        /// <summary>
        /// Name
        /// </summary>
        public string Name { set; get; } = "";
        /// <summary>
        /// Code
        /// </summary>
        public string Code { set; get; } = "";
        public string ParentCode { set; get; } = "";
    }

    public class NameIdStandardDto
    {
        /// <summary>
        /// Name
        /// </summary>
        public Guid GroupId { set; get; } 
        /// <summary>
        /// Name
        /// </summary>
        public string Name { set; get; } = "";
        /// <summary>
        /// Code
        /// </summary>
        public Guid Id { set; get; } 
        public string ParentCode { set; get; } = "";
    }

    /// <summary>
    /// NameCodeRow
    /// </summary>
    public class NameCodeDto : NameCodeStandardDto
    {
        /// <summary>
        /// Column1
        /// </summary>
        public string Column1 { set; get; } = "";
        /// <summary>
        /// Count
        /// </summary>
        public int Count { set; get; } = 0;
        public int Sort { set; get; } = 0;
    }

    /// <summary>
    /// KeyValueRow
    /// </summary>
    public class KeyValueDto
    {
        /// <summary>
        /// Key
        /// </summary>
        public string Key { set; get; }
        /// <summary>
        /// Value
        /// </summary>
        public string Value { set; get; }
    }

    /// <summary>
    /// 檔案
    /// </summary>
    public class UploadFileDto
    {
        /// <summary>
        /// 檔案名稱
        /// </summary>
        public string UploadName { get; set; }
        /// <summary>
        /// 伺服器檔案名稱
        /// </summary>
        public string ServerName { get; set; }
        /// <summary>
        /// 二進位
        /// </summary>
        public string Blob { get; set; }
        /// <summary>
        /// 型態
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 大小
        /// </summary>
        public int Size { get; set; }
    }

    public enum SendType
    {
        Mail,
        Gsm,
        All,
        None,
    }

    public class DeleteDto
    {
        public bool Pass { set; get; } = false;
    }

    public class RegisterDto : LoginDto
    {
        public Guid UserMainId { get; set; }
    }

    public class LoginInfoDto
    {
        public Guid TenantId { get; set; }
        public string TenantName { get; set; }
        public Guid UserId { get; set; }
        public string LoginId { get; set; } = "";
        public string PasswordEncrypt { get; set; } = "";
    }

    public class LoginDto
    {
        //public string Token { get; set; } = "";

        public Id4TokenDto Id4Token { get; set; }
        public List<string> Roles { get; set; } = new List<string>();
        public List<string> Orgs { get; set; } = new List<string>();
        public string Message { get; set; } = "";

        public string ThirdPartyTypeCode { get; set; }
        public ThirdPartyUserDataDto UserData { get; set; }
    }
}