using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ItemStock
    {
        private int itemId = 0;
        private int purStock = 0;
        private int salesStock = 0;
        private int currStock = 0;

        public int ItemId
        {
            get
            {
                return itemId;
            }

            set
            {
                itemId = value;
            }
        }

        public int PurStock
        {
            get
            {
                return purStock;
            }

            set
            {
                purStock = value;
            }
        }

        public int SalesStock
        {
            get
            {
                return salesStock;
            }

            set
            {
                salesStock = value;
            }
        }

        public int CurrStock
        {
            get
            {
                return currStock;
            }

            set
            {
                currStock = value;
            }
        }
    }
}
