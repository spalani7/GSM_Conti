namespace Client_Application
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ClientNameTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ServerStatus = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.RefreshStatus = new System.Windows.Forms.Button();
            this.RunningB = new System.Windows.Forms.Button();
            this.UnderAnalysisB = new System.Windows.Forms.Button();
            this.BreakdownB = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SelLineCB = new System.Windows.Forms.ComboBox();
            this.LineDGV = new System.Windows.Forms.DataGridView();
            this.StationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.No_of_DT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LongestDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResendMessB = new System.Windows.Forms.Button();
            this.TimeStamp = new System.Windows.Forms.Label();
            this.StationNameL = new System.Windows.Forms.Label();
            this.LastCmdTB = new System.Windows.Forms.TextBox();
            this.LastRespTB = new System.Windows.Forms.TextBox();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.TracerDGV = new System.Windows.Forms.DataGridView();
            this.TiST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MessType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MessText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.RecMessTB = new System.Windows.Forms.TextBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LineDGV)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TracerDGV)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClientNameTB
            // 
            this.ClientNameTB.Location = new System.Drawing.Point(120, 522);
            this.ClientNameTB.Name = "ClientNameTB";
            this.ClientNameTB.Size = new System.Drawing.Size(136, 20);
            this.ClientNameTB.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 525);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Client Name";
            // 
            // ServerStatus
            // 
            this.ServerStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ServerStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ServerStatus.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerStatus.Location = new System.Drawing.Point(0, 652);
            this.ServerStatus.Name = "ServerStatus";
            this.ServerStatus.Size = new System.Drawing.Size(955, 21);
            this.ServerStatus.TabIndex = 27;
            this.ServerStatus.Text = "Server Status";
            this.ServerStatus.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ServerStatus.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(280, 519);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(955, 652);
            this.tabControl1.TabIndex = 31;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.pictureBox4);
            this.tabPage1.Controls.Add(this.pictureBox3);
            this.tabPage1.Controls.Add(this.RefreshStatus);
            this.tabPage1.Controls.Add(this.RunningB);
            this.tabPage1.Controls.Add(this.UnderAnalysisB);
            this.tabPage1.Controls.Add(this.BreakdownB);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.SelLineCB);
            this.tabPage1.Controls.Add(this.LineDGV);
            this.tabPage1.Controls.Add(this.ResendMessB);
            this.tabPage1.Controls.Add(this.TimeStamp);
            this.tabPage1.Controls.Add(this.StationNameL);
            this.tabPage1.Controls.Add(this.LastCmdTB);
            this.tabPage1.Controls.Add(this.LastRespTB);
            this.tabPage1.Controls.Add(this.shapeContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(947, 626);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "DT Monitor";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(743, 292);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(47, 65);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 45;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(743, 175);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(47, 65);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 44;
            this.pictureBox3.TabStop = false;
            // 
            // RefreshStatus
            // 
            this.RefreshStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RefreshStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefreshStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefreshStatus.Location = new System.Drawing.Point(387, 15);
            this.RefreshStatus.Name = "RefreshStatus";
            this.RefreshStatus.Size = new System.Drawing.Size(109, 29);
            this.RefreshStatus.TabIndex = 43;
            this.RefreshStatus.Text = "Refresh";
            this.RefreshStatus.UseVisualStyleBackColor = true;
            this.RefreshStatus.Click += new System.EventHandler(this.RefreshStatus_Click);
            // 
            // RunningB
            // 
            this.RunningB.BackColor = System.Drawing.Color.LawnGreen;
            this.RunningB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RunningB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RunningB.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunningB.Location = new System.Drawing.Point(701, 128);
            this.RunningB.Name = "RunningB";
            this.RunningB.Size = new System.Drawing.Size(128, 41);
            this.RunningB.TabIndex = 40;
            this.RunningB.Text = "Running";
            this.RunningB.UseVisualStyleBackColor = false;
            this.RunningB.Click += new System.EventHandler(this.Running_Click);
            // 
            // UnderAnalysisB
            // 
            this.UnderAnalysisB.BackColor = System.Drawing.Color.Yellow;
            this.UnderAnalysisB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UnderAnalysisB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UnderAnalysisB.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UnderAnalysisB.Location = new System.Drawing.Point(701, 363);
            this.UnderAnalysisB.Name = "UnderAnalysisB";
            this.UnderAnalysisB.Size = new System.Drawing.Size(128, 42);
            this.UnderAnalysisB.TabIndex = 39;
            this.UnderAnalysisB.Text = "Under Analysis";
            this.UnderAnalysisB.UseVisualStyleBackColor = false;
            this.UnderAnalysisB.Click += new System.EventHandler(this.UnderAnalysis_Click);
            // 
            // BreakdownB
            // 
            this.BreakdownB.BackColor = System.Drawing.Color.Red;
            this.BreakdownB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BreakdownB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BreakdownB.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BreakdownB.Location = new System.Drawing.Point(701, 246);
            this.BreakdownB.Name = "BreakdownB";
            this.BreakdownB.Size = new System.Drawing.Size(128, 40);
            this.BreakdownB.TabIndex = 38;
            this.BreakdownB.Text = "Breakdown";
            this.BreakdownB.UseVisualStyleBackColor = false;
            this.BreakdownB.Click += new System.EventHandler(this.Breakdown_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "* All data belongs to today.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 21);
            this.label1.TabIndex = 37;
            this.label1.Text = "Select Line:";
            // 
            // SelLineCB
            // 
            this.SelLineCB.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.SelLineCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelLineCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelLineCB.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelLineCB.FormattingEnabled = true;
            this.SelLineCB.Location = new System.Drawing.Point(139, 15);
            this.SelLineCB.Name = "SelLineCB";
            this.SelLineCB.Size = new System.Drawing.Size(212, 29);
            this.SelLineCB.TabIndex = 36;
            this.SelLineCB.SelectedIndexChanged += new System.EventHandler(this.SelLineCB_SelectedIndexChanged);
            // 
            // LineDGV
            // 
            this.LineDGV.AllowUserToAddRows = false;
            this.LineDGV.AllowUserToDeleteRows = false;
            this.LineDGV.AllowUserToResizeColumns = false;
            this.LineDGV.AllowUserToResizeRows = false;
            this.LineDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.LineDGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.LineDGV.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LineDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LineDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.LineDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LineDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StationName,
            this.Status,
            this.No_of_DT,
            this.LongestDT,
            this.TotalDT,
            this.LastDT});
            this.LineDGV.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LineDGV.DefaultCellStyle = dataGridViewCellStyle6;
            this.LineDGV.EnableHeadersVisualStyles = false;
            this.LineDGV.Location = new System.Drawing.Point(25, 71);
            this.LineDGV.Name = "LineDGV";
            this.LineDGV.ReadOnly = true;
            this.LineDGV.RowHeadersWidth = 25;
            this.LineDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LineDGV.Size = new System.Drawing.Size(536, 483);
            this.LineDGV.TabIndex = 35;
            this.LineDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LineDGV_CellClick);
            this.LineDGV.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.LineDGV_CellMouseEnter);
            // 
            // StationName
            // 
            this.StationName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.StationName.HeaderText = "Station Name";
            this.StationName.MinimumWidth = 300;
            this.StationName.Name = "StationName";
            this.StationName.ReadOnly = true;
            this.StationName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.StationName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.StationName.Width = 300;
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 100;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // No_of_DT
            // 
            this.No_of_DT.HeaderText = "No of Dt(s)";
            this.No_of_DT.Name = "No_of_DT";
            this.No_of_DT.ReadOnly = true;
            this.No_of_DT.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.No_of_DT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.No_of_DT.Visible = false;
            this.No_of_DT.Width = 95;
            // 
            // LongestDT
            // 
            this.LongestDT.HeaderText = "Longest DT";
            this.LongestDT.Name = "LongestDT";
            this.LongestDT.ReadOnly = true;
            this.LongestDT.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.LongestDT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LongestDT.Visible = false;
            this.LongestDT.Width = 95;
            // 
            // TotalDT
            // 
            this.TotalDT.HeaderText = "Total DT";
            this.TotalDT.Name = "TotalDT";
            this.TotalDT.ReadOnly = true;
            this.TotalDT.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TotalDT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TotalDT.Visible = false;
            this.TotalDT.Width = 75;
            // 
            // LastDT
            // 
            this.LastDT.HeaderText = "Last DT";
            this.LastDT.Name = "LastDT";
            this.LastDT.ReadOnly = true;
            this.LastDT.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.LastDT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LastDT.Visible = false;
            this.LastDT.Width = 68;
            // 
            // ResendMessB
            // 
            this.ResendMessB.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ResendMessB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ResendMessB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResendMessB.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResendMessB.Location = new System.Drawing.Point(660, 428);
            this.ResendMessB.Name = "ResendMessB";
            this.ResendMessB.Size = new System.Drawing.Size(211, 75);
            this.ResendMessB.TabIndex = 34;
            this.ResendMessB.Text = "RESEND MESSAGE";
            this.ResendMessB.UseVisualStyleBackColor = false;
            this.ResendMessB.Click += new System.EventHandler(this.ResendMessB_Click);
            // 
            // TimeStamp
            // 
            this.TimeStamp.AutoSize = true;
            this.TimeStamp.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeStamp.Location = new System.Drawing.Point(638, 19);
            this.TimeStamp.Name = "TimeStamp";
            this.TimeStamp.Size = new System.Drawing.Size(65, 25);
            this.TimeStamp.TabIndex = 33;
            this.TimeStamp.Text = "label1";
            // 
            // StationNameL
            // 
            this.StationNameL.AutoSize = true;
            this.StationNameL.BackColor = System.Drawing.Color.DarkOrange;
            this.StationNameL.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StationNameL.Location = new System.Drawing.Point(635, 71);
            this.StationNameL.Name = "StationNameL";
            this.StationNameL.Size = new System.Drawing.Size(0, 37);
            this.StationNameL.TabIndex = 32;
            // 
            // LastCmdTB
            // 
            this.LastCmdTB.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LastCmdTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LastCmdTB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LastCmdTB.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastCmdTB.Location = new System.Drawing.Point(3, 579);
            this.LastCmdTB.Name = "LastCmdTB";
            this.LastCmdTB.ReadOnly = true;
            this.LastCmdTB.Size = new System.Drawing.Size(941, 22);
            this.LastCmdTB.TabIndex = 31;
            // 
            // LastRespTB
            // 
            this.LastRespTB.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LastRespTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LastRespTB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LastRespTB.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastRespTB.Location = new System.Drawing.Point(3, 601);
            this.LastRespTB.Name = "LastRespTB";
            this.LastRespTB.ReadOnly = true;
            this.LastRespTB.Size = new System.Drawing.Size(941, 22);
            this.LastRespTB.TabIndex = 30;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(3, 3);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(941, 620);
            this.shapeContainer1.TabIndex = 46;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.Location = new System.Drawing.Point(639, 116);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(254, 301);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.TracerDGV);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(947, 626);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tracer";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // TracerDGV
            // 
            this.TracerDGV.AllowUserToAddRows = false;
            this.TracerDGV.AllowUserToDeleteRows = false;
            this.TracerDGV.AllowUserToResizeColumns = false;
            this.TracerDGV.AllowUserToResizeRows = false;
            this.TracerDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.TracerDGV.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TracerDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TracerDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.TracerDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TracerDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TiST,
            this.MessType,
            this.MessText});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.TracerDGV.DefaultCellStyle = dataGridViewCellStyle8;
            this.TracerDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TracerDGV.EnableHeadersVisualStyles = false;
            this.TracerDGV.Location = new System.Drawing.Point(3, 3);
            this.TracerDGV.Name = "TracerDGV";
            this.TracerDGV.ReadOnly = true;
            this.TracerDGV.RowHeadersVisible = false;
            this.TracerDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.TracerDGV.Size = new System.Drawing.Size(941, 620);
            this.TracerDGV.TabIndex = 31;
            // 
            // TiST
            // 
            this.TiST.HeaderText = "TimeStamp";
            this.TiST.Name = "TiST";
            this.TiST.ReadOnly = true;
            this.TiST.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TiST.Width = 75;
            // 
            // MessType
            // 
            this.MessType.HeaderText = "Type";
            this.MessType.Name = "MessType";
            this.MessType.ReadOnly = true;
            this.MessType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MessType.Width = 39;
            // 
            // MessText
            // 
            this.MessText.HeaderText = "Message";
            this.MessText.MinimumWidth = 500;
            this.MessText.Name = "MessText";
            this.MessText.ReadOnly = true;
            this.MessText.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MessText.Width = 500;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.RecMessTB);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(947, 626);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Log";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // RecMessTB
            // 
            this.RecMessTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RecMessTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RecMessTB.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecMessTB.Location = new System.Drawing.Point(3, 3);
            this.RecMessTB.Multiline = true;
            this.RecMessTB.Name = "RecMessTB";
            this.RecMessTB.ReadOnly = true;
            this.RecMessTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.RecMessTB.Size = new System.Drawing.Size(941, 620);
            this.RecMessTB.TabIndex = 7;
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(660, 524);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(211, 40);
            this.button2.TabIndex = 47;
            this.button2.Text = "Message";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(955, 673);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.ServerStatus);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ClientNameTB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GSM Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LineDGV)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TracerDGV)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ClientNameTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ServerStatus;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView TracerDGV;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox RecMessTB;
        private System.Windows.Forms.DataGridViewTextBoxColumn TiST;
        private System.Windows.Forms.DataGridViewTextBoxColumn MessType;
        private System.Windows.Forms.DataGridViewTextBoxColumn MessText;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView LineDGV;
        private System.Windows.Forms.Button ResendMessB;
        private System.Windows.Forms.Label TimeStamp;
        private System.Windows.Forms.Label StationNameL;
        private System.Windows.Forms.TextBox LastCmdTB;
        private System.Windows.Forms.TextBox LastRespTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox SelLineCB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button RunningB;
        private System.Windows.Forms.Button UnderAnalysisB;
        private System.Windows.Forms.Button BreakdownB;
        private System.Windows.Forms.Button RefreshStatus;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private System.Windows.Forms.DataGridViewTextBoxColumn StationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn No_of_DT;
        private System.Windows.Forms.DataGridViewTextBoxColumn LongestDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastDT;
        private System.Windows.Forms.Button button2;
    }
}

