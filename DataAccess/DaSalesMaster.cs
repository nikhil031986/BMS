using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class DaSalesMaster
    {
        public static Entity.SalesMaster getsalesMaster(string invoiceNumber)
        {
            Entity.SalesMaster retSalesMaster = new Entity.SalesMaster();
            DataTable dtSalesMaster = DataAccess.DaItemMaster.getRecordTable("SELECT TOP 1 * FROM SalesMst WHERE SalesMst.InvoiceNo=" + invoiceNumber);
            if (dtSalesMaster != null)
            {
                DataRow firstRow = dtSalesMaster.AsEnumerable().FirstOrDefault();
                retSalesMaster=clsComModile.ToObject<Entity.SalesMaster>(firstRow);
            }
            return retSalesMaster;
        }
        public static bool deleteSales(int salesMaserId)
        {
            bool deleteValue = false;
            try
            {
                OleDbTransaction transaction = null;
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = UserDataAccess.DataBaseConnection();
                    cmd.CommandType = CommandType.Text;
                    if (salesMaserId > 0)
                    {
                        cmd.CommandText = "DELETE FROM SalesMst WHERE SalesMstId = @SalesMstId";
                    }
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@SalesMstId", salesMaserId);
                    if (cmd.Connection.State == ConnectionState.Open)
                    {
                        cmd.Connection.Close();
                    }
                    cmd.Connection.Open();
                    transaction = cmd.Connection.BeginTransaction(IsolationLevel.ReadCommitted);
                    cmd.Transaction = transaction;
                    if (salesMaserId > 0)
                    {
                        bool tranExcuate = false;
                        try
                        {
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                            cmd.CommandText = "UPDATE SalesDetail INNER JOIN StockMst ON SalesDetail.ItemId = StockMst.ItemId "
                                               +"SET StockMst.SalesStock = (StockMst.SalesStock - SalesDetail.Qty), "
                                               +"StockMst.CurrStock = (StockMst.PurStock - (StockMst.SalesStock - SalesDetail.Qty)) "
                                               +"WHERE(((SalesDetail.SalesMstId) = @SalesMstId))";
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@SalesMstId", salesMaserId);
                            cmd.ExecuteNonQuery();
                            tranExcuate = true;
                        }
                        catch
                        {
                            tranExcuate = false;
                        }
                        try
                        {
                            cmd.CommandText = "DELETE FROM SalesDetail WHERE SalesMstId = @SalesMstId";
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@SalesMstId", salesMaserId);
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
        public static bool insertSalesMaster(Entity.SalesMaster salesMaster, DataTable dtSalesDetails, string removesalesDetailsId, Entity.UserInfo currentUser)
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
                    if (salesMaster.SalesMstId == 0)
                    {
                        cmd.CommandText = "INSERT INTO [SalesMst] ([InvoiceNo],[SalesDate],PartyName,[Desc],Total_Amount,Dis_Amount,Sales_Amount,EntUserId,EntDateTime,UpUserId,UpDateTime,Year_Id) VALUES (@InvoiceNo,@SalesDate,@PartyName,@Desc,@Total_Amount,@Dis_Amount,@Sales_Amount,@EntUserId,@EntDateTime,@UpUserId,@UpDateTime,@Year_Id)";
                    }
                    else
                    {
                        cmd.CommandText = "UPDATE [SalesMst] SET [SalesMst].[InvoiceNo]=@InvoiceNo,[SalesMst].[SalesDate]=@SalesDate,[SalesMst].PartyName=@PartyName,[SalesMst].[Desc]=@Desc,[SalesMst].Total_Amount=@Total_Amount,[SalesMst].Dis_Amount=@Dis_Amount,[SalesMst].Sales_Amount=@Sales_Amount,[SalesMst].UpUserId=@UpUserId,[SalesMst].UpDateTime=@UpDateTime,Year_Id=@Year_Id WHERE((([SalesMst].SalesMstId) = @SalesMstId))";
                    }
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@InvoiceNo", salesMaster.InvoiceNo);
                    cmd.Parameters.AddWithValue("@SalesDate", salesMaster.SalesDate.ToShortDateString());
                    cmd.Parameters.AddWithValue("@PartyName", salesMaster.PartyName);
                    cmd.Parameters.AddWithValue("@Desc", salesMaster.Desc);
                    cmd.Parameters.AddWithValue("@Total_Amount", salesMaster.Total_Amount);
                    cmd.Parameters.AddWithValue("@Dis_Amount", salesMaster.Dis_Amount);
                    cmd.Parameters.AddWithValue("@Sales_Amount", salesMaster.Sales_Amount);
                    cmd.Parameters.AddWithValue("@UpUserId", currentUser.UserId);
                    cmd.Parameters.AddWithValue("@UpDateTime", DateTime.Now.ToShortDateString());
                    
                    if (salesMaster.SalesMstId == 0)
                    {                        
                        cmd.Parameters.AddWithValue("@EntUserId", currentUser.UserId);
                        cmd.Parameters.AddWithValue("@EntDateTime", DateTime.Now.ToShortDateString());
                        cmd.Parameters.AddWithValue("@Year_Id", currentUser.CurrentYearId);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Year_Id", currentUser.CurrentYearId);
                        cmd.Parameters.AddWithValue("@SalesMstId", salesMaster.SalesMstId);
                    }
                    if (cmd.Connection.State == ConnectionState.Open)
                    {
                        cmd.Connection.Close();
                    }
                    cmd.Connection.Open();
                    transaction = cmd.Connection.BeginTransaction(IsolationLevel.ReadCommitted);
                    cmd.Transaction = transaction;
                    if (salesMaster.SalesMstId== 0)
                    {
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        cmd.CommandText = queery;
                        salesMaster.SalesMstId = (int)cmd.ExecuteScalar();
                        bool stockInsert = insertUpdateSalesDetails(dtSalesDetails, salesMaster.SalesMstId, currentUser);
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
                        bool stockInsert = insertUpdateSalesDetails(dtSalesDetails, salesMaster.SalesMstId, currentUser);
                        if (!stockInsert)
                        {
                            transaction.Rollback();
                        }
                        else
                        {
                            if (removesalesDetailsId != string.Empty)
                            {
                                stockInsert = deleteSalesDetails(removesalesDetailsId);
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
            catch (Exception ex)
            {
                insetUpdateSucess = false;
            }
            return insetUpdateSucess;
        }
        private static bool deleteSalesDetails(string removesalesDetailsId)
        {
            bool deletedPurchaseDetails = false;
            if (DataAccess.DaItemMaster.deleteSalesStock(removesalesDetailsId))
            {
                OleDbTransaction transaction = null;
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    try
                    {
                        cmd.Connection = UserDataAccess.DataBaseConnection();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "DELETE * FROM [SalesDetail] WHERE [SalesDetail].SalesDetailId IN (@SalesDetailId)";
                        cmd.Parameters.AddWithValue("@SalesDetailId", removesalesDetailsId);
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
        private static bool insertUpdateSalesDetails(DataTable dtsalesDetails, int salesMasterId, Entity.UserInfo currentUser)
        {
            bool insetPurchaseDetails = false;
            dtsalesDetails.AsEnumerable().ToList().ForEach(purDetails =>
            {
                if (purDetails.RowState != DataRowState.Deleted)
                {
                    int prevQuntity = 0;
                    OleDbTransaction transaction = null;
                    Entity.SalesDetails SalesDetails = new Entity.SalesDetails();
                    SalesDetails.SalesDetailId = purDetails.Field<int>("Sales_Details_Id");
                    SalesDetails.SalesMstId = salesMasterId;
                    SalesDetails.ItemId = purDetails.Field<int>("ItemId");
                    SalesDetails.Qty = purDetails.Field<int>("Quantity");
                    SalesDetails.Rate = purDetails.Field<decimal>("Rate");
                    SalesDetails.Amount = purDetails.Field<decimal>("Total_Rate");
                    SalesDetails.Disc = Convert.ToDecimal(purDetails.Field<int>("Disc"));
                    SalesDetails.DiscPer = purDetails.Field<int>("DiscPer");
                    prevQuntity = purDetails.Field<int>("PQuantity");
                    if (SalesDetails.Qty > 0)
                    {
                        using (OleDbCommand cmd = new OleDbCommand())
                        {
                            try
                            {
                                cmd.Connection = UserDataAccess.DataBaseConnection();
                                cmd.CommandType = CommandType.Text;
                                if (SalesDetails.SalesDetailId == 0)
                                {
                                    cmd.CommandText = "INSERT INTO [SalesDetail] ([SalesMstId],[ItemId],[Qty],[Rate],[Disc],Amount,[DiscPer]) VALUES (@SalesMstId,@ItemId,@Qty,@Rate,@Disc,@Amount,@discPer)";
                                }
                                else
                                {
                                    cmd.CommandText = "UPDATE [SalesDetail] SET [SalesDetail].[SalesMstId]=@PurMstId,[SalesDetail].[ItemId]=@ItemId,[SalesDetail].[Qty]=@Qty,[SalesDetail].[Rate]=@Rate,[SalesDetail].[Disc]=@Dis,[SalesDetail].Amount=@Amount,[SalesDetail].[DiscPer]=@discPer WHERE((([SalesDetail].SalesDetailId) = @SalesDetailId))";
                                }
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@SalesMstId", SalesDetails.SalesMstId);
                                cmd.Parameters.AddWithValue("@ItemId", SalesDetails.ItemId);
                                cmd.Parameters.AddWithValue("@Qty", SalesDetails.Qty);
                                cmd.Parameters.AddWithValue("@Rate", SalesDetails.Rate);
                                cmd.Parameters.AddWithValue("@Disc", SalesDetails.Disc);
                                cmd.Parameters.AddWithValue("@Amount", SalesDetails.Amount);
                                cmd.Parameters.AddWithValue("@discPer", SalesDetails.DiscPer);
                                if (SalesDetails.SalesDetailId > 0)
                                {
                                    cmd.Parameters.AddWithValue("@SalesDetailId", SalesDetails.SalesDetailId);
                                }
                                if (cmd.Connection.State == ConnectionState.Open)
                                {
                                    cmd.Connection.Close();
                                }
                                cmd.Connection.Open();
                                transaction = cmd.Connection.BeginTransaction(IsolationLevel.ReadCommitted);
                                cmd.Transaction = transaction;
                                cmd.ExecuteNonQuery();
                                bool updateStock = DataAccess.DaItemMaster.updateSalesStock(SalesDetails.ItemId, SalesDetails.Qty, prevQuntity, currentUser);
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
