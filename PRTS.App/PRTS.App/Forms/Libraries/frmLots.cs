namespace PRTS.App.Forms.Libraries {

    using Classes;
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

        #endregion

        #region Functions

        private void SaveLot() {

            if (_formStatus == ModGlobal.FormStatus.IsNew) {
                var newId = Convert.ToInt64(_db.Lots.OrderByDescending(u => u.LotId).FirstOrDefault()?.LotId ?? 0) + 1;

                _db.Lots.Add(new Lot {
                    LotId = newId,
                    //AreaId = Convert.ToInt32(cmbArea.value),
                    LotDescription = txtLotDescription.Text,
                    Sqm = Convert.ToInt64(txtTotalSqm.Text),
                    Block = Convert.ToInt64(txtBlock.Text),
                    Remarks = txtRemarks.Text,
                    CreatedBy = ModGlobal.UserId
                });
            }
            else {
                var getLot = _db.Lots.FirstOrDefault(u => u.LotId == _lotId);

                if (getLot == null) {
                    MessageBox.Show(@"Record not exist.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                //getLot.AreaId = Convert.ToInt32(cmbArea.value);
                getLot.LotDescription = txtLotDescription.Text;
                getLot.Sqm = Convert.ToInt64(txtTotalSqm.Text);
                getLot.Block = Convert.ToInt64(txtBlock.Text);
                getLot.Remarks = txtRemarks.Text;
                getLot.UpdatedBy = ModGlobal.UserId;
                getLot.UpdatedAt = DateTime.Now;
            }
            _db.SaveChanges();

            IsSaved = true;
        }

        private string ValidateValues() {
            var lot = _db.Lots.FirstOrDefault(u => u.LotDescription == txtLotDescription.Text && u.LotId != _lotId);

            if (lot != null) {
                return @"Lot Description already exist.";

            }

            return null;
        }

        private void LoadLotData() {

            if (_lotId != 0) {

                var lot = _db.Lots.FirstOrDefault(u => u.LotId == _lotId);

                //cmbArea.SelectedIndex = lot?.AreaId - 1 ?? 0;
                txtLotDescription.Text = lot?.LotDescription;
                txtBlock.Text = lot?.Block.ToString();
                txtTotalSqm.Text = lot?.Sqm.ToString();
                txtRemarks.Text = lot?.Remarks;
            }
        }

        private void EnabledControls() {

            if (_formStatus == ModGlobal.FormStatus.IsView) {
                btnSave.Visible = false;

                txtLotDescription.ReadOnly = true;
                txtBlock.ReadOnly = true;
                txtTotalSqm.ReadOnly = true;
                txtRemarks.ReadOnly = true;
                cmbArea.Enabled = false;
            }
        }

        #endregion
    }
}
