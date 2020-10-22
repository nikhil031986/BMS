using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAccess
{
    public static class BaPurchaseMaster
    {
        public static bool insertPurchaseMaster(Entity.PurchaseMaster purchaseMaster, DataTable dtPurchaseDetasils, string removepurchaseDetailsId, Entity.UserInfo currentUser)
        {
            return DataAccess.DaPurchaseMaster.insertPurchaseMaster(purchaseMaster, dtPurchaseDetasils, removepurchaseDetailsId, currentUser);
        }
        public static Entity.PurchaseMaster getpurchaseMaster(string invoiceNumber)
        {
            return DataAccess.DaPurchaseMaster.getpurchaseMaster(invoiceNumber);
        }
        public static bool deletePurchase(int purchaseMasterId)
        {
            return DataAccess.DaPurchaseMaster.deletePurchase(purchaseMasterId);
        }
    }
}
