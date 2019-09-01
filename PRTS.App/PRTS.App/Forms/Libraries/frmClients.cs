namespace PRTS.App.Forms.Libraries {

    using Classes;
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;

    public partial class FrmClients : Form {

        private readonly long _clientId;
        private readonly DbEntities _db = new DbEntities();
        private readonly ModGlobal.FormStatus _formStatus;

        public bool IsSaved;

        public FrmClients(long clientId, ModGlobal.FormStatus formStatus) {
            InitializeComponent();

            _clientId = clientId;
            _formStatus = formStatus;
        }

        #region Events

        private void FrmUser_Load(object sender, EventArgs e) {

            LoadClientData();

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

            SaveClient();

            Dispose();
        }

        #endregion

        #region Functions

        private void SaveClient() {

            if (_formStatus == ModGlobal.FormStatus.IsNew) {
                var newId = Convert.ToInt64(_db.Clients.OrderByDescending(u => u.ClientId).FirstOrDefault()?.ClientId ?? 0) + 1;

                _db.Clients.Add(new Client {
                    ClientId = newId,
                    FirstName = txtFirstName.Text,
                    MiddleName = txtMiddleName.Text,
                    LastName = txtLastName.Text,
                    Address = txtAddress.Text,
                    Contact1 = txtContact1.Text,
                    Contact2 = txtContact2.Text,
                    IsActive = cbIsActive.Checked,
                    CreatedBy = ModGlobal.UserId,
                    CreatedAt = DateTime.Now
                });
            }
            else {
                var getClient = _db.Clients.FirstOrDefault(u => u.ClientId == _clientId);

                if (getClient == null) {
                    MessageBox.Show(@"Record not exist.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                getClient.FirstName = txtFirstName.Text;
                getClient.MiddleName = txtMiddleName.Text;
                getClient.LastName = txtLastName.Text;
                getClient.Address = txtAddress.Text;
                getClient.Contact1 = txtContact1.Text;
                getClient.Contact2 = txtContact2.Text;
                getClient.IsActive = cbIsActive.Checked;
                getClient.UpdatedBy = ModGlobal.UserId;
                getClient.UpdatedAt = DateTime.Now;
            }
            _db.SaveChanges();

            IsSaved = true;
        }

        private string ValidateValues() {
            var client = _db.Clients.FirstOrDefault(u => 
                string.Concat(u.FirstName.Trim(), u.LastName.Trim()) == 
                    string.Concat(txtFirstName.Text.Trim(), txtLastName.Text.Trim()) && 
                        u.ClientId != _clientId);

            if (client != null) {
                return @"Client already exist.";
            }

            return null;
        }

        private void LoadClientData() {

            if (_clientId != 0) {

                var user = _db.Clients.FirstOrDefault(u => u.ClientId == _clientId);

                txtFirstName.Text = user?.FirstName;
                txtMiddleName.Text = user?.MiddleName;
                txtLastName.Text = user?.LastName;
                txtAddress.Text = user?.Address;
                txtContact1.Text = user?.Contact1;
                txtContact2.Text = user?.Contact2;
                cbIsActive.Checked = user?.IsActive ?? true;
            }
        }

        private void EnabledControls() {

            if (_formStatus == ModGlobal.FormStatus.IsView) {
                btnSave.Visible = false;

                txtFirstName.ReadOnly = true;
                txtMiddleName.ReadOnly = true;
                txtLastName.ReadOnly = true;
                txtAddress.ReadOnly = true;
                txtContact1.ReadOnly = true;
                txtContact2.ReadOnly = true;
                cbIsActive.Enabled = false;
            }
        }

        #endregion
    }
}
