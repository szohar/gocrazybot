using System;
using System.Text;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
//*****************************************************************************************
//                           LICENSE INFORMATION
//*****************************************************************************************
//   PCCom.SerialCommunication Version 1.0.0.0
//   Class file for managing serial port communication
//
//   Copyright (C) 2007  
//   Richard L. McCutchen 
//   Email: richard@psychocoder.net
//   Created: 20OCT07
//
//   This program is free software: you can redistribute it and/or modify
//   it under the terms of the GNU General Public License as published by
//   the Free Software Foundation, either version 3 of the License, or
//   (at your option) any later version.
//
//   This program is distributed in the hope that it will be useful,
//   but WITHOUT ANY WARRANTY; without even the implied warranty of
//   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//   GNU General Public License for more details.
//
//   You should have received a copy of the GNU General Public License
//   along with this program.  If not, see <http://www.gnu.org/licenses/>.
//*****************************************************************************************
namespace PCComm
{
    class CommunicationManager
    {
        #region Manager Enums
        /// <summary>
        /// enumeration to hold our transmission types
        /// </summary>
        public enum TransmissionType { Text, Hex, Byte }

        /// <summary>
        /// enumeration to hold our message types
        /// </summary>
        public enum MessageType { Incoming, Outgoing, Normal, Warning, Error };
        #endregion

        #region Manager Variables
        //property variables
        private string _baudRate = string.Empty;
        public byte previousByte;
        private string _parity = string.Empty;
        private string _stopBits = string.Empty;
        private string _dataBits = string.Empty;
        private string _portName = string.Empty;
        private TransmissionType _transType;
        public RichTextBox _displayWindow;
     
      
        public int x, y;
        public byte received_byte = 0x00;
        public byte command = 0x00;
        public byte message = 0x00;
        public byte port5 = 0x00;
        public int length;


        //global manager variables
        private Color[] MessageColor = { Color.Blue, Color.Green, Color.Black, Color.Orange, Color.Red };
        public SerialPort comPort = new SerialPort();
        #endregion






        #region Manager Properties
        /// <summary>
        /// Property to hold the BaudRate
        /// of our manager class
        /// </summary>
        public string BaudRate
        {
            get { return _baudRate; }
            set { _baudRate = value; }
        }

        /// <summary>
        /// property to hold the Parity
        /// of our manager class
        /// </summary>
        public string Parity
        {
            get { return _parity; }
            set { _parity = value; }
        }

        /// <summary>
        /// property to hold the StopBits
        /// of our manager class
        /// </summary>
        public string StopBits
        {
            get { return _stopBits; }
            set { _stopBits = value; }
        }

        /// <summary>
        /// property to hold the DataBits
        /// of our manager class
        /// </summary>
        public string DataBits
        {
            get { return _dataBits; }
            set { _dataBits = value; }
        }

        /// <summary>
        /// property to hold the PortName
        /// of our manager class
        /// </summary>
        public string PortName
        {
            get { return _portName; }
            set { _portName = value; }
        }

        /// <summary>
        /// property to hold our TransmissionType
        /// of our manager class
        /// </summary>
        public TransmissionType CurrentTransmissionType
        {
            get { return _transType; }
            set { _transType = value; }
        }

        /// <summary>
        /// property to hold our display window
        /// value
        /// </summary>
        public RichTextBox DisplayWindow
        {
            get { return _displayWindow; }
            set { _displayWindow = value; }
        }
        #endregion

        #region Manager Constructors
        /// <summary>
        /// Constructor to set the properties of our Manager Class
        /// </summary>
        /// <param name="baud">Desired BaudRate</param>
        /// <param name="par">Desired Parity</param>
        /// <param name="sBits">Desired StopBits</param>
        /// <param name="dBits">Desired DataBits</param>
        /// <param name="name">Desired PortName</param>
        public CommunicationManager(string baud, string par, string sBits, string dBits, string name, RichTextBox rtb)
        {
            _baudRate = baud;
            _parity = par;
            _stopBits = sBits;
            _dataBits = dBits;
            _portName = name;
            _displayWindow = rtb;
            //now add an event handler
            comPort.DataReceived += new SerialDataReceivedEventHandler(comPort_DataReceived);
        }

        
        /// <summary>
        /// Comstructor to set the properties of our
        /// serial port communicator to nothing
        /// </summary>
        public CommunicationManager()
        {

            x = 0; y = 0;
            previousByte = 0;
            
            _baudRate = string.Empty;
            _parity = string.Empty;
            _stopBits = string.Empty;
            _dataBits = string.Empty;
            _portName = "COM4";
            _displayWindow = null;
            //add event handler
            comPort.DataReceived += new SerialDataReceivedEventHandler(comPort_DataReceived);
        }
        #endregion

