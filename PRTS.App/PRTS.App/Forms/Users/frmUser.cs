namespace PRTS.App.Forms.Users {

    using Classes;
    using Classes.Helpers;
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;

    public partial class FrmUser : Form {

        private readonly long _userId;
        private readonly DbEntities _db = new DbEntities();
        private readonly ModGlobal.FormStatus _formStatus;

        public bool IsSaved;

        public FrmUser(long userId, ModGlobal.FormStatus formStatus) {
            InitializeComponent();

            _userId = userId;
            _formStatus = formStatus;
        }

        #region Events

        private void FrmUser_Load(object sender, EventArgs e) {

            LoadRoleData();

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

            SaveUser();

            Dispose();
        }

        #endregion

        #region Functions

        private void SaveUser() {

            var comboItem = (ComboBoxItem)cmbRole.SelectedItem;

            if (_formStatus == ModGlobal.FormStatus.IsNew) {
                var newId = Convert.ToInt64(_db.Users.OrderByDescending(u => u.UserId).FirstOrDefault()?.UserId ?? 0) + 1;

                _db.Users.Add(new User {
                    UserId = newId,
                    FirstName = txtFirstName.Text,
                    MiddleName = txtMiddleName.Text,
                    LastName = txtLastName.Text,
                    UserName = txtUsername.Text,
                    Password = txtPassword.Text,
                    RoleId = Convert.ToInt32(comboItem.value),
                    IsActive = cbIsActive.Checked,
                    CreatedBy = ModGlobal.UserId,
                    CreatedAt = DateTime.Now
                });
            }
            else {
                var getUser = _db.Users.FirstOrDefault(u => u.UserId == _userId);

                if (getUser == null) {
                    MessageBox.Show(@"Record not exist.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                getUser.FirstName = txtFirstName.Text;
                getUser.MiddleName = txtMiddleName.Text;
                getUser.LastName = txtLastName.Text;
                getUser.UserName = txtUsername.Text;
                getUser.Password = txtPassword.Text;
                getUser.RoleId = Convert.ToInt32(comboItem.value);
                getUser.IsActive = cbIsActive.Checked;
                getUser.UpdatedBy = ModGlobal.UserId;
                getUser.UpdatedAt = DateTime.Now;
            }
            _db.SaveChanges();

            IsSaved = true;
        }

        private string ValidateValues() {
            var user = _db.Users.FirstOrDefault(u => u.UserName == txtUsername.Text && u.UserId != _userId);

            if (user != null) {
                return @"UserName already exist.";

            }

            if (txtPassword.Text != txtConfirmPassword.Text) {
                return @"Password doesn't match to its confirmation.";
            }

            return null;
        }

        private void LoadRoleData() {

            var privileges = _db.Roles.Where(r => r.RoleId != 0).ToList();

            foreach (var privilege in privileges) {
                cmbRole.Items.Add(new ComboBoxItem(Convert.ToString(privilege.RoleName), Convert.ToString(privilege.RoleId)));
            }

            cmbRole.ValueMember = "value";
            cmbRole.DisplayMember = "name";

            if (_formStatus == ModGlobal.FormStatus.IsNew) {
                cmbRole.SelectedIndex = 0;
            }
        }

        private void LoadUserData() {

            if (_userId != 0) {

                var user = _db.Users.FirstOrDefault(u => u.UserId == _userId);

                txtFirstName.Text = user?.FirstName;
                txtMiddleName.Text = user?.MiddleName;
                txtLastName.Text = user?.LastName;
                txtUsername.Text = user?.UserName;
                txtPassword.Text = user?.Password;
                txtConfirmPassword.Text = user?.Password;
                cbIsActive.Checked = user?.IsActive ?? true;
                cmbRole.SelectedIndex = user?.RoleId - 1 ?? 0;
            }
        }

        private void EnabledControls() {

            if (_formStatus == ModGlobal.FormStatus.IsView) {
                btnSave.Visible = false;
                txtConfirmPassword.Visible = false;
                lblConfirmPassword.Visible = false;

                txtFirstName.ReadOnly = true;
                txtMiddleName.ReadOnly = true;
                txtLastName.ReadOnly = true;
                txtUsername.ReadOnly = true;
                txtPassword.ReadOnly = true;
                cbIsActive.Enabled = false;
                cmbRole.Enabled = false;
            }
        }

        #endregion
    }
}
