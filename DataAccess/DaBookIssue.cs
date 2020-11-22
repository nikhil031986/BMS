using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class DaBookIssue
    {
        public static Entity.BookIssue getbookIssueMaster(string issueNo, int bookMasterId = 0)
        {
            Entity.BookIssue retBookMaster = new Entity.BookIssue();
            DataTable dtPurchaseMaster = DataAccess.DaItemMaster.getRecordTable("SELECT TOP 1 * FROM BookIssue WHERE " + (bookMasterId > 0 ? "BookIssue.BookIssueId=" + bookMasterId.ToString() : "BookIssue.IssueNo=" + issueNo));
            if (dtPurchaseMaster != null)
            {
                DataRow firstRow = dtPurchaseMaster.AsEnumerable().FirstOrDefault();
                if (firstRow != null)
                {
                    retBookMaster = clsComModile.ToObject<Entity.BookIssue>(firstRow);
                }
            }
            return retBookMaster;
        }
        public static bool insertBookIssueMaster(Entity.BookIssue bookIssue, DataTable dtBookDetils, string removebookDetailsId, Entity.UserInfo currentUser)
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
                    if (bookIssue.BookIssueId == 0)
                    {
                        cmd.CommandText = "INSERT INTO [BookIssue] ([IssueNo],[IssueDate],[ReturnDate],[PartyName],MobileNo,Emailid,IsReturn,EntUserId,EntDateTime,UpUserId,UpDateTime) VALUES (@IssueNo,@IssueDate,@ReturnDate,@PartyName,@MobileNo,@Emailid,@IsReturn,@EntUserId,@EntDateTime,@UpUserId,@UpDateTime)";
                    }
                    else
                    {
                        cmd.CommandText = "UPDATE [BookIssue] SET [BookIssue].[IssueNo]=@IssueNo,[BookIssue].[IssueDate]=@IssueDate,[BookIssue].ReturnDate=@ReturnDate,[BookIssue].[PartyName]=@PartyName,[BookIssue].MobileNo=@MobileNo,[BookIssue].Emailid=@Emailid,[BookIssue].IsReturn=@IsReturn,[BookIssue].UpUserId=@UpUserId,[BookIssue].UpDateTime=@UpDateTime WHERE((([BookIssue].BookIssueId) = @BookIssueId))";
                    }
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@IssueNo", bookIssue.IssueNo);
                    cmd.Parameters.AddWithValue("@IssueDate", bookIssue.IssueDate.ToShortDateString());
                    cmd.Parameters.AddWithValue("@ReturnDate", bookIssue.ReturnDate.ToShortDateString());
                    cmd.Parameters.AddWithValue("@PartyName", bookIssue.PartyName);
                    cmd.Parameters.AddWithValue("@MobileNo", bookIssue.MobileNo);
                    cmd.Parameters.AddWithValue("@Emailid", bookIssue.Emailid);
                    cmd.Parameters.AddWithValue("@IsReturn", bookIssue.IsReturn);
                    cmd.Parameters.AddWithValue("@UpUserId", currentUser.UserId);
                    cmd.Parameters.AddWithValue("@UpDateTime", DateTime.Now.ToShortDateString());
                    if (bookIssue.BookIssueId == 0)
                    {
                        cmd.Parameters.AddWithValue("@EntUserId", currentUser.UserId);
                        cmd.Parameters.AddWithValue("@EntDateTime", DateTime.Now.ToShortDateString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@PurMstId", bookIssue.BookIssueId);
                    }
                    if (cmd.Connection.State == ConnectionState.Open)
                    {
                        cmd.Connection.Close();
                    }
                    cmd.Connection.Open();
                    transaction = cmd.Connection.BeginTransaction(IsolationLevel.ReadCommitted);
                    cmd.Transaction = transaction;
                    if (bookIssue.BookIssueId == 0)
                    {
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        cmd.CommandText = queery;
                        bookIssue.BookIssueId = (int)cmd.ExecuteScalar();
                        bool stockInsert = insertUpdateBookIssueDetails(dtBookDetils, bookIssue.BookIssueId, currentUser, bookIssue.IsReturn);
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
                        bool stockInsert = insertUpdateBookIssueDetails(dtBookDetils, bookIssue.BookIssueId, currentUser, bookIssue.IsReturn);
                        if (!stockInsert)
                        {
                            transaction.Rollback();
                        }
                        else
                        {
                            transaction.Commit();
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
        private static bool insertUpdateBookIssueDetails(DataTable dtbookIssueDetails, int purchaseMasterId, Entity.UserInfo currentUser, bool isReturn)
        {
            bool insetPurchaseDetails = false;
            dtbookIssueDetails.AsEnumerable().ToList().ForEach(purDetails =>
            {
                if (purDetails.RowState != DataRowState.Deleted)
                {
                    int prevQuntity = 0;
                    OleDbTransaction transaction = null;
                    Entity.BookIssueDetail purchaseDetails = new Entity.BookIssueDetail();
                    purchaseDetails.BookIssueDetailId = purDetails.Field<int>("BookIssueDetailId");
                    purchaseDetails.BookId = purchaseMasterId;
                    purchaseDetails.ItemId = purDetails.Field<int>("ItemId");
                    purchaseDetails.Qty = purDetails.Field<int>("Quantity");
                    prevQuntity = purDetails.Field<int>("PQuantity");
                    if (purchaseDetails.Qty > 0)
                    {
                        using (OleDbCommand cmd = new OleDbCommand())
                        {
                            try
                            {
                                cmd.Connection = UserDataAccess.DataBaseConnection();
                                cmd.CommandType = CommandType.Text;
                                if (purchaseDetails.BookIssueDetailId == 0)
                                {
                                    cmd.CommandText = "INSERT INTO [BookIssueDetail] ([BookId],[ItemId],[Qty]) VALUES (@PurMstId,@ItemId,@Qty)";
                                }
                                else
                                {
                                    cmd.CommandText = "UPDATE [BookIssueDetail] SET [BookIssueDetail].[BookId]=@BookId,[BookIssueDetail].[ItemId]=@ItemId,[BookIssueDetail].[Qty]=@Qty WHERE((([BookIssueDetail].BookIssueDetailId) = @BookIssueDetailId))";
                                }
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@BookId", purchaseDetails.BookId);
                                cmd.Parameters.AddWithValue("@ItemId", purchaseDetails.ItemId);
                                cmd.Parameters.AddWithValue("@Qty", purchaseDetails.Qty);
                                if (purchaseDetails.BookIssueDetailId > 0)
                                {
                                    cmd.Parameters.AddWithValue("@BookIssueDetailId", purchaseDetails.BookIssueDetailId);
                                }
                                if (cmd.Connection.State == ConnectionState.Open)
                                {
                                    cmd.Connection.Close();
                                }
                                cmd.Connection.Open();
                                transaction = cmd.Connection.BeginTransaction(IsolationLevel.ReadCommitted);
                                cmd.Transaction = transaction;
                                cmd.ExecuteNonQuery();
                                bool updateStock = false;
                                if (!isReturn)
                                {
                                    updateStock = DataAccess.DaItemMaster.updateSalesStock(purchaseDetails.ItemId, purchaseDetails.Qty, prevQuntity, currentUser);
                                }
                                else
                                {
                                    updateStock = DataAccess.DaItemMaster.updatePurchaseStock(purchaseDetails.ItemId, purchaseDetails.Qty, 0, currentUser);
                                }
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
