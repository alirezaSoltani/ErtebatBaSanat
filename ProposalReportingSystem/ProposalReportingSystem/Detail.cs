using System;
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


            this.loginUserNCode = loginUserNCode;
            dbh = new DataBaseHandler(/*this.loginUserNCode*/);

            fileName = proposal.FileName;
            detailPersianTitleTxtbx.Text = proposal.PersianTitle;
            detailLatinTitleTxtbx.Text = proposal.EngTitle;
            detailExecutorTxtbx.Text = proposal.TeacherFullName;
            detailKeywordTxtbx.Text = proposal.KeyWord;
            detailExecutor2Txtbx.Text = proposal.Executor2;
            detailCoExecutorTxtbx.Text = proposal.CoExecutor;

            detailEditionNumberTxtbx.Text = proposal.Edition.ToString();
            detailStartDateTxtbx.Text = proposal.StartDate;
            detailPropertyTxtbx.Text = proposal.PropertyType;
            detailOrganizationTxtbx.Text = dbh.getEmployerName(proposal.Employer);

            detailDurationTxtbx.Text = proposal.Duration.ToString();
            detailRegisterTypeTxtbx.Text = proposal.RegisterType;
            detailValueTxtbx.Text = proposal.Value.ToString();

            detailProcedureTypeTxtbx.Text = proposal.ProcedureType;
            detailProposalTypeTxtbx.Text = proposal.ProposalType;
            detailStatusTxtbx.Text = proposal.Status;

            detailRegistrantTxtbx.Text = proposal.RegistrantName;

            detailSenderNameTxtbx.Text = dbh.getSenderName();
            detailSenderGradeTxtbx.Text = dbh.getSenderGrade();


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
                try
                {
                    if (saveFileDialog1.FileName != "")
                    {
                        string responseMessage = dbh.downloadFile(fileName, saveFileDialog1.FileName);
                       
                        if (responseMessage.Contains("complete"))
                        {
                            System.Diagnostics.Process.Start(saveFileDialog1.FileName);

                            string context = "فایل پروپوزال در محل مورد نظر ذخیره شد";
                            Alert alert = new Alert(context, "bluegray", 2);
                        }
                        else
                        {
                            string context = "فایل پروپوزال موجود نمی باشد";
                            Alert alert = new Alert(context, "bluegray", 2);
                        }
                    }
                    else
                    {
                        string context = "نام فایل را وارد کنید ";
                        Alert alert = new Alert(context, "darkred", 2);
                    }
                }
                catch(Exception ex)
                {
                    string context = "اشکال در فایل پروپوزال";
                    Alert alert = new Alert(context, "bluegray", 2);
                }
                
            }
        }

        private void detailPrintBtn_Click(object sender, EventArgs e)
        {
            if(detailRecieverNameTxtbx.Text == "")
            {
                string context = "عنوانی برای گیرنده نامه وارد کنید";
                Alert alert = new Alert(context, "bluegray", 2);
            }
            else if (detailRecieverGradeTxtbx.Text == "")
            {
                string context = "عنوانی برای سمت گیرنده نامه وارد کنید";
                Alert alert = new Alert(context, "bluegray", 2);
            }
            else if (detailSenderNameTxtbx.Text == "")
            {
                string context = "عنوانی برای فرستنده نامه وارد کنید";
                Alert alert = new Alert(context, "bluegray", 2);
            }
            else if (detailSenderGradeTxtbx.Text == "")
            {
                string context = "عنوانی برای سمت فرستنده نامه وارد کنید";
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

                    report.Dictionary.Variables["employer"].Value = detailRecieverGradeTxtbx.Text;
                    report.Dictionary.Variables["recieverName"].Value = detailRecieverNameTxtbx.Text;
                    report.Dictionary.Variables["persianTitle"].Value = prop.PersianTitle.ToString();
                    report.Dictionary.Variables["englishTitle"].Value = prop.EngTitle.ToString();
                    report.Dictionary.Variables["executorName"].Value = "که توسط " + dbh.getExecutorName(prop.Executor) + " عضو محترم هیات علمی دانشکده "
                                                                        + dbh.getExecutorFaculty(prop.Executor) + " این دانشگاه ارائه گردیده است، ارسال میگردد."
                                                                        + " خواهشمند است دستور فرماييد اقدام مقتضي معمول و از نتيجه امر اين معاونت را مطلع فرمايند  " ;
                    //report.Dictionary.Variables["moderatorName"].Value = detailSenderTxtbx.Text;
                    //report.Dictionary.Variables["moderatorGrade"].Value = detailSenderGradeTxtbx.Text;
                    report.Dictionary.Variables["moderatorName"].Value = detailSenderNameTxtbx.Text.ToString();
                    report.Dictionary.Variables["moderatorGrade"].Value = detailSenderGradeTxtbx.Text.ToString();

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

        private void detailValueTxtbx_TextChanged(object sender, EventArgs e)
        {
            if (detailValueTxtbx.Text == "")
            {
                detailValueTxtbx.BackColor = Color.White;
            }
            else
            {
                detailValueTxtbx.Text = string.Format("{0:n0}", double.Parse(detailValueTxtbx.Text.ToString()));
                detailValueTxtbx.SelectionStart = detailValueTxtbx.Text.Length;
                detailValueTxtbx.SelectionLength = 0;
            }
        }
    }
}
