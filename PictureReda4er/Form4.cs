using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureReda4er
{
    public partial class Form4 : Form
    {
        private Bitmap img;
        private int height;
        private int width;
        public Form4(Bitmap image, int ww, int hh)
        {
            InitializeComponent();
            img = image;
            height = hh;
            width = ww;
            pictureBox1.Image = img;
            pictureBox2.Image = img;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = ImgFuncs.MatrixFilter((Bitmap)pictureBox2.Image, textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Некорректный ввод данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int r = Convert.ToInt32(textBox2.Text);
                double sig = Convert.ToDouble(textBox3.Text);
                textBox1.Text = Functions.GetGaussMat(r, sig);
            }
            catch
            {
                MessageBox.Show("Некорректный ввод данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using SaveFileDialog saveFileFialog = new SaveFileDialog();
            saveFileFialog.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileFialog.Filter = "Картинки (png, jpg, bmp, gif) |*.png;*.jpg;*.bmp;*.gif|All files (*.*)|*.*";
            saveFileFialog.RestoreDirectory = true;

            if (saveFileFialog.ShowDialog() == DialogResult.OK)
            {
                if (img != null)
                {
                    img.Save(saveFileFialog.FileName);
                }
            }
        }
    }
}
