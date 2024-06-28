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
    public partial class thongtinchitietthongbao : Form
    {
        public thongtinchitietthongbao(string ThongBao)
        {
            InitializeComponent();
            richTextBox1.Text = ThongBao;
        }
    }
}
