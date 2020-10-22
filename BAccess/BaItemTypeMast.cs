using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAccess
{
    public static class BaItemTypeMast
    {
        public static DataTable getRecordTable(string commandText)
        {
            return DataAccess.DaItemType.getRecordTable(commandText);
        }
        public static bool itemTypeInsertUpdate(Entity.ItemTypeMsater ItemTypeMasterDetails, Entity.UserInfo currentUser)
        {
            return DataAccess.DaItemType.itemTypeInsertUpdate(ItemTypeMasterDetails, currentUser);
        }
        public static Entity.ItemTypeMsater getItemType(int itemTypeId)
        {
            return DataAccess.DaItemType.getItemType(itemTypeId);
        }
    }
}
