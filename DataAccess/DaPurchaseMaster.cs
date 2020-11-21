using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class DaPurchaseMaster
    {
        public static Entity.PurchaseMaster getpurchaseMaster(string invoiceNumber)
        {
            Entity.PurchaseMaster retpurchaseMaster = new Entity.PurchaseMaster();
            DataTable dtPurchaseMaster = DataAccess.DaItemMaster.getRecordTable("SELECT TOP 1 * FROM PurMst WHERE PurMst.InvoidNo='" + invoiceNumber + "'");
            if (dtPurchaseMaster != null)
            {
                DataRow firstRow = dtPurchaseMaster.AsEnumerable().FirstOrDefault();
                if (firstRow != null)
                {
                    retpurchaseMaster = clsComModile.ToObject<Entity.PurchaseMaster>(firstRow);
                }
            }
            return retpurchaseMaster;
        }
        public static bool deletePurchase(int purchaseMasterId)
        {
            bool deleteValue = false;
            try
            {
                OleDbTransaction transaction = null;
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = UserDataAccess.DataBaseConnection();
                    cmd.CommandType = CommandType.Text;
                    if (purchaseMasterId > 0)
                    {
                        cmd.CommandText = "DELETE FROM PurMst WHERE PurMstId = @PurMstId";
                    }
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@PurMstId", purchaseMasterId);
                    if (cmd.Connection.State == ConnectionState.Open)
                    {
                        cmd.Connection.Close();
                    }
                    cmd.Connection.Open();
                    transaction = cmd.Connection.BeginTransaction(IsolationLevel.ReadCommitted);
                    cmd.Transaction = transaction;
                    if (purchaseMasterId > 0)
                    {
                        bool tranExcuate = false;
                        try
                        {
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                            cmd.CommandText = "UPDATE PurDetail INNER JOIN StockMst ON PurDetail.ItemId = StockMst.ItemId "
                                               + "SET StockMst.PurStock = (StockMst.PurStock - PurDetail.Qty),"
                                               + " StockMst.CurrStock = ((StockMst.PurStock - PurDetail.Qty) - StockMst.SalesStock) "
                                               + " WHERE PurDetail.PurMstId = @PurMstId";
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@PurMstId", purchaseMasterId);
                            cmd.ExecuteNonQuery();
                            tranExcuate = true;
                        }
                        catch
                        {
                            tranExcuate = false;
                        }
                        try
                        {
                            cmd.CommandText = "DELETE FROM PurDetail WHERE PurDetail.PurMstId = @PurMstId";
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@PurMstId", purchaseMasterId);
                            cmd.ExecuteNonQuery();
                            tranExcuate = true;
                        }
                        catch
                        {
                            tranExcuate = false;
                        }
                        if (!tranExcuate)
                        {
                            transaction.Rollback();
                            deleteValue = false;
                        }
                        else
                        {
                            transaction.Commit();
                            deleteValue = true;                            
                        }
                    }
                    cmd.Connection.Close();

                }
            }
            catch
            {
                deleteValue = false;
            }
            return deleteValue;
        }
        public static bool insertPurchaseMaster(Entity.PurchaseMaster purchaseMaster, DataTable dtPurchaseDetasils, string removepurchaseDetailsId, Entity.UserInfo currentUser)
        {
            bool insetUpdateSucess = false;
            try
            {
                OleDbTransaction transaction = null;
                string queery = "Select @@Identity";
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = UserDataAccess.DataBaseConnection();
                    cmd.CommandType = CommandType.Text;
                    if (purchaseMaster.PurMstId == 0)
                    {
                        cmd.CommandText = "INSERT INTO [PurMst] ([InvoidNo],[InvoiceDate],Partyid,[Desc],TotalAmount,Dis_Amount,Pur_Amount,FullPayment,Pay_Amount,Pen_Amoun,EntUserId,EntDateTime,UpUserId,UpDateTime) VALUES (@InvoidNo,@InvoiceDate,@Partyid,@Desc,@TotalAmount,@Dis_Amount,@Pur_Amount,@FullPayment,@Pay_Amount,@Pen_Amoun,@EntUserId,@EntDateTime,@UpUserId,@UpDateTime)";
                    }
                    else
                    {
                        cmd.CommandText = "UPDATE [PurMst] SET [PurMst].[InvoidNo]=@InvoidNo,[PurMst].[InvoiceDate]=@InvoiceDate,[PurMst].Partyid=@Partyid,[PurMst].[Desc]=@Desc,[PurMst].TotalAmount=@TotalAmount,[PurMst].Dis_Amount=@Dis_Amount,[PurMst].Pur_Amount=@Pur_Amount,[PurMst].FullPayment=@FullPayment,[PurMst].Pay_Amount=@Pay_Amount,[PurMst].Pen_Amoun=@Pen_Amoun,[PurMst].UpUserId=@UpUserId,[PurMst].UpDateTime=@UpDateTime WHERE((([PurMst].PurMstId) = @PurMstId))";
                    }
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@InvoidNo", purchaseMaster.InvoidNo);
                    cmd.Parameters.AddWithValue("@InvoiceDate", purchaseMaster.InvoiceDate.ToShortDateString());
                    cmd.Parameters.AddWithValue("@Partyid", purchaseMaster.Partyid);
                    cmd.Parameters.AddWithValue("@Desc", purchaseMaster.Desc);
                    cmd.Parameters.AddWithValue("@TotalAmount", purchaseMaster.TotalAmount);
                    cmd.Parameters.AddWithValue("@Dis_Amount", purchaseMaster.Dis_Amount);
                    cmd.Parameters.AddWithValue("@Pur_Amount", purchaseMaster.Pur_Amount);
                    cmd.Parameters.AddWithValue("@FullPayment", purchaseMaster.FullPayment);
                    cmd.Parameters.AddWithValue("@Pay_Amount", purchaseMaster.Pay_Amount);
                    cmd.Parameters.AddWithValue("@Pen_Amoun", purchaseMaster.Pen_Amoun);
                    cmd.Parameters.AddWithValue("@UpUserId", currentUser.UserId);
                    cmd.Parameters.AddWithValue("@UpDateTime", DateTime.Now.ToShortDateString());
                    if (purchaseMaster.PurMstId == 0)
                    {
                        cmd.Parameters.AddWithValue("@EntUserId", currentUser.UserId);
                        cmd.Parameters.AddWithValue("@EntDateTime", DateTime.Now.ToShortDateString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@PurMstId", purchaseMaster.PurMstId);
                    }
                    if (cmd.Connection.State == ConnectionState.Open)
                    {
                        cmd.Connection.Close();
                    }
                    cmd.Connection.Open();
                    transaction = cmd.Connection.BeginTransaction(IsolationLevel.ReadCommitted);
                    cmd.Transaction = transaction;
                    if (purchaseMaster.PurMstId == 0)
                    {
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        cmd.CommandText = queery;
                        purchaseMaster.PurMstId = (int)cmd.ExecuteScalar();
                        bool stockInsert = insertUpdatePurchaseDetails(dtPurchaseDetasils, purchaseMaster.PurMstId, currentUser);
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
                        bool stockInsert = insertUpdatePurchaseDetails(dtPurchaseDetasils, purchaseMaster.PurMstId, currentUser);
                        if (!stockInsert)
                        {
                            transaction.Rollback();
                        }
                        else
                        {
                            if (removepurchaseDetailsId != string.Empty)
                            {
                                stockInsert = deletePurchaseDetails(removepurchaseDetailsId);
                            }
                            if (stockInsert)
                            {
                                transaction.Commit();
                                
                            }
                            else
                            {
                                transaction.Rollback();
                            }
                        }
                    }
                    cmd.Connection.Close();
                    insetUpdateSucess = true;
                }
            }
            catch
            {
                insetUpdateSucess = false;
            }
            return insetUpdateSucess;
        }
        private static bool deletePurchaseDetails(string removepurchaseDetailsId)
        {
            bool deletedPurchaseDetails = false;
            if (DataAccess.DaItemMaster.deletePurchaseStock(removepurchaseDetailsId))
            {
                OleDbTransaction transaction = null;
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    try
                    {
                        cmd.Connection = UserDataAccess.DataBaseConnection();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "DELETE * FROM [PurDetail] WHERE [PurDetail].PurDetailId IN (@PurDetailIds)";
                        cmd.Parameters.AddWithValue("@PurDetailIds", removepurchaseDetailsId);
                        if (cmd.Connection.State == ConnectionState.Open)
                        {
                            cmd.Connection.Close();
                        }
                        cmd.Connection.Open();
                        transaction = cmd.Connection.BeginTransaction(IsolationLevel.ReadCommitted);
                        cmd.Transaction = transaction;
                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                        cmd.Connection.Close();
                        deletedPurchaseDetails = true;
                    }
                    catch (Exception ex)
                    {
                        if (transaction != null)
                        {
                            transaction.Rollback();
                        }
                        deletedPurchaseDetails = false;
                    }
                }
            }
            return deletedPurchaseDetails;
        }
        private static bool insertUpdatePurchaseDetails(DataTable dtpurchaseDetails, int purchaseMasterId, Entity.UserInfo currentUser)
        {
            bool insetPurchaseDetails = false;
            dtpurchaseDetails.AsEnumerable().ToList().ForEach(purDetails =>
           {
               if (purDetails.RowState != DataRowState.Deleted)
               {
                   int prevQuntity = 0;
                   OleDbTransaction transaction = null;
                   Entity.purch_details purchaseDetails = new Entity.purch_details();
                   purchaseDetails.PurDetailId = purDetails.Field<int>("Purcahse_Details_Id");
                   purchaseDetails.PurMstId = purchaseMasterId;
                   purchaseDetails.ItemId = purDetails.Field<int>("ItemId");
                   purchaseDetails.Qty = purDetails.Field<int>("Quantity");
                   purchaseDetails.Rate = purDetails.Field<decimal>("Rate");
                   purchaseDetails.Dis = purDetails.Field<int>("Disc");
                   purchaseDetails.Amount = purDetails.Field<decimal>("Total_Rate");
                   prevQuntity = purDetails.Field<int>("PQuantity");
                   if (purchaseDetails.Qty > 0)
                   {
                       using (OleDbCommand cmd = new OleDbCommand())
                       {
                           try
                           {
                               cmd.Connection = UserDataAccess.DataBaseConnection();
                               cmd.CommandType = CommandType.Text;
                               if (purchaseDetails.PurDetailId == 0)
                               {
                                   cmd.CommandText = "INSERT INTO [PurDetail] ([PurMstId],[ItemId],[Qty],[Rate],[Dis],Amount) VALUES (@PurMstId,@ItemId,@Qty,@Rate,@Dis,@Amount)";
                               }
                               else
                               {
                                   cmd.CommandText = "UPDATE [PurDetail] SET [PurDetail].[PurMstId]=@PurMstId,[PurDetail].[ItemId]=@ItemId,[PurDetail].[Qty]=@Qty,[PurDetail].[Rate]=@Rate,[PurDetail].[Dis]=@Dis,[PurDetail].Amount=@Amount WHERE((([PurDetail].PurDetailId) = @PurDetailId))";
                               }
                               cmd.Parameters.Clear();
                               cmd.Parameters.AddWithValue("@PurMstId", purchaseDetails.PurMstId);
                               cmd.Parameters.AddWithValue("@ItemId", purchaseDetails.ItemId);
                               cmd.Parameters.AddWithValue("@Qty", purchaseDetails.Qty);
                               cmd.Parameters.AddWithValue("@Rate", purchaseDetails.Rate);
                               cmd.Parameters.AddWithValue("@Dis", purchaseDetails.Dis);
                               cmd.Parameters.AddWithValue("@Amount", purchaseDetails.Amount);
                               if (purchaseDetails.PurDetailId > 0)
                               {
                                   cmd.Parameters.AddWithValue("@PurDetailId", purchaseDetails.PurDetailId);
                               }
                               if (cmd.Connection.State == ConnectionState.Open)
                               {
                                   cmd.Connection.Close();
                               }
                               cmd.Connection.Open();
                               transaction = cmd.Connection.BeginTransaction(IsolationLevel.ReadCommitted);
                               cmd.Transaction = transaction;
                               cmd.ExecuteNonQuery();
                               bool updateStock = DataAccess.DaItemMaster.updatePurchaseStock(purchaseDetails.ItemId, purchaseDetails.Qty, prevQuntity, currentUser);
                               transaction.Commit();
                               cmd.Connection.Close();
                               insetPurchaseDetails = true;
                           }
                           catch (Exception ex)
                           {
                               if (transaction != null)
                               {
                                   transaction.Rollback();
                               }
                               insetPurchaseDetails = false;
                           }
                       }
                   }
               }
           });
            return insetPurchaseDetails;
        }
    }
}
