
namespace mis_221_pa_5_lfcoffman
{
    public class BookingUtility
    {
        static List<Booking> bookings = new List<Booking>();
        //Booking Function
        //View available training session, book a session, trainer status
        //Session includes Session ID, Customer Name/Email, Training Date, Trainer ID/Name/Status
        //Status should be initially set to booked, updated to completed after completion or cancelled if cancelled
        public static List<Booking> ReadAllBookings()
        {
            List<Booking> bookings = new List<Booking>();
            //open file
            StreamReader inFile = new StreamReader("transactions.txt");
            //process file (needs to be in loop to read in one line at a time)
            string line = inFile.ReadLine(); //priming read
            while(line != null)
            {
                string[] temp = line.Split("#"); //splits up each line and stores data in new temp array
                string sessionID = temp[0];
                string customerName = temp[1];
                string customerEmail = temp[2];
                DateTime sessionDate = DateTime.Parse(temp[3]);
                string trainerID = temp[4];
                string trainerName = temp[5];
                bool sessionClosed = bool.Parse(temp[6]);
                Booking booking = new Booking();//trainerID, trainerName, trainerEmail, trainerMail
                bookings.Add(booking);
                line = inFile.ReadLine(); //update read (reads all data from one line at a time)
            }
            //close file
            inFile.Close();
            return bookings;
        }

        public static void ManageBookingsMenu(List<Booking> bookings)
        {
            System.Console.WriteLine("\x1B[0m" + "Manage Booking Information" + "\x1B[0m");
            System.Console.WriteLine("Enter 1 to View Available Training Sessions");
            System.Console.WriteLine("Enter 2 to Book a Session");
            string bookingMenuInput = Console.ReadLine();
            if(bookingMenuInput == "1")
            {
                ViewAvailableSessions();
            }
            else if(bookingMenuInput == "2")
            {
                BookSession();
            }
            else
            {
                System.Console.WriteLine("Please enter a valid input");
                ManageBookingsMenu(bookings);
            }
        }

        public static void ViewAvailableSessions()
        {
            System.Console.WriteLine("\x1B[0m" + "Available Sessions" + "\x1B[0m");
        }

        public static void BookSession()
        {
            //Allows user to enter/add new session data
            System.Console.WriteLine("\x1B[0m" + "Book Session" + "\x1B[0m");
            System.Console.WriteLine("Enter Session's ID ");
            int sessionID = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Enter Customer's Name");
            string customerName = Console.ReadLine();
            System.Console.WriteLine("Enter Customer's Email");
            string customerEmail = Console.ReadLine();
            System.Console.WriteLine("Enter the Date of the Session (mm/dd/yyyy) ");
            DateTime sessionDate = DateTime.Parse(Console.ReadLine());
            System.Console.WriteLine("Enter Trainer's ID ");
            int trainerID = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Enter Trainer's Name");
            string trainerName = Console.ReadLine();
            bool sessionClosed = false;
            Booking booking = new Booking(sessionID, customerName, customerEmail, sessionDate, trainerID, trainerName, sessionClosed);
            BookingUtility.AddBooking(booking);
        }
        public static void AddBooking(Booking booking)
        {
            StreamWriter outFile = new StreamWriter("transactions.txt");
            for(int i = 0; i < GetBookingLength(); i++)
            {
                outFile.Write(bookings[i].GetSessionID() + "#"); 
                outFile.Write(bookings[i].GetCustomerName() + "#");
                outFile.Write(bookings[i].GetCustomerEmail() + "#");
                outFile.Write(bookings[i].GetSessionDate() + "#");
                outFile.Write(bookings[i].GetTrainerID() + "#"); 
                outFile.Write(bookings[i].GetTrainerName() + "#");
                outFile.Write(bookings[i].GetSessionClosed() + "#"); 
            }
            outFile.Write(booking.GetSessionID() + "#"); 
            outFile.Write(booking.GetCustomerName() + "#");
            outFile.Write(booking.GetCustomerEmail() + "#");
            outFile.Write(booking.GetSessionDate() + "#");
            outFile.Write(booking.GetTrainerID() + "#"); 
            outFile.Write(booking.GetTrainerName() + "#");
            outFile.Write(booking.GetSessionClosed() + "#"); 
            //close trainers file
            outFile.Close();
        }
        public static int SearchEmail(string customerEmail)
        {
            int count = 0; 
            StreamReader inFile = new StreamReader("transactions.txt");          //open file
            string line = inFile.ReadLine();
            while(line!= null)
            {
                string [] temp = line.Split("#");
                if(temp[2] == customerEmail)
                {
                    return count;
                }
                count++;
                line = inFile.ReadLine();                             //update
            }
            inFile.Close();                                     //close file
            return -1;
        }
        public static int GetBookingLength()
        {
            int count = 1;
            while(1 == 1)
            {
                if(bookings[count] == null)
                {
                    break;
                }
                count++;
            }
            return count;
        }
    }
}