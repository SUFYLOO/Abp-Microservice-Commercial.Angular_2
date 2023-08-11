using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Resume.App.Tools
{
    public class RecvDataModel
    {
        /**
 * SNS執行的結果代碼
 */
        protected byte code;
        /**
         * 手機上傳簡訊的編碼,利用此欄位輔助來呈現上傳簡訊內容
         */
        protected byte coding;
        /**
         * 手機上傳簡訊的長度
         */
        protected byte length;
        /**
         * 手機上傳簡訊的發送號碼
         */
        protected String sendMsisdn;
        protected String recvMsisdn;
        /**
         * SNS執行結果的說明,如果傳送簡訊執行成功,此欄位為簡訊查詢代碼
         */

        protected byte[] desc = null;

        public RecvDataModel()
        {
        }

        /**
         * 將SNS Server傳回的位元串流解析成SNS Protocol對映的欄位資料
         * @param data byte[] - SNS Server傳回的位元串流
         * @return RecvDataModel
         */
        public static RecvDataModel parse_v1(byte[] data)
        {
            RecvDataModel dm = new RecvDataModel();
            dm.setCode(data[0]);
            dm.setCoding(data[1]);
            dm.setLength(data[2]);
            dm.setSendMsisdn(System.Text.Encoding.UTF8.GetString(data).Substring(3, 13).Trim());
            dm.setRecvMsisdn(System.Text.Encoding.UTF8.GetString(data).Substring(16, 13).Trim());
            //dm.setSendMsisdn(new String(data, 3, 13).trim());
            //dm.setRecvMsisdn(new string(data, 16, 13).trim());

            byte[] buf = new byte[160];
            Array.Copy(data, 29, buf, 0, buf.Length);
            //System.arraycopy(data, 29, buf, 0, buf.length);
            dm.setDesc(buf);

            return dm;
        }
        /**
         * 將系統回傳碼放對映至code變數
         * @param code byte
         */
        public void setCode(byte code)
        {
            this.code = code;
        }
        /**
         * 將簡訊編碼格式對映至coding變數
         * @param coding byte
         */
        public void setCoding(byte coding)
        {
            this.coding = coding;
        }
        /**
         * 將發送簡訊的手機號碼對映至sendMsisdn變數
         * @param sendMsisdn String
         */
        public void setSendMsisdn(String sendMsisdn)
        {
            this.sendMsisdn = sendMsisdn;
        }
        /**
         * 將特碼對映至recvMsisdn變數
         * @param recvMsisdn String
         */
        public void setRecvMsisdn(String recvMsisdn)
        {
            this.recvMsisdn = recvMsisdn;
        }
        /**
         * 將簡訊長度對映至length變數
         * @param length byte
         */
        public void setLength(byte length)
        {
            this.length = length;
        }

        public void setDesc(byte[] desc)
        {
            this.desc = desc;
        }

        /**
         * 將系統回傳敘述對映至desc變數
         * @param desc String
         */

        /**
         * 傳回訊息結果代碼
         */
        public byte getCode()
        {
            return code;
        }

        public byte getCoding()
        {
            return coding;
        }

        public String getSendMsisdn()
        {
            return sendMsisdn;
        }

        public String getRecvMsisdn()
        {
            return recvMsisdn;
        }

        public byte getLength()
        {
            return length;
        }

        public byte[] getDesc()
        {
            return desc;
        }
    }
    public interface IConstants
    {
        /**
         * 發訊封包size
         */
        public static int SUBMIT_BUFFER_SIZE_V1 = 217;
        public static int SUBMIT_BUFFER_SIZE_V3 = 238;
        /**
         * 回傳封包size
         */
        public static int RECV_BUFFER_SIZE_V1 = 189;
        /**
         * 當Login時，將type設成SERV_LOGIN
         */
        public static byte SERV_LOGIN = 0;
        /**
         * 當要change password時，將type設為SERV_CHANGE_PASSWORD
         */
        public static byte SERV_CHANGE_PASSWORD = 1;
        /**
         * 當要傳送訊息時，將type設為SERV_SUBMIT_MSG
         */
        public static byte SERV_SUBMIT_MSG = 2;
        /**
         * 當要查詢簡訊傳送結果時，將type設為SERV_QUERY_STATE
         */
        public static byte SERV_QUERY_STATE = 3;
        /**
         * 當要接收簡訊時，將type設為SERV_GET_MSG
         */
        public static byte SERV_GET_MSG = 4;
        /**
         * 一般將簡訊編碼格式設成TEXT_CODING_VALUE
         */
        public static byte TEXT_CODING_VALUE = 1;
        /**
         * 預設簡訊傳送方式
         */
        public static byte DEFAULT_TRAN_TYPE = 100;
        /**
         * 每個封包的簡訊內容最大值
         */
        public static int MAX_MSG_SIZE = 160;
    }
    public class SubmitDataModel
    {
        /**
           * Sns Protocol命令代碼. 0->登入, 2->傳送簡訊, 3->查詢狀態
           */
        protected byte type;
        /**
         * 簡訊編碼方式.一般文字請設為1
         */
        protected byte coding;
        /**
         * 簡訊長度.以byte計算
         */
        protected byte length;
        /**
         * 訊息傳送方式.立即傳送為100, 預約傳送為101
         */
        protected byte tranType;
        /**
         * 登入帳號
         */
        protected String account;
        /**
         * 登入密碼
         */
        protected String password;
        /**
         * 接收簡訊的手機號碼, 09xxxxxxxx
         */
        protected String rcvMsisdn;
        /**
         * 訊息查詢代碼,運用在查詢簡訊傳送狀態
         */
        protected String messageID;
        /**
         *  簡訊傳送的預約時間,格式為yymmddhhmm00,如果是立即傳送,此欄位不用填
         */
        protected String dlvTime;
        /**
         * 簡訊內容
         */
        protected String message;
        protected byte[] byMsg;
        private Boolean isByMsg = false;

        private Boolean isSetPchid = false;
        protected byte pclid;
        protected byte[] pchid = new byte[9];

        private String m_strLastMessage = "";

        public SubmitDataModel()
        {
            reset();
        }

        /**
         * 傳回錯誤訊息
         */
        public String getLastMessage()
        {
            return m_strLastMessage;
        }

        /**
         * 重設欄位資料於初始值
         */
        public void reset()
        {
            type = (byte)0;
            coding = (byte)1;
            length = (byte)0;
            tranType = (byte)100;
            account = "";
            password = "";
            rcvMsisdn = "";
            messageID = "";
            dlvTime = "";
            message = "";

            isByMsg = false;
            isSetPchid = false;
            for (int i = 0; i < pchid.Length; i++)
            {
                pchid[i] = (byte)0;
            }
        }

        /**
         * 將物件轉成位元串流.如果轉換失敗,將會傳回null,呼叫getLastMessage()取得失敗原因
         * @return byte[] - 物件的位元串流
         */
        public byte[] toByteStream_V1()
        {
            // modified by yengopan, 2014/05/10, extending rcvMsisdn(13->22) and messageID(9->21) for international format
            byte[] stream = new byte[IConstants.SUBMIT_BUFFER_SIZE_V1];
            //sbyte[] stream = new sbyte[IConstants.SUBMIT_BUFFER_SIZE_V3];
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            stream[0] = type;
            stream[1] = coding;
            stream[2] = length;
            stream[3] = tranType;
            for (int i = 0; i < Encoding.UTF8.GetBytes(account).Length; i++)
            {//account
                stream[i + 4] = Convert.ToByte(Encoding.UTF8.GetBytes(account)[i]);
            }
            for (int i = 0; i < Encoding.UTF8.GetBytes(password).Length; i++)
            {//password
                stream[i + 13] = Convert.ToByte(Encoding.UTF8.GetBytes(password)[i]);
            }
            for (int i = 0; i < Encoding.UTF8.GetBytes(rcvMsisdn).Length; i++)
            {//要傳送的號碼
                if ((rcvMsisdn.Length > 12) && (rcvMsisdn[0] != '+'))
                    rcvMsisdn = "+" + rcvMsisdn;
                stream[i + 22] = Convert.ToByte(Encoding.UTF8.GetBytes(rcvMsisdn)[i]);
            }

            for (int i = 0; i < Encoding.UTF8.GetBytes(messageID).Length; i++)
            {
                stream[i + 35] = Encoding.UTF8.GetBytes(messageID)[i];
            }

            if (isByMsg == false)
            {
                for (int i = 0; i < Encoding.GetEncoding("Big5").GetBytes(message).Length; i++)
                {
                    stream[i + 44] = Encoding.GetEncoding("Big5").GetBytes(message)[i];
                }
            }
            else
            {
                for (int i = 0; i < byMsg.Length; i++)
                {
                    stream[i + 44] = byMsg[i];
                }
            }
            for (int i = 0; i < Encoding.UTF8.GetBytes(dlvTime).Length; i++)
            {
                stream[i + 204] = Encoding.UTF8.GetBytes(dlvTime)[i];
            }

            if (isSetPchid)
                for (int i = 0; i < pchid.Length; i++)
                {
                    stream[i + 4] = pchid[i];
                }
            return stream;
        }
        /**
         * 傳回訊息查詢代碼
         */
        public String getMessageID()
        {
            return messageID;
        }

        public byte getCoding()
        {
            return coding;
        }

        public byte getLength()
        {
            return length;
        }

        public String getDlvTime()
        {
            return dlvTime;
        }

        public String getMessage()
        {
            return message;
        }

        public String getAccount()
        {
            return account;
        }

        public byte getType()
        {
            return type;
        }

        public byte getTranType()
        {
            return tranType;
        }

        public String getRcvMsisdn()
        {
            return rcvMsisdn;
        }
        /**
         * 設定登入密碼
         * @param password String
         */
        public void setPassword(String password)
        {
            this.password = password;
        }
        /**
         * 設定訊息查詢代碼
         * @param messageID String - 訊息查詢代碼,此代碼由SNS回傳給程式
         */
        public void setMessageID(String messageID)
        {
            this.messageID = messageID;
        }
        /**
         * 設定簡訊編碼格式
         * @param coding byte
         */
        public void setCoding(byte coding)
        {
            this.coding = coding;
        }
        /**
         * 設定簡訊內容長度
         * @param length byte
         */
        public void setLength(byte length)
        {
            this.length = length;
        }
        /**
         * 設定預約傳送時間
         * @param dlvTime String
         */
        public void setDlvTime(String dlvTime)
        {
            this.dlvTime = dlvTime;
        }
        /**
         * 設定簡訊內容
         * @param message String
         */
        public void setMessage(String message)
        {
            this.message = message;
        }

        public void setMessage(byte[] bymsg)
        {
            isByMsg = true;
            this.byMsg = bymsg;
        }
        /**
         * 設定登入帳號
         * @param account String
         */
        public void setAccount(String account)
        {
            this.account = account;
        }
        /**
         * 設定服務類型
         * @param type byte
         */
        public void setType(byte type)
        {
            this.type = type;
        }
        /**
         * 設定簡訊傳送方式
         * @param tranType byte
         */
        public void setTranType(byte tranType)
        {
            this.tranType = tranType;
        }
        /**
         * 設定接收訊息之手機號碼
         * @param rcvMsisdn String
         */
        public void setRcvMsisdn(String rcvMsisdn)
        {
            this.rcvMsisdn = rcvMsisdn;
        }

        public String getPassword()
        {
            return password;
        }

        public void setExpire(byte hour, byte min)
        {
            if ((hour > 0) || (min > 0))
            {
                isSetPchid = true;
                this.pchid[0] = hour;
                this.pchid[1] = min;
            }
        }

        public void setUdhi(byte udhi)
        {
            if (udhi == 1)
            {
                isSetPchid = true;
                this.pchid[2] |= 0x01;
            }
        }

        public void setPclid(byte pclid)
        {
            if (pclid > 0)
            {
                isSetPchid = true;
                this.pchid[2] |= 0x04;
                this.pchid[4] = pclid;
            }
        }

        //public static void main(String[] args)
        //{
        //    // 測試reset後byte會不會被清為0
        //    SubmitDataModel sdm = new SubmitDataModel();
        //    sdm.setAccount("xxxxx");
        //    sdm.setPassword("yyyyy");
        //    byte[] btmp = sdm.toByteStream_V1();
        //    System.out.println("###########################");
        //    for (int i = 0; i < btmp.length; i++)
        //    {
        //        System.out.println(", " + btmp[i]);
        //    }
        //    sdm.reset();
        //    btmp = sdm.toByteStream_V1();
        //    System.out.println("###########################");
        //    for (int i = 0; i < btmp.length; i++)
        //    {
        //        System.out.println(", " + btmp[i]);
        //    }

        //}
    }
    public abstract class SnsClientImpl : SubmitDataModel
    {
        protected String m_strSnsIp = "";
        protected int m_nSnsPort = 0;
        protected byte[] m_recvBuffer = null;
        //protected StreamWriter m_socketOut = null;
        //protected StreamReader m_socketIn = null;
        protected Socket m_smsSocket = null;
        protected String m_strLastMessage = "";

        public abstract Boolean login(SubmitDataModel sdm);
        public abstract RecvDataModel submitMessage(SubmitDataModel sdn);
        public abstract RecvDataModel qryMessageStatus(SubmitDataModel sdm);
        public abstract RecvDataModel getMessage(SubmitDataModel sdm);
        public abstract void logout();
        public SnsClientImpl()
        {

        }
        //public SnsClientImpl(String ip, int port)
        //{
        //    m_strSnsIp = ip;
        //    m_nSnsPort = port;
        //}

        /**
         * 回傳上次函示執行失敗的錯誤訊息
         * @return 上次函示執行失敗的錯誤訊息
         */
        public new String getLastMessage()
        {
            return m_strLastMessage;
        }

        protected Boolean connectServer()
        {
            Boolean bRet = true;

            try
            {
                if ((m_smsSocket == null) || m_smsSocket.Connected == true)
                {
                    m_smsSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    IPEndPoint ip = new IPEndPoint(IPAddress.Parse(m_strSnsIp), m_nSnsPort);
                    m_smsSocket.SendTimeout = 10000;
                    m_smsSocket.Connect(ip);
                    bRet = m_smsSocket.Connected;
                }
            }
            catch (Exception e)
            {
                m_strLastMessage = "Connect server fail(" + e.Message + ")";
                disconnectServer();
                bRet = false;
            }
            return bRet;
        }

        protected void disconnectServer()
        {
            try
            {
                if (m_smsSocket != null) m_smsSocket.Close(); m_smsSocket = null;
                //if (m_socketOut != null) m_socketOut.Close(); m_socketOut = null;
                //if (m_socketIn != null) m_socketIn.Close(); m_socketIn = null;
            }
            catch (Exception e)
            {
                m_strLastMessage = "disconnect server fail(" + e.Message + ")";
            }
        }
    }
    public class SnsClient_V1 : SnsClientImpl
    {

        public SnsClient_V1(String ip, int port)
        {
            m_strSnsIp = ip;
            m_nSnsPort = port;
            //suport(ip, port);
            m_recvBuffer = new byte[IConstants.RECV_BUFFER_SIZE_V1];
        }

        /**
         * 登入SNS Server, 回傳值為true, 表示登入認證成功, 可以進行後續簡訊傳送/查詢命令.如果是false,表示網路障礙或是帳號資訊錯誤
         * @param sdm SubmitDataModel - 傳入SNS Server的參數物件, 必須包含帳號與密碼資訊
         * @return boolean - true, 表示登入認證成功; false, 表示登入認證失敗, 呼叫getLastMessage()取得失敗原因
         */
        public override Boolean login(SubmitDataModel sdm)
        {
            if (m_smsSocket == null)
                if (connectServer() == false)
                    return false;
            try
            {

                var iii = m_smsSocket.Send(sdm.toByteStream_V1());
                m_smsSocket.Receive(m_recvBuffer);
                RecvDataModel dm = RecvDataModel.parse_v1(m_recvBuffer);
                if (dm.getCode() != 0)
                {
                    m_strLastMessage = "Server return code : " + dm.getCode() + ":" + Encoding.UTF8.GetString(dm.getDesc()).Trim();
                    disconnectServer();
                    return false;
                }
                string rmss = Encoding.UTF8.GetString(dm.getDesc()).Trim();
                return true;
            }
            catch (Exception e)
            {
                m_strLastMessage = "Exception occurs in login(" + e.Message + ")";
                disconnectServer();
                return false;
            }
        }

        /**
         * 傳送簡訊
         * @param sdm - 傳入SNS Server的參數物件, 必須包含手機門號及欲傳送訊息
         * @return - null, 表示網路異常造成運作中斷, 呼叫getLastMessage()取得失敗原因; 如果執行成功, 透過回傳物件的getCode()與getDesc(), 判斷訊息傳送是否成功
         */
        public override RecvDataModel submitMessage(SubmitDataModel sdm)
        {
            try
            {
                RecvDataModel dm = null;
                m_smsSocket.Send(sdm.toByteStream_V1());
                int return_leng = m_smsSocket.Receive(m_recvBuffer);
                if (return_leng == 189)
                    dm = RecvDataModel.parse_v1(m_recvBuffer);

                return dm;
            }
            catch (Exception e)
            {
                m_strLastMessage = "Exception occurs in submitMessage(" + e.Message + ")";
                disconnectServer();
                return null;
            }
        }

        /**
         * 查詢簡訊傳送狀態
         * @param sdm 傳入SNS Server的參數物件, 包含受訊手機號碼以及message_id
         * @return null, 表示網路異常造成運作中斷, 呼叫getLastMessage()取得失敗原因; 否則透過回傳物件的getCode()與getDesc(), 判斷訊息的傳送狀態
         */
        public override RecvDataModel qryMessageStatus(SubmitDataModel sdm)
        {
            try
            {
                m_smsSocket.Send(sdm.toByteStream_V1());
                //m_socketOut.Write(sdm.toByteStream_V1());
                //m_socketOut.Flush();
                //m_socketIn = new DataInputStream(m_smsSocket.getInputStream());
                //m_socketIn.readFully(m_recvBuffer);
                m_smsSocket.Receive(m_recvBuffer);
                RecvDataModel dm = RecvDataModel.parse_v1(m_recvBuffer);
                return dm;
            }
            catch (Exception e)
            {
                m_strLastMessage = "Exception occurs in qryMessageStatus(" + e.Message + ")";
                disconnectServer();
                return null;
            }
        }

        /**
         * 接收簡訊
         * @param sdm - 傳入SNS Server的參數物件
         * @return - null, 表示網路異常造成運作中斷, 呼叫getLastMessage()取得失敗原因; 如果執行成功, 透過回傳物件的getCode()與getDesc(), 判斷訊息傳送是否成功
         */
        public override RecvDataModel getMessage(SubmitDataModel sdm)
        {
            try
            {
                m_smsSocket.Send(sdm.toByteStream_V1());
                m_smsSocket.Receive(m_recvBuffer);
                RecvDataModel dm = RecvDataModel.parse_v1(m_recvBuffer);
                return dm;
            }
            catch (Exception e)
            {
                m_strLastMessage = "Exception occurs in getMessage(" + e.Message + ")";
                disconnectServer();
                return null;
            }
        }


        /**
         * 中斷與SNS Server的連線
         */
        public override void logout()
        {
            disconnectServer();
        }
    }
    public class SMSSend
    {
        //String m_strIp = "60.250.52.107";
        String m_strIp = "203.66.172.133";
        int m_nPort = 8001;
        String m_account = "10427";
        String m_password = "UDJp8738";
        protected Socket m_smsSocket = null;
        byte[] m_recvBuffer = new byte[IConstants.RECV_BUFFER_SIZE_V1];
        public SMSSend(String ip, int port ,string account , string password )
        {
            m_strIp = ip;
            m_nPort = port;
            m_account = account;
            m_password = password; 
        }
        public RecvDataModel submitMessage(SubmitDataModel sdm)
        {
            try
            {
                RecvDataModel dm = null;
                m_smsSocket.Send(sdm.toByteStream_V1());
                int return_leng = m_smsSocket.Receive(m_recvBuffer);
                if (return_leng == 189)
                    dm = RecvDataModel.parse_v1(m_recvBuffer);

                return dm;
            }
            catch (Exception e)
            {
                //m_strLastMessage = "Exception occurs in submitMessage(" + e.Message + ")";
                //disconnectServer();
                return null;
            }
        }
        public void submitMessage(String recv_msisdn, String text)
        {
            String account = m_account;
            String password = m_password;
            SnsClient_V1 sns = new SnsClient_V1(m_strIp, m_nPort);
            SubmitDataModel sdm = new SubmitDataModel();
            // Login server
            sdm.setType(IConstants.SERV_LOGIN);
            sdm.setCoding(IConstants.SERV_LOGIN);
            sdm.setLength(IConstants.SERV_LOGIN);
            sdm.setTranType(IConstants.SERV_LOGIN);
            sdm.setAccount(account);
            sdm.setPassword(password);
            if (sns.login(sdm) == false)
            {
                Console.WriteLine("login server fail(" + sns.getLastMessage() + ")");
                sns.logout();
                sdm = null;
                return;
            }
            // Setting up proper parameters and submit it, then get the response message.
            sdm.reset();
            sdm.setType(IConstants.SERV_SUBMIT_MSG);
            sdm.setCoding((byte)1);
            sdm.setRcvMsisdn(recv_msisdn);
            sdm.setTranType(IConstants.DEFAULT_TRAN_TYPE);
            //sdm.setLength((byte)text.getBytes().length);
            //sdm.setLength((byte)Encoding.UTF8.GetBytes(text).Length);
            sdm.setLength((byte)Encoding.GetEncoding("Big5").GetBytes(text).Length);
            sdm.setMessage(text);
            RecvDataModel rdm = sns.submitMessage(sdm);
            if (rdm != null)
            {
                Console.WriteLine("return_code=" + rdm.getCode());
                Console.WriteLine("return_desc:" + Encoding.UTF8.GetString(rdm.getDesc()).Trim());
            }
            else  // could not receive response from SNS server
            {
                Console.WriteLine("Submit fail:" + sns.getLastMessage());
            }
            // Logout server
            sns.logout();
            sdm = null;
        }
    }
}
