using System;
using System.Collections.Generic;
using System.Text;

namespace Resume.Permissions
{
    public class CustomPermission
    {
        public string key { get; set; }
        /// <summary>
        /// 翻譯key
        /// </summary>
        public string value { get; set; }
        public string parent { get; set; }
    }
}
