namespace PRTS.App {

    using Classes;
    using Forms;
    using Forms.Libraries;
    using Forms.Users;
    using System;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    public partial class frmMain : Form {

        private string _currentModule = "";

        private readonly DbEntities _db = new DbEntities();

        #region Main

        public frmMain() {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e) {

            SetModuleNames();
            pnlSidebar.Enabled = false;
            SideBarPanelsVisibility("");

            var logIn = new frmLogIn();
            logIn.ShowDialog();

            if (logIn.isLogIn) {
                SetDefaultData();
            }
            else {
                Dispose();
            }
        }

        #endregion

        #region Events

        private void BtnModule_Click(object sender, EventArgs e) {

            _currentModule = (sender as Button)?.Text.Trim();

            lblTitle.Text = _currentModule;

            SideBarPanelsVisibility(_currentModule);

            LoadData();
        }

        private void BtnLogout_Click(object sender, EventArgs e) {

            if (MessageBox.Show(@"Are you sure you want to logout?",@"Info", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information) == DialogResult.Yes) {
                ClearData();

                var logIn = new frmLogIn();
                logIn.ShowDialog();

                if (logIn.isLogIn) {
                    SetDefaultData();
                }
                else {
                    Dispose();
                }
            }
        }

        private void TsView_Click(object sender, EventArgs e) {

            if (dgvMain.Rows.Count == 0)  {
                MessageBox.Show(@"There are no records to view.", @"Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_currentModule == ModGlobal.ModUserManagement) {
                var user = new FrmUser(Convert.ToInt64(dgvMain.SelectedRows[0].Cells[0].Value), ModGlobal.FormStatus.IsView);
                user.ShowDialog();
            } else if (_currentModule == ModGlobal.ModUserPrivileges) {
                var user = new FrmUserPrivileges(Convert.ToInt32(dgvMain.SelectedRows[0].Cells[0].Value), ModGlobal.FormStatus.IsView);
                user.ShowDialog();
            } else if (_currentModule == ModGlobal.ModAreaProfile) {
                var area = new FrmAreaProfile(Convert.ToInt64(dgvMain.SelectedRows[0].Cells[0].Value), ModGlobal.FormStatus.IsView);
                area.ShowDialog();
            } else if (_currentModule == ModGlobal.ModLots) {
                var lot = new FrmLots(Convert.ToInt64(dgvMain.SelectedRows[0].Cells[0].Value), ModGlobal.FormStatus.IsView);
                lot.ShowDialog();
            } else if (_currentModule == ModGlobal.ModAgents) {
                var agent = new FrmAgents(Convert.ToInt64(dgvMain.SelectedRows[0].Cells[0].Value), ModGlobal.FormStatus.IsView);
                agent.ShowDialog();
            } else if (_currentModule == ModGlobal.ModClients) {
                var client = new FrmClients(Convert.ToInt64(dgvMain.SelectedRows[0].Cells[0].Value), ModGlobal.FormStatus.IsView);
                client.ShowDialog();
            }
        }

        private void TsAdd_Click(object sender, EventArgs e) {
            if (_currentModule == ModGlobal.ModUserManagement) {
                var user = new FrmUser(0, ModGlobal.FormStatus.IsNew);
                user.ShowDialog();

                if (user.IsSaved) {
                    LoadData();
                }
            } else if (_currentModule == ModGlobal.ModUserPrivileges) {
                var user = new FrmUserPrivileges(0, ModGlobal.FormStatus.IsNew);
                user.ShowDialog();

                if (user.IsSaved) {
                    LoadData();
                }
            } else if (_currentModule == ModGlobal.ModAreaProfile) {
                var area = new FrmAreaProfile(0, ModGlobal.FormStatus.IsNew);
                area.ShowDialog();

                if (area.IsSaved) {
                    LoadData();
                }
            } else if (_currentModule == ModGlobal.ModLots) {

                const int isOpen = 1;

                var area = _db.AreaProfiles.FirstOrDefault(a => a.Status == isOpen);

                if (area == null) {
                    MessageBox.Show(@"There are no active Area Profile for Lot to assign to. Please contact the administrator for more info.", @"Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var lot = new FrmLots(0, ModGlobal.FormStatus.IsNew);
                lot.ShowDialog();

                if (lot.IsSaved) {
                    LoadData();
                }
            } else if (_currentModule == ModGlobal.ModAgents) {
                var agent = new FrmAgents(0, ModGlobal.FormStatus.IsNew);
                agent.ShowDialog();

                if (agent.IsSaved) {
                    LoadData();
                }
            }
            else if (_currentModule == ModGlobal.ModClients) {
                var client = new FrmClients(0, ModGlobal.FormStatus.IsNew);
                client.ShowDialog();

                if (client.IsSaved) {
                    LoadData();
                }
            }
        }

        private void TsEdit_Click(object sender, EventArgs e) {

            if (dgvMain.Rows.Count == 0) {
                MessageBox.Show(@"There are no records to edit.", @"Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_currentModule == ModGlobal.ModUserManagement) {
                var user = new FrmUser(Convert.ToInt64(dgvMain.SelectedRows[0].Cells[0].Value),
                    ModGlobal.FormStatus.IsEdit);
                user.ShowDialog();

                if (user.IsSaved) {
                    LoadData();
                }
            } else if (_currentModule == ModGlobal.ModUserPrivileges) {
                var user = new FrmUserPrivileges(Convert.ToInt32(dgvMain.SelectedRows[0].Cells[0].Value),
                    ModGlobal.FormStatus.IsEdit);
                user.ShowDialog();

                if (user.IsSaved) {
                    LoadData();
                }
            } else if (_currentModule == ModGlobal.ModAreaProfile) {
                var area = new FrmAreaProfile(Convert.ToInt64(dgvMain.SelectedRows[0].Cells[0].Value),
                    ModGlobal.FormStatus.IsEdit);
                area.ShowDialog();

                if (area.IsSaved) {
                    LoadData();
                }
            } else if (_currentModule == ModGlobal.ModLots) {
                var lot = new FrmLots(Convert.ToInt64(dgvMain.SelectedRows[0].Cells[0].Value),
                    ModGlobal.FormStatus.IsEdit);
                lot.ShowDialog();

                if (lot.IsSaved) {
                    LoadData();
                }
            } else if (_currentModule == ModGlobal.ModAgents) {
                var agent = new FrmAgents(Convert.ToInt64(dgvMain.SelectedRows[0].Cells[0].Value),
                    ModGlobal.FormStatus.IsEdit);
                agent.ShowDialog();

                if (agent.IsSaved) {
                    LoadData();
                }
            } else if (_currentModule == ModGlobal.ModClients) {
                var client = new FrmClients(Convert.ToInt64(dgvMain.SelectedRows[0].Cells[0].Value),
                    ModGlobal.FormStatus.IsEdit);
                client.ShowDialog();

                if (client.IsSaved) {
                    LoadData();
                }
            }
        }
        #endregion

        #region Functions & Methods

        private void SetDefaultData() {
            pnlSidebar.Enabled = true;
            lblUser.Text = ModGlobal.User;
            lblRole.Text = ModGlobal.Role;

            btnAreaProfile.Enabled = ModGlobal.PrivAreaProfile;
            btnLots.Enabled = ModGlobal.PrivLots;
            btnAgents.Enabled = ModGlobal.PrivAgents;
            btnClients.Enabled = ModGlobal.PrivClients;
            btnAcquisition.Enabled = ModGlobal.PrivAcquisition;
            btnIncomingPayments.Enabled = ModGlobal.PrivIncomingPayments;
            btnOutgoingPayments.Enabled = ModGlobal.PrivOutgoingPayments;
            btnReports.Enabled = ModGlobal.PrivReports;
            btnUserPrivileges.Enabled = ModGlobal.PrivUserPrivileges;
            btnUserManagement.Enabled = ModGlobal.PrivUserManagement;
        }

        private void ClearData() {
            lblTitle.Text = "";
            lblUser.Text = "";
            lblRole.Text = "";
            dgvMain.DataSource = null;
            pnlSidebar.Enabled = false;
            SideBarPanelsVisibility("");

            ModGlobal.UserId = null;
            ModGlobal.User = null;
            ModGlobal.RoleId = null;
            ModGlobal.Role = null;

            ModGlobal.PrivAreaProfile = true;
            ModGlobal.PrivLots = true;
            ModGlobal.PrivAgents = true;
            ModGlobal.PrivClients = true;
            ModGlobal.PrivIncomingPayments = true;
            ModGlobal.PrivOutgoingPayments = true;
            ModGlobal.PrivReports = true;
            ModGlobal.PrivUserPrivileges = true;
            ModGlobal.PrivUserManagement = true;
        }

        private void SetModuleNames() {
            btnAreaProfile.Text = @" " + ModGlobal.ModAreaProfile;
            btnLots.Text = @" " + ModGlobal.ModLots;
            btnAgents.Text = @" " + ModGlobal.ModAgents;
            btnClients.Text = @" " + ModGlobal.ModClients;
            btnAcquisition.Text = @" " + ModGlobal.ModAcquisition;
            btnIncomingPayments.Text = @" " + ModGlobal.ModIncomingPayments;
            btnOutgoingPayments.Text = @" " + ModGlobal.ModOutgoingPayments;
            btnReports.Text = @" " + ModGlobal.ModReports;
            btnUserPrivileges.Text = @" " + ModGlobal.ModUserPrivileges;
            btnUserManagement.Text = @" " + ModGlobal.ModUserManagement;
        }

        private void LoadData() {

            dgvMain.DataSource = null;

            if (_currentModule == ModGlobal.ModUserPrivileges) {
                var userPrivileges =
                    (from r in _db.Roles
                        where r.RoleId != 0
                        select new {
                            Id = r.RoleId,
                            Role = r.RoleName,
                            r.CreatedAt,
                            r.UpdatedAt
                        }).OrderByDescending(u => u.Id).ToList();

                dgvMain.DataSource = userPrivileges;
            }
            else if (_currentModule == ModGlobal.ModUserManagement) {
                var userManagement =
                    (from u in _db.Users
                        join r in _db.Roles on u.RoleId equals r.RoleId
                            where u.UserId != 0
                                select new {
                                    Id = u.UserId,
                                    Fullname = u.FirstName + " " + u.LastName,
                                    Role = r.RoleName,
                                    IsActive = u.IsActive ?? false,
                                    u.CreatedAt,
                                    u.UpdatedAt
                                }).OrderByDescending(u => u.Id).ToList();

                dgvMain.DataSource = userManagement;
            }
            else if (_currentModule == ModGlobal.ModAreaProfile) {
                var areas = (from a in _db.AreaProfiles
                    join u in _db.Users on a.CreatedBy equals u.UserId into au
                        from u in au.DefaultIfEmpty()
                            join u2 in _db.Users on a.UpdatedBy equals u2.UserId into au2
                                from u2 in au2.DefaultIfEmpty()
                                     select new {
                                        Id = a.AreaId,
                                        Description = a.AreaDescription,
                                        a.Address,
                                        CommPercentage = a.CommisionPercentage,
                                        a.Remarks,
                                        Status = a.Status == 1 ? "Open" : "Closed",
                                        CreatedBy = u.FirstName + " " + u.LastName,
                                        a.CreatedAt,
                                        UpdatedBy = u2.FirstName + " " + u2.LastName,
                                        a.UpdatedAt
                                    }).OrderByDescending(a => a.Id).ToList();

                dgvMain.DataSource = areas;
            }
            else if (_currentModule == ModGlobal.ModLots) {
                var lots = 
                    (from l in _db.Lots
                        join a in _db.AreaProfiles on l.AreaId equals a.AreaId
                             join u in _db.Users on l.CreatedBy equals u.UserId into au
                                from u in au.DefaultIfEmpty()
                                    join u2 in _db.Users on l.UpdatedBy equals u2.UserId into au2
                                        from u2 in au2.DefaultIfEmpty()
                                             select new {
                                                Id = l.LotId,
                                                Area = a.AreaDescription,
                                                Description = l.LotDescription,
                                                l.Block,
                                                l.Sqm,
                                                a.Remarks,
                                                Status = a.Status == 1 ? "Open" : "Closed",
                                                CreatedBy = u.FirstName + " " + u.LastName,
                                                l.CreatedAt,
                                                UpdatedBy = u2.FirstName + " " + u2.LastName,
                                                l.UpdatedAt
                                            }).OrderByDescending(l => l.Id).ToList();

                dgvMain.DataSource = lots;
            }
            else if (_currentModule == ModGlobal.ModAgents) {
                var agents =
                    (from a in _db.Agents
                         join u in _db.Users on a.CreatedBy equals u.UserId into au
                             from u in au.DefaultIfEmpty()
                                join u2 in _db.Users on a.UpdatedBy equals u2.UserId into au2
                                    from u2 in au2.DefaultIfEmpty()
                                         select new {
                                                Id = a.AgentId,
                                                Fullname = a.FirstName + " " + a.LastName,
                                                a.Contact,
                                                IsActive = a.IsActive ?? false,
                                                CreatedBy = u.FirstName + " " + u.LastName,
                                                a.CreatedAt,
                                                UpdatedBy = u2.FirstName + " " + u2.LastName,
                                                a.UpdatedAt
                                            }).OrderByDescending(a => a.Id).ToList();

                dgvMain.DataSource = agents;
            }
            else if (_currentModule == ModGlobal.ModClients) {
                var clients =
                    (from c in _db.Clients
                         join u in _db.Users on c.CreatedBy equals u.UserId into au
                             from u in au.DefaultIfEmpty()
                                 join u2 in _db.Users on c.UpdatedBy equals u2.UserId into au2
                                    from u2 in au2.DefaultIfEmpty()
                                         select new {
                                                Id = c.ClientId,
                                                Fullname = c.FirstName + " " + c.LastName,
                                                c.Address,
                                                c.Contact1,
                                                c.Contact2,
                                                IsActive = c.IsActive ?? false,
                                                CreatedBy = u.FirstName + " " + u.LastName,
                                                c.CreatedAt,
                                                UpdatedBy = u2.FirstName + " " + u2.LastName,
                                                c.UpdatedAt
                                            }).OrderByDescending(c => c.Id).ToList();

                dgvMain.DataSource = clients;
            }

            FormatGrid();
        }

        private void FormatGrid() {

            dgvMain.DefaultCellStyle.Font = new Font("Century Gothic", 9, FontStyle.Regular);
            dgvMain.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMain.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dgvMain.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            dgvMain.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            //dgvMain.EnableHeadersVisualStyles = true;
            dgvMain.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            //dgvMain.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvMain.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvMain.ReadOnly = true;

            if (_currentModule == ModGlobal.ModUserPrivileges) {
                dgvMain.Columns[0].Width = 50;
                dgvMain.Columns[0].HeaderText = @"Id";
                dgvMain.Columns[1].Width = 150;
                dgvMain.Columns[1].HeaderText = @"Role";
                dgvMain.Columns[2].Width = 150;
                dgvMain.Columns[2].HeaderText = @"Created At";
                dgvMain.Columns[3].Width = 150;
                dgvMain.Columns[3].HeaderText = @"Updated At";
            }
            else if (_currentModule == ModGlobal.ModUserManagement) {
                dgvMain.Columns[0].Width = 50;
                dgvMain.Columns[0].HeaderText = @"Id";
                dgvMain.Columns[1].Width = 200;
                dgvMain.Columns[1].HeaderText = @"Fullname";
                dgvMain.Columns[2].Width = 150;
                dgvMain.Columns[2].HeaderText = @"Role";
                dgvMain.Columns[3].Width = 100;
                dgvMain.Columns[3].HeaderText = @"Is Active?";
                dgvMain.Columns[4].Width = 150;
                dgvMain.Columns[4].HeaderText = @"Created At";
                dgvMain.Columns[5].Width = 150;
                dgvMain.Columns[5].HeaderText = @"Updated At";
            }
            else if (_currentModule == ModGlobal.ModAreaProfile) {
                dgvMain.Columns[0].Width = 50;
                dgvMain.Columns[0].HeaderText = @"Id";
                dgvMain.Columns[1].Width = 200;
                dgvMain.Columns[1].HeaderText = @"Description";
                dgvMain.Columns[2].Width = 350;
                dgvMain.Columns[2].HeaderText = @"Address";
                dgvMain.Columns[3].Width = 100;
                dgvMain.Columns[3].HeaderText = @"Comm. %";
                dgvMain.Columns[4].Visible = false;
                dgvMain.Columns[5].Width = 100;
                dgvMain.Columns[5].HeaderText = @"Status";
                dgvMain.Columns[6].Width = 200;
                dgvMain.Columns[6].HeaderText = @"Created By";
                dgvMain.Columns[7].Width = 150;
                dgvMain.Columns[7].HeaderText = @"Created At";
                dgvMain.Columns[8].Width = 200;
                dgvMain.Columns[8].HeaderText = @"Updated By";
                dgvMain.Columns[9].Width = 150;
                dgvMain.Columns[9].HeaderText = @"Updated At";
            }
            else if (_currentModule == ModGlobal.ModLots) {
                dgvMain.Columns[0].Width = 50;
                dgvMain.Columns[0].HeaderText = @"Id";
                dgvMain.Columns[1].Width = 200;
                dgvMain.Columns[1].HeaderText = @"Area";
                dgvMain.Columns[2].Width = 300;
                dgvMain.Columns[2].HeaderText = @"Description";
                dgvMain.Columns[3].Width = 150;
                dgvMain.Columns[3].HeaderText = @"Block";
                dgvMain.Columns[4].Width = 150;
                dgvMain.Columns[4].HeaderText = @"Sqm.";
                dgvMain.Columns[5].Visible = false;
                dgvMain.Columns[6].Width = 100;
                dgvMain.Columns[6].HeaderText = @"Status";
                dgvMain.Columns[7].Width = 200;
                dgvMain.Columns[7].HeaderText = @"Created By";
                dgvMain.Columns[8].Width = 150;
                dgvMain.Columns[8].HeaderText = @"Created At";
                dgvMain.Columns[9].Width = 200;
                dgvMain.Columns[9].HeaderText = @"Updated By";
                dgvMain.Columns[10].Width = 150;
                dgvMain.Columns[10].HeaderText = @"Updated At";
            }
            else if (_currentModule == ModGlobal.ModAgents) {
                dgvMain.Columns[0].Width = 50;
                dgvMain.Columns[0].HeaderText = @"Id";
                dgvMain.Columns[1].Width = 200;
                dgvMain.Columns[1].HeaderText = @"Fullname";
                dgvMain.Columns[2].Width = 200;
                dgvMain.Columns[2].HeaderText = @"Contact";
                dgvMain.Columns[3].Width = 100;
                dgvMain.Columns[3].HeaderText = @"Is Active?";
                dgvMain.Columns[4].Width = 200;
                dgvMain.Columns[4].HeaderText = @"Created By";
                dgvMain.Columns[5].Width = 150;
                dgvMain.Columns[5].HeaderText = @"Created At";
                dgvMain.Columns[6].Width = 200;
                dgvMain.Columns[6].HeaderText = @"Updated By";
                dgvMain.Columns[7].Width = 150;
                dgvMain.Columns[7].HeaderText = @"Updated At";
            }
            else if (_currentModule == ModGlobal.ModClients)
            {
                dgvMain.Columns[0].Width = 50;
                dgvMain.Columns[0].HeaderText = @"Id";
                dgvMain.Columns[1].Width = 200;
                dgvMain.Columns[1].HeaderText = @"Fullname";
                dgvMain.Columns[2].Width = 350;
                dgvMain.Columns[2].HeaderText = @"Address";
                dgvMain.Columns[3].Width = 200;
                dgvMain.Columns[3].HeaderText = @"Contact 1";
                dgvMain.Columns[4].Width = 200;
                dgvMain.Columns[4].HeaderText = @"Contact 2";
                dgvMain.Columns[5].Width = 100;
                dgvMain.Columns[5].HeaderText = @"Is Active?";
                dgvMain.Columns[6].Width = 200;
                dgvMain.Columns[6].HeaderText = @"Created By";
                dgvMain.Columns[7].Width = 150;
                dgvMain.Columns[7].HeaderText = @"Created At";
                dgvMain.Columns[8].Width = 200;
                dgvMain.Columns[8].HeaderText = @"Updated By";
                dgvMain.Columns[9].Width = 150;
                dgvMain.Columns[9].HeaderText = @"Updated At";
            }
        }

        private void SideBarPanelsVisibility(string title) {
            pnlAreaProfile.Visible = btnAreaProfile.Text.Trim() == title;
            pnlLots.Visible = btnLots.Text.Trim() == title;
            pnlAgents.Visible = btnAgents.Text.Trim() == title;
            pnlClients.Visible = btnClients.Text.Trim() == title;
            pnlAcquisition.Visible = btnAcquisition.Text.Trim() == title;
            pnlIncomingPayments.Visible = btnIncomingPayments.Text.Trim() == title;
            pnlOutgoingPayments.Visible = btnOutgoingPayments.Text.Trim() == title;
            pnlReports.Visible = btnReports.Text.Trim() == title;
            pnlUserPrivileges.Visible = btnUserPrivileges.Text.Trim() == title;
            pnlUserManagement.Visible = btnUserManagement.Text.Trim() == title;
        }

        #endregion
    }
}
