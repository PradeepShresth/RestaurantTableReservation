using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        }

        // true if data changed since the last save
        private bool hasUnsavedChanges = false;

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!hasUnsavedChanges)
            {
                return;
            }

            DialogResult result = MessageBox.Show("You have unsaved changes. Save before exiting?",
                "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else if (result == DialogResult.Yes)
            {
                bool saved = SaveDataWithDialog();
                if (!saved)
                {
                    e.Cancel = true;
                }
            }
        }

        private void menuManageTables_Click(object sender, EventArgs e)
        {
            tabControlMain.SelectedTab = tabPageTables;
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuNewSystem_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("This will clear all current data. Continue?",
                "New System", MessageBoxButtons.YesNo);

            if (confirm != DialogResult.Yes)
            {
                return;
            }

            dataGridViewTables.Rows.Clear();
            dataGridViewReservations.Rows.Clear();
            dataGridViewWaitlist.Rows.Clear();
            historicalTurnoverMinutes = new List<double> { 82, 95, 70, 88 };
            hasUnsavedChanges = false;
        }

        private void menuSaveData_Click(object sender, EventArgs e)
        {
            SaveDataWithDialog();
        }

        // returns true if it actually saved
        private bool SaveDataWithDialog()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";

            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return false;
            }

            try
            {
                SaveDataToFile(dialog.FileName);
                hasUnsavedChanges = false;
                MessageBox.Show("Data saved successfully.");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not save the file: " + ex.Message);
                return false;
            }
        }

        private void menuLoadData_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";

            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                LoadDataFromFile(dialog.FileName);
                hasUnsavedChanges = false;
                MessageBox.Show("Data loaded successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load the file: " + ex.Message);
            }
        }

        // saves all tables, reservations and waitlist entries into one csv file
        // each line starts with TABLE / RESERVATION / WAITLIST so we know what it is when loading
        private void SaveDataToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (DataGridViewRow row in dataGridViewTables.Rows)
                {
                    writer.WriteLine("TABLE," +
                        row.Cells["colTableNumber"].Value + "," +
                        row.Cells["colCapacity"].Value + "," +
                        row.Cells["colSection"].Value + "," +
                        row.Cells["colTableStatus"].Value + "," +
                        row.Cells["colOccupiedSince"].Value);
                }

                foreach (DataGridViewRow row in dataGridViewReservations.Rows)
                {
                    DateTime requestedTime = Convert.ToDateTime(row.Cells["colResTime"].Value);

                    writer.WriteLine("RESERVATION," +
                        row.Cells["colResGuestName"].Value + "," +
                        row.Cells["colResPartySize"].Value + "," +
                        requestedTime.ToString("yyyy-MM-dd HH:mm:ss") + "," +
                        row.Cells["colResTableNumber"].Value);
                }

                foreach (DataGridViewRow row in dataGridViewWaitlist.Rows)
                {
                    DateTime arrivalTime = Convert.ToDateTime(row.Cells["colWaitArrivalTime"].Value);

                    writer.WriteLine("WAITLIST," +
                        row.Cells["colWaitGuestName"].Value + "," +
                        row.Cells["colWaitPartySize"].Value + "," +
                        arrivalTime.ToString("yyyy-MM-dd HH:mm:ss") + "," +
                        row.Cells["colWaitEstimatedWait"].Value + "," +
                        row.Cells["colWaitStatus"].Value);
                }
            }
        }

        private void LoadDataFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                // file doesn't exist, let the catch in menuLoadData_Click handle the message
                throw new FileNotFoundException("That file does not exist.");
            }

            dataGridViewTables.Rows.Clear();
            dataGridViewReservations.Rows.Clear();
            dataGridViewWaitlist.Rows.Clear();

            int skippedLines = 0;

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');

                    // skip the line if something goes wrong instead of crashing
                    try
                    {
                        if (parts[0] == "TABLE")
                        {
                            int tableNumber = Convert.ToInt32(parts[1]);
                            int capacity = Convert.ToInt32(parts[2]);
                            string section = parts[3];
                            string status = parts[4];
                            string occupiedSince = parts[5];
                            dataGridViewTables.Rows.Add(tableNumber, capacity, section, status, occupiedSince);
                        }
                        else if (parts[0] == "RESERVATION")
                        {
                            string guestName = parts[1];
                            int partySize = Convert.ToInt32(parts[2]);
                            DateTime requestedTime = DateTime.Parse(parts[3]);
                            int tableNumber = Convert.ToInt32(parts[4]);
                            dataGridViewReservations.Rows.Add(guestName, partySize, requestedTime, tableNumber);
                        }
                        else if (parts[0] == "WAITLIST")
                        {
                            string guestName = parts[1];
                            int partySize = Convert.ToInt32(parts[2]);
                            DateTime arrivalTime = DateTime.Parse(parts[3]);
                            double estimatedWait = Convert.ToDouble(parts[4]);
                            string status = parts[5];
                            dataGridViewWaitlist.Rows.Add(guestName, partySize, arrivalTime, estimatedWait, status);
                        }
                        else
                        {
                            skippedLines++;
                        }
                    }
                    catch
                    {
                        skippedLines++;
                    }
                }
            }

            if (skippedLines > 0)
            {
                MessageBox.Show(skippedLines + " line(s) in the file could not be read and were skipped.");
            }
        }

        // column widths for the search results grid (columns get rebuilt every search)
        private const int resultColGuestNameWidth = 180;
        private const int resultColPartySizeWidth = 90;
        private const int resultColTimeWidth = 150;
        private const int resultColTableNumberWidth = 110;
        private const int resultColEstimatedWaitWidth = 160;
        private const int resultColStatusWidth = 90;

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (comboBoxSearchBy.SelectedItem == null)
            {
                MessageBox.Show("Choose what to search by first.");
                return;
            }

            string searchBy = comboBoxSearchBy.SelectedItem.ToString();
            string searchText = textBoxSearch.Text;

            dataGridViewSearchResults.Rows.Clear();
            dataGridViewSearchResults.Columns.Clear();

            if (searchBy == "Waitlist Status")
            {
                dataGridViewSearchResults.Columns.Add("colResultGuestName", "Guest Name");
                dataGridViewSearchResults.Columns.Add("colResultPartySize", "Party Size");
                dataGridViewSearchResults.Columns.Add("colResultArrival", "Arrival Time");
                dataGridViewSearchResults.Columns.Add("colResultWait", "Estimated Wait (min)");
                dataGridViewSearchResults.Columns.Add("colResultStatus", "Status");

                dataGridViewSearchResults.Columns["colResultGuestName"].Width = resultColGuestNameWidth;
                dataGridViewSearchResults.Columns["colResultPartySize"].Width = resultColPartySizeWidth;
                dataGridViewSearchResults.Columns["colResultArrival"].Width = resultColTimeWidth;
                dataGridViewSearchResults.Columns["colResultWait"].Width = resultColEstimatedWaitWidth;
                dataGridViewSearchResults.Columns["colResultStatus"].Width = resultColStatusWidth;

                foreach (DataGridViewRow row in dataGridViewWaitlist.Rows)
                {
                    string status = row.Cells["colWaitStatus"].Value.ToString();
                    if (status.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        dataGridViewSearchResults.Rows.Add(
                            row.Cells["colWaitGuestName"].Value,
                            row.Cells["colWaitPartySize"].Value,
                            row.Cells["colWaitArrivalTime"].Value,
                            row.Cells["colWaitEstimatedWait"].Value,
                            row.Cells["colWaitStatus"].Value);
                    }
                }
            }
            else
            {
                dataGridViewSearchResults.Columns.Add("colResultGuestName", "Guest Name");
                dataGridViewSearchResults.Columns.Add("colResultPartySize", "Party Size");
                dataGridViewSearchResults.Columns.Add("colResultTime", "Requested Time");
                dataGridViewSearchResults.Columns.Add("colResultTable", "Table Number");

                dataGridViewSearchResults.Columns["colResultGuestName"].Width = resultColGuestNameWidth;
                dataGridViewSearchResults.Columns["colResultPartySize"].Width = resultColPartySizeWidth;
                dataGridViewSearchResults.Columns["colResultTime"].Width = resultColTimeWidth;
                dataGridViewSearchResults.Columns["colResultTable"].Width = resultColTableNumberWidth;

                foreach (DataGridViewRow row in dataGridViewReservations.Rows)
                {
                    bool matches = false;

                    if (searchBy == "Guest Name")
                    {
                        string guestName = row.Cells["colResGuestName"].Value.ToString();
                        matches = guestName.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0;
                    }
                    else if (searchBy == "Table Number")
                    {
                        string tableNumber = row.Cells["colResTableNumber"].Value.ToString();
                        matches = tableNumber == searchText;
                    }
                    else if (searchBy == "Reservation Time")
                    {
                        DateTime reservedTime = Convert.ToDateTime(row.Cells["colResTime"].Value);
                        matches = reservedTime.ToString().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0;
                    }

                    if (matches)
                    {
                        dataGridViewSearchResults.Rows.Add(
                            row.Cells["colResGuestName"].Value,
                            row.Cells["colResPartySize"].Value,
                            row.Cells["colResTime"].Value,
                            row.Cells["colResTableNumber"].Value);
                    }
                }
            }

            if (dataGridViewSearchResults.Rows.Count == 0)
            {
                MessageBox.Show("No matching records found.");
            }
        }

        private void buttonGenerateSummary_Click(object sender, EventArgs e)
        {
            int totalToday = 0;
            foreach (DataGridViewRow row in dataGridViewReservations.Rows)
            {
                DateTime reservedTime = Convert.ToDateTime(row.Cells["colResTime"].Value);
                if (reservedTime.Date == DateTime.Today)
                {
                    totalToday++;
                }
            }

            int waitlistLength = 0;
            foreach (DataGridViewRow row in dataGridViewWaitlist.Rows)
            {
                if (row.Cells["colWaitStatus"].Value.ToString() == "Waiting")
                {
                    waitlistLength++;
                }
            }

            double totalTurnover = 0;
            foreach (double minutes in historicalTurnoverMinutes)
            {
                totalTurnover += minutes;
            }
            double averageTurnover = totalTurnover / historicalTurnoverMinutes.Count;

            // count reservations per hour, then find the hour with the most
            int[] hourCounts = new int[24];
            foreach (DataGridViewRow row in dataGridViewReservations.Rows)
            {
                DateTime reservedTime = Convert.ToDateTime(row.Cells["colResTime"].Value);
                hourCounts[reservedTime.Hour]++;
            }

            int busiestHour = 0;
            int busiestCount = hourCounts[0];
            for (int hour = 1; hour < 24; hour++)
            {
                if (hourCounts[hour] > busiestCount)
                {
                    busiestCount = hourCounts[hour];
                    busiestHour = hour;
                }
            }

            labelTotalReservationsToday.Text = "Total reservations today: " + totalToday;
            labelWaitlistLength.Text = "Current waitlist length: " + waitlistLength;
            labelAvgTurnover.Text = "Average table turnover: " + Math.Round(averageTurnover) + " minutes";
            labelBusiestHour.Text = "Busiest hour: " + busiestHour + ":00";

            if (waitlistLength > 3)
            {
                labelFeedback.Text = "Waitlist is longer than usual tonight.";
            }
            else
            {
                labelFeedback.Text = "Waitlist is at a normal level tonight.";
            }
        }

        // how long tables have taken to free up (in minutes), starts with some made up numbers
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
            hasUnsavedChanges = true;

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

        // finds the best waiting party for a table that just became free
        // gives points for fitting the table size well, and a few extra points for waiting longer
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

        // used for seating both reservations and waitlist parties, works through ISeatable
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
            hasUnsavedChanges = true;

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
            hasUnsavedChanges = true;

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
            hasUnsavedChanges = true;

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

            // average turnover so far
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
            hasUnsavedChanges = true;

            textBoxWaitlistGuestName.Clear();
            textBoxWaitlistPartySize.Clear();
        }

        private void buttonModifyReservation_Click(object sender, EventArgs e)
        {
            if (dataGridViewReservations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a reservation in the grid first.");
                return;
            }

            DataGridViewRow selectedRow = dataGridViewReservations.SelectedRows[0];

            // fill the form with the current values first
            ReservationForm form = new ReservationForm(dataGridViewTables, dataGridViewReservations);
            form.GuestName = selectedRow.Cells["colResGuestName"].Value.ToString();
            form.PartySize = Convert.ToInt32(selectedRow.Cells["colResPartySize"].Value);
            form.RequestedTime = Convert.ToDateTime(selectedRow.Cells["colResTime"].Value);
            form.TableNumber = Convert.ToInt32(selectedRow.Cells["colResTableNumber"].Value);

            if (form.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string guestName = form.GuestName;
            int partySize = form.PartySize;
            DateTime requestedTime = form.RequestedTime;
            int tableNumber = form.TableNumber;

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

            int minimumGapMinutes = averageDiningMinutes - overbookingBufferMinutes;

            // same overbooking check as create reservation, skip this row since its our own old time
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

            selectedRow.Cells["colResGuestName"].Value = guestName;
            selectedRow.Cells["colResPartySize"].Value = partySize;
            selectedRow.Cells["colResTime"].Value = requestedTime;
            selectedRow.Cells["colResTableNumber"].Value = tableNumber;
            hasUnsavedChanges = true;

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
            hasUnsavedChanges = true;
        }

        // assume a booking takes about 90 min, but allow a bit of overlap in case they leave early
        private const int averageDiningMinutes = 90;
        private const int overbookingBufferMinutes = 15;

        private void buttonCreateReservation_Click(object sender, EventArgs e)
        {
            // open the reservation form to get guest name, party size, time and table
            ReservationForm form = new ReservationForm(dataGridViewTables, dataGridViewReservations);
            form.RequestedTime = DateTime.Now;

            if (form.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string guestName = form.GuestName;
            int partySize = form.PartySize;
            DateTime requestedTime = form.RequestedTime;
            int tableNumber = form.TableNumber;

            // find the table to check its capacity
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

            int minimumGapMinutes = averageDiningMinutes - overbookingBufferMinutes;

            // check the table isn't already booked too close to this time
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

            dataGridViewReservations.Rows.Add(guestName, partySize, requestedTime, tableNumber);
            hasUnsavedChanges = true;
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

            // table number is used to look up tables everywhere else, so no two tables can share one
            foreach (DataGridViewRow row in dataGridViewTables.Rows)
            {
                if (Convert.ToInt32(row.Cells["colTableNumber"].Value) == tableNumber)
                {
                    MessageBox.Show("A table with that number already exists.");
                    return;
                }
            }

            dataGridViewTables.Rows.Add(tableNumber, capacity, textBoxSection.Text, "Free", "");
            hasUnsavedChanges = true;

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

            // make sure the new number doesn't clash with a different table
            foreach (DataGridViewRow otherRow in dataGridViewTables.Rows)
            {
                if (otherRow.Index == row.Index)
                {
                    continue;
                }
                if (Convert.ToInt32(otherRow.Cells["colTableNumber"].Value) == tableNumber)
                {
                    MessageBox.Show("A table with that number already exists.");
                    return;
                }
            }

            row.Cells["colTableNumber"].Value = tableNumber;
            row.Cells["colCapacity"].Value = capacity;
            row.Cells["colSection"].Value = textBoxSection.Text;
            hasUnsavedChanges = true;

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
            hasUnsavedChanges = true;

            textBoxTableNumber.Clear();
            textBoxCapacity.Clear();
            textBoxSection.Clear();
        }
    }
}
