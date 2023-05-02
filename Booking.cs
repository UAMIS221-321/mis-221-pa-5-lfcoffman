
namespace mis_221_pa_5_lfcoffman
{
    public class Booking
    {
        //Booking Function
        //View available training session, book a session, trainer status
        //Session includes Session ID, Customer Name/Email, Training Date, Trainer ID/Name/Status
        //Status should be initially set to booked, updated to completed after completion or cancelled if cancelled
        private int sessionID;
        private string customerName;
        private string customerEmail;
        private DateTime sessionDate;
        private int trainerID;
        private string trainerName;
        private bool sessionClosed;
        
        public Booking(int sessionID, string customerName, string customerEmail, DateTime sessionDate, int trainerID, string trainerName, bool sessionClosed)
        {
            this.sessionID = sessionID;
            this.customerName = customerName;
            this.customerEmail = customerEmail;
            this.sessionDate = sessionDate;
            this.trainerID = trainerID;
            this.trainerName = trainerName;
            this.sessionClosed = sessionClosed;
        }
        //default constructor
        public Booking()
        {

        }
        public int GetSessionID()
        {
            return sessionID;
        }
        public void SetSessionID(int sessionID)
        {
            this.sessionID = sessionID;
        }
        public string GetCustomerName()
        {
            return customerName;
        }
        public void SetCusomerName(string customerName)
        {
            this.customerName = customerName;
        }
        public string GetCustomerEmail()
        {
            return customerEmail;
        }
        public void SetCusomerEmail(string customerEmail)
        {
            this.customerEmail = customerEmail;
        }
        public DateTime GetSessionDate()
        {
            return sessionDate;
        }
        public void SetSessionDate(DateTime sessionDate)
        {
            this.sessionDate = sessionDate;
        }
        public int GetTrainerID()
        {
            return trainerID;
        }
        public void SetTrainerID(int trainerID)
        {
            this.trainerID = trainerID;
        }
        public string GetTrainerName()
        {
            return trainerName;
        }
        public void SetTrainerName(string trainerName)
        {
            this.trainerName = trainerName;
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