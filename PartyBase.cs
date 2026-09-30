using System;

namespace RestaurantTableReservation
{
    // Reservation and WaitlistEntry both need a guest name, a party size, and a way to know
    // if they have been seated, so that shared stuff lives here instead of being copied into
    // both classes. MarkSeated is virtual in case a subclass ever needs to do something extra
    // when it gets seated (WaitlistEntry does not need anything extra right now, but it could
    // override this later, e.g. to record the exact time it was seated).
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
