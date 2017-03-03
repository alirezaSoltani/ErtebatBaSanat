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
    public partial class Detail : Form
    {
        public Detail()
        {
            InitializeComponent();
        }

        public Detail(Proposal proposal)
        {
            InitializeComponent();

            detailPersianTitleTxtbx.Text = proposal.PersianTitle;
            detailLatinTitleTxtbx.Text = proposal.EngTitle;
            detailKeywordTxtbx.Text = proposal.KeyWord;
            detailExecutor2Txtbx.Text = proposal.Executor2;
            detailCoExecutorTxtbx.Text = proposal.CoExecutor;

            detailStartDateLbl2.Text = proposal.StartDate;
            detailPropertyLbl2.Text = proposal.PropertyType;
            detailOrganizationLbl2.Text = proposal.Employer.ToString();

            detailDurationLbl2.Text = proposal.Duration.ToString();
            detailRegisterTypeLbl2.Text = proposal.RegisterType;
            detailValueLbl2.Text = proposal.Value.ToString();

            detailProcedureTypeLbl2.Text = proposal.ProcedureType;
            detailProposalTypeLbl2.Text = proposal.ProposalType;
            detailStatusLbl2.Text = proposal.Status;

            detailRegistrantLbl2.Text = proposal.Registrant.ToString();
        }

        private void detailCloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
