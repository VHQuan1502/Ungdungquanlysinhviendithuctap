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
    public partial class qlgiangvien : Form
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
        public qlgiangvien(string chucvu)
        {
            InitializeComponent();
            this.chucvu = chucvu;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            them();
        }
        public void them()
        {
            if (btnThem.Text == THEM)
            {
                txtmagv.Enabled = true;
                txttengv.Enabled = true;
                cbgioitinh.Enabled = true;
                dateTimePicker1.Enabled = true;
                txtemail.Enabled = true;
                txtsdt.Enabled = true;
                txtchucvu.Enabled = true;
                txtkhoa.Enabled = true;
                richTextBox1.Enabled = true;

                txtmagv.Clear();
                txttengv.Clear();
                txtemail.Clear();
                txtsdt.Clear();
                txtchucvu.Clear();
                txtkhoa.Clear();
                richTextBox1.Clear();

                btnThem.Text = HOATDONG;
                BtnSua.Enabled = false;
                btnxoa.Enabled = false;
                BtnGhi.Enabled = true;
                BtnHuy.Enabled = true;
                btnThem.Enabled = false;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txt_TextChanged(object sender, EventArgs e)
        {

        }
        private void loadform()
        {
            if(chucvu == "giangvien")
            {
                btnThem.Enabled = false;
                BtnSua.Enabled = false;
                btnxoa.Enabled = false;
            }
            BtnGhi.Enabled = false;
            BtnHuy.Enabled = false;

            txtmagv.Enabled = false;
            txttengv.Enabled = false;
            cbgioitinh.Enabled = false;
            dateTimePicker1.Enabled = false;
            txtemail.Enabled = false;
            txtsdt.Enabled = false;
            txtchucvu.Enabled = false;
            txtkhoa.Enabled = false;
            richTextBox1.Enabled = false;

            dgvgv.DataSource = DataAccess.GetTable("select * from GiangVien");
            dgvgv.Columns[0].HeaderText = "Mã Giảng Viên";
            dgvgv.Columns[1].HeaderText = "Họ Tên Giảng Viên";
            dgvgv.Columns[2].HeaderText = "Giới Tính";
            dgvgv.Columns[3].HeaderText = "Ngày Sinh";
            dgvgv.Columns[4].HeaderText = "Email";
            dgvgv.Columns[5].HeaderText = "Số điện thoại";
            dgvgv.Columns[6].HeaderText = "Chức Vụ";
            dgvgv.Columns[7].HeaderText = "Khoa";
            dgvgv.Columns[8].HeaderText = "Trường";

            dgvgv.Columns[0].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvgv.Columns[1].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvgv.Columns[2].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvgv.Columns[3].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvgv.Columns[4].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvgv.Columns[5].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvgv.Columns[6].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvgv.Columns[7].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvgv.Columns[8].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
        }
        private void qlgiangvien_Load(object sender, EventArgs e)
        {
            loadform();
        }
        public void sua()
        {
            if (BtnSua.Text == SUA)
            {
                txttengv.Enabled = true;
                cbgioitinh.Enabled = true;
                dateTimePicker1.Enabled = true;
                txtemail.Enabled = true;
                txtsdt.Enabled = true;
                txtchucvu.Enabled = true;
                txtkhoa.Enabled = true;
                richTextBox1.Enabled = true;

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
                string sql = "delete from SinhVien where MaGV=N'" + txtmagv.Text + "'";
                DataAccess.AddEditDelete(sql);
                string sql1 = "delete from GiangVien where MaGV=N'" + txtmagv.Text + "'";
                DataAccess.AddEditDelete(sql1);

                dgvgv.DataSource = DataAccess.GetTable("select * from GiangVien");
                MessageBox.Show("Đã xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnGhi_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == HOATDONG)
            {
                string sql = "Insert into GiangVien values(N'" +
                             txtmagv.Text + "', N'" +
                             txttengv.Text + "', N'" +
                             cbgioitinh.Text + "', N'" +
                             dateTimePicker1.Value.ToString("yyyy/MM/dd") + "', N'" +
                             txtemail.Text + "', N'" +
                             txtsdt.Text + "', N'" +
                             txtchucvu.Text + "', N'" +
                             txtkhoa.Text + "', N'" +
                             richTextBox1.Text + "' )";
                DataAccess.AddEditDelete(sql);
                dgvgv.DataSource = DataAccess.GetTable("select * from GiangVien");
            }
            if (BtnSua.Text == HOATDONG)
            {
                DialogResult rs = MessageBox.Show("Bạn chắc chắn sửa thông tin này ? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    string sql = "update GiangVien set HoTenGV =N'" +
                          txttengv.Text + "', GioiTinh =N'" +
                          cbgioitinh.Text + "', NgaySinh =N'" +
                          dateTimePicker1.Value.ToString("yyyy/MM/dd") + "', Email =N'" +
                          txtemail.Text + "', SDT =N'" +
                          txtsdt.Text + "', ChucVu =N'" +
                          txtchucvu.Text + "', Khoa =N'" +
                          txtkhoa.Text + "', Truong =N'" +
                          richTextBox1.Text +  "' where MaGV=N'" +
                          txtmagv.Text + "'";
                    DataAccess.AddEditDelete(sql);
                    dgvgv.DataSource = DataAccess.GetTable("select * from GiangVien");
                    MessageBox.Show("Đã sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
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
            if (BtnSua.Text == HOATDONG)
            {
                BtnSua.Text = SUA;
                loadform();
            }
        }
        private void KhoiPhuc(int i)
        {
            txtmagv.Text = dgvgv.Rows[i].Cells[0].Value.ToString();
            txttengv.Text = dgvgv.Rows[i].Cells[1].Value.ToString();
            cbgioitinh.Text = dgvgv.Rows[i].Cells[2].Value.ToString();
            dateTimePicker1.Value = (DateTime)dgvgv.Rows[i].Cells[3].Value;
            txtemail.Text = dgvgv.Rows[i].Cells[4].Value.ToString();
            txtsdt.Text = dgvgv.Rows[i].Cells[5].Value.ToString();
            txtchucvu.Text = dgvgv.Rows[i].Cells[6].Value.ToString();
            txtkhoa.Text = dgvgv.Rows[i].Cells[7].Value.ToString();
            richTextBox1.Text = dgvgv.Rows[i].Cells[8].Value.ToString();
        }
        private void btnreset_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();

            btnThem.Text = THEM;
            BtnSua.Text = SUA;

            loadform();
            KhoiPhuc(cr);
        }

        private void dgvgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string MaGV = dgvgv.Rows[e.RowIndex].Cells[0].Value.ToString();
                string HoTenGV = dgvgv.Rows[e.RowIndex].Cells[1].Value.ToString();
                string GioiTinh = dgvgv.Rows[e.RowIndex].Cells[2].Value.ToString();
                string NgaySinh = dgvgv.Rows[e.RowIndex].Cells[3].Value.ToString();
                string Email = dgvgv.Rows[e.RowIndex].Cells[4].Value.ToString();
                string SDT = dgvgv.Rows[e.RowIndex].Cells[5].Value.ToString();
                string Chuvu = dgvgv.Rows[e.RowIndex].Cells[6].Value.ToString();
                string Khoa = dgvgv.Rows[e.RowIndex].Cells[7].Value.ToString();
                string Truong = dgvgv.Rows[e.RowIndex].Cells[8].Value.ToString();



                thongtinchitietgiangvien a = new thongtinchitietgiangvien(MaGV, HoTenGV, GioiTinh, NgaySinh, Email, SDT, Chuvu, Khoa, Truong);
                a.ShowDialog();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtTimKiem.Text.Trim() == "")
                sql = "select * from GiangVien";
            else
                sql = "select * from GiangVien where HoTenGV like N'%" +
                txtTimKiem.Text + "%'";

            dgvgv.DataSource = DataAccess.GetTable(sql);
        }

        private void dgvgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvgv.CurrentRow != null)
            {
                txtmagv.Text = dgvgv.CurrentRow.Cells[0].Value.ToString();
                txttengv.Text = dgvgv.CurrentRow.Cells[1].Value.ToString();
                cbgioitinh.Text = dgvgv.CurrentRow.Cells[2].Value.ToString();
                dateTimePicker1.Value = (DateTime)dgvgv.CurrentRow.Cells[3].Value;
                txtemail.Text = dgvgv.CurrentRow.Cells[4].Value.ToString();
                txtsdt.Text = dgvgv.CurrentRow.Cells[5].Value.ToString();
                txtchucvu.Text = dgvgv.CurrentRow.Cells[6].Value.ToString();
                txtkhoa.Text = dgvgv.CurrentRow.Cells[7].Value.ToString();
                richTextBox1.Text = dgvgv.CurrentRow.Cells[8].Value.ToString();
            }
        }
    }
}
