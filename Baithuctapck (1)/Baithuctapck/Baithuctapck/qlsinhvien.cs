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
using System.IO;
using OfficeOpenXml;

namespace Baithuctapck
{
    public partial class qlsinhvien : Form
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
        string user;
        string chucvu;
        public qlsinhvien(string chucvu, string user)
        {
            InitializeComponent();
            this.user = user;
            this.chucvu = chucvu;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy/MM/dd";
        }
        private void loadform()
        {
            txtmasv.Enabled = false;
            txthoten.Enabled = false;
            cbgioitinh.Enabled = false;
            dateTimePicker1.Enabled = false;
            txtquequan.Enabled = false;
            txtemail.Enabled = false;
            txtsdt.Enabled = false;
            txtdiemtb.Enabled = false;
            txtlophoc.Enabled = false;
            txttruonghoc.Enabled = false;
            cbdoanhnghiep.Enabled = false;
            cbgiangvien.Enabled = false;

            btnThem.Enabled = true;
            btnxoa.Enabled = true;
            BtnSua.Enabled = true;
            BtnGhi.Enabled = false;
            BtnHuy.Enabled = false;

            if(chucvu == "doanhnghiep")
            {
                dgvsv.DataSource = DataAccess.GetTable("select * from SinhVien where MaDN = '"+user+"'");
                dgvsv.Columns[0].HeaderText = "Mã Sinh Viên";
                dgvsv.Columns[1].HeaderText = "Họ Tên Sinh Viên";
                dgvsv.Columns[2].HeaderText = "Giới Tính";
                dgvsv.Columns[3].HeaderText = "Ngày Sinh";
                dgvsv.Columns[4].HeaderText = "Quê Quán";
                dgvsv.Columns[5].HeaderText = "Email";
                dgvsv.Columns[6].HeaderText = "Số điện thoại";
                dgvsv.Columns[7].HeaderText = "Điểm trung bình";
                dgvsv.Columns[8].HeaderText = "Lớp";
                dgvsv.Columns[9].HeaderText = "Trường";
                dgvsv.Columns[10].HeaderText = "MaDN";
                dgvsv.Columns[11].HeaderText = "MaGV";

                dgvsv.Columns[0].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvsv.Columns[1].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvsv.Columns[2].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvsv.Columns[3].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvsv.Columns[4].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.AllCells;
                dgvsv.Columns[5].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.AllCells;
                dgvsv.Columns[6].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.AllCells;
                dgvsv.Columns[7].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.AllCells;
                dgvsv.Columns[8].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.AllCells;
                dgvsv.Columns[9].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.AllCells;
                dgvsv.Columns[10].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.AllCells;
                dgvsv.Columns[11].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.AllCells;
            }
            else
            {
                dgvsv.DataSource = DataAccess.GetTable("select * from SinhVien");
                dgvsv.Columns[0].HeaderText = "Mã Sinh Viên";
                dgvsv.Columns[1].HeaderText = "Họ Tên Sinh Viên";
                dgvsv.Columns[2].HeaderText = "Giới Tính";
                dgvsv.Columns[3].HeaderText = "Ngày Sinh";
                dgvsv.Columns[4].HeaderText = "Quê Quán";
                dgvsv.Columns[5].HeaderText = "Email";
                dgvsv.Columns[6].HeaderText = "Số điện thoại";
                dgvsv.Columns[7].HeaderText = "Điểm trung bình";
                dgvsv.Columns[8].HeaderText = "Lớp";
                dgvsv.Columns[9].HeaderText = "Trường";
                dgvsv.Columns[10].HeaderText = "MaDN";
                dgvsv.Columns[11].HeaderText = "MaGV";

                dgvsv.Columns[0].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvsv.Columns[1].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvsv.Columns[2].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvsv.Columns[3].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvsv.Columns[4].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.AllCells;
                dgvsv.Columns[5].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.AllCells;
                dgvsv.Columns[6].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.AllCells;
                dgvsv.Columns[7].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.AllCells;
                dgvsv.Columns[8].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.AllCells;
                dgvsv.Columns[9].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.AllCells;
                dgvsv.Columns[10].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.AllCells;
                dgvsv.Columns[11].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.AllCells;

                //string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=db_thuctap;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT MaDN FROM DoanhNghiep";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        cbdoanhnghiep.DataSource = dataTable;
                        cbdoanhnghiep.DisplayMember = "MaDN";
                    }
                }
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT MaGV FROM GiangVien";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        cbgiangvien.DataSource = dataTable;
                        cbgiangvien.DisplayMember = "MaGV";
                    }
                }                  
        }
        private void qlsinhvien_Load(object sender, EventArgs e)
        {
            loadform();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
               
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có chắc chắn muốn thoát", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                this.Close();
            }
        }
        public void them()
        {
            if (btnThem.Text == THEM)
            {
                txtmasv.Enabled = true;
                txthoten.Enabled = true;
                cbgioitinh.Enabled = true;
                dateTimePicker1.Enabled = true;
                txtquequan.Enabled = true;
                txtemail.Enabled = true;
                txtsdt.Enabled = true;
                txtdiemtb.Enabled = true;
                txtlophoc.Enabled = true;
                txttruonghoc.Enabled = true;
                cbdoanhnghiep.Enabled = true;
                cbgiangvien.Enabled = true;

                txtmasv.Clear();
                txthoten.Clear();
                txtquequan.Clear();
                txtsdt.Clear();
                txtemail.Clear();
                txtdiemtb.Clear();
                txtlophoc.Clear();
                txttruonghoc.Clear();

                btnThem.Text = HOATDONG;
                BtnSua.Enabled = false;
                btnxoa.Enabled = false;
                BtnGhi.Enabled = true;
                BtnHuy.Enabled = true;
                btnThem.Enabled = false;
            }
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            them();
        }

        private void dgvsv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvsv.CurrentRow != null)
            {
                txtmasv.Text = dgvsv.CurrentRow.Cells[0].Value.ToString();
                txthoten.Text = dgvsv.CurrentRow.Cells[1].Value.ToString();
                cbgioitinh.Text = dgvsv.CurrentRow.Cells[2].Value.ToString();
                dateTimePicker1.Value = (DateTime)dgvsv.CurrentRow.Cells[3].Value;
                txtquequan.Text = dgvsv.CurrentRow.Cells[4].Value.ToString();
                txtemail.Text = dgvsv.CurrentRow.Cells[5].Value.ToString();
                txtsdt.Text = dgvsv.CurrentRow.Cells[6].Value.ToString();
                txtdiemtb.Text = dgvsv.CurrentRow.Cells[7].Value.ToString();
                txtlophoc.Text = dgvsv.CurrentRow.Cells[8].Value.ToString();
                txttruonghoc.Text = dgvsv.CurrentRow.Cells[9].Value.ToString();
                cbdoanhnghiep.Text = dgvsv.CurrentRow.Cells[10].Value.ToString();
                cbgiangvien.Text = dgvsv.CurrentRow.Cells[11].Value.ToString();
            }
        }

        private void BtnGhi_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == HOATDONG)
            {
                string sql = "Insert into SinhVien values(N'" +
                             txtmasv.Text + "', N'" +
                             txthoten.Text + "', N'" +
                             cbgioitinh.Text + "', N'" +
                             dateTimePicker1.Value.ToString("yyyy/MM/dd") + "', N'" +
                             txtquequan.Text + "', N'" +
                             txtemail.Text + "', N'" +
                             txtsdt.Text + "', N'" +
                             txtdiemtb.Text + "', N'" +
                             txtlophoc.Text + "', N'" +
                             txttruonghoc.Text + "', N'" +
                             cbdoanhnghiep.Text + "', N'" +
                             cbgiangvien.Text + "' )";
                DataAccess.AddEditDelete(sql);
                dgvsv.DataSource = DataAccess.GetTable("select * from SinhVien");
            }
            if (BtnSua.Text == HOATDONG)
            {
                DialogResult rs = MessageBox.Show("Bạn chắc chắn sửa thông tin này ? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    string sql = "update SinhVien set HoTen =N'" +
                          txthoten.Text + "', GioiTinh =N'" +
                          cbgioitinh.Text + "', NgaySinh =N'" +
                          dateTimePicker1.Value.ToString("yyyy/MM/dd") + "', QueQuan =N'" +
                          txtquequan.Text + "', Email =N'" +
                          txtemail.Text + "', SDT =N'" +
                          txtsdt.Text + "', DiemTB =N'" +
                          txtdiemtb.Text + "', Lop =N'" +
                          txtlophoc.Text + "', Truong =N'" +
                          txttruonghoc.Text + "', MaDN =N'" +
                          cbdoanhnghiep.Text + "', MaGV =N'" +
                          cbgiangvien.Text + "' where MaSV=N'" +
                          txtmasv.Text + "'";
                    DataAccess.AddEditDelete(sql);
                    dgvsv.DataSource = DataAccess.GetTable("select * from SinhVien");
                    MessageBox.Show("Đã sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void sua()
        {
            if (btnThem.Text == THEM)
            {
                txthoten.Enabled = true;
                cbgioitinh.Enabled = true;
                dateTimePicker1.Enabled = true;
                txtquequan.Enabled = true;
                txtemail.Enabled = true;
                txtsdt.Enabled = true;
                txtdiemtb.Enabled = true;
                txtlophoc.Enabled = true;
                txttruonghoc.Enabled = true;
                cbdoanhnghiep.Enabled = true;
                cbgiangvien.Enabled = true;

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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtTimKiem.Text.Trim() == "")
                sql = "select * from SinhVien";
            else
                sql = "select * from SinhVien where HoTen like N'%" +
                txtTimKiem.Text + "%'";

            dgvsv.DataSource = DataAccess.GetTable(sql);
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
            txtmasv.Text = dgvsv.Rows[i].Cells[0].Value.ToString();
            txthoten.Text = dgvsv.Rows[i].Cells[1].Value.ToString();
            cbgioitinh.Text = dgvsv.Rows[i].Cells[2].Value.ToString();
            dateTimePicker1.Value = (DateTime)dgvsv.Rows[i].Cells[3].Value;
            txtquequan.Text = dgvsv.Rows[i].Cells[4].Value.ToString();
            txtemail.Text = dgvsv.Rows[i].Cells[5].Value.ToString();
            txtsdt.Text = dgvsv.Rows[i].Cells[6].Value.ToString();
            txtdiemtb.Text = dgvsv.Rows[i].Cells[7].Value.ToString();
            txtlophoc.Text = dgvsv.Rows[i].Cells[8].Value.ToString();
            txttruonghoc.Text = dgvsv.Rows[i].Cells[9].Value.ToString();
            cbdoanhnghiep.Text = dgvsv.Rows[i].Cells[10].Value.ToString();
            cbgiangvien.Text = dgvsv.Rows[i].Cells[11].Value.ToString();
        }
        private void btnreset_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();

            btnThem.Text = THEM;
            BtnSua.Text = SUA;

            loadform();
            KhoiPhuc(cr);
        }

        private void dgvsv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string MaSV = dgvsv.Rows[e.RowIndex].Cells[0].Value.ToString();
                string HoTen = dgvsv.Rows[e.RowIndex].Cells[1].Value.ToString();
                string GioiTinh = dgvsv.Rows[e.RowIndex].Cells[2].Value.ToString();
                string NgaySinh = dgvsv.Rows[e.RowIndex].Cells[3].Value.ToString();
                string QueQuan = dgvsv.Rows[e.RowIndex].Cells[4].Value.ToString();
                string Email = dgvsv.Rows[e.RowIndex].Cells[5].Value.ToString();
                string SDT = dgvsv.Rows[e.RowIndex].Cells[6].Value.ToString();
                string DiemTB = dgvsv.Rows[e.RowIndex].Cells[7].Value.ToString();
                string Lop = dgvsv.Rows[e.RowIndex].Cells[8].Value.ToString();
                string Truong = dgvsv.Rows[e.RowIndex].Cells[9].Value.ToString();
                string MaDN = dgvsv.Rows[e.RowIndex].Cells[10].Value.ToString();
                string MaGV = dgvsv.Rows[e.RowIndex].Cells[11].Value.ToString();


                thongtinchitietsinhvien a = new thongtinchitietsinhvien(MaSV, HoTen, GioiTinh, NgaySinh, QueQuan, Email, SDT,DiemTB,Lop,Truong,MaDN,MaGV);
                a.ShowDialog();
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin về sinh viên này", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.OK)
            {
                string sql = "delete from QuaTrinh where MaSV=N'" + txtmasv.Text + "'";
                DataAccess.AddEditDelete(sql);
                string sql1 = "delete from SinhVien where MaSV=N'" + txtmasv.Text + "'";
                DataAccess.AddEditDelete(sql1);

                dgvsv.DataSource = DataAccess.GetTable("select * from SinhVien");
                MessageBox.Show("Đã xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ExportToExcel(DataGridView dataGridView)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files|*.xlsx";
            saveFileDialog.Title = "Save Excel File";
            saveFileDialog.FileName = "exported_data.xlsx"; // Tên mặc định cho file Excel

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                using (ExcelPackage excelPackage = new ExcelPackage())
                {
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");

                    // Ghi dữ liệu từ DataGridView vào file Excel
                    for (int row = 0; row < dataGridView.Rows.Count; row++)
                    {
                        for (int col = 0; col < dataGridView.Columns.Count; col++)
                        {
                            worksheet.Cells[row + 1, col + 1].Value = dataGridView.Rows[row].Cells[col].Value;
                        }
                    }

                    // Lưu file Excel
                    FileInfo excelFile = new FileInfo(filePath);
                    excelPackage.SaveAs(excelFile);
                }

                MessageBox.Show("Export completed successfully.", "Export to Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExP_Click(object sender, EventArgs e)
        {
            ExportToExcel(dgvsv);
        }
    }
}
