using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace CGP_Assessment_Project
{
    public partial class Shapes
    {
        public readonly struct Shape
        {

        }


        public readonly struct Rectangle
        {
            public readonly int len, wid;
            public readonly Point[] ps;

            public Rectangle(Point p1, Point p2) : this()
            {
                Point px1y1 = p1;
                Point px1y2 = new Point(p1.X, p2.Y);
                Point px2y1 = new Point(p2.X, p1.Y);
                Point px2y2 = p2;
                this.wid = Math.Abs(p1.X - p2.X);
                this.len = Math.Abs(p1.Y - p2.Y);
                this.ps = new Point[] {px1y1, px2y1, px2y2, px1y2};
            }
        }

        public readonly struct Triangle
        {
            public readonly double len1, len2, len3;
            public readonly Point[] ps;

            public Triangle(Point p1, Point p2, Point p3) : this()
            {
                this.len1 = Math.Sqrt(Math.Pow(Math.Abs(p1.X - p2.X), 2.0)  + Math.Pow(Math.Abs(p1.Y - p2.Y), 2.0));
                this.len2 = Math.Sqrt(Math.Pow(Math.Abs(p2.X - p3.X), 2.0)  + Math.Pow(Math.Abs(p2.Y - p3.Y), 2.0));
                this.len3 = Math.Sqrt(Math.Pow(Math.Abs(p3.X - p1.X), 2.0)  + Math.Pow(Math.Abs(p3.Y - p1.Y), 2.0));
                this.ps = new Point[] {p1, p2, p3};
            }
        }

    }
}
