using DevComponents.DotNetBar.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProposalReportingSystem
{
    class DataBaseHandler
    {
        string conString = "Data Source= 185.159.152.2;" +
                "Initial Catalog=rayanpro_EBS;" +
                "User id=rayanpro_rayan; " +
                "Password=P@hn1395;";


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

        public void AddProposal(Proposal proposal, long username, String dateTime)
        {
            //String persianTitle, String engTitle , String keyword, long executor, String executor2 , String coExecutor, String startDate , int duration, String procedureType , String propertyType, String registerType , String proposalType, long employer, String value , String status, long registrant


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

                transaction.Commit();
                MessageBox.Show("افزودن با موفقیت به پابان رسید");
            }
            catch
            {
                MessageBox.Show("خطا در برقراری ارتباط");
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    MessageBox.Show("خطا در برقراری ارتباط");
                }
            }

            conn.Close();
        }

        public void EditProposal(Proposal proposal, long username, String dateTime)
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
                                                    + " status = " + "'" + proposal.Status + "',"
                                                    + "registrant=" + "'" + proposal.Registrant + "'"
                                                    + "WHERE index = " + proposal.Index + "";

                sc.ExecuteNonQuery();
                sc.CommandText = " INSERT INTO logTable (username , dateTime , description ,tableName) VALUES ('" + username + "','" + dateTime + "','" + "Edited ','" + "proposalTable'" + ")";
                sc.ExecuteNonQuery();

                transaction.Commit();
                MessageBox.Show("تغییرات با موفقیت به پابان رسید");
            }
            catch
            {
                MessageBox.Show("خطا در برقراری ارتباط");
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    MessageBox.Show("خطا در برقراری ارتباط");
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
                sc.CommandText = " DELETE FROM proposalTable WHERE index = '" + proposal.Index + "'";
                sc.ExecuteNonQuery();
                sc.CommandText = " INSERT INTO deletedProposalTable (index,persianTitle,engTitle,keyword,executor,executor2,coExecutor,startDate,duration,procedureType,propertyType,registerType,proposalType,employer,value,status,registrant,username,dateTime)"
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

                transaction.Commit();
                MessageBox.Show("حذف با موفقیت به پابان رسید");
            }
            catch
            {
                MessageBox.Show("خطا در برقراری ارتباط");
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    MessageBox.Show("خطا در برقراری ارتباط");
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
                sc.CommandText = "INSERT INTO UsersTable (u_FName , u_LName , u_NCode , u_Password ,u_Email , u_Tel , u_canAddProposal , u_canEditProposal , u_canDeleteProposal , u_canAddUser,u_canEditUser , u_canDeleteUser)"
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
                                      + "'" + user.CanDeleteUser + "')";

                sc.ExecuteNonQuery();
                sc.CommandText = " INSERT INTO logTable (username , dateTime , description ,tableName) VALUES ('" + username + "','" + dateTime + "','" + "Added " + user.U_NCode + "','" + "UsersTable'" + ")";
                sc.ExecuteNonQuery();

                transaction.Commit();
                MessageBox.Show("افزودن با موفقیت به پابان رسید");
            }
            catch
            {
                MessageBox.Show("خطا در برقراری ارتباط");
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    MessageBox.Show("خطا در برقراری ارتباط");
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
                                                    + " u_canDeleteUser = " + "'" + user.CanDeleteUser + "'"
                                                    + " WHERE u_NCode = " + NCode + "";

                sc.ExecuteNonQuery();
                sc.CommandText = " INSERT INTO logTable (username , dateTime , description ,tableName) VALUES ('" + username + "','" + dateTime + "','" + "Edited ','" + "UsersTable'" + ")";
                sc.ExecuteNonQuery();

                transaction.Commit();
                MessageBox.Show("تغییرات با موفقیت به پابان رسید");
            }
            catch
            {
                MessageBox.Show("خطا در برقراری ارتباط");
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    MessageBox.Show("خطا در برقراری ارتباط");
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
                sc.CommandText = "INSERT INTO deletedUsersTable (u_FName , u_LName , u_NCode , u_Password ,u_Email , u_Tel , u_canAddProposal , u_canEditProposal , u_canDeleteProposal , u_canAddUser,u_canEditUser , u_canDeleteUser , username ,date)"
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
                                     + "'" + username + "',"
                                     + "'" + dateTime + "')";
                sc.ExecuteNonQuery();
                sc.CommandText = " INSERT INTO logTable (username , dateTime , description ,tableName) VALUES ('" + username + "','" + dateTime + "','" + "deleted " + user.U_NCode + "','" + "UsersTable" + "')";
                sc.ExecuteNonQuery();

                transaction.Commit();
                MessageBox.Show("حذف با موفقیت به پابان رسید");
            }
            catch
            {
                MessageBox.Show("خطا در برقراری ارتباط");
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    MessageBox.Show("خطا در برقراری ارتباط");
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
                MessageBox.Show("افزودن با موفقیت به پابان رسید");
            }
            catch
            {
                MessageBox.Show("خطا در برقراری ارتباط");
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    MessageBox.Show("خطا در برقراری ارتباط");
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
                sc.CommandText = " INSERT INTO logTable (username , dateTime , description ,tableName) VALUES ('" + username + "','" + dateTime + "','" + "Edited ','" + "TeacherTable'" + ")";
                sc.ExecuteNonQuery();

                transaction.Commit();
                MessageBox.Show("تغییرات با موفقیت به پابان رسید");
            }
            catch
            {
                MessageBox.Show("خطا در برقراری ارتباط");
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    MessageBox.Show("خطا در برقراری ارتباط");
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
                MessageBox.Show("حذف با موفقیت به پابان رسید");
            }
            catch
            {
                MessageBox.Show("خطا در برقراری ارتباط");
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    MessageBox.Show("خطا در برقراری ارتباط");
                }
            }

            conn.Close();
        }



        //////////////////end query Teachers



        /// <summary>
        /// querry for employers
        /// </summary>
        /// <param name="Emloyers"></param>
        public void AddEmployer(string employer, long username, String dateTime)
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
                MessageBox.Show("افزودن با موفقیت به پابان رسید");
            }
            catch
            {
                MessageBox.Show("خطا در برقراری ارتباط");
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    MessageBox.Show("خطا در برقراری ارتباط");
                }
            }

            conn.Close();


        }
        public void EditEmployer(Employers employer, string lastOrgName, long username, String dateTime)
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
                MessageBox.Show("تغییرات با موفقیت به پابان رسید");
            }
            catch
            {
                MessageBox.Show("خطا در برقراری ارتباط");
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    MessageBox.Show("خطا در برقراری ارتباط");
                }
            }

            conn.Close();

        }
        public List<Employers> getEmployers()
        {
            List<Employers> list = new List<Employers>();
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
            return list;
        }
        public void DeleteEmployers(long index, String employers, long username, String dateTime)
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
                MessageBox.Show("حذف با موفقیت به پابان رسید");
            }
            catch
            {
                MessageBox.Show("خطا در برقراری ارتباط");
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    MessageBox.Show("خطا در برقراری ارتباط");
                }
            }

            conn.Close();

        }

        ////////////////////end of employer query
        /// <summary>
        /// procedure query
        /// </summary>
        /// <param name="procedure"></param>
        public void AddProcedureType(String procedure, long username, String dateTime)
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
                MessageBox.Show("افزودن با موفقیت به پابان رسید");
            }
            catch
            {
                MessageBox.Show("خطا در برقراری ارتباط");
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    MessageBox.Show("خطا در برقراری ارتباط");
                }
            }

            conn.Close();

        }

        public void EditProcedureType(String newProcedureType, String lastProcedureType, long username, String dateTime)
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
                MessageBox.Show("تغییرات با موفقیت به پابان رسید");
            }
            catch
            {
                MessageBox.Show("خطا در برقراری ارتباط");
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    MessageBox.Show("خطا در برقراری ارتباط");
                }
            }

            conn.Close();

        }


        public List<string> getProcedureType()
        {
            List<string> list = new List<string>();
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

            return list;
        }

        public void DeleteProcedureType(String procedure, long username, String dateTime)
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
                MessageBox.Show("حذف با موفقیت به پابان رسید");
            }
            catch
            {
                MessageBox.Show("خطا در برقراری ارتباط");
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    MessageBox.Show("خطا در برقراری ارتباط");
                }
            }

            conn.Close();

        }

        /////////////////end of procedure query


        /// <summary>
        /// property query
        /// </summary>
        /// <param name=property></param>
        public void AddPropertyType(String property, long username, String dateTime)
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
                MessageBox.Show("افزودن با موفقیت به پابان رسید");
            }
            catch
            {
                MessageBox.Show("خطا در برقراری ارتباط");
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    MessageBox.Show("خطا در برقراری ارتباط");
                }
            }

            conn.Close();

        }

        public void EditPropertyType(String newPropertyType, String lastPropertyType, long username, String dateTime)
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
                MessageBox.Show("تغییرات با موفقیت به پابان رسید");
            }
            catch
            {
                MessageBox.Show("خطا در برقراری ارتباط");
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    MessageBox.Show("خطا در برقراری ارتباط");
                }
            }

            conn.Close();

        }
        public List<string> getPropertyType()
        {
            List<string> list = new List<string>();
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

            return list;
        }

        public void DeletePropertyType(String property, long username, String dateTime)
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
                MessageBox.Show("حذف با موفقیت به پابان رسید");
            }
            catch
            {
                MessageBox.Show("خطا در برقراری ارتباط");
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    MessageBox.Show("خطا در برقراری ارتباط");
                }
            }

            conn.Close();

        }


        ///////////end query property

        /// <summary>
        /// proposalType query
        /// </summary>
        /// <param name=proposalType></param>
        public void AddProposalType(String proposalType, long username, String dateTime)
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
                MessageBox.Show("افزودن با موفقیت به پابان رسید");
            }
            catch
            {
                MessageBox.Show("خطا در برقراری ارتباط");
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    MessageBox.Show("خطا در برقراری ارتباط");
                }
            }

            conn.Close();

        }

        public void EditProposalType(String newProposalType, String lastProposalType, long username, String dateTime)
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
                MessageBox.Show("تغییرات با موفقیت به پابان رسید");
            }
            catch
            {
                MessageBox.Show("خطا در برقراری ارتباط");
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    MessageBox.Show("خطا در برقراری ارتباط");
                }
            }

            conn.Close();

        }
        public List<string> getProposalType()
        {
            List<string> list = new List<string>();
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

            return list;
        }
        public void DeleteProposalType(String proposal, long username, String dateTime)
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
                MessageBox.Show("حذف با موفقیت به پابان رسید");
            }
            catch
            {
                MessageBox.Show("خطا در برقراری ارتباط");
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    MessageBox.Show("خطا در برقراری ارتباط");
                }
            }

            conn.Close();

        }

        /////////////////end proposal type query

        /// <summary>
        /// registerType query
        /// </summary>
        /// <param name=proposalType></param>
        public void AddRegisterType(String registerType, long username, String dateTime)
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
                MessageBox.Show("افزودن با موفقیت به پابان رسید");
            }
            catch
            {
                MessageBox.Show("خطا در برقراری ارتباط");
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    MessageBox.Show("خطا در برقراری ارتباط");
                }
            }

            conn.Close();

        }

        public void EditRegisterType(String newRegisterType, String lastRegisterType, long username, String dateTime)
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
                MessageBox.Show("تغییرات با موفقیت به پابان رسید");
            }
            catch
            {
                MessageBox.Show("خطا در برقراری ارتباط");
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    MessageBox.Show("خطا در برقراری ارتباط");
                }
            }

            conn.Close();

        }
        public List<string> getRegisterType()
        {
            List<string> list = new List<string>();
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

            return list;
        }

        public void DeleteRegisterType(String register, long username, String dateTime)
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
                MessageBox.Show("حذف با موفقیت به پابان رسید");
            }
            catch
            {
                MessageBox.Show("خطا در برقراری ارتباط");
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    MessageBox.Show("خطا در برقراری ارتباط");
                }
            }

            conn.Close();

        }

        //////////////end of registerType query


        /// <summary>
        /// statusType query
        /// </summary>
        /// <param name=statusType></param>
        public void AddStatusType(String statusType, long username, String dateTime)
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
                MessageBox.Show("افزودن با موفقیت به پابان رسید");
            }
            catch
            {
                MessageBox.Show("خطا در برقراری ارتباط");
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    MessageBox.Show("خطا در برقراری ارتباط");
                }
            }

            conn.Close();
        }

        public void EditStatusType(String newStatusType, String lastStatusType, long username, String dateTime)
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
                MessageBox.Show("تغییرات با موفقیت به پابان رسید");
            }
            catch
            {
                MessageBox.Show("خطا در برقراری ارتباط");
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    MessageBox.Show("خطا در برقراری ارتباط");
                }
            }

            conn.Close();




        }
        public List<string> getStatusType()
        {
            List<string> list = new List<string>();
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

            return list;
        }

        public void DeleteStatusType(String status, long username, String dateTime)
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
                MessageBox.Show("حذف با موفقیت به پابان رسید");
            }
            catch
            {
                MessageBox.Show("خطا در برقراری ارتباط");
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    MessageBox.Show("خطا در برقراری ارتباط");
                }
            }

            conn.Close();
        }

        ///////////end query of statusType

        /// <summary>
        /// statusType query
        /// </summary>
        /// <param name=Faculty></param>
        public void AddFaculty(String faculty, long username, String dateTime)
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
                MessageBox.Show("افزودن با موفقیت به پابان رسید");
            }
            catch
            {
                MessageBox.Show("خطا در برقراری ارتباط");
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    MessageBox.Show("خطا در برقراری ارتباط");
                }
            }

            conn.Close();

        }

        public void EditFaculty(String newFaculty, String lastFaculty, long username, String dateTime)
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
                MessageBox.Show("تغییرات با موفقیت به پابان رسید");
            }
            catch
            {
                MessageBox.Show("خطا در برقراری ارتباط");
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    MessageBox.Show("خطا در برقراری ارتباط");
                }
            }

            conn.Close();
        }
        public List<string> getFaculty()
        {
            List<string> list = new List<string>();
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

            return list;
        }

        public void DeleteFaculty(String faculty, long username, String dateTime)
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
                MessageBox.Show("حذف با موفقیت به پابان رسید");
            }
            catch
            {
                MessageBox.Show("خطا در برقراری ارتباط");
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    MessageBox.Show("خطا در برقراری ارتباط");
                }
            }

            conn.Close();



        }

        ///////////end query of FacultyTable


        /// <summary>
        /// statusType query
        /// </summary>
        /// <param name=Faculty></param>
        public void AddEGroup(String faculty, String group, long username, String dateTime)
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
                MessageBox.Show("افزودن با موفقیت به پابان رسید");
            }
            catch
            {
                MessageBox.Show("خطا در برقراری ارتباط");
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    MessageBox.Show("خطا در برقراری ارتباط");
                }
            }

            conn.Close();
        }

        public void EditEGroup(String newEGroup, String lastEGroup, long username, String dateTime)
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
                MessageBox.Show("تغییرات با موفقیت به پابان رسید");
            }
            catch
            {
                MessageBox.Show("خطا در برقراری ارتباط");
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    MessageBox.Show("خطا در برقراری ارتباط");
                }
            }

            conn.Close();
        }

        public List<string> getEGroup(string faculty)
        {
            List<string> list = new List<string>();
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
            return list;

        }

        public void DeleteEGroup(String groupName, String facultyName, long username, String dateTime)
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
                MessageBox.Show("حذف با موفقیت به پابان رسید");
            }
            catch
            {
                MessageBox.Show("خطا در برقراری ارتباط");
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    MessageBox.Show("خطا در برقراری ارتباط");
                }
            }

            conn.Close();


        }

        ///////////end query of EducationalGroup



        public List<string> getEDeg()
        {
            List<string> list = new List<string>();
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
            return list;

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
                dataGridview.Columns[0].HeaderText = "کد ملی";
                dataGridview.Columns[1].HeaderText = "رمز عبور";
                dataGridview.Columns[2].HeaderText = "نام";
                dataGridview.Columns[3].HeaderText = "نام خانوادگی";
                dataGridview.Columns[4].HeaderText = "ایمیل";
                dataGridview.Columns[5].HeaderText = "تلفن تماس";
                dataGridview.Columns[6].HeaderText = "افزودن پروپوزال";
                dataGridview.Columns[7].HeaderText = "تغییر اطلاعات پروپوزال";
                dataGridview.Columns[8].HeaderText = "حذف پروپوزال";
                dataGridview.Columns[9].HeaderText = "افزودن کاربر";
                dataGridview.Columns[10].HeaderText = "تغییر اطلاعات کاربر";
                dataGridview.Columns[11].HeaderText = "حذف کاربر";
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
        ////////////////////////////////////////////////////////////////////////////
        /***********************************GridView Update***********************/
        ///////////////////////////////////////////////////////////////////////////
    }


}
