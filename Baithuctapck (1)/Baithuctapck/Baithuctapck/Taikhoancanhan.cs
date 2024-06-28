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
    public partial class Taikhoancanhan : Form
    { 
        string user;
        public Taikhoancanhan(string user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "select ID from taikhoan where username ='" + user+ "' ";
            string id = DataAccess.LayMotGT(sql);
            string sql1 = "select ID from taikhoan where username ='" + user + "' ";
            string pass = DataAccess.LayMotGT(sql1);
            string a = txtmknew.Text;
            string b = txtmknew2.Text;
            if(txtmkcu.Text == pass)
            {
                if (a != b)
                {
                    MessageBox.Show("Mật khẩu không trùng khớp!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult rs = MessageBox.Show("Bạn chắc chắn sửa thông tin này ? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rs == DialogResult.Yes)
                    {
                        string sql2 = "update taikhoan set pass =N'" +
                              txtmknew.Text + "' where ID=N'" +
                              id + "'";
                        DataAccess.AddEditDelete(sql2);
                        MessageBox.Show("Đã thay đổi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }    
        }

        private void Taikhoancanhan_Load(object sender, EventArgs e)
        {
            lbuser.Text = user;
        }
    }
}
