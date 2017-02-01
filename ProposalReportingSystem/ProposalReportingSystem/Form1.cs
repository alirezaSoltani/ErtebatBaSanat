using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using System.Globalization;
using System.IO;

namespace ProposalReportingSystem
{
    public partial class Form1 : Form
    {

        Waiting w = new Waiting();

        private int systemWidth;    //related to setSize
        private int systemHeight;   //related to setSize
        private Global gl = new Global();   //related to setBounds
        private User loginUser = new User();//related to user access and prefrences
        private List<string> comboList = new List<string>();  //related to Loading comboboxes from tables
        private List<Employers> emp = new List<Employers>();  //related to Loading comboboxes from tables
        private bool isNewTeacher = false;  // related to adding proposal when teacher does not exist in the teachers table
        public FTPSetting _inputParameter = new FTPSetting(); //related to upload and download file
        private DateTime myDateTime = DateTime.Now;// Gets the local time, should be replaced by server time

        /// <summary>
        /// Current Values
        /// </summary>
        private string currentSelectedOption ,currentSelectedOption_2, currentSelectedIndex;
        /// <summary>
        /// Current Values
        /// </summary>
        /// 

        // <summary>
        /// 
        
        /// </summary>



        /// <summary>
        /// Data gridview attributes
        /// </summary>
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        private DataBaseHandler dbh = new DataBaseHandler();
        /// <summary>
        /// Data gridview attributes
        /// </summary>


        /// <summary>
        /// username
        /// </summary>
        private long username = 1741936683;
        /// <summary>
        /// username
        /// </summary>



        //***************************Convert time*******************************************\
        /*string geo = addProposalStartdateTimeInput.GeoDate.ToString();
        MessageBox.Show(geo.Substring(0, 10));//---> shamsi to miladi

        string GregorianDate = geo.Substring(0, 10);
        DateTime d = DateTime.Parse(GregorianDate);
        PersianCalendar pc = new PersianCalendar();
        MessageBox.Show(string.Format("{0}-{1:00}-{2:00}", pc.GetYear(d), pc.GetMonth(d), pc.GetDayOfMonth(d)));//---> miladi to shamsi*/

        //***************************Convert time*******************************************\





        public Form1()
        {
            
            InitializeComponent();

            //homePanel.Visible = false;
            //this.Enabled = false;

            //systemWidth = SystemInformation.PrimaryMonitorSize.Width;          //related to setSize
            //systemHeight = SystemInformation.PrimaryMonitorSize.Height;        //related to setSize
            //this.SetBounds(0, 0, systemWidth, ((955 * systemHeight) / 1000));  //related to setSize
            //gl.setSize(mainPage, 0, 0, 995, 925);                              //related to setSize

            

            ///*PopUp p = new PopUp("title", "context", "left", "center", "right" , "error");
            //p.ShowDialog();
            //if(p.DialogResult == DialogResult.Yes)
            //{
            //    MessageBox.Show("yes");
            //}

            //else
            //{
            //    MessageBox.Show("no");
            //}*/


            



            ////*****************************************************************************************************//
            ////                                               DESIGN                                                //
            ////*****************************************************************************************************//


            //////////////////////////Home design////////////////////
            //gl.setSize(homePanel, 0, 1, 900, 930);
            //gl.setSize(homeAapInfoGp, 175, 70, 500, 300);
            //gl.setSize(homeTimeDateGp, 80, 400, 700, 400);
            //gl.setSize(homeAppNameLbl, 100, 15, 425, 30);
            //gl.setSize(homeUserProfileLbl, 210, 75, 85, 85);
            //gl.setSize(homeUserNameLbl, 210, 160, 125, 30);
            //gl.setSize(homeWelcomeLbl, 225, 195, 85, 25);
            //gl.setSize(analogClockControl1, 70, 25, 180, 180);
            //gl.setSize(monthCalendar1, 300, 50, 320, 250);
            /////////////////////////Home design/////////////////////


            ////////////////Add proposal design///////////////
            //gl.setSize(addProposalPanel, 0, 1, 900, 930);
            //gl.setSize(addProposalAddGp, 22, 15, 826, 445);
            //gl.setSize(addProposalShowGp, 22, 470, 826, 425);
            //gl.setSize(superTabControlPanel2, 0, 1, 880, 1000);
            //gl.setSize(addProposalShowDgv, 5, 5, 810, 380);

            //gl.setSize(addProposalExecutorNcodeLbl, 720, 10, 60, 25);
            //gl.setSize(addProposalExecutorNcodeTxtbx, 600, 10, 110, 25);
            //gl.setSize(addProposalSearchBtn, 550, 10, 45, 25);

            //gl.setSize(addProposalExecutorFNameLbl, 720, 50, 60, 25);
            //gl.setSize(addProposalExecutorFNameTxtbx, 550, 50, 160, 25);

            //gl.setSize(addProposalExecutorLNameLbl, 720, 90, 60, 25);
            //gl.setSize(addProposalExecutorLNameTxtbx, 550, 90, 160, 25);

            //gl.setSize(addProposalExecutorFacultyLbl, 720, 130, 60, 25);
            //gl.setSize(addProposalExecutorFacultyCb, 550, 130, 160, 25);

            //gl.setSize(addProposalExecutorEGroupLbl, 720, 170, 60, 25);
            //gl.setSize(addProposalExecutorEGroupCb, 550, 170, 160, 25);

            //gl.setSize(addProposalExecutorEDegLbl, 720, 210, 60, 25);
            //gl.setSize(addProposalExecutorEDegCb, 550, 210, 160, 25);

            //gl.setSize(addProposalExecutorEmailLbl, 720, 250, 60, 25);
            //gl.setSize(addProposalExecutorEmailTxtbx, 550, 250, 160, 25);

            //gl.setSize(addProposalExecutorMobileLbl, 720, 290, 60, 25);
            //gl.setSize(addProposalExecutorMobileTxtbx, 550, 290, 160, 25);

            //gl.setSize(addProposalExecutorTel1Lbl, 720, 330, 60, 25);
            //gl.setSize(addProposalExecutorTel1Txtbx, 550, 330, 160, 25);

            //gl.setSize(addProposalExecutorTel2Lbl, 720, 370, 60, 25);
            //gl.setSize(addProposalExecutorTel2Txtbx, 550, 370, 160, 25);

            //gl.setSize(addProposalPersianTitleLbl, 460, 10, 60, 25);
            //gl.setSize(addProposalPersianTitleTxtbx, 290, 10, 160, 25);

            //gl.setSize(addProposalEnglishTitleLbl, 460, 50, 60, 25);
            //gl.setSize(addProposalEnglishTitleTxtbx, 290, 50, 160, 25);

            //gl.setSize(addProposalKeywordsLbl, 460, 90, 60, 25);
            //gl.setSize(addProposalKeywordsTxtbx, 290, 90, 160, 75);

            //gl.setSize(addProposalExecutor2Lbl, 460, 180, 60, 25);
            //gl.setSize(addProposalExecutor2Txtbx, 290, 180, 160, 75);

            //gl.setSize(addProposalCoexecutorLbl, 460, 270, 60, 25);
            //gl.setSize(addProposalCoexecutorTxtbx, 290, 270, 160, 85);

            //gl.setSize(addProposalStartdateLbl, 460, 370, 60, 25);
            //gl.setSize(addProposalStartdateTimeInput, 290, 370, 160, 35);

            //gl.setSize(addProposalDurationLbl, 200, 10, 60, 25);
            //gl.setSize(addProposalDurationTxtbx, 30, 10, 160, 25);

            //gl.setSize(addProposalProcedureTypeLbl, 200, 50, 60, 25);
            //gl.setSize(addProposalProcedureTypeCb, 30, 50, 160, 25);

            //gl.setSize(addProposalPropertyTypeLbl, 200, 90, 60, 25);
            //gl.setSize(addProposalPropertyTypeCb, 30, 90, 160, 25);

            //gl.setSize(addProposalRegisterTypeLbl, 200, 130, 60, 25);
            //gl.setSize(addProposalRegisterTypeCb, 30, 130, 160, 25);

            //gl.setSize(addProposalTypeLbl, 200, 170, 60, 25);
            //gl.setSize(addProposalProposalTypeCb, 30, 170, 160, 25);

            //gl.setSize(addProposalOrganizationLbl, 200, 210, 60, 25);
            //gl.setSize(addProposalOrganizationNameCb, 30, 210, 120, 25);
            //gl.setSize(addProposalOrganizationNumberCb, 155, 210, 35, 25);

            //gl.setSize(addProposalValueLbl, 200, 250, 60, 25);
            //gl.setSize(addProposalValueTxtbx, 30, 250, 160, 25);

            //gl.setSize(addProposalStatusLbl, 200, 290, 60, 25);
            //gl.setSize(addProposalStatusCb, 30, 290, 160, 25);

            //gl.setSize(addProposalFileLbl, 200, 330, 60, 25);
            //gl.setSize(addProposalFileLinkLbl, 30, 330, 160, 25);

            //gl.setSize(addProposalRegisterBtn, 30, 370, 80, 30);
            //gl.setSize(addProposalClearBtn, 120, 370, 60, 30);
            //gl.setSize(addProposalShowBtn, 190, 370, 70, 30);




            ////********************************************//
            ////////////////Search proposal design///////////////
            //gl.setSize(searchProposalPanel, 0, 1, 900, 930);
            //gl.setSize(searchProposalSearchGp, 22, 15, 826, 445);
            //gl.setSize(searchProposalExecutorInfoGp, 525, 5, 270, 350);
            //gl.setSize(searchProposalProposalInfoGp, 20, 5, 480, 350);
            //gl.setSize(searchProposalShowGp, 22, 470, 826, 425);
            //gl.setSize(superTabControlPanel2, 0, 1, 880, 1000);
            //gl.setSize(searchProposalShowDgv, 5, 5, 810, 380);

            //gl.setSize(searchProposalExecutorNCodeLbl, 720, 70, 60, 25);
            //gl.setSize(searchProposalExecutorNCodeTxtbx, 550, 70, 160, 25);

            //gl.setSize(searchProposalExecutorFNameLbl, 720, 110, 60, 25);
            //gl.setSize(searchProposalExecutorFNameTxtbx, 550, 110, 160, 25);

            //gl.setSize(searchProposalExecutorLNameLbl, 720, 150, 60, 25);
            //gl.setSize(searchProposalExecutorLNameTxtbx, 550, 150, 160, 25);

            //gl.setSize(searchProposalExecutorFacultyLbl, 720, 190, 60, 25);
            //gl.setSize(searchProposalExecutorFacultyCb, 550, 190, 160, 25);

            //gl.setSize(searchProposalExecutorEGroupLbl, 720, 230, 60, 25);
            //gl.setSize(searchProposalExecutorEGroupCb, 550, 230, 160, 25);

            //gl.setSize(searchProposalExecutorMobileLbl, 720, 270, 60, 25);
            //gl.setSize(searchProposalExecutorMobileTxtbx, 550, 270, 160, 25);

            //gl.setSize(searchProposalPersianTitleLbl, 420, 70, 60, 25);
            //gl.setSize(searchProposalPersianTitleTxtbx, 260, 70, 160, 25);

            //gl.setSize(searchProposalEnglishTitleLbl, 420, 110, 60, 25);
            //gl.setSize(searchProposalEnglishTitleTxtbx, 260, 110, 160, 25);

            //gl.setSize(searchProposalStartDateFromLbl, 420, 150, 60, 25);
            //gl.setSize(searchProposalStartDateFromTimeInput, 260, 150, 160, 35);
            //gl.setSize(searchProposalStartDateFromChbx, 245, 155, 30, 30);

            //gl.setSize(searchProposalStartDateToLbl, 420, 190, 60, 25);
            //gl.setSize(searchProposalStartDateToTimeInput, 260, 190, 160, 35);
            //gl.setSize(searchProposalStartDateToChbx, 245, 195, 30, 30);

            //gl.setSize(searchProposalValueFromLbl, 420, 230, 60, 25);
            //gl.setSize(searchProposalValueFromTxtbx, 260, 230, 160, 25);
            //gl.setSize(searchProposalValueToLbl, 420, 270, 60, 25);
            //gl.setSize(searchProposalValueToTxtbx, 260, 270, 160, 25);

            //gl.setSize(searchProposalProcedureTypeLbl, 175, 70, 60, 25);
            //gl.setSize(searchProposalProcedureTypeCb, 45, 70, 120, 25);

            //gl.setSize(searchProposalPropertyTypeLbl, 175, 110, 60, 25);
            //gl.setSize(searchProposalPropertyTypeCb, 45, 110, 120, 25);

            //gl.setSize(searchProposalRegisterTypeLbl, 175, 150, 60, 25);
            //gl.setSize(searchProposalRegisterTypeCb, 45, 150, 120, 25);

            //gl.setSize(searchProposalTypeLbl, 175, 190, 60, 25);
            //gl.setSize(searchProposalTypeCb, 45, 190, 120, 25);

            //gl.setSize(searchProposalOrganizationLbl, 175, 230, 60, 25);
            //gl.setSize(searchProposalOrganizationNameCb, 45, 230, 75, 25);
            //gl.setSize(searchProposalOrganizationNumberCb, 125, 230, 40, 25);

            //gl.setSize(searchProposalStatusLbl, 175, 270, 60, 25);
            //gl.setSize(searchProposalStatusCb, 45, 270, 120, 25);

            //gl.setSize(searchProposalSearchBtn, 20, 370, 130, 30);
            //gl.setSize(searchProposalClearBtn, 160, 370, 70, 30);





            ///////////////manage users design/////////////////
            ////*********************************************//
            //gl.setSize(manageUserPanel, 0, 1, 900, 1000);
            //gl.setSize(manageUserShowGp, 22, 470, 826, 425);
            //gl.setSize(manageUserDgv, 5, 5, 810, 380);
            //gl.setSize(manageUserManageGp, 22, 15, 826, 445);

            //gl.setSize(menageUserAccessLevelGp, 40, 50, 350, 250);
            //gl.setSize(manageUserPersonalInfoGp, 430, 5, 360, 330);
            //gl.setSize(manageUserNcodTxtbx, 45, 20, 160, 28);
            //gl.setSize(manageUserFnameTxtbx, 45, 60, 160, 28);
            //gl.setSize(manageUserLnameTxtbx, 45, 100, 160, 28);
            //gl.setSize(manageUserPasswordTxtbx, 45, 140, 160, 28);
            //gl.setSize(manageUserEmailTxtbx, 45, 180, 160, 28);
            //gl.setSize(manageUserTellTxtbx, 45, 220, 160, 28);

            //gl.setSize(manageUserNcodLb, 205, 20, 110, 25);
            //gl.setSize(manageUserFnameLb, 275, 60, 40, 25);
            //gl.setSize(manageUserLnameLb, 205, 100, 110, 25);
            //gl.setSize(manageUserPasswordLb, 205, 140, 110, 25);
            //gl.setSize(manageUserEmailLb, 205, 180, 110, 25);
            //gl.setSize(manageUserTellLb, 205, 220, 110, 25);

            //gl.setSize(manageUserAddProCb, 155, 25, 150, 35);
            //gl.setSize(manageUserEditProCb, 155, 85, 150, 35);
            //gl.setSize(manageUserDeleteProCb, 155, 140, 150, 35);
            //gl.setSize(manageUserAddUserCb, 20, 25, 150, 35);
            //gl.setSize(manageUserEditUserCb, 20, 85, 150, 35);
            //gl.setSize(manageUserDeleteUserCb, 20, 140, 150, 35);

            //gl.setSize(manageUserAddBtn, 40, 360, 80, 30);
            //gl.setSize(manageUserEditBtn, 130, 360, 80, 30);
            //gl.setSize(manageUserDeleteBtn, 220, 360, 80, 30);
            //gl.setSize(manageUserClearBtn, 310, 360, 80, 30);
            //gl.setSize(manageUserShowBtn, 430, 360, 80, 30);


            ////////////////////manageTeacher//////////////////////
            //gl.setSize(manageTeacherPanel, 0, 1, 900, 930);
            //gl.setSize(manageTeacherInfoGp, 22, 15, 826, 445);
            //gl.setSize(teacherManageShowGp, 22, 470, 826, 425);
            //gl.setSize(manageTeacherShowDgv, 5, 5, 810, 380);

            //gl.setSize(manageTeacherExecutorNcodeLbl, 720, 60, 60, 25);
            //gl.setSize(manageTeacherFnameLbl, 720, 130, 60, 25);
            //gl.setSize(manageTeacherLnameLbl, 720, 200, 60, 25);

            //gl.setSize(manageTeacherExecutorFacultyLbl, 455, 60, 60, 25);
            //gl.setSize(manageTeacherExecutorEGroupLbl, 455, 130, 60, 25);
            //gl.setSize(manageTeacherExecutorEDegLbl, 455, 200, 60, 25);

            //gl.setSize(manageTeacherExecutorEmailLbl, 200, 60, 60, 25);
            //gl.setSize(manageTeacherExecutorMobileLbl, 200, 130, 60, 25);
            //gl.setSize(manageTeacherExecutorTelLbl, 200, 200, 60, 25);
            //gl.setSize(manageTeacherExecutorTel2Lbl, 200, 270, 60, 25);
            
            //gl.setSize(manageTeacherExecutorNcodeTxtbx, 570, 60, 160, 25);
            //gl.setSize(manageTeacherFnameTxtbx, 570, 130, 160, 25);
            //gl.setSize(manageTeacherLnameTxtbx, 570, 200, 160, 25);

            //gl.setSize(manageTeacherExecutorFacultyCb, 310, 60, 160, 25);
            //gl.setSize(manageTeacherExecutorEgroupCb, 310, 130, 160, 25);
            //gl.setSize(manageTeacherExecutorEDegCb, 310, 200, 160, 25);

            //gl.setSize(manageTeacherExecutorEmailTxtbx, 50, 60, 160, 25);
            //gl.setSize(manageTeacherExecutorMobileTxtbx, 50, 130, 160, 25);
            //gl.setSize(manageTeacherExecutorTelTxtbx, 50, 200, 160, 25);
            //gl.setSize(manageTeacherExecutorTel2Txtbx, 50, 270, 160, 25);

            //gl.setSize(manageTeacherAddBtn, 50, 365, 80, 30);
            //gl.setSize(manageTeacherEditBtn, 140, 365, 80, 30);
            //gl.setSize(manageTeacherClearBtn, 230, 365, 80, 30);
            //gl.setSize(manageTeacherDeleteBtn, 320, 365, 80, 30);
            //gl.setSize(manageTeacherShowBtn, 410, 365, 80, 30);

            ////////////////////manageTeacher//////////////////////



            ////********************************************//
            ////////////////edit proposal design///////////////
            //gl.setSize(editProposalPanel, 0, 1, 900, 930);
            //gl.setSize(editProposalEditGp, 22, 15, 826, 445);
            //gl.setSize(editProposalShowGp, 22, 470, 826, 425);
            //gl.setSize(superTabControlPanel5, 0, 1, 880, 1000);
            //gl.setSize(editProposalShowDgv, 5, 5, 810, 380);

            //gl.setSize(editProposalExecutorNcodeLbl, 720, 10, 60, 25);
            //gl.setSize(editProposalExecutorNcodeTxtbx, 600, 10, 110, 25);
            //gl.setSize(editProposalSearchBtn, 550, 10, 45, 25);

            //gl.setSize(editProposalExecutorFNameLbl, 720, 50, 60, 25);
            //gl.setSize(editProposalExecutorFNameTxtbx, 550, 50, 160, 25);

            //gl.setSize(editProposalExecutorLNameLbl, 720, 90, 60, 25);
            //gl.setSize(editProposalExecutorLNameTxtbx, 550, 90, 160, 25);

            //gl.setSize(editProposalExecutorFacultyLbl, 720, 130, 60, 25);
            //gl.setSize(editProposalExecutorFacultyCb, 550, 130, 160, 25);

            //gl.setSize(editProposalExecutorEGroupLbl, 720, 170, 60, 25);
            //gl.setSize(editProposalExecutorEGroupCb, 550, 170, 160, 25);

            //gl.setSize(editProposalExecutorEDegLbl, 720, 210, 60, 25);
            //gl.setSize(editProposalExecutorEDegCb, 550, 210, 160, 25);

            //gl.setSize(editProposalExecutorEmailLbl, 720, 250, 60, 25);
            //gl.setSize(editProposalExecutorEmailTxtbx, 550, 250, 160, 25);

            //gl.setSize(editProposalExecutorMobileLbl, 720, 290, 60, 25);
            //gl.setSize(editProposalExecutorMobileTxtbx, 550, 290, 160, 25);

            //gl.setSize(editProposalExecutorTel1Lbl, 720, 330, 60, 25);
            //gl.setSize(editProposalExecutorTel1Txtbx, 550, 330, 160, 25);

            //gl.setSize(editProposalExecutorTel2Lbl, 720, 370, 60, 25);
            //gl.setSize(editProposalExecutorTel2Txtbx, 550, 370, 160, 25);

            //gl.setSize(editProposalPersianTitleLbl, 460, 10, 60, 25);
            //gl.setSize(editProposalPersianTitleTxtbx, 290, 10, 160, 25);

            //gl.setSize(editProposalEnglishTitleLbl, 460, 50, 60, 25);
            //gl.setSize(editProposalEnglishTitleTxtbx, 290, 50, 160, 25);

            //gl.setSize(editProposalKeywordsLbl, 460, 90, 60, 25);
            //gl.setSize(editProposalKeywordsTxtbx, 290, 90, 160, 75);

            //gl.setSize(editProposalExecutor2Lbl, 460, 180, 60, 25);
            //gl.setSize(editProposalExecutor2Txtbx, 290, 180, 160, 75);

            //gl.setSize(editProposalCoexecutorLbl, 460, 270, 60, 25);
            //gl.setSize(editProposalCoexecutorTxtbx, 290, 270, 160, 85);

            //gl.setSize(editProposalStartdateLbl, 460, 370, 60, 25);
            //gl.setSize(editProposalStartdateTimeInput, 290, 370, 160, 35);

            //gl.setSize(editProposalDurationLbl, 200, 10, 60, 25);
            //gl.setSize(editProposalDurationTxtbx, 30, 10, 160, 25);

            //gl.setSize(editProposalProcedureTypeLbl, 200, 50, 60, 25);
            //gl.setSize(editProposalProcedureTypeCb, 30, 50, 160, 25);

            //gl.setSize(editProposalPropertyTypeLbl, 200, 90, 60, 25);
            //gl.setSize(editProposalPropertyTypeCb, 30, 90, 160, 25);

            //gl.setSize(editProposalRegisterTypeLbl, 200, 130, 60, 25);
            //gl.setSize(editProposalRegisterTypeCb, 30, 130, 160, 25);

            //gl.setSize(editProposalTypeLbl, 200, 170, 60, 25);
            //gl.setSize(editProposalTypeCb, 30, 170, 160, 25);

            //gl.setSize(editProposalOrganizationLbl, 200, 210, 60, 25);
            //gl.setSize(editProposalOrganizationNameCb, 30, 210, 120, 25);
            //gl.setSize(editProposalOrganizationNumberCb, 155, 210, 35, 25);

            //gl.setSize(editProposalValueLbl, 200, 250, 60, 25);
            //gl.setSize(editProposalValueTxtbx, 30, 250, 160, 25);

            //gl.setSize(editProposalStatusLbl, 200, 290, 60, 25);
            //gl.setSize(editProposalStatusCb, 30, 290, 160, 25);

            //gl.setSize(editProposalFileLbl, 200, 330, 60, 25);
            //gl.setSize(editProposalFileLinkLbl, 30, 330, 160, 25);


            //gl.setSize(editProposalRegisterBtn, 30, 370, 70, 30);
            //gl.setSize(editProposalDeleteBtn, 120, 370, 70, 30);
            //gl.setSize(editProposalClearBtn, 210, 370, 70, 30);



            
            ////********************************************//
            /////////////////////App Setting design//////////
            //gl.setSize(appSettingPanel, 0, 1, 900, 930);
            //gl.setSize(appSettingGp, 22, 15, 826, 445);
            //gl.setSize(appSettingShowDv, 5, 5, 810, 380);
            
            //gl.setSize(appSettingCoTxtbx, 55, 60, 170, 25);
            //gl.setSize(appSettingStatusTxtbx, 55, 170, 170, 25);
            //gl.setSize(appSettingRegTypeTxtbx, 350, 60, 170, 25);
            //gl.setSize(appSettingProTypeTxtbx, 350, 170, 170, 25);
            //gl.setSize(appSettingPropertyTxtbx, 605, 170, 170, 25);
            //gl.setSize(appSettingProcedureTypeTxtbx, 605, 60, 170, 25);

            //gl.setSize(appSettingCoRbtn, 218, 20, 18, 23);
            //gl.setSize(appSettingRegTypeRbtn, 512, 20, 18, 23);
            //gl.setSize(appSettingProcedureTypeRbtn, 765, 20, 18, 23);
            //gl.setSize(appSettingStatusRbtn, 218, 130, 18, 23);
            //gl.setSize(appSettingProTypeRbtn, 512, 130, 18, 23);
            //gl.setSize(appSettingPropertyRbtn, 765, 130, 18, 23);

            //gl.setSize(aapSettingCoLbl, 150, 20, 75, 35);
            //gl.setSize(appSettingRegTypeLbl, 445, 20, 75, 35);
            //gl.setSize(appSettingProcedureTypeLbl, 695, 20, 75, 35);
            //gl.setSize(appSettingStatusLbl, 150, 130, 75, 35);
            //gl.setSize(appSettingProTypeLbl, 445, 130, 75, 35);
            //gl.setSize(appSettingPropertyLbl, 695, 130, 75, 35);

            //gl.setSize(appSettingFacultyLbl, 695, 250, 75, 35);
            //gl.setSize(appSettingEgroupLbl, 445, 250, 75, 35);
            //gl.setSize(appSettingFacultyRbtn, 765, 250, 18, 23);
            //gl.setSize(appSettingEgroupRbtn, 512, 250, 18, 23);
            //gl.setSize(appSettingFacultyTxtbx, 605, 290, 170, 25);
            //gl.setSize(appSettingEgroupTxtbx, 350, 290, 170, 25);

            //gl.setSize(appSettingAddBtn, 55, 365, 80, 30);
            //gl.setSize(appSettingEditBtn, 145, 365, 80, 30);
            //gl.setSize(appSettingDeleteBtn, 235, 365, 80, 30);
            //gl.setSize(appSettingBackBtn, 325, 365, 80, 30);

            //gl.setSize(appSettingShowGp, 22, 470, 826, 425);
            /////////////////////App Setting design//////////
            ////********************************************//





            ////*************************************************/
            /////////////////personal setting design///////////////
            //gl.setSize(personalSettingPanel, 0, 1, 900, 930);
            //gl.setSize(personalSettingPasswordGp, 22, 15, 826, 290);
            //gl.setSize(personalSettingThemeGp, 22, 325, 826, 290);


            //gl.setSize(currentPasswordLbl, 450, 35, 110, 25);
            //gl.setSize(newPasswordLbl, 450, 75, 110, 25);
            //gl.setSize(confirmNewPasswordLbl, 450, 115, 110, 25);
            
            //gl.setSize(appSettingBackgroundChangeLbl, 605, 30, 110, 25);
            //gl.setSize(appSettingBackgroundChangeGp, 610, 70, 100, 160);
            //gl.setSize(appSettingBackgroundColorLbl, 10, 15, 75, 118);

            //gl.setSize(appSettingFontSizeLbl, 325, 35, 110, 25);
            //gl.setSize(appSettingMediumFontSizeLbl, 355, 110, 110, 25);
            //gl.setSize(appSettingLargeFontSizeLbl, 350, 160, 110, 25);

            //gl.setSize(currentPasswordTxtbx, 275, 35, 220, 25);
            //gl.setSize(newPasswordTxtbx, 275, 75, 220, 25);
            //gl.setSize(confirmNewPasswordTxtbx, 275, 115, 220, 25);

            //gl.setSize(personalSettingRegisterBtn, 275, 180, 100, 30);
            //gl.setSize(personalSettingClearBtn, 395, 180, 100, 30);
            /////////////////personal setting design///////////////
            ////*************************************************//



            ///////////////////about us///////////////////////////
            //gl.setSize(aboutUsPanel, 0, 1, 900, 930);
            //gl.setSize(aboutUsGp, 210, 250, 450, 340);
            //gl.setSize(aboutUsTitleLbl, 280, 10, 150, 35);
            //gl.setSize(AboutUsArshinLbl, 280, 60, 150, 30);
            //gl.setSize(aboutUsPeymanLbl, 280, 110, 150, 30);
            //gl.setSize(aboutUsHoseinLbl, 280, 160, 150, 30);
            //gl.setSize(aboutUsNimaLbl, 280, 210, 150, 30);
            //gl.setSize(aboutUsAlirezaLbl, 280, 260, 150, 30);
            ////////////////////about us///////////////////////////


            ///////////////////log design///////////////////////////
            //gl.setSize(logPanel, 0, 1, 900, 930);
            //gl.setSize(logDgv, 20, 20, 840, 870);
            ////////////////////log design///////////////////////////

            ////*****************************************************************************************************//
            ////                                               DESIGN                                                //
            ////*****************************************************************************************************//
        }// end of Form 1

