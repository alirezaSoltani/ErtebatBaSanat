using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProposalReportingSystem
{
    class PageOffsetList : System.ComponentModel.IListSource
    {
        public bool ContainsListCollection { get; protected set; }
        private int totalRecords;
        public System.Collections.IList GetList()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source= 185.159.152.2;" +
                "Initial Catalog=rayanpro_EBS;" +
                "User id=rayanpro_rayan; " +
                "Password=P@hn1395;";

            SqlCommand sc = new SqlCommand();
            SqlDataReader reader;
            sc.CommandText = "SELECT COUNT(*) AS NumberOfLogs FROM logTable ";
            sc.CommandType = CommandType.Text;
            sc.Connection = conn;
            conn.Open();
            reader = sc.ExecuteReader();

            reader.Read();
            totalRecords = int.Parse((reader["NumberOfLogs"].ToString()));
            conn.Close();


            // Return a list of page offsets based on "totalRecords" and "pageSize"
            var pageOffsets = new List<int>();
            for (int offset = 0; offset < totalRecords; offset += 10)
                pageOffsets.Add(offset);
            return pageOffsets;
        }
    }
}
