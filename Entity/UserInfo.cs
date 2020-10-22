using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class UserInfo
    {
        /// <summary>
        /// userId
        /// </summary>
        private int userId = 0;
        /// <summary>
        /// user_Name
        /// </summary>
        private string user_Name = string.Empty;
        /// <summary>
        /// password
        /// </summary>
        private string password = string.Empty;
        /// <summary>
        /// address 
        /// </summary>
        private string address = string.Empty;
        /// <summary>
        /// sex 
        /// </summary>
        private string sex = string.Empty;
        /// <summary>
        /// emailId
        /// </summary>
        private string emailId = string.Empty;
        /// <summary>
        /// phoneNo 
        /// </summary>
        private string phoneNo = string.Empty;
        /// <summary>
        /// isAdmin 
        /// </summary>
        private bool isAdmin = false;
        /// <summary>
        /// isEdit Access.
        /// </summary>
        private bool isEdit = false;
        /// <summary>
        /// isDelete Access.
        /// </summary>
        private bool isDelete = false;
        /// <summary>
        /// IsDeactive
        /// </summary>
        private bool isDeactive = false;
        /// <summary>
        /// entUserId
        /// </summary>
        private int entUserId = 0;
        /// <summary>
        /// entDateTime
        /// </summary>
        private DateTime entDateTime = DateTime.Now;
        /// <summary>
        /// upUserId 
        /// </summary>
        private int upUserId = 0;
        /// <summary>
        /// upDateTime 
        /// </summary>
        private DateTime upDateTime = DateTime.Now;
        /// <summary>
        /// currentYearId
        /// </summary>
        private int currentYearId = 0;
        /// <summary>
        /// UserId Set Form the data base if old else zero. it is int.
        /// </summary>
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        /// <summary>
        /// user name set from the data base if old else set from the text box. it is string.
        /// </summary>
        public string User_Name
        {
            get { return user_Name; }
            set { user_Name = value; }
        }
        /// <summary>
        /// password is string value.
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        /// <summary>
        /// Address as string value.
        /// </summary>
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        /// <summary>
        /// Sex like male .. so it's string.
        /// </summary>
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        /// <summary>
        /// Emaild as string.
        /// </summary>
        public string EmailId
        {
            get { return emailId; }
            set { emailId = value; }
        }
        /// <summary>
        /// phone number as string.
        /// </summary>
        public string PhoneNo
        {
            get { return phoneNo; }
            set { phoneNo = value; }
        }
        /// <summary>
        /// is admin as bool argument if do you set admin for the user.
        /// </summary>
        public bool IsAdmin
        {
            get { return isAdmin; }
            set { isAdmin = value; }
        }
        /// <summary>
        /// is edit if you want to set user can edit record then set tre else false.
        /// </summary>
        public bool IsEdit
        {
            get { return isEdit; }
            set { isEdit = value; }
        }
        /// <summary>
        /// is delete if you want to user can delete records from the data base then set true for that user else false.
        /// </summary>
        public bool IsDelete
        {
            get { return isDelete; }
            set { isDelete = value; }
        }
        /// <summary>
        /// is deactive if user left then set true else false so if true then user can not login into the system.
        /// </summary>
        public bool IsDeactive
        {
            get { return isDeactive; }
            set { isDeactive = value; }
        }
        /// <summary>
        /// entry user id for who was enter this reords.
        /// </summary>
        public int EntUserId
        {
            get { return entUserId; }
            set { entUserId = value; }
        }
        /// <summary>
        /// entry date time so which date and time user can enter this reords.
        /// </summary>
        public DateTime EntDateTime
        {
            get { return entDateTime; }
            set { entDateTime = value; }
        }
        /// <summary>
        /// it is same as entry user.
        /// </summary>
        public int UpUserId
        {
            get { return upUserId; }
            set { upUserId = value; }
        }
        /// <summary>
        /// it is same as entry date time.
        /// </summary>
        public DateTime UpDateTime
        {
            get { return upDateTime; }
            set { upDateTime = value; }
        }
        /// <summary>
        /// CurrentYearId
        /// </summary>
        public int CurrentYearId
        {
            get { return currentYearId; }
            set { currentYearId = value; }
        }
    }
}
