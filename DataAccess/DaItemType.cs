using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class DaItemType
    {
        public static DataTable getRecordTable(string commandText)
        {
            return UserDataAccess.getRecordTable(commandText);
        }
        public static Entity.ItemTypeMsater getItemType(int itemTypeId)
        {
            Entity.ItemTypeMsater itemType = new Entity.ItemTypeMsater();
            DataTable dtForItemMaster = DaItemMaster.getRecordTable("SELECT * FROM ItemTypeMst WHERE ItemTypeMst.[ItemTypeMstId]=" + itemTypeId.ToString());
            DataRow firstRow = dtForItemMaster.AsEnumerable().FirstOrDefault();
            itemType=clsComModile.ToObject<Entity.ItemTypeMsater>(firstRow);
            return itemType;
        }
        public static bool itemTypeInsertUpdate(Entity.ItemTypeMsater ItemTypeMasterDetails, Entity.UserInfo currentUser)
        {
            bool returnValue = false;
            using (OleDbCommand cmd = new OleDbCommand())
            {
                cmd.Connection = UserDataAccess.DataBaseConnection();
                cmd.CommandType = CommandType.Text;
                if (ItemTypeMasterDetails.ItemTypeMstId == 0)
                {
                    cmd.CommandText = "INSERT INTO [ItemTypeMst] ([ItemType],[Desc],EntUserId,EntDateTime,UpUserId,UpDateTime) VALUES(@ItemType,@Desc,@EntUserId,@EntDateTime,@UpUserId,@UpDateTime)";
                }
                else
                {
                    cmd.CommandText = "UPDATE ItemTypeMst SET ItemTypeMst.ItemType = @ItemType, ItemTypeMst.[Desc] = @Desc,ItemTypeMst.UpUserId = @UpUserId, ItemTypeMst.UpDateTime = @UpDateTime WHERE(((ItemTypeMst.ItemTypeMstId) = @ItemTypeMstId))";
                }
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ItemType", ItemTypeMasterDetails.ItemType);
                cmd.Parameters.AddWithValue("@Desc", ItemTypeMasterDetails.Desc);               
                cmd.Parameters.AddWithValue("@UpUserId", currentUser.UserId);
                cmd.Parameters.AddWithValue("@UpDateTime", DateTime.Now.ToShortDateString());
                if (ItemTypeMasterDetails.ItemTypeMstId == 0)
                {
                    cmd.Parameters.AddWithValue("@EntUserId", currentUser.UserId);
                    cmd.Parameters.AddWithValue("@EntDateTime", DateTime.Now.ToShortDateString());
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ItemTypeMstId", ItemTypeMasterDetails.ItemTypeMstId);
                }
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                returnValue = true;
            }
            return returnValue;
        }
    }
}
