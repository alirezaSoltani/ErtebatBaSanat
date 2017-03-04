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
        private DataBaseHandler dbh = new DataBaseHandler();
        private static string fileName;
        public Detail()
        {
            InitializeComponent();

        }

        public Detail(Proposal proposal)
        {
            InitializeComponent();
            fileName = proposal.FileName;
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

        private void detailOutputBtn_Click(object sender, EventArgs e)
        {


            if (fileName.Contains(".docx"))
            {
                saveFileDialog1.Filter = "Word File|*.docx";

            }
            else if (fileName.Contains(".doc"))
            {
                saveFileDialog1.Filter = "Word File|*.doc";

            }
            if (fileName.Contains(".pdf"))
            {
                saveFileDialog1.Filter = "PDF File|*.pdf";

            }
            saveFileDialog1.Title = "انتخاب مسیر دانلود فایل";
            saveFileDialog1.FileName = detailPersianTitleTxtbx.Text;


            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.FileName != "")
                {
                    dbh.downloadFile(fileName, saveFileDialog1.FileName);
                    System.Diagnostics.Process.Start(saveFileDialog1.FileName);

                    MessageBox.Show("دانلود شد.");
                }
                else
                {
                    MessageBox.Show("نام فایل را وارد کنید .");
                }
            }
        }
    }
}
