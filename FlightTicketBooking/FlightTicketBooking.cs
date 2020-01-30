namespace FlightTicketBooking
{
    class FlightTicketBooking
    {
        static void Main()
        {
            EntryPortal entryPortal = new EntryPortal();
            System.Console.WriteLine("\t\t\tWelcome to Flight Ticket Booking");
            EntryPortal.flightCollection.ViewAvailableFlightDetails();
            entryPortal.GetUserRole();
        }
    }
}

