namespace PRTS.App.Classes.Forms.UserPrivileges {
    public class GetRole {
        public int RoleId { get; set; }
        public string Role { get; set; }
    }

    public class GetUserPrivileges {

        public bool AreaProfile { get; set; }

        public bool Lots { get; set; }

        public bool Agents { get; set; }

        public bool Clients { get; set; }

        public bool IncomingPayments { get; set; }

        public bool OutgoingPayments { get; set; }

        public bool Reports { get; set; }

        public bool UserPrivileges { get; set; }

        public bool UserManagement { get; set; }
    }
}
