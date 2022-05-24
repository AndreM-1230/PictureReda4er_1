using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;



namespace PictureReda4er
{
    public partial class Form1 : Form
    {
        
        private Bitmap image1 = null;
        private Bitmap image2 = null;
        private Bitmap image3 = null;
        private Bitmap image_tmp = null;
        private Bitmap image2_tmp = null;
        private Bitmap image3_tmp = null;
        public byte[] input_bytes = null; //пустой массивчик байт
        public byte[] input_bytes1 = null; //пустой массивчик байт
        public byte[] bytes = null; //пустой массивчик байт
        public byte[] bytesHist = null; //пустой массивчик байт
        public byte[] bytesHist1 = null; //пустой массивчик байт
        public byte[] bytesb = null; //пустой массивчик байт
        public int qq = 0;


        public static int Clamp(int value, int min, int max)
        {
            return (value < min) ? min : (value > max) ? max : value;
        }


        public static T Clamp<T>(T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0)
                return min;
            return val.CompareTo(max) > 0 ? max : val;
        }

        public Form1()
        {
            InitializeComponent();
            image1 = new Bitmap(pictureBox1.Width,pictureBox1.Height);
            image_tmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = image1;

            image2 = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            image2_tmp = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            pictureBox2.Image = image2;

            image3 = new Bitmap(pictureBox3.Width, pictureBox3.Height);
            image3_tmp = new Bitmap(pictureBox3.Width, pictureBox3.Height);
            pictureBox3.Image = image3;

            input_bytes = new byte[0];
            input_bytes1 = new byte[0];
            bytes = new byte[0];
            bytesHist = new byte[0];
            bytesHist1 = new byte[0];

        }
        #region byte converte

        public static byte[] ByteConverte(Bitmap img, byte[] imgbyte, int w, int h)
        {
            using (Bitmap _tmp = new Bitmap(w, h, PixelFormat.Format24bppRgb))
            {
                
                _tmp.SetResolution(img.HorizontalResolution, img.VerticalResolution);

                using (var g = Graphics.FromImage(_tmp))
                {
                    g.DrawImageUnscaled(img, 0, 0);
                }
                imgbyte = getImgBytes24(_tmp);
            }

            return imgbyte;
        }


        public static Bitmap PixelsOperation1(byte[] bytes, int w, int h, Bitmap img)
        {

            Bitmap img_ret = new Bitmap(w, h, PixelFormat.Format24bppRgb);
            img_ret.SetResolution(img.HorizontalResolution, img.VerticalResolution);

            writeImageBytes(img_ret, bytes);

            return img_ret;
        }

        static byte[] getImgBytes24(Bitmap img)
        {
            byte[] bytes = new byte[img.Width * img.Height * 3];  //выделяем память под массив байтов
            var data = img.LockBits(new Rectangle(0, 0, img.Width, img.Height),  //блокируем участок памати, занимаемый изображением
                ImageLockMode.ReadOnly,
                img.PixelFormat);
            Marshal.Copy(data.Scan0, bytes, 0, bytes.Length);  //копируем байты изображения в массив
            img.UnlockBits(data);   //разблокируем изображение
            return bytes; //возвращаем байты
        }

        static void writeImageBytes(Bitmap img, byte[] bytes)
        {
            var data = img.LockBits(new Rectangle(0, 0, img.Width, img.Height),  //блокируем участок памати, занимаемый изображением
                ImageLockMode.WriteOnly,
                img.PixelFormat);
            Marshal.Copy(bytes, 0, data.Scan0, bytes.Length); //копируем байты массива в изображение

            img.UnlockBits(data);  //разблокируем изображение
        }

        #endregion byte converte

