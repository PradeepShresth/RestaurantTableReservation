using System;

namespace RestaurantTableReservation
{
    // common fields for Reservation and WaitlistEntry so we don't repeat them in both classes
    public abstract class PartyBase
    {
        public string GuestName { get; set; }
        public int PartySize { get; set; }
        public bool IsSeated { get; set; }

        protected PartyBase(string guestName, int partySize)
        {
            GuestName = guestName;
            PartySize = partySize;
            IsSeated = false;
        }

        public virtual void MarkSeated()
        {
            IsSeated = true;
        }
    }
}
