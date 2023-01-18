namespace WinFormsApp4
{
    partial class FrmFind
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblFind = new System.Windows.Forms.Label();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdnDown = new System.Windows.Forms.RadioButton();
            this.rdnUp = new System.Windows.Forms.RadioButton();
            this.chkMatchCase = new System.Windows.Forms.CheckBox();
            this.btnFindNext = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFind
            // 
            this.lblFind.AutoSize = true;
            this.lblFind.Location = new System.Drawing.Point(22, 31);
            this.lblFind.Name = "lblFind";
            this.lblFind.Size = new System.Drawing.Size(102, 25);
            this.lblFind.TabIndex = 0;
            this.lblFind.Text = "Find What :";
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(149, 28);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(240, 31);
            this.txtFind.TabIndex = 1;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(427, 28);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(127, 31);
            this.btnFind.TabIndex = 2;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(427, 137);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(127, 31);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdnDown);
            this.groupBox1.Controls.Add(this.rdnUp);
            this.groupBox1.Location = new System.Drawing.Point(231, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(158, 87);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Direction";
            // 
            // rdnDown
            // 
            this.rdnDown.AutoSize = true;
            this.rdnDown.Checked = true;
            this.rdnDown.Location = new System.Drawing.Point(68, 43);
            this.rdnDown.Name = "rdnDown";
            this.rdnDown.Size = new System.Drawing.Size(84, 29);
            this.rdnDown.TabIndex = 5;
            this.rdnDown.TabStop = true;
            this.rdnDown.Text = "Down";
            this.rdnDown.UseVisualStyleBackColor = true;
            // 
            // rdnUp
            // 
            this.rdnUp.AutoSize = true;
            this.rdnUp.Location = new System.Drawing.Point(6, 43);
            this.rdnUp.Name = "rdnUp";
            this.rdnUp.Size = new System.Drawing.Size(60, 29);
            this.rdnUp.TabIndex = 0;
            this.rdnUp.TabStop = true;
            this.rdnUp.Text = "Up";
            this.rdnUp.UseVisualStyleBackColor = true;
            // 
            // chkMatchCase
            // 
            this.chkMatchCase.AutoSize = true;
            this.chkMatchCase.Location = new System.Drawing.Point(22, 125);
            this.chkMatchCase.Name = "chkMatchCase";
            this.chkMatchCase.Size = new System.Drawing.Size(129, 29);
            this.chkMatchCase.TabIndex = 5;
            this.chkMatchCase.Text = "Match Case";
            this.chkMatchCase.UseVisualStyleBackColor = true;
            // 
            // btnFindNext
            // 
            this.btnFindNext.Location = new System.Drawing.Point(427, 81);
            this.btnFindNext.Name = "btnFindNext";
            this.btnFindNext.Size = new System.Drawing.Size(127, 31);
            this.btnFindNext.TabIndex = 6;
            this.btnFindNext.Text = "Find Next";
            this.btnFindNext.UseVisualStyleBackColor = true;
            this.btnFindNext.Click += new System.EventHandler(this.btnFindNext_Click);
            // 
            // FrmFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 197);
            this.Controls.Add(this.btnFindNext);
            this.Controls.Add(this.chkMatchCase);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.lblFind);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "FrmFind";
            this.Text = "FrmFind";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblFind;
        protected Button btnCancel;
        protected GroupBox groupBox1;
        protected CheckBox chkMatchCase;
        protected Button btnFindNext;
        protected Button btnFind;
        protected TextBox txtFind;
        protected RadioButton rdnDown;
        protected RadioButton rdnUp;
    }
}