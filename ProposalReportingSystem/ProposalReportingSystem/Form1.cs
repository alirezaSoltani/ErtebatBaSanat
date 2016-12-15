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
        private int count;   //related to color of textbox

        private Global gl = new Global();


        public Form1()
        {
            InitializeComponent();

            systemWidth = SystemInformation.PrimaryMonitorSize.Width;          //related to setSize
            systemHeight = SystemInformation.PrimaryMonitorSize.Height;        //related to setSize
            //MessageBox.Show(systemWidth + "*" + systemHeight);
            this.SetBounds(0, 0, systemWidth, ((955 * systemHeight) / 1000));  //related to setSize
            gl.setSize(mainPage, 0, 0, 995, 925);                              //related to setSize


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


            



            //*****************************************************************************************************//
            //                                               DESIGN                                                //
            //*****************************************************************************************************//


            ////////////////////////Home design////////////////////
            gl.setSize(homePanel, 0, 1, 900, 930);
            gl.setSize(homeAapInfoGp, 175, 70, 500, 300);
            gl.setSize(homeTimeDateGp, 80, 400, 700, 400);
            gl.setSize(homeAppNameLbl, 100, 15, 425, 30);
            gl.setSize(homeUserProfileLbl, 210, 75, 85, 85);
            gl.setSize(homeUserNameLbl, 210, 160, 125, 30);
            gl.setSize(homeWelcomeLbl, 225, 195, 85, 25);
            gl.setSize(analogClockControl1, 70, 25, 180, 180);
            gl.setSize(monthCalendar1, 300, 50, 320, 250);
            ///////////////////////Home design/////////////////////


            //////////////Add proposal design///////////////
            gl.setSize(addProposalPanel, 0, 1, 900, 930);
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
            ////test the gridview by excel//*/

            //////////////add proposal design///////////////
            //********************************************//



            //********************************************//
            //////////////Search proposal design///////////////
            gl.setSize(searchProposalPanel, 0, 1, 900, 930);
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




            ////test the gridview by excel///
            //System.Data.OleDb.OleDbConnection MyConnection;
            //System.Data.DataSet DtSet;
           // System.Data.OleDb.OleDbDataAdapter MyCommand;
            MyConnection = new System.Data.OleDb.OleDbConnection(@"provider=Microsoft.ACE.OLEDB.12.0;Data Source='d:/temp/test.xlsx';Extended Properties=Excel 8.0;");
            MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection);
            MyCommand.TableMappings.Add("Table", "Net-informations.com");
            DtSet = new System.Data.DataSet();
            MyCommand.Fill(DtSet);
            searchProposalShowDgv.DataSource = DtSet.Tables[0];
            MyConnection.Close();
            ////test the gridview by excel//*/
            //////////////add proposal design///////////////
            //********************************************//


            //********************************************//
            //////////////edit proposal design///////////////
            gl.setSize(editProposalPanel, 0, 1, 900, 930);
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

            //////////////edit proposal design///////////////
            //********************************************//



            /////////////manage users design/////////////////
            //*********************************************//
            gl.setSize(manageUserPanel, 0, 1, 900, 1000);
            gl.setSize(manageUserShowGp, 22, 470, 826, 425);
            gl.setSize(manageUserDgv, 3, 5, 817, 410);
            gl.setSize(manageUserManageGp, 22, 15, 826, 445);

            gl.setSize(menageUserAccessLevelGp, 40, 50, 350, 250);
            gl.setSize(manageUserPersonalInfoGp, 430, 5, 360, 330);
            gl.setSize(manageUserFnameTxtbx, 45, 20, 160, 28);
            gl.setSize(manageUserLnameTxtbx, 45, 60, 160, 28);
            gl.setSize(manageUserNcodTxtbx, 45, 100, 160, 28);
            gl.setSize(manageUserPasswordTxtbx, 45, 140, 160, 28);
            gl.setSize(manageUserEmailTxtbx, 45, 180, 160, 28);
            gl.setSize(manageUserTellTxtbx, 45, 220, 160, 28);

            gl.setSize(manageUserFnameLb, 275, 20, 40, 25);
            gl.setSize(manageUserLnameLb, 205, 60, 110, 25);
            gl.setSize(manageUserNcodLb, 205, 100, 110, 25);
            gl.setSize(manageUserPasswordLb, 205, 140, 110, 25);
            gl.setSize(manageUserEmailLb, 205, 180, 110, 25);
            gl.setSize(manageUserTellLb, 205, 220, 110, 25);

            gl.setSize(manageUserEditBtn, 40, 360, 80, 30);
            gl.setSize(manageUserAddBtn, 130, 360, 80, 30);
            gl.setSize(manageUserClearBtn, 220, 360, 80, 30);

            gl.setSize(manageUserAddProCb, 155, 25, 150, 35);
            gl.setSize(manageUserEditProCb, 155, 85, 150, 35);
            gl.setSize(manageUserDeleteProCb, 155, 140, 150, 35);
            gl.setSize(manageUserAddUserCb, 20, 25, 150, 35);
            gl.setSize(manageUserEditUserCb, 20, 85, 150, 35);
            gl.setSize(manageUserDeletUserCb, 20, 140, 150, 35);


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
            gl.setSize(appSettingPanel, 0, 1, 900, 930);
            gl.setSize(appSettingGp, 22, 15, 826, 445);
            gl.setSize(appSettingShowDv, 3, 5, 817, 408);
            gl.setSize(appSettingJobTypeRbtn, 205, 5, 23, 18);
            gl.setSize(appSettingPropertyRbtn, 205, 5, 23, 18);
            gl.setSize(appSettingRegTypeRbtn, 205, 5, 23, 18);
            gl.setSize(appSettingProTypeRbtn, 205, 5, 23, 18);
            gl.setSize(appSettingCoRbtn, 205, 5, 23, 18);
            gl.setSize(appSettingStatusRbtn, 205, 5, 23, 18);

            gl.setSize(appSettingCoTxtbx, 55, 60, 170, 35);
            gl.setSize(appSettingStatusTxtbx, 55, 170, 170, 35);
            gl.setSize(appSettingRegTypeTxtbx, 350, 60, 170, 35);
            gl.setSize(appSettingProTypeTxtbx, 350, 170, 170, 35);
            gl.setSize(appSettingPropertyTxtbx, 605, 170, 170, 35);
            gl.setSize(appSettingJobTypeTxtbx, 605, 60, 170, 35);

            gl.setSize(appSettingCoRbtn, 218, 20, 18, 23);
            gl.setSize(appSettingRegTypeRbtn, 512, 20, 18, 23);
            gl.setSize(appSettingJobTypeRbtn, 765, 20, 18, 23);
            gl.setSize(appSettingStatusRbtn, 218, 130, 18, 23);
            gl.setSize(appSettingProTypeRbtn, 512, 130, 18, 23);
            gl.setSize(appSettingPropertyRbtn, 765, 130, 18, 23);

            gl.setSize(aapSettingCoLbl, 150, 20, 75, 35);
            gl.setSize(appSettingRegTypeLbl, 445, 20, 75, 35);
            gl.setSize(appSettingJobTypeLbl, 695, 20, 75, 35);
            gl.setSize(appSettingStatusLbl, 150, 130, 75, 35);
            gl.setSize(appSettingProTypeLbl, 445, 130, 75, 35);
            gl.setSize(appSettingPropertyLbl, 695, 130, 75, 35);

            gl.setSize(appSettingFacultyLbl, 695, 250, 75, 35);
            gl.setSize(appSettingEgroupLbl, 445, 250, 75, 35);
            gl.setSize(appSettingFacultyRbtn, 765, 250, 18, 23);
            gl.setSize(appSettingEgroupRbtn, 512, 250, 18, 23);
            gl.setSize(appSettingFacultyTxtbx, 605, 290, 170, 35);
            gl.setSize(appSettingEgroupTxtbx, 350, 290, 170, 35);

            gl.setSize(appSettingAddBtn, 20, 365, 80, 30);
            gl.setSize(appSettingEditBtn, 110, 365, 80, 30);
            gl.setSize(appSettingDeleteBtn, 200, 365, 80, 30);
            gl.setSize(appSettingBackBtn, 290, 365, 80, 30);

            gl.setSize(appSettingShowGp, 22, 470, 826, 425);
            ///////////////////App Setting design//////////
            //********************************************//





            //*************************************************/
            ///////////////personal setting design///////////////
            gl.setSize(personalSettingPanel, 0, 1, 900, 930);
            gl.setSize(personalSettingGp, 22, 15, 826, 445);

            gl.setSize(currentPasswordLbl, 450, 35, 110, 25);
            gl.setSize(newPasswordLbl, 450, 75, 110, 25);
            gl.setSize(confirmNewPasswordLbl, 450, 115, 110, 25);

            gl.setSize(currentPasswordTxtbx, 230, 35, 220, 25);
            gl.setSize(newPasswordTxtbx, 230, 75, 220, 25);
            gl.setSize(confirmNewPasswordTxtbx, 230, 115, 220, 25);

            gl.setSize(personalSettingRegisterBtn, 230, 180, 100, 30);
            gl.setSize(personalSettingClearBtn, 350, 180, 100, 30);
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



            //////////////////manageTeacher//////////////////////
            gl.setSize(manageTeacherPanel, 0, 1, 900, 930);
            gl.setSize(manageTeacherInfoGp, 22, 15, 826, 445);
            gl.setSize(teacherManageShowGp, 22, 470, 826, 425);
            gl.setSize(manageTeacherShowDgv, 3, 5, 817, 408);

            gl.setSize(manageTeacherExecutorNcodeLbl, 740, 15, 60, 25);
            gl.setSize(manageTeacherFnameLbl, 740, 130, 60, 25);
            gl.setSize(manageTeacherLnameLbl, 740, 260, 60, 25);

            gl.setSize(manageTeacherExecutorFacultyLbl, 485, 15, 60, 25);
            gl.setSize(manageTeacherExecutorEGroupLbl, 485, 130, 60, 25);
            gl.setSize(manageTeacherExecutorEDegLbl, 485, 260, 60, 25);
            gl.setSize(manageTeacherExecutorTelLbl, 230, 15, 60, 25);
            gl.setSize(manageTeacherExecutorEmailLbl, 230, 130, 60, 25);
            gl.setSize(manageTeacherExecutorMobileLbl, 230, 260, 60, 25);

            gl.setSize(manageTeacherExecutorNcodeTxtbx, 560, 15, 160, 25);
            gl.setSize(manageTeacherFnameTxtbx, 560, 130, 160, 25);
            gl.setSize(manageTeacherLnameTxtbx, 560, 260, 160, 25);
            gl.setSize(manageTeacherExecutorEGroupTxtbx, 300, 15, 160, 25);
            gl.setSize(manageTeacherExecutorEDegCb, 300, 130, 160, 25);
            gl.setSize(manageTeacherExecutorFacultyTxtbx, 300, 260, 160, 25);
            gl.setSize(manageTeacherExecutorTelTxtbx, 50, 15, 160, 25);
            gl.setSize(manageTeacherExecutorEmailTxtbx, 50, 130, 160, 25);
            gl.setSize(manageTeacherExecutorMobileTxtbx, 50, 260, 160, 25);

            gl.setSize(manageTeacherAddBtn, 50, 365, 80, 30);
            gl.setSize(manageTeacherEditBtn, 140, 365, 80, 30);
            gl.setSize(manageTeacherDeleteBtn, 230, 365, 80, 30);

            //////////////////manageTeacher//////////////////////

            //*****************************************************************************************************//
            //                                               DESIGN                                                //
            //*****************************************************************************************************//
        }// end of Form 1




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
            op1.ShowDialog();
            op1.Filter = "allfiles|*.doc|*.docx|*.pdf";

            addProposalFileLinkLbl.Text = op1.FileName;

            /*int count = 0;

            string[] FName;

            foreach (string s in op1.FileNames)

            {

                FName = s.Split('\\');

                File.Copy(s, "C:\\file\\" + FName[FName.Length - 1]);

                count++;

            }*/

            MessageBox.Show("File uploaded");
        }


        private void addProposalClearBtn_Click(object sender, EventArgs e)
        {
            addProposalExecutorNcodeTxtbx.Clear();
            addProposalExecutorFNameTxtbx.Clear();
            addProposalExecutorLNameTxtbx.Clear();
            addProposalExecutorFacultyCb.SelectedIndex = 0;
            addProposalExecutorEGroupCb.SelectedIndex = 0;
            addProposalExecutorEDegCb.SelectedIndex = 0;
            addProposalExecutorEmailTxtbx.Clear();
            addProposalExecutorMobileTxtbx.Clear();
            addProposalExecutorTel1Txtbx.Clear();
            addProposalExecutorTel2Txtbx.Clear();
            addProposalPersianTitleTxtbx.Clear();
            addProposalEnglishTitleTxtbx.Clear();
            addProposalKeywordsTxtbx.Clear();
            addProposalExecutor2Txtbx.Clear();
            addProposalCoexecutorTxtbx.Clear();
            addProposalStartdateTimeInput.ResetText();
            addProposalDurationTxtbx.Clear();
            addProposalProcedureTypeCb.SelectedIndex = 0;
            addProposalPropertyTypeCb.SelectedIndex = 0;
            addProposalRegisterTypeCb.SelectedIndex = 0;
            addProposalProposalTypeCb.SelectedIndex = 0;
            addProposalOrganizationNameCb.SelectedIndex = 0;
            addProposalOrganizationNumberCb.SelectedIndex = 0;
            addProposalValueTxtbx.Clear();
            addProposalStatusCb.SelectedIndex = 0;
            //addProposalFileLinkLbl, 30, 330, 160, 25);
        }


        private void addProposalRegisterBtn_Click(object sender, EventArgs e)
        {

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
                editProposalPanel.BackColor = dlg.Color;
                appSettingPanel.BackColor = dlg.Color;
                personalSettingPanel.BackColor = dlg.Color;
                aboutUsPanel.BackColor = dlg.Color;
                logPanel.BackColor = dlg.Color;
            }
        }

        //////////////color of textbox///////////////

        private void manageTeacherExecutorNcodeTxtbx_TextChanged(object sender, EventArgs e)
        {
            count = manageTeacherExecutorNcodeTxtbx.Text.Length;
            if (count == 10)
            {
                manageTeacherExecutorNcodeTxtbx.BackColor = Color.Green;
            }
            else if (count == 0)
            {
                manageTeacherExecutorNcodeTxtbx.BackColor = Color.White;
            }
            else
            {
                manageTeacherExecutorNcodeTxtbx.BackColor = Color.Red;
            }
        }
        //////////////color of textbox///////////////

        //////////////just int///////////////
        private void manageTeacherExecutorNcodeTxtbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }
        //////////////just int///////////////

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

        private void manageTeacherExecutorEmailTxtbx_TextChanged(object sender, EventArgs e)
        {
            manageTeacherExecutorEmailTxtbx.BackColor = Color.White;
        }
        //////////////check email///////////////
    }
}