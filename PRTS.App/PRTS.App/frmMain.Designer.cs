namespace PRTS.App
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsView = new System.Windows.Forms.ToolStripButton();
            this.tsAdd = new System.Windows.Forms.ToolStripButton();
            this.tsEdit = new System.Windows.Forms.ToolStripButton();
            this.tsDelete = new System.Windows.Forms.ToolStripButton();
            this.tsCmbFilterBy = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsSearchButton = new System.Windows.Forms.ToolStripButton();
            this.tsSearchField = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAreaProfile = new System.Windows.Forms.Button();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlAcquisition = new System.Windows.Forms.Panel();
            this.btnAcquisition = new System.Windows.Forms.Button();
            this.pnlReports = new System.Windows.Forms.Panel();
            this.btnReports = new System.Windows.Forms.Button();
            this.panel13 = new System.Windows.Forms.Panel();
            this.pnlUserPrivileges = new System.Windows.Forms.Panel();
            this.btnUserPrivileges = new System.Windows.Forms.Button();
            this.panel12 = new System.Windows.Forms.Panel();
            this.pnlUserManagement = new System.Windows.Forms.Panel();
            this.btnUserManagement = new System.Windows.Forms.Button();
            this.panel11 = new System.Windows.Forms.Panel();
            this.pnlLogout = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pnlClients = new System.Windows.Forms.Panel();
            this.btnClients = new System.Windows.Forms.Button();
            this.pnlIncomingPayments = new System.Windows.Forms.Panel();
            this.btnIncomingPayments = new System.Windows.Forms.Button();
            this.pnlOutgoingPayments = new System.Windows.Forms.Panel();
            this.btnOutgoingPayments = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pnlAgents = new System.Windows.Forms.Panel();
            this.btnAgents = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.pnlLots = new System.Windows.Forms.Panel();
            this.btnLots = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pnlAreaProfile = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblRole = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.pnlClientsContainer = new System.Windows.Forms.Panel();
            this.pnlAcquisitionContainer = new System.Windows.Forms.Panel();
            this.pnlIncomingPaymentContainer = new System.Windows.Forms.Panel();
            this.pnlOutgoingPaymentContainer = new System.Windows.Forms.Panel();
            this.pnlReportsContianer = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.pnlClientsContainer.SuspendLayout();
            this.pnlAcquisitionContainer.SuspendLayout();
            this.pnlIncomingPaymentContainer.SuspendLayout();
            this.pnlOutgoingPaymentContainer.SuspendLayout();
            this.pnlReportsContianer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MintCream;
            this.panel1.Controls.Add(this.tsMain);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1241, 86);
            this.panel1.TabIndex = 1;
            // 
            // tsMain
            // 
            this.tsMain.BackColor = System.Drawing.Color.Honeydew;
            this.tsMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsView,
            this.tsAdd,
            this.tsEdit,
            this.tsDelete,
            this.tsCmbFilterBy,
            this.toolStripLabel1,
            this.toolStripSeparator2,
            this.tsSearchButton,
            this.tsSearchField,
            this.toolStripLabel2});
            this.tsMain.Location = new System.Drawing.Point(200, 61);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1041, 25);
            this.tsMain.TabIndex = 5;
            this.tsMain.Text = "Tool Strip Main";
            this.tsMain.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical270;
            // 
            // tsView
            // 
            this.tsView.Image = ((System.Drawing.Image)(resources.GetObject("tsView.Image")));
            this.tsView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsView.Name = "tsView";
            this.tsView.Size = new System.Drawing.Size(52, 22);
            this.tsView.Text = "Vie&w";
            this.tsView.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.tsView.Click += new System.EventHandler(this.TsView_Click);
            // 
            // tsAdd
            // 
            this.tsAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsAdd.Image")));
            this.tsAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsAdd.Name = "tsAdd";
            this.tsAdd.Size = new System.Drawing.Size(51, 22);
            this.tsAdd.Text = "&New";
            this.tsAdd.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.tsAdd.Click += new System.EventHandler(this.TsAdd_Click);
            // 
            // tsEdit
            // 
            this.tsEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsEdit.Image")));
            this.tsEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsEdit.Name = "tsEdit";
            this.tsEdit.Size = new System.Drawing.Size(47, 22);
            this.tsEdit.Text = "&Edit";
            this.tsEdit.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.tsEdit.Click += new System.EventHandler(this.TsEdit_Click);
            // 
            // tsDelete
            // 
            this.tsDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsDelete.Image")));
            this.tsDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDelete.Name = "tsDelete";
            this.tsDelete.Size = new System.Drawing.Size(63, 22);
            this.tsDelete.Text = "&Cancel";
            this.tsDelete.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // tsCmbFilterBy
            // 
            this.tsCmbFilterBy.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsCmbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tsCmbFilterBy.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.tsCmbFilterBy.Name = "tsCmbFilterBy";
            this.tsCmbFilterBy.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsCmbFilterBy.Size = new System.Drawing.Size(121, 25);
            this.tsCmbFilterBy.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical270;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(52, 22);
            this.toolStripLabel1.Text = "Filter by:";
            this.toolStripLabel1.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.toolStripLabel1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator2.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical270;
            // 
            // tsSearchButton
            // 
            this.tsSearchButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsSearchButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsSearchButton.Image = ((System.Drawing.Image)(resources.GetObject("tsSearchButton.Image")));
            this.tsSearchButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSearchButton.Name = "tsSearchButton";
            this.tsSearchButton.Size = new System.Drawing.Size(23, 22);
            this.tsSearchButton.Text = "toolStripButton1";
            this.tsSearchButton.ToolTipText = "Search";
            // 
            // tsSearchField
            // 
            this.tsSearchField.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsSearchField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tsSearchField.Name = "tsSearchField";
            this.tsSearchField.Size = new System.Drawing.Size(150, 25);
            this.tsSearchField.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical270;
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(45, 22);
            this.toolStripLabel2.Text = "Search:";
            this.toolStripLabel2.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblTitle.Location = new System.Drawing.Point(206, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(0, 32);
            this.lblTitle.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 86);
            this.panel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MintCream;
            this.label1.Location = new System.Drawing.Point(17, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Elemino Realty";
            // 
            // btnAreaProfile
            // 
            this.btnAreaProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAreaProfile.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAreaProfile.FlatAppearance.BorderSize = 0;
            this.btnAreaProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAreaProfile.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAreaProfile.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnAreaProfile.Image = ((System.Drawing.Image)(resources.GetObject("btnAreaProfile.Image")));
            this.btnAreaProfile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAreaProfile.Location = new System.Drawing.Point(12, 0);
            this.btnAreaProfile.Name = "btnAreaProfile";
            this.btnAreaProfile.Size = new System.Drawing.Size(188, 51);
            this.btnAreaProfile.TabIndex = 0;
            this.btnAreaProfile.Text = " Area Profile";
            this.btnAreaProfile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAreaProfile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAreaProfile.UseVisualStyleBackColor = true;
            this.btnAreaProfile.Click += new System.EventHandler(this.BtnModule_Click);
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.MintCream;
            this.pnlSidebar.Controls.Add(this.pnlReportsContianer);
            this.pnlSidebar.Controls.Add(this.pnlOutgoingPaymentContainer);
            this.pnlSidebar.Controls.Add(this.pnlIncomingPaymentContainer);
            this.pnlSidebar.Controls.Add(this.pnlAcquisitionContainer);
            this.pnlSidebar.Controls.Add(this.pnlClientsContainer);
            this.pnlSidebar.Controls.Add(this.panel13);
            this.pnlSidebar.Controls.Add(this.panel12);
            this.pnlSidebar.Controls.Add(this.panel11);
            this.pnlSidebar.Controls.Add(this.panel6);
            this.pnlSidebar.Controls.Add(this.panel7);
            this.pnlSidebar.Controls.Add(this.panel5);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 86);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(200, 735);
            this.pnlSidebar.TabIndex = 2;
            // 
            // pnlAcquisition
            // 
            this.pnlAcquisition.BackColor = System.Drawing.Color.SeaGreen;
            this.pnlAcquisition.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAcquisition.Location = new System.Drawing.Point(0, 0);
            this.pnlAcquisition.Name = "pnlAcquisition";
            this.pnlAcquisition.Size = new System.Drawing.Size(10, 55);
            this.pnlAcquisition.TabIndex = 11;
            // 
            // btnAcquisition
            // 
            this.btnAcquisition.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAcquisition.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAcquisition.FlatAppearance.BorderSize = 0;
            this.btnAcquisition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcquisition.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcquisition.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnAcquisition.Image = ((System.Drawing.Image)(resources.GetObject("btnAcquisition.Image")));
            this.btnAcquisition.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAcquisition.Location = new System.Drawing.Point(12, 0);
            this.btnAcquisition.Name = "btnAcquisition";
            this.btnAcquisition.Size = new System.Drawing.Size(188, 55);
            this.btnAcquisition.TabIndex = 11;
            this.btnAcquisition.Text = " Acquisition";
            this.btnAcquisition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAcquisition.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAcquisition.UseVisualStyleBackColor = true;
            this.btnAcquisition.Click += new System.EventHandler(this.BtnModule_Click);
            // 
            // pnlReports
            // 
            this.pnlReports.BackColor = System.Drawing.Color.SeaGreen;
            this.pnlReports.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlReports.Location = new System.Drawing.Point(0, 0);
            this.pnlReports.Name = "pnlReports";
            this.pnlReports.Size = new System.Drawing.Size(10, 49);
            this.pnlReports.TabIndex = 14;
            // 
            // btnReports
            // 
            this.btnReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReports.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnReports.Image = ((System.Drawing.Image)(resources.GetObject("btnReports.Image")));
            this.btnReports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.Location = new System.Drawing.Point(13, 0);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(187, 49);
            this.btnReports.TabIndex = 14;
            this.btnReports.Text = " Reports";
            this.btnReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.BtnModule_Click);
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.pnlUserPrivileges);
            this.panel13.Controls.Add(this.btnUserPrivileges);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel13.Location = new System.Drawing.Point(0, 582);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(200, 51);
            this.panel13.TabIndex = 16;
            // 
            // pnlUserPrivileges
            // 
            this.pnlUserPrivileges.BackColor = System.Drawing.Color.SeaGreen;
            this.pnlUserPrivileges.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlUserPrivileges.Location = new System.Drawing.Point(0, 0);
            this.pnlUserPrivileges.Name = "pnlUserPrivileges";
            this.pnlUserPrivileges.Size = new System.Drawing.Size(10, 51);
            this.pnlUserPrivileges.TabIndex = 5;
            // 
            // btnUserPrivileges
            // 
            this.btnUserPrivileges.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUserPrivileges.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnUserPrivileges.FlatAppearance.BorderSize = 0;
            this.btnUserPrivileges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserPrivileges.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserPrivileges.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnUserPrivileges.Image = ((System.Drawing.Image)(resources.GetObject("btnUserPrivileges.Image")));
            this.btnUserPrivileges.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserPrivileges.Location = new System.Drawing.Point(12, 0);
            this.btnUserPrivileges.Name = "btnUserPrivileges";
            this.btnUserPrivileges.Size = new System.Drawing.Size(188, 51);
            this.btnUserPrivileges.TabIndex = 0;
            this.btnUserPrivileges.Text = " User Privileges";
            this.btnUserPrivileges.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserPrivileges.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUserPrivileges.UseVisualStyleBackColor = true;
            this.btnUserPrivileges.Click += new System.EventHandler(this.BtnModule_Click);
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.pnlUserManagement);
            this.panel12.Controls.Add(this.btnUserManagement);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel12.Location = new System.Drawing.Point(0, 633);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(200, 51);
            this.panel12.TabIndex = 14;
            // 
            // pnlUserManagement
            // 
            this.pnlUserManagement.BackColor = System.Drawing.Color.SeaGreen;
            this.pnlUserManagement.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlUserManagement.Location = new System.Drawing.Point(0, 0);
            this.pnlUserManagement.Name = "pnlUserManagement";
            this.pnlUserManagement.Size = new System.Drawing.Size(10, 51);
            this.pnlUserManagement.TabIndex = 5;
            // 
            // btnUserManagement
            // 
            this.btnUserManagement.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUserManagement.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnUserManagement.FlatAppearance.BorderSize = 0;
            this.btnUserManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserManagement.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserManagement.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnUserManagement.Image = ((System.Drawing.Image)(resources.GetObject("btnUserManagement.Image")));
            this.btnUserManagement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserManagement.Location = new System.Drawing.Point(12, 0);
            this.btnUserManagement.Name = "btnUserManagement";
            this.btnUserManagement.Size = new System.Drawing.Size(188, 51);
            this.btnUserManagement.TabIndex = 0;
            this.btnUserManagement.Text = " User Management";
            this.btnUserManagement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserManagement.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUserManagement.UseVisualStyleBackColor = true;
            this.btnUserManagement.Click += new System.EventHandler(this.BtnModule_Click);
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.pnlLogout);
            this.panel11.Controls.Add(this.btnLogout);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel11.Location = new System.Drawing.Point(0, 684);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(200, 51);
            this.panel11.TabIndex = 15;
            // 
            // pnlLogout
            // 
            this.pnlLogout.BackColor = System.Drawing.Color.MintCream;
            this.pnlLogout.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLogout.Location = new System.Drawing.Point(0, 0);
            this.pnlLogout.Name = "pnlLogout";
            this.pnlLogout.Size = new System.Drawing.Size(10, 51);
            this.pnlLogout.TabIndex = 5;
            // 
            // btnLogout
            // 
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(12, 0);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(188, 51);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = " Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // pnlClients
            // 
            this.pnlClients.BackColor = System.Drawing.Color.SeaGreen;
            this.pnlClients.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlClients.Location = new System.Drawing.Point(0, 0);
            this.pnlClients.Name = "pnlClients";
            this.pnlClients.Size = new System.Drawing.Size(10, 55);
            this.pnlClients.TabIndex = 10;
            // 
            // btnClients
            // 
            this.btnClients.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClients.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClients.FlatAppearance.BorderSize = 0;
            this.btnClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClients.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClients.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnClients.Image = ((System.Drawing.Image)(resources.GetObject("btnClients.Image")));
            this.btnClients.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClients.Location = new System.Drawing.Point(9, 0);
            this.btnClients.Name = "btnClients";
            this.btnClients.Size = new System.Drawing.Size(191, 55);
            this.btnClients.TabIndex = 10;
            this.btnClients.Text = " Clients";
            this.btnClients.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClients.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClients.UseVisualStyleBackColor = true;
            this.btnClients.Click += new System.EventHandler(this.BtnModule_Click);
            // 
            // pnlIncomingPayments
            // 
            this.pnlIncomingPayments.BackColor = System.Drawing.Color.SeaGreen;
            this.pnlIncomingPayments.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlIncomingPayments.Location = new System.Drawing.Point(0, 0);
            this.pnlIncomingPayments.Name = "pnlIncomingPayments";
            this.pnlIncomingPayments.Size = new System.Drawing.Size(10, 53);
            this.pnlIncomingPayments.TabIndex = 12;
            // 
            // btnIncomingPayments
            // 
            this.btnIncomingPayments.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIncomingPayments.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnIncomingPayments.FlatAppearance.BorderSize = 0;
            this.btnIncomingPayments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIncomingPayments.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncomingPayments.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnIncomingPayments.Image = ((System.Drawing.Image)(resources.GetObject("btnIncomingPayments.Image")));
            this.btnIncomingPayments.Location = new System.Drawing.Point(12, 0);
            this.btnIncomingPayments.Name = "btnIncomingPayments";
            this.btnIncomingPayments.Size = new System.Drawing.Size(188, 53);
            this.btnIncomingPayments.TabIndex = 12;
            this.btnIncomingPayments.Text = " Incoming Payments";
            this.btnIncomingPayments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIncomingPayments.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIncomingPayments.UseVisualStyleBackColor = true;
            this.btnIncomingPayments.Click += new System.EventHandler(this.BtnModule_Click);
            // 
            // pnlOutgoingPayments
            // 
            this.pnlOutgoingPayments.BackColor = System.Drawing.Color.SeaGreen;
            this.pnlOutgoingPayments.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlOutgoingPayments.Location = new System.Drawing.Point(0, 0);
            this.pnlOutgoingPayments.Name = "pnlOutgoingPayments";
            this.pnlOutgoingPayments.Size = new System.Drawing.Size(10, 49);
            this.pnlOutgoingPayments.TabIndex = 13;
            // 
            // btnOutgoingPayments
            // 
            this.btnOutgoingPayments.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOutgoingPayments.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOutgoingPayments.FlatAppearance.BorderSize = 0;
            this.btnOutgoingPayments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOutgoingPayments.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOutgoingPayments.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnOutgoingPayments.Image = ((System.Drawing.Image)(resources.GetObject("btnOutgoingPayments.Image")));
            this.btnOutgoingPayments.Location = new System.Drawing.Point(13, 0);
            this.btnOutgoingPayments.Name = "btnOutgoingPayments";
            this.btnOutgoingPayments.Size = new System.Drawing.Size(187, 49);
            this.btnOutgoingPayments.TabIndex = 13;
            this.btnOutgoingPayments.Text = " Outgoing Payments";
            this.btnOutgoingPayments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOutgoingPayments.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOutgoingPayments.UseVisualStyleBackColor = true;
            this.btnOutgoingPayments.Click += new System.EventHandler(this.BtnModule_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.pnlAgents);
            this.panel6.Controls.Add(this.btnAgents);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 102);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(200, 51);
            this.panel6.TabIndex = 9;
            // 
            // pnlAgents
            // 
            this.pnlAgents.BackColor = System.Drawing.Color.SeaGreen;
            this.pnlAgents.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAgents.Location = new System.Drawing.Point(0, 0);
            this.pnlAgents.Name = "pnlAgents";
            this.pnlAgents.Size = new System.Drawing.Size(10, 51);
            this.pnlAgents.TabIndex = 5;
            // 
            // btnAgents
            // 
            this.btnAgents.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgents.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAgents.FlatAppearance.BorderSize = 0;
            this.btnAgents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgents.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgents.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnAgents.Image = ((System.Drawing.Image)(resources.GetObject("btnAgents.Image")));
            this.btnAgents.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgents.Location = new System.Drawing.Point(12, 0);
            this.btnAgents.Name = "btnAgents";
            this.btnAgents.Size = new System.Drawing.Size(188, 51);
            this.btnAgents.TabIndex = 0;
            this.btnAgents.Text = " Agents";
            this.btnAgents.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgents.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgents.UseVisualStyleBackColor = true;
            this.btnAgents.Click += new System.EventHandler(this.BtnModule_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.pnlLots);
            this.panel7.Controls.Add(this.btnLots);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 51);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(200, 51);
            this.panel7.TabIndex = 8;
            // 
            // pnlLots
            // 
            this.pnlLots.BackColor = System.Drawing.Color.SeaGreen;
            this.pnlLots.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLots.Location = new System.Drawing.Point(0, 0);
            this.pnlLots.Name = "pnlLots";
            this.pnlLots.Size = new System.Drawing.Size(10, 51);
            this.pnlLots.TabIndex = 5;
            // 
            // btnLots
            // 
            this.btnLots.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLots.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLots.FlatAppearance.BorderSize = 0;
            this.btnLots.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLots.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLots.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnLots.Image = ((System.Drawing.Image)(resources.GetObject("btnLots.Image")));
            this.btnLots.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLots.Location = new System.Drawing.Point(12, 0);
            this.btnLots.Name = "btnLots";
            this.btnLots.Size = new System.Drawing.Size(188, 51);
            this.btnLots.TabIndex = 0;
            this.btnLots.Text = " Lots";
            this.btnLots.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLots.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLots.UseVisualStyleBackColor = true;
            this.btnLots.Click += new System.EventHandler(this.BtnModule_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.pnlAreaProfile);
            this.panel5.Controls.Add(this.btnAreaProfile);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(200, 51);
            this.panel5.TabIndex = 5;
            // 
            // pnlAreaProfile
            // 
            this.pnlAreaProfile.BackColor = System.Drawing.Color.SeaGreen;
            this.pnlAreaProfile.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAreaProfile.Location = new System.Drawing.Point(0, 0);
            this.pnlAreaProfile.Name = "pnlAreaProfile";
            this.pnlAreaProfile.Size = new System.Drawing.Size(10, 51);
            this.pnlAreaProfile.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SeaGreen;
            this.panel4.Controls.Add(this.lblRole);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.lblUser);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(200, 794);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1041, 27);
            this.panel4.TabIndex = 3;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.ForeColor = System.Drawing.Color.MintCream;
            this.lblRole.Location = new System.Drawing.Point(205, 6);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(0, 16);
            this.lblRole.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.MintCream;
            this.label4.Location = new System.Drawing.Point(165, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Role:";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.ForeColor = System.Drawing.Color.MintCream;
            this.lblUser.Location = new System.Drawing.Point(36, 6);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(0, 16);
            this.lblUser.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.MintCream;
            this.label2.Location = new System.Drawing.Point(6, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "User:";
            // 
            // dgvMain
            // 
            this.dgvMain.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMain.Location = new System.Drawing.Point(200, 86);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(1041, 708);
            this.dgvMain.TabIndex = 4;
            // 
            // pnlClientsContainer
            // 
            this.pnlClientsContainer.Controls.Add(this.pnlClients);
            this.pnlClientsContainer.Controls.Add(this.btnClients);
            this.pnlClientsContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlClientsContainer.Location = new System.Drawing.Point(0, 153);
            this.pnlClientsContainer.Name = "pnlClientsContainer";
            this.pnlClientsContainer.Size = new System.Drawing.Size(200, 55);
            this.pnlClientsContainer.TabIndex = 10;
            // 
            // pnlAcquisitionContainer
            // 
            this.pnlAcquisitionContainer.Controls.Add(this.btnAcquisition);
            this.pnlAcquisitionContainer.Controls.Add(this.pnlAcquisition);
            this.pnlAcquisitionContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAcquisitionContainer.Location = new System.Drawing.Point(0, 208);
            this.pnlAcquisitionContainer.Name = "pnlAcquisitionContainer";
            this.pnlAcquisitionContainer.Size = new System.Drawing.Size(200, 55);
            this.pnlAcquisitionContainer.TabIndex = 11;
            // 
            // pnlIncomingPaymentContainer
            // 
            this.pnlIncomingPaymentContainer.Controls.Add(this.btnIncomingPayments);
            this.pnlIncomingPaymentContainer.Controls.Add(this.pnlIncomingPayments);
            this.pnlIncomingPaymentContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlIncomingPaymentContainer.Location = new System.Drawing.Point(0, 263);
            this.pnlIncomingPaymentContainer.Name = "pnlIncomingPaymentContainer";
            this.pnlIncomingPaymentContainer.Size = new System.Drawing.Size(200, 53);
            this.pnlIncomingPaymentContainer.TabIndex = 12;
            // 
            // pnlOutgoingPaymentContainer
            // 
            this.pnlOutgoingPaymentContainer.Controls.Add(this.btnOutgoingPayments);
            this.pnlOutgoingPaymentContainer.Controls.Add(this.pnlOutgoingPayments);
            this.pnlOutgoingPaymentContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOutgoingPaymentContainer.Location = new System.Drawing.Point(0, 316);
            this.pnlOutgoingPaymentContainer.Name = "pnlOutgoingPaymentContainer";
            this.pnlOutgoingPaymentContainer.Size = new System.Drawing.Size(200, 49);
            this.pnlOutgoingPaymentContainer.TabIndex = 13;
            // 
            // pnlReportsContianer
            // 
            this.pnlReportsContianer.Controls.Add(this.btnReports);
            this.pnlReportsContianer.Controls.Add(this.pnlReports);
            this.pnlReportsContianer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlReportsContianer.Location = new System.Drawing.Point(0, 365);
            this.pnlReportsContianer.Name = "pnlReportsContianer";
            this.pnlReportsContianer.Size = new System.Drawing.Size(200, 49);
            this.pnlReportsContianer.TabIndex = 14;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1241, 821);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Property Records Tracking System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnlSidebar.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.pnlClientsContainer.ResumeLayout(false);
            this.pnlAcquisitionContainer.ResumeLayout(false);
            this.pnlIncomingPaymentContainer.ResumeLayout(false);
            this.pnlOutgoingPaymentContainer.ResumeLayout(false);
            this.pnlReportsContianer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAreaProfile;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel pnlAgents;
        private System.Windows.Forms.Button btnAgents;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel pnlLots;
        private System.Windows.Forms.Button btnLots;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel pnlAreaProfile;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel pnlLogout;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel pnlOutgoingPayments;
        private System.Windows.Forms.Button btnOutgoingPayments;
        private System.Windows.Forms.Panel pnlIncomingPayments;
        private System.Windows.Forms.Button btnIncomingPayments;
        private System.Windows.Forms.Panel pnlClients;
        private System.Windows.Forms.Button btnClients;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel pnlUserManagement;
        private System.Windows.Forms.Button btnUserManagement;
        private System.Windows.Forms.Panel pnlReports;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel pnlUserPrivileges;
        private System.Windows.Forms.Button btnUserPrivileges;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsView;
        private System.Windows.Forms.ToolStripButton tsAdd;
        private System.Windows.Forms.ToolStripButton tsEdit;
        private System.Windows.Forms.ToolStripButton tsDelete;
        private System.Windows.Forms.ToolStripTextBox tsSearchField;
        private System.Windows.Forms.ToolStripButton tsSearchButton;
        private System.Windows.Forms.ToolStripComboBox tsCmbFilterBy;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.Panel pnlAcquisition;
        private System.Windows.Forms.Button btnAcquisition;
        private System.Windows.Forms.Panel pnlIncomingPaymentContainer;
        private System.Windows.Forms.Panel pnlAcquisitionContainer;
        private System.Windows.Forms.Panel pnlClientsContainer;
        private System.Windows.Forms.Panel pnlOutgoingPaymentContainer;
        private System.Windows.Forms.Panel pnlReportsContianer;
    }
}

