using System;

namespace RestaurantTableReservation
{
    public class WaitlistEntry : PartyBase, ISeatable
    {
        public WaitlistEntry(string guestName, int partySize) : base(guestName, partySize)
        {
        }
    }
}
