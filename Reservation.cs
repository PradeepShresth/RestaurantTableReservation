using System;

namespace RestaurantTableReservation
{
    public class Reservation : PartyBase, ISeatable
    {
        public Reservation(string guestName, int partySize) : base(guestName, partySize)
        {
        }
    }
}
