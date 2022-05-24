using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureReda4er
{
    public partial class Form5 : Form
    {
        private Bitmap img;
        public Form5(Bitmap image, int ww, int hh)
        {
            InitializeComponent();
            img = image;
            pictureBox1.Image = img;
            pictureBox2.Image = img;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int size = Convert.ToInt32(textBox1.Text);
                if (size < 1)
                    throw new ArgumentNullException(null);
                pictureBox1.Image = ImgFuncs.Median((Bitmap)pictureBox2.Image, size);
            }
            catch
            {
                MessageBox.Show("Некорректный ввод данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void button2_Click(object sender, EventArgs e)
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
