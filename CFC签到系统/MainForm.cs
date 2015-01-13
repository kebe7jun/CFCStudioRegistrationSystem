using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace CFC签到系统
{
    public partial class mainFrom : Form
    {
        public mainFrom()
        {
            InitializeComponent();
            init();
        }

        String strPort;
        Int32 botelv;
        String strJiaoyan;
        String strStop;
        Int32 data;
        SerialPort sp = new SerialPort();

        System.Timers.Timer aTimer = new System.Timers.Timer();
        delegate void getString(String myString);
        getString getMyString;

        delegate void hidden();
        hidden hiddenLbl;

        System.Timers.Timer timer = new System.Timers.Timer();  
        private void Timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)  
         {  
       
            // 得到 hour minute second  如果等于某个值就开始执行某个程序。  
            int intHour = e.SignalTime.Hour;  
            int intMinute = e.SignalTime.Minute;  
            int iHour = 23;  
            int iMinute = 30;  
            if (intHour == iHour && Math.Abs(intMinute = iMinute)<20)  
            {
                aTimer.Start();
            }  
        }

        private void checkAll()
        {
            String date = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
            DateTime tmpTime = new DateTime(1970, 1, 1);
            long time = (DateTime.Now.Ticks - tmpTime.Ticks) / 10000000 - 8 * 60 * 60;
        }

        private void hiddenL()
        {
            lblShowInfo.Visible = false;
            aTimer.Stop();
        }
        private void hiddenInfo(object sender, ElapsedEventArgs e)
        {
            hiddenLbl = new hidden(hiddenL);
            this.Invoke(hiddenLbl);
        }
        private void updateData(String str)
        {
            String date = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
            DateTime tmpTime = new DateTime(1970, 1, 1);
            long time = (DateTime.Now.Ticks - tmpTime.Ticks) / 10000000 - 8 * 60 * 60;

            SQLiteParameter[] pParams = new SQLiteParameter[3];
            pParams[0] = new SQLiteParameter("@str", DbType.String);
            pParams[0].Value = str;
            pParams[1] = new SQLiteParameter("@date", DbType.String);
            pParams[1].Value = date;
            pParams[2] = new SQLiteParameter("@time", DbType.Int32);
            pParams[2].Value = time;
            DataTable dt = SqliteOperator.Query("select * from memberinfo where no = @str", pParams).Tables[0];

            aTimer.Start();
            int count = dt.Rows.Count;
            if (count == 0)
            {
                lblShowInfo.Visible = true;
                lblShowInfo.Text = "欢迎参观\nCFC Studio";
                SqliteOperator.Query("insert into visiters (no, time) values(@str, @time)", pParams);
                sp.Write("0");
            }
            else
            {
                String strNaeme = dt.Rows[0]["name"].ToString();
                String strNickname = dt.Rows[0]["nickname"].ToString();
                DataTable tmp = SqliteOperator.Query("select count(*) from qiandao where no = @str and date = @date", pParams).Tables[0];
                int c = int.Parse(tmp.Rows[0]["count(*)"].ToString());
                if(c>5 && !str.Equals("86842721"))
                {
                    lblShowInfo.Visible = true;
                    sp.Write("3");
                    lblShowInfo.Text = strNaeme + "\n签到失败！";
                    return;
                }
                DataTable qiandao = SqliteOperator.Query("select * from qiandao where no = @str and date = @date order by _id desc limit 1", pParams).Tables[0];
                if (qiandao.Rows.Count < 1)
                {
                    SqliteOperator.Query("insert into qiandao (no, time, type, date) values(@str, @time, 1, @date)", pParams);
                    lblShowInfo.Visible = true;
                    sp.Write("1");
                    lblShowInfo.Text = strNaeme + "\n签到成功！";
                    return;
                }
                int type = int.Parse(qiandao.Rows[0]["type"].ToString());
                if (type == 1)
                {
                    SqliteOperator.Query("insert into qiandao (no, time, type, date) values( @str, @time, 2, @date)", pParams);
                    lblShowInfo.Visible = true;
                    sp.Write("2");
                    lblShowInfo.Text = strNaeme + "\n签退成功！";
                }
                else
                {
                    SqliteOperator.Query("insert into qiandao (no, time, type, date) values(@str, @time, 1, @date)", pParams);
                    lblShowInfo.Visible = true;
                    sp.Write("1");
                    lblShowInfo.Text = strNaeme + "\n签到成功！";
                }
            }
        }

        public void init()
        {
            //按钮透明处理

            btn.FlatStyle = FlatStyle.Flat;//样式
            btn.ForeColor = Color.Transparent;//前景
            btn.BackColor = Color.Transparent;//去背景
            btn.FlatAppearance.BorderSize = 0;//去边线
            btn.FlatAppearance.MouseOverBackColor = Color.Transparent;//鼠标经过
            btn.FlatAppearance.MouseDownBackColor = Color.Transparent;//鼠标按下
            lblTitle.BackColor = Color.Transparent;
            lblShowInfo.BackColor = Color.Transparent;
            SqliteOperator.Query("select * from portinfo");
            DataRow dr = SqliteOperator.Query("select * from portinfo").Tables[0].Rows[0];

            String[] ports = System.IO.Ports.SerialPort.GetPortNames();
            if (ports.Length > 0)
            {
                strPort = ports[0];
                sp.PortName = strPort;
                sp.BaudRate = int.Parse(dr["BaudRate"].ToString());
                sp.StopBits = StopBits.One;
                sp.Parity = Parity.None;
                sp.DataBits = int.Parse(dr["DataBits"].ToString());
                sp.DataReceived += new SerialDataReceivedEventHandler(spDataReceived);
                sp.Open();
                aTimer.Elapsed += new ElapsedEventHandler(hiddenInfo);
                // Set the Interval to 5 seconds.
                aTimer.Interval = 2500;
                aTimer.Enabled = true;


                timer.Enabled = true;
                timer.Interval = 60000 * 30;
                timer.Start();
                timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer1_Elapsed);  
            }
            else
            {
                MessageBox.Show("没有检测到设备。");
            }
        }
        void spDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int i = 0;
            int w = sp.BytesToRead;
            int[] x = new int[w];
            for (i = 0; i < w; i++)
            {
                x[i] = sp.ReadByte();
            }
            byte[] data = new byte[w];
            for (int j = 0; j < i; j++)
            {
                data[j] = (byte)x[j];
            }
            String mystring = Encoding.UTF8.GetString(data);
            getMyString = new getString(updateData);//指定委托的函数
            this.Invoke(getMyString, mystring);//调用委托
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Click(object sender, EventArgs e)
        {

            //       ExportExcelData.OutToExcelFromDataGridView();
            sp.Close();
            Form adminForm = new AdminMain();
            adminForm.Show();
            Program.mainForm1.Hide();
        }

        private void mainFrom_VisibleChanged(object sender, EventArgs e)
        {
            if(Program.mainForm1.Visible)
            {
                if (!sp.IsOpen)
                    sp.Open();
            }
        }
    }
}
