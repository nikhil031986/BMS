using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAccess
{
    public static class BaSalesMaster
    {
        public static bool insertSalesMaster(Entity.SalesMaster saleseMaster, DataTable dtSalesDetasils, string removeSalesDetailsId, Entity.UserInfo currentUser)
        {
            return DataAccess.DaSalesMaster.insertSalesMaster(saleseMaster, dtSalesDetasils, removeSalesDetailsId, currentUser);
        }
        public static Entity.SalesMaster getsalesMaster(string invoiceNumber)
        {
            return DataAccess.DaSalesMaster.getsalesMaster(invoiceNumber);
        }
        public static bool deleteSales(int salesMasterId)
        {
            return DataAccess.DaSalesMaster.deleteSales(salesMasterId);
        }
    }
}
