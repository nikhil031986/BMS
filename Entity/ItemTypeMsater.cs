using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public  class ItemTypeMsater
    {
        private  int itemTypeMstId = 0;
        private  string itemType = string.Empty;
        private  string desc = string.Empty;

        public  int ItemTypeMstId
        {
            get
            {
                return itemTypeMstId;
            }

            set
            {
                itemTypeMstId = value;
            }
        }

        public  string ItemType
        {
            get
            {
                return itemType;
            }

            set
            {
                itemType = value;
            }
        }

        public  string Desc
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
    }
}
