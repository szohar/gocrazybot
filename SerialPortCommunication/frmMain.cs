using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PCComm;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace PCComm
{
    public enum MotorSpeed : int
    {   
        stop,
        slow,
        medium,
        fast,
        
    }

    public partial class frmMain : Form
    {
        System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
        CommunicationManager comm = new CommunicationManager();
        string transType = string.Empty;
        byte[] byteArr;
        int count;
        byte myCommand, myPort5, myReceivedByte, myMessage;
        bool DIR;
        MotorSpeed speed;

        public frmMain()
        {
            InitializeComponent();
            speed = MotorSpeed.stop;
            DIR = false;

            //we want to process paint events		
            Paint += new PaintEventHandler(OnPaint);

            timer1.Interval = 100;
            timer1.Tick += new EventHandler(Ticker);
            timer1.Start();

            //enabling double-buffering to avoid flicker
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

        }


      void Ticker(object sender, EventArgs e)
        {
          
         
           Random rnd = new Random((int)DateTime.Now.Ticks);
           int rotationDirection = (int)(2 * rnd.NextDouble());

           count ++;

            textBox6.Text = ""+ count;

            if (count == 10000)
                count = 0;

            Invalidate();



        //  ===================================


            if (comm.length >= 4)
            {
                myCommand = comm.command;
                myPort5 = comm.port5;
                myMessage = comm.message;
                myReceivedByte = comm.received_byte;

            }


            //================================================================>
            //my resetting:=


          // If the command is true the green panel will show if 
          //there is no command then the panel will not show. 
            if (myCommand == 204)
            {
                panel1.Visible = true;


            }
            else
                panel1.Visible = false;
          

            textBox9.Text = "" + myCommand;
            textBox10.Text = "" + myPort5;
            textBox11.Text = "" + myMessage;
            textBox12.Text = "" + myReceivedByte;

          

          
            if (comm.comPort.IsOpen)
            {
                
                if (DIR == true)
                {
                    byteArr[0] = 8;
                    comm.WriteByte(byteArr);
                    textBox3.Text = "Direction = RIGHT";
                }
                else
                {
                    byteArr[0] = 9;
                    comm.WriteByte(byteArr);
                    textBox3.Text = "Direction = LEFT";
                }
                comm.WriteByte(byteArr);

                
                switch (speed)
                {
                    case MotorSpeed.slow:
                        send_int_mc(1, "Slow");
                        break;
                    case MotorSpeed.medium:
                        send_int_mc(2, "Medium");
                        break;
                    case MotorSpeed.fast:
                        send_int_mc(3, "Fast");
                        break;

                    default:
                        send_int_mc(0, "Stop");
                        break;

                }
                
                                            
            }//if

      }
      private void send_int_mc(byte code, string message)
      {
          byteArr[0] = code;
          comm.WriteByte(byteArr);
          textBox5.Text = ""+message;
      }


      

      private void button_direction_Click(object sender, EventArgs e)
      {
          if (DIR == false)
              DIR = true;
          else
              DIR = false;
          
      }

      private void button_slow_Click(object sender, EventArgs e)
      {
          speed = MotorSpeed.slow;
      }

      private void button_medium_Click(object sender, EventArgs e)
      {
          speed = MotorSpeed.medium;
      }

      private void button_fast_Click(object sender, EventArgs e)
      {
          speed = MotorSpeed.fast;
      }

    void OnPaint(Object sender, PaintEventArgs e)
    {

        Graphics g = e.Graphics;

        //delete this line for normal programs: it is time consuming!
        g.SmoothingMode = SmoothingMode.AntiAlias;

        Pen bluePen = new Pen(Color.Blue);


        //changing the style of the line (other DashStyles: Dash, DashDot, Solid)
        bluePen.DashStyle = DashStyle.Solid;
        bluePen.Width = 20;
        //we use line ends (others: Round, Square, TSmoothingModeriangle, SquareAnchor)
        bluePen.StartCap = LineCap.RoundAnchor;
        bluePen.EndCap = LineCap.ArrowAnchor;

        //we create a semi-transparent brush
        SolidBrush semiTransBrush = new SolidBrush(Color.FromArgb(128, 100, 120, 255));

        semiTransBrush = new SolidBrush(Color.Red);

    }



    private void frmMain_Load(object sender, EventArgs e)
    {
       LoadValues();
       SetDefaults();
       SetControlState();
    }

    private void cmdOpen_Click(object sender, EventArgs e)
    {
        comm.Parity = cboParity.Text;
        comm.StopBits = cboStop.Text;
        comm.DataBits = cboData.Text;
        comm.BaudRate = cboBaud.Text;
        comm.DisplayWindow = rtbDisplay;
        comm.OpenPort();

        cmdOpen.Enabled = false;
        cmdClose.Enabled = true;
        byteArr = new byte[1];
        
        
       
    }


         
           

    /// <summary>
    /// Method to initialize serial port
    /// values to standard defaults
    /// </summary>
    private void SetDefaults()
    {
        cboPort.SelectedIndex = 0;
        cboBaud.SelectedText = "115000";
        cboParity.SelectedIndex = 0;
        cboStop.SelectedIndex = 1;
        cboData.SelectedIndex = 1;
    }

    /// <summary>
    /// methos to load our serial
    /// port option values
    /// </summary>
    private void LoadValues()
    {
        comm.SetPortNameValues(cboPort);
        comm.SetParityValues(cboParity);
        comm.SetStopBitValues(cboStop);
    }

    /// <summary>
    /// method to set the state of controls
    /// when the form first loads
    /// </summary>
    private void SetControlState()
    {
        rdoText.Checked = true;
        cmdClose.Enabled = false;
    }


        private void rdoHex_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoHex.Checked == true)
            {
                comm.CurrentTransmissionType = PCComm.CommunicationManager.TransmissionType.Hex;
            }
            if (rdoByte.Checked == true)
            {
                comm.CurrentTransmissionType = PCComm.CommunicationManager.TransmissionType.Byte;
            }
            if (rdoText.Checked == true)
            {
                comm.CurrentTransmissionType = PCComm.CommunicationManager.TransmissionType.Text;
            }
            
        }

        private void rtbDisplay_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cboPort_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboData_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        public void cboStop_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

       
        public void textBox6_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        public void textBox7_TextChanged(object sender, EventArgs e)
        {
           
        }

        public void textBox8_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        public void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        public void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        public void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        public void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSend_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            
        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboBaud_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        
        

    }
}


