using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphsLib;
using MySerialize;
using PathForm;

namespace GraphsTest
{


    public partial class GraphForm : Form
    {

        #region BoolUI
        bool ToolDoubleLink = false;
        bool ViewHasWeight = true;

        #endregion
        // Fields
        Graph MainGraph = new Graph();
        
       
        List<Node> Path = new List<Node>();
       
        public GraphForm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            UpdateStyles();
            Render.Start();
        }

        int Max = 50;



        

        

       

        

        #region Additional Methods
        public Node SearchNodes(Point p)
        {
            for (int i = 0; i < MainGraph.Nodes.Count; i++)
            {
                if (Distance(MainGraph.Nodes[i].UIPos, p) < NodeSize/2)
                    return MainGraph.Nodes[i];
            }
            return null;
        }

        public Link SearchLinks(Point pm)
        {
            PointF[] UI = new PointF[3];
            foreach(Node n in MainGraph.Nodes)
            {
                foreach(Link l in n.Links)
                {
                    Point p = new Point((int)(n.UIPos.X + (l.To.UIPos.X - n.UIPos.X) * u),(int)( n.UIPos.Y + (l.To.UIPos.Y - n.UIPos.Y) * u));
                    double d = GraphForm.Distance(n.UIPos, l.To.UIPos);
                    PointF nVector = new PointF();
                    nVector.X = (float)((l.To.UIPos.X - n.UIPos.X) / d);
                    nVector.Y = (float)((l.To.UIPos.Y - n.UIPos.Y) / d);
                    UI[0] = new PointF((p.X + nVector.X * TLength), (p.Y + nVector.Y * TLength));
                    UI[1] = new PointF((p.X + nVector.Y * TWidth), (p.Y + -nVector.X * TWidth));
                    UI[2] = new PointF((p.X + -nVector.Y * TWidth), (p.Y + nVector.X * TWidth));
                    
                    if (InTriangle(UI[0], UI[1], UI[2], pm))
                        return l;
                }
            }
            return null;

        }

        public static double Distance(Point p1, Point p2)
        {
            int dx = p2.X - p1.X;
            int dy = p2.Y - p1.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public bool InTriangle(PointF p1,PointF p2,PointF p3,PointF p)
        {
            float a = (p1.X - p.X) * (p2.Y - p1.Y) - (p2.X - p1.X) * (p1.Y - p.Y);
            float b = (p2.X - p.X) * (p3.Y - p2.Y) - (p3.X - p2.X) * (p2.Y - p.Y);
            float c = (p3.X - p.X) * (p1.Y - p3.Y) - (p1.X - p3.X) * (p3.Y - p.Y);
            if ((a > 0 && b > 0 && c > 0) || (a < 0 && b < 0 && c < 0))
                return true;
            return false;
        }

        public Point MouseGetPos()
        {
            return PointToClient(Cursor.Position);
        }
        #endregion

    }
}
