using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProposalReportingSystem
{
    public partial class Waiting : Form
    {
       

        private Global gl = new Global();
        public int i = 0;


        public Waiting()
        {
            InitializeComponent();

            int systemWidth = SystemInformation.PrimaryMonitorSize.Width;   
            int systemHeight = SystemInformation.PrimaryMonitorSize.Height;
            this.StartPosition = FormStartPosition.Manual;
            this.SetBounds((40 * systemWidth) / 100, (25 * systemHeight) / 100, (13* systemWidth) / 100, (14 * systemHeight) / 100);
            
            gl.setSize(circularProgress1, 13, 20, 100, 55);
            gl.setSize(waitLbl, 3, 70, 100, 50);
        }

        private void Waiting_Load(object sender, EventArgs e)
        {
            timer1.Start();
            waitLbl.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            backgroundWorker1.RunWorkerAsync();

            if (i == -1)
            {
                this.Close();
            }

            i += 11;
            if (i >98)
            {
                i = 10;

                if (circularProgress1.ProgressColor == Color.Blue)
                {
                    circularProgress1.ProgressColor = Color.Navy;
                }
                else if (circularProgress1.ProgressColor == Color.Navy)
                {
                    circularProgress1.ProgressColor = Color.Indigo;
                }
                else if (circularProgress1.ProgressColor == Color.Indigo)
                {
                    circularProgress1.ProgressColor = Color.MidnightBlue;
                }
                else if (circularProgress1.ProgressColor == Color.MidnightBlue)
                {
                    circularProgress1.ProgressColor = Color.DarkBlue;
                }
                else if (circularProgress1.ProgressColor == Color.DarkBlue)
                {
                    circularProgress1.ProgressColor = Color.Blue;
                }

                if (waitLbl.Text == ".لطفا کمی صبر کنید")
                {
                    waitLbl.Text = "..لطفا کمی صبر کنید";
                }
                else if (waitLbl.Text == "..لطفا کمی صبر کنید")
                {
                    waitLbl.Text = "...لطفا کمی صبر کنید";
                }
                else if (waitLbl.Text == "...لطفا کمی صبر کنید")
                {
                    waitLbl.Text = ".لطفا کمی صبر کنید";
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker1.ReportProgress(i);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            circularProgress1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //this.Hide();
        }
    }
}
