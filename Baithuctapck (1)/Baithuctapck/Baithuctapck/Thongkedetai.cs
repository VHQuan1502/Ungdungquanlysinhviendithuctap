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
    public partial class Thongkedetai : Form
    {
        string chucvu;
        string user;
        public Thongkedetai(string chucvu , string user)
        {
            InitializeComponent();
            this.chucvu = chucvu;
            this.user = user;
        }

        private void Thongkedetai_Load(object sender, EventArgs e)
        {
            if(chucvu == "doanhnghiep")
            {
                dgvde1.DataSource = DataAccess.GetTable("SELECT DeTai.* FROM DeTai JOIN QuaTrinh ON DeTai.MaDeTai = QuaTrinh.MaDeTai where DeTai.MaDN ='"+user+"'");
                dgvde1.Columns[0].HeaderText = "Mã Đề Tài";
                dgvde1.Columns[1].HeaderText = "Đề Tài";
                dgvde1.Columns[2].HeaderText = "Ngày bắt đầu";
                dgvde1.Columns[3].HeaderText = "Ngày kết thúc";
                dgvde1.Columns[4].HeaderText = "Mã loại đề tài";
                dgvde1.Columns[5].HeaderText = "Mã doanh nghiệp";


                dgvde1.Columns[0].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvde1.Columns[1].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvde1.Columns[2].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvde1.Columns[3].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvde1.Columns[4].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.AllCells;
                dgvde1.Columns[5].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;


                dgvde2.DataSource = DataAccess.GetTable("SELECT DeTai.* FROM DeTai LEFT JOIN QuaTrinh ON DeTai.MaDeTai = QuaTrinh.MaDeTai WHERE QuaTrinh.MaDeTai IS NULL and DeTai.MaDN ='" + user + "'");
                dgvde2.Columns[0].HeaderText = "Mã Đề Tài";
                dgvde2.Columns[1].HeaderText = "Đề Tài";
                dgvde2.Columns[2].HeaderText = "Ngày bắt đầu";
                dgvde2.Columns[3].HeaderText = "Ngày kết thúc";
                dgvde2.Columns[4].HeaderText = "Mã loại đề tài";
                dgvde2.Columns[5].HeaderText = "Mã doanh nghiệp";


                dgvde2.Columns[0].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvde2.Columns[1].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvde2.Columns[2].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvde2.Columns[3].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvde2.Columns[4].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.AllCells;
                dgvde2.Columns[5].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
            }
            else
            {
                dgvde1.DataSource = DataAccess.GetTable("SELECT DeTai.* FROM DeTai JOIN QuaTrinh ON DeTai.MaDeTai = QuaTrinh.MaDeTai");
                dgvde1.Columns[0].HeaderText = "Mã Đề Tài";
                dgvde1.Columns[1].HeaderText = "Đề Tài";
                dgvde1.Columns[2].HeaderText = "Ngày bắt đầu";
                dgvde1.Columns[3].HeaderText = "Ngày kết thúc";
                dgvde1.Columns[4].HeaderText = "Mã loại đề tài";
                dgvde1.Columns[5].HeaderText = "Mã doanh nghiệp";


                dgvde1.Columns[0].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvde1.Columns[1].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvde1.Columns[2].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvde1.Columns[3].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvde1.Columns[4].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.AllCells;
                dgvde1.Columns[5].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;


                dgvde2.DataSource = DataAccess.GetTable("SELECT DeTai.* FROM DeTai LEFT JOIN QuaTrinh ON DeTai.MaDeTai = QuaTrinh.MaDeTai WHERE QuaTrinh.MaDeTai IS NULL");
                dgvde2.Columns[0].HeaderText = "Mã Đề Tài";
                dgvde2.Columns[1].HeaderText = "Đề Tài";
                dgvde2.Columns[2].HeaderText = "Ngày bắt đầu";
                dgvde2.Columns[3].HeaderText = "Ngày kết thúc";
                dgvde2.Columns[4].HeaderText = "Mã loại đề tài";
                dgvde2.Columns[5].HeaderText = "Mã doanh nghiệp";


                dgvde2.Columns[0].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvde2.Columns[1].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvde2.Columns[2].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvde2.Columns[3].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgvde2.Columns[4].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.AllCells;
                dgvde2.Columns[5].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
            }
        }            
    }
}
