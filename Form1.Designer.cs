namespace RestaurantTableReservation
{
    partial class Form1
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

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageTables;
        private System.Windows.Forms.TabPage tabPageReservations;
        private System.Windows.Forms.TabPage tabPageWaitlist;

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
        private System.Windows.Forms.DataGridView dataGridViewTables;

        private System.Windows.Forms.GroupBox groupBoxReservationDetails;
        private System.Windows.Forms.Label labelGuestName;
        private System.Windows.Forms.TextBox textBoxGuestName;
        private System.Windows.Forms.Label labelPartySize;
        private System.Windows.Forms.TextBox textBoxPartySize;
        private System.Windows.Forms.Label labelRequestedTime;
        private System.Windows.Forms.DateTimePicker dateTimePickerRequestedTime;
        private System.Windows.Forms.Label labelReservationTableNumber;
        private System.Windows.Forms.TextBox textBoxReservationTableNumber;
        private System.Windows.Forms.Button buttonCreateReservation;
        private System.Windows.Forms.Button buttonModifyReservation;
        private System.Windows.Forms.Button buttonDeleteReservation;
        private System.Windows.Forms.DataGridView dataGridViewReservations;

        private System.Windows.Forms.GroupBox groupBoxWaitlistDetails;
        private System.Windows.Forms.Label labelWaitlistGuestName;
        private System.Windows.Forms.TextBox textBoxWaitlistGuestName;
        private System.Windows.Forms.Label labelWaitlistPartySize;
        private System.Windows.Forms.TextBox textBoxWaitlistPartySize;
        private System.Windows.Forms.Button buttonAddWaitlist;
        private System.Windows.Forms.Button buttonModifyWaitlist;
        private System.Windows.Forms.Button buttonDeleteWaitlist;
        private System.Windows.Forms.Button buttonSeatParty;
        private System.Windows.Forms.DataGridView dataGridViewWaitlist;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageTables = new System.Windows.Forms.TabPage();
            this.tabPageReservations = new System.Windows.Forms.TabPage();
            this.tabPageWaitlist = new System.Windows.Forms.TabPage();

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
            this.dataGridViewTables = new System.Windows.Forms.DataGridView();

            this.groupBoxReservationDetails = new System.Windows.Forms.GroupBox();
            this.labelGuestName = new System.Windows.Forms.Label();
            this.textBoxGuestName = new System.Windows.Forms.TextBox();
            this.labelPartySize = new System.Windows.Forms.Label();
            this.textBoxPartySize = new System.Windows.Forms.TextBox();
            this.labelRequestedTime = new System.Windows.Forms.Label();
            this.dateTimePickerRequestedTime = new System.Windows.Forms.DateTimePicker();
            this.labelReservationTableNumber = new System.Windows.Forms.Label();
            this.textBoxReservationTableNumber = new System.Windows.Forms.TextBox();
            this.buttonCreateReservation = new System.Windows.Forms.Button();
            this.buttonModifyReservation = new System.Windows.Forms.Button();
            this.buttonDeleteReservation = new System.Windows.Forms.Button();
            this.dataGridViewReservations = new System.Windows.Forms.DataGridView();

            this.groupBoxWaitlistDetails = new System.Windows.Forms.GroupBox();
            this.labelWaitlistGuestName = new System.Windows.Forms.Label();
            this.textBoxWaitlistGuestName = new System.Windows.Forms.TextBox();
            this.labelWaitlistPartySize = new System.Windows.Forms.Label();
            this.textBoxWaitlistPartySize = new System.Windows.Forms.TextBox();
            this.buttonAddWaitlist = new System.Windows.Forms.Button();
            this.buttonModifyWaitlist = new System.Windows.Forms.Button();
            this.buttonDeleteWaitlist = new System.Windows.Forms.Button();
            this.buttonSeatParty = new System.Windows.Forms.Button();
            this.dataGridViewWaitlist = new System.Windows.Forms.DataGridView();

            this.tabControlMain.SuspendLayout();
            this.tabPageTables.SuspendLayout();
            this.tabPageReservations.SuspendLayout();
            this.tabPageWaitlist.SuspendLayout();
            this.groupBoxTableDetails.SuspendLayout();
            this.groupBoxReservationDetails.SuspendLayout();
            this.groupBoxWaitlistDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReservations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWaitlist)).BeginInit();
            this.SuspendLayout();

            //
            // tabControlMain
            //
            this.tabControlMain.Controls.Add(this.tabPageTables);
            this.tabControlMain.Controls.Add(this.tabPageReservations);
            this.tabControlMain.Controls.Add(this.tabPageWaitlist);
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Location = new System.Drawing.Point(15, 15);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(860, 540);

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

            this.buttonModifyTable.Location = new System.Drawing.Point(150, 100);
            this.buttonModifyTable.Name = "buttonModifyTable";
            this.buttonModifyTable.Size = new System.Drawing.Size(120, 32);
            this.buttonModifyTable.Text = "Modify";
            this.buttonModifyTable.UseVisualStyleBackColor = true;

            this.buttonDeleteTable.Location = new System.Drawing.Point(280, 100);
            this.buttonDeleteTable.Name = "buttonDeleteTable";
            this.buttonDeleteTable.Size = new System.Drawing.Size(120, 32);
            this.buttonDeleteTable.Text = "Delete";
            this.buttonDeleteTable.UseVisualStyleBackColor = true;

            //
            // dataGridViewTables
            //
            this.dataGridViewTables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewTables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTables.Location = new System.Drawing.Point(15, 170);
            this.dataGridViewTables.Name = "dataGridViewTables";
            this.dataGridViewTables.RowHeadersWidth = 62;
            this.dataGridViewTables.RowTemplate.Height = 28;
            this.dataGridViewTables.Size = new System.Drawing.Size(820, 320);

            //
            // tabPageReservations
            //
            this.tabPageReservations.Controls.Add(this.groupBoxReservationDetails);
            this.tabPageReservations.Controls.Add(this.dataGridViewReservations);
            this.tabPageReservations.Location = new System.Drawing.Point(4, 34);
            this.tabPageReservations.Name = "tabPageReservations";
            this.tabPageReservations.Size = new System.Drawing.Size(852, 502);
            this.tabPageReservations.Text = "Reservations";
            this.tabPageReservations.UseVisualStyleBackColor = true;

            //
            // groupBoxReservationDetails
            //
            this.groupBoxReservationDetails.Controls.Add(this.labelGuestName);
            this.groupBoxReservationDetails.Controls.Add(this.textBoxGuestName);
            this.groupBoxReservationDetails.Controls.Add(this.labelPartySize);
            this.groupBoxReservationDetails.Controls.Add(this.textBoxPartySize);
            this.groupBoxReservationDetails.Controls.Add(this.labelRequestedTime);
            this.groupBoxReservationDetails.Controls.Add(this.dateTimePickerRequestedTime);
            this.groupBoxReservationDetails.Controls.Add(this.labelReservationTableNumber);
            this.groupBoxReservationDetails.Controls.Add(this.textBoxReservationTableNumber);
            this.groupBoxReservationDetails.Controls.Add(this.buttonCreateReservation);
            this.groupBoxReservationDetails.Controls.Add(this.buttonModifyReservation);
            this.groupBoxReservationDetails.Controls.Add(this.buttonDeleteReservation);
            this.groupBoxReservationDetails.Location = new System.Drawing.Point(15, 10);
            this.groupBoxReservationDetails.Name = "groupBoxReservationDetails";
            this.groupBoxReservationDetails.Size = new System.Drawing.Size(820, 150);
            this.groupBoxReservationDetails.TabStop = false;
            this.groupBoxReservationDetails.Text = "Reservation Details";

            this.labelGuestName.AutoSize = true;
            this.labelGuestName.Location = new System.Drawing.Point(20, 30);
            this.labelGuestName.Name = "labelGuestName";
            this.labelGuestName.Text = "Guest Name";

            this.textBoxGuestName.Location = new System.Drawing.Point(20, 55);
            this.textBoxGuestName.Name = "textBoxGuestName";
            this.textBoxGuestName.Size = new System.Drawing.Size(180, 29);

            this.labelPartySize.AutoSize = true;
            this.labelPartySize.Location = new System.Drawing.Point(220, 30);
            this.labelPartySize.Name = "labelPartySize";
            this.labelPartySize.Text = "Party Size";

            this.textBoxPartySize.Location = new System.Drawing.Point(220, 55);
            this.textBoxPartySize.Name = "textBoxPartySize";
            this.textBoxPartySize.Size = new System.Drawing.Size(100, 29);

            this.labelRequestedTime.AutoSize = true;
            this.labelRequestedTime.Location = new System.Drawing.Point(340, 30);
            this.labelRequestedTime.Name = "labelRequestedTime";
            this.labelRequestedTime.Text = "Requested Time";

            this.dateTimePickerRequestedTime.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateTimePickerRequestedTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerRequestedTime.Location = new System.Drawing.Point(340, 55);
            this.dateTimePickerRequestedTime.Name = "dateTimePickerRequestedTime";
            this.dateTimePickerRequestedTime.Size = new System.Drawing.Size(180, 29);

            this.labelReservationTableNumber.AutoSize = true;
            this.labelReservationTableNumber.Location = new System.Drawing.Point(560, 30);
            this.labelReservationTableNumber.Name = "labelReservationTableNumber";
            this.labelReservationTableNumber.Text = "Table Number";

            this.textBoxReservationTableNumber.Location = new System.Drawing.Point(560, 55);
            this.textBoxReservationTableNumber.Name = "textBoxReservationTableNumber";
            this.textBoxReservationTableNumber.Size = new System.Drawing.Size(120, 29);

            this.buttonCreateReservation.Location = new System.Drawing.Point(20, 100);
            this.buttonCreateReservation.Name = "buttonCreateReservation";
            this.buttonCreateReservation.Size = new System.Drawing.Size(150, 32);
            this.buttonCreateReservation.Text = "Create Reservation";
            this.buttonCreateReservation.UseVisualStyleBackColor = true;

            this.buttonModifyReservation.Location = new System.Drawing.Point(180, 100);
            this.buttonModifyReservation.Name = "buttonModifyReservation";
            this.buttonModifyReservation.Size = new System.Drawing.Size(120, 32);
            this.buttonModifyReservation.Text = "Modify";
            this.buttonModifyReservation.UseVisualStyleBackColor = true;

            this.buttonDeleteReservation.Location = new System.Drawing.Point(310, 100);
            this.buttonDeleteReservation.Name = "buttonDeleteReservation";
            this.buttonDeleteReservation.Size = new System.Drawing.Size(120, 32);
            this.buttonDeleteReservation.Text = "Delete";
            this.buttonDeleteReservation.UseVisualStyleBackColor = true;

            //
            // dataGridViewReservations
            //
            this.dataGridViewReservations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewReservations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReservations.Location = new System.Drawing.Point(15, 170);
            this.dataGridViewReservations.Name = "dataGridViewReservations";
            this.dataGridViewReservations.RowHeadersWidth = 62;
            this.dataGridViewReservations.RowTemplate.Height = 28;
            this.dataGridViewReservations.Size = new System.Drawing.Size(820, 320);

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

            this.buttonAddWaitlist.Location = new System.Drawing.Point(20, 100);
            this.buttonAddWaitlist.Name = "buttonAddWaitlist";
            this.buttonAddWaitlist.Size = new System.Drawing.Size(150, 32);
            this.buttonAddWaitlist.Text = "Add to Waitlist";
            this.buttonAddWaitlist.UseVisualStyleBackColor = true;

            this.buttonModifyWaitlist.Location = new System.Drawing.Point(180, 100);
            this.buttonModifyWaitlist.Name = "buttonModifyWaitlist";
            this.buttonModifyWaitlist.Size = new System.Drawing.Size(120, 32);
            this.buttonModifyWaitlist.Text = "Modify";
            this.buttonModifyWaitlist.UseVisualStyleBackColor = true;

            this.buttonDeleteWaitlist.Location = new System.Drawing.Point(310, 100);
            this.buttonDeleteWaitlist.Name = "buttonDeleteWaitlist";
            this.buttonDeleteWaitlist.Size = new System.Drawing.Size(120, 32);
            this.buttonDeleteWaitlist.Text = "Delete";
            this.buttonDeleteWaitlist.UseVisualStyleBackColor = true;

            this.buttonSeatParty.Location = new System.Drawing.Point(440, 100);
            this.buttonSeatParty.Name = "buttonSeatParty";
            this.buttonSeatParty.Size = new System.Drawing.Size(120, 32);
            this.buttonSeatParty.Text = "Seat Party";
            this.buttonSeatParty.UseVisualStyleBackColor = true;

            //
            // dataGridViewWaitlist
            //
            this.dataGridViewWaitlist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewWaitlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWaitlist.Location = new System.Drawing.Point(15, 170);
            this.dataGridViewWaitlist.Name = "dataGridViewWaitlist";
            this.dataGridViewWaitlist.RowHeadersWidth = 62;
            this.dataGridViewWaitlist.RowTemplate.Height = 28;
            this.dataGridViewWaitlist.Size = new System.Drawing.Size(820, 320);

            //
            // Form1
            //
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 570);
            this.MinimumSize = new System.Drawing.Size(750, 450);
            this.Controls.Add(this.tabControlMain);
            this.Name = "Form1";
            this.Text = "Restaurant Table Reservation System";

            this.groupBoxTableDetails.ResumeLayout(false);
            this.groupBoxTableDetails.PerformLayout();
            this.groupBoxReservationDetails.ResumeLayout(false);
            this.groupBoxReservationDetails.PerformLayout();
            this.groupBoxWaitlistDetails.ResumeLayout(false);
            this.groupBoxWaitlistDetails.PerformLayout();
            this.tabPageTables.ResumeLayout(false);
            this.tabPageReservations.ResumeLayout(false);
            this.tabPageWaitlist.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReservations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWaitlist)).EndInit();
            this.tabControlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
