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
        public abstract void SaveTo(StreamWriter sw);
        public abstract bool IsNearTo(Point A);
        public abstract string AddToList();
        public float Dist(Point A, Point B)
        {
            return ((float)Math.Sqrt(Math.Pow((B.X - A.X), 2) + Math.Pow((B.Y - A.Y), 2)));
        }
    }
    public class Cross : Shape
    {
        Point F;
        public Cross(Point _F)
        {
            F = _F;
        }
        public Cross(StreamReader sr)
        {
            string line = sr.ReadLine();
            string[] coords = line.Split(' ');
            F.X = Convert.ToInt32(coords[0]);
            F.Y = Convert.ToInt32(coords[1]);
        }
        public override void SaveTo(StreamWriter sw)
        {
            sw.WriteLine("Cross");
            sw.WriteLine(Convert.ToString(F.X) + " " + Convert.ToString(F.Y));
        }
        public override void DrawWith(Graphics g, Pen pen)
        {
            g.DrawLine(pen, F.X - 2, F.Y - 2, F.X + 2, F.Y + 2);
            g.DrawLine(pen, F.X + 2, F.Y - 2, F.X - 2, F.Y + 2);
        }
        public override bool IsNearTo(Point A)
        {
            return (Dist(A, F) <= 1);
        }
        public override string AddToList()
        {
            return ("Cross" + Convert.ToString(F));
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
        public Line(StreamReader sr)
        {
            string line1, line2;
            line1 = sr.ReadLine();
            line2 = sr.ReadLine();
            string[] coords1 = line1.Split(' ');
            string[] coords2 = line2.Split(' ');
            S.X = Convert.ToInt32(coords1[0]);
            S.Y = Convert.ToInt32(coords1[1]);
            F.X = Convert.ToInt32(coords2[0]);
            F.Y = Convert.ToInt32(coords2[1]);
        }
        public override void SaveTo(StreamWriter sw)
        {
            sw.WriteLine("Line");
            sw.WriteLine(Convert.ToString(S.X) + " " + Convert.ToString(S.Y));
            sw.WriteLine(Convert.ToString(F.X) + " " + Convert.ToString(F.Y));
        }
        public override void DrawWith(Graphics g, Pen pen)
        {
            g.DrawLine(pen, this.S.X, this.S.Y, this.F.X, this.F.Y);
        }
        public override bool IsNearTo(Point A)
        {
            return (((Dist(S, A) + Dist(F, A)) - Dist(S, F)) <= 1);
        }
        public override string AddToList()
        {
            return ("Line" + Convert.ToString(S) + Convert.ToString(F));
        }
    }
    public class Circle : Shape
    {
        Point C;
        Point R;
        public Circle(Point _C, Point _R)
        {
            C = _C;
            R = _R;
        }
        public Circle(StreamReader sr)
        {
            string line1, line2;
            line1 = sr.ReadLine();
            line2 = sr.ReadLine();
            string[] coords1 = line1.Split(' ');
            string[] coords2 = line2.Split(' ');
            C.X = Convert.ToInt32(coords1[0]);
            C.Y = Convert.ToInt32(coords1[1]);
            R.X = Convert.ToInt32(coords2[0]);
            R.Y = Convert.ToInt32(coords2[1]);
        }
        public override void SaveTo(StreamWriter sw)
        {
            sw.WriteLine("Circle");
            sw.WriteLine(Convert.ToString(C.X) + " " + Convert.ToString(C.Y));
            sw.WriteLine(Convert.ToString(R.X) + " " + Convert.ToString(R.Y));
        }
        public override void DrawWith(Graphics g, Pen pen)
        {
            g.DrawEllipse(pen, C.X - Dist(C, R), C.Y - Dist(C, R), Dist(C, R) * 2, Dist(C, R) * 2);
        }
        public override bool IsNearTo(Point A)
        {
            return ((Dist(C, A) - Dist(C, R)) <= 1);
        }
        public override string AddToList()
        {
            return ("Circle" + Convert.ToString(C) + Convert.ToString(R));
        }
    }
    public class Rec : Shape
    {
        Point S;
        Point F;
        public Rec(Point _S, Point _F)
        {
            this.S.X = Math.Min(_S.X,_F.X);
            this.S.Y = Math.Min(_S.Y,_F.Y);
            this.F.X = Math.Max(_S.X, _F.X);
            this.F.Y = Math.Max(_S.Y, _F.Y);
        }
        public Rec(StreamReader sr)
        {
            string line1, line2;
            line1 = sr.ReadLine();
            line2 = sr.ReadLine();
            string[] coords1 = line1.Split(' ');
            string[] coords2 = line2.Split(' ');
            S.X = Convert.ToInt32(coords1[0]);
            S.Y = Convert.ToInt32(coords1[1]);
            F.X = Convert.ToInt32(coords2[0]);
            F.Y = Convert.ToInt32(coords2[1]);
        }
        public override void SaveTo(StreamWriter sw)
        {
            sw.WriteLine("Rectangle");
            sw.WriteLine(Convert.ToString(S.X) + " " + Convert.ToString(S.Y));
            sw.WriteLine(Convert.ToString(F.X) + " " + Convert.ToString(F.Y));
        }
        public override void DrawWith(Graphics g, Pen pen)
        {
            g.DrawRectangle(pen,S.X,S.Y,F.X-S.X,F.Y-S.Y);
        }
        public override string AddToList()
        {
            return ("Rectangle" + Convert.ToString(S) + Convert.ToString(F));
        }
        public override bool IsNearTo(Point A)
        {
            return (false);
        }
    }
}
