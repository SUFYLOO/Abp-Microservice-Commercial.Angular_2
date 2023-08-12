using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbpLanguageTranslatorTools
{
    class MsgBoxHelper
    {
        public static DialogResult Confirm(string msg)
        {
            return MessageBox.Show(msg,
                "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }

        public static void Done()
        {
            MessageBox.Show("已執行完成",
                "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Done(string msg)
        {
            MessageBox.Show(msg,
                "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Warning(string msg)
        {
            MessageBox.Show(msg,
                "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void Error(string msg)
        {
            MessageBox.Show(msg,
                "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
