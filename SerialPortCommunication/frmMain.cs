using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PCComm;

using System.Drawing.Drawing2D;

namespace PCComm
{
    public partial class frmMain : Form
    {
        Timer timer1 = new Timer();
        CommunicationManager comm = new CommunicationManager();
        string transType = string.Empty;
        byte status;
        byte[] byteArr;
        int speed;
        int count;
        byte myCommand, myPort5, myReceivedByte, myMessage;
        bool buttonToggle;

        public frmMain()
        {
            InitializeComponent();

           
            speed = 0;
            buttonToggle = false;

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

            if (myMessage < 128)
            {
                trackBar1.Value = myMessage;

            }
            else
            {

                trackBar1.Value = myMessage - 128;

            }

            speed = trackBar1.Value;


            if ((speed > 85) && (speed < 128))
                textBox5.Text = "Fast Speed!";
            if ((speed > 43) && (speed < 85))
                textBox5.Text = "Medium Speed!";
            if ((speed >= 0) && (speed < 43))
                textBox5.Text = "Slow Speed!";


            if (comm.comPort.IsOpen)
            {

                if (buttonToggle == true)
                {
                    byteArr[0] = (byte)(trackBar1.Value + 128);
                    status = byteArr[0];
                    if (status == 132)
                        textBox3.Text = "Stop!";
                    else
                        textBox3.Text = "Going Right!";

                    textBox1.Text = "" + (int)((100 * (byteArr[0] - 128)) / 128);
                    byteArr[0] = (byte)(byteArr[0] - 128);

                    textBox2.Text = comm.ByteToHex(byteArr);
                    byteArr[0] = (byte)(byteArr[0] + 128);

                }
                else
                {
                    byteArr[0] = (byte)trackBar1.Value;
                    status = byteArr[0];
                    if (status == 132)
                        textBox3.Text = "Stop!";
                    else
                        textBox3.Text = "Going Left!";
                    textBox1.Text = "" + (int)((100 * byteArr[0]) / 128);
                    textBox2.Text = comm.ByteToHex(byteArr);
                }


                comm.WriteByte(byteArr);
           
            
            }//if



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
            cmdSend.Enabled = true;
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
            cmdSend.Enabled = false;
            cmdClose.Enabled = false;
        }

private void cmdSend_Click(object sender, EventArgs e)
        {
            
   
          
                comm.WriteData(txtSend.Text);

         

            byte[] output = comm.HexToByte(txtSend.Text);
           
                for (int i = 0; i < output.Length; i++)
                {
             //      comm._displayWindow.AppendText("\n==> output[" + i + "] is: " + output[i]+"\n");

                }




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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void cboStop_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

            


           



            if (buttonToggle == true)
            {
                byteArr[0] = (byte)(trackBar1.Value +128);
                status = byteArr[0];
                if (status == 132)
                    textBox3.Text = "Stop!";
                else
                    textBox3.Text = "Going Right!";

                textBox1.Text = "" + (int)((100 * (byteArr[0] - 128)) / 128);
                byteArr[0] = (byte)(byteArr[0] - 128);
                
                textBox2.Text = comm.ByteToHex(byteArr);
                byteArr[0] = (byte)(byteArr[0] + 128);
                
            }
            else
            {
                byteArr[0] = (byte)trackBar1.Value;
                status = byteArr[0];
                if (status == 132)
                    textBox3.Text = "Stop!";
                else
                    textBox3.Text = "Going Left!";
                textBox1.Text = "" + (int)((100 * byteArr[0]) / 128);
                textBox2.Text = comm.ByteToHex(byteArr);
            }



            //if continuous checked then run continuously:
            
                comm.WriteByte(byteArr);




            
            
            
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
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

        private void label9_Click_1(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) // Change Direction
        {
          

            if (buttonToggle == true)
            {
                byteArr[0] = (byte)(trackBar1.Value + 128);

                status = byteArr[0];
                if (status == 132)
                    textBox3.Text = "Stop!";
                else
                    textBox3.Text = "Going Right!";

                textBox1.Text = "" + (int)((100 * (byteArr[0] - 128)) / 128);
                byteArr[0] = (byte)(byteArr[0] - 128);
                textBox2.Text = comm.ByteToHex(byteArr);
                byteArr[0] = (byte)(byteArr[0] + 128);

            }
            else
            {
                byteArr[0] = (byte)trackBar1.Value;
                status = byteArr[0];
                if (status == 132)
                    textBox3.Text = "Stop!";
                else
                    textBox3.Text = "Going Left!";

                textBox1.Text = "" + (int)((100 * byteArr[0]) / 128);
                textBox2.Text = comm.ByteToHex(byteArr);
            }



            buttonToggle = !buttonToggle;



            speed = trackBar1.Value;

            if ((speed > 85) && (speed < 128))
                textBox5.Text = "Fast Speed!";
            if ((speed > 43) && (speed < 85))
                textBox5.Text = "Medium Speed!";
            if ((speed >= 0) && (speed < 43))
                textBox5.Text = "Slow Speed!";


            //if continuous checked then run continuously:

            comm.WriteByte(byteArr);



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
    }
}