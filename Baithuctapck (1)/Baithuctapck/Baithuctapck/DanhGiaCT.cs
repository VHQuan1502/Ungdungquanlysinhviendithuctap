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
    public partial class DanhGiaCT : Form
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

        string MaSV;
        public DanhGiaCT(string MaSV)
        {
            InitializeComponent();
            this.MaSV = MaSV;
        }
        public void loadform()
        {
            txtma.Enabled = false;
            Cbtuan.Enabled = false;
            txtmasv.Enabled = false;
            txtmadetai.Enabled = false;
            richTextBox1.Enabled = false;
            txtdiem.Enabled = false;
            dateTimePicker1.Enabled = false;
            txtmadoanhnghiep.Enabled = false;

            btnThem.Enabled = true;
            btnxoa.Enabled = true;
            BtnSua.Enabled = true;
            BtnGhi.Enabled = false;
            BtnHuy.Enabled = false;

            txtmasv.Text = MaSV;

            txtma.Text = "" + countNum() + 1;
            string sql = "select MaDN from SinhVien where MaSV='" + MaSV + "' ";
            string MaDN = DataAccess.LayMotGT(sql);
            txtmadoanhnghiep.Text = MaDN;

            string sql1 = "select MaDeTai from QuaTrinh where MaSV='" + MaSV + "' ";
            string DeTai = DataAccess.LayMotGT(sql1);
            txtmadetai.Text = DeTai;

            dgvctqt.DataSource = DataAccess.GetTable("select * from CT_QuaTrinh where MaSV = '" + MaSV + "' ");
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
        private void DanhGiaCT_Load(object sender, EventArgs e)
        {
            loadform();
        }

        int countNum()
        {
            string sql = "select count(*) from CT_QuaTrinh";
            int count = 0;
            count = Convert.ToInt32(DataAccess.CountData(sql));
            return count;
        }

        public void them()
        {
            if (btnThem.Text == THEM)
            {
                //txtma.Enabled = true;
                Cbtuan.Enabled = true;
                //txtmasv.Enabled = true;
                txtmadetai.Enabled = true;
                richTextBox1.Enabled = true;
                txtdiem.Enabled = true;
                //dateTimePicker1.Enabled = true;
                //txtmadoanhnghiep.Enabled = true;

                richTextBox1.Clear();
                txtdiem.Clear();

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
                //txtma.Enabled = true;
                Cbtuan.Enabled = true;
                //txtmasv.Enabled = true;
                //txtmadetai.Enabled = true;
                richTextBox1.Enabled = true;
                txtdiem.Enabled = true;
                //dateTimePicker1.Enabled = true;
                //txtmadoanhnghiep.Enabled = true;

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
            DialogResult rs = MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin này", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.OK)
            {
                string sql = "delete from CT_QuaTrinh where MaCTQT=N'" + txtma.Text + "'";
                DataAccess.AddEditDelete(sql);

                dgvctqt.DataSource = DataAccess.GetTable("select * from CT_QuaTrinh where MaSV = '" + MaSV + "' ");
                MessageBox.Show("Đã xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnGhi_Click(object sender, EventArgs e)
        {
            int ma = countNum() + 1;
            if (btnThem.Text == HOATDONG)
            {
                string sql = "Insert into CT_QuaTrinh values(N'" +
                             ma + "', N'" +
                             Cbtuan.Text + "', N'" +
                             txtmasv.Text + "', N'" +
                             txtmadetai.Text + "', N'" +
                             richTextBox1.Text + "', N'" +
                             txtdiem.Text + "', N'" +
                             dateTimePicker1.Value.ToString("yyyy/MM/dd") + "', N'" +
                             txtmadoanhnghiep.Text + "' )";
                DataAccess.AddEditDelete(sql);
                dgvctqt.DataSource = DataAccess.GetTable("select * from CT_QuaTrinh where MaSV = '" + MaSV + "' ");
            }
            if (BtnSua.Text == HOATDONG)
            {
                DialogResult rs = MessageBox.Show("Bạn chắc chắn sửa thông tin này ? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    string sql = "update CT_QuaTrinh set Tuan =N'" +
                          Cbtuan.Text + "', MaSV =N'" +
                          txtmasv.Text + "', MaDeTai =N'" +
                          txtmadetai.Text + "', DanhGia =N'" +
                          richTextBox1.Text + "', Diem =N'" +
                          txtdiem.Text + "', Ngaydanhgia =N'" +
                          dateTimePicker1.Value.ToString("yyyy/MM/dd") + "', MaDN =N'" +
                          txtmadoanhnghiep.Text + "'  where MaCTQT=N'" +
                          txtma.Text + "'";
                    DataAccess.AddEditDelete(sql);
                    dgvctqt.DataSource = DataAccess.GetTable("select * from CT_QuaTrinh where MaSV = '" + MaSV + "' ");
                    MessageBox.Show("Đã sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
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

        private void btnreset_Click(object sender, EventArgs e)
        {
            btnThem.Text = THEM;
            BtnSua.Text = SUA;

            loadform();
        }

        private void dgvctqt_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvctqt.CurrentRow != null)
            {
                txtma.Text = dgvctqt.CurrentRow.Cells[0].Value.ToString();
                Cbtuan.Text = dgvctqt.CurrentRow.Cells[1].Value.ToString();
                txtmasv.Text = dgvctqt.CurrentRow.Cells[2].Value.ToString();
                txtmadetai.Text = dgvctqt.CurrentRow.Cells[3].Value.ToString();
                richTextBox1.Text = dgvctqt.CurrentRow.Cells[4].Value.ToString();
                txtdiem.Text = dgvctqt.CurrentRow.Cells[5].Value.ToString();
                dateTimePicker1.Value = (DateTime)dgvctqt.CurrentRow.Cells[6].Value;
                txtmadoanhnghiep.Text = dgvctqt.CurrentRow.Cells[7].Value.ToString();
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
