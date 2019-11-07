using System.Globalization;

namespace PRTS.App.Forms.Libraries {

    using Classes;
    using Classes.Helpers;
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;

    public partial class FrmLots : Form {

        private readonly long _lotId;
        private readonly DbEntities _db = new DbEntities();
        private readonly ModGlobal.FormStatus _formStatus;

        public bool IsSaved;

        public FrmLots(long lotId, ModGlobal.FormStatus formStatus) {
            InitializeComponent();

            _lotId = lotId;
            _formStatus = formStatus;
        }

        #region Events

        private void FrmUser_Load(object sender, EventArgs e) {

            LoadAreaData();

            LoadLotData();

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

            SaveLot();

            Dispose();
        }

        private void TxtTotalSqm_TextChanged(object sender, EventArgs e) {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtTotalSqm.Text, "  ^ [0-9]")) {
                txtTotalSqm.Text = "";
            }

            AutoCalulatePrice();
        }

        private void TxtTotalSqm_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }

        private void TxtBlock_TextChanged(object sender, EventArgs e) {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtBlock.Text, "  ^ [0-9]")) {
                txtBlock.Text = "";
            }
        }

        private void TxtBlock_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }

        private void CmbArea_SelectedIndexChanged(object sender, EventArgs e) {

            var selectedArea = cmbArea.SelectedItem.ToString();

            var area = _db.AreaProfiles.FirstOrDefault(a => a.AreaDescription == selectedArea);

            if (area == null) return;

            txtPricePerSqm.Text = area.PricePerSqm.ToString();

            AutoCalulatePrice();
        }

        #endregion

        #region Functions

        private void AutoCalulatePrice() {
            if (string.IsNullOrEmpty(txtPricePerSqm.Text) || string.IsNullOrEmpty(txtTotalSqm.Text)) return;

            txtPrice.Text = (Convert.ToDecimal(txtPricePerSqm.Text) * Convert.ToInt64(txtTotalSqm.Text)).ToString(CultureInfo.InvariantCulture);
        }

        private void SaveLot() {

            const int isOpen = 1;

            var comboItem = (ComboBoxItem)cmbArea.SelectedItem;

            if (_formStatus == ModGlobal.FormStatus.IsNew) {
                var newId = Convert.ToInt64(_db.Lots.OrderByDescending(u => u.LotId).FirstOrDefault()?.LotId ?? 0) + 1;

                _db.Lots.Add(new Lot {
                    LotId = newId,
                    AreaId = Convert.ToInt32(comboItem.value),
                    LotDescription = txtLotDescription.Text,
                    Sqm = Convert.ToInt64(txtTotalSqm.Text),
                    Price = Convert.ToDecimal(txtPrice.Text),
                    Block = Convert.ToInt64(string.IsNullOrEmpty(txtBlock.Text) ? "0" : txtBlock.Text),
                    Remarks = txtRemarks.Text,
                    CreatedBy = ModGlobal.UserId,
                    CreatedAt = DateTime.Now,
                    Status = isOpen
                });
            }
            else {
                var getLot = _db.Lots.FirstOrDefault(u => u.LotId == _lotId);

                if (getLot == null) {
                    MessageBox.Show(@"Record not exist.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                getLot.AreaId = Convert.ToInt32(comboItem.value);
                getLot.LotDescription = txtLotDescription.Text;
                getLot.Sqm = Convert.ToInt64(txtTotalSqm.Text);
                getLot.Price = Convert.ToDecimal(txtPrice.Text);
                getLot.Block = Convert.ToInt64(txtBlock.Text);
                getLot.Remarks = txtRemarks.Text;
                getLot.UpdatedBy = ModGlobal.UserId;
                getLot.UpdatedAt = DateTime.Now;
            }
            _db.SaveChanges();

            IsSaved = true;
        }

        private string ValidateValues() {
            var comboItem = (ComboBoxItem)cmbArea.SelectedItem;

            var areaId = Convert.ToInt32(comboItem.value);

            var lot = _db.Lots.FirstOrDefault(u => u.LotDescription == txtLotDescription.Text && u.AreaId == areaId && u.LotId != _lotId);

            if (lot != null) {
                return $"Lot Description already exist for this area({comboItem.name}).";

            }

            return null;
        }

        private void LoadAreaData() {

            var areas = _db.AreaProfiles.Where(r => r.AreaId != 0).OrderBy(r => r.AreaId).ToList();

            foreach (var area in areas) {
                cmbArea.Items.Add(new ComboBoxItem(Convert.ToString(area.AreaDescription), Convert.ToString(area.AreaId)));
            }

            cmbArea.ValueMember = "value";
            cmbArea.DisplayMember = "name";

            if (_formStatus == ModGlobal.FormStatus.IsNew) {
                cmbArea.SelectedIndex = 0;
            }
        }

        private void LoadLotData() {

            if (_lotId != 0) {

                var lot = _db.Lots.FirstOrDefault(u => u.LotId == _lotId);

                cmbArea.SelectedIndex = Convert.ToInt32(lot?.AreaId ?? 1) - 1;
                txtLotDescription.Text = lot?.LotDescription;
                txtBlock.Text = lot?.Block.ToString();
                txtTotalSqm.Text = lot?.Sqm.ToString();
                txtPrice.Text = lot?.Price.ToString();
                txtRemarks.Text = lot?.Remarks;
            }
        }

        private void EnabledControls() {

            if (_formStatus == ModGlobal.FormStatus.IsView) {
                btnSave.Visible = false;

                txtLotDescription.ReadOnly = true;
                txtBlock.ReadOnly = true;
                txtTotalSqm.ReadOnly = true;
                txtPrice.ReadOnly = true;
                txtRemarks.ReadOnly = true;
                cmbArea.Enabled = false;
            }
        }

        #endregion
    }
}
