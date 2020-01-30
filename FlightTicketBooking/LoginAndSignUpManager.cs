using System;
namespace FlightTicketBooking
{
    class LoginAndSignUpManager
    {
        
        public string Name { set; get; }
        public string Password { set; get; }

        Passenger passenger = new Passenger();
        private static int passengerId;

        static LoginAndSignUpManager()
        {
            passengerId = PassengerCollection.passengerList.Count;
        }


        internal void Login()
        {
            Console.WriteLine("----------Login--------");
            Console.Write("Enter the User Name : ");
            Name = Console.ReadLine();
            Console.Write("Enter the Password : ");
            Password = ReadPassword();
            PassengerCollection.UserRole = EntryPortal.passengerCollection.CheckUserCredentials(Name, Password);
        }
        internal void SingUp()
        {
            try
            {
                Console.WriteLine("------New Passenger-----");
                Console.Write("Enter PassengerName : ");
                passenger.PassengerName = Console.ReadLine();
                //string name = passenger.PassengerName;
                while (Validator.UserNameValidator(passenger.PassengerName))
                {
                    Console.WriteLine("Invalid name");
                    passenger.PassengerName = Console.ReadLine();
                }

                Console.Write("Enter Mail ID : ");
                passenger.EmailId = Console.ReadLine();
                while (Validator.EmailIdValidator(passenger.EmailId))
                {
                    Console.WriteLine("Invalid mail ID");
                    passenger.EmailId = Console.ReadLine();
                }

                Console.Write("Enter the Age : ");
                bool status = byte.TryParse(Console.ReadLine(), out byte age);
                if (status)
                    passenger.Age = age;
                else
                {
                    Console.WriteLine("Not an valid age!!");
                    passenger.Age = byte.Parse(Console.ReadLine());
                }

                Console.Write("Enter the gender(m/f) : ");
                status = char.TryParse(Console.ReadLine(), out char gender);
                if (status)
                    passenger.Gender = gender;
                else
                {
                    Console.WriteLine("Not an valid gender!!");
                    passenger.Gender = char.Parse(Console.ReadLine());
                }
                Console.Write("Enter the password : ");
                passenger.Password = ReadPassword();
                //string password=string.Empty;
                while (Validator.PasswordValidator(passenger.Password))
                {
                    Console.WriteLine("Your password is invalid ....Password must contain one capital letter,one small letter,one special character and a digit");
                    passenger.Password = ReadPassword();
                    //password = passenger.Password;
                }

                Console.Write("Enter the phone number : ");
                passenger.PhoneNo = Console.ReadLine();
                while (Validator.PhoneNumberValidator(passenger.PhoneNo))
                {
                    Console.WriteLine("Your phonenumber is invalid....");
                    passenger.PhoneNo = Console.ReadLine();
                }
                //foreach (var passengerCollection in PassengerCollection.passengerList)
                //{
                //    if (!(passengerCollection.Value.PassengerName == Name && passengerCollection.Value.Password == Password))
                //    {
                       PassengerCollection.passengerList.Add(++passengerId, new Passenger(passenger.PassengerName, passenger.EmailId, passenger.Age, passenger.Gender, passenger.Password, passenger.PhoneNo));
                //    break;
                //}
                //else
                //{
                //Console.WriteLine("Passenger already exist!!!");
                //    break;
                //}
                //}
                PassengerCollection.UserRole = (byte)(UserType.User);
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
        private static string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    Console.Write("@");
                    password += info.KeyChar;
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(password))
                    {
                        // remove one character from the list of password characters
                        password = password.Substring(0, password.Length - 1);
                        // get the location of the cursor
                        int pos = Console.CursorLeft;
                        // move the cursor to the left by one character
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                        // replace it with space
                        Console.Write(" ");
                        // move the cursor to the left by one character again
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                    }
                }
                info = Console.ReadKey(true);
            }

            // add a new line because user pressed enter at the end of their password
            Console.WriteLine();
            return password;
        }

    }
}
