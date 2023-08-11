using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.App.Tools
{
    /// <summary>
    /// 
    /// </summary>
    public static class StringSplit
    {
        /// <summary>
        /// 將字串依照分割符號分割成陣列
        /// </summary>
        /// <param name="SplitString">準備分割字串</param>
        /// <param name="Separator">分割符號</param>
        /// <returns>string[]</returns>
        public static string[] SplitStringToArray(string SplitString, string Separator = ",>^<;")
        {
            SplitString = SplitString.NullToString();
            var ArraySeparator = Separator.Split(new string[] { @">^<" }, StringSplitOptions.RemoveEmptyEntries);// Regex.Split(Separator, @"][", RegexOptions.IgnoreCase);
            var Vdb = SplitString.Split(@ArraySeparator, StringSplitOptions.RemoveEmptyEntries);

            return Vdb;
        }

        /// <summary>
        /// 將字串依照分割符號分割成陣列，再依照數值得第N個陣列的內容
        /// </summary>
        /// <param name="SplitString">準備分割字串</param>
        /// <param name="Number">第N個</param>
        /// <param name="Separator">分割符號</param>
        /// <returns>string</returns>
        public static string SplitStringToArrayToValue(string SplitString, int Number = 1, string Separator = ",>^<;")
        {
            string Vdb = "";

            var ArraySplitString = SplitStringToArray(SplitString, @Separator);

            if (ArraySplitString.Length > Number - 1)
                Vdb = ArraySplitString[Number - 1];

            return Vdb;
        }
    }
}
