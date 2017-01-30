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
    public partial class Login : Form
    {
        private string username, password;

        public Login()
        {
            InitializeComponent();
        }

        private void loginEnterBtn_MouseEnter(object sender, EventArgs e)
        {
            loginEnterBtn.BackColor = Color.Gray;
        }

        private void loginClosePbx_MouseEnter(object sender, EventArgs e)
        {
            loginClosePbx.BackgroundImage = ProposalReportingSystem.Properties.Resources.login_close_white;
            loginClosePbx.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void loginClosePbx_MouseLeave(object sender, EventArgs e)
        {
            loginClosePbx.BackgroundImage = ProposalReportingSystem.Properties.Resources.login_close_black; ;
            loginClosePbx.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void loginMinimizePbx_MouseEnter(object sender, EventArgs e)
        {
            loginMinimizePbx.BackgroundImage = ProposalReportingSystem.Properties.Resources.login_minimize_white;
            loginMinimizePbx.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void loginMinimizePbx_MouseLeave(object sender, EventArgs e)
        {
            loginMinimizePbx.BackgroundImage = ProposalReportingSystem.Properties.Resources.login_minimize_black;
            loginMinimizePbx.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void loginClosePbx_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginMinimizePbx_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void loginEnterBtn_Click(object sender, EventArgs e)
        {
            
        }
    }
}
