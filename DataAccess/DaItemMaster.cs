using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class DaItemMaster
    {
        public static DataTable getRecordTable(string commandText)
        {
            return UserDataAccess.getRecordTable(commandText);
        }
        public static Entity.ItemMaster getItemMaster(int itemMasterId)
        {
            Entity.ItemMaster itemMaster = new Entity.ItemMaster();
            DataTable dtForItemMaster = DaItemMaster.getRecordTable("SELECT ItemMst.*, StockMst.CurrStock FROM ItemMst INNER JOIN StockMst ON ItemMst.ItemId = StockMst.ItemId WHERE ItemMst.[ItemId]=" + itemMasterId.ToString());
            DataRow firstRow = dtForItemMaster.AsEnumerable().FirstOrDefault();
            itemMaster=clsComModile.ToObject<Entity.ItemMaster>(firstRow);
            return itemMaster;
        }
        public static bool itemMasterInsertUpdate(Entity.ItemMaster itemMasterDetails, Entity.UserInfo currentUser)
        {
            bool returnValue = false;
            OleDbTransaction transaction = null;
            try
            {
                string queery = "Select @@Identity";
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = UserDataAccess.DataBaseConnection();
                    cmd.CommandType = CommandType.Text;
                    if (itemMasterDetails.ItemId == 0)
                    {
                        cmd.CommandText = "INSERT INTO ItemMst(ItemTypeId,[Title],[Description],[Rate],PubYear,PubPlace,Publisher,[volume],[Edition],[Language],[ISBN],Author,purRate,salesRate,OpningQty,Rate_Dic_per,Rate_Dic_Amount,Closingqty,EntUserId,EntDateTime,UpUserId,UpDateTime) VALUES(@ItemTypeId,@Title,@Description,@Rate,@PubYear,@PubPlace,@Publisher,@volume,@Edition,@Language,@ISBN,@Author,@purRate,@salesRate,@OpningQty,@Rate_Dic_per,@Rate_Dic_Amount,@Closingqty,@EntUserId,@EntDateTime,@UpUserId,@UpDateTime)";
                    }
                    else
                    {
                        cmd.CommandText = "UPDATE ItemMst SET ItemMst.[ItemTypeId]=@ItemTypeId,ItemMst.[Title]=@Title,ItemMst.[Description]=@Description,ItemMst.[Rate]=@Rate,ItemMst.PubYear=@PubYear,ItemMst.PubPlace=@PubPlace,Publisher=@Publisher,ItemMst.[volume]=@volume,ItemMst.[Edition]=@Edition,ItemMst.[Language]=@Language,ItemMst.[ISBN]=@ISBN,ItemMst.Author=@Author,ItemMst.purRate=@purRate,ItemMst.salesRate=@salesRate,ItemMst.OpningQty=@OpningQty,ItemMst.Rate_Dic_per=@Rate_Dic_per,ItemMst.Rate_Dic_Amount=@Rate_Dic_Amount,ItemMst.Closingqty=@Closingqty,ItemMst.UpUserId=@UpUserId,ItemMst.UpDateTime=@UpDateTime  WHERE(((ItemMst.ItemId) = @ItemId))";
                    }
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ItemTypeId", itemMasterDetails.ItemTypeId);
                    cmd.Parameters.AddWithValue("@Title", itemMasterDetails.Title);
                    cmd.Parameters.AddWithValue("@Description", itemMasterDetails.Description);
                    cmd.Parameters.AddWithValue("@Rate", itemMasterDetails.Rate);
                    cmd.Parameters.AddWithValue("@PubYear", itemMasterDetails.PubYear);
                    cmd.Parameters.AddWithValue("@PubPlace", itemMasterDetails.PubPlace);
                    cmd.Parameters.AddWithValue("@Publisher", itemMasterDetails.Publisher);
                    cmd.Parameters.AddWithValue("@volume", itemMasterDetails.Volume);
                    cmd.Parameters.AddWithValue("@Edition", itemMasterDetails.Edition);
                    cmd.Parameters.AddWithValue("@Language", itemMasterDetails.Language);
                    cmd.Parameters.AddWithValue("@ISBN", itemMasterDetails.ISBN);
                    cmd.Parameters.AddWithValue("@Author", itemMasterDetails.Author);
                    cmd.Parameters.AddWithValue("@purRate", itemMasterDetails.PurRate);
                    cmd.Parameters.AddWithValue("@salesRate", itemMasterDetails.SalesRate);
                    cmd.Parameters.AddWithValue("@OpningQty", itemMasterDetails.OpnignQty);
                    cmd.Parameters.AddWithValue("@Rate_Dic_per", itemMasterDetails.Rate_Dic_per);
                    cmd.Parameters.AddWithValue("@Rate_Dic_Amount", itemMasterDetails.Rate_Dic_Amount);
                    cmd.Parameters.AddWithValue("@Closingqty", itemMasterDetails.Closingqty);
                    cmd.Parameters.AddWithValue("@UpUserId", currentUser.UserId);
                    cmd.Parameters.AddWithValue("@UpDateTime", DateTime.Now.ToShortDateString());
                    if (itemMasterDetails.ItemId == 0)
                    {
                        cmd.Parameters.AddWithValue("@EntUserId", currentUser.UserId);
                        cmd.Parameters.AddWithValue("@EntDateTime", DateTime.Now.ToShortDateString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ItemId", itemMasterDetails.ItemId);
                    }
                    if (cmd.Connection.State == ConnectionState.Open)
                    {
                        cmd.Connection.Close();
                    }
                    cmd.Connection.Open();
                    transaction = cmd.Connection.BeginTransaction(IsolationLevel.ReadCommitted);
                    cmd.Transaction = transaction;
                    if (itemMasterDetails.ItemId == 0)
                    {
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        cmd.CommandText = queery;
                        itemMasterDetails.ItemId = (int)cmd.ExecuteScalar();
                        bool stockInsert = stockUpdate(itemMasterDetails, currentUser);
                        if (!stockInsert)
                        {
                            transaction.Rollback();
                        }
                        else
                        {
                            transaction.Commit();
                        }
                    }
                    else
                    {
                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                    }
                    cmd.Connection.Close();
                    returnValue = true;
                }
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw ex;
            }
            return returnValue;
        }
        public static bool updateItemWiseStock(int stockId,int purQty,int salesQrty, int totalQty,Entity.UserInfo currentUser)
        {
            bool updateStock = false;
            try
            {
                using (OleDbCommand innercmd = new OleDbCommand())
                {
                    innercmd.Connection = UserDataAccess.DataBaseConnection();
                    innercmd.CommandType = CommandType.Text;
                    innercmd.CommandText = "UPDATE  StockMst SET StockMst.PurStock = @puQty,StockMst.SalesStock = @salesQty,StockMst.CurrStock = @totalQty,StockMst.UpUserId=@UpUserId,StockMst.UpDateTime=@UpDateTime WHERE StockMst.StockMstId=@StockMstId";
                    innercmd.Parameters.Clear();
                    innercmd.Parameters.AddWithValue("@puQty", purQty);
                    innercmd.Parameters.AddWithValue("@salesQty", salesQrty);
                    innercmd.Parameters.AddWithValue("@totalQty", totalQty);
                    innercmd.Parameters.AddWithValue("@UpUserId", currentUser.UserId);
                    innercmd.Parameters.AddWithValue("@UpDateTime", DateTime.Now.ToShortDateString());
                    innercmd.Parameters.AddWithValue("@StockMstId", stockId);
                    if (innercmd.Connection.State == ConnectionState.Open)
                    {
                        innercmd.ExecuteNonQuery();
                        updateStock = true;
                    }
                    else
                    {
                        innercmd.Connection.Open();
                        innercmd.ExecuteNonQuery();
                        innercmd.Connection.Close();
                        updateStock = true;
                    }
                }
            }
            catch
            {
                updateStock = false;
            }
            return updateStock;
        }
        public static bool deleteSalesStock(string salesDetailsId)
        {
            bool updateStock = false;
            try
            {
                using (OleDbCommand innercmd = new OleDbCommand())
                {
                    innercmd.Connection = UserDataAccess.DataBaseConnection();
                    innercmd.CommandType = CommandType.Text;
                    innercmd.CommandText = "UPDATE  StockMst INNER JOIN  SalesDetail ON SalesDetail.ItemId = StockMst.ItemId SET StockMst.SalesStock = (StockMst.SalesStock - SalesDetail.Qty),StockMst.CurrStock = (StockMst.CurrStock + SalesDetail.Qty) WHERE SalesDetail.SalesDetailId IN(@SalesDetailIds)";
                    innercmd.Parameters.Clear();
                    innercmd.Parameters.AddWithValue("@SalesDetailIds", salesDetailsId);
                    if (innercmd.Connection.State == ConnectionState.Open)
                    {
                        innercmd.ExecuteNonQuery();
                        updateStock = true;
                    }
                    else
                    {
                        innercmd.Connection.Open();
                        innercmd.ExecuteNonQuery();
                        innercmd.Connection.Close();
                        updateStock = true;
                    }
                }
            }
            catch
            {
                updateStock = false;
            }
            return updateStock;
        }
        public static bool deletePurchaseStock(string purchaseDetailIds)
        {
            bool updateStock = false;
            try
            {
                using (OleDbCommand innercmd = new OleDbCommand())
                {
                    innercmd.Connection = UserDataAccess.DataBaseConnection();
                    innercmd.CommandType = CommandType.Text;
                    innercmd.CommandText = "UPDATE  StockMst INNER JOIN  PurDetail ON PurDetail.ItemId = StockMst.ItemId SET StockMst.PurStock = (StockMst.PurStock - PurDetail.Qty),StockMst.CurrStock = (StockMst.CurrStock - PurDetail.Qty) WHERE PurDetail.PurDetailId IN(@PurDetailIds)";
                    innercmd.Parameters.Clear();
                    innercmd.Parameters.AddWithValue("@PurDetailIds", purchaseDetailIds);
                    if (innercmd.Connection.State == ConnectionState.Open)
                    {
                        innercmd.ExecuteNonQuery();
                        updateStock = true;
                    }
                    else
                    {
                        innercmd.Connection.Open();
                        innercmd.ExecuteNonQuery();
                        innercmd.Connection.Close();
                        updateStock = true;
                    }
                }
            }
            catch
            {
                updateStock = false;
            }
            return updateStock;
        }
        public static bool updateClosingStock()
        {
            bool updateClosingStock = false;
            using (OleDbCommand innercmd = new OleDbCommand())
            {
                innercmd.Connection = UserDataAccess.DataBaseConnection();
                innercmd.CommandType = CommandType.Text;
                innercmd.CommandText = "UPDATE ItemMst INNER JOIN StockMst ON ItemMst.[ItemId] = StockMst.[ItemId] SET ItemMst.[Closingqty] = StockMst.[CurrStock]";
                innercmd.Parameters.Clear();               
                if (innercmd.Connection.State == ConnectionState.Open)
                {
                    innercmd.ExecuteNonQuery();
                    updateClosingStock = true;
                }     
                else
                {
                    innercmd.Connection.Open();
                    innercmd.ExecuteNonQuery();
                    innercmd.Connection.Close();
                    updateClosingStock = true;
                }         
            }
            return updateClosingStock;
        }
        public static bool updateSalesStock(int itemId, int SalesQty, int prevQunatity, Entity.UserInfo currentUser)
        {
            bool updateStock = false;
            try
            {
                using (OleDbCommand innercmd = new OleDbCommand())
                {
                    innercmd.Connection = UserDataAccess.DataBaseConnection();
                    innercmd.CommandType = CommandType.Text;
                    innercmd.CommandText = "UPDATE StockMst SET StockMst.SalesStock=((StockMst.SalesStock-@prevQuntity)+@SalesQty),StockMst.CurrStock=((StockMst.CurrStock+@prevQuntity)-@SalesQty),StockMst.UpUserId=@UpUserId,StockMst.UpDateTime=@UpDateTime WHERE StockMst.ItemId=@ItemId";
                    innercmd.Parameters.Clear();
                    innercmd.Parameters.AddWithValue("@prevQuntity", prevQunatity);
                    innercmd.Parameters.AddWithValue("@SalesQty", SalesQty);
                    innercmd.Parameters.AddWithValue("@UpUserId", currentUser.UserId);
                    innercmd.Parameters.AddWithValue("@UpDateTime", DateTime.Now.ToShortDateString());
                    innercmd.Parameters.AddWithValue("@ItemId", itemId);
                    if (innercmd.Connection.State == ConnectionState.Open)
                    {
                        innercmd.ExecuteNonQuery();
                        updateStock = true;
                    }
                    else
                    {
                        innercmd.Connection.Open();
                        innercmd.ExecuteNonQuery();
                        innercmd.Connection.Close();
                        updateStock = true;
                    }
                }
            }
            catch
            {
                updateStock = false;
            }
            return updateStock;
        }

        public static bool updatePurchaseStock(int itemId, int purQty, int prevQunatity, Entity.UserInfo currentUser)
        {
            bool updateStock = false;
            try
            {
                using (OleDbCommand innercmd = new OleDbCommand())
                {
                    innercmd.Connection = UserDataAccess.DataBaseConnection();
                    innercmd.CommandType = CommandType.Text;
                    innercmd.CommandText = "UPDATE StockMst SET StockMst.PurStock=((StockMst.PurStock-@prevQuntity)+@PurStock),StockMst.CurrStock=((StockMst.CurrStock-@prevQuntity)+@PurStock),StockMst.UpUserId=@UpUserId,StockMst.UpDateTime=@UpDateTime WHERE StockMst.ItemId=@ItemId";
                    innercmd.Parameters.Clear();
                    innercmd.Parameters.AddWithValue("@prevQuntity", prevQunatity);
                    innercmd.Parameters.AddWithValue("@PurStock", purQty);
                    innercmd.Parameters.AddWithValue("@UpUserId", currentUser.UserId);
                    innercmd.Parameters.AddWithValue("@UpDateTime", DateTime.Now.ToShortDateString());
                    innercmd.Parameters.AddWithValue("@ItemId", itemId);
                    if (innercmd.Connection.State == ConnectionState.Open)
                    {
                        innercmd.ExecuteNonQuery();
                        updateStock = true;
                    }
                    else
                    {
                        innercmd.Connection.Open();
                        innercmd.ExecuteNonQuery();
                        innercmd.Connection.Close();
                        updateStock = true;
                    }
                }
            }
            catch
            {
                updateStock = false;
            }
            return updateStock;
        }
        private static bool stockUpdate(Entity.ItemMaster itemMaster, Entity.UserInfo currentUser)
        {
            bool retInsert = false;
            DataTable dtForStock = new DataTable();
            try
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = UserDataAccess.DataBaseConnection();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select * from StockMst WHERE StockMst.ItemId = @ItemId";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ItemId", itemMaster.ItemId);
                    OleDbDataAdapter adp = new OleDbDataAdapter(cmd);
                    adp.Fill(dtForStock);
                    if (dtForStock.AsEnumerable().Count() == 0)
                    {
                        try
                        {
                            using (OleDbCommand innercmd = new OleDbCommand())
                            {
                                innercmd.Connection = UserDataAccess.DataBaseConnection();
                                innercmd.CommandType = CommandType.Text;
                                innercmd.CommandText = "INSERT INTO StockMst (ItemId,PurStock,SalesStock,CurrStock,EntUserId,EntDateTime,UpUserId,UpDateTime) VALUES(@ItemId,@PurStock,@SalesStock,@CurrStock,@EntUserId,@EntDateTime,@UpUserId,@UpDateTime)";
                                innercmd.Parameters.Clear();
                                innercmd.Parameters.AddWithValue("@ItemId", itemMaster.ItemId);
                                innercmd.Parameters.AddWithValue("@PurStock", itemMaster.OpnignQty);
                                innercmd.Parameters.AddWithValue("@SalesStock", 0);
                                innercmd.Parameters.AddWithValue("@CurrStock", itemMaster.OpnignQty);
                                innercmd.Parameters.AddWithValue("@EntUserId", currentUser.UserId);
                                innercmd.Parameters.AddWithValue("@EntDateTime", DateTime.Now.ToShortDateString());
                                innercmd.Parameters.AddWithValue("@UpUserId", currentUser.UserId);
                                innercmd.Parameters.AddWithValue("@UpDateTime", DateTime.Now.ToShortDateString());
                                if (innercmd.Connection.State == ConnectionState.Open)
                                {
                                    innercmd.ExecuteNonQuery();
                                    retInsert = true;
                                }
                                else
                                {
                                    innercmd.Connection.Open();
                                    innercmd.ExecuteNonQuery();
                                    innercmd.Connection.Close();
                                    retInsert = true;
                                }
                            }
                        }
                        catch
                        {
                            retInsert = false;
                        }
                    }
                }
            }
            catch
            {
                retInsert = false;
            }
            finally
            {
                dtForStock.Dispose();
            }
            return retInsert;
        }
    }
}
