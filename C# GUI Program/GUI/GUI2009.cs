//Version 15 
//GUI Program for Silab Laboratories Silicon F350 Compass Rd 
//Date: 05/02/2009
//Jason Zhou 

#region (Namespaces)
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Resources;
using System.Net.Cache;
using Jason.Properties;
using System.Web.UI;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.Util;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Diagnostics;


#endregion

namespace F350Compass
{
    public partial class GUI2009 : Form
    {
        #region (Variables)
        public enum LogMsgType { Incoming, Outgoing, Normal, Warning, Error };
        private Color[] LogMsgTypeColor = { Color.Blue, Color.Green, Color.Black, Color.Orange, Color.Red };
        public bool userclickstop;
        public string timefordata = "0";
        public int degree2;
        public string Counts; //Row Counts in Datagrid 
        public string testingstring = "";
        private string outputfolder = "";
        public string totaltemp1 = "";
        public float bigtemperature;
        Stopwatch stop1 = new Stopwatch(); //Use it as a timer when retrieving data from the Device

        //Variables for Display Chart
        public int totaldegreed;
        public int dirmins;
        public int totaltempd;
        public int aX;
        public int aY;
               
        #endregion

        #region Constructor, Form 1 and Combobox
        public GUI2009()
        {            
            InitializeComponent();
           
            memo.Text = "";
            EnableControls();// Enable/disable controls based on the current state
            GUI2009_Shown();
            string[] portname = SerialPort.GetPortNames();
            foreach (string port in portname)
            {
                comboBox1.Items.Add(port);
            }
        }

        private void EnableControls()
        {
           //Enable/disable controls based on whether the port is open or not
           RDbutton.Enabled = Ports.IsOpen;

        }

        private void GUI2009_Shown()
        {
             toolStripStatusLabel1.Text =("At your command - Silicon Laboratories F350 Compass GUI");
             toolStripStatusLabel2.Text = ("(Copy right reserved 2009 Massey University)");
        } 

