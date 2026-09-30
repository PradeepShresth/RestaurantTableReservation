using System;
using System.Windows.Forms;

namespace RestaurantTableReservation
{
    public partial class ReservationForm : Form
    {
        // MainForm sets these before ShowDialog() to pre-fill the fields (used for Modify),
        // and reads them back afterwards once the user clicks OK.
        public string GuestName { get; set; }
        public int PartySize { get; set; }
        public DateTime RequestedTime { get; set; }
        public int TableNumber { get; set; }

        // Passed in from MainForm so this dialog can look up tables/existing bookings itself
        // and suggest one, instead of the user having to know table numbers off by heart.
        private DataGridView tablesGrid;
        private DataGridView reservationsGrid;

        // True only while ReservationForm_Load is filling in the fields for Modify, so the
        // auto-suggest logic below does not immediately overwrite the table that was already
        // assigned to an existing reservation.
        private bool isLoadingFields = false;

        public ReservationForm(DataGridView tablesGrid, DataGridView reservationsGrid)
        {
            InitializeComponent();

            this.tablesGrid = tablesGrid;
            this.reservationsGrid = reservationsGrid;

            buttonOK.Click += buttonOK_Click;
            buttonCancel.Click += buttonCancel_Click;
            this.Load += ReservationForm_Load;
            textBoxPartySize.TextChanged += textBoxPartySize_TextChanged;
            dateTimePickerRequestedTime.ValueChanged += dateTimePickerRequestedTime_ValueChanged;
        }

        private void ReservationForm_Load(object sender, EventArgs e)
        {
            isLoadingFields = true;

            textBoxGuestName.Text = GuestName;
            if (PartySize > 0)
            {
                textBoxPartySize.Text = PartySize.ToString();
            }
            if (TableNumber > 0)
            {
                textBoxTableNumber.Text = TableNumber.ToString();
            }
            if (RequestedTime > DateTime.MinValue)
            {
                dateTimePickerRequestedTime.Value = RequestedTime;
            }

            isLoadingFields = false;
        }

        private void textBoxPartySize_TextChanged(object sender, EventArgs e)
        {
            SuggestTableNumber();
        }

        private void dateTimePickerRequestedTime_ValueChanged(object sender, EventArgs e)
        {
            SuggestTableNumber();
        }

        // Fills in Table Number automatically once a valid party size has been typed in,
        // picking the smallest free table that both fits the party and is not already
        // booked too close to the requested time. The user can still type over it by hand -
        // this is a suggestion, not a lock.
        private void SuggestTableNumber()
        {
            if (isLoadingFields || tablesGrid == null)
            {
                return;
            }

            int partySize;
            if (!int.TryParse(textBoxPartySize.Text, out partySize) || partySize <= 0)
            {
                return;
            }

            // Same idea as Form1's overbooking check: two bookings on the same table need to
            // be at least 75 minutes apart (90 minute average dining time, minus a 15 minute
            // overbooking buffer).
            const int averageDiningMinutes = 90;
            const int overbookingBufferMinutes = 15;
            int minimumGapMinutes = averageDiningMinutes - overbookingBufferMinutes;
            DateTime requestedTime = dateTimePickerRequestedTime.Value;

            int bestTableNumber = -1;
            int bestCapacity = -1;

            foreach (DataGridViewRow tableRow in tablesGrid.Rows)
            {
                int capacity = Convert.ToInt32(tableRow.Cells["colCapacity"].Value);
                if (capacity < partySize)
                {
                    continue;
                }

                int tableNumber = Convert.ToInt32(tableRow.Cells["colTableNumber"].Value);
                bool tooClose = false;

                foreach (DataGridViewRow reservationRow in reservationsGrid.Rows)
                {
                    int existingTableNumber = Convert.ToInt32(reservationRow.Cells["colResTableNumber"].Value);
                    if (existingTableNumber != tableNumber)
                    {
                        continue;
                    }

                    DateTime existingTime = Convert.ToDateTime(reservationRow.Cells["colResTime"].Value);
                    double gapMinutes = Math.Abs((requestedTime - existingTime).TotalMinutes);

                    if (gapMinutes < minimumGapMinutes)
                    {
                        tooClose = true;
                        break;
                    }
                }

                if (tooClose)
                {
                    continue;
                }

                // Keep the smallest-capacity table seen so far that still fits, so a party
                // of two does not get suggested an eight-seat table.
                if (bestCapacity == -1 || capacity < bestCapacity)
                {
                    bestCapacity = capacity;
                    bestTableNumber = tableNumber;
                }
            }

            if (bestTableNumber != -1)
            {
                textBoxTableNumber.Text = bestTableNumber.ToString();
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (textBoxGuestName.Text == "" || textBoxPartySize.Text == "" || textBoxTableNumber.Text == "")
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            int partySize;
            if (!int.TryParse(textBoxPartySize.Text, out partySize))
            {
                MessageBox.Show("Party size must be a whole number.");
                return;
            }

            int tableNumber;
            if (!int.TryParse(textBoxTableNumber.Text, out tableNumber))
            {
                MessageBox.Show("Table number must be a whole number.");
                return;
            }

            GuestName = textBoxGuestName.Text;
            PartySize = partySize;
            TableNumber = tableNumber;
            RequestedTime = dateTimePickerRequestedTime.Value;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
