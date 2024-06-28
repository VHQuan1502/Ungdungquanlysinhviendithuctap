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
    public partial class Thongkesinhvien : Form
    {
        string chucvu;
        string user;
        public Thongkesinhvien(string chucvu, string user)
        {
            InitializeComponent();
            this.chucvu = chucvu;
            this.user = user;
        }
        public void loadform()
        {
            dgvtksv.Columns[0].HeaderText = "Mã Sinh Viên";
            dgvtksv.Columns[1].HeaderText = "Họ Tên Sinh Viên";
            dgvtksv.Columns[2].HeaderText = "Giới Tính";
            dgvtksv.Columns[3].HeaderText = "Ngày Sinh";
            dgvtksv.Columns[4].HeaderText = "Quê Quán";
            dgvtksv.Columns[5].HeaderText = "Email";
            dgvtksv.Columns[6].HeaderText = "Số điện thoại";
            dgvtksv.Columns[7].HeaderText = "Điểm trung bình";
            dgvtksv.Columns[8].HeaderText = "Lớp";
            dgvtksv.Columns[9].HeaderText = "Trường";
            dgvtksv.Columns[10].HeaderText = "MaDN";
            dgvtksv.Columns[11].HeaderText = "MaGV";

            dgvtksv.Columns[0].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvtksv.Columns[1].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvtksv.Columns[2].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvtksv.Columns[3].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvtksv.Columns[4].AutoSizeMode =
               DataGridViewAutoSizeColumnMode.AllCells;
            dgvtksv.Columns[5].AutoSizeMode =
               DataGridViewAutoSizeColumnMode.AllCells;
            dgvtksv.Columns[6].AutoSizeMode =
               DataGridViewAutoSizeColumnMode.AllCells;
            dgvtksv.Columns[7].AutoSizeMode =
               DataGridViewAutoSizeColumnMode.AllCells;
            dgvtksv.Columns[8].AutoSizeMode =
               DataGridViewAutoSizeColumnMode.AllCells;
            dgvtksv.Columns[9].AutoSizeMode =
               DataGridViewAutoSizeColumnMode.AllCells;
            dgvtksv.Columns[10].AutoSizeMode =
               DataGridViewAutoSizeColumnMode.AllCells;
            dgvtksv.Columns[11].AutoSizeMode =
               DataGridViewAutoSizeColumnMode.AllCells;
        }
        private void Thongkesinhvien_Load(object sender, EventArgs e)
        {
            if(chucvu == "doanhnghiep")
            {
                dgvtksv.DataSource = DataAccess.GetTable("select * from SinhVien where MaDN = '"+user+"'");
                loadform();
            }
            else
            {
                dgvtksv.DataSource = DataAccess.GetTable("select * from SinhVien");
                loadform();
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (chucvu == "doanhnghiep")
            {
                dgvtksv.DataSource = DataAccess.GetTable("SELECT SinhVien.MaSV, SinhVien.HoTen,SinhVien.GioiTinh, SinhVien.NgaySinh, SinhVien.Email, SinhVien.Lop, SinhVien.Truong, QuaTrinh.DanhGiaQT, QuaTrinh.Diem FROM SinhVien JOIN QuaTrinh ON SinhVien.MaSV = QuaTrinh.MaSV where SinhVien.MaDN = '" + user + "' ");
                //loadform();
                dgvtksv.Columns[0].HeaderText = "Mã Sinh Viên";
                dgvtksv.Columns[1].HeaderText = "Họ Tên Sinh Viên";
                dgvtksv.Columns[2].HeaderText = "Giới Tính";
                dgvtksv.Columns[3].HeaderText = "Ngày Sinh";
                dgvtksv.Columns[4].HeaderText = "Email";
                dgvtksv.Columns[5].HeaderText = "Lớp";
                dgvtksv.Columns[6].HeaderText = "Trường";
                dgvtksv.Columns[7].HeaderText = "Đánh giá quá trình";
                dgvtksv.Columns[8].HeaderText = "Điểm Quá Trình";

                dgvtksv.Columns[0].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvtksv.Columns[1].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvtksv.Columns[2].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvtksv.Columns[3].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvtksv.Columns[4].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.AllCells;
                dgvtksv.Columns[5].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.AllCells;
                dgvtksv.Columns[6].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.AllCells;
                dgvtksv.Columns[7].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.AllCells;
                dgvtksv.Columns[8].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.AllCells;
            }
            else
            {
                dgvtksv.DataSource = DataAccess.GetTable("SELECT SinhVien.MaSV, SinhVien.HoTen,SinhVien.GioiTinh, SinhVien.NgaySinh, SinhVien.Email, SinhVien.Lop, SinhVien.Truong, QuaTrinh.DanhGiaQT, QuaTrinh.Diem FROM SinhVien JOIN QuaTrinh ON SinhVien.MaSV = QuaTrinh.MaSV; ");
                //loadform();
                dgvtksv.Columns[0].HeaderText = "Mã Sinh Viên";
                dgvtksv.Columns[1].HeaderText = "Họ Tên Sinh Viên";
                dgvtksv.Columns[2].HeaderText = "Giới Tính";
                dgvtksv.Columns[3].HeaderText = "Ngày Sinh";
                dgvtksv.Columns[4].HeaderText = "Email";
                dgvtksv.Columns[5].HeaderText = "Lớp";
                dgvtksv.Columns[6].HeaderText = "Trường";
                dgvtksv.Columns[7].HeaderText = "Đánh giá quá trình";
                dgvtksv.Columns[8].HeaderText = "Điểm Quá Trình";

                dgvtksv.Columns[0].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvtksv.Columns[1].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvtksv.Columns[2].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvtksv.Columns[3].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvtksv.Columns[4].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.AllCells;
                dgvtksv.Columns[5].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.AllCells;
                dgvtksv.Columns[6].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.AllCells;
                dgvtksv.Columns[7].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.AllCells;
                dgvtksv.Columns[8].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.AllCells;
            }
            
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (chucvu == "doanhnghiep")
            {
                dgvtksv.DataSource = DataAccess.GetTable("SELECT SinhVien.* FROM SinhVien LEFT JOIN QuaTrinh ON SinhVien.MaSV = QuaTrinh.MaSV WHERE QuaTrinh.MaSV IS NULL and SinhVien.MaDN = '" + user + "' ");
                loadform();
            }
            else
            {
                dgvtksv.DataSource = DataAccess.GetTable("SELECT SinhVien.* FROM SinhVien LEFT JOIN QuaTrinh ON SinhVien.MaSV = QuaTrinh.MaSV WHERE QuaTrinh.MaSV IS NULL ");
                loadform();
            }          
        }

        private void BtnGhi_Click(object sender, EventArgs e)
        {
            if (chucvu == "doanhnghiep")
            {
                dgvtksv.DataSource = DataAccess.GetTable("SELECT * FROM SinhVien where MaDN ='"+user+"' ORDER BY DiemTB DESC");
                loadform();
            }
            else
            {
                dgvtksv.DataSource = DataAccess.GetTable("SELECT * FROM SinhVien ORDER BY DiemTB DESC");
                loadform();
            }
            
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            if (chucvu == "doanhnghiep")
            {
                dgvtksv.DataSource = DataAccess.GetTable("select * from SinhVien where MaDN = '" + user + "'");
                loadform();
            }
            else
            {
                dgvtksv.DataSource = DataAccess.GetTable("select * from SinhVien");
                loadform();
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtTimKiem.Text.Trim() == "")
                sql = "select * from SinhVien";
            else
                sql = "select * from SinhVien where HoTen like N'%" +
                txtTimKiem.Text + "%'";

            dgvtksv.DataSource = DataAccess.GetTable(sql);
        }
    }
}
