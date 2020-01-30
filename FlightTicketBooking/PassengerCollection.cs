using System;
using System.Collections.Generic;
using System.Configuration;

namespace FlightTicketBooking
{
    class PassengerCollection
    {
        internal static Dictionary<int, Passenger> passengerList = new Dictionary<int, Passenger>();
        bool status;
        byte check;
        public static byte UserRole { set; get; }
        UserManager userManager = new UserManager();

        static PassengerCollection()
        {
            passengerList.Add(1, new Passenger("Rohini", "rohini@gmail.com", 20, 'f', "Rohini!1", "9894692925"));
            passengerList.Add(2, new Passenger("varshini", "varshini@gmail.com", 21, 'f', "Varshini!2", "9344800872"));
            passengerList.Add(3, new Passenger("adhav", "adhav@gmail.com", 3, 'm', "Adhav!!23", "124567789"));
        }


        internal static string adminName = ConfigurationManager.AppSettings["userName"].ToString().ToLower();
        internal static string adminPassword = ConfigurationManager.AppSettings["password"].ToString().ToLower();
        internal byte CheckUserCredentials(string name, string password)
        {
            try
            {
                if (name.Equals(adminName) && password.Equals(adminPassword))
                {
                    UserRole = (byte)UserType.Admin;
                    Console.WriteLine("----Welcome Admin----");
                    Console.WriteLine("Do yo want to Proceed?? 1 for Yes ,0 for No");
                    status = byte.TryParse(Console.ReadLine(), out check);
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
                {
                    UserRole = (byte)UserType.User;
                    foreach (var passenger in PassengerCollection.passengerList)
                    {
                        if (passenger.Value.PassengerName == name && passenger.Value.Password == password)
                        {
                            Console.WriteLine("-----Existing Passenger-----");
                            Console.WriteLine("Do yo want to Proceed?? 1 for Yes ,0 for No");
                            status = byte.TryParse(Console.ReadLine(), out check);
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
                        {
                            EntryPortal.loginAndSignUpManager.SingUp();
                            EntryPortal.loginAndSignUpManager.Login();
                        }
                    }
                }
            }
            catch (NullReferenceException exception)
            {
                Console.WriteLine("Something went wrong", exception.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Something went wrong", exception.Message);
            }
            return UserRole;
        }
        internal void ModifyPassengerDetails(int index)
        {
            try
            {
                do
                    {
                        Console.WriteLine("Select 1 for PassengerName,2 for Age,3 for Gender,4 for Password,5 for PhoneNumber, 6 for EmailId");
                        status = byte.TryParse(Console.ReadLine(), out byte choice);
                        if (status)
                        {
                            switch (choice)
                            {
                                case (byte)(UpdatePassengerChoice.PassengerName):
                                    PassengerCollection.passengerList[index].PassengerName = Console.ReadLine();
                                    break;
                                case (byte)(UpdatePassengerChoice.Age):
                                    PassengerCollection.passengerList[index].Age = byte.Parse(Console.ReadLine());
                                    break;
                                case (byte)(UpdatePassengerChoice.Gender):
                                    PassengerCollection.passengerList[index].Gender = char.Parse(Console.ReadLine());
                                    break;
                                case (byte)(UpdatePassengerChoice.Password):
                                    PassengerCollection.passengerList[index].Password = Console.ReadLine();
                                    break;
                                case (byte)(UpdatePassengerChoice.PhoneNumber):
                                    PassengerCollection.passengerList[index].PhoneNo = Console.ReadLine();
                                    break;
                                case (byte)(UpdatePassengerChoice.EmailId):
                                    PassengerCollection.passengerList[index].EmailId = Console.ReadLine();
                                    break;
                                default:
                                    Console.WriteLine("Please enter valid choice!!");
                                    break;
                            }
                            Console.WriteLine("Do you want to continue 1 for yes, 0 for no ?? ");
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



        internal void RemovePassengerDetails(int index)
        {
            try
            {
                    PassengerCollection.passengerList.Remove(index);
             }
            catch (Exception exception)
            {
                Console.WriteLine("Something went wrong", exception.Message);
            }
        }
        internal void ViewPassengerDetails()
        {
            try
            {
                foreach (KeyValuePair<int, Passenger> keyValuePair in PassengerCollection.passengerList)
                {
                    Passenger passenger = keyValuePair.Value;
                    Console.WriteLine("Passenger Id : {0} , Passenger Name : {1} , Passenger Age : {2} , Gender : {3} , EmailID : {4} , PhoneNumber: {5}", keyValuePair.Key, passenger.PassengerName, passenger.Age, passenger.Gender, passenger.EmailId, passenger.PhoneNo);
                }
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
    }
}
