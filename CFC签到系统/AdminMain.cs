using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CFC签到系统
{
    public partial class AdminMain : Form
    {
        public AdminMain()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form addForm = new Admin();
            this.Hide();
            addForm.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Form editForm = new DeleteData();
            this.Close();
            editForm.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Program.mainForm1.Show();
            this.Close();
        }
    }
}
