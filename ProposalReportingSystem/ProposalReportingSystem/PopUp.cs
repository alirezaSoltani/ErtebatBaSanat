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
    public partial class PopUp : Form
    {
        public PopUp()
        {
            InitializeComponent();
        }
        public PopUp(string title, string context, string leftBtnText, string rightBtnText, string icon)
        {
            InitializeComponent();

            this.Text = title;
            popUpContextLbl.Text = context;
            popUpConfirmBtn.Text = leftBtnText;
            popUpCancelBtn.Text = rightBtnText;

            if(icon.Equals("error"))
            {
                popUpIconPbx.BackgroundImage = ProposalReportingSystem.Properties.Resources.error;
            }

            else if (icon.Equals("info"))
            {
                popUpIconPbx.BackgroundImage = ProposalReportingSystem.Properties.Resources.information;
            }

            else if (icon.Equals("success"))
            {
                popUpIconPbx.BackgroundImage = ProposalReportingSystem.Properties.Resources.success;
            }
        }

        private void popUpCancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void popUpConfirmBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
    }
}
