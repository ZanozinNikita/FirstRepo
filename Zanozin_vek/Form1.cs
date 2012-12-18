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
            if (RCircle.Checked)
            {
                if (isShapeStart == true)
                {
                    ShapeStart.X = e.X;
                    ShapeStart.Y = e.Y;
                    isShapeStart = false;
                }
                else
                {
                    Shapes.Add(new Circle(ShapeStart, e.Location));
                    isShapeStart = true;
                    Refresh();
                }
            }
        }
        private void R_CheckedChanged(object sender, EventArgs e)
        {
            isShapeStart = true;
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Shape p in this.Shapes)
            {
                p.DrawWith(e.Graphics, pMain);
            }
        }

        private void Clear_button_Click(object sender, EventArgs e)
        {
            Shapes.Clear();
            isShapeStart = true;
            this.Refresh();
        }
    }
}
