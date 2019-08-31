namespace PRTS.App.Forms.Libraries {

    using Classes;
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;

    public partial class FrmAgents : Form {

        private readonly long _agentId;
        private readonly DbEntities _db = new DbEntities();
        private readonly ModGlobal.FormStatus _formStatus;

        public bool IsSaved;

        public FrmAgents(long agentId, ModGlobal.FormStatus formStatus) {
            InitializeComponent();

            _agentId = agentId;
            _formStatus = formStatus;
        }

        #region Events

        private void FrmUser_Load(object sender, EventArgs e) {

            LoadAgentData();

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

            SaveAgent();

            Dispose();
        }

        #endregion

        #region Functions

        private void SaveAgent() {

            if (_formStatus == ModGlobal.FormStatus.IsNew) {
                var newId = Convert.ToInt64(_db.Agents.OrderByDescending(u => u.AgentId).FirstOrDefault()?.AgentId ?? 0) + 1;

                _db.Agents.Add(new Agent {
                    AgentId = newId,
                    FirstName = txtFirstName.Text,
                    MiddleName = txtMiddleName.Text,
                    LastName = txtLastName.Text,
                    Contact = txtContact.Text,
                    IsActive = cbIsActive.Checked,
                    CreatedBy = ModGlobal.UserId
                });
            }
            else {
                var getAgent = _db.Agents.FirstOrDefault(u => u.AgentId == _agentId);

                if (getAgent == null) {
                    MessageBox.Show(@"Record not exist.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                getAgent.FirstName = txtFirstName.Text;
                getAgent.MiddleName = txtMiddleName.Text;
                getAgent.LastName = txtLastName.Text;
                getAgent.Contact = txtContact.Text;
                getAgent.IsActive = cbIsActive.Checked;
                getAgent.UpdatedBy = ModGlobal.UserId;
                getAgent.UpdatedAt = DateTime.Now;
            }
            _db.SaveChanges();

            IsSaved = true;
        }

        private string ValidateValues() {
            var agent = _db.Agents.FirstOrDefault(u => 
                string.Concat(u.FirstName.Trim(), u.LastName.Trim()) == 
                    string.Concat(txtFirstName.Text.Trim(), txtLastName.Text.Trim()) && 
                        u.AgentId != _agentId);

            if (agent != null) {
                return @"Agent already exist.";
            }

            return null;
        }

        private void LoadAgentData() {

            if (_agentId != 0) {

                var user = _db.Agents.FirstOrDefault(u => u.AgentId == _agentId);

                txtFirstName.Text = user?.FirstName;
                txtMiddleName.Text = user?.MiddleName;
                txtLastName.Text = user?.LastName;
                txtContact.Text = user?.Contact;
                cbIsActive.Checked = user?.IsActive ?? true;
            }
        }

        private void EnabledControls() {

            if (_formStatus == ModGlobal.FormStatus.IsView) {
                btnSave.Visible = false;

                txtFirstName.ReadOnly = true;
                txtMiddleName.ReadOnly = true;
                txtLastName.ReadOnly = true;
                txtContact.ReadOnly = true;
                cbIsActive.Enabled = false;
            }
        }

        #endregion
    }
}
