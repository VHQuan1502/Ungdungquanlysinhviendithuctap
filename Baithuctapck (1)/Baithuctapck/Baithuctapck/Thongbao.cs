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
    public partial class Thongbao : Form
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
        public Thongbao(string chucvu)
        {
            InitializeComponent();
            this.chucvu = chucvu;
        }

        private void Thongbao_Load(object sender, EventArgs e)
        {
           
        }
        private void loadform()
        {
            richTextBox1.Enabled = false;

            btnThem.Enabled = true;
            btnxoa.Enabled = true;
            BtnSua.Enabled = true;
            BtnGhi.Enabled = false;
            BtnHuy.Enabled = false;

            dgvthongbao.DataSource = DataAccess.GetTable("select * from thongbao where dentu <> '"+chucvu+"'");
            dgvthongbao.Columns[0].HeaderText = "ID";
            dgvthongbao.Columns[1].HeaderText = "Thông Báo";
            dgvthongbao.Columns[2].HeaderText = "From";

            dgvthongbao.Columns[0].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvthongbao.Columns[1].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvthongbao.Columns[2].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
        }
            private void Thongbao_Load_1(object sender, EventArgs e)
        {
            loadform();
        }

        public void them()
        {
            if (btnThem.Text == THEM)
            {
                richTextBox1.Enabled = true;
   
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
                string sql = "delete from thongbao where ThongBao=N'" + richTextBox1.Text + "'";
                DataAccess.AddEditDelete(sql);

                dgvthongbao.DataSource = DataAccess.GetTable("select ThongBao,dentu from thongbao ");
                MessageBox.Show("Đã xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        int countNum()
        {
            string sql = "select count(*) from thongbao";
            int count = 0;
            count = Convert.ToInt32(DataAccess.CountData(sql));
            return count;
        }
        private void BtnGhi_Click(object sender, EventArgs e)
        {
            int matb = countNum() + 1;
            if (btnThem.Text == HOATDONG)
            {
                string sql = "Insert into thongbao values(N'"+matb+"',N'" +
                             richTextBox1.Text + "',N'"+chucvu+"' )";
                DataAccess.AddEditDelete(sql);
                dgvthongbao.DataSource = DataAccess.GetTable("select ThongBao,dentu from thongbao");
            }
            if (BtnSua.Text == HOATDONG)
            {
                DialogResult rs = MessageBox.Show("Bạn chắc chắn sửa thông tin này ? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    string sql = "update thongbao set ThongBao =N'" +
                          richTextBox1.Text + "' where ID=N'" +
                          txtid.Text + "'";
                    DataAccess.AddEditDelete(sql);
                    dgvthongbao.DataSource = DataAccess.GetTable("select * from DeTai");
                    MessageBox.Show("Đã sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dgvthongbao_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvthongbao.CurrentRow != null)
            {
                txtid.Text = dgvthongbao.CurrentRow.Cells[0].Value.ToString();
                richTextBox1.Text = dgvthongbao.CurrentRow.Cells[1].Value.ToString();
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
            txtid.Text = dgvthongbao.Rows[i].Cells[0].Value.ToString();
            richTextBox1.Text = dgvthongbao.Rows[i].Cells[1].Value.ToString();
        }
        private void btnreset_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            btnThem.Text = THEM;
            BtnSua.Text = SUA;

            loadform();
            KhoiPhuc(cr);
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvthongbao_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                string ThongBao = dgvthongbao.Rows[e.RowIndex].Cells[1].Value.ToString();

                thongtinchitietthongbao a = new thongtinchitietthongbao(ThongBao);
                a.Show();
            }
        }
    }
}
