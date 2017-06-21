﻿using DevComponents.DotNetBar.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProposalReportingSystem
{
    class DataBaseHandler
    {
        string conString = "Data Source= 169.254.92.252;" +
                "Initial Catalog=rayanpro_EBS;" +
                "User id=test; " +
                "Password=HoseinNima1234;";

        //string conString = "Data Source= 185.159.152.2;" +
        //       "Initial Catalog=rayanpro_EBS;" +
        //       "User id=rayanpro_rayan; " +
        //       "Password=P@hn1395;";

        private Toast toast;//related to toast messages
        private PopUp popup;
        ////
        public int PgSize = 5;
        /////

        ////// string queries

        public string addProposalQuery; // "SELECT TOP " + PgSize + " * FROM proposalTable"
        public string searchProposalQuery;
        public string editProposalQuery;
        public string manageTeacherQuery;
        public string logQuery;



        /// <summary>
        /// Data gridview attributes
        /// </summary>
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        /// <summary>
        /// Data gridview attributes
        /// </summary>




        /// <summary>
        /// querry for proposals
        /// </summary>
        /// <param name="proposal"></param>

        public void AddProposal(Proposal proposal, long username, String dateTime, FTPSetting _inputParameter)
        {
            //String persianTitle, String engTitle , String keyword, long executor, String executor2 , String coExecutor, String startDate , int duration, String procedureType , String propertyType, String registerType , String proposalType, long employer, String value , String status, long registrant


            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            conn.Open();
            SqlCommand sc = new SqlCommand();
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            SqlDataReader reader;

            SqlTransaction transaction;
            transaction = conn.BeginTransaction("new");
            sc.Transaction = transaction;


            try
            {
                sc.CommandText = "INSERT INTO proposalTable (persianTitle,engTitle,keyword,executor,executor2,coExecutor,startDate,duration,procedureType,propertyType,registerType,proposalType,employer,value,status,registrant)"
                                + "VALUES ('" + proposal.PersianTitle + "',"
                                         + "'" + proposal.EngTitle + "',"
                                         + "'" + proposal.KeyWord + "',"
                                         + "'" + proposal.Executor + "',"
                                         + "'" + proposal.Executor2 + "',"
                                         + "'" + proposal.CoExecutor + "',"
                                         + "'" + proposal.StartDate + "',"
                                         + "'" + proposal.Duration + "',"
                                         + "'" + proposal.ProcedureType + "',"
                                         + "'" + proposal.PropertyType + "',"
                                         + "'" + proposal.RegisterType + "',"
                                         + "'" + proposal.ProposalType + "',"
                                         + "'" + proposal.Employer + "',"
                                         + "'" + proposal.Value + "',"
                                         + "'" + proposal.Status + "',"
                                         + "'" + proposal.Registrant + "')";

                sc.ExecuteNonQuery();


                sc.CommandText = " INSERT INTO logTable (username , dateTime , description ,tableName) VALUES ('" + username + "','" + dateTime + "','" + "Added " + proposal.PersianTitle + "','" + "proposalTable'" + ")";
                sc.ExecuteNonQuery();
                sc.CommandText = "SELECT [index] FROM proposalTable WHERE persianTitle = '" + proposal.PersianTitle + "'  ";
                reader = sc.ExecuteReader();
                reader.Read();
                proposal.Index = reader.GetInt64(0);


                if (_inputParameter.FileName.Contains(".docx"))
                {
                    _inputParameter.FileName = proposal.Index.ToString() + ".docx";
                }
                else if (_inputParameter.FileName.Contains(".doc"))
                {
                    _inputParameter.FileName = proposal.Index.ToString() + ".doc";
                }
                if (_inputParameter.FileName.Contains(".pdf"))
                {
                    _inputParameter.FileName = proposal.Index.ToString() + ".pdf";
                }


                uploadFile(_inputParameter);

                reader.Close();

                sc.CommandText = "UPDATE proposalTable SET fileName = '" + _inputParameter.FileName + "' WHERE [index] = '" + proposal.Index + "'";
                sc.ExecuteNonQuery();

                sc.CommandText = "INSERT INTO editionTable ([index] , persianTitle,engTitle,keyword,executor,executor2,coExecutor,startDate,duration,procedureType,propertyType,registerType,proposalType,employer,value,status,registrant,fileName , edition)"
                               + "VALUES ('" + proposal.Index + "',"
                                        + "'" + proposal.PersianTitle + "',"
                                         + "'" + proposal.EngTitle + "',"
                                        + "'" + proposal.KeyWord + "',"
                                        + "'" + proposal.Executor + "',"
                                        + "'" + proposal.Executor2 + "',"
                                        + "'" + proposal.CoExecutor + "',"
                                        + "'" + proposal.StartDate + "',"
                                        + "'" + proposal.Duration + "',"
                                        + "'" + proposal.ProcedureType + "',"
                                        + "'" + proposal.PropertyType + "',"
                                        + "'" + proposal.RegisterType + "',"
                                        + "'" + proposal.ProposalType + "',"
                                        + "'" + proposal.Employer + "',"
                                        + "'" + proposal.Value + "',"
                                        + "'" + proposal.Status + "',"
                                        + "'" + proposal.Registrant + "',"
                                        + "'" + _inputParameter.FileName + "',"
                                        + "'" + 0 + "')";
                sc.ExecuteNonQuery();


                transaction.Commit();
                popup = new PopUp("ثبت موفقیت آمیز", "اطلاعات پروپوزال با موفقیت ثبت شد.", "تایید", "", "", "success");
                popup.ShowDialog();
            }
            catch
            {
                //popup = new PopUp("خطا", "خطا در برقراری ارتباط با سرور", "تایید", "", "", "error");
                //popup.ShowDialog();
                string context = "خطا در برقراری ارتباط با سرور.";
                Alert alert = new Alert(context, "darkred", 5);
                try
                {
                    transaction.Rollback();
                    DeleteFile(_inputParameter.FileName);
                }
                catch
                {
                    //popup = new PopUp("خطا", "خطا در برقراری ارتباط با سرور", "تایید", "", "", "error");
                    //popup.ShowDialog();
                }
            }

            conn.Close();
        }

        public void EditProposal(Proposal proposal, long username, String dateTime,FTPSetting _inputParameter,string currentFileName)
        {

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            conn.Open();
            SqlCommand sc = new SqlCommand();
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            SqlDataReader reader;


            SqlTransaction transaction;
            transaction = conn.BeginTransaction("new");
            sc.Transaction = transaction;

            try
            {
                sc.CommandText = "UPDATE proposalTable SET persianTitle = " + "'" + proposal.PersianTitle + "',"
                                                    + "engTitle =" + "'" + proposal.EngTitle + "',"
                                                    + "keyword =" + "'" + proposal.KeyWord + "',"
                                                    + "executor =" + "'" + proposal.Executor + "',"
                                                    + "executor2 = " + "'" + proposal.Executor2 + "',"
                                                    + " coExecutor = " + "'" + proposal.CoExecutor + "',"
                                                    + "  startDate=" + "'" + proposal.StartDate + "',"
                                                    + "duration=" + "'" + proposal.Duration + "',"
                                                    + "procedureType =" + "'" + proposal.ProcedureType + "',"
                                                    + " propertyType = " + "'" + proposal.PropertyType + "',"
                                                    + "registerType =" + "'" + proposal.RegisterType + "',"
                                                    + "proposalType =" + "'" + proposal.ProposalType + "',"
                                                    + " employer = " + "'" + proposal.Employer + "',"
                                                    + " value = " + "'" + proposal.Value + "',"
                                                    + " status = " + "'" + proposal.Status + "' "
                                                    + " WHERE [index] = " + proposal.Index + "";

                sc.ExecuteNonQuery();

                sc.CommandText = "UPDATE editionTable SET persianTitle = " + "'" + proposal.PersianTitle + "',"
                                                   + "engTitle =" + "'" + proposal.EngTitle + "',"
                                                   + "keyword =" + "'" + proposal.KeyWord + "',"
                                                   + "executor =" + "'" + proposal.Executor + "',"
                                                   + "executor2 = " + "'" + proposal.Executor2 + "',"
                                                   + " coExecutor = " + "'" + proposal.CoExecutor + "',"
                                                   + " startDate=" + "'" + proposal.StartDate + "',"
                                                   + "duration=" + "'" + proposal.Duration + "',"
                                                   + "procedureType =" + "'" + proposal.ProcedureType + "',"
                                                   + " propertyType = " + "'" + proposal.PropertyType + "',"
                                                   + "registerType =" + "'" + proposal.RegisterType + "',"
                                                   + "proposalType =" + "'" + proposal.ProposalType + "',"
                                                   + " employer = " + "'" + proposal.Employer + "',"
                                                   + " value = " + "'" + proposal.Value + "',"
                                                   + " status = " + "'" + proposal.Status + "' "
                                                   + " WHERE  [index] = " + proposal.Index + " AND edition = 0 ";

                sc.ExecuteNonQuery();

                sc.CommandText = " INSERT INTO logTable (username , dateTime , description ,tableName) VALUES ('" + username + "','" + dateTime + "','" + "Edited " + proposal.PersianTitle + "','" + "proposalTable'" + ")";
                sc.ExecuteNonQuery();
                if (_inputParameter.FileName != "")
                {
                    sc.CommandText = "SELECT [index] FROM proposalTable WHERE persianTitle = '" + proposal.PersianTitle + "'  ";
                    reader = sc.ExecuteReader();
                    reader.Read();
                    proposal.Index = reader.GetInt64(0);

                    DeleteFile(currentFileName);

                    if (_inputParameter.FileName.Contains(".docx"))
                    {
                        _inputParameter.FileName = proposal.Index.ToString() + ".docx";
                    }
                    else if (_inputParameter.FileName.Contains(".doc"))
                    {
                        _inputParameter.FileName = proposal.Index.ToString() + ".doc";
                    }
                    if (_inputParameter.FileName.Contains(".pdf"))
                    {
                        _inputParameter.FileName = proposal.Index.ToString() + ".pdf";
                    }
                    
                    uploadFile(_inputParameter);
                    reader.Close();
                }
                transaction.Commit();
                popup = new PopUp("تغییرات موفقیت آمیز", "تغییر اطلاعات با موفقیت انجام شد.", "تایید", "", "", "success");
                popup.ShowDialog();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                string context = "خطا در برقراری ارتباط با سرور.";
                Alert alert = new Alert(context, "darkred", 5);
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    //popup = new PopUp("خطا", "خطا در برقراری ارتباط با سرور", "تایید", "", "", "error");
                    //popup.ShowDialog();
                }
            }

            conn.Close();

        }

        public void DeleteProposal(Proposal proposal, long username, String dateTime)
        {

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            conn.Open();
            SqlCommand sc = new SqlCommand();
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;


            SqlTransaction transaction;
            transaction = conn.BeginTransaction("new");
            sc.Transaction = transaction;




            try
            {
                sc.CommandText = " DELETE FROM proposalTable WHERE [index] = '" + proposal.Index + "'";
                sc.ExecuteNonQuery();
                sc.CommandText = " DELETE FROM editionTable WHERE [index] = '" + proposal.Index + "'";
                sc.ExecuteNonQuery();
                sc.CommandText = " INSERT INTO deletedProposalTable ([index],persianTitle,engTitle,keyword,executor,executor2,coExecutor,startDate,duration,procedureType,propertyType,registerType,proposalType,employer,value,status,registrant,username,date)"
                                + "VALUES ('" + proposal.Index + "',"
                                         + "'" + proposal.PersianTitle + "',"
                                         + "'" + proposal.EngTitle + "',"
                                         + "'" + proposal.KeyWord + "',"
                                         + "'" + proposal.Executor + "',"
                                         + "'" + proposal.Executor2 + "',"
                                         + "'" + proposal.CoExecutor + "',"
                                         + "'" + proposal.StartDate + "',"
                                         + "'" + proposal.Duration + "',"
                                         + "'" + proposal.ProcedureType + "',"
                                         + "'" + proposal.PropertyType + "',"
                                         + "'" + proposal.RegisterType + "',"
                                         + "'" + proposal.ProposalType + "',"
                                         + "'" + proposal.Employer + "',"
                                         + "'" + proposal.Value + "',"
                                         + "'" + proposal.Status + "',"
                                         + "'" + proposal.Registrant + "',"
                                         + "'" + username + "',"
                                         + "'" + dateTime + "')";

                sc.ExecuteNonQuery();
                sc.CommandText = " INSERT INTO logTable (username , dateTime , description ,tableName) VALUES ('" + username + "','" + dateTime + "','" + "deleted " + proposal.PersianTitle + "','" + "proposalTable'" + ")";
                sc.ExecuteNonQuery();

                MoveFileToDeleted(proposal.FileName);
                transaction.Commit();
                popup = new PopUp("حذف موفقیت آمیز", "حذف اطلاعات با موفقیت انجام شد.", "تایید", "", "", "success");
                popup.ShowDialog();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                string context = "خطا در برقراری ارتباط با سرور.";
                Alert alert = new Alert(context, "darkred", 5);
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    //popup = new PopUp("خطا", "خطا در برقراری ارتباط با سرور", "تایید", "", "", "error");
                    //popup.ShowDialog();
                }
            }

            conn.Close();

        }

        public void AddEdition(Proposal proposal, long username, String dateTime, FTPSetting _inputParameter)
        {
            //String persianTitle, String engTitle , String keyword, long executor, String executor2 , String coExecutor, String startDate , int duration, String procedureType , String propertyType, String registerType , String proposalType, long employer, String value , String status, long registrant


            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            conn.Open();
            SqlCommand sc = new SqlCommand();
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            SqlDataReader reader;


            SqlTransaction transaction;
            transaction = conn.BeginTransaction("new");
            sc.Transaction = transaction;


            try
            {
                sc.CommandText = "SELECT edition From editionTable WHERE [index] = '" + proposal.Index + "' ORDER BY edition DESC";
                reader = sc.ExecuteReader();
                reader.Read();
                int EditionNumber = reader.GetInt32(0) + 1;
                reader.Close();


                if (_inputParameter.FileName.Contains(".docx"))
                {
                    _inputParameter.FileName = proposal.Index.ToString() + "-" + EditionNumber + ".docx";
                }
                else if (_inputParameter.FileName.Contains(".doc"))
                {
                    _inputParameter.FileName = proposal.Index.ToString() + "-" + EditionNumber + ".doc";
                }
                if (_inputParameter.FileName.Contains(".pdf"))
                {
                    _inputParameter.FileName = proposal.Index.ToString() + "-" + EditionNumber + ".pdf";
                }




                sc.CommandText = "INSERT INTO editionTable ([index] , persianTitle,engTitle,keyword,executor,executor2,coExecutor,startDate,duration,procedureType,propertyType,registerType,proposalType,employer,value,status,registrant,fileName , edition)"
                               + "VALUES ('" + proposal.Index + "',"
                                        + "'" + proposal.PersianTitle + "',"
                                         + "'" + proposal.EngTitle + "',"
                                        + "'" + proposal.KeyWord + "',"
                                        + "'" + proposal.Executor + "',"
                                        + "'" + proposal.Executor2 + "',"
                                        + "'" + proposal.CoExecutor + "',"
                                        + "'" + proposal.StartDate + "',"
                                        + "'" + proposal.Duration + "',"
                                        + "'" + proposal.ProcedureType + "',"
                                        + "'" + proposal.PropertyType + "',"
                                        + "'" + proposal.RegisterType + "',"
                                        + "'" + proposal.ProposalType + "',"
                                        + "'" + proposal.Employer + "',"
                                        + "'" + proposal.Value + "',"
                                        + "'" + proposal.Status + "',"
                                        + "'" + proposal.Registrant + "',"
                                        + "'" + _inputParameter.FileName + "',"
                                        + "'" + EditionNumber + "')";
                sc.ExecuteNonQuery();

                sc.CommandText = " INSERT INTO logTable (username , dateTime , description ,tableName) VALUES ('" + username + "','" + dateTime + "','" + "Added edition " + EditionNumber + " of proposal " + proposal.PersianTitle + " ',' EditionTable ' )";
                sc.ExecuteNonQuery();


                uploadFile(_inputParameter);

                reader.Close();


                transaction.Commit();
                popup = new PopUp("ثبت موفقیت آمیز", "اطلاعات اصلاحیه پروپوزال با موفقیت ثبت شد.", "تایید", "", "", "success");
                popup.ShowDialog();
                //string context = "اطلاعات اصلاحیه پروپوزال با موفقیت ثبت شد.";
                //Alert alert = new Alert(context, "blue", 5);
            }
            catch
            {
                //popup = new PopUp("خطا", "خطا در برقراری ارتباط با سرور", "تایید", "", "", "error");
                //popup.ShowDialog();
                string context = "خطا در برقراری ارتباط با سرور.";
                Alert alert = new Alert(context, "darkred", 5);
                try
                {
                    transaction.Rollback();
                    DeleteFile(_inputParameter.FileName);
                }
                catch
                {
                    //popup = new PopUp("خطا", "خطا در برقراری ارتباط با سرور", "تایید", "", "", "error");
                    //popup.ShowDialog();
                }
            }

            conn.Close();
        }

        public void EditEdition(Proposal proposal, int EditionNumber, long username, String dateTime, FTPSetting _inputParameter, string currentFileName)
        {

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            conn.Open();
            SqlCommand sc = new SqlCommand();
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
           

            SqlTransaction transaction;
            transaction = conn.BeginTransaction("new");
            sc.Transaction = transaction;

            try
            {

                sc.CommandText = "UPDATE editionTable SET persianTitle = " + "'" + proposal.PersianTitle + "',"
                                                   + "engTitle =" + "'" + proposal.EngTitle + "',"
                                                   + "keyword =" + "'" + proposal.KeyWord + "',"
                                                   + "executor =" + "'" + proposal.Executor + "',"
                                                   + "executor2 = " + "'" + proposal.Executor2 + "',"
                                                   + " coExecutor = " + "'" + proposal.CoExecutor + "',"
                                                   + " startDate=" + "'" + proposal.StartDate + "',"
                                                   + "duration=" + "'" + proposal.Duration + "',"
                                                   + "procedureType =" + "'" + proposal.ProcedureType + "',"
                                                   + " propertyType = " + "'" + proposal.PropertyType + "',"
                                                   + "registerType =" + "'" + proposal.RegisterType + "',"
                                                   + "proposalType =" + "'" + proposal.ProposalType + "',"
                                                   + " employer = " + "'" + proposal.Employer + "',"
                                                   + " value = " + "'" + proposal.Value + "',"
                                                   + " status = " + "'" + proposal.Status + "' "
                                                   + " WHERE  [index] = " + proposal.Index + " AND edition = " + EditionNumber;

                sc.ExecuteNonQuery();

                sc.CommandText = " INSERT INTO logTable (username , dateTime , description ,tableName) VALUES ('" + username + "','" + dateTime + "','" + "Edited " + proposal.PersianTitle + " Edition " + EditionNumber + " ','" + "EditionTable'" + ")";
                sc.ExecuteNonQuery();

                if (_inputParameter.FileName != "")
                {

                    DeleteFile(currentFileName);

                    if (_inputParameter.FileName.Contains(".docx"))
                    {
                        _inputParameter.FileName = proposal.Index.ToString() + "-" + EditionNumber + ".docx";
                    }
                    else if (_inputParameter.FileName.Contains(".doc"))
                    {
                        _inputParameter.FileName = proposal.Index.ToString() + "-" + EditionNumber + ".doc";
                    }
                    if (_inputParameter.FileName.Contains(".pdf"))
                    {
                        _inputParameter.FileName = proposal.Index.ToString() + "-" + EditionNumber + ".pdf";
                    }
                    uploadFile(_inputParameter);
                }

                transaction.Commit();
                popup = new PopUp("تغییرات موفقیت آمیز", "تغییر اطلاعات با موفقیت انجام شد.", "تایید", "", "", "success");
                popup.ShowDialog();
            }
            catch
            {
                string context = "خطا در برقراری ارتباط با سرور.";
                Alert alert = new Alert(context, "darkred", 5);
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    //popup = new PopUp("خطا", "خطا در برقراری ارتباط با سرور", "تایید", "", "", "error");
                    //popup.ShowDialog();
                }
            }

            conn.Close();

        }

        public void DeleteEdition(Proposal proposal, int EditionNumber, long username, String dateTime)
        {

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            conn.Open();
            SqlCommand sc = new SqlCommand();
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;


            SqlTransaction transaction;
            transaction = conn.BeginTransaction("new");
            sc.Transaction = transaction;

            try
            {

                sc.CommandText = " DELETE FROM editionTable WHERE [index] = '" + proposal.Index + "' AND edition = " + EditionNumber;
                sc.ExecuteNonQuery();
                sc.CommandText = " INSERT INTO deletedEditionTable ([index],persianTitle,engTitle,keyword,executor,executor2,coExecutor,startDate,duration,procedureType,propertyType,registerType,proposalType,employer,value,status,registrant,edition,username,date)"
                                + "VALUES ('" + proposal.Index + "',"
                                         + "'" + proposal.PersianTitle + "',"
                                         + "'" + proposal.EngTitle + "',"
                                         + "'" + proposal.KeyWord + "',"
                                         + "'" + proposal.Executor + "',"
                                         + "'" + proposal.Executor2 + "',"
                                         + "'" + proposal.CoExecutor + "',"
                                         + "'" + proposal.StartDate + "',"
                                         + "'" + proposal.Duration + "',"
                                         + "'" + proposal.ProcedureType + "',"
                                         + "'" + proposal.PropertyType + "',"
                                         + "'" + proposal.RegisterType + "',"
                                         + "'" + proposal.ProposalType + "',"
                                         + "'" + proposal.Employer + "',"
                                         + "'" + proposal.Value + "',"
                                         + "'" + proposal.Status + "',"
                                         + "'" + proposal.Registrant + "',"
                                         + "'" + EditionNumber + "',"
                                         + "'" + username + "',"
                                         + "'" + dateTime + "')";

                sc.ExecuteNonQuery();
                sc.CommandText = " INSERT INTO logTable (username , dateTime , description ,tableName) VALUES ('" + username + "','" + dateTime + "','" + "deleted " + proposal.PersianTitle + " edition " + EditionNumber + " ','" + "EditionTable'" + ")";
                sc.ExecuteNonQuery();

                MoveFileToDeleted(proposal.FileName);

                transaction.Commit();
                popup = new PopUp("حذف موفقیت آمیز", "حذف اطلاعات با موفقیت انجام شد.", "تایید", "", "", "success");
                popup.ShowDialog();
            }
            catch
            {
                string context = "خطا در برقراری ارتباط با سرور.";
                Alert alert = new Alert(context, "darkred", 5);
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    //popup = new PopUp("خطا", "خطا در برقراری ارتباط با سرور", "تایید", "", "", "error");
                    //popup.ShowDialog();
                }
            }

            conn.Close();

        }




        ///////////end query for proposals

        /// <summary>
        /// querry for users
        /// </summary>
        /// <param name="Users"></param>


        public void AddUser(User user, long username, String dateTime)
        {

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            conn.Open();
            SqlCommand sc = new SqlCommand();
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;


            SqlTransaction transaction;
            transaction = conn.BeginTransaction("new");
            sc.Transaction = transaction;


            try
            {
                sc.CommandText = "INSERT INTO UsersTable (u_FName , u_LName , u_NCode , u_Password ,u_Email , u_Tel , u_canAddProposal , u_canEditProposal , u_canDeleteProposal , u_canAddUser,u_canEditUser , u_canDeleteUser,u_canManageTeacher,u_canManageType,u_Color)"
                             + " VALUES ('" + user.U_FName + "',"
                                      + "'" + user.U_LName + "',"
                                      + "'" + user.U_NCode + "',"
                                      + "'" + user.U_Password + "',"
                                      + "'" + user.U_Email + "',"
                                      + "'" + user.U_Tel + "',"
                                      + "'" + user.CanAddProposal + "',"
                                      + "'" + user.CanEditProposal + "',"
                                      + "'" + user.CanDeleteProposal + "',"
                                      + "'" + user.CanAddUser + "',"
                                      + "'" + user.CanEditUser + "',"
                                      + "'" + user.CanDeleteUser + "',"
                                      + "'" + user.CanManageTeacher + "',"
                                      + "'" + user.CanManageType + "',"
                                      + "'" + user.U_Color + "')";

                sc.ExecuteNonQuery();
                sc.CommandText = " INSERT INTO logTable (username , dateTime , description ,tableName) VALUES ('" + username + "','" + dateTime + "','" + "Added " + user.U_NCode + "','" + "UsersTable'" + ")";
                sc.ExecuteNonQuery();

                transaction.Commit();
                popup = new PopUp("ثبت موفقیت آمیز", "افزودن اطلاعات با موفقیت انجام شد.", "تایید", "", "", "success");
                popup.ShowDialog();
            }
            catch
            {
                string context = "خطا در برقراری ارتباط با سرور.";
                Alert alert = new Alert(context, "darkred", 5);
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    //popup = new PopUp("خطا", "خطا در برقراری ارتباط با سرور", "تایید", "", "", "error");
                    //popup.ShowDialog();
                }
            }

            conn.Close();

        }
        public void EditUsers(User user, long NCode, long username, String dateTime)
        {


            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            conn.Open();
            SqlCommand sc = new SqlCommand();
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;


            SqlTransaction transaction;
            transaction = conn.BeginTransaction("new");
            sc.Transaction = transaction;

            try
            {
                sc.CommandText = "UPDATE UsersTable SET u_FName = " + "'" + user.U_FName + "',"
                                                    + "u_LName =" + "'" + user.U_LName + "',"
                                                    + "u_NCode =" + "'" + user.U_NCode + "',"
                                                    + "u_Password =" + "'" + user.U_Password + "',"
                                                    + "u_Email = " + "'" + user.U_Email + "',"
                                                    + " u_Tel = " + "'" + user.U_Tel + "',"
                                                    + " u_canAddProposal = " + "'" + user.CanAddProposal + "',"
                                                    + " u_canEditProposal = " + "'" + user.CanEditProposal + "',"
                                                    + " u_canDeleteProposal = " + "'" + user.CanDeleteProposal + "',"
                                                    + " u_canAddUser = " + "'" + user.CanAddUser + "',"
                                                    + " u_canEditUser = " + "'" + user.CanEditUser + "',"
                                                    + " u_canDeleteUser = " + "'" + user.CanDeleteUser + "',"
                                                    + " u_canManageTeacher = " + "'" + user.CanManageTeacher + "',"
                                                    + " u_canManageType = " + "'" + user.CanManageType + "',"
                                                    + " u_Color = " + "'" + user.U_Color + "' "
                                                    + " WHERE u_NCode = " + NCode + "";

                sc.ExecuteNonQuery();
                sc.CommandText = " INSERT INTO logTable (username , dateTime , description ,tableName) VALUES ('" + username + "','" + dateTime + "','" + "Edited " + user.U_NCode + " ','" + "UsersTable'" + ")";
                sc.ExecuteNonQuery();

                transaction.Commit();
                popup = new PopUp("تغییر موفقیت آمیز", "تغییر اطلاعات با موفقیت انجام شد.", "تایید", "", "", "success");
                popup.ShowDialog();
            }
            catch
            {
                string context = "خطا در برقراری ارتباط با سرور.";
                Alert alert = new Alert(context, "darkred", 5);
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    //popup = new PopUp("خطا", "خطا در برقراری ارتباط با سرور", "تایید", "", "", "error");
                    //popup.ShowDialog();
                }
            }

            conn.Close();
        }

        public void DeleteUser(User user, long username, String dateTime)
        {

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            conn.Open();
            SqlCommand sc = new SqlCommand();
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;


            SqlTransaction transaction;
            transaction = conn.BeginTransaction("new");
            sc.Transaction = transaction;




            try
            {
                sc.CommandText = " DELETE FROM UsersTable WHERE u_NCode = '" + user.U_NCode + "'";
                sc.ExecuteNonQuery();
                sc.CommandText = "INSERT INTO deletedUsersTable (u_FName , u_LName , u_NCode , u_Password ,u_Email , u_Tel , u_canAddProposal , u_canEditProposal , u_canDeleteProposal , u_canAddUser, u_canEditUser , u_canDeleteUser ,u_canManageTeacher, u_canManageType, u_Color , username ,date)"
                            + " VALUES ('" + user.U_FName + "',"
                                     + "'" + user.U_LName + "',"
                                     + "'" + user.U_NCode + "',"
                                     + "'" + user.U_Password + "',"
                                     + "'" + user.U_Email + "',"
                                     + "'" + user.U_Tel + "',"
                                     + "'" + user.CanAddProposal + "',"
                                     + "'" + user.CanEditProposal + "',"
                                     + "'" + user.CanDeleteProposal + "',"
                                     + "'" + user.CanAddUser + "',"
                                     + "'" + user.CanEditUser + "',"
                                     + "'" + user.CanDeleteUser + "',"
                                     + "'" + user.CanManageTeacher + "',"
                                     + "'" + user.CanManageTeacher + "',"
                                     + "'" + user.U_Color + "',"
                                     + "'" + username + "',"
                                     + "'" + dateTime + "')";
                sc.ExecuteNonQuery();
                sc.CommandText = " INSERT INTO logTable (username , dateTime , description ,tableName) VALUES ('" + username + "','" + dateTime + "','" + "deleted " + user.U_NCode + "','" + "UsersTable" + "')";
                sc.ExecuteNonQuery();

                transaction.Commit();
                popup = new PopUp("حذف موفقیت آمیز", "حذف اطلاعات با موفقیت انجام شد.", "تایید", "", "", "success");
                popup.ShowDialog();
            }
            catch
            {
                string context = "خطا در برقراری ارتباط با سرور.";
                Alert alert = new Alert(context, "darkred", 5);
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    //popup = new PopUp("خطا", "خطا در برقراری ارتباط با سرور", "تایید", "", "", "error");
                    //popup.ShowDialog();
                }
            }

            conn.Close();

        }

        public void changeColor(long username, string color)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            conn.Open();
            SqlCommand sc = new SqlCommand();
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;


            SqlTransaction transaction;
            transaction = conn.BeginTransaction("new");
            sc.Transaction = transaction;




            try
            {
                sc.CommandText = " UPDATE UsersTable SET u_color = " + "'" + color + "' WHERE u_NCode = '" + username + "'";
                sc.ExecuteNonQuery();

                transaction.Commit();

            }
            catch
            {
                string context = "خطا در برقراری ارتباط با سرور.";
                Alert alert = new Alert(context, "darkred", 5);
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    //popup = new PopUp("خطا", "خطا در برقراری ارتباط با سرور", "تایید", "", "", "error");
                    //popup.ShowDialog();
                }
            }

            conn.Close();
        }
        public string getColor(long username)
        {
            string color = "";
            try
            {


                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                SqlCommand sc = new SqlCommand();
                SqlDataReader reader;
                sc.CommandText = "SELECT u_color FROM UsersTable WHERE u_NCode = '" + username + "'";
                sc.CommandType = CommandType.Text;
                sc.Connection = conn;
                conn.Open();
                reader = sc.ExecuteReader();

                reader.Read();
                color = reader.GetString(0);
                conn.Close();
            }
            catch
            {

            }
            return color;
        }

        public void changePassword(long username, string Password, String dateTime)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            conn.Open();
            SqlCommand sc = new SqlCommand();
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;


            SqlTransaction transaction;
            transaction = conn.BeginTransaction("new");
            sc.Transaction = transaction;




            try
            {
                sc.CommandText = " UPDATE UsersTable SET u_Password = " + "'" + Password + "' WHERE u_NCode = '" + username + "'";
                sc.ExecuteNonQuery();
                sc.CommandText = " INSERT INTO logTable (username , dateTime , description ,tableName) VALUES ('" + username + "','" + dateTime + "','" + "change Password to  " + Password + "','" + "UsersTable" + "')";
                sc.ExecuteNonQuery();


                transaction.Commit();

            }
            catch
            {
                string context = "خطا در برقراری ارتباط با سرور.";
                Alert alert = new Alert(context, "darkred", 5);
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    //popup = new PopUp("خطا", "خطا در برقراری ارتباط با سرور", "تایید", "", "", "error");
                    //popup.ShowDialog();
                }
            }

            conn.Close();
        }




        //////////////////end query Users


        /// <summary>
        /// querry for teachers
        /// </summary>
        /// <param name="Teachers"></param>
        public void AddTeacher(Teachers teacher, long username, String dateTime)
        {

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            conn.Open();
            SqlCommand sc = new SqlCommand();
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;


            SqlTransaction transaction;
            transaction = conn.BeginTransaction("new");
            sc.Transaction = transaction;


            try
            {
                sc.CommandText = "INSERT INTO TeacherTable (t_FName , t_LName , t_NCode , t_EDeg ,t_Email , t_Group , t_Mobile ,t_Tel1,t_Tel2,t_Faculty)"
                                + "VALUES ('" + teacher.T_FName + "',"
                                         + "'" + teacher.T_LName + "',"
                                         + "'" + teacher.T_NCode + "',"
                                         + "'" + teacher.T_EDeg + "',"
                                         + "'" + teacher.T_Email + "',"
                                         + "'" + teacher.T_Group + "',"
                                         + "'" + teacher.T_Mobile + "',"
                                         + "'" + teacher.T_Tel1 + "',"
                                         + "'" + teacher.T_Tel2 + "',"
                                         + "'" + teacher.T_Faculty + "')";

                sc.ExecuteNonQuery();
                sc.CommandText = " INSERT INTO logTable (username , dateTime , description ,tableName) VALUES ('" + username + "','" + dateTime + "','" + "Added " + teacher.T_NCode + "','" + "TeacherTable'" + ")";
                sc.ExecuteNonQuery();

                transaction.Commit();
                popup = new PopUp("ثبت موفقیت آمیز", "افزودن اطلاعات با موفقیت انجام شد.", "تایید", "", "", "success");
                popup.ShowDialog();
            }
            catch
            {
                string context = "خطا در برقراری ارتباط با سرور.";
                Alert alert = new Alert(context, "darkred", 5);
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    //popup = new PopUp("خطا", "خطا در برقراری ارتباط با سرور", "تایید", "", "", "error");
                    //popup.ShowDialog();
                }
            }

            conn.Close();



        }
        public void EditTeacher(Teachers teacher, long lastT_NCode, long username, String dateTime)
        {

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            conn.Open();
            SqlCommand sc = new SqlCommand();
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;


            SqlTransaction transaction;
            transaction = conn.BeginTransaction("new");
            sc.Transaction = transaction;

            try
            {
                sc.CommandText = "UPDATE TeacherTable SET t_FName = " + "'" + teacher.T_FName + "',"
                                                    + "t_LName =" + "'" + teacher.T_LName + "',"
                                                    + "t_NCode =" + "'" + teacher.T_NCode + "',"
                                                    + "t_EDeg =" + "'" + teacher.T_EDeg + "',"
                                                    + "t_Email = " + "'" + teacher.T_Email + "',"
                                                    + " t_Group = " + "'" + teacher.T_Group + "',"
                                                    + "  t_Mobile=" + "'" + teacher.T_Mobile + "',"
                                                    + "t_Tel1=" + "'" + teacher.T_Tel1 + "',"
                                                    + "t_Tel2 =" + "'" + teacher.T_Tel2 + "',"
                                                    + " t_Faculty = " + "'" + teacher.T_Faculty + "' "
                                                    + " WHERE t_NCode = '" + lastT_NCode + "'";

                sc.ExecuteNonQuery();
                sc.CommandText = " INSERT INTO logTable (username , dateTime , description ,tableName) VALUES ('" + username + "','" + dateTime + "','" + "Edited " + teacher.T_NCode + "','" + "TeacherTable'" + ")";
                sc.ExecuteNonQuery();

                transaction.Commit();
                popup = new PopUp("تغییر موفقیت آمیز", "تغییر اطلاعات با موفقیت انجام شد.", "تایید", "", "", "success");
                popup.ShowDialog();
            }
            catch
            {
                string context = "خطا در برقراری ارتباط با سرور.";
                Alert alert = new Alert(context, "darkred", 5);
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    //popup = new PopUp("خطا", "خطا در برقراری ارتباط با سرور", "تایید", "", "", "error");
                    //popup.ShowDialog();
                }
            }

            conn.Close();

        }

        public void DeleteTeacher(Teachers teacher, long username, String dateTime)
        {


            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            conn.Open();
            SqlCommand sc = new SqlCommand();
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;


            SqlTransaction transaction;
            transaction = conn.BeginTransaction("new");
            sc.Transaction = transaction;




            try
            {
                sc.CommandText = " DELETE FROM TeacherTable WHERE t_NCode = '" + teacher.T_NCode + "'";
                sc.ExecuteNonQuery();
                sc.CommandText = " INSERT INTO deletedTeacherTable (t_FName , t_LName , t_NCode , t_EDeg ,t_Email , t_Group , t_Mobile ,t_Tel1,t_Tel2,t_Faculty , username , date)"
                                + "VALUES ('" + teacher.T_FName + "',"
                                         + "'" + teacher.T_LName + "',"
                                         + "'" + teacher.T_NCode + "',"
                                         + "'" + teacher.T_EDeg + "',"
                                         + "'" + teacher.T_Email + "',"
                                         + "'" + teacher.T_Group + "',"
                                         + "'" + teacher.T_Mobile + "',"
                                         + "'" + teacher.T_Tel1 + "',"
                                         + "'" + teacher.T_Tel2 + "',"
                                         + "'" + teacher.T_Faculty + "',"
                                          + "'" + username + "',"
                                         + "'" + dateTime + "')";
                sc.ExecuteNonQuery();
                sc.CommandText = " INSERT INTO logTable (username , dateTime , description ,tableName) VALUES ('" + username + "','" + dateTime + "','" + "deleted " + teacher.T_NCode + "','" + "TeachersTable'" + ")";
                sc.ExecuteNonQuery();

                transaction.Commit();
                popup = new PopUp("حذف موفقیت آمیز", "حذف اطلاعات با موفقیت انجام شد.", "تایید", "", "", "success");
                popup.ShowDialog();
            }
            catch
            {
                string context = "خطا در برقراری ارتباط با سرور.";
                Alert alert = new Alert(context, "darkred", 5);
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    //popup = new PopUp("خطا", "خطا در برقراری ارتباط با سرور", "تایید", "", "", "error");
                    //popup.ShowDialog();
                }
            }

            conn.Close();
        }



        public List<long> getTeachersNCode(string query)
        {
            List<long> list = new List<long>();
            try
            {


                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                SqlCommand sc = new SqlCommand();
                SqlDataReader reader;
                sc.CommandText = query;
                sc.CommandType = CommandType.Text;
                sc.Connection = conn;
                conn.Open();
                reader = sc.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader.GetInt64(0));
                }
                conn.Close();
            }
            catch { }
            return list;
        }

        private List<Teachers> getTeachers()
        {
            List<Teachers> list = new List<Teachers>();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = "SELECT * FROM TeacherTable";
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();
            while (reader.Read())
            {
                Teachers teacher = new Teachers();
                teacher.T_FName = ((String)reader["t_FName"]);
                teacher.T_LName = ((string)reader["t_LName"]);
                teacher.T_NCode = ((long)reader["y_NCode"]);
                teacher.T_EDeg = ((string)reader["t_EDeg"]);
                teacher.T_Email = ((String)reader["t_Email"]);
                teacher.T_Group = ((string)reader["t_Group"]);
                teacher.T_Mobile = ((String)reader["y_Mobile"]);
                teacher.T_Tel1 = ((string)reader["t_Tel1"]);
                teacher.T_Tel2 = ((String)reader["t_Tel2"]);
                teacher.T_Faculty = ((string)reader["t_Faculty"]);

                list.Add(teacher);
            }
            conn.Close();

            return list;


        }

        // End Of getAll
        /////////////////////////////////

        private List<Teachers> searchTeachers(String query)
        {
            List<Teachers> list = new List<Teachers>();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = query;
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();
            while (reader.Read())
            {
                Teachers teacher = new Teachers();
                teacher.T_FName = ((String)reader["t_FName"]);
                teacher.T_LName = ((string)reader["t_LName"]);
                teacher.T_NCode = ((long)reader["t_NCode"]);
                teacher.T_EDeg = ((string)reader["t_EDeg"]);
                teacher.T_Email = ((String)reader["t_Email"]);
                teacher.T_Group = ((string)reader["t_Group"]);
                teacher.T_Mobile = ((String)reader["t_Mobile"]);
                teacher.T_Tel1 = ((string)reader["t_Tel1"]);
                teacher.T_Tel2 = ((String)reader["t_Tel2"]);
                teacher.T_Faculty = ((string)reader["t_Faculty"]);

                list.Add(teacher);
            }
            conn.Close();

            return list;


        }
        //Search Teachers



        //////////////////end query Teachers



        /// <summary>
        /// querry for employers
        /// </summary>
        /// <param name="Emloyers"></param>
        public void AddEmployer(string employer, long username, String dateTime)
        {
            try
            {

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                conn.Open();
                SqlCommand sc = new SqlCommand();
                sc.CommandType = CommandType.Text;
                sc.Connection = conn;

                SqlTransaction transaction;
                transaction = conn.BeginTransaction("new");
                sc.Transaction = transaction;


                try
                {
                    sc.CommandText = "INSERT INTO employersTable (orgName) VALUES ('" + employer + "')";
                    sc.ExecuteNonQuery();
                    sc.CommandText = " INSERT INTO logTable (username , dateTime , description ,tableName) VALUES ('" + username + "','" + dateTime + "','" + "Added " + employer + "','" + "employersTable'" + ")";
                    sc.ExecuteNonQuery();

                    transaction.Commit();
                    popup = new PopUp("ثبت موفقیت آمیز", "افزودن اطلاعات با موفقیت انجام شد.", "تایید", "", "", "success");
                    popup.ShowDialog();
                }
                catch (Exception e)
                {

                    try
                    {
                        transaction.Rollback();
                    }
                    catch
                    {

                    }
                    if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                    {
                        string context = "خطا در برقراری ارتباط.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else if (e.Message.Contains("PRIMARY KEY"))
                    {
                        string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else
                    {
                        popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "error");
                        popup.ShowDialog();
                    }

                }

                conn.Close();
            }

            catch (Exception e)
            {

                if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                {
                    string context = "خطا در برقراری ارتباط.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else if (e.Message.Contains("PRIMARY KEY"))
                {
                    string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else
                {
                    popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "warning");
                    popup.ShowDialog();
                }
            }

        }

        public void EditEmployer(Employers employer, string lastOrgName, long username, String dateTime)
        {
            try
            {

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                conn.Open();
                SqlCommand sc = new SqlCommand();
                sc.CommandType = CommandType.Text;
                sc.Connection = conn;


                SqlTransaction transaction;
                transaction = conn.BeginTransaction("new");
                sc.Transaction = transaction;

                try
                {
                    sc.CommandText = "UPDATE employersTable SET orgName = '" + employer.OrgName + "' WHERE [index] = '" + employer.Index + "'";
                    sc.ExecuteNonQuery();
                    sc.CommandText = " INSERT INTO logTable (username , dateTime , description ,tableName) VALUES ('" + username + "','" + dateTime + "','" + "Edited from " + lastOrgName + " to " + employer.OrgName + "','" + "employersTable'" + ")";
                    sc.ExecuteNonQuery();

                    transaction.Commit();
                    popup = new PopUp("تغییر موفقیت آمیز", "تغییر اطلاعات با موفقیت انجام شد.", "تایید", "", "", "success");
                    popup.ShowDialog();
                }
                catch (Exception e)
                {

                    try
                    {
                        transaction.Rollback();
                    }
                    catch
                    {

                    }
                    if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                    {
                        string context = "خطا در برقراری ارتباط.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else if (e.Message.Contains("PRIMARY KEY"))
                    {
                        string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else
                    {
                        popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "error");
                        popup.ShowDialog();
                    }

                }

                conn.Close();
            }

            catch (Exception e)
            {

                if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                {
                    string context = "خطا در برقراری ارتباط.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else if (e.Message.Contains("PRIMARY KEY"))
                {
                    string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else
                {
                    popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "warning");
                    popup.ShowDialog();
                }
            }

        }

        public List<Employers> getEmployers()
        {

            List<Employers> list = new List<Employers>();
            try
            {


                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                SqlCommand sc = new SqlCommand();
                SqlDataReader reader;
                sc.CommandText = "SELECT * FROM employersTable";
                sc.CommandType = CommandType.Text;
                sc.Connection = conn;
                conn.Open();
                reader = sc.ExecuteReader();
                while (reader.Read())
                {
                    Employers employers = new Employers();
                    employers.Index = ((long)reader["index"]);
                    employers.OrgName = ((string)reader["orgName"]);
                    list.Add(employers);
                }
                conn.Close();
            }
            catch
            {

            }
            return list;
        }
        public void DeleteEmployers(long index, String employers, long username, String dateTime)
        {
            try
            {

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                conn.Open();
                SqlCommand sc = new SqlCommand();
                sc.CommandType = CommandType.Text;
                sc.Connection = conn;


                SqlTransaction transaction;
                transaction = conn.BeginTransaction("new");
                sc.Transaction = transaction;

                try
                {
                    sc.CommandText = " DELETE FROM employersTable WHERE [index] = '" + index + "'";
                    sc.ExecuteNonQuery();
                    sc.CommandText = " INSERT INTO deletedEmployersTable ([index] , orgName , date , username) VALUES('" + index + "','" + employers + "' ,'" + dateTime + "' ,'" + username + "')";
                    sc.ExecuteNonQuery();
                    sc.CommandText = " INSERT INTO logTable (username , dateTime , description ,tableName) VALUES ('" + username + "','" + dateTime + "','" + "deleted " + index + "-" + employers + "','" + "employersTable'" + ")";
                    sc.ExecuteNonQuery();

                    transaction.Commit();
                    popup = new PopUp("تغییر موفقیت آمیز", "تغییر اطلاعات با موفقیت انجام شد.", "تایید", "", "", "success");
                    popup.ShowDialog();
                }
                catch (Exception e)
                {

                    try
                    {
                        transaction.Rollback();
                    }
                    catch
                    {

                    }
                    if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                    {
                        string context = "خطا در برقراری ارتباط.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else if (e.Message.Contains("PRIMARY KEY"))
                    {
                        string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else
                    {
                        popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "error");
                        popup.ShowDialog();
                    }

                }

                conn.Close();
            }

            catch (Exception e)
            {

                if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                {
                    string context = "خطا در برقراری ارتباط.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else if (e.Message.Contains("PRIMARY KEY"))
                {
                    string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else
                {
                    popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "warning");
                    popup.ShowDialog();
                }
            }

        }

        ////////////////////end of employer query
        /// <summary>
        /// procedure query
        /// </summary>
        /// <param name="procedure"></param>
        public void AddProcedureType(String procedure, long username, String dateTime)
        {
            try
            {

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                conn.Open();
                SqlCommand sc = new SqlCommand();
                sc.CommandType = CommandType.Text;
                sc.Connection = conn;


                SqlTransaction transaction;
                transaction = conn.BeginTransaction("new");
                sc.Transaction = transaction;


                try
                {
                    sc.CommandText = "INSERT INTO procedureTypeTable (procedureType) VALUES ('" + procedure + "' )";
                    sc.ExecuteNonQuery();
                    sc.CommandText = " INSERT INTO logTable (username , dateTime , description ,tableName) VALUES ('" + username + "','" + dateTime + "','" + "Added " + procedure + "','" + "procedureTypeTable'" + ")";
                    sc.ExecuteNonQuery();

                    transaction.Commit();
                    popup = new PopUp("ثبت موفقیت آمیز", "افزودن اطلاعات با موفقیت انجام شد.", "تایید", "", "", "success");
                    popup.ShowDialog();
                }
                catch (Exception e)
                {

                    try
                    {
                        transaction.Rollback();
                    }
                    catch
                    {

                    }
                    if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                    {
                        string context = "خطا در برقراری ارتباط.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else if (e.Message.Contains("PRIMARY KEY"))
                    {
                        string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else
                    {
                        MessageBox.Show(e.Message);
                        popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "error");
                        popup.ShowDialog();
                    }

                }

                conn.Close();
            }

            catch (Exception e)
            {

                if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                {
                    string context = "خطا در برقراری ارتباط.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else if (e.Message.Contains("PRIMARY KEY"))
                {
                    string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else
                {
                    popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "warning");
                    popup.ShowDialog();
                }
            }

        }

        public void EditProcedureType(String newProcedureType, String lastProcedureType, long username, String dateTime)
        {
            try
            {

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                conn.Open();
                SqlCommand sc = new SqlCommand();
                sc.CommandType = CommandType.Text;
                sc.Connection = conn;


                SqlTransaction transaction;
                transaction = conn.BeginTransaction("new");
                sc.Transaction = transaction;

                try
                {
                    sc.CommandText = "UPDATE procedureTypeTable SET procedureType = " + "'" + newProcedureType + "' WHERE procedureType = '" + lastProcedureType + "'";
                    sc.ExecuteNonQuery();
                    sc.CommandText = " INSERT INTO logTable (username , dateTime , description ,tableName) VALUES ('" + username + "','" + dateTime + "','" + "Edited from " + lastProcedureType + " to " + newProcedureType + "','" + "procedureTypeTable'" + ")";
                    sc.ExecuteNonQuery();

                    transaction.Commit();
                    popup = new PopUp("تغییر موفقیت آمیز", "تغییر اطلاعات با موفقیت انجام شد.", "تایید", "", "", "success");
                    popup.ShowDialog();
                }
                catch (Exception e)
                {

                    try
                    {
                        transaction.Rollback();
                    }
                    catch
                    {

                    }
                    if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                    {
                        string context = "خطا در برقراری ارتباط.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else if (e.Message.Contains("PRIMARY KEY"))
                    {
                        string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else
                    {
                        popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "error");
                        popup.ShowDialog();
                    }

                }

                conn.Close();
            }

            catch (Exception e)
            {

                if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                {
                    string context = "خطا در برقراری ارتباط.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else if (e.Message.Contains("PRIMARY KEY"))
                {
                    string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else
                {
                    popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "warning");
                    popup.ShowDialog();
                }
            }

        }


        public List<string> getProcedureType()
        {

            List<string> list = new List<string>();
            try
            {


                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                SqlCommand sc = new SqlCommand();
                SqlDataReader reader;
                sc.CommandText = "SELECT * FROM procedureTypeTable";
                sc.CommandType = CommandType.Text;
                sc.Connection = conn;
                conn.Open();
                reader = sc.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader.GetString(0));
                }
                conn.Close();
            }
            catch
            {

            }
            return list;
        }

        public void DeleteProcedureType(String procedure, long username, String dateTime)
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                conn.Open();
                SqlCommand sc = new SqlCommand();
                sc.CommandType = CommandType.Text;
                sc.Connection = conn;

                SqlTransaction transaction;
                transaction = conn.BeginTransaction("new");
                sc.Transaction = transaction;

                try
                {
                    sc.CommandText = " DELETE FROM procedureTypeTable WHERE procedureType = '" + procedure + "'";
                    sc.ExecuteNonQuery();
                    sc.CommandText = " INSERT INTO deletedProcedureTypeTable (procedureType , date , username) VALUES( '" + procedure + "' ,'" + dateTime + "' ,'" + username + "')";
                    sc.ExecuteNonQuery();
                    sc.CommandText = " INSERT INTO logTable (username , dateTime , description ,tableName) VALUES ('" + username + "','" + dateTime + "','" + "deleted " + procedure + "','" + "procedureTypeTable'" + ")";
                    sc.ExecuteNonQuery();

                    transaction.Commit();
                    // MessageBox.Show("حذف با موفقیت به پایان رسید");
                    popup = new PopUp("حذف موفقیت آمیز", "حذف با موفقیت به پایان رسید.", "تایید", "", "", "success");
                    popup.ShowDialog();
                }
                catch (Exception e)
                {

                    try
                    {
                        transaction.Rollback();
                    }
                    catch
                    {

                    }
                    if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                    {
                        string context = "خطا در برقراری ارتباط.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else if (e.Message.Contains("PRIMARY KEY"))
                    {
                        string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else
                    {
                        popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "error");
                        popup.ShowDialog();
                    }

                }

                conn.Close();
            }

            catch (Exception e)
            {

                if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                {
                    string context = "خطا در برقراری ارتباط.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else if (e.Message.Contains("PRIMARY KEY"))
                {
                    string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else
                {
                    popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "warning");
                    popup.ShowDialog();
                }
            }

        }

        /////////////////end of procedure query


        /// <summary>
        /// property query
        /// </summary>
        /// <param name=property></param>
        public void AddPropertyType(String property, long username, String dateTime)
        {

            try
            {

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                conn.Open();
                SqlCommand sc = new SqlCommand();
                sc.CommandType = CommandType.Text;
                sc.Connection = conn;

                SqlTransaction transaction;
                transaction = conn.BeginTransaction("new");
                sc.Transaction = transaction;
                try
                {

                    sc.CommandText = "INSERT INTO propertyTypeTable (propertyType) VALUES ('" + property + "')";
                    sc.ExecuteNonQuery();
                    sc.CommandText = " INSERT INTO logTable (username , dateTime , description ,tableName) VALUES ('" + username + "','" + dateTime + "','" + "Added " + property + "','" + "propertyTypeTable'" + ")";
                    sc.ExecuteNonQuery();

                    transaction.Commit();

                    popup = new PopUp("افزودن موفقیت آمیز", "افزودن با موفقیت به پایان رسید.", "تایید", "", "", "success");
                    popup.ShowDialog();
                }   
                catch (Exception e)
                {

                    try
                    {
                        transaction.Rollback();
                    }
                    catch
                    {

                    }
                    if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                    {
                        string context = "خطا در برقراری ارتباط.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else if (e.Message.Contains("PRIMARY KEY"))
                    {
                        string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else
                    {
                        popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "error");
                        popup.ShowDialog();
                    }

                }

                conn.Close();
            }

            catch (Exception e)
            {

                if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                {
                    string context = "خطا در برقراری ارتباط.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else if (e.Message.Contains("PRIMARY KEY"))
                {
                    string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else
                {
                    popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "warning");
                    popup.ShowDialog();
                }
            }

        }

        public void EditPropertyType(String newPropertyType, String lastPropertyType, long username, String dateTime)
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                conn.Open();
                SqlCommand sc = new SqlCommand();
                sc.CommandType = CommandType.Text;
                sc.Connection = conn;


                SqlTransaction transaction;
                transaction = conn.BeginTransaction("new");
                sc.Transaction = transaction;

                try
                {
                    sc.CommandText = "UPDATE propertyTypeTable SET propertyType = " + "'" + newPropertyType + "' WHERE propertyType = '" + lastPropertyType + "'";
                    sc.ExecuteNonQuery();
                    sc.CommandText = " INSERT INTO logTable (username , dateTime , description ,tableName) VALUES ('" + username + "','" + dateTime + "','" + "Edited from " + lastPropertyType + " to " + newPropertyType + "','" + "propertyTypeTable'" + ")";
                    sc.ExecuteNonQuery();

                    transaction.Commit();
                    popup = new PopUp("تغییرات موفقیت آمیز", "تغییرات  با موفقیت  ثبت شد.", "تایید", "", "", "success");
                    popup.ShowDialog();
                }
                catch (Exception e)
                {

                    try
                    {
                        transaction.Rollback();
                    }
                    catch
                    {

                    }
                    if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                    {
                        string context = "خطا در برقراری ارتباط.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else if (e.Message.Contains("PRIMARY KEY"))
                    {
                        string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else
                    {
                        popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "error");
                        popup.ShowDialog();
                    }

                }

                conn.Close();
            }

            catch (Exception e)
            {

                if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                {
                    string context = "خطا در برقراری ارتباط.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else if (e.Message.Contains("PRIMARY KEY"))
                {
                    string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else
                {
                    popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "warning");
                    popup.ShowDialog();
                }
            }

        }

        
        public List<string> getPropertyType()
        {

            List<string> list = new List<string>();
            try
            {


                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                SqlCommand sc = new SqlCommand();
                SqlDataReader reader;
                sc.CommandText = "SELECT * FROM propertyTypeTable";
                sc.CommandType = CommandType.Text;
                sc.Connection = conn;
                conn.Open();
                reader = sc.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader.GetString(0));

                }
                conn.Close();
            }
            catch
            {

            }
            return list;
        }

        public void DeletePropertyType(String property, long username, String dateTime)
        {
            try
            {

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                conn.Open();
                SqlCommand sc = new SqlCommand();
                sc.CommandType = CommandType.Text;
                sc.Connection = conn;


                SqlTransaction transaction;
                transaction = conn.BeginTransaction("new");
                sc.Transaction = transaction;




                try
                {
                    sc.CommandText = " DELETE FROM propertyTypeTable WHERE propertyType = '" + property + "'";
                    sc.ExecuteNonQuery();
                    sc.CommandText = " INSERT INTO deletedPropertyTypeTable  (propertyType , date , username) VALUES( '" + property + "' ,'" + dateTime + "' ,'" + username + "')";
                    sc.ExecuteNonQuery();
                    sc.CommandText = " INSERT INTO logTable (username , dateTime , description ,tableName) VALUES ('" + username + "','" + dateTime + "','" + "deleted " + property + "','" + "propertyTypeTable'" + ")";
                    sc.ExecuteNonQuery();

                    transaction.Commit();
                    popup = new PopUp("حذف موفقیت آمیز", "حذف با موفقیت به پایان رسید.", "تایید", "", "", "success");
                    popup.ShowDialog();
                }
                catch (Exception e)
                {

                    try
                    {
                        transaction.Rollback();
                    }
                    catch
                    {

                    }
                    if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                    {
                        string context = "خطا در برقراری ارتباط.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else if (e.Message.Contains("PRIMARY KEY"))
                    {
                        string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else
                    {
                        popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "error");
                        popup.ShowDialog();
                    }

                }

                conn.Close();
            }

            catch (Exception e)
            {

                if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                {
                    string context = "خطا در برقراری ارتباط.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else if (e.Message.Contains("PRIMARY KEY"))
                {
                    string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else
                {
                    popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "warning");
                    popup.ShowDialog();
                }
            }

        }


        ///////////end query property

        /// <summary>
        /// proposalType query
        /// </summary>
        /// <param name=proposalType></param>
        public void AddProposalType(String proposalType, long username, String dateTime)
        {
            try
            {



                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                conn.Open();
                SqlCommand sc = new SqlCommand();
                sc.CommandType = CommandType.Text;
                sc.Connection = conn;


                SqlTransaction transaction;
                transaction = conn.BeginTransaction("new");
                sc.Transaction = transaction;


                try
                {
                    sc.CommandText = "INSERT INTO proposalTypeTable (proposalType) VALUES ('" + proposalType + "')";
                    sc.ExecuteNonQuery();
                    sc.CommandText = " INSERT INTO logTable (username , dateTime , description ,tableName) VALUES ('" + username + "','" + dateTime + "','" + "Added " + proposalType + "','" + "proposalTypeTable'" + ")";
                    sc.ExecuteNonQuery();

                    transaction.Commit();
                    popup = new PopUp("افزودن موفقیت آمیز", "افزودن با موفقیت به پایان رسید.", "تایید", "", "", "success");
                    popup.ShowDialog();
                }
                catch (Exception e)
                {

                    try
                    {
                        transaction.Rollback();
                    }
                    catch
                    {

                    }
                    if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                    {
                        string context = "خطا در برقراری ارتباط.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else if (e.Message.Contains("PRIMARY KEY"))
                    {
                        string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else
                    {
                        popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "error");
                        popup.ShowDialog();
                    }

                }

                conn.Close();
            }

            catch (Exception e)
            {

                if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                {
                    string context = "خطا در برقراری ارتباط.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else if (e.Message.Contains("PRIMARY KEY"))
                {
                    string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else
                {
                    popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "warning");
                    popup.ShowDialog();
                }
            }

        }

        public void EditProposalType(String newProposalType, String lastProposalType, long username, String dateTime)
        {
            try
            {

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                conn.Open();
                SqlCommand sc = new SqlCommand();
                sc.CommandType = CommandType.Text;
                sc.Connection = conn;


                SqlTransaction transaction;
                transaction = conn.BeginTransaction("new");
                sc.Transaction = transaction;

                try
                {
                    sc.CommandText = "UPDATE proposalTypeTable SET proposalType = " + "'" + newProposalType + "' WHERE proposalType = '" + lastProposalType + "'";
                    sc.ExecuteNonQuery();
                    sc.CommandText = " INSERT INTO logTable (username , dateTime , description ,tableName) VALUES ('" + username + "','" + dateTime + "','" + "Edited from " + lastProposalType + " to " + newProposalType + "','" + "proposalTypeTable'" + ")";
                    sc.ExecuteNonQuery();

                    transaction.Commit();
                    popup = new PopUp("تغییرات موفقیت آمیز", "تغییرات با موفقیت ثبت شد.", "تایید", "", "", "success");
                    popup.ShowDialog();

                }
                catch (Exception e)
                {

                    try
                    {
                        transaction.Rollback();
                    }
                    catch
                    {

                    }
                    if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                    {
                        string context = "خطا در برقراری ارتباط.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else if (e.Message.Contains("PRIMARY KEY"))
                    {
                        string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else
                    {
                        popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "error");
                        popup.ShowDialog();
                    }

                }

                conn.Close();
            }

            catch (Exception e)
            {

                if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                {
                    string context = "خطا در برقراری ارتباط.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else if (e.Message.Contains("PRIMARY KEY"))
                {
                    string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else
                {
                    popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "warning");
                    popup.ShowDialog();
                }
            }

        }

        public List<string> getProposalType()
        {
            
            List<string> list = new List<string>();
            try
            {


                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                SqlCommand sc = new SqlCommand();
                SqlDataReader reader;
                sc.CommandText = "SELECT * FROM proposalTypeTable ";
                sc.CommandType = CommandType.Text;
                sc.Connection = conn;
                conn.Open();
                reader = sc.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader.GetString(0));

                }
                conn.Close();
            }
            catch
            {

            }

            return list;
        }
        public void DeleteProposalType(String proposal, long username, String dateTime)
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                conn.Open();
                SqlCommand sc = new SqlCommand();
                sc.CommandType = CommandType.Text;
                sc.Connection = conn;


                SqlTransaction transaction;
                transaction = conn.BeginTransaction("new");
                sc.Transaction = transaction;




                try
                {
                    sc.CommandText = " DELETE FROM proposalTypeTable WHERE proposalType = '" + proposal + "'";
                    sc.ExecuteNonQuery();
                    sc.CommandText = " INSERT INTO deletedProposalTypeTable  (proposalType , date , username) VALUES( '" + proposal + "' ,'" + dateTime + "' ,'" + username + "')";
                    sc.ExecuteNonQuery();
                    sc.CommandText = " INSERT INTO logTable (username , dateTime , description ,tableName) VALUES ('" + username + "','" + dateTime + "','" + "deleted " + proposal + "','" + "proposalTypeTable'" + ")";
                    sc.ExecuteNonQuery();

                    transaction.Commit();

                    popup = new PopUp("حذف موفقیت آمیز", "حذف با موفقیت به پایان رسید.", "تایید", "", "", "success");
                    popup.ShowDialog();

                }
                catch (Exception e)
                {

                    try
                    {
                        transaction.Rollback();
                    }
                    catch
                    {

                    }
                    if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                    {
                        string context = "خطا در برقراری ارتباط.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else if (e.Message.Contains("PRIMARY KEY"))
                    {
                        string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else
                    {
                        popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "error");
                        popup.ShowDialog();
                    }

                }

                conn.Close();
            }

            catch (Exception e)
            {

                if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                {
                    string context = "خطا در برقراری ارتباط.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else if (e.Message.Contains("PRIMARY KEY"))
                {
                    string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else
                {
                    popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "warning");
                    popup.ShowDialog();
                }
            }

        }

        /////////////////end proposal type query

        /// <summary>
        /// registerType query
        /// </summary>
        /// <param name=proposalType></param>
        public void AddRegisterType(String registerType, long username, String dateTime)
        {
            try
            {

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                conn.Open();
                SqlCommand sc = new SqlCommand();
                sc.CommandType = CommandType.Text;
                sc.Connection = conn;


                SqlTransaction transaction;
                transaction = conn.BeginTransaction("new");
                sc.Transaction = transaction;


                try
                {
                    sc.CommandText = "INSERT INTO registerTypeTable (registerType) VALUES ('" + registerType + "' )";
                    sc.ExecuteNonQuery();
                    sc.CommandText = " INSERT INTO logTable (username , dateTime , description ,tableName) VALUES ('" + username + "','" + dateTime + "','" + "Added " + registerType + "','" + "registerTypeTable'" + ")";
                    sc.ExecuteNonQuery();

                    transaction.Commit();

                    popup = new PopUp("افزودن موفقیت آمیز", "افزودن با موفقیت به پایان رسید.", "تایید", "", "", "success");
                    popup.ShowDialog();
                }
                catch (Exception e)
                {

                    try
                    {
                        transaction.Rollback();
                    }
                    catch
                    {

                    }
                    if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                    {
                        string context = "خطا در برقراری ارتباط.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else if (e.Message.Contains("PRIMARY KEY"))
                    {
                        string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else
                    {
                        popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "error");
                        popup.ShowDialog();
                    }

                }

                conn.Close();
            }

            catch (Exception e)
            {

                if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                {
                    string context = "خطا در برقراری ارتباط.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else if (e.Message.Contains("PRIMARY KEY"))
                {
                    string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else
                {
                    popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "warning");
                    popup.ShowDialog();
                }
            }

        }

        public void EditRegisterType(String newRegisterType, String lastRegisterType, long username, String dateTime)
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                conn.Open();
                SqlCommand sc = new SqlCommand();
                sc.CommandType = CommandType.Text;
                sc.Connection = conn;


                SqlTransaction transaction;
                transaction = conn.BeginTransaction("new");
                sc.Transaction = transaction;

                try
                {
                    sc.CommandText = "UPDATE registerTypeTable SET registerType = " + "'" + newRegisterType + "' WHERE registerType = '" + lastRegisterType + "'";
                    sc.ExecuteNonQuery();
                    sc.CommandText = " INSERT INTO logTable (username , dateTime , description ,tableName) VALUES ('" + username + "','" + dateTime + "','" + "Edited from " + lastRegisterType + " to " + newRegisterType + "','" + "registerTypeTable'" + ")";
                    sc.ExecuteNonQuery();

                    transaction.Commit();
                    popup = new PopUp("تغییرات موفقیت آمیز", "تغییرات با موفقیت ثبت شد.", "تایید", "", "", "success");
                    popup.ShowDialog();

                }
                catch (Exception e)
                {

                    try
                    {
                        transaction.Rollback();
                    }
                    catch
                    {

                    }
                    if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                    {
                        string context = "خطا در برقراری ارتباط.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else if (e.Message.Contains("PRIMARY KEY"))
                    {
                        string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else
                    {
                        popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "error");
                        popup.ShowDialog();
                    }

                }

                conn.Close();
            }

            catch (Exception e)
            {

                if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                {
                    string context = "خطا در برقراری ارتباط.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else if (e.Message.Contains("PRIMARY KEY"))
                {
                    string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else
                {
                    popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "warning");
                    popup.ShowDialog();
                }
            }

        }

        public List<string> getRegisterType()
        {
            
            List<string> list = new List<string>();
            try
            {


                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                SqlCommand sc = new SqlCommand();
                SqlDataReader reader;
                sc.CommandText = "SELECT * FROM registerTypeTable";
                sc.CommandType = CommandType.Text;
                sc.Connection = conn;
                conn.Open();
                reader = sc.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader.GetString(0));

                }
                conn.Close();
            }
            catch
            {

            }
            return list;
        }

        public void DeleteRegisterType(String register, long username, String dateTime)
        {

            try
            {



                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                conn.Open();
                SqlCommand sc = new SqlCommand();
                sc.CommandType = CommandType.Text;
                sc.Connection = conn;


                SqlTransaction transaction;
                transaction = conn.BeginTransaction("new");
                sc.Transaction = transaction;




                try
                {
                    sc.CommandText = " DELETE FROM registerTypeTable WHERE registerType = '" + register + "'";
                    sc.ExecuteNonQuery();
                    sc.CommandText = " INSERT INTO deletedRegisterTypeTable  (registerType , date , username) VALUES( '" + register + "' ,'" + dateTime + "' ,'" + username + "')";
                    sc.ExecuteNonQuery();
                    sc.CommandText = " INSERT INTO logTable (username , dateTime , description ,tableName) VALUES ('" + username + "','" + dateTime + "','" + "deleted " + register + "','" + "registerTypeTable'" + ")";
                    sc.ExecuteNonQuery();

                    transaction.Commit();

                    popup = new PopUp("حذف موفقیت آمیز", "حذف با موفقیت به پایان رسید.", "تایید", "", "", "success");
                    popup.ShowDialog();

                }
                catch (Exception e)
                {

                    try
                    {
                        transaction.Rollback();
                    }
                    catch
                    {

                    }
                    if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                    {
                        string context = "خطا در برقراری ارتباط.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else if (e.Message.Contains("PRIMARY KEY"))
                    {
                        string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else
                    {
                        popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "error");
                        popup.ShowDialog();
                    }

                }

                conn.Close();
            }

            catch (Exception e)
            {

                if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                {
                    string context = "خطا در برقراری ارتباط.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else if (e.Message.Contains("PRIMARY KEY"))
                {
                    string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else
                {
                    popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "warning");
                    popup.ShowDialog();
                }
            }

        }

        //////////////end of registerType query


        /// <summary>
        /// statusType query
        /// </summary>
        /// <param name=statusType></param>
        public void AddStatusType(String statusType, long username, String dateTime)
        {
            try
            {



                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                conn.Open();
                SqlCommand sc = new SqlCommand();
                sc.CommandType = CommandType.Text;
                sc.Connection = conn;


                SqlTransaction transaction;
                transaction = conn.BeginTransaction("new");
                sc.Transaction = transaction;


                try
                {
                    sc.CommandText = "INSERT INTO statusTypeTable (statusType) VALUES('" + statusType + "')";
                    sc.ExecuteNonQuery();
                    sc.CommandText = " INSERT INTO logTable (username , dateTime , description ,tableName) VALUES ('" + username + "','" + dateTime + "','" + "Added " + statusType + "','" + "statusTypeTable'" + ")";
                    sc.ExecuteNonQuery();

                    transaction.Commit();

                    popup = new PopUp("افزودن موفقیت آمیز", "افزودن با موفقیت به پایان رسید.", "تایید", "", "", "success");
                    popup.ShowDialog();
                }
                catch (Exception e)
                {

                    try
                    {
                        transaction.Rollback();
                    }
                    catch
                    {

                    }
                    if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                    {
                        string context = "خطا در برقراری ارتباط.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else if (e.Message.Contains("PRIMARY KEY"))
                    {
                        string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else
                    {
                        popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "error");
                        popup.ShowDialog();
                    }

                }

                conn.Close();
            }

            catch (Exception e)
            {

                if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                {
                    string context = "خطا در برقراری ارتباط.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else if (e.Message.Contains("PRIMARY KEY"))
                {
                    string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else
                {
                    popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "warning");
                    popup.ShowDialog();
                }
            }

        }

        public void EditStatusType(String newStatusType, String lastStatusType, long username, String dateTime)
        {
            try
            {

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                conn.Open();
                SqlCommand sc = new SqlCommand();
                sc.CommandType = CommandType.Text;
                sc.Connection = conn;

                SqlTransaction transaction;
                transaction = conn.BeginTransaction("new");
                sc.Transaction = transaction;

                try
                {
                    sc.CommandText = "UPDATE statusTypeTable SET statusType = " + "'" + newStatusType + "' WHERE statusType = '" + lastStatusType + "'";
                    sc.ExecuteNonQuery();
                    sc.CommandText = " INSERT INTO logTable (username , dateTime , description ,tableName) VALUES ('" + username + "','" + dateTime + "','" + "Edited from " + lastStatusType + " to " + newStatusType + "','" + "statusTypeTable'" + ")";
                    sc.ExecuteNonQuery();

                    transaction.Commit();
                    popup = new PopUp("تغییرات موفقیت آمیز", "تغییرات با موفقیت ثبت شد.", "تایید", "", "", "success");
                    popup.ShowDialog();

                }
                catch (Exception e)
                {

                    try
                    {
                        transaction.Rollback();
                    }
                    catch
                    {

                    }
                    if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                    {
                        string context = "خطا در برقراری ارتباط.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else if (e.Message.Contains("PRIMARY KEY"))
                    {
                        string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else
                    {
                        popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "error");
                        popup.ShowDialog();
                    }

                }

                conn.Close();
            }

            catch (Exception e)
            {

                if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                {
                    string context = "خطا در برقراری ارتباط.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else if (e.Message.Contains("PRIMARY KEY"))
                {
                    string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else
                {
                    popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "warning");
                    popup.ShowDialog();
                }
            }

        }

        public List<string> getStatusType()
        {
            List<string> list = new List<string>();
            try
            {


                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                SqlCommand sc = new SqlCommand();
                SqlDataReader reader;
                sc.CommandText = "SELECT * FROM statusTypeTable ";
                sc.CommandType = CommandType.Text;
                sc.Connection = conn;
                conn.Open();
                reader = sc.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader.GetString(0));

                }
                conn.Close();
            }
            catch
            {

            }
            return list;
        }

        public void DeleteStatusType(String status, long username, String dateTime)
        {
            try
            {

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                conn.Open();
                SqlCommand sc = new SqlCommand();
                sc.CommandType = CommandType.Text;
                sc.Connection = conn;

                SqlTransaction transaction;
                transaction = conn.BeginTransaction("new");
                sc.Transaction = transaction;

                try
                {
                    sc.CommandText = " DELETE FROM statusTypeTable WHERE statusType = '" + status + "'";
                    sc.ExecuteNonQuery();
                    sc.CommandText = " INSERT INTO deletedStatusTypeTable  (statusType , date , username) VALUES( '" + status + "' ,'" + dateTime + "' ,'" + username + "')";
                    sc.ExecuteNonQuery();
                    sc.CommandText = " INSERT INTO logTable (username , dateTime , description ,tableName) VALUES ('" + username + "','" + dateTime + "','" + "deleted " + status + "','" + "statusTypeTable'" + ")";
                    sc.ExecuteNonQuery();

                    transaction.Commit();

                    popup = new PopUp("حذف موفقیت آمیز", "حذف با موفقیت به پایان رسید.", "تایید", "", "", "success");
                    popup.ShowDialog();

                }
                catch (Exception e)
                {

                    try
                    {
                        transaction.Rollback();
                    }
                    catch
                    {

                    }
                    if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                    {
                        string context = "خطا در برقراری ارتباط.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else if (e.Message.Contains("PRIMARY KEY"))
                    {
                        string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else
                    {
                        popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "error");
                        popup.ShowDialog();
                    }

                }

                conn.Close();
            }

            catch (Exception e)
            {

                if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                {
                    string context = "خطا در برقراری ارتباط.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else if (e.Message.Contains("PRIMARY KEY"))
                {
                    string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else
                {
                    popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "warning");
                    popup.ShowDialog();
                }
            }

        }

        ///////////end query of statusType

        /// <summary>
        /// statusType query
        /// </summary>
        /// <param name=Faculty></param>
        public void AddFaculty(String faculty, long username, String dateTime)
        {
            try
            {


                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                conn.Open();
                SqlCommand sc = new SqlCommand();
                sc.CommandType = CommandType.Text;
                sc.Connection = conn;


                SqlTransaction transaction;
                transaction = conn.BeginTransaction("new");
                sc.Transaction = transaction;


                try
                {
                    sc.CommandText = "INSERT INTO facultyTable (facultyName) VALUES( '" + faculty + "' )";
                    sc.ExecuteNonQuery();
                    sc.CommandText = " INSERT INTO logTable (username , dateTime , description ,tableName) VALUES ('" + username + "','" + dateTime + "','" + "Added " + faculty + "','" + "facultyTable'" + ")";
                    sc.ExecuteNonQuery();

                    transaction.Commit();

                    popup = new PopUp("افزودن موفقیت آمیز", "افزودن با موفقیت به پایان رسید.", "تایید", "", "", "success");
                    popup.ShowDialog();
                }
                catch (Exception e)
                {

                    try
                    {
                        transaction.Rollback();
                    }
                    catch
                    {

                    }
                    if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                    {
                        string context = "خطا در برقراری ارتباط.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else if (e.Message.Contains("PRIMARY KEY"))
                    {
                        string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else
                    {
                        popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "error");
                        popup.ShowDialog();
                    }

                }

                conn.Close();
            }

            catch (Exception e)
            {

                if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                {
                    string context = "خطا در برقراری ارتباط.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else if (e.Message.Contains("PRIMARY KEY"))
                {
                    string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else
                {
                    popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "warning");
                    popup.ShowDialog();
                }
            }

        }

        public void EditFaculty(String newFaculty, String lastFaculty, long username, String dateTime)
        {
            try
            {

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                conn.Open();
                SqlCommand sc = new SqlCommand();
                sc.CommandType = CommandType.Text;
                sc.Connection = conn;

                SqlTransaction transaction;
                transaction = conn.BeginTransaction("new");
                sc.Transaction = transaction;

                try
                {
                    sc.CommandText = "UPDATE facultyTable SET facultyName = " + "'" + newFaculty + "' WHERE facultyName = '" + lastFaculty + "'";
                    sc.ExecuteNonQuery();
                    sc.CommandText = " INSERT INTO logTable (username , dateTime , description ,tableName) VALUES ('" + username + "','" + dateTime + "','" + "Edited from " + lastFaculty + " to " + newFaculty + "','" + "facultyTable'" + ")";
                    sc.ExecuteNonQuery();

                    transaction.Commit();
                    popup = new PopUp("تغییرات موفقیت آمیز", "تغییرات با موفقیت ثبت شد.", "تایید", "", "", "success");
                    popup.ShowDialog();

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);

                    try
                    {
                        transaction.Rollback();
                    }
                    catch
                    {

                    }
                    if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                    {
                        string context = "خطا در برقراری ارتباط.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else if (e.Message.Contains("PRIMARY KEY"))
                    {
                        string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else
                    {
                        popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "error");
                        popup.ShowDialog();
                    }

                }

                conn.Close();
            }

            catch (Exception e)
            {

                if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                {
                    string context = "خطا در برقراری ارتباط.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else if (e.Message.Contains("PRIMARY KEY"))
                {
                    string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else
                {
                    popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "warning");
                    popup.ShowDialog();
                }
            }

        }

        public List<string> getFaculty()
        {
            List<string> list = new List<string>();
            try
            {


               
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                SqlCommand sc = new SqlCommand();
                SqlDataReader reader;
                sc.CommandText = "SELECT * FROM facultyTable ";
                sc.CommandType = CommandType.Text;
                sc.Connection = conn;
                conn.Open();
                reader = sc.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader.GetString(0));

                }
                conn.Close();
            }
            catch
            {

            }

            return list;
        }

        public void DeleteFaculty(String faculty, long username, String dateTime)
        {
            try
            {

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                conn.Open();
                SqlCommand sc = new SqlCommand();
                sc.CommandType = CommandType.Text;
                sc.Connection = conn;

                SqlTransaction transaction;
                transaction = conn.BeginTransaction("new");
                sc.Transaction = transaction;

                try
                {
                    sc.CommandText = "DELETE FROM facultyTable WHERE facultyName = '" + faculty + "'";
                    sc.ExecuteNonQuery();
                    sc.CommandText = " INSERT INTO deletedFacultyTable  (facultyName , date , username) VALUES( '" + faculty + "','" + dateTime + "','" + username + "')";
                    sc.ExecuteNonQuery();
                    sc.CommandText = " INSERT INTO logTable (username , dateTime , description ,tableName) VALUES ('" + username + "','" + dateTime + "','" + "deleted " + faculty + "','" + "facultyTable'" + ")";
                    sc.ExecuteNonQuery();

                    transaction.Commit();

                    popup = new PopUp("حذف موفقیت آمیز", "حذف با موفقیت به پایان رسید.", "تایید", "", "", "success");
                    popup.ShowDialog();

                }
                catch (Exception e)
                {

                    try
                    {
                        transaction.Rollback();
                    }
                    catch
                    {

                    }
                    if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                    {
                        string context = "خطا در برقراری ارتباط.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else if (e.Message.Contains("PRIMARY KEY"))
                    {
                        string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else
                    {
                        popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "error");
                        popup.ShowDialog();
                    }

                }

                conn.Close();
            }

            catch (Exception e)
            {

                if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                {
                    string context = "خطا در برقراری ارتباط.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else if (e.Message.Contains("PRIMARY KEY"))
                {
                    string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else
                {
                    popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "warning");
                    popup.ShowDialog();
                }
            }

        }

        ///////////end query of FacultyTable


        /// <summary>
        /// statusType query
        /// </summary>
        /// <param name=Faculty></param>
        public void AddEGroup(String faculty, String group, long username, String dateTime)
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                conn.Open();
                SqlCommand sc = new SqlCommand();
                sc.CommandType = CommandType.Text;
                sc.Connection = conn;


                SqlTransaction transaction;
                transaction = conn.BeginTransaction("new");
                sc.Transaction = transaction;


                try
                {
                    sc.CommandText = "INSERT INTO EGroupTable (groupName, facultyName) VALUES('" + group + "', '" + faculty + "')";
                    sc.ExecuteNonQuery();
                    sc.CommandText = " INSERT INTO logTable (username , dateTime , description ,tableName) VALUES ('" + username + "','" + dateTime + "','" + "Added " + group + "-" + faculty + "','" + "EGroupTable'" + ")";
                    sc.ExecuteNonQuery();

                    transaction.Commit();

                    popup = new PopUp("افزودن موفقیت آمیز", "افزودن با موفقیت به پایان رسید.", "تایید", "", "", "success");
                    popup.ShowDialog();
                }
                catch (Exception e)
                {

                    try
                    {
                        transaction.Rollback();
                    }
                    catch
                    {

                    }
                    if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                    {
                        string context = "خطا در برقراری ارتباط.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else if (e.Message.Contains("PRIMARY KEY"))
                    {
                        string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else
                    {
                        popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "error");
                        popup.ShowDialog();
                    }

                }

                conn.Close();
            }

            catch (Exception e)
            {

                if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                {
                    string context = "خطا در برقراری ارتباط.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else if (e.Message.Contains("PRIMARY KEY"))
                {
                    string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else
                {
                    popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "warning");
                    popup.ShowDialog();
                }
            }

        }

        public void EditEGroup(String newEGroup, String lastEGroup, long username, String dateTime)
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                conn.Open();
                SqlCommand sc = new SqlCommand();
                sc.CommandType = CommandType.Text;
                sc.Connection = conn;


                SqlTransaction transaction;
                transaction = conn.BeginTransaction("new");
                sc.Transaction = transaction;

                try
                {
                    sc.CommandText = " UPDATE EGroupTable SET groupName = " + "'" + newEGroup + "' WHERE groupName = '" + lastEGroup + "'";
                    sc.ExecuteNonQuery();
                    sc.CommandText = " INSERT INTO logTable (username , dateTime , description ,tableName) VALUES ('" + username + "','" + dateTime + "','" + "Edited from " + lastEGroup + " to " + newEGroup + "','" + "EGroupTable'" + ")";
                    sc.ExecuteNonQuery();

                    transaction.Commit();
                    popup = new PopUp("تغییرات موفقیت آمیز", "تغییرات با موفقیت ثبت شد.", "تایید", "", "", "success");
                    popup.ShowDialog();

                }
                catch (Exception e)
                {

                    try
                    {
                        transaction.Rollback();
                    }
                    catch
                    {

                    }
                    if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                    {
                        string context = "خطا در برقراری ارتباط.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else if (e.Message.Contains("PRIMARY KEY"))
                    {
                        string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else
                    {
                        popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "error");
                        popup.ShowDialog();
                    }

                }

                conn.Close();
            }

            catch (Exception e)
            {

                if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                {
                    string context = "خطا در برقراری ارتباط.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else if (e.Message.Contains("PRIMARY KEY"))
                {
                    string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else
                {
                    popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "warning");
                    popup.ShowDialog();
                }
            }

        }

        public List<string> getEGroup(string faculty)
        {
            List<string> list = new List<string>();
            try
            {


                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                SqlCommand sc = new SqlCommand();
                SqlDataReader reader;
                sc.CommandText = "SELECT * FROM EGroupTable WHERE facultyName='" + faculty + "'";
                sc.CommandType = CommandType.Text;
                sc.Connection = conn;
                conn.Open();
                reader = sc.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader.GetString(0));
                }
                conn.Close();
            }
            catch
            {

            }
            return list;

        }

        public void DeleteEGroup(String groupName, String facultyName, long username, String dateTime)
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                conn.Open();
                SqlCommand sc = new SqlCommand();
                sc.CommandType = CommandType.Text;
                sc.Connection = conn;

                SqlTransaction transaction;
                transaction = conn.BeginTransaction("new");
                sc.Transaction = transaction;

                try
                {
                    sc.CommandText = " DELETE FROM EGroupTable WHERE groupName = '" + groupName + "'";
                    sc.ExecuteNonQuery();
                    sc.CommandText = " INSERT INTO deletedEGroupTable  (groupName ,facultyName , date , username) VALUES( '" + groupName + "','" + facultyName + "' ,'" + dateTime + "','" + username + "')";
                    sc.ExecuteNonQuery();
                    sc.CommandText = " INSERT INTO logTable (username , dateTime , description ,tableName) VALUES ('" + username + "','" + dateTime + "','" + "deleted " + groupName + "-" + facultyName + "','" + "EGroupTable'" + ")";
                    sc.ExecuteNonQuery();

                    transaction.Commit();

                    popup = new PopUp("حذف موفقیت آمیز", "حذف با موفقیت به پایان رسید.", "تایید", "", "", "success");
                    popup.ShowDialog();

                }
                catch (Exception e)
                {

                    try
                    {
                        transaction.Rollback();
                    }
                    catch
                    {

                    }
                    if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                    {
                        string context = "خطا در برقراری ارتباط.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else if (e.Message.Contains("PRIMARY KEY"))
                    {
                        string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else
                    {
                        popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "error");
                        popup.ShowDialog();
                    }

                }

                conn.Close();
            }

            catch (Exception e)
            {

                if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                {
                    string context = "خطا در برقراری ارتباط.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else if (e.Message.Contains("PRIMARY KEY"))
                {
                    string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else
                {
                    popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "warning");
                    popup.ShowDialog();
                }
            }

        }


        ///////////end query of EducationalGroup



        public List<string> getEDeg()
        {
            List<string> list = new List<string>();
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                SqlCommand sc = new SqlCommand();
                SqlDataReader reader;
                sc.CommandText = "SELECT * FROM EDegreeTable";
                sc.CommandType = CommandType.Text;
                sc.Connection = conn;
                conn.Open();
                reader = sc.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader.GetString(0));
                }
                conn.Close();
            }
            catch
            {

            }
            return list;

        }
        public void DeleteEDegree(String EDegree, long username, String dateTime)
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                conn.Open();
                SqlCommand sc = new SqlCommand();
                sc.CommandType = CommandType.Text;
                sc.Connection = conn;

                SqlTransaction transaction;
                transaction = conn.BeginTransaction("new");
                sc.Transaction = transaction;

                try
                {
                    sc.CommandText = " DELETE FROM EDegreeTable WHERE EDegree = '" + EDegree + "'";
                    sc.ExecuteNonQuery();
                    sc.CommandText = " INSERT INTO deletedEDegreeTable  (EDegree , date , username) VALUES ( '" + EDegree + "' ,'" + dateTime + "' ,'" + username + "')";
                    sc.ExecuteNonQuery();
                    sc.CommandText = " INSERT INTO logTable (username , dateTime , description ,tableName) VALUES ('" + username + "','" + dateTime + "','" + "deleted " + EDegree + "','" + "EDegreeTable'" + ")";
                    sc.ExecuteNonQuery();

                    transaction.Commit();

                    popup = new PopUp("حذف موفقیت آمیز", "حذف با موفقیت به پایان رسید.", "تایید", "", "", "success");
                    popup.ShowDialog();

                }
                catch (Exception e)
                {

                    try
                    {
                        transaction.Rollback();
                    }
                    catch
                    {

                    }
                    if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                    {
                        string context = "خطا در برقراری ارتباط.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else if (e.Message.Contains("PRIMARY KEY"))
                    {
                        string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else
                    {
                        popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "error");
                        popup.ShowDialog();
                    }

                }

                conn.Close();
            }

            catch (Exception e)
            {

                if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                {
                    string context = "خطا در برقراری ارتباط.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else if (e.Message.Contains("PRIMARY KEY"))
                {
                    string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else
                {
                    popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "warning");
                    popup.ShowDialog();
                }
            }

        }

        public void EditEDegree(String newEDegree, String lastEDegree, long username, String dateTime)
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                conn.Open();
                SqlCommand sc = new SqlCommand();
                sc.CommandType = CommandType.Text;
                sc.Connection = conn;


                SqlTransaction transaction;
                transaction = conn.BeginTransaction("new");
                sc.Transaction = transaction;

                try
                {
                    sc.CommandText = "UPDATE EDegreeTable SET EDegree = " + "'" + newEDegree + "' WHERE EDegree = '" + lastEDegree + "'";
                    sc.ExecuteNonQuery();
                    sc.CommandText = " INSERT INTO logTable (username , dateTime , description ,tableName) VALUES ('" + username + "','" + dateTime + "','" + "Edited from " + lastEDegree + " to " + newEDegree + "','" + "EDegree'" + ")";
                    sc.ExecuteNonQuery();

                    transaction.Commit();
                    popup = new PopUp("تغییرات موفقیت آمیز", "تغییرات با موفقیت ثبت شد.", "تایید", "", "", "success");
                    popup.ShowDialog();

                }
                catch (Exception e)
                {

                    try
                    {
                        transaction.Rollback();
                    }
                    catch
                    {

                    }
                    if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                    {
                        string context = "خطا در برقراری ارتباط.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else if (e.Message.Contains("PRIMARY KEY"))
                    {
                        string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else
                    {
                        popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "error");
                        popup.ShowDialog();
                    }

                }

                conn.Close();
            }

            catch (Exception e)
            {

                if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                {
                    string context = "خطا در برقراری ارتباط.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else if (e.Message.Contains("PRIMARY KEY"))
                {
                    string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else
                {
                    popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "warning");
                    popup.ShowDialog();
                }
            }

        }

        public void AddEDegree(String EDegree, long username, String dateTime)
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                conn.Open();
                SqlCommand sc = new SqlCommand();
                sc.CommandType = CommandType.Text;
                sc.Connection = conn;

                SqlTransaction transaction;
                transaction = conn.BeginTransaction("new");
                sc.Transaction = transaction;


                try
                {
                    sc.CommandText = "INSERT INTO EDegreeTable (EDegree) VALUES ('" + EDegree + "' )";
                    sc.ExecuteNonQuery();
                    sc.CommandText = " INSERT INTO logTable (username , dateTime , description ,tableName) VALUES ('" + username + "','" + dateTime + "','" + "Added " + EDegree + "','" + "EDegreeTable'" + ")";
                    sc.ExecuteNonQuery();

                    transaction.Commit();

                    popup = new PopUp("افزودن موفقیت آمیز", "افزودن با موفقیت به پایان رسید.", "تایید", "", "", "success");
                    popup.ShowDialog();
                }
                catch (Exception e)
                {

                    try
                    {
                        transaction.Rollback();
                    }
                    catch
                    {

                    }
                    if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                    {
                        string context = "خطا در برقراری ارتباط.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else if (e.Message.Contains("PRIMARY KEY"))
                    {
                        string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else
                    {
                        popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "error");
                        popup.ShowDialog();
                    }

                }

                conn.Close();
            }

            catch (Exception e)
            {

                if (e.Message.Contains("Timeout expired") || e.Message.Contains("server was not found") || e.Message.Contains("expired"))
                {
                    string context = "خطا در برقراری ارتباط.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else if (e.Message.Contains("PRIMARY KEY"))
                {
                    string context = "قبلا با این مشخصات اطلاعاتی وارد شده است.";
                    Alert alert = new Alert(context, "darkred", 5);
                }
                else
                {
                    popup = new PopUp("خطای سیستمی", "با پشتیبانی تماس حاصل فرمایید .", "تایید", "", "", "warning");
                    popup.ShowDialog();
                }
            }

        }




        ////////////////////////////////////////////////////////////////////////////
        /***********************************GET DATA******************************/
        ///////////////////////////////////////////////////////////////////////////
        private void GetData(string selectCommand, BindingSource bindingSourceObj, DataGridViewX dataGridview)
        {
            // Create a new data adapter based on the specified query.
            dataAdapter = new SqlDataAdapter(selectCommand, conString);

            // Create a command builder to generate SQL update, insert, and
            // delete commands based on selectCommand. These are used to
            // update the database.

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

            // Populate a new data table and bind it to the BindingSource.
            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter.Fill(table);
            bindingSourceObj.DataSource = table;


            // Resize the DataGridView columns to fit the newly loaded content.
            dataGridview.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridview.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);

            int i = 0;
            while (true)
            {
                try
                {
                    dataGridview.Rows[i].HeaderCell.Value = (i + 1) + "";
                    i++;
                }
                catch (ArgumentOutOfRangeException e1)
                {
                    break;
                }
            }

            if (selectCommand.Contains("UsersTable"))
            {
                dataGridview.Columns[0].HeaderText = "کد ملي";
                dataGridview.Columns[1].HeaderText = "رمز عبور";
                dataGridview.Columns[2].HeaderText = "نام";
                dataGridview.Columns[3].HeaderText = "نام خانوادگي";
                dataGridview.Columns[4].HeaderText = "ايميل";
                dataGridview.Columns[5].HeaderText = "تلفن تماس";
                dataGridview.Columns[6].HeaderText = "افزودن پروپوزال";
                dataGridview.Columns[7].HeaderText = "تغيير اطلاعات پروپوزال";
                dataGridview.Columns[8].HeaderText = "حذف پروپوزال";
                dataGridview.Columns[9].HeaderText = "افزودن کاربر";
                dataGridview.Columns[10].HeaderText = "تغيير اطلاعات کاربر";
                dataGridview.Columns[11].HeaderText = "حذف کاربر";
                dataGridview.Columns[12].HeaderText = "مديريت اطلاعات اساتيد";
                dataGridview.Columns[13].HeaderText = "تغيير تنظيمات برنامه";
                dataGridview.Columns[14].Visible = false;
            }

            else if (selectCommand.Contains("proposalTable"))
            {
                dataGridview.Columns[0].Visible = false;
                dataGridview.Columns[1].HeaderText = "عنوان فارسی";
                dataGridview.Columns[2].HeaderText = "عنوان لاتین";
                dataGridview.Columns[3].HeaderText = "کلمه کلیدی";
                dataGridview.Columns[4].HeaderText = "مجری";
                dataGridview.Columns[5].HeaderText = "مجریان همکار";
                dataGridview.Columns[6].HeaderText = "همکاران مجری";
                dataGridview.Columns[7].HeaderText = "تاریخ شروع";
                dataGridview.Columns[8].HeaderText = "مدت زمان";
                dataGridview.Columns[9].HeaderText = "نوع کار";
                dataGridview.Columns[10].HeaderText = "خاصیت";
                dataGridview.Columns[11].HeaderText = "نوع ثبت";
                dataGridview.Columns[12].HeaderText = "نوع پروپوزال";
                dataGridview.Columns[13].HeaderText = "سازمان کارفرما";
                dataGridview.Columns[14].HeaderText = "هزینه";
                dataGridview.Columns[15].HeaderText = "وضعیت";
                dataGridview.Columns[16].HeaderText = "کاربر ثبت کننده";
                dataGridview.Columns[17].HeaderText = "فایل پروپوزال";
            }

            else if (selectCommand.Contains("TeacherTable"))
            {
                dataGridview.Columns[0].HeaderText = "کد ملی";
                dataGridview.Columns[1].HeaderText = "نام";
                dataGridview.Columns[2].HeaderText = "نام خانوادگی";
                dataGridview.Columns[3].HeaderText = "دانشکده";
                dataGridview.Columns[4].HeaderText = "گروه آموزشی";
                dataGridview.Columns[5].HeaderText = "درجه علمی";
                dataGridview.Columns[6].HeaderText = "ایمیل";
                dataGridview.Columns[7].HeaderText = "تلفن همراه";
                dataGridview.Columns[8].HeaderText = "تلفن 1";
                dataGridview.Columns[9].HeaderText = "تلفن 2";
            }


        }
        ////////////////////////////////////////////////////////////////////////////
        /***********************************GET DATA******************************/
        ///////////////////////////////////////////////////////////////////////////




        ////////////////////////////////////////////////////////////////////////////
        /***********************************GridView Update***********************/
        ///////////////////////////////////////////////////////////////////////////
        public void dataGridViewUpdate(DataGridViewX dgv, BindingSource bindingSource, String query)
        {
            /// <summary>
            /// datagridview reintialization
            /// </summary>
            dgv.DataSource = bindingSource;
            GetData(query, bindingSource, dgv);
        }


        /////////JUST TEST
        public void dataGridViewUpdate3(DataGridView dgvv, BindingSource bindingSource, String query, int PgSize, int page)
        {
            int PreviousPageOffSet;
            /// <summary>
            /// datagridview reintialization
            /// </summary>
            if (query.Contains("logTable"))
            {
                PreviousPageOffSet = (page - 1) * 30;
            }
            else
            {
                PreviousPageOffSet = (page - 1) * PgSize ;
            }
            dgvv.DataSource = bindingSource;

            GetData3(query, bindingSource, dgvv, PgSize, PreviousPageOffSet);

            if (query.Contains("proposalTable"))
            {

                foreach (DataGridViewRow row in dgvv.Rows)
                {
                    string fullName;
                    fullName = getExecutorName(long.Parse(row.Cells["executor"].Value.ToString()));
                    row.Cells["executorFullName"].Value = fullName;
                }
                foreach (DataGridViewRow row in dgvv.Rows)
                {
                    string fullName;
                    fullName = getEmployerName(long.Parse(row.Cells["employer"].Value.ToString()));
                    row.Cells["employerName"].Value = fullName;
                }
                foreach (DataGridViewRow row in dgvv.Rows)
                {
                    string fullName;
                    fullName = getDateHijri(row.Cells["startDate"].Value.ToString());
                    row.Cells["hijriDate"].Value = fullName;
                }
            }


            dgvv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            dgvv.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
            //dgvv.Columns.= DataGridViewColumnSortMode.NotSortable;
            foreach(DataGridViewColumn col in dgvv.Columns)
            {
                dgvv.Columns[col.Name].SortMode =DataGridViewColumnSortMode.Programmatic;
            }
           // dgvv.RowTemplate.Height = 60;
        }
        private void GetData3(string selectCommand, BindingSource bindingSourceObj, DataGridView dataGridview,int PgSize, int PreviousPageOffSet)
        {
            //// Create a new data adapter based on the specified query.
            //dataAdapter = new SqlDataAdapter(selectCommand, conString);

            //// Create a command builder to generate SQL update, insert, and
            //// delete commands based on selectCommand. These are used to
            //// update the database.

            //SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

            //// Populate a new data table and bind it to the BindingSource.
            //DataTable table = new DataTable();
            //table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            //dataAdapter.Fill(table);
            //bindingSourceObj.DataSource = table;


            // Resize the DataGridView columns to fit the newly loaded content.
            //dataGridview.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            //dataGridview.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);

           
           

            if (selectCommand.Contains("UsersTable"))
            {
                string q = "Select TOP " + PgSize +
                           " * from UsersTable WHERE [index] NOT IN " +
                           "(Select TOP " + PreviousPageOffSet +
                           " [index] from UsersTable ORDER BY [index] ) ";

                // Create a new data adapter based on the specified query.
                dataAdapter = new SqlDataAdapter(q, conString);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand. These are used to
                // update the database.

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                // Populate a new data table and bind it to the BindingSource.
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                bindingSourceObj.DataSource = table;


                dataGridview.Columns[0].HeaderText = "کد ملي";
                dataGridview.Columns[1].HeaderText = "رمز عبور";
                dataGridview.Columns[2].HeaderText = "نام";
                dataGridview.Columns[3].HeaderText = "نام خانوادگي";
                dataGridview.Columns[4].HeaderText = "ايميل";
                dataGridview.Columns[5].HeaderText = "تلفن تماس";
                dataGridview.Columns[6].HeaderText = "افزودن پروپوزال";
                dataGridview.Columns[7].HeaderText = "تغيير اطلاعات پروپوزال";
                dataGridview.Columns[8].HeaderText = "حذف پروپوزال";
                dataGridview.Columns[9].HeaderText = "افزودن کاربر";
                dataGridview.Columns[10].HeaderText = "تغيير اطلاعات کاربر";
                dataGridview.Columns[11].HeaderText = "حذف کاربر";
                dataGridview.Columns[12].HeaderText = "مديريت اطلاعات اساتيد";
                dataGridview.Columns[13].HeaderText = "تغيير تنظيمات برنامه";
                dataGridview.Columns[14].Visible = false;
            }

            else if (selectCommand.Contains("proposalTable"))
            {
                if (dataGridview.Name  == "addProposalShowDgv")
                {
                    string q = addProposalQuery + " AND  [index] NOT IN " +
                               "(SELECT TOP " + PreviousPageOffSet +
                               " [index] FROM proposalTable ORDER BY startDate ) ";
                    // Create a new data adapter based on the specified query.
                    dataAdapter = new SqlDataAdapter(q, conString);

                    // Create a command builder to generate SQL update, insert, and
                    // delete commands based on selectCommand. These are used to
                    // update the database.

                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                    // Populate a new data table and bind it to the BindingSource.
                    DataTable table = new DataTable();
                    table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    dataAdapter.Fill(table);
                    bindingSourceObj.DataSource = table;
                }

                if (dataGridview.Name == "searchProposalShowDgv")
                {
                    string q = searchProposalQuery + " AND  [index] NOT IN " +
                               "(SELECT TOP " + PreviousPageOffSet +
                               " [index] FROM proposalTable ORDER BY startDate ) ";
                    // Create a new data adapter based on the specified query.
                    dataAdapter = new SqlDataAdapter(q, conString);

                    // Create a command builder to generate SQL update, insert, and
                    // delete commands based on selectCommand. These are used to
                    // update the database.

                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                    // Populate a new data table and bind it to the BindingSource.
                    DataTable table = new DataTable();
                    table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    dataAdapter.Fill(table);
                    bindingSourceObj.DataSource = table;
                }

                if (dataGridview.Name == "editProposalShowDgv")
                {
                    string q = editProposalQuery + " AND  [index] NOT IN " +
                               "(SELECT TOP " + PreviousPageOffSet +
                               " [index] FROM proposalTable ORDER BY startDate ) ";
                    // Create a new data adapter based on the specified query.
                    dataAdapter = new SqlDataAdapter(q, conString);

                    // Create a command builder to generate SQL update, insert, and
                    // delete commands based on selectCommand. These are used to
                    // update the database.

                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                    // Populate a new data table and bind it to the BindingSource.
                    DataTable table = new DataTable();
                    table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    dataAdapter.Fill(table);
                    bindingSourceObj.DataSource = table;
                    
                }








                ////////////////




                dataGridview.Columns["engTitle"].HeaderText = "عنوان لاتین";
                dataGridview.Columns["keyword"].HeaderText = "کلمه کلیدی";
                dataGridview.Columns["executor2"].HeaderText = "مجریان همکار";
                dataGridview.Columns["coExecutor"].HeaderText = "همکاران مجری";
                dataGridview.Columns["startDate"].HeaderText = "تاریخ شروع";
                dataGridview.Columns["duration"].HeaderText = "مدت زمان";
                dataGridview.Columns["procedureType"].HeaderText = "نوع کار";
                dataGridview.Columns["propertyType"].HeaderText = "خاصیت";
                dataGridview.Columns["registerType"].HeaderText = "نوع ثبت";
                dataGridview.Columns["proposalType"].HeaderText = "نوع پروپوزال";
                dataGridview.Columns["employer"].HeaderText = "سازمان کارفرما";
                dataGridview.Columns["value"].HeaderText = "هزینه";
                dataGridview.Columns["status"].HeaderText = "وضعیت";
                dataGridview.Columns["registrant"].HeaderText = "کاربر ثبت کننده";
                dataGridview.Columns["fileName"].HeaderText = "فایل پروپوزال";



                ///////////
                DataGridViewLinkColumn btn = new DataGridViewLinkColumn();
                dataGridview.Columns.Add(btn);
                btn.HeaderText = "اطلاعات";
                btn.Text = "نمایش کلی";
                btn.Name = "detailBtn";

                DataGridViewLinkColumn btn2 = new DataGridViewLinkColumn();
                dataGridview.Columns.Add(btn2);
                btn2.HeaderText = "نسخه";
                btn2.Text = "نمایش جزییات";
                btn2.Name = "editionBtn";

                dataGridview.Columns.Add("executorFullName", "مجری");
                dataGridview.Columns["executorFullName"].DisplayIndex = 20;
                dataGridview.Columns.Add("hijriDate", "تاریخ");
                dataGridview.Columns["hijriDate"].DisplayIndex = 21;
                dataGridview.Columns.Add("employerName", "سازمان کارفرما");
                dataGridview.Columns["employerName"].DisplayIndex = 22;

                btn.UseColumnTextForLinkValue = true;
                btn2.UseColumnTextForLinkValue = true;

                dataGridview.Columns["editionBtn"].Visible = true;
                dataGridview.Columns["detailBtn"].Visible = true;


                dataGridview.Columns[0].Visible = false;
                dataGridview.Columns["detailBtn"].DisplayIndex = 0;
               // dataGridview.Columns["detailBtn"].Frozen = true;
                dataGridview.Columns["editionBtn"].DisplayIndex = 1;
                dataGridview.Columns["editionBtn"].Frozen = true;

                dataGridview.Columns["executor"].HeaderText = "مجری";
                dataGridview.Columns["executorFullName"].DisplayIndex = 2;
                dataGridview.Columns["executorFullName"].Frozen = true;
                dataGridview.Columns["executor"].Visible = false;
                //  dataGridview.Columns["executorFullName"].Frozen = true;

                dataGridview.Columns["persianTitle"].HeaderText = "عنوان فارسی";
                dataGridview.Columns["persianTitle"].DisplayIndex = 3;
                dataGridview.Columns["persianTitle"].Frozen = true;
                ///////////////////////
                dataGridview.Columns["startDate"].Visible = false;
                dataGridview.Columns["employer"].Visible = false;
                dataGridview.Columns["fileName"].Visible = false;

            }

            else if (selectCommand.Contains("TeacherTable"))
            {

                //if (dataGridview.Name == "manageTeacherShowDgv")
                //{
                //    string q = manageTeacherQuery + " AND  [index] NOT IN " +
                //               "(SELECT TOP " + PreviousPageOffSet +
                //               " [index] FROM proposalTable ORDER BY startDate ) ";
                //    // Create a new data adapter based on the specified query.
                //    dataAdapter = new SqlDataAdapter(q, conString);

                //    // Create a command builder to generate SQL update, insert, and
                //    // delete commands based on selectCommand. These are used to
                //    // update the database.

                //    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                //    // Populate a new data table and bind it to the BindingSource.
                //    DataTable table = new DataTable();
                //    table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                //    dataAdapter.Fill(table);
                //    bindingSourceObj.DataSource = table;
                //}

                string q = manageTeacherQuery + " AND  t_NCode NOT IN " +
                               "(SELECT TOP " + PreviousPageOffSet +
                               " t_NCode FROM TeacherTable ORDER BY t_NCode ) ";

                // Create a new data adapter based on the specified query.
                dataAdapter = new SqlDataAdapter(q, conString);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand. These are used to
                // update the database.

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                // Populate a new data table and bind it to the BindingSource.
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                bindingSourceObj.DataSource = table;


                dataGridview.Columns[0].HeaderText = "کد ملی";
                dataGridview.Columns[1].HeaderText = "نام";
                dataGridview.Columns[2].HeaderText = "نام خانوادگی";
                dataGridview.Columns[3].HeaderText = "دانشکده";
                dataGridview.Columns[4].HeaderText = "گروه آموزشی";
                dataGridview.Columns[5].HeaderText = "درجه علمی";
                dataGridview.Columns[6].HeaderText = "ایمیل";
                dataGridview.Columns[7].HeaderText = "تلفن همراه";
                dataGridview.Columns[8].HeaderText = "تلفن 1";
                dataGridview.Columns[9].HeaderText = "تلفن 2";
            }
            else if (selectCommand.Contains("logTable"))
            {
                string q = logQuery + " AND  log# NOT IN " +
                              "(SELECT TOP " + PreviousPageOffSet +
                              " log# FROM logTable ORDER BY log# ) ";

                // Create a new data adapter based on the specified query.
                dataAdapter = new SqlDataAdapter(q, conString);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand. These are used to
                // update the database.

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                // Populate a new data table and bind it to the BindingSource.
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                bindingSourceObj.DataSource = table;
            }

            int i = PreviousPageOffSet;
            int j = 0;
            while (true)
            {
                try
                {
                    
                    dataGridview.Rows[j].HeaderCell.Value = (i + 1) + "";
                    i++;
                    j++;
                }
                catch (ArgumentOutOfRangeException e1)
                {
                    break;
                }
            }
            
        }

        public int totalPage(string query)
        {
            int totalPages = 0;
            float temp = 0;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            conn.Open();
            SqlCommand sc = new SqlCommand();
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            SqlDataReader reader;


            SqlTransaction transaction;
            transaction = conn.BeginTransaction("new");
            sc.Transaction = transaction;


            try
            {


                sc.CommandText = query;
                reader = sc.ExecuteReader();
                reader.Read();
                int rowCount = reader.GetInt32(0);
                reader.Close();
                totalPages = rowCount / PgSize;
                temp = (float)rowCount / (float)PgSize;
                if(temp == totalPages)
                {
                    totalPages = totalPages - 1; 
                }
                transaction.Commit();

            }
            catch
            {
                //MessageBox.Show("خطا در برقراری ارتباط");
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    //MessageBox.Show("خطا در برقراری ارتباط");
                }
            }

            conn.Close();

            return totalPages+1;
        }

        public int totalLogPage(string query)
        {
            int totalPages = 0;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            conn.Open();
            SqlCommand sc = new SqlCommand();
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            SqlDataReader reader;


            SqlTransaction transaction;
            transaction = conn.BeginTransaction("new");
            sc.Transaction = transaction;


            try
            {

                sc.CommandText = query;
                reader = sc.ExecuteReader();
                reader.Read();
                int rowCount = reader.GetInt32(0);
                reader.Close();
                totalPages = rowCount / 30;
                transaction.Commit();

            }
            catch
            {
               // MessageBox.Show("خطا در برقراری ارتباط");
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                   // MessageBox.Show("خطا در برقراری ارتباط");
                }
            }

            conn.Close();

            return totalPages + 1;
        }


        /// <summary>
        /// neeeeeeeeew
        /// </summary>
        /// <param name="dgvv"></param>
        /// <param name="bindingSource"></param>
        /// <param name="query"></param>

        public void dataGridViewUpdate2(DataGridView dgvv, BindingSource bindingSource, String query)
        {
            /// <summary>
            /// datagridview reintialization
            /// </summary>
            try
            {


                dgvv.DataSource = bindingSource;
                GetData2(query, bindingSource, dgvv);

                if (query.Contains("proposalTable"))
                {

                    foreach (DataGridViewRow row in dgvv.Rows)
                    {
                        string fullName;
                        fullName = getExecutorName(long.Parse(row.Cells["executor"].Value.ToString()));
                        row.Cells["executorFullName"].Value = fullName;
                    }
                    foreach (DataGridViewRow row in dgvv.Rows)
                    {
                        string fullName;
                        fullName = getEmployerName(long.Parse(row.Cells["employer"].Value.ToString()));
                        row.Cells["employerName"].Value = fullName;
                    }
                    foreach (DataGridViewRow row in dgvv.Rows)
                    {
                        string fullName;
                        fullName = getDateHijri(row.Cells["startDate"].Value.ToString());
                        row.Cells["hijriDate"].Value = fullName;
                    }
                }
                if (query.Contains("editionTable"))
                {

                    foreach (DataGridViewRow row in dgvv.Rows)
                    {
                        string fullName;
                        fullName = getExecutorName(long.Parse(row.Cells["executor"].Value.ToString()));
                        row.Cells["executorFullName"].Value = fullName;
                    }
                    foreach (DataGridViewRow row in dgvv.Rows)
                    {
                        string fullName;
                        fullName = getEmployerName(long.Parse(row.Cells["employer"].Value.ToString()));
                        row.Cells["employerName"].Value = fullName;
                    }
                    foreach (DataGridViewRow row in dgvv.Rows)
                    {
                        string fullName;
                        fullName = getDateHijri(row.Cells["startDate"].Value.ToString());
                        row.Cells["hijriDate"].Value = fullName;
                    }
                }

                dgvv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
                dgvv.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
                foreach (DataGridViewColumn col in dgvv.Columns)
                {
                    dgvv.Columns[col.Name].SortMode = DataGridViewColumnSortMode.Programmatic;
                }
            }
            catch
            {

            }
        }
        private void GetData2(string selectCommand, BindingSource bindingSourceObj, DataGridView dataGridview)
        {
            // Create a new data adapter based on the specified query.
            dataAdapter = new SqlDataAdapter(selectCommand, conString);

            // Create a command builder to generate SQL update, insert, and
            // delete commands based on selectCommand. These are used to
            // update the database.

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

            // Populate a new data table and bind it to the BindingSource.
            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter.Fill(table);
            bindingSourceObj.DataSource = table;


            // Resize the DataGridView columns to fit the newly loaded content.
           

            int i = 0;
            while (true)
            {
                try
                {
                    dataGridview.Rows[i].HeaderCell.Value = (i + 1) + "";
                    i++;
                }
                catch (ArgumentOutOfRangeException e1)
                {
                    break;
                }
            }

            if (selectCommand.Contains("UsersTable"))
            {
                dataGridview.Columns[0].HeaderText = "کد ملي";
                dataGridview.Columns[1].HeaderText = "رمز عبور";
                dataGridview.Columns[2].HeaderText = "نام";
                dataGridview.Columns[3].HeaderText = "نام خانوادگي";
                dataGridview.Columns[4].HeaderText = "ايميل";
                dataGridview.Columns[5].HeaderText = "تلفن تماس";
                dataGridview.Columns[6].HeaderText = "افزودن پروپوزال";
                dataGridview.Columns[7].HeaderText = "تغيير اطلاعات پروپوزال";
                dataGridview.Columns[8].HeaderText = "حذف پروپوزال";
                dataGridview.Columns[9].HeaderText = "افزودن کاربر";
                dataGridview.Columns[10].HeaderText = "تغيير اطلاعات کاربر";
                dataGridview.Columns[11].HeaderText = "حذف کاربر";
                dataGridview.Columns[12].HeaderText = "مديريت اطلاعات اساتيد";
                dataGridview.Columns[13].HeaderText = "تغيير تنظيمات برنامه";
                dataGridview.Columns[14].Visible = false;
            }

            else if (selectCommand.Contains("proposalTable"))
            {
                DataGridViewLinkColumn btn = new DataGridViewLinkColumn();
                dataGridview.Columns.Add(btn);
                btn.HeaderText = "اطلاعات کلی";
                btn.Text = "نمایش کلی";
                btn.Name = "detailBtn";

                DataGridViewLinkColumn btn2 = new DataGridViewLinkColumn();
                dataGridview.Columns.Add(btn2);
                btn2.HeaderText = "نسخه";
                btn2.Text = "نمایش جزییات";
                btn2.Name = "editionBtn";



                btn.UseColumnTextForLinkValue = true;
                btn2.UseColumnTextForLinkValue = true;

                dataGridview.Columns["editionBtn"].Visible = true;
                dataGridview.Columns["detailBtn"].Visible = true;


                dataGridview.Columns[0].Visible = false;
                dataGridview.Columns["detailBtn"].DisplayIndex = 0;
                dataGridview.Columns["detailBtn"].Frozen = true;
                dataGridview.Columns["editionBtn"].DisplayIndex = 1;
                dataGridview.Columns["editionBtn"].Frozen = true;

                dataGridview.Columns["executor"].HeaderText = "مجری";
                dataGridview.Columns["executor"].DisplayIndex = 2;
                dataGridview.Columns["executor"].Frozen = true;
                dataGridview.Columns["persianTitle"].HeaderText = "عنوان فارسی";
                dataGridview.Columns["persianTitle"].DisplayIndex = 3;
                dataGridview.Columns["persianTitle"].Frozen = true;



                dataGridview.Columns["engTitle"].HeaderText = "عنوان لاتین";
                dataGridview.Columns["keyword"].HeaderText = "کلمه کلیدی";
                dataGridview.Columns["executor2"].HeaderText = "مجریان همکار";
                dataGridview.Columns["coExecutor"].HeaderText = "همکاران مجری";
                dataGridview.Columns["startDate"].HeaderText = "تاریخ شروع";
                dataGridview.Columns["duration"].HeaderText = "مدت زمان";
                dataGridview.Columns["procedureType"].HeaderText = "نوع کار";
                dataGridview.Columns["propertyType"].HeaderText = "خاصیت";
                dataGridview.Columns["registerType"].HeaderText = "نوع ثبت";
                dataGridview.Columns["proposalType"].HeaderText = "نوع پروپوزال";
                dataGridview.Columns["employer"].HeaderText = "سازمان کارفرما";
                dataGridview.Columns["value"].HeaderText = "هزینه";
                dataGridview.Columns["status"].HeaderText = "وضعیت";
                dataGridview.Columns["registrant"].HeaderText = "کاربر ثبت کننده";
                dataGridview.Columns["fileName"].HeaderText = "فایل پروپوزال";
                dataGridview.Columns["edition"].HeaderText = "شماره نسخه";


                dataGridview.Columns["startDate"].Visible = false;
                dataGridview.Columns["employer"].Visible = false;
                dataGridview.Columns["fileName"].Visible = false;

            }

            else if (selectCommand.Contains("TeacherTable"))
            {
                dataGridview.Columns[0].HeaderText = "کد ملی";
                dataGridview.Columns[1].HeaderText = "نام";
                dataGridview.Columns[2].HeaderText = "نام خانوادگی";
                dataGridview.Columns[3].HeaderText = "دانشکده";
                dataGridview.Columns[4].HeaderText = "گروه آموزشی";
                dataGridview.Columns[5].HeaderText = "درجه علمی";
                dataGridview.Columns[6].HeaderText = "ایمیل";
                dataGridview.Columns[7].HeaderText = "تلفن همراه";
                dataGridview.Columns[8].HeaderText = "تلفن 1";
                dataGridview.Columns[9].HeaderText = "تلفن 2";
            }

            
            int j = 0;
            while (true)
            {
                try
                {

                    dataGridview.Rows[j].HeaderCell.Value = (j + 1) + "";
                   
                    j++;
                }
                catch (ArgumentOutOfRangeException e1)
                {
                    break;
                }
            }
           

        }

        /////////JUST TEST
        ////////////////////////////////////////////////////////////////////////////
        /***********************************GridView Update***********************/
        ///////////////////////////////////////////////////////////////////////////





        //public void uploadFile(FTPSetting _inputParameter)
        //{
        //    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(string.Format("{0}/{1}", "ftp://185.159.152.5", _inputParameter.FileName)));
        //    request.Method = WebRequestMethods.Ftp.UploadFile;
        //    request.Credentials = new NetworkCredential(_inputParameter.Username, _inputParameter.Password);
        //    Stream FtpStream = request.GetRequestStream();
        //    FileStream fs = File.OpenRead(_inputParameter.FullName);
        //    byte[] buffer = new byte[1024];
        //    double total = (double)fs.Length;
        //    int byteRead = 0;
        //    double read = 0;
        //    do
        //    {

        //        byteRead = fs.Read(buffer, 0, 1024);
        //        FtpStream.Write(buffer, 0, byteRead);
        //        read += (double)byteRead;
        //        double percentage = read / total * 100;
        //    }
        //    while (byteRead != 0);
        //    fs.Close();
        //    FtpStream.Close();
        //}
        public void uploadFile(FTPSetting _inputParameter)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(string.Format("{0}/{1}", "ftp://169.254.92.252", _inputParameter.FileName)));
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential("nima", "H-0sein");
            Stream FtpStream = request.GetRequestStream();
            FileStream fs = File.OpenRead(_inputParameter.FullName);
            byte[] buffer = new byte[1024];
            double total = (double)fs.Length;
            int byteRead = 0;
            double read = 0;
            do
            {

                byteRead = fs.Read(buffer, 0, 1024);
                FtpStream.Write(buffer, 0, byteRead);
                read += (double)byteRead;
                double percentage = read / total * 100;
            }
            while (byteRead != 0);
            fs.Close();
            FtpStream.Close();
        }

        //169.254.92.252

        //public string downloadFile(string FileNameToDownload, string tempDirPath)
        //{
        //    string DownloadedFilePath = "";
        //    string ResponseDescription = "";
        //    string PureFileName = new FileInfo(FileNameToDownload).Name;


        //    DownloadedFilePath = tempDirPath;
        //    string downloadUrl = String.Format("{0}/{1}", "ftp://185.159.152.5/", FileNameToDownload);
        //    FtpWebRequest req = (FtpWebRequest)FtpWebRequest.Create(downloadUrl);
        //    req.Method = WebRequestMethods.Ftp.DownloadFile;
        //    req.Credentials = new NetworkCredential("Nima", "P@hn1395");
        //    req.UseBinary = true;
        //    req.Proxy = null;

        //    FtpWebResponse response = (FtpWebResponse)req.GetResponse();
        //    Stream stream = response.GetResponseStream();
        //    byte[] buffer = new byte[2048];
        //    FileStream fs = new FileStream(DownloadedFilePath, FileMode.Create);
        //    int ReadCount = stream.Read(buffer, 0, buffer.Length);
        //    while (ReadCount > 0)
        //    {
        //        fs.Write(buffer, 0, ReadCount);
        //        ReadCount = stream.Read(buffer, 0, buffer.Length);
        //    }
        //    ResponseDescription = response.StatusDescription;
        //    fs.Close();
        //    stream.Close();


        //    return ResponseDescription;
        //}
        public string downloadFile(string FileNameToDownload, string tempDirPath)
        {
            string DownloadedFilePath = "";
            string ResponseDescription = "";
            string PureFileName = new FileInfo(FileNameToDownload).Name;


            DownloadedFilePath = tempDirPath;
            string downloadUrl = String.Format("{0}/{1}", "ftp://169.254.92.252/", FileNameToDownload);
            FtpWebRequest req = (FtpWebRequest)FtpWebRequest.Create(downloadUrl);
            req.Method = WebRequestMethods.Ftp.DownloadFile;
            req.Credentials = new NetworkCredential("nima", "H-0sein");
            req.UseBinary = true;
            req.Proxy = null;

            FtpWebResponse response = (FtpWebResponse)req.GetResponse();
            Stream stream = response.GetResponseStream();
            byte[] buffer = new byte[2048];
            FileStream fs = new FileStream(DownloadedFilePath, FileMode.Create);
            int ReadCount = stream.Read(buffer, 0, buffer.Length);
            while (ReadCount > 0)
            {
                fs.Write(buffer, 0, ReadCount);
                ReadCount = stream.Read(buffer, 0, buffer.Length);
            }
            ResponseDescription = response.StatusDescription;
            fs.Close();
            stream.Close();


            return ResponseDescription;
        }

        //private string DeleteFile(string fileName)
        //{
        //    FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://185.159.152.5/" + fileName);
        //    request.Method = WebRequestMethods.Ftp.DeleteFile;
        //    request.Credentials = new NetworkCredential("Nima", "P@hn1395");

        //    using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
        //    {
        //        return response.StatusDescription;
        //    }
        //}
        public string DeleteFile(string fileName)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://169.254.92.252/" + fileName);
            request.Method = WebRequestMethods.Ftp.DeleteFile;
            request.Credentials = new NetworkCredential("nima", "H-0sein");

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                return response.StatusDescription;
            }
        }

        //private string MoveFileToDeleted(string fileName)
        //{
        //    FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://185.159.152.5/" + fileName);
        //    request.Method = WebRequestMethods.Ftp.Rename;
        //    request.RenameTo = "Deleted/" + fileName;
        //    request.Credentials = new NetworkCredential("Nima", "P@hn1395");

        //    using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
        //    {
        //        return response.StatusDescription;
        //    }
        //}
        private string MoveFileToDeleted(string fileName)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://169.254.92.252/" + fileName);
            request.Method = WebRequestMethods.Ftp.Rename;
            request.RenameTo = "Deleted/" + fileName;
            request.Credentials = new NetworkCredential("nima", "H-0sein");

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                return response.StatusDescription;
            }
        }



        public string getExecutorName(long ncode)
        {
            string fullName, fname, lname;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = "SELECT t_FName , t_LName FROM TeacherTable WHERE t_NCode = '" + ncode + "'";
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();
            reader.Read();
            fname = reader.GetString(0);
            lname = reader.GetString(1);
            fullName = fname + " " + lname;
            conn.Close();
            return fullName;
        }

        public string getEmployerName(long code)
        {
            string employerName;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = "SELECT orgName FROM employersTable WHERE [index] = '" + code + "'";
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();
            reader.Read();
            employerName = reader.GetString(0);
            conn.Close();
            return employerName;
        }
        public string getRegistrantName(long ncode)
        {
            string fullName, fname, lname;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = "SELECT u_FName , u_LName FROM UsersTable WHERE t_NCode = '" + ncode + "'";
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();
            reader.Read();
            fname = reader.GetString(0);
            lname = reader.GetString(1);
            fullName = fname + " " + lname;
            conn.Close();
            return fullName;
        }

        public string getDateHijri(string date)
        {
  
            int len = date.IndexOf(" ");
            string GregorianDate = date.Substring(0, len);
           
            DateTime d = DateTime.Parse(GregorianDate);
            PersianCalendar pc = new PersianCalendar();
            return string.Format("{0}/{1:00}/{2:00}", pc.GetYear(d), pc.GetMonth(d), pc.GetDayOfMonth(d));//---> miladi to shamsi*/

        }

       
        public string getExecutorFaculty(long ncode)
        {
            string faculty;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = "SELECT t_Faculty FROM teacherTable WHERE t_NCode = '" + ncode + "'";
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();
            reader.Read();
            faculty = reader.GetString(0);
            conn.Close();
            return faculty;
        }

       
    }
}
