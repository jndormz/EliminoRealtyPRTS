using PRTS.App.Classes.Forms.Login;
using System;
using System.Windows.Forms;
using PRTS.App.Classes;

namespace PRTS.App.Forms {

    public partial class frmLogIn : Form {

        public bool isLogIn;

        public frmLogIn() {
            InitializeComponent();
        }

        private void LogIn_Load(object sender, EventArgs e) {
        }

        private void BtnLogin_Click(object sender, EventArgs e) {

            LogIn();
        }

        private void BtnClose_Click(object sender, EventArgs e) {
            Dispose();
        }

        private void TxtUsername_Validating(object sender, System.ComponentModel.CancelEventArgs e) {
            if (string.IsNullOrEmpty(txtUsername.Text)) {
                e.Cancel = true;
                txtUsername.Focus();
                loginErrorProvider.SetError(txtUsername, ModGlobal.ErrRequiredField);
            }
        }

        private void TxtPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e) {
            if (string.IsNullOrEmpty(txtPassword.Text)) {
                e.Cancel = true;
                txtPassword.Focus();
                loginErrorProvider.SetError(txtPassword, ModGlobal.ErrRequiredField);
            }
        }

        private void FrmLogIn_KeyUp(object sender, KeyEventArgs e) {

            if (e.KeyCode == Keys.Enter && txtPassword.Focused) {
                LogIn();
            }
        }

        #region Functions

        private void LogIn() {

            if (!ValidateChildren(ValidationConstraints.Enabled)) {
                return;
            }

            var loginLogic = new LoginLogic();

            var userLogin = loginLogic.UserLogin(txtUsername.Text, txtPassword.Text);

            if (!userLogin.Succeed)
            {
                MessageBox.Show(userLogin.Message[0], @"Input error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                isLogIn = true;
                ModGlobal.UserId = userLogin.Data.UserId;
                ModGlobal.User = string.Concat(userLogin.Data.FirstName,
                    " ",
                    !string.IsNullOrEmpty(userLogin.Data.MiddleName) ? string.Concat(userLogin.Data.MiddleName.Substring(0, 1), ".") : "",
                    " ",
                    userLogin.Data.LastName);
                ModGlobal.RoleId = userLogin.Data.UserRole.RoleId;
                ModGlobal.Role = userLogin.Data.UserRole.Role;

                ModGlobal.PrivAreaProfile = userLogin.Data.UserPrivileges.AreaProfile;
                ModGlobal.PrivLots = userLogin.Data.UserPrivileges.Lots;
                ModGlobal.PrivAgents = userLogin.Data.UserPrivileges.Agents;
                ModGlobal.PrivClients = userLogin.Data.UserPrivileges.Clients;
                ModGlobal.PrivIncomingPayments = userLogin.Data.UserPrivileges.IncomingPayments;
                ModGlobal.PrivOutgoingPayments = userLogin.Data.UserPrivileges.OutgoingPayments;
                ModGlobal.PrivReports = userLogin.Data.UserPrivileges.Reports;
                ModGlobal.PrivUserPrivileges = userLogin.Data.UserPrivileges.UserPrivileges;
                ModGlobal.PrivUserManagement = userLogin.Data.UserPrivileges.UserManagement;

                Dispose();
            }
        }

        #endregion
    }
}
