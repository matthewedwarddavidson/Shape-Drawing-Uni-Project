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
                g.DrawPath(bluePen, shape.shapePath);
                g.FillPath(new SolidBrush()
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
            
            
        }

        
        void Control_MouseDown(object sender, MouseEventArgs e)
        {
            Point mouseDownLoc = new Point(e.X, e.Y);
            lastMouseDown = mouseDownLoc;
            foreach (GraphicsPath path in shapes)
            {
                if (path.IsVisible(mouseDownLoc))
                {
                    selectedShape = path;
                    
                    
                }
            }
        }
        
        void Control_MouseUp(Object sender, MouseEventArgs e)
        {
            Point mouseUpLoc = new Point(e.X, e.Y);
            if (selectedShape != null)
            {
                Matrix transformMatrix = new Matrix();
                transformMatrix.Translate(-(lastMouseDown.X - mouseUpLoc.X),
                    -(lastMouseDown.Y - mouseUpLoc.Y));
                transformMatrix.TransformPoints(selectedShape.PathPoints);
                selectedShape.Transform(transformMatrix);
                selectedPen = blackPen;
                Canvas.Invalidate();
                
            }
        }
        void Mouse_Click(object sender, MouseEventArgs e1)
        {
            Point mouseClickLoc = new Point(e1.X, e1.Y);
            if (e1.Button == MouseButtons.Right)
            {
                foreach (GraphicsPath path in shapes)
                {
                    if (path.IsVisible(mouseClickLoc))
                    {
                        shapes.Remove(path);
                        break;
                    }
                }
            } 
            if (e1.Button == MouseButtons.Left)
            {
                foreach (GraphicsPath path in shapes)
                {
                    if (path.IsVisible(mouseClickLoc))
                    {
                        shapes.Add(path);
                        selectedPen = bluePen;
                        Canvas.Invalidate();
                        shapes.Remove(path);
                        break;
                    } 
                } 
            }
        }


    }
}
