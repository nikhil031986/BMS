using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class BookIssue
    {
        private int bookIssueId = 0;
        private int issueNo = 0;
        private DateTime issueDate = DateTime.Now;
        private DateTime returnDate = DateTime.Now.AddDays(5);
        private string partyName = string.Empty;
        private string mobileNo = string.Empty;
        private string emailid = string.Empty;
        private bool isReturn = false;

        public int BookIssueId
        {
            get { return bookIssueId; }
            set { bookIssueId = value; }
        }

        public int IssueNo
        {
            get { return issueNo; }
            set { issueNo = value; }
        }

        public DateTime IssueDate
        {
            get { return issueDate; }

            set { issueDate = value; }
        }

        public DateTime ReturnDate
        {
            get { return returnDate; }

            set { returnDate = value; }
        }

        public string PartyName
        {
            get { return partyName; }
            set { partyName = value; }
        }

        public string MobileNo
        {
            get { return mobileNo; }

            set { mobileNo = value; }
        }

        public string Emailid
        {
            get { return emailid; }
            set { emailid = value; }
        }

        public bool IsReturn
        {
            get { return isReturn; }
            set { isReturn = value; }
        }
    }
}
