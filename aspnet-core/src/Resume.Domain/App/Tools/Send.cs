using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Resume.App.Tools
{
    public static class Send
    {
        public static class Mail
        {
            private delegate bool AsyncMethodCaller(string Host, int Port, string CredentialsType, MailAddress Sender, bool IsNeedCredentials, bool IsNeedSsl, int Priority, string UserId, string Password, MailAddress ToMail, string Subject, string Body, out int ThreadId);

            /// <summary>
            /// 傳送信件射後不理
            /// </summary>
            /// <param name="Host">郵件伺服器IP或Name</param>
            /// <param name="Sender">寄件者Mail</param>
            /// <param name="IsNeedCredentials">True = 要驗証</param>
            /// <param name="UserId">寄件者帳號(若是需要驗証,則就需要輸入寄件者帳號)</param>
            /// <param name="Password">寄件者密碼(若是需要驗証,則就需要輸入寄件者密碼)</param>
            /// <param name="ToMail">收件者Mail</param>
            /// <param name="Subject">主旨</param>
            /// <param name="Body">內文</param>
            public static bool SendThread(string Host, int Port, string CredentialsType, MailAddress Sender, bool IsNeedCredentials, bool IsNeedSsl, int Priority, string UserId, string Password, MailAddress ToMail, string Subject, string Body)
            {
                int ThreadId = 0;
                AsyncMethodCaller caller = new AsyncMethodCaller(Send);
                IAsyncResult result = caller.BeginInvoke(Host, Port, CredentialsType, Sender, IsNeedCredentials, IsNeedSsl, Priority, UserId, Password, ToMail, Subject, Body, out ThreadId, null, null);

                return true;
            }

            private static bool Send(string Host, int Port, string CredentialsType, MailAddress Sender, bool IsNeedCredentials, bool IsNeedSsl, int Priority, string UserId, string Password, MailAddress ToMail, string Subject, string Body, out int ThreadId)
            {
                ThreadId = 0;
                return Send(Host, Port, CredentialsType, Sender, IsNeedCredentials, IsNeedSsl, Priority, UserId, Password, ToMail, Subject, Body);
            }

            /// <summary>
            /// 傳送信件
            /// </summary>
            /// <param name="Host">郵件伺服器IP或Name</param>
            /// <param name="Sender">寄件者Mail</param>
            /// <param name="IsNeedCredentials">True = 要驗証</param>
            /// <param name="UserId">寄件者帳號(若是需要驗証,則就需要輸入寄件者帳號)</param>
            /// <param name="Password">寄件者密碼(若是需要驗証,則就需要輸入寄件者密碼)</param>
            /// <param name="ToMail">收件者Mail</param>
            /// <param name="Subject">主旨</param>
            /// <param name="Body">內文</param>
            public static bool Send(string Host, int Port, string CredentialsType, MailAddress Sender, bool IsNeedCredentials, bool IsNeedSsl, int Priority, string UserId, string Password, MailAddress ToMail, string Subject, string Body)
            {
                try
                {
                    using (MailMessage message =
                          new MailMessage(Sender, ToMail))
                    {
                        message.Subject = Subject;
                        message.Body = Body;
                        message.IsBodyHtml = true;
                        message.BodyEncoding = Encoding.UTF8;
                        message.SubjectEncoding = Encoding.UTF8;
                        message.Priority = (MailPriority)Priority;

                        SmtpClient mailClient = new SmtpClient(Host, Port);
                        mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                        mailClient.EnableSsl = IsNeedSsl;

                        mailClient.UseDefaultCredentials = true;
                        if (IsNeedCredentials)
                        {
                            mailClient.UseDefaultCredentials = false;
                            mailClient.Credentials = new NetworkCredential(UserId, Password);
                            //CredentialCache myCache = new CredentialCache();
                            //myCache.Add(Host, Port, CredentialsType, new NetworkCredential(UserId, Password));
                            //mailClient.Credentials = myCache;
                        }

                        mailClient.Send(message);

                        return true;
                    }
                }
                catch (Exception ex)
                {
                    string msg = ex.ToString();

                    return false;
                }
            }
        }
    }
}
