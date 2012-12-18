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
        public Pen pTemp = new Pen(Color.Gray);
        public Shape tempShape;
        public Form1()
        {
            InitializeComponent();
        }
        private void AddShape(Shape shape)
        {
            Shapes.Add(shape);
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            this.Text = Convert.ToString(e.X) + " " + Convert.ToString(e.Y);
            if (RCross.Checked)
            {
                AddShape(tempShape);
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
                    AddShape(tempShape);
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
                    AddShape(tempShape);
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
            if (tempShape != null)
            {
                tempShape.DrawWith(e.Graphics, pTemp);
            }
            foreach (Shape p in this.Shapes)
            {
                p.DrawWith(e.Graphics, pMain);
            }
        }

        private void Clear_button_Click(object sender, EventArgs e)
        {
            Shapes.Clear();
            isShapeStart = true;
            tempShape = null;
            this.Refresh();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Point TempPoint = new Point();
            if (RCross.Checked)
            {
                tempShape = new Cross(e.Location);
                this.Refresh();
            }
            else if (RLine.Checked)
            {
                if (isShapeStart != true)
                {
                    TempPoint.X = e.X;
                    TempPoint.Y = e.Y;
                    tempShape = new Line(ShapeStart, TempPoint);
                    this.Refresh();
                }
            }
            else if (RCircle.Checked)
            {
                if (isShapeStart != true)
                {
                    TempPoint.X = e.X;
                    TempPoint.Y = e.Y;
                    tempShape = new Circle(ShapeStart, TempPoint);
                    this.Refresh();
                }
            }  
        }
    }
}
