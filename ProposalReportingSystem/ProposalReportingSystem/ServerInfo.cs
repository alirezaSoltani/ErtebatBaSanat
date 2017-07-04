using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProposalReportingSystem
{
    public partial class ServerInfo : Form
    {
        private User user = new User();

        public ServerInfo()
        {
            InitializeComponent();

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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serverTxtbx.Clear();
            databaseTxtbx.Clear();
            usernameTxtbx.Clear();
            passwordTxtbx.Clear();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            string connectionString = string.Format("Data Source={0}; Initial Catalog={1}; User Id={2}; Password={3}", serverTxtbx.Text, databaseTxtbx.Text, usernameTxtbx.Text, passwordTxtbx.Text);
            try
            {
                SqlHelper helper = new SqlHelper(connectionString);
                if(helper.isConnected)
                {
                    MessageBox.Show("connetion is established", "Connected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void changeBtn_Click(object sender, EventArgs e)
        {
            string connectionString = string.Format("Data Source={0}; Initial Catalog={1}; User Id={2}; Password={3};", serverTxtbx.Text, databaseTxtbx.Text, usernameTxtbx.Text, passwordTxtbx.Text);
            try
            {
                SqlHelper helper = new SqlHelper(connectionString);
                if (helper.isConnected)
                {
                    AppSetting setting = new AppSetting();
                    MessageBox.Show("Your Connection String before change:\n" + setting.getConnectionString("cn"));
                    setting.setConnectionString("cn", connectionString);
                    MessageBox.Show("Your Connection String has changed successfully:\n" + setting.getConnectionString("cn"), "Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            Form1 mainform = new Form1(user);
            this.Hide();
            mainform.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AppSetting setting = new AppSetting();

            string ftpuri = ftpUriTxtbx.Text;
            MessageBox.Show("Your FTP URI before change:\n" + setting.getConnectionString("ftpuri"));
            setting.setConnectionString("ftpuri", ftpuri);
            MessageBox.Show("Your FTP URI has changed successfully:\n" + setting.getConnectionString("ftpuri"), "Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);

            string ftpusername = ftpUsernameTxtbx.Text;
            MessageBox.Show("Your FTP Username before change:\n" + setting.getConnectionString("ftpusername"));
            setting.setConnectionString("ftpusername", ftpusername);
            MessageBox.Show("Your FTP Username has changed successfully:\n" + setting.getConnectionString("ftpusername"), "Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);

            string ftppassword = ftpPasswordTxtbx.Text;
            MessageBox.Show("Your FTP Password before change:\n" + setting.getConnectionString("ftppassword"));
            setting.setConnectionString("ftppassword", ftppassword);
            MessageBox.Show("Your FTP Password has changed successfully:\n" + setting.getConnectionString("ftppassword"), "Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ServerInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
