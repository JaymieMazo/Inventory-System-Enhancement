using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOI_Inventory_System
{


    
    class GlobalClass
    {

        private static string fname = "";

        public static string GlobalName
        {
            get { return fname; }
            set { fname = value; }
        }

        private static string uname="";

        public static string GlobalUser
        {
            get { return uname; }
            set { uname = value; }
        }

        private static bool validation = false;
        public static bool Authenticated
        {
            get { return validation; }
            set { validation = value; }
        }

        private static string cid = "";

        public static string GlobalCategoryId
        {
            get { return cid; }
            set { cid = value; }
        }

        private static string scid = "";

        public static string GlobalSubcategoryId
        {
            get { return scid; }
            set { scid = value; }
        }

        private static string aid = "";

        public static string GlobalArticleId
        {
            get { return aid; }
            set { aid = value; }
        }


        private static string Dtime = "";

        public static string GlobalDateTime
        {
            get { return Dtime; }
            set { Dtime = value; }
        }

        private static string SCatId = "";

        public static string GlobalSupCatId
        {
            get { return SCatId; }
            set { SCatId = value; }
        }

        private static string SupId = "";

        public static string GlobalSupplierId
        {
            get { return SupId; }
            set { SupId = value; }
        }


        private static string ItemId = "";

        public static string GlobalItemId
        {
            get { return ItemId; }
            set { ItemId = value; }
        }


        private static string IARNo = "";

        public static string GlobalIARNo
        {
            get { return IARNo; }
            set { IARNo = value; }
        }


        private static string ExItemId = "";

        public static string GlobalExItemId
        {
            get { return ExItemId; }
            set { ExItemId = value; }
        }

        private static string ServiceId = "";

        public static string GlobalServiceId
        {
            get { return ServiceId; }
            set { ServiceId = value; }
        }

        private static string DivisionId = "";

        public static string GlobalDivisionId
        {
            get { return DivisionId; }
            set { DivisionId = value; }
        }

        private static string EmployeeId = "";

        public static string GlobalEmployeeId
        {
            get { return EmployeeId; }
            set { EmployeeId = value; }
        }


        private static string OfficerId = "";

        public static string GlobalOfficerId
        {
            get { return OfficerId; }
            set { OfficerId = value; }
        }

        private static string InvItemId = "";

        public static string GlobalInvItemId
        {
            get { return InvItemId; }
            set { InvItemId = value; }
        }

        private static string OICId = "";

        public static string GlobalOICId
        {
            get { return OICId; }
            set { OICId = value; }
        }

        private static string RecItemId = "";

        public static string GlobalRecItemId
        {
            get { return RecItemId; }
            set { RecItemId = value; }
        }


        private static string UsersId = "";

        public static string GlobalUsersId
        {
            get { return UsersId; }
            set { UsersId = value; }
        }

        private static string UserType = "";

        public static string GlobalUserType
        {
            get { return UserType; }
            set { UserType = value; }
        }


        private static bool IsLicense;
        public static bool GlobalIsLicense
        {
            get { return IsLicense; }
            set { IsLicense = value; }
        }

        private static string pullOutIds = "";
        public static string GlobalPullOut_ID
        {
            get { return pullOutIds; }
            set { pullOutIds = value; }
        }
        
        private static string pullOutReceiver = "";
        public static string G_PullPOut_ReceivedBy
        {
            get { return pullOutReceiver; }
            set { pullOutReceiver = value; }
        }

        private static string ReceivedBy = "";
        public static string Global_ReceivedBy
        {
            get { return ReceivedBy; }
            set { ReceivedBy = value; }
        }

        private static string Remarks = "";
        public static string Global_Remarks
        {
            get { return Remarks; }
            set { Remarks = value; }
        }

    }


}
