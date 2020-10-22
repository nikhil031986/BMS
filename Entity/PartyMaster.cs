using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class PartyMaster
    {
        private int partyId = 0;
        private string type = string.Empty;
        private string partyName = string.Empty;
        private string address = string.Empty;
        private string city = string.Empty;
        private string pinCode = string.Empty;
        private string emailId = string.Empty;
        private string phoneNumber = string.Empty;
        private string mobile = string.Empty;

        public int PartyId
        {
            get
            {
                return partyId;
            }

            set
            {
                partyId = value;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
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

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public string City
        {
            get
            {
                return city;
            }

            set
            {
                city = value;
            }
        }

        public string PinCode
        {
            get
            {
                return pinCode;
            }

            set
            {
                pinCode = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }

            set
            {
                phoneNumber = value;
            }
        }

        public string Mobile
        {
            get
            {
                return mobile;
            }

            set
            {
                mobile = value;
            }
        }

        public string EmailId
        {
            get
            {
                return emailId;
            }

            set
            {
                emailId = value;
            }
        }
    }
}
