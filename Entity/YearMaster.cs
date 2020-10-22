using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class YearMaster
    {
        private int year_Id = 0;
        private DateTime start_Date = DateTime.Now;
        private DateTime end_Date = DateTime.Now;
        private string remarks = string.Empty;

        public int Year_Id
        {
            get
            {
                return year_Id;
            }

            set
            {
                year_Id = value;
            }
        }

        public DateTime Start_Date
        {
            get
            {
                return start_Date;
            }

            set
            {
                start_Date = value;
            }
        }

        public DateTime End_Date
        {
            get
            {
                return end_Date;
            }

            set
            {
                end_Date = value;
            }
        }

        public string Remarks
        {
            get
            {
                return remarks;
            }

            set
            {
                remarks = value;
            }
        }
    }
}
