using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProposalReportingSystem
{
    public class User
    {
        private long u_NCode;
        private string u_Password;
        private string u_FName;
        private string u_LName;
        private string u_Email;
        private string u_Tel;
        private string u_Color;
        private short u_IsAdmin = 0;
        private short canAddProposal, canEditProposal, canDeleteProposal, canAddUser, canEditUser, canDeleteUser, canManageTeacher, canManageType;


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

        public short CanAddProposal
        {
            get
            {
                return canAddProposal;
            }

            set
            {
                canAddProposal = value;
            }
        }

        public short CanEditProposal
        {
            get
            {
                return canEditProposal;
            }

            set
            {
                canEditProposal = value;
            }
        }

        public short CanDeleteProposal
        {
            get
            {
                return canDeleteProposal;
            }

            set
            {
                canDeleteProposal = value;
            }
        }

        public short CanAddUser
        {
            get
            {
                return canAddUser;
            }

            set
            {
                canAddUser = value;
            }
        }

        public short CanEditUser
        {
            get
            {
                return canEditUser;
            }

            set
            {
                canEditUser = value;
            }
        }

        public short CanDeleteUser
        {
            get
            {
                return canDeleteUser;
            }

            set
            {
                canDeleteUser = value;
            }
        }

        public short CanManageTeacher
        {
            get
            {
                return canManageTeacher;
            }

            set
            {
                canManageTeacher = value;
            }
        }

        public short CanManageType
        {
            get
            {
                return canManageType;
            }

            set
            {
                canManageType = value;
            }
        }


        public string U_Color
        {
            get
            {
                return u_Color;
            }

            set
            {
                u_Color = value;
            }
        }

        public short U_IsAdmin
        {
            get
            {
                return u_IsAdmin;
            }

            set
            {
                u_IsAdmin = value;
            }
        }
    }
}
