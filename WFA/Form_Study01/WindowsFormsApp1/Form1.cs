using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //MessageBox.Show("Hellow, world!");

            textBox_print.Text = "멀티\r\n라인\r\n텍스트박스\r\n입니다.";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
