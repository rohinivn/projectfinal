using System;

namespace FlightTicketBooking
{
    class FlightManager
    {
        bool status;
        byte check;
        internal void GetFlightDetails()
        {
            try
            {
                Console.Write("Enter Flight Name : ");
                FlightCollection.flight.FlightName = Console.ReadLine();
                //string name = passenger.PassengerName;
                while (Validator.UserNameValidator(FlightCollection.flight.FlightName))
                {
                    Console.WriteLine("Invalid name");
                    FlightCollection.flight.FlightName = Console.ReadLine();
                }

                Console.Write("Enter StartLocation : ");
                FlightCollection.flight.StartLocation = Console.ReadLine();
                while (Validator.UserNameValidator(FlightCollection.flight.StartLocation))
                {
                    Console.WriteLine("Invalid name");
                    FlightCollection.flight.StartLocation = Console.ReadLine();
                }

                Console.Write("Enter TargetLocation : ");
                FlightCollection.flight.TargetLocation = Console.ReadLine();
                while (Validator.UserNameValidator(FlightCollection.flight.TargetLocation))
                {
                    Console.WriteLine("Invalid name");
                    FlightCollection.flight.TargetLocation = Console.ReadLine();
                }

                Console.Write("Enter Total Available Ticket : ");
                status = byte.TryParse(Console.ReadLine(), out byte availableTicket);
                if (status)
                    FlightCollection.flight.AvailableTickets = availableTicket;
                else
                {
                    Console.WriteLine("Not an valid!!");
                    FlightCollection.flight.AvailableTickets = byte.Parse(Console.ReadLine());
                }

                Console.Write("Enter the Price per Ticket : ");
                status = float.TryParse(Console.ReadLine(), out float price);
                if (status)
                    FlightCollection.flight.TicketPrice = price;
                else
                {
                    Console.WriteLine("Not an valid!!");
                    FlightCollection.flight.TicketPrice = byte.Parse(Console.ReadLine());
                }


                Flight flight=new Flight(FlightCollection.flight.FlightName, FlightCollection.flight.StartLocation, FlightCollection.flight.TargetLocation, FlightCollection.flight.AvailableTickets, FlightCollection.flight.TicketPrice);
                EntryPortal.flightCollection.AddFlightDetails(flight);
            }
            catch (FormatException exception)
            {
                Console.WriteLine("Please enter valid Format", exception.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        internal void RemoveFlightDetails()
        {
            try
            {
                Console.Write("Enter the flight id you want to remove : ");
                status = int.TryParse(Console.ReadLine(), out int index);
                if (status)
                {
                    EntryPortal.flightCollection.RemoveFlightDetails(index);
                }
                else
                    Console.WriteLine("Please enter valid index!!");
            }
            catch (Exception exception)
            {
                Console.WriteLine("Something went wrong", exception.Message);
            }
        }

        internal void ModifyFlightDetails()
        {
            try
            {
                Console.Write("Enter the flight id you want to modify : ");
                status = int.TryParse(Console.ReadLine(), out int index);
                if (status)
                {
                    EntryPortal.flightCollection.ModifyFlightDetails(index);
                }
                else
                    Console.WriteLine("Please enter valid index!!");
            }
            catch (Exception exception)
            {
                Console.WriteLine("Something went wrong", exception.Message);
            }
        }
    }
}
