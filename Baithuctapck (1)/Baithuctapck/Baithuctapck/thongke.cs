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
using System.Windows.Forms.DataVisualization.Charting;

namespace Baithuctapck
{
    public partial class thongke : Form
    {
        string chucvu;
        string user;
        public thongke(string chucvu , string user)
        {
            InitializeComponent();
            this.chucvu = chucvu;
            this.user = user;
        }

        private void LoadChartData()
        {
            string conn = @"Data Source=.\SQLEXPRESS;Initial Catalog=db_thuctap;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();

                // Thực hiện truy vấn để lấy dữ liệu
                string query = "SELECT Diem, COUNT(*) AS SoLuong FROM QuaTrinh GROUP BY Diem";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Tạo một DataTable để chứa dữ liệu
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);

                        // Gán dữ liệu cho biểu đồ
                        chart1.DataSource = dataTable;
                        chart1.Series["Series1"].XValueMember = "SoLuong";
                        chart1.Series["Series1"].YValueMembers = "Diem";
                    }
                }
            }
        }
        private void CustomizeChart()
        {
            foreach (DataPoint dataPoint in chart1.Series["Series1"].Points)
            {
                // Tính phần trăm và hiển thị lên cột
                double percentage = (dataPoint.YValues[0] / chart1.Series["Series1"].Points.Sum(p => p.YValues[0])) * 100;
                dataPoint.Label = $"{percentage:F2}%";
            }
        }
        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void thongke_Load(object sender, EventArgs e)
        {
            LoadChartData();
            CustomizeChart();
            laygiatri();
        }

        public void laygiatri()
        {
            if(chucvu == "doanhnghiep")
            {
                string sql = "Select Count(*) from SinhVien where MaDN = '"+ user+"'";
                string laysl = DataAccess.LayMotGT(sql);
                lbsinhvien.Text = laysl;

                string sql1 = "Select Count(*) from GiangVien ";
                string laysl1 = DataAccess.LayMotGT(sql1);
                lblGiangvien.Text = laysl1;

                string sql2 = "Select Count(*) from DoanhNghiep where MaDN = '" + user + "'";
                string laysl2 = DataAccess.LayMotGT(sql2);
                lbdoanhnghiep.Text = laysl2;

                string sql3 = "Select Count(*) from DeTai where MaDN = '" + user + "'";
                string laysl3 = DataAccess.LayMotGT(sql3);
                Lbdetai.Text = laysl3;
            }
            else
            {
                string sql = "Select Count(*) from SinhVien";
                string laysl = DataAccess.LayMotGT(sql);
                lbsinhvien.Text = laysl;

                string sql1 = "Select Count(*) from GiangVien";
                string laysl1 = DataAccess.LayMotGT(sql1);
                lblGiangvien.Text = laysl1;

                string sql2 = "Select Count(*) from DoanhNghiep";
                string laysl2 = DataAccess.LayMotGT(sql2);
                lbdoanhnghiep.Text = laysl2;

                string sql3 = "Select Count(*) from DeTai";
                string laysl3 = DataAccess.LayMotGT(sql3);
                Lbdetai.Text = laysl3;
            }           
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel_croc_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            Thongkedetai a = new Thongkedetai(chucvu,user);
            a.Show();
        }

        private void panel_croc_Click(object sender, EventArgs e)
        {
            Thongkesinhvien b = new Thongkesinhvien(chucvu,user);
            b.Show();
        }

        private void panel_Cos_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel_Cos_Click(object sender, EventArgs e)
        {
            if (chucvu != "doanhnghiep")
            {
                Thongkedoanhnghiep c = new Thongkedoanhnghiep();
                c.Show();
            }
        }
    }
}
