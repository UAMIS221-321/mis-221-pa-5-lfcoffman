
namespace mis_221_pa_5_lfcoffman
{
    public class ListingUtility
    {
        //Listing Function
        //Listing ID, Trainer Name, Session Date/Time/Cost, Listing Taken/Open
        static List<Listing> listings = new List<Listing>();
        //no arg contructor
        public ListingUtility()
        {

        }
        public static List<Listing> ReadAllListings()
        {
            List<Listing> listings = new List<Listing>();
            //open file
            StreamReader inFile = new StreamReader("listings.txt");
            //process file (needs to be in loop to read in one line at a time)
            string line = inFile.ReadLine(); //priming read
            while(line != null)
            {
                string[] temp = line.Split("#"); //splits up each line and stores data in new temp array
                int listingID = int.Parse(temp[0]);
                string trainerName = temp[1];
                DateTime sessionDate = DateTime.Parse(temp[2]);
                TimeSpan sessionTime = TimeSpan.Parse(temp[3]);
                double sessionCost = double.Parse(temp[4]);
                bool sessionClosed = bool.Parse(temp[5]);
                Listing listing = new Listing(listingID, trainerName, sessionDate, sessionTime, sessionCost, sessionClosed);
                listings.Add(listing);
                line = inFile.ReadLine(); //update read (reads all data from one line at a time)
            }
            //close file
            inFile.Close();
            return listings;
        }

        public static void ManageListingsMenu(List<Listing> listings)
        {
            System.Console.WriteLine("\x1B[0m" + "Manage Listing Information" + "\x1B[0m");
            System.Console.WriteLine("Enter 1 to add a new listing");
            System.Console.WriteLine("Enter 2 to edit a listing");
            System.Console.WriteLine("Enter 3 to delete a listing");
            string listingMenuInput = Console.ReadLine();
            if(listingMenuInput == "1")
            {
                AddListing(listings);
            }
            else if(listingMenuInput == "2")
            {
                EditListing(listings);
            }
            else if(listingMenuInput == "3")
            {
                RemoveListing(listings);
            }
            else
            {
                System.Console.WriteLine("Please enter a valid input");
                ManageListingsMenu(listings);
            }
        }
        public static void AddListing(List<Listing> listings)
        {
            //Allows user to enter/add new listing data
            System.Console.WriteLine("\x1B[0m" + "Add New Listing" + "\x1B[0m");
            System.Console.WriteLine("Enter Listing's ID ");
            int listingID = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Enter Listing Trainer's Name");
            string trainerName = Console.ReadLine();
            System.Console.WriteLine("Enter the Date of the Session (mm/dd/yyyy) ");
            DateTime sessionDate = DateTime.Parse(Console.ReadLine());
            System.Console.WriteLine("Enter the Time of the Session (hh:mm) ");
            TimeSpan sessionTime = TimeSpan.Parse(Console.ReadLine());
            System.Console.WriteLine("Enter the Cost of the Session");
            double sessionCost = double.Parse(Console.ReadLine());
            bool sessionClosed = false;
            Listing listing = new Listing(listingID, trainerName, sessionDate, sessionTime, sessionCost, sessionClosed);
            listings.Add(listing);
            WriteAllListings(listings);
        }
        public static void EditListing(List<Listing> listings)
        {
            //Allows user to edit existing listing data
            System.Console.WriteLine("\x1B[0m" + "Edit Listing" + "\x1B[0m");
            System.Console.WriteLine("Enter Listing ID to edit that listing");
            int listingID = int.Parse(Console.ReadLine());
            //Finds listing that corresponds to ID input
            int index = FindListing(listingID);
            if(index == -1)
            {
                System.Console.WriteLine("Listing ID you entered does not exist!");
            }
            else
            {
                System.Console.WriteLine("Which element of this listing would you like to edit?");
                System.Console.WriteLine("Press 1 for Trainer Name");
                System.Console.WriteLine("Press 2 for Session Date");
                System.Console.WriteLine("Press 3 for Session Time");
                System.Console.WriteLine("Press 4 for Session Cost");
                System.Console.WriteLine("Press 5 for Session Status");
                string menuInput = Console.ReadLine();
                if(menuInput == "1")
                {
                    System.Console.WriteLine("Enter the new Trainer Name");
                    string trainerName = Console.ReadLine();
                    listings[index].SetTrainerName(trainerName);
                }
                else if(menuInput == "2")
                {
                    System.Console.WriteLine("Enter the new Session Date");
                    DateTime sessionDate = DateTime.Parse(Console.ReadLine());
                    listings[index].SetSessionDate(sessionDate);
                }
                else if(menuInput == "3")
                {
                    System.Console.WriteLine("Enter the new Session Time");
                    TimeSpan sessionTime = TimeSpan.Parse(Console.ReadLine());
                    listings[index].SetSessionTime(sessionTime);
                }
                else if(menuInput == "4")
                {
                    System.Console.WriteLine("Enter the new Session Cost");
                    double sessionCost = double.Parse(Console.ReadLine());
                    listings[index].SetSessionCost(sessionCost);
                }
                else if(menuInput == "5")
                {
                    if(listings[index].GetSessionClosed() == true)
                    {
                        listings[index].SetSessionClosed(false);
                        System.Console.WriteLine("Listing changed to Available");
                    }
                    else if(listings[index].GetSessionClosed() == false)
                    {
                        listings[index].SetSessionClosed(true);
                        System.Console.WriteLine("Listing changed to Unavailable");
                    }
                }
                else
                {
                    System.Console.WriteLine("Please enter a valid input");
                    EditListing(listings);
                }
                WriteAllListings(listings);
            }
        }
        public static void RemoveListing(List<Listing> listings)
        {
            
        }
        public static void WriteAllListings(List<Listing> listings)
        {
            //open up listings file
            StreamWriter outFile = new StreamWriter("listings.txt");
            //write every line in listings out to file
            for(int i = 0; i < listings.Count; i++)
            {
                Listing listing = listings[i];
                outFile.Write(listing.GetListingID() + "#"); 
                outFile.Write(listing.GetTrainerName() + "#");
                outFile.Write(listing.GetSessionDate().ToString() + "#");
                outFile.Write(listing.GetSessionTime().ToString() + "#");
                outFile.Write(listing.GetSessionCost().ToString() + "#");
                outFile.Write(listing.GetSessionClosed().ToString());
            }
            //close listings file
            outFile.Close();
        }
        public static int FindListing(int searchVal)
        {
            //open up listings file
            StreamReader inFile = new StreamReader("listings.txt");
            //read every line in listings in from file
            int i = 0;
            string line = inFile.ReadLine(); //priming read
            while(line != null)
            {
                string[] temp = line.Split("#");
                int listingID = int.Parse(temp[0]);
                if(listingID == searchVal)
                {
                    return i;
                }
                // string TrainerName = temp[1];
                // DateTime sessionDate = DateTime.Parse(temp[2]);
                // TimeSpan sessionTime = TimeSpan.Parse(temp[3]);
                // double sessionCost = double.Parse(temp[4]);
                // bool sessionClosed = bool.Parse(temp[5]);
            }
            inFile.Close();
            return -1;
        }
    }
}