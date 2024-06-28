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
    public partial class thongtinchitietgiangvien : Form
    {
        public thongtinchitietgiangvien(string MaGV, string HoTenGV, string GioiTinh, string NgaySinh, string Email, string SDT, string Chuvu, string Khoa, string Truong)
        {
            InitializeComponent();
            txtmagv.Text = MaGV;
            txttengv.Text = HoTenGV;
            txtgioitinh.Text = GioiTinh;
            txtngaysinh.Text = NgaySinh;
            txtemail.Text = Email;
            txtsdt.Text = SDT;
            txtchucvu.Text = Chuvu;
            txtkhoa.Text = Khoa;
            txttruong.Text = Truong;
        }

        private void thongtinchitietgiangvien_Load(object sender, EventArgs e)
        {
            txtmagv.Enabled = false;
            txttengv.Enabled = false;
            txtgioitinh.Enabled = false;
            txtngaysinh.Enabled = false;
            txtemail.Enabled = false;
            txtsdt.Enabled = false;
            txtchucvu.Enabled = false;
            txtkhoa.Enabled = false;
            txttruong.Enabled = false;

            dgvsvhd.DataSource = DataAccess.GetTable("select * from SinhVien where MaGV = '"+txtmagv.Text+"'");
            dgvsvhd.Columns[0].HeaderText = "Mã Sinh Viên";
            dgvsvhd.Columns[1].HeaderText = "Họ Tên Sinh Viên";
            dgvsvhd.Columns[2].HeaderText = "Giới Tính";
            dgvsvhd.Columns[3].HeaderText = "Ngày Sinh";
            dgvsvhd.Columns[4].HeaderText = "Quê Quán";
            dgvsvhd.Columns[5].HeaderText = "Email";
            dgvsvhd.Columns[6].HeaderText = "Số điện thoại";
            dgvsvhd.Columns[7].HeaderText = "Điểm trung bình";
            dgvsvhd.Columns[8].HeaderText = "Lớp";
            dgvsvhd.Columns[9].HeaderText = "Trường";
            dgvsvhd.Columns[10].HeaderText = "MaDN";
            dgvsvhd.Columns[11].HeaderText = "MaGV";

            dgvsvhd.Columns[0].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvsvhd.Columns[1].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvsvhd.Columns[2].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvsvhd.Columns[3].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvsvhd.Columns[4].AutoSizeMode =
               DataGridViewAutoSizeColumnMode.AllCells;
            dgvsvhd.Columns[5].AutoSizeMode =
               DataGridViewAutoSizeColumnMode.AllCells;
            dgvsvhd.Columns[6].AutoSizeMode =
               DataGridViewAutoSizeColumnMode.AllCells;
            dgvsvhd.Columns[7].AutoSizeMode =
               DataGridViewAutoSizeColumnMode.AllCells;
            dgvsvhd.Columns[8].AutoSizeMode =
               DataGridViewAutoSizeColumnMode.AllCells;
            dgvsvhd.Columns[9].AutoSizeMode =
               DataGridViewAutoSizeColumnMode.AllCells;
            dgvsvhd.Columns[10].AutoSizeMode =
               DataGridViewAutoSizeColumnMode.AllCells;
            dgvsvhd.Columns[11].AutoSizeMode =
               DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
