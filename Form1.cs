using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantTableReservation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            dataGridViewTables.Columns.Add("colTableNumber", "Table Number");
            dataGridViewTables.Columns.Add("colCapacity", "Capacity");
            dataGridViewTables.Columns.Add("colSection", "Section");
            dataGridViewTables.Columns.Add("colTableStatus", "Status");
            dataGridViewTables.Columns.Add("colOccupiedSince", "Occupied Since");
            // Data only ever gets added through the fields + buttons above, so turn off the
            // grid's own blank "type a new row here" row - otherwise code that loops over
            // Rows can hit that empty row and blow up on its null cell values.
            dataGridViewTables.AllowUserToAddRows = false;

            dataGridViewReservations.Columns.Add("colResGuestName", "Guest Name");
            dataGridViewReservations.Columns.Add("colResPartySize", "Party Size");
            dataGridViewReservations.Columns.Add("colResTime", "Requested Time");
            dataGridViewReservations.Columns.Add("colResTableNumber", "Table Number");
            dataGridViewReservations.AllowUserToAddRows = false;

            buttonAddTable.Click += buttonAddTable_Click;
            buttonModifyTable.Click += buttonModifyTable_Click;
            buttonDeleteTable.Click += buttonDeleteTable_Click;
            dataGridViewTables.SelectionChanged += dataGridViewTables_SelectionChanged;

            buttonCreateReservation.Click += buttonCreateReservation_Click;
            buttonModifyReservation.Click += buttonModifyReservation_Click;
            buttonDeleteReservation.Click += buttonDeleteReservation_Click;
            buttonSeatReservation.Click += buttonSeatReservation_Click;
            dataGridViewReservations.SelectionChanged += dataGridViewReservations_SelectionChanged;

            dataGridViewWaitlist.Columns.Add("colWaitGuestName", "Guest Name");
            dataGridViewWaitlist.Columns.Add("colWaitPartySize", "Party Size");
            dataGridViewWaitlist.Columns.Add("colWaitArrivalTime", "Arrival Time");
            dataGridViewWaitlist.Columns.Add("colWaitEstimatedWait", "Estimated Wait (min)");
            dataGridViewWaitlist.Columns.Add("colWaitStatus", "Status");
            dataGridViewWaitlist.AllowUserToAddRows = false;

            buttonAddWaitlist.Click += buttonAddWaitlist_Click;
            buttonModifyWaitlist.Click += buttonModifyWaitlist_Click;
            buttonDeleteWaitlist.Click += buttonDeleteWaitlist_Click;
            buttonSeatParty.Click += buttonSeatParty_Click;
            dataGridViewWaitlist.SelectionChanged += dataGridViewWaitlist_SelectionChanged;

            buttonMarkTableFree.Click += buttonMarkTableFree_Click;
        }

        // Real observed "how long did a table actually stay occupied" times, in minutes.
        // Starts with a few made-up baseline numbers so the wait estimate on the Waitlist
        // tab is not just zero before any table has actually been freed yet.
        private List<double> historicalTurnoverMinutes = new List<double> { 82, 95, 70, 88 };

        private void buttonMarkTableFree_Click(object sender, EventArgs e)
        {
            if (dataGridViewTables.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a table in the grid first.");
                return;
            }

            DataGridViewRow row = dataGridViewTables.SelectedRows[0];

            if (row.Cells["colTableStatus"].Value.ToString() != "Occupied")
            {
                MessageBox.Show("That table is not occupied.");
                return;
            }

            DateTime occupiedSince = Convert.ToDateTime(row.Cells["colOccupiedSince"].Value);
            double minutesOccupied = (DateTime.Now - occupiedSince).TotalMinutes;
            historicalTurnoverMinutes.Add(minutesOccupied);

            row.Cells["colTableStatus"].Value = "Free";
            row.Cells["colOccupiedSince"].Value = "";

            MessageBox.Show("Table marked free. It was occupied for about " + Math.Round(minutesOccupied) + " minutes.");

            int tableNumber = Convert.ToInt32(row.Cells["colTableNumber"].Value);
            int tableCapacity = Convert.ToInt32(row.Cells["colCapacity"].Value);
            DataGridViewRow matchedRow = FindBestWaitlistMatch(tableCapacity);

            if (matchedRow != null)
            {
                string guestName = matchedRow.Cells["colWaitGuestName"].Value.ToString();
                int partySize = Convert.ToInt32(matchedRow.Cells["colWaitPartySize"].Value);

                DialogResult offer = MessageBox.Show(
                    guestName + " (party of " + partySize + ") from the waitlist looks like the best match " +
                    "for this table. Seat them now?", "Waitlist Match Found", MessageBoxButtons.YesNo);

                if (offer == DialogResult.Yes)
                {
                    WaitlistEntry entry = new WaitlistEntry(guestName, partySize);
                    bool seated = SeatParty(entry, tableNumber);
                    if (seated)
                    {
                        matchedRow.Cells["colWaitStatus"].Value = "Seated";
                    }
                }
            }
        }

        // The assignment's "custom algorithm" requirement: hand-written priority matching
        // instead of Queue<T> or a LINQ OrderBy. Every waiting party that fits the freed
        // table gets a score - a good size fit matters a lot more than how long they have
        // waited, so a party of 2 does not jump ahead of a perfectly-fitting party of 6 just
        // because they arrived a bit earlier - and we just keep track of the best one seen
        // so far as we loop through.
        private DataGridViewRow FindBestWaitlistMatch(int tableCapacity)
        {
            DataGridViewRow bestRow = null;
            double bestScore = -1;

            foreach (DataGridViewRow row in dataGridViewWaitlist.Rows)
            {
                string status = row.Cells["colWaitStatus"].Value.ToString();
                if (status != "Waiting")
                {
                    continue;
                }

                int partySize = Convert.ToInt32(row.Cells["colWaitPartySize"].Value);
                if (partySize > tableCapacity)
                {
                    continue;
                }

                int seatsWasted = tableCapacity - partySize;
                double fitScore = 1.0 / (1.0 + seatsWasted);

                DateTime arrivalTime = Convert.ToDateTime(row.Cells["colWaitArrivalTime"].Value);
                double minutesWaited = (DateTime.Now - arrivalTime).TotalMinutes;
                double waitScore = minutesWaited / 60.0;

                double totalScore = (fitScore * 10) + waitScore;

                if (totalScore > bestScore)
                {
                    bestScore = totalScore;
                    bestRow = row;
                }
            }

            return bestRow;
        }

        // Shared by both Seat Party buttons below. It does not care whether "party" is a
        // Reservation or a WaitlistEntry - it only talks to it through ISeatable - so the
        // actual seating logic only has to be written once instead of twice.
        private bool SeatParty(ISeatable party, int tableNumber)
        {
            DataGridViewRow tableRow = null;
            foreach (DataGridViewRow row in dataGridViewTables.Rows)
            {
                if (Convert.ToInt32(row.Cells["colTableNumber"].Value) == tableNumber)
                {
                    tableRow = row;
                    break;
                }
            }

            if (tableRow == null)
            {
                MessageBox.Show("There is no table with that number.");
                return false;
            }

            if (tableRow.Cells["colTableStatus"].Value.ToString() != "Free")
            {
                MessageBox.Show("Table " + tableNumber + " is not free right now.");
                return false;
            }

            int tableCapacity = Convert.ToInt32(tableRow.Cells["colCapacity"].Value);
            if (party.PartySize > tableCapacity)
            {
                MessageBox.Show("Party size is too big for that table (capacity is " + tableCapacity + ").");
                return false;
            }

            tableRow.Cells["colTableStatus"].Value = "Occupied";
            tableRow.Cells["colOccupiedSince"].Value = DateTime.Now;
            party.MarkSeated();

            MessageBox.Show(party.GuestName + " (party of " + party.PartySize + ") has been seated at table " + tableNumber + ".");
            return true;
        }

        private void buttonSeatReservation_Click(object sender, EventArgs e)
        {
            if (dataGridViewReservations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a reservation in the grid first.");
                return;
            }

            DataGridViewRow row = dataGridViewReservations.SelectedRows[0];
            string guestName = row.Cells["colResGuestName"].Value.ToString();
            int partySize = Convert.ToInt32(row.Cells["colResPartySize"].Value);
            int tableNumber = Convert.ToInt32(row.Cells["colResTableNumber"].Value);

            Reservation reservation = new Reservation(guestName, partySize);
            SeatParty(reservation, tableNumber);
        }

        private void buttonSeatParty_Click(object sender, EventArgs e)
        {
            if (dataGridViewWaitlist.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a waitlist entry in the grid first.");
                return;
            }

            if (textBoxWaitlistTableNumber.Text == "")
            {
                MessageBox.Show("Type in which table number to seat them at.");
                return;
            }

            int tableNumber;
            if (!int.TryParse(textBoxWaitlistTableNumber.Text, out tableNumber))
            {
                MessageBox.Show("Table number must be a whole number.");
                return;
            }

            DataGridViewRow selectedRow = dataGridViewWaitlist.SelectedRows[0];
            string guestName = selectedRow.Cells["colWaitGuestName"].Value.ToString();
            int partySize = Convert.ToInt32(selectedRow.Cells["colWaitPartySize"].Value);

            WaitlistEntry entry = new WaitlistEntry(guestName, partySize);
            bool seated = SeatParty(entry, tableNumber);

            if (seated)
            {
                selectedRow.Cells["colWaitStatus"].Value = "Seated";
                textBoxWaitlistTableNumber.Clear();
            }
        }

        private void dataGridViewWaitlist_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewWaitlist.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow row = dataGridViewWaitlist.SelectedRows[0];
            textBoxWaitlistGuestName.Text = row.Cells["colWaitGuestName"].Value.ToString();
            textBoxWaitlistPartySize.Text = row.Cells["colWaitPartySize"].Value.ToString();
        }

        private void buttonModifyWaitlist_Click(object sender, EventArgs e)
        {
            if (dataGridViewWaitlist.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a waitlist entry in the grid first.");
                return;
            }

            if (textBoxWaitlistGuestName.Text == "" || textBoxWaitlistPartySize.Text == "")
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            int partySize;
            if (!int.TryParse(textBoxWaitlistPartySize.Text, out partySize))
            {
                MessageBox.Show("Party size must be a whole number.");
                return;
            }

            DataGridViewRow selectedRow = dataGridViewWaitlist.SelectedRows[0];
            selectedRow.Cells["colWaitGuestName"].Value = textBoxWaitlistGuestName.Text;
            selectedRow.Cells["colWaitPartySize"].Value = partySize;

            MessageBox.Show("Waitlist entry updated.");
        }

        private void buttonDeleteWaitlist_Click(object sender, EventArgs e)
        {
            if (dataGridViewWaitlist.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a waitlist entry in the grid first.");
                return;
            }

            DialogResult confirm = MessageBox.Show("Delete this waitlist entry?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes)
            {
                return;
            }

            dataGridViewWaitlist.Rows.Remove(dataGridViewWaitlist.SelectedRows[0]);

            textBoxWaitlistGuestName.Clear();
            textBoxWaitlistPartySize.Clear();
        }

        private void buttonAddWaitlist_Click(object sender, EventArgs e)
        {
            if (textBoxWaitlistGuestName.Text == "" || textBoxWaitlistPartySize.Text == "")
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            int partySize;
            if (!int.TryParse(textBoxWaitlistPartySize.Text, out partySize))
            {
                MessageBox.Show("Party size must be a whole number.");
                return;
            }

            // Work out the real average turnover time from tables that have actually been
            // marked free so far, instead of just assuming a fixed number of minutes.
            double totalTurnover = 0;
            foreach (double minutes in historicalTurnoverMinutes)
            {
                totalTurnover += minutes;
            }
            double averageTurnover = totalTurnover / historicalTurnoverMinutes.Count;

            int partiesAhead = 0;
            foreach (DataGridViewRow row in dataGridViewWaitlist.Rows)
            {
                string status = row.Cells["colWaitStatus"].Value.ToString();
                int otherPartySize = Convert.ToInt32(row.Cells["colWaitPartySize"].Value);

                if (status == "Waiting" && otherPartySize <= partySize + 2)
                {
                    partiesAhead++;
                }
            }

            double estimatedWait;
            if (partiesAhead == 0)
            {
                estimatedWait = averageTurnover * 0.5;
            }
            else
            {
                estimatedWait = averageTurnover * partiesAhead;
            }

            dataGridViewWaitlist.Rows.Add(textBoxWaitlistGuestName.Text, partySize, DateTime.Now,
                Math.Round(estimatedWait), "Waiting");

            textBoxWaitlistGuestName.Clear();
            textBoxWaitlistPartySize.Clear();
        }

        private void dataGridViewReservations_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewReservations.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow row = dataGridViewReservations.SelectedRows[0];
            textBoxGuestName.Text = row.Cells["colResGuestName"].Value.ToString();
            textBoxPartySize.Text = row.Cells["colResPartySize"].Value.ToString();
            dateTimePickerRequestedTime.Value = Convert.ToDateTime(row.Cells["colResTime"].Value);
            textBoxReservationTableNumber.Text = row.Cells["colResTableNumber"].Value.ToString();
        }

        private void buttonModifyReservation_Click(object sender, EventArgs e)
        {
            if (dataGridViewReservations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a reservation in the grid first.");
                return;
            }

            if (textBoxGuestName.Text == "" || textBoxPartySize.Text == "" || textBoxReservationTableNumber.Text == "")
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            int partySize;
            int tableNumber;

            if (!int.TryParse(textBoxPartySize.Text, out partySize))
            {
                MessageBox.Show("Party size must be a whole number.");
                return;
            }

            if (!int.TryParse(textBoxReservationTableNumber.Text, out tableNumber))
            {
                MessageBox.Show("Table number must be a whole number.");
                return;
            }

            int tableCapacity = -1;
            foreach (DataGridViewRow row in dataGridViewTables.Rows)
            {
                if (Convert.ToInt32(row.Cells["colTableNumber"].Value) == tableNumber)
                {
                    tableCapacity = Convert.ToInt32(row.Cells["colCapacity"].Value);
                    break;
                }
            }

            if (tableCapacity == -1)
            {
                MessageBox.Show("There is no table with that number.");
                return;
            }

            if (partySize > tableCapacity)
            {
                MessageBox.Show("Party size is too big for that table (capacity is " + tableCapacity + ").");
                return;
            }

            DataGridViewRow selectedRow = dataGridViewReservations.SelectedRows[0];
            DateTime requestedTime = dateTimePickerRequestedTime.Value;
            int minimumGapMinutes = averageDiningMinutes - overbookingBufferMinutes;

            // Same overbooking check as Create Reservation, but skip the row we are
            // editing - otherwise it would always conflict with its own old time.
            foreach (DataGridViewRow row in dataGridViewReservations.Rows)
            {
                if (row.Index == selectedRow.Index)
                {
                    continue;
                }

                int existingTableNumber = Convert.ToInt32(row.Cells["colResTableNumber"].Value);
                if (existingTableNumber != tableNumber)
                {
                    continue;
                }

                DateTime existingTime = Convert.ToDateTime(row.Cells["colResTime"].Value);
                double gapMinutes = Math.Abs((requestedTime - existingTime).TotalMinutes);

                if (gapMinutes < minimumGapMinutes)
                {
                    MessageBox.Show("Table " + tableNumber + " already has a booking at " + existingTime +
                        ", which is too close to this requested time.");
                    return;
                }
            }

            selectedRow.Cells["colResGuestName"].Value = textBoxGuestName.Text;
            selectedRow.Cells["colResPartySize"].Value = partySize;
            selectedRow.Cells["colResTime"].Value = requestedTime;
            selectedRow.Cells["colResTableNumber"].Value = tableNumber;

            MessageBox.Show("Reservation updated.");
        }

        private void buttonDeleteReservation_Click(object sender, EventArgs e)
        {
            if (dataGridViewReservations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a reservation in the grid first.");
                return;
            }

            DialogResult confirm = MessageBox.Show("Delete this reservation?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes)
            {
                return;
            }

            dataGridViewReservations.Rows.Remove(dataGridViewReservations.SelectedRows[0]);

            textBoxGuestName.Clear();
            textBoxPartySize.Clear();
            textBoxReservationTableNumber.Clear();
        }

        // A booking is assumed to take about this long, and we allow bookings on the same
        // table to be a little closer together than that (the "overbooking buffer") in case
        // the earlier party finishes a bit early.
        private const int averageDiningMinutes = 90;
        private const int overbookingBufferMinutes = 15;

        private void buttonCreateReservation_Click(object sender, EventArgs e)
        {
            if (textBoxGuestName.Text == "" || textBoxPartySize.Text == "" || textBoxReservationTableNumber.Text == "")
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            int partySize;
            int tableNumber;

            if (!int.TryParse(textBoxPartySize.Text, out partySize))
            {
                MessageBox.Show("Party size must be a whole number.");
                return;
            }

            if (!int.TryParse(textBoxReservationTableNumber.Text, out tableNumber))
            {
                MessageBox.Show("Table number must be a whole number.");
                return;
            }

            // Find the table so we can check its capacity.
            int tableCapacity = -1;
            foreach (DataGridViewRow row in dataGridViewTables.Rows)
            {
                if (Convert.ToInt32(row.Cells["colTableNumber"].Value) == tableNumber)
                {
                    tableCapacity = Convert.ToInt32(row.Cells["colCapacity"].Value);
                    break;
                }
            }

            if (tableCapacity == -1)
            {
                MessageBox.Show("There is no table with that number.");
                return;
            }

            if (partySize > tableCapacity)
            {
                MessageBox.Show("Party size is too big for that table (capacity is " + tableCapacity + ").");
                return;
            }

            DateTime requestedTime = dateTimePickerRequestedTime.Value;
            int minimumGapMinutes = averageDiningMinutes - overbookingBufferMinutes;

            // Check the table isn't already booked too close to this time.
            foreach (DataGridViewRow row in dataGridViewReservations.Rows)
            {
                int existingTableNumber = Convert.ToInt32(row.Cells["colResTableNumber"].Value);
                if (existingTableNumber != tableNumber)
                {
                    continue;
                }

                DateTime existingTime = Convert.ToDateTime(row.Cells["colResTime"].Value);
                double gapMinutes = Math.Abs((requestedTime - existingTime).TotalMinutes);

                if (gapMinutes < minimumGapMinutes)
                {
                    MessageBox.Show("Table " + tableNumber + " already has a booking at " + existingTime +
                        ", which is too close to this requested time.");
                    return;
                }
            }

            dataGridViewReservations.Rows.Add(textBoxGuestName.Text, partySize, requestedTime, tableNumber);

            textBoxGuestName.Clear();
            textBoxPartySize.Clear();
            textBoxReservationTableNumber.Clear();
        }

        private void dataGridViewTables_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewTables.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow row = dataGridViewTables.SelectedRows[0];
            textBoxTableNumber.Text = row.Cells["colTableNumber"].Value.ToString();
            textBoxCapacity.Text = row.Cells["colCapacity"].Value.ToString();
            textBoxSection.Text = row.Cells["colSection"].Value.ToString();
        }

        private void buttonAddTable_Click(object sender, EventArgs e)
        {
            if (textBoxTableNumber.Text == "" || textBoxCapacity.Text == "" || textBoxSection.Text == "")
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            int tableNumber;
            int capacity;

            if (!int.TryParse(textBoxTableNumber.Text, out tableNumber))
            {
                MessageBox.Show("Table number must be a whole number.");
                return;
            }

            if (!int.TryParse(textBoxCapacity.Text, out capacity))
            {
                MessageBox.Show("Capacity must be a whole number.");
                return;
            }

            dataGridViewTables.Rows.Add(tableNumber, capacity, textBoxSection.Text, "Free", "");

            textBoxTableNumber.Clear();
            textBoxCapacity.Clear();
            textBoxSection.Clear();
        }

        private void buttonModifyTable_Click(object sender, EventArgs e)
        {
            if (dataGridViewTables.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a table in the grid first.");
                return;
            }

            if (textBoxTableNumber.Text == "" || textBoxCapacity.Text == "" || textBoxSection.Text == "")
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            int tableNumber;
            int capacity;

            if (!int.TryParse(textBoxTableNumber.Text, out tableNumber))
            {
                MessageBox.Show("Table number must be a whole number.");
                return;
            }

            if (!int.TryParse(textBoxCapacity.Text, out capacity))
            {
                MessageBox.Show("Capacity must be a whole number.");
                return;
            }

            DataGridViewRow row = dataGridViewTables.SelectedRows[0];
            row.Cells["colTableNumber"].Value = tableNumber;
            row.Cells["colCapacity"].Value = capacity;
            row.Cells["colSection"].Value = textBoxSection.Text;

            MessageBox.Show("Table updated.");
        }

        private void buttonDeleteTable_Click(object sender, EventArgs e)
        {
            if (dataGridViewTables.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a table in the grid first.");
                return;
            }

            DialogResult confirm = MessageBox.Show("Delete this table?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes)
            {
                return;
            }

            dataGridViewTables.Rows.Remove(dataGridViewTables.SelectedRows[0]);

            textBoxTableNumber.Clear();
            textBoxCapacity.Clear();
            textBoxSection.Clear();
        }
    }
}
