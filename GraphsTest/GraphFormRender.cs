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
    partial class GraphForm
    {
        #region RenderConstants - Константы рендера
        const int TLength = 20;
        const int TWidth = 15;
        const double u = 0.5;
        int NodeSize = 50;
        Bitmap ImgNode = Resource1.Node;
        Bitmap ImgNode2 = Resource1.Node2;
        #endregion

        #region Отрисовка
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            DrawMainGraph(g);

        }

        private void DrawMainGraph(Graphics g)
        {
            // связи
            DrawLinks(g);
            //пути соединения
            DrawPathLinks(g);
            // Рисуем линки
            DrawLinksTips(g);
            // Рисуем текущий линк
            DrawCurrentLink(g);
            // Рисуем ноды
            DrawNodes(g);
            // Рисуем ноды
            DrawPathNodes(g);
        }

        private void DrawPathNodes(Graphics g)
        {
            if (Path != null)
                foreach (Node n in Path)
                {
                    //Круг
                    g.DrawImage(ImgNode2, new Rectangle(n.UIPos.X - NodeSize / 2, n.UIPos.Y - NodeSize / 2, NodeSize, NodeSize));
                    //Текст в круге
                    g.DrawString(n.Name, this.Font, Brushes.Black, n.UIPos.X - g.MeasureString(n.Name, this.Font).Width / 2, n.UIPos.Y - g.MeasureString(n.Name, this.Font).Height / 2);
                }
        }

        private void DrawNodes(Graphics g)
        {
            foreach (Node n in MainGraph.Nodes)
            {
                //Круг
                g.DrawImage(ImgNode, new Rectangle(n.UIPos.X - NodeSize / 2, n.UIPos.Y - NodeSize / 2, NodeSize, NodeSize));
                //Текст в круге
                g.DrawString(n.Name, this.Font, Brushes.Black, n.UIPos.X - g.MeasureString(n.Name, this.Font).Width / 2, n.UIPos.Y - g.MeasureString(n.Name, this.Font).Height / 2);
            }
        }

        private void DrawCurrentLink(Graphics g)
        {
            if (NodeForLink != null)
            {
                g.DrawLine(new Pen(Color.Black, 2), NodeForLink.UIPos, MouseGetPos());
            }
        }

        private void DrawLinks(Graphics g)
        {
            foreach (Node n in MainGraph.Nodes)
                foreach (Link l in n.Links)
                    g.DrawLine(new Pen(Color.White, 2), n.UIPos, l.To.UIPos);
        }

        private void DrawPathLinks(Graphics g)
        {
            if (Path != null)
                for (int i = 0; i < Path.Count - 1; i++)
                    g.DrawLine(new Pen(Color.OrangeRed, 4), Path[i].UIPos, Path[i + 1].UIPos);
        }

        void DrawLinksTips(Graphics g)
        {
            foreach (Node n in MainGraph.Nodes)
                foreach (Link l in n.Links)
                {
                    
                    g.DrawTip(n, l.To,TLength,TWidth,u);
                    //
                    double d = GraphForm.Distance(n.UIPos, l.To.UIPos);
                    double u2 = u - TLength / (d*5);
                    GraphicsExtension.GetPoint(n, l.To, u2);
                    //
                    if (ViewHasWeight)
                        g.DrawString(l.Weight.ToString(), label1.Font, Brushes.Yellow, GraphicsExtension.pt.X - 4, GraphicsExtension.pt.Y - 6);
                    //test
                    //g.FillEllipse(Brushes.Purple, GraphicsExtension.pt.X, GraphicsExtension.pt.Y, 4, 4);
                    //test
                }
        }

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
        #endregion
    }
}
