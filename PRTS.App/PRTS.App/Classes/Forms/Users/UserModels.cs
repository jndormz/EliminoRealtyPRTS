using PRTS.App.Classes.Forms.UserPrivileges;

namespace PRTS.App.Classes.Forms.Users
{
    public class GetUsers {
        public long UserId { get; set; }
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public bool IsActive { get; set; }

        public GetRole UserRole { get; set; }

        public GetUserPrivileges UserPrivileges { get; set; }
    }
}
