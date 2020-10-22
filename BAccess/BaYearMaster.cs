using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAccess
{
    public static class BaYearMaster
    {
        public static DataTable getRecordTable(string commandText)
        {
            return DataAccess.DaYearMaster.getRecordTable(commandText);
        }
        public static bool yearMasterInsertUpdate(Entity.YearMaster YearMaster, Entity.UserInfo currentUser)
        {
            return DataAccess.DaYearMaster.yearMasterInsertUpdate(YearMaster, currentUser);
        }
        public static Entity.YearMaster getYear(int yearMasterId)
        {
            return DataAccess.DaYearMaster.getYear(yearMasterId);
        }
    }
}
