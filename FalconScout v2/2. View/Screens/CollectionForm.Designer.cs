namespace T250DynoScout_v2023
{
    partial class MainScreen
    {
        ///<summary>
        ///Required designer variable.
        ///</summary>
        private System.ComponentModel.IContainer components = null;

        ///<summary>
        ///Clean up any resources being used.
        ///</summary>
        ///<param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        ///<summary>
        ///Required method for Designer support - do not modify
        ///the contents of this method with the code editor.
        ///</summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
            this.lstLog = new System.Windows.Forms.ListBox();
            this.timerJoysticks = new System.Windows.Forms.Timer(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.btnpopulateForEvent = new System.Windows.Forms.Button();
            this.btnPreviousMatch = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.btnInitialDBLoad = new System.Windows.Forms.Button();
            this.btnNextMatch = new System.Windows.Forms.Button();
            this.comboBoxSelectRegional = new System.Windows.Forms.ComboBox();
            this.lblMatch = new System.Windows.Forms.Label();
            this.lblkey = new System.Windows.Forms.Label();
            this.eventSummaryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelMatch = new System.Windows.Forms.Label();
            this.eventSummaryBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.cbxEndMatch = new System.Windows.Forms.CheckBox();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnUpdateDB = new System.Windows.Forms.Button();
            this.lbl0Position6Value2 = new System.Windows.Forms.Label();
            this.team1 = new System.Windows.Forms.Panel();
            this.lbl0Position6Value = new System.Windows.Forms.Label();
            this.lbl0Position10Value = new System.Windows.Forms.Label();
            this.lbl0Position10 = new System.Windows.Forms.Label();
            this.lbl0Position7Value = new System.Windows.Forms.Label();
            this.lbl0Position9Value = new System.Windows.Forms.Label();
            this.lbl0Position9 = new System.Windows.Forms.Label();
            this.lbl0Position7 = new System.Windows.Forms.Label();
            this.lbl0Position2Flag = new System.Windows.Forms.Label();
            this.lbl0Position0Flag = new System.Windows.Forms.Label();
            this.lbl0Position4Value = new System.Windows.Forms.Label();
            this.lbl0Position5Value = new System.Windows.Forms.Label();
            this.lbl0Position6 = new System.Windows.Forms.Label();
            this.lbl0Position2Value = new System.Windows.Forms.Label();
            this.lbl0Position1Value = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl0Position5 = new System.Windows.Forms.Label();
            this.lbl0Position4 = new System.Windows.Forms.Label();
            this.lbl0Position8Value = new System.Windows.Forms.Label();
            this.lbl0Position0 = new System.Windows.Forms.Label();
            this.lbl0Position3Value = new System.Windows.Forms.Label();
            this.lbl0Position3 = new System.Windows.Forms.Label();
            this.lbl0Position8 = new System.Windows.Forms.Label();
            this.lbl0Position1 = new System.Windows.Forms.Label();
            this.lbl0Position2 = new System.Windows.Forms.Label();
            this.lbl0Position11 = new System.Windows.Forms.Label();
            this.lbl0Position0Value = new System.Windows.Forms.Label();
            this.lbl0TeamName = new System.Windows.Forms.Label();
            this.lbl0ScoutName = new System.Windows.Forms.Label();
            this.lbl0ModeValue = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label28 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.eventSummaryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventSummaryBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.team1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstLog
            // 
            this.lstLog.BackColor = System.Drawing.Color.Black;
            this.lstLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstLog.ForeColor = System.Drawing.Color.White;
            this.lstLog.FormattingEnabled = true;
            this.lstLog.Location = new System.Drawing.Point(8, 728);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(1010, 0);
            this.lstLog.TabIndex = 1;
            this.lstLog.SelectedIndexChanged += new System.EventHandler(this.lstLog_SelectedIndexChanged);
            // 
            // timerJoysticks
            // 
            this.timerJoysticks.Interval = 50;
            this.timerJoysticks.Tick += new System.EventHandler(this.JoyStickReader);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Black;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Crimson;
            this.btnExit.Location = new System.Drawing.Point(939, 6);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(40, 23);
            this.btnExit.TabIndex = 228;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnpopulateForEvent
            // 
            this.btnpopulateForEvent.BackColor = System.Drawing.Color.Black;
            this.btnpopulateForEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnpopulateForEvent.ForeColor = System.Drawing.Color.Navy;
            this.btnpopulateForEvent.Location = new System.Drawing.Point(447, 6);
            this.btnpopulateForEvent.Name = "btnpopulateForEvent";
            this.btnpopulateForEvent.Size = new System.Drawing.Size(102, 23);
            this.btnpopulateForEvent.TabIndex = 232;
            this.btnpopulateForEvent.Text = "Get Matches";
            this.btnpopulateForEvent.UseVisualStyleBackColor = true;
            this.btnpopulateForEvent.Click += new System.EventHandler(this.btnpopulateForEvent_Click);
            // 
            // btnPreviousMatch
            // 
            this.btnPreviousMatch.BackColor = System.Drawing.Color.Black;
            this.btnPreviousMatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreviousMatch.ForeColor = System.Drawing.Color.Navy;
            this.btnPreviousMatch.Location = new System.Drawing.Point(551, 6);
            this.btnPreviousMatch.Name = "btnPreviousMatch";
            this.btnPreviousMatch.Size = new System.Drawing.Size(36, 23);
            this.btnPreviousMatch.TabIndex = 241;
            this.btnPreviousMatch.Text = "<<";
            this.btnPreviousMatch.UseVisualStyleBackColor = true;
            this.btnPreviousMatch.Click += new System.EventHandler(this.btnPreviousMatch_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label14.Location = new System.Drawing.Point(211, 12);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 26);
            this.label14.TabIndex = 244;
            this.label14.Text = "Event:\r\n\r\n";
            // 
            // btnInitialDBLoad
            // 
            this.btnInitialDBLoad.BackColor = System.Drawing.Color.Black;
            this.btnInitialDBLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInitialDBLoad.ForeColor = System.Drawing.Color.Navy;
            this.btnInitialDBLoad.Location = new System.Drawing.Point(128, 6);
            this.btnInitialDBLoad.Name = "btnInitialDBLoad";
            this.btnInitialDBLoad.Size = new System.Drawing.Size(79, 22);
            this.btnInitialDBLoad.TabIndex = 243;
            this.btnInitialDBLoad.Text = "Load >";
            this.btnInitialDBLoad.UseVisualStyleBackColor = true;
            this.btnInitialDBLoad.Click += new System.EventHandler(this.btnInitialDBLoad_Click);
            // 
            // btnNextMatch
            // 
            this.btnNextMatch.BackColor = System.Drawing.Color.Black;
            this.btnNextMatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextMatch.ForeColor = System.Drawing.Color.Navy;
            this.btnNextMatch.Location = new System.Drawing.Point(686, 6);
            this.btnNextMatch.Name = "btnNextMatch";
            this.btnNextMatch.Size = new System.Drawing.Size(36, 23);
            this.btnNextMatch.TabIndex = 253;
            this.btnNextMatch.Text = ">>";
            this.btnNextMatch.UseVisualStyleBackColor = true;
            this.btnNextMatch.Click += new System.EventHandler(this.btnNextMatch_Click);
            // 
            // comboBoxSelectRegional
            // 
            this.comboBoxSelectRegional.DisplayMember = "event_code";
            this.comboBoxSelectRegional.FormattingEnabled = true;
            this.comboBoxSelectRegional.Location = new System.Drawing.Point(250, 7);
            this.comboBoxSelectRegional.Name = "comboBoxSelectRegional";
            this.comboBoxSelectRegional.Size = new System.Drawing.Size(191, 21);
            this.comboBoxSelectRegional.TabIndex = 254;
            this.comboBoxSelectRegional.Text = "Please press the Load Events Button...";
            this.comboBoxSelectRegional.ValueMember = "event_code";
            this.comboBoxSelectRegional.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectRegional_SelectedIndexChanged);
            // 
            // lblMatch
            // 
            this.lblMatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblMatch.Location = new System.Drawing.Point(654, 7);
            this.lblMatch.Name = "lblMatch";
            this.lblMatch.Size = new System.Drawing.Size(36, 23);
            this.lblMatch.TabIndex = 264;
            this.lblMatch.Text = "0";
            this.lblMatch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMatch.Click += new System.EventHandler(this.lblMatch_Click);
            // 
            // lblkey
            // 
            this.lblkey.BackColor = System.Drawing.Color.Black;
            this.lblkey.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblkey.Location = new System.Drawing.Point(1028, 144);
            this.lblkey.Name = "lblkey";
            this.lblkey.Size = new System.Drawing.Size(272, 569);
            this.lblkey.TabIndex = 265;
            this.lblkey.Text = "lblkey";
            this.lblkey.Click += new System.EventHandler(this.lblkey_Click);
            // 
            // labelMatch
            // 
            this.labelMatch.AutoSize = true;
            this.labelMatch.BackColor = System.Drawing.Color.Black;
            this.labelMatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMatch.ForeColor = System.Drawing.Color.LimeGreen;
            this.labelMatch.Location = new System.Drawing.Point(587, 6);
            this.labelMatch.Name = "labelMatch";
            this.labelMatch.Size = new System.Drawing.Size(66, 24);
            this.labelMatch.TabIndex = 259;
            this.labelMatch.Text = "Match:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(120, 31);
            this.pictureBox2.TabIndex = 269;
            this.pictureBox2.TabStop = false;
            // 
            // cbxEndMatch
            // 
            this.cbxEndMatch.AutoSize = true;
            this.cbxEndMatch.BackColor = System.Drawing.Color.Black;
            this.cbxEndMatch.ForeColor = System.Drawing.Color.Yellow;
            this.cbxEndMatch.Location = new System.Drawing.Point(723, 10);
            this.cbxEndMatch.Margin = new System.Windows.Forms.Padding(2);
            this.cbxEndMatch.Name = "cbxEndMatch";
            this.cbxEndMatch.Size = new System.Drawing.Size(78, 17);
            this.cbxEndMatch.TabIndex = 280;
            this.cbxEndMatch.Text = "End Match";
            this.cbxEndMatch.UseVisualStyleBackColor = false;
            this.cbxEndMatch.CheckedChanged += new System.EventHandler(this.cbxEndMatch_CheckedChanged);
            // 
            // pictureBox14
            // 
            this.pictureBox14.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox14.Image")));
            this.pictureBox14.Location = new System.Drawing.Point(979, 2);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(55, 28);
            this.pictureBox14.TabIndex = 261;
            this.pictureBox14.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(1024, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(102, 138);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 268;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnUpdateDB
            // 
            this.btnUpdateDB.Location = new System.Drawing.Point(1040, 5);
            this.btnUpdateDB.Name = "btnUpdateDB";
            this.btnUpdateDB.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateDB.TabIndex = 282;
            this.btnUpdateDB.Text = "Update DB";
            this.btnUpdateDB.UseVisualStyleBackColor = true;
            this.btnUpdateDB.Click += new System.EventHandler(this.btnUpdateDB_Click);
            // 
            // lbl0Position6Value2
            // 
            this.lbl0Position6Value2.AutoSize = true;
            this.lbl0Position6Value2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl0Position6Value2.ForeColor = System.Drawing.Color.Red;
            this.lbl0Position6Value2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lbl0Position6Value2.Location = new System.Drawing.Point(418, 214);
            this.lbl0Position6Value2.Name = "lbl0Position6Value2";
            this.lbl0Position6Value2.Size = new System.Drawing.Size(38, 26);
            this.lbl0Position6Value2.TabIndex = 277;
            this.lbl0Position6Value2.Text = "00";
            this.lbl0Position6Value2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // team1
            // 
            this.team1.BackColor = System.Drawing.Color.Black;
            this.team1.Controls.Add(this.lbl0Position6Value);
            this.team1.Controls.Add(this.lbl0Position10Value);
            this.team1.Controls.Add(this.lbl0Position10);
            this.team1.Controls.Add(this.lbl0Position7Value);
            this.team1.Controls.Add(this.lbl0Position9Value);
            this.team1.Controls.Add(this.lbl0Position9);
            this.team1.Controls.Add(this.lbl0Position7);
            this.team1.Controls.Add(this.lbl0Position2Flag);
            this.team1.Controls.Add(this.lbl0Position0Flag);
            this.team1.Controls.Add(this.lbl0Position4Value);
            this.team1.Controls.Add(this.lbl0Position5Value);
            this.team1.Controls.Add(this.lbl0Position6);
            this.team1.Controls.Add(this.lbl0Position2Value);
            this.team1.Controls.Add(this.lbl0Position1Value);
            this.team1.Controls.Add(this.panel5);
            this.team1.Controls.Add(this.panel4);
            this.team1.Controls.Add(this.lbl0Position5);
            this.team1.Controls.Add(this.lbl0Position4);
            this.team1.Controls.Add(this.lbl0Position8Value);
            this.team1.Controls.Add(this.lbl0Position0);
            this.team1.Controls.Add(this.lbl0Position3Value);
            this.team1.Controls.Add(this.lbl0Position3);
            this.team1.Controls.Add(this.lbl0Position8);
            this.team1.Controls.Add(this.lbl0Position1);
            this.team1.Controls.Add(this.lbl0Position2);
            this.team1.Controls.Add(this.lbl0Position11);
            this.team1.Controls.Add(this.lbl0Position0Value);
            this.team1.Controls.Add(this.lbl0TeamName);
            this.team1.Controls.Add(this.lbl0ScoutName);
            this.team1.Controls.Add(this.lbl0ModeValue);
            this.team1.Location = new System.Drawing.Point(6, 3);
            this.team1.Name = "team1";
            this.team1.Size = new System.Drawing.Size(330, 333);
            this.team1.TabIndex = 0;
            this.team1.Paint += new System.Windows.Forms.PaintEventHandler(this.team1_Paint);
            // 
            // lbl0Position6Value
            // 
            this.lbl0Position6Value.AutoSize = true;
            this.lbl0Position6Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbl0Position6Value.ForeColor = System.Drawing.Color.Yellow;
            this.lbl0Position6Value.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lbl0Position6Value.Location = new System.Drawing.Point(263, 159);
            this.lbl0Position6Value.Name = "lbl0Position6Value";
            this.lbl0Position6Value.Size = new System.Drawing.Size(32, 24);
            this.lbl0Position6Value.TabIndex = 345;
            this.lbl0Position6Value.Text = "$$";
            this.lbl0Position6Value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl0Position10Value
            // 
            this.lbl0Position10Value.AutoSize = true;
            this.lbl0Position10Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbl0Position10Value.ForeColor = System.Drawing.Color.Yellow;
            this.lbl0Position10Value.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lbl0Position10Value.Location = new System.Drawing.Point(246, 211);
            this.lbl0Position10Value.Name = "lbl0Position10Value";
            this.lbl0Position10Value.Size = new System.Drawing.Size(21, 24);
            this.lbl0Position10Value.TabIndex = 344;
            this.lbl0Position10Value.Text = "0";
            this.lbl0Position10Value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl0Position10
            // 
            this.lbl0Position10.AutoSize = true;
            this.lbl0Position10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl0Position10.ForeColor = System.Drawing.Color.White;
            this.lbl0Position10.Location = new System.Drawing.Point(202, 210);
            this.lbl0Position10.Name = "lbl0Position10";
            this.lbl0Position10.Size = new System.Drawing.Size(52, 24);
            this.lbl0Position10.TabIndex = 343;
            this.lbl0Position10.Text = "Avo:";
            // 
            // lbl0Position7Value
            // 
            this.lbl0Position7Value.AutoSize = true;
            this.lbl0Position7Value.BackColor = System.Drawing.Color.Red;
            this.lbl0Position7Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbl0Position7Value.ForeColor = System.Drawing.Color.Red;
            this.lbl0Position7Value.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lbl0Position7Value.Location = new System.Drawing.Point(97, 184);
            this.lbl0Position7Value.Name = "lbl0Position7Value";
            this.lbl0Position7Value.Size = new System.Drawing.Size(16, 24);
            this.lbl0Position7Value.TabIndex = 342;
            this.lbl0Position7Value.Text = ".";
            this.lbl0Position7Value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl0Position9Value
            // 
            this.lbl0Position9Value.AutoSize = true;
            this.lbl0Position9Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbl0Position9Value.ForeColor = System.Drawing.Color.Yellow;
            this.lbl0Position9Value.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lbl0Position9Value.Location = new System.Drawing.Point(68, 213);
            this.lbl0Position9Value.Name = "lbl0Position9Value";
            this.lbl0Position9Value.Size = new System.Drawing.Size(21, 24);
            this.lbl0Position9Value.TabIndex = 341;
            this.lbl0Position9Value.Text = "#";
            this.lbl0Position9Value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl0Position9Value.Click += new System.EventHandler(this.label9_Click);
            // 
            // lbl0Position9
            // 
            this.lbl0Position9.AutoSize = true;
            this.lbl0Position9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl0Position9.ForeColor = System.Drawing.Color.White;
            this.lbl0Position9.Location = new System.Drawing.Point(3, 213);
            this.lbl0Position9.Name = "lbl0Position9";
            this.lbl0Position9.Size = new System.Drawing.Size(59, 24);
            this.lbl0Position9.TabIndex = 340;
            this.lbl0Position9.Text = "Mics:";
            // 
            // lbl0Position7
            // 
            this.lbl0Position7.AutoSize = true;
            this.lbl0Position7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl0Position7.ForeColor = System.Drawing.Color.White;
            this.lbl0Position7.Location = new System.Drawing.Point(2, 184);
            this.lbl0Position7.Name = "lbl0Position7";
            this.lbl0Position7.Size = new System.Drawing.Size(73, 24);
            this.lbl0Position7.TabIndex = 339;
            this.lbl0Position7.Text = "Spotlit:";
            this.lbl0Position7.Click += new System.EventHandler(this.lbl0Position7_Click);
            // 
            // lbl0Position2Flag
            // 
            this.lbl0Position2Flag.AutoSize = true;
            this.lbl0Position2Flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl0Position2Flag.ForeColor = System.Drawing.Color.White;
            this.lbl0Position2Flag.Location = new System.Drawing.Point(154, 87);
            this.lbl0Position2Flag.Name = "lbl0Position2Flag";
            this.lbl0Position2Flag.Size = new System.Drawing.Size(27, 24);
            this.lbl0Position2Flag.TabIndex = 338;
            this.lbl0Position2Flag.Text = "M";
            this.lbl0Position2Flag.Click += new System.EventHandler(this.label5_Click);
            // 
            // lbl0Position0Flag
            // 
            this.lbl0Position0Flag.AutoSize = true;
            this.lbl0Position0Flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl0Position0Flag.ForeColor = System.Drawing.Color.White;
            this.lbl0Position0Flag.Location = new System.Drawing.Point(154, 50);
            this.lbl0Position0Flag.Name = "lbl0Position0Flag";
            this.lbl0Position0Flag.Size = new System.Drawing.Size(24, 24);
            this.lbl0Position0Flag.TabIndex = 337;
            this.lbl0Position0Flag.Text = "D";
            // 
            // lbl0Position4Value
            // 
            this.lbl0Position4Value.AutoSize = true;
            this.lbl0Position4Value.BackColor = System.Drawing.Color.Red;
            this.lbl0Position4Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbl0Position4Value.ForeColor = System.Drawing.Color.Red;
            this.lbl0Position4Value.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lbl0Position4Value.Location = new System.Drawing.Point(274, 130);
            this.lbl0Position4Value.Name = "lbl0Position4Value";
            this.lbl0Position4Value.Size = new System.Drawing.Size(16, 24);
            this.lbl0Position4Value.TabIndex = 336;
            this.lbl0Position4Value.Text = ".";
            this.lbl0Position4Value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl0Position5Value
            // 
            this.lbl0Position5Value.AutoSize = true;
            this.lbl0Position5Value.BackColor = System.Drawing.Color.Red;
            this.lbl0Position5Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbl0Position5Value.ForeColor = System.Drawing.Color.Red;
            this.lbl0Position5Value.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lbl0Position5Value.Location = new System.Drawing.Point(97, 157);
            this.lbl0Position5Value.Name = "lbl0Position5Value";
            this.lbl0Position5Value.Size = new System.Drawing.Size(16, 24);
            this.lbl0Position5Value.TabIndex = 334;
            this.lbl0Position5Value.Text = ".";
            this.lbl0Position5Value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl0Position5Value.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // lbl0Position6
            // 
            this.lbl0Position6.AutoSize = true;
            this.lbl0Position6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl0Position6.ForeColor = System.Drawing.Color.White;
            this.lbl0Position6.Location = new System.Drawing.Point(202, 158);
            this.lbl0Position6.Name = "lbl0Position6";
            this.lbl0Position6.Size = new System.Drawing.Size(57, 24);
            this.lbl0Position6.TabIndex = 331;
            this.lbl0Position6.Text = "Strat:";
            this.lbl0Position6.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // lbl0Position2Value
            // 
            this.lbl0Position2Value.AutoSize = true;
            this.lbl0Position2Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbl0Position2Value.ForeColor = System.Drawing.Color.Yellow;
            this.lbl0Position2Value.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lbl0Position2Value.Location = new System.Drawing.Point(54, 87);
            this.lbl0Position2Value.Name = "lbl0Position2Value";
            this.lbl0Position2Value.Size = new System.Drawing.Size(32, 24);
            this.lbl0Position2Value.TabIndex = 330;
            this.lbl0Position2Value.Text = "$$";
            this.lbl0Position2Value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl0Position1Value
            // 
            this.lbl0Position1Value.AutoSize = true;
            this.lbl0Position1Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbl0Position1Value.ForeColor = System.Drawing.Color.Yellow;
            this.lbl0Position1Value.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lbl0Position1Value.Location = new System.Drawing.Point(243, 50);
            this.lbl0Position1Value.Name = "lbl0Position1Value";
            this.lbl0Position1Value.Size = new System.Drawing.Size(32, 24);
            this.lbl0Position1Value.TabIndex = 329;
            this.lbl0Position1Value.Text = "$$";
            this.lbl0Position1Value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Red;
            this.panel5.Controls.Add(this.label4);
            this.panel5.Location = new System.Drawing.Point(0, 34);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(330, 13);
            this.panel5.TabIndex = 279;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label4.Location = new System.Drawing.Point(418, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 26);
            this.label4.TabIndex = 277;
            this.label4.Text = "00";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Red;
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(0, 246);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(330, 11);
            this.panel4.TabIndex = 279;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label3.Location = new System.Drawing.Point(418, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 26);
            this.label3.TabIndex = 277;
            this.label3.Text = "00";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl0Position5
            // 
            this.lbl0Position5.AutoSize = true;
            this.lbl0Position5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl0Position5.ForeColor = System.Drawing.Color.White;
            this.lbl0Position5.Location = new System.Drawing.Point(2, 158);
            this.lbl0Position5.Name = "lbl0Position5";
            this.lbl0Position5.Size = new System.Drawing.Size(99, 24);
            this.lbl0Position5.TabIndex = 328;
            this.lbl0Position5.Text = "HP Amp: ";
            this.lbl0Position5.Click += new System.EventHandler(this.lbl0Position9_Click);
            // 
            // lbl0Position4
            // 
            this.lbl0Position4.AutoSize = true;
            this.lbl0Position4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl0Position4.ForeColor = System.Drawing.Color.White;
            this.lbl0Position4.Location = new System.Drawing.Point(202, 130);
            this.lbl0Position4.Name = "lbl0Position4";
            this.lbl0Position4.Size = new System.Drawing.Size(72, 24);
            this.lbl0Position4.TabIndex = 322;
            this.lbl0Position4.Text = "Leave:";
            // 
            // lbl0Position8Value
            // 
            this.lbl0Position8Value.AutoSize = true;
            this.lbl0Position8Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbl0Position8Value.ForeColor = System.Drawing.Color.Yellow;
            this.lbl0Position8Value.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lbl0Position8Value.Location = new System.Drawing.Point(246, 185);
            this.lbl0Position8Value.Name = "lbl0Position8Value";
            this.lbl0Position8Value.Size = new System.Drawing.Size(21, 24);
            this.lbl0Position8Value.TabIndex = 324;
            this.lbl0Position8Value.Text = "0";
            this.lbl0Position8Value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl0Position0
            // 
            this.lbl0Position0.AutoSize = true;
            this.lbl0Position0.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl0Position0.ForeColor = System.Drawing.Color.White;
            this.lbl0Position0.Location = new System.Drawing.Point(2, 50);
            this.lbl0Position0.Name = "lbl0Position0";
            this.lbl0Position0.Size = new System.Drawing.Size(53, 24);
            this.lbl0Position0.TabIndex = 322;
            this.lbl0Position0.Text = "Acq:";
            this.lbl0Position0.Click += new System.EventHandler(this.label23_Click);
            // 
            // lbl0Position3Value
            // 
            this.lbl0Position3Value.AutoSize = true;
            this.lbl0Position3Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbl0Position3Value.ForeColor = System.Drawing.Color.Yellow;
            this.lbl0Position3Value.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lbl0Position3Value.Location = new System.Drawing.Point(78, 131);
            this.lbl0Position3Value.Name = "lbl0Position3Value";
            this.lbl0Position3Value.Size = new System.Drawing.Size(21, 24);
            this.lbl0Position3Value.TabIndex = 317;
            this.lbl0Position3Value.Text = "#";
            this.lbl0Position3Value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl0Position3Value.Click += new System.EventHandler(this.lbl0Position8Value1_Click);
            // 
            // lbl0Position3
            // 
            this.lbl0Position3.AutoSize = true;
            this.lbl0Position3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl0Position3.ForeColor = System.Drawing.Color.White;
            this.lbl0Position3.Location = new System.Drawing.Point(2, 130);
            this.lbl0Position3.Name = "lbl0Position3";
            this.lbl0Position3.Size = new System.Drawing.Size(70, 24);
            this.lbl0Position3.TabIndex = 321;
            this.lbl0Position3.Text = "Setup:";
            // 
            // lbl0Position8
            // 
            this.lbl0Position8.AutoSize = true;
            this.lbl0Position8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl0Position8.ForeColor = System.Drawing.Color.White;
            this.lbl0Position8.Location = new System.Drawing.Point(202, 184);
            this.lbl0Position8.Name = "lbl0Position8";
            this.lbl0Position8.Size = new System.Drawing.Size(47, 24);
            this.lbl0Position8.TabIndex = 266;
            this.lbl0Position8.Text = "Def:";
            this.lbl0Position8.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbl0Position1
            // 
            this.lbl0Position1.AutoSize = true;
            this.lbl0Position1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl0Position1.ForeColor = System.Drawing.Color.White;
            this.lbl0Position1.Location = new System.Drawing.Point(188, 50);
            this.lbl0Position1.Name = "lbl0Position1";
            this.lbl0Position1.Size = new System.Drawing.Size(56, 24);
            this.lbl0Position1.TabIndex = 327;
            this.lbl0Position1.Text = "Orig:";
            this.lbl0Position1.Click += new System.EventHandler(this.label28_Click_1);
            // 
            // lbl0Position2
            // 
            this.lbl0Position2.AutoSize = true;
            this.lbl0Position2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl0Position2.ForeColor = System.Drawing.Color.White;
            this.lbl0Position2.Location = new System.Drawing.Point(2, 87);
            this.lbl0Position2.Name = "lbl0Position2";
            this.lbl0Position2.Size = new System.Drawing.Size(47, 24);
            this.lbl0Position2.TabIndex = 318;
            this.lbl0Position2.Text = "Del:";
            this.lbl0Position2.Click += new System.EventHandler(this.label19_Click_1);
            // 
            // lbl0Position11
            // 
            this.lbl0Position11.AutoSize = true;
            this.lbl0Position11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl0Position11.ForeColor = System.Drawing.Color.White;
            this.lbl0Position11.Location = new System.Drawing.Point(3, 261);
            this.lbl0Position11.Name = "lbl0Position11";
            this.lbl0Position11.Size = new System.Drawing.Size(125, 24);
            this.lbl0Position11.TabIndex = 291;
            this.lbl0Position11.Text = "Match Event";
            this.lbl0Position11.Click += new System.EventHandler(this.lbl0Position5_Click);
            // 
            // lbl0Position0Value
            // 
            this.lbl0Position0Value.AutoSize = true;
            this.lbl0Position0Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbl0Position0Value.ForeColor = System.Drawing.Color.Yellow;
            this.lbl0Position0Value.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lbl0Position0Value.Location = new System.Drawing.Point(54, 50);
            this.lbl0Position0Value.Name = "lbl0Position0Value";
            this.lbl0Position0Value.Size = new System.Drawing.Size(32, 24);
            this.lbl0Position0Value.TabIndex = 274;
            this.lbl0Position0Value.Text = "$$";
            this.lbl0Position0Value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl0Position0Value.Click += new System.EventHandler(this.label6_Click);
            // 
            // lbl0TeamName
            // 
            this.lbl0TeamName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl0TeamName.BackColor = System.Drawing.Color.Black;
            this.lbl0TeamName.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl0TeamName.ForeColor = System.Drawing.Color.Goldenrod;
            this.lbl0TeamName.Location = new System.Drawing.Point(168, 291);
            this.lbl0TeamName.Name = "lbl0TeamName";
            this.lbl0TeamName.Size = new System.Drawing.Size(159, 37);
            this.lbl0TeamName.TabIndex = 248;
            this.lbl0TeamName.Text = "Team 0";
            this.lbl0TeamName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl0TeamName.Click += new System.EventHandler(this.lbl1TeamName_Click);
            // 
            // lbl0ScoutName
            // 
            this.lbl0ScoutName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl0ScoutName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl0ScoutName.ForeColor = System.Drawing.Color.Goldenrod;
            this.lbl0ScoutName.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lbl0ScoutName.Location = new System.Drawing.Point(4, 301);
            this.lbl0ScoutName.Name = "lbl0ScoutName";
            this.lbl0ScoutName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl0ScoutName.Size = new System.Drawing.Size(158, 27);
            this.lbl0ScoutName.TabIndex = 247;
            this.lbl0ScoutName.Text = "Select Name";
            this.lbl0ScoutName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl0ScoutName.Click += new System.EventHandler(this.lbl0ScoutName_Click);
            // 
            // lbl0ModeValue
            // 
            this.lbl0ModeValue.AutoSize = true;
            this.lbl0ModeValue.BackColor = System.Drawing.Color.Black;
            this.lbl0ModeValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.lbl0ModeValue.ForeColor = System.Drawing.Color.LimeGreen;
            this.lbl0ModeValue.Location = new System.Drawing.Point(1, 3);
            this.lbl0ModeValue.Name = "lbl0ModeValue";
            this.lbl0ModeValue.Size = new System.Drawing.Size(67, 29);
            this.lbl0ModeValue.TabIndex = 2;
            this.lbl0ModeValue.Text = "Auto:";
            this.lbl0ModeValue.Click += new System.EventHandler(this.lbl1ModeValue_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Red;
            this.panel3.Controls.Add(this.label28);
            this.panel3.Location = new System.Drawing.Point(6, 120);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(330, 11);
            this.panel3.TabIndex = 278;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint_1);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.Red;
            this.label28.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label28.Location = new System.Drawing.Point(418, 214);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(38, 26);
            this.label28.TabIndex = 277;
            this.label28.Text = "00";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.team1);
            this.panel1.Controls.Add(this.lbl0Position6Value2);
            this.panel1.Location = new System.Drawing.Point(2, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 339);
            this.panel1.TabIndex = 246;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkBlue;
            this.panel2.Location = new System.Drawing.Point(1, 379);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1017, 343);
            this.panel2.TabIndex = 260;
            // 
            // MainScreen
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1376, 787);
            this.Controls.Add(this.btnUpdateDB);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cbxEndMatch);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelMatch);
            this.Controls.Add(this.lblkey);
            this.Controls.Add(this.btnInitialDBLoad);
            this.Controls.Add(this.pictureBox14);
            this.Controls.Add(this.comboBoxSelectRegional);
            this.Controls.Add(this.btnNextMatch);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblMatch);
            this.Controls.Add(this.lstLog);
            this.Controls.Add(this.btnPreviousMatch);
            this.Controls.Add(this.btnpopulateForEvent);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainScreen";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DynoScoutScoutingSystemForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.eventSummaryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventSummaryBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.team1.ResumeLayout(false);
            this.team1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //API Start
        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.Timer timerJoysticks;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnpopulateForEvent;
        private System.Windows.Forms.Button btnPreviousMatch;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnInitialDBLoad;
        private System.Windows.Forms.Button btnNextMatch;
        private System.Windows.Forms.ComboBox comboBoxSelectRegional;
        private System.Windows.Forms.BindingSource eventSummaryBindingSource;
        private System.Windows.Forms.BindingSource eventSummaryBindingSource1;
        private System.Windows.Forms.Label lblMatch;
        private System.Windows.Forms.Label lblkey;
        private System.Windows.Forms.Label labelMatch;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.CheckBox cbxEndMatch;
        private System.Windows.Forms.PictureBox pictureBox14;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnUpdateDB;
        private System.Windows.Forms.Label lbl0Position6Value2;
        private System.Windows.Forms.Panel team1;
        private System.Windows.Forms.Label lbl0Position2Value;
        private System.Windows.Forms.Label lbl0Position1Value;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl0Position5;
        private System.Windows.Forms.Label lbl0Position4;
        private System.Windows.Forms.Label lbl0Position0;
        private System.Windows.Forms.Label lbl0Position3Value;
        private System.Windows.Forms.Label lbl0Position3;
        private System.Windows.Forms.Label lbl0Position1;
        private System.Windows.Forms.Label lbl0Position2;
        private System.Windows.Forms.Label lbl0Position11;
        private System.Windows.Forms.Label lbl0Position0Value;
        private System.Windows.Forms.Label lbl0TeamName;
        private System.Windows.Forms.Label lbl0ScoutName;
        private System.Windows.Forms.Label lbl0ModeValue;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl0Position4Value;
        private System.Windows.Forms.Label lbl0Position2Flag;
        private System.Windows.Forms.Label lbl0Position0Flag;
        private System.Windows.Forms.Label lbl0Position6;
        private System.Windows.Forms.Label lbl0Position8Value;
        private System.Windows.Forms.Label lbl0Position8;
        private System.Windows.Forms.Label lbl0Position5Value;
        private System.Windows.Forms.Label lbl0Position7Value;
        private System.Windows.Forms.Label lbl0Position9Value;
        private System.Windows.Forms.Label lbl0Position9;
        private System.Windows.Forms.Label lbl0Position7;
        private System.Windows.Forms.Label lbl0Position10Value;
        private System.Windows.Forms.Label lbl0Position10;
        private System.Windows.Forms.Label lbl0Position6Value;
    }
}
