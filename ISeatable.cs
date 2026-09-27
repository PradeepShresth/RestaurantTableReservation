using System;

namespace RestaurantTableReservation
{
    // Both Reservation and WaitlistEntry implement this, so the "seat this party" code
    // in Form1 only needs to be written once instead of once per type.
    public interface ISeatable
    {
        string GuestName { get; }
        int PartySize { get; }

        void MarkSeated();
    }
}
