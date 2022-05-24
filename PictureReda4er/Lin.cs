using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureReda4er
{
    public interface Interpol
    {
        double F(double _x);

        void Calc(Point[] points);

        Interpol Copy();
    }

    public class Point
    {
        public double X { set; get; }

        public double Y { set; get; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Point()
        {
        }
    }


    public class linearInterpolation : Interpol
    {
        private double[] x = new double[0];
        private double[] y = new double[0];

        public void Calc(Point[] points)
        {
            x = ((IEnumerable<Point>)points).Select((Func<Point, double>)(_p => _p.X)).ToArray<double>();
            y = ((IEnumerable<Point>)points).Select((Func<Point, double>)(_p => _p.Y)).ToArray<double>();
        }

        public Interpol Copy() => new linearInterpolation()
        {
            x = ((IEnumerable<double>)x).Select<double, double>((Func<double, double>)(_x => _x)).ToArray<double>(),
            y = ((IEnumerable<double>)y).Select<double, double>((Func<double, double>)(_x => _x)).ToArray<double>()
        };

        public double F(double _x)
        {
            int length = x.Length;
            if (length < 2)
                return 0.0;
            for (int index = 0; index < length - 1; ++index)
            {
                if (_x >= x[index] && _x < x[index + 1])
                {
                    double n1 = x[index + 1] - x[index];
                    double n2 = _x - x[index];
                    return y[index] * (1.0 - n2 / n1) + y[index + 1] * n2 / n1;
                }
            }
            return 0.0;
        }
    }

}
