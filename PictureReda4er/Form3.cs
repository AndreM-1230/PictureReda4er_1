using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureReda4er
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            label1.BackColor = Color.Transparent;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer1.Stop();
            timer2.Enabled = false;
            timer2.Stop();
            this.Hide();
            Form1 frm1 = new Form1();
            frm1.ShowDialog();
            this.Close();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label1.Text = label1.Text + ".";
            if (label1.Text == "Загрузка...")
            {
                label1.Text = "Загрузка";
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            timer1.Interval = 3000;
            timer1.Enabled = true;
            timer1.Start();
            timer2.Interval = 200;
            timer2.Enabled = true;
            timer2.Start();
        }
    }
}
