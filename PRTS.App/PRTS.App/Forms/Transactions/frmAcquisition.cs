namespace PRTS.App.Forms.Transactions {

    using Classes;
    using Helpers;
    using PRTS.App.Classes.Helpers;
    using System;
    using System.Linq;
    using System.Windows.Forms;

    public partial class FrmAcquisition : Form {

        private readonly long _acquisitionId;
        private readonly DbEntities _db = new DbEntities();
        private readonly ModGlobal.FormStatus _formStatus;

        public bool IsSaved;

        private long AgentId;
        private string AgentName;
        private long LotId;
        private string LotDescription;

        public FrmAcquisition(long acquisitionId, ModGlobal.FormStatus formStatus) {
            InitializeComponent();

            _acquisitionId = acquisitionId;
            _formStatus = formStatus;
        }

        #region Events

        private void BtnClose_Click(object sender, EventArgs e) {
            Dispose();
        }

        private void BtnAddAgent_Click(object sender, EventArgs e) {
            var lookup = new FrmLookup(ModGlobal.ModAgents,
                _formStatus);
            lookup.ShowDialog();

            if (lookup.Id != 0) {
                AgentId = lookup.Id;
                AgentName = lookup.Name;
            }
        }

        private void BtnLotAdd_Click(object sender, EventArgs e) {
            var lookup = new FrmLookup(ModGlobal.ModLots,
                _formStatus);
            lookup.ShowDialog();

            if (lookup.Id != 0) {
                LotId = lookup.Id;
                LotDescription = lookup.Name;
                txtLot.Text = LotDescription;
                txtAmount.Text = lookup.Price;
            }
        }

        private void FrmAcquisition_Load(object sender, EventArgs e) {

            txtStatus.Text = @"New";
            txtDate.Text = DateTime.Now.ToShortDateString();

            LoadClientData();
            LoadAreaData();
            LoadCommissionPercentage();
        }
        private void CmbArea_SelectedIndexChanged(object sender, EventArgs e) {
            LoadCommissionPercentage();
        }

        #endregion

        #region Fuctions

        private void LoadCommissionPercentage() {

            var comboItem = (ComboBoxItem)cmbArea.SelectedItem;

            if (comboItem.value == null) return;

            var area = _db.AreaProfiles.FirstOrDefault(x => x.AreaId.ToString() == comboItem.value);

            if (area != null) {
                txtCommPercentage.Text = area.CommisionPercentage.ToString();
            }
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

        private void LoadClientData() {

            var clients = _db.Clients.Where(r => r.ClientId != 0).OrderBy(r => r.ClientId).ToList();

            foreach (var client in clients) {

                var clientName = string.Concat(client.FirstName, " ", client.LastName);

                cmbClient.Items.Add(new ComboBoxItem(clientName, Convert.ToString(client.ClientId)));
            }

            cmbClient.ValueMember = "value";
            cmbClient.DisplayMember = "name";

            if (_formStatus == ModGlobal.FormStatus.IsNew) {
                cmbClient.SelectedIndex = 0;
            }
        }


        #endregion
    }
}
