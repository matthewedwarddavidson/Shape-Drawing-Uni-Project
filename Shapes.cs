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
                this.lens       = lens;
                this.shapePath  = shapePath;
                this.pen        = pen;
                brush           = new SolidBrush(fillColour);
                this.fillColour = fillColour;
                this.show       = show;
                this.fill       = fill;
                this.selected   = selected;
            }

            public Shape (Rectangle rectangle) : this()
            {
                lens            = rectangle.lens;
                shapePath       = rectangle.shapePath;
                pen             = rectangle.pen;
                brush           = rectangle.brush;
                fillColour      = rectangle.fillColour;
                show            = rectangle.show;
                fill            = rectangle.fill;
                selected        = rectangle.selected;
            }
            public Shape(Circle circle) : this()
            {
                lens            = circle.lens;
                shapePath       = circle.shapePath;
                pen             = circle.pen;
                brush           = circle.brush;
                fillColour      = circle.fillColour;
                show            = circle.show;
                fill            = circle.fill;
                selected        = circle.selected;
            }
            public Shape(Triangle triangle) : this()
            {
                lens            = triangle.lens;
                shapePath       = triangle.shapePath;
                pen             = triangle.pen;
                brush           = triangle.brush;
                fillColour      = triangle.fillColour;
                show            = triangle.show;
                fill            = triangle.fill;
                selected        = triangle.selected;
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
                double wid = Math.Abs(p1.X - p2.X);
                double len = Math.Abs(p1.Y - p2.Y);

                List<double> lens = new List<double> { wid, len, wid, len };
                shapePath = new GraphicsPath();
                shapePath.AddPolygon(new Point[] { p1,
                                                   new Point(p2.X, p1.Y), 
                                                   p2, 
                                                   new Point(p1.X, p2.Y) });

                this.pen        = pen;
                brush           = new SolidBrush(fillColour);
                this.fillColour = fillColour;
                this.show       = show;
                this.fill       = fill;
                this.selected   = selected;
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
                List<double> lens = new List<double> { pythagorise(p1, p2), 
                                                       pythagorise(p2, p3), 
                                                       pythagorise(p3, p1) };
                shapePath = new GraphicsPath();
                shapePath.AddPolygon(new Point[] { p1, p2, p3 });

                this.pen = pen;
                brush = new SolidBrush(fillColour);
                this.fillColour = fillColour;
                this.show = show;
                this.fill = fill;
                this.selected = selected;
            }
            double pythagorise(Point p1, Point p2) => Math.Sqrt(Math.Pow(Math.Abs(p1.X - p2.X), 2.0) + Math.Pow(Math.Abs(p1.Y - p2.Y), 2.0));
        }

        public readonly struct Circle
        {
            public readonly List<double> lens;
            public readonly GraphicsPath shapePath;
            public readonly Pen pen;
            public readonly Brush brush;
            public readonly Color fillColour;
            public readonly bool show, fill, selected;

            public Circle(Point p1, Point p2, Pen pen, Color fillColour, bool show, bool fill, bool selected) : this()
            {
                float wid = Math.Abs(p1.X - p2.X);
                float len = Math.Abs(p1.Y - p2.Y);

                this.lens = new List<double> { wid, len, wid, len };
                shapePath = new GraphicsPath();
                shapePath.AddEllipse(p1.X, p1.Y, wid, len);

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
