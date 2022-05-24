using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureReda4er
{
    public partial class Form2 : Form
    {
        private System.Windows.Forms.Timer t = new();
        private Bitmap image2 = new Bitmap(256, 512);
        private Bitmap image2b;
        private Graphics image2bb;
        private Bitmap image_out;
        private Bitmap image_in;
        private Bitmap image2_og;
        private List<Task> tasks = new();
        private Form2.update_delegate update_method;
        private byte[] imagebytesin;
        private byte[] imagebytesout;
        private Pan pann;
        public Form2(Bitmap image1, int ww, int hh)
        {
            InitializeComponent();
            update_method = new Form2.update_delegate(Run);
            Bitmap bitmap = new(1, 1);
            Bitmap image2;
            image2 = new Bitmap(image1);
            image_in = new Bitmap(ww, hh, PixelFormat.Format24bppRgb);
            image_in.SetResolution(image1.HorizontalResolution, image1.VerticalResolution);
            image_out = new Bitmap(ww, hh, PixelFormat.Format24bppRgb);
            image_out.SetResolution(image1.HorizontalResolution, image1.VerticalResolution);

            using Graphics graphics = Graphics.FromImage((Image)image_in);
            graphics.DrawImageUnscaled((Image)image1, 0, 0);
            using (Graphics.FromImage((Image)image_out))
            {
                graphics.DrawImageUnscaled((Image)image1, 0, 0);
                image1.Dispose();
                imagebytesin = GetImgBytes24(image_in);
                imagebytesout = new byte[imagebytesin.Length];
                int width1 = pictureBox2.Size.Width;
                Size size = pictureBox2.Size;
                int height1 = size.Height;
                image2b = new Bitmap(width1, height1);
                size = pictureBox2.Size;
                int width2 = size.Width;
                size = pictureBox2.Size;
                int height2 = size.Height;
                image2_og = new Bitmap(width2, height2);
                image2bb = Graphics.FromImage((Image)image2b);
                image2bb.InterpolationMode = InterpolationMode.NearestNeighbor;
                pictureBox2.Image = (Image)image2b;
                pann = new Pan();
                panel1.Controls.Add((Control)pann);
                pann.Size = panel1.Size;
                pann.Location = new System.Drawing.Point(0, 0);
                pictureBox1.Image = (Image)image_out;
                Gistogramma();
                pann.changed_event += (Pan.changed_delegate)(pp => tasks.Add(new Task((Action)(() => Process(pp)))));
                new Task((Action)(() =>
                {
                    while (true)
                    {
                        if (tasks.Count >= 1)
                        {
                            tasks[tasks.Count - 1].RunSynchronously();
                            tasks.Clear();
                        }
                        Thread.Sleep(1);
                    }
                })).Start();
                Load += (EventHandler)((s, a) => pann.Emit());
            }
        }

        public void Run(object[] args)
        {
            
            pictureBox1.Refresh();
            pictureBox2.Refresh();
        }

        static byte[] GetImgBytes24(Bitmap img)
        {
            byte[] bytes = new byte[img.Width * img.Height * 3];  //выделяем память под массив байтов
            var data = img.LockBits(new Rectangle(0, 0, img.Width, img.Height),  //блокируем участок памати, занимаемый изображением
                ImageLockMode.ReadOnly,
                img.PixelFormat);
            Marshal.Copy(data.Scan0, bytes, 0, bytes.Length);  //копируем байты изображения в массив
            img.UnlockBits(data);   //разблокируем изображение
            return bytes; //возвращаем байты
        }

        public void Process(Interpol li)
        {
            Parallel.For(0, imagebytesin.Length, (Action<int>)(i => imagebytesout[i] = (byte)((double)byte.MaxValue - (double)byte.MaxValue * li.F(1.0 * (double)imagebytesin[i] / (double)byte.MaxValue))));
            Form2.writeImageBytes(image_out, imagebytesout);
            int[] n = new int[256];
            Parallel.For(0, imagebytesin.Length / 3, (Action<int>)(i => Interlocked.Increment(ref n[(int)((double)((int)imagebytesout[i * 3] + (int)imagebytesout[i * 3 + 1] + (int)imagebytesout[i * 3 + 2]) / 3.0)])));
            int num1 = ((IEnumerable<int>)n).Max();
            using Graphics graphics = Graphics.FromImage((Image)image2);
            graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            graphics.FillRectangle(Brushes.White, 0, 0, image2.Width, image2.Height);
            double num2 = 1.0 * (double)image2.Height / (double)num1;
            for (int index = 0; index < n.Length; ++index)
                graphics.DrawLine(Pens.Black, index, image2.Height - 1, index, (int)((double)(image2.Height - 1) - (double)n[index] * num2));
            image2bb.DrawImage((Image)image2, 0, 0, image2b.Width - 1, image2b.Height - 1);
            Invoke((Delegate)update_method, (object)new object[0]);
        }

        public void Gistogramma()
        {
            int[] n = new int[256];
            using Bitmap bitmap = new(256, 256);
            Parallel.For(0, imagebytesin.Length / 3, (Action<int>)(i => Interlocked.Increment(ref n[(int)((double)((int)imagebytesin[i * 3] + (int)imagebytesin[i * 3 + 1] + (int)imagebytesin[i * 3 + 2]) / 3.0)])));
            int num1 = ((IEnumerable<int>)n).Max();
            using Graphics graphics1 = Graphics.FromImage((Image)bitmap);
            graphics1.InterpolationMode = InterpolationMode.NearestNeighbor;
            graphics1.FillRectangle(Brushes.White, 0, 0, image2.Width, image2.Height);
            double num2 = 1.0 * (double)bitmap.Height / (double)num1;
            using Pen pen = new(Color.FromArgb(0, 0, 0));
            for (int index = 0; index < n.Length; ++index)
                graphics1.DrawLine(pen, index, bitmap.Height - 1, index, (int)((double)(bitmap.Height - 1) - (double)n[index] * num2));
            using Graphics graphics2 = Graphics.FromImage((Image)image2_og);
            graphics2.InterpolationMode = InterpolationMode.NearestNeighbor;
            graphics2.DrawImage((Image)bitmap, 0, 0, image2_og.Width - 1, image2_og.Height - 1);
        }

        static void writeImageBytes(Bitmap img, byte[] bytes)
        {
            var data = img.LockBits(new Rectangle(0, 0, img.Width, img.Height),  //блокируем участок памати, занимаемый изображением
                ImageLockMode.WriteOnly,
                img.PixelFormat);
            Marshal.Copy(bytes, 0, data.Scan0, bytes.Length); //копируем байты массива в изображение

            img.UnlockBits(data);  //разблокируем изображение
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Close();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            using SaveFileDialog saveFileFialog = new SaveFileDialog();
            saveFileFialog.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileFialog.Filter = "Картинки (png, jpg, bmp, gif) |*.png;*.jpg;*.bmp;*.gif|All files (*.*)|*.*";
            saveFileFialog.RestoreDirectory = true;

            if (saveFileFialog.ShowDialog() == DialogResult.OK)
            {
                if (image_out != null)
                {

                    image_out.Save(saveFileFialog.FileName);
                }
            }
        }
        public delegate void update_delegate(object[] arr);
    }
}
