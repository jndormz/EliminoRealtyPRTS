using System.Collections.Generic;
using System.Linq;
using PRTS.App.Classes.Forms.UserPrivileges;
using PRTS.App.Classes.Forms.Users;

namespace PRTS.App.Classes.Forms.Login {
    public class LoginLogic {
        private readonly List<string> _infos = new List<string>();

        public ResponseModel<GetUsers> UserLogin(string userName, string password) {
            var db = new DbEntities();

            var user = db.Users.FirstOrDefault(u => u.UserName == userName && u.Password == password);

            if (user == null) {

                _infos.Add("User not found.");
                return new ResponseModel<GetUsers> {Message = _infos};
            }

            if (user.IsActive == false) {

                _infos.Add("User is deactivated. Please contact the administrator.");
                return new ResponseModel<GetUsers> { Message = _infos };
            }

            var role = db.Roles.FirstOrDefault(r => r.RoleId == user.RoleId);

            if (role == null) {

                _infos.Add("User role not set.");
                return new ResponseModel<GetUsers> { Message = _infos };
            }

            var userPriv = db.UserPrivileges.Where(r => r.RoleId == role.RoleId).ToList();

            return new ResponseModel<GetUsers> { Succeed = true, Data = new GetUsers {
                UserId = user.UserId,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                UserRole = new GetRole {
                    RoleId = role.RoleId,
                    Role = role.RoleName
                },
                UserPrivileges = new GetUserPrivileges {
                    AreaProfile = userPriv.FirstOrDefault(p => p.ModuleId == ModGlobal.ModAreaProfileId)?.IsVisible ?? false,
                    Lots = userPriv.FirstOrDefault(p => p.ModuleId == ModGlobal.ModLotsId)?.IsVisible ?? false,
                    Agents = userPriv.FirstOrDefault(p => p.ModuleId == ModGlobal.ModAgentsId)?.IsVisible ?? false,
                    Clients = userPriv.FirstOrDefault(p => p.ModuleId == ModGlobal.ModClientsId)?.IsVisible ?? false,
                    Acquisition = userPriv.FirstOrDefault(p => p.ModuleId == ModGlobal.ModAcquisitionId)?.IsVisible ?? false,
                    IncomingPayments = userPriv.FirstOrDefault(p => p.ModuleId == ModGlobal.ModIncomingPaymentsId)?.IsVisible ?? false,
                    OutgoingPayments = userPriv.FirstOrDefault(p => p.ModuleId == ModGlobal.ModOutgoingPaymentsId)?.IsVisible ?? false,
                    Reports = userPriv.FirstOrDefault(p => p.ModuleId == ModGlobal.ModReportsId)?.IsVisible ?? false,
                    UserPrivileges = userPriv.FirstOrDefault(p => p.ModuleId == ModGlobal.ModUserPrivilegesId)?.IsVisible ?? false,
                    UserManagement = userPriv.FirstOrDefault(p => p.ModuleId == ModGlobal.ModUserManagementId)?.IsVisible ?? false
                }
            }};
        }
    }
}
