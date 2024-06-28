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
    public partial class Xacnhandoanhnghiep : Form
    {
        string chucvu;
        public Xacnhandoanhnghiep(string chucvu)
        {
            InitializeComponent();
            this.chucvu = chucvu;
        }

        private void Xacnhandoanhnghiep_Load(object sender, EventArgs e)
        {

        }
        public void xacnhan()
        {
            string sql = "select TenDN from DoanhNghiep where MaDN ='" + textBox1.Text + "' ";
            string doanhnghiep = DataAccess.LayMotGT(sql);
            string user = textBox1.Text;
            if (doanhnghiep == "")
            {
                MessageBox.Show("Mã xác thực không đúng !", "Thống báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                textBox1.SelectAll();
            }
            else
            {
                Home frmMain = new Home(chucvu, user);
                frmMain.Show();
                this.Hide();
            }
        }
        private void btnxacnhap_Click(object sender, EventArgs e)
        {
            xacnhan();
        }
    }
}
