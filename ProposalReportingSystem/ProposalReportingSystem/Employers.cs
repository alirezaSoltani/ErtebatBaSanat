using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProposalReportingSystem
{
   
    class Employers
    {
        
        private string orgName;
        public Employers(string orgName) {
            this.orgName = orgName;
        }
        public string getOrgName() {
            return orgName;
        }
        public void setOrgName(String orgName) {
            this.orgName = orgName;
        }
    }
}
