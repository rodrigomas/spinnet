namespace SpinNet
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainContainer = new System.Windows.Forms.Panel();
            this.Simulator = new System.ComponentModel.BackgroundWorker();
            this.Run = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AtomsUP = new System.Windows.Forms.NumericUpDown();
            this.StepsUP = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.ChangeTB = new System.Windows.Forms.TextBox();
            this.TempTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.UseGPU = new System.Windows.Forms.CheckBox();
            this.MatrixReuse = new System.Windows.Forms.CheckBox();
            this.CancelBT = new System.Windows.Forms.Button();
            this.SaveIMatrixBT = new System.Windows.Forms.Button();
            this.SaveImageBT = new System.Windows.Forms.Button();
            this.RefreshBT = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.MatrixCombo = new System.Windows.Forms.ComboBox();
            this.RenderIt = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ZoomBar = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.AtomSpaceUP = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.AtomSizeUP = new System.Windows.Forms.NumericUpDown();
            this.Progress = new System.Windows.Forms.ProgressBar();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TimeList = new System.Windows.Forms.ListView();
            this.GridSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GridIt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SimTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel5 = new System.Windows.Forms.Panel();
            this.ListSave = new System.Windows.Forms.Button();
            this.ListClear = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.RunningLabel = new System.Windows.Forms.Label();
            this.btAbout = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.SimTimer = new System.Windows.Forms.Timer(this.components);
            this.SimulatorGPU = new System.ComponentModel.BackgroundWorker();
            this.Engine = new SpinNet.RenderPanel();
            this.MainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AtomsUP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StepsUP)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZoomBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AtomSpaceUP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AtomSizeUP)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainContainer
            // 
            this.MainContainer.AutoScroll = true;
            this.MainContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MainContainer.Controls.Add(this.Engine);
            this.MainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainContainer.Location = new System.Drawing.Point(10, 10);
            this.MainContainer.Name = "MainContainer";
            this.MainContainer.Size = new System.Drawing.Size(656, 615);
            this.MainContainer.TabIndex = 0;
            this.MainContainer.SizeChanged += new System.EventHandler(this.MainContainer_Resize);
            this.MainContainer.Resize += new System.EventHandler(this.MainContainer_Resize);
            // 
            // Simulator
            // 
            this.Simulator.WorkerReportsProgress = true;
            this.Simulator.WorkerSupportsCancellation = true;
            this.Simulator.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Simulator_DoWork);
            this.Simulator.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Simulator_ProgressChanged);
            this.Simulator.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Simulator_RunWorkerCompleted);
            // 
            // Run
            // 
            this.Run.Location = new System.Drawing.Point(170, 157);
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(75, 23);
            this.Run.TabIndex = 2;
            this.Run.Text = "Run";
            this.Run.UseVisualStyleBackColor = true;
            this.Run.Click += new System.EventHandler(this.Run_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Atoms:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Steps:";
            // 
            // AtomsUP
            // 
            this.AtomsUP.Location = new System.Drawing.Point(85, 22);
            this.AtomsUP.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.AtomsUP.Name = "AtomsUP";
            this.AtomsUP.Size = new System.Drawing.Size(160, 20);
            this.AtomsUP.TabIndex = 7;
            this.AtomsUP.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.AtomsUP.ValueChanged += new System.EventHandler(this.AtomsUP_ValueChanged);
            // 
            // StepsUP
            // 
            this.StepsUP.Location = new System.Drawing.Point(85, 60);
            this.StepsUP.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.StepsUP.Name = "StepsUP";
            this.StepsUP.Size = new System.Drawing.Size(160, 20);
            this.StepsUP.TabIndex = 8;
            this.StepsUP.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "J:";
            // 
            // ChangeTB
            // 
            this.ChangeTB.Location = new System.Drawing.Point(85, 96);
            this.ChangeTB.Name = "ChangeTB";
            this.ChangeTB.Size = new System.Drawing.Size(160, 20);
            this.ChangeTB.TabIndex = 10;
            this.ChangeTB.Text = "1";
            // 
            // TempTB
            // 
            this.TempTB.Location = new System.Drawing.Point(85, 131);
            this.TempTB.Name = "TempTB";
            this.TempTB.Size = new System.Drawing.Size(160, 20);
            this.TempTB.TabIndex = 12;
            this.TempTB.Text = "0.12";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Temperature:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.UseGPU);
            this.groupBox1.Controls.Add(this.MatrixReuse);
            this.groupBox1.Controls.Add(this.CancelBT);
            this.groupBox1.Controls.Add(this.Run);
            this.groupBox1.Controls.Add(this.TempTB);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ChangeTB);
            this.groupBox1.Controls.Add(this.AtomsUP);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.StepsUP);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 241);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Simulation Options ";
            // 
            // UseGPU
            // 
            this.UseGPU.AutoSize = true;
            this.UseGPU.Location = new System.Drawing.Point(85, 208);
            this.UseGPU.Name = "UseGPU";
            this.UseGPU.Size = new System.Drawing.Size(110, 17);
            this.UseGPU.TabIndex = 15;
            this.UseGPU.Text = "Use GPU (CUDA)";
            this.UseGPU.UseVisualStyleBackColor = true;
            // 
            // MatrixReuse
            // 
            this.MatrixReuse.AutoSize = true;
            this.MatrixReuse.Location = new System.Drawing.Point(85, 187);
            this.MatrixReuse.Name = "MatrixReuse";
            this.MatrixReuse.Size = new System.Drawing.Size(131, 17);
            this.MatrixReuse.TabIndex = 14;
            this.MatrixReuse.Text = "Reuse the initial matrix";
            this.MatrixReuse.UseVisualStyleBackColor = true;
            // 
            // CancelBT
            // 
            this.CancelBT.Enabled = false;
            this.CancelBT.Location = new System.Drawing.Point(85, 157);
            this.CancelBT.Name = "CancelBT";
            this.CancelBT.Size = new System.Drawing.Size(75, 23);
            this.CancelBT.TabIndex = 13;
            this.CancelBT.Text = "Cancel";
            this.CancelBT.UseVisualStyleBackColor = true;
            this.CancelBT.Click += new System.EventHandler(this.CancelBT_Click);
            // 
            // SaveIMatrixBT
            // 
            this.SaveIMatrixBT.Location = new System.Drawing.Point(178, 12);
            this.SaveIMatrixBT.Name = "SaveIMatrixBT";
            this.SaveIMatrixBT.Size = new System.Drawing.Size(75, 23);
            this.SaveIMatrixBT.TabIndex = 14;
            this.SaveIMatrixBT.Text = "Save Matrix";
            this.SaveIMatrixBT.UseVisualStyleBackColor = true;
            this.SaveIMatrixBT.Click += new System.EventHandler(this.SaveIMatrixBT_Click);
            // 
            // SaveImageBT
            // 
            this.SaveImageBT.Location = new System.Drawing.Point(16, 12);
            this.SaveImageBT.Name = "SaveImageBT";
            this.SaveImageBT.Size = new System.Drawing.Size(75, 23);
            this.SaveImageBT.TabIndex = 15;
            this.SaveImageBT.Text = "Save Image";
            this.SaveImageBT.UseVisualStyleBackColor = true;
            this.SaveImageBT.Click += new System.EventHandler(this.SaveImageBT_Click);
            // 
            // RefreshBT
            // 
            this.RefreshBT.Location = new System.Drawing.Point(97, 12);
            this.RefreshBT.Name = "RefreshBT";
            this.RefreshBT.Size = new System.Drawing.Size(75, 23);
            this.RefreshBT.TabIndex = 16;
            this.RefreshBT.Text = "Refresh";
            this.RefreshBT.UseVisualStyleBackColor = true;
            this.RefreshBT.Click += new System.EventHandler(this.RefreshBT_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.MatrixCombo);
            this.groupBox2.Controls.Add(this.RenderIt);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.ZoomBar);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.AtomSpaceUP);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.AtomSizeUP);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(8, 299);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(275, 157);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Render Options ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(37, 135);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Matrix:";
            // 
            // MatrixCombo
            // 
            this.MatrixCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MatrixCombo.FormattingEnabled = true;
            this.MatrixCombo.Items.AddRange(new object[] {
            "Initial",
            "Final"});
            this.MatrixCombo.Location = new System.Drawing.Point(85, 129);
            this.MatrixCombo.Name = "MatrixCombo";
            this.MatrixCombo.Size = new System.Drawing.Size(93, 21);
            this.MatrixCombo.TabIndex = 21;
            this.MatrixCombo.SelectedIndexChanged += new System.EventHandler(this.MatrixCombo_SelectedIndexChanged);
            // 
            // RenderIt
            // 
            this.RenderIt.AutoSize = true;
            this.RenderIt.Checked = true;
            this.RenderIt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RenderIt.Location = new System.Drawing.Point(184, 131);
            this.RenderIt.Name = "RenderIt";
            this.RenderIt.Size = new System.Drawing.Size(61, 17);
            this.RenderIt.TabIndex = 20;
            this.RenderIt.Text = "Render";
            this.RenderIt.UseVisualStyleBackColor = true;
            this.RenderIt.CheckedChanged += new System.EventHandler(this.RenderIt_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Zoom:";
            // 
            // ZoomBar
            // 
            this.ZoomBar.Location = new System.Drawing.Point(85, 80);
            this.ZoomBar.Maximum = 100;
            this.ZoomBar.Name = "ZoomBar";
            this.ZoomBar.Size = new System.Drawing.Size(160, 45);
            this.ZoomBar.TabIndex = 12;
            this.ZoomBar.TickFrequency = 5;
            this.ZoomBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.ZoomBar.Value = 100;
            this.ZoomBar.ValueChanged += new System.EventHandler(this.ZoomBar_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Atom Space:";
            // 
            // AtomSpaceUP
            // 
            this.AtomSpaceUP.Location = new System.Drawing.Point(85, 57);
            this.AtomSpaceUP.Name = "AtomSpaceUP";
            this.AtomSpaceUP.Size = new System.Drawing.Size(160, 20);
            this.AtomSpaceUP.TabIndex = 11;
            this.AtomSpaceUP.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.AtomSpaceUP.ValueChanged += new System.EventHandler(this.AtomSpaceUP_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Atom Size:";
            // 
            // AtomSizeUP
            // 
            this.AtomSizeUP.Location = new System.Drawing.Point(85, 21);
            this.AtomSizeUP.Name = "AtomSizeUP";
            this.AtomSizeUP.Size = new System.Drawing.Size(160, 20);
            this.AtomSizeUP.TabIndex = 9;
            this.AtomSizeUP.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.AtomSizeUP.ValueChanged += new System.EventHandler(this.AtomSizeUP_ValueChanged);
            // 
            // Progress
            // 
            this.Progress.Location = new System.Drawing.Point(7, 22);
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(265, 23);
            this.Progress.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Progress:";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(666, 10);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(8);
            this.panel1.Size = new System.Drawing.Size(291, 615);
            this.panel1.TabIndex = 20;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.TimeList);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(8, 456);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(5);
            this.panel3.Size = new System.Drawing.Size(275, 79);
            this.panel3.TabIndex = 25;
            // 
            // TimeList
            // 
            this.TimeList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.GridSize,
            this.GridIt,
            this.SimTime});
            this.TimeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TimeList.FullRowSelect = true;
            this.TimeList.GridLines = true;
            this.TimeList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.TimeList.Location = new System.Drawing.Point(5, 5);
            this.TimeList.Name = "TimeList";
            this.TimeList.Size = new System.Drawing.Size(207, 69);
            this.TimeList.TabIndex = 1;
            this.TimeList.UseCompatibleStateImageBehavior = false;
            this.TimeList.View = System.Windows.Forms.View.Details;
            this.TimeList.Resize += new System.EventHandler(this.TimeList_Resize);
            // 
            // GridSize
            // 
            this.GridSize.Text = "Atoms";
            this.GridSize.Width = 50;
            // 
            // GridIt
            // 
            this.GridIt.Text = "Steps";
            this.GridIt.Width = 65;
            // 
            // SimTime
            // 
            this.SimTime.Text = "Time (ms)";
            this.SimTime.Width = 84;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.ListSave);
            this.panel5.Controls.Add(this.ListClear);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(212, 5);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(58, 69);
            this.panel5.TabIndex = 0;
            // 
            // ListSave
            // 
            this.ListSave.Location = new System.Drawing.Point(6, 37);
            this.ListSave.Name = "ListSave";
            this.ListSave.Size = new System.Drawing.Size(46, 23);
            this.ListSave.TabIndex = 1;
            this.ListSave.Text = "Save";
            this.ListSave.UseVisualStyleBackColor = true;
            this.ListSave.Click += new System.EventHandler(this.ListSave_Click);
            // 
            // ListClear
            // 
            this.ListClear.Location = new System.Drawing.Point(6, 8);
            this.ListClear.Name = "ListClear";
            this.ListClear.Size = new System.Drawing.Size(47, 23);
            this.ListClear.TabIndex = 0;
            this.ListClear.Text = "Clear";
            this.ListClear.UseVisualStyleBackColor = true;
            this.ListClear.Click += new System.EventHandler(this.ListClear_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.SaveImageBT);
            this.panel4.Controls.Add(this.RefreshBT);
            this.panel4.Controls.Add(this.SaveIMatrixBT);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(8, 249);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(275, 50);
            this.panel4.TabIndex = 26;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Progress);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.RunningLabel);
            this.panel2.Controls.Add(this.btAbout);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(8, 535);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(275, 72);
            this.panel2.TabIndex = 24;
            // 
            // RunningLabel
            // 
            this.RunningLabel.AutoSize = true;
            this.RunningLabel.Location = new System.Drawing.Point(41, 52);
            this.RunningLabel.Name = "RunningLabel";
            this.RunningLabel.Size = new System.Drawing.Size(49, 13);
            this.RunningLabel.TabIndex = 22;
            this.RunningLabel.Text = "00:00:00";
            // 
            // btAbout
            // 
            this.btAbout.Location = new System.Drawing.Point(197, 47);
            this.btAbout.Name = "btAbout";
            this.btAbout.Size = new System.Drawing.Size(75, 23);
            this.btAbout.TabIndex = 20;
            this.btAbout.Text = "About";
            this.btAbout.UseVisualStyleBackColor = true;
            this.btAbout.Click += new System.EventHandler(this.btAbout_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Time:";
            // 
            // SimTimer
            // 
            this.SimTimer.Interval = 500;
            this.SimTimer.Tick += new System.EventHandler(this.SimTimer_Tick);
            // 
            // SimulatorGPU
            // 
            this.SimulatorGPU.DoWork += new System.ComponentModel.DoWorkEventHandler(this.SimulatorGPU_DoWork);
            this.SimulatorGPU.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Simulator_RunWorkerCompleted);
            // 
            // Engine
            // 
            this.Engine.Location = new System.Drawing.Point(109, 32);
            this.Engine.Name = "Engine";
            this.Engine.Size = new System.Drawing.Size(400, 400);
            this.Engine.TabIndex = 1;
            this.Engine.Paint += new System.Windows.Forms.PaintEventHandler(this.Engine_Paint);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 635);
            this.Controls.Add(this.MainContainer);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spin Network Simulator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MaximizedBoundsChanged += new System.EventHandler(this.MainContainer_Resize);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.SizeChanged += new System.EventHandler(this.MainContainer_Resize);
            this.Resize += new System.EventHandler(this.MainContainer_Resize);
            this.MainContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AtomsUP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StepsUP)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZoomBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AtomSpaceUP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AtomSizeUP)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainContainer;
        private RenderPanel Engine;
        private System.ComponentModel.BackgroundWorker Simulator;
        private System.Windows.Forms.Button Run;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown AtomsUP;
        private System.Windows.Forms.NumericUpDown StepsUP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ChangeTB;
        private System.Windows.Forms.TextBox TempTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button CancelBT;
        private System.Windows.Forms.Button SaveIMatrixBT;
        private System.Windows.Forms.Button SaveImageBT;
        private System.Windows.Forms.Button RefreshBT;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown AtomSizeUP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown AtomSpaceUP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar ZoomBar;
        private System.Windows.Forms.ProgressBar Progress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox RenderIt;
        private System.Windows.Forms.Button btAbout;
        private System.Windows.Forms.Label RunningLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox MatrixCombo;
        private System.Windows.Forms.Timer SimTimer;
        private System.Windows.Forms.CheckBox MatrixReuse;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView TimeList;
        private System.Windows.Forms.ColumnHeader GridSize;
        private System.Windows.Forms.ColumnHeader SimTime;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button ListSave;
        private System.Windows.Forms.Button ListClear;
        private System.Windows.Forms.ColumnHeader GridIt;
        private System.ComponentModel.BackgroundWorker SimulatorGPU;
        private System.Windows.Forms.CheckBox UseGPU;
    }
}

