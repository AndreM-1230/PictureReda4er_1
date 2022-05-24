using System;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;


namespace PictureReda4er
{
    internal static class Functions
    {
        public static T Clamp<T>(T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0)
                return min;
            return val.CompareTo(max) > 0 ? max : val;
        }
        public static void Swap<T>(ref T val1, ref T val2) 
        {
            T temp = val1;
            val1 = val2;
            val2 = temp;
        }
        public static double[,] GetMatrixFromStr(string matrix)
        {
            char[] sep = { '\n' };
            matrix = matrix.Replace('\r', ' ');
            var str_list = matrix.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            double[,] mat = new double[0, 0];
            char[] sep_space = { ' ' };

            for (int i = 0; i < str_list.Count(); ++i)
            {
                //str_list[i] = str_list[i].Replace('\r', ' ');
                var chars = str_list[i].Split(sep_space, StringSplitOptions.RemoveEmptyEntries);

                if (i == 0)
                {
                    mat = new double[str_list.Length, chars.Length];
                }

                for (int j = 0; j < chars.Length; ++j)
                {                    
                    mat[i, j] = Convert.ToDouble(Convert.ToString(chars[j]).Replace('.', ','));
                }
            }
            return mat;
        }
        
        public static int QuickSelect(int[] arr, int left, int right, int k)
        {
            if (right - left == 1)
                return arr[left];

            int left_count = 0;
            int eqv_count = 0;            

            for (int i = left; i < right - 1; ++i)
            {
                if (arr[i] < arr[right - 1])
                {
                    Swap(ref arr[i], ref arr[left + left_count]);                    
                    left_count++;
                }
            }
            for (int i = left + left_count; i < right - 1; ++i)
            {
                if (arr[i] == arr[right - 1])
                {
                    Swap(ref arr[i], ref arr[left + left_count + eqv_count]);                    
                    eqv_count++;
                }
            }
            Swap(ref arr[right - 1], ref arr[left + left_count + eqv_count]);

            if (k < left_count)
                return QuickSelect(arr, left, left + left_count, k);
            else if (k < left_count + eqv_count)
                return arr[left + left_count];
            else
                return QuickSelect(arr, left + left_count + eqv_count, right, k - left_count - eqv_count);

        }

        public static string GetGaussMat(int r, double sig)
        {
            double s = 0;
            double g;
            string ss="";                        

            double sig_sqr = 2.0 * sig * sig;
            double pi_siq_sqr = sig_sqr * Math.PI;

            for (int i = -r; i <= r; ++i)
            {
                for (int j = -r; j <= r; ++j)
                {
                    g = 1.0 / pi_siq_sqr * Math.Pow(Math.E,(-1.0 * (i * i + j * j) / (sig_sqr)));
                    s += g;
                    
                    if (j == r)
                        ss += Math.Round(g, 5).ToString() + "\r\n";
                    else
                        ss += Math.Round(g, 5).ToString() + " ";
                }
                
            }
            return ss;
        }
        //Быстрое преобразование Фурье (FFT).
        public static Complex[] FFT(Complex[] arr, int x0, int N, int s)
        {
            Complex[] X = new Complex[N];
            if (N == 1)
            {
                X[0] = arr[x0];
            }
            else
            {
                FFT(arr, x0, N / 2, 2 * s).CopyTo(X, 0);
                FFT(arr, x0 + s, N / 2, 2 * s).CopyTo(X, N / 2);

                for (int k = 0; k < N / 2; k++)
                {
                    var t = X[k];
                    double u = -2.0 * Math.PI * k / N;
                    X[k] = t + new Complex(Math.Cos(u), Math.Sin(u)) * X[k + N / 2];
                    X[k + N / 2] = t - new Complex(Math.Cos(u), Math.Sin(u)) * X[k + N / 2];
                }
            }
            return X;
        }

