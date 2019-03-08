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
    

    public partial class Form1 : Form
    {

        #region BoolUI
        bool ToolDoubleLink = false;
        bool ViewHasWeight = true;

        #endregion
        // Fields
        Graph MainGraph = new Graph();
        int NodeSize = 50;
        Bitmap ImgNode = Resource1.Node;
        Bitmap ImgNode2 = Resource1.Node2;
        List<Node> Path = new List<Node>();
       
        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            UpdateStyles();
            
            Render.Start();
            

        }
        //Отрисовка
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //
            foreach(Node n in MainGraph.Nodes)
                foreach(Link l in n.Links)
                    g.DrawLine(new Pen(Color.White, 2), n.UIPos, l.To.UIPos);

            if(Path!=null)
                for(int i=0;i<Path.Count-1;i++)
                    g.DrawLine(new Pen(Color.OrangeRed, 4),Path[i].UIPos,Path[i+1].UIPos);
            // Рисуем линки
            foreach (Node n in MainGraph.Nodes)
                foreach (Link l in n.Links)
                {
                    g.DrawTip(n, l.To);
                    int x = (int)((l.To.UIPos.X - n.UIPos.X) * (u));
                    int y = (int)((l.To.UIPos.Y - n.UIPos.Y) * (u));
                    if(ViewHasWeight)
                        g.DrawString(l.Weight.ToString(), label1.Font, Brushes.Yellow, n.UIPos.X + x + 7 - g.MeasureString(n.Name, label1.Font).Width / 2, n.UIPos.Y + y + 7  - g.MeasureString(n.Name, this.Font).Height / 2);
                }
           
            // Рисуем текущий линк
            if (NodeForLink!=null)
            {
                g.DrawLine(new Pen(Color.Black,2), NodeForLink.UIPos, MouseGetPos());
            }
            // Рисуем ноды
            foreach (Node n in MainGraph.Nodes)
            {
                //Круг
                g.DrawImage(ImgNode, new Rectangle(n.UIPos.X - NodeSize / 2, n.UIPos.Y - NodeSize / 2, NodeSize, NodeSize));
                //Текст в круге
                g.DrawString(n.Name, this.Font, Brushes.Black, n.UIPos.X  - g.MeasureString(n.Name,this.Font).Width/2, n.UIPos.Y - g.MeasureString(n.Name, this.Font).Height / 2);
            }
            if(Path!=null)
            foreach (Node n in Path)
            {
                //Круг
                g.DrawImage(ImgNode2, new Rectangle(n.UIPos.X - NodeSize / 2, n.UIPos.Y - NodeSize / 2, NodeSize, NodeSize));
                //Текст в круге
                g.DrawString(n.Name, this.Font, Brushes.Black, n.UIPos.X - g.MeasureString(n.Name, this.Font).Width / 2, n.UIPos.Y - g.MeasureString(n.Name, this.Font).Height / 2);
            }

        }

        //Стажер отрисовки
        private void Render_Tick(object sender, EventArgs e)
        {
            Point p = MouseGetPos();
            if (CurrentNode != null)
            {
                CurrentNode.UIPos.X = p.X;
                CurrentNode.UIPos.Y = p.Y;
            }
            Refresh();
        }

       
        Node CurrentNode;
        Node NodeForLink;
        int Max = 500;
        
      
        int NextNodeName = 1;

        #region Mouse
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Link l = null;
            bool KeyShift = Control.ModifierKeys == Keys.Shift;
            bool KeyCtrl = Control.ModifierKeys == Keys.Control;
            
            Node ClickNode = SearchNodes(MouseGetPos());
            if (ClickNode == null)
               l = SearchLinks(MouseGetPos());
            if(ClickNode!=null)   // ЕСЛИ КЛИКНУЛИ НА ВЕРШИНУ
            {
                if (e.Button == MouseButtons.Left) //ЛЕВЫЙ КЛИК НА ВЕРШИНУ
                {
                    if (KeyShift && KeyCtrl)
                    {

                    }
                    else if (KeyShift)
                    {
                        NodeForLink = ClickNode;

                    }
                    else if (KeyCtrl)
                    {
                        if (MainGraph.Nodes.Count >= Max)
                            return;
                        Node n = new Node("N" + NextNodeName++, MouseGetPos());
                        MainGraph.Add(n);
                        if (!ToolDoubleLink)
                            ClickNode.Link(n);
                        else
                            ClickNode.LinkTwo(n);
                        CurrentNode = n;

                    }
                    else
                    {
                        CurrentNode = ClickNode;
                    }
                }
                else if(e.Button == MouseButtons.Right) //ПРАВЫЙ КЛИК НА ВЕРШИНУ
                {
                    NodeContext = ClickNode;
                    this.ContextMenuStrip = ContextNode;
                   
                }
            }
            else if(l!=null) //КЛИК НА ЛИНКА
            {
                if(e.Button == MouseButtons.Right)
                {
                    LinkContext = l;
                    ContextMenuStrip = ContexLink;
                }
            }
            else  //КЛИК В НИКУДА
            {
                if(e.Button == MouseButtons.Left)
                {
                    if (KeyCtrl)
                    {
                        if (MainGraph.Nodes.Count >= Max)
                            return;
                        MainGraph.Add(new Node("N" + NextNodeName++, MouseGetPos()));
                    }
                }
                else if(e.Button == MouseButtons.Right)
                {
                    NodeContext = null;
                    this.ContextMenuStrip = null;
                }

            }
           

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Node ClickNode = SearchNodes(MouseGetPos());
            CurrentNode = null;
            if (NodeForLink != null && ClickNode != null)
            {
                if(!ToolDoubleLink)
                    NodeForLink.Link(ClickNode,1);
                else
                    NodeForLink.LinkTwo(ClickNode);
            }
            NodeForLink = null;
           
        }
        #endregion

        #region ContextMenu

        Node NodeContext;
        Link LinkContext;

        private void ContextNode_Opening(object sender, CancelEventArgs e)
        {
            TsTbName.Text = NodeContext.Name;
        }
        private void ContextNode_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            if (!MainGraph.Contains(TsTbName.Text))
                NodeContext.Name = TsTbName.Text;
        }

        private void ContexLink_Opening(object sender, CancelEventArgs e)
        {
            if (ViewHasWeight)
                TsLinktb.Text = LinkContext.Weight.ToString();
            else
                TsLinktb.Text = "";
        }
        private void ContexLink_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            if(ViewHasWeight)
            {
                double temp;
                if (double.TryParse(TsLinktb.Text, out temp))
                {
                    if(ToolDoubleLink)
                    {
                        Link t = LinkContext.To.Links.Find((link) => link.To == LinkContext.From);
                        if(t!=null)
                            t.Weight = temp;
                    }
                    LinkContext.Weight = temp;
                }
                    
            }
            
        }
        #endregion

        #region TollStrips

        #region Context
        private void TsDelete_Click(object sender, EventArgs e)
        {
            Path = null;
            MainGraph.RemoveNode(NodeContext);
            ContextNode.Close();
            NodeContext = null;
        }

        private void TsLinkDelete_Click(object sender, EventArgs e)
        {
            Path = null;
            MainGraph.RemoveLink(LinkContext);
            if(ToolDoubleLink)
                MainGraph.RemoveLink(LinkContext.To.Links.Find((el) => { return el.To == LinkContext.From; }));
                
           
                
        }
        #endregion

        #region Файл
        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Path = null;
            MainGraph.Nodes.Clear();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                PackedGraph pg = new PackedGraph(MainGraph);
                Serializer.Write(saveFileDialog1.FileName, pg);
            }


        }


        PF PForm = new PF();

        private void поискПутиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(PForm.ShowDialog()==DialogResult.OK)
            {
                Dijkstra pf = new Dijkstra();
                Node n1 = MainGraph.Nodes.Find((x) => x.Name == PForm.N1);
                Node n2 = MainGraph.Nodes.Find((x) => x.Name == PForm.N2);
                if (n1 == null || n2 == null)
                    MessageBox.Show("Ошибка!");
                else
                {
                    Path = null;
                    switch(PForm.Mode)
                    {
                        case "Дейкстра":
                            Path = pf.FindPath(n1, n2, DijkstraMode.Default);
                            break;
                        case "Дейкстра(с двоичной кучей)":
                            Path = pf.FindPath(n1, n2, DijkstraMode.BinaryHeap);
                            break;
                     

                    }
                    
                    if (Path == null)
                        MessageBox.Show("Нет пути");
                }
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                PackedGraph pg = Serializer.Read<PackedGraph>(openFileDialog1.FileName);
                Path = null;
                MainGraph = pg.UnPack();
            }
           
        }
        #endregion

        #region Инструменты
        private void показыватьВесаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewHasWeight = !ViewHasWeight;
            показыватьВесаToolStripMenuItem.Checked = ViewHasWeight;
        }

        private void убратьВесаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Node n in MainGraph.Nodes)
                foreach (Link l in n.Links)
                    l.Weight = 1;
            ViewHasWeight = !ViewHasWeight;
            показыватьВесаToolStripMenuItem.Checked = ViewHasWeight;
        }

        private void двойнаяСвязьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolDoubleLink = !ToolDoubleLink;
            двойнаяСвязьToolStripMenuItem.Checked = ToolDoubleLink;
        }
        #endregion
        #endregion

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

        int TLength =  15;
        int TWidth = 10;
        double u = 0.6;
        public Link SearchLinks(Point pm)
        {
            PointF[] UI = new PointF[3];
            foreach(Node n in MainGraph.Nodes)
            {
                foreach(Link l in n.Links)
                {
                    Point p = new Point((int)(n.UIPos.X + (l.To.UIPos.X - n.UIPos.X) * u),(int)( n.UIPos.Y + (l.To.UIPos.Y - n.UIPos.Y) * u));
                    double d = Form1.Distance(n.UIPos, l.To.UIPos);
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
            double d = Form1.Distance(p1, p2);
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
