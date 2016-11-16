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
            gl.setSize(mainTabControl, 0, 0, 990, 900);                       //related to setSize
            mainTabControl.TabHorizontalSpacing = (systemWidth / 200);

            //********************************************//
            //////////////add proposal design///////////////
            gl.setSize(addProposalPanel, 0, 1, 875, 930);
            gl.setSize(addProposalAddGp, 22, 15, 826, 425);
            gl.setSize(addProposalShowGp, 22, 450, 826, 450);
            gl.setSize(superTabControlPanel2, 0, 1, 880, 1000);
            gl.setSize(addProposalShowDgv, 3, 5, 817, 425);

            //Labels
            gl.setSize(addProposalPersianTitleLbl, 720, 25, 60, 25);
            gl.setSize(addProposalEnglishTitleLbl, 720, 65, 60, 25);
            gl.setSize(addProposalKeywordsLbl, 720, 105, 60, 25);
            gl.setSize(addProposalExecutorNcodeLbl, 720, 220, 60, 25);
            gl.setSize(addProposalExecutor2Lbl, 720, 260, 60, 25);

            gl.setSize(addProposalCoexecutorLbl, 460, 25, 60, 25);
            gl.setSize(addProposalStartdateLbl, 460, 140, 60, 25);
            gl.setSize(addProposalDurationLbl, 460, 180, 60, 25);
            gl.setSize(addProposalProcedureTypeLbl, 460, 220, 60, 25);
            gl.setSize(addProposalPropertyTypeLbl, 460, 260, 60, 25);
            gl.setSize(addProposalRegisterTypeLbl, 460, 300, 60, 25);

            gl.setSize(addProposalTypeLbl, 200, 25, 60, 25);
            gl.setSize(addProposalOrganizationLbl, 200, 65, 60, 25);
            gl.setSize(addProposalValueLbl, 200, 105, 60, 25);
            gl.setSize(addProposalStatusLbl, 200, 145, 60, 25);



            //NON labels
            gl.setSize(addProposalPersianTitleTxtbx, 550, 25, 160, 25);
            gl.setSize(addProposalEnglishTitleTxtbx, 550, 65, 160, 25);
            gl.setSize(addProposalKeywordsTxtbx, 550, 105, 160, 100);
            gl.setSize(addProposalExecutorNcodeTxtbx, 550, 220, 160, 25);
            gl.setSize(addProposalExecutor2Txtbx, 550, 260, 160, 100);

            gl.setSize(addProposalCoexecutorTxtbx, 290, 25, 160, 100);
            gl.setSize(addProposalStartdateTimeInput, 290, 140, 160, 25);
            gl.setSize(addProposalDurationTxtbx, 290, 180, 160, 100);
            gl.setSize(addProposalProcedureTypeCb, 290, 220, 160, 25);
            gl.setSize(addProposalPropertyTypeCb, 290, 260, 160, 25);
            gl.setSize(addProposalRegisterTypeCb, 290, 300, 160, 25);

            gl.setSize(addProposalTypeCb, 30, 25, 160, 25);
            gl.setSize(addProposalOrganizationCb, 30, 65, 160, 25);
            gl.setSize(addProposalValueTxtbx, 30, 105, 160, 25);
            gl.setSize(addProposalStatusCb, 30, 145, 160, 25);

            gl.setSize(addProposalRegisterBtn, 30, 290, 80, 45);
            gl.setSize(addProposalClearBtn, 120, 290, 80, 45);



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
            gl.setSize(editProposalShowDgv, 3, 5, 817, 425);

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
            //*********************************************//
            /////////////manage users design/////////////////
        }
    }
}