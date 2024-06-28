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
    public partial class DanhGia : Form
    {
        string chucvu;
        string user;
        public DanhGia(string chucvu , string user)
        {
            InitializeComponent();
            this.chucvu = chucvu;
            this.user = user;
        }

        public void loadform()
        {
            if (chucvu == "doanhnghiep")
            {

                dgvctqt.DataSource = DataAccess.GetTable("select * from SinhVien where MaDN = '"+user+"' ");
                dgvctqt.Columns[0].HeaderText = "Mã Sinh Viên";
                dgvctqt.Columns[1].HeaderText = "Họ Tên Sinh Viên";
                dgvctqt.Columns[2].HeaderText = "Giới Tính";
                dgvctqt.Columns[3].HeaderText = "Ngày Sinh";
                dgvctqt.Columns[4].HeaderText = "Quê Quán";
                dgvctqt.Columns[5].HeaderText = "Email";
                dgvctqt.Columns[6].HeaderText = "Số điện thoại";
                dgvctqt.Columns[7].HeaderText = "Điểm trung bình";
                dgvctqt.Columns[8].HeaderText = "Lớp";
                dgvctqt.Columns[9].HeaderText = "Trường";
                dgvctqt.Columns[10].HeaderText = "MaDN";
                dgvctqt.Columns[11].HeaderText = "MaGV";

                dgvctqt.Columns[0].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvctqt.Columns[1].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvctqt.Columns[2].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvctqt.Columns[3].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvctqt.Columns[4].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.AllCells;
                dgvctqt.Columns[5].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.AllCells;
                dgvctqt.Columns[6].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.AllCells;
                dgvctqt.Columns[7].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.AllCells;
                dgvctqt.Columns[8].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.AllCells;
                dgvctqt.Columns[9].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.AllCells;
                dgvctqt.Columns[10].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.AllCells;
                dgvctqt.Columns[11].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.AllCells;                
            }
            else
            {
                dgvctqt.DataSource = DataAccess.GetTable("select * from CT_QuaTrinh");
                dgvctqt.Columns[0].HeaderText = "Mã Chi Tiết";
                dgvctqt.Columns[1].HeaderText = "Tuần ";
                dgvctqt.Columns[2].HeaderText = "Mã Sinh Viên";
                dgvctqt.Columns[3].HeaderText = "Mã Đề Tài";
                dgvctqt.Columns[4].HeaderText = "Đánh Giá";
                dgvctqt.Columns[5].HeaderText = "Điểm";
                dgvctqt.Columns[6].HeaderText = "Ngày Đánh Giá";
                dgvctqt.Columns[7].HeaderText = "Mã Doanh Nghiệp";

                dgvctqt.Columns[0].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvctqt.Columns[1].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvctqt.Columns[2].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvctqt.Columns[3].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvctqt.Columns[4].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvctqt.Columns[5].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvctqt.Columns[6].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvctqt.Columns[6].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
            }
        }
        private void DanhGia_Load(object sender, EventArgs e)
        {
            loadform();
        }

        private void dgvctqt_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(chucvu != "giangvien")
            {
                if (e.RowIndex >= 0)
                {
                    string MaSV = dgvctqt.Rows[e.RowIndex].Cells[0].Value.ToString();

                    DanhGiaCT a = new DanhGiaCT(MaSV);
                    a.ShowDialog();
                }
            }            
        }
    }
}