        public static Complex[] FFT1(Complex[] arr, int width, int height)
        {
            Complex[] X = new Complex[arr.Length];

            
            Parallel.For(0, height, i =>
            {
                Complex[] tmp = new Complex[width];
                Array.Copy(arr, i * width, tmp, 0, width);

                tmp = FFT(tmp, 0, width, 1);

                for (int k = 0; k < width; ++k)
                    X[i * width + k] = tmp[k] / width;
            }
            );
            
            Parallel.For(0, width, j =>
            {
                Complex[] tmp = new Complex[height];
                for (int k = 0; k < height; ++k)
                    tmp[k] = X[j + k * width];

                tmp = FFT(tmp, 0, tmp.Length, 1);

                for (int k = 0; k < height; ++k)
                    X[j + k * width] = tmp[k] / height;
            }
            );
            return X;
        }

        public static Complex[] FFT2(Complex[] arr, int width, int height)
        {
            Complex[] X = new Complex[arr.Length];
            
            Parallel.For(0, height, i =>
            {
                Complex[] tmp = new Complex[width];
                Array.Copy(arr, i * width, tmp, 0, width);
                for (int k = 0; k < width; ++k)
                    tmp[k] = new Complex(arr[i * width + k].Real, -arr[i * width + k].Imaginary);

                tmp = FFT(tmp, 0, width, 1);

                for (int k = 0; k < width; ++k)
                    X[i * width + k] = (new Complex(tmp[k].Real, -tmp[k].Imaginary));
            }
            );
            
            Parallel.For(0, width, j =>
            {
                Complex[] tmp = new Complex[height];
                for (int k = 0; k < height; ++k)
                    tmp[k] = new Complex(X[j + k * width].Real, -X[j + k * width].Imaginary);

                tmp = FFT(tmp, 0, tmp.Length, 1);

                for (int k = 0; k < height; ++k)
                    X[j + k * width] = (new Complex(tmp[k].Real, -tmp[k].Imaginary));
            }
            );
            return X;
        }
        public static double Butter(double x, double y, double D0, double n, double dx = 0, double dy = 0, double G = 1.0, double h = 0)
        {
            double D = Math.Sqrt((x - dx) * (x - dx) + (y - dy) * (y - dy)) - h;
            return G / (1 + Math.Pow(D / D0, 2 * n));
        }

