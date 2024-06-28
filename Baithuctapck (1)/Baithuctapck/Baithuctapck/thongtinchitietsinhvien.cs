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
    public partial class thongtinchitietsinhvien : Form
    {
        public thongtinchitietsinhvien(string MaSV, string HoTen, string GioiTinh, string NgaySinh, string QueQuan, string Email, string SDT, string DiemTB, string Lop, string Truong, string MaDN, string MaGV)
        {
            InitializeComponent();
            txtmasv.Text = MaSV;
            txthoten.Text = HoTen;
            txtgioitinh.Text = GioiTinh;
            txtngaysinh.Text = NgaySinh;
            txtquequan.Text = QueQuan;
            txtemail.Text = Email;
            txtsdt.Text = SDT;
            txtdiemtb.Text = DiemTB;
            txtlophoc.Text = Lop;
            txttruonghoc.Text = Truong;
            txtmadn.Text = MaDN;
            txtmagv.Text = MaGV;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thongtinchitietsinhvien_Load(object sender, EventArgs e)
        {
            txtmasv.Enabled = false;
            txthoten.Enabled = false;
            txtgioitinh.Enabled = false;
            txtngaysinh.Enabled = false;
            txtquequan.Enabled = false;
            txtemail.Enabled = false;
            txtsdt.Enabled = false;
            txtdiemtb.Enabled = false;
            txtlophoc.Enabled = false;
            txttruonghoc.Enabled = false;
            txtmadn.Enabled = false;
            txtmagv.Enabled = false;
        }
    }
}
