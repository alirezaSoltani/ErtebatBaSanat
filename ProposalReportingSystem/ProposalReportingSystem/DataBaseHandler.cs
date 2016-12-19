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

        public void AddProposal(Proposal proposal)
        {
            //String persianTitle, String engTitle , String keyword, long executor, String executor2 , String coExecutor, String startDate , int duration, String procedureType , String propertyType, String registerType , String proposalType, long employer, String value , String status, long registrant
          

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                SqlCommand sc = new SqlCommand();
                SqlDataReader reader;
                sc.CommandText = "INSERT INTO proposalTable (index,persianTitle,engTitle,keyword,executor,executor2,coExecutor,startDate,duration,procedureType,propertyType,registerType,proposalType,employer,value,status,registrant,deleted)"
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
                                         + "'" + proposal.Registrant + "'"
                                         + "'" + 0 + "')"; // 0 for deleted 

                sc.CommandType = CommandType.Text;
                sc.Connection = conn;
                conn.Open();
                reader = sc.ExecuteReader();
                conn.Close();
          
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
            sc.CommandText = "UPDATE proposalTable SET deleted = " + "'" + 1 + "'"
                           + "WHERE index = " + index + "";
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
            
           
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                SqlCommand sc = new SqlCommand();
                SqlDataReader reader;
                sc.CommandText = "INSERT INTO UsersTable (u_FName , u_LName , u_NCode , u_Password ,u_Email , u_Tel , deleted)"
                                + "VALUES ('" + user.U_FName + "'"
                                         + "'" + user.U_LName  + "'"
                                         + "'" + user.U_NCode+ "'"
                                         + "'" + user.U_Password + "'"
                                         + "'" + user.U_Email+ "'"
                                         + "'" + user.U_Tel + "'"
                                         +"'" + 0 + "')";

                sc.CommandType = CommandType.Text;
                sc.Connection = conn;
                conn.Open();
                reader = sc.ExecuteReader();
                conn.Close();
           
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
            sc.CommandText = "UPDATE UsersTable SET deleted = " + "'" + 1 + "'" + " WHERE u_NCode = " + NCode + "";
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

           

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                SqlCommand sc = new SqlCommand();
                SqlDataReader reader;
                sc.CommandText = "INSERT INTO TeacherTable (t_FName , t_LName , t_NCode , t_EDeg ,t_Email , t_Group , t_Mobile ,t_Tel1,t_Tel2,t_Faculty , deleted)"
                                + "VALUES ('" + teacher.T_FName + "'"
                                         + "'" +teacher.T_LName + "'"
                                         + "'" + teacher.T_NCode + "'"
                                         + "'" + teacher.T_EDeg + "'"
                                         + "'" + teacher.T_Email + "'"
                                         + "'" + teacher.T_Group + "'"
                                         + "'" + teacher.T_Mobile + "'"
                                         + "'" + teacher.T_Tel1+ "'"
                                         + "'" + teacher.T_Tel2 + "'"
                                         + "'" + teacher.T_Faculty + "'"
                                         +"'" + 0 + "')";

                sc.CommandType = CommandType.Text;
                sc.Connection = conn;
                conn.Open();
                reader = sc.ExecuteReader();
                conn.Close();
           
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
            sc.CommandText = "UPDATE TeacherTable SET deleted = " + "'" + 1 + "'" +" WHERE t_NCode = " + NCode + "";
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

           

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conString;
                SqlCommand sc = new SqlCommand();
                SqlDataReader reader;
                sc.CommandText = "INSERT INTO employersTable (orgName , index, deleted)"
                                + "VALUES ('" + employer.OrgName + "'"
                                         + "'" + employer.Index + "'"
                                         +"'" + 0 + "')";

                sc.CommandType = CommandType.Text;
                sc.Connection = conn;
                conn.Open();
                reader = sc.ExecuteReader();
                conn.Close();
          
            
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
        public List<Employers> getEmployers()
        {
            Employers employer = new Employers();
            List<Employers> list = new List<Employers>();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = "SELECT * FROM employersTable WHERE deleted = 0";
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();
            while (reader.Read())
            {
                
                employer.Index = ((long)reader["index"]);
                employer.OrgName = ((string)reader["orgName"]);

            }
            conn.Close();

            return list;
        }
        public void DeleteEmployers(long index)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = "UPDATE employersTable SET deleted = " + "'" + 1 + "'" + " WHERE index = " + index + "";
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();
            conn.Close();
        }

        ////////////////////end of employer querry
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
            sc.CommandText = "INSERT INTO procedureTypeTable (procedureType,deleted) VALUES ('" + procedure + "', 0 )";
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
        public List<string> getProcedureType()
        {
            List<string> list = new List<string>();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = "SELECT * FROM procedureTypeTable WHERE deleted = 0";
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

        public void DeleteProcedureType(String procedure)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = "UPDATE procedureTypeTable SET deleted = " + "'" + 1 + "'" + " WHERE procedureType = '" + procedure + "'";
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
            sc.CommandText = "INSERT INTO propertyTypeTable (propertyType , deleted) VALUES ('" + property + "', 0)";
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
            sc.CommandText = "UPDATE propertyTypeTable SET propertyType = " + "'" + newPropertyType + "' WHERE propertyType = '" + lastPropertyType + "'";
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();
            conn.Close();
        }
        public List<string> getPropertyType()
        {
            List<string> list = new List<string>();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = "SELECT * FROM propertyTypeTable WHERE deleted = 0";
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

        public void DeletePropertyeType(String property)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = "UPDATE propertyTypeTable SET deleted = " + "'" + 1 + "'" + " WHERE propertyType = '" + property + "'";
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
            sc.CommandText = "INSERT INTO proposalTypeTable (proposaltyType , deleted) VALUES ('" + proposalType + "' , 0)";
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
            sc.CommandText = "UPDATE proposalTypeTable SET proposalType = " + "'" + newProposalType + "' WHERE proposalType = '" + lastProposalType + "'";
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();
            conn.Close();
        }
        public List<string> getProposalType()
        {
            List<string> list = new List<string>();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = "SELECT * FROM proposalTypeTable WHERE deleted = 0";
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
        public void DeleteProposalType(String proposal)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = "UPDATE proposalTypeTable SET deleted = " + "'" + 1 + "'" + " WHERE proposalType = '" + proposal + "'";
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
            sc.CommandText = "INSERT INTO registerTypeTable (registerType , deleted) VALUES ('" + registerType  + "' , 0 )";
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
            sc.CommandText = "UPDATE registerTypeTable SET registerType = " + "'" + newRegisterType + "' WHERE registerType = '" + lastRegisterType + "'";
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();
            conn.Close();
        }
        public List<string> getRegisterType()
        {
            List<string> list = new List<string>();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = "SELECT * FROM registerTypeTable WHERE deleted = 0";
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

        public void DeleteRegisterType(String register)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = "UPDATE registerTypeTable SET deleted = " + "'" + 1 + "'" + " WHERE registerType = '" + register + "'";
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
            sc.CommandText = "INSERT INTO statusTypeTable (statusType , deleted) VALUES( '" + statusType + "' , 0)";
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
            sc.CommandText = "UPDATE statusTypeTable SET statusType = " + "'" + newStatusType + "' WHERE statusType = '" + lastStatusType + "'";
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();
            conn.Close();
        }
        public List<string> getStatusType()
        {
            List<string> list = new List<string>();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = "SELECT * FROM statusTypeTable WHERE deleted = 0";
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();
            while (reader.Read())
            {
               list.Add( reader.GetString(0));

            }
            conn.Close();

            return list;
        }

        public void DeleteStatusType(String status)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;
            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = "UPDATE statusTypeTable SET deleted = " + "'" + 1 + "'" + " WHERE statusType = '" + status + "'";
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();
            conn.Close();
        }

        ///////////end query of statusType




        ////////////////////////////////////////////////////////////////////////////
        /***********************************GET DATA******************************/
        ///////////////////////////////////////////////////////////////////////////
        private void GetData(string selectCommand, BindingSource bindingSourceObj, DataGridViewX dataGridview)
        {
            try
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

            }
            catch (SqlException)
            {
                //DialogForm dialog = new DialogForm("مشکل در ارتباط با سرور یا پایگاه داده", "خطا", "error", this);
                //show some error
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
            try
            {
                /// <summary>
                /// datagridview reintialization
                /// </summary>
                dgv.DataSource = bindingSource;
                GetData(query, bindingSource, dgv);

                /*//***change mode of columns to Fill
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.RowHeadersWidth = (width / 25);
                dataGridView1.Columns[0].HeaderText = "شماره استاد";
                dataGridView1.Columns[1].HeaderText = "نام استاد";
                dataGridView1.Columns[2].HeaderText = "نام خانوادگی استاد";
                dataGridView1.Columns[3].HeaderText = "رمز عبور";
                dataGridView1.Columns[4].HeaderText = "آدرس اینترنتی";
                dataGridView1.Columns[4].Width = (width / 5);

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value.ToString() == "-1")
                    {
                        dataGridView1.Rows.Remove(row);
                    }
                }

                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    dataGridView1.Rows[row.Index].HeaderCell.Value = (row.Index + 1).ToString();
                }
                /// <summary>
                /// datagridview reintialization
                /// </summary>*/
            }
            catch (ArgumentOutOfRangeException)
            {
                //DialogForm dialog = new DialogForm("اشکال در ارتباط با پایگاه داده", "خطا", "error", this);
                //show some error
            }
        }


        ////////////////////////////////////////////////////////////////////////////
        /***********************************GridView Update***********************/
        ///////////////////////////////////////////////////////////////////////////
    }


}
