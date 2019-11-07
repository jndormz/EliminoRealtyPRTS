namespace PRTS.App.Forms.Libraries {

    using Classes;
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;

    public partial class FrmAreaProfile : Form {

        private readonly long _areaId;
        private readonly DbEntities _db = new DbEntities();
        private readonly ModGlobal.FormStatus _formStatus;

        public bool IsSaved;

        public FrmAreaProfile(long areaId, ModGlobal.FormStatus formStatus) {
            InitializeComponent();

            _areaId = areaId;
            _formStatus = formStatus;
        }

        #region Events

        private void FrmUser_Load(object sender, EventArgs e) {

            LoadAreaData();

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

            SaveArea();

            Dispose();
        }

        private void TxtCommisionPercentage_TextChanged(object sender, EventArgs e) {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtCommisionPercentage.Text, "  ^ [0-9]")) {
                txtCommisionPercentage.Text = "";
            }
        }

        private void TxtCommisionPercentage_KeyPress(object sender, KeyPressEventArgs e) {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) {
                e.Handled = true;
            }
        }

        private void TxtPricePerSqm_TextChanged(object sender, EventArgs e) {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtCommisionPercentage.Text, "  ^ [0-9]")) {
                txtCommisionPercentage.Text = "";
            }
        }

        private void TxtPricePerSqm_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) {
                e.Handled = true;
            }
        }

        #endregion

        #region Functions & Methods

        private void SaveArea() {

            const int isOpen = 1;

            if (_formStatus == ModGlobal.FormStatus.IsNew) {
                var newId = Convert.ToInt64(_db.AreaProfiles.OrderByDescending(u => u.AreaId).FirstOrDefault()?.AreaId ?? 0) + 1;

                _db.AreaProfiles.Add(new AreaProfile {
                    AreaId = newId,
                    AreaDescription = txtAreaDescription.Text,
                    Address = txtAddress.Text,
                    PricePerSqm = Convert.ToDecimal(txtPricePerSqm.Text),
                    CommisionPercentage = Convert.ToDecimal(txtCommisionPercentage.Text),
                    Remarks = txtRemarks.Text,
                    CreatedBy = ModGlobal.UserId,
                    CreatedAt = DateTime.Now,
                    Status = isOpen
                });
            }
            else {
                var getAreaProfile = _db.AreaProfiles.FirstOrDefault(u => u.AreaId == _areaId);

                if (getAreaProfile == null) {
                    MessageBox.Show(@"Record not exist.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                getAreaProfile.AreaDescription = txtAreaDescription.Text;
                getAreaProfile.Address = txtAddress.Text;
                getAreaProfile.PricePerSqm = Convert.ToDecimal(txtPricePerSqm.Text);
                getAreaProfile.CommisionPercentage = Convert.ToDecimal(txtCommisionPercentage.Text);
                getAreaProfile.Remarks = txtRemarks.Text;
                getAreaProfile.UpdatedBy = ModGlobal.UserId;
                getAreaProfile.UpdatedAt = DateTime.Now;
            }
            _db.SaveChanges();

            IsSaved = true;
        }

        private string ValidateValues() {
            var area = _db.AreaProfiles.FirstOrDefault(u => u.AreaDescription == txtAreaDescription.Text && u.AreaId != _areaId);

            if (area != null) {
                return @"Area Description already exist.";

            }

            return null;
        }

        private void LoadAreaData() {

            if (_areaId != 0) {

                var area = _db.AreaProfiles.FirstOrDefault(u => u.AreaId == _areaId);

                txtAreaDescription.Text = area?.AreaDescription;
                txtAddress.Text = area?.Address;
                txtPricePerSqm.Text = area?.PricePerSqm.ToString();
                txtCommisionPercentage.Text = area?.CommisionPercentage.ToString();
                txtRemarks.Text = area?.Remarks;
            }
        }

        private void EnabledControls() {

            if (_formStatus == ModGlobal.FormStatus.IsView) {
                btnSave.Visible = false;

                txtAreaDescription.ReadOnly = true;
                txtAddress.ReadOnly = true;
                txtPricePerSqm.ReadOnly = true;
                txtCommisionPercentage.ReadOnly = true;
                txtRemarks.ReadOnly = true;
            }
        }


        #endregion
    }
}
