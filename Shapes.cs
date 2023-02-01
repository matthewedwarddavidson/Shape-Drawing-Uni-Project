using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace CGP_Assessment_Project
{
    public partial class Shapes
    {
        public readonly struct Shape
        {
            public readonly List<double> lens;
            public readonly GraphicsPath shapePath;
            public readonly Pen pen;
            public readonly Brush brush;
            public readonly Color fillColour;
            public readonly bool show, fill, selected;

            public Shape (List<double> lens, GraphicsPath shapePath, Pen pen, Color fillColour, bool show, bool fill, bool selected) : this()
            {
                this.lens = lens;
                this.shapePath = shapePath;
                this.pen = pen;
                brush = new SolidBrush(fillColour);
                this.fillColour = fillColour;
                this.show = show;
                this.fill = fill;
                this.selected = selected;
            }

            public Shape (Rectangle rectangle) : this()
            {
                lens = rectangle.lens;
                shapePath = rectangle.shapePath;
                pen = rectangle.pen;
                brush = rectangle.brush;
                fillColour = rectangle.fillColour;
                show = rectangle.show;
                fill = rectangle.fill;
                selected = rectangle.selected;
            }
            public Shape(Triangle triangle) : this()
            {
                lens = triangle.lens;
                shapePath = triangle.shapePath;
                pen = triangle.pen;
                brush = triangle.brush;
                fillColour = triangle.fillColour;
                show = triangle.show;
                fill = triangle.fill;
                selected = triangle.selected;
            }

        }


        public readonly struct Rectangle
        {
            public readonly List<double> lens;
            public readonly GraphicsPath shapePath;
            public readonly Pen pen;
            public readonly Brush brush;
            public readonly Color fillColour;
            public readonly bool show, fill, selected;

            public Rectangle(Point p1, Point p2, Pen pen, Color fillColour, bool show, bool fill, bool selected) : this()
            {
                Point px1y1 = p1;
                Point px1y2 = new Point(p1.X, p2.Y);
                Point px2y1 = new Point(p2.X, p1.Y);
                Point px2y2 = p2;

                double wid = Math.Abs(p1.X - p2.X);
                double len = Math.Abs(p1.Y - p2.Y);

                lens = new List<double>();
                lens.AddRange(new List<double> { wid, len, wid, len });

                shapePath = new GraphicsPath();
                shapePath.AddPolygon(new Point[] { px1y1, px2y1, px2y2, px1y2});

                this.pen = pen;
                brush = new SolidBrush(fillColour);
                this.fillColour = fillColour;
                this.show = show;
                this.fill = fill;
                this.selected = selected;
                

            }
        }

        public readonly struct Triangle
        {
            public readonly List<double> lens;
            public readonly GraphicsPath shapePath;
            public readonly Pen pen;
            public readonly Brush brush;
            public readonly Color fillColour;
            public readonly bool show, fill, selected;

            public Triangle(Point p1, Point p2, Point p3, Pen pen, Color fillColour, bool show, bool fill, bool selected) : this()
            {
                double len1 = Math.Sqrt(Math.Pow(Math.Abs(p1.X - p2.X), 2.0)  + Math.Pow(Math.Abs(p1.Y - p2.Y), 2.0));
                double len2 = Math.Sqrt(Math.Pow(Math.Abs(p2.X - p3.X), 2.0)  + Math.Pow(Math.Abs(p2.Y - p3.Y), 2.0));
                double len3 = Math.Sqrt(Math.Pow(Math.Abs(p3.X - p1.X), 2.0)  + Math.Pow(Math.Abs(p3.Y - p1.Y), 2.0));

                lens = new List<double>();
                lens.AddRange(new List<double> { len1, len2, len3 });

                shapePath = new GraphicsPath();
                shapePath.AddPolygon(new Point[] { p1, p2, p3 });

                this.pen = pen;
                brush = new SolidBrush(fillColour);
                this.fillColour = fillColour;
                this.show = show;
                this.fill = fill;
                this.selected = selected;
            }
        }

    }
}
