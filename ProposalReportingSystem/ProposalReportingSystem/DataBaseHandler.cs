using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProposalReportingSystem
{
    class DataBaseHandler
    {
        string conString = "Data Source= 185.159.152.2;" +
                "Initial Catalog=rayanpro_EBS;" +
                "User id=rayanpro_rayan; " +
                "Password=P@hn1395;";

        /// <summary>
        /// querry for proposals
        /// </summary>
        /// <param name="proposal"></param>

        public void AddProposal(Proposal proposal)
        {
            //String persianTitle, String engTitle , String keyword, long executor, String executor2 , String coExecutor, String startDate , int duration, String procedureType , String propertyType, String registerType , String proposalType, long employer, String value , String status, long registrant
            try
            {

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                SqlCommand sc = new SqlCommand();
                SqlDataReader reader;
                sc.CommandText = "INSERT INTO proposalTable ([index],persianTitle,engTitle,keyword,executor,executor2,coExecutor,startDate,duration,procedureType,propertyType,registerType,proposalType,employer,value,status,registrant)"
                                + "VALUES ('" + proposal.PersianTitle + "'"
                                         + "'" + proposal.EngTitle + "'"
                                         + "'" + proposal.KeyWord + "'"
                                         + "'" + proposal.Executor + "'"
                                         + "'" + proposal.Executor2 + "'"
                                         + "'" + proposal.CoExecutor + "'"
                                         + "'" + proposal.StartDate + "'"
                                         + "'" + proposal.Duration + "'"
                                         + "'" + proposal.ProcedureType + "'"
                                         + "'" + proposal.PropertyType + "'"
                                         + "'" + proposal.RegisterType + "'"
                                         + "'" + proposal.ProposalType + "'"
                                         + "'" + proposal.Employer + "'"
                                         + "'" + proposal.Value + "'"
                                         + "'" + proposal.Status + "'"
                                         + "'" + proposal.Registrant + "'";

                sc.CommandType = CommandType.Text;
                sc.Connection = conn;
                conn.Open();
                reader = sc.ExecuteReader();
                conn.Close();
            }
            catch
            {

            }
        }
        
        public void EditProposal (Proposal proposal)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = "UPDATE proposalTable SET persianTitle = " + "'" + proposal.PersianTitle + "'"
                                                    + "engTitle =" + "'" + proposal.EngTitle + "'"
                                                    + "keyword =" + "'" + proposal.KeyWord + "'"
                                                    + "executor =" + "'" + proposal.Executor + "'"
                                                    + "executor2 = " + "'" + proposal.Executor2 + "'"
                                                    + " coExecutor = " + "'" + proposal.CoExecutor + "'"
                                                    + "  startDate=" + "'" + proposal.StartDate + "'"
                                                    + "duration=" + "'" + proposal.Duration + "'"
                                                    + "procedureType =" + "'" + proposal.ProcedureType + "'"
                                                    + " propertyType = " + "'" + proposal.PropertyType + "'"
                                                    + "registerType =" + "'" + proposal.RegisterType + "'"
                                                    + "proposalType =" + "'" + proposal.ProposalType + "'"
                                                    + " employer = " + "'" + proposal.Employer + "'"
                                                    + " value = " + "'" + proposal.Value + "'"
                                                    + " status = " + "'" + proposal.Status + "'"
                                                    + "registrant=" + "'" + proposal.Registrant + "'"
                                                    + "WHERE index = " + proposal.Index + "";
                
                         
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();
            conn.Close();
        }
      
        public void DeleteProposal(long index)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = "DELETE FROM proposalTable WHERE index = " + index + "";
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();
            conn.Close();
        }

        ///////////end query for proposals

        /// <summary>
        /// querry for users
        /// </summary>
        /// <param name="Users"></param>


        public void AddUser(User user)
        {
            
            try
            {

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                SqlCommand sc = new SqlCommand();
                SqlDataReader reader;
                sc.CommandText = "INSERT INTO UsersTable (u_FName , u_LName , u_NCode , u_Password ,u_Email , u_Tel)"
                                + "VALUES ('" + user.U_FName + "'"
                                         + "'" + user.U_LName  + "'"
                                         + "'" + user.U_NCode+ "'"
                                         + "'" + user.U_Password + "'"
                                         + "'" + user.U_Email+ "'"
                                         + "'" + user.U_Tel + "'";

                sc.CommandType = CommandType.Text;
                sc.Connection = conn;
                conn.Open();
                reader = sc.ExecuteReader();
                conn.Close();
            }
            catch
            {

            }
        }
        public void EditUsers(User user,long currentNCode)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = "UPDATE UsersTable SET u_FName = " + "'" + user.U_FName + "'"
                                                    + "u_LName =" + "'" + user.U_LName + "'"
                                                    + "u_NCode =" + "'" + user.U_NCode + "'"
                                                    + "u_Password =" + "'" + user.U_Password + "'"
                                                    + "u_Email = " + "'" + user.U_Email + "'"
                                                    + " u_Tel = " + "'" + user.U_Tel + "'"
                                                    + " WHERE u_NCode = " + currentNCode + "";


            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();
            conn.Close();
        }

        public void DeleteUser(long NCode)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = "DELETE FROM UsersTable WHERE u_NCode = " + NCode + "";
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();
            conn.Close();
        }

        //////////////////end query Users


        /// <summary>
        /// querry for teachers
        /// </summary>
        /// <param name="Teachers"></param>
        public void AddTeacher(Teachers teacher)
        {

            try
            {

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                SqlCommand sc = new SqlCommand();
                SqlDataReader reader;
                sc.CommandText = "INSERT INTO TeacherTable (t_FName , t_LName , t_NCode , t_EDeg ,t_Email , t_Group , t_Mobile ,t_Tel1,t_Tel2,t_Faculty)"
                                + "VALUES ('" + teacher.T_FName + "'"
                                         + "'" +teacher.T_LName + "'"
                                         + "'" + teacher.T_NCode + "'"
                                         + "'" + teacher.T_EDeg + "'"
                                         + "'" + teacher.T_Email + "'"
                                         + "'" + teacher.T_Group + "'"
                                         + "'" + teacher.T_Mobile + "'"
                                         + "'" + teacher.T_Tel1+ "'"
                                         + "'" + teacher.T_Tel2 + "'"
                                         + "'" + teacher.T_Faculty + "'";

                sc.CommandType = CommandType.Text;
                sc.Connection = conn;
                conn.Open();
                reader = sc.ExecuteReader();
                conn.Close();
            }
            catch
            {

            }
        }
        public void EditTeacher(Teachers teacher)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = "UPDATE TeacherTable SET t_FName = " + "'" + teacher.T_FName + "'"
                                                    + "t_LName =" + "'" + teacher.T_LName + "'"
                                                    + "t_NCode =" + "'" + teacher.T_NCode + "'"
                                                    + "t_EDeg =" + "'" + teacher.T_EDeg + "'"
                                                    + "t_Email = " + "'" + teacher.T_Email + "'"
                                                    + " t_Group = " + "'" + teacher.T_Group + "'"
                                                    + "  t_Mobile=" + "'" + teacher.T_Mobile + "'"
                                                    + "t_Tel1=" + "'" + teacher.T_Tel1+ "'"
                                                    + "t_Tel2 =" + "'" + teacher.T_Tel2 + "'"
                                                    + " t_Faculty = " + "'" + teacher.T_Faculty + "'";


            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();
            conn.Close();
        }

        public void DeleteTeacher(long NCode)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = "DELETE FROM TeacherTable WHERE t_NCode = " + NCode + "";
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();
            conn.Close();
        }

        //////////////////end query Teachers



        /// <summary>
        /// querry for employers
        /// </summary>
        /// <param name="Emloyers"></param>
        public void AddEmployer(Employers employer)
        {

            try
            {

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                SqlCommand sc = new SqlCommand();
                SqlDataReader reader;
                sc.CommandText = "INSERT INTO employersTable (orgName , index)"
                                + "VALUES ('" + employer.OrgName + "'"
                                         + "'" + employer.Index + "'";

                sc.CommandType = CommandType.Text;
                sc.Connection = conn;
                conn.Open();
                reader = sc.ExecuteReader();
                conn.Close();
            }
            catch
            {

            }
        }
        public void UpdateEmployer(Employers employer)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = "UPDATE employersTable SET orgName = " + "'" + employer.OrgName + "' WHERE index = "+employer.Index+"";
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();
            conn.Close();
        }

        /// <summary>
        /// procedure query
        /// </summary>
        /// <param name="procedure"></param>
        public void AddProcedureType(String procedure)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = "INSERT INTO procedureTypeTable (procedureType) VALUES " + procedure + "";
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();
            conn.Close();
        }

        public void EditProcedureType(String newProcedureType , String lastProcedureType)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = "UPDATE procedureTypeTable SET procedureType = " + "'" + newProcedureType + "' WHERE procedureType = " + lastProcedureType + "";
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();
            conn.Close();
        }

        /////////////////end of procedure query


        /// <summary>
        /// property query
        /// </summary>
        /// <param name=property></param>
        public void AddPropertyType(String property)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = "INSERT INTO propertyTypeTable (propertyType) VALUES " + property + "";
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();
            conn.Close();
        }

        public void EditPropertyType(String newPropertyType, String lastPropertyType)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = "UPDATE propertyTypeTable SET propertyType = " + "'" + newPropertyType + "' WHERE propertyType = " + lastPropertyType + "";
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();
            conn.Close();
        }


        ///////////end query property

        /// <summary>
        /// proposalType query
        /// </summary>
        /// <param name=proposalType></param>
        public void AddProposalType(String proposalType)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = "INSERT INTO proposalTypeTable (proposaltyType) VALUES " + proposalType + "";
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();
            conn.Close();
        }

        public void EditProposalType(String newProposalType, String lastProposalType)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = "UPDATE proposalTypeTable SET proposalType = " + "'" + newProposalType + "' WHERE proposalType = " + lastProposalType + "";
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();
            conn.Close();
        }

        /////////////////end proposal type query

        /// <summary>
        /// registerType query
        /// </summary>
        /// <param name=proposalType></param>
        public void AddRegisterType(String registerType)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = "INSERT INTO registerTypeTable (registerType) VALUES " + registerType  + "";
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();
            conn.Close();
        }

        public void EditRegisterType(String newRegisterType, String lastRegisterType)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = "UPDATE registerTypeTable SET registerType = " + "'" + newRegisterType + "' WHERE registerType = " + lastRegisterType + "";
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();
            conn.Close();
        }

        //////////////end of registerType query


        /// <summary>
        /// statusType query
        /// </summary>
        /// <param name=statusType></param>
        public void AddStatusType(String statusType)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = "INSERT INTO statusTypeTable (statusType) VALUES " + statusType + "";
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();
            conn.Close();
        }

        public void EditStatusType(String newStatusType, String lastStatusType)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = "UPDATE statusTypeTable SET statusType = " + "'" + newStatusType + "' WHERE statusType = " + lastStatusType + "";
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();
            conn.Close();
        }

        ///////////end query of statusType

    }

}
