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
    public partial class Home : Form
    {
        int panelWidth;
        bool Hidden;
        string chucvu;
        string user;
        #region tenchucvu 
        string gvhhd = "Giảng viên hướng dẫn";
        string doanhnghiep = "Doanh Nghiệp";
        string gvql = "Giảng viên quản lý";
        string admin = "Admin";
        #endregion
        public Home(string chucvu, string user)
        {
            InitializeComponent();

            this.chucvu = chucvu;
            this.user = user;
            panelWidth = panelLeft.Width;
            Hidden = false;
            UpdateTime();
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();

            lbuser.Text = user;

            if(chucvu == "doanhnghiep")
            {
                btnGiangvien.Enabled = false;
                lbchucvu.Text = doanhnghiep;
                btnTaiKhoan.Text = "     Đổi mật khẩu";
            }
            else if(chucvu == "giangvien")
            {
                lbchucvu.Text = gvhhd;
                btnTaiKhoan.Text = "     Đổi mật khẩu";
            }
            else if(chucvu == "giangvienquanly")
            {
                lbchucvu.Text = gvql;
                btnTaiKhoan.Text = "     Đổi mật khẩu";
            }
            else if(chucvu == "admin")
            {
                lbchucvu.Text = admin;
                btnTaiKhoan.Text = "     Tài khoản";
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateTime();
        }
        private void UpdateTime()
        {
            DateTime currentTime = DateTime.Now;
            lblTime.Text = currentTime.ToString("HH:mm:ss");
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            int stepSize = 20;

            if (Hidden)
            {
                int newWidth = Math.Min(panelLeft.Width + stepSize, panelWidth);
                if (newWidth != panelLeft.Width)
                {
                    panelLeft.Width = newWidth;
                }
                else
                {
                    timer1.Stop();
                    Hidden = false;
                }
            }
            else
            {
                int newWidth = Math.Max(panelLeft.Width - stepSize, 55);
                if (newWidth != panelLeft.Width)
                {
                    panelLeft.Width = newWidth;
                }
                else
                {
                    timer1.Stop();
                    Hidden = true;
                }
            }

            this.Refresh();
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AddForm(Form add)
        {
            this.pnlContent.Controls.Clear();
            add.TopLevel = false;
            add.AutoScroll = true;
            add.FormBorderStyle = FormBorderStyle.None;
            add.Dock = DockStyle.Fill;
            this.Text = add.Text;
            this.pnlContent.Controls.Add(add);
            add.Show();
        }

        private void btnSinhvien_Click(object sender, EventArgs e)
        {
            if (chucvu == "doanhnghiep")
            {
                qlsinhvien add = new qlsinhvien(chucvu,user);
                AddForm(add);
            }
            else
            {
                qlsinhvien add = new qlsinhvien(chucvu,user);
                AddForm(add);
            }
        }

        private void btnGiangvien_Click(object sender, EventArgs e)
        {
            qlgiangvien add = new qlgiangvien(chucvu);
            AddForm(add);
        }

        private void btndoanhnghiep_Click(object sender, EventArgs e)
        {
            qldoanhnghiep add = new qldoanhnghiep(chucvu);
            AddForm(add);
        }

        private void btndetai_Click(object sender, EventArgs e)
        {
            qldetai add = new qldetai(chucvu,user);
            AddForm(add);
        }

        private void btnThongBao_Click(object sender, EventArgs e)
        {
            Thongbao add = new Thongbao(chucvu);
            AddForm(add);
        }

        private void btnQuaTrinh_Click(object sender, EventArgs e)
        {
            qlquatrinh add = new qlquatrinh(chucvu,user);
            AddForm(add);
        }

        private void btndangxuat_Click(object sender, EventArgs e)
        {
            login a = new login();
            a.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            thongke add = new thongke(chucvu,user);
            AddForm(add);
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            if(chucvu == "admin")
            {
                Taikhoan add = new Taikhoan();
                AddForm(add);
            }
            else
            {
                Taikhoancanhan a = new Taikhoancanhan(user);
                a.Show();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DanhGia add = new DanhGia(chucvu,user);
            AddForm(add);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            timer1.Interval=10;
        }
    }
}
