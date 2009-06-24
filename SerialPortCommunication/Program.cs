using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PCComm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmMain myForm = new frmMain();
            Application.Run(myForm);



            // updating states:

            myForm.Update();

        }
    }
}
