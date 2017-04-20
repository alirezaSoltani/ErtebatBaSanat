﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Stimulsoft.Report;

namespace ProposalReportingSystem
{
    public partial class Detail : Form
    {
        private DataBaseHandler dbh; 
        private static string fileName;
        private long loginUserNCode;
        private Proposal prop = new Proposal();

        public Detail()
        {
            InitializeComponent();
        }

        public Detail(Proposal proposal, long loginUserNCode)
        {
            InitializeComponent();

            prop = proposal;


            //MessageBox.Show(prop.RegisterType);
            this.loginUserNCode = loginUserNCode;
            dbh = new DataBaseHandler(/*this.loginUserNCode*/);

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

        private void detailPrintBtn_Click(object sender, EventArgs e)
        {
            if(detailRecieverTxtbx.Text == "")
            {
                string context = "عنوانی برای گیرنده نامه وارد کنید";
                Alert alert = new Alert(context, "bluegray", 2);
            }
            /*else if (detailSenderTxtbx.Text == "")
            {
                string context = "عنوانی برای فرستنده نامه وارد کنید";
                Alert alert = new Alert(context, "bluegray", 2);
            }*/
            else
            {
                try
                {
                    StiReport report = new StiReport();
                    report.Load(Application.StartupPath + @"\Report2.mrt");

                    detailPrintBtn.Enabled = false;
                    detailPrintBtn.Enabled = true;

                    report.Dictionary.Variables["employer"].Value = detailRecieverTxtbx.Text;
                    report.Dictionary.Variables["persianTitle"].Value = prop.PersianTitle.ToString();
                    report.Dictionary.Variables["englishTitle"].Value = prop.EngTitle.ToString();
                    report.Dictionary.Variables["executorName"].Value = "که توسط " + dbh.getExecutorName(prop.Executor) + " عضو محترم هیات علمی دانشکده "
                                                                        + dbh.getExecutorFaculty(prop.Executor) + " این دانشگاه ارائه گردیده است، ارسال میگردد."
                                                                        + " خواهشمند است دستور فرماييد اقدام مقتضي معمول و از نتيجه امر اين معاونت را مطلع فرمايند  " ;
                    //report.Dictionary.Variables["moderatorName"].Value = detailSenderTxtbx.Text;
                    //report.Dictionary.Variables["moderatorGrade"].Value = detailSenderGradeTxtbx.Text;
                    report.Dictionary.Variables["moderatorName"].Value = "افشین قنبرزاده";
                    report.Dictionary.Variables["moderatorGrade"].Value = "رئيس گروه كارآفريني و ارتباط با صنعت دانشگاه شهید چمران اهواز";

                    try
                    {
                        report.Compile();
                        report.Show();
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show(ee.Message.ToString());
                        string context = "خطای نام فرستنده یا گیرنده";
                        Alert alert = new Alert(context, "bluegray", 15);
                    }
                }
                catch(Exception ee)
                {
                    string context = "خطای فایل نامه";
                    Alert alert = new Alert(context, "bluegray", 15);
                }
            }
        }
    }
}
