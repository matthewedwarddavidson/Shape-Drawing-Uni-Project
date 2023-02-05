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
        private Point lastMouseDown;

        Pen blackPen = new Pen(Color.Black);
        Pen redPen = new Pen(Color.Red);
        Pen bluePen = new Pen(Color.Blue);

        List<Shapes.Shape> get_selected_shapes(List<Shapes.Shape> shapes) => shapes.Where(shape => shape.selected).ToList();
        List<Shapes.Shape> get_shown_shapes(List<Shapes.Shape> shapes) => shapes.Where(shape => shape.show).ToList();

        public CanvasForm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.ResizeRedraw, true);
            DoubleBuffered = true;
            
        }

        void Canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            foreach (Shapes.Shape shape in get_shown_shapes(shapes))
            {
                    g.DrawPath(pen: shape.pen,
                               path: shape.shapePath);
                    g.FillPath(brush: shape.brush,
                               path: shape.shapePath);
            }
            
        }
        
        void createSquare_Click(object sender, EventArgs e)
        {

            shapes.Add(new Shapes.Shape(new Shapes.Rectangle(p1: new Point(50, 50),
                                                             p2: new Point(250, 250),
                                                             pen: redPen,
                                                             fillColour: Color.Blue,
                                                             show: true,
                                                             fill: true,
                                                             selected: false)));
            Canvas.Invalidate();
        }

        void create_circle_Click(object sender, EventArgs e)
        {

            shapes.Add(new Shapes.Shape(new Shapes.Circle(p1: new Point(50, 50),
                                                             p2: new Point(250, 250),
                                                             pen: redPen,
                                                             fillColour: Color.Blue,
                                                             show: true,
                                                             fill: true,
                                                             selected: false)));
            Canvas.Invalidate();
        }

        void CreateTriangle_Click(object sender, EventArgs e)
        {
            shapes.Add(new Shapes.Shape(new Shapes.Triangle(p1: new Point(100, 50),
                                                            p2: new Point(250, 250),
                                                            p3: new Point(50, 300),
                                                            pen: blackPen,
                                                            fillColour: Color.Red,
                                                            show: true,
                                                            fill: true,
                                                            selected: false)));
            Canvas.Invalidate();
            
        }

        
        void Control_MouseDown(object sender, MouseEventArgs e)
        {

        }
        
        void Control_MouseUp(object sender, MouseEventArgs e)
        {

        }
        void Mouse_Click(object sender, MouseEventArgs e1)
        {
            
        }


    }
}
