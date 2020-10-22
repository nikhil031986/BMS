using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class BookIssueDetail
    {
        private int bookIssueDetailId = 0;
        private int bookId = 0;
        private int itemId = 0;
        private int qty = 0;

        public int BookIssueDetailId
        {
            get { return bookIssueDetailId; }
            set { bookIssueDetailId = value; }
        }

        public int BookId
        {
            get { return bookId; }
            set { bookId = value; }
        }

        public int ItemId
        {
            get { return itemId; }
            set { itemId = value; }
        }

        public int Qty
        {
            get { return qty; }
            set { qty = value; }
        }
    }
}
