namespace CSharpBarcode128
{
    partial class mainFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainFrm));
            this.label1 = new System.Windows.Forms.Label();
            this.txtAN = new System.Windows.Forms.TextBox();
            this.btnGen = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgView = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnPrintPreview = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageIPD = new System.Windows.Forms.TabPage();
            this.tabPageOPD = new System.Windows.Forms.TabPage();
            this.chkBlankOPD = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dgViewOPD = new System.Windows.Forms.DataGridView();
            this.pictureBoxOPD = new System.Windows.Forms.PictureBox();
            this.txtVNOPD = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbVSDateOPD = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnPreviewOPD = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtHNOPD = new System.Windows.Forms.TextBox();
            this.btnGenOPD = new System.Windows.Forms.Button();
            this.btnPrintOPD = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPageIPD.SuspendLayout();
            this.tabPageOPD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewOPD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOPD)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(14, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "AN";
            // 
            // txtAN
            // 
            this.txtAN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtAN.Location = new System.Drawing.Point(49, 48);
            this.txtAN.Margin = new System.Windows.Forms.Padding(2);
            this.txtAN.Name = "txtAN";
            this.txtAN.Size = new System.Drawing.Size(220, 23);
            this.txtAN.TabIndex = 1;
            // 
            // btnGen
            // 
            this.btnGen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnGen.Image = ((System.Drawing.Image)(resources.GetObject("btnGen.Image")));
            this.btnGen.Location = new System.Drawing.Point(273, 48);
            this.btnGen.Margin = new System.Windows.Forms.Padding(2);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(72, 58);
            this.btnGen.TabIndex = 2;
            this.btnGen.UseVisualStyleBackColor = true;
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Location = new System.Drawing.Point(421, 48);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(74, 58);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(13, 86);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "HN";
            // 
            // txtHN
            // 
            this.txtHN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtHN.Location = new System.Drawing.Point(49, 83);
            this.txtHN.Margin = new System.Windows.Forms.Padding(2);
            this.txtHN.Name = "txtHN";
            this.txtHN.Size = new System.Drawing.Size(220, 23);
            this.txtHN.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(13, 120);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "First Name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtFirstName.Location = new System.Drawing.Point(97, 117);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(2);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(155, 23);
            this.txtFirstName.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(261, 120);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Last Name";
            // 
            // txtLastName
            // 
            this.txtLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtLastName.Location = new System.Drawing.Point(341, 117);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(2);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(155, 23);
            this.txtLastName.TabIndex = 12;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(241, 187);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(255, 186);
            this.pictureBox.TabIndex = 13;
            this.pictureBox.TabStop = false;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(545, 24);
            this.menuStrip.TabIndex = 14;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.configToolStripMenuItem.Text = "Config";
            this.configToolStripMenuItem.Click += new System.EventHandler(this.configToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(107, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // dgView
            // 
            this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgView.Location = new System.Drawing.Point(18, 187);
            this.dgView.Margin = new System.Windows.Forms.Padding(2);
            this.dgView.Name = "dgView";
            this.dgView.RowTemplate.Height = 24;
            this.dgView.Size = new System.Drawing.Size(210, 186);
            this.dgView.TabIndex = 15;
            this.dgView.SelectionChanged += new System.EventHandler(this.dgView_SelectionChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(14, 16);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "IPD Form";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(14, 164);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "Output Barcode";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(237, 164);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 20);
            this.label7.TabIndex = 18;
            this.label7.Text = "Barcode Image";
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnPrintPreview.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintPreview.Image")));
            this.btnPrintPreview.Location = new System.Drawing.Point(350, 48);
            this.btnPrintPreview.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(66, 58);
            this.btnPrintPreview.TabIndex = 19;
            this.btnPrintPreview.UseVisualStyleBackColor = true;
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageIPD);
            this.tabControl.Controls.Add(this.tabPageOPD);
            this.tabControl.Location = new System.Drawing.Point(12, 27);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(520, 417);
            this.tabControl.TabIndex = 20;
            // 
            // tabPageIPD
            // 
            this.tabPageIPD.Controls.Add(this.label5);
            this.tabPageIPD.Controls.Add(this.btnPrintPreview);
            this.tabPageIPD.Controls.Add(this.label1);
            this.tabPageIPD.Controls.Add(this.label7);
            this.tabPageIPD.Controls.Add(this.txtAN);
            this.tabPageIPD.Controls.Add(this.label6);
            this.tabPageIPD.Controls.Add(this.btnGen);
            this.tabPageIPD.Controls.Add(this.btnPrint);
            this.tabPageIPD.Controls.Add(this.dgView);
            this.tabPageIPD.Controls.Add(this.label2);
            this.tabPageIPD.Controls.Add(this.pictureBox);
            this.tabPageIPD.Controls.Add(this.txtHN);
            this.tabPageIPD.Controls.Add(this.txtLastName);
            this.tabPageIPD.Controls.Add(this.label3);
            this.tabPageIPD.Controls.Add(this.label4);
            this.tabPageIPD.Controls.Add(this.txtFirstName);
            this.tabPageIPD.Location = new System.Drawing.Point(4, 22);
            this.tabPageIPD.Name = "tabPageIPD";
            this.tabPageIPD.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageIPD.Size = new System.Drawing.Size(512, 391);
            this.tabPageIPD.TabIndex = 0;
            this.tabPageIPD.Text = "IPD";
            this.tabPageIPD.UseVisualStyleBackColor = true;
            // 
            // tabPageOPD
            // 
            this.tabPageOPD.Controls.Add(this.chkBlankOPD);
            this.tabPageOPD.Controls.Add(this.label12);
            this.tabPageOPD.Controls.Add(this.label13);
            this.tabPageOPD.Controls.Add(this.dgViewOPD);
            this.tabPageOPD.Controls.Add(this.pictureBoxOPD);
            this.tabPageOPD.Controls.Add(this.txtVNOPD);
            this.tabPageOPD.Controls.Add(this.label11);
            this.tabPageOPD.Controls.Add(this.cmbVSDateOPD);
            this.tabPageOPD.Controls.Add(this.label10);
            this.tabPageOPD.Controls.Add(this.label8);
            this.tabPageOPD.Controls.Add(this.btnPreviewOPD);
            this.tabPageOPD.Controls.Add(this.label9);
            this.tabPageOPD.Controls.Add(this.txtHNOPD);
            this.tabPageOPD.Controls.Add(this.btnGenOPD);
            this.tabPageOPD.Controls.Add(this.btnPrintOPD);
            this.tabPageOPD.Location = new System.Drawing.Point(4, 22);
            this.tabPageOPD.Name = "tabPageOPD";
            this.tabPageOPD.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOPD.Size = new System.Drawing.Size(512, 391);
            this.tabPageOPD.TabIndex = 1;
            this.tabPageOPD.Text = "OPD";
            this.tabPageOPD.UseVisualStyleBackColor = true;
            // 
            // chkBlankOPD
            // 
            this.chkBlankOPD.AutoSize = true;
            this.chkBlankOPD.Location = new System.Drawing.Point(275, 122);
            this.chkBlankOPD.Name = "chkBlankOPD";
            this.chkBlankOPD.Size = new System.Drawing.Size(153, 17);
            this.chkBlankOPD.TabIndex = 34;
            this.chkBlankOPD.Text = "I want to print without type.";
            this.chkBlankOPD.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label12.Location = new System.Drawing.Point(238, 166);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(131, 20);
            this.label12.TabIndex = 33;
            this.label12.Text = "Barcode Image";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label13.Location = new System.Drawing.Point(15, 166);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(136, 20);
            this.label13.TabIndex = 32;
            this.label13.Text = "Output Barcode";
            // 
            // dgViewOPD
            // 
            this.dgViewOPD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgViewOPD.Location = new System.Drawing.Point(19, 189);
            this.dgViewOPD.Margin = new System.Windows.Forms.Padding(2);
            this.dgViewOPD.Name = "dgViewOPD";
            this.dgViewOPD.RowTemplate.Height = 24;
            this.dgViewOPD.Size = new System.Drawing.Size(210, 186);
            this.dgViewOPD.TabIndex = 31;
            // 
            // pictureBoxOPD
            // 
            this.pictureBoxOPD.Location = new System.Drawing.Point(242, 189);
            this.pictureBoxOPD.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxOPD.Name = "pictureBoxOPD";
            this.pictureBoxOPD.Size = new System.Drawing.Size(255, 186);
            this.pictureBoxOPD.TabIndex = 30;
            this.pictureBoxOPD.TabStop = false;
            // 
            // txtVNOPD
            // 
            this.txtVNOPD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtVNOPD.Location = new System.Drawing.Point(81, 119);
            this.txtVNOPD.Margin = new System.Windows.Forms.Padding(2);
            this.txtVNOPD.Name = "txtVNOPD";
            this.txtVNOPD.Size = new System.Drawing.Size(188, 23);
            this.txtVNOPD.TabIndex = 29;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label11.Location = new System.Drawing.Point(16, 122);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 17);
            this.label11.TabIndex = 28;
            this.label11.Text = "VN";
            // 
            // cmbVSDateOPD
            // 
            this.cmbVSDateOPD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cmbVSDateOPD.FormattingEnabled = true;
            this.cmbVSDateOPD.Location = new System.Drawing.Point(81, 82);
            this.cmbVSDateOPD.Name = "cmbVSDateOPD";
            this.cmbVSDateOPD.Size = new System.Drawing.Size(187, 24);
            this.cmbVSDateOPD.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label10.Location = new System.Drawing.Point(16, 84);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 17);
            this.label10.TabIndex = 26;
            this.label10.Text = "Date";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(14, 16);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 20);
            this.label8.TabIndex = 24;
            this.label8.Text = "OPD Form";
            // 
            // btnPreviewOPD
            // 
            this.btnPreviewOPD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreviewOPD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnPreviewOPD.Image = ((System.Drawing.Image)(resources.GetObject("btnPreviewOPD.Image")));
            this.btnPreviewOPD.Location = new System.Drawing.Point(350, 48);
            this.btnPreviewOPD.Margin = new System.Windows.Forms.Padding(2);
            this.btnPreviewOPD.Name = "btnPreviewOPD";
            this.btnPreviewOPD.Size = new System.Drawing.Size(66, 58);
            this.btnPreviewOPD.TabIndex = 25;
            this.btnPreviewOPD.UseVisualStyleBackColor = true;
            this.btnPreviewOPD.Click += new System.EventHandler(this.btnPreviewOPD_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label9.Location = new System.Drawing.Point(14, 49);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 17);
            this.label9.TabIndex = 20;
            this.label9.Text = "HN";
            // 
            // txtHNOPD
            // 
            this.txtHNOPD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtHNOPD.Location = new System.Drawing.Point(81, 48);
            this.txtHNOPD.Margin = new System.Windows.Forms.Padding(2);
            this.txtHNOPD.Name = "txtHNOPD";
            this.txtHNOPD.Size = new System.Drawing.Size(188, 23);
            this.txtHNOPD.TabIndex = 21;
            // 
            // btnGenOPD
            // 
            this.btnGenOPD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenOPD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnGenOPD.Image = ((System.Drawing.Image)(resources.GetObject("btnGenOPD.Image")));
            this.btnGenOPD.Location = new System.Drawing.Point(273, 48);
            this.btnGenOPD.Margin = new System.Windows.Forms.Padding(2);
            this.btnGenOPD.Name = "btnGenOPD";
            this.btnGenOPD.Size = new System.Drawing.Size(72, 58);
            this.btnGenOPD.TabIndex = 22;
            this.btnGenOPD.UseVisualStyleBackColor = true;
            this.btnGenOPD.Click += new System.EventHandler(this.btnGenOPD_Click);
            // 
            // btnPrintOPD
            // 
            this.btnPrintOPD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintOPD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnPrintOPD.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintOPD.Image")));
            this.btnPrintOPD.Location = new System.Drawing.Point(421, 48);
            this.btnPrintOPD.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrintOPD.Name = "btnPrintOPD";
            this.btnPrintOPD.Size = new System.Drawing.Size(74, 58);
            this.btnPrintOPD.TabIndex = 23;
            this.btnPrintOPD.UseVisualStyleBackColor = true;
            this.btnPrintOPD.Click += new System.EventHandler(this.btnPrintOPD_Click);
            // 
            // mainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 459);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "mainFrm";
            this.Text = "Barcode Generator";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainFrm_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPageIPD.ResumeLayout(false);
            this.tabPageIPD.PerformLayout();
            this.tabPageOPD.ResumeLayout(false);
            this.tabPageOPD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewOPD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOPD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAN;
        private System.Windows.Forms.Button btnGen;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgView;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnPrintPreview;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageIPD;
        private System.Windows.Forms.TabPage tabPageOPD;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView dgViewOPD;
        private System.Windows.Forms.PictureBox pictureBoxOPD;
        private System.Windows.Forms.TextBox txtVNOPD;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbVSDateOPD;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnPreviewOPD;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtHNOPD;
        private System.Windows.Forms.Button btnGenOPD;
        private System.Windows.Forms.Button btnPrintOPD;
        private System.Windows.Forms.CheckBox chkBlankOPD;
    }
}