        public Form1(User user)
        {
            InitializeComponent();

            
            loginUser = user;

            //نمایش نام و نام خانوادگی 
            if (loginUser.U_NCode == 88888888 && loginUser.U_Password == "P@hn")
            {
                homeUserNameLbl.Text = "ادمین نرم افزار";
                sysLogTab.Visible = true;

                //MANAGE ACCESS LEVELS
                if (loginUser.CanAddProposal == 0)
                {
                    addProposalTab.Visible = false;
                    manageTeacherTab.Visible = false;
                }

                if (loginUser.CanEditProposal == 0 && loginUser.CanDeleteProposal == 0)
                {
                    manageProposalTab.Visible = false;
                }
                else if (loginUser.CanEditProposal == 1 && loginUser.CanDeleteProposal == 0)
                {
                    editProposalDeleteBtn.Visible = false;
                }
                else if (loginUser.CanEditProposal == 0 && loginUser.CanDeleteProposal == 1)
                {
                    editProposalRegisterBtn.Visible = false;
                }

                if (loginUser.CanAddUser == 0 && loginUser.CanEditUser == 0 && loginUser.CanDeleteUser == 0)
                {
                    manageUserTab.Visible = false;
                }

                if (loginUser.CanAddUser == 0)
                {
                    manageUserAddBtn.Visible = false;
                }
                if (loginUser.CanEditUser == 0)
                {
                    manageUserEditBtn.Visible = false;
                }
                if (loginUser.CanDeleteUser == 0)
                {
                    manageUserDeleteBtn.Visible = false;
                }
                //MANAGE ACCESS LEVELS
            }
            else
            {
                homeUserNameLbl.Text = loginUser.U_LName + " " + loginUser.U_FName;

                //MANAGE ACCESS LEVELS
                if (loginUser.CanAddProposal == 0)
                {
                    addProposalTab.Visible = false;
                    manageTeacherTab.Visible = false;
                }

                if (loginUser.CanEditProposal == 0 && loginUser.CanDeleteProposal == 0)
                {
                    manageProposalTab.Visible = false;
                }
                else if (loginUser.CanEditProposal == 1 && loginUser.CanDeleteProposal == 0)
                {
                    editProposalDeleteBtn.Visible = false;
                }
                else if (loginUser.CanEditProposal == 0 && loginUser.CanDeleteProposal == 1)
                {
                    editProposalRegisterBtn.Visible = false;
                }

                if(loginUser.CanAddUser == 0 && loginUser.CanEditUser == 0 && loginUser.CanDeleteUser == 0)
                {
                    manageUserTab.Visible = false;
                }

                if(loginUser.CanAddUser == 0)
                {
                    manageUserAddBtn.Visible = false;
                }
                if (loginUser.CanEditUser == 0)
                {
                    manageUserEditBtn.Visible = false;
                }
                if (loginUser.CanDeleteUser == 0)
                {
                    manageUserDeleteBtn.Visible = false;
                }
                //MANAGE ACCESS LEVELS
            }


            homePanel.Visible = false;
            this.Enabled = false;

            systemWidth = SystemInformation.PrimaryMonitorSize.Width;          //related to setSize
            systemHeight = SystemInformation.PrimaryMonitorSize.Height;        //related to setSize
            this.SetBounds(0, 0, systemWidth, ((955 * systemHeight) / 1000));  //related to setSize
            gl.setSize(mainPage, 0, 0, 995, 925);                              //related to setSize



            //*****************************************************************************************************//
            //                                               DESIGN                                                //
            //*****************************************************************************************************//

            /*PopUp p = new PopUp("title", "context", "left", "center", "right" , "error");
            p.ShowDialog();
            if(p.DialogResult == DialogResult.Yes)
            {
                MessageBox.Show("yes");
            }

            else
            {
                MessageBox.Show("no");
            }*/


            ////////////////////////Home design////////////////////
            gl.setSize(homePanel, 0, 1, 900, 930);
            gl.setSize(homeAapInfoGp, 175, 70, 500, 300);
            gl.setSize(homeTimeDateGp, 80, 400, 700, 400);
            gl.setSize(homeAppNameLbl, 100, 15, 425, 30);
            gl.setSize(homeUserProfileLbl, 210, 75, 85, 85);
            gl.setSize(homeUserNameLbl, 190, 160, 125, 30);
            gl.setSize(homeWelcomeLbl, 190, 200, 125, 30);
            gl.setSize(analogClockControl1, 70, 25, 180, 180);
            gl.setSize(monthCalendar1, 300, 50, 320, 250);
            ///////////////////////Home design/////////////////////


            //////////////Add proposal design///////////////
            gl.setSize(addProposalPanel, 0, 1, 900, 930);
            gl.setSize(addProposalAddGp, 22, 15, 826, 445);
            gl.setSize(addProposalShowGp, 22, 470, 826, 425);
            gl.setSize(superTabControlPanel2, 0, 1, 880, 1000);
            gl.setSize(addProposalShowDgv, 5, 5, 810, 380);

            gl.setSize(addProposalExecutorNcodeLbl, 720, 10, 60, 25);
            gl.setSize(addProposalExecutorNcodeTxtbx, 600, 10, 110, 25);
            gl.setSize(addProposalSearchBtn, 550, 10, 45, 25);

            gl.setSize(addProposalExecutorFNameLbl, 720, 50, 60, 25);
            gl.setSize(addProposalExecutorFNameTxtbx, 550, 50, 160, 25);

            gl.setSize(addProposalExecutorLNameLbl, 720, 90, 60, 25);
            gl.setSize(addProposalExecutorLNameTxtbx, 550, 90, 160, 25);

            gl.setSize(addProposalExecutorFacultyLbl, 720, 130, 60, 25);
            gl.setSize(addProposalExecutorFacultyCb, 550, 130, 160, 25);

            gl.setSize(addProposalExecutorEGroupLbl, 720, 170, 60, 25);
            gl.setSize(addProposalExecutorEGroupCb, 550, 170, 160, 25);

            gl.setSize(addProposalExecutorEDegLbl, 720, 210, 60, 25);
            gl.setSize(addProposalExecutorEDegCb, 550, 210, 160, 25);

            gl.setSize(addProposalExecutorEmailLbl, 720, 250, 60, 25);
            gl.setSize(addProposalExecutorEmailTxtbx, 550, 250, 160, 25);

            gl.setSize(addProposalExecutorMobileLbl, 720, 290, 60, 25);
            gl.setSize(addProposalExecutorMobileTxtbx, 550, 290, 160, 25);

            gl.setSize(addProposalExecutorTel1Lbl, 720, 330, 60, 25);
            gl.setSize(addProposalExecutorTel1Txtbx, 550, 330, 160, 25);

            gl.setSize(addProposalExecutorTel2Lbl, 720, 370, 60, 25);
            gl.setSize(addProposalExecutorTel2Txtbx, 550, 370, 160, 25);

            gl.setSize(addProposalPersianTitleLbl, 460, 10, 60, 25);
            gl.setSize(addProposalPersianTitleTxtbx, 290, 10, 160, 25);

            gl.setSize(addProposalEnglishTitleLbl, 460, 50, 60, 25);
            gl.setSize(addProposalEnglishTitleTxtbx, 290, 50, 160, 25);

            gl.setSize(addProposalKeywordsLbl, 460, 90, 60, 25);
            gl.setSize(addProposalKeywordsTxtbx, 290, 90, 160, 75);

            gl.setSize(addProposalExecutor2Lbl, 460, 180, 60, 25);
            gl.setSize(addProposalExecutor2Txtbx, 290, 180, 160, 75);

            gl.setSize(addProposalCoexecutorLbl, 460, 270, 60, 25);
            gl.setSize(addProposalCoexecutorTxtbx, 290, 270, 160, 85);

            gl.setSize(addProposalStartdateLbl, 460, 370, 60, 25);
            gl.setSize(addProposalStartdateTimeInput, 290, 370, 160, 35);

            gl.setSize(addProposalDurationLbl, 200, 10, 60, 25);
            gl.setSize(addProposalDurationTxtbx, 30, 10, 160, 25);

            gl.setSize(addProposalProcedureTypeLbl, 200, 50, 60, 25);
            gl.setSize(addProposalProcedureTypeCb, 30, 50, 160, 25);

            gl.setSize(addProposalPropertyTypeLbl, 200, 90, 60, 25);
            gl.setSize(addProposalPropertyTypeCb, 30, 90, 160, 25);

            gl.setSize(addProposalRegisterTypeLbl, 200, 130, 60, 25);
            gl.setSize(addProposalRegisterTypeCb, 30, 130, 160, 25);

            gl.setSize(addProposalTypeLbl, 200, 170, 60, 25);
            gl.setSize(addProposalProposalTypeCb, 30, 170, 160, 25);

            gl.setSize(addProposalOrganizationLbl, 200, 210, 60, 25);
            gl.setSize(addProposalOrganizationNameCb, 30, 210, 120, 25);
            gl.setSize(addProposalOrganizationNumberCb, 155, 210, 35, 25);

            gl.setSize(addProposalValueLbl, 200, 250, 60, 25);
            gl.setSize(addProposalValueTxtbx, 30, 250, 160, 25);

            gl.setSize(addProposalStatusLbl, 200, 290, 60, 25);
            gl.setSize(addProposalStatusCb, 30, 290, 160, 25);

            gl.setSize(addProposalFileLbl, 200, 330, 60, 25);
            gl.setSize(addProposalFileLinkLbl, 30, 330, 160, 25);

            gl.setSize(addProposalRegisterBtn, 30, 370, 80, 30);
            gl.setSize(addProposalClearBtn, 120, 370, 60, 30);
            gl.setSize(addProposalShowBtn, 190, 370, 70, 30);




            //********************************************//
            //////////////Search proposal design///////////////
            gl.setSize(searchProposalPanel, 0, 1, 900, 930);
            gl.setSize(searchProposalSearchGp, 22, 15, 826, 445);
            gl.setSize(searchProposalExecutorInfoGp, 525, 5, 270, 350);
            gl.setSize(searchProposalProposalInfoGp, 20, 5, 480, 350);
            gl.setSize(searchProposalShowGp, 22, 470, 826, 425);
            gl.setSize(superTabControlPanel2, 0, 1, 880, 1000);
            gl.setSize(searchProposalShowDgv, 5, 5, 810, 380);

            gl.setSize(searchProposalExecutorNCodeLbl, 720, 70, 60, 25);
            gl.setSize(searchProposalExecutorNCodeTxtbx, 550, 70, 160, 25);

            gl.setSize(searchProposalExecutorFNameLbl, 720, 110, 60, 25);
            gl.setSize(searchProposalExecutorFNameTxtbx, 550, 110, 160, 25);

            gl.setSize(searchProposalExecutorLNameLbl, 720, 150, 60, 25);
            gl.setSize(searchProposalExecutorLNameTxtbx, 550, 150, 160, 25);

            gl.setSize(searchProposalExecutorFacultyLbl, 720, 190, 60, 25);
            gl.setSize(searchProposalExecutorFacultyCb, 550, 190, 160, 25);

            gl.setSize(searchProposalExecutorEGroupLbl, 720, 230, 60, 25);
            gl.setSize(searchProposalExecutorEGroupCb, 550, 230, 160, 25);

            gl.setSize(searchProposalExecutorMobileLbl, 720, 270, 60, 25);
            gl.setSize(searchProposalExecutorMobileTxtbx, 550, 270, 160, 25);

            gl.setSize(searchProposalPersianTitleLbl, 420, 70, 60, 25);
            gl.setSize(searchProposalPersianTitleTxtbx, 260, 70, 160, 25);

            gl.setSize(searchProposalEnglishTitleLbl, 420, 110, 60, 25);
            gl.setSize(searchProposalEnglishTitleTxtbx, 260, 110, 160, 25);

            gl.setSize(searchProposalStartDateFromLbl, 420, 150, 60, 25);
            gl.setSize(searchProposalStartDateFromTimeInput, 260, 150, 160, 35);
            gl.setSize(searchProposalStartDateFromChbx, 245, 155, 30, 30);

            gl.setSize(searchProposalStartDateToLbl, 420, 190, 60, 25);
            gl.setSize(searchProposalStartDateToTimeInput, 260, 190, 160, 35);
            gl.setSize(searchProposalStartDateToChbx, 245, 195, 30, 30);

            gl.setSize(searchProposalValueFromLbl, 420, 230, 60, 25);
            gl.setSize(searchProposalValueFromTxtbx, 260, 230, 160, 25);
            gl.setSize(searchProposalValueToLbl, 420, 270, 60, 25);
            gl.setSize(searchProposalValueToTxtbx, 260, 270, 160, 25);

            gl.setSize(searchProposalProcedureTypeLbl, 175, 70, 60, 25);
            gl.setSize(searchProposalProcedureTypeCb, 45, 70, 120, 25);

            gl.setSize(searchProposalPropertyTypeLbl, 175, 110, 60, 25);
            gl.setSize(searchProposalPropertyTypeCb, 45, 110, 120, 25);

            gl.setSize(searchProposalRegisterTypeLbl, 175, 150, 60, 25);
            gl.setSize(searchProposalRegisterTypeCb, 45, 150, 120, 25);

            gl.setSize(searchProposalTypeLbl, 175, 190, 60, 25);
            gl.setSize(searchProposalTypeCb, 45, 190, 120, 25);

            gl.setSize(searchProposalOrganizationLbl, 175, 230, 60, 25);
            gl.setSize(searchProposalOrganizationNameCb, 45, 230, 75, 25);
            gl.setSize(searchProposalOrganizationNumberCb, 125, 230, 40, 25);

            gl.setSize(searchProposalStatusLbl, 175, 270, 60, 25);
            gl.setSize(searchProposalStatusCb, 45, 270, 120, 25);

            gl.setSize(searchProposalSearchBtn, 20, 370, 130, 30);
            gl.setSize(searchProposalClearBtn, 160, 370, 70, 30);





            /////////////manage users design/////////////////
            //*********************************************//
            gl.setSize(manageUserPanel, 0, 1, 900, 1000);
            gl.setSize(manageUserShowGp, 22, 470, 826, 425);
            gl.setSize(manageUserDgv, 5, 5, 810, 380);
            gl.setSize(manageUserManageGp, 22, 15, 826, 445);

            gl.setSize(menageUserAccessLevelGp, 40, 50, 350, 250);
            gl.setSize(manageUserPersonalInfoGp, 430, 5, 360, 330);
            gl.setSize(manageUserNcodTxtbx, 45, 20, 160, 28);
            gl.setSize(manageUserFnameTxtbx, 45, 60, 160, 28);
            gl.setSize(manageUserLnameTxtbx, 45, 100, 160, 28);
            gl.setSize(manageUserPasswordTxtbx, 45, 140, 160, 28);
            gl.setSize(manageUserEmailTxtbx, 45, 180, 160, 28);
            gl.setSize(manageUserTellTxtbx, 45, 220, 160, 28);

            gl.setSize(manageUserNcodLb, 205, 20, 110, 25);
            gl.setSize(manageUserFnameLb, 275, 60, 40, 25);
            gl.setSize(manageUserLnameLb, 205, 100, 110, 25);
            gl.setSize(manageUserPasswordLb, 205, 140, 110, 25);
            gl.setSize(manageUserEmailLb, 205, 180, 110, 25);
            gl.setSize(manageUserTellLb, 205, 220, 110, 25);

            gl.setSize(manageUserAddProCb, 155, 25, 150, 35);
            gl.setSize(manageUserEditProCb, 155, 85, 150, 35);
            gl.setSize(manageUserDeleteProCb, 155, 140, 150, 35);
            gl.setSize(manageUserAddUserCb, 20, 25, 150, 35);
            gl.setSize(manageUserEditUserCb, 20, 85, 150, 35);
            gl.setSize(manageUserDeleteUserCb, 20, 140, 150, 35);

            gl.setSize(manageUserAddBtn, 40, 360, 80, 30);
            gl.setSize(manageUserEditBtn, 130, 360, 80, 30);
            gl.setSize(manageUserDeleteBtn, 220, 360, 80, 30);
            gl.setSize(manageUserClearBtn, 310, 360, 80, 30);
            gl.setSize(manageUserShowBtn, 430, 360, 80, 30);


            //////////////////manageTeacher//////////////////////
            gl.setSize(manageTeacherPanel, 0, 1, 900, 930);
            gl.setSize(manageTeacherInfoGp, 22, 15, 826, 445);
            gl.setSize(teacherManageShowGp, 22, 470, 826, 425);
            gl.setSize(manageTeacherShowDgv, 5, 5, 810, 380);

            gl.setSize(manageTeacherExecutorNcodeLbl, 720, 60, 60, 25);
            gl.setSize(manageTeacherFnameLbl, 720, 130, 60, 25);
            gl.setSize(manageTeacherLnameLbl, 720, 200, 60, 25);

            gl.setSize(manageTeacherExecutorFacultyLbl, 455, 60, 60, 25);
            gl.setSize(manageTeacherExecutorEGroupLbl, 455, 130, 60, 25);
            gl.setSize(manageTeacherExecutorEDegLbl, 455, 200, 60, 25);

            gl.setSize(manageTeacherExecutorEmailLbl, 200, 60, 60, 25);
            gl.setSize(manageTeacherExecutorMobileLbl, 200, 130, 60, 25);
            gl.setSize(manageTeacherExecutorTelLbl, 200, 200, 60, 25);
            gl.setSize(manageTeacherExecutorTel2Lbl, 200, 270, 60, 25);

            gl.setSize(manageTeacherExecutorNcodeTxtbx, 570, 60, 160, 25);
            gl.setSize(manageTeacherFnameTxtbx, 570, 130, 160, 25);
            gl.setSize(manageTeacherLnameTxtbx, 570, 200, 160, 25);

            gl.setSize(manageTeacherExecutorFacultyCb, 310, 60, 160, 25);
            gl.setSize(manageTeacherExecutorEgroupCb, 310, 130, 160, 25);
            gl.setSize(manageTeacherExecutorEDegCb, 310, 200, 160, 25);

            gl.setSize(manageTeacherExecutorEmailTxtbx, 50, 60, 160, 25);
            gl.setSize(manageTeacherExecutorMobileTxtbx, 50, 130, 160, 25);
            gl.setSize(manageTeacherExecutorTelTxtbx, 50, 200, 160, 25);
            gl.setSize(manageTeacherExecutorTel2Txtbx, 50, 270, 160, 25);

            gl.setSize(manageTeacherAddBtn, 50, 365, 80, 30);
            gl.setSize(manageTeacherEditBtn, 140, 365, 80, 30);
            gl.setSize(manageTeacherClearBtn, 230, 365, 80, 30);
            gl.setSize(manageTeacherDeleteBtn, 320, 365, 80, 30);
            gl.setSize(manageTeacherShowBtn, 410, 365, 80, 30);

            //////////////////manageTeacher//////////////////////



            //********************************************//
            //////////////edit proposal design///////////////
            gl.setSize(editProposalPanel, 0, 1, 900, 930);
            gl.setSize(editProposalEditGp, 22, 15, 826, 445);
            gl.setSize(editProposalShowGp, 22, 470, 826, 425);
            gl.setSize(superTabControlPanel5, 0, 1, 880, 1000);
            gl.setSize(editProposalShowDgv, 5, 5, 810, 380);

            gl.setSize(editProposalExecutorNcodeLbl, 720, 10, 60, 25);
            gl.setSize(editProposalExecutorNcodeTxtbx, 600, 10, 110, 25);
            gl.setSize(editProposalSearchBtn, 550, 10, 45, 25);

            gl.setSize(editProposalExecutorFNameLbl, 720, 50, 60, 25);
            gl.setSize(editProposalExecutorFNameTxtbx, 550, 50, 160, 25);

            gl.setSize(editProposalExecutorLNameLbl, 720, 90, 60, 25);
            gl.setSize(editProposalExecutorLNameTxtbx, 550, 90, 160, 25);

            gl.setSize(editProposalExecutorFacultyLbl, 720, 130, 60, 25);
            gl.setSize(editProposalExecutorFacultyCb, 550, 130, 160, 25);

            gl.setSize(editProposalExecutorEGroupLbl, 720, 170, 60, 25);
            gl.setSize(editProposalExecutorEGroupCb, 550, 170, 160, 25);

            gl.setSize(editProposalExecutorEDegLbl, 720, 210, 60, 25);
            gl.setSize(editProposalExecutorEDegCb, 550, 210, 160, 25);

            gl.setSize(editProposalExecutorEmailLbl, 720, 250, 60, 25);
            gl.setSize(editProposalExecutorEmailTxtbx, 550, 250, 160, 25);

            gl.setSize(editProposalExecutorMobileLbl, 720, 290, 60, 25);
            gl.setSize(editProposalExecutorMobileTxtbx, 550, 290, 160, 25);

            gl.setSize(editProposalExecutorTel1Lbl, 720, 330, 60, 25);
            gl.setSize(editProposalExecutorTel1Txtbx, 550, 330, 160, 25);

            gl.setSize(editProposalExecutorTel2Lbl, 720, 370, 60, 25);
            gl.setSize(editProposalExecutorTel2Txtbx, 550, 370, 160, 25);

            gl.setSize(editProposalPersianTitleLbl, 460, 10, 60, 25);
            gl.setSize(editProposalPersianTitleTxtbx, 290, 10, 160, 25);

            gl.setSize(editProposalEnglishTitleLbl, 460, 50, 60, 25);
            gl.setSize(editProposalEnglishTitleTxtbx, 290, 50, 160, 25);

            gl.setSize(editProposalKeywordsLbl, 460, 90, 60, 25);
            gl.setSize(editProposalKeywordsTxtbx, 290, 90, 160, 75);

            gl.setSize(editProposalExecutor2Lbl, 460, 180, 60, 25);
            gl.setSize(editProposalExecutor2Txtbx, 290, 180, 160, 75);

            gl.setSize(editProposalCoexecutorLbl, 460, 270, 60, 25);
            gl.setSize(editProposalCoexecutorTxtbx, 290, 270, 160, 85);

            gl.setSize(editProposalStartdateLbl, 460, 370, 60, 25);
            gl.setSize(editProposalStartdateTimeInput, 290, 370, 160, 35);

            gl.setSize(editProposalDurationLbl, 200, 10, 60, 25);
            gl.setSize(editProposalDurationTxtbx, 30, 10, 160, 25);

            gl.setSize(editProposalProcedureTypeLbl, 200, 50, 60, 25);
            gl.setSize(editProposalProcedureTypeCb, 30, 50, 160, 25);

            gl.setSize(editProposalPropertyTypeLbl, 200, 90, 60, 25);
            gl.setSize(editProposalPropertyTypeCb, 30, 90, 160, 25);

            gl.setSize(editProposalRegisterTypeLbl, 200, 130, 60, 25);
            gl.setSize(editProposalRegisterTypeCb, 30, 130, 160, 25);

            gl.setSize(editProposalTypeLbl, 200, 170, 60, 25);
            gl.setSize(editProposalTypeCb, 30, 170, 160, 25);

            gl.setSize(editProposalOrganizationLbl, 200, 210, 60, 25);
            gl.setSize(editProposalOrganizationNameCb, 30, 210, 120, 25);
            gl.setSize(editProposalOrganizationNumberCb, 155, 210, 35, 25);

            gl.setSize(editProposalValueLbl, 200, 250, 60, 25);
            gl.setSize(editProposalValueTxtbx, 30, 250, 160, 25);

            gl.setSize(editProposalStatusLbl, 200, 290, 60, 25);
            gl.setSize(editProposalStatusCb, 30, 290, 160, 25);

            gl.setSize(editProposalFileLbl, 200, 330, 60, 25);
            gl.setSize(editProposalFileLinkLbl, 30, 330, 160, 25);


            gl.setSize(editProposalRegisterBtn, 30, 370, 70, 30);
            gl.setSize(editProposalDeleteBtn, 120, 370, 70, 30);
            gl.setSize(editProposalClearBtn, 210, 370, 70, 30);




            //********************************************//
            ///////////////////App Setting design//////////
            gl.setSize(appSettingPanel, 0, 1, 900, 930);
            gl.setSize(appSettingGp, 22, 15, 826, 445);
            gl.setSize(appSettingShowDv, 5, 5, 810, 380);

            gl.setSize(appSettingCoTxtbx, 55, 60, 170, 25);
            gl.setSize(appSettingStatusTxtbx, 55, 170, 170, 25);
            gl.setSize(appSettingRegTypeTxtbx, 350, 60, 170, 25);
            gl.setSize(appSettingProTypeTxtbx, 350, 170, 170, 25);
            gl.setSize(appSettingPropertyTxtbx, 605, 170, 170, 25);
            gl.setSize(appSettingProcedureTypeTxtbx, 605, 60, 170, 25);

            gl.setSize(appSettingCoRbtn, 218, 20, 18, 23);
            gl.setSize(appSettingRegTypeRbtn, 512, 20, 18, 23);
            gl.setSize(appSettingProcedureTypeRbtn, 765, 20, 18, 23);
            gl.setSize(appSettingStatusRbtn, 218, 130, 18, 23);
            gl.setSize(appSettingProTypeRbtn, 512, 130, 18, 23);
            gl.setSize(appSettingPropertyRbtn, 765, 130, 18, 23);

            gl.setSize(aapSettingCoLbl, 150, 20, 75, 35);
            gl.setSize(appSettingRegTypeLbl, 445, 20, 75, 35);
            gl.setSize(appSettingProcedureTypeLbl, 695, 20, 75, 35);
            gl.setSize(appSettingStatusLbl, 150, 130, 75, 35);
            gl.setSize(appSettingProTypeLbl, 445, 130, 75, 35);
            gl.setSize(appSettingPropertyLbl, 695, 130, 75, 35);

            gl.setSize(appSettingFacultyLbl, 695, 250, 75, 35);
            gl.setSize(appSettingEgroupLbl, 445, 250, 75, 35);
            gl.setSize(appSettingFacultyRbtn, 765, 250, 18, 23);
            gl.setSize(appSettingEgroupRbtn, 512, 250, 18, 23);
            gl.setSize(appSettingFacultyTxtbx, 605, 290, 170, 25);
            gl.setSize(appSettingEgroupTxtbx, 350, 290, 170, 25);

            gl.setSize(appSettingAddBtn, 55, 365, 80, 30);
            gl.setSize(appSettingEditBtn, 145, 365, 80, 30);
            gl.setSize(appSettingDeleteBtn, 235, 365, 80, 30);
            gl.setSize(appSettingBackBtn, 325, 365, 80, 30);

            gl.setSize(appSettingShowGp, 22, 470, 826, 425);
            ///////////////////App Setting design//////////
            //********************************************//





            //*************************************************/
            ///////////////personal setting design///////////////
            gl.setSize(personalSettingPanel, 0, 1, 900, 930);
            gl.setSize(personalSettingPasswordGp, 22, 15, 826, 290);
            gl.setSize(personalSettingThemeGp, 22, 325, 826, 290);


            gl.setSize(currentPasswordLbl, 450, 35, 110, 25);
            gl.setSize(newPasswordLbl, 450, 75, 110, 25);
            gl.setSize(confirmNewPasswordLbl, 450, 115, 110, 25);

            gl.setSize(appSettingBackgroundChangeLbl, 605, 30, 110, 25);
            gl.setSize(appSettingBackgroundChangeGp, 610, 70, 100, 160);
            gl.setSize(appSettingBackgroundColorLbl, 10, 15, 75, 118);

            gl.setSize(appSettingFontSizeLbl, 325, 35, 110, 25);
            gl.setSize(appSettingMediumFontSizeLbl, 355, 110, 110, 25);
            gl.setSize(appSettingLargeFontSizeLbl, 350, 160, 110, 25);

            gl.setSize(currentPasswordTxtbx, 275, 35, 220, 25);
            gl.setSize(newPasswordTxtbx, 275, 75, 220, 25);
            gl.setSize(confirmNewPasswordTxtbx, 275, 115, 220, 25);

            gl.setSize(personalSettingRegisterBtn, 275, 180, 100, 30);
            gl.setSize(personalSettingClearBtn, 395, 180, 100, 30);
            ///////////////personal setting design///////////////
            //*************************************************//



            /////////////////about us///////////////////////////
            gl.setSize(aboutUsPanel, 0, 1, 900, 930);
            gl.setSize(aboutUsGp, 210, 250, 450, 340);
            gl.setSize(aboutUsTitleLbl, 280, 10, 150, 35);
            gl.setSize(AboutUsArshinLbl, 280, 60, 150, 30);
            gl.setSize(aboutUsPeymanLbl, 280, 110, 150, 30);
            gl.setSize(aboutUsHoseinLbl, 280, 160, 150, 30);
            gl.setSize(aboutUsNimaLbl, 280, 210, 150, 30);
            gl.setSize(aboutUsAlirezaLbl, 280, 260, 150, 30);
            //////////////////about us///////////////////////////


            /////////////////log design///////////////////////////
            gl.setSize(logPanel, 0, 1, 900, 930);
            gl.setSize(logDgv, 20, 20, 840, 870);
            //////////////////log design///////////////////////////

            //*****************************************************************************************************//
            //                                               DESIGN                                                //
            //*****************************************************************************************************//
        }




