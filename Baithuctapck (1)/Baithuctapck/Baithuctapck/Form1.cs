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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //InitializeCenterPanel();
        }
        //private void InitializeCenterPanel()
        //{
        //    panel1 = new Panel();
        //    panel1.Dock = DockStyle.Fill;

        //    // Thêm Panel vào Form
        //    Controls.Add(panel1);
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            login a = new login();
            a.Show();
        }
        //private void AddForm(Form add)
        //{
        //    this.panel1.Controls.Clear();
        //    add.TopLevel = false;
        //    add.AutoScroll = true;
        //    add.FormBorderStyle = FormBorderStyle.None;
        //    add.Dock = DockStyle.Fill;
        //    this.Text = add.Text;
        //    this.panel1.Controls.Add(add);
        //    add.Show();
        //}

        private void Form1_Load(object sender, EventArgs e)
        {
            //login add = new login();
            //add.TopLevel = false;
            //add.FormBorderStyle = FormBorderStyle.None;
            //add.Dock = DockStyle.Fill;

            //// Xóa các điều khiển hiện tại trong Panel (nếu có)
            //panel1.Controls.Clear();

            //// Thêm Form vào Panel và hiển thị
            //AddForm(add);
            //add.Show();
        }
    }
}
