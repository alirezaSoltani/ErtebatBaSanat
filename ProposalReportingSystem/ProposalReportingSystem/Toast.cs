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
    public partial class Toast : Form
    {
        private Global gl = new Global();
        private bool toastUp = true;
        private bool toastDown = false;
        private double fadingUpSpeed, fadingDownSpeed;
        private int mainTainTime;
        private int i = 0;

        public Toast()
        {
            InitializeComponent();
        }

        public Toast(string context, double fadeUpSpeed, double fadeDownSpeed,int mainTainTime, string icon)
        {
            InitializeComponent();

            toastContextLbl.Text = context;
            fadingUpSpeed = fadeUpSpeed;
            fadingDownSpeed = fadeDownSpeed;
            this.mainTainTime = mainTainTime;

            if (icon == "error")
            {
                toastIconPb.BackgroundImage = ProposalReportingSystem.Properties.Resources.error;
            }

            else if (icon == "info")
            {
                toastIconPb.BackgroundImage = ProposalReportingSystem.Properties.Resources.information;
            }

            this.Opacity = 0;
            i = 0;
            timer.Start();

            int systemWidth = SystemInformation.PrimaryMonitorSize.Width;          //related to setSize
            int systemHeight = SystemInformation.PrimaryMonitorSize.Height;        //related to setSize
            this.SetBounds(((235 * systemWidth) / 1000), ((840 * systemHeight) / 1000), ((400 * systemWidth) / 1000), ((100 * systemHeight) / 1000));      //related to setSize

            gl.setSize(toastPanel, 0, 0, 400, 100);
            gl.setSize(toastIconPb, 352, 16, 35, 65);
            gl.setSize(toastContextLbl, 10, 15, 335, 70);
        }

        public void showToast(string context, double fadeUpSpeed, double fadeDownSpeed, int mainTainTime, string icon)
        {
            toastContextLbl.Text = context;
            fadingUpSpeed = fadeUpSpeed;
            fadingDownSpeed = fadeDownSpeed;
            this.mainTainTime = mainTainTime;

            if (icon == "error")
            {
                toastIconPb.BackgroundImage = ProposalReportingSystem.Properties.Resources.error;
            }

            else if (icon == "info")
            {
                toastIconPb.BackgroundImage = ProposalReportingSystem.Properties.Resources.information;
            }

            this.Opacity = 0;
            i = 0;
            timer.Start();
            //MessageBox.Show("hello");

            int systemWidth = SystemInformation.PrimaryMonitorSize.Width;          //related to setSize
            int systemHeight = SystemInformation.PrimaryMonitorSize.Height;        //related to setSize
            this.SetBounds(((235 * systemWidth) / 1000), ((840 * systemHeight) / 1000), ((400 * systemWidth) / 1000), ((100 * systemHeight) / 1000));      //related to setSize

            gl.setSize(toastPanel, 0, 0, 400, 100);
            gl.setSize(toastIconPb, 352, 16, 35, 65);
            gl.setSize(toastContextLbl, 10, 15, 335, 70);

            this.Show();
        }


        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1 && toastUp && !toastDown)
            {
                this.Opacity += fadingUpSpeed;
            }

            else if (this.Opacity > 0.99 && !toastDown)
            {
                toastUp = false;
                i++;

                if (i > this.mainTainTime)
                {
                    toastDown = true;
                }
            }

            else
            {
                this.Opacity -= fadingDownSpeed;
                if (this.Opacity < 0.01)
                {
                    timer.Stop();
                    this.Close();
                }
            }
        }
    }
}
