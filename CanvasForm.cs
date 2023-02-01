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

namespace CGP_Assessment_Project
{
    public partial class CanvasForm : Form
    {
        private List<Shapes.Shape> shapes = new List<Shapes.Shape>();
        // Dictionary: GraphicsPath shape, Pen pen, bool show?, bool fill?, bool Selected?
        private Point lastMouseDown;
        Pen blackPen = new Pen(Color.Black);
        Pen redPen = new Pen(Color.Red);
        Pen bluePen = new Pen(Color.Blue);

        public CanvasForm()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
            
        }

        void Canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            foreach (Shapes.Shape shape in shapes)
            {
                if (shape.show)
                {
                    g.DrawPath(pen: shape.pen,
                               path: shape.shapePath);
                    g.FillPath(brush: shape.brush,
                               path: shape.shapePath);
                }
            }
            
        }
        
        void createSquare_Click(object sender, EventArgs e)
        {
            
            Shapes.Shape Square = new Shapes.Shape(new Shapes.Rectangle(p1: new Point(50, 50), 
                                                                        p2: new Point(250, 250),
                                                                        pen: redPen,
                                                                        fillColour: Color.Blue,
                                                                        show: true,
                                                                        fill: true,
                                                                        selected: false));
            shapes.Add(Square);
            Canvas.Invalidate();
        }
        
        void CreateTriangle_Click(object sender, EventArgs e)
        {
            Shapes.Shape triangle = new Shapes.Shape(new Shapes.Triangle(p1: new Point(100, 50),
                                                                         p2: new Point(250, 250),
                                                                         p3: new Point(50, 300),
                                                                         pen: blackPen,
                                                                         fillColour: Color.Red,
                                                                         show: true,
                                                                         fill: true,
                                                                         selected: false));
            shapes.Add(triangle);
            Canvas.Invalidate();
            
        }

        
        void Control_MouseDown(object sender, MouseEventArgs e)
        {
            Point mouseDownLoc = new Point(e.X, e.Y);
            lastMouseDown = mouseDownLoc;
            foreach (Shapes.Shape shape in shapes)
            {
                if (shape.shapePath.IsVisible(mouseDownLoc))
                {
                    Shapes.Shape newShape = new Shapes.Shape(lens: shape.lens,
                                                             shapePath: shape.shapePath,
                                                             pen: shape.pen,
                                                             fillColour: shape.fillColour,
                                                             show: true,
                                                             fill: shape.fill,
                                                             selected: true);
                    shapes.Remove(shape);
                    shapes.Add(newShape);
                    Canvas.Invalidate();
                    break;
                    
                    
                }
            }
        }
        
        void Control_MouseUp(object sender, MouseEventArgs e)
        {
            Point mouseUpLoc = new Point(e.X, e.Y);
            Matrix transformMatrix = new Matrix();
            transformMatrix.Translate(-(lastMouseDown.X - mouseUpLoc.X),
                                      -(lastMouseDown.Y - mouseUpLoc.Y));
            foreach (Shapes.Shape shape in shapes)
            {
                if (shape.selected)
                {
                    transformMatrix.TransformPoints(shape.shapePath.PathPoints);
                    GraphicsPath newPath = shape.shapePath;
                    newPath.Transform(transformMatrix);
                    Shapes.Shape newShape = new Shapes.Shape(lens: shape.lens,
                                                             shapePath: newPath,
                                                             pen: shape.pen,
                                                             fillColour: shape.fillColour,
                                                             show: true,
                                                             fill: shape.fill,
                                                             selected: false);
                    shapes.Remove(shape);
                    shapes.Add(newShape);
                    Canvas.Invalidate();
                    break;
                }
            }

        }
        void Mouse_Click(object sender, MouseEventArgs e1)
        {
            Point mouseClickLoc = new Point(e1.X, e1.Y);
            if (e1.Button == MouseButtons.Right)
            {
                foreach (Shapes.Shape shape in shapes)
                {
                    if (shape.shapePath.IsVisible(mouseClickLoc))
                    {
                        shapes.Remove(shape);
                        break;
                    }
                }
            } 
            if (e1.Button == MouseButtons.Left)
            {
                foreach (Shapes.Shape shape in shapes)
                {
                    if (shape.shapePath.IsVisible(mouseClickLoc))
                    {
                        Shapes.Shape newShape = new Shapes.Shape(lens: shape.lens,
                                                                 shapePath: shape.shapePath,
                                                                 pen: bluePen,
                                                                 fillColour: shape.fillColour,
                                                                 show: true,
                                                                 fill: shape.fill,
                                                                 selected: true);
                        shapes.Remove(shape);
                        shapes.Add(newShape);
                        Canvas.Invalidate();
                        break;
                    } 
                } 
            }
        }


    }
}
