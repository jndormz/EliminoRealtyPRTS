namespace PRTS.App.Forms.Helpers {

    using Classes;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    public partial class FrmLookup : Form {

        private readonly string _module;
        private readonly DbEntities _db = new DbEntities();
        private readonly ModGlobal.FormStatus _formStatus;

        public long Id;
        public new string Name;
        public string Price;

        public FrmLookup(string module, ModGlobal.FormStatus formStatus) {
            InitializeComponent();

            _module = module;
            _formStatus = formStatus;
        }

        private void BtnClose_Click(object sender, EventArgs e) {
            Dispose();
        }

        private void FrmLookup_Load(object sender, EventArgs e) {
            lblTitle.Text = _module + @" Lookup";

            LoadData("");
        }

        private void BtnLotAdd_Click(object sender, EventArgs e) {
            LoadData(txtSearch.Text);
        }

        private void BtnSave_Click(object sender, EventArgs e) {

            if (dgvGeneric.Rows.Count == 0) {
                MessageBox.Show(@"There are no records to select.", @"Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Id = Convert.ToInt64(dgvGeneric.SelectedRows[0].Cells[0].Value);
            Name = dgvGeneric.SelectedRows[0].Cells[1].Value.ToString();

            if (_module == ModGlobal.ModLots) Price = dgvGeneric.SelectedRows[0].Cells[4].Value.ToString();

            Dispose();
        }

        private void LoadData(string search) {

            var data = new List<object>();

            if (_module == ModGlobal.ModAgents) {

                var agents = from a in _db.Agents
                             where a.IsActive == true
                             select  new {
                                 a.AgentId,
                                 Name = string.Concat(a.FirstName, " ", a.LastName),
                                 a.Contact };

                 data.AddRange(agents.Where(a => a.AgentId.ToString().Contains(search) || 
                                                 a.Name.Contains(search) || 
                                                 a.Contact.Contains(search)).ToList());
            }
            else if (_module == ModGlobal.ModLots) {

                var lots = from l in _db.Lots
                    where l.Status == 1
                    select new {
                        l.LotId,
                        Description = l.LotDescription,
                        l.Block,
                        l.Sqm,
                        l.Price
                    };

                data.AddRange(lots.Where(l => l.LotId.ToString().Contains(search) ||
                                              l.Description.Contains(search) ||
                                              l.Block.ToString().Contains(search) ||
                                              l.Sqm.ToString().Contains(search)).ToList());
            }

            dgvGeneric.DataSource = data;

            if (data.Count > 0) {
                FormatGrid();
            }

        }

        private void FormatGrid() {
            dgvGeneric.DefaultCellStyle.Font = new Font("Century Gothic", 9, FontStyle.Regular);
            dgvGeneric.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvGeneric.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dgvGeneric.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            dgvGeneric.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            //dgvMain.EnableHeadersVisualStyles = true;
            dgvGeneric.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            //dgvMain.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvGeneric.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvGeneric.ReadOnly = true;

            if (_module == ModGlobal.ModAgents) {

                dgvGeneric.Columns[0].Width = 50;
                dgvGeneric.Columns[0].HeaderText = @"Id";
                dgvGeneric.Columns[1].Width = 200;
                dgvGeneric.Columns[1].HeaderText = @"Name";
                dgvGeneric.Columns[2].Width = 100;
                dgvGeneric.Columns[2].HeaderText = @"Contact";
            } else if (_module == ModGlobal.ModLots) {

                dgvGeneric.Columns[0].Width = 50;
                dgvGeneric.Columns[0].HeaderText = @"Id";
                dgvGeneric.Columns[1].Width = 120;
                dgvGeneric.Columns[1].HeaderText = @"Description";
                dgvGeneric.Columns[2].Width = 60;
                dgvGeneric.Columns[2].HeaderText = @"Block";
                dgvGeneric.Columns[3].Width = 60;
                dgvGeneric.Columns[3].HeaderText = @"Sqm";
                dgvGeneric.Columns[4].Width = 80;
                dgvGeneric.Columns[4].HeaderText = @"Price";
            }
        }
    }
}
