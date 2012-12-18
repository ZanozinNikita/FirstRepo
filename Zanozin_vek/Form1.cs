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
        List<Cross> Shapes = new List<Cross>();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            this.Text = Convert.ToString(e.X) + " " + Convert.ToString(e.Y);
            Shapes.Add(new Cross(e.Location));
            Refresh();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Cross p in this.Shapes)
            {
                p.DrawWith(e.Graphics, pMain);
            }
        }
    }
    public class Cross
    {
        Point F;
        public Cross(Point _F)
        {
            F = _F;
        }
        public void DrawWith(Graphics g, Pen pen)
        {
            g.DrawLine(pen, F.X - 2, F.Y - 2, F.X + 2, F.Y + 2);
            g.DrawLine(pen, F.X + 2, F.Y - 2, F.X - 2, F.Y + 2);
        }
    }
}
