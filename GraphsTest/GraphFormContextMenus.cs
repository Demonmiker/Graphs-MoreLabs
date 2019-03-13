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
        #region ContextMenu

        //узел для которого контекстное меню
        Node NodeContext;

        //соединение для которого контекстное меню
        Link LinkContext;

        //УЗЕЛ
        private void ContextNode_Opening(object sender, CancelEventArgs e)
        {
            TsTbName.Text = NodeContext.Name;
        }

        private void ContextNode_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            if (!MainGraph.Contains(TsTbName.Text))
                NodeContext.Name = TsTbName.Text;
        }

        //СОЕДИНЕНИЕ
        private void ContexLink_Opening(object sender, CancelEventArgs e)
        {
            if (ViewHasWeight)
                TsLinktb.Text = LinkContext.Weight.ToString();
            else
                TsLinktb.Text = "";
        }

        private void ContexLink_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            if (ViewHasWeight)
            {
                double temp;
                if (double.TryParse(TsLinktb.Text, out temp))
                {
                    if (ToolDoubleLink)
                    {
                        Link t = LinkContext.To.Links.Find((link) => link.To == LinkContext.From);
                        if (t != null)
                            t.Weight = temp;
                    }
                    LinkContext.Weight = temp;
                }

            }

        }
        #endregion
    }
}
