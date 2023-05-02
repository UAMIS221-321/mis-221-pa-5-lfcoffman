namespace mis_221_pa_5_lfcoffman
{
    public class Trainer
    {
        //Trainer ID/Name/Email Address, Mailing Address
        //Trainer instance variables
        public int trainerID;
        public string trainerName;
        public string trainerEmail;
        public string trainerMail;

        //no arg constructor (no return type and same name as class)
        public Trainer()
        {
            
        }
        //constructor that sets all 3 instance variables
        public Trainer(int trainerID, string trainerName ,string trainerEmail, string trainerMail)
        {
            this.trainerID = trainerID;
            this.trainerName = trainerName;
            this.trainerEmail = trainerEmail;
            this.trainerMail = trainerMail;
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
        public string GetTrainerEmail()
        {
            return trainerEmail;
        }
        public void SetTrainerEmail(string trainerEmail)
        {
            this.trainerEmail = trainerEmail;
        }
        public string GetTrainerMail()
        {
            return trainerMail;
        }
        public void SetTrainerMail(string trainerMail)
        {
            this.trainerMail = trainerMail;
        }
    }
}