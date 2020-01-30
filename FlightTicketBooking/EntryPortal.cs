using System;
namespace FlightTicketBooking
{
    class EntryPortal
    {
        internal static FlightCollection flightCollection = new FlightCollection();
        internal static PassengerCollection passengerCollection = new PassengerCollection();
        internal static BookTicket bookTicket = new BookTicket();
        internal static LoginAndSignUpManager loginAndSignUpManager = new LoginAndSignUpManager();
        UserManager userManager = new UserManager();

        internal void GetUserRole()
        {
            try
            {
                Console.WriteLine("\t\t------Welocome-----");
                Console.WriteLine("Select 1 for admin , 2 for newuser");
                bool status = byte.TryParse(Console.ReadLine(), out byte choice);
                if (status)
                {
                    if (choice.Equals((byte)UserType.Admin))
                        loginAndSignUpManager.Login();
                    else if (choice.Equals((byte)UserType.User))
                    {
                        loginAndSignUpManager.SingUp();
                        Console.WriteLine("----Welcome Passenger----");
                        Console.WriteLine("Do yo want to Proceed?? 1 for Yes ,0 for No");
                        status = byte.TryParse(Console.ReadLine(), out byte check);
                        if (status)
                        {
                            while (check == (byte)RepeatCheck.Yes)
                            {
                                userManager.BindingUserAccessability();
                            }
                        }
                        else
                            Console.WriteLine("Please enter valid number!!");
                    }
                    else
                        Console.WriteLine("No such user exists!!!");

                }
                else
                    Console.WriteLine("Not an Valid usertype");
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
    }
}
