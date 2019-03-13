using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GraphsLib;


namespace GraphsTest
{
    partial class GraphForm
    {
        //поля
        Node CurrentNode;
        Node NodeForLink;

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
            if (ClickNode != null)   // ЕСЛИ КЛИКНУЛИ НА ВЕРШИНУ
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
                else if (e.Button == MouseButtons.Right) //ПРАВЫЙ КЛИК НА ВЕРШИНУ
                {
                    NodeContext = ClickNode;
                    this.ContextMenuStrip = ContextNode;

                }
            }
            else if (l != null) //КЛИК НА ЛИНКА
            {
                if (e.Button == MouseButtons.Right)
                {
                    LinkContext = l;
                    ContextMenuStrip = ContexLink;
                }
            }
            else  //КЛИК В НИКУДА
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (KeyCtrl)
                    {
                        if (MainGraph.Nodes.Count >= Max)
                            return;
                        MainGraph.Add(new Node("N" + NextNodeName++, MouseGetPos()));
                    }
                }
                else if (e.Button == MouseButtons.Right)
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
                if (!ToolDoubleLink)
                    NodeForLink.Link(ClickNode, 1);
                else
                    NodeForLink.LinkTwo(ClickNode);
            }
            NodeForLink = null;

        }

        #endregion
    }
}
