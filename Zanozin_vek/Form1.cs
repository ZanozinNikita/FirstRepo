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
        public string curFile = "text.txt";
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
            ShapesList.Items.Add(shape.AddToList());
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int q = 0;
                foreach (Shape shape in Shapes)
                {
                    if (shape.IsNearTo(e.Location))
                    {
                        ShapesList.SetSelected(q, true);
                    }
                    q++;
                }
            }
            if (e.Button == MouseButtons.Left)
            {
                this.Text = Convert.ToString(e.X) + " " + Convert.ToString(e.Y);
                if (RCross.Checked)
                {
                    AddShape(tempShape);
                    isShapeStart = true;
                }
                if (RLine.Checked)
                {
                    if (isShapeStart == true)
                    {
                        ShapeStart = e.Location;
                        isShapeStart = false;
                    }
                    else
                    {
                        AddShape(tempShape);
                        isShapeStart = true;
                    }
                }
                if (RCircle.Checked)
                {
                    if (isShapeStart == true)
                    {
                        ShapeStart = e.Location;
                        isShapeStart = false;
                    }
                    else
                    {
                        AddShape(tempShape);
                        isShapeStart = true;
                    }
                }
                Refresh();
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
            ShapesList.Items.Clear();
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
                    TempPoint = e.Location;
                    tempShape = new Line(ShapeStart, TempPoint);
                    this.Refresh();
                }
            }
            else if (RCircle.Checked)
            {
                if (isShapeStart != true)
                {
                    TempPoint = e.Location;
                    tempShape = new Circle(ShapeStart, TempPoint);
                    this.Refresh();
                }
            }  
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                curFile = openFileDialog1.FileName;
                Shapes.Clear();
                isShapeStart = true;
                this.Refresh();
                StreamReader sr = new StreamReader(curFile);
                while (!sr.EndOfStream)
                {
                    string type = sr.ReadLine();
                    switch (type)
                    {
                        case "Cross":
                            {
                                Shapes.Add(new Cross(sr));
                                this.Refresh();
                                break;
                            }
                        case "Line":
                            {
                                Shapes.Add(new Line(sr));
                                this.Refresh();
                                break;
                            }
                        case "Circle":
                            {
                                Shapes.Add(new Circle(sr));
                                this.Refresh();
                                break;
                            }
                        case "":
                            {
                                this.Refresh();
                                break;
                            }
                    }
                }
                sr.Close();
            }
        }

        private void сохранитькакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                curFile = saveFileDialog1.FileName;
                StreamWriter sw = new StreamWriter(curFile);
                foreach (Shape p in this.Shapes)
                {
                    p.SaveTo(sw);
                }
                sw.Close();
            }
        }

        private void delete_item_Click(object sender, EventArgs e)
        {
            while (ShapesList.SelectedIndices.Count > 0)
            {
                Shapes.RemoveAt(ShapesList.SelectedIndices[0]);
                ShapesList.Items.RemoveAt(ShapesList.SelectedIndices[0]);
                isShapeStart = true;
                tempShape = null;
            }
            Refresh();  
        }
    }
}
