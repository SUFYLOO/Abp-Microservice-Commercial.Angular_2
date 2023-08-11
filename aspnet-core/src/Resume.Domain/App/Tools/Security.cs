using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Resume.App.Tools
{
    public static class Security
    {
        private static byte[] key = { 0x21, 0x43, 0x65, 0x87, 0x09, 0xBA, 0xDC, 0xFE };
        private static byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

        /// <summary>
        /// 加密處理
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public static string Encrypt(string Input)
        {
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                Byte[] inputByteArray = Encoding.UTF8.GetBytes(Input);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 解密處理
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public static string Decrypt(string Input)
        {
            if (!string.IsNullOrEmpty(Input))
            {
                Input = Input.Replace(" ", "+");
                Byte[] inputByteArray = new Byte[Input.Length];
                try
                {
                    DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                    inputByteArray = Convert.FromBase64String(Input);
                    MemoryStream ms = new MemoryStream();
                    CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    Encoding encoding = Encoding.UTF8;
                    return encoding.GetString(ms.ToArray());
                }
                catch
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// ToMD5
        /// </summary>
        /// <param name="Str"></param>
        /// <returns>string</returns>
        public static string ToMD5(this string Str)
        {
            MD5 md5 = MD5.Create();//建立一個MD5
            byte[] source = Encoding.Default.GetBytes(Str);//將字串轉為Byte[]
            byte[] crypto = md5.ComputeHash(source);//進行MD5加密
            string result = Convert.ToBase64String(crypto);//把加密後的字串從Byte[]轉為字串

            return result;
        }

        /// <summary>
        /// ToSHA1
        /// </summary>
        /// <param name="Str"></param>
        /// <returns>string</returns>
        public static string ToSHA1(this string Str)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();//建立一個SHA1
            byte[] source = Encoding.Default.GetBytes(Str);//將字串轉為Byte[]
            byte[] crypto = sha1.ComputeHash(source);//進行SHA1加密
            string result = Convert.ToBase64String(crypto);//把加密後的字串從Byte[]轉為字串

            return result;
        }

        /// <summary>
        /// ToSHA256
        /// </summary>
        /// <param name="Str"></param>
        /// <returns>string</returns>
        public static string ToSHA256(this string Str)
        {
            SHA256 sha256 = new SHA256CryptoServiceProvider();//建立一個SHA256
            byte[] source = Encoding.Default.GetBytes(Str);//將字串轉為Byte[]
            byte[] crypto = sha256.ComputeHash(source);//進行SHA256加密
            string result = Convert.ToBase64String(crypto);//把加密後的字串從Byte[]轉為字串

            return result;
        }

        /// <summary>
        /// ToSHA384
        /// </summary>
        /// <param name="Str"></param>
        /// <returns>string</returns>
        public static string ToSHA384(this string Str)
        {
            SHA384 sha384 = new SHA384CryptoServiceProvider();//建立一個SHA384
            byte[] source = Encoding.Default.GetBytes(Str);//將字串轉為Byte[]
            byte[] crypto = sha384.ComputeHash(source);//進行SHA384加密
            string result = Convert.ToBase64String(crypto);//把加密後的字串從Byte[]轉為字串

            return result;
        }

        /// <summary>
        /// ToSHA512
        /// </summary>
        /// <param name="Str"></param>
        /// <returns>string</returns>
        public static string ToSHA512(this string Str)
        {
            SHA512 sha512 = new SHA512CryptoServiceProvider();//建立一個SHA512
            byte[] source = Encoding.Default.GetBytes(Str);//將字串轉為Byte[]
            byte[] crypto = sha512.ComputeHash(source);//進行SHA512加密
            string result = Convert.ToBase64String(crypto);//把加密後的字串從Byte[]轉為字串

            return result;
        }

        /// <summary>
        /// 驗証是否有使用權限
        /// </summary>
        /// <param name="ValidKey">可通行權限</param>
        /// <param name="UserRoleKey">登入帳號權限</param>
        /// <returns>bool</returns>
        public static bool IsRoleValid(int ValidKey, int UserRoleKey)
        {
            return ((ValidKey & UserRoleKey) == UserRoleKey);
        }

        /// <summary>
        /// 驗証是否有使用權限
        /// </summary>
        /// <param name="ValidKey">可通行權限(10進位)</param>
        /// <param name="UserRoleKeys">帳號所擁有的角色(2進位集合)</param>
        /// <returns></returns>
        public static bool IsRoleValid(int ValidKey, List<int> UserRoleKeys)
        {
            foreach (int UserRoleKey in UserRoleKeys)
                if (IsRoleValid(ValidKey, UserRoleKey))
                    return true;

            return false;
        }

        /// <summary>
        /// 將角色轉成2進位所擁有的權限
        /// </summary>
        /// <param name="RoleKey">角色代碼的總和</param>
        /// <returns>List int</returns>
        public static List<int> GetRoleKeyToBinaryKey(int RoleKey)
        {
            // 這邊都一樣, 用Convert轉成0, 1字串: 5 -> 101
            string bString = Convert.ToString(RoleKey, 2);
            // 用Linq
            var Vdb = bString.Reverse().Select((c, i) => (c - '0') * (1 << i)).Where(c => c > 0).ToList();

            return Vdb;
        }

        /// <summary>以亂數生成新密碼</summary>
        /// <returns>回傳認證碼</returns>
        public static string CreateNewPassword(int PasswordLength = 10 , string RuleChars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ")
        {
            // 使用 RNGCryptoServiceProvider 產生由密碼編譯服務供應者 (CSP) 提供的亂數產生器
            RNGCryptoServiceProvider RNGPService = new RNGCryptoServiceProvider();
            // 用來存放隨機序列值
            byte[] RandomByte = new byte[4];
            // 用來存放隨機亂數值
            char[] Chars = RuleChars.ToCharArray();
            // 用來存放生成的亂數密碼
            StringBuilder Str = new StringBuilder();
            // 初始密碼長度
            //int PasswordLength = 10;
            // 用來存放位元陣列轉換後的結果
            int Value = 0;
            // 開始生成密碼
            for (int Index = 0; Index < PasswordLength; Index++)
            {
                // 取得隨機編譯的亂數值
                RNGPService.GetBytes(RandomByte);
                // 用來存放位元陣列轉換後的結果
                Value = BitConverter.ToInt32(RandomByte, 0);
                // 產生一個非負數且最大值為隨機亂數值長度以下的亂數
                Value = Value % (Chars.Length - 1 + 1);
                if (Value < 0) Value = -Value;
                // 印出亂數
                Str.Append(Chars[Value]);
            }

            return Str.ToString();
        }
    }
    public class EncryptHepler
    {
        // 驗值 
        static string saltValue = "84211021";
        // 密碼值 
        static public string pwdValue = @"J---B";

        /// <summary>
        /// 加密
        /// </summary>
        public string Encrypt(string input)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(input);
            byte[] salt = UTF8Encoding.UTF8.GetBytes(saltValue);

            // AesManaged - 高級加密標準(AES) 對稱算法的管理類 
            AesManaged aes = new AesManaged();
            // Rfc2898DeriveBytes - 通過使用基於 HMACSHA1 的偽隨機數生成器，實現基於密碼的密鑰派生功能 (PBKDF2 - 一種基於密碼的密鑰派生函數) 
            // 通過 密碼 和 salt 派生密鑰 
            Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(pwdValue, salt);

            aes.BlockSize = aes.LegalBlockSizes[0].MaxSize;
            aes.KeySize = aes.LegalKeySizes[0].MaxSize;
            aes.Key = rfc.GetBytes(aes.KeySize / 8);
            aes.IV = rfc.GetBytes(aes.BlockSize / 8);

            // 用當前的 Key 屬性和初始化向量 IV 創建對稱加密器對象 
            ICryptoTransform encryptTransform = aes.CreateEncryptor();
            // 加密後的輸出流 
            MemoryStream encryptStream = new MemoryStream();
            // 將加密後的目標流（encryptStream）與加密轉換（encryptTransform）相連接 
            CryptoStream encryptor = new CryptoStream
                (encryptStream, encryptTransform, CryptoStreamMode.Write);

            // 將一個字節序列寫入當前 CryptoStream （完成加密的過程）
            encryptor.Write(data, 0, data.Length);
            encryptor.Close();
            // 將加密後所得到的流轉換成字節數組，再用Base64編碼將其轉換為字符串 
            string encryptedString = Convert.ToBase64String(encryptStream.ToArray());
            return encryptedString;
        }
        /// <summary>
        /// 解密
        /// </summary>
        public string Decrypt(string input)
        {
            byte[] encryptBytes = Convert.FromBase64String(input);
            byte[] salt = Encoding.UTF8.GetBytes(saltValue);
            AesManaged aes = new AesManaged();
            Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(pwdValue, salt);

            aes.BlockSize = aes.LegalBlockSizes[0].MaxSize;
            aes.KeySize = aes.LegalKeySizes[0].MaxSize;
            aes.Key = rfc.GetBytes(aes.KeySize / 8);
            aes.IV = rfc.GetBytes(aes.BlockSize / 8);

            // 用當前的 Key 屬性和初始化向量 IV 創建對稱解密器對象 
            ICryptoTransform decryptTransform = aes.CreateDecryptor();
            // 解密後的輸出流 
            MemoryStream decryptStream = new MemoryStream();

            // 將解密後的目標流（decryptStream）與解密轉換（decryptTransform）相連接 
            CryptoStream decryptor = new CryptoStream(
                decryptStream, decryptTransform, CryptoStreamMode.Write);
            // 將一個字節序列寫入當前 CryptoStream （完成解密的過程） 
            decryptor.Write(encryptBytes, 0, encryptBytes.Length);
            decryptor.Close();

            // 將解密後所得到的流轉換為字符串 
            byte[] decryptBytes = decryptStream.ToArray();
            string decryptedString = UTF8Encoding.UTF8.GetString(decryptBytes, 0, decryptBytes.Length);
            return decryptedString;
        }
    }//class end
}