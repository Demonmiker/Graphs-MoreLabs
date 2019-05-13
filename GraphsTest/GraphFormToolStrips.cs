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
        bool ToolDoubleLink = false;
        bool ViewHasWeight = true;

        #region ToolStrips

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
            if (ToolDoubleLink)
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
            if (PForm.ShowDialog() == DialogResult.OK)
            {
                Dijkstra pf = new Dijkstra();
                Node n1 = MainGraph.Nodes.Find((x) => x.Name == PForm.N1);
                Node n2 = MainGraph.Nodes.Find((x) => x.Name == PForm.N2);
                if (n1 == null || n2 == null)
                    MessageBox.Show("Ошибка!");
                else
                {
                    Path = null;
                    switch (PForm.Mode)
                    {
                        case "Дейкстра":
                            Pathes = pf.FindPath(n1, n2, DijkstraMode.Default);
                            break;
                        case "Дейкстра(с двоичной кучей)":
                            Pathes = pf.FindPath(n1, n2, DijkstraMode.BinaryHeap);
                            break;
                            


                    }
                    pathindex = 0;
                    Path = Pathes[0];
                    if (Path == null)
                        MessageBox.Show("Нет пути");
                }
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
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
    }
}
