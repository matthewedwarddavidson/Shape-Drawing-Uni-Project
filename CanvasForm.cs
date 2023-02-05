using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CGP_Assessment_Project.Shapes;

namespace CGP_Assessment_Project
{
    public partial class CanvasForm : Form
    {
        private readonly List<Shapes.Shape> shapes = new List<Shapes.Shape>();
        private readonly Func<List<double>, GraphicsPath, Pen, Color, bool, bool, bool, Shape> getShape;
        private readonly Func<Shapes.Rectangle, Shape> getShape_rectangle;
        private readonly Func<Triangle, Shape> getShape_triangle;
        private readonly Func<Circle, Shape> getShape_circle;

        private readonly Func<Point, Point, Pen, Color, bool, bool, bool, Shapes.Rectangle> getRectangle;
        private readonly Func<Point, Point, Pen, Color, bool, bool, bool, Circle> getCircle;
        private readonly Func<Point, Point, Point, Pen, Color, bool, bool, bool, Triangle> getTriangle;

        Pen black_pen = new Pen(Color.Black);
        Pen red_pen = new Pen(Color.Red);

        private readonly Action<PaintEventArgs, Shape> drawShape;
        private readonly Action<PaintEventArgs, Shape> fillShape;

        public CanvasForm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.ResizeRedraw, true);
            DoubleBuffered = true;

            getRectangle = (p1, p2, pen, fillColour, show, fill, selected) =>
                new Shapes.Rectangle(p1, p2, pen, fillColour, show, fill, selected);
            getCircle = (p1, p2, pen, fillColour, show, fill, selected) =>
                new Shapes.Circle(p1, p2, pen, fillColour, show, fill, selected);
            getTriangle = (p1, p2, p3, pen, fillColour, show, fill, selected) =>
                new Shapes.Triangle(p1, p2, p3, pen, fillColour, show, fill, selected);
            getShape = (lens, path, pen, fillColour, show, fill, selected) =>
                new Shape(lens, path, pen, fillColour, show, fill, selected);
            getShape_rectangle = (rectangle) => 
                new Shape(rectangle);
            getShape_circle = (circle) => 
                new Shape(circle);
            getShape_triangle = (triangle) => 
                new Shape(triangle);
            

            drawShape = (e, shape) => e.Graphics.DrawPath(shape.pen, shape.shapePath);
            fillShape = (e, shape) => e.Graphics.FillPath(shape.brush, shape.shapePath);
            Canvas.Paint += (sender, e) =>
            {
                foreach (Shape shape in shapes)
                {
                    drawShape(e, shape);
                    fillShape(e, shape);
                };
            };

            createSquare.Click += (sender, e) =>
            {
                shapes.Add(getShape_rectangle(getRectangle(new Point(50, 50), new Point(250, 250), black_pen, Color.Blue, true, true, false)));

                Canvas.Invalidate();
            };
            createTriangle.Click += (sender, e) =>
            {
                shapes.Add(getShape_triangle(getTriangle(new Point(100, 150), new Point(250, 250), new Point(40, 300), black_pen, Color.Blue, true, true, false)));

                Canvas.Invalidate();
            };
            createCircle.Click += (sender, e) =>
            {
                shapes.Add(getShape_circle(getCircle(new Point(50, 50), new Point(250, 250), black_pen, Color.Blue, true, true, false)));

                Canvas.Invalidate();
            };

        }
    }
}
