using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProposalReportingSystem
{
    public partial class Form1 : Form
    {
        private int systemWidth;    //related to setSize
        private int systemHeight;   //related to setSize

        private Global gl = new Global();

        public Form1()
        {
            InitializeComponent();

            systemWidth = SystemInformation.PrimaryMonitorSize.Width;          //related to setSize
            systemHeight = SystemInformation.PrimaryMonitorSize.Height;        //related to setSize
            this.SetBounds(0, 0, systemWidth, ((955 * systemHeight) / 1000));  //related to setSize
            gl.setSize(mainTabControl, 0, 0, 998, 1000);                       //related to setSize
           // mainTabControl.TabHorizontalSpacing = ((2 * systemWidth) / 1000);  //related to setSize


            //////////////add proposal design///////////////
            gl.setSize(addProposalPanel, 0, 1, 875, 1000);
            gl.setSize(addProposalAddGp, 20, 3, 826, 250);
            gl.setSize(superTabControlPanel2, 0, 1, 880, 1000);
            //addProposalPanel.SetBounds(((0 * systemWidth) / 1000), ((1 * systemHeight) / 1000), ((870 * systemWidth) / 1000), ((1000 * systemHeight) / 1000));
            //addProposalAddGp.SetBounds(((20 * systemWidth) / 1000), ((3 * systemHeight) / 1000), ((826 * systemWidth) / 1000), ((250 * systemHeight) / 1000));

        }
    }
}