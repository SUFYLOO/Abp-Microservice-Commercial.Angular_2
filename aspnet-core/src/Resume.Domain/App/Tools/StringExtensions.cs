using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.App.Tools
{
    /// <summary>
    /// 字串延伸應用
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static string NullToString(this object Value)
        {
            // Value.ToString() allows for Value being DBNull, but will also convert int, double, etc.
            return Value == null ? "" : Value.ToString();

            // If this is not what you want then this form may suit you better, handles 'Null' and DBNull otherwise tries a straight cast
            // which will throw if Value isn't actually a string object.
            //return Value == null || Value == DBNull.Value ? "" : (string)Value;
        }
    }

    public static class UrlEncodDecode
    {
        /// <summary>
        /// 对字符进行UrlEncode编码
        /// string转Encoding格式
        /// </summary>
        /// <param name="text"></param>
        /// <param name="encod">编码格式</param>
        /// <param name="cap">是否输出大写字母</param>
        /// <returns></returns>
        public static string UrlEncode(string text, Encoding encod, bool cap = true)
        {
            if (cap)
            {
                StringBuilder builder = new StringBuilder();
                foreach (char c in text)
                {
                    if (System.Web.HttpUtility.UrlEncode(c.ToString(), encod).Length > 1)
                    {
                        builder.Append(System.Web.HttpUtility.UrlEncode(c.ToString(), encod).ToUpper());
                    }
                    else
                    {
                        builder.Append(c);
                    }
                }
                return builder.ToString();
            }
            else
            {
                string encodString = System.Web.HttpUtility.UrlEncode(text, encod);
                return encodString;
            }
        }

        /// <summary>
        /// 对字符进行UrlDecode解码
        /// Encoding转string格式
        /// </summary>
        /// <param name="encodString"></param>
        /// <param name="encod">编码格式</param>
        /// <returns></returns>
        public static string UrlDecode(string encodString, Encoding encod)
        {
            string text = System.Web.HttpUtility.UrlDecode(encodString, encod);
            return text;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public static class StringMaskDataExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="start"></param>
        /// <param name="maskLength"></param>
        /// <returns></returns>
        public static string Mask(this string source, int start, int maskLength)
        {
            return source.Mask(start, maskLength, '*');
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="start"></param>
        /// <param name="maskLength"></param>
        /// <param name="maskCharacter"></param>
        /// <returns></returns>
        public static string Mask(this string source, int start, int maskLength, char maskCharacter)
        {
            if (start > source.Length - 1)
            {
                throw new ArgumentException("Start position is greater than string length");
            }

            if (maskLength > source.Length)
            {
                throw new ArgumentException("Mask length is greater than string length");
            }

            if (start + maskLength > source.Length)
            {
                throw new ArgumentException("Start position and mask length imply more characters than are present");
            }

            string mask = new string(maskCharacter, maskLength);
            string unMaskStart = source.Substring(0, start);
            string unMaskEnd = source.Substring(start + maskLength);

            return unMaskStart + mask + unMaskEnd;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public static class IntegerMaskDataExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="start"></param>
        /// <param name="maskLength"></param>
        /// <returns></returns>
        public static string ToStringMask(this int source, int start, int maskLength)
        {
            return source.ToString().Mask(start, maskLength, 'X');
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="start"></param>
        /// <param name="maskLength"></param>
        /// <param name="maskCharacter"></param>
        /// <returns></returns>
        public static string ToStringMask(this int source, int start, int maskLength, char maskCharacter)
        {
            return source.ToString().Mask(start, maskLength, maskCharacter);
        }
    }
}
