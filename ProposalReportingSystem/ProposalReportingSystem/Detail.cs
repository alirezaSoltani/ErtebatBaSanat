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
using FastReport;
using FastReport.Data;

namespace ProposalReportingSystem
{
    public partial class Detail : Form
    {
        private DataBaseHandler dbh; 
        private static string fileName;
        private long loginUserNCode;
        private User loginUser; 
        private Proposal prop = new Proposal();

        public Detail()
        {
            InitializeComponent();
        }

        public Detail(Proposal proposal,User user)
        {
            InitializeComponent();
            loginUser = user;
            if(user.U_otherAccess != 0)
            {
                detailPreviewBtn.Enabled = false;
                detailFastPrintBtn.Enabled = false;
            }
            prop = proposal;

            this.loginUserNCode = user.U_NCode;
            dbh = new DataBaseHandler(user);

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

            detailRegistrantTxtbx.Text = proposal.RegistrantName ;

            detailLetterDateDts.Value = DateTime.Now;

            detailSenderNameTxtbx.Text = dbh.getSenderName();
            detailSenderGradeTxtbx.Text = dbh.getSenderGrade();
            detailRecieverNameTxtbx.Focus();

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

        

        private void detailFastPrintBtn_Click(object sender, EventArgs e)
        {
            if (detailRecieverNameTxtbx.Text == "")
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
                    /*StiReport report = new StiReport();
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
                        if (loginUserNCode == 999999999) // to show exceptin for admin
                        {
                            MessageBox.Show(ee.Message);
                        }
                        MessageBox.Show(ee.Message.ToString());
                        string context = "خطای نام فرستنده یا گیرنده";
                        Alert alert = new Alert(context, "bluegray", 15);
                    }*/


                    Report report = new Report();
                    report.Load("report3.frx");
                    report.SetParameterValue("l_date", detailLetterDateDts.GetText("yyyy/MM/dd"));
                    report.SetParameterValue("l_number", detailLetterNumberTxtbx.Text);

                    if (detailAttachmentChb.Checked)
                    {
                        report.SetParameterValue("l_attachment", "دارد");
                    }
                    else
                    {
                        report.SetParameterValue("l_attachment", "ندارد");
                    }

                    report.SetParameterValue("l_recieverName", detailRecieverNameTxtbx.Text);
                    report.SetParameterValue("l_recieverGrade", detailRecieverGradeTxtbx.Text);

                    if (detailMaleExecutorRb.Checked == true)
                    {
                        report.SetParameterValue("l_beforeTitle", "         بدین وسیله «یک نسخه» فرم مشروح پیشـنهاد پـروژه پژوهشـی " + "جنـاب آقای " + detailExecutorTxtbx.Text + " عضــو محتــرم هیــات علمــی دانشــکده " + dbh.getExecutorFaculty(prop.Executor) + " تحت عنوان:");
                    }
                    else if (detailFemaleExecutorRb.Checked == true)
                    {
                        report.SetParameterValue("l_beforeTitle", "         بدین وسیله «یک نسخه» فرم مشروح پیشـنهاد پـروژه پژوهشـی " + "سرکار خانم " + detailExecutorTxtbx.Text + " عضــو محتــرم هیــات علمــی دانشــکده " + dbh.getExecutorFaculty(prop.Executor) + " تحت عنوان:");
                    }
                    else
                    {
                        report.SetParameterValue("l_beforeTitle", "         بدین وسیله «یک نسخه» فرم مشروح پیشـنهاد پـروژه پژوهشـی " + detailExecutorTxtbx.Text + " عضــو محتــرم هیــات علمــی دانشــکده " + dbh.getExecutorFaculty(prop.Executor) + " تحت عنوان:");
                    }

                    report.SetParameterValue("l_title", "«" + detailPersianTitleTxtbx.Text + "»");
                    report.SetParameterValue("l_afterTitle", "به حضور ایفاد می گردد. خواهشمند است ضمن بررسی و در صورت تایید نتیجه امر جهت تهیه نسخ مورد نیاز قرارداد و انعقاد آن به این مدیرت ابلاغ گردد.");

                    report.SetParameterValue("l_senderName", detailSenderNameTxtbx.Text);
                    report.SetParameterValue("l_senderGrade", detailSenderGradeTxtbx.Text);

                    if (detailMaleRegistrantRb.Checked == true)
                    {
                        report.SetParameterValue("l_registrant", "کارشناس مسئول پیگیری: " + "آقای" + " " + loginUser.U_LName);
                    }
                    else if (detailFemaleRegistrantRb.Checked == true)
                    {
                        report.SetParameterValue("l_registrant", "کارشناس مسئول پیگیری: " + "خانم" + " " + loginUser.U_LName);
                    }
                    else
                    {
                        report.SetParameterValue("l_registrant", "کارشناس مسئول پیگیری: " + loginUser.U_LName);
                    }
                    report.SetParameterValue("l_registrantInternal", "داخلی:");
                    report.SetParameterValue("l_registrantInternalNumber", loginUser.U_Tel);
                    report.SetParameterValue("l_registrantEmail", loginUser.U_Email);

                    report.SetParameterValue("l_psText", detailLetterPSTxtbx.Text);

                    report.Print();
                }
                catch (Exception ee)
                {
                    if (loginUserNCode == 999999999) // to show exceptin for admin
                    {
                        MessageBox.Show(ee.Message);
                    }
                    string context = "خطای فایل نامه";
                    Alert alert = new Alert(context, "bluegray", 15);
                }
            }
        }

