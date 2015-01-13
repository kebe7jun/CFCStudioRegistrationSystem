using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CFC签到系统
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        bool isDeviceConnected = false;

        String strPort;
        Int32 botelv;
        String strJiaoyan;
        String strStop;
        Int32 data;
        SerialPort sp = new SerialPort();

        System.Timers.Timer aTimer = new System.Timers.Timer();
        delegate void getString(String myString);
        getString getMyString;
        private void Admin_Load(object sender, EventArgs e)
        {
            lblTishi.Text = "未连接设备!";
            groupBox1.Enabled = false;
            button1_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!isDeviceConnected)
            {
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
                    lblTishi.Text = "设备连接成功!";
                    groupBox1.Enabled = true;
                    isDeviceConnected = true;
                }
            }
        }
        private void updateData(String str)
        {
            textNo.Text = str;
            sp.Write("4");
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            String no = textNo.Text;
            String name = textName.Text;
            String nickName = textNickName.Text;
            String bumen = textBumen.Text;
            String stuNo = textStuNo.Text;
            if(no == "" || name == "" || nickName == "" || bumen == "" || stuNo == "" )
            {
                lblTishi.Text = "请正确输入信息！";
                return;
            }
            SQLiteParameter[] pParams = new SQLiteParameter[5];
            pParams[0] = new SQLiteParameter("@no", DbType.Int32);
            pParams[0].Value = int.Parse(no);
            pParams[1] = new SQLiteParameter("@name", DbType.String);
            pParams[1].Value = name;
            pParams[2] = new SQLiteParameter("@nickName", DbType.String);
            pParams[2].Value = nickName;
            pParams[3] = new SQLiteParameter("@bumen", DbType.String);
            pParams[3].Value = bumen;
            pParams[4] = new SQLiteParameter("@stuNo", DbType.String);
            pParams[4].Value = stuNo;
            if (SqliteOperator.Query("insert into memberinfo (no, name, bumen, xuehao, nickname) values(@no, @name, @bumen, @stuNo, @nickName)", pParams) != null)
            {
                lblTishi.Text = "添加成功！";
            }
            else
                lblTishi.Text = "添加失败";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            sp.Close();
            this.Close();
            Form main = new AdminMain();
            main.Show();
        }
    }
}
