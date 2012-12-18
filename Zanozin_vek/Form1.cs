using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Zanozin_vek
{
    public abstract class Shape
    {
        public abstract void DrawWith(Graphics g, Pen pen);
    }
    public partial class Form1 : Form
    {
        public Pen pMain = new Pen(Color.Black);
        List<Shape> Shapes = new List<Shape>();
        public bool isShapeStart = true;
        public Point ShapeStart = new Point();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            this.Text = Convert.ToString(e.X) + " " + Convert.ToString(e.Y);
            if (RCross.Checked)
            {
                Shapes.Add(new Cross(e.Location));
                isShapeStart = true;
                Refresh();
            }
            if (RLine.Checked)
            {
                if (isShapeStart == true)
                {
                    ShapeStart.X = e.X;
                    ShapeStart.Y = e.Y;
                    isShapeStart = false;
                }
                else
                {
                    Shapes.Add(new Line(ShapeStart,e.Location));
                    isShapeStart = true;
                    Refresh();
                }
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Shape p in this.Shapes)
            {
                p.DrawWith(e.Graphics, pMain);
            }
        }
    }
    public class Cross : Shape
    {
        Point F;
        public Cross(Point _F)
        {
            F = _F;
        }
        public override void DrawWith(Graphics g, Pen pen)
        {
            g.DrawLine(pen, F.X - 2, F.Y - 2, F.X + 2, F.Y + 2);
            g.DrawLine(pen, F.X + 2, F.Y - 2, F.X - 2, F.Y + 2);
        }
    }
    public class Line : Shape
    {
        Point S;
        Point F;
        public Line(Point _S, Point _F)
        {
            this.S = _S;
            this.F = _F;
        }
        public override void DrawWith(Graphics g, Pen pen)
        {
            g.DrawLine(pen, this.S.X, this.S.Y, this.F.X, this.F.Y);
        }
    }
}
