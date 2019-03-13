using System.Drawing;
using GraphsLib;

namespace GraphsTest
{
    public static class GraphicsExtension
    {
      
        public static void DrawArrow(this Graphics g,Node n1,Node n2)
        {
            g.DrawLine(new Pen(Color.Black,2), n1.UIPos, n2.UIPos);
            Point p = new Point(n1.UIPos.X + (n2.UIPos.X - n1.UIPos.X) / 2, n1.UIPos.Y + (n2.UIPos.Y - n1.UIPos.Y) / 2);
            g.DrawTip(n1,n2,p);
        }

        public static void DrawTip(this Graphics g,Point p1,Point p2,Point p,int Length,int Width)
        {
            PointF[] UI = new PointF[3];
            double d = GraphForm.Distance(p1, p2);
            PointF nVector = new PointF();
            nVector.X = (float)((p2.X - p1.X) / d);
            nVector.Y = (float)((p2.Y - p1.Y) / d);
            UI[0] = new PointF((p.X + nVector.X * Length),(p.Y + nVector.Y * Length));
            UI[1] = new PointF((p.X + nVector.Y * Width),(p.Y + -nVector.X * Width));
            UI[2] = new PointF((p.X + -nVector.Y * Width), (p.Y + nVector.X * Width));
            g.FillPolygon(Brushes.DarkCyan, UI);
            g.DrawPolygon(new Pen(Color.Black,2), UI);
        }

        public static void DrawTip(this Graphics g,Node n1,Node n2,Point p)
        {
            g.DrawTip(n1.UIPos, n2.UIPos, p, 15, 10);
        }

        public static void DrawTip(this Graphics g,Node n1,Node n2)
        {
            Point p = new Point((int)(n1.UIPos.X + (n2.UIPos.X - n1.UIPos.X) * (0.6)),(int)( n1.UIPos.Y + (n2.UIPos.Y - n1.UIPos.Y) * (0.6)));
            g.DrawTip(n1, n2, p);
        }
    }
}
