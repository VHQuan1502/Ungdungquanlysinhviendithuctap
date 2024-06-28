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
    public partial class Taikhoan : Form
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
        public Taikhoan()
        {
            InitializeComponent();
        }
        public void loadform()
        {
            txttk.Enabled = false;
            txtmk.Enabled = false;
            comboBox1.Enabled = false;

                btnThem.Enabled = true;
                BtnGhi.Enabled = false;

            dgvtk.DataSource = DataAccess.GetTable("select * from taikhoan");
            dgvtk.Columns[0].HeaderText = "ID";
            dgvtk.Columns[1].HeaderText = "Tên đăng nhập";
            dgvtk.Columns[2].HeaderText = "Mật khẩu";
            dgvtk.Columns[3].HeaderText = "Chức vụ";


            dgvtk.Columns[0].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvtk.Columns[1].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvtk.Columns[2].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvtk.Columns[3].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
        }
        private void Taikhoan_Load(object sender, EventArgs e)
        {
            loadform();
        }
        public void them()
        {
            if (btnThem.Text == THEM)
            {
                txttk.Enabled = true;
                txtmk.Enabled = true;
                comboBox1.Enabled = true;

                txttk.Clear();
                txtmk.Clear();

                btnThem.Text = HUY;
                BtnGhi.Enabled = true;
            }
            else
            {
                txttk.Enabled = false;
                txtmk.Enabled = false;
                comboBox1.Enabled = false;

                KhoiPhuc(cr);

                btnThem.Text = THEM;
                BtnGhi.Enabled = false;
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            them();
        }
        int countNum()
        {
            string sql = "select count(*) from taikhoan";
            int count = 0;
            count = Convert.ToInt32(DataAccess.CountData(sql));
            return count;
        }
        private void BtnGhi_Click(object sender, EventArgs e)
        {
            int id = countNum() + 1;
            if (btnThem.Text == HUY)
            { 
                string sql = "Insert into taikhoan values(N'" +
                             id + "', N'" +
                             txttk.Text + "', N'" +
                             txtmk.Text + "', N'" +
                             comboBox1.Text + "' )";
                DataAccess.AddEditDelete(sql);
                dgvtk.DataSource = DataAccess.GetTable("select * from taikhoan");
            }
        }

        private void dgvtk_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvtk.CurrentRow != null)
            {
                txtid.Text = dgvtk.CurrentRow.Cells[0].Value.ToString();
                txttk.Text = dgvtk.CurrentRow.Cells[1].Value.ToString();
                txtmk.Text = dgvtk.CurrentRow.Cells[2].Value.ToString();
                comboBox1.Text = dgvtk.CurrentRow.Cells[3].Value.ToString();
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.OK)
            {
                string sql = "delete from taikhoan where ID=N'" + txtid.Text + "'";
                DataAccess.AddEditDelete(sql);

                dgvtk.DataSource = DataAccess.GetTable("select * from taikhoan");
                MessageBox.Show("Đã xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void KhoiPhuc(int i)
        {
            txtid.Text = dgvtk.Rows[i].Cells[0].Value.ToString();
            txttk.Text = dgvtk.Rows[i].Cells[1].Value.ToString();
            txtmk.Text = dgvtk.Rows[i].Cells[2].Value.ToString();
            comboBox1.Text = dgvtk.Rows[i].Cells[3].Value.ToString();
        }
        private void btnreset_Click(object sender, EventArgs e)
        {
            //txtTimKiem.Clear();
            //btnThem.Text = THEM;

            //loadform();
            //KhoiPhuc(cr);

            string sql = "UPDATE taikhoan SET pass = '123' WHERE id = '"+txtid.Text+"'; ";
            DataAccess.AddEditDelete(sql);
            dgvtk.DataSource = DataAccess.GetTable("select * from taikhoan");
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            them();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtTimKiem.Text.Trim() == "")
                sql = "select * from taikhoan";
            else
                sql = "select * from taikhoan where username like N'%" +
                txtTimKiem.Text + "%'";

            dgvtk.DataSource = DataAccess.GetTable(sql);
        }
    }
}