        public static double Gauss(double x, double y, double D0, double dx = 0, double dy = 0, double G = 1.0, double h = 0)
        {
            double D = Math.Sqrt((x - dx) * (x - dx) + (y - dy) * (y - dy)) - h;
            return G * Math.Exp(-(D * D / (2.0 * D0 * D0)));
        }
        public static double Bright(double x)
        {
            return Math.Log(x + 1);
        }
    }

    internal class ImgFuncs
    {

        internal static byte[] getImgBytes24(Bitmap img)
        {
            byte[] bytes = new byte[img.Width * img.Height * 3];  //выделяем память под массив байтов
            var data = img.LockBits(new Rectangle(0, 0, img.Width, img.Height),  //блокируем участок памати, занимаемый изображением
                ImageLockMode.ReadOnly,
                img.PixelFormat);
            Marshal.Copy(data.Scan0, bytes, 0, bytes.Length);  //копируем байты изображения в массив
            img.UnlockBits(data);   //разблокируем изображение
            return bytes; //возвращаем байты
        }
        internal static void writeImageBytes(Bitmap img, byte[] bytes)
        {
            var data = img.LockBits(new Rectangle(0, 0, img.Width, img.Height),  //блокируем участок памати, занимаемый изображением
                ImageLockMode.WriteOnly,
                img.PixelFormat);
            Marshal.Copy(bytes, 0, data.Scan0, bytes.Length); //копируем байты массива в изображение

            img.UnlockBits(data);  //разблокируем изображение
        }

        public static Bitmap MatrixFilter(Bitmap input, string matrix)
        {
            int width = input.Width;
            int height = input.Height;


            Bitmap _tmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            _tmp.SetResolution(input.HorizontalResolution, input.VerticalResolution);
            using (Graphics g = Graphics.FromImage(_tmp))
            {
                g.DrawImageUnscaled(input, 0, 0);
            }


            byte[] in_bytes = getImgBytes24(_tmp);
            byte[] out_bytes = new byte[width * height * 3];


            var core = Functions.GetMatrixFromStr(matrix);
            int M = core.GetLength(0);
            int N = core.GetLength(1);

            Parallel.For(0, width * height, arr_i =>
            {
                int _i = arr_i / width;
                int _j = arr_i - _i * width;

                double sum1 = 0;
                double sum2 = 0;
                double sum3 = 0;

                for (int ii = 0; ii < M; ++ii)
                {
                    int i = _i + ii - M / 2;

                    i = i < 0 ? Math.Abs(i) : i;
                    i = i >= height ? 2 * height - i - 1 : i;

                    var index = width * i;
                    for (int jj = 0; jj < N; ++jj)
                    {
                        int j = _j + jj - N / 2;


                        j = j < 0 ? Math.Abs(j) : j;
                        j = j >= width ? 2 * width - j - 1 : j;

                        var idj = index + j;

                        sum1 += in_bytes[3 * idj + 0] * core[ii, jj];
                        sum2 += in_bytes[3 * idj + 1] * core[ii, jj];
                        sum3 += in_bytes[3 * idj + 2] * core[ii, jj];
                    }
                }
                out_bytes[arr_i * 3 + 0] = (byte)Functions.Clamp(sum1, 0, 255);
                out_bytes[arr_i * 3 + 1] = (byte)Functions.Clamp(sum2, 0, 255);
                out_bytes[arr_i * 3 + 2] = (byte)Functions.Clamp(sum3, 0, 255);
            });

            Bitmap new_bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            new_bitmap.SetResolution(input.HorizontalResolution, input.VerticalResolution);
            writeImageBytes(new_bitmap, out_bytes);

            return new_bitmap;
        }
        public static Bitmap Median(Bitmap input, int a)
        {
            int width = input.Width;
            int height = input.Height;

            Bitmap _tmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            _tmp.SetResolution(input.HorizontalResolution, input.VerticalResolution);
            using (Graphics g = Graphics.FromImage(_tmp))
            {
                g.DrawImageUnscaled(input, 0, 0);
            }

            byte[] in_bytes = getImgBytes24(_tmp);
            byte[] out_bytes = new byte[width * height * 3];



            Parallel.For(0, height, _i =>
            {
                int[] aR = new int[a * a];
                int[] aG = new int[a * a];
                int[] aB = new int[a * a];
                var idi = width * _i;
                for (int _j = 0; _j < width; ++_j)
                {
                    var idj = idi + _j;
                    for (int ii = 0; ii < a; ++ii)
                    {
                        int i = _i + ii - a / 2;

                        i = i < 0 ? Math.Abs(i) : i;
                        i = i >= height ? 2 * height - i - 1 : i;

                        var index = width * i;
                        for (int jj = 0; jj < a; ++jj)
                        {
                            int j = _j + jj - a / 2;

                            j = j < 0 ? Math.Abs(j) : j;
                            j = j >= width ? 2 * width - j - 1 : j;

                            var idjj = index + j;

                            aR[ii * a + jj] = in_bytes[3 * idjj + 0];
                            aG[ii * a + jj] = in_bytes[3 * idjj + 1];
                            aB[ii * a + jj] = in_bytes[3 * idjj + 2];
                        }
                    }
                    out_bytes[3 * idj + 0] = (byte)Functions.QuickSelect(aR, 0, a * a, a * a / 2);
                    out_bytes[3 * idj + 1] = (byte)Functions.QuickSelect(aG, 0, a * a, a * a / 2);
                    out_bytes[3 * idj + 2] = (byte)Functions.QuickSelect(aB, 0, a * a, a * a / 2);
                }

            });
            Bitmap new_bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            new_bitmap.SetResolution(input.HorizontalResolution, input.VerticalResolution);
            writeImageBytes(new_bitmap, out_bytes);

            return new_bitmap;
        }
        public static (Bitmap, Bitmap, Bitmap) Frequency_filtering(
            Bitmap input,
            int filter_type,
            double[][] filter_params_double,
            double furier_multiplyer = 1.0,
            double in_filter_zone = 1.0,
            double out_filter_zone = 0.0)
        {
            int width = input.Width;
            int height = input.Height;

            int new_width = width;
            int new_height = height;

            var p = Math.Log(width, 2);
            if (p != Math.Floor(p))
                new_width = (int)Math.Pow(2, Math.Ceiling(p));
            p = Math.Log(height, 2);
            if (p != Math.Floor(p))
                new_height = (int)Math.Pow(2, Math.Ceiling(p));

            Bitmap _tmp = new Bitmap(new_width, new_height, PixelFormat.Format24bppRgb);
            _tmp.SetResolution(input.HorizontalResolution, input.VerticalResolution);

            byte[] new_bytes = new byte[new_width * new_height * 3];
            byte[] furier_bytes = new byte[new_width * new_height * 3];
            byte[] filter_bytes = new byte[new_width * new_height * 3];

            Graphics g = Graphics.FromImage(_tmp);
            g.DrawImageUnscaled(input, 0, 0);

            byte[] old_bytes = getImgBytes24(_tmp);


            Complex[] complex_bytes = new Complex[new_width * new_height];

            for (int rgb = 0; rgb <= 2; rgb++)
            {

                for (int i = 0; i < new_width * new_height; ++i)
                {
                    int y = i / new_width;
                    int x = i - y * new_width;
                    complex_bytes[i] = Math.Pow(-1, x + y) * old_bytes[i * 3 + rgb];
                }

                complex_bytes = Functions.FFT1(complex_bytes, new_width, new_height);

                var max_bright = complex_bytes.Max(x => Functions.Bright(x.Imaginary));

                Complex[] complex_bytes_filtered = null;


                if (filter_type == 0) //Полосовой    
                {
                    complex_bytes_filtered = complex_bytes.Select((a, i) =>
                    {
                        int y = i / new_width;
                        int x = i - y * new_width - new_width / 2;
                        y -= new_height / 2;
                        foreach (var v in filter_params_double)
                        {
                            if (Math.Pow(x - v[0], 2) + Math.Pow(y - v[1], 2) >= Math.Pow(v[2], 2) &&
                                Math.Pow(x - v[0], 2) + Math.Pow(y - v[1], 2) <= Math.Pow(v[3], 2))
                            {
                                filter_bytes[i * 3 + rgb] = (byte)Functions.Clamp(255 * in_filter_zone, 0, 255);
                                return a * in_filter_zone;
                            }

                        }
                        filter_bytes[i * 3 + rgb] = (byte)Functions.Clamp(255 * out_filter_zone, 0, 255);
                        return a * out_filter_zone;

                    }).ToArray();
                }
                else
                if (filter_type == 1) //Режекторный
                {
                    complex_bytes_filtered = complex_bytes.Select((a, i) =>
                    {
                        int y = i / new_width;
                        int x = i - y * new_width - new_width / 2;
                        y -= new_height / 2;

                        foreach (var v in filter_params_double)
                        {
                            //if (Math.Pow(x - v[0], 2) + Math.Pow(y - v[1], 2) <= Math.Pow(v[2], 2) ||
                            //    Math.Pow(x - v[0], 2) + Math.Pow(y - v[1], 2) >= Math.Pow(v[3], 2))
                            //{
                            //    filter_bytes[i * 3 + rgb] = (byte)Functions.Clamp(255 * in_filter_zone, 0, 255);
                            //    return a * in_filter_zone;
                            //}
                            if (Math.Pow(x - v[0], 2) + Math.Pow(y - v[1], 2) >= Math.Pow(v[2], 2) &&
                                Math.Pow(x - v[0], 2) + Math.Pow(y - v[1], 2) <= Math.Pow(v[3], 2))
                            {
                                filter_bytes[i * 3 + rgb] = (byte)Functions.Clamp(255 * out_filter_zone, 0, 255);
                                return a * out_filter_zone;
                            }
                        }
                        filter_bytes[i * 3 + rgb] = (byte)Functions.Clamp(255 * in_filter_zone, 0, 255);
                        return a * in_filter_zone;


                    }).ToArray();
                }
                else
                if (filter_type == 2) //Баттерворта ФНЧ
                {
                    complex_bytes_filtered = complex_bytes.Select((a, i) =>
                    {
                        var val = filter_params_double.Select(v =>
                        {
                            int y = i / new_width;
                            int x = i - y * new_width - new_width / 2;
                            y -= new_height / 2;

                            double D0 = v[2];
                            double h = v[2] - D0;
                            double b = Functions.Butter(x, y, D0, (int)out_filter_zone, v[0], v[1], in_filter_zone, h);
                            return b;
                        }).Max();
                        filter_bytes[i * 3 + rgb] = (byte)Functions.Clamp(255 * val, 0, 255);
                        return a * val;
                    }).ToArray();
                }
                else if (filter_type == 3) //Баттерворта ФВЧ
                {
                    complex_bytes_filtered = complex_bytes.Select((a, i) =>
                    {
                        var val = filter_params_double.Select(v =>
                        {
                            int y = i / new_width;
                            int x = i - y * new_width - new_width / 2;
                            y -= new_height / 2;

                            double D0 = v[2];
                            double h = v[2] - D0;
                            double b = in_filter_zone - Functions.Butter(x, y, D0, (int)out_filter_zone, v[0], v[1], in_filter_zone, h);
                            return b;
                        }).Min();
                        filter_bytes[i * 3 + rgb] = (byte)Functions.Clamp(255 * val, 0, 255);
                        return a * val;
                    }).ToArray();
                }
                else if (filter_type == 4)  //Гаусса ФНЧ
                {
                    complex_bytes_filtered = complex_bytes.Select((a, i) =>
                    {
                        var val = filter_params_double.Select(v =>
                        {
                            int y = i / new_width;
                            int x = i - y * new_width - new_width / 2;
                            y -= new_height / 2;
                            double D0 = v[2];
                            double h = v[2] - D0;
                            double b = Functions.Gauss(x, y, D0, v[0], v[1], in_filter_zone, h);
                            return b;
                        }).Max();
                        filter_bytes[i * 3 + rgb] = (byte)Functions.Clamp(255 * val, 0, 255);
                        return a * val;
                    }).ToArray();
                }
                else if (filter_type == 5) //Гаусса ФВЧ
                {
                    complex_bytes_filtered = complex_bytes.Select((a, i) =>
                    {
                        var val = filter_params_double.Select(v =>
                        {
                            int y = i / new_width;
                            int x = i - y * new_width - new_width / 2;
                            y -= new_height / 2;
                            double D0 = v[2];
                            double h = v[2] - D0;
                            double b = in_filter_zone - Functions.Gauss(x, y, D0, v[0], v[1], in_filter_zone, h);
                            return b;
                        }).Min();
                        filter_bytes[i * 3 + rgb] = (byte)Functions.Clamp(255 * val, 0, 255);
                        return a * val;
                    }).ToArray();
                }
                else
                if (filter_type == 6) //Узкополосный режекторный
                {
                    complex_bytes_filtered = complex_bytes.Select((a, i) =>
                    {
                        int y = i / new_width;
                        int x = i - y * new_width - new_width / 2;
                        y -= new_height / 2;

                        foreach (var v in filter_params_double)
                        {
                            if (Math.Pow(x - v[0], 2) + Math.Pow(y - v[1], 2) <= Math.Pow(v[2], 2))
                            {
                                filter_bytes[i * 3 + rgb] = (byte)Functions.Clamp(255 * out_filter_zone, 0, 255);
                                return a * out_filter_zone;
                            }
                        }
                        filter_bytes[i * 3 + rgb] = (byte)Functions.Clamp(255 * in_filter_zone, 0, 255);
                        return a * in_filter_zone;

                    }).ToArray();
                }
                else
                if (filter_type == 7) //Узкополосный полосовой
                {
                    complex_bytes_filtered = complex_bytes.Select((a, i) =>
                    {
                        int y = i / new_width;
                        int x = i - y * new_width - new_width / 2;
                        y -= new_height / 2;

                        foreach (var v in filter_params_double)
                        {
                            if (Math.Pow(x - v[0], 2) + Math.Pow(y - v[1], 2) <= Math.Pow(v[2], 2))
                            {
                                filter_bytes[i * 3 + rgb] = (byte)Functions.Clamp(255 * in_filter_zone, 0, 255);
                                return a * in_filter_zone;
                            }

                        }
                        filter_bytes[i * 3 + rgb] = (byte)Functions.Clamp(255 * out_filter_zone, 0, 255);
                        return a * out_filter_zone;

                    }).ToArray();
                }

                //Обратное FFT
                var complex_bytes_result = Functions.FFT2(complex_bytes_filtered, new_width, new_height);

                for (int i = 0; i < new_width * new_height; ++i)
                {
                    int y = i / new_width;
                    int x = i - y * new_width - new_width / 2;
                    y -= new_height / 2;
                    new_bytes[i * 3 + rgb] = (byte)Functions.Clamp(Math.Round((Math.Pow(-1, x + y) * complex_bytes_result[i]).Real), 0, 255);
                    furier_bytes[i * 3 + rgb] = (byte)Functions.Clamp(furier_multiplyer * Functions.Bright(complex_bytes[i].Magnitude) * 255 / max_bright, 0, 255);
                }
            }

            //Bitmap для восстановленного изображения
            Bitmap new_bitmap = new Bitmap(new_width, new_height, PixelFormat.Format24bppRgb);
            new_bitmap.SetResolution(input.HorizontalResolution, input.VerticalResolution);
            writeImageBytes(new_bitmap, new_bytes);

            //Рисуем восстановленное изображение
            Bitmap new_bitmap_img = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            new_bitmap_img.SetResolution(input.HorizontalResolution, input.VerticalResolution);
            using (Graphics g1 = Graphics.FromImage(new_bitmap_img))
            {
                g1.DrawImageUnscaled(new_bitmap, 0, 0);
            }

            //Фурье-образ и кружки
            Bitmap new_bitmap_fur = new Bitmap(new_width, new_height, PixelFormat.Format24bppRgb);
            new_bitmap_fur.SetResolution(input.HorizontalResolution, input.VerticalResolution);
            writeImageBytes(new_bitmap_fur, furier_bytes);
            var g_fur = Graphics.FromImage(new_bitmap_fur);
            if (filter_type < 2)
                foreach (var v in filter_params_double)
                {
                    g_fur.DrawEllipse(Pens.GreenYellow, (int)v[0] - (int)v[2] + new_width / 2, (int)v[1] - (int)v[2] + new_height / 2, (int)v[2] * 2, (int)v[2] * 2);
                    g_fur.DrawEllipse(Pens.GreenYellow, (int)v[0] - (int)v[3] + new_width / 2, (int)v[1] - (int)v[3] + new_height / 2, (int)v[3] * 2, (int)v[3] * 2);
                }
            else
                foreach (var v in filter_params_double)
                {
                    g_fur.DrawEllipse(Pens.GreenYellow, (int)v[0] - (int)v[2] + new_width / 2, (int)v[1] - (int)v[2] + new_height / 2, (int)v[2] * 2, (int)v[2] * 2);
                }

            //Маска фильтра
            Bitmap new_bitmap_mask = new Bitmap(new_width, new_height, PixelFormat.Format24bppRgb);
            new_bitmap_mask.SetResolution(input.HorizontalResolution, input.VerticalResolution);
            writeImageBytes(new_bitmap_mask, filter_bytes);

            return (new_bitmap_img, new_bitmap_fur, new_bitmap_mask);
        }
    }
}