        #region WriteData
        public void WriteData(string msg)
        {
            switch (CurrentTransmissionType)
            {
                case TransmissionType.Text:
                    //first make sure the port is open
                    //if its not open then open it
                    if (!(comPort.IsOpen == true)) comPort.Open();
                    //send the message to the port
                    comPort.Write(msg);
                    //display the message
                    DisplayData(MessageType.Outgoing, msg + "\n");
                    break;
                case TransmissionType.Hex:
                    try
                    {
                        //convert the message to byte array
                        byte[] newMsg = HexToByte(msg);
                        //send the message to the port
                        comPort.Write(newMsg, 0, newMsg.Length);
                        //convert back to hex and display
                        DisplayData(MessageType.Outgoing, ByteToHex(newMsg) + "\n");
                              
                                

                    }
                    catch (FormatException ex)
                    {
                        //display error message
                        DisplayData(MessageType.Error, ex.Message);
                    }
                    finally
                    {
                        _displayWindow.SelectAll();
                    }
                    break;

                
                default:
                    //first make sure the port is open
                    //if its not open then open it
                    if (!(comPort.IsOpen == true)) comPort.Open();
                    //send the message to the port
                    comPort.Write(msg);
                    //display the message
                    DisplayData(MessageType.Outgoing, msg + "\n");
                    break;
            }
        }
        #endregion

        #region WriteByte
        public void WriteByte(byte[] msg)
        {
            switch (CurrentTransmissionType)
            {
                case TransmissionType.Byte:
                    //first make sure the port is open
                    //if its not open then open it
                    if (!(comPort.IsOpen == true)) comPort.Open();
                   
                    try
                    {
                        
                        comPort.Write(msg, 0, msg.Length);
                        //convert back to hex and display
                    //    DisplayData(MessageType.Outgoing, (int)msg[0] + "\n");



                    }
                    catch (FormatException ex)
                    {
                        //display error message
                        DisplayData(MessageType.Error, ex.Message);
                    }
                    finally
                    {
                        _displayWindow.SelectAll();
                    }
                    break;


                default:
                    //first make sure the port is open
                    //if its not open then open it
                    if (!(comPort.IsOpen == true)) comPort.Open();

                 //   DisplayData(MessageType.Outgoing, (int)msg[0] + "\n");
                    break;
            }
        }
        #endregion

        #region HexToByte
        /// <summary>
        /// method to convert hex string into a byte array
        /// </summary>
        /// <param name="msg">string to convert</param>
        /// <returns>a byte array</returns>
        public byte[] HexToByte(string msg)
        {
            //remove any spaces from the string
            msg = msg.Replace(" ", "");
            //create a byte array the length of the
            //divided by 2 (Hex is 2 characters in length)
            byte[] comBuffer = new byte[msg.Length / 2];
            //loop through the length of the provided string
            for (int i = 0; i < msg.Length; i += 2)
                //convert each set of 2 characters to a byte
                //and add to the array
                comBuffer[i / 2] = (byte)Convert.ToByte(msg.Substring(i, 2), 16);
            //return the array
            return comBuffer;
        }
        #endregion

        
        #region convertToBits

        public static bool[] convertToBits(byte val)
        {
            int t;
            bool[] results = new bool[8];
            int bit = 8;

            for (t = 128; t > 0; t = t / 2)
            {

                if ((val & t) != 0)
                {


                    results[bit - 1] = true;
                }//if
                else
                {

                    results[bit - 1] = false;
                }
                bit--;

            }//for


            return results;
        }//convertToBits

        #endregion

        #region ByteToHex
        /// <summary>
        /// method to convert a byte array into a hex string
        /// </summary>
        /// <param name="comByte">byte array to convert</param>
        /// <returns>a hex string</returns>
        public string ByteToHex(byte[] comByte)
        {
            //create a new StringBuilder object
            StringBuilder builder = new StringBuilder(comByte.Length * 3);
            //loop through each byte in the array
            foreach (byte data in comByte)
                //convert the byte to a string and add to the stringbuilder
                builder.Append(Convert.ToString(data, 16).PadLeft(2, '0').PadRight(3, ' '));
            //return the converted value
            return builder.ToString().ToUpper();
        }
        #endregion

        #region DisplayData
        /// <summary>
        /// method to display the data to & from the port
        /// on the screen
        /// </summary>
        /// <param name="type">MessageType of the message</param>
        /// <param name="msg">Message to display</param>
        [STAThread]
        private void DisplayData(MessageType type, string msg)
        {
            _displayWindow.Invoke(new EventHandler(delegate
        {
            _displayWindow.SelectedText = string.Empty;
            _displayWindow.SelectionFont = new Font(_displayWindow.SelectionFont, FontStyle.Bold);
            _displayWindow.SelectionColor = MessageColor[(int)type];
            _displayWindow.AppendText(msg);                 
            _displayWindow.ScrollToCaret();
           
        }));
        }
        #endregion

