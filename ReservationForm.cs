using System;
using System.Windows.Forms;

namespace RestaurantTableReservation
{
    public partial class ReservationForm : Form
    {
        // used to pass values in/out of this form (Form1 sets these before ShowDialog for modify)
        public string GuestName { get; set; }
        public int PartySize { get; set; }
        public DateTime RequestedTime { get; set; }
        public int TableNumber { get; set; }

        // grids passed in from Form1 so we can look up tables and existing bookings
        private DataGridView tablesGrid;
        private DataGridView reservationsGrid;

        // stops the auto suggest from overwriting the table number while we are still loading
        private bool isLoadingFields = false;

        public ReservationForm(DataGridView tablesGrid, DataGridView reservationsGrid)
        {
            InitializeComponent();

            this.tablesGrid = tablesGrid;
            this.reservationsGrid = reservationsGrid;
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

        // picks the smallest free table that fits the party and isn't booked too close in time
        // just fills the text box, user can still change it
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

            // same rule as Form1, bookings need to be at least 75 min apart (90 min minus 15 min buffer)
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

                // keep the smallest table that still fits so far
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