        //*****************************************************************************************************//
        //                                               LISTENERS                                             //
        //*****************************************************************************************************//

        private void searchProposalStartDateFromChbx_CheckedChanged(object sender, EventArgs e)
        {
            if(searchProposalStartDateFromChbx.Checked == true)
            {
                searchProposalStartDateFromTimeInput.Enabled = true;
            }
            else
            {
                searchProposalStartDateFromTimeInput.Enabled = false;
            }
        }

        private void searchProposalStartDateToChbx_CheckedChanged(object sender, EventArgs e)
        {
            if (searchProposalStartDateToChbx.Checked == true)
            {
                searchProposalStartDateToTimeInput.Enabled = true;
            }
            else
            {
                searchProposalStartDateToTimeInput.Enabled = false;
            }
        }

        private void addProposalFileLinkLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog op1 = new OpenFileDialog();
            op1.Multiselect = false;


            addProposalFileLinkLbl.Text = op1.FileName;
            if (op1.ShowDialog() == DialogResult.OK)
            {
                FileInfo fi = new FileInfo(op1.FileName);
                _inputParameter.Username = "Nima";
                _inputParameter.Password = "P@hn1395";
                _inputParameter.Server = "ftp://185.159.152.5";
                _inputParameter.FileName = fi.Name;
                _inputParameter.FullName = fi.FullName;
            }
        }


        private void addProposalClearBtn_Click(object sender, EventArgs e)
        {
            isNewTeacher = false;

            addProposalExecutorNcodeTxtbx.BackColor = Color.White;
            addProposalExecutorNcodeTxtbx.Clear();
            addProposalExecutorFNameTxtbx.Clear();
            addProposalExecutorLNameTxtbx.Clear();
            addProposalExecutorFacultyCb.SelectedIndex = -1;
            addProposalExecutorEGroupCb.SelectedIndex = -1;
            addProposalExecutorEDegCb.SelectedIndex = -1;
            addProposalExecutorEmailTxtbx.Clear();
            addProposalExecutorEmailTxtbx.BackColor = Color.White;
            addProposalExecutorMobileTxtbx.Clear();
            addProposalExecutorTel1Txtbx.Clear();
            addProposalExecutorTel2Txtbx.Clear();
            addProposalPersianTitleTxtbx.Clear();
            addProposalEnglishTitleTxtbx.Clear();
            addProposalKeywordsTxtbx.Clear();
            addProposalExecutor2Txtbx.Clear();
            addProposalCoexecutorTxtbx.Clear();
            addProposalStartdateTimeInput.GeoDate = DateTime.Now;
            addProposalDurationTxtbx.Clear();
            addProposalDurationTxtbx.BackColor = Color.White;
            addProposalProcedureTypeCb.SelectedIndex = -1;
            addProposalPropertyTypeCb.SelectedIndex = -1;
            addProposalRegisterTypeCb.SelectedIndex = -1;
            addProposalProposalTypeCb.SelectedIndex = -1;
            addProposalOrganizationNameCb.SelectedIndex = -1;
            addProposalOrganizationNumberCb.SelectedIndex = -1;
            addProposalOrganizationNameCb.BackColor = Color.White;
            addProposalOrganizationNumberCb.BackColor = Color.White;
            addProposalValueTxtbx.Clear();
            addProposalValueTxtbx.BackColor = Color.White;
            addProposalStatusCb.SelectedIndex = -1;
        }


