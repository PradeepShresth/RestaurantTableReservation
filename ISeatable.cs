using System;

namespace RestaurantTableReservation
{
    // implemented by both Reservation and WaitlistEntry so we can seat either one the same way
    public interface ISeatable
    {
        string GuestName { get; }
        int PartySize { get; }

        void MarkSeated();
    }
}
