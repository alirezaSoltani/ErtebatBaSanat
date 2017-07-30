using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastReport;
using FastReport.Data;

namespace ProposalReportingSystem
{
    public partial class reportForm : Form
    {
        User user = new User();
        DataBaseHandler dbh;
        string query;

        public reportForm(String queryy)
        {
            InitializeComponent();
            query = queryy;
            
        }

        private void detailPrintBtn_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn col in reportDataGridView.Columns)
            {

                dt.Columns.Add(col.Name);
            }

            foreach (DataGridViewRow row in reportDataGridView.Rows)
            {
                DataRow dRow = dt.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex == 14)
                    {
                        string temp = string.Format("{0:n0}", double.Parse(cell.Value.ToString()));
                        temp = temp.Replace(',', '/');
                        dRow[cell.ColumnIndex] = temp;
                    }
                    else
                        dRow[cell.ColumnIndex] = cell.Value;
                }
                dt.Rows.Add(dRow);
            }

            //DataTable dt = (DataTable)(searchProposalShowDgv.DataSource);

            Report report = new Report();
            report.Load("report1.frx");
            report.SetParameterValue("r_header", "پیشنهاد پروژه های ارسالی به سازمان ها و دستگاه های اجرایی در سال  پیشنهاد پروژه های ارسالی به سازمان ها و دستگاه های اجرایی در سال  پیشنهاد و دستگاه های اجرایی در سال 96");
            //TableDataSource table = report.GetDataSource("proposalTable") as TableDataSource;
            report.RegisterData(dt, "proposalTable");
            report.GetDataSource("proposalTable").Enabled = true;
            report.Prepare();
            report.Show();
        }

        private void reportForm_Load(object sender, EventArgs e)
        {
            int i = 0;
            while (true)
            {
                try
                {
                    reportDataGridView.Rows[i].HeaderCell.Value = (i + 1) + "";
                    i++;
                }
                catch (ArgumentOutOfRangeException e1)
                {
                    break;
                }
            }


            query = query.Replace("TOP 5 *", "*");
            query = query.Replace("SELECT * FROM proposalTable", "SELECT * FROM proposalTable LEFT OUTER JOIN TeacherTable ON proposalTable.executor = TeacherTable.t_NCode LEFT OUTER JOIN employersTable ON proposalTable.employer = employersTable.[index] ");

            //reportDataGridView.Columns.Clear();
            //reportDataGridView.DataSource = null;

            dbh = new DataBaseHandler(user);
            dbh.dataGridViewUpdateForReport(reportDataGridView, reportBindingSource, query);
            reportDataGridView.Columns.Add("hijriDate", "تاریخ");


            foreach (DataGridViewRow row in reportDataGridView.Rows)
            {
                string fullName;
                fullName = dbh.getDateHijri(row.Cells["startDate"].Value.ToString());
                string[] splittedString = fullName.Split(' ');
                row.Cells["hijriDate"].Value = splittedString[0];
            }
            foreach (DataGridViewRow row in reportDataGridView.Rows)
            {
                string fullName;
                fullName = row.Cells["t_LName"].Value.ToString();
                row.Cells["t_FName"].Value = row.Cells["t_FName"].Value + " " + fullName;
            }

            reportDataGridView.Columns["index"].Visible = false;
            reportDataGridView.Columns["engTitle"].Visible = false;
            reportDataGridView.Columns["keyword"].Visible = false;
            reportDataGridView.Columns["engTitle"].Visible = false;
            reportDataGridView.Columns["coExecutor"].Visible = false;
            reportDataGridView.Columns["executor"].Visible = false;
            reportDataGridView.Columns["executor2"].Visible = false;
            reportDataGridView.Columns["duration"].Visible = false;
            reportDataGridView.Columns["startDate"].Visible = false;
            reportDataGridView.Columns["procedureType"].Visible = false;
            reportDataGridView.Columns["registerType"].Visible = false;
            reportDataGridView.Columns["propertyType"].Visible = false;
            reportDataGridView.Columns["registrant"].Visible = false;
            reportDataGridView.Columns["employer"].Visible = false;
            reportDataGridView.Columns["fileName"].Visible = false;
            reportDataGridView.Columns["t_NCode"].Visible = false;
            reportDataGridView.Columns["t_LName"].Visible = false;
            reportDataGridView.Columns["t_Tel1"].Visible = false;
            reportDataGridView.Columns["t_Tel2"].Visible = false;
            reportDataGridView.Columns["t_Email"].Visible = false;
            reportDataGridView.Columns["t_EDeg"].Visible = false;
            reportDataGridView.Columns["t_Mobile"].Visible = false;
            reportDataGridView.Columns["index1"].Visible = false;

            reportDataGridView.Columns["orgName"].HeaderText = "سازمان کارفرما";
            /*
            int j = 0;
            //  reportDataGridView.Rows[j].HeaderCell.Value = "ردیف";
            while (true)
            {
                try
                {
                    MessageBox.Show(reportDataGridView.Rows[j].HeaderCell.Value + "");
                    j++;
                }
                catch (ArgumentOutOfRangeException e1)
                {
                    break;
                }
            }*/
        }

    }
}
