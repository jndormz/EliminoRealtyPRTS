namespace PRTS.App.Forms.Users {

    using Classes;
    using Classes.Helpers;
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;

    public partial class FrmUserPrivileges : Form {

        private readonly long _userId;
        private readonly DbEntities _db = new DbEntities();
        private readonly ModGlobal.FormStatus _formStatus;

        public bool IsSaved;

        public FrmUserPrivileges(long userId, ModGlobal.FormStatus formStatus) {
            InitializeComponent();

            _userId = userId;
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

            SaveUser();

            Dispose();
        }

        #endregion

        #region Functions

        private void SaveUser() {

            if (_formStatus == ModGlobal.FormStatus.IsNew) {
                var newId = Convert.ToInt64(_db.Users.OrderByDescending(u => u.UserId).FirstOrDefault()?.UserId ?? 0) + 1;

                _db.Users.Add(new User {
                    UserId = newId,
                    FirstName = txtRoleDescription.Text,
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

                getUser.FirstName = txtRoleDescription.Text;
                getUser.UpdatedBy = ModGlobal.UserId;
                getUser.UpdatedAt = DateTime.Now;
            }
            _db.SaveChanges();

            IsSaved = true;
        }

        private string ValidateValues() {
            var user = _db.Users.FirstOrDefault(u => u.UserName == txtRoleDescription.Text && u.UserId != _userId);

            if (user != null) {
                return @"Role already exist.";

            }

            return null;
        }

        private void LoadUserData() {

            if (_userId != 0) {

                var user = _db.Users.FirstOrDefault(u => u.UserId == _userId);

                txtRoleDescription.Text = user?.FirstName;
            }
        }

        private void LoadUserModules() {

            var modules = 
                (from m in _db.Modules
                    select new {
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