        #region OpenPort
        public bool OpenPort()
        {
            try
            {
                //first check if the port is already open
                //if its open then close it
                if (comPort.IsOpen == true) comPort.Close();

                //set the properties of our SerialPort Object
                comPort.BaudRate = int.Parse(_baudRate);    //BaudRate
                comPort.DataBits = int.Parse(_dataBits);    //DataBits
                comPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), _stopBits);    //StopBits
                comPort.Parity = (Parity)Enum.Parse(typeof(Parity), _parity);    //Parity
                comPort.PortName = _portName;   //PortName
                //now open the port
                comPort.Open();
                //display message
                DisplayData(MessageType.Normal, "Port opened at " + DateTime.Now + "\n");
                //return true
                return true;
            }
            catch (Exception ex)
            {
                DisplayData(MessageType.Error, ex.Message);
                return false;
            }
        }
        #endregion

        #region SetParityValues
        public void SetParityValues(object obj)
        {
            foreach (string str in Enum.GetNames(typeof(Parity)))
            {
                ((ComboBox)obj).Items.Add(str);
            }
        }
        #endregion

        #region SetStopBitValues
        public void SetStopBitValues(object obj)
        {
            foreach (string str in Enum.GetNames(typeof(StopBits)))
            {
                ((ComboBox)obj).Items.Add(str);
            }
        }
        #endregion

        #region SetPortNameValues
        public void SetPortNameValues(object obj)
        {

            foreach (string str in SerialPort.GetPortNames())
            {
                ((ComboBox)obj).Items.Add(str);
            }
        }
        #endregion

        #region comPort_DataReceived
        /// <summary>
        /// method that will be called when theres data waiting in the buffer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void comPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //determine the mode the user selected (binary/string)
            switch (CurrentTransmissionType)
            {
                //user chose string
                case TransmissionType.Text:
                    //read data waiting in the buffer
                    string msg = comPort.ReadExisting();
                    //display the data to the user
                  //  DisplayData(MessageType.Incoming, msg + "\n");
                    break;
                //user chose binary

                case TransmissionType.Hex:
                    //retrieve number of bytes in the buffer
                    int bytes = comPort.BytesToRead;
                    length = bytes;

                    //create a byte array to hold the awaiting data
                    byte[] comBuffer = new byte[bytes];
                    //read the data and store it
                    
                     comPort.Read(comBuffer, 0, bytes);
                    
                   

                    if (bytes == 4)
                    {
                        //display the data to the user
                     //   DisplayData(MessageType.Incoming, "Start==> Incoming hex: " + ByteToHex(comBuffer) + "\n");
                    //    DisplayData(MessageType.Incoming, "no. of bytes is:  " + bytes + "\n");


                        int value = 0;
                        int value2 = 0;
                        long value3 = 0;

                        command = comBuffer[0];
                        port5 = comBuffer[1];
                        message = comBuffer[2];
                        received_byte = comBuffer[3];


                        value = ((int)comBuffer[0] << 8);
                        value = value + (int)comBuffer[1];

                        value2 = ((int)comBuffer[2] << 8);
                        value2 = value2 + (int)comBuffer[3];

                        value3 = (int)comBuffer[0];
                        value3 = value3 << 24;
                        value3 = value3 + ((int)comBuffer[1] << 16);
                        value3 = value3 + ((int)comBuffer[2] << 8);
                        value3 = value3 + (int)comBuffer[3];

                        //   if (previousByte != comBuffer[0])
                        //   {

                       //     DisplayData(MessageType.Incoming, "Incoming bytes:(hex) " + ByteToHex(comBuffer) + "\n");
                       //     DisplayData(MessageType.Incoming, "Incoming bytes:(int)  " + comBuffer[0] + " " +
                       //                                                          comBuffer[1] + " " + comBuffer[2] +
                       //                                                          " " + comBuffer[3] + "\n");


                  //      DisplayData(MessageType.Incoming, "value of 1st 2 bytes as 16 bit number:  " + value + "\n");
                  //      DisplayData(MessageType.Incoming, "value of 2nd 2 bytes as 16 bit number:  " + value2 + "\n");
                  //      DisplayData(MessageType.Incoming, "value of all 4 bytes as 32 bit number:  " + value3 + "\n");
                      
  
                        /*
                        if (bytes >= 9)
                        {
                            x = ((int)comBuffer[5] << 8);
                            x = x + (int)comBuffer[6];

                            y = ((int)comBuffer[7] << 8);
                            y = y + (int)comBuffer[8];

                            DisplayData(MessageType.Incoming, "x and y as 16 bit numbers are:  " + x +", "+ y + "\n");
                          

                        }//if
                        */

                    }//if



                    break;
                case TransmissionType.Byte:
                   
                    //retrieve number of bytes in the buffer
                      bytes = comPort.BytesToRead;

                      length = bytes;

                    //create a byte array to hold the awaiting data
                      comBuffer = new byte[bytes];


                    //read the data and store it
                   
                     comPort.Read(comBuffer, 0, bytes);
                    
                       

                       

                  
                    if (bytes == 4)
                    {
                        //display the data to the user
                     //   DisplayData(MessageType.Incoming, "Start==> Incoming hex: " + ByteToHex(comBuffer) + "\n");
                     //   DisplayData(MessageType.Incoming, "no. of bytes is:  " + bytes + "\n");



                       int value = 0;
                       int  value2 = 0;
                       long value3 = 0;
                        x = 0;
                        y = 0;
                        
                         command = comBuffer[0];
                         port5 = comBuffer[1];
                         message= comBuffer[2];
                         received_byte = comBuffer[3];

                        value = ((int)comBuffer[0] << 8);
                        value = value + (int)comBuffer[1];

                        value2 = ( (int)comBuffer[2] << 8 );
                        value2 = value2 + (int)comBuffer[3];

                        value3 = (int)comBuffer[0];
                        value3 = value3 << 24;
                        value3 = value3 + ( (int)comBuffer[1]<<16 );
                        value3 = value3 + ((int)comBuffer[2] << 8);
                        value3 = value3 + (int)comBuffer[3];

                  
                     //       DisplayData(MessageType.Incoming, "Incoming bytes:(hex) " + ByteToHex(comBuffer) + "\n");
                     //       DisplayData(MessageType.Incoming, "Incoming bytes:(int)  " + comBuffer[0] + " " +
                     //                                                            comBuffer[1] + " " + comBuffer[2] +
                     //                                                            " " + comBuffer[3] + "\n");
                     //       DisplayData(MessageType.Incoming, "value of 1st 2 bytes as 16 bit number:  " + value + "\n");
                    //        DisplayData(MessageType.Incoming, "value of 2nd 2 bytes as 16 bit number:  " + value2 + "\n");
                     //       DisplayData(MessageType.Incoming, "value of all 4 bytes as 32 bit number:  " + value3 + "\n");
                    //        DisplayData(MessageType.Incoming, "no. of bytes is:  " + bytes + "\n");
                      

/*
                           if (bytes >= 9)
                           {
                               x = ((int)comBuffer[5] << 8);
                               x = x + (int)comBuffer[6];

                               y = ((int)comBuffer[7] << 8);
                               y = y + (int)comBuffer[8];

                               DisplayData(MessageType.Incoming, "x as 16 bit number:  " + x + "\n");
                               DisplayData(MessageType.Incoming, "y as 16 bit number:  " + y + "\n");

                           }//if
                        */

                         //  DisplayData(MessageType.Incoming, "Incoming: " + comBuffer[0] + "\n");
                     //   }

                    }
                
                  //  DisplayData(MessageType.Incoming, comBuffer[0] + "\n");
                 
                    break;
                default:

                    //read data waiting in the buffer
                    string str = comPort.ReadExisting();
                    //display the data to the user
                 //   DisplayData(MessageType.Incoming, str + "\n");
                    
                    break;
            }

         /*
            
            //retrieve number of bytes in the buffer
            int bytes2 = comPort.BytesToRead;
            //create a byte array to hold the awaiting data
            byte[] comBuffer2 = new byte[bytes2];
            //read the data and store it
            comPort.Read(comBuffer2, 0, bytes2);
            //display the data to the user
            DisplayData(MessageType.Incoming, ByteToHex(comBuffer2) + "\n");



            if (bytes2 >= 5)
            {
                bool[] test = new bool[8];
                test = convertToBits(comBuffer2[5]);
               // _displayWindow.AppendText("\ntest:");
                /*
                for (int i = test.Length - 1; i >= 0; i--)
                {
                    if (test[i] == true)
                        _displayWindow.AppendText("1 ");
                    if (test[i] == false)
                        _displayWindow.AppendText("0 ");
                }//for
                 
                _displayWindow.AppendText("/n");
                

                  
                test = convertToBits(comBuffer2[6]);
               // _displayWindow.AppendText("\ntest:");

                /*
                for (int i = test.Length - 1; i >= 0; i--)
                {
                    if (test[i] == true)
                        _displayWindow.AppendText("1 ");
                    if (test[i] == false)
                        _displayWindow.AppendText("0 ");
                }//for
                
                  
                _displayWindow.AppendText("\n");
            
                
            }//if
        

        /*
            for (int i = 0; i < comBuffer2.Length; i++)
            {
                //     _displayWindow.AppendText("\n==> input[" + i + "] is: " + comBuffer2[i] + "\n");

            }
            */
        }
        #endregion
    }
}
