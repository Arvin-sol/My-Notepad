using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp4
{
    public partial class FrmReplace : WinFormsApp4.FrmFind
    {
        Form1 frmMain;
        public FrmReplace(Form1 x) : base(x)   
        {
            frmMain= x;
            InitializeComponent();
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            frmMain.replaceFunc(txtReplace.Text);
        }

        private void btnReplaceAll_Click(object sender, EventArgs e)
        {
            StringComparison x = StringComparison.OrdinalIgnoreCase;

            if (chkMatchCase.Checked == true)
                x = StringComparison.Ordinal;

            frmMain.replaceAllFunc(txtFind.Text, txtReplace.Text, x, rdnDown.Checked);
        }
    }
}
