using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProposalReportingSystem
{
    class Proposal
    {
        private long index;
        private string persianTitle;
        private string engTitle;
        private string keyWord;
        private long executor;
        private string executor2;
        private string coExecutor;
        private string startDate;
        private int duration;
        private string procedureType;
        private string propertyType;
        private string registerType;
        private string proposalType;
        private long employer;
        private long value;
        private string status;
        private long registrant;
        private string fileName;

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

        public string PersianTitle
        {
            get
            {
                return persianTitle;
            }

            set
            {
                persianTitle = value;
            }
        }

        public string EngTitle
        {
            get
            {
                return engTitle;
            }

            set
            {
                engTitle = value;
            }
        }

        public string KeyWord
        {
            get
            {
                return keyWord;
            }

            set
            {
                keyWord = value;
            }
        }

        public long Executor
        {
            get
            {
                return executor;
            }

            set
            {
                executor = value;
            }
        }

        public string Executor2
        {
            get
            {
                return executor2;
            }

            set
            {
                executor2 = value;
            }
        }

        public string CoExecutor
        {
            get
            {
                return coExecutor;
            }

            set
            {
                coExecutor = value;
            }
        }



        public int Duration
        {
            get
            {
                return duration;
            }

            set
            {
                duration = value;
            }
        }

        public string ProcedureType
        {
            get
            {
                return procedureType;
            }

            set
            {
                procedureType = value;
            }
        }

        public string PropertyType
        {
            get
            {
                return propertyType;
            }

            set
            {
                propertyType = value;
            }
        }

        public string RegisterType
        {
            get
            {
                return registerType;
            }

            set
            {
                registerType = value;
            }
        }

        public string ProposalType
        {
            get
            {
                return proposalType;
            }

            set
            {
                proposalType = value;
            }
        }

        public long Employer
        {
            get
            {
                return employer;
            }

            set
            {
                employer = value;
            }
        }

        public long Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
            }
        }

        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public long Registrant
        {
            get
            {
                return registrant;
            }

            set
            {
                registrant = value;
            }
        }

        public string StartDate
        {
            get
            {
                return startDate;
            }

            set
            {
                startDate = value;
            }
        }

        public string FileName
        {
            get
            {
                return fileName;
            }

            set
            {
                fileName = value;
            }
        }
    }
}
