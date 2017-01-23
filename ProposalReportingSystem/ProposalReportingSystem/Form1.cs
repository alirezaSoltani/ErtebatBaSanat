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

namespace ProposalReportingSystem
{
    public partial class Form1 : Form
    {
        private int systemWidth;    //related to setSize
        private int systemHeight;   //related to setSize
        private int count;   //related to color of textbox
        private Global gl = new Global();   //related to setBounds

        private List<string> comboList = new List<string>();
        private List<Employers> emp = new List<Employers>();

        /// <summary>
        /// Current Values
        /// </summary>
        private string currentSelectedOption, currentSelectedIndex;
        /// <summary>
        /// Current Values
        /// </summary>



        /// <summary>
        /// Data gridview attributes
        /// </summary>
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        /// <summary>
        /// Data gridview attributes
        /// </summary>
         



        /// <summary>
        /// Data gridview attributes
        /// </summary>
        private DataBaseHandler dbh = new DataBaseHandler();
        /// <summary>
        /// Data gridview attributes
        /// </summary>





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
            /*System.Data.OleDb.OleDbConnection MyConnection;
            System.Data.DataSet DtSet;
            System.Data.OleDb.OleDbDataAdapter MyCommand;
            MyConnection = new System.Data.OleDb.OleDbConnection(@"provider=Microsoft.ACE.OLEDB.12.0;Data Source='d:/temp/test.xlsx';Extended Properties=Excel 8.0;");
            MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection);
            MyCommand.TableMappings.Add("Table", "Net-informations.com");
            DtSet = new System.Data.DataSet();
            MyCommand.Fill(DtSet);
            addProposalShowDgv.DataSource = DtSet.Tables[0];
            MyConnection.Close();*/
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
            /*MyConnection = new System.Data.OleDb.OleDbConnection(@"provider=Microsoft.ACE.OLEDB.12.0;Data Source='d:/temp/test.xlsx';Extended Properties=Excel 8.0;");
            MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection);
            MyCommand.TableMappings.Add("Table", "Net-informations.com");
            DtSet = new System.Data.DataSet();
            MyCommand.Fill(DtSet);
            searchProposalShowDgv.DataSource = DtSet.Tables[0];
            MyConnection.Close();*/
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
            gl.setSize(editProposalDeleteBtn, 120, 370, 70, 30);
            gl.setSize(editProposalClearBtn, 210, 370, 70, 30);



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

            gl.setSize(manageUserEditBtn, 130, 360, 80, 30);
            gl.setSize(manageUserAddBtn, 40, 360, 80, 30);
            gl.setSize(manageUserClearBtn, 310, 360, 80, 30);
            gl.setSize(manageUserDeleteBtn, 220, 360, 80, 30);

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
            gl.setSize(appSettingProcedureTypeRbtn, 205, 5, 23, 18);
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
            gl.setSize(appSettingProcedureTypeTxtbx, 605, 60, 170, 35);

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
            gl.setSize(manageTeacherExecutorFacultyCb, 300, 260, 160, 25);
            gl.setSize(manageTeacherExecutorTelTxtbx, 50, 15, 160, 25);
            gl.setSize(manageTeacherExecutorEmailTxtbx, 50, 130, 160, 25);
            gl.setSize(manageTeacherExecutorMobileTxtbx, 50, 260, 160, 25);

            gl.setSize(manageTeacherAddBtn, 50, 365, 80, 30);
            gl.setSize(manageTeacherEditBtn, 140, 365, 80, 30);
            gl.setSize(manageTeacherClearBtn, 230, 365, 80, 30);
            gl.setSize(manageTeacherDeleteBtn, 320, 365, 80, 30);

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
            addProposalExecutorFacultyCb.ResetText();
            addProposalExecutorEGroupCb.ResetText();
            addProposalExecutorEDegCb.ResetText();
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
            addProposalProcedureTypeCb.ResetText();
            addProposalPropertyTypeCb.ResetText();
            addProposalRegisterTypeCb.ResetText();
            addProposalProposalTypeCb.ResetText();
            addProposalOrganizationNameCb.ResetText();
            addProposalOrganizationNumberCb.ResetText();
            addProposalValueTxtbx.Clear();
            addProposalStatusCb.ResetText();
            //addProposalFileLinkLbl, 30, 330, 160, 25);
        }


