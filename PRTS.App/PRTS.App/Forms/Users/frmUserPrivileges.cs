namespace PRTS.App.Forms.Users {

    using Classes;
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;

    public partial class FrmUserPrivileges : Form {

        private readonly long _roleId;
        private readonly DbEntities _db = new DbEntities();
        private readonly ModGlobal.FormStatus _formStatus;

        public bool IsSaved;

        public FrmUserPrivileges(long roleId, ModGlobal.FormStatus formStatus) {
            InitializeComponent();

            _roleId = roleId;
            _formStatus = formStatus;
        }

        #region Events

        private void FrmUser_Load(object sender, EventArgs e) {

            LoadUserModules();

            LoadUserData();

            EnabledControls();
        }

        private void BtnClose_Click(object sender, EventArgs e) {
            Dispose();
        }

        private void Field_Validation(object sender, CancelEventArgs e) {
            if (string.IsNullOrEmpty((sender as TextBox)?.Text)) {
                e.Cancel = true;
                (sender as TextBox)?.Focus();
                UserErrorProvider.SetError(sender as TextBox ?? throw new InvalidOperationException(), ModGlobal.ErrRequiredField);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e) {

            if (!ValidateChildren(ValidationConstraints.Enabled)) {
                return;
            }

            var validationResult = ValidateValues();

            if (!string.IsNullOrEmpty(validationResult)) {
                MessageBox.Show(validationResult, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (MessageBox.Show(@"Are you sure you want to save this record?", @"Info", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information) == DialogResult.No) {

                return;
            }

            SaveUserPrivileges();

            Dispose();
        }

        #endregion

        #region Functions

        private void SaveUserPrivileges() {

            if (_formStatus == ModGlobal.FormStatus.IsNew) {
                var newId = Convert.ToInt32(_db.Roles.OrderByDescending(u => u.RoleId).FirstOrDefault()?.RoleId ?? 0) + 1;

                _db.Roles.Add(new Role {
                    RoleId = newId,
                    RoleName = txtRoleDescription.Text,
                    CreatedBy = ModGlobal.UserId,
                    CreatedAt = DateTime.Now
                });
            }
            else {
                var getRole = _db.Roles.FirstOrDefault(u => u.RoleId == _roleId);

                if (getRole == null) {
                    MessageBox.Show(@"Record not exist.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                getRole.RoleName = txtRoleDescription.Text;
                getRole.UpdatedBy = ModGlobal.UserId;
                getRole.UpdatedAt = DateTime.Now;
            }
            _db.SaveChanges();

            IsSaved = true;
        }

        private string ValidateValues() {
            var user = _db.Users.FirstOrDefault(u => u.UserName == txtRoleDescription.Text && u.UserId != _roleId);

            if (user != null) {
                return @"Role already exist.";

            }

            return null;
        }

        private void LoadUserData() {

            if (_roleId != 0) {

                var user = _db.Roles.FirstOrDefault(u => u.RoleId == _roleId);

                txtRoleDescription.Text = user?.RoleName;
            }
        }

        private void LoadUserModules() {

            var modules = 
                (from m in _db.Modules
                    select new {
                        Select = false,
                        m.ModuleName
                    }).ToList();

            dgvUserPrivileges.DataSource = modules;
        }

        private void EnabledControls() {

            if (_formStatus == ModGlobal.FormStatus.IsView) {
                btnSave.Visible = false;

                txtRoleDescription.ReadOnly = true;
            }
        }

        #endregion
    }
}
