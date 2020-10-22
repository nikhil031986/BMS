using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ItemMaster
    {
        private int itemId=0;
        private int itemTypeId=0;
        private string title = string.Empty;
        private string description = string.Empty;
        private decimal rate=decimal.Zero;
        private string pubYear = string.Empty;
        private string pubPlace = string.Empty;
        private string volume = string.Empty;
        private string edition = string.Empty;
        private string language = string.Empty;
        private string iSBN = string.Empty;
        private string author = string.Empty;
        private decimal purRate=decimal.Zero;
        private decimal salesRate=decimal.Zero;
        private int closingqty = 0;
        private int opnignQty=0;
        private int rate_Dic_per=0;
        private decimal rate_Dic_Amount=decimal.Zero;
        private string publisher = string.Empty;
        private int currentStock = 0;
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

        public int ItemTypeId
        {
            get
            {
                return itemTypeId;
            }

            set
            {
                itemTypeId = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
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

        public string PubYear
        {
            get
            {
                return pubYear;
            }

            set
            {
                pubYear = value;
            }
        }

        public string PubPlace
        {
            get
            {
                return pubPlace;
            }

            set
            {
                pubPlace = value;
            }
        }

        public string Volume
        {
            get
            {
                return volume;
            }

            set
            {
                volume = value;
            }
        }

        public string Edition
        {
            get
            {
                return edition;
            }

            set
            {
                edition = value;
            }
        }

        public string Language
        {
            get
            {
                return language;
            }

            set
            {
                language = value;
            }
        }

        public string ISBN
        {
            get
            {
                return iSBN;
            }

            set
            {
                iSBN = value;
            }
        }

        public string Author
        {
            get
            {
                return author;
            }

            set
            {
                author = value;
            }
        }

        public decimal PurRate
        {
            get
            {
                return purRate;
            }

            set
            {
                purRate = value;
            }
        }

        public decimal SalesRate
        {
            get
            {
                return salesRate;
            }

            set
            {
                salesRate = value;
            }
        }

        public int OpnignQty
        {
            get
            {
                return opnignQty;
            }

            set
            {
                opnignQty = value;
            }
        }

        public int Rate_Dic_per
        {
            get
            {
                return rate_Dic_per;
            }

            set
            {
                rate_Dic_per = value;
            }
        }

        public decimal Rate_Dic_Amount
        {
            get
            {
                return rate_Dic_Amount;
            }

            set
            {
                rate_Dic_Amount = value;
            }
        }

        public string Publisher
        {
            get
            {
                return publisher;
            }

            set
            {
                publisher = value;
            }
        }

        public int CurrentStock
        {
            get
            {
                return currentStock;
            }

            set
            {
                currentStock = value;
            }
        }

        public int Closingqty
        {
            get
            {
                return closingqty;
            }

            set
            {
                closingqty = value;
            }
        }
    }
}
