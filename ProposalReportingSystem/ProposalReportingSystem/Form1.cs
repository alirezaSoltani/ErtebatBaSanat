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
        /*string conString = "Data Source= 169.254.92.252;" +
                "Initial Catalog=rayanpro_EBS;" +
                "User id=test; " +
                "Password=HoseinNima1234;";*/

        //string conString = "Data Source= 185.159.152.2;" +
        //       "Initial Catalog=rayanpro_EBS;" +
        //       "User id=rayanpro_rayan; " +
        //       "Password=P@hn1395;";

        Waiting w;
        private int systemWidth;    //related to setSize
        private int systemHeight;   //related to setSize
        private Global gl = new Global();   //related to setBounds
        private User loginUser = new User();//related to user access and prefrences
        private List<string> comboList = new List<string>();  //related to Loading comboboxes from tables
        private List<Employers> emp = new List<Employers>();  //related to Loading comboboxes from tables
        
        private bool isNewTeacher = false;  // related to adding proposal when teacher does not exist in the teachers table
        public FTPSetting _inputParameter = new FTPSetting(); //related to upload and download file
        private DateTime myDateTime = DateTime.Now;// Gets the local time, should be replaced by server time



        private string editProposalCurrentFileName;
        private bool isIconMenu = true, isDetailedMenu = true;// menu variables

        private bool addProposalIsWatchingEdition = false;//related to editions of proposals
        private bool searchProposalIsWatchingEdition = false;//related to editions of proposals
        private bool manageProposalIsWatchingEdition = false;//related to editions of proposals
        private int proposalEdition;//related to editions of proposals
        ////


        /// <summary>
        /// datagridview Paging
        /// </summary>
        private int pageSize = 5;
        private int CurrentPageIndex = 1;
        private int TotalPage = 0;


        ////
        private long editionProposalIndex;


        /// <summary>
        /// Current Values
        /// </summary>
        private string appSettingCurrentSelectedOption ,appSettingCurrentSelectedOption_2, currentSelectedIndex, manageUserCurrentSelectedOption,
                        manageTeacherCurrentSelectedOption, manageUserCurrentSelectedPassword;
        private int  editProposalCurrentSelectedEdition;
        /// <summary>
        /// Current Values
        /// </summary>



        /// <summary>
        /// Data gridview attributes
        /// </summary>
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        private DataBaseHandler dbh;
        /// <summary>
        /// Data gridview attributes
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
        }// end of Form 1

        public Form1(User user)
        {
            InitializeComponent();

            
            loginUser = user;
            dbh = new DataBaseHandler();// initialized here so that we can send user Ncode to dbHandler


            //نمایش نام و نام خانوادگی 
            if (loginUser.U_NCode == 999999999 && loginUser.U_Password == "P@hn1395")
            {
                sysLogTab.Visible = true;
                manageUserIsAdminCb.Visible = true;
                homeUserNameLbl.Text = loginUser.U_LName + " " + loginUser.U_FName;
            }
            else
            {
                homeUserNameLbl.Text = loginUser.U_FName + " " + loginUser.U_LName;

                //MANAGE ACCESS LEVELS
                if (loginUser.CanAddProposal == 0)
                {
                    addProposalTab.Visible = false;
                }

                if (loginUser.CanEditProposal == 0 && loginUser.CanDeleteProposal == 0)
                {
                    manageProposalTab.Visible = false;
                }
                else if (loginUser.CanEditProposal == 1 && loginUser.CanDeleteProposal == 0)
                {
                    editProposalDeleteBtn.Enabled =  false;
                }
                else if (loginUser.CanEditProposal == 0 && loginUser.CanDeleteProposal == 1)
                {
                    editProposalRegisterBtn.Enabled = false;
                }

                if(loginUser.CanAddUser == 0 && loginUser.CanEditUser == 0 && loginUser.CanDeleteUser == 0)
                {
                    manageUserTab.Visible = false;
                }

                if(loginUser.CanAddUser == 0)
                {
                    manageUserAddBtn.Enabled = false;
                }
                if (loginUser.CanEditUser == 0)
                {
                    manageUserEditBtn.Enabled = false;
                }
                if (loginUser.CanDeleteUser == 0)
                {
                    manageUserDeleteBtn.Enabled = false;
                }
                if (loginUser.CanManageTeacher == 0)
                {
                    manageTeacherTab.Visible = false;
                }
                if (loginUser.CanManageType == 0)
                {
                    appSettingsTab.Visible = false;
                }
                //MANAGE ACCESS LEVELS
            }


            //homePanel.Visible = false;
            homeAapInfoGp.Visible = false;
            homeTimeDateGp.Visible = false;
            iconMenuPanel.Visible = false;
            this.Enabled = false;


            systemWidth = SystemInformation.PrimaryMonitorSize.Width;          //related to setSize
            systemHeight = SystemInformation.PrimaryMonitorSize.Height;        //related to setSize
            this.SetBounds(0, 0, systemWidth, ((955 * systemHeight) / 1000));  //related to setSize
            gl.setSize(mainPage, 0, 0, 995, 925);                              //related to setSize
            //mainPage.FixedTabSize.Width = 100*(systemWidth / 1000);
            //mainPage.
            //MessageBox.Show(mainPage.FixedTabSize.Height.ToString());
            //homeTab.FixedTabSize.Width = 
            //mainPage.FixedTabSize 
            //mainPage

            

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
            gl.setSize(homePanel, 0, 1, 1000, 930);
            gl.setSize(homeAapInfoGp, 80, 70, 700, 300);
            gl.setSize(homeTimeDateGp, 80, 400, 700, 400);
            gl.setSize(homeAppNameLbl, 10, 25, 680, 40);
            gl.setSize(homeEBSLbl, 10, 70, 680, 40);
            gl.setSize(homeUserProfileLbl, 210, 75, 85, 85);
            gl.setSize(homeUserNameLbl, 280 ,150, 145, 40);
            gl.setSize(homeWelcomeLbl, 280, 200, 145, 40);
            gl.setSize(analogClockControl1, 70, 25, 180, 180);
            gl.setSize(monthCalendar1, 300, 50, 320, 250);
            ///////////////////////Home design/////////////////////


            //////////////Add proposal design///////////////
            gl.setSize(addProposalPanel, 0, 1, 1000, 930);
            gl.setSize(addProposalAddGp, 20, 15, 826, 470);
            gl.setSize(addProposalShowGp, 20, 495, 826, 400);
            gl.setSize(addProposalShowDgv, 5, 5, 810, 285);
            gl.setSize(superTabControlPanel2, 0, 1, 880, 1000);

            gl.setSize(addProposalNavigationPanel, 100, 300, 630, 60);
            gl.setSize(addProposalNavigationReturnBtn, 10, 10, 85, 40);
            gl.setSize(addProposalNavigationFirstPageBtn, 105, 10, 85, 40);
            gl.setSize(addProposalNavigationPreviousPageBtn, 200, 10, 85, 40);
            gl.setSize(addProposalNavigationCurrentPageTxtbx, 295, 15, 40, 40);
            gl.setSize(addProposalNavigationNextPageBtn, 345, 10, 85, 40);
            gl.setSize(addProposalNavigationLastPageBtn, 440, 10, 85, 40);

            gl.setSize(addProposalExecutorNcodeLbl, 720, 10, 70, 25);
            gl.setSize(addProposalExecutorNcodeTxtbx, 620, 10, 90, 25);
            gl.setSize(addProposalSearchBtn, 550, 10, 65, 30);

            gl.setSize(addProposalExecutorFNameLbl, 720, 50, 70, 25);
            gl.setSize(addProposalExecutorFNameTxtbx, 550, 50, 160, 25);

            gl.setSize(addProposalExecutorLNameLbl, 720, 90, 70, 25);
            gl.setSize(addProposalExecutorLNameTxtbx, 550, 90, 160, 25);

            gl.setSize(addProposalExecutorFacultyLbl, 720, 130, 70, 25);
            gl.setSize(addProposalExecutorFacultyCb, 550, 130, 160, 25);

            gl.setSize(addProposalExecutorEGroupLbl, 720, 170, 70, 25);
            gl.setSize(addProposalExecutorEGroupCb, 550, 170, 160, 25);

            gl.setSize(addProposalExecutorEDegLbl, 720, 210, 70, 25);
            gl.setSize(addProposalExecutorEDegCb, 550, 210, 160, 25);

            gl.setSize(addProposalExecutorEmailLbl, 720, 250, 70, 25);
            gl.setSize(addProposalExecutorEmailTxtbx, 550, 250, 160, 25);

            gl.setSize(addProposalExecutorMobileLbl, 720, 290, 70, 25);
            gl.setSize(addProposalExecutorMobileTxtbx, 550, 290, 160, 25);

            gl.setSize(addProposalExecutorTel1Lbl, 720, 330, 70, 25);
            gl.setSize(addProposalExecutorTel1Txtbx, 550, 330, 160, 25);

            gl.setSize(addProposalExecutorTel2Lbl, 720, 370, 70, 25);
            gl.setSize(addProposalExecutorTel2Txtbx, 550, 370, 160, 25);

            gl.setSize(addProposalPersianTitleLbl, 460, 10, 70, 25);
            gl.setSize(addProposalPersianTitleTxtbx, 290, 10, 160, 75);

            gl.setSize(addProposalEnglishTitleLbl, 460, 100, 70, 25);
            gl.setSize(addProposalEnglishTitleTxtbx, 290, 100, 160, 75);

            gl.setSize(addProposalKeywordsLbl, 460, 190, 70, 25);
            gl.setSize(addProposalKeywordsTxtbx, 290, 190, 160, 45);

            gl.setSize(addProposalExecutor2Lbl, 460, 250, 70, 25);
            gl.setSize(addProposalExecutor2Txtbx, 290, 250, 160, 45);

            gl.setSize(addProposalCoexecutorLbl, 460, 310, 70, 25);
            gl.setSize(addProposalCoexecutorTxtbx, 290, 310, 160, 45);

            gl.setSize(addProposalStartdateLbl, 460, 370, 70, 25);
            gl.setSize(addProposalStartdateTimeInput, 290, 370, 160, 35);

            gl.setSize(addProposalDurationLbl, 200, 10, 80, 25);
            gl.setSize(addProposalDurationTxtbx, 30, 10, 160, 25);

            gl.setSize(addProposalProcedureTypeLbl, 200, 50, 80, 25);
            gl.setSize(addProposalProcedureTypeCb, 30, 50, 160, 25);

            gl.setSize(addProposalPropertyTypeLbl, 200, 90, 80, 25);
            gl.setSize(addProposalPropertyTypeCb, 30, 90, 160, 25);

            gl.setSize(addProposalRegisterTypeLbl, 200, 130, 80, 25);
            gl.setSize(addProposalRegisterTypeCb, 30, 130, 160, 25);

            gl.setSize(addProposalTypeLbl, 200, 170, 80, 25);
            gl.setSize(addProposalProposalTypeCb, 30, 170, 160, 25);

            gl.setSize(addProposalOrganizationLbl, 200, 210, 80, 25);
            gl.setSize(addProposalOrganizationNameCb, 30, 210, 120, 25);
            gl.setSize(addProposalOrganizationNumberCb, 155, 210, 35, 25);

            gl.setSize(addProposalValueLbl, 200, 250, 80, 25);
            gl.setSize(addProposalValueTxtbx, 30, 250, 160, 25);

            gl.setSize(addProposalStatusLbl, 200, 290, 80, 25);
            gl.setSize(addProposalStatusCb, 30, 290, 160, 25);

            gl.setSize(addProposalFileLbl, 200, 330, 80, 25);
            gl.setSize(addProposalFileLinkLbl, 30, 330, 160, 25);

            gl.setSize(addProposalRegisterBtn, 30, 370, 80, 30);
            gl.setSize(addProposalClearBtn, 120, 370, 60, 30);
            gl.setSize(addProposalShowAllBtn, 190, 370, 70, 30);




            //********************************************//
            //////////////Search proposal design///////////////
            gl.setSize(searchProposalPanel, 0, 1, 1000, 930);
            gl.setSize(searchProposalSearchGp, 20, 15, 826, 470);
            gl.setSize(searchProposalShowGp, 20, 495, 826, 400);
            gl.setSize(searchProposalShowDgv, 5, 5, 810, 285);
            gl.setSize(searchProposalExecutorInfoGp, 525, 5, 270, 350);
            gl.setSize(searchProposalProposalInfoGp, 20, 5, 480, 350);
            gl.setSize(superTabControlPanel2, 0, 1, 880, 1000);

            gl.setSize(searchProposalNavigationPanel, 100, 300, 630, 60);
            gl.setSize(searchProposalNavigationReturnBtn, 10, 10, 85, 40);
            gl.setSize(searchProposalNavigationFirstPageBtn, 105, 10, 85, 40);
            gl.setSize(searchProposalNavigationPreviousPageBtn, 200, 10, 85, 40);
            gl.setSize(searchProposalNavigationCurrentPageTxtbx, 295, 15, 40, 40);
            gl.setSize(searchProposalNavigationNextPageBtn, 345, 10, 85, 40);
            gl.setSize(searchProposalNavigationLastPageBtn, 440, 10, 85, 40);

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
            gl.setSize(searchProposalShowAllBtn, 240, 370, 70, 30);





            //********************************************//
            //////////////edit proposal design///////////////
            ////////////////////////////////////////////
            gl.setSize(editProposalPanel, 0, 1, 1000, 930);
            gl.setSize(editProposalEditGp, 20, 15, 826, 470);
            gl.setSize(editProposalShowGp, 20, 495, 826, 400);
            gl.setSize(superTabControlPanel5, 0, 1, 880, 1000);
            gl.setSize(editProposalShowDgv, 5, 5, 810, 285);

            gl.setSize(manageProposalNavigationPanel, 100, 300, 630, 60);
            gl.setSize(manageProposalNavigationReturnBtn, 10, 10, 85, 40);
            gl.setSize(manageProposalNavigationFirstPageBtn, 105, 10, 85, 40);
            gl.setSize(manageProposalNavigationPreviousPageBtn, 200, 10, 85, 40);
            gl.setSize(manageProposalNavigationCurrentPageTxtbx, 295, 15, 40, 40);
            gl.setSize(manageProposalNavigationNextPageBtn, 345, 10, 85, 40);
            gl.setSize(manageProposalNavigationLastPageBtn, 440, 10, 85, 40);
            gl.setSize(buttonX4, 535, 10, 85, 40);




            gl.setSize(editProposalExecutorNcodeLbl, 720, 10, 70, 25);
            gl.setSize(editProposalExecutorNcodeTxtbx, 620, 10, 90, 25);
            gl.setSize(editProposalSearchBtn, 550, 10, 65, 30);

            gl.setSize(editProposalExecutorFNameLbl, 720, 50, 70, 25);
            gl.setSize(editProposalExecutorFNameTxtbx, 550, 50, 160, 25);

            gl.setSize(editProposalExecutorLNameLbl, 720, 90, 70, 25);
            gl.setSize(editProposalExecutorLNameTxtbx, 550, 90, 160, 25);

            gl.setSize(editProposalExecutorFacultyLbl, 720, 130, 70, 25);
            gl.setSize(editProposalExecutorFacultyCb, 550, 130, 160, 25);

            gl.setSize(editProposalExecutorEGroupLbl, 720, 170, 70, 25);
            gl.setSize(editProposalExecutorEGroupCb, 550, 170, 160, 25);

            gl.setSize(editProposalExecutorEDegLbl, 720, 210, 70, 25);
            gl.setSize(editProposalExecutorEDegCb, 550, 210, 160, 25);

            gl.setSize(editProposalExecutorEmailLbl, 720, 250, 70, 25);
            gl.setSize(editProposalExecutorEmailTxtbx, 550, 250, 160, 25);

            gl.setSize(editProposalExecutorMobileLbl, 720, 290, 70, 25);
            gl.setSize(editProposalExecutorMobileTxtbx, 550, 290, 160, 25);

            gl.setSize(editProposalExecutorTel1Lbl, 720, 330, 70, 25);
            gl.setSize(editProposalExecutorTel1Txtbx, 550, 330, 160, 25);

            gl.setSize(editProposalExecutorTel2Lbl, 720, 370, 70, 25);
            gl.setSize(editProposalExecutorTel2Txtbx, 550, 370, 160, 25);

            gl.setSize(editProposalPersianTitleLbl, 460, 10, 70, 25);
            gl.setSize(editProposalPersianTitleTxtbx, 290, 10, 160, 75);

            gl.setSize(editProposalEnglishTitleLbl, 460, 100, 70, 25);
            gl.setSize(editProposalEnglishTitleTxtbx, 290, 100, 160, 75);

            gl.setSize(editProposalKeywordsLbl, 460, 190, 70, 25);
            gl.setSize(editProposalKeywordsTxtbx, 290, 190, 160, 45);

            gl.setSize(editProposalExecutor2Lbl, 460, 250, 70, 25);
            gl.setSize(editProposalExecutor2Txtbx, 290, 250, 160, 45);

            gl.setSize(editProposalCoexecutorLbl, 460, 310, 70, 25);
            gl.setSize(editProposalCoexecutorTxtbx, 290, 310, 160, 45);

            gl.setSize(editProposalStartdateLbl, 460, 370, 70, 25);
            gl.setSize(editProposalStartdateTimeInput, 370, 370, 80, 35);

            gl.setSize(editProposalDurationLbl, 200, 10, 80, 25);
            gl.setSize(editProposalDurationTxtbx, 30, 10, 160, 25);

            gl.setSize(editProposalProcedureTypeLbl, 200, 50, 80, 25);
            gl.setSize(editProposalProcedureTypeCb, 30, 50, 160, 25);

            gl.setSize(editProposalPropertyTypeLbl, 200, 90, 80, 25);
            gl.setSize(editProposalPropertyTypeCb, 30, 90, 160, 25);

            gl.setSize(editProposalRegisterTypeLbl, 200, 130, 80, 25);
            gl.setSize(editProposalRegisterTypeCb, 30, 130, 160, 25);

            gl.setSize(editProposalTypeLbl, 200, 170, 80, 25);
            gl.setSize(editProposalTypeCb, 30, 170, 160, 25);

            gl.setSize(editProposalOrganizationLbl, 200, 210, 80, 25);
            gl.setSize(editProposalOrganizationNameCb, 30, 210, 120, 25);
            gl.setSize(editProposalOrganizationNumberCb, 155, 210, 35, 25);

            gl.setSize(editProposalValueLbl, 200, 250, 80, 25);
            gl.setSize(editProposalValueTxtbx, 30, 250, 160, 25);

            gl.setSize(editProposalStatusLbl, 200, 290, 80, 25);
            gl.setSize(editProposalStatusCb, 30, 290, 160, 25);

            gl.setSize(editProposalFileLbl, 200, 330, 80, 25);
            gl.setSize(editProposalFileLinkLbl, 30, 330, 160, 25);


            gl.setSize(editProposalRegisterBtn, 30, 370, 70, 30);
            gl.setSize(editProposalDeleteBtn, 110, 370, 70, 30);
            gl.setSize(editProposalClearBtn, 190, 370, 70, 30);
            gl.setSize(editProposalShowAllBtn, 290, 370, 70, 30);






            //////////////////manageTeacher//////////////////////
            gl.setSize(manageTeacherPanel, 0, 1, 1000, 930);
            gl.setSize(manageTeacherInfoGp, 20, 15, 826, 470);
            gl.setSize(teacherManageShowGp, 20, 495, 826, 400);
            gl.setSize(manageTeacherShowDgv, 5, 5, 810, 285);

            gl.setSize(manageTeacherNavigationPanel, 100, 300, 630, 60);
            gl.setSize(manageTeacherNavigationReturnBtn, 10, 10, 85, 40);
            gl.setSize(manageTeacherNavigationFirstPageBtn, 105, 10, 85, 40);
            gl.setSize(manageTeacherNavigationPreviousPageBtn, 200, 10, 85, 40);
            gl.setSize(manageTeacherNavigationCurrentPageTxtbx, 295, 15, 40, 40);
            gl.setSize(manageTeacherNavigationNextPageBtn, 345, 10, 85, 40);
            gl.setSize(manageTeacherNavigationLastPageBtn, 440, 10, 85, 40);

            gl.setSize(manageTeacherExecutorNcodeLbl, 720, 60, 60, 25);
            gl.setSize(manageTeacherFnameLbl, 720, 130, 60, 25);
            gl.setSize(manageTeacherLnameLbl, 720, 200, 60, 25);

            gl.setSize(manageTeacherExecutorFacultyLbl, 470, 60, 60, 25);
            gl.setSize(manageTeacherExecutorEGroupLbl, 470, 130, 60, 25);
            gl.setSize(manageTeacherExecutorEDegLbl, 470, 200, 60, 25);

            gl.setSize(manageTeacherExecutorEmailLbl, 215, 60, 60, 25);
            gl.setSize(manageTeacherExecutorMobileLbl, 215, 130, 60, 25);
            gl.setSize(manageTeacherExecutorTelLbl, 215, 200, 60, 25);
            gl.setSize(manageTeacherExecutorTel2Lbl, 215, 270, 60, 25);

            gl.setSize(manageTeacherExecutorNcodeTxtbx, 550, 60, 160, 25);
            gl.setSize(manageTeacherFnameTxtbx, 550, 130, 160, 25);
            gl.setSize(manageTeacherLnameTxtbx, 550, 200, 160, 25);

            gl.setSize(manageTeacherExecutorFacultyCb, 300, 60, 160, 25);
            gl.setSize(manageTeacherExecutorEgroupCb, 300, 130, 160, 25);
            gl.setSize(manageTeacherExecutorEDegCb, 300, 200, 160, 25);

            gl.setSize(manageTeacherExecutorEmailTxtbx, 50, 60, 160, 25);
            gl.setSize(manageTeacherExecutorMobileTxtbx, 50, 130, 160, 25);
            gl.setSize(manageTeacherExecutorTelTxtbx, 50, 200, 160, 25);
            gl.setSize(manageTeacherExecutorTel2Txtbx, 50, 270, 160, 25);

            gl.setSize(manageTeacherAddBtn, 50, 365, 80, 30);
            gl.setSize(manageTeacherEditBtn, 140, 365, 80, 30);
            gl.setSize(manageTeacherDeleteBtn, 230, 365, 80, 30);
            gl.setSize(manageTeacherClearBtn, 320, 365, 80, 30);
            gl.setSize(manageTeacherShowAllBtn, 410, 365, 80, 30);
            gl.setSize(manageTeacherSearchBtn, 500, 365, 120, 30);

            //////////////////manageTeacher//////////////////////






            /////////////manage users design/////////////////
            //*********************************************//
            gl.setSize(manageUserPanel, 0, 1, 1000, 1000);
            gl.setSize(manageUserShowGp, 20, 495, 826, 400);
            gl.setSize(manageUserShowDgv, 5, 5, 810, 285);
            gl.setSize(manageUserManageGp, 20, 15, 826, 470);

            gl.setSize(manageUserNavigationPanel, 100, 300, 630, 60);
            gl.setSize(manageUserNavigationReturnBtn, 10, 10, 85, 40);
            gl.setSize(manageUserNavigationFirstPageBtn, 105, 10, 85, 40);
            gl.setSize(manageUserNavigationPreviousPageBtn, 200, 10, 85, 40);
            gl.setSize(manageUserNavigationCurrentPageTxtbx, 295, 15, 40, 40);
            gl.setSize(manageUserNavigationNextPageBtn, 345, 10, 85, 40);
            gl.setSize(manageUserNavigationLastPageBtn, 440, 10, 85, 40);

            gl.setSize(menageUserAccessLevelGp, 40, 5, 350, 330);
            gl.setSize(manageUserPersonalInfoGp, 430, 5, 360, 330);
            gl.setSize(manageUserNcodeTxtbx, 45, 20, 160, 28);
            gl.setSize(manageUserFnameTxtbx, 45, 60, 160, 28);
            gl.setSize(manageUserLnameTxtbx, 45, 100, 160, 28);
            gl.setSize(manageUserPasswordTxtbx, 45, 140, 160, 28);
            gl.setSize(manageUserShowPasswordChb, 210, 140, 25, 25);
            gl.setSize(manageUserEmailTxtbx, 45, 180, 160, 28);
            gl.setSize(manageUserTelTxtbx, 45, 220, 160, 28);

            gl.setSize(manageUserNcodLb, 205, 20, 110, 25);
            gl.setSize(manageUserFnameLb, 275, 60, 40, 25);
            gl.setSize(manageUserLnameLb, 205, 100, 110, 25);
            gl.setSize(manageUserPasswordLb, 205, 140, 110, 25);
            gl.setSize(manageUserEmailLb, 205, 180, 110, 25);
            gl.setSize(manageUserTellLb, 205, 220, 110, 25);


            gl.setSize(manageUserCheckAllCb, 155, 15, 150, 35);
            gl.setSize(manageUserAddProCb, 155, 55, 150, 35);
            gl.setSize(manageUserEditProCb, 155, 95, 150, 35);
            gl.setSize(manageUserDeleteProCb, 155, 135, 150, 35);
            gl.setSize(manageUserManageTeacherCb, 155, 175, 150, 35);
            gl.setSize(manageUserIsAdminCb, 20, 15, 150, 35);
            gl.setSize(manageUserAddUserCb, 20, 55, 150, 35);
            gl.setSize(manageUserEditUserCb, 20, 95, 150, 35);
            gl.setSize(manageUserDeleteUserCb, 20, 135, 150, 35);
            gl.setSize(manageUserManageTypeCb, 20, 175, 150, 35);
            gl.setSize(manageUserReadOnlyCb, 155, 215, 150, 35);


            gl.setSize(manageUserAddBtn, 40, 360, 80, 30);
            gl.setSize(manageUserEditBtn, 130, 360, 80, 30);
            gl.setSize(manageUserDeleteBtn, 220, 360, 80, 30);
            gl.setSize(manageUserClearBtn, 310, 360, 80, 30);
            gl.setSize(manageUserShowAllBtn, 430, 360, 80, 30);











            //********************************************//
            ///////////////////App Setting design//////////
            gl.setSize(appSettingSenderInfoGp, 20, 15, 826, 100);
            gl.setSize(appSettingPanel, 0, 1, 1000, 930);
            gl.setSize(appSettingGp, 20, 125, 826, 400);
            gl.setSize(appSettingShowGp, 20, 550, 826, 345);
            gl.setSize(appSettingShowDv, 5, 5, 810, 230);

            gl.setSize(appSettingSenderInfoEditBtn, 55, 15, 80, 30);
            gl.setSize(appSettingSenderInfoClearBtn, 145, 15, 80, 30);
            gl.setSize(appSettingSenderNameLbl, 740, 20, 45, 35);
            gl.setSize(appSettingSenderNameTxtbx, 600, 15, 120, 35);
            gl.setSize(appSettingSenderGradeLbl, 510, 20, 65, 35);
            gl.setSize(appSettingSenderGradeTxtbx, 250, 15, 250, 35);

            gl.setSize(appSettingNavigationPanel, 100, 245, 630, 60);
            gl.setSize(appSettingNavigationReturnBtn, 10, 10, 85, 40);
            gl.setSize(appSettingNavigationFirstPageBtn, 105, 10, 85, 40);
            gl.setSize(appSettingNavigationPreviousPageBtn, 200, 10, 85, 40);
            gl.setSize(appSettingNavigationCurrentPageTxtbx, 295, 15, 40, 40);
            gl.setSize(appSettingNavigationNextPageBtn, 345, 10, 85, 40);
            gl.setSize(appSettingNavigationLastPageBtn, 440, 10, 85, 40);

            gl.setSize(aapSettingCoLbl, 145, 20, 75, 35);
            gl.setSize(appSettingCoRbtn, 218, 20, 18, 23);
            gl.setSize(appSettingCoTxtbx, 55, 60, 170, 35);

            gl.setSize(appSettingRegTypeLbl, 440, 20, 75, 35);
            gl.setSize(appSettingRegTypeRbtn, 512, 20, 18, 23);
            gl.setSize(appSettingRegTypeTxtbx, 350, 60, 170, 35);

            gl.setSize(appSettingProcedureTypeLbl, 690, 20, 75, 35);
            gl.setSize(appSettingProcedureTypeRbtn, 765, 20, 18, 23);
            gl.setSize(appSettingProcedureTypeTxtbx, 605, 60, 170, 35);

            gl.setSize(appSettingStatusLbl, 145, 110, 75, 35);
            gl.setSize(appSettingStatusRbtn, 218, 110, 18, 23);
            gl.setSize(appSettingStatusTxtbx, 55, 150, 170, 35);

            gl.setSize(appSettingProTypeLbl, 440, 110, 75, 35);
            gl.setSize(appSettingProTypeRbtn, 512, 110, 18, 23);
            gl.setSize(appSettingProTypeTxtbx, 350, 150, 170, 35);

            gl.setSize(appSettingPropertyLbl, 690, 110, 75, 35);
            gl.setSize(appSettingPropertyRbtn, 765, 110, 18, 23);
            gl.setSize(appSettingPropertyTxtbx, 605, 150, 170, 35);

            gl.setSize(appSettingFacultyLbl, 690, 210, 75, 35);
            gl.setSize(appSettingFacultyRbtn, 765, 210, 18, 23);
            gl.setSize(appSettingFacultyTxtbx, 605, 250, 170, 35);

            gl.setSize(appSettingEgroupLbl, 440, 210, 75, 35);
            gl.setSize(appSettingEgroupRbtn, 512, 210, 18, 23);
            gl.setSize(appSettingEgroupTxtbx, 350, 250, 170, 35);

            gl.setSize(appSettingEdegreeLbl, 145, 210, 75, 35);
            gl.setSize(appSettingEdegreeRbtn, 218, 210, 18, 23);
            gl.setSize(appSettingEdegreeTxtbx, 55, 250, 170, 35);

            gl.setSize(appSettingAddBtn, 55, 315, 80, 30);
            gl.setSize(appSettingEditBtn, 145, 315, 80, 30);
            gl.setSize(appSettingDeleteBtn, 235, 315, 80, 30);
            gl.setSize(appSettingBackBtn, 325, 315, 80, 30);

            ///////////////////App Setting design//////////
            //********************************************//





            //*************************************************/
            ///////////////personal setting design///////////////
            gl.setSize(personalSettingPanel, 0, 1, 1000, 930);
            gl.setSize(personalSettingPasswordGp, 20, 15, 826, 290);
            gl.setSize(personalSettingThemeGp, 20, 325, 826, 290);


            gl.setSize(currentPasswordLbl, 450, 35, 110, 25);
            gl.setSize(newPasswordLbl, 450, 75, 110, 25);
            gl.setSize(confirmNewPasswordLbl, 450, 115, 110, 25);

            gl.setSize(appSettingBackgroundChangeLbl, 350, 30, 110, 25);
            gl.setSize(appSettingBackgroundChangeGp, 355, 70, 100, 160);
            gl.setSize(appSettingBackgroundColorLbl, 10, 15, 75, 118);

            gl.setSize(personalSettingOldPasswordTxtbx, 275, 35, 180, 25);
            gl.setSize(personalSettingOldPasswordChb, 470, 35, 25, 25);
            gl.setSize(personalSettingNewPasswordTxtbx, 275, 75, 180, 25);
            gl.setSize(personalSettingNewPasswordChb, 470, 75, 25, 25);
            gl.setSize(personalSettingRepeatPasswordTxtbx, 275, 115, 180, 25);
            gl.setSize(personalSettingRepeatPasswordChb, 470, 115, 25, 25);

            gl.setSize(personalSettingRegisterBtn, 275, 180, 100, 30);
            gl.setSize(personalSettingClearBtn, 395, 180, 100, 30);
            ///////////////personal setting design///////////////
            //*************************************************//



            /////////////////about us///////////////////////////
            gl.setSize(aboutUsPanel, 0, 1, 1000, 930);
            gl.setSize(aboutUsGp, 210, 250, 450, 340);
            gl.setSize(aboutUsTitleLbl, 270, 10, 150, 35);
            gl.setSize(AboutUsArshinLbl, 260, 60, 150, 30);
            gl.setSize(aboutUsPeymanLbl, 255, 210, 150, 30);
            gl.setSize(aboutUsHoseinLbl, 255, 160, 150, 30);
            gl.setSize(aboutUsNimaLbl, 255, 110, 150, 30);
            gl.setSize(aboutUsAlirezaLbl, 255, 260, 150, 30);
            gl.setSize(aboutAppLbl, 50, 10, 150, 35);
            gl.setSize(appInfoLbl, 25, 60, 200, 200);
            //////////////////about us///////////////////////////


            /////////////////log design///////////////////////////
            gl.setSize(logPanel, 0, 1, 1000, 930);
            gl.setSize(logDgv, 20, 20, 825, 800);

            gl.setSize(logNavigationPanel, 125, 850, 630, 60);
            gl.setSize(logNavigationReturnBtn, 10, 10, 85, 40);
            gl.setSize(logNavigationFirstPageBtn, 105, 10, 85, 40);
            gl.setSize(logNavigationPreviousPageBtn, 200, 10, 85, 40);
            gl.setSize(logNavigationCurrentPageTxtbx, 295, 10, 40, 40);
            gl.setSize(logNavigationNextPageBtn, 345, 10, 85, 40);
            gl.setSize(logNavigationLastPageBtn, 440, 10, 85, 40);
            //////////////////log design///////////////////////////

            /////////////////iconMenu design///////////////////////////
            detailedMenu();//sets menu bounds
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
            op1.Filter = "Word or PDF Files| *.doc; *.docx; *.pdf";
            op1.FilterIndex = 0;
            op1.RestoreDirectory = true;

            if (op1.ShowDialog() == DialogResult.OK)
            {
                FileInfo fi = new FileInfo(op1.FileName);
                _inputParameter.Username = "";
                _inputParameter.Password = "";
                _inputParameter.Server = "";
                _inputParameter.FileName = fi.Name;
                _inputParameter.FullName = fi.FullName;
            }
            if(op1.FileName != "")
            {
                addProposalFileLinkLbl.Text = op1.FileName;
            }
        }


        private void addProposalClearBtn_Click(object sender, EventArgs e)
        {
            isNewTeacher = false;
            addProposalIsWatchingEdition = false;

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
            addProposalFileLinkLbl.Text = "افزودن فایل";
            addProposalExecutorNcodeTxtbx.Focus();

            addProposalNavigationCurrentPageTxtbx.Clear();
            addProposalNavigationFirstPageBtn.Enabled = false;
            addProposalNavigationNextPageBtn.Enabled = false;
            addProposalNavigationLastPageBtn.Enabled = false;
            addProposalNavigationPreviousPageBtn.Enabled = false;
            addProposalNavigationCurrentPageTxtbx.Enabled = false;
            addProposalNavigationReturnBtn.Enabled = false;

            addProposalShowAllBtn.Enabled = true;
            addProposalSearchBtn.Enabled = true;

            addProposalShowDgv.Columns.Clear();
            addProposalShowDgv.DataSource = null;

        }


        private void addProposalRegisterBtn_Click(object sender, EventArgs e)
        {
            if (!addProposalIsWatchingEdition)
            {
                if (addProposalExecutorNcodeTxtbx.Text.Length < 10)
                {
                    //PopUp p = new PopUp("خطای ورودی", "شماره ملی ده رقمی را به طور صحیح وارد نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();

                    string context = "شماره ملی ده رقمی را به طور صحیح وارد نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    addProposalExecutorNcodeTxtbx.Focus();
                }

                else if (addProposalExecutorFNameTxtbx.Text.Length == 0)
                {
                    //PopUp p = new PopUp("خطای ورودی", "نام را وارد نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "نام را وارد نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    addProposalExecutorFNameTxtbx.Focus();
                }

                else if (addProposalExecutorLNameTxtbx.Text.Length == 0)
                {
                    //PopUp p = new PopUp("خطای ورودی", "نام خانوادگی را وارد نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "نام خانوادگی را وارد نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    addProposalExecutorLNameTxtbx.Focus();
                }

                else if (addProposalExecutorFacultyCb.SelectedIndex == -1)
                {
                    //PopUp p = new PopUp("خطای ورودی", "دانشکده را انتخاب نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();

                    string context = "دانشکده را انتخاب نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    addProposalExecutorFacultyCb.Focus();
                }

                else if (addProposalExecutorEGroupCb.SelectedIndex == -1)
                {
                    //PopUp p = new PopUp("خطای ورودی", "گروه آموزشی را انتخاب نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "گروه آموزشی را انتخاب نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    addProposalExecutorEGroupCb.Focus();
                }

                else if (addProposalExecutorEDegCb.SelectedIndex == -1)
                {
                    //PopUp p = new PopUp("خطای ورودی", "درجه علمی را انتخاب نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "درجه علمی را انتخاب نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    addProposalExecutorEDegCb.Focus();
                }

                else if (addProposalExecutorEmailTxtbx.Text.Length == 0)
                {
                    //PopUp p = new PopUp("خطای ورودی", "آدرس ایمیل را وارد نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "آدرس ایمیل را وارد نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    addProposalExecutorEmailTxtbx.Focus();
                }

                else if (addProposalExecutorEmailTxtbx.BackColor == Color.Pink)
                {
                    //PopUp p = new PopUp("خطای ورودی", "آدرس ایمیل وارد شده صحیح نیست.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "آدرس ایمیل وارد شده صحیح نیست";
                    Alert alert = new Alert(context, "darkred", 5);
                    addProposalExecutorEmailTxtbx.Focus();
                }

                else if (addProposalExecutorMobileTxtbx.Text.Length == 0)
                {
                    //PopUp p = new PopUp("خطای ورودی", "شماره موبایل را وارد نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "شماره موبایل را وارد نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    addProposalExecutorMobileTxtbx.Focus();
                }

                else if (addProposalPersianTitleTxtbx.Text.Length == 0)
                {
                    //PopUp p = new PopUp("خطای ورودی", "عنوان فارسی پروپوزال را وارد نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "عنوان فارسی پروپوزال را وارد نمایید.";
                    Alert alert = new Alert(context, "darkred", 5);
                    addProposalPersianTitleTxtbx.Focus();
                }

                else if (addProposalEnglishTitleTxtbx.Text.Length == 0)
                {
                    //PopUp p = new PopUp("خطای ورودی", "عنوان لاتین پروپوزال را وارد نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "عنوان لاتین پروپوزال را وارد نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    addProposalEnglishTitleTxtbx.Focus();
                }

                else if (addProposalKeywordsTxtbx.Text.Length == 0)
                {
                    //PopUp p = new PopUp("خطای ورودی", "کلمات کلیدی را وارد نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "کلمات کلیدی را وارد نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    addProposalKeywordsTxtbx.Focus();
                }


                else if (addProposalFileLinkLbl.Text == "افزودن فایل")
                {
                    //PopUp p = new PopUp("خطای ورودی", "فایل پروپوزال را جهت بارگذاری انتخاب نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "فایل پروپوزال را جهت بارگذاری انتخاب نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    addProposalFileLinkLbl.Focus();
                }

                else if (addProposalDurationTxtbx.Text.Length == 0)
                {
                    //PopUp p = new PopUp("خطای ورودی", "مدت زمان را وارد نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "مدت زمان را وارد نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    addProposalDurationTxtbx.Focus();
                }

                else if (addProposalProcedureTypeCb.SelectedIndex == -1)
                {
                    //PopUp p = new PopUp("خطای ورودی", "نوع کار پروپوزال را انتخاب نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "نوع کار پروپوزال را انتخاب نمایید.";
                    Alert alert = new Alert(context, "darkred", 5);
                    addProposalProcedureTypeCb.Focus();
                }

                else if (addProposalPropertyTypeCb.SelectedIndex == -1)
                {
                    //PopUp p = new PopUp("خطای ورودی", "خاصیت پروپوزال را انتخاب نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "خاصیت پروپوزال را انتخاب نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    addProposalPropertyTypeCb.Focus();
                }

                else if (addProposalRegisterTypeCb.SelectedIndex == -1)
                {
                    //PopUp p = new PopUp("خطای ورودی", "نوع ثبت پروپوزال را انتخاب نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "نوع ثبت پروپوزال را انتخاب نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    addProposalRegisterTypeCb.Focus();
                }

                else if (addProposalProposalTypeCb.SelectedIndex == -1)
                {
                    //PopUp p = new PopUp("خطای ورودی", "نوع پروپوزال را انتخاب نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "نوع پروپوزال را انتخاب نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    addProposalProposalTypeCb.Focus();
                }

                else if (addProposalOrganizationNumberCb.SelectedIndex == -1)
                {
                    //PopUp p = new PopUp("خطای ورودی", "سازمان کارفرما را انتخاب نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "سازمان کارفرما را انتخاب نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    addProposalOrganizationNumberCb.Focus();
                }

                else if (addProposalOrganizationNameCb.SelectedIndex == -1)
                {
                    //PopUp p = new PopUp("خطای ورودی", "سازمان کارفرما را انتخاب نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "سازمان کارفرما را انتخاب نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    addProposalOrganizationNameCb.Focus();
                }

                else if (addProposalValueTxtbx.Text.Length == 0)
                {
                    //PopUp p = new PopUp("خطای ورودی", "مبلغ را وارد نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "مبلغ را وارد نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    addProposalValueTxtbx.Focus();
                }

                else if (addProposalStatusCb.SelectedIndex == -1)
                {
                    //PopUp p = new PopUp("خطای ورودی", "وضعیت پروپوزال را انتخاب نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "وضعیت پروپوزال را انتخاب نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    addProposalStatusCb.Focus();
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

                        dbh.AddTeacher(teacher, loginUser.U_NCode, DateTime.Now.ToString());
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
                    string tempValue = addProposalValueTxtbx.Text.Replace(",", "");
                    //addProposalValueTxtbx.Text = tempValue;
                    proposal.Value = long.Parse(tempValue);
                    proposal.Executor = long.Parse(addProposalExecutorNcodeTxtbx.Text);
                    //INITIALIZE STARTDATE OF PROPOSAL
                    string temp = addProposalStartdateTimeInput.GeoDate.Value.Year + "-";//YEAR
                    if (addProposalStartdateTimeInput.GeoDate.Value.Month > 9)//MONTH
                    {
                        temp += addProposalStartdateTimeInput.GeoDate.Value.Month + "-";
                    }
                    else
                    {
                        temp += "0" + addProposalStartdateTimeInput.GeoDate.Value.Month + "-";
                    }

                    if (addProposalStartdateTimeInput.GeoDate.Value.Day > 9)//DAY
                    {
                        temp += addProposalStartdateTimeInput.GeoDate.Value.Day;
                    }
                    else
                    {
                        temp += "0" + addProposalStartdateTimeInput.GeoDate.Value.Day;
                    }
                    //INITIALIZE STARTDATE OF PROPOSAL
                    proposal.StartDate = temp;
                    proposal.Registrant = loginUser.U_NCode;



                    //TotalPage = dbh.totalPage("SELECT COUNT(*) FROM proposalTable WHERE persianTitle = '" + addProposalPersianTitleTxtbx.Text + "'");


                    //CurrentPageIndex = 1;
                    //addProposalNavigationCurrentPageTxtbx.Text = CurrentPageIndex.ToString();
                    bool b = dbh.AddProposal(proposal, loginUser.U_NCode, myDateTime.ToString(), _inputParameter);
                    dbh.addProposalQuery = "SELECT TOP " + pageSize + " * FROM proposalTable WHERE persianTitle = '" + addProposalPersianTitleTxtbx.Text + "'";
                    if (b == true)
                    {
                        addProposalClearBtn.PerformClick();
                        dbh.dataGridViewUpdate3(addProposalShowDgv, addProposalBindingSource, dbh.addProposalQuery, pageSize, CurrentPageIndex);
                    }

                }
            }
            else if (addProposalIsWatchingEdition)
            {

                if (addProposalExecutorNcodeTxtbx.Text.Length < 10)
                {
                    //PopUp p = new PopUp("خطای ورودی", "شماره ملی ده رقمی را به طور صحیح وارد نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();

                    string context = "شماره ملی ده رقمی را به طور صحیح وارد نمایید";
                    Alert alert = new Alert(context, "darkred", 5);
                    addProposalExecutorNcodeTxtbx.Focus();
                }

                else if (addProposalExecutorFNameTxtbx.Text.Length == 0)
                {
                    //PopUp p = new PopUp("خطای ورودی", "نام را وارد نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "نام را وارد نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    addProposalExecutorFNameTxtbx.Focus();
                }

                else if (addProposalExecutorLNameTxtbx.Text.Length == 0)
                {
                    //PopUp p = new PopUp("خطای ورودی", "نام خانوادگی را وارد نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "نام خانوادگی را وارد نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    addProposalExecutorLNameTxtbx.Focus();
                }

                else if (addProposalExecutorFacultyCb.SelectedIndex == -1)
                {
                    //PopUp p = new PopUp("خطای ورودی", "دانشکده را انتخاب نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();

                    string context = "دانشکده را انتخاب نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    addProposalExecutorFacultyCb.Focus();
                }

                else if (addProposalExecutorEGroupCb.SelectedIndex == -1)
                {
                    //PopUp p = new PopUp("خطای ورودی", "گروه آموزشی را انتخاب نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "گروه آموزشی را انتخاب نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    addProposalExecutorEGroupCb.Focus();
                }

                else if (addProposalExecutorEDegCb.SelectedIndex == -1)
                {
                    //PopUp p = new PopUp("خطای ورودی", "درجه علمی را انتخاب نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "درجه علمی را انتخاب نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    addProposalExecutorEDegCb.Focus();
                }

                else if (addProposalExecutorEmailTxtbx.Text.Length == 0)
                {
                    //PopUp p = new PopUp("خطای ورودی", "آدرس ایمیل را وارد نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "آدرس ایمیل را وارد نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    addProposalExecutorEmailTxtbx.Focus();
                }

                else if (addProposalExecutorEmailTxtbx.BackColor == Color.Pink)
                {
                    //PopUp p = new PopUp("خطای ورودی", "آدرس ایمیل وارد شده صحیح نیست.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "آدرس ایمیل وارد شده صحیح نیست";
                    Alert alert = new Alert(context, "darkred", 5);
                    addProposalExecutorEmailTxtbx.Focus();
                }

                else if (addProposalExecutorMobileTxtbx.Text.Length == 0)
                {
                    //PopUp p = new PopUp("خطای ورودی", "شماره موبایل را وارد نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "شماره موبایل را وارد نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    addProposalExecutorMobileTxtbx.Focus();
                }

                else if (addProposalPersianTitleTxtbx.Text.Length == 0)
                {
                    //PopUp p = new PopUp("خطای ورودی", "عنوان فارسی پروپوزال را وارد نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "عنوان فارسی پروپوزال را وارد نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    addProposalPersianTitleTxtbx.Focus();
                }

                else if (addProposalEnglishTitleTxtbx.Text.Length == 0)
                {
                    //PopUp p = new PopUp("خطای ورودی", "عنوان لاتین پروپوزال را وارد نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "عنوان لاتین پروپوزال را وارد نمایید.";
                    Alert alert = new Alert(context, "bluegray", 5);
                    addProposalEnglishTitleTxtbx.Focus();
                }

                else if (addProposalKeywordsTxtbx.Text.Length == 0)
                {
                    //PopUp p = new PopUp("خطای ورودی", "کلمات کلیدی را وارد نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "کلمات کلیدی را وارد نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    addProposalKeywordsTxtbx.Focus();
                }


                else if (addProposalFileLinkLbl.Text == "افزودن فایل")
                {
                    //PopUp p = new PopUp("خطای ورودی", "فایل پروپوزال را جهت بارگذاری انتخاب نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "فایل پروپوزال را جهت بارگذاری انتخاب نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    addProposalFileLinkLbl.Focus();
                }

                else if (addProposalDurationTxtbx.Text.Length == 0)
                {
                    //PopUp p = new PopUp("خطای ورودی", "مدت زمان را وارد نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "مدت زمان را وارد نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    addProposalDurationTxtbx.Focus();
                }

                else if (addProposalProcedureTypeCb.SelectedIndex == -1)
                {
                    //PopUp p = new PopUp("خطای ورودی", "نوع کار پروپوزال را انتخاب نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "نوع کار پروپوزال را انتخاب نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    addProposalProcedureTypeCb.Focus();
                }

                else if (addProposalPropertyTypeCb.SelectedIndex == -1)
                {
                    //PopUp p = new PopUp("خطای ورودی", "خاصیت پروپوزال را انتخاب نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "خاصیت پروپوزال را انتخاب نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    addProposalPropertyTypeCb.Focus();
                }

                else if (addProposalRegisterTypeCb.SelectedIndex == -1)
                {
                    //PopUp p = new PopUp("خطای ورودی", "نوع ثبت پروپوزال را انتخاب نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "نوع ثبت پروپوزال را انتخاب نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    addProposalRegisterTypeCb.Focus();
                }

                else if (addProposalProposalTypeCb.SelectedIndex == -1)
                {
                    //PopUp p = new PopUp("خطای ورودی", "نوع پروپوزال را انتخاب نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "نوع پروپوزال را انتخاب نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    addProposalProposalTypeCb.Focus();
                }

                else if (addProposalOrganizationNumberCb.SelectedIndex == -1)
                {
                    //PopUp p = new PopUp("خطای ورودی", "سازمان کارفرما را انتخاب نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "سازمان کارفرما را انتخاب نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    addProposalOrganizationNumberCb.Focus();
                }

                else if (addProposalOrganizationNameCb.SelectedIndex == -1)
                {
                    //PopUp p = new PopUp("خطای ورودی", "سازمان کارفرما را انتخاب نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "سازمان کارفرما را انتخاب نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    addProposalOrganizationNameCb.Focus();
                }

                else if (addProposalValueTxtbx.Text.Length == 0)
                {
                    //PopUp p = new PopUp("خطای ورودی", "مبلغ را وارد نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "مبلغ را وارد نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    addProposalValueTxtbx.Focus();
                }

                else if (addProposalStatusCb.SelectedIndex == -1)
                {
                    //PopUp p = new PopUp("خطای ورودی", "وضعیت پروپوزال را انتخاب نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "وضعیت پروپوزال را انتخاب نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    addProposalStatusCb.Focus();
                }
                else
                {


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
                    string tempValue = addProposalValueTxtbx.Text.Replace(",", "");
                    //addProposalValueTxtbx.Text = tempValue;
                    proposal.Value = long.Parse(tempValue);
                    proposal.Executor = long.Parse(addProposalExecutorNcodeTxtbx.Text);
                    //INITIALIZE STARTDATE OF PROPOSAL
                    string temp = addProposalStartdateTimeInput.GeoDate.Value.Year + "-";//YEAR
                    if (addProposalStartdateTimeInput.GeoDate.Value.Month > 9)//MONTH
                    {
                        temp += addProposalStartdateTimeInput.GeoDate.Value.Month + "-";
                    }
                    else
                    {
                        temp += "0" + addProposalStartdateTimeInput.GeoDate.Value.Month + "-";
                    }

                    if (addProposalStartdateTimeInput.GeoDate.Value.Day > 9)//DAY
                    {
                        temp += addProposalStartdateTimeInput.GeoDate.Value.Day;
                    }
                    else
                    {
                        temp += "0" + addProposalStartdateTimeInput.GeoDate.Value.Day;
                    }
                    //INITIALIZE STARTDATE OF PROPOSAL
                    proposal.StartDate = temp;
                    proposal.Registrant = loginUser.U_NCode;
                    proposal.Index = editionProposalIndex;


                    dbh.AddEdition(proposal, loginUser.U_NCode, myDateTime.ToString(), _inputParameter);
                    addProposalFileLinkLbl.Text = "افزودن فایل";
                    //addProposalClearBtn.PerformClick();
                    addProposalShowDgv.Columns.Clear();
                    dbh.dataGridViewUpdate2(addProposalShowDgv, addProposalBindingSource, "SELECT * FROM editionTable WHERE [index] = '" + editionProposalIndex + "'");
                    addProposalShowDgv.Columns["editionBtn"].Visible = false;
                    addProposalShowDgv.Columns["edition"].HeaderText = "شماره نسخه";
                    addProposalShowDgv.Columns["edition"].DisplayIndex = 3;
                    addProposalShowDgv.Columns["edition"].Frozen = true;
                    addProposalIsWatchingEdition = true;

                }
            }
        }


        private void appSettingAddBtn_Click(object sender, EventArgs e)
        {

            if (appSettingProcedureTypeTxtbx.Enabled == true)
            {
                if (!appSettingProcedureTypeTxtbx.Text.Equals(""))
                {
                    dbh.AddProcedureType(appSettingProcedureTypeTxtbx.Text, loginUser.U_NCode, myDateTime.ToString());
                    appSettingProcedureTypeTxtbx.Clear();
                    dbh.dataGridViewUpdate2(appSettingShowDv, appSettingBindingSource, "SELECT procedureType FROM procedureTypeTable");


                    addProposalProcedureTypeCb.Items.Clear();
                    editProposalProcedureTypeCb.Items.Clear();
                    searchProposalProcedureTypeCb.Items.Clear();

                    comboList = dbh.getProcedureType();
                    foreach (String procedure in comboList)
                    {
                        addProposalProcedureTypeCb.Items.Add(procedure);
                        editProposalProcedureTypeCb.Items.Add(procedure);
                        searchProposalProcedureTypeCb.Items.Add(procedure);
                    }

                    appSettingProcedureTypeTxtbx.Focus();
                }
            }

            else if (appSettingPropertyTxtbx.Enabled == true)
            {
                if (!appSettingPropertyTxtbx.Text.Equals(""))
                {
                    dbh.AddPropertyType(appSettingPropertyTxtbx.Text, loginUser.U_NCode, myDateTime.ToString());
                    appSettingPropertyTxtbx.Clear();

                    dbh.dataGridViewUpdate2(appSettingShowDv, appSettingBindingSource, "SELECT propertyType FROM propertyTypeTable");
                    addProposalPropertyTypeCb.Items.Clear();
                    editProposalPropertyTypeCb.Items.Clear();
                    searchProposalPropertyTypeCb.Items.Clear();

                    comboList = dbh.getPropertyType();
                    foreach (String Property in comboList)
                    {
                        addProposalPropertyTypeCb.Items.Add(Property);
                        editProposalPropertyTypeCb.Items.Add(Property);
                        searchProposalPropertyTypeCb.Items.Add(Property);
                    }

                    // form_initializer(); // To Reset items of comboBoxes and others
                    appSettingPropertyTxtbx.Focus();
                }
            }

            else if (appSettingFacultyTxtbx.Enabled == true)
            {
                if (!appSettingFacultyTxtbx.Text.Equals(""))
                {
                    dbh.AddFaculty(appSettingFacultyTxtbx.Text, loginUser.U_NCode, myDateTime.ToString());
                    appSettingFacultyTxtbx.Clear();
                    dbh.dataGridViewUpdate2(appSettingShowDv, appSettingBindingSource, "SELECT facultyName FROM facultyTable");

                    addProposalExecutorFacultyCb.Items.Clear();
                    editProposalExecutorFacultyCb.Items.Clear();
                    searchProposalExecutorFacultyCb.Items.Clear();
                    manageTeacherExecutorFacultyCb.Items.Clear();

                    comboList = dbh.getFaculty();
                    foreach (String ExecutorFaculty in comboList)
                    {
                        addProposalExecutorFacultyCb.Items.Add(ExecutorFaculty);
                        editProposalExecutorFacultyCb.Items.Add(ExecutorFaculty);
                        searchProposalExecutorFacultyCb.Items.Add(ExecutorFaculty);
                        manageTeacherExecutorFacultyCb.Items.Add(ExecutorFaculty);
                    }

                    // form_initializer(); // To Reset items of comboBoxes and others
                    appSettingFacultyTxtbx.Focus();
                }
            }

            else if (appSettingRegTypeTxtbx.Enabled == true)
            {
                if (!appSettingRegTypeTxtbx.Text.Equals(""))
                {
                    dbh.AddRegisterType(appSettingRegTypeTxtbx.Text, loginUser.U_NCode, myDateTime.ToString());
                    appSettingRegTypeTxtbx.Clear();
                    dbh.dataGridViewUpdate2(appSettingShowDv, appSettingBindingSource, "SELECT registerType FROM registerTypeTable");

                    addProposalRegisterTypeCb.Items.Clear();
                    editProposalRegisterTypeCb.Items.Clear();
                    searchProposalRegisterTypeCb.Items.Clear();

                    comboList = dbh.getRegisterType();
                    foreach (String RegisterType in comboList)
                    {
                        addProposalRegisterTypeCb.Items.Add(RegisterType);
                        editProposalRegisterTypeCb.Items.Add(RegisterType);
                        searchProposalRegisterTypeCb.Items.Add(RegisterType);
                    }
                    appSettingRegTypeTxtbx.Focus();
                }
            }

            else if (appSettingProTypeTxtbx.Enabled == true)
            {
                if (!appSettingProTypeTxtbx.Text.Equals(""))
                {
                    dbh.AddProposalType(appSettingProTypeTxtbx.Text, loginUser.U_NCode, myDateTime.ToString());
                    appSettingProTypeTxtbx.Clear();
                    dbh.dataGridViewUpdate2(appSettingShowDv, appSettingBindingSource, "SELECT proposalType FROM proposalTypeTable");

                    addProposalProposalTypeCb.Items.Clear();
                    editProposalTypeCb.Items.Clear();
                    searchProposalTypeCb.Items.Clear();

                    comboList = dbh.getProposalType();
                    foreach (String ProposalType in comboList)
                    {
                        addProposalProposalTypeCb.Items.Add(ProposalType);
                        editProposalTypeCb.Items.Add(ProposalType);
                        searchProposalTypeCb.Items.Add(ProposalType);
                    }
                    appSettingProTypeTxtbx.Focus();
                }
            }

            else if (appSettingEgroupTxtbx.Enabled == true)
            {
                if (!appSettingEgroupTxtbx.Text.Equals(""))
                {
                    dbh.AddEGroup(appSettingFacultyTxtbx.Text, appSettingEgroupTxtbx.Text, loginUser.U_NCode, DateTime.Now.ToString());
                    appSettingEgroupTxtbx.Clear();
                    dbh.dataGridViewUpdate2(appSettingShowDv, appSettingBindingSource, "SELECT groupName FROM EGroupTable WHERE facultyName ='" + appSettingFacultyTxtbx.Text + "'");

                    comboList = dbh.getEGroup(appSettingFacultyTxtbx.Text);

                    addProposalExecutorEGroupCb.Items.Clear();
                    editProposalExecutorEGroupCb.Items.Clear();
                    searchProposalExecutorEGroupCb.Items.Clear();
                    manageTeacherExecutorEgroupCb.Items.Clear();



                    foreach (String EGroup in comboList)
                    {
                        addProposalExecutorEGroupCb.Items.Add(EGroup);
                        editProposalExecutorEGroupCb.Items.Add(EGroup);
                        searchProposalExecutorEGroupCb.Items.Add(EGroup);
                        manageTeacherExecutorEgroupCb.Items.Add(EGroup);

                        appSettingEgroupTxtbx.Focus();
                    }
                }
            }

            else if (appSettingCoTxtbx.Enabled == true)
            {
                if (!appSettingCoTxtbx.Text.Equals(""))
                {
                    dbh.AddEmployer(appSettingCoTxtbx.Text, loginUser.U_NCode, myDateTime.ToString());
                    appSettingCoTxtbx.Clear();
                    dbh.dataGridViewUpdate2(appSettingShowDv, appSettingBindingSource, "SELECT * FROM employersTable");
                    appSettingShowDv.Columns["orgName"].HeaderText = "نام سازمان";
                    appSettingShowDv.Columns["index"].HeaderText = "کد سازمان";
                    // appSettingShowDv.Columns[2].Visible = false;

                    emp = dbh.getEmployers();
                    addProposalOrganizationNameCb.Items.Clear();
                    addProposalOrganizationNumberCb.Items.Clear();
                    editProposalOrganizationNameCb.Items.Clear();
                    editProposalOrganizationNumberCb.Items.Clear();
                    searchProposalOrganizationNameCb.Items.Clear();
                    searchProposalOrganizationNumberCb.Items.Clear();

                    editProposalStatusCb.Items.Clear();
                    searchProposalStatusCb.Items.Clear();
                    foreach (Employers employer in emp)
                    {
                        addProposalOrganizationNumberCb.Items.Add(employer.Index);
                        addProposalOrganizationNameCb.Items.Add(employer.OrgName);
                        
                        editProposalOrganizationNumberCb.Items.Add(employer.Index);
                        editProposalOrganizationNameCb.Items.Add(employer.OrgName);
                        
                        searchProposalOrganizationNumberCb.Items.Add(employer.Index);
                        searchProposalOrganizationNameCb.Items.Add(employer.OrgName);
                    }
                    appSettingCoTxtbx.Focus();
                }
            }

            else if (appSettingStatusTxtbx.Enabled == true)
            {
                if (!appSettingStatusTxtbx.Text.Equals(""))
                {
                    dbh.AddStatusType(appSettingStatusTxtbx.Text, loginUser.U_NCode, myDateTime.ToString());
                    appSettingStatusTxtbx.Clear();
                    dbh.dataGridViewUpdate2(appSettingShowDv, appSettingBindingSource, "SELECT statusType FROM statusTypeTable");


                    comboList = dbh.getStatusType();
                    addProposalStatusCb.Items.Clear();
                    editProposalStatusCb.Items.Clear();
                    searchProposalStatusCb.Items.Clear();


                    foreach (String Status in comboList)
                    {
                        addProposalStatusCb.Items.Add(Status);
                        editProposalStatusCb.Items.Add(Status);
                        searchProposalStatusCb.Items.Add(Status);
                    }
                    appSettingStatusTxtbx.Focus();
                }
            }

            else if (appSettingEdegreeTxtbx.Enabled == true)
            {
                // MessageBox
                if (!appSettingEdegreeTxtbx.Text.Equals(""))
                {
                    dbh.AddEDegree(appSettingEdegreeTxtbx.Text, loginUser.U_NCode, myDateTime.ToString());
                    appSettingEdegreeTxtbx.Clear();
                    dbh.dataGridViewUpdate2(appSettingShowDv, appSettingBindingSource, "SELECT * FROM EDegreeTable");

                    comboList = dbh.getEDeg();
                    addProposalExecutorEDegCb.Items.Clear();
                    editProposalExecutorEDegCb.Items.Clear();
                    manageTeacherExecutorEDegCb.Items.Clear();
                    //searchProposalEde.Items.Clear();


                    foreach (String ExecutorEDeg in comboList)
                    {
                        addProposalExecutorEDegCb.Items.Add(ExecutorEDeg);
                        editProposalExecutorEDegCb.Items.Add(ExecutorEDeg);
                        manageTeacherExecutorEDegCb.Items.Add(ExecutorEDeg);
                        //  searchProposalStatusCb.Items.Add(Status);
                    }
                    appSettingEdegreeTxtbx.Focus();
                }
            }
        }
       
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
         
        private void manageTeacherExecutorNcodeTxtbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }
          
        private void manageTeacherExecutorEmailTxtbx_Leave(object sender, EventArgs e)
        {
            if (!manageTeacherExecutorEmailTxtbx.Text.Equals("") && !System.Text.RegularExpressions.Regex.IsMatch(manageTeacherExecutorEmailTxtbx.Text, @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"))
            {
                manageTeacherExecutorEmailTxtbx.BackColor = Color.Pink;
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(manageTeacherExecutorEmailTxtbx.Text, @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"))
            {
                manageTeacherExecutorEmailTxtbx.BackColor = Color.LightGreen;
            }
        }

        private void manageTeacherExecutorEmailTxtbx_TextChanged(object sender, EventArgs e)
        {
            manageTeacherExecutorEmailTxtbx.BackColor = Color.White;
        }

        private void appSettingProcedureTypeRbtn_Click(object sender, EventArgs e)
        {
            appSettingEditBtn.Enabled = false;
            appSettingDeleteBtn.Enabled = false;

            appSettingProcedureTypeTxtbx.Enabled = true;
            appSettingProcedureTypeTxtbx.Focus();

            appSettingPropertyTxtbx.Enabled = false;
            appSettingFacultyTxtbx.Enabled = false;
            appSettingRegTypeTxtbx.Enabled = false;
            appSettingProTypeTxtbx.Enabled = false;
            appSettingEgroupTxtbx.Enabled = false;
            appSettingCoTxtbx.Enabled = false;
            appSettingStatusTxtbx.Enabled = false;

            appSettingEdegreeTxtbx.Enabled = false;
            appSettingEdegreeTxtbx.Clear();

            appSettingPropertyTxtbx.Clear();
            appSettingFacultyTxtbx.Clear();
            appSettingRegTypeTxtbx.Clear();
            appSettingProTypeTxtbx.Clear();
            appSettingEgroupTxtbx.Clear();
            appSettingCoTxtbx.Clear();
            appSettingStatusTxtbx.Clear();

            appSettingAddBtn.Enabled = true;

            dbh.dataGridViewUpdate2(appSettingShowDv, appSettingBindingSource, "SELECT procedureType FROM procedureTypeTable");
            appSettingShowDv.Columns[0].HeaderText = "نوع کار";
        }

        private void appSettingPropertyRbtn_Click(object sender, EventArgs e)
        {
            appSettingEditBtn.Enabled = false;
            appSettingDeleteBtn.Enabled = false;


            appSettingProcedureTypeTxtbx.Enabled = false;
            appSettingPropertyTxtbx.Enabled = true;
            appSettingPropertyTxtbx.Focus();

            appSettingFacultyTxtbx.Enabled = false;
            appSettingRegTypeTxtbx.Enabled = false;
            appSettingProTypeTxtbx.Enabled = false;
            appSettingEgroupTxtbx.Enabled = false;
            appSettingCoTxtbx.Enabled = false;
            appSettingStatusTxtbx.Enabled = false;

            appSettingEdegreeTxtbx.Enabled = false;
            appSettingEdegreeTxtbx.Clear();

            appSettingProcedureTypeTxtbx.Clear();
            appSettingFacultyTxtbx.Clear();
            appSettingRegTypeTxtbx.Clear();
            appSettingProTypeTxtbx.Clear();
            appSettingEgroupTxtbx.Clear();
            appSettingCoTxtbx.Clear();
            appSettingStatusTxtbx.Clear();

            appSettingAddBtn.Enabled = true;

            dbh.dataGridViewUpdate2(appSettingShowDv, appSettingBindingSource, "SELECT propertyType FROM propertyTypeTable");
            appSettingShowDv.Columns[0].HeaderText = "نوع خاصیت";
        }

        private void appSettingFacultyRbtn_Click(object sender, EventArgs e)
        {
            appSettingEditBtn.Enabled = false;
            appSettingDeleteBtn.Enabled = false;

            appSettingProcedureTypeTxtbx.Enabled = false;
            appSettingPropertyTxtbx.Enabled = false;
            appSettingFacultyTxtbx.Enabled = true;
            appSettingFacultyTxtbx.Focus();

            appSettingRegTypeTxtbx.Enabled = false;
            appSettingProTypeTxtbx.Enabled = false;
            appSettingEgroupTxtbx.Enabled = false;
            appSettingCoTxtbx.Enabled = false;
            appSettingStatusTxtbx.Enabled = false;
            appSettingEdegreeTxtbx.Enabled = false;
            appSettingEdegreeTxtbx.Clear();

            appSettingProcedureTypeTxtbx.Clear();
            appSettingPropertyTxtbx.Clear();
            appSettingRegTypeTxtbx.Clear();
            appSettingProTypeTxtbx.Clear();
            appSettingEgroupTxtbx.Clear();
            appSettingCoTxtbx.Clear();
            appSettingStatusTxtbx.Clear();

            appSettingAddBtn.Enabled = true;

            dbh.dataGridViewUpdate2(appSettingShowDv, appSettingBindingSource, "SELECT facultyName FROM facultyTable");
            appSettingShowDv.Columns[0].HeaderText = "نام دانشکده";
        }

        private void appSettingRegTypeRbtn_Click(object sender, EventArgs e)
        {
            appSettingEditBtn.Enabled = false;
            appSettingDeleteBtn.Enabled = false;


            appSettingProcedureTypeTxtbx.Enabled = false;
            appSettingPropertyTxtbx.Enabled = false;
            appSettingFacultyTxtbx.Enabled = false;
            appSettingRegTypeTxtbx.Enabled = true;
            appSettingRegTypeTxtbx.Focus();

            appSettingProTypeTxtbx.Enabled = false;
            appSettingEgroupTxtbx.Enabled = false;
            appSettingCoTxtbx.Enabled = false;
            appSettingStatusTxtbx.Enabled = false;
            appSettingEdegreeTxtbx.Enabled = false;
            appSettingEdegreeTxtbx.Clear();

            appSettingProcedureTypeTxtbx.Clear();
            appSettingPropertyTxtbx.Clear();
            appSettingFacultyTxtbx.Clear();
            appSettingProTypeTxtbx.Clear();
            appSettingEgroupTxtbx.Clear();
            appSettingCoTxtbx.Clear();
            appSettingStatusTxtbx.Clear();

            appSettingAddBtn.Enabled = true;

            dbh.dataGridViewUpdate2(appSettingShowDv, appSettingBindingSource, "SELECT registerType FROM registerTypeTable");
            appSettingShowDv.Columns[0].HeaderText = "نوع ثبت";
        }

        private void appSettingProTypeRbtn_Click(object sender, EventArgs e)
        {

            appSettingEditBtn.Enabled = false;
            appSettingDeleteBtn.Enabled = false;
            appSettingProcedureTypeTxtbx.Enabled = false;
            appSettingPropertyTxtbx.Enabled = false;
            appSettingFacultyTxtbx.Enabled = false;
            appSettingRegTypeTxtbx.Enabled = false;
            appSettingProTypeTxtbx.Enabled = true;
            appSettingProTypeTxtbx.Focus();

            appSettingEgroupTxtbx.Enabled = false;
            appSettingCoTxtbx.Enabled = false;
            appSettingStatusTxtbx.Enabled = false;
            appSettingEdegreeTxtbx.Enabled = false;
            appSettingEdegreeTxtbx.Clear();

            appSettingProcedureTypeTxtbx.Clear();
            appSettingPropertyTxtbx.Clear();
            appSettingFacultyTxtbx.Clear();
            appSettingRegTypeTxtbx.Clear();
            appSettingEgroupTxtbx.Clear();
            appSettingCoTxtbx.Clear();
            appSettingStatusTxtbx.Clear();

            appSettingAddBtn.Enabled = true;

            dbh.dataGridViewUpdate2(appSettingShowDv, appSettingBindingSource, "SELECT proposalType FROM proposalTypeTable");
            appSettingShowDv.Columns[0].HeaderText = "نوع پروپوزال";
        }

        private void appSettingEgroupRbtn_Click(object sender, EventArgs e)
        {
            //There is no actions yet, maybe later.
        }

        private void appSettingCoRbtn_Click(object sender, EventArgs e)
        {
            appSettingEditBtn.Enabled = false;
            appSettingDeleteBtn.Enabled = false;


            appSettingProcedureTypeTxtbx.Enabled = false;
            appSettingPropertyTxtbx.Enabled = false;
            appSettingFacultyTxtbx.Enabled = false;
            appSettingRegTypeTxtbx.Enabled = false;
            appSettingProTypeTxtbx.Enabled = false;
            appSettingEgroupTxtbx.Enabled = false;
            appSettingCoTxtbx.Enabled = true;
            appSettingCoTxtbx.Focus();

            appSettingStatusTxtbx.Enabled = false;
            appSettingEdegreeTxtbx.Enabled = false;
            appSettingEdegreeTxtbx.Clear();

            appSettingProcedureTypeTxtbx.Clear();
            appSettingPropertyTxtbx.Clear();
            appSettingFacultyTxtbx.Clear();
            appSettingRegTypeTxtbx.Clear();
            appSettingEgroupTxtbx.Clear();
            appSettingProTypeTxtbx.Clear();
            appSettingStatusTxtbx.Clear();

            appSettingAddBtn.Enabled = true;
            appSettingNavigationPanel.Enabled = true;

            dbh.dataGridViewUpdate2(appSettingShowDv, appSettingBindingSource, "SELECT * FROM employersTable");
            appSettingShowDv.Columns["index"].HeaderText = "کد سازمان";
            appSettingShowDv.Columns["orgName"].HeaderText = "نام سازمان";
            appSettingShowDv.Columns["orgName"].DisplayIndex = 0;
            
            //appSettingShowDv.Columns["index"].DisplayIndex = 2;


            // appSettingShowDv.Columns[2].Visible = false;
        }

        private void appSettingStatusRbtn_Click(object sender, EventArgs e)
        {
            appSettingEditBtn.Enabled = false;
            appSettingDeleteBtn.Enabled = false;

            

            appSettingProcedureTypeTxtbx.Enabled = false;
            appSettingPropertyTxtbx.Enabled = false;
            appSettingFacultyTxtbx.Enabled = false;
            appSettingRegTypeTxtbx.Enabled = false;
            appSettingProTypeTxtbx.Enabled = false;
            appSettingEgroupTxtbx.Enabled = false;
            appSettingCoTxtbx.Enabled = false;
            appSettingStatusTxtbx.Enabled = true;
            appSettingStatusTxtbx.Focus();

            appSettingEdegreeTxtbx.Enabled = false;
            appSettingEdegreeTxtbx.Clear();

            appSettingProcedureTypeTxtbx.Clear();
            appSettingPropertyTxtbx.Clear();
            appSettingFacultyTxtbx.Clear();
            appSettingRegTypeTxtbx.Clear();
            appSettingEgroupTxtbx.Clear();
            appSettingProTypeTxtbx.Clear();
            appSettingCoTxtbx.Clear();

            appSettingAddBtn.Enabled = true;

            dbh.dataGridViewUpdate2(appSettingShowDv, appSettingBindingSource, "SELECT statusType FROM statusTypeTable");
            appSettingShowDv.Columns[0].HeaderText = "وضعیت";
        }

        private void appSettingEditBtn_Click(object sender, EventArgs e)
        {
            if (appSettingProcedureTypeTxtbx.Enabled == true)
            {
                if (!appSettingProcedureTypeTxtbx.Text.Equals(""))
                {
                    dbh.EditProcedureType(appSettingProcedureTypeTxtbx.Text, appSettingCurrentSelectedOption, loginUser.U_NCode, myDateTime.ToString());
                    appSettingProcedureTypeTxtbx.Clear();
                    dbh.dataGridViewUpdate2(appSettingShowDv, appSettingBindingSource, "SELECT procedureType FROM procedureTypeTable");
                    appSettingShowDv.Columns[0].HeaderText = "نوع کار";

                    addProposalProcedureTypeCb.Items.Clear();
                    editProposalProcedureTypeCb.Items.Clear();
                    searchProposalProcedureTypeCb.Items.Clear();

                    comboList = dbh.getProcedureType();
                    foreach (String procedure in comboList)
                    {
                        addProposalProcedureTypeCb.Items.Add(procedure);
                        editProposalProcedureTypeCb.Items.Add(procedure);
                        searchProposalProcedureTypeCb.Items.Add(procedure);
                    }

                    appSettingProcedureTypeTxtbx.Focus();
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
                    dbh.EditPropertyType(appSettingPropertyTxtbx.Text, appSettingCurrentSelectedOption, loginUser.U_NCode, myDateTime.ToString());
                    appSettingPropertyTxtbx.Clear();
                    dbh.dataGridViewUpdate2(appSettingShowDv, appSettingBindingSource, "SELECT propertyType FROM propertyTypeTable");
                    appSettingShowDv.Columns[0].HeaderText = "نوع خاصیت";

                    addProposalPropertyTypeCb.Items.Clear();
                    editProposalPropertyTypeCb.Items.Clear();
                    searchProposalPropertyTypeCb.Items.Clear();

                    comboList = dbh.getPropertyType();
                    foreach (String Property in comboList)
                    {
                        addProposalPropertyTypeCb.Items.Add(Property);
                        editProposalPropertyTypeCb.Items.Add(Property);
                        searchProposalPropertyTypeCb.Items.Add(Property);
                    }

                    appSettingPropertyTxtbx.Focus();
                }
                else
                {
                    PopUp popUp = new PopUp("خطا", "نوع خاصیت را مشخص کنید.", "تایید", "", "", "error");
                    popUp.ShowDialog();
                    appSettingPropertyTxtbx.Focus();
                }
            }

            else if (appSettingFacultyTxtbx.Enabled == true)
            {
                if (!appSettingFacultyTxtbx.Text.Equals(""))
                {
                    dbh.EditFaculty(appSettingFacultyTxtbx.Text, appSettingCurrentSelectedOption, loginUser.U_NCode, myDateTime.ToString());
                    appSettingFacultyTxtbx.Clear();
                    dbh.dataGridViewUpdate2(appSettingShowDv, appSettingBindingSource, "SELECT facultyName FROM facultyTable");
                    appSettingShowDv.Columns[0].HeaderText = "نام دانشکده";

                    addProposalExecutorFacultyCb.Items.Clear();
                    editProposalExecutorFacultyCb.Items.Clear();
                    searchProposalExecutorFacultyCb.Items.Clear();
                    manageTeacherExecutorFacultyCb.Items.Clear();

                    comboList = dbh.getFaculty();
                    foreach (String ExecutorFaculty in comboList)
                    {
                        addProposalExecutorFacultyCb.Items.Add(ExecutorFaculty);
                        editProposalExecutorFacultyCb.Items.Add(ExecutorFaculty);
                        searchProposalExecutorFacultyCb.Items.Add(ExecutorFaculty);
                        manageTeacherExecutorFacultyCb.Items.Add(ExecutorFaculty);
                    }
                    appSettingFacultyTxtbx.Focus();
                }
                else
                {
                    PopUp popUp = new PopUp("خطا", "نام دانشکده را مشخص کنید.", "تایید", "", "", "error");
                    popUp.ShowDialog();
                    appSettingFacultyTxtbx.Focus();
                }
            }

            else if (appSettingRegTypeTxtbx.Enabled == true)
            {
                if (!appSettingRegTypeTxtbx.Text.Equals(""))
                {
                    dbh.EditRegisterType(appSettingRegTypeTxtbx.Text, appSettingCurrentSelectedOption, loginUser.U_NCode, myDateTime.ToString());
                    appSettingRegTypeTxtbx.Clear();
                    dbh.dataGridViewUpdate2(appSettingShowDv, appSettingBindingSource, "SELECT registerType FROM registerTypeTable");
                    appSettingShowDv.Columns[0].HeaderText = "نوع ثبت";

                    addProposalRegisterTypeCb.Items.Clear();
                    editProposalRegisterTypeCb.Items.Clear();
                    searchProposalRegisterTypeCb.Items.Clear();

                    comboList = dbh.getRegisterType();
                    foreach (String RegisterType in comboList)
                    {
                        addProposalRegisterTypeCb.Items.Add(RegisterType);
                        editProposalRegisterTypeCb.Items.Add(RegisterType);
                        searchProposalRegisterTypeCb.Items.Add(RegisterType);
                    }
                    appSettingRegTypeTxtbx.Focus();
                }
                else
                {
                    PopUp popUp = new PopUp("خطا", "نوع ثبت را مشخص کنید.", "تایید", "", "", "error");
                    popUp.ShowDialog();
                    appSettingRegTypeTxtbx.Focus();
                }
            }

            else if (appSettingProTypeTxtbx.Enabled == true)
            {
                if (!appSettingProTypeTxtbx.Text.Equals(""))
                {
                    dbh.EditProposalType(appSettingProTypeTxtbx.Text, appSettingCurrentSelectedOption, loginUser.U_NCode, myDateTime.ToString());
                    appSettingProTypeTxtbx.Clear();
                    dbh.dataGridViewUpdate2(appSettingShowDv, appSettingBindingSource, "SELECT proposalType FROM proposalTypeTable");
                    appSettingShowDv.Columns[0].HeaderText = "نوع پروپوزال";


                    addProposalProposalTypeCb.Items.Clear();
                    editProposalTypeCb.Items.Clear();
                    searchProposalTypeCb.Items.Clear();

                    comboList = dbh.getProposalType();
                    foreach (String ProposalType in comboList)
                    {
                        addProposalProposalTypeCb.Items.Add(ProposalType);
                        editProposalTypeCb.Items.Add(ProposalType);
                        searchProposalTypeCb.Items.Add(ProposalType);
                    }
                   
                    appSettingProTypeTxtbx.Focus();
                }
                else
                {
                    PopUp popUp = new PopUp("خطا", "نوع پروپوزال را مشخص کنید.", "تایید", "", "", "error");
                    popUp.ShowDialog();
                    appSettingProTypeTxtbx.Focus();
                }
            }

            else if (appSettingEgroupTxtbx.Enabled == true)
            {
                if (!appSettingEgroupTxtbx.Text.Equals(""))
                {
                    dbh.EditEGroup(appSettingEgroupTxtbx.Text, appSettingCurrentSelectedOption, loginUser.U_NCode, myDateTime.ToString());
                    appSettingEgroupTxtbx.Clear();
                    dbh.dataGridViewUpdate2(appSettingShowDv, appSettingBindingSource, "SELECT groupName FROM EGroupTable WHERE facultyName ='" + appSettingFacultyTxtbx.Text + "'");
                    appSettingShowDv.Columns[0].HeaderText = "گروه آموزشی";

                    comboList = dbh.getEGroup(appSettingFacultyTxtbx.Text);

                    addProposalExecutorEGroupCb.Items.Clear();
                    editProposalExecutorEGroupCb.Items.Clear();
                    searchProposalExecutorEGroupCb.Items.Clear();
                    manageTeacherExecutorEgroupCb.Items.Clear();


                    foreach (String EGroup in comboList)
                    {
                        addProposalExecutorEGroupCb.Items.Add(EGroup);
                        editProposalExecutorEGroupCb.Items.Add(EGroup);
                        searchProposalExecutorEGroupCb.Items.Add(EGroup);
                        manageTeacherExecutorEgroupCb.Items.Add(EGroup);
                    }

                    appSettingEgroupTxtbx.Focus();
                }
                else
                {
                    PopUp popUp = new PopUp("خطا", "نام گروه را مشخص کنید.", "تایید", "", "", "error");
                    popUp.ShowDialog();
                    appSettingEgroupTxtbx.Focus();
                }
            }

            else if (appSettingCoTxtbx.Enabled == true)
            {
                if (!appSettingCoTxtbx.Text.Equals(""))
                {
                    Employers employer = new Employers();
                    employer.Index = int.Parse(currentSelectedIndex);
                    employer.OrgName = appSettingCoTxtbx.Text;
                    dbh.EditEmployer(employer, appSettingCurrentSelectedOption, loginUser.U_NCode, myDateTime.ToString());
                    appSettingCoTxtbx.Clear();
                    dbh.dataGridViewUpdate2(appSettingShowDv, appSettingBindingSource, "SELECT * FROM employersTable");
                    appSettingShowDv.Columns[0].HeaderText = "کد سازمان";
                    appSettingShowDv.Columns[1].HeaderText = "نام سازمان";
                    //    appSettingShowDv.Columns[2].Visible = false;


                    emp = dbh.getEmployers();
                    addProposalOrganizationNameCb.Items.Clear();
                    addProposalOrganizationNumberCb.Items.Clear();
                    editProposalOrganizationNameCb.Items.Clear();
                    editProposalOrganizationNumberCb.Items.Clear();
                    searchProposalOrganizationNameCb.Items.Clear();
                    searchProposalOrganizationNumberCb.Items.Clear();

                    editProposalStatusCb.Items.Clear();
                    searchProposalStatusCb.Items.Clear();
                    foreach (Employers employer2 in emp)
                    {
                        addProposalOrganizationNumberCb.Items.Add(employer2.Index);
                        addProposalOrganizationNameCb.Items.Add(employer2.OrgName);

                        editProposalOrganizationNumberCb.Items.Add(employer2.Index);
                        editProposalOrganizationNameCb.Items.Add(employer2.OrgName);

                        searchProposalOrganizationNumberCb.Items.Add(employer2.Index);
                        searchProposalOrganizationNameCb.Items.Add(employer2.OrgName);
                    }
                    appSettingCoTxtbx.Focus();
                }
                else
                {
                    PopUp popUp = new PopUp("خطا", "نام سازمان را مشخص کنید.", "تایید", "", "", "error");
                    popUp.ShowDialog();
                    appSettingCoTxtbx.Focus();
                }
            }

            else if (appSettingStatusTxtbx.Enabled == true)
            {
                if (!appSettingStatusTxtbx.Text.Equals(""))
                {
                    dbh.EditStatusType(appSettingStatusTxtbx.Text, appSettingCurrentSelectedOption, loginUser.U_NCode, myDateTime.ToString());
                    appSettingStatusTxtbx.Clear();
                    dbh.dataGridViewUpdate2(appSettingShowDv, appSettingBindingSource, "SELECT statusType FROM statusTypeTable");
                    appSettingShowDv.Columns[0].HeaderText = "نوع وضعیت";

                    comboList = dbh.getStatusType();
                    addProposalStatusCb.Items.Clear();
                    editProposalStatusCb.Items.Clear();
                    searchProposalStatusCb.Items.Clear();


                    foreach (String Status in comboList)
                    {
                        addProposalStatusCb.Items.Add(Status);
                        editProposalStatusCb.Items.Add(Status);
                        searchProposalStatusCb.Items.Add(Status);
                    }

                    appSettingStatusTxtbx.Focus();
                }
                else
                {
                    PopUp popUp = new PopUp("خطا", "نوع وضعیت را مشخص کنید.", "تایید", "", "", "error");
                    popUp.ShowDialog();
                    appSettingStatusTxtbx.Focus();
                }
            }

            else if (appSettingEdegreeTxtbx.Enabled == true)
            {
                if (!appSettingEdegreeTxtbx.Text.Equals(""))
                {
                    dbh.EditEDegree(appSettingEdegreeTxtbx.Text, appSettingCurrentSelectedOption, loginUser.U_NCode, myDateTime.ToString());
                    appSettingEdegreeTxtbx.Clear();
                    dbh.dataGridViewUpdate2(appSettingShowDv, appSettingBindingSource, "SELECT * FROM EDegreeTable");
                    appSettingShowDv.Columns[0].HeaderText = "نوع وضعیت";

                    comboList = dbh.getEDeg();
                    addProposalExecutorEDegCb.Items.Clear();
                    editProposalExecutorEDegCb.Items.Clear();
                    manageTeacherExecutorEDegCb.Items.Clear();
                    //searchProposalEde.Items.Clear();


                    foreach (String ExecutorEDeg in comboList)
                    {
                        addProposalExecutorEDegCb.Items.Add(ExecutorEDeg);
                        editProposalExecutorEDegCb.Items.Add(ExecutorEDeg);
                        manageTeacherExecutorEDegCb.Items.Add(ExecutorEDeg);
                        //  searchProposalStatusCb.Items.Add(Status);
                    }
                    appSettingEdegreeTxtbx.Focus();
                }
                else
                {
                    PopUp popUp = new PopUp("خطا", "نوع وضعیت را مشخص کنید.", "تایید", "", "", "error");
                    popUp.ShowDialog();
                    appSettingEdegreeTxtbx.Focus();
                }
            }
            appSettingEditBtn.Enabled = false;
            appSettingDeleteBtn.Enabled = false;
        }

        private void appSettingShowDv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (appSettingProcedureTypeTxtbx.Enabled == true)
            {
                
                appSettingEditBtn.Enabled = true;
                appSettingDeleteBtn.Enabled = true;
                try
                {
                    appSettingCurrentSelectedOption = appSettingShowDv.Rows[e.RowIndex].Cells["procedureType"].Value.ToString();
                    appSettingProcedureTypeTxtbx.Text = appSettingCurrentSelectedOption;
                }
                catch (ArgumentOutOfRangeException) { }
            }

            else if (appSettingPropertyTxtbx.Enabled == true)
            {
                appSettingEditBtn.Enabled = true;
                appSettingDeleteBtn.Enabled = true;

                try
                {
                    appSettingCurrentSelectedOption = appSettingShowDv.Rows[e.RowIndex].Cells["propertyType"].Value.ToString();
                    appSettingPropertyTxtbx.Text = appSettingCurrentSelectedOption;
                }
                catch (ArgumentOutOfRangeException) { }
            }

            else if (appSettingFacultyTxtbx.Enabled == true)
            {
                appSettingEditBtn.Enabled = true;
                appSettingDeleteBtn.Enabled = true;

                try
                {
                    appSettingCurrentSelectedOption = appSettingShowDv.Rows[e.RowIndex].Cells["facultyName"].Value.ToString();
                    appSettingFacultyTxtbx.Text = appSettingCurrentSelectedOption;
                }
                catch (ArgumentOutOfRangeException) { }
               
            }

            else if (appSettingRegTypeTxtbx.Enabled == true)
            {
                appSettingEditBtn.Enabled = true;
                appSettingDeleteBtn.Enabled = true;

                try
                {
                    appSettingCurrentSelectedOption = appSettingShowDv.Rows[e.RowIndex].Cells["registerType"].Value.ToString();
                    appSettingRegTypeTxtbx.Text = appSettingCurrentSelectedOption;
                }
                catch (ArgumentOutOfRangeException) { }
            }

            else if (appSettingProTypeTxtbx.Enabled == true)
            {
                appSettingEditBtn.Enabled = true;
                appSettingDeleteBtn.Enabled = true;

                try
                {
                    appSettingCurrentSelectedOption = appSettingShowDv.Rows[e.RowIndex].Cells["proposalType"].Value.ToString();
                    appSettingProTypeTxtbx.Text = appSettingCurrentSelectedOption;
                }
                catch (ArgumentOutOfRangeException) { }
            }

            else if (appSettingEgroupTxtbx.Enabled == true)
            {
                appSettingEditBtn.Enabled = true;
                appSettingDeleteBtn.Enabled = true;

                try
                {
                    appSettingCurrentSelectedOption = appSettingShowDv.Rows[e.RowIndex].Cells["groupName"].Value.ToString();
                    appSettingEgroupTxtbx.Text = appSettingCurrentSelectedOption;
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
                    appSettingCurrentSelectedOption = appSettingShowDv.Rows[e.RowIndex].Cells["orgName"].Value.ToString();
                    appSettingCoTxtbx.Text = appSettingCurrentSelectedOption;
                }
                catch (ArgumentOutOfRangeException) { }
            }

            else if (appSettingStatusTxtbx.Enabled == true)
            {
                appSettingEditBtn.Enabled = true;
                appSettingDeleteBtn.Enabled = true;

                try
                {
                    appSettingCurrentSelectedOption = appSettingShowDv.Rows[e.RowIndex].Cells["statusType"].Value.ToString();
                    appSettingStatusTxtbx.Text = appSettingCurrentSelectedOption;
                }
                catch (ArgumentOutOfRangeException) { }
            }

            else if (appSettingEdegreeTxtbx.Enabled == true)
            {
                appSettingEditBtn.Enabled = true;
                appSettingDeleteBtn.Enabled = true;

                try
                {
                    appSettingCurrentSelectedOption = appSettingShowDv.Rows[e.RowIndex].Cells["EDegree"].Value.ToString();
                    appSettingEdegreeTxtbx.Text = appSettingCurrentSelectedOption;
                }
                catch (ArgumentOutOfRangeException) { }
            }

        }

        private void appSettingDeleteBtn_Click(object sender, EventArgs e)
        {
            PopUp p = new PopUp("حذف اطلاعات", "آیا از حذف گزینه مورد نظر مطمئن هستید؟", "بله", "خیر", "", "info");
            p.ShowDialog();
            if (p.DialogResult == DialogResult.Yes)
            {
                if (appSettingProcedureTypeTxtbx.Enabled == true)
                {
                    dbh.DeleteProcedureType(appSettingCurrentSelectedOption, loginUser.U_NCode, myDateTime.ToString());
                    appSettingProcedureTypeTxtbx.Clear();
                    dbh.dataGridViewUpdate2(appSettingShowDv, appSettingBindingSource, "SELECT procedureType FROM procedureTypeTable");
                    appSettingShowDv.Columns[0].HeaderText = "نوع کار";
                    appSettingEditBtn.Enabled = false;
                    appSettingDeleteBtn.Enabled = false;

                    form_initializer(); // To Reset items of comboBoxes and others
                    appSettingProcedureTypeTxtbx.Focus();
                }

                else if (appSettingPropertyTxtbx.Enabled == true)
                {
                    dbh.DeletePropertyType(appSettingCurrentSelectedOption, loginUser.U_NCode, myDateTime.ToString());
                    appSettingPropertyTxtbx.Clear();
                    dbh.dataGridViewUpdate2(appSettingShowDv, appSettingBindingSource, "SELECT propertyType FROM propertyTypeTable");
                    appSettingShowDv.Columns[0].HeaderText = "نوع خاصیت";
                    appSettingEditBtn.Enabled = false;
                    appSettingDeleteBtn.Enabled = false;

                    form_initializer(); // To Reset items of comboBoxes and others
                    appSettingPropertyTxtbx.Focus();
                }

                else if (appSettingFacultyTxtbx.Enabled == true)
                {
                    dbh.DeleteFaculty(appSettingCurrentSelectedOption, loginUser.U_NCode, myDateTime.ToString());
                    appSettingFacultyTxtbx.Clear();
                    dbh.dataGridViewUpdate2(appSettingShowDv, appSettingBindingSource, "SELECT facultyName FROM facultyTable");
                    appSettingShowDv.Columns[0].HeaderText = "نام دانشکده";
                    appSettingEditBtn.Enabled = false;
                    appSettingDeleteBtn.Enabled = false;

                    form_initializer(); // To Reset items of comboBoxes and others
                    appSettingFacultyTxtbx.Focus();
                }

                else if (appSettingRegTypeTxtbx.Enabled == true)
                {
                    dbh.DeleteRegisterType(appSettingCurrentSelectedOption, loginUser.U_NCode, myDateTime.ToString());
                    appSettingRegTypeTxtbx.Clear();
                    dbh.dataGridViewUpdate2(appSettingShowDv, appSettingBindingSource, "SELECT registerType FROM registerTypeTable");
                    appSettingShowDv.Columns[0].HeaderText = "نوع ثبت";
                    appSettingEditBtn.Enabled = false;
                    appSettingDeleteBtn.Enabled = false;

                    form_initializer(); // To Reset items of comboBoxes and others
                    appSettingRegTypeTxtbx.Focus();
                }

                else if (appSettingProTypeTxtbx.Enabled == true)
                {
                    dbh.DeleteProposalType(appSettingCurrentSelectedOption, loginUser.U_NCode, myDateTime.ToString());
                    appSettingProTypeTxtbx.Clear();
                    dbh.dataGridViewUpdate2(appSettingShowDv, appSettingBindingSource, "SELECT proposalType from proposalTypeTable");
                    appSettingShowDv.Columns[0].HeaderText = "نوع پروپوزال";
                    appSettingEditBtn.Enabled = false;
                    appSettingDeleteBtn.Enabled = false;

                    form_initializer(); // To Reset items of comboBoxes and others
                    appSettingProTypeTxtbx.Focus();
                }

                else if (appSettingEgroupTxtbx.Enabled == true)
                {
                    dbh.DeleteEGroup(appSettingCurrentSelectedOption, appSettingCurrentSelectedOption_2 /*faculty*/, loginUser.U_NCode, myDateTime.ToString());
                    appSettingEgroupTxtbx.Clear();
                    dbh.dataGridViewUpdate2(appSettingShowDv, appSettingBindingSource, "SELECT groupName FROM EGroupTable WHERE facultyName = '" + appSettingFacultyTxtbx.Text + "'");
                    appSettingShowDv.Columns[0].HeaderText = "گروه آموزشی";
                    appSettingEditBtn.Enabled = false;
                    appSettingDeleteBtn.Enabled = false;

                    form_initializer(); // To Reset items of comboBoxes and others
                    appSettingEgroupTxtbx.Focus();
                }

                else if (appSettingCoTxtbx.Enabled == true)
                {
                
                    dbh.DeleteEmployers(long.Parse(currentSelectedIndex), appSettingCurrentSelectedOption, loginUser.U_NCode, myDateTime.ToString());
                    appSettingCoTxtbx.Clear();
                    dbh.dataGridViewUpdate2(appSettingShowDv, appSettingBindingSource, "SELECT * FROM employersTable");
                    appSettingShowDv.Columns[0].HeaderText = "کد سازمان";
                    appSettingShowDv.Columns[1].HeaderText = "نام سازمان";
                    // appSettingShowDv.Columns[1].Visible = false;
                    appSettingEditBtn.Enabled = false;
                    appSettingDeleteBtn.Enabled = false;

                    form_initializer(); // To Reset items of comboBoxes and others
                    appSettingCoTxtbx.Focus();
                }

                else if (appSettingStatusTxtbx.Enabled == true)
                {
                    dbh.DeleteStatusType(appSettingCurrentSelectedOption, loginUser.U_NCode, myDateTime.ToString());
                    appSettingStatusTxtbx.Clear();
                    dbh.dataGridViewUpdate2(appSettingShowDv, appSettingBindingSource, "SELECT statusType FROM statusTypeTable");
                    appSettingShowDv.Columns[0].HeaderText = "نوع وضعیت";
                    appSettingEditBtn.Enabled = false;
                    appSettingDeleteBtn.Enabled = false;

                    form_initializer(); // To Reset items of comboBoxes and others
                    appSettingStatusTxtbx.Focus();
                }

                else if (appSettingEdegreeTxtbx.Enabled == true)
                {
                    dbh.DeleteEDegree(appSettingCurrentSelectedOption, loginUser.U_NCode, myDateTime.ToString());
                    appSettingEdegreeTxtbx.Clear();
                    dbh.dataGridViewUpdate2(appSettingShowDv, appSettingBindingSource, "SELECT * FROM EDegreeTable");
                    appSettingShowDv.Columns[0].HeaderText = "درجه علمی";
                    appSettingEditBtn.Enabled = false;
                    appSettingDeleteBtn.Enabled = false;

                    form_initializer(); // To Reset items of comboBoxes and others
                    appSettingEdegreeTxtbx.Focus();
                }

                appSettingEditBtn.Enabled = false;
                appSettingDeleteBtn.Enabled = false;
             }
        }

        private void appSettingShowDv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(appSettingFacultyTxtbx.Enabled == true)
            {
                appSettingEditBtn.Enabled = false;
                appSettingDeleteBtn.Enabled = false;

                appSettingBackBtn.Enabled = true;

                appSettingProcedureTypeRbtn.Enabled = false;
                appSettingPropertyRbtn.Enabled = false;
                appSettingFacultyRbtn.Enabled = false;
                appSettingRegTypeRbtn.Enabled = false;
                appSettingEdegreeRbtn.Enabled = false;
                appSettingProTypeRbtn.Enabled = false;
                appSettingCoRbtn.Enabled = false;
                appSettingStatusRbtn.Enabled = false;

                appSettingFacultyTxtbx.Enabled = false;
                appSettingFacultyTxtbx.Text = appSettingShowDv.Rows[e.RowIndex].Cells["facultyName"].Value.ToString();
                appSettingCurrentSelectedOption_2 = appSettingShowDv.Rows[e.RowIndex].Cells["facultyName"].Value.ToString();

                appSettingEgroupRbtn.Select();
                appSettingEgroupTxtbx.Enabled = true;
                appSettingEgroupTxtbx.Focus();

               // MessageBox.Show(appSettingShowDv.Rows[e.RowIndex].Cells["facultyName"].Value.ToString());
                dbh.dataGridViewUpdate2(appSettingShowDv, appSettingBindingSource, "SELECT groupName FROM EGroupTable WHERE facultyName ='" + appSettingShowDv.Rows[e.RowIndex].Cells["facultyName"].Value.ToString() + "'");
                appSettingShowDv.Columns[0].HeaderText = "گروه آموزشی";
            }
        }

        private void searchProposalClearBtn_Click(object sender, EventArgs e)
        {
            searchProposalIsWatchingEdition = false;
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


            searchProposalNavigationCurrentPageTxtbx.Clear();
            searchProposalNavigationFirstPageBtn.Enabled = false;
            searchProposalNavigationNextPageBtn.Enabled = false;
            searchProposalNavigationLastPageBtn.Enabled = false;
            searchProposalNavigationPreviousPageBtn.Enabled = false;
            searchProposalNavigationCurrentPageTxtbx.Enabled = false;
            searchProposalNavigationReturnBtn.Enabled = false;

            searchProposalShowDgv.Columns.Clear();
            searchProposalShowDgv.DataSource = null;
            searchProposalShowAllBtn.Enabled = true;
        }

        private void manageUserClearBtn_Click(object sender, EventArgs e)
        {
            manageUserFnameTxtbx.Clear();
            manageUserLnameTxtbx.Clear();
            manageUserNcodeTxtbx.Clear();
            manageUserNcodeTxtbx.BackColor = Color.White;
            manageUserPasswordTxtbx.Clear();
            manageUserEmailTxtbx.Clear();
            manageUserTelTxtbx.Clear();
            manageUserAddProCb.Checked = false;
            manageUserEditProCb.Checked = false;
            manageUserDeleteProCb.Checked = false;
            manageUserAddUserCb.Checked = false;
            manageUserEditUserCb.Checked = false;
            manageUserDeleteUserCb.Checked = false;
            manageUserManageTeacherCb.Checked = false;
            manageUserManageTypeCb.Checked = false;
            manageUserCheckAllCb.Checked = false;

            manageUserShowDgv.DataSource = null;
            manageUserShowAllBtn.Enabled = true;
            manageUserEditBtn.Enabled = false;
            manageUserDeleteBtn.Enabled = false;

            manageUserNavigationCurrentPageTxtbx.Clear();
            manageUserNavigationFirstPageBtn.Enabled = false;
            manageUserNavigationNextPageBtn.Enabled = false;
            manageUserNavigationLastPageBtn.Enabled = false;
            manageUserNavigationPreviousPageBtn.Enabled = false;
            manageUserNavigationCurrentPageTxtbx.Enabled = false;
            manageUserNavigationReturnBtn.Enabled = false;
        }

        private void editProposalClearBtn_Click(object sender, EventArgs e)
        {
            manageProposalIsWatchingEdition = false;

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
            editProposalFileLinkLbl.Text = "افزودن فایل";
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

            editProposalSearchBtn.Enabled = true;
            editProposalShowAllBtn.Enabled = true;
            editProposalRegisterBtn.Enabled = false;
            editProposalDeleteBtn.Enabled = false;
            editProposalShowDgv.Columns.Clear();
            editProposalShowDgv.DataSource = null;

            manageProposalNavigationCurrentPageTxtbx.Clear();
            manageProposalNavigationFirstPageBtn.Enabled = false;
            manageProposalNavigationNextPageBtn.Enabled = false;
            manageProposalNavigationLastPageBtn.Enabled = false;
            manageProposalNavigationPreviousPageBtn.Enabled = false;
            manageProposalNavigationCurrentPageTxtbx.Enabled = false;
            manageProposalNavigationReturnBtn.Enabled = false;
        }

        private void manageTeacherClearBtn_Click(object sender, EventArgs e)
        {

            //manageTeacherExecutorNcodeTxtbx.Enabled = true;
            manageTeacherExecutorNcodeTxtbx.Clear();
            manageTeacherFnameTxtbx.Clear();
            manageTeacherLnameTxtbx.Clear();
            manageTeacherExecutorEgroupCb.SelectedIndex = -1;
            manageTeacherExecutorEDegCb.SelectedIndex = -1;
            manageTeacherExecutorFacultyCb.SelectedIndex = -1;
            manageTeacherExecutorTelTxtbx.Clear();
            manageTeacherExecutorEmailTxtbx.Clear();
            manageTeacherExecutorMobileTxtbx.Clear();
            manageTeacherExecutorTel2Txtbx.Clear();
            manageTeacherShowDgv.DataSource = null;
            manageTeacherEditBtn.Enabled = false;
            manageTeacherDeleteBtn.Enabled = false;
            manageTeacherShowAllBtn.Enabled = true;
            manageTeacherSearchBtn.Enabled = true;


            manageTeacherNavigationCurrentPageTxtbx.Clear();
            manageTeacherNavigationFirstPageBtn.Enabled = false;
            manageTeacherNavigationNextPageBtn.Enabled = false;
            manageTeacherNavigationLastPageBtn.Enabled = false;
            manageTeacherNavigationPreviousPageBtn.Enabled = false;
            manageTeacherNavigationCurrentPageTxtbx.Enabled = false;
            manageTeacherNavigationReturnBtn.Enabled = false;
        }

        private void personalSettingClearBtn_Click(object sender, EventArgs e)
        {
            personalSettingOldPasswordTxtbx.Clear();
            personalSettingNewPasswordTxtbx.Clear();
            personalSettingRepeatPasswordTxtbx.Clear();
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
            appSettingEdegreeRbtn.Enabled = true;
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
                  //  MessageBox.Show("arg");
                    addProposalOrganizationNumberCb.Text = "";
                    addProposalOrganizationNumberCb.SelectedIndex = -1;
                    addProposalOrganizationNameCb.BackColor = Color.Pink;
                }
                catch (FormatException)
                {
                    //MessageBox.Show("for");
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
                   // MessageBox.Show("arg");
                    addProposalOrganizationNumberCb.Text = "";
                    addProposalOrganizationNumberCb.SelectedIndex = -1;
                    addProposalOrganizationNameCb.BackColor = Color.Pink;
                }
                catch (FormatException)
                {
                   // MessageBox.Show("for");
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
            //try
            //{
            //    long onlyDigit = long.Parse(addProposalValueTxtbx.Text);
            //}
            //catch (FormatException)
            //{
            //    addProposalValueTxtbx.BackColor = Color.Pink;
            //}
            //catch (OverflowException)
            //{
            //    addProposalValueTxtbx.BackColor = Color.Pink;
            //}
            if (addProposalValueTxtbx.Text == "")
            {
                addProposalValueTxtbx.BackColor = Color.White;
            }
            else
            {
                addProposalValueTxtbx.Text = string.Format("{0:n0}", double.Parse(addProposalValueTxtbx.Text.ToString()));
                addProposalValueTxtbx.SelectionStart = addProposalValueTxtbx.Text.Length;
                addProposalValueTxtbx.SelectionLength = 0;
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
            logDgv.Columns.Clear();
            TotalPage = dbh.totalLogPage("SELECT COUNT(*) FROM logTable");


            CurrentPageIndex = 1;
            logNavigationCurrentPageTxtbx.Text = CurrentPageIndex.ToString();
            dbh.logQuery = "SELECT TOP 30 * FROM logTable WHERE 1=1 ";
            dbh.dataGridViewUpdate3(logDgv, logBindingSource, dbh.logQuery, 30 , CurrentPageIndex);
          


            logNavigationFirstPageBtn.Enabled = true;
            logNavigationNextPageBtn.Enabled = true;
            logNavigationLastPageBtn.Enabled = true;
            logNavigationPreviousPageBtn.Enabled = true;
            logNavigationCurrentPageTxtbx.Enabled = true;
            logNavigationReturnBtn.Enabled = false;

           // dbh.dataGridViewUpdate2(logDgv, logBindingSource, "SELECT * FROM logTable");
        }

        private void searchProposalExecutorNCodeTxtbx_TextChanged(object sender, EventArgs e)
        {
            if (searchProposalExecutorNCodeTxtbx.Text.Length == 10)
            {
                Teachers teacher = new Teachers();

                try
                {
                    teacher = dbh.getExecutorInfo(long.Parse(searchProposalExecutorNCodeTxtbx.Text));

                    if (teacher.T_FName.ToString() != "notfound")
                    {
                        searchProposalExecutorNCodeTxtbx.BackColor = Color.LightGreen;

                        // Fill componenets with existing information
                        searchProposalExecutorFNameTxtbx.Text = teacher.T_FName;
                        searchProposalExecutorLNameTxtbx.Text = teacher.T_LName;
                        searchProposalExecutorFacultyCb.Text = teacher.T_Faculty;
                        searchProposalExecutorEGroupCb.Text = teacher.T_Group;
                        searchProposalExecutorMobileTxtbx.Text = teacher.T_Mobile;

                        //make components uneditable
                        searchProposalExecutorFNameTxtbx.Enabled = false;
                        searchProposalExecutorLNameTxtbx.Enabled = false;
                        searchProposalExecutorFacultyCb.Enabled = false;
                        searchProposalExecutorEGroupCb.Enabled = false;
                        searchProposalExecutorMobileTxtbx.Enabled = false;
                    }
                }
                catch(NullReferenceException)
                {
                    string context = "خطا در برقراری ارتباط با سرور";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                catch(Exception ex)
                {
                    string context = "با پشتیبانی تماس بگیرید";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                
            } 
            else
            {
                searchProposalExecutorNCodeTxtbx.BackColor = Color.White;

                searchProposalExecutorFNameTxtbx.Enabled = true;
                searchProposalExecutorLNameTxtbx.Enabled = true;
                searchProposalExecutorFacultyCb.Enabled = true;
                searchProposalExecutorEGroupCb.Enabled = true;
                searchProposalExecutorMobileTxtbx.Enabled = true;

                searchProposalExecutorFNameTxtbx.Clear();
                searchProposalExecutorLNameTxtbx.Clear();
                searchProposalExecutorFacultyCb.SelectedIndex = -1;
                searchProposalExecutorEGroupCb.SelectedIndex = -1;
                searchProposalExecutorMobileTxtbx.Clear();
            }
        }

        private void addProposalExecutorNcodeTxtbx_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (addProposalExecutorNcodeTxtbx.Text.Length == 10)
                {
                    addProposalExecutorNcodeTxtbx.BackColor = Color.LightGreen;

                    addProposalExecutorEDegCb.Items.Clear();
                    comboList = dbh.getEDeg();
                    foreach (String eDegree in comboList)
                    {
                        addProposalExecutorEDegCb.Items.Add(eDegree);
                    }

                    Teachers teacher = new Teachers();

                    teacher = dbh.getExecutorInfo(long.Parse(addProposalExecutorNcodeTxtbx.Text));

                    if (teacher.T_FName.ToString() != "notfound")
                    {
                        //Fill componenets with existing information
                        addProposalExecutorFNameTxtbx.Text = teacher.T_FName;
                        addProposalExecutorLNameTxtbx.Text = teacher.T_LName;
                        addProposalExecutorFacultyCb.Text = teacher.T_Faculty;

                        addProposalExecutorEGroupCb.Items.Clear();
                        if (addProposalExecutorFacultyCb.Text != "")
                        {
                            comboList = dbh.getEGroup(addProposalExecutorFacultyCb.SelectedItem.ToString());

                            foreach (String eGroup in comboList)
                            {
                                addProposalExecutorEGroupCb.Items.Add(eGroup);
                            }
                        }


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

                    if (addProposalExecutorFNameTxtbx.Text == "")
                    {
                        PopUp p = new PopUp("ثبت اطلاعات جدید", "استادی با کد ملی وارد شده در سیستم ثبت نشده است.", "ثبت اطلاعات استاد جدید", "تغییر کد ملی وارد شده", "", "info");
                        p.ShowDialog();
                        if (p.DialogResult == DialogResult.Yes)
                        {
                            ////
                            //addProposalSearchBtn.Enabled = true;
                            addProposalExecutorFNameTxtbx.Enabled = true;
                            addProposalExecutorLNameTxtbx.Enabled = true; ;
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
                            ////
                            addProposalExecutorFNameTxtbx.Focus();
                            isNewTeacher = true;
                        }

                        else
                        {
                            addProposalExecutorNcodeTxtbx.BackColor = Color.White;
                            addProposalExecutorNcodeTxtbx.Clear();
                        }
                    }

                }

                else
                {
                    addProposalExecutorNcodeTxtbx.BackColor = Color.White;

                    addProposalSearchBtn.Enabled = true;
                    addProposalExecutorFNameTxtbx.Enabled = true;
                    addProposalExecutorLNameTxtbx.Enabled = true; ;
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
            catch (NullReferenceException)
            {
                string context = "خطا در برقراری ارتباط با سرور";
                Alert alert = new Alert(context, "darkred", 5);
            }
            catch (Exception ex)
            {
                string context = "با پشتیبانی تماس بگیرید";
                Alert alert = new Alert(context, "darkred", 5);
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
                   // MessageBox.Show("arg");
                    searchProposalOrganizationNumberCb.Text = "";
                    searchProposalOrganizationNumberCb.SelectedIndex = -1;
                    searchProposalOrganizationNameCb.BackColor = Color.Pink;
                }
                catch (FormatException)
                {
                   // MessageBox.Show("for");
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
                  //  MessageBox.Show("arg");
                    searchProposalOrganizationNumberCb.Text = "";
                    searchProposalOrganizationNumberCb.SelectedIndex = -1;
                    searchProposalOrganizationNameCb.BackColor = Color.Pink;
                }
                catch (FormatException)
                {
                   // MessageBox.Show("for");
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
            if (manageUserNcodeTxtbx.Text.Length < 10)
            {
                //PopUp p = new PopUp("خطا", "کد ملی ده رقمی را به طور کامل وارد نمایید.", "تایید", "", "", "error");
                //p.ShowDialog();
                string context = "کد ملی ده رقمی را به طور کامل وارد نمایید";
                Alert alert = new Alert(context, "darkred", 5);
                manageUserNcodeTxtbx.Focus();
            }
            else if (manageUserFnameTxtbx.Text == "")
            {
                //PopUp p = new PopUp("خطا", "نام را وارد نمایید.", "تایید", "", "", "error");
                //p.ShowDialog();
                string context = "نام را وارد نمایید";
                Alert alert = new Alert(context, "bluegray", 5);
                manageUserFnameTxtbx.Focus();
            }

            else if (manageUserLnameTxtbx.Text == "")
            {
                //PopUp p = new PopUp("خطا", "نام خانوادگی را وارد نمایید.", "تایید", "", "", "error");
                //p.ShowDialog();
                string context = "نام خانوادگی را وارد نمایید";
                Alert alert = new Alert(context, "bluegray", 5);
                manageUserLnameTxtbx.Focus();
            }

            else if (manageUserPasswordTxtbx.Text == "")
            {
                //PopUp p = new PopUp("خطا", "رمز عبور را وارد نمایید.", "تایید", "", "", "error");
                //p.ShowDialog();
                string context = "رمز عبور را وارد نمایید";
                Alert alert = new Alert(context, "bluegray", 5);
                manageUserPasswordTxtbx.Focus();
            }

            else if (manageUserAddProCb.Checked == false && manageUserEditProCb.Checked == false && manageUserDeleteProCb.Checked == false &&
                     manageUserAddUserCb.Checked == false && manageUserEditUserCb.Checked == false && manageUserDeleteUserCb.Checked == false &&
                     manageUserManageTeacherCb.Checked == false && manageUserManageTypeCb.Checked == false && manageUserReadOnlyCb.Checked == false)
            {
                //PopUp p = new PopUp("خطا", "داشتن حداقل یک سطح دسترسی الزامی است.", "تایید", "", "", "error");
                //p.ShowDialog();
                string context = "داشتن حداقل یک سطح دسترسی الزامی است";
                Alert alert = new Alert(context, "darkred", 5);
            }

            else
            {
                User user = new User();
                user.U_FName = manageUserFnameTxtbx.Text;
                user.U_LName = manageUserLnameTxtbx.Text;
                user.U_NCode = long.Parse(manageUserNcodeTxtbx.Text);
                user.U_Email = manageUserEmailTxtbx.Text;
                user.U_Tel = manageUserTelTxtbx.Text;
                user.U_Password = dbh.hashPass(manageUserPasswordTxtbx.Text);

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


                if (manageUserManageTeacherCb.Checked == true)
                {
                    user.CanManageTeacher = 1;
                }
                else
                {
                    user.CanManageTeacher = 0;
                }


                if (manageUserManageTypeCb.Checked == true)
                {
                    user.CanManageType = 1;
                }
                else
                {
                    user.CanManageType = 0;
                }

                if (manageUserReadOnlyCb.Checked == true)
                {
                    user.U_otherAccess = 1; // ReadOnlyUser
                }
                else
                {
                    user.U_otherAccess = 0;
                }

                if (loginUser.U_NCode == 999999999)
                {
                    if (manageUserIsAdminCb.Checked == true)
                    {
                        user.U_IsAdmin = 1;
                    }
                    else
                    {
                        user.U_IsAdmin = 0;
                    }
                }

                dbh.AddUser(user, loginUser.U_NCode, myDateTime.ToString());
                manageUserClearBtn.PerformClick();
                dbh.dataGridViewUpdate2(manageUserShowDgv, usersBindingSource, "SELECT * FROM UsersTable WHERE u_NCode > 999999999");

            }
        }

        private void manageUserEditBtn_Click(object sender, EventArgs e)
        {
            if (manageUserNcodeTxtbx.Text.Length < 10)
            {
                //PopUp p = new PopUp("خطا", "کد ملی ده رقمی را به طور کامل وارد نمایید.", "تایید", "", "", "error");
                //p.ShowDialog();
                string context = "کد ملی ده رقمی را به طور کامل وارد نمایید";
                Alert alert = new Alert(context, "darkred", 5);
                manageUserNcodeTxtbx.Focus();
            }
            else if (manageUserFnameTxtbx.Text == "")
            {
                //PopUp p = new PopUp("خطا", "نام را وارد نمایید.", "تایید", "", "", "error");
                //p.ShowDialog();
                string context = "نام را وارد نمایید";
                Alert alert = new Alert(context, "bluegray", 5);
                manageUserFnameTxtbx.Focus();
            }

            else if (manageUserLnameTxtbx.Text == "")
            {
                //PopUp p = new PopUp("خطا", "نام خانوادگی را وارد نمایید.", "تایید", "", "", "error");
                //p.ShowDialog();
                string context = "نام خانوادگی را وارد نمایید";
                Alert alert = new Alert(context, "bluegray", 5);
                manageUserLnameTxtbx.Focus();
            }

            else if (manageUserPasswordTxtbx.Text == "")
            {
                //PopUp p = new PopUp("خطا", "رمز عبور را وارد نمایید.", "تایید", "", "", "error");
                //p.ShowDialog();
                string context = "رمز عبور را وارد نمایید";
                Alert alert = new Alert(context, "bluegray", 5);
                manageUserPasswordTxtbx.Focus();
            }

            else if (manageUserAddProCb.Checked == false && manageUserEditProCb.Checked == false && manageUserDeleteProCb.Checked == false &&
                     manageUserAddUserCb.Checked == false && manageUserEditUserCb.Checked == false && manageUserDeleteUserCb.Checked == false &&
                     manageUserManageTeacherCb.Checked == false && manageUserManageTypeCb.Checked == false && manageUserReadOnlyCb.Checked == false)
            {
                //PopUp p = new PopUp("خطا", "داشتن حداقل یک سطح دسترسی الزامی است.", "تایید", "", "", "error");
                //p.ShowDialog();
                string context = "داشتن حداقل یک سطح دسترسی الزامی است";
                Alert alert = new Alert(context, "bluegray", 5);
            }

            else
            {
                User user = new User();
                user.U_FName = manageUserFnameTxtbx.Text;
                user.U_LName = manageUserLnameTxtbx.Text;
                user.U_NCode = long.Parse(manageUserNcodeTxtbx.Text);
                user.U_Email = manageUserEmailTxtbx.Text;
                user.U_Tel = manageUserTelTxtbx.Text;

                if (manageUserCurrentSelectedPassword != manageUserPasswordTxtbx.Text)
                {
                    user.U_Password = dbh.hashPass(manageUserPasswordTxtbx.Text);
                }
                else
                {
                    user.U_Password = manageUserPasswordTxtbx.Text;
                }

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
                if (manageUserManageTypeCb.Checked == true)
                {
                    user.CanManageType = 1;
                }
                else
                {
                    user.CanManageType = 0;
                }
                if (manageUserManageTeacherCb.Checked == true)
                {
                    user.CanManageTeacher = 1;
                }
                else
                {
                    user.CanManageTeacher = 0;
                }

                if (manageUserReadOnlyCb.Checked == true)
                {
                    user.U_otherAccess = 1; // ReadOnlyUser
                }
                else
                {
                    user.U_otherAccess = 0;
                }

                if (loginUser.U_NCode == 999999999)
                {
                    if (manageUserIsAdminCb.Checked == true)
                    {
                        user.U_IsAdmin = 1;
                    }
                    else
                    {
                        user.U_IsAdmin = 0;
                    }
                }

                if (user.U_IsAdmin == 1 && loginUser.U_IsAdmin == 0)
                {
                    string context = "اطلاعات کاربر ادمین تنها توسط خود کاربر ادمین قابل تغییر می باشد";
                    Alert alert = new Alert(context, "darkred", 5);
                }

                else
                {
                    dbh.EditUsers(user, long.Parse(manageUserCurrentSelectedOption), loginUser.U_NCode, myDateTime.ToString());
                    dbh.dataGridViewUpdate2(manageUserShowDgv, usersBindingSource, "SELECT * FROM UsersTable WHERE u_NCode > 999999999");

                    manageUserClearBtn.PerformClick();
                    manageUserShowAllBtn.PerformClick();
                }

            }
        }

        private void manageUserDeleteBtn_Click(object sender, EventArgs e)
        {
            PopUp p = new PopUp("حذف اطلاعات کاربران", "آیا از حذف اطلاعات کاربر مطمئن هستید؟", "بله", "خیر", "", "info");
            p.ShowDialog();
            if (p.DialogResult == DialogResult.Yes)
            {
                User user = new User();

                user.U_NCode = long.Parse(manageUserCurrentSelectedOption);
                user.U_FName = manageUserFnameTxtbx.Text;
                user.U_LName = manageUserLnameTxtbx.Text;
                user.U_Email = manageUserEmailTxtbx.Text;
                user.U_Tel = manageUserTelTxtbx.Text;
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

                if (manageUserIsAdminCb.Checked == true)
                {
                    user.U_IsAdmin = 1;
                }
                else
                {
                    user.U_IsAdmin = 0;
                }

                if (manageUserReadOnlyCb.Checked == true)
                {
                    user.U_otherAccess = 1; // ReadOnlyUser
                }
                else
                {
                    user.U_otherAccess = 0;
                }

                if (user.U_IsAdmin == 1 && loginUser.U_NCode != 999999999 && user.U_NCode != loginUser.U_NCode)
                {
                    string context = "کاربر مورد نظر ادمین بوده و غیر قابل حذف می باشد";
                    Alert alert = new Alert(context, "darkred", 5);
                }

                else if (user.U_NCode == loginUser.U_NCode)
                {
                    string context = "شما توانایی حذف اطلاعات پروفایل خود را ندارید";
                    Alert alert = new Alert(context, "darkred", 5);
                }

                else
                {
                    dbh.DeleteUser(user, loginUser.U_NCode, myDateTime.ToString());
                    dbh.dataGridViewUpdate2(manageUserShowDgv, usersBindingSource, "SELECT * FROM UsersTable WHERE u_NCode > 999999999");
                    manageUserClearBtn.PerformClick();
                    manageUserShowAllBtn.PerformClick();
                }

            }
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
            if (e.KeyChar == (char)13)
            {
                addProposalSearchBtn.PerformClick();
            }
        }

        private void editProposalExecutorNcodeTxtbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void searchProposalExecutorNCodeTxtbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
            if (e.KeyChar == (char)13)
            {
                searchProposalSearchBtn.PerformClick();
            }
        }

        private void searchProposalValueFromTxtbx_TextChanged_1(object sender, EventArgs e)
        {
            //try
            //{
            //    long onlyDigit = long.Parse(addProposalValueTxtbx.Text);
            //}
            //catch (FormatException)
            //{
            //    addProposalValueTxtbx.BackColor = Color.Pink;
            //}
            //catch (OverflowException)
            //{
            //    addProposalValueTxtbx.BackColor = Color.Pink;
            //}
            if (searchProposalValueFromTxtbx.Text == "")
            {
                searchProposalValueFromTxtbx.BackColor = Color.White;
            }
            else
            {
                searchProposalValueFromTxtbx.Text = string.Format("{0:n0}", double.Parse(searchProposalValueFromTxtbx.Text.ToString()));
                searchProposalValueFromTxtbx.SelectionStart = searchProposalValueFromTxtbx.Text.Length;
                searchProposalValueFromTxtbx.SelectionLength = 0;
            }
        }

        private void searchProposalValueToTxtbx_TextChanged_1(object sender, EventArgs e)
        {
            //try
            //{
            //    long onlyDigit = long.Parse(addProposalValueTxtbx.Text);
            //}
            //catch (FormatException)
            //{
            //    addProposalValueTxtbx.BackColor = Color.Pink;
            //}
            //catch (OverflowException)
            //{
            //    addProposalValueTxtbx.BackColor = Color.Pink;
            //}
            if (searchProposalValueToTxtbx.Text == "")
            {
                searchProposalValueToTxtbx.BackColor = Color.White;
            }
            else
            {
                searchProposalValueToTxtbx.Text = string.Format("{0:n0}", double.Parse(searchProposalValueToTxtbx.Text.ToString()));
                searchProposalValueToTxtbx.SelectionStart = searchProposalValueToTxtbx.Text.Length;
                searchProposalValueToTxtbx.SelectionLength = 0;
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
            if (manageUserNcodeTxtbx.Text.Length == 10)
            {
                manageUserNcodeTxtbx.BackColor = Color.LightGreen;
            }
            else
            {
                manageUserNcodeTxtbx.BackColor = Color.White;
            }
        }

        private void manageUserNcodTxtbx_Leave(object sender, EventArgs e)
        {
            if (manageUserNcodeTxtbx.Text.Length < 10)
            {
                manageUserNcodeTxtbx.BackColor = Color.Pink;
            }
        }

        private void editProposalExecutorNcodeTxtbx_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
            if (e.KeyChar == (char)13)
            {
                editProposalSearchBtn.PerformClick();
            }
        }

        private void editProposalExecutorNcodeTxtbx_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (editProposalExecutorNcodeTxtbx.Text.Length == 10)
                {
                    editProposalExecutorNcodeTxtbx.BackColor = Color.LightGreen;
                    editProposalExecutorEDegCb.Items.Clear();
                    comboList = dbh.getEDeg();
                    foreach (String eDegree in comboList)
                    {
                        editProposalExecutorEDegCb.Items.Add(eDegree);
                    }

                    Teachers teacher = new Teachers();

                    teacher = dbh.getExecutorInfo(long.Parse(editProposalExecutorNcodeTxtbx.Text));

                    if (teacher.T_FName.ToString() != "notfound")
                    {
                        //Fill componenets with existing information
                        editProposalExecutorFNameTxtbx.Text = teacher.T_FName;
                        editProposalExecutorLNameTxtbx.Text = teacher.T_LName;
                        editProposalExecutorFacultyCb.Text = teacher.T_Faculty;

                        editProposalExecutorEGroupCb.Items.Clear();
                        comboList = dbh.getEGroup(editProposalExecutorFacultyCb.SelectedItem.ToString());
                        foreach (String eGroup in comboList)
                        {
                            editProposalExecutorEGroupCb.Items.Add(eGroup);
                        }


                        editProposalExecutorEGroupCb.Text = teacher.T_Group;
                        editProposalExecutorEDegCb.Text = teacher.T_EDeg;
                        editProposalExecutorEmailTxtbx.Text = teacher.T_Email;
                        editProposalExecutorMobileTxtbx.Text = teacher.T_Mobile;
                        editProposalExecutorTel1Txtbx.Text = teacher.T_Tel1;
                        editProposalExecutorTel2Txtbx.Text = teacher.T_Tel2;

                        //make components uneditable
                        editProposalExecutorFNameTxtbx.Enabled = false;
                        editProposalExecutorLNameTxtbx.Enabled = false;
                        editProposalExecutorFacultyCb.Enabled = false;
                        editProposalExecutorEGroupCb.Enabled = false;
                        editProposalExecutorEDegCb.Enabled = false;
                        editProposalExecutorEmailTxtbx.Enabled = false;
                        editProposalExecutorMobileTxtbx.Enabled = false;
                        editProposalExecutorTel1Txtbx.Enabled = false;
                        editProposalExecutorTel2Txtbx.Enabled = false;
                    }
                }

                else
                {
                    editProposalExecutorNcodeTxtbx.BackColor = Color.White;
                }
            }
            catch (NullReferenceException)
            {
                string context = "خطا در برقراری ارتباط با سرور";
                Alert alert = new Alert(context, "darkred", 5);
            }
            catch (Exception ex)
            {
                string context = "با پشتیبانی تماس بگیرید";
                Alert alert = new Alert(context, "darkred", 5);
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
            //try
            //{
            //    long onlyDigit = long.Parse(addProposalValueTxtbx.Text);
            //}
            //catch (FormatException)
            //{
            //    addProposalValueTxtbx.BackColor = Color.Pink;
            //}
            //catch (OverflowException)
            //{
            //    addProposalValueTxtbx.BackColor = Color.Pink;
            //}
            if (editProposalValueTxtbx.Text == "")
            {
                editProposalValueTxtbx.BackColor = Color.White;
            }
            else
            {
                editProposalValueTxtbx.Text = string.Format("{0:n0}", double.Parse(editProposalValueTxtbx.Text.ToString()));
                editProposalValueTxtbx.SelectionStart = editProposalValueTxtbx.Text.Length;
                editProposalValueTxtbx.SelectionLength = 0;
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
                 //   MessageBox.Show("arg");
                    editProposalOrganizationNumberCb.Text = "";
                    editProposalOrganizationNumberCb.SelectedIndex = -1;
                    editProposalOrganizationNameCb.BackColor = Color.Pink;
                }
                catch (FormatException)
                {
                   // MessageBox.Show("for");
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
                   // MessageBox.Show("arg");
                    editProposalOrganizationNumberCb.Text = "";
                    editProposalOrganizationNumberCb.SelectedIndex = -1;
                    editProposalOrganizationNameCb.BackColor = Color.Pink;
                }
                catch (FormatException)
                {
                  //  MessageBox.Show("for");
                    editProposalOrganizationNumberCb.Text = "";
                    editProposalOrganizationNumberCb.SelectedIndex = -1;
                    editProposalOrganizationNameCb.BackColor = Color.Pink;
                }

                if (editProposalOrganizationNameCb.Text == "")
                {
                   // MessageBox.Show("null");
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


        private void manageUserShowBtn_Click(object sender, EventArgs e)
        {
            dbh.dataGridViewUpdate2(manageUserShowDgv, usersBindingSource, "SELECT * FROM UsersTable WHERE u_NCode > 999999999");
            manageUserShowAllBtn.Enabled = false;
        }

        private void appSettingBackgroundColorLbl_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Color c = new Color();
                c = dlg.Color;
                string myColor = "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
                //MessageBox.Show(myColor);
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
                iconMenuPanel.BackColor = dlg.Color;
            }
        }

        private void wait_bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            w.ShowDialog();
        }

        private void manageTeacherAddBtn_Click(object sender, EventArgs e)
        {
            Teachers teacher = new Teachers();
            if (manageTeacherExecutorNcodeTxtbx.Text.Length < 10)
            {
                //PopUp p = new PopUp("خطای ورودی", "شماره ملی ده رقمی را به طور صحیح وارد نمایید.", "تایید", "", "", "error");
                //p.ShowDialog();

                string context = "شماره ملی ده رقمی را به طور صحیح وارد نمایید";
                Alert alert = new Alert(context, "darkred", 5);
                manageTeacherExecutorNcodeTxtbx.Focus();
            }

            else if (manageTeacherFnameTxtbx.Text.Length == 0)
            {
                //PopUp p = new PopUp("خطای ورودی", "نام را وارد نمایید.", "تایید", "", "", "error");
                //p.ShowDialog();
                string context = "نام را وارد نمایید";
                Alert alert = new Alert(context, "bluegray", 5);
                manageTeacherFnameTxtbx.Focus();
            }

            else if (manageTeacherLnameTxtbx.Text.Length == 0)
            {
                //PopUp p = new PopUp("خطای ورودی", "نام خانوادگی را وارد نمایید.", "تایید", "", "", "error");
                //p.ShowDialog();
                string context = "نام خانوادگی را وارد نمایید";
                Alert alert = new Alert(context, "bluegray", 5);
                manageTeacherLnameTxtbx.Focus();
            }

            else if (manageTeacherExecutorFacultyCb.SelectedIndex == -1)
            {
                //PopUp p = new PopUp("خطای ورودی", "دانشکده را انتخاب نمایید.", "تایید", "", "", "error");
                //p.ShowDialog();

                string context = "دانشکده را انتخاب نمایید";
                Alert alert = new Alert(context, "bluegray", 5);
                manageTeacherExecutorFacultyCb.Focus();
            }

            else if (manageTeacherExecutorEgroupCb.SelectedIndex == -1)
            {
                //PopUp p = new PopUp("خطای ورودی", "گروه آموزشی را انتخاب نمایید.", "تایید", "", "", "error");
                //p.ShowDialog();
                string context = "گروه آموزشی را انتخاب نمایید";
                Alert alert = new Alert(context, "bluegray", 5);
                manageTeacherExecutorEgroupCb.Focus();
            }

            else if (manageTeacherExecutorEDegCb.SelectedIndex == -1)
            {
                //PopUp p = new PopUp("خطای ورودی", "درجه علمی را انتخاب نمایید.", "تایید", "", "", "error");
                //p.ShowDialog();
                string context = "درجه علمی را انتخاب نمایید";
                Alert alert = new Alert(context, "bluegray", 5);
                manageTeacherExecutorEDegCb.Focus();
            }

            else if (manageTeacherExecutorEmailTxtbx.Text.Length == 0)
            {
                //PopUp p = new PopUp("خطای ورودی", "آدرس ایمیل را وارد نمایید.", "تایید", "", "", "error");
                //p.ShowDialog();
                string context = "آدرس ایمیل را وارد نمایید";
                Alert alert = new Alert(context, "bluegray", 5);
                manageTeacherExecutorEmailTxtbx.Focus();
            }

            else if (manageTeacherExecutorEmailTxtbx.BackColor == Color.Pink)
            {
                //PopUp p = new PopUp("خطای ورودی", "آدرس ایمیل وارد شده صحیح نیست.", "تایید", "", "", "error");
                //p.ShowDialog();
                string context = "آدرس ایمیل وارد شده صحیح نیست";
                Alert alert = new Alert(context, "darkred", 5);
                manageTeacherExecutorEmailTxtbx.Focus();
            }

            else if (manageTeacherExecutorMobileTxtbx.Text.Length == 0)
            {
                //PopUp p = new PopUp("خطای ورودی", "شماره موبایل را وارد نمایید.", "تایید", "", "", "error");
                //p.ShowDialog();
                string context = "شماره موبایل را وارد نمایید";
                Alert alert = new Alert(context, "bluegray", 5);
                manageTeacherExecutorMobileTxtbx.Focus();
            }
            else
            {



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


                dbh.AddTeacher(teacher, loginUser.U_NCode, myDateTime.ToString());

                dbh.dataGridViewUpdate2(manageTeacherShowDgv, teacherBindingSource, "SELECT * FROM TeacherTable WHERE t_NCode = '" + manageTeacherExecutorNcodeTxtbx.Text + "'");
            }
        }

        private void manageTeacherDeleteBtn_Click(object sender, EventArgs e)
        {
            PopUp p = new PopUp("حذف اطلاعات استاد", "آیا از حذف اطلاعات استاد مطمئن هستید؟", "بله", "خیر", "", "info");
            p.ShowDialog();
            if (p.DialogResult == DialogResult.Yes)
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

                dbh.DeleteTeacher(teacher,long.Parse(manageTeacherCurrentSelectedOption), loginUser.U_NCode, myDateTime.ToString());


                manageTeacherClearBtn.PerformClick();
                manageTeacherShowAllBtn.PerformClick();
                manageTeacherShowAllBtn.Enabled = false;
            }
        }

        private void manageTeacherEditBtn_Click(object sender, EventArgs e)
        {
            Teachers teacher = new Teachers();

            if (manageTeacherExecutorNcodeTxtbx.Text.Length < 10)
            {
                //PopUp p = new PopUp("خطای ورودی", "شماره ملی ده رقمی را به طور صحیح وارد نمایید.", "تایید", "", "", "error");
                //p.ShowDialog();

                string context = "شماره ملی ده رقمی را به طور صحیح وارد نمایید";
                Alert alert = new Alert(context, "darkred", 5);
                manageTeacherExecutorNcodeTxtbx.Focus();
            }

            else if (manageTeacherFnameTxtbx.Text.Length == 0)
            {
                //PopUp p = new PopUp("خطای ورودی", "نام را وارد نمایید.", "تایید", "", "", "error");
                //p.ShowDialog();
                string context = "نام را وارد نمایید";
                Alert alert = new Alert(context, "bluegray", 5);
                manageTeacherFnameTxtbx.Focus();
            }

            else if (manageTeacherLnameTxtbx.Text.Length == 0)
            {
                //PopUp p = new PopUp("خطای ورودی", "نام خانوادگی را وارد نمایید.", "تایید", "", "", "error");
                //p.ShowDialog();
                string context = "نام خانوادگی را وارد نمایید";
                Alert alert = new Alert(context, "bluegray", 5);
                manageTeacherLnameTxtbx.Focus();
            }

            else if (manageTeacherExecutorFacultyCb.SelectedIndex == -1)
            {
                //PopUp p = new PopUp("خطای ورودی", "دانشکده را انتخاب نمایید.", "تایید", "", "", "error");
                //p.ShowDialog();

                string context = "دانشکده را انتخاب نمایید";
                Alert alert = new Alert(context, "bluegray", 5);
                manageTeacherExecutorFacultyCb.Focus();
            }

            else if (manageTeacherExecutorEgroupCb.SelectedIndex == -1)
            {
                //PopUp p = new PopUp("خطای ورودی", "گروه آموزشی را انتخاب نمایید.", "تایید", "", "", "error");
                //p.ShowDialog();
                string context = "گروه آموزشی را انتخاب نمایید";
                Alert alert = new Alert(context, "bluegray", 5);
                manageTeacherExecutorEgroupCb.Focus();
            }

            else if (manageTeacherExecutorEDegCb.SelectedIndex == -1)
            {
                //PopUp p = new PopUp("خطای ورودی", "درجه علمی را انتخاب نمایید.", "تایید", "", "", "error");
                //p.ShowDialog();
                string context = "درجه علمی را انتخاب نمایید";
                Alert alert = new Alert(context, "bluegray", 5);
                manageTeacherExecutorEDegCb.Focus();
            }

            else if (manageTeacherExecutorEmailTxtbx.Text.Length == 0)
            {
                //PopUp p = new PopUp("خطای ورودی", "آدرس ایمیل را وارد نمایید.", "تایید", "", "", "error");
                //p.ShowDialog();
                string context = "آدرس ایمیل را وارد نمایید";
                Alert alert = new Alert(context, "bluegray", 5);
                manageTeacherExecutorEmailTxtbx.Focus();
            }

            else if (manageTeacherExecutorEmailTxtbx.BackColor == Color.Pink)
            {
                //PopUp p = new PopUp("خطای ورودی", "آدرس ایمیل وارد شده صحیح نیست.", "تایید", "", "", "error");
                //p.ShowDialog();
                string context = "آدرس ایمیل وارد شده صحیح نیست";
                Alert alert = new Alert(context, "darkred", 5);
                manageTeacherExecutorEmailTxtbx.Focus();
            }

            else if (manageTeacherExecutorMobileTxtbx.Text.Length == 0)
            {
                //PopUp p = new PopUp("خطای ورودی", "شماره موبایل را وارد نمایید.", "تایید", "", "", "error");
                //p.ShowDialog();
                string context = "شماره موبایل را وارد نمایید";
                Alert alert = new Alert(context, "bluegray", 5);
                manageTeacherExecutorMobileTxtbx.Focus();
            }
            else
            {

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

                dbh.EditTeacher(teacher, long.Parse(manageTeacherCurrentSelectedOption), loginUser.U_NCode, myDateTime.ToString());


                manageTeacherClearBtn.PerformClick();
                manageTeacherShowAllBtn.PerformClick();
                manageTeacherShowAllBtn.Enabled = false;
            }
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
                manageTeacherCurrentSelectedOption = manageTeacherShowDgv.Rows[e.RowIndex].Cells["t_NCode"].Value.ToString();

               // manageTeacherExecutorNcodeTxtbx.Enabled = false;
               if(loginUser.CanManageTeacher == 1)
               {
                    manageTeacherEditBtn.Enabled = true;
                    manageTeacherDeleteBtn.Enabled = true;
               } 
            }
            catch (ArgumentOutOfRangeException) { }
        }

        private void addProposalShowBtn_Click(object sender, EventArgs e)
        {

            addProposalShowDgv.Columns.Clear();
            addProposalShowDgv.DataSource = null;
            if(addProposalIsWatchingEdition)
            {
                addProposalClearBtn.PerformClick();
            }
            TotalPage =  dbh.totalPage("SELECT COUNT(*) FROM proposalTable");
            

            CurrentPageIndex = 1;
            addProposalNavigationCurrentPageTxtbx.Text = CurrentPageIndex.ToString();
            dbh.addProposalQuery = "SELECT TOP "+pageSize+" * FROM proposalTable WHERE 1=1 ";
            dbh.dataGridViewUpdate3(addProposalShowDgv, addProposalBindingSource, dbh.addProposalQuery, pageSize,CurrentPageIndex);
            addProposalExecutorNcodeTxtbx.BackColor = Color.White;
            addProposalExecutorNcodeTxtbx.Focus();

            //foreach (DataGridViewRow row in addProposalShowDgv.Rows)
            //{
            //    string fullName;
            //    fullName = dbh.getExecutorName(long.Parse(row.Cells["executor"].Value.ToString()));
            //    row.Cells["executorFullName"].Value = fullName;
            //}
            //foreach (DataGridViewRow row in addProposalShowDgv.Rows)
            //{
            //    string fullName;
            //    fullName = dbh.getEmployerName(long.Parse(row.Cells["employer"].Value.ToString()));
            //    row.Cells["employerName"].Value = fullName;
            //}
            //foreach (DataGridViewRow row in addProposalShowDgv.Rows)
            //{
            //    string fullName;
            //    fullName = dbh.getDateHijri(row.Cells["startDate"].Value.ToString());
            //    row.Cells["hijriDate"].Value = fullName;
            //}

            addProposalNavigationFirstPageBtn.Enabled = true;
            addProposalNavigationNextPageBtn.Enabled = true;
            addProposalNavigationLastPageBtn.Enabled = true;
            addProposalNavigationPreviousPageBtn.Enabled = true;
            addProposalNavigationCurrentPageTxtbx.Enabled = true;
            addProposalNavigationReturnBtn.Enabled = false;
            //  addProposalShowAllBtn.Enabled = false;

        }

        private void addProposalNavigationNextPageBtn_Click(object sender, EventArgs e)
        {
            if (CurrentPageIndex < TotalPage)
            {
                addProposalShowDgv.Columns.Clear();
                CurrentPageIndex++;
                addProposalNavigationCurrentPageTxtbx.Text = CurrentPageIndex.ToString();
                dbh.dataGridViewUpdate3(addProposalShowDgv, addProposalBindingSource, dbh.addProposalQuery, pageSize, CurrentPageIndex);
                addProposalExecutorNcodeTxtbx.BackColor = Color.White;
                addProposalExecutorNcodeTxtbx.Focus();

               // addProposalShowAllBtn.Enabled = false;
            }
        }
        private void addProposalNavigationPreviousPageBtn_Click(object sender, EventArgs e)
        {
            if (CurrentPageIndex > 1)
            {
                addProposalShowDgv.Columns.Clear();
                CurrentPageIndex--;
                addProposalNavigationCurrentPageTxtbx.Text = CurrentPageIndex.ToString();
                dbh.dataGridViewUpdate3(addProposalShowDgv, addProposalBindingSource, dbh.addProposalQuery, pageSize, CurrentPageIndex);
                addProposalExecutorNcodeTxtbx.BackColor = Color.White;
                addProposalExecutorNcodeTxtbx.Focus();

                addProposalShowAllBtn.Enabled = false;
            }
        }

        private void addProposalNavigationCurrentPageTxtbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    if (int.Parse(addProposalNavigationCurrentPageTxtbx.Text) >= 1 && int.Parse(addProposalNavigationCurrentPageTxtbx.Text) <= TotalPage)
                    {
                        addProposalShowDgv.Columns.Clear();
                        CurrentPageIndex = int.Parse(addProposalNavigationCurrentPageTxtbx.Text);
                        addProposalNavigationCurrentPageTxtbx.Text = CurrentPageIndex.ToString();
                        dbh.dataGridViewUpdate3(addProposalShowDgv, addProposalBindingSource, dbh.addProposalQuery, pageSize, CurrentPageIndex);
                        addProposalExecutorNcodeTxtbx.BackColor = Color.White;
                        addProposalExecutorNcodeTxtbx.Focus();

                        addProposalShowAllBtn.Enabled = false;
                    }
                    else
                    {
                        string context = "شماره صفحه بیشتر از تعداد صفحات است";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                }
                else
                {
                    e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
                }
            }
            catch
            { }
        }

        private void addProposalNavigationFirstPageBtn_Click(object sender, EventArgs e)
        {
            addProposalShowDgv.Columns.Clear();
            CurrentPageIndex=1;
            addProposalNavigationCurrentPageTxtbx.Text = CurrentPageIndex.ToString();
            dbh.dataGridViewUpdate3(addProposalShowDgv, addProposalBindingSource, dbh.addProposalQuery, pageSize, CurrentPageIndex);
            addProposalExecutorNcodeTxtbx.BackColor = Color.White;
            addProposalExecutorNcodeTxtbx.Focus();

            //addProposalShowAllBtn.Enabled = false;
        }



        private void addProposalNavigationLastPageBtn_Click(object sender, EventArgs e)
        {
            addProposalShowDgv.Columns.Clear();
            CurrentPageIndex = TotalPage;
            addProposalNavigationCurrentPageTxtbx.Text = CurrentPageIndex.ToString();
            dbh.dataGridViewUpdate3(addProposalShowDgv, addProposalBindingSource, dbh.addProposalQuery, pageSize, CurrentPageIndex);
            addProposalExecutorNcodeTxtbx.BackColor = Color.White;
            addProposalExecutorNcodeTxtbx.Focus();

           // addProposalShowAllBtn.Enabled = false;
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
                addProposalShowDgv.Columns.Clear();
                //addProposalShowDgv.DataSource = null;
                TotalPage = dbh.totalPage("SELECT COUNT(*) FROM proposalTable WHERE executor = '" + addProposalExecutorNcodeTxtbx.Text + "'");
                CurrentPageIndex = 1;
                addProposalNavigationCurrentPageTxtbx.Text = CurrentPageIndex.ToString();
                dbh.addProposalQuery = "SELECT TOP " + pageSize  + " * FROM proposalTable WHERE executor = '" + addProposalExecutorNcodeTxtbx.Text + "'";
                dbh.dataGridViewUpdate3(addProposalShowDgv, addProposalBindingSource, dbh.addProposalQuery,pageSize,CurrentPageIndex);

                addProposalNavigationFirstPageBtn.Enabled = true;
                addProposalNavigationNextPageBtn.Enabled = true;
                addProposalNavigationLastPageBtn.Enabled = true;
                addProposalNavigationPreviousPageBtn.Enabled = true;
                addProposalNavigationCurrentPageTxtbx.Enabled = true;
                addProposalNavigationReturnBtn.Enabled = false ;
              //  addProposalSearchBtn.Enabled = false;
            }
            else
            {
                //PopUp p = new PopUp("خطا", "کد ملی ده رقمی را به طور کامل وارد نمایید.", "تایید", "", "", "info");
                //p.ShowDialog();
                string context = "کد ملی ده رقمی را به طور کامل وارد نمایید";
                Alert alert = new Alert(context, "bluegray", 5);
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
            manageTeacherShowDgv.Columns.Clear();
            TotalPage = dbh.totalPage("SELECT COUNT(*) FROM TeacherTable");


            CurrentPageIndex = 1;
            manageTeacherNavigationCurrentPageTxtbx.Text = CurrentPageIndex.ToString();
            dbh.manageTeacherQuery = "SELECT TOP " + pageSize + " * FROM TeacherTable WHERE 1=1 ";
            dbh.dataGridViewUpdate3(manageTeacherShowDgv, teacherBindingSource, dbh.manageTeacherQuery, pageSize, CurrentPageIndex);
            manageTeacherExecutorNcodeTxtbx.BackColor = Color.White;
            manageTeacherExecutorNcodeTxtbx.Focus();


            manageTeacherNavigationFirstPageBtn.Enabled = true;
            manageTeacherNavigationNextPageBtn.Enabled = true;
            manageTeacherNavigationLastPageBtn.Enabled = true;
            manageTeacherNavigationPreviousPageBtn.Enabled = true;
            manageTeacherNavigationCurrentPageTxtbx.Enabled = true;
            manageTeacherNavigationReturnBtn.Enabled = false;

            /////////
            //dbh.dataGridViewUpdate2(manageTeacherShowDgv, teacherBindingSource, "SELECT * FROM TeacherTable");
          //  manageTeacherShowAllBtn.Enabled = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
            //Application.Run(new Login());
        }

        private void editProposalSearchBtn_Click(object sender, EventArgs e)
        {
            if(editProposalExecutorNcodeTxtbx.Text.Length == 10)
            {

                if (loginUser.U_IsAdmin == 1)
                {
                    editProposalShowDgv.Columns.Clear();
                    TotalPage = dbh.totalPage("SELECT COUNT(*) FROM proposalTable WHERE executor = '"+ editProposalExecutorNcodeTxtbx.Text + "'");


                    CurrentPageIndex = 1;
                    manageProposalNavigationCurrentPageTxtbx.Text = CurrentPageIndex.ToString();
                    dbh.editProposalQuery = "SELECT TOP " + pageSize + " * FROM proposalTable WHERE executor = '" + editProposalExecutorNcodeTxtbx.Text + "'";
                    dbh.dataGridViewUpdate3(editProposalShowDgv, editProposalBindingSource, dbh.editProposalQuery, pageSize, CurrentPageIndex);
                    editProposalExecutorNcodeTxtbx.BackColor = Color.White;
                    editProposalExecutorNcodeTxtbx.Focus();


                    manageProposalNavigationFirstPageBtn.Enabled = true;
                    manageProposalNavigationNextPageBtn.Enabled = true;
                    manageProposalNavigationLastPageBtn.Enabled = true;
                    manageProposalNavigationPreviousPageBtn.Enabled = true;
                    manageProposalNavigationCurrentPageTxtbx.Enabled = true;
                    manageProposalNavigationReturnBtn.Enabled = false;
                    //  dbh.dataGridViewUpdate2(editProposalShowDgv, editProposalBindingSource, "SELECT * FROM proposalTable");
                }
                else
                {
                    editProposalShowDgv.Columns.Clear();
                    //addProposalShowDgv.DataSource = null;
                    TotalPage = dbh.totalPage("SELECT COUNT(*) FROM proposalTable WHERE registrant = '" + loginUser.U_NCode + "' AND  executor = '" + editProposalExecutorNcodeTxtbx.Text + "'");


                    CurrentPageIndex = 1;
                    manageProposalNavigationCurrentPageTxtbx.Text = CurrentPageIndex.ToString();
                    dbh.editProposalQuery = "SELECT TOP " + pageSize + " * FROM proposalTable WHERE registrant = '" + loginUser.U_NCode + "' AND  executor = '" + editProposalExecutorNcodeTxtbx.Text + "'";
                    dbh.dataGridViewUpdate3(editProposalShowDgv, editProposalBindingSource, dbh.editProposalQuery, pageSize, CurrentPageIndex);
                    editProposalExecutorNcodeTxtbx.BackColor = Color.White;
                    editProposalExecutorNcodeTxtbx.Focus();


                    manageProposalNavigationFirstPageBtn.Enabled = true;
                    manageProposalNavigationNextPageBtn.Enabled = true;
                    manageProposalNavigationLastPageBtn.Enabled = true;
                    manageProposalNavigationPreviousPageBtn.Enabled = true;
                    manageProposalNavigationCurrentPageTxtbx.Enabled = true;
                    manageProposalNavigationReturnBtn.Enabled = false;
                    //  addProposalShowAllBtn.Enabled = false;

                    ////////
                    // dbh.dataGridViewUpdate2(editProposalShowDgv, editProposalBindingSource, "SELECT * FROM proposalTable WHERE registrant = '" + loginUser.U_NCode + "'");
                }

               // dbh.dataGridViewUpdate2(editProposalShowDgv, editProposalBindingSource, "SELECT * FROM proposalTable WHERE executor = '" + editProposalExecutorNcodeTxtbx.Text + "'");
                //editProposalSearchBtn.Enabled = false;
            }
            else
            {
                //PopUp popUp = new PopUp("کد ملی ناقص", "کد ملی ده رقمی را به طور کامل وارد نمایید.", "تایید", "", "", "info");
                //popUp.ShowDialog();
                string context = "برای جست و جو کد ملی ده رقمی را به طور کامل وارد نمایید";
                Alert alert = new Alert(context, "darkred", 5);
            }
        }

        private void editProposalRegisterBtn_Click(object sender, EventArgs e)
        {
            if (!manageProposalIsWatchingEdition)
            {
                if (editProposalExecutorNcodeTxtbx.Text.Length < 10)
                {
                    //PopUp p = new PopUp("خطای ورودی", "شماره ملی ده رقمی را به طور صحیح وارد نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "شماره ملی ده رقمی را به طور صحیح وارد نمایید";
                    Alert alert = new Alert(context, "darkred", 5);
                    editProposalExecutorNcodeTxtbx.Focus();
                }

                else if (editProposalExecutorFNameTxtbx.Text.Length == 0)
                {
                    //PopUp p = new PopUp("خطای ورودی", "نام را وارد نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "نام را وارد نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    editProposalExecutorFNameTxtbx.Focus();
                }

                else if (editProposalExecutorLNameTxtbx.Text.Length == 0)
                {
                    //PopUp p = new PopUp("خطای ورودی", "نام خانوادگی را وارد نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "نام خانوادگی را وارد نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    editProposalExecutorLNameTxtbx.Focus();
                }

                else if (editProposalExecutorFacultyCb.SelectedIndex == -1)
                {
                    //PopUp p = new PopUp("خطای ورودی", "دانشکده را انتخاب نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "دانشکده را انتخاب نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    editProposalExecutorFacultyCb.Focus();
                }

                else if (editProposalExecutorEGroupCb.SelectedIndex == -1)
                {
                    //PopUp p = new PopUp("خطای ورودی", "گروه آموزشی را انتخاب نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "گروه آموزشی را انتخاب نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    editProposalExecutorEGroupCb.Focus();
                }

                else if (editProposalExecutorEDegCb.SelectedIndex == -1)
                {
                    //PopUp p = new PopUp("خطای ورودی", "درجه علمی را انتخاب نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "درجه علمی را انتخاب نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    editProposalExecutorEDegCb.Focus();
                }

                else if (editProposalExecutorEmailTxtbx.Text.Length == 0)
                {
                    //PopUp p = new PopUp("خطای ورودی", "آدرس ایمیل را وارد نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "آدرس ایمیل را وارد نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    editProposalExecutorEmailTxtbx.Focus();
                }

                else if (editProposalExecutorEmailTxtbx.BackColor == Color.Pink)
                {
                    //PopUp p = new PopUp("خطای ورودی", "آدرس ایمیل وارد شده صحیح نیست.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    /////////////////////////////////////////////////////////
                    string context = "آدرس ایمیل وارد شده صحیح نیست";
                    Alert alert = new Alert(context, "darkred", 5);
                    editProposalExecutorEmailTxtbx.Focus();
                }

                else if (editProposalExecutorMobileTxtbx.Text.Length == 0)
                {
                    //PopUp p = new PopUp("خطای ورودی", "شماره موبایل را وارد نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "شماره موبایل را وارد نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    editProposalExecutorMobileTxtbx.Focus();
                }

                else if (editProposalPersianTitleTxtbx.Text.Length == 0)
                {
                    //PopUp p = new PopUp("خطای ورودی", "عنوان فارسی پروپوزال را وارد نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "عنوان فارسی پروپوزال را وارد نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    editProposalPersianTitleTxtbx.Focus();
                }

                else if (editProposalEnglishTitleTxtbx.Text.Length == 0)
                {
                    //PopUp p = new PopUp("خطای ورودی", "عنوان لاتین پروپوزال را وارد نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "عنوان لاتین پروپوزال را وارد نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    editProposalEnglishTitleTxtbx.Focus();
                }

                else if (editProposalKeywordsTxtbx.Text.Length == 0)
                {
                    //PopUp p = new PopUp("خطای ورودی", "کلمات کلیدی را وارد نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "کلمات کلیدی را وارد نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    editProposalKeywordsTxtbx.Focus();
                }

               

                else if (editProposalDurationTxtbx.Text.Length == 0)
                {
                    //PopUp p = new PopUp("خطای ورودی", "مدت زمان را وارد نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "مدت زمان را وارد نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    editProposalDurationTxtbx.Focus();
                }

                else if (editProposalProcedureTypeCb.SelectedIndex == -1)
                {
                    //PopUp p = new PopUp("خطای ورودی", "نوع کار پروپوزال را انتخاب نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "نوع کار پروپوزال را انتخاب نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    editProposalProcedureTypeCb.Focus();
                }

                else if (editProposalPropertyTypeCb.SelectedIndex == -1)
                {
                    //PopUp p = new PopUp("خطای ورودی", "خاصیت پروپوزال را انتخاب نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "خاصیت پروپوزال را انتخاب نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    editProposalPropertyTypeCb.Focus();
                }

                else if (editProposalRegisterTypeCb.SelectedIndex == -1)
                {
                    //PopUp p = new PopUp("خطای ورودی", "نوع ثبت پروپوزال را انتخاب نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "نوع ثبت پروپوزال را انتخاب نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    editProposalRegisterTypeCb.Focus();
                }

                else if (editProposalTypeCb.SelectedIndex == -1)
                {
                    //PopUp p = new PopUp("خطای ورودی", "نوع پروپوزال را انتخاب نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "نوع پروپوزال را انتخاب نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    editProposalTypeCb.Focus();
                }

                else if (editProposalOrganizationNumberCb.SelectedIndex == -1)
                {
                    //PopUp p = new PopUp("خطای ورودی", "سازمان کارفرما را انتخاب نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "سازمان کارفرما را انتخاب نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    editProposalOrganizationNumberCb.Focus();
                }

                else if (editProposalOrganizationNameCb.SelectedIndex == -1)
                {
                    //PopUp p = new PopUp("خطای ورودی", "سازمان کارفرما را انتخاب نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "سازمان کارفرما را انتخاب نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    editProposalOrganizationNameCb.Focus();
                }

                else if (editProposalValueTxtbx.Text.Length == 0)
                {
                    //PopUp p = new PopUp("خطای ورودی", "مبلغ را وارد نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "مبلغ را وارد نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    editProposalValueTxtbx.Focus();
                }

                else if (editProposalStatusCb.SelectedIndex == -1)
                {
                    //PopUp p = new PopUp("خطای ورودی", "وضعیت پروپوزال را انتخا نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "وضعیت پروپوزال را انتخاب نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    editProposalStatusCb.Focus();
                }
                else
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
                    string tempValue = editProposalValueTxtbx.Text.Replace(",", "");
                    //addProposalValueTxtbx.Text = tempValue;
                    proposal.Value = long.Parse(tempValue);
                    proposal.Executor = long.Parse(editProposalExecutorNcodeTxtbx.Text);
                    //INITIALIZE STARTDATE OF PROPOSAL
                    string temp = addProposalStartdateTimeInput.GeoDate.Value.Year + "-";//YEAR
                    if (addProposalStartdateTimeInput.GeoDate.Value.Month > 9)//MONTH
                    {
                        temp += addProposalStartdateTimeInput.GeoDate.Value.Month + "-";
                    }
                    else
                    {
                        temp += "0" + addProposalStartdateTimeInput.GeoDate.Value.Month + "-";
                    }

                    if (addProposalStartdateTimeInput.GeoDate.Value.Day > 9)//DAY
                    {
                        temp += addProposalStartdateTimeInput.GeoDate.Value.Day;
                    }
                    else
                    {
                        temp += "0" + addProposalStartdateTimeInput.GeoDate.Value.Day;
                    }
                    //INITIALIZE STARTDATE OF PROPOSAL
                    proposal.StartDate = temp;
                    proposal.Index = long.Parse(currentSelectedIndex);
                    proposal.FileName = editProposalCurrentFileName;
                    //_inputParameter.FileName = editProposalCurrentFileName;
                    if (editProposalCurrentFileName == editProposalFileLinkLbl.Text)
                    {
                        _inputParameter.FileName = "";
                    }
                   
                    dbh.EditProposal(proposal, loginUser.U_NCode, myDateTime.ToString(),_inputParameter, editProposalCurrentFileName);
                    dbh.editProposalQuery = "SELECT TOP " + pageSize + " * FROM proposalTable WHERE persianTitle = '" + editProposalPersianTitleTxtbx.Text + "'";
                    editProposalClearBtn.PerformClick();
                    dbh.dataGridViewUpdate3(editProposalShowDgv, editProposalBindingSource,dbh.editProposalQuery,pageSize,1);
                }
            }
            else if (manageProposalIsWatchingEdition)
            {
                if (editProposalExecutorNcodeTxtbx.Text.Length < 10)
                {
                    //PopUp p = new PopUp("خطای ورودی", "شماره ملی ده رقمی را به طور صحیح وارد نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "شماره ملی ده رقمی را به طور صحیح وارد نمایید";
                    Alert alert = new Alert(context, "darkred", 5);
                    editProposalExecutorNcodeTxtbx.Focus();
                }

                else if (editProposalExecutorFNameTxtbx.Text.Length == 0)
                {
                    //PopUp p = new PopUp("خطای ورودی", "نام را وارد نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "نام را وارد نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    editProposalExecutorFNameTxtbx.Focus();
                }

                else if (editProposalExecutorLNameTxtbx.Text.Length == 0)
                {
                    //PopUp p = new PopUp("خطای ورودی", "نام خانوادگی را وارد نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "نام خانوادگی را وارد نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    editProposalExecutorLNameTxtbx.Focus();
                }

                else if (editProposalExecutorFacultyCb.SelectedIndex == -1)
                {
                    //PopUp p = new PopUp("خطای ورودی", "دانشکده را انتخاب نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "دانشکده را انتخاب نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    editProposalExecutorFacultyCb.Focus();
                }

                else if (editProposalExecutorEGroupCb.SelectedIndex == -1)
                {
                    //PopUp p = new PopUp("خطای ورودی", "گروه آموزشی را انتخاب نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "گروه آموزشی را انتخاب نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    editProposalExecutorEGroupCb.Focus();
                }

                else if (editProposalExecutorEDegCb.SelectedIndex == -1)
                {
                    //PopUp p = new PopUp("خطای ورودی", "درجه علمی را انتخاب نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "درجه علمی را انتخاب نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    editProposalExecutorEDegCb.Focus();
                }

                else if (editProposalExecutorEmailTxtbx.Text.Length == 0)
                {
                    //PopUp p = new PopUp("خطای ورودی", "آدرس ایمیل را وارد نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "آدرس ایمیل را وارد نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    editProposalExecutorEmailTxtbx.Focus();
                }

                else if (editProposalExecutorEmailTxtbx.BackColor == Color.Pink)
                {
                    //PopUp p = new PopUp("خطای ورودی", "آدرس ایمیل وارد شده صحیح نیست.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "آدرس ایمیل وارد شده صحیح نیست";
                    Alert alert = new Alert(context, "darkred", 5);
                    editProposalExecutorEmailTxtbx.Focus();
                }

                else if (editProposalExecutorMobileTxtbx.Text.Length == 0)
                {
                    //PopUp p = new PopUp("خطای ورودی", "شماره موبایل را وارد نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "شماره موبایل را وارد نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    editProposalExecutorMobileTxtbx.Focus();
                }

                else if (editProposalPersianTitleTxtbx.Text.Length == 0)
                {
                    //PopUp p = new PopUp("خطای ورودی", "عنوان فارسی پروپوزال را وارد نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "عنوان فارسی پروپوزال را وارد نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    editProposalPersianTitleTxtbx.Focus();
                }

                else if (editProposalEnglishTitleTxtbx.Text.Length == 0)
                {
                    //PopUp p = new PopUp("خطای ورودی", "عنوان لاتین پروپوزال را وارد نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "عنوان لاتین پروپوزال را وارد نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    editProposalEnglishTitleTxtbx.Focus();
                }

                else if (editProposalKeywordsTxtbx.Text.Length == 0)
                {
                    //PopUp p = new PopUp("خطای ورودی", "کلمات کلیدی را وارد نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "کلمات کلیدی را وارد نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    editProposalKeywordsTxtbx.Focus();
                }


                else if (editProposalDurationTxtbx.Text.Length == 0)
                {
                    //PopUp p = new PopUp("خطای ورودی", "مدت زمان را وارد نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "مدت زمان را وارد نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    editProposalDurationTxtbx.Focus();
                }

                else if (editProposalProcedureTypeCb.SelectedIndex == -1)
                {
                    //PopUp p = new PopUp("خطای ورودی", "نوع کار پروپوزال را انتخاب نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "نوع کار پروپوزال را انتخاب نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    editProposalProcedureTypeCb.Focus();
                }

                else if (editProposalPropertyTypeCb.SelectedIndex == -1)
                {
                    //PopUp p = new PopUp("خطای ورودی", "خاصیت پروپوزال را انتخاب نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "خاصیت پروپوزال را انتخاب نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    editProposalPropertyTypeCb.Focus();
                }

                else if (editProposalRegisterTypeCb.SelectedIndex == -1)
                {
                    //PopUp p = new PopUp("خطای ورودی", "نوع ثبت پروپوزال را انتخاب نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "نوع ثبت پروپوزال را انتخاب نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    editProposalRegisterTypeCb.Focus();
                }

                else if (editProposalTypeCb.SelectedIndex == -1)
                {
                    //PopUp p = new PopUp("خطای ورودی", "نوع پروپوزال را انتخاب نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "نوع پروپوزال را انتخاب نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    editProposalTypeCb.Focus();
                }

                else if (editProposalOrganizationNumberCb.SelectedIndex == -1)
                {
                    //PopUp p = new PopUp("خطای ورودی", "سازمان کارفرما را انتخاب نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "سازمان کارفرما را انتخاب نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    editProposalOrganizationNumberCb.Focus();
                }

                else if (editProposalOrganizationNameCb.SelectedIndex == -1)
                {
                    //PopUp p = new PopUp("خطای ورودی", "سازمان کارفرما را انتخاب نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "سازمان کارفرما را انتخاب نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    editProposalOrganizationNameCb.Focus();
                }

                else if (editProposalValueTxtbx.Text.Length == 0)
                {
                //    PopUp p = new PopUp("خطای ورودی", "مبلغ را وارد نمایید.", "تایید", "", "", "error");
                //    p.ShowDialog();
                    string context = "مبلغ را وارد نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    editProposalValueTxtbx.Focus();
                }

                else if (editProposalStatusCb.SelectedIndex == -1)
                {
                    //PopUp p = new PopUp("خطای ورودی", "وضعیت پروپوزال را انتخاب نمایید.", "تایید", "", "", "error");
                    //p.ShowDialog();
                    string context = "وضعیت پروپوزال را انتخاب نمایید";
                    Alert alert = new Alert(context, "bluegray", 5);
                    editProposalStatusCb.Focus();
                }
                else
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
                    string tempValue = editProposalValueTxtbx.Text.Replace(",", "");
                    //addProposalValueTxtbx.Text = tempValue;
                    proposal.Value = long.Parse(tempValue);
                    proposal.Executor = long.Parse(editProposalExecutorNcodeTxtbx.Text);
                    proposal.StartDate = editProposalStartdateTimeInput.GeoDate.ToString();
                    proposal.Edition =  editProposalCurrentSelectedEdition;
                    proposal.Index = long.Parse(currentSelectedIndex);
                    proposal.FileName = editProposalCurrentFileName;

                    if (editProposalCurrentFileName == editProposalFileLinkLbl.Text)
                    {
                        _inputParameter.FileName = "";
                    }
                    if (proposal.Edition == 0)
                    {
                        PopUp p = new PopUp("تغییر اطلاعات پروپوزال", "نسخه ای که میخواهید تغییر دهید نسخه اصلی پروپوزال است . آیا مایل به تغییر پروپوزال هستید ؟", "بله", "خیر", "", "info");
                        p.ShowDialog();
                        if (p.DialogResult == DialogResult.Yes)
                        {
                            dbh.EditProposal(proposal, loginUser.U_NCode, myDateTime.ToString(), _inputParameter, editProposalCurrentFileName);
                            editProposalClearBtn.PerformClick();
                            dbh.dataGridViewUpdate2(editProposalShowDgv, editProposalBindingSource, "SELECT * FROM editionTable WHERE [index] = '" + proposal.Index + "'");
                            editProposalShowDgv.Columns["editionBtn"].Visible = false;
                            editProposalShowDgv.Columns["edition"].HeaderText = "شماره نسخه";
                            editProposalShowDgv.Columns["edition"].DisplayIndex = 3;
                            editProposalShowDgv.Columns["edition"].Frozen = true;
                            manageProposalIsWatchingEdition = true;

                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        dbh.EditEdition(proposal, proposalEdition, loginUser.U_NCode, myDateTime.ToString(), _inputParameter, editProposalCurrentFileName);
                        editProposalClearBtn.PerformClick();
                        dbh.dataGridViewUpdate2(editProposalShowDgv, editProposalBindingSource, "SELECT * FROM editionTable WHERE [index] = '" + proposal.Index + "'");
                        editProposalShowDgv.Columns["editionBtn"].Visible = false;
                        editProposalShowDgv.Columns["edition"].HeaderText = "شماره نسخه";
                        editProposalShowDgv.Columns["edition"].DisplayIndex = 3;
                        editProposalShowDgv.Columns["edition"].Frozen = true;
                        manageProposalIsWatchingEdition = true;

                    }
                   
                }
            }
        }

        private void editProposalShowDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!manageProposalIsWatchingEdition)
                {
                    if (e.ColumnIndex == 18)
                    {

                        Proposal proposal = new Proposal();
                        proposal.Index = long.Parse(editProposalShowDgv.Rows[e.RowIndex].Cells["index"].Value.ToString());
                        proposal.PersianTitle = editProposalShowDgv.Rows[e.RowIndex].Cells["persianTitle"].Value.ToString();
                        proposal.EngTitle = editProposalShowDgv.Rows[e.RowIndex].Cells["engTitle"].Value.ToString();
                        proposal.KeyWord = editProposalShowDgv.Rows[e.RowIndex].Cells["keyword"].Value.ToString();
                        proposal.Executor2 = editProposalShowDgv.Rows[e.RowIndex].Cells["executor2"].Value.ToString();
                        proposal.CoExecutor = editProposalShowDgv.Rows[e.RowIndex].Cells["coExecutor"].Value.ToString();
                        proposal.StartDate = editProposalShowDgv.Rows[e.RowIndex].Cells["hijriDate"].Value.ToString();
                        proposal.Duration = Int32.Parse(editProposalShowDgv.Rows[e.RowIndex].Cells["duration"].Value.ToString());
                        proposal.ProcedureType = editProposalShowDgv.Rows[e.RowIndex].Cells["procedureType"].Value.ToString();
                        proposal.ProposalType = editProposalShowDgv.Rows[e.RowIndex].Cells["proposalType"].Value.ToString();
                        proposal.PropertyType = editProposalShowDgv.Rows[e.RowIndex].Cells["propertyType"].Value.ToString();
                        proposal.RegisterType = editProposalShowDgv.Rows[e.RowIndex].Cells["registerType"].Value.ToString();
                        proposal.Employer = Int32.Parse(editProposalShowDgv.Rows[e.RowIndex].Cells["employer"].Value.ToString());
                        proposal.Edition = 0;
                        proposal.Value = long.Parse(editProposalShowDgv.Rows[e.RowIndex].Cells["value"].Value.ToString());
                        proposal.Status = editProposalShowDgv.Rows[e.RowIndex].Cells["status"].Value.ToString();
                        proposal.FileName = editProposalShowDgv.Rows[e.RowIndex].Cells["fileName"].Value.ToString();
                        proposal.Executor = long.Parse(editProposalShowDgv.Rows[e.RowIndex].Cells["executor"].Value.ToString());
                        proposal.Registrant = long.Parse(editProposalShowDgv.Rows[e.RowIndex].Cells["registrant"].Value.ToString());
                        proposal.RegistrantName = editProposalShowDgv.Rows[e.RowIndex].Cells["registrantBtn"].Value.ToString();
                        proposal.TeacherFullName = editProposalShowDgv.Rows[e.RowIndex].Cells["executorFullName"].Value.ToString();


                        Detail detail = new Detail(proposal, loginUser.U_NCode);
                        detail.ShowDialog();
                    }
                    if (e.ColumnIndex == 19)
                    {

                        Proposal proposal = new Proposal();

                        proposal.Index = long.Parse(editProposalShowDgv.Rows[e.RowIndex].Cells["index"].Value.ToString());

                        ////////
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
                        editProposalCurrentFileName = editProposalShowDgv.Rows[e.RowIndex].Cells["fileName"].Value.ToString();
                        editProposalFileLinkLbl.Text = editProposalCurrentFileName;
                        editProposalExecutorNcodeTxtbx.Text = editProposalShowDgv.Rows[e.RowIndex].Cells["executor"].Value.ToString();
                        editProposalStartdateTimeInput.GeoDate = DateTime.Parse(editProposalShowDgv.Rows[e.RowIndex].Cells["startDate"].Value.ToString());
                       

                        editProposalRegisterBtn.Enabled = true;
                        editProposalDeleteBtn.Enabled = true;
                        ////////
                        editProposalShowDgv.Columns.Clear();
                        dbh.dataGridViewUpdate2(editProposalShowDgv, editProposalBindingSource, "SELECT * FROM editionTable WHERE [index] = '" + proposal.Index + "'");
                        editProposalShowDgv.Columns["editionBtn"].Visible = false;
                        editProposalShowDgv.Columns["edition"].HeaderText = "شماره نسخه";
                        editProposalShowDgv.Columns["edition"].DisplayIndex = 3;
                        editProposalShowDgv.Columns["edition"].Frozen = true;


                        editionProposalIndex = proposal.Index;
                        manageProposalIsWatchingEdition = true;

                        manageProposalNavigationFirstPageBtn.Enabled = false;
                        manageProposalNavigationNextPageBtn.Enabled = false;
                        manageProposalNavigationLastPageBtn.Enabled = false;
                        manageProposalNavigationPreviousPageBtn.Enabled = false;
                        manageProposalNavigationCurrentPageTxtbx.Enabled = false;
                        manageProposalNavigationReturnBtn.Enabled = true;

                    }
                    else
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
                        editProposalCurrentFileName = editProposalShowDgv.Rows[e.RowIndex].Cells["fileName"].Value.ToString();
                        editProposalFileLinkLbl.Text = editProposalCurrentFileName;
                        editProposalExecutorNcodeTxtbx.Text = editProposalShowDgv.Rows[e.RowIndex].Cells["executor"].Value.ToString();
                        editProposalStartdateTimeInput.GeoDate = DateTime.Parse(editProposalShowDgv.Rows[e.RowIndex].Cells["startDate"].Value.ToString());
                    

                        if(loginUser.CanEditProposal == 1)
                        {
                            editProposalRegisterBtn.Enabled = true;
                        }

                        if(loginUser.CanDeleteProposal == 1)
                        {
                            editProposalDeleteBtn.Enabled = true;
                        }
                    }
                }
                else if (manageProposalIsWatchingEdition)
                {
                   
                    if (e.ColumnIndex == 19)
                    {

                        Proposal proposal = new Proposal();
                        proposal.Index = long.Parse(editProposalShowDgv.Rows[e.RowIndex].Cells["index"].Value.ToString());
                        proposal.PersianTitle = editProposalShowDgv.Rows[e.RowIndex].Cells["persianTitle"].Value.ToString();
                        proposal.EngTitle = editProposalShowDgv.Rows[e.RowIndex].Cells["engTitle"].Value.ToString();
                        proposal.KeyWord = editProposalShowDgv.Rows[e.RowIndex].Cells["keyword"].Value.ToString();
                        proposal.Executor2 = editProposalShowDgv.Rows[e.RowIndex].Cells["executor2"].Value.ToString();
                        proposal.CoExecutor = editProposalShowDgv.Rows[e.RowIndex].Cells["coExecutor"].Value.ToString();
                        proposal.StartDate = editProposalShowDgv.Rows[e.RowIndex].Cells["hijriDate"].Value.ToString();
                        proposal.Duration = Int32.Parse(editProposalShowDgv.Rows[e.RowIndex].Cells["duration"].Value.ToString());
                        proposal.ProcedureType = editProposalShowDgv.Rows[e.RowIndex].Cells["procedureType"].Value.ToString();
                        proposal.ProposalType = editProposalShowDgv.Rows[e.RowIndex].Cells["proposalType"].Value.ToString();
                        proposal.PropertyType = editProposalShowDgv.Rows[e.RowIndex].Cells["propertyType"].Value.ToString();
                        proposal.RegisterType = editProposalShowDgv.Rows[e.RowIndex].Cells["registerType"].Value.ToString();
                        proposal.Employer = Int32.Parse(editProposalShowDgv.Rows[e.RowIndex].Cells["employer"].Value.ToString());
                        proposal.Edition = int.Parse(editProposalShowDgv.Rows[e.RowIndex].Cells["edition"].Value.ToString());
                        proposal.Value = long.Parse(editProposalShowDgv.Rows[e.RowIndex].Cells["value"].Value.ToString());
                        proposal.Status = editProposalShowDgv.Rows[e.RowIndex].Cells["status"].Value.ToString();
                        proposal.FileName = editProposalShowDgv.Rows[e.RowIndex].Cells["fileName"].Value.ToString();
                        proposal.Executor = long.Parse(editProposalShowDgv.Rows[e.RowIndex].Cells["executor"].Value.ToString());
                        proposal.Edition = int.Parse(editProposalShowDgv.Rows[e.RowIndex].Cells["edition"].Value.ToString());
                        proposal.Registrant = long.Parse(editProposalShowDgv.Rows[e.RowIndex].Cells["registrant"].Value.ToString());
                        proposal.RegistrantName = editProposalShowDgv.Rows[e.RowIndex].Cells["registrantBtn"].Value.ToString();
                        proposal.TeacherFullName = editProposalShowDgv.Rows[e.RowIndex].Cells["executorFullName"].Value.ToString();


                        Detail detail = new Detail(proposal, loginUser.U_NCode);
                        detail.ShowDialog();
                    }
                    else
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
                        editProposalCurrentFileName = editProposalShowDgv.Rows[e.RowIndex].Cells["fileName"].Value.ToString();
                        editProposalFileLinkLbl.Text = editProposalCurrentFileName;
                        editProposalExecutorNcodeTxtbx.Text = editProposalShowDgv.Rows[e.RowIndex].Cells["executor"].Value.ToString();
                        editProposalStartdateTimeInput.GeoDate = DateTime.Parse(editProposalShowDgv.Rows[e.RowIndex].Cells["startDate"].Value.ToString());
                        proposalEdition = int.Parse(editProposalShowDgv.Rows[e.RowIndex].Cells["edition"].Value.ToString());
                        editProposalCurrentSelectedEdition = int.Parse(editProposalShowDgv.Rows[e.RowIndex].Cells["edition"].Value.ToString());


                        editProposalRegisterBtn.Enabled = true;
                        editProposalDeleteBtn.Enabled = true;
                    }
                }
            }
            catch (ArgumentOutOfRangeException) { }
        }

        private void editProposalDeleteBtn_Click(object sender, EventArgs e)
        {
            
            PopUp p = new PopUp("حذف اطلاعات پروپوزال", "آیا از حذف اطلاعات پروپوزال مطمئن هستید؟", "بله", "خیر", "", "info");
            p.ShowDialog();
            if (p.DialogResult == DialogResult.Yes)
            {
                if (!manageProposalIsWatchingEdition)
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
                    string tempValue = editProposalValueTxtbx.Text.Replace(",", "");
                    //addProposalValueTxtbx.Text = tempValue;
                    proposal.Value = long.Parse(tempValue);
                    proposal.Executor = long.Parse(editProposalExecutorNcodeTxtbx.Text);
                    proposal.StartDate = editProposalStartdateTimeInput.GeoDate.ToString();
                    proposal.Index = long.Parse(currentSelectedIndex);
                    proposal.FileName = editProposalCurrentFileName;

                    dbh.DeleteProposal(proposal, loginUser.U_NCode, myDateTime.ToString());
                    // dbh.dataGridViewUpdate3(editProposalShowDgv, editProposalBindingSource, "SELECT * FROM proposalTable WHERE executor = '" + editProposalExecutorNcodeTxtbx.Text + "'");

                    editProposalClearBtn.PerformClick();
                    editProposalShowAllBtn.PerformClick();
                }
                else if (manageProposalIsWatchingEdition)
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
                    string tempValue = editProposalValueTxtbx.Text.Replace(",", "");
                    //addProposalValueTxtbx.Text = tempValue;
                    proposal.Value = long.Parse(tempValue);
                    proposal.Executor = long.Parse(editProposalExecutorNcodeTxtbx.Text);
                    proposal.StartDate = editProposalStartdateTimeInput.GeoDate.ToString();
                    proposal.Index = long.Parse(currentSelectedIndex);
                    proposal.FileName = editProposalCurrentFileName;
                    proposal.Edition = editProposalCurrentSelectedEdition;
                    if (proposal.Edition == 0)
                    {
                        PopUp pop = new PopUp("اخطار", "نسخه ای که میخواهید حذف کنید نسخه اصلی پروپوزال است . آیا مایل به حذف پروپوزال هستید ؟", "بله", "خیر", "", "info");
                        pop.ShowDialog();
                        if (pop.DialogResult == DialogResult.Yes)
                        {
                            dbh.DeleteProposal(proposal, loginUser.U_NCode, myDateTime.ToString());
                        }
                    }
                    else
                    {
                        dbh.DeleteEdition(proposal, proposalEdition, loginUser.U_NCode, myDateTime.ToString(), 1);
                    }
                    //string exNCode = editProposalExecutorNcodeTxtbx.Text;
                    //editProposalClearBtn.PerformClick();
                    //dbh.dataGridViewUpdate2(editProposalShowDgv, editProposalBindingSource, "SELECT * FROM editionTable WHERE [index] = '" + proposal.Index + "'");

                    editProposalClearBtn.PerformClick();
                    editProposalShowAllBtn.PerformClick();
                }
            }
        }

        private void manageUserDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                manageUserFnameTxtbx.Text = manageUserShowDgv.Rows[e.RowIndex].Cells["u_FName"].Value.ToString();
                manageUserLnameTxtbx.Text = manageUserShowDgv.Rows[e.RowIndex].Cells["u_LName"].Value.ToString();
                manageUserPasswordTxtbx.Text = manageUserShowDgv.Rows[e.RowIndex].Cells["u_Password"].Value.ToString();
                manageUserNcodeTxtbx.Text = manageUserShowDgv.Rows[e.RowIndex].Cells["u_NCode"].Value.ToString();
                manageUserEmailTxtbx.Text = manageUserShowDgv.Rows[e.RowIndex].Cells["u_Email"].Value.ToString();
                manageUserTelTxtbx.Text = manageUserShowDgv.Rows[e.RowIndex].Cells["u_Tel"].Value.ToString();
                manageUserAddProCb.Checked = bool.Parse(manageUserShowDgv.Rows[e.RowIndex].Cells["u_canAddProposal"].Value.ToString());
                manageUserEditProCb.Checked = bool.Parse(manageUserShowDgv.Rows[e.RowIndex].Cells["u_canEditProposal"].Value.ToString());
                manageUserDeleteProCb.Checked = bool.Parse(manageUserShowDgv.Rows[e.RowIndex].Cells["u_canDeleteProposal"].Value.ToString());
                manageUserAddUserCb.Checked = bool.Parse(manageUserShowDgv.Rows[e.RowIndex].Cells["u_canAddUser"].Value.ToString());
                manageUserEditUserCb.Checked = bool.Parse(manageUserShowDgv.Rows[e.RowIndex].Cells["u_canEditUser"].Value.ToString());
                manageUserDeleteUserCb.Checked = bool.Parse(manageUserShowDgv.Rows[e.RowIndex].Cells["u_canDeleteUser"].Value.ToString());
                manageUserManageTeacherCb.Checked = bool.Parse(manageUserShowDgv.Rows[e.RowIndex].Cells["u_canManageTeacher"].Value.ToString());
                manageUserManageTypeCb.Checked = bool.Parse(manageUserShowDgv.Rows[e.RowIndex].Cells["u_canManageType"].Value.ToString());
                manageUserCurrentSelectedOption = manageUserShowDgv.Rows[e.RowIndex].Cells["u_NCode"].Value.ToString();
            }
            catch (ArgumentOutOfRangeException) { }
    }

      

        private void searchProposalShowAllBtn_Click(object sender, EventArgs e)
        {
            searchProposalShowDgv.Columns.Clear();
            //addProposalShowDgv.DataSource = null;
            if(searchProposalIsWatchingEdition)
            {
                searchProposalClearBtn.PerformClick();
            }
            TotalPage = dbh.totalPage("SELECT COUNT(*) FROM proposalTable");


            CurrentPageIndex = 1;
            searchProposalNavigationCurrentPageTxtbx.Text = CurrentPageIndex.ToString();
            dbh.searchProposalQuery = "SELECT TOP " + pageSize + " * FROM proposalTable WHERE 1=1 ";
            dbh.dataGridViewUpdate3(searchProposalShowDgv, searchProposalBindingSource, dbh.searchProposalQuery, pageSize, CurrentPageIndex);
            searchProposalExecutorNCodeTxtbx.BackColor = Color.White;
            searchProposalExecutorNCodeTxtbx.Focus();

            searchProposalNavigationFirstPageBtn.Enabled = true;
            searchProposalNavigationNextPageBtn.Enabled = true;
            searchProposalNavigationLastPageBtn.Enabled = true;
            searchProposalNavigationPreviousPageBtn.Enabled = true;
            searchProposalNavigationCurrentPageTxtbx.Enabled = true;
            searchProposalNavigationReturnBtn.Enabled = false;
            //  addProposalShowAllBtn.Enabled = false;
        }


        private void searchProposalSearchBtn_Click(object sender, EventArgs e)
        {
            List<long> NCODES = new List<long>();

            string query = "SELECT TOP " + pageSize + " * FROM proposalTable WHERE ";

            string query2 = "SELECT t_NCode FROM teacherTable WHERE ";

            if (searchProposalExecutorFNameTxtbx.Text != "" && searchProposalExecutorFNameTxtbx.Enabled != false)
            {
                query2 = query2 + " t_FName LIKE '%" + searchProposalExecutorFNameTxtbx.Text + "%' AND";
            }
            if (searchProposalExecutorLNameTxtbx.Text != "" && searchProposalExecutorLNameTxtbx.Enabled != false)
            {
                query2 = query2 + " t_LName LIKE '%" + searchProposalExecutorLNameTxtbx.Text + "%' AND";
            }
            if (searchProposalExecutorFacultyCb.Text != "" && searchProposalExecutorFacultyCb.Enabled != false)
            {
                query2 = query2 + " t_Faculty = '" + searchProposalExecutorFacultyCb.Text + "' AND";
            }
            if (searchProposalExecutorEGroupCb.Text != "" && searchProposalExecutorEGroupCb.Enabled != false)
            {
                query2 = query2 + " t_Group = '" + searchProposalExecutorEGroupCb.Text + "' AND";
            }
            if (searchProposalExecutorMobileTxtbx.Text != "" && searchProposalExecutorMobileTxtbx.Enabled != false)
            {
                query2 = query2 + " t_Mobile LIKE '%" + searchProposalExecutorMobileTxtbx.Text + "%' AND";
            }

            query2 = query2.Substring(0, query2.Length - 3);


            if (query2 != "SELECT t_NCode FROM teacherTable WHE")
            {
                NCODES = dbh.getTeachersNCode(query2);
            }


            foreach (long NC in NCODES)
            {
                query = query + " executor = '" + NC + "' OR";

            }

            if (query != "SELECT TOP " + pageSize + " * FROM proposalTable WHERE ")
            {
                query = query.Substring(0, query.Length - 2) + " AND";
            }

            if (searchProposalExecutorNCodeTxtbx.Text != "")
            {
                query = query + " executor = '" + searchProposalExecutorNCodeTxtbx.Text + "' AND";
            }

            if (searchProposalPersianTitleTxtbx.Text != "")
            {
                query = query + " persianTitle LIKE '%" + searchProposalPersianTitleTxtbx.Text + "%' AND";
            }

            if (searchProposalEnglishTitleTxtbx.Text != "")
            {
                query = query + " engTitle LIKE '%" + searchProposalEnglishTitleTxtbx.Text + "%' AND";
            }

            if (searchProposalProcedureTypeCb.Text != "")
            {
                query = query + " procedureType = '" + searchProposalProcedureTypeCb.Text + "' AND";
            }

            if (searchProposalPropertyTypeCb.Text != "")
            {
                query = query + " propertyType = '" + searchProposalPropertyTypeCb.Text + "' AND";
            }

            if (searchProposalRegisterTypeCb.Text != "")
            {
                query = query + " registerType = '" + searchProposalRegisterTypeCb.Text + "' AND";
            }

            if (searchProposalTypeCb.Text != "")
            {
                query = query + " proposalType = '" + searchProposalTypeCb.Text + "' AND";
            }

            if (searchProposalStatusCb.Text != "")
            {
                query = query + " status = '" + searchProposalStatusCb.Text + "' AND";
            }

            if (searchProposalOrganizationNumberCb.Text != "")
            {
                query = query + " employer = '" + searchProposalOrganizationNumberCb.Text + "' AND";
            }

            if (searchProposalValueFromTxtbx.Text != "")
            {
                string tempValueFrom = searchProposalValueFromTxtbx.Text.Replace(",", "");
                //MessageBox.Show(tempValueFrom);
                query = query + " value >= '" + long.Parse(tempValueFrom) + "' AND";
            }

            if (searchProposalValueToTxtbx.Text != "")
            {
                string tempValueTo = searchProposalValueToTxtbx.Text.Replace(",", "");
                //MessageBox.Show(tempValueTo);
                query = query + " value <= '" + long.Parse(tempValueTo) + "' AND";
            }

            if (searchProposalStartDateFromChbx.Checked == true)
            {
                query = query + " startDate >= '" + searchProposalStartDateFromTimeInput.GeoDate.ToString() + "' AND";
            }

            if (searchProposalStartDateToChbx.Checked == true)
            {
                query = query + " startDate <= '" + searchProposalStartDateToTimeInput.GeoDate.ToString() + "' AND";

            }

            query = query.Substring(0, query.Length - 3);

            if (query != "SELECT TOP " + pageSize + " * FROM proposalTable WHE")
            {
                searchProposalShowDgv.Columns.Clear();

                query = query.Replace("TOP 5 *", "COUNT(*)");
                TotalPage = dbh.totalPage(query);

                query = query.Replace("COUNT(*)", "TOP 5 *");


                //MessageBox.Show(query);

                //// total page 
                CurrentPageIndex = 1;
                searchProposalNavigationCurrentPageTxtbx.Text = CurrentPageIndex.ToString();
                dbh.searchProposalQuery = query;
                dbh.dataGridViewUpdate3(searchProposalShowDgv, searchProposalBindingSource, dbh.searchProposalQuery, pageSize, CurrentPageIndex);

                searchProposalExecutorNCodeTxtbx.BackColor = Color.White;
                searchProposalExecutorNCodeTxtbx.Focus();

                searchProposalNavigationFirstPageBtn.Enabled = true;
                searchProposalNavigationNextPageBtn.Enabled = true;
                searchProposalNavigationLastPageBtn.Enabled = true;
                searchProposalNavigationPreviousPageBtn.Enabled = true;
                searchProposalNavigationCurrentPageTxtbx.Enabled = true;
                searchProposalNavigationReturnBtn.Enabled = false;
            }
            else
            {
                searchProposalShowDgv.Columns.Clear();
                searchProposalShowDgv.DataSource = null;
            }

        }

        private void editProposalShowAllBtn_Click(object sender, EventArgs e)
        {
            if(loginUser.U_IsAdmin == 1)
            {
                editProposalShowDgv.Columns.Clear();
                if(manageProposalIsWatchingEdition)
                {
                    editProposalClearBtn.PerformClick();
                }
                TotalPage = dbh.totalPage("SELECT COUNT(*) FROM proposalTable");


                CurrentPageIndex = 1;
                manageProposalNavigationCurrentPageTxtbx.Text = CurrentPageIndex.ToString();
                dbh.editProposalQuery = "SELECT TOP " + pageSize + " * FROM proposalTable WHERE 1=1 ";
                dbh.dataGridViewUpdate3(editProposalShowDgv, editProposalBindingSource, dbh.editProposalQuery, pageSize, CurrentPageIndex);
                editProposalExecutorNcodeTxtbx.BackColor = Color.White;
                editProposalExecutorNcodeTxtbx.Focus();


                manageProposalNavigationFirstPageBtn.Enabled = true;
                manageProposalNavigationNextPageBtn.Enabled = true;
                manageProposalNavigationLastPageBtn.Enabled = true;
                manageProposalNavigationPreviousPageBtn.Enabled = true;
                manageProposalNavigationCurrentPageTxtbx.Enabled = true;
                manageProposalNavigationReturnBtn.Enabled = false;
                //  dbh.dataGridViewUpdate2(editProposalShowDgv, editProposalBindingSource, "SELECT * FROM proposalTable");
            }
            else
            {
                editProposalShowDgv.Columns.Clear();
                if (manageProposalIsWatchingEdition)
                {
                    editProposalClearBtn.PerformClick();
                }
                //addProposalShowDgv.DataSource = null;
                TotalPage = dbh.totalPage("SELECT COUNT(*) FROM proposalTable WHERE registrant = '" + loginUser.U_NCode + "'");


                CurrentPageIndex = 1;
                manageProposalNavigationCurrentPageTxtbx.Text = CurrentPageIndex.ToString();
                dbh.editProposalQuery = "SELECT TOP " + pageSize + " * FROM proposalTable WHERE registrant = '" + loginUser.U_NCode + "'";
                dbh.dataGridViewUpdate3(editProposalShowDgv, editProposalBindingSource, dbh.editProposalQuery, pageSize, CurrentPageIndex);
                editProposalExecutorNcodeTxtbx.BackColor = Color.White;
                editProposalExecutorNcodeTxtbx.Focus();


                manageProposalNavigationFirstPageBtn.Enabled = true;
                manageProposalNavigationNextPageBtn.Enabled = true;
                manageProposalNavigationLastPageBtn.Enabled = true;
                manageProposalNavigationPreviousPageBtn.Enabled = true;
                manageProposalNavigationCurrentPageTxtbx.Enabled = true;
                manageProposalNavigationReturnBtn.Enabled = false;
                //  addProposalShowAllBtn.Enabled = false;

                ////////
               // dbh.dataGridViewUpdate2(editProposalShowDgv, editProposalBindingSource, "SELECT * FROM proposalTable WHERE registrant = '" + loginUser.U_NCode + "'");
            }
           // editProposalShowAllBtn.Enabled = false;
        }

        private void editProposalExecutorFNameTxtbx_Enter(object sender, EventArgs e)
        {
            if (editProposalExecutorNcodeTxtbx.Text.Length < 10)
            {
                editProposalExecutorNcodeTxtbx.BackColor = Color.Pink;
            }
        }

        private void personalSettingOldPassChb_MouseDown(object sender, MouseEventArgs e)
        {
            personalSettingOldPasswordChb.Checked = true;
            personalSettingOldPasswordTxtbx.PasswordChar = '\0';
        }

        private void personalSettingOldPassChb_MouseUp(object sender, MouseEventArgs e)
        {
            personalSettingOldPasswordChb.Checked = false;
            personalSettingOldPasswordTxtbx.PasswordChar = '●';
        }

        private void personalSettingNewPassChb_MouseDown(object sender, MouseEventArgs e)
        {
            personalSettingNewPasswordChb.Checked = true;
            personalSettingNewPasswordTxtbx.PasswordChar = '\0';
        }

        private void personalSettingNewPassChb_MouseUp(object sender, MouseEventArgs e)
        {
            personalSettingNewPasswordChb.Checked = false;
            personalSettingNewPasswordTxtbx.PasswordChar = '●';
        }

        private void personalSettingRepeatPassChb_MouseDown(object sender, MouseEventArgs e)
        {
            personalSettingRepeatPasswordChb.Checked = true;
            personalSettingRepeatPasswordTxtbx.PasswordChar = '\0';
        }

        private void personalSettingRepeatPassChb_MouseUp(object sender, MouseEventArgs e)
        {
            personalSettingRepeatPasswordChb.Checked = false;
            personalSettingRepeatPasswordTxtbx.PasswordChar = '●';
        }

        private void manageUserShowPasswordChb_MouseDown(object sender, MouseEventArgs e)
        {
            manageUserShowPasswordChb.Checked = true;
            manageUserPasswordTxtbx.PasswordChar = '\0';
        }

        private void manageUserShowPasswordChb_MouseUp(object sender, MouseEventArgs e)
        {
            manageUserShowPasswordChb.Checked = false;
            manageUserPasswordTxtbx.PasswordChar = '●';
        }

        private void manageUserShowDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                manageUserCurrentSelectedOption = manageUserShowDgv.Rows[e.RowIndex].Cells["u_NCode"].Value.ToString();
                manageUserFnameTxtbx.Text = manageUserShowDgv.Rows[e.RowIndex].Cells["u_FName"].Value.ToString();
                manageUserLnameTxtbx.Text = manageUserShowDgv.Rows[e.RowIndex].Cells["u_LName"].Value.ToString();
                manageUserNcodeTxtbx.Text = manageUserShowDgv.Rows[e.RowIndex].Cells["u_NCode"].Value.ToString();
                manageUserCurrentSelectedPassword = manageUserShowDgv.Rows[e.RowIndex].Cells["u_Password"].Value.ToString();
                manageUserPasswordTxtbx.Text = manageUserShowDgv.Rows[e.RowIndex].Cells["u_Password"].Value.ToString();
                manageUserEmailTxtbx.Text = manageUserShowDgv.Rows[e.RowIndex].Cells["u_Email"].Value.ToString();
                manageUserTelTxtbx.Text = manageUserShowDgv.Rows[e.RowIndex].Cells["u_Tel"].Value.ToString();

                manageUserAddProCb.Checked = bool.Parse(manageUserShowDgv.Rows[e.RowIndex].Cells["u_canAddProposal"].Value.ToString());
                manageUserEditProCb.Checked = bool.Parse(manageUserShowDgv.Rows[e.RowIndex].Cells["u_canEditProposal"].Value.ToString());
                manageUserDeleteProCb.Checked = bool.Parse(manageUserShowDgv.Rows[e.RowIndex].Cells["u_canDeleteProposal"].Value.ToString());
                manageUserAddUserCb.Checked = bool.Parse(manageUserShowDgv.Rows[e.RowIndex].Cells["u_canAddUser"].Value.ToString());
                manageUserEditUserCb.Checked = bool.Parse(manageUserShowDgv.Rows[e.RowIndex].Cells["u_canEditUser"].Value.ToString());
                manageUserDeleteUserCb.Checked = bool.Parse(manageUserShowDgv.Rows[e.RowIndex].Cells["u_canDeleteUser"].Value.ToString());
                manageUserManageTeacherCb.Checked = bool.Parse(manageUserShowDgv.Rows[e.RowIndex].Cells["u_canManageTeacher"].Value.ToString());
                manageUserManageTypeCb.Checked = bool.Parse(manageUserShowDgv.Rows[e.RowIndex].Cells["u_canManageType"].Value.ToString());
                manageUserIsAdminCb.Checked = bool.Parse(manageUserShowDgv.Rows[e.RowIndex].Cells["u_IsAdmin"].Value.ToString());

                if(Int16.Parse(manageUserShowDgv.Rows[e.RowIndex].Cells["u_otherAccess"].Value.ToString())==1)
                {
                    manageUserReadOnlyCb.Checked = true;
                }
                else
                {
                    manageUserReadOnlyCb.Checked = false;
                }


                if (loginUser.CanEditUser == 1)
                {
                    manageUserEditBtn.Enabled = true;
                }
                if(loginUser.CanDeleteUser == 1)
                {
                    manageUserDeleteBtn.Enabled = true;
                }
                
            }
            catch (ArgumentOutOfRangeException) { }
        }

        private void searchProposalExecutorFNameTxtbx_Enter(object sender, EventArgs e)
        {
            if (searchProposalExecutorNCodeTxtbx.Text.Length < 10)
            {
                searchProposalExecutorNCodeTxtbx.BackColor = Color.Pink;
            }
        }

        private void appSettingEdegreeRbtn_Click(object sender, EventArgs e)
        {
            appSettingEditBtn.Enabled = false;
            appSettingDeleteBtn.Enabled = false;

            appSettingProcedureTypeTxtbx.Enabled = false;
            appSettingPropertyTxtbx.Enabled = false;
            appSettingEdegreeTxtbx.Enabled = true;
            appSettingRegTypeTxtbx.Enabled = false;
            appSettingProTypeTxtbx.Enabled = false;
            appSettingEgroupTxtbx.Enabled = false;
            appSettingCoTxtbx.Enabled = false;
            appSettingStatusTxtbx.Enabled = false;
            appSettingFacultyTxtbx.Enabled = false;

            appSettingProcedureTypeTxtbx.Clear();
            appSettingPropertyTxtbx.Clear();
            appSettingRegTypeTxtbx.Clear();
            appSettingProTypeTxtbx.Clear();
            appSettingEgroupTxtbx.Clear();
            appSettingCoTxtbx.Clear();
            appSettingStatusTxtbx.Clear();
            appSettingFacultyTxtbx.Clear();

            appSettingAddBtn.Enabled = true;

            dbh.dataGridViewUpdate2(appSettingShowDv, appSettingBindingSource, "SELECT * FROM EDegreeTable");
            appSettingShowDv.Columns[0].HeaderText = "درجه علمی";
        }
        private void editProposalFileLinkLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog op1 = new OpenFileDialog();
            op1.Multiselect = false;
            op1.Filter = "Word or PDF Files| *.doc; *.docx; *.pdf";
            op1.FilterIndex = 0;
            op1.RestoreDirectory = true;

            if (op1.ShowDialog() == DialogResult.OK)
            {
                FileInfo fi = new FileInfo(op1.FileName);
                _inputParameter.Username = "";
                _inputParameter.Password = "";
                _inputParameter.Server = "";
                _inputParameter.FileName = fi.Name;
                _inputParameter.FullName = fi.FullName;
            }
            if (op1.FileName != "")
            {
                editProposalFileLinkLbl.Text = op1.FileName;
            }
        }

        private void manageTeacherSearchBtn_Click(object sender, EventArgs e)
        {
            string query2 = "SELECT TOP " + pageSize + " * FROM TeacherTable WHERE ";

            bool searchByeNCode = false;

            if (manageTeacherExecutorNcodeTxtbx.Text != "")
            {
                query2 = query2 + " t_NCode = '" + manageTeacherExecutorNcodeTxtbx.Text + "' AND";
                searchByeNCode = true;
            }

            if (!searchByeNCode)
            {
                if (manageTeacherFnameTxtbx.Text != "")
                {
                    query2 = query2 + " t_FName LIKE '%" + manageTeacherFnameTxtbx.Text + "%' AND";
                }
                if (manageTeacherLnameTxtbx.Text != "")
                {
                    query2 = query2 + " t_LName LIKE '%" + manageTeacherLnameTxtbx.Text + "%' AND";
                }
                if (manageTeacherExecutorFacultyCb.Text != "")
                {
                    query2 = query2 + " t_Faculty = '" + manageTeacherExecutorFacultyCb.Text + "' AND";
                }
                if (manageTeacherExecutorEgroupCb.Text != "")
                {
                    query2 = query2 + " t_Group = '" + manageTeacherExecutorEgroupCb.Text + "' AND";
                }
                if (manageTeacherExecutorEDegCb.Text != "")
                {
                    query2 = query2 + " t_EDeg = '" + manageTeacherExecutorEDegCb.Text + "' AND";
                }
                if (manageTeacherExecutorMobileTxtbx.Text != "")
                {
                    query2 = query2 + " t_Mobile LIKE '%" + manageTeacherExecutorMobileTxtbx.Text + "%' AND";
                }
                if (manageTeacherExecutorEmailTxtbx.Text != "")
                {
                    query2 = query2 + " t_Email LIKE '%" + manageTeacherExecutorEmailTxtbx.Text + "%' AND";
                }
                if (manageTeacherExecutorTelTxtbx.Text != "")
                {
                    query2 = query2 + " t_Tel1 LIKE '%" + manageTeacherExecutorTelTxtbx.Text + "%' AND";
                }
                if (manageTeacherExecutorTel2Txtbx.Text != "")
                {
                    query2 = query2 + " t_Tel2 LIKE '%" + manageTeacherExecutorTel2Txtbx.Text + "%' AND";
                }


            }

            query2 = query2.Substring(0, query2.Length - 3);


            if (query2 != "SELECT TOP " + pageSize + " * FROM TeacherTable WHE")
            {
                manageTeacherShowDgv.Columns.Clear();
                query2 = query2.Replace("TOP " + pageSize + " *", "COUNT(*)");
                TotalPage = dbh.totalPage(query2);
                query2 = query2.Replace("COUNT(*)", "TOP " + pageSize + " *");

                CurrentPageIndex = 1;
                manageTeacherNavigationCurrentPageTxtbx.Text = CurrentPageIndex.ToString();
                dbh.manageTeacherQuery = query2;
                dbh.dataGridViewUpdate3(manageTeacherShowDgv, teacherBindingSource, dbh.manageTeacherQuery, pageSize, CurrentPageIndex);
                manageTeacherExecutorNcodeTxtbx.BackColor = Color.White;
                manageTeacherExecutorNcodeTxtbx.Focus();


                manageTeacherNavigationFirstPageBtn.Enabled = true;
                manageTeacherNavigationNextPageBtn.Enabled = true;
                manageTeacherNavigationLastPageBtn.Enabled = true;
                manageTeacherNavigationPreviousPageBtn.Enabled = true;
                manageTeacherNavigationCurrentPageTxtbx.Enabled = true;
                manageTeacherNavigationReturnBtn.Enabled = false;

                ////

                // dbh.dataGridViewUpdate3(manageTeacherShowDgv, teacherBindingSource, dbh.manageTeacherQuery , pageSize,CurrentPageIndex);

            }
        }

        private void Form1_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Login l = new Login();
            this.Hide();
        }

        private void exitTab_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            this.Hide();
        }

        private void iconMenuPanel_MouseEnter(object sender, EventArgs e)
        {
            if(menuSlideRb.Checked)
                detailedMenu();
        }

        private void homePanel_MouseEnter(object sender, EventArgs e)
        {
            if (menuSlideRb.Checked)
                iconMenu();
        }

        private void wait_bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            w.Hide();
        }

        private void form_initializer()
        {
            w = new Waiting();
            //w.i = 1;
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

            addProposalExecutorEDegCb.Items.Clear();
            comboList = dbh.getEDeg();
            foreach (String eDegree in comboList)
            {
                addProposalExecutorEDegCb.Items.Add(eDegree);
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

            editProposalExecutorEDegCb.Items.Clear();
            comboList = dbh.getEDeg();
            foreach (String eDegree in comboList)
            {
                editProposalExecutorEDegCb.Items.Add(eDegree);
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





            //*************************************************************************\\
            //                                app setting                              \\
            //*************************************************************************\\
            appSettingSenderNameTxtbx.Text = dbh.getSenderName();
            appSettingSenderGradeTxtbx.Text = dbh.getSenderGrade();

            //*************************************************************************\\
            //                               app setting                               \\
            //*************************************************************************\\

            this.Enabled = true;
            iconMenuPanel.Visible = true;
            homePanel.Visible = true;
            homeAapInfoGp.Visible = true;
            homeTimeDateGp.Visible = true;
            w.i = -1;

            //*************************************************************************\\
            //                        manage color prefrence                           \\
            //*************************************************************************\\
            if(loginUser.U_Color != "")
            {
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
                iconMenuPanel.BackColor = System.Drawing.ColorTranslator.FromHtml(loginUser.U_Color);
                // iconMenuPanel.BackColor = System.Drawing.ColorTranslator.FromHtml(loginUser.U_Color);
            }
            //*************************************************************************\\
            //                        manage color prefrence                           \\
            //*************************************************************************\\
        }

        private void menuHomeBtn_Click(object sender, EventArgs e)
        {
            mainPage.SelectedTabIndex = 0;
            menuHomeBtn.Checked = true;
            menuAddProposalBtn.Checked = false;
            menuSearchProposalBtn.Checked = false;
            menuManageProposalBtn.Checked = false;
            menuManageTeacherBtn.Checked = false;
            menuManageUserBtn.Checked = false;
            menuAppSettingBtn.Checked = false;
            menuPersonalSettingBtn.Checked = false;
            menuAboutUsBtn.Checked = false;
            menuSysLogBtn.Checked = false;
            menuExitBtn.Checked = false;
        }

        private void menuAddProposalBtn_Click(object sender, EventArgs e)
        {
            mainPage.SelectedTabIndex = 1;
            
            menuHomeBtn.Checked = false;
            menuAddProposalBtn.Checked = true;
            menuSearchProposalBtn.Checked = false;
            menuManageProposalBtn.Checked = false;
            menuManageTeacherBtn.Checked = false;
            menuManageUserBtn.Checked = false;
            menuAppSettingBtn.Checked = false;
            menuPersonalSettingBtn.Checked = false;
            menuAboutUsBtn.Checked = false;
            menuSysLogBtn.Checked = false;
            menuExitBtn.Checked = false;
        }

        private void menuSearchProposalBtn_Click(object sender, EventArgs e)
        {
            mainPage.SelectedTabIndex = 2;

            menuHomeBtn.Checked = false;
            menuAddProposalBtn.Checked = false;
            menuSearchProposalBtn.Checked = true;
            menuManageProposalBtn.Checked = false;
            menuManageTeacherBtn.Checked = false;
            menuManageUserBtn.Checked = false;
            menuAppSettingBtn.Checked = false;
            menuPersonalSettingBtn.Checked = false;
            menuAboutUsBtn.Checked = false;
            menuSysLogBtn.Checked = false;
            menuExitBtn.Checked = false;
        }

        private void menuManageProposalBtn_Click(object sender, EventArgs e)
        {
            mainPage.SelectedTabIndex = 3;

            menuHomeBtn.Checked = false;
            menuAddProposalBtn.Checked = false;
            menuSearchProposalBtn.Checked = false;
            menuManageProposalBtn.Checked = true;
            menuManageTeacherBtn.Checked = false;
            menuManageUserBtn.Checked = false;
            menuAppSettingBtn.Checked = false;
            menuPersonalSettingBtn.Checked = false;
            menuAboutUsBtn.Checked = false;
            menuSysLogBtn.Checked = false;
            menuExitBtn.Checked = false;
        }

        private void menuManageTeacherBtn_Click(object sender, EventArgs e)
        {
            mainPage.SelectedTabIndex = 4;

            menuHomeBtn.Checked = false;
            menuAddProposalBtn.Checked = false;
            menuSearchProposalBtn.Checked = false;
            menuManageProposalBtn.Checked = false;
            menuManageTeacherBtn.Checked = true;
            menuManageUserBtn.Checked = false;
            menuAppSettingBtn.Checked = false;
            menuPersonalSettingBtn.Checked = false;
            menuAboutUsBtn.Checked = false;
            menuSysLogBtn.Checked = false;
            menuExitBtn.Checked = false;
        }

        private void menuManageUserBtn_Click(object sender, EventArgs e)
        {
            mainPage.SelectedTabIndex = 5;

            menuHomeBtn.Checked = false;
            menuAddProposalBtn.Checked = false;
            menuSearchProposalBtn.Checked = false;
            menuManageProposalBtn.Checked = false;
            menuManageTeacherBtn.Checked = false;
            menuManageUserBtn.Checked = true;
            menuAppSettingBtn.Checked = false;
            menuPersonalSettingBtn.Checked = false;
            menuAboutUsBtn.Checked = false;
            menuSysLogBtn.Checked = false;
            menuExitBtn.Checked = false;
        }

        private void menuAppSettingBtn_Click(object sender, EventArgs e)
        {
            mainPage.SelectedTabIndex = 6;

            menuHomeBtn.Checked = false;
            menuAddProposalBtn.Checked = false;
            menuSearchProposalBtn.Checked = false;
            menuManageProposalBtn.Checked = false;
            menuManageTeacherBtn.Checked = false;
            menuManageUserBtn.Checked = false;
            menuAppSettingBtn.Checked = true;
            menuPersonalSettingBtn.Checked = false;
            menuAboutUsBtn.Checked = false;
            menuSysLogBtn.Checked = false;
            menuExitBtn.Checked = false;
        }

        private void menuPersonalSettingBtn_Click(object sender, EventArgs e)
        {
            mainPage.SelectedTabIndex = 7;

            menuHomeBtn.Checked = false;
            menuAddProposalBtn.Checked = false;
            menuSearchProposalBtn.Checked = false;
            menuManageProposalBtn.Checked = false;
            menuManageTeacherBtn.Checked = false;
            menuManageUserBtn.Checked = false;
            menuAppSettingBtn.Checked = false;
            menuPersonalSettingBtn.Checked = true;
            menuAboutUsBtn.Checked = false;
            menuSysLogBtn.Checked = false;
            menuExitBtn.Checked = false;
        }

        private void menuAboutUsBtn_Click(object sender, EventArgs e)
        {
            mainPage.SelectedTabIndex = 8;

            menuHomeBtn.Checked = false;
            menuAddProposalBtn.Checked = false;
            menuSearchProposalBtn.Checked = false;
            menuManageProposalBtn.Checked = false;
            menuManageTeacherBtn.Checked = false;
            menuManageUserBtn.Checked = false;
            menuAppSettingBtn.Checked = false;
            menuPersonalSettingBtn.Checked = false;
            menuAboutUsBtn.Checked = true;
            menuSysLogBtn.Checked = false;
            menuExitBtn.Checked = false;
        }

        private void menuSysLogBtn_Click(object sender, EventArgs e)
        {
            mainPage.SelectedTabIndex = 9;
            logDgv.Columns.Clear();
            TotalPage = dbh.totalLogPage("SELECT COUNT(*) FROM logTable");


            CurrentPageIndex = 1;
            logNavigationCurrentPageTxtbx.Text = CurrentPageIndex.ToString();
            dbh.logQuery = "SELECT TOP 30 * FROM logTable WHERE 1=1 ";
            dbh.dataGridViewUpdate3(logDgv, logBindingSource, dbh.logQuery, 30, CurrentPageIndex);



            logNavigationFirstPageBtn.Enabled = true;
            logNavigationNextPageBtn.Enabled = true;
            logNavigationLastPageBtn.Enabled = true;
            logNavigationPreviousPageBtn.Enabled = true;
            logNavigationCurrentPageTxtbx.Enabled = true;
            logNavigationReturnBtn.Enabled = false;

            menuHomeBtn.Checked = false;
            menuAddProposalBtn.Checked = false;
            menuSearchProposalBtn.Checked = false;
            menuManageProposalBtn.Checked = false;
            menuManageTeacherBtn.Checked = false;
            menuManageUserBtn.Checked = false;
            menuAppSettingBtn.Checked = false;
            menuPersonalSettingBtn.Checked = false;
            menuAboutUsBtn.Checked = false;
            menuSysLogBtn.Checked = true;
            menuExitBtn.Checked = false;
        }

        private void menuExitBtn_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            this.Hide();

            menuHomeBtn.Checked = false;
            menuAddProposalBtn.Checked = false;
            menuSearchProposalBtn.Checked = false;
            menuManageProposalBtn.Checked = false;
            menuManageTeacherBtn.Checked = false;
            menuManageUserBtn.Checked = false;
            menuAppSettingBtn.Checked = false;
            menuPersonalSettingBtn.Checked = false;
            menuAboutUsBtn.Checked = false;
            menuSysLogBtn.Checked = false;
            menuExitBtn.Checked = true;
        }

        private void menuIconRb_Click(object sender, EventArgs e)
        {
            iconMenu();
        }

        private void personalSettingRegisterBtn_Click(object sender, EventArgs e)
        {
            if (loginUser.U_Password == dbh.hashPass(personalSettingOldPasswordTxtbx.Text))
            {
                if (personalSettingNewPasswordTxtbx.Text == personalSettingRepeatPasswordTxtbx.Text)
                {
                    dbh.changePassword(loginUser.U_NCode, dbh.hashPass(personalSettingNewPasswordTxtbx.Text), myDateTime.ToString());
                    loginUser.U_Password = dbh.hashPass(personalSettingNewPasswordTxtbx.Text);
                    personalSettingClearBtn.PerformClick();
                    PopUp p1 = new PopUp("تغییر رمز عبور", "رمز عبور با موفقیت تغییر یافت", "تایید", "", "", "success");
                    p1.ShowDialog();
                }
                else
                {
                    PopUp p1 = new PopUp("خطا", "رمز جدید و تکرار آن یکسان نیستند.", "تایید", "", "", "error");
                    p1.ShowDialog();
                    personalSettingRepeatPasswordTxtbx.Focus();
                }
            }
            else
            {
                PopUp p = new PopUp("خطا", "رمز فعلی شما نادرست است .", "تایید", "", "", "error");
                p.ShowDialog();
                personalSettingOldPasswordTxtbx.Focus();
            }
            
        }

        private void addProposalShowDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //addProposalShowDgv.Columns[e.Column.Index].SortMode = DataGridViewColumnSortMode.NotSortable;
            try
                {

                    if (!addProposalIsWatchingEdition)
                    {
                        if (e.ColumnIndex == 18)
                        {
                            Proposal proposal = new Proposal();

                            proposal.Index = long.Parse(addProposalShowDgv.Rows[e.RowIndex].Cells["index"].Value.ToString());
                            proposal.PersianTitle = addProposalShowDgv.Rows[e.RowIndex].Cells["persianTitle"].Value.ToString();
                            proposal.EngTitle = addProposalShowDgv.Rows[e.RowIndex].Cells["engTitle"].Value.ToString();
                            proposal.KeyWord = addProposalShowDgv.Rows[e.RowIndex].Cells["keyword"].Value.ToString();
                            proposal.Executor2 = addProposalShowDgv.Rows[e.RowIndex].Cells["executor2"].Value.ToString();
                            proposal.CoExecutor = addProposalShowDgv.Rows[e.RowIndex].Cells["coExecutor"].Value.ToString();
                            proposal.StartDate = addProposalShowDgv.Rows[e.RowIndex].Cells["hijriDate"].Value.ToString();
                            proposal.Duration = Int32.Parse(addProposalShowDgv.Rows[e.RowIndex].Cells["duration"].Value.ToString());
                            proposal.ProcedureType = addProposalShowDgv.Rows[e.RowIndex].Cells["procedureType"].Value.ToString();
                            proposal.ProposalType = addProposalShowDgv.Rows[e.RowIndex].Cells["proposalType"].Value.ToString();
                            proposal.PropertyType = addProposalShowDgv.Rows[e.RowIndex].Cells["propertyType"].Value.ToString();
                            proposal.RegisterType = addProposalShowDgv.Rows[e.RowIndex].Cells["registerType"].Value.ToString();
                            proposal.Employer = Int32.Parse(addProposalShowDgv.Rows[e.RowIndex].Cells["employer"].Value.ToString());
                            proposal.Value = long.Parse(addProposalShowDgv.Rows[e.RowIndex].Cells["value"].Value.ToString());
                            proposal.Edition = 0;
                            proposal.Status = addProposalShowDgv.Rows[e.RowIndex].Cells["status"].Value.ToString();
                            proposal.FileName = addProposalShowDgv.Rows[e.RowIndex].Cells["fileName"].Value.ToString();
                            proposal.Executor = long.Parse(addProposalShowDgv.Rows[e.RowIndex].Cells["executor"].Value.ToString());
                            proposal.Registrant = long.Parse(addProposalShowDgv.Rows[e.RowIndex].Cells["registrant"].Value.ToString());
                            proposal.RegistrantName =addProposalShowDgv.Rows[e.RowIndex].Cells["registrantBtn"].Value.ToString();
                            proposal.TeacherFullName = addProposalShowDgv.Rows[e.RowIndex].Cells["executorFullName"].Value.ToString();
                            Detail detail = new Detail(proposal, loginUser.U_NCode);
                            detail.ShowDialog();

                        }
                        if (e.ColumnIndex == 19)
                        {

                            Proposal proposal = new Proposal();

                            proposal.Index = long.Parse(addProposalShowDgv.Rows[e.RowIndex].Cells["index"].Value.ToString());

                            addProposalPersianTitleTxtbx.Text = addProposalShowDgv.Rows[e.RowIndex].Cells["persianTitle"].Value.ToString();
                            addProposalEnglishTitleTxtbx.Text = addProposalShowDgv.Rows[e.RowIndex].Cells["engTitle"].Value.ToString();
                            addProposalKeywordsTxtbx.Text = addProposalShowDgv.Rows[e.RowIndex].Cells["keyword"].Value.ToString();
                            addProposalExecutor2Txtbx.Text = addProposalShowDgv.Rows[e.RowIndex].Cells["executor2"].Value.ToString();
                            addProposalCoexecutorTxtbx.Text = addProposalShowDgv.Rows[e.RowIndex].Cells["coExecutor"].Value.ToString();
                            addProposalDurationTxtbx.Text = addProposalShowDgv.Rows[e.RowIndex].Cells["duration"].Value.ToString();
                            addProposalProcedureTypeCb.Text = addProposalShowDgv.Rows[e.RowIndex].Cells["procedureType"].Value.ToString();
                            addProposalProposalTypeCb.Text = addProposalShowDgv.Rows[e.RowIndex].Cells["proposalType"].Value.ToString();
                            addProposalPropertyTypeCb.Text = addProposalShowDgv.Rows[e.RowIndex].Cells["propertyType"].Value.ToString();
                            addProposalRegisterTypeCb.Text = addProposalShowDgv.Rows[e.RowIndex].Cells["registerType"].Value.ToString();
                            addProposalOrganizationNumberCb.Text = addProposalShowDgv.Rows[e.RowIndex].Cells["employer"].Value.ToString();
                            addProposalValueTxtbx.Text = addProposalShowDgv.Rows[e.RowIndex].Cells["value"].Value.ToString();
                            addProposalStatusCb.Text = addProposalShowDgv.Rows[e.RowIndex].Cells["status"].Value.ToString();
                            addProposalExecutorNcodeTxtbx.Text = addProposalShowDgv.Rows[e.RowIndex].Cells["executor"].Value.ToString();
                            addProposalStartdateTimeInput.GeoDate = DateTime.Parse(addProposalShowDgv.Rows[e.RowIndex].Cells["startDate"].Value.ToString());

                            addProposalShowDgv.Columns.Clear();
                            dbh.dataGridViewUpdate2(addProposalShowDgv, addProposalBindingSource, "SELECT * FROM editionTable WHERE [index] = '" + proposal.Index + "'");
                            addProposalShowDgv.Columns["editionBtn"].Visible = false;
                            addProposalShowDgv.Columns["edition"].HeaderText = "شماره نسخه";
                            addProposalShowDgv.Columns["edition"].DisplayIndex = 3;
                            addProposalShowDgv.Columns["edition"].Frozen = true;

                            addProposalNavigationFirstPageBtn.Enabled = false;
                            addProposalNavigationNextPageBtn.Enabled = false;
                            addProposalNavigationLastPageBtn.Enabled = false;
                            addProposalNavigationPreviousPageBtn.Enabled = false;
                            addProposalNavigationCurrentPageTxtbx.Enabled = false;
                            addProposalNavigationReturnBtn.Enabled = true;
                            editionProposalIndex = proposal.Index;
                            addProposalIsWatchingEdition = true;




                        }

                    }
                    else if (addProposalIsWatchingEdition)
                    {
                   // MessageBox.Show(addProposalShowDgv.Columns["detailBtn"].DisplayIndex + " ,"+ e.ColumnIndex);
                    if (e.ColumnIndex == 19)
                    {
                       // MessageBox.Show(editProposalShowDgv.Columns["detailBtn"].DisplayIndex + "34334");
                        Proposal proposal = new Proposal();

                            proposal.Index = long.Parse(addProposalShowDgv.Rows[e.RowIndex].Cells["index"].Value.ToString());
                            proposal.PersianTitle = addProposalShowDgv.Rows[e.RowIndex].Cells["persianTitle"].Value.ToString();
                            proposal.EngTitle = addProposalShowDgv.Rows[e.RowIndex].Cells["engTitle"].Value.ToString();
                            proposal.KeyWord = addProposalShowDgv.Rows[e.RowIndex].Cells["keyword"].Value.ToString();
                            proposal.Executor2 = addProposalShowDgv.Rows[e.RowIndex].Cells["executor2"].Value.ToString();
                            proposal.CoExecutor = addProposalShowDgv.Rows[e.RowIndex].Cells["coExecutor"].Value.ToString();
                            proposal.StartDate = addProposalShowDgv.Rows[e.RowIndex].Cells["hijriDate"].Value.ToString();
                            proposal.Duration = Int32.Parse(addProposalShowDgv.Rows[e.RowIndex].Cells["duration"].Value.ToString());
                            proposal.ProcedureType = addProposalShowDgv.Rows[e.RowIndex].Cells["procedureType"].Value.ToString();
                            proposal.ProposalType = addProposalShowDgv.Rows[e.RowIndex].Cells["proposalType"].Value.ToString();
                            proposal.PropertyType = addProposalShowDgv.Rows[e.RowIndex].Cells["propertyType"].Value.ToString();
                            proposal.RegisterType = addProposalShowDgv.Rows[e.RowIndex].Cells["registerType"].Value.ToString();
                            proposal.Employer = Int32.Parse(addProposalShowDgv.Rows[e.RowIndex].Cells["employer"].Value.ToString());
                            proposal.Value = long.Parse(addProposalShowDgv.Rows[e.RowIndex].Cells["value"].Value.ToString());
                            proposal.Edition = int.Parse(addProposalShowDgv.Rows[e.RowIndex].Cells["edition"].Value.ToString());
                            proposal.Status = addProposalShowDgv.Rows[e.RowIndex].Cells["status"].Value.ToString();
                            proposal.FileName = addProposalShowDgv.Rows[e.RowIndex].Cells["fileName"].Value.ToString();
                            proposal.Executor = long.Parse(addProposalShowDgv.Rows[e.RowIndex].Cells["executor"].Value.ToString());
                            proposal.Registrant = long.Parse(addProposalShowDgv.Rows[e.RowIndex].Cells["registrant"].Value.ToString());
                            proposal.RegistrantName = addProposalShowDgv.Rows[e.RowIndex].Cells["registrantBtn"].Value.ToString();
                            proposal.TeacherFullName = addProposalShowDgv.Rows[e.RowIndex].Cells["executorFullName"].Value.ToString();

                            Detail detail = new Detail(proposal, loginUser.U_NCode);
                            detail.ShowDialog();

                        }
                    }
                }
                catch (ArgumentOutOfRangeException) { }
            
        }

        private void searchProposalShowDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!searchProposalIsWatchingEdition)
                {
                    if (e.ColumnIndex == 18)
                    {
                        Proposal proposal = new Proposal();

                        proposal.Index = long.Parse(searchProposalShowDgv.Rows[e.RowIndex].Cells["index"].Value.ToString());
                        proposal.PersianTitle = searchProposalShowDgv.Rows[e.RowIndex].Cells["persianTitle"].Value.ToString();
                        proposal.EngTitle = searchProposalShowDgv.Rows[e.RowIndex].Cells["engTitle"].Value.ToString();
                        proposal.KeyWord = searchProposalShowDgv.Rows[e.RowIndex].Cells["keyword"].Value.ToString();
                        proposal.Executor2 = searchProposalShowDgv.Rows[e.RowIndex].Cells["executor2"].Value.ToString();
                        proposal.CoExecutor = searchProposalShowDgv.Rows[e.RowIndex].Cells["coExecutor"].Value.ToString();
                        proposal.StartDate = searchProposalShowDgv.Rows[e.RowIndex].Cells["hijriDate"].Value.ToString();
                        proposal.Duration = Int32.Parse(searchProposalShowDgv.Rows[e.RowIndex].Cells["duration"].Value.ToString());
                        proposal.ProcedureType = searchProposalShowDgv.Rows[e.RowIndex].Cells["procedureType"].Value.ToString();
                        proposal.ProposalType = searchProposalShowDgv.Rows[e.RowIndex].Cells["proposalType"].Value.ToString();
                        proposal.PropertyType = searchProposalShowDgv.Rows[e.RowIndex].Cells["propertyType"].Value.ToString();
                        proposal.RegisterType = searchProposalShowDgv.Rows[e.RowIndex].Cells["registerType"].Value.ToString();
                        proposal.Employer = Int32.Parse(searchProposalShowDgv.Rows[e.RowIndex].Cells["employer"].Value.ToString());
                        proposal.Edition = 0;
                        proposal.Value = long.Parse(searchProposalShowDgv.Rows[e.RowIndex].Cells["value"].Value.ToString());
                        proposal.Status = searchProposalShowDgv.Rows[e.RowIndex].Cells["status"].Value.ToString();
                        proposal.FileName = searchProposalShowDgv.Rows[e.RowIndex].Cells["fileName"].Value.ToString();
                        proposal.Executor = long.Parse(searchProposalShowDgv.Rows[e.RowIndex].Cells["executor"].Value.ToString());
                        proposal.Registrant = long.Parse(searchProposalShowDgv.Rows[e.RowIndex].Cells["registrant"].Value.ToString());
                        proposal.RegistrantName = searchProposalShowDgv.Rows[e.RowIndex].Cells["registrantBtn"].Value.ToString();
                        proposal.TeacherFullName = searchProposalShowDgv.Rows[e.RowIndex].Cells["executorFullName"].Value.ToString();
                        Detail detail = new Detail(proposal, loginUser.U_NCode);
                        detail.ShowDialog();
                    }
                    if (e.ColumnIndex == 19)
                    {

                        Proposal proposal = new Proposal();

                        proposal.Index = long.Parse(searchProposalShowDgv.Rows[e.RowIndex].Cells["index"].Value.ToString());

                        searchProposalShowDgv.Columns.Clear();
                        dbh.dataGridViewUpdate2(searchProposalShowDgv, searchProposalBindingSource, "SELECT * FROM editionTable WHERE [index] = '" + proposal.Index + "'");
                        //searchProposalShowDgv.Columns["navToAdd"].Visible = false;
                        //searchProposalShowDgv.Columns["navToEdit"].Visible = false;
                        searchProposalShowDgv.Columns["editionBtn"].Visible = false;
                        searchProposalShowDgv.Columns["edition"].HeaderText = "شماره نسخه";
                        searchProposalShowDgv.Columns["edition"].DisplayIndex = 3;
                        searchProposalShowDgv.Columns["edition"].Frozen = true;

                        editionProposalIndex = proposal.Index;
                        searchProposalIsWatchingEdition = true;

                        searchProposalNavigationFirstPageBtn.Enabled = false;
                        searchProposalNavigationNextPageBtn.Enabled = false;
                        searchProposalNavigationLastPageBtn.Enabled = false;
                        searchProposalNavigationPreviousPageBtn.Enabled = false;
                        searchProposalNavigationCurrentPageTxtbx.Enabled = false;
                        searchProposalNavigationReturnBtn.Enabled = true;
                    }

                    if (e.ColumnIndex == 21)
                    {

                        Proposal proposal = new Proposal();

                        proposal.Index = long.Parse(searchProposalShowDgv.Rows[e.RowIndex].Cells["index"].Value.ToString());
                        proposal.PersianTitle = searchProposalShowDgv.Rows[e.RowIndex].Cells["persianTitle"].Value.ToString();
                        proposal.EngTitle = searchProposalShowDgv.Rows[e.RowIndex].Cells["engTitle"].Value.ToString();
                        proposal.KeyWord = searchProposalShowDgv.Rows[e.RowIndex].Cells["keyword"].Value.ToString();
                        proposal.Executor2 = searchProposalShowDgv.Rows[e.RowIndex].Cells["executor2"].Value.ToString();
                        proposal.CoExecutor = searchProposalShowDgv.Rows[e.RowIndex].Cells["coExecutor"].Value.ToString();
                        proposal.StartDate = searchProposalShowDgv.Rows[e.RowIndex].Cells["hijriDate"].Value.ToString();
                        proposal.Duration = Int32.Parse(searchProposalShowDgv.Rows[e.RowIndex].Cells["duration"].Value.ToString());
                        proposal.ProcedureType = searchProposalShowDgv.Rows[e.RowIndex].Cells["procedureType"].Value.ToString();
                        proposal.ProposalType = searchProposalShowDgv.Rows[e.RowIndex].Cells["proposalType"].Value.ToString();
                        proposal.PropertyType = searchProposalShowDgv.Rows[e.RowIndex].Cells["propertyType"].Value.ToString();
                        proposal.RegisterType = searchProposalShowDgv.Rows[e.RowIndex].Cells["registerType"].Value.ToString();
                        proposal.Employer = Int32.Parse(searchProposalShowDgv.Rows[e.RowIndex].Cells["employer"].Value.ToString());
                        proposal.Edition = 0;
                        proposal.Value = long.Parse(searchProposalShowDgv.Rows[e.RowIndex].Cells["value"].Value.ToString());
                        proposal.Status = searchProposalShowDgv.Rows[e.RowIndex].Cells["status"].Value.ToString();
                        proposal.FileName = searchProposalShowDgv.Rows[e.RowIndex].Cells["fileName"].Value.ToString();
                        proposal.Executor = long.Parse(searchProposalShowDgv.Rows[e.RowIndex].Cells["executor"].Value.ToString());
                        proposal.Registrant = long.Parse(searchProposalShowDgv.Rows[e.RowIndex].Cells["registrant"].Value.ToString());
                        proposal.RegistrantName = searchProposalShowDgv.Rows[e.RowIndex].Cells["registrantBtn"].Value.ToString();
                        proposal.TeacherFullName = searchProposalShowDgv.Rows[e.RowIndex].Cells["executorFullName"].Value.ToString();

                        if (proposal.Registrant == loginUser.U_NCode || loginUser.U_IsAdmin == 1)
                        {
                            if (loginUser.CanEditProposal == 1 || loginUser.U_IsAdmin == 1)
                            {
                                menuManageProposalBtn.PerformClick();
                                editProposalShowDgv.Columns.Clear();
                                if (manageProposalIsWatchingEdition)
                                {
                                    editProposalClearBtn.PerformClick();
                                }
                                TotalPage = 1;
                                CurrentPageIndex = 1;
                                manageProposalNavigationCurrentPageTxtbx.Text = CurrentPageIndex.ToString();
                                dbh.editProposalQuery = "SELECT * FROM proposalTable WHERE [index] = '" + proposal.Index + "'";
                                dbh.dataGridViewUpdate3(editProposalShowDgv, editProposalBindingSource, dbh.editProposalQuery, pageSize, CurrentPageIndex);
                                editProposalExecutorNcodeTxtbx.BackColor = Color.White;
                                editProposalExecutorNcodeTxtbx.Focus();


                                manageProposalNavigationFirstPageBtn.Enabled = true;
                                manageProposalNavigationNextPageBtn.Enabled = true;
                                manageProposalNavigationLastPageBtn.Enabled = true;
                                manageProposalNavigationPreviousPageBtn.Enabled = true;
                                manageProposalNavigationCurrentPageTxtbx.Enabled = true;
                                manageProposalNavigationReturnBtn.Enabled = false;

                                editProposalShowDgv.CurrentCell = editProposalShowDgv.Rows[0].Cells[5];
                                editProposalShowDgv_CellClick(this.editProposalShowDgv, new DataGridViewCellEventArgs(0, 0));
                            }
                            else
                            {
                                string context = "شما دسترسی برای تغییر پروپوزال ها را ندارید";
                                Alert alert = new Alert(context, "darkred", 5);
                            }
                        }
                        else
                        {
                            string context = "شما دسترسی برای تغییر این پروپوزال را ندارید";
                            Alert alert = new Alert(context, "darkred", 5);
                        }



                    }
                    if (e.ColumnIndex == 22)
                    {

                        Proposal proposal = new Proposal();

                        proposal.Index = long.Parse(searchProposalShowDgv.Rows[e.RowIndex].Cells["index"].Value.ToString());
                        proposal.PersianTitle = searchProposalShowDgv.Rows[e.RowIndex].Cells["persianTitle"].Value.ToString();
                        proposal.EngTitle = searchProposalShowDgv.Rows[e.RowIndex].Cells["engTitle"].Value.ToString();
                        proposal.KeyWord = searchProposalShowDgv.Rows[e.RowIndex].Cells["keyword"].Value.ToString();
                        proposal.Executor2 = searchProposalShowDgv.Rows[e.RowIndex].Cells["executor2"].Value.ToString();
                        proposal.CoExecutor = searchProposalShowDgv.Rows[e.RowIndex].Cells["coExecutor"].Value.ToString();
                        proposal.StartDate = searchProposalShowDgv.Rows[e.RowIndex].Cells["hijriDate"].Value.ToString();
                        proposal.Duration = Int32.Parse(searchProposalShowDgv.Rows[e.RowIndex].Cells["duration"].Value.ToString());
                        proposal.ProcedureType = searchProposalShowDgv.Rows[e.RowIndex].Cells["procedureType"].Value.ToString();
                        proposal.ProposalType = searchProposalShowDgv.Rows[e.RowIndex].Cells["proposalType"].Value.ToString();
                        proposal.PropertyType = searchProposalShowDgv.Rows[e.RowIndex].Cells["propertyType"].Value.ToString();
                        proposal.RegisterType = searchProposalShowDgv.Rows[e.RowIndex].Cells["registerType"].Value.ToString();
                        proposal.Employer = Int32.Parse(searchProposalShowDgv.Rows[e.RowIndex].Cells["employer"].Value.ToString());
                        proposal.Edition = 0;
                        proposal.Value = long.Parse(searchProposalShowDgv.Rows[e.RowIndex].Cells["value"].Value.ToString());
                        proposal.Status = searchProposalShowDgv.Rows[e.RowIndex].Cells["status"].Value.ToString();
                        proposal.FileName = searchProposalShowDgv.Rows[e.RowIndex].Cells["fileName"].Value.ToString();
                        proposal.Executor = long.Parse(searchProposalShowDgv.Rows[e.RowIndex].Cells["executor"].Value.ToString());
                        proposal.Registrant = long.Parse(searchProposalShowDgv.Rows[e.RowIndex].Cells["registrant"].Value.ToString());
                        proposal.RegistrantName = searchProposalShowDgv.Rows[e.RowIndex].Cells["registrantBtn"].Value.ToString();
                        proposal.TeacherFullName = searchProposalShowDgv.Rows[e.RowIndex].Cells["executorFullName"].Value.ToString();


                        if (proposal.Registrant == loginUser.U_NCode || loginUser.U_IsAdmin == 1)
                        {
                            if (loginUser.CanAddProposal == 1 || loginUser.U_IsAdmin == 1)
                            {
                                menuAddProposalBtn.PerformClick();
                                addProposalShowDgv.Columns.Clear();
                                if (addProposalIsWatchingEdition)
                                {
                                    addProposalClearBtn.PerformClick();
                                }
                                TotalPage = 1;
                                CurrentPageIndex = 1;
                                addProposalNavigationCurrentPageTxtbx.Text = CurrentPageIndex.ToString();
                                dbh.addProposalQuery = "SELECT * FROM proposalTable WHERE [index] = '" + proposal.Index + "'";
                                dbh.dataGridViewUpdate3(addProposalShowDgv, addProposalBindingSource, dbh.addProposalQuery, pageSize, CurrentPageIndex);
                                addProposalExecutorNcodeTxtbx.BackColor = Color.White;
                                addProposalExecutorNcodeTxtbx.Focus();


                                addProposalNavigationFirstPageBtn.Enabled = true;
                                addProposalNavigationNextPageBtn.Enabled = true;
                                addProposalNavigationLastPageBtn.Enabled = true;
                                addProposalNavigationPreviousPageBtn.Enabled = true;
                                addProposalNavigationCurrentPageTxtbx.Enabled = true;
                                addProposalNavigationReturnBtn.Enabled = false;

                                addProposalShowDgv.CurrentCell = addProposalShowDgv.Rows[0].Cells["editionBtn"];

                                addProposalShowDgv_CellClick(this.addProposalShowDgv, new DataGridViewCellEventArgs(addProposalShowDgv.CurrentCell.ColumnIndex, addProposalShowDgv.CurrentCell.RowIndex));
                            }
                            else
                            {
                                string context = "شما دسترسی برای افزودن پروپوزال ها را ندارید.";
                                Alert alert = new Alert(context, "darkred", 5);
                            }
                        }
                        else
                        {
                            string context = " شما دسترسی برای افزودن نسخه این پروپوزال را ندارید";
                            Alert alert = new Alert(context, "darkred", 5);
                        }

                    }


                }
                else if (searchProposalIsWatchingEdition)
                {
                    if (e.ColumnIndex == 19)
                    {
                        Proposal proposal = new Proposal();

                        proposal.Index = long.Parse(searchProposalShowDgv.Rows[e.RowIndex].Cells["index"].Value.ToString());
                        proposal.PersianTitle = searchProposalShowDgv.Rows[e.RowIndex].Cells["persianTitle"].Value.ToString();
                        proposal.EngTitle = searchProposalShowDgv.Rows[e.RowIndex].Cells["engTitle"].Value.ToString();
                        proposal.KeyWord = searchProposalShowDgv.Rows[e.RowIndex].Cells["keyword"].Value.ToString();
                        proposal.Executor2 = searchProposalShowDgv.Rows[e.RowIndex].Cells["executor2"].Value.ToString();
                        proposal.CoExecutor = searchProposalShowDgv.Rows[e.RowIndex].Cells["coExecutor"].Value.ToString();
                        proposal.StartDate = searchProposalShowDgv.Rows[e.RowIndex].Cells["hijriDate"].Value.ToString();
                        proposal.Duration = Int32.Parse(searchProposalShowDgv.Rows[e.RowIndex].Cells["duration"].Value.ToString());
                        proposal.ProcedureType = searchProposalShowDgv.Rows[e.RowIndex].Cells["procedureType"].Value.ToString();
                        proposal.ProposalType = searchProposalShowDgv.Rows[e.RowIndex].Cells["proposalType"].Value.ToString();
                        proposal.PropertyType = searchProposalShowDgv.Rows[e.RowIndex].Cells["propertyType"].Value.ToString();
                        proposal.RegisterType = searchProposalShowDgv.Rows[e.RowIndex].Cells["registerType"].Value.ToString();
                        proposal.Employer = Int32.Parse(searchProposalShowDgv.Rows[e.RowIndex].Cells["employer"].Value.ToString());
                        proposal.Edition = int.Parse(searchProposalShowDgv.Rows[e.RowIndex].Cells["edition"].Value.ToString());
                        proposal.Value = long.Parse(searchProposalShowDgv.Rows[e.RowIndex].Cells["value"].Value.ToString());
                        proposal.Status = searchProposalShowDgv.Rows[e.RowIndex].Cells["status"].Value.ToString();
                        proposal.FileName = searchProposalShowDgv.Rows[e.RowIndex].Cells["fileName"].Value.ToString();
                        proposal.Executor = long.Parse(searchProposalShowDgv.Rows[e.RowIndex].Cells["executor"].Value.ToString());
                        proposal.Registrant = long.Parse(searchProposalShowDgv.Rows[e.RowIndex].Cells["registrant"].Value.ToString());
                        proposal.RegistrantName = searchProposalShowDgv.Rows[e.RowIndex].Cells["registrantBtn"].Value.ToString();
                        proposal.TeacherFullName = searchProposalShowDgv.Rows[e.RowIndex].Cells["executorFullName"].Value.ToString();
                        Detail detail = new Detail(proposal, loginUser.U_NCode);
                        detail.ShowDialog();

                    }
                }
            }
            catch (ArgumentOutOfRangeException) { }
            catch (ArgumentException) { }
            catch (Exception)
            {
            }

        }


        private void searchProposalNavigationFirstPageBtn_Click(object sender, EventArgs e)
        {
            searchProposalShowDgv.Columns.Clear();
            CurrentPageIndex = 1;
            searchProposalNavigationCurrentPageTxtbx.Text = CurrentPageIndex.ToString();
            dbh.dataGridViewUpdate3(searchProposalShowDgv, searchProposalBindingSource, dbh.searchProposalQuery, pageSize, CurrentPageIndex);
            searchProposalExecutorNCodeTxtbx.BackColor = Color.White;
            searchProposalExecutorNCodeTxtbx.Focus();

           // searchProposalShowAllBtn.Enabled = false;
        }

        private void searchProposalNavigationLastPageBtn_Click(object sender, EventArgs e)
        {
            searchProposalShowDgv.Columns.Clear();
            CurrentPageIndex = TotalPage;
            searchProposalNavigationCurrentPageTxtbx.Text = CurrentPageIndex.ToString();
            dbh.dataGridViewUpdate3(searchProposalShowDgv, searchProposalBindingSource, dbh.searchProposalQuery, pageSize, CurrentPageIndex);
            searchProposalExecutorNCodeTxtbx.BackColor = Color.White;
            searchProposalExecutorNCodeTxtbx.Focus();

           // searchProposalShowAllBtn.Enabled = false;
        }

        private void searchProposalNavigationPreviousPageBtn_Click(object sender, EventArgs e)
        {
            if (CurrentPageIndex > 1)
            {
                searchProposalShowDgv.Columns.Clear();
                CurrentPageIndex--;
                searchProposalNavigationCurrentPageTxtbx.Text = CurrentPageIndex.ToString();
                dbh.dataGridViewUpdate3(searchProposalShowDgv, searchProposalBindingSource, dbh.searchProposalQuery, pageSize, CurrentPageIndex);
                searchProposalExecutorNCodeTxtbx.BackColor = Color.White;
                searchProposalExecutorNCodeTxtbx.Focus();

              //  searchProposalShowAllBtn.Enabled = false;
            }
        }

        private void searchProposalNavigationNextPageBtn_Click(object sender, EventArgs e)
        {
            if (CurrentPageIndex < TotalPage)
            {
                searchProposalShowDgv.Columns.Clear();
                CurrentPageIndex++;
                searchProposalNavigationCurrentPageTxtbx.Text = CurrentPageIndex.ToString();
                dbh.dataGridViewUpdate3(searchProposalShowDgv, searchProposalBindingSource, dbh.searchProposalQuery, pageSize, CurrentPageIndex);
                searchProposalExecutorNCodeTxtbx.BackColor = Color.White;
                searchProposalExecutorNCodeTxtbx.Focus();

             //   searchProposalShowAllBtn.Enabled = false;
            }
        }

        private void addProposalNavigationReturnBtn_Click(object sender, EventArgs e)
        {
           
            if (dbh.addProposalQuery.Contains("executor"))
            {
                addProposalIsWatchingEdition = false;
                addProposalShowDgv.Columns.Clear();
                //addProposalShowDgv.DataSource = null;
                addProposalClearBtn.PerformClick();
                TotalPage = dbh.totalPage("SELECT COUNT(*) FROM proposalTable WHERE executor = '" + addProposalExecutorNcodeTxtbx.Text + "'");
                
                addProposalNavigationCurrentPageTxtbx.Text = CurrentPageIndex.ToString();
                dbh.addProposalQuery = "SELECT TOP " + pageSize + " * FROM proposalTable WHERE executor = '" + addProposalExecutorNcodeTxtbx.Text + "'";
                dbh.dataGridViewUpdate3(addProposalShowDgv, addProposalBindingSource, dbh.addProposalQuery, pageSize, CurrentPageIndex);

                addProposalNavigationFirstPageBtn.Enabled = true;
                addProposalNavigationNextPageBtn.Enabled = true;
                addProposalNavigationLastPageBtn.Enabled = true;
                addProposalNavigationPreviousPageBtn.Enabled = true;
                addProposalNavigationCurrentPageTxtbx.Enabled = true;
                addProposalNavigationReturnBtn.Enabled = false;
                //addProposalSearchBtn.Enabled = false;
            }   
            if(!dbh.addProposalQuery.Contains("executor"))
            {
                addProposalIsWatchingEdition = false;
                addProposalShowDgv.Columns.Clear();
                //addProposalShowDgv.DataSource = null;
                addProposalClearBtn.PerformClick();
                TotalPage = dbh.totalPage("SELECT COUNT(*) FROM proposalTable ");

                addProposalNavigationCurrentPageTxtbx.Text = CurrentPageIndex.ToString();
                dbh.addProposalQuery = "SELECT TOP " + pageSize + " * FROM proposalTable WHERE 1=1 ";
                dbh.dataGridViewUpdate3(addProposalShowDgv, addProposalBindingSource, dbh.addProposalQuery, pageSize, CurrentPageIndex);

                addProposalNavigationFirstPageBtn.Enabled = true;
                addProposalNavigationNextPageBtn.Enabled = true;
                addProposalNavigationLastPageBtn.Enabled = true;
                addProposalNavigationPreviousPageBtn.Enabled = true;
                addProposalNavigationCurrentPageTxtbx.Enabled = true;
                addProposalNavigationReturnBtn.Enabled = false;
                addProposalSearchBtn.Enabled = false;
            }
            
        }

     

        private void searchProposalNavigationCurrentPageTxtbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    if (int.Parse(searchProposalNavigationCurrentPageTxtbx.Text) >= 1 && int.Parse(searchProposalNavigationCurrentPageTxtbx.Text) <= TotalPage)
                    {
                        searchProposalShowDgv.Columns.Clear();
                        CurrentPageIndex = int.Parse(searchProposalNavigationCurrentPageTxtbx.Text);
                        searchProposalNavigationCurrentPageTxtbx.Text = CurrentPageIndex.ToString();
                        dbh.dataGridViewUpdate3(searchProposalShowDgv, searchProposalBindingSource, dbh.searchProposalQuery, pageSize, CurrentPageIndex);
                        searchProposalExecutorNCodeTxtbx.BackColor = Color.White;
                        searchProposalExecutorNCodeTxtbx.Focus();

                    
                    }
                    else
                    {
                        string context = "شماره صفحه بیشتر از تعداد صفحات است";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                }
                else
                {
                    e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
                }
            }
            catch
            { }
        }


        private void searchProposalNavigationReturnBtn_Click(object sender, EventArgs e)
        {
           
                searchProposalIsWatchingEdition = false;
                searchProposalShowDgv.Columns.Clear();
            //addProposalShowDgv.DataSource = null;
                dbh.searchProposalQuery = dbh.searchProposalQuery.Replace("TOP " + pageSize + " *", "COUNT(*)");

                TotalPage = dbh.totalPage(dbh.searchProposalQuery);

                dbh.searchProposalQuery = dbh.searchProposalQuery.Replace( "COUNT(*)","TOP " + pageSize + " *");
 
                addProposalNavigationCurrentPageTxtbx.Text = CurrentPageIndex.ToString();
                
                dbh.dataGridViewUpdate3(searchProposalShowDgv, searchProposalBindingSource, dbh.searchProposalQuery, pageSize, CurrentPageIndex);

                searchProposalNavigationFirstPageBtn.Enabled = true;
                searchProposalNavigationNextPageBtn.Enabled = true;
                searchProposalNavigationLastPageBtn.Enabled = true;
                searchProposalNavigationPreviousPageBtn.Enabled = true;
                searchProposalNavigationCurrentPageTxtbx.Enabled = true;
                searchProposalNavigationReturnBtn.Enabled = false;
                //addProposalSearchBtn.Enabled = false;
              
        }

        private void manageProposalNavigationFirstPageBtn_Click(object sender, EventArgs e)
        {
            editProposalShowDgv.Columns.Clear();
            CurrentPageIndex = 1;
            manageProposalNavigationCurrentPageTxtbx.Text = CurrentPageIndex.ToString();
            dbh.dataGridViewUpdate3(editProposalShowDgv, editProposalBindingSource, dbh.editProposalQuery, pageSize, CurrentPageIndex);
            editProposalExecutorNcodeTxtbx.BackColor = Color.White;
            editProposalExecutorNcodeTxtbx.Focus();
        }

        private void manageProposalNavigationPreviousPageBtn_Click(object sender, EventArgs e)
        {
            if (CurrentPageIndex > 1)
            {
                editProposalShowDgv.Columns.Clear();
                CurrentPageIndex--;
                manageProposalNavigationCurrentPageTxtbx.Text = CurrentPageIndex.ToString();
                dbh.dataGridViewUpdate3(editProposalShowDgv, editProposalBindingSource, dbh.editProposalQuery, pageSize, CurrentPageIndex);
                editProposalExecutorNcodeTxtbx.BackColor = Color.White;
                editProposalExecutorNcodeTxtbx.Focus();

                //  searchProposalShowAllBtn.Enabled = false;
            }
        }

        private void manageProposalNavigationNextPageBtn_Click(object sender, EventArgs e)
        {
            if (CurrentPageIndex < TotalPage)
            {
                editProposalShowDgv.Columns.Clear();
                CurrentPageIndex++;
                manageProposalNavigationCurrentPageTxtbx.Text = CurrentPageIndex.ToString();
                dbh.dataGridViewUpdate3(editProposalShowDgv, editProposalBindingSource, dbh.editProposalQuery, pageSize, CurrentPageIndex);
                editProposalExecutorNcodeTxtbx.BackColor = Color.White;
                editProposalExecutorNcodeTxtbx.Focus();

                // addProposalShowAllBtn.Enabled = false;
            }

        }

        private void manageProposalNavigationLastPageBtn_Click(object sender, EventArgs e)
        {
            editProposalShowDgv.Columns.Clear();
            CurrentPageIndex = TotalPage;
            manageProposalNavigationCurrentPageTxtbx.Text = CurrentPageIndex.ToString();
            dbh.dataGridViewUpdate3(editProposalShowDgv, editProposalBindingSource, dbh.editProposalQuery, pageSize, CurrentPageIndex);
            editProposalExecutorNcodeTxtbx.BackColor = Color.White;
            editProposalExecutorNcodeTxtbx.Focus();
        }

        private void manageProposalNavigationCurrentPageTxtbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    if (int.Parse(manageProposalNavigationCurrentPageTxtbx.Text) >= 1 && int.Parse(manageProposalNavigationCurrentPageTxtbx.Text) <= TotalPage)
                    {
                        editProposalShowDgv.Columns.Clear();
                        CurrentPageIndex = int.Parse(manageProposalNavigationCurrentPageTxtbx.Text);
                        manageProposalNavigationCurrentPageTxtbx.Text = CurrentPageIndex.ToString();
                        dbh.dataGridViewUpdate3(editProposalShowDgv, editProposalBindingSource, dbh.editProposalQuery, pageSize, CurrentPageIndex);
                        editProposalExecutorNcodeTxtbx.BackColor = Color.White;
                        editProposalExecutorNcodeTxtbx.Focus();


                    }
                    else
                    {
                        string context = "شماره صفحه بیشتر از تعداد صفحات است";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                }
                else
                {
                    e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
                }
            }
            catch
            { }
        }

        private void manageProposalNavigationReturnBtn_Click(object sender, EventArgs e)
        {
            manageProposalIsWatchingEdition = false;
            editProposalShowDgv.Columns.Clear();
            //addProposalShowDgv.DataSource = null;
            dbh.editProposalQuery = dbh.editProposalQuery.Replace("TOP " + pageSize + " *", "COUNT(*)");

            TotalPage = dbh.totalPage(dbh.editProposalQuery);

            dbh.editProposalQuery = dbh.editProposalQuery.Replace("COUNT(*)", "TOP " + pageSize + " *");

            manageProposalNavigationCurrentPageTxtbx.Text = CurrentPageIndex.ToString();

            dbh.dataGridViewUpdate3(editProposalShowDgv, editProposalBindingSource, dbh.editProposalQuery, pageSize, CurrentPageIndex);

            manageProposalNavigationFirstPageBtn.Enabled = true;
            manageProposalNavigationNextPageBtn.Enabled = true;
            manageProposalNavigationLastPageBtn.Enabled = true;
            manageProposalNavigationPreviousPageBtn.Enabled = true;
            manageProposalNavigationCurrentPageTxtbx.Enabled = true;
            manageProposalNavigationReturnBtn.Enabled = false;
        }

        private void manageTeacherNavigationFirstPageBtn_Click(object sender, EventArgs e)
        {
            manageTeacherShowDgv.Columns.Clear();
            CurrentPageIndex = 1;
            manageTeacherNavigationCurrentPageTxtbx.Text = CurrentPageIndex.ToString();
            dbh.dataGridViewUpdate3(manageTeacherShowDgv, teacherBindingSource, dbh.manageTeacherQuery, pageSize, CurrentPageIndex);
            manageTeacherExecutorNcodeTxtbx.BackColor = Color.White;
            manageTeacherExecutorNcodeTxtbx.Focus();
        }

        private void manageTeacherNavigationPreviousPageBtn_Click(object sender, EventArgs e)
        {
            if (CurrentPageIndex > 1)
            {
                manageTeacherShowDgv.Columns.Clear();
                CurrentPageIndex--;
                manageTeacherNavigationCurrentPageTxtbx.Text = CurrentPageIndex.ToString();
                dbh.dataGridViewUpdate3(manageTeacherShowDgv, teacherBindingSource, dbh.manageTeacherQuery, pageSize, CurrentPageIndex);
                manageTeacherExecutorNcodeTxtbx.BackColor = Color.White;
                manageTeacherExecutorNcodeTxtbx.Focus();

                //  searchProposalShowAllBtn.Enabled = false;
            }
        }

        private void manageTeacherNavigationNextPageBtn_Click(object sender, EventArgs e)
        {
            if (CurrentPageIndex < TotalPage)
            {
                manageTeacherShowDgv.Columns.Clear();
                CurrentPageIndex++;
                manageTeacherNavigationCurrentPageTxtbx.Text = CurrentPageIndex.ToString();
                dbh.dataGridViewUpdate3(manageTeacherShowDgv, teacherBindingSource, dbh.manageTeacherQuery, pageSize, CurrentPageIndex);
                manageTeacherExecutorNcodeTxtbx.BackColor = Color.White;
                manageTeacherExecutorNcodeTxtbx.Focus();

                // addProposalShowAllBtn.Enabled = false;
            }
        }

        private void manageTeacherNavigationLastPageBtn_Click(object sender, EventArgs e)
        {
            manageTeacherShowDgv.Columns.Clear();
            CurrentPageIndex = TotalPage;
            manageTeacherNavigationCurrentPageTxtbx.Text = CurrentPageIndex.ToString();
            dbh.dataGridViewUpdate3(manageTeacherShowDgv, teacherBindingSource, dbh.manageTeacherQuery, pageSize, CurrentPageIndex);
            manageTeacherExecutorNcodeTxtbx.BackColor = Color.White;
            manageTeacherExecutorNcodeTxtbx.Focus();
        }

        private void logNavigationFirstPageBtn_Click(object sender, EventArgs e)
        {
            logDgv.Columns.Clear();
            CurrentPageIndex = 1;
            logNavigationCurrentPageTxtbx.Text = CurrentPageIndex.ToString();
            dbh.dataGridViewUpdate3(logDgv, logBindingSource, dbh.logQuery, 30, CurrentPageIndex);
            
        }

        private void logNavigationPreviousPageBtn_Click(object sender, EventArgs e)
        {
            if (CurrentPageIndex > 1)
            {
                logDgv.Columns.Clear();
                CurrentPageIndex--;
                logNavigationCurrentPageTxtbx.Text = CurrentPageIndex.ToString();
                dbh.dataGridViewUpdate3(logDgv, logBindingSource, dbh.logQuery, 30, CurrentPageIndex);
                manageTeacherExecutorNcodeTxtbx.BackColor = Color.White;
                manageTeacherExecutorNcodeTxtbx.Focus();

                //  searchProposalShowAllBtn.Enabled = false;
            }
        }

        private void logNavigationNextPageBtn_Click(object sender, EventArgs e)
        {
            if (CurrentPageIndex < TotalPage)
            {
                logDgv.Columns.Clear();
                CurrentPageIndex++;
                logNavigationCurrentPageTxtbx.Text = CurrentPageIndex.ToString();
                dbh.dataGridViewUpdate3(logDgv, logBindingSource, dbh.logQuery, 30, CurrentPageIndex);
              
            
            }
        }

        private void logNavigationLastPageBtn_Click(object sender, EventArgs e)
        {
            logDgv.Columns.Clear();
            CurrentPageIndex = TotalPage;
            logNavigationCurrentPageTxtbx.Text = CurrentPageIndex.ToString();
            dbh.dataGridViewUpdate3(logDgv, logBindingSource, dbh.logQuery, 30, CurrentPageIndex);
          
        }

        private void manageTeacherNavigationCurrentPageTxtbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    if (int.Parse(manageTeacherNavigationCurrentPageTxtbx.Text) >= 1 && int.Parse(manageTeacherNavigationCurrentPageTxtbx.Text) <= TotalPage)
                    {
                        manageTeacherShowDgv.Columns.Clear();
                        CurrentPageIndex = int.Parse(manageTeacherNavigationCurrentPageTxtbx.Text);
                        manageTeacherNavigationCurrentPageTxtbx.Text = CurrentPageIndex.ToString();
                        dbh.dataGridViewUpdate3(manageTeacherShowDgv, teacherBindingSource, dbh.manageTeacherQuery, pageSize, CurrentPageIndex);
                        manageTeacherExecutorNcodeTxtbx.BackColor = Color.White;
                        manageTeacherExecutorNcodeTxtbx.Focus();


                    }
                    else
                    {
                        string context = "شماره صفحه بیشتر از تعداد صفحات است";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                }
                else
                {
                    e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
                }
            }
            catch
            { }
        }

        private void logNavigationCurrentPageTxtbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    if (int.Parse(logNavigationCurrentPageTxtbx.Text) >= 1 && int.Parse(logNavigationCurrentPageTxtbx.Text) <= TotalPage)
                    {
                        logDgv.Columns.Clear();
                        CurrentPageIndex = int.Parse(logNavigationCurrentPageTxtbx.Text);
                        logNavigationCurrentPageTxtbx.Text = CurrentPageIndex.ToString();
                        dbh.dataGridViewUpdate3(logDgv, logBindingSource, dbh.logQuery, 30, CurrentPageIndex);
                       

                    }
                    else
                    {
                        string context = "شماره صفحه بیشتر از تعداد صفحات است";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                }
                else
                {
                    e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
                }
            }
            catch
            { }
        }

        private void manageUserCheckAllCb_CheckedChanged(object sender, EventArgs e)
        {
            if(manageUserCheckAllCb.Checked)
            {
                manageUserAddProCb.Checked = true;
                manageUserEditProCb.Checked = true;
                manageUserDeleteProCb.Checked = true;
                manageUserManageTeacherCb.Checked = true;
                manageUserAddUserCb.Checked = true;
                manageUserEditUserCb.Checked = true;
                manageUserDeleteUserCb.Checked = true;
                manageUserManageTypeCb.Checked = true;
            }
        }

        private void appSettingCoRbtn_CheckedChanged(object sender, EventArgs e)
        {
            if(!appSettingCoRbtn.Checked)
            {
                appSettingNavigationPanel.Enabled = false;
            }
        }

        private void appSettingSenderInfoClearBtn_Click(object sender, EventArgs e)
        {
            appSettingSenderNameTxtbx.Clear();
            appSettingSenderGradeTxtbx.Clear();
        }

        private void appSettingSenderInfoEditBtn_Click(object sender, EventArgs e)
        {
            if (appSettingSenderNameTxtbx.Text == "")
            {
                string context = "عنوانی برای نام فرستنده نامه وارد کنید";
                Alert alert = new Alert(context, "bluegray", 2);
            }
            else if (appSettingSenderGradeTxtbx.Text == "")
            {
                string context = "عنوانی برای سمت فرستنده نامه وارد کنید";
                Alert alert = new Alert(context, "bluegray", 2);
            }
            else
            {
                PopUp p = new PopUp("تغییر اطلاعات", "آیا از تغییر اطلاعات فرستنده نامه مطمئن هستید؟", "بله", "خیر", "", "info");
                p.ShowDialog();
                if (p.DialogResult == DialogResult.Yes)
                {
                    dbh.editSender(appSettingSenderNameTxtbx.Text, appSettingSenderGradeTxtbx.Text, loginUser.U_NCode, myDateTime.ToString());
                }
            }
        }

        private void searchProposalExecutorFNameTxtbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                searchProposalSearchBtn.PerformClick();
            }
        }

        private void searchProposalExecutorLNameTxtbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                searchProposalSearchBtn.PerformClick();
            }
        }

        private void searchProposalExecutorFacultyCb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                searchProposalSearchBtn.PerformClick();
            }
        }

        private void searchProposalExecutorEGroupCb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                searchProposalSearchBtn.PerformClick();
            }
        }

        private void manageUserEditProCb_CheckedChanged(object sender, EventArgs e)
        {
            if (!manageUserEditProCb.Checked)
            {
                manageUserCheckAllCb.Checked = false;
            }

            if (manageUserAddProCb.Checked && manageUserManageTypeCb.Checked && manageUserDeleteUserCb.Checked && manageUserEditUserCb.Checked
               && manageUserAddUserCb.Checked && manageUserManageTeacherCb.Checked && manageUserDeleteProCb.Checked && manageUserEditProCb.Checked)
            {
                manageUserCheckAllCb.Checked = true;
            }
        }

        private void manageUserDeleteProCb_CheckedChanged(object sender, EventArgs e)
        {
            if (!manageUserDeleteProCb.Checked)
            {
                manageUserCheckAllCb.Checked = false;
            }

            if (manageUserAddProCb.Checked && manageUserManageTypeCb.Checked && manageUserDeleteUserCb.Checked && manageUserEditUserCb.Checked
               && manageUserAddUserCb.Checked && manageUserManageTeacherCb.Checked && manageUserDeleteProCb.Checked && manageUserEditProCb.Checked)
            {
                manageUserCheckAllCb.Checked = true;
            }
        }

        private void manageUserManageTeacherCb_CheckedChanged(object sender, EventArgs e)
        {
            if (!manageUserManageTeacherCb.Checked)
            {
                manageUserCheckAllCb.Checked = false;
            }

            if (manageUserAddProCb.Checked && manageUserManageTypeCb.Checked && manageUserDeleteUserCb.Checked && manageUserEditUserCb.Checked
               && manageUserAddUserCb.Checked && manageUserManageTeacherCb.Checked && manageUserDeleteProCb.Checked && manageUserEditProCb.Checked)
            {
                manageUserCheckAllCb.Checked = true;
            }
        }

        private void manageUserAddUserCb_CheckedChanged(object sender, EventArgs e)
        {
            if (!manageUserAddUserCb.Checked)
            {
                manageUserCheckAllCb.Checked = false;
            }

            if (manageUserAddProCb.Checked && manageUserManageTypeCb.Checked && manageUserDeleteUserCb.Checked && manageUserEditUserCb.Checked
               && manageUserAddUserCb.Checked && manageUserManageTeacherCb.Checked && manageUserDeleteProCb.Checked && manageUserEditProCb.Checked)
            {
                manageUserCheckAllCb.Checked = true;
            }
        }

        private void manageUserEditUserCb_CheckedChanged(object sender, EventArgs e)
        {
            if (!manageUserEditUserCb.Checked)
            {
                manageUserCheckAllCb.Checked = false;
            }

            if (manageUserAddProCb.Checked && manageUserManageTypeCb.Checked && manageUserDeleteUserCb.Checked && manageUserEditUserCb.Checked
               && manageUserAddUserCb.Checked && manageUserManageTeacherCb.Checked && manageUserDeleteProCb.Checked && manageUserEditProCb.Checked)
            {
                manageUserCheckAllCb.Checked = true;
            }
        }

        private void manageUserDeleteUserCb_CheckedChanged(object sender, EventArgs e)
        {
            if (!manageUserDeleteUserCb.Checked)
            {
                manageUserCheckAllCb.Checked = false;
            }

            if (manageUserAddProCb.Checked && manageUserManageTypeCb.Checked && manageUserDeleteUserCb.Checked && manageUserEditUserCb.Checked
               && manageUserAddUserCb.Checked && manageUserManageTeacherCb.Checked && manageUserDeleteProCb.Checked && manageUserEditProCb.Checked)
            {
                manageUserCheckAllCb.Checked = true;
            }
        }

        private void manageUserManageTypeCb_CheckedChanged(object sender, EventArgs e)
        {
            if (!manageUserManageTypeCb.Checked)
            {
                manageUserCheckAllCb.Checked = false;
            }

            if (manageUserAddProCb.Checked && manageUserManageTypeCb.Checked && manageUserDeleteUserCb.Checked && manageUserEditUserCb.Checked
               && manageUserAddUserCb.Checked && manageUserManageTeacherCb.Checked && manageUserDeleteProCb.Checked && manageUserEditProCb.Checked)
            {
                manageUserCheckAllCb.Checked = true;
            }
        }

        private void searchProposalStartDateFromTimeInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                searchProposalSearchBtn.PerformClick();
            }
        }

        private void manageUserReadOnlyCb_CheckedChanged(object sender, EventArgs e)
        {
            if(manageUserReadOnlyCb.Checked)
            {
                manageUserCheckAllCb.Checked = false;
                manageUserAddProCb.Checked = false;
                manageUserEditProCb.Checked = false;
                manageUserDeleteProCb.Checked = false;
                manageUserManageTeacherCb.Checked = false;
                manageUserAddUserCb.Checked = false;
                manageUserEditUserCb.Checked = false;
                manageUserDeleteUserCb.Checked = false;
                manageUserManageTypeCb.Checked = false;

                manageUserCheckAllCb.Enabled = false;
                manageUserAddProCb.Enabled = false;
                manageUserEditProCb.Enabled = false;
                manageUserDeleteProCb.Enabled = false;
                manageUserManageTeacherCb.Enabled = false;
                manageUserAddUserCb.Enabled = false;
                manageUserEditUserCb.Enabled = false;
                manageUserDeleteUserCb.Enabled = false;
                manageUserManageTypeCb.Enabled = false;

            }

            else
            {
                manageUserCheckAllCb.Enabled = true;
                manageUserAddProCb.Enabled = true;
                manageUserEditProCb.Enabled = true;
                manageUserDeleteProCb.Enabled = true;
                manageUserManageTeacherCb.Enabled = true;
                manageUserAddUserCb.Enabled = true;
                manageUserEditUserCb.Enabled = true;
                manageUserDeleteUserCb.Enabled = true;
                manageUserManageTypeCb.Enabled = true;

            }
        }

        private void manageUserAddProCb_CheckedChanged(object sender, EventArgs e)
        {
            if(!manageUserAddProCb.Checked)
            {
                manageUserCheckAllCb.Checked = false;
            }

            if(manageUserAddProCb.Checked && manageUserManageTypeCb.Checked && manageUserDeleteUserCb.Checked && manageUserEditUserCb.Checked
               && manageUserAddUserCb.Checked && manageUserManageTeacherCb.Checked && manageUserDeleteProCb.Checked && manageUserEditProCb.Checked)
            {
                manageUserCheckAllCb.Checked = true;
            }
        }


        private void editProposalExecutorNcodeTxtbx_Leave(object sender, EventArgs e)
        {
            if(editProposalExecutorNcodeTxtbx.Text.Length < 10)
            {
                editProposalExecutorNcodeTxtbx.BackColor = Color.Pink;
            }
        }


        private void searchProposalExecutorNCodeTxtbx_Leave(object sender, EventArgs e)
        {
            if(searchProposalExecutorNCodeTxtbx.Text.Length<10)
            {
                searchProposalExecutorNCodeTxtbx.BackColor = Color.Pink;
            }
        }


        private void menuDetailRb_CheckedChanged(object sender, EventArgs e)
        {
            detailedMenu();
        }

        private void iconMenu()
        {
            int numberOfMenuOptions = 0;

            if (isDetailedMenu)
            {
                for (int i = 865; i < 946; i++)
                {
                    gl.setSize(iconMenuPanel, i, -2, 313, 1000);
                }
            }
            
            gl.setSize(menuHomeBtn, 0, 5, 55, 75);
            menuHomeBtn.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center;
            menuHomeBtn.Text = "";
            numberOfMenuOptions++;

            if (loginUser.CanAddProposal == 1)
            {
                gl.setSize(menuAddProposalBtn, 0, 5 + (numberOfMenuOptions * 75), 55, 75);
                menuAddProposalBtn.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center;
                menuAddProposalBtn.Text = "";
                numberOfMenuOptions++;
            }
            else
            {
                menuAddProposalBtn.Visible = false;
            }
            

            gl.setSize(menuSearchProposalBtn, 0, 5 + (numberOfMenuOptions * 75), 55, 75);
            menuSearchProposalBtn.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center;
            menuSearchProposalBtn.Text = "";
            numberOfMenuOptions++;

            if (loginUser.CanEditProposal == 1)
            {
                gl.setSize(menuManageProposalBtn, 0, 5 + (numberOfMenuOptions * 75), 55, 75);
                menuManageProposalBtn.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center;
                menuManageProposalBtn.Text = "";
                numberOfMenuOptions++;
            }
            else
            {
                menuManageProposalBtn.Visible = false;
            }

            if (loginUser.CanManageTeacher == 1)
            {
                gl.setSize(menuManageTeacherBtn, 0, 5 + (numberOfMenuOptions * 75), 55, 75);
                menuManageTeacherBtn.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center;
                menuManageTeacherBtn.Text = "";
                numberOfMenuOptions++;
            }
            else
            {
                menuManageTeacherBtn.Visible = false;
            }

            if (loginUser.CanAddUser == 1 || loginUser.CanEditUser == 1 || loginUser.CanDeleteUser == 1)
            {
                gl.setSize(menuManageUserBtn, 0, 5 + (numberOfMenuOptions * 75), 55, 75);
                menuManageUserBtn.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center;
                menuManageUserBtn.Text = "";
                numberOfMenuOptions++;
            }
            else
            {
                menuManageUserBtn.Visible = false;
            }

            if (loginUser.CanManageType == 1)
            {
                gl.setSize(menuAppSettingBtn, 0, 5 + (numberOfMenuOptions * 75), 55, 75);
                menuAppSettingBtn.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center;
                menuAppSettingBtn.Text = "";
                numberOfMenuOptions++;
            }
            else
            {
                menuAppSettingBtn.Visible = false;
            }

            gl.setSize(menuPersonalSettingBtn, 0, 5 + (numberOfMenuOptions * 75), 55, 75);
            menuPersonalSettingBtn.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center;
            menuPersonalSettingBtn.Text = "";
            numberOfMenuOptions++;

            gl.setSize(menuAboutUsBtn, 0, 5 + (numberOfMenuOptions * 75), 55, 75);
            menuAboutUsBtn.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center;
            menuAboutUsBtn.Text = "";
            numberOfMenuOptions++;

            if (loginUser.U_NCode == 999999999 && loginUser.U_Password == "P@hn1395")
            {
                gl.setSize(menuSysLogBtn, 0, 5 + (numberOfMenuOptions * 75), 55, 75);
                menuSysLogBtn.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center;
                menuSysLogBtn.Text = "";
                numberOfMenuOptions++;
            }
            else
            {
                menuSysLogBtn.Visible = false;
            }

            gl.setSize(menuExitBtn, 0, 5 + (numberOfMenuOptions * 75), 55, 75);
            menuExitBtn.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center;
            menuExitBtn.Text = "";
            numberOfMenuOptions++;

            gl.setSize(menuIconRb, 0, 845, 50, 25);
            gl.setSize(menuDetailRb, 0, 870, 50, 25);
            gl.setSize(menuSlideRb, 0, 895, 50, 25);

            isIconMenu = true;
            isDetailedMenu = false;
        }

        private void detailedMenu()
        {
            int numberOfMenuOptions = 0;

            if(isIconMenu)
            {
                for (int i = 945; i > 864; i--)
                {
                    gl.setSize(iconMenuPanel, i, -2, 313, 1000);
                }
            }
            
            gl.setSize(menuHomeBtn, 1, 5, 133, 75);
            menuHomeBtn.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Right;
            menuHomeBtn.Text = "خانه";
            numberOfMenuOptions++;

            if(loginUser.CanAddProposal == 1)
            {
                gl.setSize(menuAddProposalBtn, 1, 5 + (numberOfMenuOptions * 75), 133, 75);
                menuAddProposalBtn.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Right;
                menuAddProposalBtn.Text = "افزودن پروپوزال";
                numberOfMenuOptions++;
            }
            else
            {
                menuAddProposalBtn.Visible = false;
            }
            

            gl.setSize(menuSearchProposalBtn, 1, 5 + (numberOfMenuOptions * 75), 133, 75);
            menuSearchProposalBtn.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Right;
            menuSearchProposalBtn.Text = "جستجوی پروپوزال";
            numberOfMenuOptions++;


            if (loginUser.CanEditProposal == 1)
            {
                gl.setSize(menuManageProposalBtn, 1, 5 + (numberOfMenuOptions * 75), 133, 75);
                menuManageProposalBtn.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Right;
                menuManageProposalBtn.Text = "مدیریت پروپوزال";
                numberOfMenuOptions++;
            }
            else
            {
                menuManageProposalBtn.Visible = false;
            }


            if (loginUser.CanManageTeacher == 1)
            {
                gl.setSize(menuManageTeacherBtn, 1, 5 + (numberOfMenuOptions * 75), 133, 75);
                menuManageTeacherBtn.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Right;
                menuManageTeacherBtn.Text = "اساتید";
                numberOfMenuOptions++;
            }
            else
            {
                menuManageTeacherBtn.Visible = false;
            }


            if (loginUser.CanAddUser == 1 || loginUser.CanEditUser == 1 || loginUser.CanDeleteUser == 1)
            {
                gl.setSize(menuManageUserBtn, 1, 5 + (numberOfMenuOptions * 75), 133, 75);
                menuManageUserBtn.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Right;
                menuManageUserBtn.Text = "کاربران";
                numberOfMenuOptions++;
            }
            else
            {
                menuManageUserBtn.Visible = false;
            }


            if(loginUser.CanManageType == 1)
            {
                gl.setSize(menuAppSettingBtn, 1, 5 + (numberOfMenuOptions * 75), 133, 75);
                menuAppSettingBtn.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Right;
                menuAppSettingBtn.Text = "تنظیمات برنامه";
                numberOfMenuOptions++;
            }
            else
            {
                menuAppSettingBtn.Visible = false;
            }
           

            gl.setSize(menuPersonalSettingBtn, 1, 5 + (numberOfMenuOptions * 75), 133, 75);
            menuPersonalSettingBtn.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Right;
            menuPersonalSettingBtn.Text = "تنظیمات شخصی";
            numberOfMenuOptions++;

            gl.setSize(menuAboutUsBtn, 1, 5 + (numberOfMenuOptions * 75), 133, 75);
            menuAboutUsBtn.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Right;
            menuAboutUsBtn.Text = "درباره ما";
            numberOfMenuOptions++;

            if (loginUser.U_NCode == 999999999 && loginUser.U_Password == "P@hn1395")
            {
                gl.setSize(menuSysLogBtn, 1, 5 + (numberOfMenuOptions * 75), 133, 75);
                menuSysLogBtn.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Right;
                menuSysLogBtn.Text = "System Log";
                numberOfMenuOptions++;
            }
            else
            {
                menuSysLogBtn.Visible = false;
            }

            gl.setSize(menuExitBtn, 1, 5 + (numberOfMenuOptions * 75), 133, 75);
            menuExitBtn.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Right;
            menuExitBtn.Text = "خروج";

            gl.setSize(menuIconRb, 45, 845, 50, 25);
            gl.setSize(menuDetailRb, 45, 870, 50, 25);
            gl.setSize(menuSlideRb, 45, 895, 50, 25);

            isDetailedMenu = true;
            isIconMenu = false;
        }
    }
}