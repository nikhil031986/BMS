using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class SalesDetails
    {
        private int salesDetailId = 0;
        private int salesMstId = 0;
        private int itemId = 0;
        private int qty = 0;
        private decimal rate = decimal.Zero;
        private decimal disc = decimal.Zero;
        private decimal amount = decimal.Zero;
        private int discPer = 0;
        public int SalesDetailId
        {
            get
            {
                return salesDetailId;
            }

            set
            {
                salesDetailId = value;
            }
        }

        public int SalesMstId
        {
            get
            {
                return salesMstId;
            }

            set
            {
                salesMstId = value;
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

        public decimal Disc
        {
            get
            {
                return disc;
            }

            set
            {
                disc = value;
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

        public int DiscPer
        {
            get
            {
                return discPer;
            }

            set
            {
                discPer = value;
            }
        }
    }
}
