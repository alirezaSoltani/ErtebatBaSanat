using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProposalReportingSystem
{
    class Teachers
    {
        private string t_FName;
        private string t_LName;
        private long t_NCode;
        private string t_EDeg;
        private string t_Email;
        private string t_Mobile;
        private string t_Tel1;
        private string t_Tel2;
        private string t_Faculty;
        private string t_Group;

        public string T_FName
        {
            get
            {
                return t_FName;
            }

            set
            {
                t_FName = value;
            }
        }

        public string T_LName
        {
            get
            {
                return t_LName;
            }

            set
            {
                t_LName = value;
            }
        }

        public long T_NCode
        {
            get
            {
                return t_NCode;
            }

            set
            {
                t_NCode = value;
            }
        }

        public string T_EDeg
        {
            get
            {
                return t_EDeg;
            }

            set
            {
                t_EDeg = value;
            }
        }

        public string T_Email
        {
            get
            {
                return t_Email;
            }

            set
            {
                t_Email = value;
            }
        }

        public string T_Mobile
        {
            get
            {
                return t_Mobile;
            }

            set
            {
                t_Mobile = value;
            }
        }

        public string T_Tel1
        {
            get
            {
                return t_Tel1;
            }

            set
            {
                t_Tel1 = value;
            }
        }

        public string T_Tel2
        {
            get
            {
                return t_Tel2;
            }

            set
            {
                t_Tel2 = value;
            }
        }

        public string T_Faculty
        {
            get
            {
                return t_Faculty;
            }

            set
            {
                t_Faculty = value;
            }
        }

        public string T_Group
        {
            get
            {
                return t_Group;
            }

            set
            {
                t_Group = value;
            }
        }

        public Teachers(string t_FName, string t_LName, long t_NCode, string t_EDeg, string t_Email, string t_Mobile, string t_Tel1, string t_Tel2, string t_Faculty, string t_Group)
        {
            this.T_FName = t_FName;
            this.T_LName = t_LName;
            this.T_NCode = t_NCode;
            this.T_EDeg = t_EDeg;
            this.T_Email = t_Email;
            this.T_Mobile = t_Mobile;
            this.T_Tel1 = t_Tel1;
            this.T_Tel2 = t_Tel2;
            this.T_Faculty = t_Faculty;
            this.T_Group = t_Group;
        }
    }
}
