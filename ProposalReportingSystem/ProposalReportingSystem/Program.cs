using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ProposalReportingSystem
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
            //Application.Run(new Waiting());
            //Application.Run(new Form1());
            try
            {
                Application.Run(new Login());
            }
            catch (ArgumentOutOfRangeException e)
            {
                if (e.Message.Contains("'1401'"))
                {
                    MessageBox.Show("hi");
                }
            }
            //Application.Run(new Toast());
            //Application.Run(new Detail());

        }
    }
}
