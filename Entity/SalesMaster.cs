using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class SalesMaster
    {
        private int salesMstId = 0;
        private DateTime salesDate = DateTime.Now;
        private int invoiceNo = 0;
        private string partyName = string.Empty;
        private string desc = string.Empty;
        private decimal total_Amount = decimal.Zero;
        private decimal dis_Amount = decimal.Zero;
        private decimal sales_Amount = decimal.Zero;

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

        public DateTime SalesDate
        {
            get
            {
                return salesDate;
            }

            set
            {
                salesDate = value;
            }
        }

        public int InvoiceNo
        {
            get
            {
                return invoiceNo;
            }

            set
            {
                invoiceNo = value;
            }
        }

        public string PartyName
        {
            get
            {
                return partyName;
            }

            set
            {
                partyName = value;
            }
        }

        public string Desc
        {
            get
            {
                return desc;
            }

            set
            {
                desc = value;
            }
        }

        public decimal Total_Amount
        {
            get
            {
                return total_Amount;
            }

            set
            {
                total_Amount = value;
            }
        }

        public decimal Dis_Amount
        {
            get
            {
                return dis_Amount;
            }

            set
            {
                dis_Amount = value;
            }
        }

        public decimal Sales_Amount
        {
            get
            {
                return sales_Amount;
            }

            set
            {
                sales_Amount = value;
            }
        }
    }
}
