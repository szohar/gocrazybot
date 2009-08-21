using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO.Ports;

using GPS;

namespace GPSClient
{
	public class MainForm : System.Windows.Forms.Form
	{
		public NMEAProtocol protocol = new NMEAProtocol();
        public SerialPort port = new SerialPort();

		System.Text.Encoding encoding = System.Text.ASCIIEncoding.GetEncoding(1252);

        private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.Button connectButton;
		private System.Windows.Forms.ListBox COMlistBox;
		private System.Windows.Forms.Button disconnectButton;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.TextBox NMEAText;
        private System.Windows.Forms.CheckBox dumpRawDataCheck;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label labelLatitude;
		private System.Windows.Forms.Label labelLongitude;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label labelAltitude;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label labelTime;
		private System.Windows.Forms.ListBox listGPSQuality;
		private System.Windows.Forms.ColumnHeader IdColumn;
		private System.Windows.Forms.ColumnHeader ElevationColumn;
		private System.Windows.Forms.ColumnHeader AzimuthColumn;
		private System.Windows.Forms.ColumnHeader UsedColumn;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label labelSatellitesInView;
		private System.Windows.Forms.ListView listSatellites;
		private System.Windows.Forms.PictureBox picSats;
        private Label labelFixMode;
        private Label label5;
        private Label labelVDOP;
        private Label label12;
        private Label labelHDOP;
        private Label label10;
        private Label labelPDOP;
        private Label label8;
        private Label labelDataValid;
        private Label label9;
        private Label label7;
        private Label labelDate;
        private Label label11;
        private Label labelTimeLocal;
        private Label label13;
        private TabPage tabPage5;
        private SerialPort serialPort1;
		private System.ComponentModel.IContainer components;

