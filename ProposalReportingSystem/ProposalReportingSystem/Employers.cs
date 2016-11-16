using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProposalReportingSystem
{
   
    class Employers
    {
        
        private string orgName;
        private long index;

        public Employers(string orgName)
        {
            this.OrgName = orgName;
        }

        public string OrgName
        {
            get
            {
                return orgName;
            }

            set
            {
                orgName = value;
            }
        }

        public long Index
        {
            get
            {
                return index;
            }

            set
            {
                index = value;
            }
        }
    }
}
