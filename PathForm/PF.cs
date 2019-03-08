using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PathForm
{
    public partial class PF : Form
    {
        public string N1
        {
            get { return tb_From.Text; }
        }

        public string N2
        {
            get { return tb_To.Text; }
        }

        public string Mode
        {
            get { return cb.Text; }
        }

        public PF()
        {
            InitializeComponent();
            cb.Text = "Дейкстра";
        }

        private void btn__OK_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.OK;
        }

        private void PF_Shown(object sender, EventArgs e)
        {
            DialogResult = DialogResult.None;
        }
    }
}
