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
    public partial class FrmFind : Form
    {
        Form1 frmMain;
        public FrmFind(Form1 frm)
        {
            frmMain =  frm;
            InitializeComponent();
        }
        public FrmFind()
        {
            
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            frmMain.FindFunction(txtFind.Text);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFindNext_Click(object sender, EventArgs e)
        {
            StringComparison a = StringComparison.OrdinalIgnoreCase;
            if (chkMatchCase.Checked == true)
                a = StringComparison.Ordinal;

            frmMain.FindNextFunction(txtFind.Text ,a ,rdnDown.Checked);
        }
    }
}
