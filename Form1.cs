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

            dataGridViewReservations.Columns.Add("colResGuestName", "Guest Name");
            dataGridViewReservations.Columns.Add("colResPartySize", "Party Size");
            dataGridViewReservations.Columns.Add("colResTime", "Requested Time");
            dataGridViewReservations.Columns.Add("colResTableNumber", "Table Number");

            buttonAddTable.Click += buttonAddTable_Click;
            buttonModifyTable.Click += buttonModifyTable_Click;
            buttonDeleteTable.Click += buttonDeleteTable_Click;
            dataGridViewTables.SelectionChanged += dataGridViewTables_SelectionChanged;

            buttonCreateReservation.Click += buttonCreateReservation_Click;
            buttonModifyReservation.Click += buttonModifyReservation_Click;
            buttonDeleteReservation.Click += buttonDeleteReservation_Click;
            dataGridViewReservations.SelectionChanged += dataGridViewReservations_SelectionChanged;
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

            dataGridViewTables.Rows.Add(tableNumber, capacity, textBoxSection.Text);

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