        private void addProposalRegisterBtn_Click(object sender, EventArgs e)
        {
            if(    addProposalExecutorNcodeTxtbx.BackColor == Color.Pink || addProposalExecutorNcodeTxtbx.Text.Length < 10
                || addProposalExecutorFNameTxtbx.Text.Length == 0 || addProposalExecutorLNameTxtbx.Text.Length == 0
                || addProposalExecutorFacultyCb.SelectedIndex == -1 || addProposalExecutorEGroupCb.SelectedIndex == -1
                || addProposalExecutorEDegCb.SelectedIndex == -1 || addProposalExecutorEmailTxtbx.Text.Length == 0
                || addProposalExecutorMobileTxtbx.Text.Length == 0 || addProposalPersianTitleTxtbx.Text.Length == 0
                || addProposalEnglishTitleTxtbx.Text.Length == 0 || addProposalKeywordsTxtbx.Text.Length == 0
                || addProposalFileLinkLbl.Text == "افزودن فایل" || addProposalDurationTxtbx.Text.Length == 0
                || addProposalProcedureTypeCb.SelectedIndex == -1 || addProposalPropertyTypeCb.SelectedIndex == -1
                || addProposalRegisterTypeCb.SelectedIndex == -1 || addProposalProposalTypeCb.SelectedIndex == -1
                || addProposalOrganizationNumberCb.SelectedIndex == -1 || addProposalOrganizationNameCb.SelectedIndex == -1
                || addProposalValueTxtbx.Text.Length == 0 || addProposalStatusCb.SelectedIndex == -1)
            {
                PopUp p = new PopUp("خطای ورودی", "اطلاعات وارد شده صحیح نیست. پر کردن موارد ستاره دار الزامی می باشد.", "تایید", "", "", "error");
                p.ShowDialog();
            }

            else
            {
                if (isNewTeacher)
                {
                    Teachers teacher = new Teachers();

                    teacher.T_NCode = long.Parse(addProposalExecutorNcodeTxtbx.Text);
                    teacher.T_FName = addProposalExecutorFNameTxtbx.Text;
                    teacher.T_LName = addProposalExecutorLNameTxtbx.Text;
                    teacher.T_Faculty = addProposalExecutorFacultyCb.Text;
                    teacher.T_Group = addProposalExecutorEGroupCb.Text;
                    teacher.T_EDeg = addProposalExecutorEDegCb.Text;
                    teacher.T_Email = addProposalExecutorEmailTxtbx.Text;
                    teacher.T_Mobile = addProposalExecutorMobileTxtbx.Text;
                    teacher.T_Tel1 = addProposalExecutorTel1Txtbx.Text;
                    teacher.T_Tel2 = addProposalExecutorTel2Txtbx.Text;

                    dbh.AddTeacher(teacher, username, DateTime.Now.ToString());
                }

                Proposal proposal = new Proposal();
                proposal.PersianTitle = addProposalPersianTitleTxtbx.Text;
                proposal.EngTitle = addProposalEnglishTitleTxtbx.Text;
                proposal.KeyWord = addProposalKeywordsTxtbx.Text;
                proposal.CoExecutor = addProposalCoexecutorTxtbx.Text;
                proposal.Executor2 = addProposalExecutor2Txtbx.Text;
                proposal.Duration = int.Parse(addProposalDurationTxtbx.Text);
                proposal.ProcedureType = addProposalProcedureTypeCb.Text;
                proposal.PropertyType = addProposalPropertyTypeCb.Text;
                proposal.ProposalType = addProposalProposalTypeCb.Text;
                proposal.Status = addProposalStatusCb.Text;
                proposal.RegisterType = addProposalRegisterTypeCb.Text;
                proposal.Employer = long.Parse(addProposalOrganizationNumberCb.Text);
                proposal.Value = addProposalValueTxtbx.Text;
                proposal.Executor = long.Parse(addProposalExecutorNcodeTxtbx.Text);
                proposal.StartDate = addProposalStartdateTimeInput.GeoDate.ToString();
                proposal.Registrant = username;

                dbh.AddProposal(proposal, username, myDateTime.ToString(), _inputParameter);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                homePanel.BackColor = dlg.Color;
                addProposalPanel.BackColor = dlg.Color;
                searchProposalPanel.BackColor = dlg.Color;
                manageUserPanel.BackColor = dlg.Color;
                manageTeacherPanel.BackColor = dlg.Color;
                editProposalPanel.BackColor = dlg.Color;
                appSettingPanel.BackColor = dlg.Color;
                personalSettingPanel.BackColor = dlg.Color;
                aboutUsPanel.BackColor = dlg.Color;
                logPanel.BackColor = dlg.Color;
            }
        }


        private void appSettingAddBtn_Click(object sender, EventArgs e)
        {
            if(appSettingProcedureTypeTxtbx.Enabled == true)
            {
                if(!appSettingProcedureTypeTxtbx.Text.Equals(""))
                {
                    dbh.AddProcedureType(appSettingProcedureTypeTxtbx.Text, 9999 /* admin */ , myDateTime.ToString());
                    appSettingProcedureTypeTxtbx.Clear();
                    dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT procedureType FROM procedureTypeTable");

                    form_initializer(); // To Reset items of comboBoxes and others
                }
            }

            else if (appSettingPropertyTxtbx.Enabled == true)
            {
                if (!appSettingPropertyTxtbx.Text.Equals(""))
                {
                    dbh.AddPropertyType(appSettingPropertyTxtbx.Text, 9999 /*admin*/, myDateTime.ToString());
                    appSettingPropertyTxtbx.Clear();
                    dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT propertyType FROM propertyTypeTable");

                    form_initializer(); // To Reset items of comboBoxes and others
                }
            }

            else if (appSettingFacultyTxtbx.Enabled == true)
            {
                if (!appSettingFacultyTxtbx.Text.Equals(""))
                {
                    dbh.AddFaculty(appSettingFacultyTxtbx.Text, 9999 /*admin*/, myDateTime.ToString());
                    appSettingFacultyTxtbx.Clear();
                    dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT facultyName FROM facultyTable");

                    form_initializer(); // To Reset items of comboBoxes and others
                }
            }

            else if (appSettingRegTypeTxtbx.Enabled == true)
            {
                if (!appSettingRegTypeTxtbx.Text.Equals(""))
                {
                    dbh.AddRegisterType(appSettingRegTypeTxtbx.Text, 9999 /*admin*/, myDateTime.ToString());
                    appSettingRegTypeTxtbx.Clear();
                    dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT registerType FROM registerTypeTable");

                    form_initializer(); // To Reset items of comboBoxes and others
                }
            }

            else if (appSettingProTypeTxtbx.Enabled == true)
            {
                if (!appSettingProTypeTxtbx.Text.Equals(""))
                {
                    dbh.AddProposalType(appSettingProTypeTxtbx.Text, 9999 /*admin*/, myDateTime.ToString());
                    appSettingProTypeTxtbx.Clear();
                    dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT proposalType FROM proposalTypeTable");

                    form_initializer(); // To Reset items of comboBoxes and others
                }
            }

            else if (appSettingEgroupTxtbx.Enabled == true)
            {
                if (!appSettingEgroupTxtbx.Text.Equals(""))
                {
                    dbh.AddEGroup(appSettingFacultyTxtbx.Text,appSettingEgroupTxtbx.Text, 9999, DateTime.Now.ToString());
                    appSettingEgroupTxtbx.Clear();
                    dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT groupName FROM EGroupTable WHERE facultyName ='" + appSettingFacultyTxtbx.Text + "'");

                    form_initializer(); // To Reset items of comboBoxes and others
                }
            }

            else if (appSettingCoTxtbx.Enabled == true)
            {
                if (!appSettingCoTxtbx.Text.Equals(""))
                {
                    dbh.AddEmployer(appSettingCoTxtbx.Text, 9999 /*admin*/, myDateTime.ToString());
                    appSettingCoTxtbx.Clear();
                    dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT * FROM employersTable");
                    appSettingShowDv.Columns[0].HeaderText = "نام سازمان";
                    appSettingShowDv.Columns[1].HeaderText = "کد سازمان";
                   // appSettingShowDv.Columns[2].Visible = false;

                    form_initializer(); // To Reset items of comboBoxes and others
                }
            }

            else if (appSettingStatusTxtbx.Enabled == true)
            {
                if (!appSettingStatusTxtbx.Text.Equals(""))
                {
                    dbh.AddStatusType(appSettingStatusTxtbx.Text, 9999 /*admin*/, myDateTime.ToString());
                    appSettingStatusTxtbx.Clear();
                    dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT statusType FROM statusTypeTable");

                    form_initializer(); // To Reset items of comboBoxes and others
                }
            }

            
        }



        //////////////color of textbox///////////////
        private void manageTeacherExecutorNcodeTxtbx_TextChanged(object sender, EventArgs e)
        {
            if (manageTeacherExecutorNcodeTxtbx.Text.Length == 10)
            {
                manageTeacherExecutorNcodeTxtbx.BackColor = Color.LightGreen;
            }
            else
            {
                manageTeacherExecutorNcodeTxtbx.BackColor = Color.White;
            }
        }
        //////////////color of textbox///////////////



