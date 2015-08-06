namespace ArabizationExample
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ConvertBtn = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Convert = new System.Windows.Forms.TabPage();
            this.MessagesLbl = new System.Windows.Forms.Label();
            this.OutputFileButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.OutputFileName = new System.Windows.Forms.TextBox();
            this.InputFileButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.InputFileName = new System.Windows.Forms.TextBox();
            this.About = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1.SuspendLayout();
            this.Convert.SuspendLayout();
            this.About.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConvertBtn
            // 
            this.ConvertBtn.Location = new System.Drawing.Point(484, 136);
            this.ConvertBtn.Name = "ConvertBtn";
            this.ConvertBtn.Size = new System.Drawing.Size(75, 23);
            this.ConvertBtn.TabIndex = 0;
            this.ConvertBtn.Text = "Convert";
            this.ConvertBtn.UseVisualStyleBackColor = true;
            this.ConvertBtn.Click += new System.EventHandler(this.ConvertBtn_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Convert);
            this.tabControl1.Controls.Add(this.About);
            this.tabControl1.Location = new System.Drawing.Point(-3, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(579, 218);
            this.tabControl1.TabIndex = 4;
            // 
            // Convert
            // 
            this.Convert.BackColor = System.Drawing.Color.Transparent;
            this.Convert.Controls.Add(this.MessagesLbl);
            this.Convert.Controls.Add(this.OutputFileButton);
            this.Convert.Controls.Add(this.label2);
            this.Convert.Controls.Add(this.OutputFileName);
            this.Convert.Controls.Add(this.InputFileButton);
            this.Convert.Controls.Add(this.label1);
            this.Convert.Controls.Add(this.InputFileName);
            this.Convert.Controls.Add(this.ConvertBtn);
            this.Convert.Location = new System.Drawing.Point(4, 22);
            this.Convert.Name = "Convert";
            this.Convert.Padding = new System.Windows.Forms.Padding(3);
            this.Convert.Size = new System.Drawing.Size(571, 192);
            this.Convert.TabIndex = 0;
            this.Convert.Text = "Convert";
            // 
            // MessagesLbl
            // 
            this.MessagesLbl.AutoSize = true;
            this.MessagesLbl.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.MessagesLbl.Location = new System.Drawing.Point(11, 225);
            this.MessagesLbl.Name = "MessagesLbl";
            this.MessagesLbl.Size = new System.Drawing.Size(0, 13);
            this.MessagesLbl.TabIndex = 7;
            // 
            // OutputFileButton
            // 
            this.OutputFileButton.Location = new System.Drawing.Point(484, 91);
            this.OutputFileButton.Name = "OutputFileButton";
            this.OutputFileButton.Size = new System.Drawing.Size(75, 23);
            this.OutputFileButton.TabIndex = 6;
            this.OutputFileButton.Text = "Browse";
            this.OutputFileButton.UseVisualStyleBackColor = true;
            this.OutputFileButton.Click += new System.EventHandler(this.OutputFileButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(12, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Select Output File";
            // 
            // OutputFileName
            // 
            this.OutputFileName.Location = new System.Drawing.Point(11, 93);
            this.OutputFileName.Name = "OutputFileName";
            this.OutputFileName.Size = new System.Drawing.Size(467, 20);
            this.OutputFileName.TabIndex = 4;
            // 
            // InputFileButton
            // 
            this.InputFileButton.Location = new System.Drawing.Point(484, 44);
            this.InputFileButton.Name = "InputFileButton";
            this.InputFileButton.Size = new System.Drawing.Size(75, 23);
            this.InputFileButton.TabIndex = 3;
            this.InputFileButton.Text = "Browse";
            this.InputFileButton.UseVisualStyleBackColor = true;
            this.InputFileButton.Click += new System.EventHandler(this.InputFileButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(11, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select Input File";
            // 
            // InputFileName
            // 
            this.InputFileName.Location = new System.Drawing.Point(11, 46);
            this.InputFileName.Name = "InputFileName";
            this.InputFileName.Size = new System.Drawing.Size(467, 20);
            this.InputFileName.TabIndex = 1;
            // 
            // About
            // 
            this.About.BackColor = System.Drawing.Color.Transparent;
            this.About.Controls.Add(this.textBox1);
            this.About.Controls.Add(this.label3);
            this.About.ForeColor = System.Drawing.SystemColors.ControlText;
            this.About.Location = new System.Drawing.Point(4, 22);
            this.About.Name = "About";
            this.About.Padding = new System.Windows.Forms.Padding(3);
            this.About.Size = new System.Drawing.Size(571, 192);
            this.About.TabIndex = 1;
            this.About.Text = "About";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(17, 64);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(480, 114);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(264, 35);
            this.label3.TabIndex = 0;
            this.label3.Text = "ArabizationExample";
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 212);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "ArabizationExample";
            this.tabControl1.ResumeLayout(false);
            this.Convert.ResumeLayout(false);
            this.Convert.PerformLayout();
            this.About.ResumeLayout(false);
            this.About.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ConvertBtn;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Convert;
        private System.Windows.Forms.TabPage About;
        private System.Windows.Forms.Button OutputFileButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox OutputFileName;
        private System.Windows.Forms.Button InputFileButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox InputFileName;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog;
        private System.Windows.Forms.Label MessagesLbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
    }
}

