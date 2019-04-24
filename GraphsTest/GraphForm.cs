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
        
        int Max = 50;
        #endregion
        // Fields
        Graph MainGraph = new Graph();

        List<Node>[] Pathes = new List<Node>[0];
        List<Node> Path = new List<Node>();
        int pathindex;
       
        public GraphForm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            UpdateStyles();
            Render.Start();
        }

       



        

        

       

        

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

        
        public PointF[] GetTriangle(Node n1,Node n2)
        {
            GraphicsExtension.GetTriangle(n1,n2,TWidth,TLength,u);
            return GraphicsExtension.UI;
        }

        public Link SearchLinks(Point pm)
        {
            PointF[] UI = new PointF[3];
            foreach(Node n in MainGraph.Nodes)
            {
                foreach(Link l in n.Links)
                {
                    if (InTriangle(GetTriangle(n, l.To), pm))
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

        public bool InTriangle(PointF[] tri,PointF p)
        {
            float a = (tri[0].X - p.X) * (tri[1].Y - tri[0].Y) - (tri[1].X - tri[0].X) * (tri[0].Y - p.Y);
            float b = (tri[1].X - p.X) * (tri[2].Y - tri[1].Y) - (tri[2].X - tri[1].X) * (tri[1].Y - p.Y);
            float c = (tri[2].X - p.X) * (tri[0].Y - tri[2].Y) - (tri[0].X - tri[2].X) * (tri[2].Y - p.Y);
            if ((a > 0 && b > 0 && c > 0) || (a < 0 && b < 0 && c < 0))
                return true;
            return false;
        }

        public Point MouseGetPos()
        {
            return PointToClient(Cursor.Position);
        }
        #endregion

        private void btn_Left_Click(object sender, EventArgs e)
        {
            if(pathindex>0)
            {
                pathindex--;
                Path = Pathes[pathindex];
            }
        }

        private void btn_Right_Click(object sender, EventArgs e)
        {
            if (pathindex < Pathes.Length-1)
            {
                pathindex++;
                Path = Pathes[pathindex];
            }
        }

        public void ResetPathes()
        {
            pathindex = 0;
            Path = Pathes[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pathes = Algorithms.DoDFS(MainGraph);
            ResetPathes();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pathes = Algorithms.StrongConnection(MainGraph);
            ResetPathes();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainGraph = MainGraph.GetReverse();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Pathes = Algorithms.BFS(MainGraph);
            ResetPathes();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
