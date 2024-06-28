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
    public partial class qldetai : Form
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
        string user;
        public qldetai(string chucvu,string user)
        {
            InitializeComponent();
            this.chucvu = chucvu;
            this.user = user;
            datebd.Format = DateTimePickerFormat.Custom;
            datebd.CustomFormat = "yyyy/MM/dd";
            datekt.Format = DateTimePickerFormat.Custom;
            datekt.CustomFormat = "yyyy/MM/dd";
        }
        public void loadform()
        {
            txtmadt.Enabled = false;
            richTextBox1.Enabled = false;
            datebd.Enabled = false;
            datekt.Enabled = false;
            cbmaloai.Enabled = false;
            txtmadn.Enabled = false;

            if (chucvu == "doanhnghiep")
            {
                btnThem.Enabled = true;
                btnxoa.Enabled = true;
                BtnSua.Enabled = true;
                BtnGhi.Enabled = false;
                BtnHuy.Enabled = false;

                dgvdetai.DataSource = DataAccess.GetTable("select * from DeTai where MaDN = '"+user+"' ");
                dgvdetai.Columns[0].HeaderText = "Mã Đề Tài";
                dgvdetai.Columns[1].HeaderText = "Đề Tài";
                dgvdetai.Columns[2].HeaderText = "Ngày bắt đầu";
                dgvdetai.Columns[3].HeaderText = "Ngày kết thúc";
                dgvdetai.Columns[4].HeaderText = "Mã loại đề tài";
                dgvdetai.Columns[5].HeaderText = "Mã doanh nghiệp";


                dgvdetai.Columns[0].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvdetai.Columns[1].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvdetai.Columns[2].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvdetai.Columns[3].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvdetai.Columns[4].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.AllCells;
                dgvdetai.Columns[5].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;

                string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=db_thuctap;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT MaLoai,TenLoai FROM LoaiDT";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        cbmaloai.DataSource = dataTable;
                        cbmaloai.DisplayMember = "MaLoai";
                        cbtimkiem.DataSource = dataTable;
                        cbtimkiem.DisplayMember = "TenLoai";
                        cbtimkiem.ValueMember = "MaLoai";
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

                dgvdetai.DataSource = DataAccess.GetTable("select * from DeTai");
                dgvdetai.Columns[0].HeaderText = "Mã Đề Tài";
                dgvdetai.Columns[1].HeaderText = "Đề Tài";
                dgvdetai.Columns[2].HeaderText = "Ngày bắt đầu";
                dgvdetai.Columns[3].HeaderText = "Ngày kết thúc";
                dgvdetai.Columns[4].HeaderText = "Mã loại đề tài";
                dgvdetai.Columns[5].HeaderText = "Mã doanh nghiệp";


                dgvdetai.Columns[0].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvdetai.Columns[1].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvdetai.Columns[2].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvdetai.Columns[3].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvdetai.Columns[4].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.AllCells;
                dgvdetai.Columns[5].AutoSizeMode =
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
            //        cbdoanhnghiep.DataSource = dataTable;
            //        cbdoanhnghiep.DisplayMember = "MaDN";
            //    }
            //}
        }
        private void qldetai_Load(object sender, EventArgs e)
        {
            loadform();
        }

        public void them()
        {
            if (btnThem.Text == THEM)
            {
                //txtmadt.Enabled = true;
                richTextBox1.Enabled = true;
                datebd.Enabled = true;
                datekt.Enabled = true;
                cbmaloai.Enabled = true;
                //txtmadn.Enabled = true;

                txtmadn.Text = user;
                
                richTextBox1.Clear();

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
                richTextBox1.Enabled = true;
                datebd.Enabled = true;
                datekt.Enabled = true;
                cbmaloai.Enabled = true;
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

        private void btnxoa_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin về đề tài này", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.OK)
            {
                string sql = "delete from DeTai where MaDeTai=N'" + txtmadt.Text + "'";
                DataAccess.AddEditDelete(sql);

                dgvdetai.DataSource = DataAccess.GetTable("select * from DeTai where MaDN = '" + user + "' ");
                MessageBox.Show("Đã xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvdetai_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdetai.CurrentRow != null)
            {
                txtmadt.Text = dgvdetai.CurrentRow.Cells[0].Value.ToString();
                richTextBox1.Text = dgvdetai.CurrentRow.Cells[1].Value.ToString();
                datebd.Value = (DateTime)dgvdetai.CurrentRow.Cells[2].Value;
                datekt.Value = (DateTime)dgvdetai.CurrentRow.Cells[3].Value;
                cbmaloai.Text = dgvdetai.CurrentRow.Cells[4].Value.ToString();
                txtmadn.Text = dgvdetai.CurrentRow.Cells[5].Value.ToString();
            }
        }
        int countNum()
        {
            string sql = "select count(*) from DeTai";
            int count = 0;
            count = Convert.ToInt32(DataAccess.CountData(sql));
            return count;
        }

        private void BtnGhi_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == HOATDONG)
            {
                txtmadt.Text = "DT" + (countNum() + 1);
                string sql = "Insert into DeTai values(N'" +
                             txtmadt.Text + "', N'" +
                             richTextBox1.Text + "', N'" +
                             datebd.Value.ToString("yyyy/MM/dd") + "', N'" +
                             datekt.Value.ToString("yyyy/MM/dd") + "', N'" +
                             cbmaloai.Text + "', N'" +
                             txtmadn.Text + "' )";
                DataAccess.AddEditDelete(sql);
                dgvdetai.DataSource = DataAccess.GetTable("select * from DeTai where MaDN = '" + user + "' ");
            }
            if (BtnSua.Text == HOATDONG)
            {
                DialogResult rs = MessageBox.Show("Bạn chắc chắn sửa thông tin này ? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    string sql = "update DeTai set TenDeTai =N'" +
                          richTextBox1.Text + "', Ngaybatdau =N'" +
                          datebd.Value.ToString("yyyy/MM/dd") + "', Ngayketthuc =N'" +
                          datekt.Value.ToString("yyyy/MM/dd") + "', MaLoai =N'" +
                          cbmaloai.Text + "', MaDN =N'" +
                          txtmadn.Text + "' where MaDeTai=N'" +
                          txtmadt.Text + "'";
                    DataAccess.AddEditDelete(sql);
                    dgvdetai.DataSource = DataAccess.GetTable("select * from DeTai where MaDN = '" + user + "' ");
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
            txtmadt.Text = dgvdetai.Rows[i].Cells[0].Value.ToString();
            richTextBox1.Text = dgvdetai.Rows[i].Cells[1].Value.ToString();
            datebd.Value = (DateTime)dgvdetai.Rows[i].Cells[2].Value;
            datekt.Value = (DateTime)dgvdetai.Rows[i].Cells[3].Value;
            cbmaloai.Text = dgvdetai.Rows[i].Cells[4].Value.ToString();
            txtmadn.Text = dgvdetai.Rows[i].Cells[5].Value.ToString();
        }
        private void btnreset_Click(object sender, EventArgs e)
        {
            cbtimkiem.SelectedItem = "";
            btnThem.Text = THEM;
            BtnSua.Text = SUA;

            loadform();
            KhoiPhuc(cr);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            if (cbtimkiem.Text.Trim() == "")
                sql = "select * from DeTai where MaDN = '" + user + "' ";
            else
                sql = "select DeTai.* from DeTai inner join LoaiDT on DeTai.MaLoai = LoaiDT.MaLoai where LoaiDT.TenLoai = N'" +
                cbtimkiem.Text + "' and DeTai.MaDN = '"+user+"'";

            dgvdetai.DataSource = DataAccess.GetTable(sql);
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbmaloai_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cbmaloai_Click(object sender, EventArgs e)
        { 
            
        }

        private void cbmaloai_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string sql = "select TenLoai from LoaiDT where MaLoai='" + cbmaloai.Text + "' ";
            string tenloai = DataAccess.LayMotGT(sql);

            MessageBox.Show("Tên loại đề tài " + tenloai + "");
        }

        private void dgvdetai_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvdetai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