        private void addProposalRegisterBtn_Click(object sender, EventArgs e)
        {
            /***************************Convert time*******************************************\
             string geo = addProposalStartdateTimeInput.GeoDate.ToString();
             MessageBox.Show(geo.Substring(0, 10));//---> shamsi to miladi

             string GregorianDate = geo.Substring(0, 10);
             DateTime d = DateTime.Parse(GregorianDate);
             PersianCalendar pc = new PersianCalendar();
             MessageBox.Show(string.Format("{0}-{1:00}-{2:00}", pc.GetYear(d), pc.GetMonth(d), pc.GetDayOfMonth(d)));//---> miladi to shamsi

           /***************************Convert time*******************************************\*/
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
                    dbh.AddProcedureType(appSettingProcedureTypeTxtbx.Text);
                    appSettingProcedureTypeTxtbx.Clear();
                    dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT procedureType from procedureTypeTable WHERE deleted = 0");

                    form_initializer(); // To Reset items of comboBoxes and others
                }
            }

            else if (appSettingPropertyTxtbx.Enabled == true)
            {
                if (!appSettingPropertyTxtbx.Text.Equals(""))
                {
                    dbh.AddPropertyType(appSettingPropertyTxtbx.Text);
                    appSettingPropertyTxtbx.Clear();
                    dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT propertyType from propertyTypeTable WHERE deleted = 0");

                    form_initializer(); // To Reset items of comboBoxes and others
                }
            }

            else if (appSettingFacultyTxtbx.Enabled == true)
            {
                if (!appSettingFacultyTxtbx.Text.Equals(""))
                {
                    dbh.AddFaculty(appSettingFacultyTxtbx.Text);
                    appSettingFacultyTxtbx.Clear();
                    dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT facultyName from facultyTable WHERE deleted = 0");

                    form_initializer(); // To Reset items of comboBoxes and others
                }
            }

            else if (appSettingRegTypeTxtbx.Enabled == true)
            {
                if (!appSettingRegTypeTxtbx.Text.Equals(""))
                {
                    dbh.AddRegisterType(appSettingRegTypeTxtbx.Text);
                    appSettingRegTypeTxtbx.Clear();
                    dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT registerType from registerTypeTable WHERE deleted = 0");

                    form_initializer(); // To Reset items of comboBoxes and others
                }
            }

            else if (appSettingProTypeTxtbx.Enabled == true)
            {
                if (!appSettingProTypeTxtbx.Text.Equals(""))
                {
                    dbh.AddProposalType(appSettingProTypeTxtbx.Text);
                    appSettingProTypeTxtbx.Clear();
                    dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT proposalType from proposalTypeTable WHERE deleted = 0");

                    form_initializer(); // To Reset items of comboBoxes and others
                }
            }

            else if (appSettingEgroupTxtbx.Enabled == true)
            {
                if (!appSettingEgroupTxtbx.Text.Equals(""))
                {
                    dbh.AddEGroup(appSettingFacultyTxtbx.Text,appSettingEgroupTxtbx.Text);
                    appSettingEgroupTxtbx.Clear();
                    dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT groupName FROM EGroupTable WHERE deleted = 0 AND facultyName='" + appSettingFacultyTxtbx.Text + "'");

                    form_initializer(); // To Reset items of comboBoxes and others
                }
            }

            else if (appSettingCoTxtbx.Enabled == true)
            {
                if (!appSettingCoTxtbx.Text.Equals(""))
                {
                    dbh.AddEmployer(appSettingCoTxtbx.Text);
                    appSettingCoTxtbx.Clear();
                    dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT * from employersTable WHERE deleted = 0");
                    appSettingShowDv.Columns[0].HeaderText = "نام سازمان";
                    appSettingShowDv.Columns[1].HeaderText = "کد سازمان";
                    appSettingShowDv.Columns[2].Visible = false;

                    form_initializer(); // To Reset items of comboBoxes and others
                }
            }

            else if (appSettingStatusTxtbx.Enabled == true)
            {
                if (!appSettingStatusTxtbx.Text.Equals(""))
                {
                    dbh.AddStatusType(appSettingStatusTxtbx.Text);
                    appSettingStatusTxtbx.Clear();
                    dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT statusType from statusTypeTable WHERE deleted = 0");

                    form_initializer(); // To Reset items of comboBoxes and others
                }
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

            dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT procedureType from procedureTypeTable WHERE deleted = 0");
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

            dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT propertyType from propertyTypeTable WHERE deleted = 0");
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

            dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT facultyName from facultyTable WHERE deleted = 0");
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

            dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT registerType from registerTypeTable WHERE deleted = 0");
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

            dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT proposalType from proposalTypeTable WHERE deleted = 0");
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

            dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT * FROM employersTable WHERE deleted = 0");
            appSettingShowDv.Columns[0].HeaderText = "کد سازمان";
            appSettingShowDv.Columns[1].HeaderText = "نام سازمان";
            appSettingShowDv.Columns[2].Visible = false;
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

            dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT statusType from statusTypeTable WHERE deleted = 0");
            appSettingShowDv.Columns[0].HeaderText = "وضعیت";
        }

        private void appSettingEditBtn_Click(object sender, EventArgs e)
        {
            if (appSettingProcedureTypeTxtbx.Enabled == true)
            {
                if (!appSettingProcedureTypeTxtbx.Text.Equals(""))
                {
                    dbh.EditProcedureType(appSettingProcedureTypeTxtbx.Text, currentSelectedOption);
                    appSettingProcedureTypeTxtbx.Clear();
                    dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT procedureType from procedureTypeTable WHERE deleted = 0");
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
                    dbh.EditPropertyType(appSettingPropertyTxtbx.Text, currentSelectedOption);
                    appSettingPropertyTxtbx.Clear();
                    dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT propertyType from propertyTypeTable WHERE deleted = 0");
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
                    dbh.EditFaculty(appSettingFacultyTxtbx.Text, currentSelectedOption);
                    appSettingFacultyTxtbx.Clear();
                    dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT facultyName from facultyTable WHERE deleted = 0");
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
                    dbh.EditRegisterType(appSettingRegTypeTxtbx.Text, currentSelectedOption);
                    appSettingRegTypeTxtbx.Clear();
                    dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT registerType from registerTypeTable WHERE deleted = 0");
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
                    dbh.EditProposalType(appSettingProTypeTxtbx.Text, currentSelectedOption);
                    appSettingProTypeTxtbx.Clear();
                    dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT proposalType from proposalTypeTable WHERE deleted = 0");
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
                    dbh.EditEGroup(appSettingEgroupTxtbx.Text, currentSelectedOption);
                    appSettingEgroupTxtbx.Clear();
                    dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT groupName FROM EGroupTable WHERE deleted = 0 AND facultyName='" + appSettingFacultyTxtbx.Text + "'");
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
                    dbh.EditEmployer(employer);
                    appSettingCoTxtbx.Clear();
                    dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT * FROM employersTable WHERE deleted = 0");
                    appSettingShowDv.Columns[0].HeaderText = "کد سازمان";
                    appSettingShowDv.Columns[1].HeaderText = "نام سازمان";
                    appSettingShowDv.Columns[2].Visible = false;

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
                    dbh.EditStatusType(appSettingStatusTxtbx.Text, currentSelectedOption);
                    appSettingStatusTxtbx.Clear();
                    dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT statusType from statusTypeTable WHERE deleted = 0");
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
                dbh.DeleteProcedureType(currentSelectedOption);
                appSettingProcedureTypeTxtbx.Clear();
                dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT procedureType from procedureTypeTable WHERE deleted = 0");
                appSettingShowDv.Columns[0].HeaderText = "نوع کار";
                appSettingEditBtn.Enabled = false;
                appSettingDeleteBtn.Enabled = false;

                form_initializer(); // To Reset items of comboBoxes and others
            }

            else if (appSettingPropertyTxtbx.Enabled == true)
            {
                dbh.DeletePropertyType(currentSelectedOption);
                appSettingPropertyTxtbx.Clear();
                dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT propertyType from propertyTypeTable WHERE deleted = 0");
                appSettingShowDv.Columns[0].HeaderText = "نوع خاصیت";
                appSettingEditBtn.Enabled = false;
                appSettingDeleteBtn.Enabled = false;

                form_initializer(); // To Reset items of comboBoxes and others
            }

            else if (appSettingFacultyTxtbx.Enabled == true)
            {
                dbh.DeleteFaculty(currentSelectedOption);
                appSettingFacultyTxtbx.Clear();
                dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT facultyName from facultyTable WHERE deleted = 0");
                appSettingShowDv.Columns[0].HeaderText = "نام دانشکده";
                appSettingEditBtn.Enabled = false;
                appSettingDeleteBtn.Enabled = false;

                form_initializer(); // To Reset items of comboBoxes and others
            }

            else if (appSettingRegTypeTxtbx.Enabled == true)
            {
                dbh.DeleteRegisterType(currentSelectedOption);
                appSettingRegTypeTxtbx.Clear();
                dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT registerType from registerTypeTable WHERE deleted = 0");
                appSettingShowDv.Columns[0].HeaderText = "نوع ثبت";
                appSettingEditBtn.Enabled = false;
                appSettingDeleteBtn.Enabled = false;

                form_initializer(); // To Reset items of comboBoxes and others
            }

            else if (appSettingProTypeTxtbx.Enabled == true)
            {
                dbh.DeleteProposalType(currentSelectedOption);
                appSettingProTypeTxtbx.Clear();
                dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT proposalType from proposalTypeTable WHERE deleted = 0");
                appSettingShowDv.Columns[0].HeaderText = "نوع پروپوزال";
                appSettingEditBtn.Enabled = false;
                appSettingDeleteBtn.Enabled = false;

                form_initializer(); // To Reset items of comboBoxes and others
            }

            else if (appSettingEgroupTxtbx.Enabled == true)
            {
                dbh.DeleteEGroup(currentSelectedOption);
                appSettingEgroupTxtbx.Clear();
                dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT groupName FROM EGroupTable WHERE deleted = 0 AND facultyName='" + appSettingFacultyTxtbx.Text + "'");
                appSettingShowDv.Columns[0].HeaderText = "گروه آموزشی";
                appSettingEditBtn.Enabled = false;
                appSettingDeleteBtn.Enabled = false;

                form_initializer(); // To Reset items of comboBoxes and others
            }

            else if (appSettingCoTxtbx.Enabled == true)
            {
                
                dbh.DeleteEmployers(long.Parse(currentSelectedIndex));
                appSettingCoTxtbx.Clear();
                dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT * FROM employersTable WHERE deleted = 0");
                appSettingShowDv.Columns[0].HeaderText = "کد سازمان";
                appSettingShowDv.Columns[1].HeaderText = "نام سازمان";
                appSettingShowDv.Columns[1].Visible = false;
                appSettingEditBtn.Enabled = false;
                appSettingDeleteBtn.Enabled = false;

                form_initializer(); // To Reset items of comboBoxes and others
            }

            else if (appSettingStatusTxtbx.Enabled == true)
            {
                dbh.DeleteStatusType(currentSelectedOption);
                appSettingStatusTxtbx.Clear();
                dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT statusType from  statusTypeTable WHERE deleted = 0");
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

                appSettingEgroupRbtn.Select();
                appSettingEgroupTxtbx.Enabled = true;

                MessageBox.Show(appSettingShowDv.Rows[e.RowIndex].Cells["facultyName"].Value.ToString());
                dbh.dataGridViewUpdate(appSettingShowDv, appSettingBindingSource, "SELECT groupName FROM EGroupTable WHERE deleted = 0 AND facultyName='" + appSettingShowDv.Rows[e.RowIndex].Cells["facultyName"].Value.ToString() + "'");
                appSettingShowDv.Columns[0].HeaderText = "گروه آموزشی";
            }
        }

        private void searchProposalClearBtn_Click(object sender, EventArgs e)
        {
            searchProposalExecutorNCodeTxtbx.Clear();
            searchProposalExecutorFNameTxtbx.Clear();
            searchProposalExecutorLNameTxtbx.Clear();
            searchProposalExecutorFacultyCb.SelectedIndex = 0;
            searchProposalExecutorEGroupCb.SelectedIndex = 0;
            searchProposalExecutorMobileTxtbx.Clear();
            searchProposalPersianTitleTxtbx.Clear();
            searchProposalEnglishTitleTxtbx.Clear();
            searchProposalStartDateFromTimeInput.ResetText();
            searchProposalStartDateToTimeInput.ResetText();
            searchProposalValueFromTxtbx.Clear();
            searchProposalValueToTxtbx.Clear();
            searchProposalProcedureTypeCb.SelectedIndex = 0;
            searchProposalPropertyTypeCb.SelectedIndex = 0;
            searchProposalRegisterTypeCb.SelectedIndex = 0;
            searchProposalTypeCb.SelectedIndex = 0;
            searchProposalOrganizationNumberCb.SelectedIndex = 0;
            searchProposalOrganizationNameCb.SelectedIndex = 0;
            searchProposalStatusCb.SelectedIndex = 0;
        }

        private void manageUserClearBtn_Click(object sender, EventArgs e)
        {
            manageUserFnameTxtbx.Clear();
            manageUserLnameTxtbx.Clear();
            manageUserNcodTxtbx.Clear();
            manageUserPasswordTxtbx.Clear();
            manageUserEmailTxtbx.Clear();
            manageUserTellTxtbx.Clear();
        }

        private void editProposalClearBtn_Click(object sender, EventArgs e)
        {
            editProposalExecutorNcodeTxtbx.Clear();
            editProposalExecutorFNameTxtbx.Clear();
            editProposalExecutorLNameTxtbx.Clear();
            editProposalExecutorFacultyCb.SelectedIndex = 0;
            editProposalExecutorEGroupCb.SelectedIndex = 0;
            editProposalExecutorEDegCb.SelectedIndex = 0;
            editProposalExecutorEmailTxtbx.Clear();
            editProposalExecutorMobileTxtbx.Clear();
            editProposalExecutorTel1Txtbx.Clear();
            editProposalExecutorTel2Txtbx.Clear();
            editProposalPersianTitleTxtbx.Clear();
            editProposalEnglishTitleTxtbx.Clear();
            editProposalKeywordsTxtbx.Clear();
            editProposalExecutor2Txtbx.Clear();
            editProposalCoexecutorTxtbx.Clear();
            editProposalStartdateTimeInput.ResetText();
            editProposalDurationTxtbx.Clear();
            editProposalProcedureTypeCb.SelectedIndex = 0;
            editProposalPropertyTypeCb.SelectedIndex = 0;
            editProposalRegisterTypeCb.SelectedIndex = 0;
            editProposalTypeCb.SelectedIndex = 0;
            editProposalOrganizationNameCb.SelectedIndex = 0;
            editProposalOrganizationNumberCb.SelectedIndex = 0;
            editProposalValueTxtbx.Clear();
            editProposalStatusCb.SelectedIndex = 0;
        }

        private void manageTeacherClearBtn_Click(object sender, EventArgs e)
        {
            manageTeacherExecutorNcodeTxtbx.Clear();
            manageTeacherFnameTxtbx.Clear();
            manageTeacherLnameTxtbx.Clear();
            manageTeacherExecutorEGroupTxtbx.Clear();
            manageTeacherExecutorEDegCb.SelectedIndex = 0;
            manageTeacherExecutorFacultyCb.SelectedIndex = 0;
            manageTeacherExecutorTelTxtbx.Clear();
            manageTeacherExecutorEmailTxtbx.Clear();
            manageTeacherExecutorMobileTxtbx.Clear();
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
            addProposalExecutorEGroupCb.Items.Clear();
            comboList = dbh.getEGroup(addProposalExecutorFacultyCb.SelectedItem.ToString());
            foreach (String eGroup in comboList)
            {
                addProposalExecutorEGroupCb.Items.Add(eGroup);
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
                if (addProposalOrganizationNumberCb.Text == "0")
                {
                    addProposalOrganizationNumberCb.BackColor = Color.Pink;
                }
                else
                {
                    addProposalOrganizationNameCb.SelectedIndex = (int.Parse(addProposalOrganizationNumberCb.Text) - 1);
                    addProposalOrganizationNumberCb.BackColor = Color.White;
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
            if (!addProposalExecutorEmailTxtbx.Text.Equals("") && !System.Text.RegularExpressions.Regex.IsMatch(addProposalExecutorEmailTxtbx.Text, @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"))
            {
                addProposalExecutorEmailTxtbx.BackColor = Color.Pink;
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(addProposalExecutorEmailTxtbx.Text, @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"))
            {
                addProposalExecutorEmailTxtbx.BackColor = Color.White;
            }
            if(addProposalExecutorEmailTxtbx.Text == "")
            {
                addProposalExecutorEmailTxtbx.BackColor = Color.White;
            }
        }

        private void appSettingBackgroundColorLbl_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
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

                appSettingBackgroundColorLbl.BackColor = dlg.Color;
            }
        }

        private void form_initializer()
        {
            addProposalExecutorFacultyCb.Items.Clear();
            addProposalProcedureTypeCb.Items.Clear();
            addProposalPropertyTypeCb.Items.Clear();
            addProposalRegisterTypeCb.Items.Clear();
            addProposalProposalTypeCb.Items.Clear();
            addProposalProcedureTypeCb.Items.Clear();
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
             //   MessageBox.Show(employer.Index.ToString() + "" + employer.OrgName);
            }

            comboList = dbh.getStatusType();
            foreach (String statusType in comboList)
            {
                addProposalStatusCb.Items.Add(statusType);
            }
        }
    }
}