using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CFC签到系统
{
    public partial class DeleteData : Form
    {
        DataSet ds = null;
        int nowId;
        public DeleteData()
        {
            InitializeComponent();
            init();
            
        }
        void init(){
            this.ds = SqliteOperator.Query("select * from memberinfo");
            String temp = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            dataGridView1.DataSource = this.ds.Tables[0];
        }

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            SQLiteParameter[] pParams = new SQLiteParameter[1];
            pParams[0] = new SQLiteParameter("@id", DbType.Int32);
            pParams[0].Value = nowId;
            SqliteOperator.Query("delete from memberinfo where _id=@id", pParams);
            MessageBox.Show("删除数据成功！");
        }

        private void dataGridView1_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            String value = ds.Tables[0].Rows[e.RowIndex].ItemArray[e.ColumnIndex].ToString();
            String cName = dataGridView1.Columns[e.ColumnIndex].Name;
            SQLiteParameter[] pParams = new SQLiteParameter[3];
            pParams[0] = new SQLiteParameter("@value", DbType.String);
            pParams[0].Value = value;
            pParams[1] = new SQLiteParameter("@cname", DbType.String);
            pParams[1].Value = cName;
            pParams[2] = new SQLiteParameter("@id", DbType.Int32);
            pParams[2].Value = nowId;
            String sql = "update memberinfo set " + cName + " = @value where _id = @id";
            SqliteOperator.Query(sql, pParams);
            MessageBox.Show("修改数据成功！");
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            nowId = int.Parse(ds.Tables[0].Rows[e.RowIndex].ItemArray[0].ToString());
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Form main = new AdminMain();
            main.Show();
        }
    }
}
