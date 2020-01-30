using System;
using System.Collections.Generic;

namespace FlightTicketBooking
{
    class FlightCollection
    {
        internal static Dictionary<int, Flight> flightList = new Dictionary<int, Flight>();
        public static int flightId;
        internal static Flight flight = new Flight();
        byte check;
        bool status;
        internal static bool displayFlag;
        static FlightCollection()
        {
            flightList.Add(1, new Flight("King", "Cbe", "Chennai", 70, 1000));
            flightList.Add(2, new Flight("Kingfisher", "Chennai", "cbe", 70, 1400));
            flightList.Add(3, new Flight("Boat", "Cbe", "Chennai", 70, 1020));
            flightId = flightList.Count;
        }
        
        internal void AddFlightDetails(Flight flight)
        {
            
                FlightCollection.flightList.Add(++flightId, new Flight(flight.FlightName, flight.StartLocation, flight.TargetLocation, flight.AvailableTickets, flight.TicketPrice));
        }

        internal void ViewAvailableFlightDetails()
        {
            try
            {
                Console.WriteLine("\t\tAvailable Flights");
                foreach (KeyValuePair<int, Flight> keyValuePair in FlightCollection.flightList)
                {
                    Flight flight = keyValuePair.Value;
                    Console.WriteLine("Flight Id : {0} , Flight Name : {1} , StartLocation : {2} , TargetLocation : {3} , Available Tickets : {4} , Ticket Cost : {5}", keyValuePair.Key, flight.FlightName, flight.StartLocation, flight.TargetLocation, flight.AvailableTickets, flight.TicketPrice);

                }
                displayFlag = true;
            }
            catch (NullReferenceException exception)
            {
                Console.WriteLine("Something went wrong", exception.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Something went wrong", exception.Message);
            }
        }

        internal void RemoveFlightDetails(int index)
        {   
            FlightCollection.flightList.Remove(index);
        }

        internal void ModifyFlightDetails(int index)
        {
            try
            {
                    do
                    {
                        Console.WriteLine("Select 1 for FlightName,2 for StartLocation,3 for TargetLocation,4 for AvailableTickets,5 for TicketPrice");
                        status = byte.TryParse(Console.ReadLine(), out byte choice);
                        if (status)
                        {
                            switch (choice)
                            {
                                case (byte)(UpdateFlightChoice.FlightName):
                                    FlightCollection.flightList[index].FlightName = Console.ReadLine();
                                    break;
                                case (byte)(UpdateFlightChoice.StartLocation):
                                    FlightCollection.flightList[index].StartLocation = Console.ReadLine();
                                    break;
                                case (byte)(UpdateFlightChoice.TargetLocation):
                                    FlightCollection.flightList[index].TargetLocation = Console.ReadLine();
                                    break;
                                case (byte)(UpdateFlightChoice.AvailableTickets):
                                    FlightCollection.flightList[index].AvailableTickets = byte.Parse(Console.ReadLine());
                                    break;
                                case (byte)(UpdateFlightChoice.TicketPrice):
                                    FlightCollection.flightList[index].TicketPrice = float.Parse(Console.ReadLine());
                                    break;
                                default:
                                    Console.WriteLine("Please enter valid choice!!");
                                    break;
                            }
                            Console.WriteLine("Do you want to continue Updating 1 for yes, 0 for no ?? ");
                            check = byte.Parse(Console.ReadLine());
                        }
                        else
                            Console.WriteLine("Please enter valid integer!!");
                    } while (check == (byte)RepeatCheck.Yes);
                }
            catch (Exception exception)
            {
                Console.WriteLine("Something went wrong", exception.Message);
            }
        }
    }
}
