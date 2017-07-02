using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProposalReportingSystem
{
    public partial class Login : Form
    {
        private string username, password;
        // private DataBaseHandler dbh = new DataBaseHandler(0);
        private string[] remembering = new string[2];
        private User user = new User();

        public Login()
        {
            InitializeComponent();
            this.Show();
            //this.TopMost = true;
        }

        private void loginEnterBtn_MouseEnter(object sender, EventArgs e)
        {
            loginEnterBtn.BackColor = Color.Gray;
        }

        private void loginClosePbx_MouseEnter(object sender, EventArgs e)
        {
            loginClosePbx.BackgroundImage = ProposalReportingSystem.Properties.Resources.login_close_white;
            loginClosePbx.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void loginClosePbx_MouseLeave(object sender, EventArgs e)
        {
            loginClosePbx.BackgroundImage = ProposalReportingSystem.Properties.Resources.login_close_black; ;
            loginClosePbx.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void loginMinimizePbx_MouseEnter(object sender, EventArgs e)
        {
            loginMinimizePbx.BackgroundImage = ProposalReportingSystem.Properties.Resources.login_minimize_white;
            loginMinimizePbx.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void loginMinimizePbx_MouseLeave(object sender, EventArgs e)
        {
            loginMinimizePbx.BackgroundImage = ProposalReportingSystem.Properties.Resources.login_minimize_black;
            loginMinimizePbx.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void loginClosePbx_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginMinimizePbx_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void loginUsernameTxtBx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                loginEnterBtn.PerformClick();
            }
            else
            {
                e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
            }
        }

        private void loginShowPasswordChb_MouseDown(object sender, MouseEventArgs e)
        {
            loginShowPasswordChb.Checked = true;
            loginPasswordTxtbx.PasswordChar = '\0';
        }

        private void loginShowPasswordChb_MouseUp(object sender, MouseEventArgs e)
        {
            loginShowPasswordChb.Checked = false;
            loginPasswordTxtbx.PasswordChar = '●';
        }

        private void Login_Load(object sender, EventArgs e)
        {
            remembering = File.ReadAllLines("loginInformation");
            if (remembering[0] == "yes")
            {
                loginRememberUsername.Checked = true;
                loginUsernameTxtBx.Text = remembering[1];
                loginPasswordTxtbx.TabIndex = 0;
                loginPasswordTxtbx.Focus();
            }
        }

        private void loginUsernameTxtBx_Click(object sender, EventArgs e)
        {
            loginPasswordTxtbx.TabIndex = 2;
        }

        private void loginPasswordTxtbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                loginEnterBtn.PerformClick();
            }
        }

        private void loginRememberUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                loginEnterBtn.PerformClick();
            }
        }

        private void loginUsernameTxtBx_MouseDown(object sender, MouseEventArgs e)
        {
            loginPasswordTxtbx.TabIndex = 2;
        }

        private void loginPasswordTxtbx_Enter(object sender, EventArgs e)
        {
            /*loginPasswordTxtbx.Text = "1";
            loginEnterBtn.PerformClick();*/
        }

        private void loginEnterBtn_Click(object sender, EventArgs e)
        {
            try
            {
               
                SqlConnection conn2 = new SqlConnection();
            
                SqlCommand sc2 = new SqlCommand();
                //conn2.ConnectionString = "Data Source= 185.159.152.2;" +
                //"Initial Catalog=rayanpro_EBS;" +
                //"User id=rayanpro_rayan; " +
                //"Password=P@hn1395;";
                conn2.ConnectionString = "Data Source= 169.254.92.252;" +
                "Initial Catalog=rayanpro_EBS;" +
                "User id=test; " +
                "Password=HoseinNima1234;";
                
                sc2.Connection = conn2;
              
                conn2.Open();

                try
                {
                    if (loginUsernameTxtBx.Text == "" || loginPasswordTxtbx.Text == "")
                    {
                        string context = "نام کاربری یا رمز عبور وارد نشده است";
                        Alert alert = new Alert(context, "darkred", 5);
                    }
                    else if (loginUsernameTxtBx.Text == "98765" && loginPasswordTxtbx.Text == "1")
                    {
                        username = loginUsernameTxtBx.Text;
                        password = loginPasswordTxtbx.Text;

                        // REMEMBERING PASSWORD
                        if (loginRememberUsername.Checked)
                        {
                            remembering[0] = "yes";
                            remembering[1] = username;
                            File.WriteAllLines("loginInformation", remembering);
                        }
                        else
                        {
                            remembering[0] = "no";
                            remembering[1] = "-";
                            File.WriteAllLines("loginInformation", remembering);
                        }
                        // REMEMBERING PASSWORD

                        user.U_FName = "admin";
                        user.U_LName = "admin";
                        user.U_NCode = 98765;
                        user.U_Password = "1";

                        user.CanAddProposal = 1;
                        user.CanEditProposal = 1;
                        user.CanDeleteProposal = 1;
                        user.CanAddUser = 1;
                        user.CanEditUser = 1;
                        user.CanDeleteUser = 1;
                        user.CanManageTeacher = 1;
                        user.CanManageType = 1;
                        user.U_Color = "#D3EFFC";

                        Form1 mainForm = new Form1(user);
                        this.Hide();
                        mainForm.Show();
                    }

                    else
                    {
                        username = loginUsernameTxtBx.Text;
                        password = loginPasswordTxtbx.Text;

                        SqlConnection conn = new SqlConnection();
                        //conn.ConnectionString = "Data Source= 185.159.152.2;" +
                        //"Initial Catalog=rayanpro_EBS;" +
                        //"User id=rayanpro_rayan; " +
                        //"Password=P@hn1395;";
                        conn.ConnectionString = "Data Source= 169.254.92.252;" +
                        "Initial Catalog=rayanpro_EBS;" +
                        "User id=test; " +
                        "Password=HoseinNima1234;";

                        SqlCommand sc = new SqlCommand();
                        sc.CommandTimeout = 5;
                        SqlDataReader reader;
                        sc.CommandText = "SELECT * FROM UsersTable WHERE u_NCode = '" + long.Parse(username) + "' AND u_Password = '" + password + "'";
                        sc.CommandType = CommandType.Text;
                        sc.Connection = conn;
                        conn.Open();
                        reader = sc.ExecuteReader();
                        if (reader.HasRows)
                        {
                            // REMEMBERING PASSWORD
                            if (loginRememberUsername.Checked)
                            {
                                remembering[0] = "yes";
                                remembering[1] = username;
                                File.WriteAllLines("loginInformation", remembering);
                            }
                            else
                            {
                                remembering[0] = "no";
                                remembering[1] = "-";
                                File.WriteAllLines("loginInformation", remembering);
                            }
                            // REMEMBERING PASSWORD

                            reader.Read();

                            user.U_FName = reader["u_FName"].ToString();
                            user.U_LName = reader["u_LName"].ToString();
                            user.U_NCode = long.Parse(reader["u_NCode"].ToString());
                            user.U_Password = reader["u_Password"].ToString();
                            user.U_Email = reader["u_Email"].ToString();
                            user.U_Tel = reader["u_Tel"].ToString();

                            if (reader["u_canAddProposal"].ToString() == "True")
                                user.CanAddProposal = 1;
                            else
                                user.CanAddProposal = 0;

                            if (reader["u_canEditProposal"].ToString() == "True")
                                user.CanEditProposal = 1;
                            else
                                user.CanEditProposal = 0;

                            if (reader["u_canDeleteProposal"].ToString() == "True")
                                user.CanDeleteProposal = 1;
                            else
                                user.CanDeleteProposal = 0;

                            if (reader["u_canAddUser"].ToString() == "True")
                                user.CanAddUser = 1;
                            else
                                user.CanAddUser = 0;

                            if (reader["u_canEditUser"].ToString() == "True")
                                user.CanEditUser = 1;
                            else
                                user.CanEditUser = 0;

                            if (reader["u_canDeleteUser"].ToString() == "True")
                                user.CanDeleteUser = 1;
                            else
                                user.CanDeleteUser = 0;

                            if (reader["u_canManageTeacher"].ToString() == "True")
                                user.CanManageTeacher = 1;
                            else
                                user.CanManageTeacher = 0;

                            if (reader["u_canManageType"].ToString() == "True")
                                user.CanManageType = 1;
                            else
                                user.CanManageType = 0;

                            user.U_Color = reader["u_Color"].ToString();

                            this.Hide();
                            Form1 mainForm = new Form1(user);
                            mainForm.Show();
                        }
                        else
                        {
                            //PopUp popUp = new PopUp("خطا", "نام کاربری یا رمز عبور اشتباه است.", "تایید", "", "", "error");
                            //popUp.ShowDialog();
                            string context = "نام کاربری یا رمز عبور اشتباه است.";
                            Alert alert = new Alert(context, "darkred", 5);
                        }
                        conn.Close();
                    }
                }
                catch (SqlException)
                {
                    PopUp popUp = new PopUp("خطا", "خطا در برقراری ارتباط با سرور", "تایید", "", "", "error");
                    popUp.ShowDialog();
                }
            }
            catch
            {
                string context = "خطا در برقراری ارتباط با سرور";
                Alert alert = new Alert(context, "darkred", 5);
            }
            }
        }
    }
