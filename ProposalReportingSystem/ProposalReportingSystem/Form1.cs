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
            MessageBox.Show(systemWidth + "*" + systemHeight);
            this.SetBounds(0, 0, systemWidth, ((955 * systemHeight) / 1000));  //related to setSize
            gl.setSize(systemSetting, 0, 0, 992, 900);                       //related to setSize
            //mainTabControl.TabHorizontalSpacing = (systemWidth / 200);

            //********************************************//
            //////////////add proposal design///////////////
            gl.setSize(addProposalPanel, 0, 1, 875, 930);
            gl.setSize(addProposalAddGp, 22, 15, 826, 445);
            gl.setSize(addProposalShowGp, 22, 470, 826, 450);
            gl.setSize(superTabControlPanel2, 0, 1, 880, 1000);
            gl.setSize(addProposalShowDgv, 3, 5, 817, 423);

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
            gl.setSize(addProposalTypeCb, 30, 170, 160, 25);

            gl.setSize(addProposalOrganizationLbl, 200, 210, 60, 25);
            gl.setSize(addProposalOrganizationCb, 30, 210, 160, 25);

            gl.setSize(addProposalValueLbl, 200, 250, 60, 25);
            gl.setSize(addProposalValueTxtbx, 30, 250, 160, 25);

            gl.setSize(addProposalStatusLbl, 200, 290, 60, 25);
            gl.setSize(addProposalStatusCb, 30, 290, 160, 25);


            gl.setSize(addProposalRegisterBtn, 30, 370, 70, 30);
            gl.setSize(addProposalClearBtn, 120, 370, 70, 30);



            ////test the gridview by excel///
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
            ////test the gridview by excel///

            //////////////add proposal design///////////////
            //********************************************//



            //********************************************//
            //////////////edit proposal design///////////////
            gl.setSize(editProposalPanel, 0, 1, 875, 930);
            gl.setSize(editProposalEditGp, 22, 15, 826, 425);
            gl.setSize(editProposalShowGp, 22, 450, 826, 450);
            gl.setSize(superTabControlPanel2, 0, 1, 880, 1000);
            gl.setSize(editProposalShowDgv, 3, 5, 817, 423);

            //Labels
            gl.setSize(editProposalPersianTitleLbl, 720, 25, 60, 25);
            gl.setSize(editProposalEnglishTitleLbl, 720, 65, 60, 25);
            gl.setSize(editProposalKeywordsLbl, 720, 105, 60, 25);
            gl.setSize(editProposalExecutorNcodeLbl, 720, 220, 60, 25);
            gl.setSize(editProposalExecutor2Lbl, 720, 260, 60, 25);

            gl.setSize(editProposalCoexecutorLbl, 460, 25, 60, 25);
            gl.setSize(editProposalStartdateLbl, 460, 140, 60, 25);
            gl.setSize(editProposalDurationLbl, 460, 180, 60, 25);
            gl.setSize(editProposalProcedureTypeLbl, 460, 220, 60, 25);
            gl.setSize(editProposalPropertyTypeLbl, 460, 260, 60, 25);
            gl.setSize(editProposalRegisterTypeLbl, 460, 300, 60, 25);

            gl.setSize(editProposalTypeLbl, 200, 25, 60, 25);
            gl.setSize(editProposalOrganizationLbl, 200, 65, 60, 25);
            gl.setSize(editProposalValueLbl, 200, 105, 60, 25);
            gl.setSize(editProposalStatusLbl, 200, 145, 60, 25);



            //NON labels
            gl.setSize(editProposalPersianTitleTxtbx, 550, 25, 160, 25);
            gl.setSize(editProposalEnglishTitleTxtbx, 550, 65, 160, 25);
            gl.setSize(editProposalKeywordsTxtbx, 550, 105, 160, 100);
            gl.setSize(editProposalExecutorNcodeTxtbx, 550, 220, 160, 25);
            gl.setSize(editProposalExecutor2Txtbx, 550, 260, 160, 100);

            gl.setSize(editProposalCoexecutorTxtbx, 290, 25, 160, 100);
            gl.setSize(editProposalStartdateTimeInput, 290, 140, 160, 25);
            gl.setSize(editProposalDurationTxtbx, 290, 180, 160, 100);
            gl.setSize(editProposalProcedureTypeCb, 290, 220, 160, 25);
            gl.setSize(editProposalPropertyTypeCb, 290, 260, 160, 25);
            gl.setSize(editProposalRegisterTypeCb, 290, 300, 160, 25);

            gl.setSize(editProposalTypeCb, 30, 25, 160, 25);
            gl.setSize(editProposalOrganizationCb, 30, 65, 160, 25);
            gl.setSize(editProposalValueTxtbx, 30, 105, 160, 25);
            gl.setSize(editProposalStatusCb, 30, 145, 160, 25);

            gl.setSize(editProposalRegisterBtn, 30, 290, 80, 45);
            gl.setSize(editProposalClearBtn, 120, 290, 80, 45);



            ////test the gridview by excel///
            System.Data.OleDb.OleDbConnection MyConnection1;
            System.Data.DataSet DtSet1;
            System.Data.OleDb.OleDbDataAdapter MyCommand1;
            MyConnection = new System.Data.OleDb.OleDbConnection(@"provider=Microsoft.ACE.OLEDB.12.0;Data Source='d:/temp/test.xlsx';Extended Properties=Excel 8.0;");
            MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection);
            MyCommand.TableMappings.Add("Table", "Net-informations.com");
            DtSet = new System.Data.DataSet();
            MyCommand.Fill(DtSet);
            editProposalShowDgv.DataSource = DtSet.Tables[0];
            MyConnection.Close();
            ////test the gridview by excel///

            //////////////edit proposal design///////////////
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


            ////test the gridview by excel///
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
            ////test the gridview by excel///

            //*********************************************//
            /////////////manage users design/////////////////




            //********************************************//
            ///////////////log design///////////////
            gl.setSize(logPanel, 0, 1, 875, 930);
            gl.setSize(logGp, 22, 15, 826, 850);
            gl.setSize(logDgv, 3, 5, 817, 800);

            ////test the gridview by excel///
            MyConnection = new System.Data.OleDb.OleDbConnection(@"provider=Microsoft.ACE.OLEDB.12.0;Data Source='d:/temp/test.xlsx';Extended Properties=Excel 8.0;");
            MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection);
            MyCommand.TableMappings.Add("Table", "Net-informations.com");
            DtSet = new System.Data.DataSet();
            MyCommand.Fill(DtSet);
            logDgv.DataSource = DtSet.Tables[0];
            MyConnection.Close();
            ////test the gridview by excel///

            ///////////////log design///////////////
            //********************************************//



            //********************************************//
            ///////////////////App Setting design//////////
            gl.setSize(appSettingPanel, 0, 1, 875, 930);
            gl.setSize(appSettingGp, 22, 15, 826, 425);
            gl.setSize(appSettingCoGp, 20, 15, 240, 135);
            gl.setSize(appSettingStatusGp, 20, 185, 240, 135);
            gl.setSize(appSettingRegTypeGp, 290, 15, 240, 135);
            gl.setSize(appSettingProTypeGp, 290, 185, 240, 135);
            gl.setSize(appSettingTypeJobGp, 560, 15, 240, 135);
            gl.setSize(appSettingPropertyGp, 560, 185, 240, 135);
            gl.setSize(appSettingShowDv, 3, 5, 817, 408);
            gl.setSize(appSettingJobTypeRbtn, 205, 5, 23, 18);
            gl.setSize(appSettingPropertyRbtn, 205, 5, 23, 18);
            gl.setSize(appSettingRegTypeRbtn, 205, 5, 23, 18);
            gl.setSize(appSettingProTypeRbtn, 205, 5, 23, 18);
            gl.setSize(appSettingCoRbtn, 205, 5, 23, 18);
            gl.setSize(appSettingStatusRbtn, 205, 5, 23, 18);

            gl.setSize(appSettingCoTxtbx, 45, 30, 170, 35);
            gl.setSize(appSettingStatusTxtbx, 45, 30, 170, 35);
            gl.setSize(appSettingRegTypeTxtbx, 45, 30, 170, 35);
            gl.setSize(appSettingProTypeTxtbx, 45, 30, 170, 35);
            gl.setSize(appSettingPropertyTxtbx, 45, 30, 170, 35);
            gl.setSize(appSettingJobTypeTxtbx, 45, 30, 170, 35);

            gl.setSize(appSettingAddBtn, 20, 335, 80, 45);
            gl.setSize(appSettingEditBtn, 110, 335, 80, 45);
            gl.setSize(appSettingDeleteBtn, 200, 335, 80, 45);

            gl.setSize(appSettingShowGp, 22, 450, 826, 450);
            ///////////////////App Setting design//////////
            //********************************************//





            //*************************************************//
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
        }
    }
}