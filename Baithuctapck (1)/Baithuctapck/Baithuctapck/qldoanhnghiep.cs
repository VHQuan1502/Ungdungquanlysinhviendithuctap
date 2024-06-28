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
    public partial class qldoanhnghiep : Form
    {
        #region Hằng xâu 
        string THEM = "Thêm";
        string HUY = "Hủy";
        string LUU = "Ghi";
        string SUA = "Sửa";
        string XOA = "Xóa";
        string THOAT = "Thoát";
        string TIMKIEM = "Tìm kiếm";
        string RESET = "Reset";
        string HOATDONG = ">>>";
        #endregion

        private int cr;
        string chucvu;
        public qldoanhnghiep(string chucvu)
        {
            InitializeComponent();
            this.chucvu = chucvu;

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy/MM/dd";
        }
        private void loadform()
        {
            btnThem.Enabled = true;
            btnxoa.Enabled = true;
            BtnSua.Enabled = true;
            BtnGhi.Enabled = false;
            BtnHuy.Enabled = false;

            txtmadn.Enabled = false;
            txttendn.Enabled = false;
            txttenvt.Enabled = false;
            txtdiachi.Enabled = false;
            txtsdt.Enabled = false;
            dateTimePicker1.Enabled = false;
            txtloaihinh.Enabled = false;

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
        private void qldoanhnghiep_Load(object sender, EventArgs e)
        {
            loadform();
        }
        public void them()
        {
            if (btnThem.Text == THEM)
            {
                txtmadn.Enabled = true;
                txttendn.Enabled = true;
                txttenvt.Enabled = true;
                txtdiachi.Enabled = true;
                txtsdt.Enabled = true;
                dateTimePicker1.Enabled = true;
                txtloaihinh.Enabled = true;

                txtmadn.Clear();
                txttendn.Clear();
                txttenvt.Clear();
                txtdiachi.Clear();
                txtsdt.Clear();
                txtloaihinh.Clear();

                btnThem.Text = HOATDONG;
                BtnSua.Enabled = false;
                btnxoa.Enabled = false;
                BtnGhi.Enabled = true;
                BtnHuy.Enabled = true;
                btnThem.Enabled = false;
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            them();
        }

        public void sua()
        {
            if (btnThem.Text == THEM)
            {
                txttendn.Enabled = true;
                txttenvt.Enabled = true;
                txtdiachi.Enabled = true;
                txtsdt.Enabled = true;
                dateTimePicker1.Enabled = true;
                txtloaihinh.Enabled = true;

                BtnSua.Text = HOATDONG;
                BtnSua.Enabled = false;
                btnxoa.Enabled = false;
                BtnGhi.Enabled = true;
                BtnHuy.Enabled = true;
                btnThem.Enabled = false;
            }
        }
        private void BtnSua_Click(object sender, EventArgs e)
        {
            sua();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin về doanh nghiệp này", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.OK)
            {
                string sql = "delete from SinhVien where MaDN=N'" + txtmadn.Text + "'";
                DataAccess.AddEditDelete(sql);
                string sql1 = "delete from DeTai where MaDN=N'" + txtmadn.Text + "'";
                DataAccess.AddEditDelete(sql1);
                string sql2 = "delete from QuaTrinh where MaDN=N'" + txtmadn.Text + "'";
                DataAccess.AddEditDelete(sql2);
                string sql3 = "delete from DoanhNghiep where MaDN=N'" + txtmadn.Text + "'";
                DataAccess.AddEditDelete(sql3);


                dgvdn.DataSource = DataAccess.GetTable("select * from DoanhNghiep");
                MessageBox.Show("Đã xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvdn_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdn.CurrentRow != null)
            {
                txtmadn.Text = dgvdn.CurrentRow.Cells[0].Value.ToString();
                txttendn.Text = dgvdn.CurrentRow.Cells[1].Value.ToString();
                txttenvt.Text = dgvdn.CurrentRow.Cells[2].Value.ToString();
                txtdiachi.Text = dgvdn.CurrentRow.Cells[3].Value.ToString();
                txtsdt.Text = dgvdn.CurrentRow.Cells[4].Value.ToString();
                dateTimePicker1.Value = (DateTime)dgvdn.CurrentRow.Cells[5].Value;
                txtloaihinh.Text = dgvdn.CurrentRow.Cells[6].Value.ToString();
            }
        }

        private void BtnGhi_Click(object sender, EventArgs e)
        {
            if(btnThem.Text == HOATDONG)
            {
                string sql = "insert into DoanhNghiep values(N'" +
                              txtmadn.Text + "', N'" +
                              txttendn.Text + "', N'" +
                              txttenvt.Text + "', N'" +
                              txtdiachi.Text + "', N'" +
                              txtsdt.Text + "', N'" +
                              dateTimePicker1.Value.ToString("yyyy/MM/dd") + "', N'" +
                              txtloaihinh.Text + "')";
                DataAccess.AddEditDelete(sql);
                dgvdn.DataSource = DataAccess.GetTable("select * from DoanhNghiep");
            }
            if(BtnSua.Text == HOATDONG)
            {
                DialogResult rs = MessageBox.Show("Bạn chắc chắn sửa thông tin này ? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    string sql = "update DoanhNghiep set TenDN =N'" +
                          txttendn.Text + "', TenVietTat =N'" +
                          txttenvt.Text + "', DiaChi =N'" +
                          txtdiachi.Text + "', SDT =N'" +
                          txtsdt.Text + "', NgayHD =N'" +
                          dateTimePicker1.Value.ToString("yyyy/MM/dd") + "', LoaiHinhDN =N'" +
                          txtloaihinh.Text + "' where MaDN=N'" +
                          txtmadn.Text + "'";
                    DataAccess.AddEditDelete(sql);
                    dgvdn.DataSource = DataAccess.GetTable("select * from DoanhNghiep");
                    MessageBox.Show("Đã sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnxoa.Enabled = true;
            BtnSua.Enabled = true;
            BtnGhi.Enabled = false;
            BtnHuy.Enabled = false;
            if (btnThem.Text == HOATDONG)
            {
                btnThem.Text = THEM;
                loadform();
            }
            if(BtnSua.Text == HOATDONG)
            {
                BtnSua.Text = SUA;
                loadform();
            }
        }

        private void KhoiPhuc(int i)
        {
            txtmadn.Text = dgvdn.Rows[i].Cells[0].Value.ToString();
            txttendn.Text = dgvdn.Rows[i].Cells[1].Value.ToString();
            txttenvt.Text = dgvdn.Rows[i].Cells[2].Value.ToString();
            txtdiachi.Text = dgvdn.Rows[i].Cells[3].Value.ToString();
            txtsdt.Text = dgvdn.Rows[i].Cells[4].Value.ToString();
            dateTimePicker1.Value = (DateTime)dgvdn.Rows[i].Cells[5].Value;
            txtloaihinh.Text = dgvdn.Rows[i].Cells[6].Value.ToString();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();

            loadform();

            btnThem.Text = THEM;
            BtnSua.Text = SUA;

            KhoiPhuc(cr);
        }

        private void dgvdn_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string MaDN = dgvdn.Rows[e.RowIndex].Cells[0].Value.ToString();
                string TenDN = dgvdn.Rows[e.RowIndex].Cells[1].Value.ToString();
                string TenVietTat = dgvdn.Rows[e.RowIndex].Cells[2].Value.ToString();
                string DiaChi = dgvdn.Rows[e.RowIndex].Cells[3].Value.ToString();
                string SDT = dgvdn.Rows[e.RowIndex].Cells[4].Value.ToString();
                string NgayHD = dgvdn.Rows[e.RowIndex].Cells[5].Value.ToString();
                string LoaiHinhDN = dgvdn.Rows[e.RowIndex].Cells[6].Value.ToString();


                thongtinchitietdoanhnghiep a = new thongtinchitietdoanhnghiep(MaDN, TenDN, TenVietTat, DiaChi, SDT, NgayHD, LoaiHinhDN);
                a.ShowDialog();
            }
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