        private void Form1_Load(object sender, EventArgs e)
        {
            Ports.DataReceived += new SerialDataReceivedEventHandler(Ports_DataReceived);
            memo.Hide();
            progressBar1.Maximum = 200;
            progressBar1.Minimum = 1;
            progressBar1.Step = 1;

           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            memo.Show();
            
            //Set up F350 Compass serial port specifications
            if (Ports.IsOpen) Ports.Close();
            Ports.PortName = comboBox1.SelectedItem.ToString();
            Ports.BaudRate = 57600;
            Ports.DataBits = 8;
            Ports.Parity = Parity.None;
            Ports.StopBits = StopBits.One;
            Ports.ReadTimeout = 1000;
            Ports.WriteTimeout = 1000;
            Ports.Handshake = Handshake.None;
            Ports.Encoding = System.Text.Encoding.UTF8;
            Ports.ReceivedBytesThreshold = 7;
            Ports.DtrEnable = true;
            Ports.RtsEnable = true;
     
            try
            {
                Ports.Open();
                label3.Text = Convert.ToString(Ports.BaudRate) +" bps";
                label5.Text = Convert.ToString(Ports.DataBits) +" bits";
                label7.Text = Convert.ToString(Ports.Parity);
                label9.Text = Convert.ToString(Ports.StopBits);

                for (int i = progressBar1.Minimum; i <= progressBar1.Maximum; i++)
                {
                    progressBar1.PerformStep();

                }
                MessageBox.Show("PORT Number: " + Ports.PortName + " is Open!", "F350 Compass RD POrt");
                progressBar1.Value = 1;
                
            }
            catch
            {
                MessageBox.Show("Serial port " + Ports.PortName + " cannot be opened!", "F350 Compass RD POrt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox1.SelectedText = "";
            }

            EnableControls();      
           
        }
        #endregion 

        #region Write button (Data request command)

        private void RDbutton_Click(object sender, EventArgs e)
        {
            userclickstop = false;
            GetDATAS();           
        }

        private void Stopbutton_Click(object sender, EventArgs e)
        {
            stop1.Stop();
            stop1.Reset();
            userclickstop = true;
            for (int i = progressBar1.Minimum; i <= progressBar1.Maximum; i++)
            {
               progressBar1.PerformStep();
            }
            MessageBox.Show("Stop requesting data from device");
            progressBar1.Value = 1;
           
        }
        private void GetDATAS()
        {        
            while (userclickstop == false) 
            {            
                 if (Ports.IsOpen)
                 {                                    
                    Ports.Write(new byte[] {0x11}, 0, 1);
                                         
                    for (int i = progressBar1.Minimum; i <= progressBar1.Maximum; i++)
                    {
                        progressBar1.PerformStep();
                    }
                    Application.DoEvents();
                    
                    Thread.Sleep(500); //Block the current Thread for 500 milliseconds
                    clearit();
                 }
                 else
                 {
                    MessageBox.Show("What are you doing? The Serial port is closed!", "Jason's tester", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                 }  
             }
        }
        #endregion
                
        #region HexStringToByteArray
        //Convert a string of hex digits (ex: E4 CA B2) to a byte array.
        //The string containing the hex digits (with or without spaces). 
        //Returns an array of bytes. 
        private byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
            buffer[i /2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            return buffer;
        }
        #endregion

        #region ByteArrayToHexString
        //Converts an array of bytes into a formatted string of hex digits (EG:7F 2A)
        //The array of bytes to be translated into a string of hex digits. 
        //Returns a well formatted string of hex digits with spacing. 
        private string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
            sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
            return sb.ToString().ToUpper();       

        }
        #endregion

        #region Datareceived and Stop Watch
        void Ports_DataReceived(Object sender, SerialDataReceivedEventArgs e)
        {
           // Obtain the number of bytes waiting in the port's buffer
            int bytes = 0;
            bytes = Ports.BytesToRead;
           // MessageBox.Show(Convert.ToString(bytes));

            // Create a byte array buffer to hold the incoming data
            byte[] buffer = new byte[bytes];

            // Read the data from the port and store it in our buffer
            Ports.Read(buffer, 0, bytes);

            // Show the user the incoming data in hex format
            Log(LogMsgType.Incoming, ByteArrayToHexString(buffer));

            //Stop watch - The timer
            stop1.Start();
            long millis = (stop1.ElapsedMilliseconds);
            float millis1 = Convert.ToSingle(millis);
            float millis2 = (millis1 / 1000);
            timefordata = Convert.ToString(millis2);
            //timefordata = DateTime.Now.ToString("hh:mm:ss tt");
         } 

        #endregion

        #region Save as, save and Exit
              
        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save this file?", "File Saving mode", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                toolStripStatusLabel3.Text = "Saving data";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter outputstream;
                    string sValue;
                    outputfolder = saveFileDialog1.FileName; //Choose the saving directory for the Excel spread sheet

                    try
                    { 
                        outputstream = File.CreateText(outputfolder); 
                    }
                    catch 
                    {
                        string Warningmm = " is in Use. Close it and Try again later.";
                        MessageBox.Show((outputfolder + Warningmm), "Warning Mode");
                        return;                        
                    }
                    
                    //Create Header Line in the Excel File when saving directory is selected                                      
                    foreach (DataGridViewColumn colums in memo2.Columns)
                    {
                        if (colums.Visible)
                        {
                            outputstream.Write(colums.HeaderText);
                            if ((colums.Index < memo2.Columns.Count))
                            {
                                outputstream.Write(",");
                            }
                        }
                    }
                    outputstream.WriteLine();
                 
                 //Rows and Columns from DataGridView
                 foreach (DataGridViewRow rows in memo2.Rows)
                 {
                     foreach (DataGridViewColumn colums in memo2.Columns)
                     {
                         if (colums.Visible)
                         {
                             try
                             {
                                 if (!(rows.Cells[colums.Index].Value == null))
                                 {
                                     switch (rows.Cells[colums.Index].ValueType.Name)
                                     {
                                         case "String":
                                             sValue = ((string)(rows.Cells[colums.Index].Value));
                                             sValue = sValue.Replace(",", " ");
                                             // lose the commas   
                                             outputstream.Write(sValue.Trim());
                                             break;
                                             default:
                                             outputstream.Write(rows.Cells[colums.Index].Value);
                                             break;
                                     }
                                 }
                                 if ((colums.Index < memo2.Columns.Count))
                                 {
                                     outputstream.Write(",");
                                 }
                             }
                             catch
                             {
                                 MessageBox.Show("Can not export data!!!!");
                                 return;
                             }
                         }                    
                     }                    
                     outputstream.WriteLine(); //Write data information into the specified location
                     
                     //Progress Bar 
                     for (int i = progressBar1.Minimum; i <= progressBar1.Maximum; i++)
                     {
                         progressBar1.PerformStep();
                     }                        
                 }
                //outputstream.fFlush();
                outputstream.Close(); //Close the stream 
                MessageBox.Show("Data has been succefully transferred into" + outputfolder + "Excel file");
                toolStripStatusLabel3.Text = "";
                progressBar1.Value = 1;

                }              
                
            }
            else
            {
                MessageBox.Show("File Did not save!");
                progressBar1.Value = 1;
            }

        }

        private void saveToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            
            if (outputfolder != "")
            {
                StreamWriter outputs1 = File.CreateText(outputfolder);
                string Vvalues;
                
                //Create Header Line in the Excel File when saving directory is selected                                      
                foreach (DataGridViewColumn colums in memo2.Columns)
                {
                    if (colums.Visible)
                    {
                        outputs1.Write(colums.HeaderText);
                        if ((colums.Index < memo2.Columns.Count))
                        {
                            outputs1.Write(",");
                        }
                    }
                }
                outputs1.WriteLine();

                //Rows and Columns from DataGridView
                foreach (DataGridViewRow rows in memo2.Rows)
                {
                    foreach (DataGridViewColumn colums in memo2.Columns)
                    {
                        if (colums.Visible)
                        {
                            try
                            {
                                if (!(rows.Cells[colums.Index].Value == null))
                                {
                                    switch (rows.Cells[colums.Index].ValueType.Name)
                                    {
                                        case "String":
                                            Vvalues = ((string)(rows.Cells[colums.Index].Value));
                                            Vvalues = Vvalues.Replace(",", " ");
                                            // lose the commas   
                                            outputs1.Write(Vvalues.Trim());
                                            break;
                                            default:
                                            outputs1.Write(rows.Cells[colums.Index].Value);
                                            break;
                                    }
                                }
                                if ((colums.Index < memo2.Columns.Count))
                                {
                                    outputs1.Write(",");
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Can not export data!!!!");
                                return;
                            }
                        }
                    }
                    outputs1.WriteLine(); //Write data information into the specified location
                }
                outputs1.Flush();
                outputs1.Close(); //Close the stream 
                MessageBox.Show("Data has been successfully save!", "Saving File.......");
                
            }

            else
            {
                MessageBox.Show("File Did not save, do save as first!");
            }
        }
      
        #endregion

        #region Exit function
        private void Exitbutton_Click_1(object sender, EventArgs e)
        {
             for (int i = progressBar1.Minimum; i <= progressBar1.Maximum; i++) 
             {
                  progressBar1.PerformStep();
             }
            
            exitfunction();
        }

        private void exitfunction()
        {  
            if (MessageBox.Show("Are you sure you want to Exit?", "Exit mode!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {                
                Close();
            }
            else
            {                
                progressBar1.Value = 1;
            }
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            exitfunction();
        }
        #endregion 
        
        #region Timer Class, Data Grid Class, Statusstrip class, tabpage class and richtextbox Class
        private void F350Timer_Tick(object sender, EventArgs e)
        {        
           
          
        }

        private void memo2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {  
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
           
        }

        private void memo_TextChanged(object sender, EventArgs e)
        {

        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        #endregion 

        #region string Data record log 
        private void Log(LogMsgType msgtype, string msg)
        {
            //Main Thread
            memo.Invoke(new EventHandler(delegate { memo.SelectedText = string.Empty;
            memo.SelectionFont = new Font(memo.SelectionFont, FontStyle.Bold);
            memo.SelectionColor = LogMsgTypeColor[(int)msgtype];
            memo.AppendText(msg + "\n"); //Append text into memo box
            populateDatagGrid(msg);  //pass string data into another function                              
            memo.ScrollToCaret(); }));                            
        }
        #endregion   
       
        #region Data to be display in Datagrid
        private void populateDatagGrid(string Bufferformsg)
        {  
             try
             {
                int stringlength = Convert.ToInt32((Bufferformsg.Length) - 1);
                if (stringlength == 26)
                {
                    string DataResult1 = Bufferformsg.Substring(0, 2);  //first byte 
                    string DataResult2 = Bufferformsg.Substring(3, 2);  //second byte
                    string DataResult3 = Bufferformsg.Substring(6, 2);  //Third byte
                    string DataResult4 = Bufferformsg.Substring(9, 2);  //Fourth byte
                    string DataResult5 = Bufferformsg.Substring(12, 2); //Fifth byte
                    string DataResult6 = Bufferformsg.Substring(15, 2); //sixth byte
                    string DataResult7 = Bufferformsg.Substring(18, 2); //seventh byte
                    string DataResult8 = Bufferformsg.Substring(21, 2); //Eighth byte
                    string DataResult9 = Bufferformsg.Substring(24, 2); //ninth byte

                    //Direction Degree first byte
                    if (DataResult1 == "01")
                    {
                        DataResult1 = "256";
                        degree2 = Convert.ToInt32(DataResult1);                        
                    }
                    if (DataResult1 == "00")
                    {
                        DataResult1 = "0";
                        degree2 = Convert.ToInt32(DataResult1);
                    }

                    //Direction Degree second byte
                    byte[] DirDegree3 = HexStringToByteArray(DataResult2);
                    string DirDegree4 = "";
                    foreach (byte b0 in DirDegree3)
                    {DirDegree4 = Convert.ToString(b0); }

                    //Merging the two bytes together to form the total degree reading
                    int degree1 = Convert.ToInt32(DirDegree4);
                    int totaldegree = degree1 + degree2;
                    string totaldegree1 = Convert.ToString(totaldegree);
                    totaldegreed = Convert.ToInt32(totaldegree1);

                    //Dir_minutes (third byte)
                    byte[] Dirminutes = HexStringToByteArray(DataResult3);
                    string Dirminutes1 = "";
                    foreach (byte b6 in Dirminutes)
                    {
                        Dirminutes1 = Convert.ToString(b6);
                        dirmins = Convert.ToInt32(Dirminutes1);
                        //MessageBox.Show(Convert.ToString(dirmins));
                    }                    

                    //Total Temperature in celcius only (fourth and fifth bytes)
                    if (DataResult4 == "00")
                    {
                        DataResult4 = "0";
                        bigtemperature = Convert.ToSingle(DataResult4);

                        byte[] temp4 = HexStringToByteArray(DataResult5);
                        string temp5 = "";
                        foreach (byte b5 in temp4)
                        {
                            temp5 = Convert.ToString(b5);
                        }
                        float temp1 = Convert.ToSingle(temp5);
                        float totaltemp = ((bigtemperature + temp1) / 10);
                        totaltempd = Convert.ToInt32(totaltemp);
                        totaltemp1 = Convert.ToString(totaltemp);

                    }                    
                    else if (DataResult4 == "01")
                    {
                        DataResult4 = "128";
                        bigtemperature = Convert.ToSingle(DataResult4);

                        byte[] temp4 = HexStringToByteArray(DataResult5);
                        string temp5 = "";
                        foreach (byte b5 in temp4)
                        {
                            temp5 = Convert.ToString(b5);
                        }
                        float temp1 = Convert.ToSingle(temp5);
                        float totaltemp = ((bigtemperature + temp1) / 10);
                        totaltempd = Convert.ToInt32(totaltemp);
                        totaltemp1 = Convert.ToString(totaltemp);
                    }
                    else if (DataResult4 == "02")
                    {
                        DataResult4 = "256";
                        bigtemperature = Convert.ToSingle(DataResult4);

                        byte[] temp4 = HexStringToByteArray(DataResult5);
                        string temp5 = "";
                        foreach (byte b5 in temp4)
                        {
                            temp5 = Convert.ToString(b5);
                        }
                        float temp1 = Convert.ToSingle(temp5);
                        float totaltemp = ((bigtemperature + temp1) / 10);
                        totaltempd = Convert.ToInt32(totaltemp);
                        totaltemp1 = Convert.ToString(totaltemp);
                    }

                    //Probably not needed for reading Celsius
                    else  
                    {
                        byte[] temp2 = HexStringToByteArray(DataResult4);
                        string temp3 = "";
                        foreach (byte b4 in temp2)
                        {
                            temp3 = Convert.ToString(b4);
                        }
                        byte[] temp4 = HexStringToByteArray(DataResult5);
                        string temp5 = "";
                        foreach (byte b5 in temp4)
                        {
                            temp5 = Convert.ToString(b5);
                        }
                        float temp10 = Convert.ToSingle(temp3);
                        float temp11 = Convert.ToSingle(temp5);
                        float temp12 = (((temp10) + temp11) / 10);
                        totaltemp1 = Convert.ToString(temp12);
                    }
                  
                    //Inclination X (Sixth byte)
                    byte[] angelX = HexStringToByteArray(DataResult6);
                    string angelX1 = "";
                    foreach (byte b7 in angelX)
                    {
                        angelX1 = Convert.ToString(b7);
                        
                    }
                    long angelX2 = Convert.ToInt64(angelX1); //Always negative int number
                    string angelX11 = Convert.ToString(angelX2);
                    aX = Convert.ToInt32(angelX11);

                    //Inclination Y (Seventh Byte)
                    byte[] angelY = HexStringToByteArray(DataResult7);
                    string angelY1 = "";
                    foreach (byte b8 in angelY)
                    {
                        angelY1 = Convert.ToString(b8);
                    }
                    long angelY2 = Convert.ToInt64(angelY1);
                    string angelY11 = Convert.ToString(angelY2);
                    aY = Convert.ToInt32(angelY11);

                    //Status Register 1byte (Eighth Byte)
                    byte[] Status = HexStringToByteArray(DataResult8);
                    string Status1 = "";
                    foreach (byte b9 in Status)
                    {
                        Status1 = Convert.ToString(b9);
                    }
                    int status2 = Convert.ToInt32(Status1);

                    //Cyclic redundancy check (CRC) - CheckSum calculation (Ninth byte)
                    byte[] CRC = HexStringToByteArray(DataResult9);
                    string CRC1 = "";
                    foreach (byte b10 in CRC)
                    {
                        CRC1 = Convert.ToString(b10);                      
                    }
                    int CRC2 = Convert.ToInt32(CRC1);

                    //Number of rows in receiving data from F350 Compass
                    for (int counts = 1; counts <= memo2.RowCount; counts++)
                    {
                        Counts = Convert.ToString(counts); 
                    }

                    //Pass all information in string data byte onto the data grid form
                    memo2.Rows.Add(Counts, totaldegree1, Dirminutes1, totaltemp1, angelX11, angelY11, Status1, CRC1, timefordata);
                    DisplayInfos();
                }
                else
                {}                
            }
            catch
            {
                memo2.Rows.Add("Error", "Error", "Error", "Error", "Error", "Error", "Error", "Error", "Error");
                return;
            }
            
            
        }
        #endregion     
  
        #region BarCharts Display
        private void DisplayInfos()
        {
            Graphics paper = picture1.CreateGraphics();
            Pen mypen = new Pen(Color.Black);
            SolidBrush mybrush = new SolidBrush(Color.Blue);
           
            Rectangle rtl = new Rectangle(50, (400 - totaldegreed), 50, totaldegreed);
            Rectangle rtl1 = new Rectangle(150, (400 - dirmins), 50, dirmins);
            Rectangle rtl2 = new Rectangle(250, (400 - totaltempd), 50, totaltempd);
            Rectangle rtl3 = new Rectangle(350, (400 - aX), 50, aX);
            Rectangle rtl4 = new Rectangle(450, (400 - aY), 50, aY);

            paper.FillRectangle(mybrush, rtl);
            paper.FillRectangle(mybrush, rtl1);
            paper.FillRectangle(mybrush, rtl2);
            paper.FillRectangle(mybrush, rtl3);
            paper.FillRectangle(mybrush, rtl4);
           
        }

        private void clearit()
        {
            Graphics paper = picture1.CreateGraphics();
            paper.Clear(Color.White);
        }
        #endregion 
    }
}