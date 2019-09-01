using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace PRTS.App.Forms.Users {

    using Classes;
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;

    public partial class FrmUserPrivileges : Form {

        private readonly int _roleId;
        private readonly DbEntities _db = new DbEntities();
        private readonly ModGlobal.FormStatus _formStatus;

        public bool IsSaved;

        public FrmUserPrivileges(int roleId, ModGlobal.FormStatus formStatus) {
            InitializeComponent();

            _roleId = roleId;
            _formStatus = formStatus;
        }

        #region Events

        private void FrmUser_Load(object sender, EventArgs e) {

            LoadUserModules();

            LoadUserData();

            EnabledControls();

            FormatGrid();
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

            SaveUserPrivileges();

            Dispose();
        }

        #endregion

        #region Functions

        private void SaveUserPrivileges() {

            if (_formStatus == ModGlobal.FormStatus.IsNew) {
                var newId = Convert.ToInt32(_db.Roles.OrderByDescending(u => u.RoleId).FirstOrDefault()?.RoleId ?? 0) + 1;

                _db.Roles.Add(new Role {
                    RoleId = newId,
                    RoleName = txtRoleDescription.Text,
                    CreatedBy = ModGlobal.UserId,
                    CreatedAt = DateTime.Now
                });

                SaveUserModules(newId);
            }
            else {
                var getRole = _db.Roles.FirstOrDefault(u => u.RoleId == _roleId);

                if (getRole == null) {
                    MessageBox.Show(@"Record not exist.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                getRole.RoleName = txtRoleDescription.Text;
                getRole.UpdatedBy = ModGlobal.UserId;
                getRole.UpdatedAt = DateTime.Now;

                DeleteUserModules();

                SaveUserModules(_roleId);
            }

            _db.SaveChanges();

            IsSaved = true;
        }

        private void SaveUserModules(int id) {

            for (var i = 0; i < dgvUserPrivileges.RowCount; i++) {

                _db.UserPrivileges.Add(new UserPrivilege {
                    RoleId = id,
                    ModuleId = Convert.ToInt64(dgvUserPrivileges.Rows[i].Cells[2].Value),
                    IsVisible = Convert.ToBoolean(dgvUserPrivileges.Rows[i].Cells[0].Value)
                });
            }
        }

        private void DeleteUserModules() {

            var userPrivileges = _db.UserPrivileges.Where(u => u.RoleId == _roleId);

            _db.UserPrivileges.RemoveRange(userPrivileges);
        }

        private string ValidateValues() {
            var user = _db.Users.FirstOrDefault(u => u.UserName == txtRoleDescription.Text && u.UserId != _roleId);

            if (user != null) {
                return @"Role already exist.";

            }

            return null;
        }

        private void LoadUserData() {

            if (_roleId != 0) {

                var user = _db.Roles.FirstOrDefault(u => u.RoleId == _roleId);

                txtRoleDescription.Text = user?.RoleName;

                var userPrivileges = (from u in _db.UserPrivileges
                                        join m in _db.Modules on u.ModuleId equals m.ModuleId
                                            where u.RoleId == _roleId
                                                select new ModuleModel {
                                                    Select = u.IsVisible ?? false,
                                                    ModuleName = m.ModuleName,
                                                    ModuleId = m.ModuleId
                                                }).ToList();

                LoadDataTableToGrid(userPrivileges);
            }
        }

        private void LoadUserModules() {

            var modules = 
                (from m in _db.Modules
                    select new ModuleModel {
                        Select = true,
                        ModuleName = m.ModuleName,
                        ModuleId = m.ModuleId
                    }).ToList();

            LoadDataTableToGrid(modules);
        }

        private void LoadDataTableToGrid(List<ModuleModel> data) {
            var dt = new DataTable();
            dt.Columns.Add("Select", typeof(bool));
            dt.Columns.Add("Module", typeof(string));
            dt.Columns.Add("ModuleId", typeof(long));

            foreach (var module in data) {
                object[] dr = { module.Select, module.ModuleName, module.ModuleId };

                dt.Rows.Add(dr);
            }

            dgvUserPrivileges.DataSource = dt;
        }

        private class ModuleModel {

            public bool Select { get; set; }

            public string ModuleName { get; set; }

            public long ModuleId { get; set; }
        }

        private void FormatGrid() {
            dgvUserPrivileges.DefaultCellStyle.Font = new Font("Century Gothic", 9, FontStyle.Regular);
            dgvUserPrivileges.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvUserPrivileges.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dgvUserPrivileges.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            dgvUserPrivileges.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            dgvUserPrivileges.EnableHeadersVisualStyles = true;
            dgvUserPrivileges.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvUserPrivileges.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvUserPrivileges.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgvUserPrivileges.Columns[0].Width = 50;
            dgvUserPrivileges.Columns[1].Width = 330;
            dgvUserPrivileges.Columns[1].HeaderText = @"Module";
            dgvUserPrivileges.Columns[2].Visible = false;
        }

        private void EnabledControls() {

            if (_formStatus == ModGlobal.FormStatus.IsView) {
                btnSave.Visible = false;

                txtRoleDescription.ReadOnly = true;
                dgvUserPrivileges.ReadOnly = true;
            }
        }

        #endregion
    }
}
