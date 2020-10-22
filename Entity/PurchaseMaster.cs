using System;

namespace Entity
{
    public class PurchaseMaster
    {
        private int purMstId = 0;
        private string invoidNo = string.Empty;
        private DateTime invoiceDate = DateTime.Now;
        private int partyid = 0;
        private string desc = string.Empty;
        private decimal totalAmount = decimal.Zero;
        private decimal dis_Amount = decimal.Zero;
        private decimal pur_Amount = decimal.Zero;
        private bool fullPayment = false;
        private decimal pay_Amount = decimal.Zero;
        private decimal pen_Amoun = decimal.Zero;

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

        public string InvoidNo
        {
            get
            {
                return invoidNo;
            }

            set
            {
                invoidNo = value;
            }
        }

        public DateTime InvoiceDate
        {
            get
            {
                return invoiceDate;
            }

            set
            {
                invoiceDate = value;
            }
        }

        public int Partyid
        {
            get
            {
                return partyid;
            }

            set
            {
                partyid = value;
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

        public decimal TotalAmount
        {
            get
            {
                return totalAmount;
            }

            set
            {
                totalAmount = value;
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

        public decimal Pur_Amount
        {
            get
            {
                return pur_Amount;
            }

            set
            {
                pur_Amount = value;
            }
        }

        public bool FullPayment
        {
            get
            {
                return fullPayment;
            }

            set
            {
                fullPayment = value;
            }
        }

        public decimal Pay_Amount
        {
            get
            {
                return pay_Amount;
            }

            set
            {
                pay_Amount = value;
            }
        }

        public decimal Pen_Amoun
        {
            get
            {
                return pen_Amoun;
            }

            set
            {
                pen_Amoun = value;
            }
        }
    }
}
