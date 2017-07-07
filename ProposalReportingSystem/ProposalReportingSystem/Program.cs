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
                runApp();
            }
            catch (ArgumentOutOfRangeException e)
            {
                if (e.Message.Contains("'1401'"))
                {
                    PopUp popup;
                    popup = new PopUp("خطای تاریخ ورودی", "تاریخ غیرمجاز: این نسخه از نرم افزار از تاریخ ورودی پشتیبانی نمی کند", "تایید", "", "", "error");
                    popup.ShowDialog();

                    runApp();
                }
            }
            

        }

        static void runApp()
        {
            try
            {
                Application.Run(new Login());
            }
            catch (ArgumentOutOfRangeException e)
            {
                if (e.Message.Contains("'1401'"))
                {
                    PopUp popup;
                    popup = new PopUp("خطای تاریخ ورودی", "تاریخ غیرمجاز: این نسخه از نرم افزار از تاریخ ورودی پشتیبانی نمی کند", "تایید", "", "", "error");
                    popup.ShowDialog();

                    runApp();
                }
            }
        }
    }
}
