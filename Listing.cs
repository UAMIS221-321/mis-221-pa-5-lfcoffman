
namespace mis_221_pa_5_lfcoffman
{
    public class Listing
    {
        //Listing Function
        //Listing ID, Trainer Name, Session Date/Time/Cost, Listing Taken/Open
        //Listing instance variables
        private int listingID;
        private string trainerName;
        private DateTime sessionDate;
        private TimeSpan sessionTime;
        private double sessionCost;
        private bool sessionClosed;
        //no arg constructor (no return type and same name as class)
        public Listing()
        {
            
        }
        //constructor that sets all 6 instance variables
        public Listing(int listingID, string trainerName ,DateTime sessionDate, TimeSpan sessionTime,  double sessionCost, bool sessionClosed)
        {
            this.listingID = listingID;
            this.trainerName = trainerName;
            this.sessionDate = sessionDate.Date;
            this.sessionTime = sessionTime;
            this.sessionCost = sessionCost;
            this.sessionClosed = sessionClosed;
        }
        //Accessors and mutators
        public int GetListingID()
        {
            return listingID;
        }
        public void SetListingID(int listingID)
        {
            this.listingID = listingID;
        }
        public string GetTrainerName()
        {
            return trainerName;
        }
        public void SetTrainerName(string trainerName)
        {
            this.trainerName = trainerName;
        }
        public DateTime GetSessionDate()
        {
            return sessionDate;
        }
        public void SetSessionDate(DateTime sessionDate)
        {
            this.sessionDate = sessionDate;
        }
        public TimeSpan GetSessionTime()
        {
            return sessionTime;
        }
        public void SetSessionTime(TimeSpan sessionTime)
        {
            this.sessionTime = sessionTime;
        }
        public double GetSessionCost()
        {
            return sessionCost;
        }
        public void SetSessionCost(double sessionCost)
        {
            this.sessionCost = sessionCost;
        }
        public bool GetSessionClosed()
        {
            return sessionClosed;
        }
        public void SetSessionClosed(bool sessionClosed)
        {
            this.sessionClosed = sessionClosed;
        }
    }
}