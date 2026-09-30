namespace RestaurantTableReservation
{
    partial class ReservationForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private System.Windows.Forms.Label labelGuestName;
        private System.Windows.Forms.TextBox textBoxGuestName;
        private System.Windows.Forms.Label labelPartySize;
        private System.Windows.Forms.TextBox textBoxPartySize;
        private System.Windows.Forms.Label labelRequestedTime;
        private System.Windows.Forms.DateTimePicker dateTimePickerRequestedTime;
        private System.Windows.Forms.Label labelTableNumber;
        private System.Windows.Forms.TextBox textBoxTableNumber;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;

        private void InitializeComponent()
        {
            this.labelGuestName = new System.Windows.Forms.Label();
            this.textBoxGuestName = new System.Windows.Forms.TextBox();
            this.labelPartySize = new System.Windows.Forms.Label();
            this.textBoxPartySize = new System.Windows.Forms.TextBox();
            this.labelRequestedTime = new System.Windows.Forms.Label();
            this.dateTimePickerRequestedTime = new System.Windows.Forms.DateTimePicker();
            this.labelTableNumber = new System.Windows.Forms.Label();
            this.textBoxTableNumber = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // labelGuestName
            //
            this.labelGuestName.AutoSize = true;
            this.labelGuestName.Location = new System.Drawing.Point(20, 20);
            this.labelGuestName.Name = "labelGuestName";
            this.labelGuestName.Text = "Guest Name";
            //
            // textBoxGuestName
            //
            this.textBoxGuestName.Location = new System.Drawing.Point(20, 40);
            this.textBoxGuestName.Name = "textBoxGuestName";
            this.textBoxGuestName.Size = new System.Drawing.Size(280, 29);
            //
            // labelPartySize
            //
            this.labelPartySize.AutoSize = true;
            this.labelPartySize.Location = new System.Drawing.Point(20, 80);
            this.labelPartySize.Name = "labelPartySize";
            this.labelPartySize.Text = "Party Size";
            //
            // textBoxPartySize
            //
            this.textBoxPartySize.Location = new System.Drawing.Point(20, 100);
            this.textBoxPartySize.Name = "textBoxPartySize";
            this.textBoxPartySize.Size = new System.Drawing.Size(120, 29);
            //
            // labelRequestedTime
            //
            this.labelRequestedTime.AutoSize = true;
            this.labelRequestedTime.Location = new System.Drawing.Point(20, 140);
            this.labelRequestedTime.Name = "labelRequestedTime";
            this.labelRequestedTime.Text = "Requested Time";
            //
            // dateTimePickerRequestedTime
            //
            this.dateTimePickerRequestedTime.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateTimePickerRequestedTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerRequestedTime.Location = new System.Drawing.Point(20, 160);
            this.dateTimePickerRequestedTime.Name = "dateTimePickerRequestedTime";
            this.dateTimePickerRequestedTime.Size = new System.Drawing.Size(220, 29);
            //
            // labelTableNumber
            //
            this.labelTableNumber.AutoSize = true;
            this.labelTableNumber.Location = new System.Drawing.Point(20, 200);
            this.labelTableNumber.Name = "labelTableNumber";
            this.labelTableNumber.Text = "Table Number (auto-suggested)";
            //
            // textBoxTableNumber
            //
            this.textBoxTableNumber.Location = new System.Drawing.Point(20, 220);
            this.textBoxTableNumber.Name = "textBoxTableNumber";
            this.textBoxTableNumber.Size = new System.Drawing.Size(120, 29);
            //
            // buttonOK
            //
            this.buttonOK.Location = new System.Drawing.Point(40, 270);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(110, 32);
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            //
            // buttonCancel
            //
            this.buttonCancel.Location = new System.Drawing.Point(180, 270);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(110, 32);
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            //
            // ReservationForm
            //
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 320);
            this.Controls.Add(this.labelGuestName);
            this.Controls.Add(this.textBoxGuestName);
            this.Controls.Add(this.labelPartySize);
            this.Controls.Add(this.textBoxPartySize);
            this.Controls.Add(this.labelRequestedTime);
            this.Controls.Add(this.dateTimePickerRequestedTime);
            this.Controls.Add(this.labelTableNumber);
            this.Controls.Add(this.textBoxTableNumber);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReservationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reservation Details";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
