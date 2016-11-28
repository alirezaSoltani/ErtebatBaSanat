using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProposalReportingSystem
{
    public partial class Form1 : Form
    {
        private int systemWidth;    //related to setSize
        private int systemHeight;   //related to setSize

        private Global gl = new Global();

        public Form1()
        {
            InitializeComponent();

            systemWidth = SystemInformation.PrimaryMonitorSize.Width;          //related to setSize
            systemHeight = SystemInformation.PrimaryMonitorSize.Height;        //related to setSize
            //MessageBox.Show(systemWidth + "*" + systemHeight);
            this.SetBounds(0, 0, systemWidth, ((955 * systemHeight) / 1000));  //related to setSize
            gl.setSize(mainPage, 0, 0, 995, 925);                       //related to setSize



            //********************************************//
            ////////////////////////Home////////////////////
            gl.setSize(homeAapInfoGp, 175, 70, 500, 300);
            gl.setSize(homeTimeDateGp, 80, 400, 700, 400);
            gl.setSize(homeAppNameLbl, 90, 15, 425, 30);
            gl.setSize(homeUserProfileLbl, 210, 75, 85, 85);
            gl.setSize(homeUserNameLbl, 210, 160, 125, 30);
            gl.setSize(homeWellcomeLbl, 225, 195, 85, 25);
            gl.setSize(analogClockControl1, 70, 25, 180, 180);
            gl.setSize(monthCalendar1, 370, 80, 360, 165);
            ///////////////////////Home/////////////////////




            //********************************************//
            //////////////add proposal design///////////////
            gl.setSize(addProposalPanel, 0, 1, 875, 930);
            gl.setSize(addProposalAddGp, 22, 15, 826, 445);
            gl.setSize(addProposalShowGp, 22, 470, 826, 425);
            gl.setSize(superTabControlPanel2, 0, 1, 880, 1000);
            gl.setSize(addProposalShowDgv, 3, 5, 817, 380);

            gl.setSize(addProposalExecutorNcodeLbl, 720, 10, 60, 25);
            gl.setSize(addProposalExecutorNcodeTxtbx, 550, 10, 160, 25);

            gl.setSize(addProposalExecutorFNameLbl, 720, 50, 60, 25);
            gl.setSize(addProposalExecutorFNameTxtbx, 550, 50, 160, 25);

            gl.setSize(addProposalExecutorLNameLbl, 720, 90, 60, 25);
            gl.setSize(addProposalExecutorLNameTxtbx, 550, 90, 160, 25);

            gl.setSize(addProposalExecutorFacultyLbl, 720, 130, 60, 25);
            gl.setSize(addProposalExecutorFacultyTxtbx, 550, 130, 160, 25);

            gl.setSize(addProposalExecutorEGroupLbl, 720, 170, 60, 25);
            gl.setSize(addProposalExecutorEGroupTxtbx, 550, 170, 160, 25);

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
            gl.setSize(addProposalStartdateTimeInput, 290, 370, 160, 25);

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

            gl.setSize(addProposalRegisterBtn, 30, 370, 70, 30);
            gl.setSize(addProposalClearBtn, 120, 370, 70, 30);



            /*///test the gridview by excel///
            System.Data.OleDb.OleDbConnection MyConnection;
            System.Data.DataSet DtSet;
            System.Data.OleDb.OleDbDataAdapter MyCommand;
            MyConnection = new System.Data.OleDb.OleDbConnection(@"provider=Microsoft.ACE.OLEDB.12.0;Data Source='d:/temp/test.xlsx';Extended Properties=Excel 8.0;");
            MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection);
            MyCommand.TableMappings.Add("Table", "Net-informations.com");
            DtSet = new System.Data.DataSet();
            MyCommand.Fill(DtSet);
            addProposalShowDgv.DataSource = DtSet.Tables[0];
            MyConnection.Close();
            ////test the gridview by excel//*/

            //////////////add proposal design///////////////
            //********************************************//



            //********************************************//
            //////////////search proposal design///////////////
            gl.setSize(searchProposalPanel, 0, 1, 875, 930);
            gl.setSize(searchProposalSearchGp, 22, 15, 826, 445);
            gl.setSize(searchProposalExecutorInfoGp, 525, 5, 270, 350);
            gl.setSize(searchProposalProposalInfoGp, 20, 5, 480, 350);
            gl.setSize(searchProposalShowGp, 22, 470, 826, 425);
            gl.setSize(superTabControlPanel2, 0, 1, 880, 1000);
            gl.setSize(searchProposalShowDgv, 3, 5, 817, 380);

            gl.setSize(searchProposalExecutorNCodeLbl, 720, 70, 60, 25);
            gl.setSize(searchProposalExecutorNCodeTxtbx, 550, 70, 160, 25);

            gl.setSize(searchProposalExecutorFNameLbl, 720, 110, 60, 25);
            gl.setSize(searchProposalExecutorFNameTxtbx, 550, 110, 160, 25);

            gl.setSize(searchProposalExecutorLNameLbl, 720, 150, 60, 25);
            gl.setSize(searchProposalExecutorLNameTxtbx, 550, 150, 160, 25);

            gl.setSize(searchProposalExecutorFacultyLbl, 720, 190, 60, 25);
            gl.setSize(searchProposalExecutorFacultyTxtbx, 550, 190, 160, 25);

            gl.setSize(searchProposalExecutorEGroupLbl, 720, 230, 60, 25);
            gl.setSize(searchProposalExecutorEGroupTxtbx, 550, 230, 160, 25);

            gl.setSize(searchProposalExecutorMobileLbl, 720, 270, 60, 25);
            gl.setSize(searchProposalExecutorMobileTxtbx, 550, 270, 160, 25);

            gl.setSize(searchProposalPersianTitleLbl, 420, 70, 60, 25);
            gl.setSize(searchProposalPersianTitleTxtbx, 260, 70, 160, 25);

            gl.setSize(searchProposalEnglishTitleLbl, 420, 110, 60, 25);
            gl.setSize(searchProposalEnglishTitleTxtbx, 260, 110, 160, 25);

            gl.setSize(searchProposalStartDateFromLbl, 420, 150, 60, 25);
            gl.setSize(searchProposalStartDateFromTimeInput, 260, 150, 160, 25);
            gl.setSize(searchProposalStartDateFromChbx, 245, 155, 30, 30);

            gl.setSize(searchProposalStartDateToLbl, 420, 190, 60, 25);
            gl.setSize(searchProposalStartDateToTimeInput, 260, 190, 160, 25);
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




            /*///test the gridview by excel///
            System.Data.OleDb.OleDbConnection MyConnection;
            System.Data.DataSet DtSet;
            System.Data.OleDb.OleDbDataAdapter MyCommand;
            MyConnection = new System.Data.OleDb.OleDbConnection(@"provider=Microsoft.ACE.OLEDB.12.0;Data Source='d:/temp/test.xlsx';Extended Properties=Excel 8.0;");
            MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection);
            MyCommand.TableMappings.Add("Table", "Net-informations.com");
            DtSet = new System.Data.DataSet();
            MyCommand.Fill(DtSet);
            addProposalShowDgv.DataSource = DtSet.Tables[0];
            MyConnection.Close();
            ////test the gridview by excel//*/

            //////////////add proposal design///////////////
            //********************************************//





            //********************************************//
            //////////////edit proposal design///////////////
            gl.setSize(editProposalPanel, 0, 1, 875, 930);
            gl.setSize(editProposalEditGp, 22, 15, 826, 445);
            gl.setSize(editProposalShowGp, 22, 470, 826, 425);
            gl.setSize(superTabControlPanel5, 0, 1, 880, 1000);
            gl.setSize(editProposalShowDgv, 3, 5, 817, 380);

            gl.setSize(editProposalExecutorNcodeLbl, 720, 10, 60, 25);
            gl.setSize(editProposalExecutorNcodeTxtbx, 550, 10, 160, 25);

            gl.setSize(editProposalExecutorFNameLbl, 720, 50, 60, 25);
            gl.setSize(editProposalExecutorFNameTxtbx, 550, 50, 160, 25);

            gl.setSize(editProposalExecutorLNameLbl, 720, 90, 60, 25);
            gl.setSize(editProposalExecutorLNameTxtbx, 550, 90, 160, 25);

            gl.setSize(editProposalExecutorFacultyLbl, 720, 130, 60, 25);
            gl.setSize(editProposalExecutorFacultyTxtbx, 550, 130, 160, 25);

            gl.setSize(editProposalExecutorEGroupLbl, 720, 170, 60, 25);
            gl.setSize(editProposalExecutorEGroupTxtbx, 550, 170, 160, 25);

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
            gl.setSize(editProposalStartdateTimeInput, 290, 370, 160, 25);

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
            gl.setSize(editProposalClearBtn, 120, 370, 70, 30);



            /*///test the gridview by excel///
            System.Data.OleDb.OleDbConnection MyConnection;
            System.Data.DataSet DtSet;
            System.Data.OleDb.OleDbDataAdapter MyCommand;
            MyConnection = new System.Data.OleDb.OleDbConnection(@"provider=Microsoft.ACE.OLEDB.12.0;Data Source='d:/temp/test.xlsx';Extended Properties=Excel 8.0;");
            MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection);
            MyCommand.TableMappings.Add("Table", "Net-informations.com");
            DtSet = new System.Data.DataSet();
            MyCommand.Fill(DtSet);
            addProposalShowDgv.DataSource = DtSet.Tables[0];
            MyConnection.Close();
            ////test the gridview by excel//*/

            //////////////add proposal design///////////////
            //********************************************//



            /////////////manage users design/////////////////
            //*********************************************//
            gl.setSize(manageUserPanel, 0, 1, 875, 1000);
            gl.setSize(manageUserShowGp, 22, 450, 826, 450);
            gl.setSize(manageUserDgv, 3, 5, 817, 410);
            gl.setSize(manageUserManageGp, 22, 15, 826, 425);
            gl.setSize(menageUserAccessLevelGp, 40, 15, 350, 305);

            gl.setSize(manageUserPersonalInfoGp, 430, 15, 360, 370);
            gl.setSize(manageUserFnameTxtbx, 45, 20, 160, 25);
            gl.setSize(manageUserLnameTxtbx, 45, 65, 160, 25);
            gl.setSize(manageUserNcodTxtbx, 45, 115, 160, 25);
            gl.setSize(manageUserPasswordTxtbx, 45, 165, 160, 25);
            gl.setSize(manageUserEmailTxtbx, 45, 215, 160, 25);
            gl.setSize(manageUserTellTxtbx, 45, 263, 160, 25);

            gl.setSize(manageUserFnameLb, 275, 20, 40, 40);
            gl.setSize(manageUserLnameLb, 205, 65, 110, 35);
            gl.setSize(manageUserNcodLb, 205, 115, 110, 35);
            gl.setSize(manageUserPasswordLb, 205, 165, 110, 35);
            gl.setSize(manageUserEmailLb, 205, 215, 110, 35);
            gl.setSize(manageUserTellLb, 205, 265, 110, 35);

            gl.setSize(manageUserEditBtn, 40, 340, 80, 45);
            gl.setSize(manageUserAddBtn, 125, 340, 80, 45);

            gl.setSize(manageUserAddProCb, 155, 30, 150, 35);
            gl.setSize(manageUserEditProCb, 155, 90, 150, 35);
            gl.setSize(manageUserDeleteProCb, 155, 145, 150, 35);
            gl.setSize(manageUserAddUserCb, 20, 30, 150, 35);
            gl.setSize(manageUserEditUserCb, 20, 90, 150, 35);
            gl.setSize(manageUserDeletUserCb, 20, 145, 150, 35);


            /*///test the gridview by excel///
            System.Data.OleDb.OleDbConnection MyConnection2;
            System.Data.DataSet DtSet2;
            System.Data.OleDb.OleDbDataAdapter MyCommand2;
            MyConnection = new System.Data.OleDb.OleDbConnection(@"provider=Microsoft.ACE.OLEDB.12.0;Data Source='d:/temp/test.xlsx';Extended Properties=Excel 8.0;");
            MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection);
            MyCommand.TableMappings.Add("Table", "Net-informations.com");
            DtSet = new System.Data.DataSet();
            MyCommand.Fill(DtSet);
            manageUserDgv.DataSource = DtSet.Tables[0];
            MyConnection.Close();
            ////test the gridview by excel//*/

            //*********************************************//
            /////////////manage users design/////////////////





            //********************************************//
            ///////////////////App Setting design//////////
            gl.setSize(appSettingPanel, 0, 1, 875, 930);
            gl.setSize(appSettingGp, 22, 15, 826, 425);
            gl.setSize(appSettingShowDv, 3, 5, 817, 408);
            gl.setSize(appSettingJobTypeRbtn, 205, 5, 23, 18);
            gl.setSize(appSettingPropertyRbtn, 205, 5, 23, 18);
            gl.setSize(appSettingRegTypeRbtn, 205, 5, 23, 18);
            gl.setSize(appSettingProTypeRbtn, 205, 5, 23, 18);
            gl.setSize(appSettingCoRbtn, 205, 5, 23, 18);
            gl.setSize(appSettingStatusRbtn, 205, 5, 23, 18);

            gl.setSize(appSettingCoTxtbx, 55, 60, 170, 35);
            gl.setSize(appSettingStatusTxtbx, 55, 230, 170, 35);
            gl.setSize(appSettingRegTypeTxtbx, 350, 60, 170, 35);
            gl.setSize(appSettingProTypeTxtbx, 350, 230, 170, 35);
            gl.setSize(appSettingPropertyTxtbx, 605, 230, 170, 35);
            gl.setSize(appSettingJobTypeTxtbx, 605, 60, 170, 35);

            gl.setSize(appSettingCoRbtn, 218, 20, 18, 23);
            gl.setSize(appSettingRegTypeRbtn, 512, 20, 18, 23);
            gl.setSize(appSettingJobTypeRbtn, 765, 20, 18, 23);
            gl.setSize(appSettingStatusRbtn, 218, 190, 18, 23);
            gl.setSize(appSettingProTypeRbtn, 512, 190, 18, 23);
            gl.setSize(appSettingPropertyRbtn, 765, 190, 18, 23);

            gl.setSize(aapSettingCoLbl, 150, 20, 75, 35);
            gl.setSize(appSettingRegTypeLbl, 445, 20, 75, 35);
            gl.setSize(appSettingJobTypeLbl, 695, 20, 75, 35);
            gl.setSize(appSettingStatusLbl, 150, 190, 75, 35);
            gl.setSize(appSettingProTypeLbl, 445, 190, 75, 35);
            gl.setSize(appSettingPropertyLbl, 695, 190, 75, 35);

            gl.setSize(appSettingAddBtn, 20, 335, 80, 45);
            gl.setSize(appSettingEditBtn, 110, 335, 80, 45);
            gl.setSize(appSettingDeleteBtn, 200, 335, 80, 45);

            gl.setSize(appSettingShowGp, 22, 450, 826, 450);
            ///////////////////App Setting design//////////
            //********************************************//





            //*************************************************/
            ///////////////personal setting design///////////////
            gl.setSize(personalSettingPanel, 0, 1, 875, 930);
            gl.setSize(personalSettingGp, 22, 15, 826, 400);

            gl.setSize(currentPasswordLbl, 450, 35, 110, 25);
            gl.setSize(newPasswordLbl, 450, 75, 110, 25);
            gl.setSize(confirmNewPasswordLbl, 450, 115, 110, 25);

            gl.setSize(currentPasswordTxtbx, 230, 35, 210, 25);
            gl.setSize(newPasswordTxtbx, 230, 75, 210, 25);
            gl.setSize(confirmNewPasswordTxtbx, 230, 115, 210, 25);

            gl.setSize(personalSettingRegisterBtn, 250, 180, 80, 45);
            gl.setSize(personalSettingClearBtn, 345, 180, 80, 45);
            ///////////////personal setting design///////////////
            //*************************************************//



            /////////////////about us///////////////////////////
            gl.setSize(aboutUsGp, 210, 250, 450, 340);
            gl.setSize(aboutUsTitleLbl, 300, 10, 180, 25);
            gl.setSize(AboutUsArshinLbl, 350, 60, 90, 20);
            gl.setSize(aboutUsPeymanLbl, 367, 110, 90, 20);
            gl.setSize(aboutUsHoseinLbl, 330, 160, 100, 20);
            gl.setSize(aboutUsNimaLbl, 375, 210, 90, 20);
            gl.setSize(aboutUsAlirezaLbl, 360, 260, 90, 20);
            //////////////////about us///////////////////////////
        }
    }
}