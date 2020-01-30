using System;
namespace FlightTicketBooking
{
    class UserManager
    {
        bool status;
        byte check;
        FlightManager flightManager = new FlightManager();
        internal void BindingUserAccessability()
        {
            if (PassengerCollection.UserRole == (byte)(UserType.Admin))
                BindingAdminAccessability();
            else
                BindingPassengerAccessability();
        }

        private void BindingAdminAccessability()
        {
            try
            {
                Console.WriteLine("Select 1 for AddingFlight,2 for DisplayingFlights, 3 for DeletingFlightDetails ,4 for UpdatingFlightDetails,5 for DisplayPassengerDetails");
                status = byte.TryParse(Console.ReadLine(), out byte choice);
                if (status)
                {
                    do
                    {
                        switch (choice)
                        {
                            case (byte)(AdminChoice.AddingFlightDetails):
                                flightManager.GetFlightDetails();
                                break;
                            case (byte)(AdminChoice.DisplayingFlightDetails):
                                EntryPortal.flightCollection.ViewAvailableFlightDetails();
                                break;
                            case (byte)(AdminChoice.DeletingFlightDetails):
                                flightManager.RemoveFlightDetails();
                                break;
                            case (byte)(AdminChoice.UpdatingFlightDetails):
                                flightManager.ModifyFlightDetails();
                                break;
                            case (byte)(AdminChoice.ViewPassengerDetails):
                                EntryPortal.passengerCollection.ViewPassengerDetails();
                                break;
                            default:
                                Console.WriteLine("Please enter valid choice!!");
                                break;
                        }
                        Console.WriteLine("Do you want to continue 1 for yes, 0 for no ?? ");
                        check = byte.Parse(Console.ReadLine());
                    } while (check == (byte)RepeatCheck.Yes);
                }
                else
                    Console.WriteLine("Please enter valid number!!");
            }
            catch (FormatException exception)
            {
                Console.WriteLine("Something went wrong", exception.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Something went wrong", exception.Message);
            }
        }

        private void BindingPassengerAccessability()
        {
            try
            {
                Console.WriteLine("Select 1 for DisplayAvailableFlights, 2 for BookTicket, 3 for UpdatingPassengerDetails, 4 for CancelingTicket, 5 for PreviewDetails 6 for Removing Passengers, 7 for Searching fights by loation");
                status = byte.TryParse(Console.ReadLine(), out byte choice);
                if (status)
                {
                    do
                    {
                        switch (choice)
                        {
                            case (byte)(UserChoice.DisplayAvailableFlights):
                                EntryPortal.flightCollection.ViewAvailableFlightDetails();
                                break;
                            case (byte)(UserChoice.BookTicket):
                                EntryPortal.bookTicket.TicketReservation();
                                break;
                            case (byte)(UserChoice.UpdatingPassengerDetails):
                                ModifyPassengerDetails();
                                break;
                            case (byte)(UserChoice.CancelingTicket):
                                EntryPortal.bookTicket.CancelTicket();
                                break;
                            case (byte)(UserChoice.PreviewDetails):
                                EntryPortal.bookTicket.PreviewTicketDetails();
                                break;
                            case (byte)(UserChoice.DeletePassengerDetails):
                                RemovePassengerDetails();
                                break;
                            case (byte)(UserChoice.SearchingFlightsByLocation):
                                string source = Console.ReadLine();
                                string target = Console.ReadLine();
                                EntryPortal.bookTicket.SearchByLocation(source, target);
                                break;
                            default:
                                Console.WriteLine("Please enter valid choice!!");
                                break;
                        }
                        Console.WriteLine("Do you want to continue 1 for yes, 0 for no ?? ");
                        check = byte.Parse(Console.ReadLine());
                    } while (check == (byte)RepeatCheck.Yes);
                }
                else
                    Console.WriteLine("Please enter valid number!!");
            }
            catch (FormatException exception)
            {
                Console.WriteLine("Something went wrong", exception.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Something went wrong", exception.Message);
            }
        }

        internal void ModifyPassengerDetails()
        {
            try
            {
                Console.Write("Enter the passenger id you want to modify : ");
                status = int.TryParse(Console.ReadLine(), out int index);
                if (status)
                {
                    EntryPortal.passengerCollection.ModifyPassengerDetails(index);
                }
                else
                    Console.WriteLine("Please enter valid index!!");
            }
            catch (Exception exception)
            {
                Console.WriteLine("Something went wrong", exception.Message);
            }
        }



        internal void RemovePassengerDetails()
        {
            try
            {
                Console.Write("Enter the Passenger id you want to remove : ");
                status = int.TryParse(Console.ReadLine(), out int index);
                if (status)
                {
                    EntryPortal.passengerCollection.RemovePassengerDetails(index);
                }
                else
                    Console.WriteLine("Please enter valid Id!!");
            }
            catch (Exception exception)
            {
                Console.WriteLine("Something went wrong", exception.Message);
            }
        }

    }
}
