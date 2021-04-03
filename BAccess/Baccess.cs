using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAccess
{
    public static class UserBaccess
    {
        
        public static Entity.UserInfo login(string userName, string passsword)
        {
            return DataAccess.UserDataAccess.login(userName, passsword);
        }

        public static DataTable getRecordTable(string commandText)
        {
            return DataAccess.UserDataAccess.getRecordTable(commandText);
        }
        public static bool userInsertUpdate(Entity.UserInfo userDetails, Entity.UserInfo currentUser)
        {
            return DataAccess.UserDataAccess.userInsertUpdate(userDetails, currentUser);
        }
        public static bool DataBaseBackUp(string location)
        {
            return DataAccess.UserDataAccess.DataBaseBackUp(location);
        }
        public static int getScalerValue(string commandString)
        {
            return DataAccess.UserDataAccess.getScalerValue(commandString);
        }
    }
}
