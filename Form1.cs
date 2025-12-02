using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            BT5 bt5 = new BT5();
            bt5.Show();
            Button btn = sender as Button;
            btn.BackColor = Color.LightGreen;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BT3 bt3 = new BT3();
            bt3.Show();
            Button btn = sender as Button;
            btn.BackColor = Color.LightGreen;
        }
    }
}
