using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class purch_details
    {
        private int purDetailId = 0;
        private int purMstId = 0;
        private int itemId = 0;
        private int qty = 0;
        private decimal rate = decimal.Zero;
        private decimal dis = decimal.Zero;
        private decimal amount = decimal.Zero;

        public int PurDetailId
        {
            get
            {
                return purDetailId;
            }

            set
            {
                purDetailId = value;
            }
        }

        public int PurMstId
        {
            get
            {
                return purMstId;
            }

            set
            {
                purMstId = value;
            }
        }

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

        public int Qty
        {
            get
            {
                return qty;
            }

            set
            {
                qty = value;
            }
        }

        public decimal Rate
        {
            get
            {
                return rate;
            }

            set
            {
                rate = value;
            }
        }

        public decimal Dis
        {
            get
            {
                return dis;
            }

            set
            {
                dis = value;
            }
        }

        public decimal Amount
        {
            get
            {
                return amount;
            }

            set
            {
                amount = value;
            }
        }
    }
}
