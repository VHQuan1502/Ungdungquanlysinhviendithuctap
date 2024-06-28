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
    public partial class Thongkedoanhnghiep : Form
    {
        public Thongkedoanhnghiep()
        {
            InitializeComponent();
        }
        public void loadform()
        {
            dgvdn.DataSource = DataAccess.GetTable("select * from DoanhNghiep");
            dgvdn.Columns[0].HeaderText = "Mã Doanh Nghiệp";
            dgvdn.Columns[1].HeaderText = "Tên Doanh Nghiệp";
            dgvdn.Columns[2].HeaderText = "Tên Viết Tắt";
            dgvdn.Columns[3].HeaderText = "Địa Chỉ";
            dgvdn.Columns[4].HeaderText = "Số điện thoại";
            dgvdn.Columns[5].HeaderText = "Ngày hoạt động";
            dgvdn.Columns[6].HeaderText = "Loại hình doanh nghiệp";

            dgvdn.Columns[0].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvdn.Columns[1].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvdn.Columns[2].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvdn.Columns[3].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvdn.Columns[4].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvdn.Columns[5].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvdn.Columns[6].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
        }
        private void Thongkedoanhnghiep_Load(object sender, EventArgs e)
        {
            loadform();
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            dgvdn.DataSource = DataAccess.GetTable("SELECT DoanhNghiep.*, COUNT(SinhVien.MaSV) AS SoLuongSinhVien FROM DoanhNghiep LEFT JOIN SinhVien ON DoanhNghiep.MaDN = SinhVien.MaDN GROUP BY DoanhNghiep.MaDN, DoanhNghiep.TenDN, DoanhNghiep.TenVietTat, DoanhNghiep.DiaChi, DoanhNghiep.SDT , DoanhNghiep.NgayHD , DoanhNghiep.LoaiHinhDN");
            dgvdn.Columns[0].HeaderText = "Mã Doanh Nghiệp";
            dgvdn.Columns[1].HeaderText = "Tên Doanh Nghiệp";
            dgvdn.Columns[2].HeaderText = "Tên Viết Tắt";
            dgvdn.Columns[3].HeaderText = "Địa Chỉ";
            dgvdn.Columns[4].HeaderText = "Số điện thoại";
            dgvdn.Columns[5].HeaderText = "Ngày hoạt động";
            dgvdn.Columns[6].HeaderText = "Loại hình doanh nghiệp";
            dgvdn.Columns[7].HeaderText = "Số lượng sinh viên";

            dgvdn.Columns[0].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvdn.Columns[1].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvdn.Columns[2].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvdn.Columns[3].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvdn.Columns[4].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvdn.Columns[5].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvdn.Columns[6].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvdn.Columns[7].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            dgvdn.DataSource = DataAccess.GetTable("SELECT DoanhNghiep.*, COUNT(DeTai.MaDeTai) AS SoLuongDeTai FROM DoanhNghiep LEFT JOIN DeTai ON DoanhNghiep.MaDN = DeTai.MaDN GROUP BY DoanhNghiep.MaDN, DoanhNghiep.TenDN, DoanhNghiep.TenVietTat, DoanhNghiep.DiaChi, DoanhNghiep.SDT , DoanhNghiep.NgayHD , DoanhNghiep.LoaiHinhDN");
            dgvdn.Columns[0].HeaderText = "Mã Doanh Nghiệp";
            dgvdn.Columns[1].HeaderText = "Tên Doanh Nghiệp";
            dgvdn.Columns[2].HeaderText = "Tên Viết Tắt";
            dgvdn.Columns[3].HeaderText = "Địa Chỉ";
            dgvdn.Columns[4].HeaderText = "Số điện thoại";
            dgvdn.Columns[5].HeaderText = "Ngày hoạt động";
            dgvdn.Columns[6].HeaderText = "Loại hình doanh nghiệp";
            dgvdn.Columns[7].HeaderText = "Số lượng đề tài";

            dgvdn.Columns[0].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvdn.Columns[1].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvdn.Columns[2].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvdn.Columns[3].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvdn.Columns[4].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvdn.Columns[5].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvdn.Columns[6].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvdn.Columns[7].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            loadform();
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtTimKiem.Text.Trim() == "")
                sql = "select * from DoanhNghiep";
            else
                sql = "select * from DoanhNghiep where TenDN like N'%" +
                txtTimKiem.Text + "%'";

            dgvdn.DataSource = DataAccess.GetTable(sql);
        }
    }
}
