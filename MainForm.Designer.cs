namespace RestaurantTableReservation
{
    partial class MainForm
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

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuNewSystem;
        private System.Windows.Forms.ToolStripMenuItem menuLoadData;
        private System.Windows.Forms.ToolStripMenuItem menuSaveData;
        private System.Windows.Forms.ToolStripMenuItem menuManageTables;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageTables;
        private System.Windows.Forms.TabPage tabPageReservations;
        private System.Windows.Forms.TabPage tabPageWaitlist;
        private System.Windows.Forms.TabPage tabPageSummary;

        private System.Windows.Forms.GroupBox groupBoxTableDetails;
        private System.Windows.Forms.Label labelTableNumber;
        private System.Windows.Forms.TextBox textBoxTableNumber;
        private System.Windows.Forms.Label labelCapacity;
        private System.Windows.Forms.TextBox textBoxCapacity;
        private System.Windows.Forms.Label labelSection;
        private System.Windows.Forms.TextBox textBoxSection;
        private System.Windows.Forms.Button buttonAddTable;
        private System.Windows.Forms.Button buttonModifyTable;
        private System.Windows.Forms.Button buttonDeleteTable;
        private System.Windows.Forms.Button buttonMarkTableFree;
        private System.Windows.Forms.DataGridView dataGridViewTables;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTableNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCapacity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSection;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTableStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOccupiedSince;

        private System.Windows.Forms.Button buttonCreateReservation;
        private System.Windows.Forms.Button buttonModifyReservation;
        private System.Windows.Forms.Button buttonDeleteReservation;
        private System.Windows.Forms.Button buttonSeatReservation;
        private System.Windows.Forms.DataGridView dataGridViewReservations;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResGuestName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResPartySize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResTableNumber;

        private System.Windows.Forms.GroupBox groupBoxWaitlistDetails;
        private System.Windows.Forms.Label labelWaitlistGuestName;
        private System.Windows.Forms.TextBox textBoxWaitlistGuestName;
        private System.Windows.Forms.Label labelWaitlistPartySize;
        private System.Windows.Forms.TextBox textBoxWaitlistPartySize;
        private System.Windows.Forms.Label labelWaitlistTableNumber;
        private System.Windows.Forms.TextBox textBoxWaitlistTableNumber;
        private System.Windows.Forms.Button buttonAddWaitlist;
        private System.Windows.Forms.Button buttonModifyWaitlist;
        private System.Windows.Forms.Button buttonDeleteWaitlist;
        private System.Windows.Forms.Button buttonSeatParty;
        private System.Windows.Forms.DataGridView dataGridViewWaitlist;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWaitGuestName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWaitPartySize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWaitArrivalTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWaitEstimatedWait;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWaitStatus;

        private System.Windows.Forms.GroupBox groupBoxSearch;
        private System.Windows.Forms.Label labelSearchBy;
        private System.Windows.Forms.ComboBox comboBoxSearchBy;
        private System.Windows.Forms.Label labelSearchText;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.DataGridView dataGridViewSearchResults;
        private System.Windows.Forms.GroupBox groupBoxSummary;
        private System.Windows.Forms.Button buttonGenerateSummary;
        private System.Windows.Forms.Label labelTotalReservationsToday;
        private System.Windows.Forms.Label labelWaitlistLength;
        private System.Windows.Forms.Label labelAvgTurnover;
        private System.Windows.Forms.Label labelBusiestHour;
        private System.Windows.Forms.Label labelFeedback;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuNewSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLoadData = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveData = new System.Windows.Forms.ToolStripMenuItem();
            this.menuManageTables = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageTables = new System.Windows.Forms.TabPage();
            this.tabPageReservations = new System.Windows.Forms.TabPage();
            this.tabPageWaitlist = new System.Windows.Forms.TabPage();
            this.tabPageSummary = new System.Windows.Forms.TabPage();

            this.groupBoxTableDetails = new System.Windows.Forms.GroupBox();
            this.labelTableNumber = new System.Windows.Forms.Label();
            this.textBoxTableNumber = new System.Windows.Forms.TextBox();
            this.labelCapacity = new System.Windows.Forms.Label();
            this.textBoxCapacity = new System.Windows.Forms.TextBox();
            this.labelSection = new System.Windows.Forms.Label();
            this.textBoxSection = new System.Windows.Forms.TextBox();
            this.buttonAddTable = new System.Windows.Forms.Button();
            this.buttonModifyTable = new System.Windows.Forms.Button();
            this.buttonDeleteTable = new System.Windows.Forms.Button();
            this.buttonMarkTableFree = new System.Windows.Forms.Button();
            this.dataGridViewTables = new System.Windows.Forms.DataGridView();
            this.colTableNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCapacity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTableStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOccupiedSince = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.buttonCreateReservation = new System.Windows.Forms.Button();
            this.buttonModifyReservation = new System.Windows.Forms.Button();
            this.buttonDeleteReservation = new System.Windows.Forms.Button();
            this.buttonSeatReservation = new System.Windows.Forms.Button();
            this.dataGridViewReservations = new System.Windows.Forms.DataGridView();
            this.colResGuestName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResPartySize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResTableNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.groupBoxWaitlistDetails = new System.Windows.Forms.GroupBox();
            this.labelWaitlistGuestName = new System.Windows.Forms.Label();
            this.textBoxWaitlistGuestName = new System.Windows.Forms.TextBox();
            this.labelWaitlistPartySize = new System.Windows.Forms.Label();
            this.textBoxWaitlistPartySize = new System.Windows.Forms.TextBox();
            this.labelWaitlistTableNumber = new System.Windows.Forms.Label();
            this.textBoxWaitlistTableNumber = new System.Windows.Forms.TextBox();
            this.buttonAddWaitlist = new System.Windows.Forms.Button();
            this.buttonModifyWaitlist = new System.Windows.Forms.Button();
            this.buttonDeleteWaitlist = new System.Windows.Forms.Button();
            this.buttonSeatParty = new System.Windows.Forms.Button();
            this.dataGridViewWaitlist = new System.Windows.Forms.DataGridView();
            this.colWaitGuestName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWaitPartySize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWaitArrivalTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWaitEstimatedWait = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWaitStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.groupBoxSearch = new System.Windows.Forms.GroupBox();
            this.labelSearchBy = new System.Windows.Forms.Label();
            this.comboBoxSearchBy = new System.Windows.Forms.ComboBox();
            this.labelSearchText = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.dataGridViewSearchResults = new System.Windows.Forms.DataGridView();
            this.groupBoxSummary = new System.Windows.Forms.GroupBox();
            this.buttonGenerateSummary = new System.Windows.Forms.Button();
            this.labelTotalReservationsToday = new System.Windows.Forms.Label();
            this.labelWaitlistLength = new System.Windows.Forms.Label();
            this.labelAvgTurnover = new System.Windows.Forms.Label();
            this.labelBusiestHour = new System.Windows.Forms.Label();
            this.labelFeedback = new System.Windows.Forms.Label();

            this.tabControlMain.SuspendLayout();
            this.tabPageTables.SuspendLayout();
            this.tabPageReservations.SuspendLayout();
            this.tabPageWaitlist.SuspendLayout();
            this.tabPageSummary.SuspendLayout();
            this.groupBoxTableDetails.SuspendLayout();
            this.groupBoxWaitlistDetails.SuspendLayout();
            this.groupBoxSearch.SuspendLayout();
            this.groupBoxSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReservations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWaitlist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSearchResults)).BeginInit();
            this.SuspendLayout();

            //
            // menuStrip1
            //
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.menuNewSystem,
                this.menuLoadData,
                this.menuSaveData,
                this.menuManageTables,
                this.menuExit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(890, 24);

            this.menuNewSystem.Name = "menuNewSystem";
            this.menuNewSystem.Text = "New System";
            this.menuNewSystem.Click += new System.EventHandler(this.menuNewSystem_Click);

            this.menuLoadData.Name = "menuLoadData";
            this.menuLoadData.Text = "Load Data";
            this.menuLoadData.Click += new System.EventHandler(this.menuLoadData_Click);

            this.menuSaveData.Name = "menuSaveData";
            this.menuSaveData.Text = "Save Data";
            this.menuSaveData.Click += new System.EventHandler(this.menuSaveData_Click);

            this.menuManageTables.Name = "menuManageTables";
            this.menuManageTables.Text = "Manage Tables";
            this.menuManageTables.Click += new System.EventHandler(this.menuManageTables_Click);

            this.menuExit.Name = "menuExit";
            this.menuExit.Text = "Exit";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);

            //
            // tabControlMain
            //
            this.tabControlMain.Controls.Add(this.tabPageTables);
            this.tabControlMain.Controls.Add(this.tabPageReservations);
            this.tabControlMain.Controls.Add(this.tabPageWaitlist);
            this.tabControlMain.Controls.Add(this.tabPageSummary);
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Location = new System.Drawing.Point(15, 30);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(860, 525);

            //
            // tabPageTables
            //
            this.tabPageTables.Controls.Add(this.groupBoxTableDetails);
            this.tabPageTables.Controls.Add(this.dataGridViewTables);
            this.tabPageTables.Location = new System.Drawing.Point(4, 34);
            this.tabPageTables.Name = "tabPageTables";
            this.tabPageTables.Size = new System.Drawing.Size(852, 502);
            this.tabPageTables.Text = "Tables";
            this.tabPageTables.UseVisualStyleBackColor = true;

            //
            // groupBoxTableDetails
            //
            this.groupBoxTableDetails.Controls.Add(this.labelTableNumber);
            this.groupBoxTableDetails.Controls.Add(this.textBoxTableNumber);
            this.groupBoxTableDetails.Controls.Add(this.labelCapacity);
            this.groupBoxTableDetails.Controls.Add(this.textBoxCapacity);
            this.groupBoxTableDetails.Controls.Add(this.labelSection);
            this.groupBoxTableDetails.Controls.Add(this.textBoxSection);
            this.groupBoxTableDetails.Controls.Add(this.buttonAddTable);
            this.groupBoxTableDetails.Controls.Add(this.buttonModifyTable);
            this.groupBoxTableDetails.Controls.Add(this.buttonDeleteTable);
            this.groupBoxTableDetails.Controls.Add(this.buttonMarkTableFree);
            this.groupBoxTableDetails.Location = new System.Drawing.Point(15, 10);
            this.groupBoxTableDetails.Name = "groupBoxTableDetails";
            this.groupBoxTableDetails.Size = new System.Drawing.Size(820, 150);
            this.groupBoxTableDetails.TabStop = false;
            this.groupBoxTableDetails.Text = "Table Details";

            this.labelTableNumber.AutoSize = true;
            this.labelTableNumber.Location = new System.Drawing.Point(20, 30);
            this.labelTableNumber.Name = "labelTableNumber";
            this.labelTableNumber.Text = "Table Number";

            this.textBoxTableNumber.Location = new System.Drawing.Point(20, 55);
            this.textBoxTableNumber.Name = "textBoxTableNumber";
            this.textBoxTableNumber.Size = new System.Drawing.Size(160, 29);

            this.labelCapacity.AutoSize = true;
            this.labelCapacity.Location = new System.Drawing.Point(220, 30);
            this.labelCapacity.Name = "labelCapacity";
            this.labelCapacity.Text = "Capacity";

            this.textBoxCapacity.Location = new System.Drawing.Point(220, 55);
            this.textBoxCapacity.Name = "textBoxCapacity";
            this.textBoxCapacity.Size = new System.Drawing.Size(160, 29);

            this.labelSection.AutoSize = true;
            this.labelSection.Location = new System.Drawing.Point(420, 30);
            this.labelSection.Name = "labelSection";
            this.labelSection.Text = "Section";

            this.textBoxSection.Location = new System.Drawing.Point(420, 55);
            this.textBoxSection.Name = "textBoxSection";
            this.textBoxSection.Size = new System.Drawing.Size(220, 29);

            this.buttonAddTable.Location = new System.Drawing.Point(20, 100);
            this.buttonAddTable.Name = "buttonAddTable";
            this.buttonAddTable.Size = new System.Drawing.Size(120, 32);
            this.buttonAddTable.Text = "Add Table";
            this.buttonAddTable.UseVisualStyleBackColor = true;
            this.buttonAddTable.Click += new System.EventHandler(this.buttonAddTable_Click);

            this.buttonModifyTable.Location = new System.Drawing.Point(150, 100);
            this.buttonModifyTable.Name = "buttonModifyTable";
            this.buttonModifyTable.Size = new System.Drawing.Size(120, 32);
            this.buttonModifyTable.Text = "Modify";
            this.buttonModifyTable.UseVisualStyleBackColor = true;
            this.buttonModifyTable.Click += new System.EventHandler(this.buttonModifyTable_Click);

            this.buttonDeleteTable.Location = new System.Drawing.Point(280, 100);
            this.buttonDeleteTable.Name = "buttonDeleteTable";
            this.buttonDeleteTable.Size = new System.Drawing.Size(120, 32);
            this.buttonDeleteTable.Text = "Delete";
            this.buttonDeleteTable.UseVisualStyleBackColor = true;
            this.buttonDeleteTable.Click += new System.EventHandler(this.buttonDeleteTable_Click);

            this.buttonMarkTableFree.Location = new System.Drawing.Point(410, 100);
            this.buttonMarkTableFree.Name = "buttonMarkTableFree";
            this.buttonMarkTableFree.Size = new System.Drawing.Size(140, 32);
            this.buttonMarkTableFree.Text = "Mark Table Free";
            this.buttonMarkTableFree.UseVisualStyleBackColor = true;
            this.buttonMarkTableFree.Click += new System.EventHandler(this.buttonMarkTableFree_Click);

            //
            // colTableNumber
            //
            this.colTableNumber.HeaderText = "Table Number";
            this.colTableNumber.Name = "colTableNumber";
            //
            // colCapacity
            //
            this.colCapacity.HeaderText = "Capacity";
            this.colCapacity.Name = "colCapacity";
            //
            // colSection
            //
            this.colSection.HeaderText = "Section";
            this.colSection.Name = "colSection";
            //
            // colTableStatus
            //
            this.colTableStatus.HeaderText = "Status";
            this.colTableStatus.Name = "colTableStatus";
            //
            // colOccupiedSince
            //
            this.colOccupiedSince.HeaderText = "Occupied Since";
            this.colOccupiedSince.Name = "colOccupiedSince";

            //
            // dataGridViewTables
            //
            this.dataGridViewTables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewTables.AllowUserToAddRows = false;
            this.dataGridViewTables.ReadOnly = true;
            this.dataGridViewTables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colTableNumber,
                this.colCapacity,
                this.colSection,
                this.colTableStatus,
                this.colOccupiedSince});
            this.dataGridViewTables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTables.Location = new System.Drawing.Point(15, 170);
            this.dataGridViewTables.Name = "dataGridViewTables";
            this.dataGridViewTables.RowHeadersWidth = 62;
            this.dataGridViewTables.RowTemplate.Height = 28;
            this.dataGridViewTables.Size = new System.Drawing.Size(820, 320);
            this.dataGridViewTables.SelectionChanged += new System.EventHandler(this.dataGridViewTables_SelectionChanged);

            //
            // tabPageReservations
            //
            this.tabPageReservations.Controls.Add(this.buttonCreateReservation);
            this.tabPageReservations.Controls.Add(this.buttonModifyReservation);
            this.tabPageReservations.Controls.Add(this.buttonDeleteReservation);
            this.tabPageReservations.Controls.Add(this.buttonSeatReservation);
            this.tabPageReservations.Controls.Add(this.dataGridViewReservations);
            this.tabPageReservations.Location = new System.Drawing.Point(4, 34);
            this.tabPageReservations.Name = "tabPageReservations";
            this.tabPageReservations.Size = new System.Drawing.Size(852, 502);
            this.tabPageReservations.Text = "Reservations";
            this.tabPageReservations.UseVisualStyleBackColor = true;

            //
            // buttonCreateReservation
            //
            this.buttonCreateReservation.Location = new System.Drawing.Point(15, 10);
            this.buttonCreateReservation.Name = "buttonCreateReservation";
            this.buttonCreateReservation.Size = new System.Drawing.Size(150, 32);
            this.buttonCreateReservation.Text = "Create Reservation";
            this.buttonCreateReservation.UseVisualStyleBackColor = true;
            this.buttonCreateReservation.Click += new System.EventHandler(this.buttonCreateReservation_Click);

            this.buttonModifyReservation.Location = new System.Drawing.Point(175, 10);
            this.buttonModifyReservation.Name = "buttonModifyReservation";
            this.buttonModifyReservation.Size = new System.Drawing.Size(120, 32);
            this.buttonModifyReservation.Text = "Modify";
            this.buttonModifyReservation.UseVisualStyleBackColor = true;
            this.buttonModifyReservation.Click += new System.EventHandler(this.buttonModifyReservation_Click);

            this.buttonDeleteReservation.Location = new System.Drawing.Point(305, 10);
            this.buttonDeleteReservation.Name = "buttonDeleteReservation";
            this.buttonDeleteReservation.Size = new System.Drawing.Size(120, 32);
            this.buttonDeleteReservation.Text = "Delete";
            this.buttonDeleteReservation.UseVisualStyleBackColor = true;
            this.buttonDeleteReservation.Click += new System.EventHandler(this.buttonDeleteReservation_Click);

            this.buttonSeatReservation.Location = new System.Drawing.Point(435, 10);
            this.buttonSeatReservation.Name = "buttonSeatReservation";
            this.buttonSeatReservation.Size = new System.Drawing.Size(120, 32);
            this.buttonSeatReservation.Text = "Seat Party";
            this.buttonSeatReservation.UseVisualStyleBackColor = true;
            this.buttonSeatReservation.Click += new System.EventHandler(this.buttonSeatReservation_Click);

            //
            // colResGuestName
            //
            this.colResGuestName.HeaderText = "Guest Name";
            this.colResGuestName.Name = "colResGuestName";
            //
            // colResPartySize
            //
            this.colResPartySize.HeaderText = "Party Size";
            this.colResPartySize.Name = "colResPartySize";
            //
            // colResTime
            //
            this.colResTime.HeaderText = "Requested Time";
            this.colResTime.Name = "colResTime";
            //
            // colResTableNumber
            //
            this.colResTableNumber.HeaderText = "Table Number";
            this.colResTableNumber.Name = "colResTableNumber";

            //
            // dataGridViewReservations
            //
            this.dataGridViewReservations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewReservations.AllowUserToAddRows = false;
            this.dataGridViewReservations.ReadOnly = true;
            this.dataGridViewReservations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colResGuestName,
                this.colResPartySize,
                this.colResTime,
                this.colResTableNumber});
            this.dataGridViewReservations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReservations.Location = new System.Drawing.Point(15, 55);
            this.dataGridViewReservations.Name = "dataGridViewReservations";
            this.dataGridViewReservations.RowHeadersWidth = 62;
            this.dataGridViewReservations.RowTemplate.Height = 28;
            this.dataGridViewReservations.Size = new System.Drawing.Size(820, 435);

            //
            // tabPageWaitlist
            //
            this.tabPageWaitlist.Controls.Add(this.groupBoxWaitlistDetails);
            this.tabPageWaitlist.Controls.Add(this.dataGridViewWaitlist);
            this.tabPageWaitlist.Location = new System.Drawing.Point(4, 34);
            this.tabPageWaitlist.Name = "tabPageWaitlist";
            this.tabPageWaitlist.Size = new System.Drawing.Size(852, 502);
            this.tabPageWaitlist.Text = "Waitlist";
            this.tabPageWaitlist.UseVisualStyleBackColor = true;

            //
            // groupBoxWaitlistDetails
            //
            this.groupBoxWaitlistDetails.Controls.Add(this.labelWaitlistGuestName);
            this.groupBoxWaitlistDetails.Controls.Add(this.textBoxWaitlistGuestName);
            this.groupBoxWaitlistDetails.Controls.Add(this.labelWaitlistPartySize);
            this.groupBoxWaitlistDetails.Controls.Add(this.textBoxWaitlistPartySize);
            this.groupBoxWaitlistDetails.Controls.Add(this.labelWaitlistTableNumber);
            this.groupBoxWaitlistDetails.Controls.Add(this.textBoxWaitlistTableNumber);
            this.groupBoxWaitlistDetails.Controls.Add(this.buttonAddWaitlist);
            this.groupBoxWaitlistDetails.Controls.Add(this.buttonModifyWaitlist);
            this.groupBoxWaitlistDetails.Controls.Add(this.buttonDeleteWaitlist);
            this.groupBoxWaitlistDetails.Controls.Add(this.buttonSeatParty);
            this.groupBoxWaitlistDetails.Location = new System.Drawing.Point(15, 10);
            this.groupBoxWaitlistDetails.Name = "groupBoxWaitlistDetails";
            this.groupBoxWaitlistDetails.Size = new System.Drawing.Size(820, 150);
            this.groupBoxWaitlistDetails.TabStop = false;
            this.groupBoxWaitlistDetails.Text = "Waitlist Details";

            this.labelWaitlistGuestName.AutoSize = true;
            this.labelWaitlistGuestName.Location = new System.Drawing.Point(20, 30);
            this.labelWaitlistGuestName.Name = "labelWaitlistGuestName";
            this.labelWaitlistGuestName.Text = "Guest Name";

            this.textBoxWaitlistGuestName.Location = new System.Drawing.Point(20, 55);
            this.textBoxWaitlistGuestName.Name = "textBoxWaitlistGuestName";
            this.textBoxWaitlistGuestName.Size = new System.Drawing.Size(200, 29);

            this.labelWaitlistPartySize.AutoSize = true;
            this.labelWaitlistPartySize.Location = new System.Drawing.Point(240, 30);
            this.labelWaitlistPartySize.Name = "labelWaitlistPartySize";
            this.labelWaitlistPartySize.Text = "Party Size";

            this.textBoxWaitlistPartySize.Location = new System.Drawing.Point(240, 55);
            this.textBoxWaitlistPartySize.Name = "textBoxWaitlistPartySize";
            this.textBoxWaitlistPartySize.Size = new System.Drawing.Size(100, 29);

            this.labelWaitlistTableNumber.AutoSize = true;
            this.labelWaitlistTableNumber.Location = new System.Drawing.Point(360, 30);
            this.labelWaitlistTableNumber.Name = "labelWaitlistTableNumber";
            this.labelWaitlistTableNumber.Text = "Seat At Table Number";

            this.textBoxWaitlistTableNumber.Location = new System.Drawing.Point(360, 55);
            this.textBoxWaitlistTableNumber.Name = "textBoxWaitlistTableNumber";
            this.textBoxWaitlistTableNumber.Size = new System.Drawing.Size(120, 29);

            this.buttonAddWaitlist.Location = new System.Drawing.Point(20, 100);
            this.buttonAddWaitlist.Name = "buttonAddWaitlist";
            this.buttonAddWaitlist.Size = new System.Drawing.Size(150, 32);
            this.buttonAddWaitlist.Text = "Add to Waitlist";
            this.buttonAddWaitlist.UseVisualStyleBackColor = true;
            this.buttonAddWaitlist.Click += new System.EventHandler(this.buttonAddWaitlist_Click);

            this.buttonModifyWaitlist.Location = new System.Drawing.Point(180, 100);
            this.buttonModifyWaitlist.Name = "buttonModifyWaitlist";
            this.buttonModifyWaitlist.Size = new System.Drawing.Size(120, 32);
            this.buttonModifyWaitlist.Text = "Modify";
            this.buttonModifyWaitlist.UseVisualStyleBackColor = true;
            this.buttonModifyWaitlist.Click += new System.EventHandler(this.buttonModifyWaitlist_Click);

            this.buttonDeleteWaitlist.Location = new System.Drawing.Point(310, 100);
            this.buttonDeleteWaitlist.Name = "buttonDeleteWaitlist";
            this.buttonDeleteWaitlist.Size = new System.Drawing.Size(120, 32);
            this.buttonDeleteWaitlist.Text = "Delete";
            this.buttonDeleteWaitlist.UseVisualStyleBackColor = true;
            this.buttonDeleteWaitlist.Click += new System.EventHandler(this.buttonDeleteWaitlist_Click);

            this.buttonSeatParty.Location = new System.Drawing.Point(440, 100);
            this.buttonSeatParty.Name = "buttonSeatParty";
            this.buttonSeatParty.Size = new System.Drawing.Size(120, 32);
            this.buttonSeatParty.Text = "Seat Party";
            this.buttonSeatParty.UseVisualStyleBackColor = true;
            this.buttonSeatParty.Click += new System.EventHandler(this.buttonSeatParty_Click);

            //
            // colWaitGuestName
            //
            this.colWaitGuestName.HeaderText = "Guest Name";
            this.colWaitGuestName.Name = "colWaitGuestName";
            //
            // colWaitPartySize
            //
            this.colWaitPartySize.HeaderText = "Party Size";
            this.colWaitPartySize.Name = "colWaitPartySize";
            //
            // colWaitArrivalTime
            //
            this.colWaitArrivalTime.HeaderText = "Arrival Time";
            this.colWaitArrivalTime.Name = "colWaitArrivalTime";
            //
            // colWaitEstimatedWait
            //
            this.colWaitEstimatedWait.HeaderText = "Estimated Wait (min)";
            this.colWaitEstimatedWait.Name = "colWaitEstimatedWait";
            //
            // colWaitStatus
            //
            this.colWaitStatus.HeaderText = "Status";
            this.colWaitStatus.Name = "colWaitStatus";

            //
            // dataGridViewWaitlist
            //
            this.dataGridViewWaitlist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewWaitlist.AllowUserToAddRows = false;
            this.dataGridViewWaitlist.ReadOnly = true;
            this.dataGridViewWaitlist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colWaitGuestName,
                this.colWaitPartySize,
                this.colWaitArrivalTime,
                this.colWaitEstimatedWait,
                this.colWaitStatus});
            this.dataGridViewWaitlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWaitlist.Location = new System.Drawing.Point(15, 170);
            this.dataGridViewWaitlist.Name = "dataGridViewWaitlist";
            this.dataGridViewWaitlist.RowHeadersWidth = 62;
            this.dataGridViewWaitlist.RowTemplate.Height = 28;
            this.dataGridViewWaitlist.Size = new System.Drawing.Size(820, 320);
            this.dataGridViewWaitlist.SelectionChanged += new System.EventHandler(this.dataGridViewWaitlist_SelectionChanged);

            //
            // tabPageSummary
            //
            this.tabPageSummary.Controls.Add(this.groupBoxSearch);
            this.tabPageSummary.Controls.Add(this.dataGridViewSearchResults);
            this.tabPageSummary.Controls.Add(this.groupBoxSummary);
            this.tabPageSummary.Location = new System.Drawing.Point(4, 34);
            this.tabPageSummary.Name = "tabPageSummary";
            this.tabPageSummary.Size = new System.Drawing.Size(852, 502);
            this.tabPageSummary.Text = "Summary && Search";
            this.tabPageSummary.UseVisualStyleBackColor = true;

            //
            // groupBoxSearch
            //
            this.groupBoxSearch.Controls.Add(this.labelSearchBy);
            this.groupBoxSearch.Controls.Add(this.comboBoxSearchBy);
            this.groupBoxSearch.Controls.Add(this.labelSearchText);
            this.groupBoxSearch.Controls.Add(this.textBoxSearch);
            this.groupBoxSearch.Controls.Add(this.buttonSearch);
            this.groupBoxSearch.Location = new System.Drawing.Point(15, 10);
            this.groupBoxSearch.Name = "groupBoxSearch";
            this.groupBoxSearch.Size = new System.Drawing.Size(820, 90);
            this.groupBoxSearch.TabStop = false;
            this.groupBoxSearch.Text = "Search";

            this.labelSearchBy.AutoSize = true;
            this.labelSearchBy.Location = new System.Drawing.Point(20, 20);
            this.labelSearchBy.Name = "labelSearchBy";
            this.labelSearchBy.Text = "Search By";

            this.comboBoxSearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearchBy.Location = new System.Drawing.Point(20, 40);
            this.comboBoxSearchBy.Name = "comboBoxSearchBy";
            this.comboBoxSearchBy.Size = new System.Drawing.Size(180, 29);
            this.comboBoxSearchBy.Items.AddRange(new object[] {
                "Guest Name",
                "Table Number",
                "Reservation Time",
                "Waitlist Status"});

            this.labelSearchText.AutoSize = true;
            this.labelSearchText.Location = new System.Drawing.Point(220, 20);
            this.labelSearchText.Name = "labelSearchText";
            this.labelSearchText.Text = "Search Text";

            this.textBoxSearch.Location = new System.Drawing.Point(220, 40);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(220, 29);

            this.buttonSearch.Location = new System.Drawing.Point(460, 38);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(120, 32);
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);

            //
            // dataGridViewSearchResults
            // columns get added in code depending on search type
            //
            this.dataGridViewSearchResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSearchResults.AllowUserToAddRows = false;
            this.dataGridViewSearchResults.ReadOnly = true;
            this.dataGridViewSearchResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSearchResults.Location = new System.Drawing.Point(15, 110);
            this.dataGridViewSearchResults.Name = "dataGridViewSearchResults";
            this.dataGridViewSearchResults.RowHeadersWidth = 62;
            this.dataGridViewSearchResults.RowTemplate.Height = 28;
            this.dataGridViewSearchResults.Size = new System.Drawing.Size(820, 180);

            //
            // groupBoxSummary
            //
            this.groupBoxSummary.Controls.Add(this.buttonGenerateSummary);
            this.groupBoxSummary.Controls.Add(this.labelTotalReservationsToday);
            this.groupBoxSummary.Controls.Add(this.labelWaitlistLength);
            this.groupBoxSummary.Controls.Add(this.labelAvgTurnover);
            this.groupBoxSummary.Controls.Add(this.labelBusiestHour);
            this.groupBoxSummary.Controls.Add(this.labelFeedback);
            this.groupBoxSummary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSummary.Location = new System.Drawing.Point(15, 300);
            this.groupBoxSummary.Name = "groupBoxSummary";
            this.groupBoxSummary.Size = new System.Drawing.Size(820, 195);
            this.groupBoxSummary.TabStop = false;
            this.groupBoxSummary.Text = "Service Summary";

            this.buttonGenerateSummary.Location = new System.Drawing.Point(20, 30);
            this.buttonGenerateSummary.Name = "buttonGenerateSummary";
            this.buttonGenerateSummary.Size = new System.Drawing.Size(180, 32);
            this.buttonGenerateSummary.Text = "Generate Summary";
            this.buttonGenerateSummary.UseVisualStyleBackColor = true;
            this.buttonGenerateSummary.Click += new System.EventHandler(this.buttonGenerateSummary_Click);

            this.labelTotalReservationsToday.AutoSize = true;
            this.labelTotalReservationsToday.Location = new System.Drawing.Point(20, 75);
            this.labelTotalReservationsToday.Name = "labelTotalReservationsToday";
            this.labelTotalReservationsToday.Text = "Total reservations today: -";

            this.labelWaitlistLength.AutoSize = true;
            this.labelWaitlistLength.Location = new System.Drawing.Point(20, 99);
            this.labelWaitlistLength.Name = "labelWaitlistLength";
            this.labelWaitlistLength.Text = "Current waitlist length: -";

            this.labelAvgTurnover.AutoSize = true;
            this.labelAvgTurnover.Location = new System.Drawing.Point(20, 123);
            this.labelAvgTurnover.Name = "labelAvgTurnover";
            this.labelAvgTurnover.Text = "Average table turnover: -";

            this.labelBusiestHour.AutoSize = true;
            this.labelBusiestHour.Location = new System.Drawing.Point(20, 147);
            this.labelBusiestHour.Name = "labelBusiestHour";
            this.labelBusiestHour.Text = "Busiest hour: -";

            this.labelFeedback.AutoSize = true;
            this.labelFeedback.Location = new System.Drawing.Point(20, 171);
            this.labelFeedback.Name = "labelFeedback";
            this.labelFeedback.Text = "";

            //
            // MainForm
            //
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 570);
            this.MinimumSize = new System.Drawing.Size(750, 450);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Restaurant Table Reservation System";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);

            this.groupBoxTableDetails.ResumeLayout(false);
            this.groupBoxTableDetails.PerformLayout();
            this.groupBoxWaitlistDetails.ResumeLayout(false);
            this.groupBoxWaitlistDetails.PerformLayout();
            this.groupBoxSearch.ResumeLayout(false);
            this.groupBoxSearch.PerformLayout();
            this.groupBoxSummary.ResumeLayout(false);
            this.groupBoxSummary.PerformLayout();
            this.tabPageTables.ResumeLayout(false);
            this.tabPageReservations.ResumeLayout(false);
            this.tabPageWaitlist.ResumeLayout(false);
            this.tabPageSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReservations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWaitlist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSearchResults)).EndInit();
            this.tabControlMain.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
