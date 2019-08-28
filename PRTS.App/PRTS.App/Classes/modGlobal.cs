namespace PRTS.App.Classes {
    public class ModGlobal {

        public enum FormStatus {
            IsView = 0,
            IsNew = 1,
            IsEdit = 2,
            IsCancel = 3
        }

        //User info
        public static long? UserId;
        public static string User;
        public static int? RoleId;
        public static string Role;

        //User privileges
        public static bool PrivAreaProfile = true;
        public static bool PrivLots = true;
        public static bool PrivAgents = true;
        public static bool PrivClients = true;
        public static bool PrivIncomingPayments = true;
        public static bool PrivOutgoingPayments = true;
        public static bool PrivReports = true;
        public static bool PrivUserPrivileges = true;
        public static bool PrivUserManagement = true;

        //Module Ids
        public const long ModAreaProfileId = 1;
        public const long ModLotsId = 2;
        public const long ModAgentsId = 3;
        public const long ModClientsId = 4;
        public const long ModIncomingPaymentsId = 5;
        public const long ModOutgoingPaymentsId = 6;
        public const long ModReportsId = 7;
        public const long ModUserPrivilegesId = 8;
        public const long ModUserManagementId = 9;

        //Module names
        public const string ModAreaProfile = "Area profile";
        public const string ModLots = "Lots";
        public const string ModAgents = "Agents";
        public const string ModClients = "Clients";
        public const string ModIncomingPayments = "Incoming Payments";
        public const string ModOutgoingPayments = "Outgoing Payments";
        public const string ModReports = "Reports";
        public const string ModUserPrivileges = "User Privileges";
        public const string ModUserManagement = "User Management";

        //Validation
        public const string ErrRequiredField = "Required field.";


    }
}
