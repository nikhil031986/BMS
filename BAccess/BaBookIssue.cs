using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAccess
{
    public static class BaBookIssue
    {
        public static Entity.BookIssue getbookIssueMaster(string issueNo, int bookMasterId = 0)
        {
            return DataAccess.DaBookIssue.getbookIssueMaster(issueNo, bookMasterId);
        }
        public static bool insertBookIssueMaster(Entity.BookIssue bookIssue, DataTable dtBookDetils, string removebookDetailsId, Entity.UserInfo currentUser)
        {
            return DataAccess.DaBookIssue.insertBookIssueMaster(bookIssue, dtBookDetils, removebookDetailsId, currentUser);
        }
    }
}
