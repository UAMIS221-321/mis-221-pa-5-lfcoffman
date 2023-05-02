using mis_221_pa_5_lfcoffman;
using System.IO;
namespace mis_221_pa_5_lfcoffman
{
    class Program
    {
        static void Main()
        {
            List<Trainer> trainerList = new List<Trainer>();
            List<Booking> bookings = new List<Booking>();
            List<Listing> listings = new List<Listing>();
            // // TrainerUtility trainerUtility = new TrainerUtility(trainerList);
            // // ListingUtility listingUtility = new ListingUtility();
            // // BookingUtility bookingUtility = new BookingUtility();
            // //Displays Main Menu to user
            System.Console.WriteLine("Press 1 to Manage Trainer Data");
            System.Console.WriteLine("Press 2 to Manage Listing Data");
            System.Console.WriteLine("Press 3 to Manage Customer Booking Data");
            System.Console.WriteLine("Press 4 to Run Reports");
            System.Console.WriteLine("Press 5 to Exit Application");
            string menuInput = Console.ReadLine();
            if(menuInput == "1")
            {
                TrainerUtility.ManageTrainersMenu();
            }
            else if(menuInput == "2")
            {
                ListingUtility.ManageListingsMenu(listings);
            }
            else if(menuInput == "3")
            {
                BookingUtility.ManageBookingsMenu(bookings);
            }
            // else if(menuInput == "4")
            // {
            //     Report.RunReports();
            // }
            else if(menuInput == "5")
            {
                TrainerUtility.WriteAllTrainers(trainerList);
                ListingUtility.WriteAllListings(listings);
                // BookingUtility.WriteAllBookings(bookings);
                System.Console.WriteLine("Program Ended");
            }
            else
            {
                System.Console.WriteLine("Please enter a valid input");
                Main();
            }
        }
    }
}