        private void detailPreviewBtn_Click(object sender, EventArgs e)
        {
            if (detailRecieverNameTxtbx.Text == "")
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
                    /*StiReport report = new StiReport();
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
                        if (loginUserNCode == 999999999) // to show exceptin for admin
                        {
                            MessageBox.Show(ee.Message);
                        }
                        MessageBox.Show(ee.Message.ToString());
                        string context = "خطای نام فرستنده یا گیرنده";
                        Alert alert = new Alert(context, "bluegray", 15);
                    }*/


                    Report report = new Report();
                    report.Load("report3.frx");
                    report.SetParameterValue("l_date", detailLetterDateDts.GetText("yyyy/MM/dd"));
                    report.SetParameterValue("l_number", detailLetterNumberTxtbx.Text);

                    if (detailAttachmentChb.Checked)
                    {
                        report.SetParameterValue("l_attachment", "دارد");
                    }
                    else
                    {
                        report.SetParameterValue("l_attachment", "ندارد");
                    }

                    report.SetParameterValue("l_recieverName", detailRecieverNameTxtbx.Text);
                    report.SetParameterValue("l_recieverGrade", detailRecieverGradeTxtbx.Text);

                    if (detailMaleExecutorRb.Checked == true)
                    {
                        report.SetParameterValue("l_beforeTitle", "         بدین وسیله «یک نسخه» فرم مشروح پیشـنهاد پـروژه پژوهشـی " + "جنـاب آقای " + detailExecutorTxtbx.Text + " عضــو محتــرم هیــات علمــی دانشــکده " + dbh.getExecutorFaculty(prop.Executor) + " تحت عنوان:");
                    }
                    else if (detailFemaleExecutorRb.Checked == true)
                    {
                        report.SetParameterValue("l_beforeTitle", "         بدین وسیله «یک نسخه» فرم مشروح پیشـنهاد پـروژه پژوهشـی " + "سرکار خانم " + detailExecutorTxtbx.Text + " عضــو محتــرم هیــات علمــی دانشــکده " + dbh.getExecutorFaculty(prop.Executor) + " تحت عنوان:");
                    }
                    else
                    {
                        report.SetParameterValue("l_beforeTitle", "         بدین وسیله «یک نسخه» فرم مشروح پیشـنهاد پـروژه پژوهشـی " + detailExecutorTxtbx.Text + " عضــو محتــرم هیــات علمــی دانشــکده " + dbh.getExecutorFaculty(prop.Executor) + " تحت عنوان:");
                    }

                    report.SetParameterValue("l_title", "«" + detailPersianTitleTxtbx.Text + "»");
                    report.SetParameterValue("l_afterTitle", "به حضور ایفاد می گردد. خواهشمند است ضمن بررسی و در صورت تایید نتیجه امر جهت تهیه نسخ مورد نیاز قرارداد و انعقاد آن به این مدیرت ابلاغ گردد.");

                    report.SetParameterValue("l_senderName", detailSenderNameTxtbx.Text);
                    report.SetParameterValue("l_senderGrade", detailSenderGradeTxtbx.Text);

                    if (detailMaleRegistrantRb.Checked == true)
                    {
                        report.SetParameterValue("l_registrant", "کارشناس مسئول پیگیری: " + "آقای" + " " + loginUser.U_LName);
                    }
                    else if (detailFemaleRegistrantRb.Checked == true)
                    {
                        report.SetParameterValue("l_registrant", "کارشناس مسئول پیگیری: " + "خانم" + " " + loginUser.U_LName);
                    }
                    else
                    {
                        report.SetParameterValue("l_registrant", "کارشناس مسئول پیگیری: " + loginUser.U_LName);
                    }
                    report.SetParameterValue("l_registrantInternal", "داخلی:");
                    report.SetParameterValue("l_registrantInternalNumber", loginUser.U_Tel);
                    report.SetParameterValue("l_registrantEmail", loginUser.U_Email);

                    report.SetParameterValue("l_psText", detailLetterPSTxtbx.Text);

                    report.Show();
                }
                catch (Exception ee)
                {
                    if (loginUserNCode == 999999999) // to show exceptin for admin
                    {
                        MessageBox.Show(ee.Message);
                    }
                    string context = "خطای فایل نامه";
                    Alert alert = new Alert(context, "bluegray", 15);
                }
            }
        }

        private void detailExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void detailOutputFileBtn_Click(object sender, EventArgs e)
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
                catch (Exception ex)
                {
                    if (loginUserNCode == 999999999) // to show exceptin for admin
                    {
                        MessageBox.Show(ex.Message);
                    }
                    string context = "اشکال در فایل پروپوزال";
                    Alert alert = new Alert(context, "bluegray", 2);
                }

            }
        }
    }
}
