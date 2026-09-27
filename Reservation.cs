using System;

namespace RestaurantTableReservation
{
    public class Reservation : ISeatable
    {
        public string GuestName { get; set; }
        public int PartySize { get; set; }
        public bool IsSeated { get; set; }

        public Reservation(string guestName, int partySize)
        {
            GuestName = guestName;
            PartySize = partySize;
            IsSeated = false;
        }

        public void MarkSeated()
        {
            IsSeated = true;
        }
    }
}
