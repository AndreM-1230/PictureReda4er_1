using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace PictureReda4er
{
    public class Pan : Control
    {
        private readonly List<Point> points = new();
        public Interpol interpol = (Interpol)new linearInterpolation();
        private Point dragingPoint;
        private Bitmap b;
        private Graphics g;
        private Pan.State state;


        public event Pan.changed_delegate changed_event;

        public Pan()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            Paint += new PaintEventHandler(P_event);
            MouseClick += new MouseEventHandler(Click);
            MouseDown += new MouseEventHandler(Down);
            MouseUp += new MouseEventHandler(up);
            MouseMove += new MouseEventHandler(Go);
            Timer y = new()
            {
                Interval = 30
            };
            y.Tick += (EventHandler)((s, a) => Refresh());
            VisibleChanged += (EventHandler)((s, a) => y.Start());
            SizeChanged += (EventHandler)((s, a) =>
            {
                Size size = Size;
                int width = size.Width;
                size = Size;
                int height = size.Height;
                b = new Bitmap(width, height);
                g = Graphics.FromImage((Image)b);
                points.Add(new Point()
                {
                    X = 0.0,
                    Y = (double)Size.Height - 1.0
                });
                points.Add(new Point()
                {
                    X = (double)Size.Width - 1.0,
                    Y = 0.0
                });
                interpol.Calc(points.Select<Point, Point>((Func<Point, Point>)(p => new Point(p.X / (double)(Size.Width - 1), p.Y / (double)(Size.Height - 1)))).ToArray<Point>());
            });
        }

        public void Emit()
        {
            Pan.changed_delegate changedEvent = changed_event;
            if (changedEvent == null)
                return;
            changedEvent(interpol.Copy());
        }

        public void Clear()
        {
            if (points.Count <= 2)
                return;
            points.RemoveRange(1, points.Count - 2);
            interpol.Calc(points.Select<Point, Point>((Func<Point, Point>)(p => new Point(p.X / (double)(Size.Width - 1), p.Y / (double)(Size.Height - 1)))).ToArray<Point>());
            Pan.changed_delegate changedEvent = changed_event;
            if (changedEvent == null)
                return;
            changedEvent(interpol.Copy());
        }

        private void Go(object sender, MouseEventArgs e)
        {
            if (state != Pan.State.POINT_DRAG)
                return;
            Point dragingPoint1 = dragingPoint;
            int x = e.X;
            Size size = Size;
            int num1 = size.Width - 2;
            int num2;
            if (x < num1)
            {
                num2 = e.X <= 1 ? 1 : e.X;
            }
            else
            {
                size = Size;
                num2 = size.Width - 2;
            }
            double num3 = (double)num2;
            dragingPoint1.X = num3;
            Point dragingPoint2 = dragingPoint;
            int y = e.Y;
            size = Size;
            int num4 = size.Height - 1;
            int num5;
            if (y <= num4)
            {
                num5 = e.Y < 0 ? 0 : e.Y;
            }
            else
            {
                size = Size;
                num5 = size.Height - 1;
            }
            double num6 = (double)num5;
            dragingPoint2.Y = num6;
        }

        private void up(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            state = Pan.State.FREE;
            Pan.changed_delegate changedEvent = changed_event;
            if (changedEvent == null)
                return;
            changedEvent(interpol.Copy());
        }

        private void Down(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                for (int index = 1; index < points.Count - 1; ++index)
                {
                    Point point = points[index];
                    if (Math.Pow(point.X - (double)e.Location.X, 2.0) + Math.Pow(point.Y - (double)e.Location.Y, 2.0) <= 225.0)
                    {
                        state = Pan.State.POINT_DRAG;
                        dragingPoint = point;
                        return;
                    }
                }
                System.Drawing.Point location = e.Location;
                double y = (double)location.Y;
                Interpol interpol = this.interpol;
                location = e.Location;
                double _x = 1.0 * (double)location.X / (double)(Size.Width - 1);
                double num = interpol.F(_x) * (double)Size.Height;
                if (Math.Abs(y - num) >= 30.0)
                    return;
                Point myPoint1 = new();
                location = e.Location;
                myPoint1.X = (double)location.X;
                location = e.Location;
                myPoint1.Y = (double)location.Y;
                Point myPoint2 = myPoint1;
                points.Add(myPoint2);
                points.Sort((Comparison<Point>)((p1, p2) => p1.X.CompareTo(p2.X)));
                interpol.Calc(points.Select<Point, Point>((Func<Point, Point>)(p => new Point(p.X / (double)(Size.Width - 1), p.Y / (double)(Size.Height - 1)))).ToArray<Point>());
                state = Pan.State.POINT_DRAG;
                dragingPoint = myPoint2;
            }
            else
            {
                if (e.Button != MouseButtons.Right)
                    return;
                for (int index = 1; index < points.Count - 1; ++index)
                {
                    Point point = points[index];
                    if (Math.Pow(point.X - (double)e.Location.X, 2.0) + Math.Pow(point.Y - (double)e.Location.Y, 2.0) <= 225.0)
                    {
                        points.Remove(point);
                        interpol.Calc(points.Select<Point, Point>((Func<Point, Point>)(p => new Point(p.X / (double)(Size.Width - 1), p.Y / (double)(Size.Height - 1)))).ToArray<Point>());
                    }
                    changed_event?.Invoke(interpol.Copy());
                }
            }
        }

        private new void Click(object sender, MouseEventArgs e)
        {
        }

        public void P_event(object sender, PaintEventArgs e)
        {
            Pan pan = sender as Pan;
            Graphics graphics1 = e.Graphics;
            graphics1.InterpolationMode = InterpolationMode.NearestNeighbor;
            Graphics graphics2 = graphics1;
            Brush white = Brushes.White;
            Size size1 = pan.Size;
            int width1 = size1.Width;
            size1 = pan.Size;
            int height1 = size1.Height;
            graphics2.FillRectangle(white, 0, 0, width1, height1);
            if (state == Pan.State.POINT_DRAG)
            {
                points.Sort((Comparison<Point>)((p1, p2) => p1.X.CompareTo(p2.X)));
                interpol.Calc(points.Select<Point, Point>((Func<Point, Point>)(p => new Point(p.X / (double)(Size.Width - 1), p.Y / (double)(Size.Height - 1)))).ToArray<Point>());
            }
            foreach (Point point in points)
            {
                int width2 = 8;
                int height2 = 8;
                graphics1.FillRectangle(Brushes.Black, (int)(point.X - 0.5 * (double)width2), (int)(point.Y - 0.5 * (double)height2), width2, height2);
            }
            if (points.Count >= 2)
            {
                for (int index = (int)points[0].X + 1; (double)index < points[points.Count - 1].X; ++index)
                {
                    Graphics graphics3 = graphics1;
                    Pen Black = Pens.Black;
                    int x1 = index;
                    Interpol interpol1 = interpol;
                    double num1 = 1.0 * (double)index;
                    Size size2 = Size;
                    double width3 = (double)size2.Width;
                    double _x1 = num1 / width3;
                    double num2 = interpol1.F(_x1);
                    size2 = Size;
                    double height3 = (double)size2.Height;
                    int y1 = (int)(num2 * height3);
                    int x2 = index - 1;
                    Interpol interpol2 = interpol;
                    double num3 = 1.0 * (double)(index - 1);
                    size2 = Size;
                    double width4 = (double)size2.Width;
                    double _x2 = num3 / width4;
                    double num4 = interpol2.F(_x2);
                    size2 = Size;
                    double height4 = (double)size2.Height;
                    int y2 = (int)(num4 * height4);
                    graphics3.DrawLine(Black, x1, y1, x2, y2);
                }
            }
            if (state != Pan.State.POINT_DRAG)
                return;
            int width5 = 8;
            int height5 = 8;
            graphics1.FillRectangle(Brushes.Black, (int)(dragingPoint.X - 0.3 * (double)width5), (int)(dragingPoint.Y - 0.3 * (double)height5), width5, height5);
            Pan.changed_delegate changedEvent = changed_event;
            if (changedEvent == null)
                return;
            changedEvent(interpol.Copy());
        }

        public delegate void changed_delegate(Interpol li);

        private enum State
        {
            FREE,
            POINT_DRAG,
        }
    }
}
