using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Steering;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        RobotSteering RBsteer = new RobotSteering();
        CommunicationManager commMC = new CommunicationManager();
        public Form1()
        {
            cmdOpen.Enabled = false;
            cmdClose.Enabled = true;
            commMC.DisplayWindow = rtbDisplay;
            InitializeComponent();
        }

        public void SetTextbox9(byte _myCommand)
        {
            textBox9.Text = "" + _myCommand;
        }

        public void SetTextbox10(byte _myCommand)
        {
            textBox10.Text = "" + _myCommand;
        }

        public void SetTextbox11(byte _myCommand)
        {
            textBox11.Text = "" + _myCommand;
        }

        public void SetTextbox12(byte _myCommand)
        {
            textBox12.Text = "" + _myCommand;
        }


        

        private void cboBaud_SelectedIndexChanged(object sender, EventArgs e)
        {
            RBsteer.OpenCom();
            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            RBsteer.UpdateTicker(sender, e);
            textBox6.Text = RBsteer.time;
        }

        private void SetControlState()
        {
            rdoText.Checked = true;
            cmdClose.Enabled = false;
        }


        private void rdoHex_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoHex.Checked == true)
            {
                commMC.CurrentTransmissionType = CommunicationManager.TransmissionType.Hex;
            }
            if (rdoByte.Checked == true)
            {
                commMC.CurrentTransmissionType = CommunicationManager.TransmissionType.Byte;
            }
            if (rdoText.Checked == true)
            {
                commMC.CurrentTransmissionType = CommunicationManager.TransmissionType.Text;
            }

        }   //select com type hex,byte,text

        private void cmdClose_Click(object sender, EventArgs e)
        {
            cmdClose.Enabled = true;
        }

        private void cmdOpen_Click(object sender, EventArgs e)
        {

        }

        private void button_direction_Click(object sender, EventArgs e)
        {
            RBsteer.Direction();

        }

        private void button_slow_Click(object sender, EventArgs e)
        {
            RBsteer.slow();
        }

        private void button_medium_Click(object sender, EventArgs e)
        {
            RBsteer.medium();
        }

        private void button_fast_Click(object sender, EventArgs e)
        {
            RBsteer.fast();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }


        

        
    }
}