		public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.picSats = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelSatellitesInView = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.listSatellites = new System.Windows.Forms.ListView();
            this.IdColumn = new System.Windows.Forms.ColumnHeader();
            this.ElevationColumn = new System.Windows.Forms.ColumnHeader();
            this.AzimuthColumn = new System.Windows.Forms.ColumnHeader();
            this.UsedColumn = new System.Windows.Forms.ColumnHeader();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.labelTimeLocal = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelDataValid = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelVDOP = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.labelHDOP = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.labelPDOP = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelFixMode = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.listGPSQuality = new System.Windows.Forms.ListBox();
            this.labelLatitude = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelLongitude = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelAltitude = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dumpRawDataCheck = new System.Windows.Forms.CheckBox();
            this.NMEAText = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.COMlistBox = new System.Windows.Forms.ListBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSats)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(700, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.picSats);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(692, 424);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Satellite Tracking";
            // 
            // picSats
            // 
            this.picSats.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picSats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.picSats.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picSats.Location = new System.Drawing.Point(10, 11);
            this.picSats.Name = "picSats";
            this.picSats.Size = new System.Drawing.Size(407, 401);
            this.picSats.TabIndex = 2;
            this.picSats.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.labelSatellitesInView);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.listSatellites);
            this.groupBox1.Location = new System.Drawing.Point(423, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 401);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Satellite Details";
            // 
            // labelSatellitesInView
            // 
            this.labelSatellitesInView.AutoSize = true;
            this.labelSatellitesInView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSatellitesInView.Location = new System.Drawing.Point(99, 24);
            this.labelSatellitesInView.Name = "labelSatellitesInView";
            this.labelSatellitesInView.Size = new System.Drawing.Size(14, 13);
            this.labelSatellitesInView.TabIndex = 3;
            this.labelSatellitesInView.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Satellites in View:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            this.listSatellites.Location = new System.Drawing.Point(6, 41);
            this.listSatellites.Name = "listSatellites";
            this.listSatellites.Size = new System.Drawing.Size(248, 354);
            this.listSatellites.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listSatellites.TabIndex = 0;
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
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.labelTimeLocal);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.labelDate);
            this.tabPage2.Controls.Add(this.labelDataValid);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.labelVDOP);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.labelHDOP);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.labelPDOP);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.labelFixMode);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.listGPSQuality);
            this.tabPage2.Controls.Add(this.labelLatitude);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.labelLongitude);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.labelAltitude);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.labelTime);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(692, 424);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Summary";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(284, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 24);
            this.label11.TabIndex = 15;
            this.label11.Text = "Local DateTime:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelTimeLocal
            // 
            this.labelTimeLocal.AutoSize = true;
            this.labelTimeLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimeLocal.Location = new System.Drawing.Point(409, 64);
            this.labelTimeLocal.Name = "labelTimeLocal";
            this.labelTimeLocal.Size = new System.Drawing.Size(30, 13);
            this.labelTimeLocal.TabIndex = 16;
            this.labelTimeLocal.Text = "N/A";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(328, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 24);
            this.label7.TabIndex = 13;
            this.label7.Text = "Date (Zulu):";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelDate
            // 
            this.labelDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDate.Location = new System.Drawing.Point(409, 40);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(120, 24);
            this.labelDate.TabIndex = 14;
            this.labelDate.Text = "N/A";
            // 
            // labelDataValid
            // 
            this.labelDataValid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDataValid.Location = new System.Drawing.Point(144, 188);
            this.labelDataValid.Name = "labelDataValid";
            this.labelDataValid.Size = new System.Drawing.Size(184, 24);
            this.labelDataValid.TabIndex = 12;
            this.labelDataValid.Text = "N/A";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(73, 188);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Data Valid:";
            // 
            // labelVDOP
            // 
            this.labelVDOP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVDOP.Location = new System.Drawing.Point(144, 164);
            this.labelVDOP.Name = "labelVDOP";
            this.labelVDOP.Size = new System.Drawing.Size(184, 24);
            this.labelVDOP.TabIndex = 10;
            this.labelVDOP.Text = "N/A";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(92, 164);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "VDOP:";
            // 
            // labelHDOP
            // 
            this.labelHDOP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHDOP.Location = new System.Drawing.Point(144, 139);
            this.labelHDOP.Name = "labelHDOP";
            this.labelHDOP.Size = new System.Drawing.Size(184, 24);
            this.labelHDOP.TabIndex = 8;
            this.labelHDOP.Text = "N/A";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(92, 139);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "HDOP:";
            // 
            // labelPDOP
            // 
            this.labelPDOP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPDOP.Location = new System.Drawing.Point(144, 112);
            this.labelPDOP.Name = "labelPDOP";
            this.labelPDOP.Size = new System.Drawing.Size(184, 24);
            this.labelPDOP.TabIndex = 6;
            this.labelPDOP.Text = "N/A";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(92, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "PDOP:";
            // 
            // labelFixMode
            // 
            this.labelFixMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFixMode.Location = new System.Drawing.Point(144, 88);
            this.labelFixMode.Name = "labelFixMode";
            this.labelFixMode.Size = new System.Drawing.Size(184, 24);
            this.labelFixMode.TabIndex = 4;
            this.labelFixMode.Text = "N/A";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(79, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Fix Mode:";
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
            this.listGPSQuality.Location = new System.Drawing.Point(329, 90);
            this.listGPSQuality.Name = "listGPSQuality";
            this.listGPSQuality.Size = new System.Drawing.Size(231, 17);
            this.listGPSQuality.TabIndex = 2;
            // 
            // labelLatitude
            // 
            this.labelLatitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLatitude.Location = new System.Drawing.Point(144, 16);
            this.labelLatitude.Name = "labelLatitude";
            this.labelLatitude.Size = new System.Drawing.Size(184, 24);
            this.labelLatitude.TabIndex = 1;
            this.labelLatitude.Text = "N/A";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Latitude: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Longitude:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelLongitude
            // 
            this.labelLongitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLongitude.Location = new System.Drawing.Point(144, 40);
            this.labelLongitude.Name = "labelLongitude";
            this.labelLongitude.Size = new System.Drawing.Size(184, 24);
            this.labelLongitude.TabIndex = 1;
            this.labelLongitude.Text = "N/A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(87, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Altitude:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelAltitude
            // 
            this.labelAltitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAltitude.Location = new System.Drawing.Point(144, 64);
            this.labelAltitude.Name = "labelAltitude";
            this.labelAltitude.Size = new System.Drawing.Size(184, 24);
            this.labelAltitude.TabIndex = 1;
            this.labelAltitude.Text = "N/A";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(329, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Time (Zulu):";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelTime
            // 
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime.Location = new System.Drawing.Point(409, 16);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(120, 24);
            this.labelTime.TabIndex = 1;
            this.labelTime.Text = "N/A";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dumpRawDataCheck);
            this.tabPage1.Controls.Add(this.NMEAText);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(692, 424);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Raw NMEA Data";
            // 
            // dumpRawDataCheck
            // 
            this.dumpRawDataCheck.Location = new System.Drawing.Point(16, 8);
            this.dumpRawDataCheck.Name = "dumpRawDataCheck";
            this.dumpRawDataCheck.Size = new System.Drawing.Size(240, 24);
            this.dumpRawDataCheck.TabIndex = 1;
            this.dumpRawDataCheck.Text = "Output NMEA data";
            // 
            // NMEAText
            // 
            this.NMEAText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.NMEAText.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NMEAText.Location = new System.Drawing.Point(9, 40);
            this.NMEAText.Multiline = true;
            this.NMEAText.Name = "NMEAText";
            this.NMEAText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.NMEAText.Size = new System.Drawing.Size(672, 375);
            this.NMEAText.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label13);
            this.tabPage4.Controls.Add(this.COMlistBox);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(692, 424);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Set Up";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(19, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(116, 13);
            this.label13.TabIndex = 2;
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
            this.COMlistBox.Location = new System.Drawing.Point(20, 39);
            this.COMlistBox.Name = "COMlistBox";
            this.COMlistBox.Size = new System.Drawing.Size(136, 69);
            this.COMlistBox.TabIndex = 1;
            // 
            // connectButton
            // 
            this.connectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.connectButton.Location = new System.Drawing.Point(16, 469);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(112, 23);
            this.connectButton.TabIndex = 0;
            this.connectButton.Text = "Connect";
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // disconnectButton
            // 
            this.disconnectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.disconnectButton.Enabled = false;
            this.disconnectButton.Location = new System.Drawing.Point(134, 469);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(112, 23);
            this.disconnectButton.TabIndex = 2;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 700;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(692, 424);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            this.tabPage5.Click += new System.EventHandler(this.tabPage5_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(725, 499);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.disconnectButton);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GPS in .NET";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSats)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
            Application.EnableVisualStyles();
			Application.Run(new MainForm());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			//set com5 by default
			COMlistBox.SelectedIndex = 4;
		}

		private void connectButton_Click(object sender, System.EventArgs e)
		{
			connectButton.Enabled = false;
			disconnectButton.Enabled = true;
            COMlistBox.Enabled = false;
            port.PortName = COMlistBox.SelectedItem as string;
            port.Parity = Parity.None;
            port.BaudRate = 4800;
            port.StopBits = StopBits.One;
            port.DataBits = 8;
            port.Open();
			timer1.Enabled = true;
		}

		private void disconnectButton_Click(object sender, System.EventArgs e)
		{
			disconnectButton.Enabled = false;
			connectButton.Enabled = true;
            COMlistBox.Enabled = true;
            timer1.Enabled=false;
            try
            {
                port.Close();
            }
            catch(Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Trouble closing the SerialPort! " + ex.ToString());
            }
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			ReadData();
		}


		private void ReadData()
		{
			byte[] bData = new byte[256];

			try
			{
				//bData = serialHelper.Read();
                port.Read(bData, 0, 256);

				protocol.ParseBuffer(bData);
			}
			catch(Exception e)
			{
                System.Diagnostics.Debug.WriteLine(e.ToString());
				//swallow it.
			}

			DisplayNMEARawData(bData);
			DisplayGeneralInfo();
			DisplaySatellites();
		}

		private void DisplayNMEARawData(byte[] bData)
		{
			string sData="";
			if(null != bData)
			{
				sData = encoding.GetString(bData);
			}

			if (dumpRawDataCheck.Checked)
			{
				//if dumped 100k of data get rid of the oldest 50k
				if(NMEAText.Text.Length > 100*1000)
				{
					NMEAText.Text = NMEAText.Text.Substring(50000,50000);

				}

				NMEAText.Text =    NMEAText.Text + sData;
				NMEAText.SelectionStart = NMEAText.Text.Length-1;
				NMEAText.ScrollToCaret();
			}
		}

		private void DisplayGeneralInfo()
		{
			labelLatitude.Text = protocol.GPGGA.Latitude.ToString();
			labelLongitude.Text = protocol.GPGGA.Longitude.ToString();
			labelAltitude.Text = protocol.GPGGA.Altitude.ToString();

            DateTime utc = DateTime.MinValue;   

            if (protocol.GPRMC.Month != 0 && protocol.GPRMC.Year != 0 && protocol.GPRMC.Day != 0)
            {
                utc = new DateTime(protocol.GPRMC.Year + 2000, protocol.GPRMC.Month, protocol.GPRMC.Day, protocol.GPGGA.Hour, protocol.GPGGA.Minute, protocol.GPGGA.Second, DateTimeKind.Utc);
                labelDate.Text = utc.ToShortDateString();
                labelTimeLocal.Text = utc.ToLocalTime().ToString();
                labelTime.Text = utc.ToShortTimeString();
            }

			listGPSQuality.SelectedIndex = (int)protocol.GPGGA.GPSQuality;

            labelFixMode.Text = protocol.GPGSA.Mode == 'A' ? "Automatic" : "Manual";
            labelPDOP.Text = protocol.GPGSA.PDOP.ToString();
            labelVDOP.Text = protocol.GPGSA.VDOP.ToString();
            labelHDOP.Text = protocol.GPGSA.HDOP.ToString();

            labelDataValid.Text = protocol.GPRMC.DataValid == 'A' ? "Data Valid" : "Navigation Receive Warning";

		}

		private void DisplaySatellites()
		{
			labelSatellitesInView.Text =  protocol.GPGSV.SatellitesInView.ToString();
			
            Pen circlePen = new Pen(System.Drawing.Color.DarkBlue,1);

			Graphics g= picSats.CreateGraphics();
		
			int centerX = picSats.Width/2;
			int centerY = picSats.Height/2;

			double maxRadius = (Math.Min(picSats.Height,picSats.Width)-20) / 2;

			//draw circles
			double[] elevations = new double[] {0,Math.PI/2, Math.PI/3 ,Math.PI / 6};

			foreach(double elevation in elevations)
			{
				double radius = (double)System.Math.Cos(elevation) * maxRadius;
				g.DrawEllipse(circlePen,(int)(centerX - radius) ,(int)(centerY - radius),(int)(2 * radius),(int)( 2*  radius));
			}
			//90 degrees elevation reticule
			g.DrawLine(circlePen,new Point(centerX-3,centerY),new Point(centerX + 3,centerY));
			g.DrawLine(circlePen,new Point(centerX,centerY-3),new Point(centerX,centerY+3));

			Pen satellitePen = new Pen(System.Drawing.Color.LightGoldenrodYellow,4);

			foreach(Satellite sat in protocol.GPGSV.Satellites.Values)
			{			
				//if has a listitem
				ListViewItem lvItem = (ListViewItem)sat.Thing;

				if(null == lvItem)
				{
					lvItem =  new ListViewItem
						( 
							new string[] 
							{
								sat.Id.ToString() ,
								sat.Elevation.ToString(),
								sat.Azimuth.ToString(),
								sat.Used.ToString()
							} 
						);
					

					listSatellites.Items.Add(lvItem);
					
					sat.Thing = lvItem;//lvItem;
				}
				else
				{
					lvItem.Text = sat.Id.ToString();
					lvItem.SubItems[1].Text = sat.Elevation.ToString();
					lvItem.SubItems[2].Text = sat.Azimuth.ToString();
					lvItem.SubItems[3].Text = sat.Used.ToString();
				}

				//draw satellites
				double h = (double)System.Math.Cos((sat.Elevation*Math.PI)/180) * maxRadius;
				
				int satX = (int)(centerX + h * Math.Sin((sat.Azimuth * Math.PI)/180));
				int satY = (int)(centerY - h * Math.Cos((sat.Azimuth * Math.PI)/180));

				g.DrawRectangle(satellitePen,satX,satY, 4,4);

                g.DrawString(sat.Id.ToString(), new Font("Verdana", 8, FontStyle.Regular), new System.Drawing.SolidBrush(Color.Black), new Point(satX + 5, satY + 5));
			}
		}

        private void output_Click(object sender, EventArgs e)
        {

        }
	}
}
