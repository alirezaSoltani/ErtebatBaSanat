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
        private DataBaseHandler dbh; 
        private static string fileName;
        private long loginUserNCode;

        public Detail()
        {
            InitializeComponent();
        }

        public Detail(Proposal proposal, long loginUserNCode)
        {
            InitializeComponent();

            this.loginUserNCode = loginUserNCode;
            //dbh = new DataBaseHandler(this.loginUserNCode);

            fileName = proposal.FileName;
            detailPersianTitleTxtbx.Text = proposal.PersianTitle;
            detailLatinTitleTxtbx.Text = proposal.EngTitle;
            detailKeywordTxtbx.Text = proposal.KeyWord;
            detailExecutor2Txtbx.Text = proposal.Executor2;
            detailCoExecutorTxtbx.Text = proposal.CoExecutor;

            detailStartDateTxtbx.Text = proposal.StartDate;
            detailPropertyTxtbx.Text = proposal.PropertyType;
            detailOrganizationTxtbx.Text = proposal.Employer.ToString();

            detailDurationTxtbx.Text = proposal.Duration.ToString();
            detailRegisterTypeTxtbx.Text = proposal.RegisterType;
            detailValueTxtbx.Text = proposal.Value.ToString();

            detailProcedureTypeTxtbx.Text = proposal.ProcedureType;
            detailProposalTypeTxtbx.Text = proposal.ProposalType;
            detailStatusTxtbx.Text = proposal.Status;

            detailRegistrantTxtbx.Text = proposal.Registrant.ToString();


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
