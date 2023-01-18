namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        string fn;
        MyUndoRedo NotepadUndoRedo = new MyUndoRedo();
        Boolean saveflag;
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SetBackColor(object sender, EventArgs e)
        {
            txtNotepad.BackColor = Color.FromName(((ToolStripMenuItem)sender).Text);
            foreach(ToolStripMenuItem x in backColorToolStripMenuItem.DropDownItems)
            {
                if(x.Text == ((ToolStripMenuItem)sender).Text)
                    x.Checked = true;
                else 
                    x.Checked = false;
            }
        }

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip1.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void foreColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            txtNotepad.ForeColor = colorDialog1.Color;
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = txtNotepad.Font;
            fontDialog1.ShowDialog();
            txtNotepad.Font = fontDialog1.Font;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string[] a = new string[5];
            a[0] = txtNotepad.BackColor.Name;
            a[1] = txtNotepad.Font.Name;
            a[2] = txtNotepad.Font.Size.ToString();
            a[3] = this.Height.ToString();
            a[4] = this.Width.ToString();

            System.IO.File.WriteAllLines(@"c:\\layout.txt", a);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] x = new string[5];
            if (System.IO.File.Exists("layout.txt"))
            {
                x = System.IO.File.ReadAllLines(@"c:\layout.txt");
                ToolStripMenuItem temp = new ToolStripMenuItem();
                temp.Text = x[0];
                SetBackColor(temp, null);
                txtNotepad.Font = new Font(x[1] , Convert.ToInt32(x[2]));
                this.Height = Convert.ToInt32(x[3]);
                this.Width = Convert.ToInt32(x[4]);
                saveflag = true;
            }
            

        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNotepad.WordWrap = wordWrapToolStripMenuItem.Checked;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(fn == null)

            {
                DialogResult x;
                saveFileDialog1.DefaultExt = "txt";
                x = saveFileDialog1.ShowDialog();
                if (x == DialogResult.Cancel)
                    return;
                fn = saveFileDialog1.FileName;

            }
            System.IO.File.WriteAllText(fn, txtNotepad.Text);
            saveflag = true;
            this.Text = fn;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveflag != true)

            {
                DialogResult d;
                d = MessageBox.Show("Do you want to save" , "Save...",MessageBoxButtons.YesNo);
                if (d == DialogResult.Yes)
                    saveToolStripMenuItem_Click(null , null);
            }
            txtNotepad.Text = "";
            this.Text = "My Notpad";
            saveflag = true;
            fn = null;
                
        }

        private void txtNotepad_TextChanged(object sender, EventArgs e)
        {
            saveflag = false;
            SetRowCol();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newToolStripMenuItem_Click(null, null);
            openFileDialog1.Filter = "Text File|*.txt|Document File|*.doc|All File|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            fn = openFileDialog1.FileName;
            txtNotepad.Text = System.IO.File.ReadAllText(fn);
            saveflag = true;
            this.Text = fn;

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            newToolStripMenuItem_Click(null, null);

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fn = null;
            saveToolStripMenuItem_Click(null, null);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtNotepad.SelectedText);

        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNotepad.SelectedText = Clipboard.GetText();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNotepad.SelectedText = "";
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copyToolStripMenuItem_Click(null, null);
            deleteToolStripMenuItem_Click(null, null);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNotepad.SelectAll();
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFind f1 = new FrmFind(this);
            f1.Show(this);
        }

        public Boolean FindFunction(string s) 
        {
            int i;
            i = txtNotepad.Text.IndexOf(s);
            if (i == -1)
            {
                MessageBox.Show("Not found");
                return false;
            }
            else
            {
                txtNotepad.SelectionStart = i;
                txtNotepad.SelectionLength = s.Length;
                txtNotepad.Focus();
                return true;
            }
        }
        public Boolean FindNextFunction(string s , StringComparison compairType , Boolean RightToLeft)
        {
            int i;
            if(RightToLeft ==true)
                i = txtNotepad.Text.IndexOf(s , txtNotepad.SelectionStart + 1 , compairType);
            else
                i = txtNotepad.Text.LastIndexOf(s, txtNotepad.SelectionStart - 1, compairType);
            if (i == -1)
            {
                MessageBox.Show("Not found");
                return false;
            }
            else
            {
                txtNotepad.SelectionStart = i;
                txtNotepad.SelectionLength = s.Length;
                txtNotepad.Focus();
                return true;
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNotepad.Text = NotepadUndoRedo.Undo();

        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNotepad.Text = NotepadUndoRedo.Redo();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            NotepadUndoRedo.SetText(txtNotepad.Text);
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReplace r = new FrmReplace(this);
            r.Show(this);
        }
        public void replaceFunc(string str)
        {
            if(txtNotepad.SelectionLength > 0)
            {
                txtNotepad.SelectedText = str;
            }
        }
        public void replaceAllFunc(string str1 , string str2 , StringComparison cmptype , Boolean LeftToRight)
        {
            while(FindNextFunction(str1 , cmptype, LeftToRight))
            {
                replaceFunc(str2);
            }
        }

        private void goToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGoto f = new FrmGoto(this);
            f.ShowDialog(this);
        }
        public int getLines()
        {
            return txtNotepad.Lines.Count();
        }
        public void gotoFunc(int x)
        {
            txtNotepad.SelectionStart = txtNotepad.GetFirstCharIndexFromLine(x);
        }
        public void SetRowCol()
        {
            int row = txtNotepad.GetLineFromCharIndex(txtNotepad.SelectionStart) + 1;
            int col = txtNotepad.SelectionStart - txtNotepad.GetFirstCharIndexOfCurrentLine() + 1;

            lblRowCol.Text = "ln " + row.ToString() + "Col " + col.ToString();
        }

        private void txtNotepad_Click(object sender, EventArgs e)
        {
            SetRowCol();
        }

        private void txtNotepad_KeyUp(object sender, KeyEventArgs e)
        {
            SetRowCol();
        }

        public void setEnables()
        {
            copyToolStripMenuItem.Enabled = Convert.ToBoolean(txtNotepad.SelectionLength);
            cutToolStripMenuItem.Enabled = txtNotepad.SelectionLength > 0;
            deleteToolStripMenuItem.Enabled = txtNotepad.SelectionLength > 0;
            pasteToolStripMenuItem.Enabled = Clipboard.ContainsText();
            findTextToolStripMenuItem.Enabled = txtNotepad.Text.Length > 0;
            goToToolStripMenuItem.Enabled = txtNotepad.TextLength > 0;
            saveToolStripMenuItem.Enabled = !saveflag;

        }

        private void fileToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            setEnables();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult x;
            printDialog1.Document = printDocument1;
            x = printDialog1.ShowDialog();
            if(x == DialogResult.OK)
                printDocument1.Print();
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(txtNotepad.Text, txtNotepad.Font, Brushes.Black, 0, 0);
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
    }



    public class MyUndoRedo
    {
        string[] temp = new string[1000];
        int index;
        int CurrentPosition;

        public MyUndoRedo()
        {
            index = 0;
            CurrentPosition = 0;
        }

        public void SetText(string s)
        {
            temp[index] = s;
            CurrentPosition = index;
            ++index;
        }

        public string Undo()
        {
            if (CurrentPosition > 0)
                return temp[--CurrentPosition];

            return null;
        }

        public string Redo()
        {
            if (CurrentPosition < index)
                return temp[++CurrentPosition];

            return null;
        }

    }// end of undo redo class
}