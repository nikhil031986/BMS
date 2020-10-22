using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAccess
{
    public static class BaPartyMaster
    {
        public static DataTable getRecordTable(string commandText)
        {
            return DataAccess.DaPartyMaster.getRecordTable(commandText);
        }
        public static bool partyMasterInsertUpdate(Entity.PartyMaster partyMaster, Entity.UserInfo currentUser)
        {
            return DataAccess.DaPartyMaster.partyMasterInsertUpdate(partyMaster, currentUser);
        }
    }
}
