using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProposalReportingSystem
{
    class User
    {
        private long u_NCode;
        private string u_Password;
        private string u_FName;
        private string u_LName;
        private string u_Email;
        private string u_Tel;


        public long U_NCode
        {
            get
            {
                return u_NCode;
            }

            set
            {
                u_NCode = value;
            }
        }

        public string U_Password
        {
            get
            {
                return u_Password;
            }

            set
            {
                u_Password = value;
            }
        }

        public string U_FName
        {
            get
            {
                return u_FName;
            }

            set
            {
                u_FName = value;
            }
        }

        public string U_LName
        {
            get
            {
                return u_LName;
            }

            set
            {
                u_LName = value;
            }
        }

        public string U_Email
        {
            get
            {
                return u_Email;
            }

            set
            {
                u_Email = value;
            }
        }

        public string U_Tel
        {
            get
            {
                return u_Tel;
            }

            set
            {
                u_Tel = value;
            }
        }
    }
}
