namespace PCComm
{
    partial class frmMain
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
            this.cboData = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdClose = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdoByte = new System.Windows.Forms.RadioButton();
            this.rdoText = new System.Windows.Forms.RadioButton();
            this.rdoHex = new System.Windows.Forms.RadioButton();
            this.cboStop = new System.Windows.Forms.ComboBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.rtbDisplay = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboParity = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.cboBaud = new System.Windows.Forms.ComboBox();
            this.cboPort = new System.Windows.Forms.ComboBox();
            this.cmdOpen = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.button_direction = new System.Windows.Forms.Button();
            this.button_slow = new System.Windows.Forms.Button();
            this.button_medium = new System.Windows.Forms.Button();
            this.button_fast = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxRPM = new System.Windows.Forms.TextBox();
            this.picSats = new System.Windows.Forms.PictureBox();
            this.listSatellites = new System.Windows.Forms.ListView();
            this.IdColumn = new System.Windows.Forms.ColumnHeader();
            this.ElevationColumn = new System.Windows.Forms.ColumnHeader();
            this.AzimuthColumn = new System.Windows.Forms.ColumnHeader();
            this.UsedColumn = new System.Windows.Forms.ColumnHeader();
            this.LocalDateTime = new System.Windows.Forms.Label();
            this.labelTimeLocal = new System.Windows.Forms.Label();
            this.DateZulu = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelDataValid = new System.Windows.Forms.Label();
            this.DataValid = new System.Windows.Forms.Label();
            this.labelVDOP = new System.Windows.Forms.Label();
            this.VDOP = new System.Windows.Forms.Label();
            this.labelHDOP = new System.Windows.Forms.Label();
            this.HDOP = new System.Windows.Forms.Label();
            this.labelPDOP = new System.Windows.Forms.Label();
            this.PDOP = new System.Windows.Forms.Label();
            this.labelFixMode = new System.Windows.Forms.Label();
            this.FixMode = new System.Windows.Forms.Label();
            this.listGPSQuality = new System.Windows.Forms.ListBox();
            this.labelLatitude = new System.Windows.Forms.Label();
            this.Latitude = new System.Windows.Forms.Label();
            this.Longitude = new System.Windows.Forms.Label();
            this.labelLongitude = new System.Windows.Forms.Label();
            this.Altitude = new System.Windows.Forms.Label();
            this.labelAltitude = new System.Windows.Forms.Label();
            this.TineZulu = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.NMEAText = new System.Windows.Forms.TextBox();
            this.dumpRawDataCheck = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.COMlistBox = new System.Windows.Forms.ListBox();
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
            this.groupBox3.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSats)).BeginInit();
            this.SuspendLayout();
            // 
            // cboData
            // 
            this.cboData.FormattingEnabled = true;
            this.cboData.Items.AddRange(new object[] {
            "7",
            "8",
            "9"});
            this.cboData.Location = new System.Drawing.Point(9, 195);
            this.cboData.Name = "cboData";
            this.cboData.Size = new System.Drawing.Size(76, 21);
            this.cboData.TabIndex = 14;
            this.cboData.SelectedIndexChanged += new System.EventHandler(this.cboData_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Stop Bits";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Data Bits";
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(231, 314);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 23);
            this.cmdClose.TabIndex = 5;
            this.cmdClose.Text = "Close Port";
            this.cmdClose.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdoByte);
            this.groupBox3.Controls.Add(this.rdoText);
            this.groupBox3.Controls.Add(this.rdoHex);
            this.groupBox3.Location = new System.Drawing.Point(231, 202);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(100, 81);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Mode";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // rdoByte
            // 
            this.rdoByte.AutoSize = true;
            this.rdoByte.Location = new System.Drawing.Point(6, 58);
            this.rdoByte.Name = "rdoByte";
            this.rdoByte.Size = new System.Drawing.Size(46, 17);
            this.rdoByte.TabIndex = 2;
            this.rdoByte.TabStop = true;
            this.rdoByte.Text = "Byte";
            this.rdoByte.UseVisualStyleBackColor = true;
            // 
            // rdoText
            // 
            this.rdoText.AutoSize = true;
            this.rdoText.Location = new System.Drawing.Point(6, 38);
            this.rdoText.Name = "rdoText";
            this.rdoText.Size = new System.Drawing.Size(46, 17);
            this.rdoText.TabIndex = 1;
            this.rdoText.TabStop = true;
            this.rdoText.Text = "Text";
            this.rdoText.UseVisualStyleBackColor = true;
            // 
            // rdoHex
            // 
            this.rdoHex.AutoSize = true;
            this.rdoHex.Location = new System.Drawing.Point(6, 16);
            this.rdoHex.Name = "rdoHex";
            this.rdoHex.Size = new System.Drawing.Size(44, 17);
            this.rdoHex.TabIndex = 0;
            this.rdoHex.TabStop = true;
            this.rdoHex.Text = "Hex";
            this.rdoHex.UseVisualStyleBackColor = true;
            this.rdoHex.CheckedChanged += new System.EventHandler(this.rdoHex_CheckedChanged);
            // 
            // cboStop
            // 
            this.cboStop.FormattingEnabled = true;
            this.cboStop.Location = new System.Drawing.Point(9, 155);
            this.cboStop.Name = "cboStop";
            this.cboStop.Size = new System.Drawing.Size(76, 21);
            this.cboStop.TabIndex = 13;
            this.cboStop.SelectedIndexChanged += new System.EventHandler(this.cboStop_SelectedIndexChanged);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.rtbDisplay);
            this.GroupBox1.ForeColor = System.Drawing.Color.Blue;
            this.GroupBox1.Location = new System.Drawing.Point(12, 12);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(421, 123);
            this.GroupBox1.TabIndex = 4;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Serial Port Communication";
            this.GroupBox1.Enter += new System.EventHandler(this.GroupBox1_Enter);
            // 
            // rtbDisplay
            // 
            this.rtbDisplay.Location = new System.Drawing.Point(10, 16);
            this.rtbDisplay.Name = "rtbDisplay";
            this.rtbDisplay.Size = new System.Drawing.Size(400, 96);
            this.rtbDisplay.TabIndex = 3;
            this.rtbDisplay.Text = "";
            this.rtbDisplay.TextChanged += new System.EventHandler(this.rtbDisplay_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cboStop);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cboParity);
            this.groupBox2.Controls.Add(this.Label1);
            this.groupBox2.Controls.Add(this.cboBaud);
            this.groupBox2.Controls.Add(this.cboPort);
            this.groupBox2.Controls.Add(this.cboData);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(337, 200);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(96, 221);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Parity";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Baud Rate";
            // 
            // cboParity
            // 
            this.cboParity.FormattingEnabled = true;
            this.cboParity.Location = new System.Drawing.Point(9, 114);
            this.cboParity.Name = "cboParity";
            this.cboParity.Size = new System.Drawing.Size(76, 21);
            this.cboParity.TabIndex = 12;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(6, 18);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(26, 13);
            this.Label1.TabIndex = 15;
            this.Label1.Text = "Port";
            // 
            // cboBaud
            // 
            this.cboBaud.FormattingEnabled = true;
            this.cboBaud.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "28800",
            "36000",
            "115000"});
            this.cboBaud.Location = new System.Drawing.Point(9, 74);
            this.cboBaud.Name = "cboBaud";
            this.cboBaud.Size = new System.Drawing.Size(76, 21);
            this.cboBaud.TabIndex = 11;
            this.cboBaud.SelectedIndexChanged += new System.EventHandler(this.cboBaud_SelectedIndexChanged);
            // 
            // cboPort
            // 
            this.cboPort.FormattingEnabled = true;
            this.cboPort.Location = new System.Drawing.Point(9, 34);
            this.cboPort.Name = "cboPort";
            this.cboPort.Size = new System.Drawing.Size(76, 21);
            this.cboPort.TabIndex = 10;
            this.cboPort.SelectedIndexChanged += new System.EventHandler(this.cboPort_SelectedIndexChanged);
            // 
            // cmdOpen
            // 
            this.cmdOpen.Location = new System.Drawing.Point(231, 289);
            this.cmdOpen.Name = "cmdOpen";
            this.cmdOpen.Size = new System.Drawing.Size(100, 23);
            this.cmdOpen.TabIndex = 8;
            this.cmdOpen.Text = "Open Port";
            this.cmdOpen.UseVisualStyleBackColor = true;
            this.cmdOpen.Click += new System.EventHandler(this.cmdOpen_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(74, 274);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(111, 20);
            this.textBox3.TabIndex = 13;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(97, 421);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(68, 20);
            this.textBox5.TabIndex = 15;
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(346, 427);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(78, 20);
            this.textBox6.TabIndex = 17;
            this.textBox6.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lime;
            this.panel1.Location = new System.Drawing.Point(74, 213);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(100, 42);
            this.panel1.TabIndex = 6;
            this.panel1.Visible = false;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 152);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Code";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(118, 152);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Port Value";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(224, 152);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Message";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(330, 152);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "ReceivedByte";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(12, 168);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(100, 20);
            this.textBox9.TabIndex = 27;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(121, 168);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(100, 20);
            this.textBox10.TabIndex = 28;
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(227, 168);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(100, 20);
            this.textBox11.TabIndex = 29;
            this.textBox11.TextChanged += new System.EventHandler(this.textBox11_TextChanged);
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(332, 168);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(100, 20);
            this.textBox12.TabIndex = 30;
            // 
            // button_direction
            // 
            this.button_direction.Location = new System.Drawing.Point(90, 302);
            this.button_direction.Name = "button_direction";
            this.button_direction.Size = new System.Drawing.Size(75, 46);
            this.button_direction.TabIndex = 31;
            this.button_direction.Text = "Direction";
            this.button_direction.UseVisualStyleBackColor = true;
            this.button_direction.Click += new System.EventHandler(this.button_direction_Click);
            // 
            // button_slow
            // 
            this.button_slow.Location = new System.Drawing.Point(12, 359);
            this.button_slow.Name = "button_slow";
            this.button_slow.Size = new System.Drawing.Size(72, 52);
            this.button_slow.TabIndex = 33;
            this.button_slow.Text = "Slow";
            this.button_slow.UseVisualStyleBackColor = true;
            this.button_slow.Click += new System.EventHandler(this.button_slow_Click);
            // 
            // button_medium
            // 
            this.button_medium.Location = new System.Drawing.Point(90, 359);
            this.button_medium.Name = "button_medium";
            this.button_medium.Size = new System.Drawing.Size(75, 52);
            this.button_medium.TabIndex = 34;
            this.button_medium.Text = "Medium";
            this.button_medium.UseVisualStyleBackColor = true;
            this.button_medium.Click += new System.EventHandler(this.button_medium_Click);
            // 
            // button_fast
            // 
            this.button_fast.Location = new System.Drawing.Point(171, 359);
            this.button_fast.Name = "button_fast";
            this.button_fast.Size = new System.Drawing.Size(72, 52);
            this.button_fast.TabIndex = 35;
            this.button_fast.Text = "Fast";
            this.button_fast.UseVisualStyleBackColor = true;
            this.button_fast.Click += new System.EventHandler(this.button_fast_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(344, 453);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "Run Time";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // textBoxRPM
            // 
            this.textBoxRPM.Location = new System.Drawing.Point(231, 427);
            this.textBoxRPM.Name = "textBoxRPM";
            this.textBoxRPM.Size = new System.Drawing.Size(100, 20);
            this.textBoxRPM.TabIndex = 37;
            this.textBoxRPM.TextChanged += new System.EventHandler(this.textBoxRPM_TextChanged);
            // 
            // picSats
            // 
            this.picSats.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picSats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.picSats.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picSats.Location = new System.Drawing.Point(456, 15);
            this.picSats.Name = "picSats";
            this.picSats.Size = new System.Drawing.Size(181, 205);
            this.picSats.TabIndex = 38;
            this.picSats.TabStop = false;
            // 
            // listSatellites
            // 
            this.listSatellites.AllowColumnReorder = true;
            this.listSatellites.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listSatellites.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IdColumn,
            this.ElevationColumn,
            this.AzimuthColumn,
            this.UsedColumn});
            this.listSatellites.FullRowSelect = true;
            this.listSatellites.Location = new System.Drawing.Point(655, 15);
            this.listSatellites.Name = "listSatellites";
            this.listSatellites.Size = new System.Drawing.Size(248, 205);
            this.listSatellites.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listSatellites.TabIndex = 39;
            this.listSatellites.UseCompatibleStateImageBehavior = false;
            this.listSatellites.View = System.Windows.Forms.View.Details;
            // 
            // IdColumn
            // 
            this.IdColumn.Text = "Satellite Id";
            this.IdColumn.Width = 81;
            // 
            // ElevationColumn
            // 
            this.ElevationColumn.Text = "Elevation";
            this.ElevationColumn.Width = 52;
            // 
            // AzimuthColumn
            // 
            this.AzimuthColumn.Text = "Azimuth";
            this.AzimuthColumn.Width = 51;
            // 
            // UsedColumn
            // 
            this.UsedColumn.Text = "In-use";
            this.UsedColumn.Width = 45;
            // 
            // LocalDateTime
            // 
            this.LocalDateTime.Location = new System.Drawing.Point(264, 527);
            this.LocalDateTime.Name = "LocalDateTime";
            this.LocalDateTime.Size = new System.Drawing.Size(116, 24);
            this.LocalDateTime.TabIndex = 61;
            this.LocalDateTime.Text = "Local DateTime:";
            this.LocalDateTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelTimeLocal
            // 
            this.labelTimeLocal.AutoSize = true;
            this.labelTimeLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimeLocal.Location = new System.Drawing.Point(389, 527);
            this.labelTimeLocal.Name = "labelTimeLocal";
            this.labelTimeLocal.Size = new System.Drawing.Size(30, 13);
            this.labelTimeLocal.TabIndex = 62;
            this.labelTimeLocal.Text = "N/A";
            // 
            // DateZulu
            // 
            this.DateZulu.Location = new System.Drawing.Point(308, 503);
            this.DateZulu.Name = "DateZulu";
            this.DateZulu.Size = new System.Drawing.Size(72, 24);
            this.DateZulu.TabIndex = 59;
            this.DateZulu.Text = "Date (Zulu):";
            this.DateZulu.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelDate
            // 
            this.labelDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDate.Location = new System.Drawing.Point(389, 503);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(120, 24);
            this.labelDate.TabIndex = 60;
            this.labelDate.Text = "N/A";
            // 
            // labelDataValid
            // 
            this.labelDataValid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDataValid.Location = new System.Drawing.Point(124, 651);
            this.labelDataValid.Name = "labelDataValid";
            this.labelDataValid.Size = new System.Drawing.Size(184, 24);
            this.labelDataValid.TabIndex = 58;
            this.labelDataValid.Text = "N/A";
            // 
            // DataValid
            // 
            this.DataValid.AutoSize = true;
            this.DataValid.Location = new System.Drawing.Point(53, 651);
            this.DataValid.Name = "DataValid";
            this.DataValid.Size = new System.Drawing.Size(59, 13);
            this.DataValid.TabIndex = 57;
            this.DataValid.Text = "Data Valid:";
            // 
            // labelVDOP
            // 
            this.labelVDOP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVDOP.Location = new System.Drawing.Point(124, 627);
            this.labelVDOP.Name = "labelVDOP";
            this.labelVDOP.Size = new System.Drawing.Size(184, 24);
            this.labelVDOP.TabIndex = 56;
            this.labelVDOP.Text = "N/A";
            // 
            // VDOP
            // 
            this.VDOP.AutoSize = true;
            this.VDOP.Location = new System.Drawing.Point(72, 627);
            this.VDOP.Name = "VDOP";
            this.VDOP.Size = new System.Drawing.Size(40, 13);
            this.VDOP.TabIndex = 55;
            this.VDOP.Text = "VDOP:";
            // 
            // labelHDOP
            // 
            this.labelHDOP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHDOP.Location = new System.Drawing.Point(124, 602);
            this.labelHDOP.Name = "labelHDOP";
            this.labelHDOP.Size = new System.Drawing.Size(184, 24);
            this.labelHDOP.TabIndex = 54;
            this.labelHDOP.Text = "N/A";
            // 
            // HDOP
            // 
            this.HDOP.AutoSize = true;
            this.HDOP.Location = new System.Drawing.Point(72, 602);
            this.HDOP.Name = "HDOP";
            this.HDOP.Size = new System.Drawing.Size(41, 13);
            this.HDOP.TabIndex = 53;
            this.HDOP.Text = "HDOP:";
            // 
            // labelPDOP
            // 
            this.labelPDOP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPDOP.Location = new System.Drawing.Point(124, 575);
            this.labelPDOP.Name = "labelPDOP";
            this.labelPDOP.Size = new System.Drawing.Size(184, 24);
            this.labelPDOP.TabIndex = 52;
            this.labelPDOP.Text = "N/A";
            // 
            // PDOP
            // 
            this.PDOP.AutoSize = true;
            this.PDOP.Location = new System.Drawing.Point(72, 575);
            this.PDOP.Name = "PDOP";
            this.PDOP.Size = new System.Drawing.Size(40, 13);
            this.PDOP.TabIndex = 51;
            this.PDOP.Text = "PDOP:";
            // 
            // labelFixMode
            // 
            this.labelFixMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFixMode.Location = new System.Drawing.Point(124, 551);
            this.labelFixMode.Name = "labelFixMode";
            this.labelFixMode.Size = new System.Drawing.Size(184, 24);
            this.labelFixMode.TabIndex = 50;
            this.labelFixMode.Text = "N/A";
            // 
            // FixMode
            // 
            this.FixMode.AutoSize = true;
            this.FixMode.Location = new System.Drawing.Point(59, 551);
            this.FixMode.Name = "FixMode";
            this.FixMode.Size = new System.Drawing.Size(53, 13);
            this.FixMode.TabIndex = 49;
            this.FixMode.Text = "Fix Mode:";
            // 
            // listGPSQuality
            // 
            this.listGPSQuality.Enabled = false;
            this.listGPSQuality.FormattingEnabled = true;
            this.listGPSQuality.Items.AddRange(new object[] {
            "Fix Not Available",
            "GPS SPS Mode",
            "Differential, GPS SPS Mode, FixValid",
            "GPS PPSMode, Fix Valid"});
            this.listGPSQuality.Location = new System.Drawing.Point(309, 553);
            this.listGPSQuality.Name = "listGPSQuality";
            this.listGPSQuality.Size = new System.Drawing.Size(231, 17);
            this.listGPSQuality.TabIndex = 48;
            // 
            // labelLatitude
            // 
            this.labelLatitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLatitude.Location = new System.Drawing.Point(124, 479);
            this.labelLatitude.Name = "labelLatitude";
            this.labelLatitude.Size = new System.Drawing.Size(184, 24);
            this.labelLatitude.TabIndex = 44;
            this.labelLatitude.Text = "N/A";
            // 
            // Latitude
            // 
            this.Latitude.AutoSize = true;
            this.Latitude.Location = new System.Drawing.Point(61, 479);
            this.Latitude.Name = "Latitude";
            this.Latitude.Size = new System.Drawing.Size(51, 13);
            this.Latitude.TabIndex = 40;
            this.Latitude.Text = "Latitude: ";
            this.Latitude.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Longitude
            // 
            this.Longitude.AutoSize = true;
            this.Longitude.Location = new System.Drawing.Point(55, 503);
            this.Longitude.Name = "Longitude";
            this.Longitude.Size = new System.Drawing.Size(57, 13);
            this.Longitude.TabIndex = 42;
            this.Longitude.Text = "Longitude:";
            this.Longitude.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelLongitude
            // 
            this.labelLongitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLongitude.Location = new System.Drawing.Point(124, 503);
            this.labelLongitude.Name = "labelLongitude";
            this.labelLongitude.Size = new System.Drawing.Size(184, 24);
            this.labelLongitude.TabIndex = 47;
            this.labelLongitude.Text = "N/A";
            // 
            // Altitude
            // 
            this.Altitude.AutoSize = true;
            this.Altitude.Location = new System.Drawing.Point(67, 527);
            this.Altitude.Name = "Altitude";
            this.Altitude.Size = new System.Drawing.Size(45, 13);
            this.Altitude.TabIndex = 41;
            this.Altitude.Text = "Altitude:";
            this.Altitude.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelAltitude
            // 
            this.labelAltitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAltitude.Location = new System.Drawing.Point(124, 527);
            this.labelAltitude.Name = "labelAltitude";
            this.labelAltitude.Size = new System.Drawing.Size(184, 24);
            this.labelAltitude.TabIndex = 46;
            this.labelAltitude.Text = "N/A";
            // 
            // TineZulu
            // 
            this.TineZulu.Location = new System.Drawing.Point(309, 479);
            this.TineZulu.Name = "TineZulu";
            this.TineZulu.Size = new System.Drawing.Size(72, 24);
            this.TineZulu.TabIndex = 43;
            this.TineZulu.Text = "Time (Zulu):";
            this.TineZulu.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelTime
            // 
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime.Location = new System.Drawing.Point(389, 479);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(120, 24);
            this.labelTime.TabIndex = 45;
            this.labelTime.Text = "N/A";
            // 
            // NMEAText
            // 
            this.NMEAText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.NMEAText.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NMEAText.Location = new System.Drawing.Point(456, 289);
            this.NMEAText.Multiline = true;
            this.NMEAText.Name = "NMEAText";
            this.NMEAText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.NMEAText.Size = new System.Drawing.Size(302, 173);
            this.NMEAText.TabIndex = 63;
            // 
            // dumpRawDataCheck
            // 
            this.dumpRawDataCheck.Location = new System.Drawing.Point(456, 240);
            this.dumpRawDataCheck.Name = "dumpRawDataCheck";
            this.dumpRawDataCheck.Size = new System.Drawing.Size(240, 24);
            this.dumpRawDataCheck.TabIndex = 64;
            this.dumpRawDataCheck.Text = "Output NMEA data";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(654, 490);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(116, 13);
            this.label13.TabIndex = 66;
            this.label13.Text = "Select a COM Port:";
            // 
            // COMlistBox
            // 
            this.COMlistBox.FormattingEnabled = true;
            this.COMlistBox.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8"});
            this.COMlistBox.Location = new System.Drawing.Point(655, 506);
            this.COMlistBox.Name = "COMlistBox";
            this.COMlistBox.Size = new System.Drawing.Size(136, 69);
            this.COMlistBox.TabIndex = 65;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(969, 702);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.COMlistBox);
            this.Controls.Add(this.dumpRawDataCheck);
            this.Controls.Add(this.NMEAText);
            this.Controls.Add(this.LocalDateTime);
            this.Controls.Add(this.labelTimeLocal);
            this.Controls.Add(this.DateZulu);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.labelDataValid);
            this.Controls.Add(this.DataValid);
            this.Controls.Add(this.labelVDOP);
            this.Controls.Add(this.VDOP);
            this.Controls.Add(this.labelHDOP);
            this.Controls.Add(this.HDOP);
            this.Controls.Add(this.labelPDOP);
            this.Controls.Add(this.PDOP);
            this.Controls.Add(this.labelFixMode);
            this.Controls.Add(this.FixMode);
            this.Controls.Add(this.listGPSQuality);
            this.Controls.Add(this.labelLatitude);
            this.Controls.Add(this.Latitude);
            this.Controls.Add(this.Longitude);
            this.Controls.Add(this.labelLongitude);
            this.Controls.Add(this.Altitude);
            this.Controls.Add(this.labelAltitude);
            this.Controls.Add(this.TineZulu);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.listSatellites);
            this.Controls.Add(this.picSats);
            this.Controls.Add(this.textBoxRPM);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button_fast);
            this.Controls.Add(this.button_medium);
            this.Controls.Add(this.button_slow);
            this.Controls.Add(this.button_direction);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cmdOpen);
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSats)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdoText;
        private System.Windows.Forms.RadioButton rdoHex;
        private System.Windows.Forms.ComboBox cboStop;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.RichTextBox rtbDisplay;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.ComboBox cboPort;
        private System.Windows.Forms.Button cmdOpen;
        private System.Windows.Forms.RadioButton rdoByte;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.Button button_direction;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboParity;
        private System.Windows.Forms.Button button_slow;
        private System.Windows.Forms.Button button_medium;
        private System.Windows.Forms.Button button_fast;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboBaud;
        private System.Windows.Forms.TextBox textBoxRPM;
        private System.Windows.Forms.PictureBox picSats;
        private System.Windows.Forms.ListView listSatellites;
        private System.Windows.Forms.ColumnHeader IdColumn;
        private System.Windows.Forms.ColumnHeader ElevationColumn;
        private System.Windows.Forms.ColumnHeader AzimuthColumn;
        private System.Windows.Forms.ColumnHeader UsedColumn;
        private System.Windows.Forms.Label LocalDateTime;
        private System.Windows.Forms.Label labelTimeLocal;
        private System.Windows.Forms.Label DateZulu;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelDataValid;
        private System.Windows.Forms.Label DataValid;
        private System.Windows.Forms.Label labelVDOP;
        private System.Windows.Forms.Label VDOP;
        private System.Windows.Forms.Label labelHDOP;
        private System.Windows.Forms.Label HDOP;
        private System.Windows.Forms.Label labelPDOP;
        private System.Windows.Forms.Label PDOP;
        private System.Windows.Forms.Label labelFixMode;
        private System.Windows.Forms.Label FixMode;
        private System.Windows.Forms.ListBox listGPSQuality;
        private System.Windows.Forms.Label labelLatitude;
        private System.Windows.Forms.Label Latitude;
        private System.Windows.Forms.Label Longitude;
        private System.Windows.Forms.Label labelLongitude;
        private System.Windows.Forms.Label Altitude;
        private System.Windows.Forms.Label labelAltitude;
        private System.Windows.Forms.Label TineZulu;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Timer timer2;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TextBox NMEAText;
        private System.Windows.Forms.CheckBox dumpRawDataCheck;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ListBox COMlistBox;
        private System.IO.Ports.SerialPort serialPort2;
       
    }
}