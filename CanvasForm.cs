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
        private ListDictionary shapes = new ListDictionary();
        // Dictionary: GraphicsPath shape, Pen pen, bool show?, bool fill?, bool Selected?
        private GraphicsPath selectedShape;
        private Point lastMouseDown;
        public Graphics g;
        Pen blackPen = new Pen(Color.Black);
        Pen redPen = new Pen(Color.Red);
        Pen bluePen = new Pen(Color.Blue);
        Pen selectedPen;

        public CanvasForm()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
            
        }

        void Canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            foreach (GraphicsPath shape in shapes)
            {
                g.DrawPath(bluePen, shape);
            }
            
        }
        
        void createSquare_Click(object sender, EventArgs e)
        {
            
            Shapes.Rectangle defaultSquare = new Shapes.Rectangle(new Point(50, 50), new Point(250, 250));
            GraphicsPath square = new GraphicsPath();
            square.AddPolygon(defaultSquare.ps);
            List<object> attributes = new List<object>();
            // Pen
            attributes.Add(blackPen);
            // Show?
            attributes.Add(true);
            // Fill?
            attributes.Add(false);
            // Selected?
            attributes.Add(false);
            shapes.Add(square, attributes);
            g.DrawPath(blackPen, square);
            selectedPen = blackPen;
            Canvas.Invalidate();
            Canvas.Paint()
        }
        
        void CreateTriangle_Click(object sender, EventArgs e)
        {

            Shapes.Triangle defaultTri = new Shapes.Triangle(new Point(100, 50), new Point(250, 250), new Point(50, 300));
            GraphicsPath tri = new GraphicsPath();
            tri.AddPolygon(defaultTri.ps);
            shapes.Add(tri);
            Canvas.Invalidate();
            
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
