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
        private DateTime startDate;
        private int duration;
        private string procedureType;
        private string propertyType;
        private string registerType;
        private string proposalType;
        private long employer;
        private string value;
        private string status;
        private long registrant;

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

        public DateTime StartDate
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

        public string Value
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

        public Proposal(long index, string persianTitle, string engTitle, string keyWord, long executor, string executor2, string coExecutor, DateTime startDate, int duration, string procedureType, string propertyType, string registerType, string proposalType, long employer, string value, string status, long registrant)
        {
            this.Index = index;
            this.PersianTitle = persianTitle;
            this.EngTitle = engTitle;
            this.KeyWord = keyWord;
            this.Executor = executor;
            this.Executor2 = executor2;
            this.CoExecutor = coExecutor;
            this.StartDate = startDate;
            this.Duration = duration;
            this.ProcedureType = procedureType;
            this.PropertyType = propertyType;
            this.RegisterType = registerType;
            this.ProposalType = proposalType;
            this.Employer = employer;
            this.Value = value;
            this.Status = status;
            this.Registrant = registrant;
        }
    }
}
