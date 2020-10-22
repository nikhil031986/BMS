using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAccess
{
    public static class BaItemMaster
    {
        public static DataTable getRecordTable(string commandText)
        {
            return DataAccess.DaItemMaster.getRecordTable(commandText);
        }
        public static bool itemMasterInsertUpdate(Entity.ItemMaster itemMasterDetails, Entity.UserInfo currentUser)
        {
            return DataAccess.DaItemMaster.itemMasterInsertUpdate(itemMasterDetails, currentUser);
        }
        public static Entity.ItemMaster getItemMaster(int itemMasterId)
        {
            return DataAccess.DaItemMaster.getItemMaster(itemMasterId);
        }
        public static bool updateItemWiseStock(int stockId, int purQty, int salesQrty, int totalQty, Entity.UserInfo currentUser)
        {
            return DataAccess.DaItemMaster.updateItemWiseStock(stockId, purQty, salesQrty, totalQty, currentUser);
        }
        public static bool updateClosingStock()
        {
            return DataAccess.DaItemMaster.updateClosingStock();
        }
    }
}