        private void bOpenone_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog  = new OpenFileDialog();
            openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog.Filter = "Картинки (png, jpg, bmp, gif) |*.png;*.jpg;*.bmp;*.gif|All files (*.*)|*.*";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (image3 != null)
                {
                    pictureBox3.Image = null;
                    image3.Dispose();
                    
                }
                image3 = new Bitmap(openFileDialog.FileName);
                pictureBox3.Image = image3;
                if (pictureBox3.Visible == false)
                {
                    bOpenone.Text = "Изменить 1";
                    pictureBox3.Visible = true;
                    bOpenone.Location = new System.Drawing.Point(bOpenone.Location.X, bOpenone.Location.Y + 109);
                    bOpentwo.Visible = true;
                    label2.Visible = true;
                    comboBox2.Visible = true;
                }
                image3_tmp = new Bitmap(image3);
                image_tmp = new Bitmap(image3);
            }
        }

        private void bOpentwo_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog.Filter = "Картинки (png, jpg, bmp, gif) |*.png;*.jpg;*.bmp;*.gif|All files (*.*)|*.*";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (image2 != null)
                {
                    pictureBox2.Image = null;
                    image2.Dispose();
                }

                image2 = new Bitmap(openFileDialog.FileName);
                pictureBox2.Image = image2;
                if (pictureBox2.Visible == false)
                {
                    bOpentwo.Text = "Изменить 2";
                    pictureBox2.Visible = true;
                    bOpentwo.Location = new System.Drawing.Point(bOpentwo.Location.X, bOpentwo.Location.Y + 109);
                    label1.Visible = true;
                    comboBox1.Visible = true;
                    button1.Visible = true;
                    buttondelpict2.Visible = true;

                }
                image2_tmp = new Bitmap(image2);
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            using SaveFileDialog saveFileFialog = new SaveFileDialog();
            saveFileFialog.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileFialog.Filter = "Картинки (png, jpg, bmp, gif) |*.png;*.jpg;*.bmp;*.gif|All files (*.*)|*.*";
            saveFileFialog.RestoreDirectory = true;

            if (saveFileFialog.ShowDialog() == DialogResult.OK)
            {
                if (image1 != null)
                {
                    image1 = new Bitmap(image_tmp);
                    image1.Save(saveFileFialog.FileName);
                }
            }
        }
       
        #region mask

        //Маска круг
        static void pixel_mask_circle(byte[] input_bytes, byte[] input_bytes1, byte[] bytes, int x, int y, int rad, int w, int h)
        {
             for (int i = 0; i < h; ++i)
             {
                 var index = i * w;
                 for (int j = 0; j < w; ++j)
                 {
                     var idj = index + j;
                 bytes[3 * idj + 2] = (byte)(input_bytes[3 * idj + 2]);
                 bytes[3 * idj + 1] = (byte)(input_bytes[3 * idj + 1]);
                 bytes[3 * idj + 0] = (byte)(input_bytes[3 * idj + 0]);

                 if (Math.Pow((i - x), 2) + Math.Pow((j - y), 2) <= rad * rad)
                     {
                     bytes[3 * idj + 2] = (byte)(input_bytes1[3 * idj + 2]);
                     bytes[3 * idj + 1] = (byte)(input_bytes1[3 * idj + 1]);
                     bytes[3 * idj + 0] = (byte)(input_bytes1[3 * idj + 0]);
                 }
                 }
             }
        }

        static int product(int Px, int Py, int Ax, int Ay, int Bx, int By)
        {
            return (Bx - Ax) * (Py - Ay) - (By - Ay) * (Px - Ax);
        }
        //Маска прямоугольник
        static void pixel_mask_rectangle(byte[] input_bytes, byte[] input_bytes1, byte[] bytes, int x, int y, int ww, int hh, int w, int h)
        {
            int x1, x2, x3, x4;
            int y1, y2, y3, y4;
            y1 = y2 = y + hh / 2; // y1y4
            y3 = y4 = y - hh / 2; // y2 y3
            x1 = x4 = x - ww / 2; // x1 x2
            x2 = x3 = x + ww / 2; // x3 x4

                for (int i = 0; i < h; ++i)
                {   
                    var index = i * w;
                    for (int j = 0; j < w; ++j)
                    {
                        var idj = index + j;
                        int p1 = product(j, i, x1, y1, x2, y2),
                            p2 = product(j, i, x2, y2, x3, y3),
                            p3 = product(j, i, x3, y3, x4, y4),
                            p4 = product(j, i, x4, y4, x1, y1);
                    
                    if ((p1 < 0 && p2 < 0 && p3 < 0 && p4 < 0) ||
                            (p1 > 0 && p2 > 0 && p3 > 0 && p4 > 0))
                        {
                        bytes[3 * idj + 2] = (byte)(input_bytes1[3 * idj + 2]);
                        bytes[3 * idj + 1] = (byte)(input_bytes1[3 * idj + 1]);
                        bytes[3 * idj + 0] = (byte)(input_bytes1[3 * idj + 0]);
                    }
                        else
                        {
                        bytes[3 * idj + 2] = (byte)(input_bytes[3 * idj + 2]);
                        bytes[3 * idj + 1] = (byte)(input_bytes[3 * idj + 1]);
                        bytes[3 * idj + 0] = (byte)(input_bytes[3 * idj + 0]);
                    }
                    }
                }
        }

        //Маска квадрат
        static void pixel_mask_square(byte[] input_bytes, byte[] input_bytes1, byte[] bytes, int x, int y, int wh, int w, int h)
        {
            
            int x1, x2, x3, x4;
            int y1, y2, y3, y4;
            y1 = y2 = y + wh / 2; // y1y4
            y3 = y4 = y - wh / 2; // y2 y3
            x1 = x4 = x - wh / 2; // x1 x2
            x2 = x3 = x + wh / 2; // x3 x4
                for (int i = 0; i < h; ++i)
                {   
                    var index = i * w;
                    for (int j = 0; j < w; ++j)
                    {
                        var idj = index + j;
                        int p1 = product(j, i, x1, y1, x2, y2),
                            p2 = product(j, i, x2, y2, x3, y3),
                            p3 = product(j, i, x3, y3, x4, y4),
                            p4 = product(j, i, x4, y4, x1, y1);
                    

                    if ((p1 < 0 && p2 < 0 && p3 < 0 && p4 < 0) ||
                            (p1 > 0 && p2 > 0 && p3 > 0 && p4 > 0))
                        {
                        bytes[3 * idj + 2] = (byte)(input_bytes1[3 * idj + 2]);
                        bytes[3 * idj + 1] = (byte)(input_bytes1[3 * idj + 1]);
                        bytes[3 * idj + 0] = (byte)(input_bytes1[3 * idj + 0]);
                    }
                        else
                        {
                        bytes[3 * idj + 2] = (byte)(input_bytes[3 * idj + 2]);
                        bytes[3 * idj + 1] = (byte)(input_bytes[3 * idj + 1]);
                        bytes[3 * idj + 0] = (byte)(input_bytes[3 * idj + 0]);
                        }
                    }
                }
        }

        #endregion mask

        #region operations

        public static void pixelsumm(byte[] input_bytes, byte[] input_bytes1, byte[] bytes, int height, int width)
        {
            for (int i = 0; i < height; i++)
            {
                var index = i * width;
                for (int j = 0; j < width; j++)
                {
                    var idj = index + j;
                    bytes[3 * idj + 2] = (byte)Clamp(input_bytes[3 * idj + 2] + input_bytes1[3 * idj + 2], 0, 255);
                    bytes[3 * idj + 1] = (byte)Clamp(input_bytes[3 * idj + 1] + input_bytes1[3 * idj + 1], 0, 255);
                    bytes[3 * idj + 0] = (byte)Clamp(input_bytes[3 * idj + 0] + input_bytes1[3 * idj + 0], 0, 255);
                }
            }
        }
        // умножение
        public static void pixelumnozh(byte[] input_bytes, byte[] input_bytes1, byte[] bytes, int height, int width)
        {
            for (int i = 0; i < height; i++)
            {
                var index = i * width;
                for (int j = 0; j < width; j++)
                {
                    var idj = index + j;
                    bytes[3 * idj + 2] = (byte)Clamp(input_bytes[3 * idj + 2] * input_bytes1[3 * idj + 2] / 255, 0, 255);
                    bytes[3 * idj + 1] = (byte)Clamp(input_bytes[3 * idj + 1] * input_bytes1[3 * idj + 1] / 255, 0, 255);
                    bytes[3 * idj + 0] = (byte)Clamp(input_bytes[3 * idj + 0] * input_bytes1[3 * idj + 0] / 255, 0, 255);
                }
            }
        }
        //разность
        public static void pixelrazn(byte[] input_bytes, byte[] input_bytes1, byte[] bytes, int height, int width)
        {
            for (int i = 0; i < height; i++)
            {
                var index = i * width;
                for (int j = 0; j < width; j++)
                {
                    var idj = index + j;
                    bytes[3 * idj + 2] = (byte)Clamp(input_bytes[3 * idj + 2] > input_bytes1[3 * idj + 2] ? input_bytes[3 * idj + 2] - input_bytes1[3 * idj + 2] : 0, 0, 255);
                    bytes[3 * idj + 1] = (byte)Clamp(input_bytes[3 * idj + 1] > input_bytes1[3 * idj + 1] ? input_bytes[3 * idj + 1] - input_bytes1[3 * idj + 1] : 0, 0, 255);
                    bytes[3 * idj + 0] = (byte)Clamp(input_bytes[3 * idj + 0] > input_bytes1[3 * idj + 0] ? input_bytes[3 * idj + 0] - input_bytes1[3 * idj + 0] : 0, 0, 255);
                }
            }
        }
        // среднее арифметическое
        public static void pixelsrednar(byte[] input_bytes, byte[] input_bytes1, byte[] bytes, int height, int width)
        {
            for (int i = 0; i < height; i++)
            {
                var index = i * width;
                for (int j = 0; j < width; j++)
                {
                    var idj = index + j;
                    var r = input_bytes[3 * idj + 2];
                    var g = input_bytes[3 * idj + 1];
                    var b = input_bytes[3 * idj + 0];
                    bytes[3 * idj + 2] = (byte)Clamp((input_bytes[3 * idj + 2] + input_bytes1[3 * idj + 2]) / 2, 0, 255);
                    bytes[3 * idj + 1] = (byte)Clamp((input_bytes[3 * idj + 1] + input_bytes1[3 * idj + 1]) / 2, 0, 255);
                    bytes[3 * idj + 0] = (byte)Clamp((input_bytes[3 * idj + 0] + input_bytes1[3 * idj + 0]) / 2, 0, 255);
                }
            }
        }
        // минимум
        public static void pixelmin(byte[] input_bytes, byte[] input_bytes1, byte[] bytes, int height, int width)
        {
            for (int i = 0; i < height; i++)
            {
                var index = i * width;
                for (int j = 0; j < width; j++)
                {
                    var idj = index + j;
                    var r1 = input_bytes[3 * idj + 2];
                    var g1 = input_bytes[3 * idj + 1];
                    var b1 = input_bytes[3 * idj + 0];
                    var r2 = input_bytes1[3 * idj + 2];
                    var g2 = input_bytes1[3 * idj + 1];
                    var b2 = input_bytes1[3 * idj + 0];
                    if (r1 > r2)
                        bytes[3 * idj + 2] = r2;
                    else
                        bytes[3 * idj + 2] = r1;
                    if (g1 > g2)
                        bytes[3 * idj + 1] = g2;
                    else
                        bytes[3 * idj + 1] = g1;
                    if (b1 > b2)
                        bytes[3 * idj + 0] = b2;
                    else
                        bytes[3 * idj + 0] = b1;
                }
            }
        }
        // максимум
        public static void pixelmax(byte[] input_bytes, byte[] input_bytes1, byte[] bytes, int height, int width)
        {
            for (int i = 0; i < height; i++)
            {
                var index = i * width;
                for (int j = 0; j < width; j++)
                {
                    var idj = index + j;
                    var r1 = input_bytes[3 * idj + 2];
                    var g1 = input_bytes[3 * idj + 1];
                    var b1 = input_bytes[3 * idj + 0];
                    var r2 = input_bytes1[3 * idj + 2];
                    var g2 = input_bytes1[3 * idj + 1];
                    var b2 = input_bytes1[3 * idj + 0];
                    if (r1 > r2)
                        bytes[3 * idj + 2] = r1;
                    else
                        bytes[3 * idj + 2] = r2;
                    if (g1 > g2)
                        bytes[3 * idj + 1] = g1;
                    else
                        bytes[3 * idj + 1] = g2;
                    if (b1 > b2)
                        bytes[3 * idj + 0] = b1;
                    else
                        bytes[3 * idj + 0] = b2;
                }
            }
        }


        #endregion operations

        #region sizepicture
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private void checksize()
        {
            var w = image3.Width;
            var h = image3.Height;
            if (w * h != image2.Width * image2.Height)
            {
                if (w * h > image2.Width * image2.Height)
                {
                    image2 = ResizeImage(image2, w, h);
                }
                else if (w * h < image2.Width * image2.Height)
                {

                    w = image2.Width;
                    h = image2.Height;
                    image3 = ResizeImage(image3, w, h);
                }
            }
            image1 = new Bitmap(w, h);
            w = image2.Width;
            h = image2.Height;
            input_bytes1 = ByteConverte(image2, input_bytes1, w, h);
            w = image3.Width;
            h = image3.Height;
            input_bytes = ByteConverte(image3, input_bytes, w, h);
            bytes = new byte[0];
        }

        #endregion sizepicture

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {   
            checksize();
            
            int index = comboBox1.FindString(comboBox1.Text);
            comboBox1.SelectedIndex = index;
            if(index == 5)
            {
                comboBox3.Visible = true;
                label3.Visible = true;
            }
            else
            {
                comboBox3.Visible = false;
                label3.Visible = false;
            }
            var w = image1.Width;
            var h = image1.Height;
            bytes = ByteConverte(image1, bytes, w, h);
            switch (index)
            {
                case 0:
                    //попиксельно сумма
                    pixelsumm(input_bytes, input_bytes1, bytes, h, w);
                    break;

                case 1:
                    // произведение
                    pixelumnozh(input_bytes, input_bytes1, bytes, h, w);
                    break;

                case 2:
                    //среднее-арифметическое
                    pixelsrednar(input_bytes, input_bytes1, bytes, h, w);
                    
                    break;

                case 3:
                    //минимум
                    pixelmin(input_bytes, input_bytes1, bytes, h, w);
                    break;

                case 4:
                    //максимум
                    pixelmax(input_bytes, input_bytes1, bytes, h, w);
                    break;

                case 5:
                    //маска
                   
                    break;

            }
            image1 = PixelsOperation1(bytes, w, h, image1);
            image_tmp = new Bitmap(image1);
            pictureBox1.Image = image1;
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexrgb = comboBox2.FindString(comboBox2.Text);
            comboBox2.SelectedIndex = indexrgb;
            var w = image1.Width;
            var h = image1.Height;
            bytes = ByteConverte(image1, bytes, w, h);
            switch (indexrgb)
            {
                case 0:
                    //_RGB
                    break;

                case 1:
                    //R
                    for (int i = 0; i < h; i++)
                    {
                        var ind = i * w;
                        for (int j = 0; j < w; j++)
                        {
                            var idj = ind + j;
                            bytes[3 * idj + 1] = (byte)(0x000000);
                            bytes[3 * idj + 0] = (byte)(0x000000);
                        }
                    }
                    break;
                case 2:
                    //G
                    for (int i = 0; i < h; i++)
                    {
                        var ind = i * w;
                        for (int j = 0; j < w; j++)
                        {
                            var idj = ind + j;
                            bytes[3 * idj + 2] = (byte)(0x000000);
                            bytes[3 * idj + 0] = (byte)(0x000000);
                        }
                    }
                    break;
                case 3:
                    //B
                    for (int i = 0; i < h; i++)
                    {
                        var ind = i * w;
                        for (int j = 0; j < w; j++)
                        {
                            var idj = ind + j;
                            bytes[3 * idj + 2] = (byte)(0x000000);
                            bytes[3 * idj + 1] = (byte)(0x000000);
                        }
                    }
                    break;
                case 4:
                    //RG
                    for (int i = 0; i < h; i++)
                    {
                        var ind = i * w;
                        for (int j = 0; j < w; j++)
                        {
                            var idj = ind + j;
                            bytes[3 * idj + 0] = (byte)(0x000000);
                        }
                    }
                    break;
                case 5:
                    //GB
                    for (int i = 0; i < h; i++)
                    {
                        var ind = i * w;
                        for (int j = 0; j < w; j++)
                        {
                            var idj = ind + j;
                            bytes[3 * idj + 2] = (byte)(0x000000);
                        }
                    }
                    break;
                case 6:
                    //RB
                    for (int i = 0; i < h; i++)
                    {
                        var ind = i * w;
                        for (int j = 0; j < w; j++)
                        {
                            var idj = ind + j;
                            bytes[3 * idj + 1] = (byte)(0x000000);
                        }
                    }
                    break;

            }
            image1 = PixelsOperation1(bytes, w, h, image1);
            pictureBox1.Image = image1;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            checksize();
            var w = image1.Width;
            var h = image1.Height;
            bytes = ByteConverte(image1, bytes, w, h);
            int indexmask = comboBox3.FindString(comboBox3.Text);
            comboBox3.SelectedIndex = indexmask;
            var w1 = w / 2;
            var h1 = h / 2;
            int r;
            switch (indexmask)
            {
                case 0:
                    //круг
                    if (w > h)
                    {
                        r = h / 3;
                    }
                    else
                    {
                        r = w / 3;
                    }
                    pixel_mask_circle(input_bytes, input_bytes1, bytes, h1, w1, r, w, h);
                    image1 = PixelsOperation1(bytes, w, h, image1);
                    break;
                case 1:
                    //квадрат
                    if (w > h)
                    {
                        r = h / 3;
                    }
                    else
                    {
                        r = w / 3;
                    }
                    pixel_mask_square(input_bytes, input_bytes1, bytes, w1, h1, r, w, h);
                    image1 = PixelsOperation1(bytes, w, h, image1);
                    break;
                case 2:
                    //прямоугольник
                    int ww = w / 2;
                    int hh = h / 2;
                    pixel_mask_rectangle(input_bytes, input_bytes1, bytes, w1, h1, ww, hh, w, h);
                    image1 = PixelsOperation1(bytes, w, h, image1);
                    break;
            }
            image_tmp = new Bitmap(image1);
            pictureBox1.Image = image1;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            image2 = new Bitmap(image2_tmp);
            pictureBox2.Image = image2;
            image3 = new Bitmap(image3_tmp);
            pictureBox3.Image = image3;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/merkulov-1230/PictureReda4er");
        }

        private void buttondelpict2_Click(object sender, EventArgs e)
        {
            image1.Dispose();
            image2.Dispose();
            bOpentwo.Text = "Открыть 2 картинку";
            pictureBox2.Visible = false;
            bOpentwo.Location = new System.Drawing.Point(bOpentwo.Location.X, bOpentwo.Location.Y - 109);
            label1.Visible = false;
            comboBox1.Visible = false;
            comboBox3.Visible = false;
            label3.Visible = false;
            button1.Visible = false;
            buttondelpict2.Visible = false;
            pictureBox1.Image = null;
            bytes = new byte[0];
        }

        #region menu
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using SaveFileDialog saveFileFialog = new SaveFileDialog();
            saveFileFialog.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileFialog.Filter = "Картинки (png, jpg, bmp, gif) |*.png;*.jpg;*.bmp;*.gif|All files (*.*)|*.*";
            saveFileFialog.RestoreDirectory = true;

            if (saveFileFialog.ShowDialog() == DialogResult.OK)
            {
                if (image1 != null)
                {
                    image1 = new Bitmap(image_tmp);
                    image1.Save(saveFileFialog.FileName);
                }
            }
        }


        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            int index = toolStripComboBox1.FindString(toolStripComboBox1.Text);
            toolStripComboBox1.SelectedIndex = index;
            switch (index)
            {
                case 0:
                    image1 = ResizeImage(image1, 2048, 1080);
                    break;
                case 1:
                    image1 = ResizeImage(image1, 1920, 1080);
                    break;
                case 2:
                    image1 = ResizeImage(image1, 1600, 900);
                    break;
                case 3:
                    image1 = ResizeImage(image1, 1366, 768);
                    break;
                case 4:
                    image1 = ResizeImage(image1, 1280, 720);
                    break;
                case 5:
                    image1 = ResizeImage(image1, 11520, 6480);
                    break;


            }
            pictureBox1.Image = image1;
        }

        #endregion menu

        private void kEKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var w = image1.Width;
            var h = image1.Height;
            bytes = ByteConverte(image1, bytes, w, h);
            var w2 = w / 2;
            byte[] bytes_filtr = bytes; 
            for (int i = 0; i < h; i++)
            {
                var q = w-1;
                var index = i * w;
                for (int j = 0; j < w; j++)
                {
                    var idq = index + q;
                    var idj = index + j;
                    bytes[3 * idj + 2] = (byte)(bytes_filtr[3 * idq + 2]);
                    bytes[3 * idj + 1] = (byte)(bytes_filtr[3 * idq + 1]);
                    bytes[3 * idj + 0] = (byte)(bytes_filtr[3 * idq + 0]);
                    q--;
                }
            }
            image1 = PixelsOperation1(bytes, w, h, image1);
            image_tmp = new Bitmap(image1);
            pictureBox1.Image = image1;
        }

        private void повернутьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image1.RotateFlip(RotateFlipType.Rotate90FlipY);
            image_tmp = new Bitmap(image1);
            pictureBox1.Image = image1;
        }

        private void поВертикалиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image1.RotateFlip(RotateFlipType.Rotate180FlipY);
            image_tmp = new Bitmap(image1);
            pictureBox1.Image = image1;
        }

        private void поГоризонталиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image1.RotateFlip(RotateFlipType.Rotate180FlipX);
            image_tmp = new Bitmap(image1);
            pictureBox1.Image = image1;
        }
        
        private void сохранить1КартинкуToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            
            if (qq == 2)
            {
                pictureBox2.Image = image1;
                image2 = new Bitmap(image1);
            }
            if (qq == 3)
            {
                pictureBox3.Image = image1;
                image3 = new Bitmap(image1);
            }
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            qq = 3;
            pictureBox1.Image = image3;
            image1 = new Bitmap(image3);
            гистограммаToolStripMenuItem.Enabled = true;
            var index = 0;
            comboBox2.SelectedIndex = index;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            qq = 2;
            pictureBox1.Image = image2;
            image1 = new Bitmap(image2);
            гистограммаToolStripMenuItem.Enabled = true;
        }

        #region whiteblack
        private byte[] whiteblack()
        {
            var w = image1.Width;
            var h = image1.Height;
            bytes = ByteConverte(image1, bytes, w, h);
            byte[] I = new byte[bytes.Length];
            Parallel.For(0, h, (i) =>
            {
                var index = i * w;
                Parallel.For(0, w, (j) =>
                {
                    var idj = index + j;
                    I[3 * idj] = (byte)Clamp((0.2125 * bytes[3 * idj + 2] + 0.7154 * bytes[3 * idj + 1] + 0.0721 * bytes[3 * idj + 0]), 0, 255);
                    I[3 * idj + 2] = I[3 * idj + 1] = I[3 * idj];
                });
            });
            return I;
        }

        private void чБ1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Метод Гаврилова;

            var w = image1.Width;
            var h = image1.Height;
            byte[] I = whiteblack();
            byte[] out_bytes = new byte[w * h * 3];
            var t = I.Average(x => x);
            Parallel.For(0, h, (i) =>
            {
                var index = i * w;
                Parallel.For(0, w, (j) =>
                {
                    var idj = index + j;
                    out_bytes[3 * idj + 0] = out_bytes[3 * idj + 1] = out_bytes[3 * idj + 2] = (I[3 * idj] <= t) ? (byte)0 : (byte)255;
                });
            });
            image1 = new Bitmap(w, h, PixelFormat.Format24bppRgb);
            image1.SetResolution(image1.HorizontalResolution, image1.VerticalResolution);
            writeImageBytes(image1, out_bytes);
            image_tmp = new Bitmap(image1);
            pictureBox1.Image = image1;
        }

        private void чБ2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Метод Отсу;

            var w = image1.Width;
            var h = image1.Height;
            byte[] I = whiteblack();
            byte[] out_bytes = new byte[w * h * 3];
            double[] N = new double[256];
            double[] sum_N = new double[256];
            double[] sum_iN = new double[256];
            double sum = 0.0, isum = 0.0, max_t = 0.0, max_sigma = 0.0, w1 = 0.0, w2 = 0.0, u1 = 0.0, u2 = 0.0;
            var max_I = I.Max(x => x);
            Parallel.For(0, h, (i) =>
            {
                var index = i * w;
                Parallel.For(0, w, (j) =>
                {
                    var idj = index + j;
                    N[I[3 * idj]] += 1.0 / (w * h);
                });
            });

            for (int i = 0; i <= max_I; ++i)
            {
                sum += N[i];
                isum += i * N[i];
                sum_N[i] = sum;
                sum_iN[i] = isum;
            }

            for (int t = 1; t <= max_I; ++t)
            {
                w1 = sum_N[t - 1];
                w2 = 1.0 - w1;
                u1 = sum_iN[t - 1] / w1;
                u2 = (sum_iN[max_I] - u1 * w1) / w2;
                var sigma = w1 * w2 * Math.Pow(u1 - u2, 2);
                if (sigma > max_sigma)
                {
                    max_sigma = sigma;
                    max_t = t;
                }
            }

            Parallel.For(0, h, (i) =>
            {
                var index = i * w;
                Parallel.For(0, w, (j) =>
                {
                    var idj = index + j;
                    out_bytes[3 * idj + 0] = out_bytes[3 * idj + 1] = out_bytes[3 * idj + 2] = (I[3 * idj] <= max_t) ? (byte)0 : (byte)255;
                });
            });
            image1 = new Bitmap(w, h, PixelFormat.Format24bppRgb);
            image1.SetResolution(image1.HorizontalResolution, image1.VerticalResolution);
            writeImageBytes(image1, out_bytes);
            image_tmp = new Bitmap(image1);
            pictureBox1.Image = image1;
        }

        private void чБ3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Метод Ниблека
            int a = 15;
            double k = -0.2;
            var w = image1.Width;
            var h = image1.Height;
            byte[] I = whiteblack();
            byte[] out_bytes = new byte[w * h * 3];
            var integral_mat = new long[h, w];
            var integral_sqr_mat = new long[h, w];
            var a_2 = (int)Math.Ceiling(1.0 * a / 2);
            for (int i = 0; i < h; ++i)
            {
                for (int j = 0; j < w; ++j)
                {
                    integral_mat[i, j] = I[i * w * 3 + j * 3] +
                                    (j >= 1 ? integral_mat[i, j - 1] : 0) +
                                    (i >= 1 ? integral_mat[i - 1, j] : 0) -
                                    (i >= 1 && j >= 1 ? integral_mat[i - 1, j - 1] : 0);

                    integral_sqr_mat[i, j] = I[i * w * 3 + j * 3] * I[i * w * 3 + j * 3] +
                                    (j >= 1 ? integral_sqr_mat[i, j - 1] : 0) +
                                    (i >= 1 ? integral_sqr_mat[i - 1, j] : 0) -
                                    (i >= 1 && j >= 1 ? integral_sqr_mat[i - 1, j - 1] : 0);
                }
            }
            for (int i = 0; i < h; ++i)
            {
                var y1 = i - a_2;
                y1 = (y1 < 0) ? 0 : y1;
                var y2 = i + a_2;
                y2 = (y2 >= h) ? h - 1 : y2;
                for (int j = 0; j < w; ++j)
                {
                    int index = 3 * (i * w + j);
                    long sum = 0;
                    long sqr_sum = 0;
                    var x1 = j - a_2;
                    x1 = (x1 < 0) ? 0 : x1;
                    var x2 = j + a_2;
                    x2 = (x2 >= w) ? w - 1 : x2;
                    sum = ((x1 >= 1 && y1 >= 1) ? integral_mat[y1 - 1, x1 - 1] : 0) +
                        integral_mat[y2, x2] -
                        ((y1 >= 1) ? integral_mat[y1 - 1, x2] : 0) -
                        ((x1 >= 1) ? integral_mat[y2, x1 - 1] : 0);

                    sqr_sum = ((x1 >= 1 && y1 >= 1) ? integral_sqr_mat[y1 - 1, x1 - 1] : 0) +
                              integral_sqr_mat[y2, x2] -
                          ((y1 >= 1) ? integral_sqr_mat[y1 - 1, x2] : 0) -
                          ((x1 >= 1) ? integral_sqr_mat[y2, x1 - 1] : 0);

                    sqr_sum /= (x2 - x1 + 1) * (y2 - y1 + 1);
                    sum /= (x2 - x1 + 1) * (y2 - y1 + 1);

                    double D = Math.Sqrt(sqr_sum - sum * sum);
                    double t = sum + k * D;

                    out_bytes[index + 0] = out_bytes[index + 1] = out_bytes[index + 2] = (I[index] <= t) ? (byte)0 : (byte)255;
                }
            }
            image1 = new Bitmap(w, h, PixelFormat.Format24bppRgb);
            image1.SetResolution(image1.HorizontalResolution, image1.VerticalResolution);
            writeImageBytes(image1, out_bytes);
            image_tmp = new Bitmap(image1);
            pictureBox1.Image = image1;

        }

        private void методToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Метод Сауволы
            int a = 15;
            double k = 0.25;
            int R = 128;
            var w = image1.Width;
            var h = image1.Height;
            byte[] I = whiteblack();
            byte[] out_bytes = new byte[w * h * 3];
            var integral_mat = new long[h, w];
            var integral_sqr_mat = new long[h, w];
            var a_2 = (int)Math.Ceiling(1.0 * a / 2);
            for (int i = 0; i < h; ++i)
            {
                for (int j = 0; j < w; ++j)
                {
                    integral_mat[i, j] = I[i * w * 3 + j * 3] +
                                    (j >= 1 ? integral_mat[i, j - 1] : 0) +
                                    (i >= 1 ? integral_mat[i - 1, j] : 0) -
                                    (i >= 1 && j >= 1 ? integral_mat[i - 1, j - 1] : 0);

                    integral_sqr_mat[i, j] = I[i * w * 3 + j * 3] * I[i * w * 3 + j * 3] +
                                    (j >= 1 ? integral_sqr_mat[i, j - 1] : 0) +
                                    (i >= 1 ? integral_sqr_mat[i - 1, j] : 0) -
                                    (i >= 1 && j >= 1 ? integral_sqr_mat[i - 1, j - 1] : 0);
                }
            }
            for (int i = 0; i < h; ++i)
            {
                var y1 = i - a_2;
                y1 = (y1 < 0) ? 0 : y1;
                var y2 = i + a_2;
                y2 = (y2 >= h) ? h - 1 : y2;
                for (int j = 0; j < w; ++j)
                {
                    int index = 3 * (i * w + j);
                    long sum = 0;
                    long sqr_sum = 0;
                    var x1 = j - a_2;
                    x1 = (x1 < 0) ? 0 : x1;
                    var x2 = j + a_2;
                    x2 = (x2 >= w) ? w - 1 : x2;
                    sum = ((x1 >= 1 && y1 >= 1) ? integral_mat[y1 - 1, x1 - 1] : 0) +
                        integral_mat[y2, x2] -
                        ((y1 >= 1) ? integral_mat[y1 - 1, x2] : 0) -
                        ((x1 >= 1) ? integral_mat[y2, x1 - 1] : 0);

                    sqr_sum = ((x1 >= 1 && y1 >= 1) ? integral_sqr_mat[y1 - 1, x1 - 1] : 0) +
                              integral_sqr_mat[y2, x2] -
                          ((y1 >= 1) ? integral_sqr_mat[y1 - 1, x2] : 0) -
                          ((x1 >= 1) ? integral_sqr_mat[y2, x1 - 1] : 0);

                    sqr_sum /= (x2 - x1 + 1) * (y2 - y1 + 1);
                    sum /= (x2 - x1 + 1) * (y2 - y1 + 1);

                    double D = Math.Sqrt(sqr_sum - sum * sum);
                    double t = sum * (1 + k * (D / R - 1));

                    out_bytes[index + 0] = out_bytes[index + 1] = out_bytes[index + 2] = (I[index] <= t) ? (byte)0 : (byte)255;
                }
            }
            image1 = new Bitmap(w, h, PixelFormat.Format24bppRgb);
            image1.SetResolution(image1.HorizontalResolution, image1.VerticalResolution);
            writeImageBytes(image1, out_bytes);
            image_tmp = new Bitmap(image1);
            pictureBox1.Image = image1;
        }

        #endregion whiteblack

        #region Histogramm
        private void гистограммаToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            Form2 newfrm = new(image1, image1.Width, image1.Height);
            newfrm.ShowDialog();
            image1.Dispose();
            pictureBox1.Image = null;
        }
        private void savehist()
        {
            
           
            if (qq == 2)
            {
                pictureBox2.Image = image1;
                image2 = new Bitmap(image1);
            }
            if (qq == 3)
            {
                pictureBox3.Image = image1;
                image3 = new Bitmap(image1);
            }
        }

        #endregion Histogramm

        private void фильтрацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void линейнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 newfrm = new(image1, image1.Width, image1.Height);
            newfrm.ShowDialog();
            image1.Dispose();
            pictureBox1.Image = null;
        }

        private void медианнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 newfrm = new(image1, image1.Width, image1.Height);
            newfrm.ShowDialog();
            image1.Dispose();
            pictureBox1.Image = null;
        }

        private void частотнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 newfrm = new(image1, image1.Width, image1.Height);
            newfrm.ShowDialog();
            image1.Dispose();
            pictureBox1.Image = null;
        }
    }
    
}