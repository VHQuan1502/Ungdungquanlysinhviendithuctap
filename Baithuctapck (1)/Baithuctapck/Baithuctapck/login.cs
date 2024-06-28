using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baithuctapck
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void dangnhap()
        {
            string MaDN;
            string sql = "select chucvu from taikhoan where username='" + textBox1.Text + "' and pass ='" + textBox2.Text + "'";
            string chucvu = DataAccess.LayMotGT(sql);
            string user = textBox1.Text;
            if (chucvu == "")
            {
                MessageBox.Show(" Tài khoản không đúng!", "Thống báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                textBox1.SelectAll();
                textBox2.Text = "";
            }
            if(chucvu == "doanhnghiep")
            {
                Xacnhandoanhnghiep a = new Xacnhandoanhnghiep(chucvu);
                a.Show();
                this.Hide();
            }
            else
            {
                Home frmMain = new Home(chucvu, user);
                frmMain.Show();
                this.Hide();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            dangnhap();
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                dangnhap();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
