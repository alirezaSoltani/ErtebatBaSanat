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
        public Form1()
        {
            InitializeComponent();
        }

        private void sideNavPanel1_Paint(object sender, PaintEventArgs e)
        {
            Employers p = new Employers("s");
            p.OrgName="dad";
            string s = p.OrgName;
        }
    }
}
