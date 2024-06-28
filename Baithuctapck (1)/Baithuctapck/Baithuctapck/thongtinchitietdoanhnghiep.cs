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
    public partial class thongtinchitietdoanhnghiep : Form
    {
        public thongtinchitietdoanhnghiep(string MaDN, string TenDN, string TenVietTat, string DiaChi, string SDT, string NgayHD, string LoaiHinhDN)
        {
            InitializeComponent();
            txtmadn.Text = MaDN;
            txttendn.Text = TenDN;
            txttenvt.Text = TenVietTat;
            txtdiachi.Text = DiaChi;
            txtsdt.Text = SDT;
            txtngayhd.Text = NgayHD;
            txtloaihinh.Text = LoaiHinhDN;
            // Thêm sự kiện cho Button1
            button1.MouseEnter += button1_MouseEnter;
            button1.MouseLeave += button1_MouseLeave;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thongtinchitietdoanhnghiep_Load(object sender, EventArgs e)
        {
            txtmadn.Enabled = false;
            txttendn.Enabled = false;
            txttenvt.Enabled = false;
            txtdiachi.Enabled = false;
            txtsdt.Enabled = false;
            txtngayhd.Enabled = false;
            txtloaihinh.Enabled = false;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            // Xử lý khi con trỏ chuột đi vào
            button1.BackColor = System.Drawing.Color.AliceBlue;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            // Xử lý khi con trỏ chuột đi vào
            button1.BackColor = System.Drawing.Color.Transparent;
        }
    }
}
