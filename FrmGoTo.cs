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
    public partial class FrmGoto : Form
    {
        Form1 frmMain;
        public FrmGoto(Form1 frm)
        {
            frmMain = frm;
            InitializeComponent();
        }

        private void FrmGoto_Load(object sender, EventArgs e)
        {
            txtGoto.Text = frmMain.getLines().ToString();
        }

        private void btnGoto_Click(object sender, EventArgs e)
        {
            int n;
            n = Convert.ToInt16(txtGoto.Text) - 1;
            if (n > frmMain.getLines())
            {
                MessageBox.Show("Out of range.");
                txtGoto.SelectAll();
                txtGoto.Focus();
            }
            else
            {
                frmMain.gotoFunc(n);
                this.Close();
            }
        }
    }
}
