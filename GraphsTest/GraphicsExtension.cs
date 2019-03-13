using System.Drawing;
using GraphsLib;

namespace GraphsTest
{
    public static class GraphicsExtension
    {
        public static Point pt;
        public static void GetPoint(Node n1,Node n2,double ratio)
        {
       
            pt = new Point((int)(n1.UIPos.X + (n2.UIPos.X - n1.UIPos.X) * ratio), (int)(n1.UIPos.Y + (n2.UIPos.Y - n1.UIPos.Y) * ratio));

        }

        public static PointF[] UI = new PointF[3];
        public static void GetTriangle(Node n1, Node n2,int w,int l,double u)
        {
            double d = GraphForm.Distance(n1.UIPos, n2.UIPos);
            double u2 = u - l / (d * 2);
            GetPoint(n1, n2, u2);
            PointF nVector = new PointF();
            nVector.X = (float)((n2.UIPos.X - n1.UIPos.X) / d);
            nVector.Y = (float)((n2.UIPos.Y - n1.UIPos.Y) / d);
            UI[0] = new PointF((pt.X + nVector.X * l), (pt.Y + nVector.Y * l));
            UI[1] = new PointF((pt.X + nVector.Y * w), (pt.Y + -nVector.X * w));
            UI[2] = new PointF((pt.X + -nVector.Y * w), (pt.Y + nVector.X * w));
        }

        public static void DrawTip(this Graphics g,Node n1,Node n2,int Length,int Width,double ratio)
        {
            GetTriangle(n1,n2,Width,Length,ratio);
           
            g.FillPolygon(Brushes.DarkCyan, UI);
            g.DrawPolygon(new Pen(Color.Black,2), UI);
           
        }




    }
}