        //////////////only int///////////////
        private void manageTeacherExecutorNcodeTxtbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }
        //////////////only int///////////////




        //////////////check email///////////////
        private void manageTeacherExecutorEmailTxtbx_Leave(object sender, EventArgs e)
        {
            if (!manageTeacherExecutorEmailTxtbx.Text.Equals("") && !System.Text.RegularExpressions.Regex.IsMatch(manageTeacherExecutorEmailTxtbx.Text, @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"))
            {
                manageTeacherExecutorEmailTxtbx.BackColor = Color.Red;
                MessageBox.Show("email is invalid");
            }
            else if(System.Text.RegularExpressions.Regex.IsMatch(manageTeacherExecutorEmailTxtbx.Text, @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"))
            {
                manageTeacherExecutorEmailTxtbx.BackColor = Color.White;
            }
        }
        //////////////check email///////////////




        private void manageTeacherExecutorEmailTxtbx_TextChanged(object sender, EventArgs e)
        {
            manageTeacherExecutorEmailTxtbx.BackColor = Color.White;
        }

        private void appSettingProcedureTypeRbtn_Click(object sender, EventArgs e)
        {
            appSettingProcedureTypeTxtbx.Enabled = true;
            appSettingPropertyTxtbx.Enabled = false;
            appSettingFacultyTxtbx.Enabled = false;
            appSettingRegTypeTxtbx.Enabled = false;
            appSettingProTypeTxtbx.Enabled = false;
            appSettingEgroupTxtbx.Enabled = false;
            appSettingCoTxtbx.Enabled = false;
            appSettingStatusTxtbx.Enabled = false;

            appSettingPropertyTxtbx.Clear();
            appSettingFacultyTxtbx.Clear();
            appSettingRegTypeTxtbx.Clear();
            appSettingProTypeTxtbx.Clear();
            appSettingEgroupTxtbx.Clear();
            appSettingCoTxtbx.Clear();
            appSettingStatusTxtbx.Clear();

            appSettingAddBtn.Enabled = true;

            dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT procedureType FROM procedureTypeTable");
            appSettingShowDv.Columns[0].HeaderText = "نوع کار";
        }

        private void appSettingPropertyRbtn_Click(object sender, EventArgs e)
        {
            appSettingProcedureTypeTxtbx.Enabled = false;
            appSettingPropertyTxtbx.Enabled = true;
            appSettingFacultyTxtbx.Enabled = false;
            appSettingRegTypeTxtbx.Enabled = false;
            appSettingProTypeTxtbx.Enabled = false;
            appSettingEgroupTxtbx.Enabled = false;
            appSettingCoTxtbx.Enabled = false;
            appSettingStatusTxtbx.Enabled = false;

            appSettingProcedureTypeTxtbx.Clear();
            appSettingFacultyTxtbx.Clear();
            appSettingRegTypeTxtbx.Clear();
            appSettingProTypeTxtbx.Clear();
            appSettingEgroupTxtbx.Clear();
            appSettingCoTxtbx.Clear();
            appSettingStatusTxtbx.Clear();

            appSettingAddBtn.Enabled = true;

            dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT propertyType FROM propertyTypeTable");
            appSettingShowDv.Columns[0].HeaderText = "نوع خاصیت";
        }

        private void appSettingFacultyRbtn_Click(object sender, EventArgs e)
        {
            appSettingProcedureTypeTxtbx.Enabled = false;
            appSettingPropertyTxtbx.Enabled = false;
            appSettingFacultyTxtbx.Enabled = true;
            appSettingRegTypeTxtbx.Enabled = false;
            appSettingProTypeTxtbx.Enabled = false;
            appSettingEgroupTxtbx.Enabled = false;
            appSettingCoTxtbx.Enabled = false;
            appSettingStatusTxtbx.Enabled = false;

            appSettingProcedureTypeTxtbx.Clear();
            appSettingPropertyTxtbx.Clear();
            appSettingRegTypeTxtbx.Clear();
            appSettingProTypeTxtbx.Clear();
            appSettingEgroupTxtbx.Clear();
            appSettingCoTxtbx.Clear();
            appSettingStatusTxtbx.Clear();

            appSettingAddBtn.Enabled = true;

            dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT facultyName FROM facultyTable");
            appSettingShowDv.Columns[0].HeaderText = "نام دانشکده";
        }

        private void appSettingRegTypeRbtn_Click(object sender, EventArgs e)
        {
            appSettingProcedureTypeTxtbx.Enabled = false;
            appSettingPropertyTxtbx.Enabled = false;
            appSettingFacultyTxtbx.Enabled = false;
            appSettingRegTypeTxtbx.Enabled = true;
            appSettingProTypeTxtbx.Enabled = false;
            appSettingEgroupTxtbx.Enabled = false;
            appSettingCoTxtbx.Enabled = false;
            appSettingStatusTxtbx.Enabled = false;

            appSettingProcedureTypeTxtbx.Clear();
            appSettingPropertyTxtbx.Clear();
            appSettingFacultyTxtbx.Clear();
            appSettingProTypeTxtbx.Clear();
            appSettingEgroupTxtbx.Clear();
            appSettingCoTxtbx.Clear();
            appSettingStatusTxtbx.Clear();

            appSettingAddBtn.Enabled = true;

            dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT registerType FROM registerTypeTable");
            appSettingShowDv.Columns[0].HeaderText = "نوع ثبت";
        }

        private void appSettingProTypeRbtn_Click(object sender, EventArgs e)
        {
            appSettingProcedureTypeTxtbx.Enabled = false;
            appSettingPropertyTxtbx.Enabled = false;
            appSettingFacultyTxtbx.Enabled = false;
            appSettingRegTypeTxtbx.Enabled = false;
            appSettingProTypeTxtbx.Enabled = true;
            appSettingEgroupTxtbx.Enabled = false;
            appSettingCoTxtbx.Enabled = false;
            appSettingStatusTxtbx.Enabled = false;

            appSettingProcedureTypeTxtbx.Clear();
            appSettingPropertyTxtbx.Clear();
            appSettingFacultyTxtbx.Clear();
            appSettingRegTypeTxtbx.Clear();
            appSettingEgroupTxtbx.Clear();
            appSettingCoTxtbx.Clear();
            appSettingStatusTxtbx.Clear();

            appSettingAddBtn.Enabled = true;

            dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT proposalType FROM proposalTypeTable");
            appSettingShowDv.Columns[0].HeaderText = "نوع پروپوزال";
        }

        private void appSettingEgroupRbtn_Click(object sender, EventArgs e)
        {
            //There is no actions yet, maybe later.
        }

        private void appSettingCoRbtn_Click(object sender, EventArgs e)
        {
            appSettingProcedureTypeTxtbx.Enabled = false;
            appSettingPropertyTxtbx.Enabled = false;
            appSettingFacultyTxtbx.Enabled = false;
            appSettingRegTypeTxtbx.Enabled = false;
            appSettingProTypeTxtbx.Enabled = false;
            appSettingEgroupTxtbx.Enabled = false;
            appSettingCoTxtbx.Enabled = true;
            appSettingStatusTxtbx.Enabled = false;

            appSettingProcedureTypeTxtbx.Clear();
            appSettingPropertyTxtbx.Clear();
            appSettingFacultyTxtbx.Clear();
            appSettingRegTypeTxtbx.Clear();
            appSettingEgroupTxtbx.Clear();
            appSettingProTypeTxtbx.Clear();
            appSettingStatusTxtbx.Clear();

            appSettingAddBtn.Enabled = true;

            dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT * FROM employersTable");
            appSettingShowDv.Columns[0].HeaderText = "کد سازمان";
            appSettingShowDv.Columns[1].HeaderText = "نام سازمان";
           // appSettingShowDv.Columns[2].Visible = false;
        }

        private void appSettingStatusRbtn_Click(object sender, EventArgs e)
        {
            appSettingProcedureTypeTxtbx.Enabled = false;
            appSettingPropertyTxtbx.Enabled = false;
            appSettingFacultyTxtbx.Enabled = false;
            appSettingRegTypeTxtbx.Enabled = false;
            appSettingProTypeTxtbx.Enabled = false;
            appSettingEgroupTxtbx.Enabled = false;
            appSettingCoTxtbx.Enabled = false;
            appSettingStatusTxtbx.Enabled = true;

            appSettingProcedureTypeTxtbx.Clear();
            appSettingPropertyTxtbx.Clear();
            appSettingFacultyTxtbx.Clear();
            appSettingRegTypeTxtbx.Clear();
            appSettingEgroupTxtbx.Clear();
            appSettingProTypeTxtbx.Clear();
            appSettingCoTxtbx.Clear();

            appSettingAddBtn.Enabled = true;

            dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT statusType FROM statusTypeTable");
            appSettingShowDv.Columns[0].HeaderText = "وضعیت";
        }

        private void appSettingEditBtn_Click(object sender, EventArgs e)
        {
            if (appSettingProcedureTypeTxtbx.Enabled == true)
            {
                if (!appSettingProcedureTypeTxtbx.Text.Equals(""))
                {
                    dbh.EditProcedureType(appSettingProcedureTypeTxtbx.Text, currentSelectedOption, 9999 /*admin*/, myDateTime.ToString());
                    appSettingProcedureTypeTxtbx.Clear();
                    dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT procedureType FROM procedureTypeTable");
                    appSettingShowDv.Columns[0].HeaderText = "نوع کار";

                    form_initializer(); // To Reset items of comboBoxes and others
                }
                else
                {
                    PopUp popUp = new PopUp("خطا", "نوع کار را مشخص کنید.", "تایید", "", "", "error");
                    popUp.ShowDialog();
                }
            }

            else if (appSettingPropertyTxtbx.Enabled == true)
            {
                if (!appSettingPropertyTxtbx.Text.Equals(""))
                {
                    dbh.EditPropertyType(appSettingPropertyTxtbx.Text, currentSelectedOption, 9999 /*admin*/, myDateTime.ToString());
                    appSettingPropertyTxtbx.Clear();
                    dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT propertyType FROM propertyTypeTable");
                    appSettingShowDv.Columns[0].HeaderText = "نوع خاصیت";

                    form_initializer(); // To Reset items of comboBoxes and others
                }
                else
                {
                    PopUp popUp = new PopUp("خطا", "نوع خاصیت را مشخص کنید.", "تایید", "", "", "error");
                    popUp.ShowDialog();
                }
            }

            else if (appSettingFacultyTxtbx.Enabled == true)
            {
                if (!appSettingFacultyTxtbx.Text.Equals(""))
                {
                    dbh.EditFaculty(appSettingFacultyTxtbx.Text, currentSelectedOption, 9999 /*admin*/, myDateTime.ToString());
                    appSettingFacultyTxtbx.Clear();
                    dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT facultyName FROM facultyTable");
                    appSettingShowDv.Columns[0].HeaderText = "نام دانشکده";

                    form_initializer(); // To Reset items of comboBoxes and others
                }
                else
                {
                    PopUp popUp = new PopUp("خطا", "نام دانشکده را مشخص کنید.", "تایید", "", "", "error");
                    popUp.ShowDialog();
                }
            }

            else if (appSettingRegTypeTxtbx.Enabled == true)
            {
                if (!appSettingRegTypeTxtbx.Text.Equals(""))
                {
                    dbh.EditRegisterType(appSettingRegTypeTxtbx.Text, currentSelectedOption, 9999 /*admin*/, myDateTime.ToString());
                    appSettingRegTypeTxtbx.Clear();
                    dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT registerType FROM registerTypeTable");
                    appSettingShowDv.Columns[0].HeaderText = "نوع ثبت";

                    form_initializer(); // To Reset items of comboBoxes and others
                }
                else
                {
                    PopUp popUp = new PopUp("خطا", "نوع ثبت را مشخص کنید.", "تایید", "", "", "error");
                    popUp.ShowDialog();
                }
            }

            else if (appSettingProTypeTxtbx.Enabled == true)
            {
                if (!appSettingProTypeTxtbx.Text.Equals(""))
                {
                    dbh.EditProposalType(appSettingProTypeTxtbx.Text, currentSelectedOption, 9999 /*admin*/, myDateTime.ToString());
                    appSettingProTypeTxtbx.Clear();
                    dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT proposalType FROM proposalTypeTable");
                    appSettingShowDv.Columns[0].HeaderText = "نوع پروپوزال";

                    form_initializer(); // To Reset items of comboBoxes and others
                }
                else
                {
                    PopUp popUp = new PopUp("خطا", "نوع پروپوزال را مشخص کنید.", "تایید", "", "", "error");
                    popUp.ShowDialog();
                }
            }

            else if (appSettingEgroupTxtbx.Enabled == true)
            {
                if (!appSettingEgroupTxtbx.Text.Equals(""))
                {
                    dbh.EditEGroup(appSettingEgroupTxtbx.Text, currentSelectedOption, 9999 /*admin*/, myDateTime.ToString());
                    appSettingEgroupTxtbx.Clear();
                    dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT groupName FROM EGroupTable WHERE facultyName ='" + appSettingFacultyTxtbx.Text + "'");
                    appSettingShowDv.Columns[0].HeaderText = "گروه آموزشی";

                    form_initializer(); // To Reset items of comboBoxes and others
                }
                else
                {
                    PopUp popUp = new PopUp("خطا", "نام گروه را مشخص کنید.", "تایید", "", "", "error");
                    popUp.ShowDialog();
                }
            }

            else if (appSettingCoTxtbx.Enabled == true)
            {
                if (!appSettingCoTxtbx.Text.Equals(""))
                {
                    Employers employer = new Employers();
                    employer.Index = int.Parse(currentSelectedIndex);
                    employer.OrgName = appSettingCoTxtbx.Text;
                    dbh.EditEmployer(employer,currentSelectedOption, 9999 /*admin*/, myDateTime.ToString());
                    appSettingCoTxtbx.Clear();
                    dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT * FROM employersTable");
                    appSettingShowDv.Columns[0].HeaderText = "کد سازمان";
                    appSettingShowDv.Columns[1].HeaderText = "نام سازمان";
                //    appSettingShowDv.Columns[2].Visible = false;

                    form_initializer(); // To Reset items of comboBoxes and others
                }
                else
                {
                    PopUp popUp = new PopUp("خطا", "نام سازمان را مشخص کنید.", "تایید", "", "", "error");
                    popUp.ShowDialog();
                }
            }

            else if (appSettingStatusTxtbx.Enabled == true)
            {
                if (!appSettingStatusTxtbx.Text.Equals(""))
                {
                    dbh.EditStatusType(appSettingStatusTxtbx.Text, currentSelectedOption, 9999 /*admin*/, myDateTime.ToString());
                    appSettingStatusTxtbx.Clear();
                    dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT statusType FROM statusTypeTable");
                    appSettingShowDv.Columns[0].HeaderText = "نوع وضعیت";

                    form_initializer(); // To Reset items of comboBoxes and others
                }
                else
                {
                    PopUp popUp = new PopUp("خطا", "نوع وضعیت را مشخص کنید.", "تایید", "", "", "error");
                    popUp.ShowDialog();
                }
            }
        }

        private void appSettingShowDv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (appSettingProcedureTypeTxtbx.Enabled == true)
            {
                appSettingEditBtn.Enabled = true;
                appSettingDeleteBtn.Enabled = true;
                try
                {
                    currentSelectedOption = appSettingShowDv.Rows[e.RowIndex].Cells["procedureType"].Value.ToString();
                    appSettingProcedureTypeTxtbx.Text = currentSelectedOption;
                }
                catch (ArgumentOutOfRangeException) { }
            }

            else if (appSettingPropertyTxtbx.Enabled == true)
            {
                appSettingEditBtn.Enabled = true;
                appSettingDeleteBtn.Enabled = true;

                try
                {
                    currentSelectedOption = appSettingShowDv.Rows[e.RowIndex].Cells["propertyType"].Value.ToString();
                    appSettingPropertyTxtbx.Text = currentSelectedOption;
                }
                catch (ArgumentOutOfRangeException) { }
            }

            else if (appSettingFacultyTxtbx.Enabled == true)
            {
                appSettingEditBtn.Enabled = true;
                appSettingDeleteBtn.Enabled = true;

                try
                {
                    currentSelectedOption = appSettingShowDv.Rows[e.RowIndex].Cells["facultyName"].Value.ToString();
                    appSettingFacultyTxtbx.Text = currentSelectedOption;
                }
                catch (ArgumentOutOfRangeException) { }
               
            }

            else if (appSettingRegTypeTxtbx.Enabled == true)
            {
                appSettingEditBtn.Enabled = true;
                appSettingDeleteBtn.Enabled = true;

                try
                {
                    currentSelectedOption = appSettingShowDv.Rows[e.RowIndex].Cells["registerType"].Value.ToString();
                    appSettingRegTypeTxtbx.Text = currentSelectedOption;
                }
                catch (ArgumentOutOfRangeException) { }
            }

            else if (appSettingProTypeTxtbx.Enabled == true)
            {
                appSettingEditBtn.Enabled = true;
                appSettingDeleteBtn.Enabled = true;

                try
                {
                    currentSelectedOption = appSettingShowDv.Rows[e.RowIndex].Cells["proposalType"].Value.ToString();
                    appSettingProTypeTxtbx.Text = currentSelectedOption;
                }
                catch (ArgumentOutOfRangeException) { }
            }

            else if (appSettingEgroupTxtbx.Enabled == true)
            {
                appSettingEditBtn.Enabled = true;
                appSettingDeleteBtn.Enabled = true;

                try
                {
                    currentSelectedOption = appSettingShowDv.Rows[e.RowIndex].Cells["groupName"].Value.ToString();
                    appSettingEgroupTxtbx.Text = currentSelectedOption;
                }
                catch (ArgumentOutOfRangeException) { }
            }

            else if (appSettingCoTxtbx.Enabled == true)
            {
                appSettingEditBtn.Enabled = true;
                appSettingDeleteBtn.Enabled = true;

                try
                {
                    currentSelectedIndex = appSettingShowDv.Rows[e.RowIndex].Cells["index"].Value.ToString();
                    currentSelectedOption = appSettingShowDv.Rows[e.RowIndex].Cells["orgName"].Value.ToString();
                    appSettingCoTxtbx.Text = currentSelectedOption;
                }
                catch (ArgumentOutOfRangeException) { }
            }

            else if (appSettingStatusTxtbx.Enabled == true)
            {
                appSettingEditBtn.Enabled = true;
                appSettingDeleteBtn.Enabled = true;

                try
                {
                    currentSelectedOption = appSettingShowDv.Rows[e.RowIndex].Cells["statusType"].Value.ToString();
                    appSettingStatusTxtbx.Text = currentSelectedOption;
                }
                catch (ArgumentOutOfRangeException) { }
            }

        }

        private void appSettingDeleteBtn_Click(object sender, EventArgs e)
        {
            if (appSettingProcedureTypeTxtbx.Enabled == true)
            {
                dbh.DeleteProcedureType(currentSelectedOption, 9999 /*admin*/, myDateTime.ToString());
                appSettingProcedureTypeTxtbx.Clear();
                dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT procedureType FROM procedureTypeTable");
                appSettingShowDv.Columns[0].HeaderText = "نوع کار";
                appSettingEditBtn.Enabled = false;
                appSettingDeleteBtn.Enabled = false;

                form_initializer(); // To Reset items of comboBoxes and others
            }

            else if (appSettingPropertyTxtbx.Enabled == true)
            {
                dbh.DeletePropertyType(currentSelectedOption, 9999 /*admin*/, myDateTime.ToString());
                appSettingPropertyTxtbx.Clear();
                dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT propertyType FROM propertyTypeTable");
                appSettingShowDv.Columns[0].HeaderText = "نوع خاصیت";
                appSettingEditBtn.Enabled = false;
                appSettingDeleteBtn.Enabled = false;

                form_initializer(); // To Reset items of comboBoxes and others
            }

            else if (appSettingFacultyTxtbx.Enabled == true)
            {
                dbh.DeleteFaculty(currentSelectedOption, 9999 /*admin*/, myDateTime.ToString());
                appSettingFacultyTxtbx.Clear();
                dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT facultyName FROM facultyTable");
                appSettingShowDv.Columns[0].HeaderText = "نام دانشکده";
                appSettingEditBtn.Enabled = false;
                appSettingDeleteBtn.Enabled = false;

                form_initializer(); // To Reset items of comboBoxes and others
            }

            else if (appSettingRegTypeTxtbx.Enabled == true)
            {
                dbh.DeleteRegisterType(currentSelectedOption, 9999 /*admin*/, myDateTime.ToString());
                appSettingRegTypeTxtbx.Clear();
                dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT registerType FROM registerTypeTable");
                appSettingShowDv.Columns[0].HeaderText = "نوع ثبت";
                appSettingEditBtn.Enabled = false;
                appSettingDeleteBtn.Enabled = false;

                form_initializer(); // To Reset items of comboBoxes and others
            }

            else if (appSettingProTypeTxtbx.Enabled == true)
            {
                dbh.DeleteProposalType(currentSelectedOption, 9999 /*admin*/, myDateTime.ToString());
                appSettingProTypeTxtbx.Clear();
                dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT proposalType from proposalTypeTable");
                appSettingShowDv.Columns[0].HeaderText = "نوع پروپوزال";
                appSettingEditBtn.Enabled = false;
                appSettingDeleteBtn.Enabled = false;

                form_initializer(); // To Reset items of comboBoxes and others
            }

            else if (appSettingEgroupTxtbx.Enabled == true)
            {
                dbh.DeleteEGroup(currentSelectedOption, currentSelectedOption_2 /*faculty*/, 9999 /*admin*/, myDateTime.ToString());
                appSettingEgroupTxtbx.Clear();
                dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT groupName FROM EGroupTable WHERE facultyName = '" + appSettingFacultyTxtbx.Text + "'");
                appSettingShowDv.Columns[0].HeaderText = "گروه آموزشی";
                appSettingEditBtn.Enabled = false;
                appSettingDeleteBtn.Enabled = false;

                form_initializer(); // To Reset items of comboBoxes and others
            }

            else if (appSettingCoTxtbx.Enabled == true)
            {
                
                dbh.DeleteEmployers(long.Parse(currentSelectedIndex), currentSelectedOption, 9999 /*admin*/, myDateTime.ToString());
                appSettingCoTxtbx.Clear();
                dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT * FROM employersTable");
                appSettingShowDv.Columns[0].HeaderText = "کد سازمان";
                appSettingShowDv.Columns[1].HeaderText = "نام سازمان";
              // appSettingShowDv.Columns[1].Visible = false;
                appSettingEditBtn.Enabled = false;
                appSettingDeleteBtn.Enabled = false;

                form_initializer(); // To Reset items of comboBoxes and others
            }

            else if (appSettingStatusTxtbx.Enabled == true)
            {
                dbh.DeleteStatusType(currentSelectedOption, 9999 /*admin*/, myDateTime.ToString());
                appSettingStatusTxtbx.Clear();
                dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT statusType FROM statusTypeTable");
                appSettingShowDv.Columns[0].HeaderText = "نوع وضعیت";
                appSettingEditBtn.Enabled = false;
                appSettingDeleteBtn.Enabled = false;

                form_initializer(); // To Reset items of comboBoxes and others
            }
        }

        private void appSettingShowDv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(appSettingFacultyTxtbx.Enabled == true)
            {
                appSettingBackBtn.Enabled = true;

                appSettingProcedureTypeRbtn.Enabled = false;
                appSettingPropertyRbtn.Enabled = false;
                appSettingFacultyRbtn.Enabled = false;
                appSettingRegTypeRbtn.Enabled = false;
                appSettingProTypeRbtn.Enabled = false;
                appSettingCoRbtn.Enabled = false;
                appSettingStatusRbtn.Enabled = false;

                appSettingFacultyTxtbx.Enabled = false;
                appSettingFacultyTxtbx.Text = appSettingShowDv.Rows[e.RowIndex].Cells["facultyName"].Value.ToString();
                currentSelectedOption_2 = appSettingShowDv.Rows[e.RowIndex].Cells["facultyName"].Value.ToString();

                appSettingEgroupRbtn.Select();
                appSettingEgroupTxtbx.Enabled = true;

                MessageBox.Show(appSettingShowDv.Rows[e.RowIndex].Cells["facultyName"].Value.ToString());
                dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT groupName FROM EGroupTable WHERE facultyName ='" + appSettingShowDv.Rows[e.RowIndex].Cells["facultyName"].Value.ToString() + "'");
                appSettingShowDv.Columns[0].HeaderText = "گروه آموزشی";
            }
        }

        private void searchProposalClearBtn_Click(object sender, EventArgs e)
        {
            searchProposalStartDateFromChbx.Checked = false;
            searchProposalStartDateToChbx.Checked = false;

            searchProposalExecutorNCodeTxtbx.Clear();
            searchProposalExecutorNCodeTxtbx.BackColor = Color.White;
            searchProposalExecutorFNameTxtbx.Clear();
            searchProposalExecutorLNameTxtbx.Clear();
            searchProposalExecutorFacultyCb.SelectedIndex = -1;
            searchProposalExecutorEGroupCb.SelectedIndex = -1;
            searchProposalExecutorMobileTxtbx.Clear();
            searchProposalPersianTitleTxtbx.Clear();
            searchProposalEnglishTitleTxtbx.Clear();
            searchProposalStartDateFromTimeInput.GeoDate = DateTime.Now;
            searchProposalStartDateToTimeInput.GeoDate = DateTime.Now;
            searchProposalValueFromTxtbx.Clear();
            searchProposalValueToTxtbx.Clear();
            searchProposalValueFromTxtbx.BackColor = Color.White;
            searchProposalValueToTxtbx.BackColor = Color.White;
            searchProposalProcedureTypeCb.SelectedIndex = -1;
            searchProposalPropertyTypeCb.SelectedIndex = -1;
            searchProposalRegisterTypeCb.SelectedIndex = -1;
            searchProposalTypeCb.SelectedIndex = -1;
            searchProposalOrganizationNumberCb.SelectedIndex = -1;
            searchProposalOrganizationNameCb.SelectedIndex = -1;
            searchProposalStatusCb.SelectedIndex = -1;
        }

        private void manageUserClearBtn_Click(object sender, EventArgs e)
        {
            manageUserFnameTxtbx.Clear();
            manageUserLnameTxtbx.Clear();
            manageUserNcodTxtbx.Clear();
            manageUserNcodTxtbx.BackColor = Color.White;
            manageUserPasswordTxtbx.Clear();
            manageUserEmailTxtbx.Clear();
            manageUserTellTxtbx.Clear();
            manageUserAddProCb.Checked = false;
            manageUserEditProCb.Checked = false;
            manageUserDeleteProCb.Checked = false;
            manageUserAddUserCb.Checked = false;
            manageUserEditUserCb.Checked = false;
            manageUserDeleteUserCb.Checked = false;
        }

        private void editProposalClearBtn_Click(object sender, EventArgs e)
        {
            editProposalExecutorNcodeTxtbx.BackColor = Color.White;
            editProposalExecutorNcodeTxtbx.Clear();
            editProposalExecutorFNameTxtbx.Clear();
            editProposalExecutorLNameTxtbx.Clear();
            editProposalExecutorFacultyCb.SelectedIndex = -1;
            editProposalExecutorEGroupCb.SelectedIndex = -1;
            editProposalExecutorEDegCb.SelectedIndex = -1;
            editProposalExecutorEmailTxtbx.Clear();
            editProposalExecutorEmailTxtbx.BackColor = Color.White;
            editProposalExecutorMobileTxtbx.Clear();
            editProposalExecutorTel1Txtbx.Clear();
            editProposalExecutorTel2Txtbx.Clear();
            editProposalPersianTitleTxtbx.Clear();
            editProposalEnglishTitleTxtbx.Clear();
            editProposalKeywordsTxtbx.Clear();
            editProposalExecutor2Txtbx.Clear();
            editProposalCoexecutorTxtbx.Clear();
            editProposalStartdateTimeInput.GeoDate = DateTime.Now;
            editProposalDurationTxtbx.Clear();
            editProposalDurationTxtbx.BackColor = Color.White;
            editProposalProcedureTypeCb.SelectedIndex = -1;
            editProposalPropertyTypeCb.SelectedIndex = -1;
            editProposalRegisterTypeCb.SelectedIndex = -1;
            editProposalTypeCb.SelectedIndex = -1;
            editProposalOrganizationNameCb.SelectedIndex = -1;
            editProposalOrganizationNumberCb.SelectedIndex = -1;
            editProposalOrganizationNameCb.BackColor = Color.White;
            editProposalOrganizationNumberCb.BackColor = Color.White;
            editProposalValueTxtbx.Clear();
            editProposalValueTxtbx.BackColor = Color.White;
            editProposalStatusCb.SelectedIndex = -1;
        }

        private void manageTeacherClearBtn_Click(object sender, EventArgs e)
        {
            manageTeacherExecutorNcodeTxtbx.Clear();
            manageTeacherFnameTxtbx.Clear();
            manageTeacherLnameTxtbx.Clear();
            manageTeacherExecutorEgroupCb.SelectedIndex = -1;
            manageTeacherExecutorEDegCb.SelectedIndex = -1;
            manageTeacherExecutorFacultyCb.SelectedIndex = -1;
            manageTeacherExecutorTelTxtbx.Clear();
            manageTeacherExecutorEmailTxtbx.Clear();
            manageTeacherExecutorMobileTxtbx.Clear();

            manageTeacherShowDgv.DataSource = null;
        }

        private void personalSettingClearBtn_Click(object sender, EventArgs e)
        {
            currentPasswordTxtbx.Clear();
            newPasswordTxtbx.Clear();
            confirmNewPasswordTxtbx.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            form_initializer();
        }

        private void addProposalExecutorFacultyCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(addProposalExecutorFacultyCb.SelectedIndex >-1)
            {
                addProposalExecutorEGroupCb.Items.Clear();
                comboList = dbh.getEGroup(addProposalExecutorFacultyCb.SelectedItem.ToString());
                foreach (String eGroup in comboList)
                {
                    addProposalExecutorEGroupCb.Items.Add(eGroup);
                }
            }
        }

        private void appSettingBackBtn_Click(object sender, EventArgs e)
        {
            appSettingBackBtn.Enabled = false;

            appSettingProcedureTypeRbtn.Enabled = true;
            appSettingPropertyRbtn.Enabled = true;
            appSettingFacultyRbtn.Enabled = true;
            appSettingRegTypeRbtn.Enabled = true;
            appSettingProTypeRbtn.Enabled = true;
            appSettingCoRbtn.Enabled = true;
            appSettingStatusRbtn.Enabled = true;

            appSettingFacultyRbtn.Select();
            appSettingFacultyTxtbx.Clear();
        }

        private void addProposalOrganizationNumberCb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                addProposalOrganizationNumberCb.BackColor = Color.White;
                if (addProposalOrganizationNumberCb.Text == "0")
                {
                    addProposalOrganizationNumberCb.BackColor = Color.Pink;
                }
                else
                {
                    bool isFound = false;
                    foreach (Employers employer in emp)
                    {
                        if (int.Parse(addProposalOrganizationNumberCb.Text) == employer.Index)
                        {
                            addProposalOrganizationNameCb.Text = employer.OrgName;
                            isFound = true;
                        }

                    }

                    if(!isFound)
                    {
                        addProposalOrganizationNameCb.SelectedIndex = -1;
                        addProposalOrganizationNumberCb.BackColor = Color.Pink;
                    }
                }
            }
            catch(ArgumentOutOfRangeException)
            {
                addProposalOrganizationNameCb.Text = "";
                addProposalOrganizationNameCb.SelectedIndex = -1;
                addProposalOrganizationNumberCb.BackColor = Color.Pink;
            }
            catch(FormatException)
            {
                addProposalOrganizationNameCb.Text = "";
                addProposalOrganizationNameCb.SelectedIndex = -1;
                addProposalOrganizationNumberCb.BackColor = Color.Pink;
            }
            
            if(addProposalOrganizationNumberCb.Text == "")
            {

                addProposalOrganizationNameCb.Text = "";
                addProposalOrganizationNameCb.SelectedIndex = -1;
                addProposalOrganizationNumberCb.BackColor = Color.White;
            }
        }

        private void addProposalOrganizationNameCb_TextChanged(object sender, EventArgs e)
        {
            if(addProposalOrganizationNameCb.Focused)
            {
                try
                {
                    addProposalOrganizationNumberCb.SelectedIndex = addProposalOrganizationNameCb.SelectedIndex;
                    if(!addProposalOrganizationNameCb.Items.Contains(addProposalOrganizationNameCb.Text))
                    {
                        addProposalOrganizationNameCb.BackColor = Color.Pink;
                    }
                    else
                    {
                        addProposalOrganizationNameCb.BackColor = Color.White;
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("arg");
                    addProposalOrganizationNumberCb.Text = "";
                    addProposalOrganizationNumberCb.SelectedIndex = -1;
                    addProposalOrganizationNameCb.BackColor = Color.Pink;
                }
                catch (FormatException)
                {
                    MessageBox.Show("for");
                    addProposalOrganizationNumberCb.Text = "";
                    addProposalOrganizationNumberCb.SelectedIndex = -1;
                    addProposalOrganizationNameCb.BackColor = Color.Pink;
                }

                if (addProposalOrganizationNameCb.Text == "")
                {

                    addProposalOrganizationNumberCb.Text = "";
                    addProposalOrganizationNumberCb.SelectedIndex = -1;
                    addProposalOrganizationNameCb.BackColor = Color.White;
                }
            }
        }

        private void addProposalOrganizationNameCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (addProposalOrganizationNameCb.Focused)
            {
                try
                {
                    addProposalOrganizationNumberCb.SelectedIndex = addProposalOrganizationNameCb.SelectedIndex;
                    if (!addProposalOrganizationNameCb.Items.Contains(addProposalOrganizationNameCb.Text))
                    {
                        addProposalOrganizationNameCb.BackColor = Color.Pink;
                    }
                    else
                    {
                        addProposalOrganizationNameCb.BackColor = Color.White;
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("arg");
                    addProposalOrganizationNumberCb.Text = "";
                    addProposalOrganizationNumberCb.SelectedIndex = -1;
                    addProposalOrganizationNameCb.BackColor = Color.Pink;
                }
                catch (FormatException)
                {
                    MessageBox.Show("for");
                    addProposalOrganizationNumberCb.Text = "";
                    addProposalOrganizationNumberCb.SelectedIndex = -1;
                    addProposalOrganizationNameCb.BackColor = Color.Pink;
                }

                if (addProposalOrganizationNameCb.Text == "")
                {

                    addProposalOrganizationNumberCb.Text = "";
                    addProposalOrganizationNumberCb.SelectedIndex = -1;
                    addProposalOrganizationNameCb.BackColor = Color.White;
                }
            }
        }

        private void addProposalValueTxtbx_TextChanged(object sender, EventArgs e)
        {
            try
            {
                long onlyDigit = long.Parse(addProposalValueTxtbx.Text);
            }
            catch (FormatException)
            {
                addProposalValueTxtbx.BackColor = Color.Pink;
            }
            catch (OverflowException)
            {
                addProposalValueTxtbx.BackColor = Color.Pink;
            }
            if (addProposalValueTxtbx.Text == "")
            {
                addProposalValueTxtbx.BackColor = Color.White;
            }
        }

        private void addProposalDurationTxtbx_TextChanged(object sender, EventArgs e)
        {
            try
            {
                addProposalDurationTxtbx.BackColor = Color.White;
                int onlyDigit = int.Parse(addProposalDurationTxtbx.Text);
            }
            catch (FormatException)
            {
                addProposalDurationTxtbx.BackColor = Color.Pink;
            }
            catch (OverflowException)
            {
                addProposalDurationTxtbx.BackColor = Color.Pink;
            }
            if (addProposalDurationTxtbx.Text == "")
            {
                addProposalDurationTxtbx.BackColor = Color.White;
            }
        }

        private void addProposalExecutorTel1Txtbx_TextChanged(object sender, EventArgs e)
        {
            try
            {
                long onlyDigit = long.Parse(addProposalExecutorTel1Txtbx.Text);
            }
            catch (FormatException)
            {
                addProposalExecutorTel1Txtbx.BackColor = Color.Pink;
            }
            catch (OverflowException)
            {
                addProposalExecutorTel1Txtbx.BackColor = Color.Pink;
            }
            if (addProposalExecutorTel1Txtbx.Text == "")
            {
                addProposalExecutorTel1Txtbx.BackColor = Color.White;
            }
        }

        private void addProposalExecutorTel2Txtbx_TextChanged(object sender, EventArgs e)
        {
            try
            {
                long onlyDigit = long.Parse(addProposalExecutorTel2Txtbx.Text);
            }
            catch (FormatException)
            {
                addProposalExecutorTel2Txtbx.BackColor = Color.Pink;
            }
            catch (OverflowException)
            {
                addProposalExecutorTel2Txtbx.BackColor = Color.Pink;
            }
            if (addProposalExecutorTel2Txtbx.Text == "")
            {
                addProposalExecutorTel2Txtbx.BackColor = Color.White;
            }
        }

        private void addProposalExecutorMobileTxtbx_TextChanged(object sender, EventArgs e)
        {
            try
            {
                long onlyDigit = long.Parse(addProposalExecutorMobileTxtbx.Text);
            }
            catch (FormatException)
            {
                addProposalExecutorMobileTxtbx.BackColor = Color.Pink;
            }
            catch (OverflowException)
            {
                addProposalExecutorMobileTxtbx.BackColor = Color.Pink;
            }
            if (addProposalExecutorMobileTxtbx.Text == "")
            {
                addProposalExecutorMobileTxtbx.BackColor = Color.White;
            }
        }

        private void addProposalExecutorEmailTxtbx_TextChanged(object sender, EventArgs e)
        {
            addProposalExecutorEmailTxtbx.BackColor = Color.White;
        }

        private void sysLogTab_Click(object sender, EventArgs e)
        {
            dbh.dataGridViewUpdate(logDgv, logBindingSource, "SELECT * FROM logTable");
        }

        private void searchProposalExecutorNCodeTxtbx_TextChanged(object sender, EventArgs e)
        {
            if (searchProposalExecutorNCodeTxtbx.Text.Length == 10)
            {
                MessageBox.Show("چک موجود بودن استاد");
                searchProposalExecutorNCodeTxtbx.BackColor = Color.LightGreen;
            }
            else
            {
                searchProposalExecutorNCodeTxtbx.BackColor = Color.White;
            }
        }

        private void addProposalExecutorNcodeTxtbx_TextChanged(object sender, EventArgs e)
        {
            if(addProposalExecutorNcodeTxtbx.Text.Length == 10)
            {
                addProposalExecutorNcodeTxtbx.BackColor = Color.LightGreen;

                addProposalExecutorEDegCb.Items.Clear();
                comboList = dbh.getEDeg();
                foreach (String eDegree in comboList)
                {
                    addProposalExecutorEDegCb.Items.Add(eDegree);
                }

                Teachers teacher = new Teachers();

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "Data Source= 185.159.152.2;" +
                "Initial Catalog=rayanpro_EBS;" +
                "User id=rayanpro_rayan; " +
                "Password=P@hn1395;";

                SqlCommand sc = new SqlCommand();
                SqlDataReader reader;
                sc.CommandText = "SELECT * FROM TeacherTable WHERE t_NCode = '" + addProposalExecutorNcodeTxtbx.Text +"'";
                sc.CommandType = CommandType.Text;
                sc.Connection = conn;
                conn.Open();
                reader = sc.ExecuteReader();
                if(reader.HasRows)
                {
                    reader.Read();

                    teacher.T_FName = reader["t_FName"].ToString();
                    teacher.T_LName = reader["t_LName"].ToString();
                    teacher.T_NCode = long.Parse(reader["t_NCode"].ToString());
                    teacher.T_EDeg = reader["t_EDeg"].ToString();
                    teacher.T_Email = reader["t_Email"].ToString();
                    teacher.T_Mobile = reader["t_Mobile"].ToString();
                    teacher.T_Tel1 = reader["t_Tel1"].ToString();
                    teacher.T_Tel2 = reader["t_Tel2"].ToString();
                    teacher.T_Faculty = reader["t_Faculty"].ToString();
                    teacher.T_Group = reader["t_Group"].ToString();

                    addProposalExecutorFNameTxtbx.Text = teacher.T_FName;
                    addProposalExecutorLNameTxtbx.Text = teacher.T_LName;
                    addProposalExecutorFacultyCb.Text = teacher.T_Faculty;

                    addProposalExecutorEGroupCb.Items.Clear();
                    comboList = dbh.getEGroup(addProposalExecutorFacultyCb.SelectedItem.ToString());
                    foreach (String eGroup in comboList)
                    {
                        addProposalExecutorEGroupCb.Items.Add(eGroup);
                    }

                    //Fill componenets with existing information
                    addProposalExecutorEGroupCb.Text = teacher.T_Group;
                    addProposalExecutorEDegCb.Text = teacher.T_EDeg;
                    addProposalExecutorEmailTxtbx.Text = teacher.T_Email;
                    addProposalExecutorMobileTxtbx.Text = teacher.T_Mobile;
                    addProposalExecutorTel1Txtbx.Text = teacher.T_Tel1;
                    addProposalExecutorTel2Txtbx.Text = teacher.T_Tel2;

                    //make components uneditable
                    addProposalExecutorFNameTxtbx.Enabled = false;
                    addProposalExecutorLNameTxtbx.Enabled = false;
                    addProposalExecutorFacultyCb.Enabled = false;
                    addProposalExecutorEGroupCb.Enabled = false;
                    addProposalExecutorEDegCb.Enabled = false;
                    addProposalExecutorEmailTxtbx.Enabled = false;
                    addProposalExecutorMobileTxtbx.Enabled = false;
                    addProposalExecutorTel1Txtbx.Enabled = false;
                    addProposalExecutorTel2Txtbx.Enabled = false;
                }
                
                else
                {
                    PopUp p = new PopUp("ثبت اطلاعات جدید", "استادی با کد ملی وارد شده در سیستم ثبت نشده است.", "ثبت اطلاعات استاد جدید", "تغییر کد ملی وارد شده", "", "info");
                    p.ShowDialog();
                    if (p.DialogResult == DialogResult.Yes)
                    {
                        addProposalExecutorFNameTxtbx.Focus();
                        isNewTeacher = true;
                    }

                    else
                    {
                        addProposalExecutorNcodeTxtbx.BackColor = Color.White;
                        addProposalExecutorNcodeTxtbx.Clear();
                    }
                }

                conn.Close();
            }
            else
            {
                addProposalExecutorNcodeTxtbx.BackColor = Color.White;

                addProposalExecutorFNameTxtbx.Enabled = true;
                addProposalExecutorLNameTxtbx.Enabled = true;;
                addProposalExecutorFacultyCb.Enabled = true;
                addProposalExecutorEGroupCb.Enabled = true;
                addProposalExecutorEDegCb.Enabled = true;
                addProposalExecutorEmailTxtbx.Enabled = true;
                addProposalExecutorMobileTxtbx.Enabled = true;
                addProposalExecutorTel1Txtbx.Enabled = true;
                addProposalExecutorTel2Txtbx.Enabled = true;

                addProposalExecutorFNameTxtbx.Clear();
                addProposalExecutorLNameTxtbx.Clear();
                addProposalExecutorFacultyCb.SelectedIndex = -1;
                addProposalExecutorEGroupCb.SelectedIndex = -1;
                addProposalExecutorEGroupCb.Items.Clear();
                addProposalExecutorEDegCb.SelectedIndex = -1;
                addProposalExecutorEmailTxtbx.Clear();
                addProposalExecutorMobileTxtbx.Clear();
                addProposalExecutorTel1Txtbx.Clear();
                addProposalExecutorTel2Txtbx.Clear();
            }
        }

        private void addProposalTab_Click(object sender, EventArgs e)
        {
            addProposalExecutorNcodeTxtbx.Focus();
        }

        private void searchProposalExecutorMobileTxtbx_TextChanged(object sender, EventArgs e)
        {
            try
            {
                long onlyDigit = long.Parse(searchProposalExecutorMobileTxtbx.Text);
            }
            catch (FormatException)
            {
                searchProposalExecutorMobileTxtbx.BackColor = Color.Pink;
            }
            catch (OverflowException)
            {
                searchProposalExecutorMobileTxtbx.BackColor = Color.Pink;
            }
            if (searchProposalExecutorMobileTxtbx.Text == "")
            {
                searchProposalExecutorMobileTxtbx.BackColor = Color.White;
            }
        }

        private void searchProposalValueFromTxtbx_TextChanged(object sender, EventArgs e)
        {
            try
            {
                long onlyDigit = long.Parse(searchProposalValueFromTxtbx.Text);
            }
            catch (FormatException)
            {
                searchProposalValueFromTxtbx.BackColor = Color.Pink;
            }
            catch (OverflowException)
            {
                searchProposalValueFromTxtbx.BackColor = Color.Pink;
            }
            if (searchProposalValueFromTxtbx.Text == "")
            {
                searchProposalValueFromTxtbx.BackColor = Color.White;
            }
        }

        private void searchProposalValueToTxtbx_TextChanged(object sender, EventArgs e)
        {
            try
            {
                long onlyDigit = long.Parse(searchProposalValueToTxtbx.Text);
            }
            catch (FormatException)
            {
                searchProposalValueToTxtbx.BackColor = Color.Pink;
            }
            catch (OverflowException)
            {
                searchProposalValueToTxtbx.BackColor = Color.Pink;
            }
            if (searchProposalValueToTxtbx.Text == "")
            {
                searchProposalValueToTxtbx.BackColor = Color.White;
            }
        }

        private void searchProposalExecutorFacultyCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(searchProposalExecutorFacultyCb.SelectedIndex > -1)
            {
                searchProposalExecutorEGroupCb.Items.Clear();
                comboList = dbh.getEGroup(searchProposalExecutorFacultyCb.SelectedItem.ToString());
                foreach (String eGroup in comboList)
                {
                    searchProposalExecutorEGroupCb.Items.Add(eGroup);
                }
            }  
        }

        private void searchProposalOrganizationNumberCb_TextChanged(object sender, EventArgs e)
        {
            searchProposalOrganizationNumberCb.BackColor = Color.White;
            try
            {
                if (searchProposalOrganizationNumberCb.Text == "0")
                {
                    searchProposalOrganizationNumberCb.BackColor = Color.Pink;
                }
                else
                {
                    bool isFound = false;
                    foreach (Employers employer in emp)
                    {
                        if (int.Parse(searchProposalOrganizationNumberCb.Text) == employer.Index)
                        {
                            searchProposalOrganizationNameCb.Text = employer.OrgName;
                            isFound = true;
                        }

                    }

                    if (!isFound)
                    {
                        searchProposalOrganizationNameCb.SelectedIndex = -1;
                        searchProposalOrganizationNumberCb.BackColor = Color.Pink;
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                searchProposalOrganizationNameCb.Text = "";
                searchProposalOrganizationNameCb.SelectedIndex = -1;
                searchProposalOrganizationNumberCb.BackColor = Color.Pink;
            }
            catch (FormatException)
            {
                searchProposalOrganizationNameCb.Text = "";
                searchProposalOrganizationNameCb.SelectedIndex = -1;
                searchProposalOrganizationNumberCb.BackColor = Color.Pink;
            }

            if (searchProposalOrganizationNumberCb.Text == "")
            {

                searchProposalOrganizationNameCb.Text = "";
                searchProposalOrganizationNameCb.SelectedIndex = -1;
                searchProposalOrganizationNumberCb.BackColor = Color.White;
            }
        }

        private void searchProposalOrganizationNameCb_TextChanged(object sender, EventArgs e)
        {
            if (searchProposalOrganizationNameCb.Focused)
            {
                try
                {
                    searchProposalOrganizationNumberCb.SelectedIndex = searchProposalOrganizationNameCb.SelectedIndex;
                    if (!searchProposalOrganizationNameCb.Items.Contains(searchProposalOrganizationNameCb.Text))
                    {
                        searchProposalOrganizationNameCb.BackColor = Color.Pink;
                    }
                    else
                    {
                        searchProposalOrganizationNameCb.BackColor = Color.White;
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("arg");
                    searchProposalOrganizationNumberCb.Text = "";
                    searchProposalOrganizationNumberCb.SelectedIndex = -1;
                    searchProposalOrganizationNameCb.BackColor = Color.Pink;
                }
                catch (FormatException)
                {
                    MessageBox.Show("for");
                    searchProposalOrganizationNumberCb.Text = "";
                    searchProposalOrganizationNumberCb.SelectedIndex = -1;
                    searchProposalOrganizationNameCb.BackColor = Color.Pink;
                }

                if (searchProposalOrganizationNameCb.Text == "")
                {

                    searchProposalOrganizationNumberCb.Text = "";
                    searchProposalOrganizationNumberCb.SelectedIndex = -1;
                    searchProposalOrganizationNameCb.BackColor = Color.White;
                }
            }
        }

        private void searchProposalOrganizationNameCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (searchProposalOrganizationNameCb.Focused)
            {
                try
                {
                    searchProposalOrganizationNumberCb.SelectedIndex = searchProposalOrganizationNameCb.SelectedIndex;
                    if (!searchProposalOrganizationNameCb.Items.Contains(searchProposalOrganizationNameCb.Text))
                    {
                        searchProposalOrganizationNameCb.BackColor = Color.Pink;
                    }
                    else
                    {
                        searchProposalOrganizationNameCb.BackColor = Color.White;
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("arg");
                    searchProposalOrganizationNumberCb.Text = "";
                    searchProposalOrganizationNumberCb.SelectedIndex = -1;
                    searchProposalOrganizationNameCb.BackColor = Color.Pink;
                }
                catch (FormatException)
                {
                    MessageBox.Show("for");
                    searchProposalOrganizationNumberCb.Text = "";
                    searchProposalOrganizationNumberCb.SelectedIndex = -1;
                    searchProposalOrganizationNameCb.BackColor = Color.Pink;
                }

                if (searchProposalOrganizationNameCb.Text == "")
                {
                    searchProposalOrganizationNumberCb.Text = "";
                    searchProposalOrganizationNumberCb.SelectedIndex = -1;
                    searchProposalOrganizationNameCb.BackColor = Color.White;
                }
            }
        }

        private void addProposalOrganizationNumberCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                addProposalOrganizationNumberCb.BackColor = Color.White;
                if (addProposalOrganizationNumberCb.Text == "0")
                {
                    addProposalOrganizationNumberCb.BackColor = Color.Pink;
                }
                else
                {
                    bool isFound = false;
                    foreach (Employers employer in emp)
                    {
                        if (int.Parse(addProposalOrganizationNumberCb.Text) == employer.Index)
                        {
                            addProposalOrganizationNameCb.Text = employer.OrgName;
                            isFound = true;
                        }
                    }

                    if (!isFound)
                    {
                        addProposalOrganizationNameCb.SelectedIndex = -1;
                        addProposalOrganizationNumberCb.BackColor = Color.Pink;
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                addProposalOrganizationNameCb.Text = "";
                addProposalOrganizationNameCb.SelectedIndex = -1;
                addProposalOrganizationNumberCb.BackColor = Color.Pink;
            }
            catch (FormatException)
            {
                addProposalOrganizationNameCb.Text = "";
                addProposalOrganizationNameCb.SelectedIndex = -1;
                addProposalOrganizationNumberCb.BackColor = Color.Pink;
            }

            if (addProposalOrganizationNumberCb.Text == "")
            {
                addProposalOrganizationNameCb.Text = "";
                addProposalOrganizationNameCb.SelectedIndex = -1;
                addProposalOrganizationNumberCb.BackColor = Color.White;
            }
        }

        private void searchProposalOrganizationNumberCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                searchProposalOrganizationNumberCb.BackColor = Color.White;
                if (searchProposalOrganizationNumberCb.Text == "0")
                {
                    searchProposalOrganizationNumberCb.BackColor = Color.Pink;
                }
                else
                {
                    bool isFound = false;
                    foreach (Employers employer in emp)
                    {
                        if (int.Parse(searchProposalOrganizationNumberCb.Text) == employer.Index)
                        {
                            searchProposalOrganizationNameCb.Text = employer.OrgName;
                            isFound = true;
                        }

                    }

                    if (!isFound)
                    {
                        searchProposalOrganizationNameCb.SelectedIndex = -1;
                        searchProposalOrganizationNumberCb.BackColor = Color.Pink;
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                searchProposalOrganizationNameCb.Text = "";
                searchProposalOrganizationNameCb.SelectedIndex = -1;
                searchProposalOrganizationNumberCb.BackColor = Color.Pink;
            }
            catch (FormatException)
            {
                searchProposalOrganizationNameCb.Text = "";
                searchProposalOrganizationNameCb.SelectedIndex = -1;
                searchProposalOrganizationNumberCb.BackColor = Color.Pink;
            }

            if (searchProposalOrganizationNumberCb.Text == "")
            {
                searchProposalOrganizationNameCb.Text = "";
                searchProposalOrganizationNameCb.SelectedIndex = -1;
                searchProposalOrganizationNumberCb.BackColor = Color.White;
            }
        }

        private void manageUserAddBtn_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.U_FName = manageUserFnameTxtbx.Text;
            user.U_LName = manageUserLnameTxtbx.Text;
            user.U_NCode = long.Parse(manageUserNcodTxtbx.Text);
            user.U_Email = manageUserEmailTxtbx.Text;
            user.U_Tel = manageUserTellTxtbx.Text;
            user.U_Password = manageUserPasswordTxtbx.Text;

            if (manageUserAddProCb.Checked == true)
            {
                user.CanAddProposal = 1;
            }
            else
            {
                user.CanAddProposal = 0;
            }

            if (manageUserEditProCb.Checked == true)
            {
                user.CanEditProposal = 1;
            }
            else
            {
                user.CanEditProposal = 0;
            }
            if (manageUserDeleteProCb.Checked == true)
            {
                user.CanDeleteProposal = 1;
            }
            else
            {
                user.CanDeleteProposal = 0;
            }
            if (manageUserAddUserCb.Checked == true)
            {
                user.CanAddUser = 1;
            }
            else
            {
                user.CanAddUser = 0;
            }
            if (manageUserEditUserCb.Checked == true)
            {
                user.CanEditUser = 1;
            }
            else
            {
                user.CanEditUser = 0;
            }
            if (manageUserDeleteUserCb.Checked == true)
            {
                user.CanDeleteUser = 1;
            }
            else
            {
                user.CanDeleteUser = 0;
            }

            dbh.AddUser(user, 9999, myDateTime.ToString());
            dbh.dataGridViewUpdate(manageUserDgv, usersBindingSource, "SELECT * FROM UsersTable");

            manageUserClearBtn.PerformClick();
        }

        private void manageUserEditBtn_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.U_FName = manageUserFnameTxtbx.Text;
            user.U_LName = manageUserLnameTxtbx.Text;
            user.U_NCode = long.Parse(manageUserNcodTxtbx.Text);
            user.U_Email = manageUserEmailTxtbx.Text;
            user.U_Tel = manageUserTellTxtbx.Text;
            user.U_Password = manageUserPasswordTxtbx.Text;

            if (manageUserAddProCb.Checked == true)
            {
                user.CanAddProposal = 1;
            }
            else
            {
                user.CanAddProposal = 0;
            }

            if (manageUserEditProCb.Checked == true)
            {
                user.CanEditProposal = 1;
            }
            else
            {
                user.CanEditProposal = 0;
            }
            if (manageUserDeleteProCb.Checked == true)
            {
                user.CanDeleteProposal = 1;
            }
            else
            {
                user.CanDeleteProposal = 0;
            }
            if (manageUserAddUserCb.Checked == true)
            {
                user.CanAddUser = 1;
            }
            else
            {
                user.CanAddUser = 0;
            }
            if (manageUserEditUserCb.Checked == true)
            {
                user.CanEditUser = 1;
            }
            else
            {
                user.CanEditUser = 0;
            }
            if (manageUserDeleteUserCb.Checked == true)
            {
                user.CanDeleteUser = 1;
            }
            else
            {
                user.CanDeleteUser = 0;
            }

            dbh.EditUsers(user, long.Parse(currentSelectedOption), 9999, myDateTime.ToString());
            dbh.dataGridViewUpdate(manageUserDgv, usersBindingSource, "SELECT * FROM UsersTable");

            manageUserClearBtn.PerformClick();
        }

        private void manageUserDeleteBtn_Click(object sender, EventArgs e)
        {
            User user = new User();

            user.U_NCode = long.Parse(currentSelectedOption);
            user.U_FName = manageUserFnameTxtbx.Text;
            user.U_LName = manageUserLnameTxtbx.Text;
            user.U_Email = manageUserEmailTxtbx.Text;
            user.U_Tel = manageUserTellTxtbx.Text;
            user.U_Password = manageUserPasswordTxtbx.Text;

            if (manageUserAddProCb.Checked == true)
            {
                user.CanAddProposal = 1;
            }
            else
            {
                user.CanAddProposal = 0;
            }

            if (manageUserEditProCb.Checked == true)
            {
                user.CanEditProposal = 1;
            }
            else
            {
                user.CanEditProposal = 0;
            }
            if (manageUserDeleteProCb.Checked == true)
            {
                user.CanDeleteProposal = 1;
            }
            else
            {
                user.CanDeleteProposal = 0;
            }
            if (manageUserAddUserCb.Checked == true)
            {
                user.CanAddUser = 1;
            }
            else
            {
                user.CanAddUser = 0;
            }
            if (manageUserEditUserCb.Checked == true)
            {
                user.CanEditUser = 1;
            }
            else
            {
                user.CanEditUser = 0;
            }
            if (manageUserDeleteUserCb.Checked == true)
            {
                user.CanDeleteUser = 1;
            }
            else
            {
                user.CanDeleteUser = 0;
            }

            dbh.DeleteUser(user, 9999, myDateTime.ToString());
            dbh.dataGridViewUpdate(manageUserDgv, usersBindingSource, "SELECT * FROM UsersTable");
            manageUserClearBtn.PerformClick();
        }

        private void manageTeacherExecutorFacultyCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (manageTeacherExecutorFacultyCb.SelectedIndex > -1)
            {
                manageTeacherExecutorEgroupCb.Items.Clear();
                comboList = dbh.getEGroup(manageTeacherExecutorFacultyCb.SelectedItem.ToString());
                foreach (String eGroup in comboList)
                {
                    manageTeacherExecutorEgroupCb.Items.Add(eGroup);
                }
            }
        }

        private void addProposalExecutorEmailTxtbx_Leave(object sender, EventArgs e)
        {
            if (!addProposalExecutorEmailTxtbx.Text.Equals("") && !System.Text.RegularExpressions.Regex.IsMatch(addProposalExecutorEmailTxtbx.Text, @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"))
            {
                addProposalExecutorEmailTxtbx.BackColor = Color.Pink;
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(addProposalExecutorEmailTxtbx.Text, @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"))
            {
                addProposalExecutorEmailTxtbx.BackColor = Color.LightGreen;
            }
        }

        private void addProposalExecutorNcodeTxtbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void editProposalExecutorNcodeTxtbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void searchProposalExecutorNCodeTxtbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void searchProposalValueFromTxtbx_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                long onlyDigit = long.Parse(searchProposalValueFromTxtbx.Text);
            }
            catch (FormatException)
            {
                searchProposalValueFromTxtbx.BackColor = Color.Pink;
            }
            catch (OverflowException)
            {
                searchProposalValueFromTxtbx.BackColor = Color.Pink;
            }
            if (searchProposalValueFromTxtbx.Text == "")
            {
                searchProposalValueFromTxtbx.BackColor = Color.White;
            }
        }

        private void searchProposalValueToTxtbx_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                long onlyDigit = long.Parse(searchProposalValueToTxtbx.Text);
            }
            catch (FormatException)
            {
                searchProposalValueToTxtbx.BackColor = Color.Pink;
            }
            catch (OverflowException)
            {
                searchProposalValueToTxtbx.BackColor = Color.Pink;
            }
            if (searchProposalValueToTxtbx.Text == "")
            {
                searchProposalValueToTxtbx.BackColor = Color.White;
            }
        }

        private void manageUserNcodTxtbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void manageUserEmailTxtbx_TextChanged(object sender, EventArgs e)
        {
            manageUserEmailTxtbx.BackColor = Color.White;
        }

        private void manageUserEmailTxtbx_Leave(object sender, EventArgs e)
        {
            if (!manageUserEmailTxtbx.Text.Equals("") && !System.Text.RegularExpressions.Regex.IsMatch(manageUserEmailTxtbx.Text, @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"))
            {
                manageUserEmailTxtbx.BackColor = Color.Pink;
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(manageUserEmailTxtbx.Text, @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"))
            {
                manageUserEmailTxtbx.BackColor = Color.LightGreen;
            }
        }

        private void manageUserNcodTxtbx_TextChanged(object sender, EventArgs e)
        {
            if (manageUserNcodTxtbx.Text.Length == 10)
            {
                manageUserNcodTxtbx.BackColor = Color.LightGreen;
                MessageBox.Show("چک موجود بودن استاد");
            }
            else
            {
                manageUserNcodTxtbx.BackColor = Color.White;
            }
        }

        private void manageUserNcodTxtbx_Leave(object sender, EventArgs e)
        {
            if (manageUserNcodTxtbx.Text.Length < 10)
            {
                manageUserNcodTxtbx.BackColor = Color.Pink;
            }
        }

        private void editProposalExecutorNcodeTxtbx_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void editProposalExecutorNcodeTxtbx_TextChanged(object sender, EventArgs e)
        {
            if (editProposalExecutorNcodeTxtbx.Text.Length == 10)
            {
                editProposalExecutorNcodeTxtbx.BackColor = Color.LightGreen;
                MessageBox.Show("چک موجود بودن استاد");
            }
            else
            {
                editProposalExecutorNcodeTxtbx.BackColor = Color.White;
            }
        }

        private void editProposalExecutorNcodeTxtbx_Leave(object sender, EventArgs e)
        {
            if (editProposalExecutorNcodeTxtbx.Text.Length < 10)
            {
                editProposalExecutorNcodeTxtbx.BackColor = Color.Pink;
            }
        }

        private void editProposalExecutorEmailTxtbx_TextChanged(object sender, EventArgs e)
        {
            editProposalExecutorEmailTxtbx.BackColor = Color.White;

        }

        private void editProposalExecutorEmailTxtbx_Leave(object sender, EventArgs e)
        {
            if (!editProposalExecutorEmailTxtbx.Text.Equals("") && !System.Text.RegularExpressions.Regex.IsMatch(editProposalExecutorEmailTxtbx.Text, @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"))
            {
                editProposalExecutorEmailTxtbx.BackColor = Color.Pink;
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(editProposalExecutorEmailTxtbx.Text, @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"))
            {
                editProposalExecutorEmailTxtbx.BackColor = Color.LightGreen;
            }
        }

        private void editProposalDurationTxtbx_TextChanged(object sender, EventArgs e)
        {
            try
            {
                editProposalDurationTxtbx.BackColor = Color.White;
                int onlyDigit = int.Parse(editProposalDurationTxtbx.Text);
            }
            catch (FormatException)
            {
                editProposalDurationTxtbx.BackColor = Color.Pink;
            }
            catch (OverflowException)
            {
                editProposalDurationTxtbx.BackColor = Color.Pink;
            }
            if (editProposalDurationTxtbx.Text == "")
            {
                editProposalDurationTxtbx.BackColor = Color.White;
            }
        }

        private void editProposalValueTxtbx_TextChanged(object sender, EventArgs e)
        {
            try
            {
                editProposalValueTxtbx.BackColor = Color.White;
                int onlyDigit = int.Parse(editProposalValueTxtbx.Text);
            }
            catch (FormatException)
            {
                editProposalValueTxtbx.BackColor = Color.Pink;
            }
            catch (OverflowException)
            {
                editProposalValueTxtbx.BackColor = Color.Pink;
            }
            if (editProposalValueTxtbx.Text == "")
            {
                editProposalValueTxtbx.BackColor = Color.White;
            }
        }

        private void editProposalOrganizationNumberCb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                editProposalOrganizationNumberCb.BackColor = Color.White;
                if (editProposalOrganizationNumberCb.Text == "0")
                {
                    editProposalOrganizationNumberCb.BackColor = Color.Pink;
                }
                else
                {
                    bool isFound = false;
                    foreach (Employers employer in emp)
                    {
                        if (int.Parse(editProposalOrganizationNumberCb.Text) == employer.Index)
                        {
                            editProposalOrganizationNameCb.Text = employer.OrgName;
                            isFound = true;
                        }

                    }

                    if (!isFound)
                    {
                        editProposalOrganizationNameCb.SelectedIndex = -1;
                        editProposalOrganizationNumberCb.BackColor = Color.Pink;
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                editProposalOrganizationNameCb.Text = "";
                editProposalOrganizationNameCb.SelectedIndex = -1;
                editProposalOrganizationNumberCb.BackColor = Color.Pink;
            }
            catch (FormatException)
            {
                editProposalOrganizationNameCb.Text = "";
                editProposalOrganizationNameCb.SelectedIndex = -1;
                editProposalOrganizationNumberCb.BackColor = Color.Pink;
            }

            if (editProposalOrganizationNumberCb.Text == "")
            {

                editProposalOrganizationNameCb.Text = "";
                editProposalOrganizationNameCb.SelectedIndex = -1;
                editProposalOrganizationNumberCb.BackColor = Color.White;
            }
        }

        private void editProposalOrganizationNumberCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                editProposalOrganizationNumberCb.BackColor = Color.White;
                if (editProposalOrganizationNumberCb.Text == "0")
                {
                    editProposalOrganizationNumberCb.BackColor = Color.Pink;
                }
                else
                {
                    bool isFound = false;
                    foreach (Employers employer in emp)
                    {
                        if (int.Parse(editProposalOrganizationNumberCb.Text) == employer.Index)
                        {
                            editProposalOrganizationNameCb.Text = employer.OrgName;
                            isFound = true;
                        }
                    }

                    if (!isFound)
                    {
                        editProposalOrganizationNameCb.SelectedIndex = -1;
                        editProposalOrganizationNumberCb.BackColor = Color.Pink;
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                editProposalOrganizationNameCb.Text = "";
                editProposalOrganizationNameCb.SelectedIndex = -1;
                editProposalOrganizationNumberCb.BackColor = Color.Pink;
            }
            catch (FormatException)
            {
                editProposalOrganizationNameCb.Text = "";
                editProposalOrganizationNameCb.SelectedIndex = -1;
                editProposalOrganizationNumberCb.BackColor = Color.Pink;
            }

            if (editProposalOrganizationNumberCb.Text == "")
            {
                editProposalOrganizationNameCb.Text = "";
                editProposalOrganizationNameCb.SelectedIndex = -1;
                editProposalOrganizationNumberCb.BackColor = Color.White;
            }
        }

        private void editProposalOrganizationNameCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (editProposalOrganizationNameCb.Focused)
            {
                try
                {
                    editProposalOrganizationNumberCb.SelectedIndex = editProposalOrganizationNameCb.SelectedIndex;
                    if (!editProposalOrganizationNameCb.Items.Contains(editProposalOrganizationNameCb.Text))
                    {
                        editProposalOrganizationNameCb.BackColor = Color.Pink;
                    }
                    else
                    {
                        editProposalOrganizationNameCb.BackColor = Color.White;
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("arg");
                    editProposalOrganizationNumberCb.Text = "";
                    editProposalOrganizationNumberCb.SelectedIndex = -1;
                    editProposalOrganizationNameCb.BackColor = Color.Pink;
                }
                catch (FormatException)
                {
                    MessageBox.Show("for");
                    editProposalOrganizationNumberCb.Text = "";
                    editProposalOrganizationNumberCb.SelectedIndex = -1;
                    editProposalOrganizationNameCb.BackColor = Color.Pink;
                }

                if (editProposalOrganizationNameCb.Text == "")
                {

                    editProposalOrganizationNumberCb.Text = "";
                    editProposalOrganizationNumberCb.SelectedIndex = -1;
                    editProposalOrganizationNameCb.BackColor = Color.White;
                }
            }
        }

        private void editProposalOrganizationNameCb_TextChanged(object sender, EventArgs e)
        {
            if (editProposalOrganizationNameCb.Focused)
            {
                try
                {
                    editProposalOrganizationNumberCb.SelectedIndex = editProposalOrganizationNameCb.SelectedIndex;
                    if (!editProposalOrganizationNameCb.Items.Contains(editProposalOrganizationNameCb.Text))
                    {
                        editProposalOrganizationNameCb.BackColor = Color.Pink;
                    }
                    else
                    {
                        editProposalOrganizationNameCb.BackColor = Color.White;
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    editProposalOrganizationNumberCb.Text = "";
                    editProposalOrganizationNumberCb.SelectedIndex = -1;
                    editProposalOrganizationNameCb.BackColor = Color.Pink;
                }
                catch (FormatException)
                {
                    editProposalOrganizationNumberCb.Text = "";
                    editProposalOrganizationNumberCb.SelectedIndex = -1;
                    editProposalOrganizationNameCb.BackColor = Color.Pink;
                }

                if (editProposalOrganizationNameCb.Text == "")
                {
                    editProposalOrganizationNumberCb.Text = "";
                    editProposalOrganizationNumberCb.SelectedIndex = -1;
                    editProposalOrganizationNameCb.BackColor = Color.White;
                }
            }
        }

        private void editProposalExecutorFacultyCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (editProposalExecutorFacultyCb.SelectedIndex > -1)
            {
                editProposalExecutorEGroupCb.Items.Clear();
                comboList = dbh.getEGroup(editProposalExecutorFacultyCb.SelectedItem.ToString());
                foreach (String eGroup in comboList)
                {
                    editProposalExecutorEGroupCb.Items.Add(eGroup);
                }
            }
        }

        private void addProposalTab_LostFocus(object sender, EventArgs e)
        {
            addProposalClearBtn.PerformClick();
        }

        private void searchProposalExecutorNCodeTxtbx_Leave(object sender, EventArgs e)
        {
            if (searchProposalExecutorNCodeTxtbx.Text.Length < 10)
            {
                searchProposalExecutorNCodeTxtbx.BackColor = Color.Pink;
            }
        }

        private void manageUserShowBtn_Click(object sender, EventArgs e)
        {
            dbh.dataGridViewUpdate(manageUserDgv, usersBindingSource, "SELECT * FROM UsersTable");
            manageUserShowBtn.Enabled = false;
        }

        private void appSettingBackgroundColorLbl_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Color c = new Color();
                c = dlg.Color;
                string myColor = "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
                dbh.changeColor(loginUser.U_NCode, myColor);
                
                homePanel.BackColor = dlg.Color;
                addProposalPanel.BackColor = dlg.Color;
                searchProposalPanel.BackColor = dlg.Color;
                manageUserPanel.BackColor = dlg.Color;
                manageTeacherPanel.BackColor = dlg.Color;
                editProposalPanel.BackColor = dlg.Color;
                appSettingPanel.BackColor = dlg.Color;
                personalSettingPanel.BackColor = dlg.Color;
                aboutUsPanel.BackColor = dlg.Color;
                logPanel.BackColor = dlg.Color;

                appSettingBackgroundColorLbl.BackColor = dlg.Color;
            }
        }

        private void wait_bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            w.ShowDialog();
        }

        private void manageTeacherAddBtn_Click(object sender, EventArgs e)
        {
            Teachers teacher = new Teachers();
            teacher.T_FName = manageTeacherFnameTxtbx.Text;
            teacher.T_LName = manageTeacherLnameTxtbx.Text;
            teacher.T_NCode = long.Parse(manageTeacherExecutorNcodeTxtbx.Text);
            teacher.T_EDeg = manageTeacherExecutorEDegCb.Text;
            teacher.T_Faculty = manageTeacherExecutorFacultyCb.Text;
            teacher.T_Group = manageTeacherExecutorEgroupCb.Text;
            teacher.T_Email = manageTeacherExecutorEmailTxtbx.Text;
            teacher.T_Mobile = manageTeacherExecutorMobileTxtbx.Text;
            teacher.T_Tel1 = manageTeacherExecutorTelTxtbx.Text;
            teacher.T_Tel2 = manageTeacherExecutorTel2Txtbx.Text;
            teacher.T_Email = manageTeacherExecutorEmailTxtbx.Text;

            dbh.AddTeacher(teacher, 9999, myDateTime.ToString());


            dbh.dataGridViewUpdate(manageTeacherShowDgv, teacherBindingSource, "SELECT * FROM TeacherTable WHERE t_NCode = '" + manageTeacherExecutorNcodeTxtbx + "'");
        }

        private void manageTeacherDeleteBtn_Click(object sender, EventArgs e)
        {
            Teachers teacher = new Teachers();
            teacher.T_FName = manageTeacherFnameTxtbx.Text;
            teacher.T_LName = manageTeacherLnameTxtbx.Text;
            teacher.T_NCode = long.Parse(manageTeacherExecutorNcodeTxtbx.Text);
            teacher.T_EDeg = manageTeacherExecutorEDegCb.Text;
            teacher.T_Faculty = manageTeacherExecutorFacultyCb.Text;
            teacher.T_Group = manageTeacherExecutorEgroupCb.Text;
            teacher.T_Email = manageTeacherExecutorEmailTxtbx.Text;
            teacher.T_Mobile = manageTeacherExecutorMobileTxtbx.Text;
            teacher.T_Tel1 = manageTeacherExecutorTelTxtbx.Text;
            teacher.T_Tel2 = manageTeacherExecutorTel2Txtbx.Text;
            teacher.T_Email = manageTeacherExecutorEmailTxtbx.Text;

            dbh.DeleteTeacher(teacher, 9999, myDateTime.ToString());


            dbh.dataGridViewUpdate(manageTeacherShowDgv, teacherBindingSource, "SELECT * FROM TeacherTable");
        }

        private void manageTeacherEditBtn_Click(object sender, EventArgs e)
        {
            Teachers teacher = new Teachers();
            teacher.T_FName = manageTeacherFnameTxtbx.Text;
            teacher.T_LName = manageTeacherLnameTxtbx.Text;
            teacher.T_NCode = long.Parse(manageTeacherExecutorNcodeTxtbx.Text);
            teacher.T_EDeg = manageTeacherExecutorEDegCb.Text;
            teacher.T_Faculty = manageTeacherExecutorFacultyCb.Text;
            teacher.T_Group = manageTeacherExecutorEgroupCb.Text;
            teacher.T_Email = manageTeacherExecutorEmailTxtbx.Text;
            teacher.T_Mobile = manageTeacherExecutorMobileTxtbx.Text;
            teacher.T_Tel1 = manageTeacherExecutorTelTxtbx.Text;
            teacher.T_Tel2 = manageTeacherExecutorTel2Txtbx.Text;
            teacher.T_Email = manageTeacherExecutorEmailTxtbx.Text;

            dbh.EditTeacher(teacher, long.Parse(currentSelectedOption), 9999, myDateTime.ToString());


            dbh.dataGridViewUpdate(manageTeacherShowDgv, teacherBindingSource, "SELECT * FROM TeacherTable");
        }

        private void manageTeacherShowDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                manageTeacherFnameTxtbx.Text = manageTeacherShowDgv.Rows[e.RowIndex].Cells["t_FName"].Value.ToString();
                manageTeacherLnameTxtbx.Text = manageTeacherShowDgv.Rows[e.RowIndex].Cells["t_LName"].Value.ToString();
                manageTeacherExecutorNcodeTxtbx.Text = manageTeacherShowDgv.Rows[e.RowIndex].Cells["t_NCode"].Value.ToString();
                manageTeacherExecutorMobileTxtbx.Text = manageTeacherShowDgv.Rows[e.RowIndex].Cells["t_Mobile"].Value.ToString();
                manageTeacherExecutorEmailTxtbx.Text = manageTeacherShowDgv.Rows[e.RowIndex].Cells["t_Email"].Value.ToString();
                manageTeacherExecutorTelTxtbx.Text = manageTeacherShowDgv.Rows[e.RowIndex].Cells["t_Tel1"].Value.ToString();
                manageTeacherExecutorTel2Txtbx.Text = manageTeacherShowDgv.Rows[e.RowIndex].Cells["t_Tel2"].Value.ToString();
                manageTeacherExecutorFacultyCb.Text = manageTeacherShowDgv.Rows[e.RowIndex].Cells["t_Faculty"].Value.ToString();
                manageTeacherExecutorEgroupCb.Text = manageTeacherShowDgv.Rows[e.RowIndex].Cells["t_Group"].Value.ToString();

                manageTeacherExecutorEDegCb.Text = manageTeacherShowDgv.Rows[e.RowIndex].Cells["t_EDeg"].Value.ToString();
                currentSelectedOption = manageTeacherShowDgv.Rows[e.RowIndex].Cells["t_NCode"].Value.ToString();
            }
            catch (ArgumentOutOfRangeException) { }
        }

        private void addProposalShowBtn_Click(object sender, EventArgs e)
        {
            dbh.dataGridViewUpdate(addProposalShowDgv, addProposalBindingSource, "SELECT * FROM proposalTable");
            addProposalExecutorNcodeTxtbx.BackColor = Color.White;
            addProposalExecutorNcodeTxtbx.Focus();
        }

        private void manageTeacherExecutorNcodeTxtbx_Leave(object sender, EventArgs e)
        {
            if (manageTeacherExecutorNcodeTxtbx.Text.Length < 10)
            {
                manageTeacherExecutorNcodeTxtbx.BackColor = Color.Pink;
            }
        }

        private void addProposalSearchBtn_Click(object sender, EventArgs e)
        {
            if (addProposalExecutorNcodeTxtbx.Text.Length == 10)
            {
                dbh.dataGridViewUpdate(addProposalShowDgv, addProposalBindingSource, "SELECT * FROM proposalTable WHERE executor = '" + addProposalExecutorNcodeTxtbx.Text + "'");
            }
            else
            {
                PopUp p = new PopUp("خطا", "کد ملی وارد شده ناقص است.", "تایید", "", "", "error");
                p.ShowDialog();
            }
        }

        private void addProposalExecutorFNameTxtbx_Enter(object sender, EventArgs e)
        {
            if (addProposalExecutorNcodeTxtbx.Text.Length < 10)
            {
                addProposalExecutorNcodeTxtbx.BackColor = Color.Pink;
            }
        }

        private void manageTeacherShowBtn_Click(object sender, EventArgs e)
        {
            dbh.dataGridViewUpdate(manageTeacherShowDgv, teacherBindingSource, "SELECT * FROM TeacherTable");
        }

        private void addProposalPanel_Leave(object sender, EventArgs e)
        {
            addProposalClearBtn.PerformClick();
            addProposalShowDgv.DataSource = null;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void editProposalSearchBtn_Click(object sender, EventArgs e)
        {
            dbh.dataGridViewUpdate(editProposalShowDgv, editProposalBindingSource, "SELECT * FROM proposalTable WHERE executor = '" + editProposalExecutorNcodeTxtbx.Text + "'");
        }

        private void editProposalRegisterBtn_Click(object sender, EventArgs e)
        {
            Proposal proposal = new Proposal();
            proposal.PersianTitle = editProposalPersianTitleTxtbx.Text;
            proposal.EngTitle = editProposalEnglishTitleTxtbx.Text;
            proposal.KeyWord = editProposalKeywordsTxtbx.Text;
            proposal.CoExecutor = editProposalCoexecutorTxtbx.Text;
            proposal.Executor2 = editProposalExecutor2Txtbx.Text;
            proposal.Duration = int.Parse(editProposalDurationTxtbx.Text);
            proposal.ProcedureType = editProposalProcedureTypeCb.Text;
            proposal.PropertyType = editProposalPropertyTypeCb.Text;
            proposal.ProposalType = editProposalTypeCb.Text;
            proposal.Status = editProposalStatusCb.Text;
            proposal.RegisterType = editProposalRegisterTypeCb.Text;
            proposal.Employer = long.Parse(editProposalOrganizationNumberCb.Text);
            proposal.Value = editProposalValueTxtbx.Text;
            proposal.Executor = long.Parse(editProposalExecutorNcodeTxtbx.Text);
            proposal.StartDate = editProposalStartdateTimeInput.GeoDate.ToString();

            proposal.Index = long.Parse(currentSelectedIndex);





            dbh.EditProposal(proposal, username, myDateTime.ToString());
            dbh.dataGridViewUpdate(editProposalShowDgv, editProposalBindingSource, "SELECT * FROM proposalTable WHERE executor = '" + editProposalExecutorNcodeTxtbx.Text + "'");

        }

        private void editProposalShowDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                currentSelectedIndex = editProposalShowDgv.Rows[e.RowIndex].Cells["index"].Value.ToString();
                editProposalPersianTitleTxtbx.Text = editProposalShowDgv.Rows[e.RowIndex].Cells["persianTitle"].Value.ToString();
                editProposalEnglishTitleTxtbx.Text = editProposalShowDgv.Rows[e.RowIndex].Cells["engTitle"].Value.ToString();
                editProposalKeywordsTxtbx.Text = editProposalShowDgv.Rows[e.RowIndex].Cells["keyword"].Value.ToString();
                editProposalExecutor2Txtbx.Text = editProposalShowDgv.Rows[e.RowIndex].Cells["executor2"].Value.ToString();
                editProposalCoexecutorTxtbx.Text = editProposalShowDgv.Rows[e.RowIndex].Cells["coExecutor"].Value.ToString();
                editProposalStartdateTimeInput.Text = editProposalShowDgv.Rows[e.RowIndex].Cells["startDate"].Value.ToString();
                editProposalDurationTxtbx.Text = editProposalShowDgv.Rows[e.RowIndex].Cells["duration"].Value.ToString();
                editProposalProcedureTypeCb.Text = editProposalShowDgv.Rows[e.RowIndex].Cells["procedureType"].Value.ToString();
                editProposalTypeCb.Text = editProposalShowDgv.Rows[e.RowIndex].Cells["proposalType"].Value.ToString();
                editProposalPropertyTypeCb.Text = editProposalShowDgv.Rows[e.RowIndex].Cells["propertyType"].Value.ToString();
                editProposalRegisterTypeCb.Text = editProposalShowDgv.Rows[e.RowIndex].Cells["registerType"].Value.ToString();
                editProposalOrganizationNumberCb.Text = editProposalShowDgv.Rows[e.RowIndex].Cells["employer"].Value.ToString();
                editProposalValueTxtbx.Text = editProposalShowDgv.Rows[e.RowIndex].Cells["value"].Value.ToString();
                editProposalStatusCb.Text = editProposalShowDgv.Rows[e.RowIndex].Cells["status"].Value.ToString();
            }
            catch (ArgumentOutOfRangeException) { }
        }

        private void editProposalDeleteBtn_Click(object sender, EventArgs e)
        {
            Proposal proposal = new Proposal();
            proposal.PersianTitle = editProposalPersianTitleTxtbx.Text;
            proposal.EngTitle = editProposalEnglishTitleTxtbx.Text;
            proposal.KeyWord = editProposalKeywordsTxtbx.Text;
            proposal.CoExecutor = editProposalCoexecutorTxtbx.Text;
            proposal.Executor2 = editProposalExecutor2Txtbx.Text;
            proposal.Duration = int.Parse(editProposalDurationTxtbx.Text);
            proposal.ProcedureType = editProposalProcedureTypeCb.Text;
            proposal.PropertyType = editProposalPropertyTypeCb.Text;
            proposal.ProposalType = editProposalTypeCb.Text;
            proposal.Status = editProposalStatusCb.Text;
            proposal.RegisterType = editProposalRegisterTypeCb.Text;
            proposal.Employer = long.Parse(editProposalOrganizationNumberCb.Text);
            proposal.Value = editProposalValueTxtbx.Text;
            proposal.Executor = long.Parse(editProposalExecutorNcodeTxtbx.Text);
            proposal.StartDate = editProposalStartdateTimeInput.GeoDate.ToString();

            proposal.Index = long.Parse(currentSelectedIndex);

            dbh.DeleteProposal(proposal, username, myDateTime.ToString());
            dbh.dataGridViewUpdate(editProposalShowDgv, editProposalBindingSource, "SELECT * FROM proposalTable WHERE executor = '" + editProposalExecutorNcodeTxtbx.Text + "'");
        }

        private void wait_bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            w.Hide();
        }

        private void form_initializer()
        {
            waitBw.RunWorkerAsync();

            //*************************************************************************\\
            //                                Add Proposal                             \\
            //*************************************************************************\\
            addProposalStartdateTimeInput.GeoDate = DateTime.Now;
            
            addProposalExecutorFacultyCb.Items.Clear();
            addProposalProcedureTypeCb.Items.Clear();
            addProposalPropertyTypeCb.Items.Clear();
            addProposalRegisterTypeCb.Items.Clear();
            addProposalProposalTypeCb.Items.Clear();
            addProposalOrganizationNumberCb.Items.Clear();
            addProposalOrganizationNameCb.Items.Clear();
            addProposalStatusCb.Items.Clear();


            comboList = dbh.getFaculty();
            foreach (String faculty in comboList)
            {
                addProposalExecutorFacultyCb.Items.Add(faculty);
            }

            comboList = dbh.getProcedureType();
            foreach (String ProcedureType in comboList)
            {
                addProposalProcedureTypeCb.Items.Add(ProcedureType);
            }

            comboList = dbh.getPropertyType();
            foreach (String PropertyType in comboList)
            {
                addProposalPropertyTypeCb.Items.Add(PropertyType);
            }

            comboList = dbh.getRegisterType();
            foreach (String RegisterType in comboList)
            {
                addProposalRegisterTypeCb.Items.Add(RegisterType);
            }

            comboList = dbh.getProposalType();
            foreach (String ProposalType in comboList)
            {
                addProposalProposalTypeCb.Items.Add(ProposalType);
            }

            emp = dbh.getEmployers();
            
            foreach (Employers employer in emp)
            {
                addProposalOrganizationNumberCb.Items.Add(employer.Index);
                addProposalOrganizationNameCb.Items.Add(employer.OrgName);
            }

            comboList = dbh.getStatusType();
            foreach (String statusType in comboList)
            {
                addProposalStatusCb.Items.Add(statusType);
            }
            //*************************************************************************\\
            //                                Add Proposal                             \\
            //*************************************************************************\\


            //*************************************************************************\\
            //                                Search Proposal                          \\
            //*************************************************************************\\
            searchProposalStartDateFromTimeInput.GeoDate = DateTime.Now;
            searchProposalStartDateToTimeInput.GeoDate = DateTime.Now;

            searchProposalExecutorFacultyCb.Items.Clear();
            searchProposalExecutorEGroupCb.Items.Clear();
            searchProposalPropertyTypeCb.Items.Clear();
            searchProposalRegisterTypeCb.Items.Clear();
            searchProposalTypeCb.Items.Clear();
            searchProposalProcedureTypeCb.Items.Clear();
            searchProposalOrganizationNumberCb.Items.Clear();
            searchProposalOrganizationNameCb.Items.Clear();
            searchProposalStatusCb.Items.Clear();

            comboList = dbh.getFaculty();
            foreach (String faculty in comboList)
            {
                searchProposalExecutorFacultyCb.Items.Add(faculty);
            }

            comboList = dbh.getProcedureType();
            foreach (String ProcedureType in comboList)
            {
                searchProposalProcedureTypeCb.Items.Add(ProcedureType);
            }

            comboList = dbh.getPropertyType();
            foreach (String PropertyType in comboList)
            {
                searchProposalPropertyTypeCb.Items.Add(PropertyType);
            }

            comboList = dbh.getRegisterType();
            foreach (String RegisterType in comboList)
            {
                searchProposalRegisterTypeCb.Items.Add(RegisterType);
            }

            comboList = dbh.getProposalType();
            foreach (String ProposalType in comboList)
            {
                searchProposalTypeCb.Items.Add(ProposalType);
            }

            emp = dbh.getEmployers();
            foreach (Employers employer in emp)
            {
                searchProposalOrganizationNumberCb.Items.Add(employer.Index);
                searchProposalOrganizationNameCb.Items.Add(employer.OrgName);
            }

            comboList = dbh.getStatusType();
            foreach (String statusType in comboList)
            {
                searchProposalStatusCb.Items.Add(statusType);
            }
            //*************************************************************************\\
            //                                Search Proposal                          \\
            //*************************************************************************\\


            //*************************************************************************\\
            //                                edit Proposal                             \\
            //*************************************************************************\\
            editProposalStartdateTimeInput.GeoDate = DateTime.Now;

            editProposalExecutorFacultyCb.Items.Clear();
            editProposalProcedureTypeCb.Items.Clear();
            editProposalPropertyTypeCb.Items.Clear();
            editProposalRegisterTypeCb.Items.Clear();
            editProposalTypeCb.Items.Clear();
            editProposalOrganizationNumberCb.Items.Clear();
            editProposalOrganizationNameCb.Items.Clear();
            editProposalStatusCb.Items.Clear();


            comboList = dbh.getFaculty();
            foreach (String faculty in comboList)
            {
                editProposalExecutorFacultyCb.Items.Add(faculty);
            }

            comboList = dbh.getProcedureType();
            foreach (String ProcedureType in comboList)
            {
                editProposalProcedureTypeCb.Items.Add(ProcedureType);
            }

            comboList = dbh.getPropertyType();
            foreach (String PropertyType in comboList)
            {
                editProposalPropertyTypeCb.Items.Add(PropertyType);
            }

            comboList = dbh.getRegisterType();
            foreach (String RegisterType in comboList)
            {
                editProposalRegisterTypeCb.Items.Add(RegisterType);
            }

            comboList = dbh.getProposalType();
            foreach (String ProposalType in comboList)
            {
                editProposalTypeCb.Items.Add(ProposalType);
            }

            emp = dbh.getEmployers();

            foreach (Employers employer in emp)
            {
                editProposalOrganizationNumberCb.Items.Add(employer.Index);
                editProposalOrganizationNameCb.Items.Add(employer.OrgName);
            }

            comboList = dbh.getStatusType();
            foreach (String statusType in comboList)
            {
                editProposalStatusCb.Items.Add(statusType);
            }
            //*************************************************************************\\
            //                                edit Proposal                             \\
            //*************************************************************************\\



            //*************************************************************************\\
            //                                manage Users                           \\
            //*************************************************************************\\

            //*************************************************************************\\
            //                                manage Users                            \\
            //*************************************************************************\\



            //*************************************************************************\\
            //                                manage Teacher                             \\
            //*************************************************************************\\
            comboList = dbh.getFaculty();
            foreach (String faculty in comboList)
            {
                manageTeacherExecutorFacultyCb.Items.Add(faculty);
            }

            manageTeacherExecutorEDegCb.Items.Clear();
            comboList = dbh.getEDeg();
            foreach (String eDegree in comboList)
            {
                manageTeacherExecutorEDegCb.Items.Add(eDegree);
            }
            //*************************************************************************\\
            //                                manage Teacher                           \\
            //*************************************************************************\\

            this.Enabled = true;
            homePanel.Visible = true;
            w.i = -1;

            //*************************************************************************\\
            //                        manage color prefrence                           \\
            //*************************************************************************\\
            homePanel.BackColor = System.Drawing.ColorTranslator.FromHtml(loginUser.U_Color);
            addProposalPanel.BackColor = System.Drawing.ColorTranslator.FromHtml(loginUser.U_Color);
            searchProposalPanel.BackColor = System.Drawing.ColorTranslator.FromHtml(loginUser.U_Color);
            manageUserPanel.BackColor = System.Drawing.ColorTranslator.FromHtml(loginUser.U_Color);
            manageTeacherPanel.BackColor = System.Drawing.ColorTranslator.FromHtml(loginUser.U_Color);
            editProposalPanel.BackColor = System.Drawing.ColorTranslator.FromHtml(loginUser.U_Color);
            appSettingPanel.BackColor = System.Drawing.ColorTranslator.FromHtml(loginUser.U_Color);
            personalSettingPanel.BackColor = System.Drawing.ColorTranslator.FromHtml(loginUser.U_Color);
            aboutUsPanel.BackColor = System.Drawing.ColorTranslator.FromHtml(loginUser.U_Color);
            logPanel.BackColor = System.Drawing.ColorTranslator.FromHtml(loginUser.U_Color);

            appSettingBackgroundColorLbl.BackColor = System.Drawing.ColorTranslator.FromHtml(loginUser.U_Color);
            //*************************************************************************\\
            //                        manage color prefrence                           \\
            //*************************************************************************\\
        }
    }
}