using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Baithuctapck
{
    public partial class qlquatrinh : Form
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
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=db_thuctap;Integrated Security=True";
        private int cr;
        string chucvu;
        string user;
        public qlquatrinh(string chucvu,string user)
        {
            InitializeComponent();
            this.chucvu = chucvu;
            this.user = user;
        }
        private void loadform()
        {
            string sql = "UPDATE QuaTrinh SET Diem = (SELECT AVG(Diem) FROM CT_QuaTrinh WHERE CT_QuaTrinh.MaSV = QuaTrinh.MaSV)WHERE EXISTS(SELECT 1 FROM CT_QuaTrinh WHERE CT_QuaTrinh.MaSV = QuaTrinh.MaSV) ";
            DataAccess.AddEditDelete(sql); 

            txtmaqt.Enabled = false;
            cbmasv.Enabled = false;
            cbmadetai.Enabled = false;
            txtdiem.Enabled = false;
            richTextBox1.Enabled = false;
            txtmadn.Enabled = false;

            if (chucvu == "doanhnghiep")
            {
                btnThem.Enabled = true;
                btnxoa.Enabled = true;
                BtnSua.Enabled = true;
                BtnGhi.Enabled = false;
                BtnHuy.Enabled = false;

                dgvqt.DataSource = DataAccess.GetTable("select * from QuaTrinh where MaDN = '"+user+"' ");
                dgvqt.Columns[0].HeaderText = "Mã Quá Trình";
                dgvqt.Columns[1].HeaderText = "Mã Sinh Viên";
                dgvqt.Columns[2].HeaderText = "Mã Đề Tài";
                dgvqt.Columns[3].HeaderText = "Đánh Giá Quá Trình";
                dgvqt.Columns[4].HeaderText = "Điểm";
                dgvqt.Columns[5].HeaderText = "MaDN";

                dgvqt.Columns[0].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvqt.Columns[1].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvqt.Columns[2].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvqt.Columns[3].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvqt.Columns[4].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.AllCells;
                dgvqt.Columns[5].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.AllCells;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT MaSV FROM SinhVien where MaDN ='"+user+"' ";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        cbmasv.DataSource = dataTable;
                        cbmasv.DisplayMember = "MaSV";
                    }
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT MaDeTai FROM DeTai where MaDN = '" + user + "' ";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        cbmadetai.DataSource = dataTable;
                        cbmadetai.DisplayMember = "MaDeTai";
                    }
                }

            }
            else
            {
                btnThem.Enabled = false;
                btnxoa.Enabled = false;
                BtnSua.Enabled = false;
                BtnGhi.Enabled = false;
                BtnHuy.Enabled = false;

                dgvqt.DataSource = DataAccess.GetTable("select * from QuaTrinh");
                dgvqt.Columns[0].HeaderText = "Mã Quá Trình";
                dgvqt.Columns[1].HeaderText = "Mã Sinh Viên";
                dgvqt.Columns[2].HeaderText = "Mã Đề Tài";
                dgvqt.Columns[3].HeaderText = "Đánh Giá Quá Trình";
                dgvqt.Columns[4].HeaderText = "Điểm";
                dgvqt.Columns[5].HeaderText = "MaDN";

                dgvqt.Columns[0].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvqt.Columns[1].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvqt.Columns[2].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvqt.Columns[3].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvqt.Columns[4].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.AllCells;
                dgvqt.Columns[5].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.AllCells;            
            }
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    string query = "SELECT MaDN FROM DoanhNghiep";
            //    using (SqlCommand command = new SqlCommand(query, connection))
            //    {
            //        SqlDataAdapter adapter = new SqlDataAdapter(command);
            //        DataTable dataTable = new DataTable();
            //        adapter.Fill(dataTable);
            //        cbmadn.DataSource = dataTable;
            //        cbmadn.DisplayMember = "MaDN";
            //    }
            //}
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    string query = "SELECT MaDeTai FROM DeTai where MaDN = '"+txtmadn.Text+"' ";
            //    using (SqlCommand command = new SqlCommand(query, connection))
            //    {
            //        SqlDataAdapter adapter = new SqlDataAdapter(command);
            //        DataTable dataTable = new DataTable();
            //        adapter.Fill(dataTable);
            //        cbmadetai.DataSource = dataTable;
            //        cbmadetai.DisplayMember = "MaDeTai";
            //    }
            //}
        }
            private void qlquatrinh_Load(object sender, EventArgs e)
        {
            loadform();
        }
        public void them()
        {
            if (btnThem.Text == THEM)
            {
                txtmaqt.Enabled = true;
                cbmasv.Enabled = true;
                cbmadetai.Enabled = true;
                //txtdiem.Enabled = true;
                richTextBox1.Enabled = true;
                //txtmadn.Enabled = true;

                txtmaqt.Text = "QT" + (countNum() + 1);
                txtdiem.Clear();
                richTextBox1.Clear();
                cbmadetai.SelectedItem = "";
                cbmasv.SelectedItem = "";
                txtmadn.Text = user;

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
                cbmasv.Enabled = true;
                cbmadetai.Enabled = true;
                //txtdiem.Enabled = true;
                richTextBox1.Enabled = true;
                //txtmadn.Enabled = true;

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
        int countNum()
        {
            string sql = "select count(*) from DeTai";
            int count = 0;
            count = Convert.ToInt32(DataAccess.CountData(sql));
            return count;
        }
        private void btnxoa_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin về quá trình này", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.OK)
            {
                string sql = "delete from QuaTrinh where MaQT=N'" + txtmaqt.Text + "'";
                DataAccess.AddEditDelete(sql);

                dgvqt.DataSource = DataAccess.GetTable("select * from QuaTrinh where MaDN = '" + user + "'");
                MessageBox.Show("Đã xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnGhi_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == HOATDONG)
            {
                txtmaqt.Text = "QT" + (countNum() + 1);
                string ma = "QT" + (countNum() + 1);
                string sql = "Insert into QuaTrinh values(N'" +
                             ma + "', N'" +
                             cbmasv.Text + "', N'" +
                             cbmadetai.Text + "', N'" +
                             richTextBox1.Text + "', " +
                             0 +", N'" +
                             txtmadn.Text + "' )";
                DataAccess.AddEditDelete(sql);
                dgvqt.DataSource = DataAccess.GetTable("select * from QuaTrinh where MaDN = '" + user + "'");
            }
            if (BtnSua.Text == HOATDONG)
            {
                DialogResult rs = MessageBox.Show("Bạn chắc chắn sửa thông tin này ? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    string sql = "update QuaTrinh set MaSV =N'" +
                          cbmasv.Text + "', MaDeTai =N'" +
                          cbmadetai.Text + "', DanhGiaQT =N'" +
                          richTextBox1.Text + "', Diem =N'" +
                          txtdiem.Text + "', MaDN =N'" +
                          txtmadn.Text + "' where MaQT=N'" +
                          txtmaqt.Text + "'";
                    DataAccess.AddEditDelete(sql);
                    dgvqt.DataSource = DataAccess.GetTable("select * from QuaTrinh where MaDN = '" + user + "'");
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
        private void KhoiPhuc(int i)
        {
            txtmaqt.Text = dgvqt.Rows[i].Cells[0].Value.ToString();
            cbmasv.Text = dgvqt.Rows[i].Cells[1].Value.ToString();
            cbmadetai.Text = dgvqt.Rows[i].Cells[2].Value.ToString();
            richTextBox1.Text = dgvqt.Rows[i].Cells[3].Value.ToString();
            txtdiem.Text = dgvqt.Rows[i].Cells[4].Value.ToString();
            txtmadn.Text = dgvqt.Rows[i].Cells[5].Value.ToString();
        }
        private void btnreset_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();

            btnThem.Text = THEM;
            BtnSua.Text = SUA;

            loadform();
            KhoiPhuc(cr);
        }

        private void dgvqt_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvqt.CurrentRow != null)
            {
                txtmaqt.Text = dgvqt.CurrentRow.Cells[0].Value.ToString();
                cbmasv.Text = dgvqt.CurrentRow.Cells[1].Value.ToString();
                cbmadetai.Text = dgvqt.CurrentRow.Cells[2].Value.ToString();
                richTextBox1.Text = dgvqt.CurrentRow.Cells[3].Value.ToString();
                txtdiem.Text = dgvqt.CurrentRow.Cells[4].Value.ToString();
                txtmadn.Text = dgvqt.CurrentRow.Cells[5].Value.ToString();
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
                sql = "select * from QuaTrinh where MaDN = '" + user + "'";
            else
                sql = "select * from QuaTrinh where MaDN = '" + user + "' and MaSV like N'%" +
                txtTimKiem.Text + "%'";

            dgvqt.DataSource = DataAccess.GetTable(sql);
        }

        private void cbmasv_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
